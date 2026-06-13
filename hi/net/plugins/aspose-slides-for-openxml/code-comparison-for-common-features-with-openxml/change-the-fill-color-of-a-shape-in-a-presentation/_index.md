---
title: प्रस्तुति में आकृति का भरने का रंग बदलें
type: docs
weight: 40
url: /hi/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML प्रस्तुति**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// एक आकृति का भरने का रंग बदलें।

// परीक्षण फ़ाइल में पहले स्लाइड की पहली आकृति के रूप में एक भरी हुई आकृति होनी चाहिए।

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // पहले स्लाइड का रिलेशनशिप ID प्राप्त करें।

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // रिलेशनशिप ID से स्लाइड भाग प्राप्त करें।

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // उस आकृति को शामिल करने वाले शेप ट्री को प्राप्त करें जिसे बदलना है।

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // शेप ट्री में पहली आकृति प्राप्त करें।

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // आकृति की शैली प्राप्त करें।

                ShapeStyle style = shape.ShapeStyle;

                // फ़िल रेफ़रेंस प्राप्त करें।

                Drawing.FillReference fillRef = style.FillReference;

                // फ़िल रंग को SchemeColor Accent 6 पर सेट करें;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // संशोधित स्लाइड को सहेजें।

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
हमें प्रस्तुति में आकृतियों को भरने के लिए निम्नलिखित चरणों का पालन करना होगा:

- Presentation वर्ग की एक इंस्टेंस बनाएं।
- उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड में एक IShape जोड़ें।
- आकृति के Fill Type को Solid पर सेट करें।
- आकृति का रंग सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

// PPTX का प्रतिनिधित्व करने वाली PrseetationEx क्लास का इंस्टैंस बनाएं 

using (Presentation pres = new Presentation())

{

    // पहली स्लाइड प्राप्त करें

    ISlide sld = pres.Slides[0];

    // rectangle प्रकार का ऑटॉशेप जोड़ें

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Fill प्रकार को Solid सेट करें

    shp.FillFormat.FillType = FillType.Solid;

    // आयत का रंग सेट करें

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर लिखें

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **चल रहा कोड उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **नमूना कोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)