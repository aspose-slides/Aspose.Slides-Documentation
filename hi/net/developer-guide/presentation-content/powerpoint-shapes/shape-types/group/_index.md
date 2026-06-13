---
title: ".NET में ग्रुप प्रस्तुति शैप्स"
linktitle: "शेप समूह"
type: docs
weight: 40
url: /hi/net/group/
keywords:
- "ग्रुप शैप"
- "शैप ग्रुप"
- "ग्रुप जोड़ें"
- "वैकल्पिक टेक्स्ट"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint डेक्स में शैप्स को ग्रुप और अनग्रुप करना सीखें—तेज़, चरण-दर-चरण गाइड मुफ्त C# कोड के साथ।"
---
## **परिचय**

यह लेख Aspose.Slides में ग्रुप शैप्स के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड में ग्रुप शैप कैसे जोड़ें, उसके भीतर शैप्स रखें, और अपडेटेड प्रेजेंटेशन को सहेजें। यह भी दिखाता है कि ग्रुप के अंदर संग्रहीत शैप्स तक कैसे पहुँचें और उनके `AlternativeText` मान पढ़ें। अतिरिक्त रूप से, लेख संक्षेप में नेस्टेड ग्रुप्स, Z‑ऑर्डर, और लॉकिंग विकल्प जैसी संबंधित ग्रुप‑शैप क्षमताओं को कवर करता है।

## **एक ग्रुप शैप जोड़ें**
Aspose.Slides स्लाइड्स पर ग्रुप शैप्स के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रेजेंटेशन बनाने में मदद करती है। Aspose.Slides for .NET ग्रुप शैप्स को जोड़ने या उनके तक पहुँचने का समर्थन करता है। एक जोड़े गए ग्रुप शैप में शैप्स जोड़कर उसे भरना या ग्रुप शैप की किसी भी प्रॉपर्टी तक पहुँचना संभव है। Aspose.Slides for .NET का उपयोग करके स्लाइड में ग्रुप शैप जोड़ने के लिए:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक ग्रुप शैप जोड़ें।
1. जोड़े गये ग्रुप शैप में शैप्स जोड़ें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में एक ग्रुप शैप जोड़ता है।

```c#
 // Presentation क्लास को इंस्टैंटिएट करें 
 using (Presentation pres = new Presentation())
 {
     // पहले स्लाइड को प्राप्त करें 
     ISlide sld = pres.Slides[0];

     // स्लाइड्स के शैप कलेक्शन तक पहुँचें 
     IShapeCollection slideShapes = sld.Shapes;

     // स्लाइड में एक ग्रुप शैप जोड़ें 
     IGroupShape groupShape = slideShapes.AddGroupShape();

     // जोड़े गए ग्रुप शैप के भीतर शैप्स जोड़ें 
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

     // ग्रुप शैप फ्रेम जोड़ें 
     groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

     // PPTX फ़ाइल को डिस्क पर सहेजें 
     pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
 }
```

## **AltText प्रॉपर्टी तक पहुँचें**
यह विषय सरल चरण दिखाता है, कोड उदाहरणों सहित, ग्रुप शैप जोड़ने और स्लाइड्स पर ग्रुप शैप्स की AltText प्रॉपर्टी तक पहुँचने के लिए। स्लाइड में ग्रुप शैप की AltText तक पहुँचने के लिए Aspose.Slides for .NET का उपयोग:

1. `Presentation` क्लास को इंस्टैंसिएट करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड्स के शैप कलेक्शन तक पहुँच प्राप्त करें।
1. ग्रुप शैप तक पहुँच प्राप्त करें।
1. AltText प्रॉपर्टी तक पहुँच प्राप्त करें।

नीचे दिया गया उदाहरण ग्रुप शैप का वैकल्पिक टेक्स्ट एक्सेस करता है।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
Presentation pres = new Presentation("AltText.pptx");

// पहली स्लाइड प्राप्त करें
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // स्लाइड्स के शैप कलेक्शन तक पहुँचें
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // ग्रुप शैप तक पहुँचें।
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // AltText प्रॉपर्टी तक पहुँचें
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या नेस्टेड ग्रुपिंग (एक ग्रुप के अंदर एक ग्रुप) समर्थित है?**

हाँ। [GroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/groupshape/) में एक [ParentGroup](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/parentgroup/) प्रॉपर्टी है, जो सीधे पदानुक्रम समर्थन को दर्शाती है (एक ग्रुप दूसरे ग्रुप का चाइल्ड हो सकता है)।

**मैं स्लाइड पर अन्य ऑब्जेक्ट्स की तुलना में ग्रुप का Z‑ऑर्डर कैसे नियंत्रित करूँ?**

[GroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/groupshape/) की [ZOrderPosition](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/zorderposition/) प्रॉपर्टी का उपयोग करके उसके डिस्प्ले स्टैक में स्थिति की जांच करें।

**क्या मैं मूविंग/एडिटिंग/अनग्रुपिंग को रोक सकता हूँ?**

हाँ। ग्रुप का लॉक सेक्शन [GroupShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/groupshape/groupshapelock/) के माध्यम से उपलब्ध है, जो आपको ऑब्जेक्ट पर संचालन को प्रतिबंधित करने की अनुमति देता है।