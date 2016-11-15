#region Header
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using LitJson;
#endregion Header


#region Methods
public class Phrase
{
    public   string  term;
    public   float   occurrences;
}

public class start
{
}

public class FormWordCloud : MonoBehaviour
{
    public   GameObject   childObject;
    public   GameObject   GvrCam;
    public   float        size              = 10.0f;
    private  List<Phrase> phrases           = new List<Phrase>();
    private  List<Phrase> randomisedPhrases = new List<Phrase>();

    //same data referenced in file // string jsonString = "[{'term': 'brexit', 'frequency': 46006}, {'term': '\u2026', 'frequency': 25034}, {'term': '#brexit', 'frequency': 13806}, {'term': 'election', 'frequency': 9414}, {'term': 'theresa', 'frequency': 7983}, {'term': 'uk', 'frequency': 6708}, {'term': '...', 'frequency': 5890}, {'term': 'plan', 'frequency': 5747}, {'term': 'people', 'frequency': 4381}, {'term':'eu', 'frequency': 4263}, {'term': '#pmqs', 'frequency': 4071}, {'term': 'vote', 'frequency': 3788}, {'term': 'trump', 'frequency': 3654}, {'term': 'corbyn', 'frequency': 3436}, {'term': 'https', 'frequency': 2956}, {'term': 'means', 'frequency': 2920}, {'term': 'leave', 'frequency': 2667}, {'term': 'tories', 'frequency': 2551}, {'term': 'britain', 'frequency': 2493}, {'term': 'trade', 'frequency': 2407}]";
    string jsonString = File.ReadAllText("Assets/WordCloud/sample.json");

    private float totalOccurances = 0.0f;

    void Start()
    {

        ProcessWords(jsonString);
        Sphere();
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = GvrCam.transform;

        // Tell each of the objects to look at the camera
        foreach (Transform child in transform)
        {
            child.LookAt(camera.position);
            child.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void Sphere()
    {
        float points = phrases.Count;
        float increment = Mathf.PI * (3 - Mathf.Sqrt(5));
        float offset = 2 / points;
        for (float i = 0; i < points; i++)
        {
            float y = i * offset - 1 + (offset / 2);
            float radius = Mathf.Sqrt(1 - y * y);
            float angle = i * increment;
            Vector3 pos = new Vector3((Mathf.Cos(angle) * radius * size) - 20f, y * size, (Mathf.Sin(angle) * radius * size) - 10f);

            // Create the object as a child of the sphere
            GameObject child = Instantiate(childObject, pos, Quaternion.identity) as GameObject;
            child.transform.parent = transform;
            TextMesh phraseText = child.transform.GetComponent<TextMesh>();

            Phrase phrase = randomisedPhrases[(int)i];
            phraseText.text = phrase.term;

            float scale = (phrase.occurrences / totalOccurances) * 100.0f;
            child.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void ProcessWords(string jsonString)
    {
        totalOccurances = 0.0f;

        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        for (int i = 0; i < jsonvale.Count; i++)
        {
            Phrase phrase = new Phrase();
            phrase.term = jsonvale[i]["term"].ToString();
            phrase.occurrences = float.Parse(jsonvale[i]["frequency"].ToString());
            phrases.Add(phrase);
            totalOccurances += phrase.occurrences;
        }

        System.Random random = new System.Random();
        randomisedPhrases.Clear();
        for (int i = 0; i < phrases.Count; i++)
        {
            randomisedPhrases.Add(phrases[i]);
        }

        for (int i = 0; i < randomisedPhrases.Count; i++)
        {
            int first = i;
            int second = random.Next(0, randomisedPhrases.Count);
            Phrase temp = randomisedPhrases[second];
            randomisedPhrases[second] = randomisedPhrases[first];
            randomisedPhrases[first] = temp;
        }
    }
}
#endregion Methods