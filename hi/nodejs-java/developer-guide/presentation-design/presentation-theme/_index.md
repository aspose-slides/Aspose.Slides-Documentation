---
title: JavaScript में प्रेजेंटेशन थीम प्रबंधित करें
linktitle: प्रेजेंटेशन थीम
type: docs
weight: 10
url: /hi/nodejs-java/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेजेंटेशन थीम
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
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में मुख्य प्रेजेंटेशन थीम बनाएं, अनुकूलित करें और PowerPoint फ़ाइलों को स्थिर ब्रांडिंग के साथ बनाएँ, संशोधित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-ज्ञात वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को निश्चित मान के रूप में संग्रहीत करती हैं, इसलिए थीम बदलने से कई वस्तुएँ एक साथ अपडेट हो सकती हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) के माध्यम से उपलब्ध है। एक प्रस्तुति में नीचे स्तरों पर भी थीम ओवरराइड हो सकता है। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterthememanager/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत शृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत व ओवरराइड के बाद प्रभावी मान पढ़ना।

## **एक थीम देखें**

[MasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) ऑब्जेक्ट [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) के माध्यम से थीम के रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को उजागर करता है। इन संग्रहों को बदलने से पहले निरीक्षण करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि हर स्लाइड की समान प्रभावी थीम है। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑ज्ञात भराव, रेखाएँ, और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तब सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुएँ थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल बदलता है, प्रस्तुति को सहेजता है, फिर उसे खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, इसलिए थीम बदलने पर उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकृति पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करता है रंग परिवर्तन लागू करके। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तनित रंग नए `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मूल्यों को `ColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग निश्चित है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो एक रूप से दूसरे में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए एक प्रमुख फ़ॉन्ट सेट और मुख्य पाठ के लिए एक लघु फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) विधियों से ये सेट उजागर होते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग पाठ फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी पंक्ति जो लघु लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

शीर्षक प्रमुख फ़ॉन्ट का पालन करता है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। वह पाठ जिसमें स्पष्ट फ़ॉन्ट नाम है, थीम पहचानकर्ता के बजाय, थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलता।

मुख्य और लघु फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी रख सकते हैं। इन मैपिंग को निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/nodejs-java/script-specific-font-mappings/)।

{{% alert color="info" title="सलाह" %}}

प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/nodejs-java/powerpoint-fonts/)।

{{% /alert %}}

## **एक थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह हैं, और वे अलग-अलग समस्याओं को हल करते हैं।

### **स्लाइड स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप एक स्लाइड को दूसरी प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) द्वारा क्लोन करें, फिर स्लाइड को क्लोन करें [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) और क्लोन किए गए मास्टर के साथ। इससे मास्टर, उसके लेआउट, और संबंधित थीम साथ में चलेगी।

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

यह कार्यप्रवाह तब पसंदीदा है जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए। केवल सामग्री को असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि, और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह स्लाइड द्वारा उपयोग की गई थीम को बदले बिना अन्य स्लाइड की विरासत वाली थीम को नहीं बदलता। स्थानीय ओवरराइड को हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइडों पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड का अपना ओवरराइड न हो। समान प्रारंभिक विधियों का उपयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड समान आधार डिज़ाइन साझादारी करनी चाहिए तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, एक लेआउट ओवरराइड तब उपयोग करें जब एक लेआउट परिवार को अलग शैली चाहिए, और स्लाइड ओवरराइड केवल वास्तविक अपवादों के लिए। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद की वैश्विक थीम परिवर्तन को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) में संग्रहीत होती हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है जितनी भराव परिभाषाएँ इस संग्रह में भौतिक रूप से संग्रहीत हैं, क्योंकि UI थीम भराव को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![प्रेजेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) को निरीक्षण करें। `0` शैली सूचक का अर्थ है कोई थीम्ड भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ हैं। यह जावास्क्रिप्ट संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `0` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती की रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि संदर्भ सौंपता है, और प्रस्तुति सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी खुद की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने की आवश्यकता होने पर [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}

शैली सूचक को शून्य‑आधारित संग्रह सूचक न समझें। साथ ही एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।

{{% /alert %}}

{{% alert color="info" title="सलाह" %}}

सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/)।

{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

थीम फ़ॉर्मेट योजना में अलग-अलग भराव, रेखा, और प्रभाव शैली संग्रह होते हैं जिन्हें [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) के द्वारा उजागर किया जाता है। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप में सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाते हैं, लेकिन कोड को प्रत्येक संग्रह को निरीक्षण करना चाहिए न कि स्थिर गिनती मान लेना।

![एक ही आकृति पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप इन संग्रहों को जावास्क्रिप्ट में एक्सेस करते हैं, तो संग्रह सूचक शून्य‑आधारित होता है: सूचक `0` पहला संग्रहीत शैली है और सूचक `2` तीसरा। आकृति की शैली‑संदर्भ सूचक अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapestyle/) के द्वारा उजागर किया जाता है। थीम शैली को बदलने से उन आकृतियों पर असर पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधे फ़ॉर्मेट की गई आकृतियों में परिवर्तन नहीं हो सकता।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहला रेखा शैली बदलता है, तिसरा भराव शैली बदलता है, तिसरी प्रभाव शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

उन आकृतियों के लिए जो इन स्लॉट्स को संदर्भित करती हैं, पहला थीम रेखा शैली लाल हो जाता है, तिसरा थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन बन जाता है, और तिसरी प्रभाव शैली में 10 पॉइंट दूरी का बाहरी शैडो जुड़ जाता है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकृति कौन से शैली स्लॉट संदर्भित करती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव, और शैडो सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के बाद स्लाइड या आकृति वास्तविक में क्या उपयोग करती है। स्लाइड के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें, और भराव के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) का।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकृति भराव पढ़ता है:

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

रेंडरिंग निदान, सत्यापन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) का निरीक्षण करते हैं, तो आप एक मास्टर, लेआउट, स्लाइड, या आकृति ओवरराइड को चूक सकते हैं जो अंतिम रूप को बदलता है।

## **FAQ**

**क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन उस स्लाइड तक सीमित रहता है; अन्य स्लाइड अपनी मौजूदा थीम विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसकी स्रोत उपस्थिति बनाए रखनी हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और उस मास्टर के साथ स्लाइड को क्लोन करें [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) का उपयोग करके। यह मास्टर, लेआउट, और थीम को एक साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा विधियों को कॉल करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।