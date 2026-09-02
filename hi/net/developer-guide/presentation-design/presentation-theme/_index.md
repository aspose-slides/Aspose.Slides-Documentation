---
title: .NET में प्रेज़ेंटेशन थीम प्रबंधित करें
linktitle: प्रेज़ेंटेशन थीम
type: docs
weight: 10
url: /hi/net/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेज़ेंटेशन थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- बाहरी थीम
- THMX
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में मास्टर प्रेज़ेंटेशन थीम्स का उपयोग करके, PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाएं, अनुकूलित करें और बदलें।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट, बैकग्राउंड शैलियों, फ़िल, लाइनों और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को नियत मान के रूप में संग्रहीत करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रेजेंटेशन‑स्तर की थीम उपलब्ध है [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) प्रॉपर्टी के माध्यम से। एक प्रेजेंटेशन में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर थीम को ओवरराइड कर सकता है [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/masterthememanager/overridetheme/) द्वारा, लेआउट अपना विरासतित थीम ओवरराइड कर सकता है [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) द्वारा, और एक व्यक्तिगत स्लाइड भी यही कर सकती है। व्यावहारिक रूप से, स्लाइड के लिए प्रभावी थीम इस उत्तराधिकार श्रृंखला के माध्यम से निकाली जाती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, बैकग्राउंड और प्रभाव शैलियों को अपडेट करना, और उत्तराधिकार तथा ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम की [ColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/fontscheme/), और [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/formatscheme/) को उजागर करता है। इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रेजेंटेशन बाहरी स्रोत से आता है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्नलिखित उदाहरण मुख्य थीम गुण पढ़ता है और यह रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह मान लेना सही नहीं है कि हर स्लाइड में समान प्रभावी थीम हो। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और बाद में दर्शाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम के रंग बदलें**

थीम‑सचेत फ़िल, लाइन्स, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) एनेमरेशन से एक तार्किक रंग का उल्लेख कर सकते हैं। जब आप थीम की [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के विरुद्ध हल हो जाते हैं। जो ऑब्जेक्ट्स सीधे RGB रंग का उपयोग करते हैं, वे थीम‑रंग अपडेट से नहीं बदलते।

निम्नलिखित एंड‑टू‑एंड उदाहरण एक शेप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेजेंटेशन सहेजता है, फिर इसे पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से बंधी रहती है, थीम बदलने के बाद उसका दिखने वाला रंग लाल हो जाता है। यदि आप शेप पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग**

PowerPoint थीम रंग से हल्के और गहरे वेरिएंट बनाता है रंग परिवर्तन लागू करके। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/net/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के व गहरे वेरिएंट।

निम्नलिखित उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये वेरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नई `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) एनेमरेशन `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) वही थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; यह मूल्य नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से बदलते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए एक प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme.Major](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टीज़ इन सेट्स को उजागर करती हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्नलिखित उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह टेक्स्ट जिसमें स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय है, थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलेगा।

प्रमुख और गौण फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी शामिल कर सकते हैं। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **मास्टर‑निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो उपयोग करें [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)। चयनित मास्टर को [Presentation.Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) संग्रह से चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/) को लागू करता है, और थीम फ़ाइल पथ को मेथड को पास करें।

मेथड निम्नलिखित संचालन करता है:

1. चयनित मास्टर के आधार पर नई मास्टर स्लाइड बनाता है।
1. नई मास्टर पर बाहरी थीम लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नई मास्टर असाइन करता है।
1. नई बनाई गई [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) लौटाता है।

निम्नलिखित उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है, प्रेजेंटेशन सहेजता है, और परिणाम पुनः खोलता है:

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

अवैध, भ्रष्ट या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) या उसकी कोई फ़ॉर्मेट‑संबंधी सबक्लास उत्पन्न कर सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को सत्यापित करें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रेजेंटेशन सहेजें।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स अपना वर्तमान मास्टर और थीम बनाए रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, फ़िल, लाइन्स, बैकग्राउंड और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड नई मास्टर से विरासतित मूल्यों पर प्राथमिकता ले सकते हैं।

थीम फ़ॉन्ट ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/net/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: मेथड `.thmx` फ़ाइल पथ को स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रेजेंटेशन में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पूर्व ज्ञान में नहीं है, तो उसे प्रतिनिधि स्लाइड से प्राप्त करें [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) और [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/masterslide/) के माध्यम से। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रेजेंटेशन में एक नया मास्टर बनाता है।

निम्नलिखित उदाहरण दो सेक्शन की स्लाइड्स से उनके मास्टर प्राप्त करता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करती है, और दूसरी कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य किसी भी मास्टर से जुड़ी स्लाइड्स को फिर से शैली नहीं दी जाती।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को सुरक्षित रखें**

