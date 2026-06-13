---
title: एक प्रस्तुति में सभी बाहरी हाइपरलिंक प्राप्त करें
type: docs
weight: 90
url: /hi/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML प्रस्तुति**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// प्रस्तुति के स्लाइड्स में सभी बाहरी हाइपरलिंक लौटाता है।

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// स्ट्रिंग्स की एक सूची घोषित करें।

List<string> ret = new List<string>();

// प्रस्तुति फ़ाइल को केवल‑पढ़ने के मोड में खोलें।

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // प्रस्तुति भाग में सभी स्लाइड भागों पर इटररेट करें।

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // स्लाइड भाग में सभी लिंक पर इटररेट करें।

        foreach (Drawing.HyperlinkType link in links)

        {

            // स्लाइड भाग में सभी बाहरी रिलेशनशिप पर इटररेट करें। 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // यदि रिलेशनशिप ID लिंक ID से मेल खाता है...

                if (relation.Id.Equals(link.Id))

                {

                    // बाहरी रिलेशनशिप का URI स्ट्रिंग्स की सूची में जोड़ें।

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// स्ट्रिंग्स की सूची लौटाएँ।

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET डेवलपर्स को प्रस्तुति, स्लाइड और टेक्स्ट फ्रेम स्तर पर हाइपरलिंक प्रबंधित करने की अनुमति देता है। **IHyperlinkQueries** क्लास प्रस्तुति में हाइपरलिंक को प्रबंधित करने में मदद करती है।

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

// PPTX फ़ाइल को दर्शाने वाला Presentation ऑब्जेक्ट बनाएं

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **चल रहा कोड उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **उदाहरण कोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)