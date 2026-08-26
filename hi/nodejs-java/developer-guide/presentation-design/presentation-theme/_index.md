---
title: जावास्क्रिप्ट में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides के साथ जावास्क्रिप्ट में मास्टर प्रस्तुति थीम को बनाएं, अनुकूलित करें और PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों के समन्वित सेट को परिभाषित करती है। थीम-सजागर वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

In Aspose.Slides, प्रस्तुति‑स्तर की थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterthememanager/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकता है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियां, और प्रभाव](theme-constituents.png)

नीچے के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण करें, रंग और फ़ॉन्ट बदलें, थीम की कॉपी बनाएं या लागू करें, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करें, और विरासत एवं ओवरराइड के बाद प्रभावी मान पढ़ें।

## **थीम का निरीक्षण करें**

The [MasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम के रंग योजना, फ़ॉन्ट योजना और फॉर्मेट योजना को [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों का निरीक्षण करना, विशेषकर जब प्रस्तुति बाहरी स्रोत से आती है, उपयोगी होता है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियां संग्रहीत हैं:

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

यदि एक फ़ाइल में कई मास्टर उपयोग किए गए हैं, तो यह न मानें कि प्रत्येक स्लाइड की वही प्रभावी थीम होगी। स्लाइड से संबद्ध मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम के रंग बदलें**

थीम-सचेत भराव, रेखाएं, और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग को संदर्भित कर सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नई मान के विरूद्ध हल की जाती हैं। सीधे RGB रंग उपयोग करने वाली वस्तुएँ थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न पूर्ण उदाहरण एक ऐसा आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्य रंग लाल हो जाएगा। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे संस्करण रंग परिवर्तन लागू करके प्राप्त करता है। Aspose.Slides इन परिवर्तन को [ColorTransformOperation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के और गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे संस्करण।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये संस्करण थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये वही थीम स्लॉट के वैकल्पिक नाम हैं; ये उन मानों को दर्शाते नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग्स के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक छोटे फ़ॉन्ट सेट होते हैं। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) मेथड उन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो छोटे लैटिन थीम फ़ॉन्ट का उपयोग करता है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मुख्य फ़ॉन्ट का पालन करती है और बॉडी टेक्स्ट छोटे फ़ॉन्ट का। वह टेक्स्ट जो स्पष्ट फ़ॉन्ट नाम का उपयोग करता है न कि थीम पहचानकर्ता, थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलेगा।

मुख्य और छोटे फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों के लिए फ़ॉन्ट मैपिंग भी शामिल कर सकते हैं, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियॉन, और थाना। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/nodejs-java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिए प्रस्तुति फ़ॉन्ट देखें, देखें [PowerPoint Fonts](/slides/hi/nodejs-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम की कॉपी बनाएं या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक बाहरी थीम को मास्टर की निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैली देना चाहते हों, तो [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) का उपयोग करें।  
[Presentation.getMasters](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) संग्रह से मास्टर चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) द्वारा प्रदर्शित होता है, और मेथड को थीम फ़ाइल पथ पास करें।

विधि निम्नलिखित संचालन करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।  
2. नए मास्टर पर बाहरी थीम लागू करता है।  
3. उस नए मास्टर को सभी स्लाइड्स को असाइन करता है जो पहले चयनित मास्टर पर निर्भर थीं।  
4. नए बनाए गए [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) को लौटाता है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

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

एक असमान्य, भ्रष्ट, या असमर्थित थीम [PptxReadException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxreadexception/) का कारण बन सकती है। उपयोगकर्ताओं द्वारा प्रदान किए गए पथों को सत्यापित करें, फ़ाइल‑सिस्टम पहुँच त्रुटियों को संभालें, और केवल तभी प्रस्तुति को सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों से संबद्ध स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखाएं, पृष्ठभूमि और प्रभाव बाहरी थीम के विरूद्ध हल किए जाते हैं। सीधे सौंपे गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकती है। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नई मास्टर से विरासत में मिली मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट्स का संदर्भ दे सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट्स स्थापित करें, उन्हें [custom font sources](/slides/hi/nodejs-java/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/nodejs-java/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: मेथड `.thmx` फ़ाइल पथ को स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर अग्रिम में ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड के माध्यम से [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत रखें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

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

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `firstGroupMaster` पर निर्भर थीं, और दूसरा कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `secondGroupMaster` पर निर्भर थीं। अन्य किसी भी मास्टर से जुड़ी स्लाइड्स पुनः शैली नहीं दी जातीं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप एक स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिजाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) के साथ क्लोन करें, फिर उस क्लोन किए गए मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) से स्लाइड को क्लोन करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम एक साथ ले जाएँगे।

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

यह प्राथमिक कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए। केवल सामग्री को अनसंबद्ध गंतव्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड आरंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह उस स्लाइड द्वारा उपयोग की जाने वाली थीम को बदलता है बिना अन्य स्लाइड्स द्वारा विरासत में ली गई थीम को बदले। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए, [OverrideTheme.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान आरंभिक मेथड [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो, तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें; जब एक लेआउट परिवार को अलग शैली चाहिए, तो लेआउट ओवरराइड का उपयोग करें; और केवल असाधारण मामलों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) में संग्रहीत होती हैं। PowerPoint UI में उपलब्ध पृष्ठभूमि विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत भराव परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint पृष्ठभूमि शैली गैलरी प्रस्तुति थीम के लिए](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) को निरीक्षण करें। स्टाइल इंडेक्स `0` का अर्थ कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह जावास्क्रिप्ट संग्रह को सीधे इंडेक्स करने से भिन्न है, जहाँ इंडेक्स `0` पहला संग्रहीत आइटम होता है। प्रत्येक प्रस्तुति में पृष्ठभूमि भराव शैलियों की संख्या समान नहीं है, ऐसा मान न रखें।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को एक थीम पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। जब आपको विरासत के बाद अंतिम पृष्ठभूमि जाननी हो, तो [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
स्टाइल इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से स्टाइल नंबर हार्ड‑कोड न करें और मानें कि वह दूसरे फ़ाइल में समान दिखेगा; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

थीम फॉर्मेट योजना में अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रह होते हैं, जो [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/formatscheme/) द्वारा उजागर होते हैं। सामान्य Office थीम अक्सर तीन मुख्य शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र स्वरूपण से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित गिनती मान लेना।

![समान आकार पर सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव लागू किए गए](presentation-design_10.png)

जब आप जावास्क्रिप्ट में इन संग्रहों को एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: इंडेक्स `0` पहला संग्रहीत शैली है और इंडेक्स `2` तीसरा। आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapestyle/) द्वारा उजागर होती है। थीम शैली को बदलने से उन आकारों पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, और तीसरी प्रभाव शैली में बाहरी छाया को 10 पॉइंट दूरी के साथ सक्षम करता है, फिर परिणाम सहेजता है:

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

इन स्लॉटों को संदर्भित करने वाले आकारों के लिए, पहली थीम रेखा शैली लाल हो जाएगी, तीसरी थीम भराव शैली ठोस फॉरेस्ट ग्रीन होगी, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जोड़ दी जाएगी। ठीक‑ठीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौनसे शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![रेखा, भराव, और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) उपयोग करें, और भराव के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकार भराव पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैधता, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं मास्टर बदलें बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारम्भ करें। परिवर्तन उस स्लाइड तक ही सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में जारी रखेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर रहे हों और उसकी स्रोत उपस्थिति को संरक्षित रखना चाहते हों, तो स्रोत मास्टर को लक्ष्य में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर उस क्लोन किए गए मास्टर के साथ स्लाइड को [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, लेआउट, और थीम एक साथ रहते हैं।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseoverridethememanager/) का उपयोग स्लाइड या लेआउट थीम के लिए करें और स्वरूप ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) के लिए सम्बंधित प्रभावी‑डेटा मेथड। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।