---
title: जावास्क्रिप्ट में प्रेजेंटेशन थीम प्रबंधित करें
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
- बाहरी थीम
- THMX
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट में मास्टर प्रेजेंटेशन थीम बनाना, अनुकूलित करना और PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ बदलना।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का समन्वित सेट निर्धारित करती है। थीम‑सजग ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहित करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रेजेंटेशन‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) के माध्यम से उपलब्ध कराया जाता है। एक प्रेजेंटेशन में निम्न स्तरों पर भी थीम ओवरराइड्स हो सकते हैं। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterthememanager/) के द्वारा प्रेजेंटेशन थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) के द्वारा ओवरराइड कर सकते हैं। वास्तविक में, स्लाइड की प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियाँ अपडेट करना, और विरासत तथा ओवरराइड्स के हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम, और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रेजेंटेशन बाहरी स्रोत से आया हो, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुणों को पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल में कई मास्टर उपयोग किए गए हों, तो यह न मानें कि हर स्लाइड की प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो, तब बाद में दर्शाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑सजग फ़िल्स, लाइन्स, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग को संदर्भित कर सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अब भी उस थीम रंग को संदर्भित करते हैं, नए मान के विरुद्ध हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अन्त उदाहरण एक शैप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेजेंटेशन को सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्य रंग लाल हो जाता है। यदि आप शैप पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे विविधताएँ बनाने के लिए रंग परिवर्तन लागू करता है। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

निम्न उदाहरण `Accent4` के आधार पर छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम को सहेजता है:

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तनित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में शीर्षक के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) मेथड्स ये सेट उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं को टेक्स्ट फ़ॉर्मेटिंग में उपयोग किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह टेक्स्ट जो स्पष्ट फ़ॉन्ट नाम रखता है, थीम पहचानकर्ता के बजाय, फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलेगा।

प्रमुख और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन‑प्रणालियों के लिए फ़ॉन्ट मैपिंग भी शामिल हो सकते हैं, जैसे सिलिरिक, अरबी, जापानी, जॉर्जियन, और थाना। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/nodejs-java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिये देखें [PowerPoint Fonts](/slides/hi/nodejs-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम को कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) का उपयोग करें। पहले [Presentation.getMasters](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) संग्रह से इच्छित मास्टर चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) द्वारा दर्शाया जाता है, और मेथड को थीम फ़ाइल पाथ पास करें।

मेथड निम्न कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. नए मास्टर पर बाहरी थीम लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर से असाइन करता है।
1. नया बनाया गया [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) लौटाता है।

निम्न उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रेजेंटेशन सहेजता है:

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

एक अमान्य, भ्रष्ट, या असमर्थित थीम की वजह से [PptxReadException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पाथ को मान्य करें, फ़ाइल‑सिस्टम एक्सेस त्रुटियों को संभालें, और केवल तभी प्रेजेंटेशन सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल वही स्लाइड्स जो चयनित मास्टर पर निर्भर थीं, पुनः असाइन की गईं। अन्य मास्टरों से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम रखती हैं। थीम‑सजग रंग, फ़ॉन्ट, फ़िल, लाइन, बैकग्राउंड, और इफ़ेक्ट नई थीम के विरुध़ हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड्स नई मास्टर से विरासत में मिले मूल्यों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट्स को संदर्भित कर सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट्स स्थापित करें, उन्हें [custom font sources](/slides/hi/nodejs-java/custom-font/) के माध्यम से उपलब्ध कराएँ, या [font substitution](/slides/hi/nodejs-java/font-substitution/) कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर कार्यप्रवाह है: मेथड `.thmx` फ़ाइल पाथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड्स को मैन्युअल रूप से बनाने की आवश्यकता नहीं रहती।

### **बहु‑मास्टर प्रेजेंटेशन में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पूर्वनिर्धारित न हो, तो इसे प्रतिनिधि स्लाइड के माध्यम से [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) से प्राप्त करें। किसी भी थीम को लागू करने से पहले मूल मास्टर रेफ़रेंसेज़ को सहेजें, क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो सेक्शन की स्लाइड्स के मास्टर खोजता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य किसी भी मास्टर से जुड़ी स्लाइड्स अपरिवर्तित रहती हैं।

### **स्लाइड स्थानांतरण के समय स्रोत थीम संरक्षित रखें**

यदि आप किसी स्लाइड को अन्य प्रेजेंटेशन में ले जाना चाहते हैं और उसकी मूल डिज़ाइन बनाये रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेजेंटेशन में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर स्लाइड को [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) और क्लोन किए गए मास्टर के साथ क्लोन करें। यह मास्टर, उसके लेआउट, और संबंधित थीम को साथ ले जाता है।

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

जब स्रोत स्लाइड को लक्ष्य में समान दिखना आवश्यक हो, तब यह पसंदीदा कार्यप्रवाह है। केवल सामग्री को असंबद्ध लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारम्भ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को使用 करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान प्रारम्भिक मेथड्स को [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करते हैं तो मास्टर या प्रेजेंटेशन‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तब लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिये स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड्स बाद में वैश्विक थीम परिवर्तन को अनुमानित करना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम के बैकग्राउंड फ़िल्स [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) में संग्रहीत होते हैं। PowerPoint UI में बैकग्राउंड विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकती है, क्योंकि UI थीम फ़िल्स को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकती है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

बैकग्राउंड शैली का उपयोग करने से पहले संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) को निरीक्षण करें। शैली इंडेक्स `0` का मतलब कोई थीम्ड फ़िल नहीं; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल रेफ़रेंस होते हैं। यह जावास्क्रिप्ट संग्रह को सीधे इंडेक्स करने से भिन्न है जहाँ `0` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गिनती रिपोर्ट करता है, प्रथम मास्टर को थीम्ड बैकग्राउंड रेफ़रेंस असाइन करता है, और प्रेजेंटेशन सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड‑स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिये [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके अन्य फ़ाइल में समान दिखावट मानना टालें; थीम शैली परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिये देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

थीम फ़ॉर्मेट स्कीम अलग‑अलग फ़िल, लाइन, और इफ़ेक्ट शैली संग्रहों को उजागर करती है, जो क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) से उपलब्ध हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो क्रमशः सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को निश्चित गिनती मानने की बजाय प्रत्येक संग्रह को निरीक्षण करना चाहिए।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

जब आप जावास्क्रिप्ट में इन संग्रहों तक पहुँचते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: इंडेक्स `0` पहला संग्रहीत शैली है और इंडेक्स `2` तीसरा। शैप का शैली‑रेफ़रेंस इंडेक्स एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapestyle/) द्वारा उजागर होता है। थीम शैली को बदलने से उन शैप्स पर प्रभाव पड़ेगा जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले शैप्स अपरिवर्तित रह सकते हैं।

