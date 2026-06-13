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
- थीम प्रबंधन
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
description: "Aspose.Slides for .NET में मास्टर प्रस्तुति थीम का उपयोग करके PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की प्रॉपर्टीज़ को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूल रूप से दृश्यमान तत्वों और उनकी प्रॉपर्टीज़ का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम रंगों, [फ़ॉन्ट](/slides/hi/net/powerpoint-fonts/), [पृष्ठभूमि शैलियां](/slides/hi/net/presentation-background/), और प्रभावों को सम्मिलित करती है।

![थीम-घटक](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint की एक थीम स्लाइड के विभिन्न तत्वों के लिए रंगों का एक विशिष्ट सेट उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। आपको नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration के तहत मान प्रदान करता है।

यह C# कोड आपको दिखाता है कि थीम के लिए एक्सेंट रंग कैसे बदलें:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

आप इस तरह से परिणामस्वरूप रंग का प्रभावी मान निर्धारित कर सकते हैं:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (रंग [A=255, R=128, G=100, B=162])
```

रंग परिवर्तन ऑपरेशन को और स्पष्ट करने के लिए, हम एक और तत्व बनाते हैं और इसे एक्सेंट रंग (प्राथमिक ऑपरेशन से) असाइन करते हैं। फिर हम थीम में रंग बदलते हैं:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग(1) पर ल्यूमिनेंस रूपांतरण लागू करते हैं, तो अतिरिक्त पैलेट(2) के रंग बनते हैं। आप फिर उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![अतिरिक्त-पैलेट-रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग  
**2** - अतिरिक्त पैलेट के रंग।

यह C# कोड एक ऑपरेशन दर्शाता है जिसमें अतिरिक्त पैलेट के रंग मुख्य थीम रंग से प्राप्त किए जाते हैं और फिर आकृतियों में उपयोग होते हैं:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // एक्सेंट 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // एक्सेंट 4, 80% हल्का
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // एक्सेंट 4, 60% हल्का
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // एक्सेंट 4, 40% हल्का
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // एक्सेंट 4, 25% गहरा
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // एक्सेंट 4, 50% गहरा
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor` को `IColorScheme` रंगों से मानचित्रित करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान होते हैं: `Background1`, `Background2`, `Text1` और `Text2`।

हालांकि, `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) को 반환 करता है, जो संबंधित रंगों को इस प्रकार प्रदर्शित करता है: `Dark1`, `Dark2`, `Light1` और `Light2`।

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट को संदर्भित करते हैं और मानचित्रण स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर माइक्रोसॉफ्ट ऑफिस शब्दावली से आया है। पुराने ऑफिस संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग किए जाते थे, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में दिखाते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने में आपकी सहायता करने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (जो PowerPoint में उपयोग किए जाने वाले के समान हैं):
* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (मैजॉर लैटिन फ़ॉन्ट)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)

यह C# कोड आपको दिखाता है कि लैटिन फ़ॉन्ट को थीम तत्व में कैसे असाइन करें:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

यह C# कोड आपको दिखाता है कि प्रस्तुति थीम फ़ॉन्ट को कैसे बदलें:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

सभी टेक्स्ट बॉक्सों में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="primary" title="TIP" %}} 

आप [PowerPoint फ़ॉन्ट](/slides/hi/net/powerpoint-fonts/) देखना चाह सकते हैं।

{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint ऐप 12 पूर्वनिर्धारित पृष्ठभूमियां प्रदान करता है, लेकिन इन 12 पृष्ठभूमियों में से केवल 3 एक सामान्य प्रस्तुति में सहेजे जाते हैं।

![प्रेजेंटेशन-डिज़ाइन](presentation-design_8.png)

उदाहरण के लिए, PowerPoint ऐप में प्रस्तुति सहेजने के बाद, आप इस C# कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/) क्लास से उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली जोड़ या एक्सेस कर सकते हैं।

{{% /alert %}}

यह C# कोड आपको दिखाता है कि प्रस्तुति के लिए पृष्ठभूमि कैसे सेट करें:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**इंडेक्स गाइड**: 0 को कोई भराव नहीं के लिए उपयोग किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="primary" title="TIP" %}} 

आप [PowerPoint पृष्ठभूमि](/slides/hi/net/presentation-background/) देखना चाह सकते हैं।

{{% /alert %}}

## **थीम प्रभाव बदलें**

PowerPoint थीम आमतौर पर प्रत्येक शैली एरे के लिए 3 मान रखती है। ये एरे इन 3 प्रभावों में मिलते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब प्रभावों को किसी विशिष्ट आकार पर लागू किया जाता है तो यह परिणाम होता है:

![प्रेजेंटेशन-डिज़ाइन-10](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles), और [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme) क्लास से उपयोग करके आप थीम के तत्वों को बदल सकते हैं (PowerPoint में विकल्पों की तुलना में अधिक लचीले ढंग से)।

यह C# कोड आपको दिखाता है कि तत्वों के भागों को बदलकर थीम प्रभाव कैसे बदलें:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

परिणामस्वरूप भराव रंग, भराव प्रकार, शेडो प्रभाव आदि में परिवर्तन:

![प्रेजेंटेशन-डिज़ाइन-11](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। Aspose.Slides स्लाइड-स्तर के थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं (via the [SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/))।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

[Clone slides](/slides/hi/net/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में ले जाएँ। यह मूल मास्टर, लेआउट और संबंधित थीम को संरक्षित रखता है ताकि रूप अधिक सुसंगत बना रहे।

**सभी विरासत और ओवरराइड के बाद "प्रभावी" मान कैसे देखूँ?**

थीम/रंग/फ़ॉन्ट/प्रभाव के लिए API के ["effective" views](/slides/hi/net/shape-effective-properties/) का उपयोग करें। ये मास्टर लागू करने और किसी भी स्थानीय ओवरराइड के बाद हल किए गए अंतिम प्रॉपर्टीज़ लौटाते हैं।