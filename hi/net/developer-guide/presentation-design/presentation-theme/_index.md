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
- बाहरी थीम
- THMX
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
description: "Aspose.Slides for .NET में मास्टर प्रस्तुति थीम का उपयोग करके PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाएं, अनुकूलित करें और रूपांतरित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करता है। थीम‑सचेत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं вместо प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) प्रॉपर्टी के माध्यम से उपलब्ध है। एक प्रस्तुति निचले स्तरों पर भी थीम ओवरराइड रख सकती है। एक मास्टर [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, एक लेआउट [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) के माध्यम से अपनी विरासत में मिली थीम को ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी वही कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

निम्नलिखित अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम का निरीक्षण, रंगों और फ़ॉन्टों को बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत तथा ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/), और [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) को उजागर करता है। इन संग्रहों का निरीक्षण करना, विशेष रूप से तब उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख के बाद दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखाएँ, और पाठ [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट जो अभी भी उस थीम रंग को संदर्भित करते हैं नए मान के विरुद्ध हल हो जाते हैं। जो ऑब्जेक्ट सीधे RGB रंग का उपयोग करते हैं, वे थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

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

चूँकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्यमान रंग लाल हो जाता है। यदि आप आकार पर योजना रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में बदलाव उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे संस्करण उत्पन्न करता है रंग परिवर्तन लागू करके। Aspose.Slides इन परिवर्तन को [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंग से उत्पन्न हल्के और गहरे संस्करण।

निम्न उदाहरण छह आयतें बनाता है जो `Accent4` पर आधारित हैं, पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये रूपांतरण अभी भी थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मिलाएँ**

[SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मानचित्रण स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये मान नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से बदले जाते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग के लिए एक प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी इन सेटों को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियान (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियान (Major East Asian Font)
* `+mn-cs` - बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Minor Complex Script Font)
* `+mj-cs` - हेडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Major Complex Script Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह टेक्स्ट जिसकी स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय है, थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलता।

प्रमुख और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों, जैसे सायरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
थीम फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/net/powerpoint-fonts/)।
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भों को हल करें**

टेक्स्ट का निरीक्षण करते समय, [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) में `+mn-lt` जैसी थीम रेफरेंस हो सकती है बजाय फ़ॉन्ट परिवार नाम के। उपयुक्त [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) के साथ [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) को कॉल करें। `+mj` और `+mn` उपसर्ग क्रमशः प्रमुख और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea`, `-cs` प्रत्यय उनके लैटिन, ईस्ट एशियान, और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

उस ऑब्जेक्ट पर [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) से प्रभावी थीम प्राप्त करें जिसके ऊपर टेक्स्ट लागू होता है। सामान्य स्लाइड टेक्स्ट के लिए `slide.CreateThemeEffective()` प्रयोग करें ताकि संदर्भ में उस स्लाइड की विरासत थीम और स्थानीय ओवरराइड शामिल हों। जब लेआउट या मास्टर का निरीक्षण कर रहे हों तो उसके अपने प्रभावी थीम का उपयोग करें। यह न मानें कि पहले मास्टर की थीम हर स्लाइड पर लागू है।

निम्न उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट को संदर्भित करता है। यह [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) के माध्यम से स्लाइड फ़ॉन्ट योजना को प्रारंभ करता है और प्रमुख और गौण लैटिन फ़ॉन्ट को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे इनपुट फ़ाइल के बिना परिणाम पुनरुत्पादनीय बनता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

आउटपुट `+mn-lt -> Calibri` के बाद `Verdana -> Verdana` है। संग्रहीत रेफ़रेंस अपरिवर्तित रहता है, जबकि स्पष्ट फ़ॉन्ट नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj-lt` उपयोग करता, तो यह इस थीम में `Arial` पर हल होता।

थीम रेफ़रेंस को हल करने से निर्धारित होता है कि थीम द्वारा कौन सी फ़ॉन्ट परिवार निर्दिष्ट है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान ग्लिफ़ फॉलबैक के बाद उपयोग की गई फ़ाइल की जांच नहीं करता। उन अलग चरणों के लिए देखें [Font Selection Sequence](/slides/hi/net/font-selection-sequence/) और [Font Substitution](/slides/hi/net/font-substitution/)।

## **थीम को कॉपी या लागू करें**

नीचे दिए गए वर्कफ़्लो विभिन्न थीम‑संबंधित समस्याओं को हल करते हैं।

### **बाहरी थीम को किसी मास्टर‑निर्भर स्लाइड पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) का उपयोग करें। [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) संग्रह से वह मास्टर चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) को लागू करता है, और थीम फ़ाइल पथ को मौड में पास करें।

यह विधि निम्न कार्य करती है:

1. चुने हुए मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
1. बाहरी थीम को नए मास्टर पर लागू करती है।
1. पूर्व में चुने हुए मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर से जोड़ती है।
1. नव निर्मित [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) को लौटाती है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम को लागू करता है, प्रस्तुति सहेजता है, और परिणाम पुनः खोलता है:

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

एक अमान्य, क्षतिग्रस्त या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी सबक्लास को उत्पन्न कर सकती है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को वैध करें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और केवल तब प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल वे स्लाइड्स जिन्हें चुने हुए मास्टर पर निर्भरता थी, पुनः असाइन की जाती हैं। अन्य मास्टर से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखते हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखाएँ, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड भी नई मास्टर से विरासत मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकता है जो रन‑टाइम वातावरण में उपलब्ध न हों। निरंतर रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/net/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) को कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर वर्कफ़्लो है: विधि `.thmx` फ़ाइल पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो उसे प्रतिनिधि स्लाइड से [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) और [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर रेफ़रेंसेज़ को सहेजें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूँढता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

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

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। किसी अन्य मास्टर से जुड़ी स्लाइड्स को री‑स्टाइल नहीं किया जाता।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप स्लाइड को अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर क्लोन किए गए मास्टर के साथ स्लाइड को [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) से क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम एक साथ स्थानांतरित होते हैं।

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

यह वर्कफ़्लो तब पसंदीदा है जब स्रोत स्लाइड को लक्ष्य में समान दिखना आवश्यक हो। केवल सामग्री को असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रहना आवश्यक है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) विधियां तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइड्स की विरासत थीम को बदले। स्थानीय ओवरराइड को हटाकर विरासत मानों पर लौटने के लिये [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपना स्वयं का ओवरराइड न रखे। वही प्रारंभिक विधियां लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग की जा सकती हैं:

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

जब कई लेआउट और स्लाइड को एक ही बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड और वास्तविक अपवादों के लिये स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद की वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) में संग्रहीत होती हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली रेफ़रेंस के साथ संयोजित कर सकता है।

![प्रस्तुति थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) का निरीक्षण करें। `StyleIndex` `0` का उपयोग बिना थीम भराव के करता है; सकारात्मक मूल्य थीम पृष्ठभूमि‑शैली रेफ़रेंस होते हैं। यह .NET संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ हों।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम‑पृष्ठभूमि रेफ़रेंस असाइन करता है, और प्रस्तुति को सहेजता है:

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

दर्शनीय परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिये [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह सूचक मानें नहीं। साथ ही किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान रूप मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

थीम फ़ॉर्मेट योजना में अलग‑अलग [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/), और [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) संग्रह होते हैं। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियाँ रखती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को निरीक्षण करना चाहिए न कि स्थिर गिनती मान लेना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

C# में इन संग्रहों तक पहुँचते समय संग्रह सूचक शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली और `[2]` तृतीय है। आकार की शैली‑रेफ़रेंस सूचक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर असर पड़ेगा जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेट किए गए आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तृतीय भराव शैली बदलता है, तृतीय प्रभाव शैली में बाहरी छाया सक्रिय करता है, और परिणाम सहेजता है:

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

इन स्लॉटों को संदर्भित करने वाले आकारों के लिये, पहली थीम रेखा शैली लाल हो जाती है, तृतीय थीम भराव शैली ठोस फॉरेस्ट ग्रीन हो जाती है, और तृतीय प्रभाव शैली में दूरी 10 पॉइंट वाली बाहरी छाया जुड़ जाती है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव और छाया सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **एक आकार के लिये थीम भराव और रेखा शैलियाँ चुनें**

एक आकार अपने भराव और रूपरेखा को स्वतंत्र रूप से [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) और [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) के द्वारा चुन सकता है। दोनों प्रॉपर्टी के लिये, सूचक `1` संबंधित थीम संग्रह की पहली प्रविष्टि (`FillStyles[0]` या `LineStyles[0]`) चुनता है, और सूचक `2` दूसरी प्रविष्टि चुनता है।

निम्न उदाहरण दो भराव शैलियाँ (सोना और आकाश‑नीला) और दो रेखा शैलियाँ (6 pt पर गहरा नीला और 12 pt पर गहरा लाल) को नई प्रस्तुति की डिफ़ॉल्ट थीम में सेट करता है। यह स्लाइड को तीन चरणों में सहेजता है ताकि आप PowerPoint में परिणाम तुलना कर सकें।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| प्रारम्भिक शैलियाँ | दाएँ रूपरेखा बदलें | पहली थीम भराव संपादित करें |
|:---:|:---:|:---:|
| ![सोने और आकाश‑नीले आयतें समान पतली गहरी नीली रूपरेखा के साथ](theme-style-initial.png) | ![अब आकाश‑नीली आयत के पास मोटी गहरी लाल रूपरेखा है](theme-style-line-changed.png) | ![बाएँ आयत अब हरा है और दोनों रूपरेखा अपरिवर्तित हैं](theme-style-fill-changed.png) |

विभिन्न रेखा शैली चुनने से केवल दाएँ आयत की रूपरेखा बदलती है। पहली थीम भराव संपादित करने से सभी आकार जिनका उपयोग हो रहा है, अपडेट होते हैं। यहाँ, केवल बायाँ आयत हरा हो जाता है।

किसी मौजूदा आकार पर, स्थानीय भराव रंग, रेखा रंग, या रेखा चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकती है। यदि शैली सूचक बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो आकार की [direct formatting](/slides/hi/net/shape-formatting/) जाँचें।

## **निर्धारित करें कि क्या प्रभावी सॉलिड भराव थीम रंग का उपयोग करता है**

भराव ऑब्जेक्ट पर सीधे संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या किसी अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। उस पदानुक्रम को अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) में बदलने के लिये [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) को कॉल करें। पहले [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) जांचें। केवल जब यह `FillType.Solid` हो तब ही सॉलिड‑भराव गुण पढ़ें।

सॉलिड भराव के लिये, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) विरासत, थीम लुक‑अप, और रंग परिवर्तन लागू होने के बाद अंतिम RGB मान लौटाता है। [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का मान दर्शाता है कि प्रभावी सॉलिड भराव योजना रंग पर आधारित नहीं है। इस वर्कफ़्लो में जहाँ भराव केवल थीम रंग या सीधे RGB रंग होते हैं, यह मान सीधे RGB भराव को पहचानता है।

स्थानीय [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) मान को अकेले भराव वर्गीकृत करने के लिये उपयोग न करें। उदाहरण के लिये, कोई टेक्स्ट भाग में स्थानीय स्तर पर कोई योजना रंग परिभाषित नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` होता है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेता है और `Text1` या `Accent6` में हल होता है। उलट, `SolidFillSchemeColor` बताता है कि कौन सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकार भराव और टेक्स्ट‑भाग भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबंधित योजना रंग प्रिंट करता है, और उन सॉलिड भरावों को चिन्हित करता है जो थीम रंग परिवर्तन का अनुसरण नहीं करेंगे:

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

`NotDefined` शाखा उन सॉलिड भरावों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट्स में परिवर्तन पर प्रतिक्रिया नहीं देते। जब प्रस्तुति को नई ब्रांड पैलेट का अनुसरण करना हो, तो उन वस्तुओं की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान स्वरूप दिखाता है, जबकि योजना मान यह बताता है कि वह स्वरूप थीम से जुड़ा है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड, या किसी विरासत फ़ॉर्मेटिंग को बदलने के बाद, फिर से `GetEffective` कॉल करें और तुलना या रिपोर्ट करने से पहले नया `IFillFormatEffectiveData` ऑब्जेक्ट पढ़ें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिये, [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) को कॉल करें। पृष्ठभूमि के लिये, [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) उपयोग करें, और भराव के लिये, [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और प्रथम आकार भराव पढ़ता है:

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

रेंडरिंग निदान, वैधता, और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम स्वरूप को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की प्रत्येक स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं किसी एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपनी मौजूदा थीम विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसकी स्रोत उपस्थिति को संरक्षित रखना हों, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) से क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) तथा [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) की संबंधित प्रभावी‑डेटा विधियों का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।