निम्न उदाहरण आवश्यक शैली प्रविष्टियों की उपस्थिति जांचता है, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले शैप्स के लिये, पहली थीम लाइन शैली लाल हो जाएगी, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी इफ़ेक्ट शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाएगी। वास्तविक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक शैप कौन से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **यह निर्धारित करें कि प्रभावी सॉलिड फ़िल थीम रंग का उपयोग करता है या नहीं**

फ़िल ऑब्जेक्ट पर सीधे संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। इस पदानुक्रम को अपरिवर्तनीय प्रभावी‑फ़िल स्नैपशॉट में हल करने के लिये [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) को कॉल करें। पहले उसके `getFillType` मान की जाँच करें। केवल जब वह `FillType.Solid` हो, तभी सॉलिड‑फ़िल गुण पढ़ें।

सॉलिड फ़िल के लिये, `getSolidFillColor` विरासत, थीम लुकअप, और रंग परिवर्तन लागू होने के बाद अंतिम रेंडर किया गया RGB मान लौटाता है। `getSolidFillSchemeColor` संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का अर्थ है कि प्रभावी सॉलिड फ़िल किसी स्कीम रंग पर आधारित नहीं है। थीम‑रंग या सीधे RGB रंग के बीच अंतर करने वाले कार्यप्रवाह में यह मान सीधे RGB फ़िल की पहचान करता है।

स्थानीय [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorformat/) मान को अकेले उपयोग करके फ़िल वर्गीकृत न करें। उदाहरण के लिये, कोई टेक्स्ट भाग स्थानीय रूप से कोई स्कीम रंग न परिभाषित करे, इसलिए उसका स्थानीय मान `NotDefined` हो सकता है, जबकि उसका प्रभावी फ़िल थीम रंग से विरासत में लेकर `Text1` या `Accent6` में हल हो जाता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि कौन सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या फ़ॉर्मेटिंग पदानुक्रम के अन्य स्तर से आया है।

निम्न उदाहरण प्रेजेंटेशन लोड करता है, शैप फ़िल और टेक्स्ट‑पोर्टियन फ़िल दोनों का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबंधित स्कीम रंग प्रिंट करता है, और उन सॉलिड फ़िल को चिन्हित करता है जो थीम रंग परिवर्तन को ट्रैक नहीं करेंगे:

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

`NotDefined` शाखा उन सॉलिड फ़िल की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट परिवर्तन पर प्रतिक्रिया नहीं देंगे। जब प्रेजेंटेशन को नई ब्रांड पैलेट के साथ संरेखित करना हो, तो उन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दिखावट दिखाता है, जबकि स्कीम मान बताता है कि वह दिखावट थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रेजेंटेशन थीम, थीम ओवरराइड, या कोई विरासत फ़ॉर्मेटिंग बदलने के बाद, फिर से `getEffective` कॉल करें और नई प्रभावी‑फ़िल ऑब्जेक्ट पढ़ें, फिर रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल यह बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड्स हल होने के बाद स्लाइड या शैप वास्तव में क्या उपयोग करता है। स्लाइड के लिये, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) को कॉल करें। बैकग्राउंड के लिये, [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) उपयोग करें, और फ़िल के लिये, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/)।

निम्न उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड, और प्रथम शैप फ़िल पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैधता, और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) का निरीक्षण करते हैं, तो आप ऐसे मास्टर, लेआउट, स्लाइड, या शैप ओवरराइड को मिस कर सकते हैं जो अंतिम दिखावट को बदलते हैं।

## **आम प्रश्नोत्तर**

**क्या बाहरी थीम लागू करने से प्रेजेंटेशन की हर स्लाइड पर असर पड़ता है?**

नहीं। [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidethememanager/) का उपयोग करके उसका ओवरराइड थीम प्रारम्भ करें। परिवर्तन केवल उस स्लाइड पर स्थानीय रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक थीम को एक प्रेजेंटेशन से दूसरे में ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित कर उसकी स्रोत दिखावट बनाए रखनी हो, तो स्रोत मास्टर को लक्ष्य में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) से क्लोन करें और फिर स्लाइड को [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) और क्लोन किए गए मास्टर के साथ क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड्स के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड्स लागू होने के बाद हल किए गए मान लौटाते हैं।