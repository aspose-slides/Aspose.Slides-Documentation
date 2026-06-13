---
title: स्लाइड में सभी टेक्स्ट प्राप्त करें
type: docs
weight: 110
url: /hi/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// स्लाइड में सभी टेक्स्ट प्राप्त करें।

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // प्रस्तुति को केवल-पढ़ने के रूप में खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // प्रस्तुति और स्लाइड इंडेक्स पास करें

        // अगले GetAllTextInSlide मेथड को, और

        // फिर वह लौटाए गए स्ट्रिंग्स की एरे को रिटर्न करें।

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // सत्यापित करें कि प्रस्तुति दस्तावेज़ मौजूद है।

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // सत्यापित करें कि स्लाइड इंडेक्स सीमा के बाहर नहीं है।

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // प्रस्तुति दस्तावेज़ के प्रस्तुति भाग को प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // सत्यापित करें कि प्रस्तुति भाग और प्रस्तुति मौजूद हैं।

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // प्रस्तुति भाग से Presentation ऑब्जेक्ट प्राप्त करें।

        Presentation presentation = presentationPart.Presentation;

        // सत्यापित करें कि स्लाइड आईडी सूची मौजूद है।

        if (presentation.SlideIdList != null)

        {

            // स्लाइड आईडी सूची से स्लाइड आईडी का संग्रह प्राप्त करें।

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // यदि स्लाइड आईडी सीमा में है...

            if (slideIndex < slideIds.Count)

            {

                // स्लाइड का रिलेशनशिप आईडी प्राप्त करें।

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // रिलेशनशिप आईडी से निर्दिष्ट स्लाइड भाग प्राप्त करें।

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // स्लाइड भाग को अगले मेथड को पास करें, और

                // फिर उस मेथड द्वारा लौटाई गई स्ट्रिंग्स की एरे रिटर्न करें

                // जो पिछले मेथड को लौटती है।

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // अन्यथा, null रिटर्न करें।

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // सत्यापित करें कि स्लाइड भाग मौजूद है।

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // स्ट्रिंग्स की नई लिंक्ड लिस्ट बनाओ।

    LinkedList<string> texts = new LinkedList<string>();

    // यदि स्लाइड मौजूद है...

    if (slidePart.Slide != null)

    {

        // स्लाइड में सभी पैराग्राफ़ को इटररेट करें।

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // नया स्ट्रिंग बिल्डर बनाएं.                    

            StringBuilder paragraphText = new StringBuilder();

            // पैराग्राफ़ की लाइनों को इटररेट करें।

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // प्रत्येक लाइन को पिछले लाइनों में जोड़ें।

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // प्रत्येक पैराग्राफ को लिंक्ड लिस्ट में जोड़ें।

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // स्ट्रिंग्स की एरे रिटर्न करें।

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// स्लाइड में सभी टेक्स्ट प्राप्त करें।

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// स्ट्रिंग्स की नई लिंक्ड लिस्ट बनाएं।

List<string> texts = new List<string>();

// PPTX का प्रतिनिधित्व करने वाले PresentationEx क्लास को इंस्टैंसिएट करें

using (Presentation pres = new Presentation(presentationFile))

{

    // स्लाइड तक पहुंचें

    ISlide sld = pres.Slides[slideIndex];

    // शैप्स को इटररेट करके प्लेसहोल्डर खोजें

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // प्रत्येक प्लेसहोल्डर का टेक्स्ट प्राप्त करें

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// स्ट्रिंग्स की एरे रिटर्न करें।

return texts;

}

```
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)