यदि आप एक स्लाइड को किसी अन्य प्रेजेंटेशन में ले जाना चाहते हैं और उसका मूल डिज़ाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेजेंटेशन में [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) द्वारा क्लोन करें, फिर स्लाइड को [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और क्लोन किए हुए मास्टर के साथ क्लोन करें। इससे मास्टर, उसके लेआउट, और संबद्ध थीम साथ में कॉपी होते हैं।

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

यह वह पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान रूप दिखना चाहिए। केवल सामग्री को असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, बैकग्राउंड और प्रभाव बदल सकते हैं।

### **मौजूद स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को इनिशियलाइज़ करें। [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासतित थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड को हटाने और विरासतित मानों पर लौटने के लिए कॉल करें [OverrideTheme.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/clear/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड का अपना ओवरराइड न हो। वही इनिशियलाइज़ेशन मेथड लेआउट की [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड समान आधार डिज़ाइन साझा करते हैं तो मास्टर या प्रेजेंटेशन‑स्तर थीम उपयोग करें, एक लेआउट परिवार को अलग शैली की आवश्यकता होने पर लेआउट ओवरराइड उपयोग करें, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद के वैश्विक थीम परिवर्तन को अनुमान लगाना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) में संग्रहीत होती हैं। PowerPoint UI में बैकग्राउंड विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम फ़िल को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![प्रेजेंटेशन थीम के लिए PowerPoint बैकग्राउंड शैली गैलरी](presentation-design_8.png)

बैकग्राउंड शैली उपयोग करने से पहले संग्रह और वर्तमान [Background.StyleIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/background/styleindex/) को निरीक्षण करें। `StyleIndex` `0` का उपयोग कोई थीम्ड फ़िल नहीं होने के लिए करता है; धनात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह .NET संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। यह मान न लें कि हर प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल शैलियाँ होती हैं।

निम्नलिखित उदाहरण उपलब्ध बैकग्राउंड फ़िल गणना रिपोर्ट करता है, पहले मास्टर को थीम्ड बैकग्राउंड संदर्भ असाइन करता है, और प्रेजेंटेशन सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रव-entry और लेआउट या स्लाइड‑स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड का अपना बैकग्राउंड है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। जब आपको विरासत लागू होने के बाद अंतिम बैकग्राउंड जानना हो तो उपयोग करें [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/)।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह सूचकांक न समझें। साथ ही एक फ़ाइल से शैली संख्या हार्ड‑कोड न करें और इसे दूसरे फ़ाइल में समान रूप मानने से बचें; थीम शैली परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles/), और [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles/) संग्रह होते हैं। सामान्य Office थीम अक्सर तीन मुख्य शैली प्रविष्टियों को सम्मिलित करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को निरीक्षण करना चाहिए न कि स्थिर काउंट मान लेना चाहिए।

![एक ही शेप पर सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव लागू किए गए](presentation-design_10.png)

जब आप C# में इन संग्रहों तक पहुँचते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। शेप की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapestyle/) के माध्यम से उजागर होती है। थीम शैली को बदलने से उन शेप्स पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधे फ़ॉर्मेटिंग वाले शेप्स अपरिवर्तित रह सकते हैं।

निम्नलिखित उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी प्रभाव शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित शेप्स के लिए पहली थीम लाइन शैली लाल हो जाएगी, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली में दूरी 10 पॉइंट का बाहरी शैडो जुड़ जाएगा। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक शेप कौन से शैली स्लॉट को संदर्भित करती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल, और शैडो सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि उत्तराधिकार और स्थानीय ओवरराइड के बाद स्लाइड या शेप वास्तव में क्या उपयोग करती है। स्लाइड के लिए कॉल करें [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)। बैकग्राउंड के लिए उपयोग करें [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/), और फ़िल के लिए उपयोग करें [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/)।

निम्नलिखित उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड, और पहली शेप फ़िल पढ़ता है:

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

रेंडरिंग डाइग्नॉस्टिक्स, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या शेप ओवरराइड को मिस कर सकते हैं जो अंतिम उपस्थिति को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रेजेंटेशन की हर स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बनाए रखती हैं।

**क्या मैं एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हां। स्लाइड की [SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम इनिशियलाइज़ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर रहे हों और उसकी मूल उपस्थिति बनाए रखनी हो, तो स्रोत मास्टर को लक्ष्य में [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) द्वारा क्लोन करें और फिर स्लाइड को [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और क्लोन किए हुए मास्टर के साथ क्लोन करें। इससे मास्टर, लेआउट, और थीम एक साथ रहेंगे।

**मैं उत्तराधिकार और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए उपयोग करें [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) और स्वरूप ऑब्जेक्ट्स जैसे [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) और [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड्स। ये API उत्तराधिकार और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।