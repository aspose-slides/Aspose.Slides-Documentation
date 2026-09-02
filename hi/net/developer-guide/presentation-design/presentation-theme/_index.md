---
title: .NET में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रेज़ेंटेशन थीम
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
description: "Aspose.Slides for .NET में मुख्य प्रस्तुति थीम का उपयोग करके PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाना, अनुकूलित करना और बदलना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भराव, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑समझदार वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं, न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करती हैं, इसलिए थीम बदलाव कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) प्रॉपर्टी के माध्यम से उपलब्ध है। एक प्रस्तुति निचले स्तरों पर थीम ओवरराइड भी रख सकती है। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/masterthememanager/overridetheme/) के जरिए ओवरराइड कर सकता है, एक लेआउट अपने विरासत में मिली थीम को [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) के माध्यम से ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकता है। व्यावहारिक रूप में, स्लाइड के लिए प्रभावी थीम इस वंशानुक्रम श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियां, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: एक थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम की कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और वंशानुक्रम एवं ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [ColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/fontscheme/), और [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/formatscheme/) को उजागर करता है। इन संग्रहों का परिवर्तन से पहले निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्नलिखित उदाहरण मुख्य थीम प्रॉपर्टी पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियां संग्रहीत हैं:

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

यदि फ़ाइल कई मास्टर का उपयोग करती है, तो यह मत मानिए कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर की जाँच करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हों तो बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑समझदार भराव, रेखा और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ दे सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम‑रंग को संदर्भित करती हैं, नई मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुएँ थीम‑रंग अपडेट से नहीं बदलतीं।

निम्नलिखित एंड‑टू‑एंड उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से लिंक्ड रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग के साथ स्कीम‑रंग को बदलते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट लागू करके उत्पन्न करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/net/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्नलिखित उदाहरण `Accent4` पर आधारित छह आयत बनाता है, उनमें से पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नई `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये किसी रूपांतरित मान नहीं हैं जो एक रूप से दूसरे में गतिशील रूप से बदलते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम फ़ॉन्ट स्कीम में हेडिंग के लिए एक मेजर फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक माइनर फ़ॉन्ट सेट होता है। [FontScheme.Major](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी इन सेट को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता को टेक्स्ट फ़ॉर्मेटिंग में उपयोग किया जा सकता है:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्नलिखित उदाहरण एक हेडिंग बनाता है जो मेजर लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो माइनर लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मेजर फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट माइनर फ़ॉन्ट का। यदि कोई स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय उपयोग किया गया है, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

मेजर और माइनर फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रस्तुति फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए, देखें [PowerPoint Fonts](/slides/hi/net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम की कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह हैं, और वे विभिन्न समस्याओं को हल करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप एक स्लाइड को अन्य प्रस्तुति में स्थानांतरित करना चाहते हैं और उसके मूल डिज़ाइन को संरक्षित रखना चाहते हैं, तो [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) के साथ स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और क्लोन किए गए मास्टर के साथ स्लाइड को क्लोन करें। यह मास्टर, उसके लेआउट, और संबन्धित थीम को साथ ले जाता है।

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

जब स्रोत स्लाइड को गंतव्य में वही रूप चाहिए, तो यह पसंदीदा कार्यप्रवाह है। एक असंबंधित गंतव्य मास्टर पर सामग्री को क्लोन करना थीम‑ड्रिवेन रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकता है।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसके वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है, जबकि अन्य स्लाइडों द्वारा विरासत में ली गई थीम अपरिवर्तित रहती है। स्थानीय ओवरराइड को हटाकर विरासत मानों पर लौटने के लिए, कॉल करें [OverrideTheme.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/clear/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइडों पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। समान प्रारंभिक मेथड्स लेआउट की [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

कई लेआउट और स्लाइड को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, एक लेआउट परिवार को अलग स्टाइलिंग चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) में संग्रहीत होते हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ मिलाकर प्रस्तुत करता है।

![PowerPoint प्रस्तुति थीम के लिए पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background.StyleIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/background/styleindex/) की जाँच करें। `StyleIndex` थीम भराव न होने पर `0` का उपयोग करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह .NET संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। प्रत्येक प्रस्तुति में पृष्ठभूमि भराव शैलियों की संख्या समान होने का अनुमान न लगाएँ।

निम्नलिखित उदाहरण उपलब्ध पृष्ठभूमि भराव संख्या रिपोर्ट करता है, पहले मास्टर को थीम‑पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

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

दिखायी देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए उपयोग करें [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/)।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह इंडेक्स न समझें। किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड न करें और मानें कि वह दूसरी फ़ाइल में समान दिखेगा; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles/), और [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो क्रमशः सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग के दृश्य रूप से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह की जाँच करनी चाहिए न कि स्थिर गणना मानना चाहिए।

![समान आकार पर लागू सूक्ष्म, मध्यस्थ और तीव्र थीम प्रभाव](presentation-design_10.png)

C# में इन संग्रहों को एक्सेस करने पर संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। किसी आकार की शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapestyle/) के माध्यम से उजागर होती है। थीम शैली को बदलने से उन आकारों पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेट की गई आकारें अपरिवर्तित रह सकती हैं।

निम्नलिखित उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी शैडो को 10 पॉइंट दूरी के साथ सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉटों को संदर्भित करने वाले आकारों के लिए, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली को 10 पॉइंट दूरी की बाहरी शैडो मिलती है। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव और शैडो सेटिंग बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल यह बताते हैं कि किसी विशिष्ट स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि स्लाइड या आकार वास्तव में विरासत और स्थानीय ओवरराइड हल होने के बाद क्या उपयोग करता है। स्लाइड के लिए, कॉल करें [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。 पृष्ठभूमि के लिए उपयोग करें [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/), और भराव के लिए उपयोग करें [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/)।

निम्नलिखित उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकार भराव को पढ़ता है:

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

रेंडरिंग निदान, वैधता और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) देख रहे हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम प्रस्तुति को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइडें अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित करके उसके मूल स्वरूप को संरक्षित करना हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और फिर उस क्लोन किए गए मास्टर के साथ स्लाइड को [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) का उपयोग करके क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए उपयोग करें [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) तथा फॉर्मेट ऑब्जेक्ट जैसे [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) और [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।