---
title: जावा में समूह प्रस्तुति आकृतियाँ
linktitle: आकृति समूह
type: docs
weight: 40
url: /hi/java/group/
keywords:
- समूह आकृति
- आकृति समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint डेक्स में आकृतियों को ग्रुप और अनग्रुप करना सीखें—तेज़, चरण-दर-चरण मार्गदर्शिका जिसमें मुफ्त Java कोड शामिल है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में ग्रुप शेप्स के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में ग्रुप शेप कैसे जोड़ा जाए, उसके अंदर शेप्स रखें, और अद्यतन प्रेज़ेंटेशन को सहेजा जाए। यह यह भी दर्शाता है कि समूह के अंदर संग्रहीत शेप्स तक कैसे पहुंचा जाए और उनके `AlternativeText` मान पढ़े जाएँ। अतिरिक्त रूप से, यह लेख नेस्टेड ग्रुप्स, z‑order, और लॉकिंग विकल्प जैसी संबंधित ग्रुप‑शेप क्षमताओं को संक्षेप में कवर करता है।

## **ग्रुप शेप जोड़ें**
Aspose.Slides स्लाइड्स पर ग्रुप शेप्स के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रेज़ेंटेशन बनाने में मदद करती है। Aspose.Slides for Java ग्रुप शेप्स को जोड़ने या एक्सेस करने का समर्थन करता है। जोड़े गए ग्रुप शेप में शेप्स जोड़कर उसे भरना या ग्रुप शेप की किसी भी प्रॉपर्टी को एक्सेस करना संभव है। Aspose.Slides for Java का उपयोग करके स्लाइड में ग्रुप शेप जोड़ने के लिए:

1. एक उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक ग्रुप शेप जोड़ें।
1. जोड़े गए ग्रुप शेप में शेप्स जोड़ें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में ग्रुप शेप जोड़ता है।

```java
// Presentation क्लास का उदाहरण बनाएँ
Presentation pres = new Presentation();
try {
    //    पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    //    स्लाइड्स की शैप कलेक्शन तक पहुँच रहा है
    IShapeCollection slideShapes = sld.getShapes();

    //    स्लाइड में एक समूह आकृति जोड़ना
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    //    जोड़े गए समूह आकृति के भीतर आकृतियों को जोड़ना
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    //    समूह आकृति फ्रेम जोड़ना
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    //    PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltText प्रॉपर्टी तक पहुँचें**
यह विषय सरल चरणों को दिखाता है, जिसमें कोड उदाहरण शामिल हैं, ग्रुप शेप जोड़ने और स्लाइड्स पर ग्रुप शेप्स की AltText प्रॉपर्टी तक पहुँचने के लिए। Aspose.Slides for Java का उपयोग करके स्लाइड में ग्रुप शेप की AltText तक पहुँचने के लिए:

1. PPTX फ़ाइल का प्रतिनिधित्व करने वाली [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास को इंस्टैंसिएट करें।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड्स के शेप कलेक्शन तक पहुँचें।
1. ग्रुप शेप तक पहुँचें।
1. [AlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getAlternativeText--) प्रॉपर्टी तक पहुँचें।

नीचे दिया गया उदाहरण ग्रुप शेप के विकल्प पाठ तक पहुँचता है।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("AltText.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // स्लाइड्स की शैप कलेक्शन तक पहुँच रहा है
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // समूह आकृति तक पहुँच रहा है।
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText प्रॉपर्टी तक पहुँच रहा है
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **आम प्रश्न**

**क्या नेस्टेड ग्रुपिंग (एक ग्रुप के अंदर दूसरा ग्रुप) समर्थित है?**

हां। [GroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/groupshape/) में एक [getParentGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getParentGroup--) मेथड है, जो सीधे पदानुक्रम समर्थन दर्शाता है (एक ग्रुप दूसरे ग्रुप का चाइल्ड हो सकता है)।

**मैं स्लाइड पर अन्य ऑब्जेक्ट्स की तुलना में ग्रुप के z‑order को कैसे नियंत्रित करूँ?**

[GroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/groupshape/) के [getZOrderPosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getZOrderPosition--) मेथड का उपयोग करके उसकी डिस्प्ले स्टैक में स्थिति की जाँच करें।

**क्या मैं स्थानांतरित करने/संपादित करने/अन्ग्रुप करने को रोक सकता हूँ?**

हां। ग्रुप की लॉक सेक्शन को [GroupShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/groupshape/#getGroupShapeLock--) के द्वारा एक्सपोज़ किया गया है, जिससे आप ऑब्जेक्ट पर ऑपरेशंस को प्रतिबंधित कर सकते हैं।