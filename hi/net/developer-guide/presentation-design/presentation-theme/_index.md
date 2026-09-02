---
title: ".NET में प्रस्तुति थीम्स प्रबंधित करें"
linktitle: "प्रेजेंटेशन थीम"
type: docs
weight: 10
url: /hi/net/presentation-theme/
keywords:
- "PowerPoint थीम"
- "प्रेजेंटेशन थीम"
- "स्लाइड थीम"
- "थीम सेट करें"
- "थीम बदलें"
- "थीम प्रबंधित करें"
- "बाहरी थीम"
- "THMX"
- "थीम रंग"
- "अतिरिक्त पैलेट"
- "थीम फ़ॉन्ट"
- "थीम शैली"
- "थीम प्रभाव"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में मास्टर प्रस्तुति थीम्स का उपयोग करके PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाएं, अनुकूलित करें और रूपांतरित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करती हैं, इसलिए थीम में परिवर्तन कई वस्तुओं को एक साथ अद्यतन कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) गुण के माध्यम से उपलब्ध होती है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/masterthememanager/overridetheme/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, एक लेआउट अपने विरासत में मिली थीम को [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) के माध्यम से ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकती है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

निम्नलिखित अनुभाग सबसे सामान्य थीम कार्य‑प्रवाह दिखाते हैं: थीम निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि तथा प्रभाव शैलियों को अद्यतन करना, तथा विरासत और ओवरराइड हल हो जाने के बाद प्रभावी मानों को पढ़ना।

## **एक थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/) वस्तु थीम के [ColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/fontscheme/) और [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/formatscheme/) को उजागर करती है। इन्हें बदलने से पहले इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड में समान प्रभावी थीम है। स्लाइड से संबद्ध मास्टर का निरीक्षण करें, और बाद में जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं, तो इस लेख में दर्शाए गए प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखाएं और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration से तार्किक रंग का संदर्भ ले सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के अनुसार हल हो जाती हैं। जिन वस्तुओं ने प्रत्यक्ष RGB रंग उपयोग किया है, वे थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर प्रत्यक्ष रंग के साथ स्कीम रंग को बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे विविधताएँ उत्पन्न करने के लिए रंग परिवर्तन लागू करता है। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/net/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

ये विविधताएँ अभी भी थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) वही थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये कोई डायनामिक रूपांतरण नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में शीर्षकों के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.Major](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/minor/) गुण इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता पाठ फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - शीर्षक फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - शीर्षक फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी पंक्ति जो गौण लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

शीर्षक मुख्य फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। स्पष्ट फ़ॉन्ट नाम वाले पाठ, जो थीम पहचानकर्ता नहीं है, थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलेंगे।

मुख्य और गौण फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना, के लिए फ़ॉन्ट मैपिंग भी रख सकते हैं। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें: [Script-Specific Theme Fonts](/slides/hi/net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेज़ेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें: [PowerPoint Fonts](/slides/hi/net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे दिए गए कार्य‑प्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक मास्टर‑निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनः स्टाइल करना चाहते हों, तो [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) का उपयोग करें। [Presentation.Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) संग्रह से वह मास्टर चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/) को लागू करता है, और मेथड को थीम फ़ाइल पथ पास करें।

मेथड निम्न कार्य करता है:

1. चुने हुए मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
2. बाहरी थीम को नए मास्टर पर लागू करता है।
3. पहले चुने हुए मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर से संबद्ध करता है।
4. नए बनाए गए [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) को वापस करता है।

निम्न उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है, प्रस्तुति सहेजता है, और परिणाम पुनः खोलता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

एक असमान्य, भ्रष्ट या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) या उसकी किसी फ़ॉर्मेट‑संबंधी उप‑क्लास को उत्पन्न कर सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को मान्य करें, फ़ाइल‑सिस्टम त्रुटियों को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रस्तुति सहेजें।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चुने हुए मास्टर पर निर्भर थे। अन्य मास्टरों से जुड़े स्लाइड्स अपनी मौजूदा मास्टर और थीम बनाए रखते हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। प्रत्यक्ष रूप से निर्धारित रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकती है। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नई मास्टर से विरासती मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम परिवेश में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [custom font sources](/slides/hi/net/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/net/font-substitution/) कॉन्फ़िगर करें।

