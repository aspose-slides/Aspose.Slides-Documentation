---
title: .NET में प्रेजेंटेशन थीम प्रबंधित करें
linktitle: प्रेजेंटेशन थीम
type: docs
weight: 10
url: /hi/net/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेजेंटेशन थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त रंगपट्टिका
- थीम फ़ॉन्ट
- थीम शैली
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में मुख्य प्रेजेंटेशन थीम का उपयोग करके PowerPoint फाइलों को सुसंगत ब्रांडिंग के साथ बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का समन्वित सेट निर्धारित करती है। थीम‑अवेयर ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं बजाय प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रेजेंटेशन‑स्तर की थीम [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) प्रॉपर्टी के माध्यम से उपलब्ध है। एक प्रेजेंटेशन में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/masterthememanager/overridetheme/) के द्वारा प्रेजेंटेशन थीम को ओवरराइड कर सकता है, एक लेआउट अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) के द्वारा ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकता है। व्यवहार में, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से हल होती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड शैलियाँ, और इफ़ेक्ट्स](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियों को अपडेट करना, और विरासत तथा ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम की [ColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/fontscheme/), और [FormatScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/mastertheme/formatscheme/) को उजागर करता है। इन संग्रहों का निरीक्षण करना, विशेष रूप से जब प्रेजेंटेशन बाहरी स्रोत से आता है, उपयोगी होता है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम प्रॉपर्टीज़ पढ़ता है और बताता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन, और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

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

यदि फाइल कई मास्टर उपयोग करती है, तो यह मान नहीं लेना चाहिए कि प्रत्येक स्लाइड की प्रभावी थीम समान है। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑अवेयर फ़िल्स, लाइन्स, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) एनेमरेशन से एक तर्कसंगत रंग का संदर्भ दे सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग का संदर्भ देते हैं, नए मान के मुकाबले हल हो जाते हैं। सीधे RGB रंग उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल बदलता है, प्रेजेंटेशन सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस फ़िल को अब प्रभावित नहीं करेंगे।

### **अतिरिक्त रंगपट्टिका से रंगों का उपयोग करें**

PowerPoint थीम रंग पर रंग परिवर्तन लागू करके हल्के और गहरे वैरिएंट बनाता है। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/net/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त रंगपट्टिका से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि `Accent4` बाद में बदलता है, तो परिवर्तनित रंग नए `Accent4` मान से फिर से गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/net/aspose.slides/schemecolor/) एनेमरेशन `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/icolorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; ये मूल्य नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होते हैं। [FontScheme.Major](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी इन सेट्स को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (मेजर ईस्ट एशियन फ़ॉन्ट)

निम्न उदाहरण एक हेडिंग बनाता है जो मेजर लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो माइनर लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मेजर फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट माइनर फ़ॉन्ट का। जिसमें स्पष्ट फ़ॉन्ट नाम है, वह थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से बदल नहीं जाएगा।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो आम वर्कफ़्लो होते हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड्स को मूव करते समय स्रोत थीम सुरक्षित रखें**

यदि आप एक स्लाइड को किसी अन्य प्रेजेंटेशन में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेजेंटेशन में [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) के साथ क्लोन करें, फिर स्लाइड को क्लोन करते समय [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) और क्लोन किया हुआ मास्टर उपयोग करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम एक साथ रहेंगे।

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

जब स्रोत स्लाइड को लक्ष्य में वही जैसा दिखाना आवश्यक हो, यह वर्कफ़्लो प्राथमिकता रखता है। केवल कंटेंट को किसी असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑ड्रिवन रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिले थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर वापस जाने के लिए, [OverrideTheme.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि विशेष स्लाइड का अपना ओवरराइड न हो। वही प्रारंभिक मेथड्स लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो, तो मास्टर या प्रेजेंटेशन‑स्तर थीम उपयोग करें; जब एक लेआउट परिवार को अलग स्टाइलिंग चाहिए, तो लेआउट ओवरराइड उपयोग करें, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम बदलावों को अनुमान लगाना कठिन बना देते हैं।

## **थीम बैकग्राउंड स्टाइल अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) में संग्रहीत हैं। PowerPoint अपने UI में अधिक बैकग्राउंड विकल्प दिखा सकता है जितनी फ़िल परिभाषाएँ वास्तविक रूप से इस संग्रह में संग्रहीत हैं, क्योंकि UI थीम फ़िल को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint बैकग्राउंड स्टाइल गैलरी प्रेजेंटेशन थीम के लिए](presentation-design_8.png)

बैकग्राउंड स्टाइल उपयोग करने से पहले, संग्रह और वर्तमान [Background.StyleIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/background/styleindex/) को निरीक्षण करें। `StyleIndex` `0` के लिए कोई थीम्ड फ़िल नहीं दर्शाता; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह .NET संग्रह के शून्य‑आधारित इंडेक्सिंग से अलग है, जहाँ `[0]` का अर्थ पहला संग्रहीत आइटम है। यह मान न लें कि प्रत्येक प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल स्टाइल्स होंगी।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल काउंट रिपोर्ट करता है, पहले मास्टर को एक थीम्ड बैकग्राउंड संदर्भ असाइन करता है, और प्रेजेंटेशन सहेजता है:

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

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिए [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह इंडेक्स मानें नहीं। साथ ही एक फाइल से शैली संख्या को हार्ड‑कोड न करें और मानें कि वह दूसरी फाइल में समान दिखाई देगी; थीम शैली परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/net/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FillStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/linestyles/), और [EffectStyles](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/formatscheme/effectstyles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि स्थिर गणना पर भरोसा करना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम इफ़ेक्ट्स](presentation-design_10.png)

C# में इन संग्रहों तक पहुंचते समय संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। एक आकार के शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटेड आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए, पहली थीम लाइन शैली लाल हो जाती है, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी इफ़ेक्ट शैली को 10 पॉइंट दूरी वाला बाहरी शैडो मिलता है। अंतिम दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल, और शैडो सेटिंग्स बदलने के बाद थीम इफ़ेक्ट शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट्स आपको बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि एक स्लाइड या आकार वास्तव में विरासत और स्थानीय ओवरराइड हल होने के बाद क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) को कॉल करें। बैकग्राउंड के लिए, [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) का उपयोग करें, और फ़िल के लिए, [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) का उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, बैकग्राउंड, और पहली आकार फ़िल पढ़ता है:

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

रेंडरिंग डायग्नोस्टिक, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर बदलें बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/slidethememanager/) का उपयोग करके उसके ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में प्राप्त करती रहेंगी।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसकी स्रोत उपस्थिति को बनाए रखना हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और उस मास्टर का उपयोग करके स्लाइड को [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) के साथ क्लोन करें। इससे मास्टर, लेआउट, और थीम एक साथ रहेंगे।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/background/geteffective/) और [FillFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल हुए मान लौटाते हैं।