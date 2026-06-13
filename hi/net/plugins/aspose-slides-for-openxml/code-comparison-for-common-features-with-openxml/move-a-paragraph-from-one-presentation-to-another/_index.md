---
title: एक प्रस्तुति से दूसरे में एक पैराग्राफ़ को ले जाएँ
type: docs
weight: 130
url: /hi/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML प्रस्तुति**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// स्रोत दस्तावेज़ में TextBody आकार में पैराग्राफ़ रेंज को ले जाता है

// लक्ष्य दस्तावेज़ में दूसरे TextBody आकार में।

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// स्रोत फ़ाइल को पढ़ने/लिखने के रूप में खोलें.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // लक्ष्य फ़ाइल को पढ़ने/लिखने के रूप में खोलें.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // स्रोत प्रस्तुति में पहली स्लाइड प्राप्त करें।

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // इसमें पहला TextBody आकार प्राप्त करें।

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // TextBody आकार में पहला पैराग्राफ प्राप्त करें।

        // नोट: "Drawing" नामस्थान DocumentFormat.OpenXml.Drawing का उपनाम है

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // लक्ष्य प्रस्तुति में पहली स्लाइड प्राप्त करें।

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // इसमें पहला TextBody आकार प्राप्त करें।

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // स्रोत पैराग्राफ को क्लोन करें और क्लोन किया हुआ पैराग्राफ लक्ष्य TextBody आकार में सम्मिलित करें।

        // "true" पास करने से गहरा क्लोन बनता है, जो 

        // पैराग्राफ ऑब्जेक्ट और उस ऑब्जेक्ट द्वारा सीधे या अप्रत्यक्ष रूप से संदर्भित सभी चीज़ों की कॉपी बनाता है।

        textBody2.Append(p1.CloneNode(true));

        // स्रोत फ़ाइल से स्रोत पैराग्राफ को हटाएँ।

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // हटाए हुए पैराग्राफ को प्लेसहोल्डर से बदलें।

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // स्रोत फ़ाइल में स्लाइड को सहेजें।

        slide1.Slide.Save();

        // लक्ष्य फ़ाइल में स्लाइड को सहेजें।

        slide2.Slide.Save();

    }

}

}

// Get the slide part of the first slide in the presentation document.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// पहली स्लाइड का रिलेशनशिप ID प्राप्त करें

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// रिलेशनशिप ID द्वारा स्लाइड पार्ट प्राप्त करें।

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}
``` 
## **Aspose.Slides**
यह बेज़ार नहीं है कि डेवलपर्स को प्रस्तुति से टेक्स्ट निकालना पड़े। ऐसा करने के लिए, आपको प्रस्तुति में सभी स्लाइडों के सभी आकारों से टेक्स्ट निकालना होगा। यह लेख Aspose.Slides का उपयोग करके Microsoft PowerPoint PPTX प्रस्तुतियों से टेक्स्ट निकालने की प्रक्रिया समझाता है। एक स्लाइड से या पूरी प्रस्तुति से टेक्स्ट निकालें, Aspose.Slides PresentationScanner क्लास और इसकी स्थैतिक मेथड्स का उपयोग करता है। वे सभी [Aspose.Slides.Util](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil) नेमस्पेस के अंतर्गत पैक किए गए हैं।

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// स्रोत दस्तावेज़ में TextBody आकार में पैराग्राफ़ रेंज को ले जाता है
// लक्ष्य दस्तावेज़ में दूसरे TextBody आकार में।

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //PPTX का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं//PPTX का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं

    Presentation sourcePres = new Presentation(sourceFile);

    //पहली स्लाइड में पहला आकार एक्सेस करें

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //प्लेसहोल्डर से टेक्स्ट प्राप्त करें

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //पहली स्लाइड में पहला आकार एक्सेस करें

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //प्लेसहोल्डर से टेक्स्ट प्राप्त करें

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **चलता कोड उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **नमूना कोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)