यह प्रत्यक्ष मास्टर‑स्तर कार्य‑प्रवाह है: मेथड `.thmx` फ़ाइल पथ को स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब आवश्यक मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) और [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/masterslide/) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स से उनके मास्टर खोजता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य मास्टरों से जुड़े स्लाइड्स पुनः स्टाइल नहीं होते।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप किसी स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर स्लाइड को [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और क्लोन किए हुए मास्टर से क्लोन करें। यह मास्टर, उसके लेआउट और संबंधित थीम को एक साथ ले जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

यह वह पसंदीदा कार्य‑प्रवाह है जब स्रोत स्लाइड को गंतव्य में समान दिखना आवश्यक हो। केवल सामग्री को किसी असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑प्रेरित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initfontschemefrom/) और [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड को हटाने और विरासत मानों पर वापस लौटने के लिए [OverrideTheme.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड का अपना ओवरराइड न हो। वही प्रारंभिक मेथड लेआउट की [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करने चाहिए तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली की आवश्यकता हो तो लेआउट ओवरराइड, और केवल असाधारण मामलों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम बदलने को पूर्वानुमानित करना कठिन बनाते हैं।

## **थीम पृष्ठभूमि शैलियों को अद्यतन करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) में संग्रहीत होती हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.StyleIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/background/styleindex/) की जांच करें। `StyleIndex` थीम भराव न होने पर `0` उपयोग करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह .NET संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `[0]` पहला संग्रहित आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, प्रथम मास्टर को थीम पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह इंडेक्स न समझें। एक फ़ाइल से शैली संख्या को हार्ड‑कोड कर दूसरे फ़ाइल में समान उपस्थिति की उम्मीद न रखें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के बारे में देखें: [Presentation Background](/slides/hi/net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभावों को अद्यतन करें**

एक थीम फ़ॉर्मेट स्कीम में अलग-अलग [FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles/), और [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को निरीक्षण करना चाहिए, न कि निश्चित गिनती मान लेना।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# में इन संग्रहों को पहुंचते समय इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहित शैली और `[2]` तीसरा। एक आकार का शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को बदलना उन आकारों को प्रभावित करता है जो उस थीम शैली को संदर्भित करते हैं; प्रत्यक्ष फ़ॉर्मेटिंग वाली आकारें अविचल रह सकती हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहले रेखा शैली को बदलता है, तीसरी भराव शैली को बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाती है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या प्रत्यक्ष फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **निर्धारित करें कि क्या प्रभावी ठोस भराव थीम रंग का उपयोग करता है**

एक भराव वस्तु पर प्रत्यक्ष रूप से संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। उसे ठीक करने के लिए [IFillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformat/geteffective/) को कॉल करें, जिससे वह पदानुक्रम [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/) में अपरिवर्तनीय बन जाता है। पहले [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/filltype/) जाँचें। केवल जब यह `FillType.Solid` हो, तभी ठोस‑भराव गुण पढ़ें।

ठोस भराव के लिए, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) विरासत, थीम लुक‑अप और रंग परिवर्तन लागू करने के बाद अंतिम RGB मान लौटाता है। [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) संबंधित तर्कसंगत [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) स्लॉट देता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` मान का अर्थ है कि प्रभावी ठोस भराव किसी स्कीम रंग पर आधारित नहीं है। ऐसी कार्य‑प्रवाह में जहाँ भराव या तो थीम रंग या प्रत्यक्ष RGB रंग होते हैं, यह मान प्रत्यक्ष RGB भराव को पहचानता है।

स्थानीय [IColorFormat.SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/icolorformat/schemecolor/) मान को अकेले उपयोग करके भराव को वर्गीकृत न करें। उदाहरण के लिए, कोई पाठ भाग स्थानीय रूप से स्कीम रंग परिभाषित नहीं कर सकता, इसलिए उसका स्थानीय मान `NotDefined` होता है, जबकि उसका प्रभावी भराव थीम रंग से विरासत में मिल सकता है और `Text1` या `Accent6` पर हल हो सकता है। इसके विपरीत, `SolidFillSchemeColor` बताता है कि कौन सा तर्कसंगत थीम स्लॉट प्रभावी रंग उत्पन्न करता है, लेकिन यह नहीं बताता कि वह स्लॉट वस्तु, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकार भराव और पाठ‑भाग भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबंधित स्कीम रंग प्रिंट करता है, और उन ठोस भरावों को चिन्हित करता है जो थीम रंग परिवर्तन का अनुसरण नहीं करेंगे:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

`NotDefined` शाखा उन ठोस भरावों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट परिवर्तन पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट का पालन करना हो, तो इन वस्तुओं की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान उपस्थिति दर्शाता है, जबकि स्कीम मान बताता है कि वह उपस्थिति थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट वस्तुएँ स्नैपशॉट होती हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई भी विरासत फ़ॉर्मेटिंग बदलने के बाद, `GetEffective` को पुनः कॉल करें और तुलना या रिपोर्टिंग से पहले नया `IFillFormatEffectiveData` ऑब्जेक्ट पढ़ें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम वस्तुएँ आपको बताती हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान आपको बताते हैं कि विरासत और स्थानीय ओवरराइड हल हो जाने के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) को कॉल करें। पृष्ठभूमि के लिए, [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) का उपयोग करें, और भराव के लिए [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) का।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकार भराव को पढ़ता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

रेंडरिंग निदान, वैधता और तुलनाओं के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की प्रत्येक स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चुने हुए मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बनाए रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/) का प्रयोग करके उसके ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उसी स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर उसकी स्रोत उपस्थिति बनाए रखते हैं, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को क्लोन करें, इसके लिए [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) का उपयोग करें। यह मास्टर, लेआउट और थीम को एक साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) तथा फ़ॉर्मेट वस्तुओं जैसे [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) और [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) के अनुरूप प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।