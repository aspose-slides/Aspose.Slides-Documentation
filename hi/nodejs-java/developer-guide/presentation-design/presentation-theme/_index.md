---
title: "JavaScript में प्रस्तुति थीम प्रबंधित करें"
linktitle: "प्रेज़ेंटेशन थीम"
type: docs
weight: 10
url: /hi/nodejs-java/presentation-theme/
keywords:
- "PowerPoint थीम"
- "प्रस्तुति थीम"
- "स्लाइड थीम"
- "थीम सेट करें"
- "थीम बदलें"
- "थीम प्रबंधित करें"
- "बाहरी थीम"
- THMX
- "थीम रंग"
- "अतिरिक्त पैलेट"
- "थीम फ़ॉन्ट"
- "थीम शैली"
- "थीम प्रभाव"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में Aspose.Slides for Node.js के साथ मुख्य प्रस्तुति थीम को प्रबंधित करें, निरंतर ब्रांडिंग के साथ PowerPoint फ़ाइलें बनाने, अनुकूलित करने और परिवर्तित करने के लिए।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भराव, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-आधारित वस्तुएँ इन साझा परिभाषाओं का संदर्भ लेती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तरीय थीम को **[Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/)** के माध्यम से प्राप्त किया जा सकता है। एक प्रस्तुति निम्न स्तरों पर भी थीम ओवरराइड रख सकती है। एक मास्टर **[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/)** के द्वारा प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड **[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)** के द्वारा उसकी विरासत में मिली थीम को ओवरराइड कर सकते हैं। व्यवहार में, स्लाइड की प्रभावी थीम इस विरासत श्रृंखला द्वारा निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के अनुभाग सबसे आम थीम कार्य‑प्रवाह दिखाते हैं: एक थीम की जाँच करना, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियाँ अपडेट करना, तथा विरासत और ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **एक थीम की जाँच करें**

**[MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)** वस्तु थीम की कलर स्कीम, फ़ॉन्ट स्कीम, और फ़ॉर्मेट स्कीम को क्रमशः **[MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)**, **[MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)**, और **[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)** के द्वारा उजागर करती है। इन्हें बदलने से पहले इन संग्रहों की जाँच करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर की जाँच करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर नीचे दिखाए गये प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑आधारित भराव, रेखा, और पाठ **[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)** enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप **[ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/)** में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग का संदर्भ ले रही हैं, नए मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग प्रयुक्त वस्तुएँ थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न अंत‑से‑अंत उदाहरण एक शैप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल बदलता है, प्रस्तुति सहेजता है, फिर इसे पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);

    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

क्योंकि आयत अभी भी `Accent4` से जुड़ी हुई है, इसलिए थीम बदलने के बाद उसका दृश्य रंग लाल हो जाता है। यदि आप शैप पर सीधे रंग के साथ स्कीम रंग को बदल देते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करता है रंग रूपांतरण लागू करके। Aspose.Slides इन रूपांतरणों को **[ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/)** enumeration के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मैप करें**

**[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)** enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि **[ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/)** समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थायी है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये कोई गतिशील रूपांतरण नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग्स के लिये एक मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिये एक गौण फ़ॉन्ट सेट होता है। **[FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/)** और **[FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/)** विधियाँ इन सेटों को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता पाठ स्वरूपण में उपयोग किए जा सकते हैं:

* `+mn‑lt` – बॉडी फ़ॉन्ट लैटिन (गौण लैटिन फ़ॉन्ट)
* `+mj‑lt` – हेडिंग फ़ॉन्ट लैटिन (मुख्य लैटिन फ़ॉन्ट)
* `+mn‑ea` – बॉडी फ़ॉन्ट ईस्ट एशियन (गौण ईस्ट एशियन फ़ॉन्ट)
* `+mj‑ea` – हेडिंग फ़ॉन्ट ईस्ट एशियन (मुख्य ईस्ट एशियन फ़ॉन्ट)
* `+mn‑cs` – बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (गौण कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट)
* `+mj‑cs` – हेडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (मुख्य कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));

    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

हेडिंग मुख्य फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह फ़ॉन्ट जो स्पष्ट फ़ॉन्ट नाम रखता है न कि थीम पहचानकर्ता, थीम फ़ॉन्ट स्कीम बदलने पर स्वतः नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणाली‑विशिष्ट फ़ॉन्ट मैपिंग भी हो सकती है, जैसे कि सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना। इन्हें जाँचने, जोड़ने, बदलने या हटाने के लिये देखें **[Script-Specific Theme Fonts](/slides/hi/nodejs-java/script-specific-font-mappings/)**।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिये देखें **[PowerPoint Fonts](/slides/hi/nodejs-java/powerpoint-fonts/)**।
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भ हल करें**

