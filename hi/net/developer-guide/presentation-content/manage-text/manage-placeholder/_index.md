---
title: .NET में प्रेजेंटेशन प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/net/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में प्लेसहोल्डर को आसानी से प्रबंधित करें: टेक्स्ट बदलें, प्रॉम्प्ट कस्टमाइज़ करें और PowerPoint तथा OpenDocument में इमेज की पारदर्शिता सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रेजेंटेशन प्लेसहोल्डर को प्रोग्रामेटिकली प्रबंधित करने की सुविधा देता है। यह लेख स्लाइड पर प्लेसहोल्डर को खोजने, उनके पाठ को बदलने, प्लेसहोल्डर लेआउट के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करने, और प्लेसहोल्डर बैकग्राउंड के रूप में उपयोग की गई छवि की पार्दर्शिता को समायोजित करने के तरीकों को बताता है। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर और स्थानीय आकृति में अंतर स्पष्ट करता है, बताता है कि प्लेसहोल्डर परिवर्तन को लेआउट या मास्टर के माध्यम से कैसे लागू किया जा सकता है, और हेडर तथा फुटर प्लेसहोल्डर प्रबंधन की ओर संकेत करता है।

## **प्लेसहोल्डर में पाठ बदलें**
उपयोग करके [Aspose.Slides for .NET](/slides/hi/net/), आप प्रेजेंटेशन में स्लाइड पर प्लेसहोल्डर को खोज और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर में पाठ को बदलने की अनुमति देता है।

**पूर्वापेक्षा**: आपको वह प्रेजेंटेशन चाहिए जिसमें प्लेसहोल्डर मौजूद हो। आप ऐसा प्रेजेंटेशन माइक्रोसॉफ्ट पॉवरपॉइंट एप्लिकेशन में बना सकते हैं।

यहाँ बताया गया है कि आप Aspose.Slides का उपयोग करके उस प्रेजेंटेशन में प्लेसहोल्डर के पाठ को कैसे बदल सकते हैं:

1. [`Presentation`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाकर प्रेजेंटेशन को आर्ग्युमेंट के रूप में पास करें।
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. आकृतियों (shapes) को इटरेट करके प्लेसहोल्डर खोजें।
4. प्लेसहोल्डर आकृति को [`AutoShape`](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) में टाइपकास्ट करें और उस साथ जुड़े हुए [`TextFrame`](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) का उपयोग करके पाठ बदलें। 
5. संशोधित प्रेजेंटेशन को सहेजें।

यह C# कोड दिखाता है कि प्लेसहोल्डर में पाठ कैसे बदला जाए:

```c#
// Presentation क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.Slides[0];

    // प्लेसहोल्डर खोजने के लिए आकृतियों पर इटरैट करता है
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // प्रत्येक प्लेसहोल्डर में टेक्स्ट बदलता है
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें**
मानक और पूर्वनिर्मित लेआउट में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट होते हैं जैसे ***शीर्षक जोड़ने के लिए क्लिक करें*** या ***उपशीर्षक जोड़ने के लिए क्लिक करें***। Aspose.Slides का उपयोग करके आप अपने पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट में सम्मिलित कर सकते हैं।

यह C# कोड दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट किया जाए:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // स्लाइड के माध्यम से इटरैट करता है
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint दर्शाता है "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // उपशीर्षक जोड़ता है
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **प्लेसहोल्डर छवि पार्दर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर में पृष्ठभूमि छवि की पार्दर्शिता सेट करने की सहूलियत देता है। इस फ़्रेम में छवि की पार्दर्शिता को समायोजित करके आप पाठ या छवि को अधिक प्रमुख बना सकते हैं (पाठ और छवि के रंगों के आधार पर)।

यह C# कोड दिखाता है कि शैल (shape) के भीतर छवि पृष्ठभूमि के लिए पार्दर्शिता कैसे सेट की जाए:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर स्थानीय आकृति से कैसे अलग है?**

बेस प्लेसहोल्डर एक लेआउट या मास्टर पर मूल आकृति है जिससे स्लाइड की आकृति विरासत में प्राप्त करती है—प्रकार, स्थिति और कुछ फ़ॉर्मेटिंग उससे आती है। स्थानीय आकृति स्वतंत्र होती है; यदि बेस प्लेसहोल्डर नहीं है, तो विरासत लागू नहीं होती।

**मैं प्रत्येक स्लाइड पर इटरैट किए बिना पूरी प्रेजेंटेशन में सभी शीर्षक या कैप्शन को कैसे अपडेट कर सकता हूँ?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को संपादित करें। उन लेआउट/मास्टर पर आधारित स्लाइडें स्वतः ही परिवर्तन को विरासत में प्राप्त कर लेंगी।

**मैं मानक हेडर/फ़ुटर प्लेसहोल्डर—दिनांक एवं समय, स्लाइड नंबर, और फुटर टेक्स्ट—को कैसे नियंत्रित करूँ?**

उचित स्कोप (सामान्य स्लाइड, लेआउट, मास्टर, नोट्स/हैंडआउट) पर HeaderFooter प्रबंधकों का उपयोग करके इन प्लेसहोल्डरों को ऑन या ऑफ करें और उनकी सामग्री सेट करें।