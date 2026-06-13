---
title: सभी स्लाइड्स के शीर्षक प्राप्त करें
type: docs
weight: 120
url: /hi/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// प्रस्तुति में सभी स्लाइड्स के शीर्षकों की सूची प्राप्त करें।

public static IList<string> GetSlideTitles(string presentationFile)

{

    // प्रस्तुति को केवल- पढ़ने के रूप में खोलें।

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// प्रस्तुति में सभी स्लाइड्स के शीर्षकों की सूची प्राप्त करें।

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // PresentationDocument ऑब्जेक्ट से एक PresentationPart ऑब्जेक्ट प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // PresentationPart ऑब्जेक्ट से एक Presentation ऑब्जेक्ट प्राप्त करें।

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // स्लाइड क्रम में प्रत्येक स्लाइड का शीर्षक प्राप्त करें।

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // स्लाइड शीर्षक प्राप्त करें।

                string title = GetSlideTitle(slidePart);

                // एक खाली शीर्षक भी जोड़ा जा सकता है।

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// स्लाइड की शीर्षक स्ट्रिंग प्राप्त करें।

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // पैराग्राफ विभाजक घोषित करें।

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // सभी शीर्षक आकार खोजें।

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // इस आकार में प्रत्येक पैराग्राफ का पाठ प्राप्त करें।

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // एक पंक्ति विभाजन जोड़ें।

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// निर्धारित करता है कि आकार शीर्षक आकार है या नहीं।

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // कोई भी शीर्षक आकार।

            case PlaceholderValues.Title:

            // एक केंद्रित शीर्षक।

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // प्रस्तुति को केवल- पढ़ने के रूप में खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // प्रस्तुति को अगली CountSlides विधि में पास करें

        // और स्लाइड गणना लौटाएँ।

        return CountSlides(presentationDocument);

    }

}

// प्रस्तुति में स्लाइड्स की गणना करें।

public static int CountSlides(PresentationDocument presentationDocument)

{

    // जांचें कि दस्तावेज़ ऑब्जेक्ट null है या नहीं।

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // दस्तावेज़ का प्रस्तुति भाग प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts से स्लाइड गणना प्राप्त करें।

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // स्लाइड गणना को पिछले मेथड में वापस करें।

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // पहली स्लाइड का रिलेशनशिप आईडी प्राप्त करें।

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // रिलेशनशिप आईडी से स्लाइड भाग प्राप्त करें।

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // एक StringBuilder ऑब्जेक्ट बनाएं।

        StringBuilder paragraphText = new StringBuilder();

        // स्लाइड का आंतरिक पाठ प्राप्त करें:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)