पाठ की जाँच करते समय, **[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/)** थीम संदर्भ जैसे `+mn‑lt` को लौट सकता है बजाय फ़ॉन्ट पारिवारिक नाम के। उपयुक्त प्रभावी थीम के साथ **[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/)** को कॉल करें ताकि वह संदर्भ हल हो सके। `+mj` और `+mn` उपसर्ग मुख्य और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea`, और `-cs` प्रत्यय क्रमशः लैटिन, ईस्ट एशियन, और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

वह प्रभावी थीम प्राप्त करें **[Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)** के द्वारा उस वस्तु पर जिससे थीम लागू होती है। सामान्य स्लाइड पर, इस विधि को स्लाइड पर कॉल करें ताकि संदर्भ में उस स्लाइड की विरासत थीम और स्थानीय ओवरराइड शामिल हों। जब लेआउट या मास्टर स्वयं की जाँच कर रहे हों, तो उसकी अपनी प्रभावी थीम उपयोग करें। यह न मानें कि पहले मास्टर की थीम सभी स्लाइड पर लागू है।

निम्न उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट का संदर्भ देता है। यह **[OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)** के द्वारा स्लाइड फ़ॉन्ट स्कीम को प्रारम्भ करता है और मुख्य व गौण लैटिन फ़ॉन्ट को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे परिणाम इनपुट फ़ाइल के बिना पुनरुत्पादनीय हो जाता है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

आउटपुट `+mn‑lt -> Calibri` के बाद `Verdana -> Verdana` है। संग्रहीत संदर्भ अपरिवर्तित रहता है, जबकि स्पष्ट पारिवारिक नाम जैसा है वैसा ही लौटता है। यदि भाग ने `+mj‑lt` इस्तेमाल किया होता, तो वह इस थीम में `Arial` में हल होता।

थीम संदर्भ को हल करना बताता है कि थीम द्वारा निर्दिष्ट फ़ॉन्ट परिवार कौन‑सा है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान उपसर्ग फ़ॉन्ट फ़ाइल निर्धारण की जाँच नहीं करता। देखें **[Font Selection Sequence](/slides/hi/nodejs-java/font-selection-sequence/)** और **[Font Substitution](/slides/hi/nodejs-java/font-substitution/)**।

## **एक थीम कॉपी या लागू करें**

नीचे के कार्य‑प्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भरत स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड को पुनः‑शैलित करना चाहते हों, तो **[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)** का उपयोग करें। **[Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)** संग्रह से वह मास्टर चुनें, जिसे **[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)** द्वारा दर्शाया जाता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
1. बाहरी थीम को नए मास्टर पर लागू करती है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड को नए मास्टर से जोड़ती है।
1. नया **[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)** लौटाती है।

निम्न उदाहरण प्रथम मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक अमान्य, दूषित, या असमर्थित थीम **[PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/)** उत्पन्न कर सकता है। उपयोगकर्ता‑द्वारा प्रदान किए गये पथ का मान्यकरण करें, फ़ाइल‑सिस्टम पहुँच विफलताओं को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल वे स्लाइड्स जिन्हें चयनित मास्टर पर निर्भर किया गया था, पुनः‑निर्धारित होते हैं। अन्य मास्टर‑संबद्ध स्लाइड्स अपनी मौजूदा मास्टर और थीम बनाए रखती हैं। थीम‑आधारित रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गये रंग, फ़ॉन्ट, भराव आदि अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड नई मास्टर से विरासत में प्राप्त मानों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट्स का संदर्भ दे सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग एवं निर्यात के लिये आवश्यक फ़ॉन्ट्स स्थापित करें, उन्हें **[custom font sources](/slides/hi/nodejs-java/custom-font/)** के द्वारा प्रदान करें, या **[font substitution](/slides/hi/nodejs-java/font-substitution/)** कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर कार्य‑प्रवाह है: विधि `.thmx` फ़ाइल पथ लेती है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं है।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो **[Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)** और **[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)** के द्वारा उसे प्रतिनिधि स्लाइड से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर रेफ़रेंस संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूँढ़ता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `firstGroupMaster` पर निर्भर थीं, और दूसरा कॉल केवल उन स्लाइड्स को जो `secondGroupMaster` पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स पुनः‑शैलित नहीं होतीं।

### **स्लाइड स्थानांतरित करते समय स्रोत थीम संरक्षित रखें**

यदि आप एक स्लाइड को अन्य प्रस्तुति में स्थानांतरित करके उसकी मूल डिज़ाइन संरक्षित रखना चाहते हैं, तो **[MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)** के द्वारा स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर **[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)** के द्वारा स्लाइड को क्लोन करें तथा क्लोन किया गया मास्टर उपयोग करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम साथ में चलेंगे।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);

        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

यह वही कार्य‑प्रवाह है जब स्रोत स्लाइड को लक्ष्य में समान दिखना आवश्यक हो। केवल सामग्री को असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारम्भ करें। **[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)**, **[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)**, और **[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)** विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

यह स्लाइड द्वारा उपयोग की गई थीम को बदलता है जबकि अन्य स्लाइड की विरासत थीम अपरिवर्तित रहती है। स्थानीय ओवरराइड हटाने और विरासत मान पर वापस जाने के लिये **[OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)** कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। समान प्रारम्भ विधियों को **[LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/)** के द्वारा उपयोग किया जा सकता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

जब कई लेआउट और स्लाइड समान बेस डिज़ाइन साझा करते हों, तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें; जब एक लेआउट परिवार को अलग शैली चाहिए, तो लेआउट ओवरराइड उपयोग करें, और केवल असाधारण मामलों के लिये स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को पूर्वानुमानित करना कठिन बना देते हैं।

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*लेआउट ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं जब तक कि स्लाइड अपना स्वयं का ओवरराइड न दे। थीम‑आधारित मान उनका समाधान किया हुआ स्कीम पालन करते हैं; स्पष्ट रूप से स्वरूपित वस्तुएँ अपना स्थानीय रूप बनाए रख सकती हैं। अभिप्रेत डिज़ाइन अपवाद के अनुसार ओवरराइड को संकीर्ण रखें।*
<!-- visual-explanation:presentation-theme:end -->

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव **[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)** में संग्रहीत होते हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान **[Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)** की जाँच करें। शैली अनुक्रम `0` का अर्थ है कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह जावास्क्रिप्ट संग्रह के सीधे अनुक्रमण से अलग है जहाँ `0` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ हों।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, प्रथम मास्टर को थीम पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी खुद की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिये **[Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)** उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली अनुक्रम को शून्य‑आधारित संग्रह अनुक्रम मान न लें। किसी फ़ाइल से एक शैली संख्या हार्ड‑कोड करके दूसरे फ़ाइल में समान दिखावट की उम्मीद न रखें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष पृष्ठभूमि स्वरूपण और पृष्ठभूमि विरासत के लिये देखें **[Presentation Background](/slides/hi/nodejs-java/presentation-background/)**।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रह **[FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)**, **[FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)**, और **[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)** द्वारा उजागर होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप में सूक्ष्म, मध्यम, और तीव्र स्वरूपण के अनुरूप होती हैं, परंतु कोड को प्रत्येक संग्रह की जाँच करनी चाहिए न कि स्थिर गिनती मान लेना।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

जब आप इन संग्रहों को जावास्क्रिप्ट में पहुँचते हैं, तो संग्रह अनुक्रम शून्य‑आधारित होता है: अनुक्रम `0` पहला संग्रहीत शैली है और `2` तीसरा। शैप की शैली‑संदर्भ अनुक्रम एक अलग अवधारणा है, जिसे **[ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/)** के द्वारा उजागर किया जाता है। थीम शैली को बदलने से उन शैप्स पर प्रभाव पड़ता है जो उस थीम शैली का संदर्भ लेते हैं; सीधे स्वरूपित शैप्स अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, प्रथम रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);

    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इन स्लॉट्स का संदर्भ लेने वाले शैप्स के लिये, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली को 10 पॉइंट दूरी वाली बाहरी छाया मिलती है। ठीक‑ठीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक शैप कौन‑से स्लॉट का संदर्भ लेता है और क्या सीधे स्वरूपण थीम को ओवरराइड करता है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **एक शैप के लिये थीम भराव और रेखा शैलियाँ चुनें**

एक शैप **[ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/)** और **[ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/)** के माध्यम से भराव तथा कंटूर को स्वतंत्र रूप से चुन सकता है। दोनों विधियों में अनुक्रम `1` संबंधित थीम संग्रह की पहली प्रविष्टि (`get_Item(0)`) चुनता है, और अनुक्रम `2` दूसरी (`get_Item(1)`) चुनता है।

निम्न उदाहरण दो भराव शैलियाँ (सोना और आकाश‑नीला) और दो रेखा शैलियाँ (6 pt पर डार्क ब्लू और 12 pt पर डार्क रेड) को नई प्रस्तुति की डिफ़ॉल्ट थीम में सेट करता है। यह स्लाइड को तीन चरणों पर सहेजता है ताकि आप PowerPoint में परिणाम की तुलना कर सकें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| प्रारम्भिक शैलियाँ | दाएँ रूपरेखा बदलें | पहले थीम भराव को संपादित करें |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

विभिन्न रेखा शैली चुनने से केवल दाएँ आयत की रूपरेखा बदलती है। पहले थीम भराव को संपादित करने से सभी शैप्स जो इसका उपयोग करते हैं, अपडेट होते हैं। यहाँ केवल बायाँ आयत हरा हो जाता है।

किसी मौजूदा शैप पर, स्थानीय भराव रंग, रेखा रंग, या रेखा चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकती है। यदि शैली अनुक्रम बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो शैप की **[direct formatting](/slides/hi/nodejs-java/shape-formatting/)** जाँचें।

## **यह निर्धारित करें कि प्रभावी सॉलिड भराव थीम रंग उपयोग करता है या नहीं**

एक भराव वस्तु पर सीधे संग्रहीत या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य स्वरूपण स्तर से विरासत में प्राप्त हो सकता है। **[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)** को कॉल करके वह पदानुक्रम एक अपरिवर्तनीय प्रभावी‑भराव स्नैपशॉट में हल किया जाता है। पहले `getFillType` मान जाँचें। केवल जब यह `FillType.Solid` हो, तब सॉलिड‑भराव गुण पढ़ें।

सॉलिड भराव के लिये, `getSolidFillColor` विरासत, थीम लुक‑अप, और रंग रूपांतरण लागू होने के बाद अंतिम RGB मान लौटाता है। `getSolidFillSchemeColor` संबंधित तार्किक **[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/)** स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का अर्थ है कि प्रभावी सॉलिड भराव किसी स्कीम रंग पर आधारित नहीं है। ऐसी कार्य‑प्रवाह में जहाँ भराव या तो थीम रंग या सीधे RGB रंग होते हैं, यह मान सीधे RGB भराव निर्धारित करता है।

केवल स्थानीय **[ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/)** मान से भराव वर्गीकरण न करें। उदाहरण के लिये, कोई टेक्स्ट भाग लोकली कोई स्कीम रंग नहीं रखता, इसलिए उसका स्थानीय मान `NotDefined` होता है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। उलट, `getSolidFillSchemeColor` बताता है कि कौन‑सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट वस्तु, पैराग्राफ, लेआउट, मास्टर, या अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, शैप भराव और टेक्स्ट‑पोर्टियन भराव दोनों का ऑडिट करता है, प्रत्येक अंतिम RGB मान और सम्बद्ध स्कीम रंग को प्रिंट करता है, तथा उन सॉलिड भरावों को फ़्लैग करता है जो थीम रंग परिवर्तन के साथ नहीं बदलेंगे:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` शाखा उन सॉलिड भरावों की ऑडिट सूची प्रदान करती है जो थीम‑रंग स्लॉट परिवर्तनों पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट के साथ संरेखित करना हो, तो इन वस्तुओं की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दिखावट दर्शाता है, जबकि स्कीम मान समझाता है कि वह दिखावट थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट वस्तुएँ स्नैपशॉट हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई विरासत स्वरूपण बदलने के बाद फिर से `getEffective` कॉल करें और तुलना या रिपोर्ट करने से पहले नया प्रभावी‑भराव वस्तु पढ़ें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम वस्तुओं से आप विशिष्ट स्तर पर क्या परिभाषित है, पता चलता है। प्रभावी मान बताते हैं कि एक स्लाइड या शैप वास्तव में विरासत और स्थानीय ओवरराइड के बाद क्या उपयोग करता है। स्लाइड के लिये **[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)** को कॉल करें। पृष्ठभूमि के लिये **[Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)**, और भराव के लिये **[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)** उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और प्रथम शैप भराव पढ़ता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();

    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

रेंडरिंग निदान, वैधता, और तुलना हेतु प्रभावी डेटा का उपयोग करें। यदि आप केवल **[Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/)** को जांचते हैं, तो आप उन मास्टर, लेआउट, स्लाइड, या शैप ओवरराइड को मिस कर सकते हैं जो अंतिम दिखावट को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। **[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)** केवल उन स्लाइड्स को पुनः‑निर्धारित करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बनाए रखती हैं।

**क्या मैं बिना मास्टर बदले एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के **[SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)** का उपयोग करें और उसका ओवरराइड थीम प्रारम्भ करें। परिवर्तन केवल उस स्लाइड पर ही रहेगा; अन्य स्लाइड्स अपनी मौजूदा थीम विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित करके उसकी मूल दिखावट संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य में **[MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)** से क्लोन करें और फिर स्लाइड को **[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)** के साथ उस मास्टर का उपयोग करके क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिये **[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)** और फ़ॉर्मेट वस्तुओं जैसे **[Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)** तथा **[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)** के समान प्रभावी‑डेटा विधियों का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गये मान लौटाते हैं।