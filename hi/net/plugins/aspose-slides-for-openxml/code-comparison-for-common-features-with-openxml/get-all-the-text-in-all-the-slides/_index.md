---
title: सभी स्लाइड्स में सभी टेक्स्ट प्राप्त करें
type: docs
weight: 100
url: /hi/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // प्रेजेंटेशन को केवल-रीड मोड में खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // प्रेजेंटेशन को अगले CountSlides मेथड में पास करें

        // और स्लाइड गिनती लौटाएँ।

        return CountSlides(presentationDocument);

    }

}

// प्रेजेंटेशन में स्लाइड्स की गणना करें।

public static int CountSlides(PresentationDocument presentationDocument)

{

    // नल डॉक्यूमेंट ऑब्जेक्ट की जाँच करें।

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // डॉक्यूमेंट का प्रेजेंटेशन पार्ट प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts से स्लाइड गिनती प्राप्त करें।

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // स्लाइड गिनती को पिछले मेथड में लौटाएँ।

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // पहले स्लाइड का रिलेशनशिप आईडी प्राप्त करें।

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // रिलेशनशिप आईडी से स्लाइड पार्ट प्राप्त करें।

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // एक StringBuilder ऑब्जेक्ट बनाएँ।

        StringBuilder paragraphText = new StringBuilder();

        // स्लाइड का आंतरिक टेक्स्ट प्राप्त करें:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // PPTX का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंसिएट करें

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    // PPTX का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंसिएट करें

    using (Presentation pres = new Presentation(docName))

    {

        // स्लाइड तक पहुंचें
        ISlide sld = pres.Slides[index];
        // प्लेसहोल्डर खोजने के लिए शेप्स पर इटररेट करें
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {

                // प्रत्येक प्लेसहोल्डर का टेक्स्ट प्राप्त करें
                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)