---
title: .NET में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/net/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में मुख्य प्रस्तुति थीम को नियंत्रित करें ताकि लगातार ब्रांडिंग के साथ PowerPoint फाइलें बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की विशेषताओं को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूल रूप से दृश्य तत्वों और उनकी विशेषताओं का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/net/powerpoint-fonts/), [बैकग्राउंड शैलियाँ](/slides/hi/net/presentation-background/), और प्रभाव शामिल होते हैं।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड के विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको ये रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration में मान प्रदान करता है।

यह C# कोड दर्शाता है कि कैसे थीम के लिए एक्सेंट रंग बदलें:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

आप इस तरह परिणामस्वरूप रंग का प्रभावी मान निर्धारित कर सकते हैं:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (रंग [A=255, R=128, G=100, B=162])
}
```

रंग परिवर्तन ऑपरेशन को आगे प्रदर्शित करने के लिए, हम एक और तत्व बनाते हैं और उसे एक्सेंट रंग (प्रारंभिक ऑपरेशन से) सौंपते हैं। फिर हम थीम में रंग बदलते हैं:
```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **वैकल्पिक पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग(1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट(2) से रंग बनते हैं। आप तब उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** - मुख्य थीम रंग

**2** - अतिरिक्त पैलेट के रंग।

यह C# कोड एक ऑपरेशन दर्शाता है जहाँ अतिरिक्त पैलेट रंग मुख्य थीम रंग से प्राप्त होते हैं और फिर आकारों में उपयोग किए जाते हैं:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // एक्सेंट 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // एक्सेंट 4, हल्का 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // एक्सेंट 4, हल्का 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // एक्सेंट 4, हल्का 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // एक्सेंट 4, गहरा 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // एक्सेंट 4, गहरा 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor` को `IColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान होते हैं:
`Background1`, `Background2`, `Text1`, और `Text2`.

हालांकि, `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रस्तुत करता है:
`Dark1`, `Dark2`, `Light1`, और `Light2`.

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट्स को दर्शाते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आया है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` का उपयोग किया जाता था, जबकि नवीनतम UI संस्करण समान स्लॉट्स को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य प्रयोजनों के लिए फ़ॉन्ट चुनने के लिए, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में उपयोग किए गए समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

यह C# कोड दर्शाता है कि कैसे लैटिन फ़ॉन्ट को एक थीम तत्व में असाइन करें:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

यह C# कोड दर्शाता है कि कैसे प्रस्तुति थीम फ़ॉन्ट बदलें:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

सभी टेक्स्ट बॉक्स में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="info" title="TIP" %}} 
आप [PowerPoint फ़ॉन्ट](/slides/hi/net/powerpoint-fonts/) देखना चाहेंगे।
{{% /alert %}}

## **थीम बैकग्राउंड स्टाइल बदलें**

डिफ़ॉल्ट रूप से, PowerPoint एप्लिकेशन 12 पूर्वनिर्धारित बैकग्राउंड प्रदान करता है, लेकिन सामान्य प्रस्तुति में उन 12 बैकग्राउंड में से केवल 3 ही बचाए जाते हैं। 

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint एप्लिकेशन में प्रस्तुति सहेजने के बाद, आप इस C# कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित बैकग्राउंड की संख्या पता कर सकते हैं:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/) क्लास से उपयोग करके PowerPoint थीम में बैकग्राउंड स्टाइल जोड़ या प्राप्त कर सकते हैं।
{{% /alert %}}

यह C# कोड दर्शाता है कि कैसे प्रस्तुति के लिए बैकग्राउंड सेट करें:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**इंडेक्स गाइड**: 0 का उपयोग कोई फ़िल नहीं के लिए किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="info" title="TIP" %}} 
आप [PowerPoint बैकग्राउंड](/slides/hi/net/presentation-background/) देखना चाहेंगे।
{{% /alert %}}

## **थीम इफ़ेक्ट बदलें**

एक PowerPoint थीम आमतौर पर प्रत्येक स्टाइल एरे के लिए 3 मान रखती है। उन एरे को मिलाकर ये 3 इफ़ेक्ट बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब इफ़ेक्ट को किसी विशिष्ट आकार पर लागू किया जाता है तो यह परिणाम मिलता है:
![todo:image_alt_text](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme) क्लास की 3 प्रॉपर्टीज़ ([FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles)) का उपयोग करके थीम के तत्वों को बदल सकते हैं (PowerPoint में उपलब्ध विकल्पों से भी अधिक लचीले तरीके से)।

यह C# कोड दर्शाता है कि कैसे तत्वों के भागों को बदलकर थीम इफ़ेक्ट बदलें:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

फलस्वरूप फ़िल रंग, फ़िल प्रकार, शैडो इफ़ेक्ट आदि में परिवर्तन आते हैं:
![todo:image_alt_text](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?

हाँ। Aspose.Slides स्लाइड-स्तर के थीम ओवरराइड को सपोर्ट करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं ([SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/) के माध्यम से)।

### एक प्रस्तुति से दूसरी प्रस्तुति तक थीम स्थानांतरित करने का सबसे सुरक्षित तरीका क्या है?

[Clone slides](/slides/hi/net/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में कॉपी करें। इससे मूल मास्टर, लेआउट और संबंधित थीम संरक्षित रहते हैं, जिससे रूपरेखा समान बनी रहती है।

### सभी विरासत और ओवरराइड के बाद "इफ़ेक्टिव" मान कैसे देखें?

API के ["effective" दृश्य](/slides/hi/net/shape-effective-properties/) का उपयोग करें ताकि थीम/रंग/फ़ॉन्ट/इफ़ेक्ट के अंतिम मान देख सकें। ये मास्टर प्लस किसी भी स्थानीय ओवरराइड को लागू करने के बाद हल किए हुए, अंतिम गुण लौटाते हैं।