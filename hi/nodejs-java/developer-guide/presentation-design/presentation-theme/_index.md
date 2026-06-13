---
title: JavaScript में प्रस्तुति थीमों का प्रबंधन
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
description: "Node.js के लिए Aspose.Slides के साथ JavaScript में प्रस्तुति थीमों को मास्टर करके PowerPoint फ़ाइलों को बनाना, अनुकूलित करना और निरंतर ब्रांडिंग के साथ परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों के गुणों को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूलतः विशिष्ट दृश्य तत्वों और उनके गुणों का एक सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/nodejs-java/powerpoint-fonts/), [पृष्ठभूमि शैली](/slides/hi/nodejs-java/presentation-background/), और प्रभाव शामिल होते हैं।

![theme-constituents](theme-constitents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड पर विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको ये रंग पसंद नहीं हैं, तो आप थीम के नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SchemeColor) एना्मरेशन के तहत मान प्रदान करता है।

यह JavaScript कोड आपको थीम के एक्सेंट रंग को बदलने का तरीका दिखाता है:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

आप इस प्रकार परिणामस्वरूप रंग का प्रभावी मान निर्धारित कर सकते हैं:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

रंग परिवर्तन ऑपरेशन को और स्पष्ट करने के लिए, हम एक नया तत्व बनाते हैं और उस पर एक्सेंट रंग (प्रारंभिक ऑपरेशन से) लागू करते हैं। फिर हम थीम में रंग बदलते हैं:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग (1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट (2) से रंग बनते हैं। आप फिर उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** - मुख्य थीम रंग  
**2** - अतिरिक्त पैलेट के रंग।

यह JavaScript कोड दर्शाता है कि कैसे मुख्य थीम रंग से अतिरिक्त पैलेट के रंग प्राप्त करके आकृतियों में उपयोग किए जाते हैं:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // एक्सेंट 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // एक्सेंट 4, हल्का 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // एक्सेंट 4, हल्का 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // एक्सेंट 4, हल्का 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // एक्सेंट 4, गहरा 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // एक्सेंट 4, गहरा 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **`SchemeColor` को `ColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देखेंगे कि इसमें निम्नलिखित थीम रंग मान शामिल हैं:

`Background1`, `Background2`, `Text1`, and `Text2`.

हालांकि, `Presentation.getMasterTheme().getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रदर्शित करता है:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट को संदर्भित करते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आया है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग किए जाते थे, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चयन की सुविधा देने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं (PowerPoint में उपयोग किए जाने वाले समान) का उपयोग करता है:

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (मैजर लैटिन फ़ॉन्ट)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (मैजर ईस्ट एशियन फ़ॉन्ट)

यह JavaScript कोड आपको लैटिन फ़ॉन्ट को थीम तत्व में असाइन करने का तरीका दिखाता है:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

यह JavaScript कोड आपको प्रस्तुति थीम फ़ॉन्ट बदलने का तरीका दिखाता है:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

सभी टेक्स्ट बॉक्सों में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint फ़ॉन्ट](/slides/hi/nodejs-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint ऐप 12 पूर्वनिर्धारित पृष्ठभूमियां प्रदान करता है, लेकिन उन 12 में से केवल 3 ही सामान्य प्रस्तुति में सहेजी जाती हैं।

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint ऐप में प्रस्तुति को सहेजने के बाद, आप इस JavaScript कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
आप [FormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme) वर्ग की [BackgroundFillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) प्रॉपर्टी का उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली जोड़ या प्राप्त कर सकते हैं।
{{% /alert %}} 

यह JavaScript कोड आपको प्रस्तुति के लिए पृष्ठभूमि सेट करने का तरीका दिखाता है:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**इंडेक्स गाइड**: 0 का उपयोग कोई भराव नहीं के लिए किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint पृष्ठभूमि](/slides/hi/nodejs-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव बदलें**

PowerPoint थीम में प्रत्येक शैली एरे के लिए सामान्यतः 3 मान होते हैं। इन एरे को मिलाकर 3 प्रभाव बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब प्रभाव किसी विशिष्ट आकार पर लागू होते हैं तो परिणाम इस प्रकार होता है:

![todo:image_alt_text](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme) वर्ग से 3 प्रॉपर्टी ([FillStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) का उपयोग करके थीम के तत्वों को बदल सकते हैं (PowerPoint के विकल्पों से भी अधिक लचीलापन के साथ)।

यह JavaScript कोड आपको थीम प्रभाव को तत्वों के भाग बदलकर कैसे बदलना है दिखाता है:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

फिल रंग, फिल प्रकार, शैडो प्रभाव आदि में होने वाले परिवर्तन इस प्रकार हैं:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**क्या मैं मास्टर में परिवर्तन किए बिना एक एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। Aspose.Slides स्लाइड-स्तर पर थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं (via the [SlideThemeManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidethememanager/))।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम को सुरक्षित रूप से ले जाने का सबसे बेहतर तरीका क्या है?**

[Clone slides](/slides/hi/nodejs-java/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में जोड़ें। इससे मूल मास्टर, लेआउट और संबंधित थीम बनी रहती है, जिससे रूपरेखा लगातार रहती है।

**सभी विरासत और ओवरराइड के बाद मैं "इफ़ेक्टिव" मान कैसे देख सकता हूँ?**

थीम/रंग/फ़ॉन्ट/प्रभाव के लिए API के ["इफ़ेक्टिव" दृश्य](/slides/hi/nodejs-java/shape-effective-properties/) का उपयोग करें। ये मास्टर के साथ किसी भी स्थानीय ओवरराइड लागू करने के बाद समाधानित अंतिम प्रॉपर्टी लौटाते हैं।