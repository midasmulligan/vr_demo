#region Header
using UnityEngine;
using System.Collections.Generic;
using LitJson;
#endregion Header

#region Methods
public class Phrase
{
    public string term;
    public float  frequency;
}

public class StaticWordCloud : MonoBehaviour
{
    public GameObject childObject;
    public float size = 10.0f;
    private List<Phrase> phrases = new List<Phrase>();
    private List<Phrase> randomisedPhrases = new List<Phrase>();

    private float totalOccurances = 0.0f;

    private string jsonString = "[{'term': u'brexit', 'frequency': 46006}, {'term': u'\u2026', 'frequency': 25034}, {'term': u'#brexit', 'frequency': 13806}, {'term': u'election', 'frequency': 9414}, {'term': u'theresa', 'frequency': 7983}, {'term': u'uk', 'frequency': 6708}, {'term': u'...', 'frequency': 5890}, {'term': u'plan', 'frequency': 5747}, {'term': u'people', 'frequency': 4381}, {'term': u'eu', 'frequency': 4263}, {'term': u'#pmqs', 'frequency': 4071}, {'term': u'vote', 'frequency': 3788}, {'term': u'trump', 'frequency': 3654}, {'term': u'corbyn', 'frequency': 3436}, {'term': u'https', 'frequency': 2956}, {'term': u'means', 'frequency': 2920}, {'term': u'leave', 'frequency': 2667}, {'term': u'tories', 'frequency': 2551}, {'term': u'britain', 'frequency': 2493}, {'term': u'trade', 'frequency': 2407}]";

    void Start()
    {
        ProcessWords(jsonString);
        Sphere();
    }

    void Update()
    {
        Transform camera = Camera.main.transform;

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

            Vector3 pos = new Vector3(-20f, 2f, -10f);

            GameObject child = Instantiate(childObject, pos, Quaternion.identity) as GameObject;
            child.transform.parent = transform;
            TextMesh phraseText = child.transform.GetComponent<TextMesh>();

            Phrase phrase = randomisedPhrases[(int)i];
            phraseText.text = phrase.term;

            float scale = (phrase.frequency / totalOccurances) * 100.0f;
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
            phrase.frequency = float.Parse(jsonvale[i]["frequency"].ToString());
            phrases.Add(phrase);
            totalOccurances += phrase.frequency;
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