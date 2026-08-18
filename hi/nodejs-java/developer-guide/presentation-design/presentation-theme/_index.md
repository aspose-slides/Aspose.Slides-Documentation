---
title: JavaScript में प्रस्तुतिकरण थीम प्रबंधित करें
linktitle: प्रस्तुतिकरण थीम
type: docs
weight: 10
url: /hi/nodejs-java/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुतिकरण थीम
- स्लाइड थीम
- थीम निर्धारित करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुतिकरण
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides के साथ JavaScript में प्रमुख प्रस्तुतिकरण थीम को बनाकर, अनुकूलित करके और PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुतिकरण थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरणों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-जनित वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अद्यतन कर सकता है।

Aspose.Slides में, प्रस्तुतिकरण‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) के माध्यम से प्राप्त किया जा सकता है। एक प्रस्तुतिकरण में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterthememanager/) के द्वारा ओवरराइड किया जा सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) से ओवरराइड कर सकते हैं। व्यवहार में, एक स्लाइड के लिए प्रभावी थीम इस विरासत शृंखला के माध्यम से निर्धारित होती है: प्रस्तुतिकरण थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत एवं ओवरराइड समाधान के बाद प्रभावी मान पढ़ना।

## **एक थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम, और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुतिकरण बाहरी स्रोत से आया हो क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, फ़िल, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर का उपयोग करती है, तो यह अनुमान न लगाएँ कि हर स्लाइड की प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और बाद में इस लेख में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम के रंग बदलें**

थीम‑जनित फ़िल, रेखाएँ और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुएँ थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल बदलता है, प्रस्तुतिकरण को सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रही, थीम बदलने के बाद उसका दृश्यमान रंग लाल हो जाता है। यदि आप योजना रंग को आकृति पर सीधे रंग से बदलते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को अब प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे विविधताओं को रंग परिवर्तन लागू करके उत्पन्न करता है। Aspose.Slides इन परिवर्तनओँ को [ColorTransformOperation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधता।

निम्न उदाहरण `Accent4` आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना हो जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; इन्हें एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में शीर्षकों के लिए एक प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) विधियाँ इन सेटों को उजागर करती हैं।

PowerPoint‑अनुरूप थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियाई (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियाई (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का पालन करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। एक स्पष्ट फ़ॉन्ट नाम वाला टेक्स्ट, जो थीम पहचानकर्ता नहीं है, थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलता।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिए प्रस्तुतिकरण फ़ॉन्ट देखें, देखें [PowerPoint Fonts](/slides/hi/nodejs-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह हैं, और वे अलग‑अलग समस्याओं का समाधान करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम सुरक्षित रखें**

यदि आप किसी स्लाइड को किसी अन्य प्रस्तुतिकरण में ले जाना चाहते हैं और उसकी मूल डिजाइन को सुरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुतिकरण में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर स्लाइड को क्लोन करने के लिए [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) और क्लोन किए गए मास्टर का उपयोग करें। यह मास्टर, उसकी लेआउट्स, और संबद्ध थीम को साथ ले जाता है।

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

यह वांछित कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए। केवल किसी असंबंधित गंतव्य मास्टर पर सामग्री क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि, और प्रभाव बदल सकते हैं।

### **एक मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसके वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइड्स की विरासत थीम को बदले। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि विशेष स्लाइड की अपनी ओवरराइड न हो। समान प्रारंभिक विधियों का उपयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुतिकरण‑स्तर थीम का उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल असामान्य मामलों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद के वैश्विक थीम परिवर्तनों को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि फ़िलें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) में संग्रहीत हैं। PowerPoint अपने UI में अधिक पृष्ठभूमि विकल्प प्रस्तुत कर सकता है जितने फ़िल परिभाषाएँ वास्तव में इस संग्रह में संग्रहीत हैं, क्योंकि UI थीम फ़िल को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![एक प्रस्तुतिकरण थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का निरीक्षण करें। `0` शैली इंडेक्स का अर्थ है कोई थीम फ़िल नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ हैं। यह JavaScript संग्रह की सीधे सूचकांक के विपरीत है, जहाँ `0` पहली संग्रहीत वस्तु को दर्शाता है। यह अनुमान न लगाएँ कि हर प्रस्तुतिकरण में समान संख्या में पृष्ठभूमि फ़िल शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गणना रिपोर्ट करता है, पहले मास्टर को थीम‑पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुतिकरण सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। जब आपको विरासत लागू होने के बाद अंतिम पृष्ठभूमि जाननी हो, तब [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही किसी फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति की उम्मीद न रखें; थीम शैली परिभाषाएँ प्रस्तुतिकरण‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम अलग‑अलग फ़िल, रेखा, और प्रभाव शैली संग्रहों को उजागर करती है, जिन्हें क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) से एक्सेस किया जा सकता है। सामान्य Office थीम्स में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित संख्या मानना चाहिए।

![एक ही आकृति पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप इन संग्रहों को JavaScript में एक्सेस करते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: सूचकांक `0` पहली संग्रहीत शैली है और सूचकांक `2` तीसरी है। आकृति की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapestyle/) के माध्यम से उजागर होती है। थीम शैली को बदलने से उन आकृतियों पर असर पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधे फ़ॉर्मेटिंग वाली आकृतियाँ अनछुई रह सकती हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

उन आकृतियों के लिए जो इन स्लॉट्स को संदर्भित करती हैं, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम फ़िल शैली ठोस फॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाती है। अंतिम दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकृति कौन‑सी शैली स्लॉट संदर्भित करती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल, और छाया सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट आपको बताते हैं कि किसी विशिष्ट स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि कोई स्लाइड या आकृति वास्तव में क्या उपयोग करती है विरासत और स्थानीय ओवरराइड समाधान के बाद। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें, और फ़िल के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) का उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकृति फ़िल को पढ़ता है:

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

रेंडरिंग निदान, मान्यकरण, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) को निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकृति ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में प्राप्त करती रहेंगी।

**एक प्रस्तुतिकरण से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसकी स्रोत उपस्थिति सुरक्षित रखना हो, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और उस मास्टर के साथ स्लाइड को क्लोन करें, यह [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) का उपयोग करके किया जाता है। इससे मास्टर, लेआउट, और थीम साथ रहती हैं।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।