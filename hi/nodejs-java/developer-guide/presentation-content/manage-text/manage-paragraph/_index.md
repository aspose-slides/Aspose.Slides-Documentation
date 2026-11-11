---
title: JavaScript में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से छवि
- टेक्स्ट से छवि
- पैराग्राफ निर्यात
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियां, इंडेंट, HTML सामग्री, और पैराग्राफ छवियों को बनाना और स्वरूपित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java पाठ को टेक्स्ट फ़्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) एक टेक्स्ट फ़्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन और पैराग्राफ-स्तर के फ़ॉर्मेटिंग तक पहुंच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) एक पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर-स्तर फ़ॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ में विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके शामिल किया जा सकता है।

## **पैराग्राफ बनाएं और स्वरूपित करें**

एक आकार के टेक्स्ट फ़्रेम में पैराग्राफ बनाएं और व्यक्तिगत टेक्स्ट रन को स्वरूपित करने के लिए पोर्शन का उपयोग करें। यह अनुभाग दिखाता है कि प्रत्येक पैराग्राफ में कई पोर्शन को कैसे मिलाया जाए और विभिन्न रंग, फ़ॉन्ट आकार और शैलियों को कैसे लागू किया जाए।

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित JavaScript उदाहरण तीन पैराग्राफ बनाता है, प्रत्येक में तीन टेक्स्ट रन होते हैं जो [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) द्वारा लौटाए गए संग्रह में होते हैं। यह डिफ़ॉल्ट पैराग्राफ और उसके खाली पोर्शन को पुन: उपयोग करता है, फिर शेष पैराग्राफ और पोर्शन को जोड़ता है। फ़ॉर्मेटिंग [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ का पहला पोर्शन लाल, बोल्ड और 15 पॉइंट है; दूसरा नीला, इटैलिक और 18 पॉइंट; तीसरा अपनी डिफ़ॉल्ट फ़ॉर्मेटिंग बनाए रखता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **बुलेटेड और नंबरेड सूचियां बनाएं**

पैराग्राफ टेक्स्ट को चिन्हों, संख्याओं या कस्टम छवियों के साथ सूचियों में व्यवस्थित करें। इस अनुभाग के उदाहरण बुलेट फ़ॉर्मेटिंग, बहु-स्तरीय सूचियां और कस्टम प्रारंभिक संख्याओं को कवर करते हैं।

### **बुलेटेड या नंबरेड सूची बनाएं**

बुलेट और नंबरिंग संबंधित आइटम को स्कैन करने में आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

यह JavaScript उदाहरण एक ही टेक्स्ट फ़्रेम में एक प्रतीक बुलेट और एक क्रमांकित आइटम जोड़ता है। [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) बुलेट प्रकार चुनता है, जबकि [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) प्रतीक प्रदान करता है और [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) नंबरिंग शैली चुनता है। दोनों आइटम काले बुलेट का उपयोग करते हैं जिनकी ऊँचाई 100 प्रतिशत और पैराग्राफ इंडेंट 25 पॉइंट है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चित्र बुलेट्स का उपयोग करें**

चित्र बुलेट्स आपको प्रतीक या संख्या के बजाय कस्टम छवि उपयोग करने की अनुमति देते हैं।

यह JavaScript उदाहरण `image.png` को एप्लिकेशन की कार्य निर्देशिका से लोड करता है, उसे प्रस्तुति की छवि संग्रह में एक [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) के रूप में जोड़ता है और इसे पैराग्राफ बुलेट के रूप में उपयोग करता है। यह बुलेट के रूप में चित्र उपयोग करने के लिए [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) को कॉल करता है और छवि को [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) के माध्यम से निर्दिष्ट करता है। बुलेट की ऊँचाई को 100 प्रतिशत पर सेट करने के लिए [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) का उपयोग किया जाता है ताकि बुलेट पैराग्राफ टेक्स्ट के सापेक्ष आकारित हो:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **बहु-स्तरीय सूची बनाएं**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) को सेट करके सूचियों में पैराग्राफ को विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर की गहराई `0` है।

यह JavaScript उदाहरण चार पैराग्राफ के लिए 0 से 3 तक के [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) मान असाइन करता है, जिससे एक ही टेक्स्ट फ़्रेम में एक पदानुक्रम बनता है। प्रत्येक पैराग्राफ एक प्रतीक बुलेट का उपयोग करता है, और [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) गोल बुलेट और हाइफ़न के बीच बारी-बारी से बदलता है ताकि क्रमिक स्तरों को अलग किया जा सके:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **कस्टम मूल्यों के साथ क्रमांकित सूची आइटम शुरू करें**

एक क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या निर्धारित करने के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) का उपयोग करें।

यह JavaScript उदाहरण तीन पैराग्राफ के लिए बुलेट प्रकार को क्रमांकित करने हेतु [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) सेट करता है और क्रमशः 2, 3 और 7 के [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) मान असाइन करता है। प्रारंभिक मान प्रत्येक पैराग्राफ के लिए अलग-अलग कॉन्फ़िगर किया जाता है, जिससे प्रदर्शित संख्याएं मूल्यों को छोड़ सकती हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पैराग्राफ लेआउट और अंत गुणों को नियंत्रित करें**

पहली पंक्ति और लिपटे हुए पंक्तियों की स्थिति को नियंत्रित करने के लिए पैराग्राफ मार्जिन और इंडेंट समायोजित करें। आप पैराग्राफ अंत चिह्न को दृश्यमान टेक्स्ट पोर्शन से अलग भी स्वरूपित कर सकते हैं।

### **पहली-पंक्ति इंडेंट सेट करें**

पहली-पंक्ति इंडेंट को नियंत्रित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड का उपयोग करें। यह सेटिंग केवल पैराग्राफ के बाएं मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएं शिफ्ट करता है, जबकि शेष पंक्तियां पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने की आवश्यकता होने पर [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) का उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करें।

निम्नलिखित उदाहरण तीन पैराग्राफ को समान [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 20 पॉइंट और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मान 0, 20 और 40 पॉइंट असाइन करता है। पहली पंक्तियां क्रमश: बड़े ऑफ़सेट पर शुरू होती हैं, जबकि लिपटी पंक्तियां समान बाएं मार्जिन बनाए रखती हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ़ के प्रथम-लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, आप इसे [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड से बनाते हैं। इंडेंट को नकारात्मक मान पर सेट करके पहली पंक्ति को पैराग्राफ बॉडी की सापेक्ष बाईं ओर ले जाएँ।

व्यावहारिक रूप से, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ बॉडी की बाईं स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक बाएं मार्जिन और नकारात्मक इंडेंट सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफों के लिए उपयोगी है जहाँ लिपटी पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्नलिखित JavaScript उदाहरण [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) मान 40 और 60 पॉइंट को [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मान -20 और -30 पॉइंट के साथ जोड़ता है। प्रत्येक पैराग्राफ में, पहली पंक्ति लिपटी पंक्तियों से बाईं ओर शुरू होती है; दूसरे पैराग्राफ में गहरा हैंगिंग इंडेंट है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ़ के हैंगिंग इंडेंट](hanging_indent.png)

### **परिच्छेद अंत रन गुण सेट करें**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) मेथड पैराग्राफ अंत चिह्न की फ़ॉर्मेटिंग को नियंत्रित करता है। निम्नलिखित उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) बनाता है जिसमें [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 48 पॉइंट और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) Times New Roman पर सेट है। यह फ़ॉर्मेट दूसरे पैराग्राफ के अंत चिह्न पर असाइन किया जाता है, जबकि दृश्यमान टेक्स्ट पोर्शन अपरिवर्तित रहते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **रेंडर की गई पंक्तियों की गणना करें**

पैराग्राफ नियम जो स्वचालित लिपटाव और लाइन समाप्ति पर विराम चिह्न को प्रभावित करते हैं, उनके लिए देखें [Control Line Breaking](/slides/hi/nodejs-java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/nodejs-java/text-formatting/#control-hanging-punctuation)।

पैराग्राफ के टेक्स्ट लेआउट के बाद ली गई पंक्तियों की संख्या गिनने के लिए [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करें, जिसमें स्वचालित लिपटाव भी शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट लंबाई और लेआउट की जाँच करने में उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) में एक आइटम है, और यह कई रेंडर की गई पंक्तियों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक एक नई पंक्ति बनाता है बिना नया पैराग्राफ बनाए। स्वचालित लिपटाव उपलब्ध चौड़ाई के आधार पर पंक्तियां बनाता है बिना टेक्स्ट में स्पष्ट लाइन ब्रेक डाले। इसलिए पैराग्राफ या लाइन-ब्रेक कैरेक्टर गिनने से रेंडर की गई पंक्तियों की संख्या नहीं मिलती।

निम्नलिखित उदाहरण एक टेक्स्ट शैप बनाता है, उसकी पंक्तियों की गिनती करता है, शैप को संकुचित करता है, और फिर टेक्स्ट को एक छोटे स्ट्रिंग से बदलता है। उदाहरण [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) के साथ लिपटाव सक्षम करता है और [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) के साथ ऑटोफ़िट को निष्क्रिय करता है ताकि शैप की चौड़ाई लिपटाव को नियंत्रित करे, बिना टेक्स्ट को स्वतः छोटा किए या शैप को पुन: आकारित किए। प्रत्येक माप [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करता है। शैप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ़्रेम में पंक्तियों की गिनती को जोड़ता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

इन टेक्स्ट और आयामों के साथ, शैप को संकुचित करने से पंक्तियों की संख्या बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने पर घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंट, लिपटाव और ऑटोफ़िट सेटिंग्स के साथ बदल सकती है। टेम्पलेट की जाँच करते समय लक्ष्य पर्यावरण के लिए नियत फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल पंक्ति गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर जाता है या नहीं। उपलब्ध ऊँचाई, पंक्ति ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; जब लिपटाव निष्क्रिय हो तो एक ही पंक्ति भी उपलब्ध चौड़ाई से अधिक हो सकता है।

## **पैराग्राफ सामग्री आयात और निर्यात करें**

HTML का प्रयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ को बाहर उपयोग के लिए निर्यात करें। यह अनुभाग दिखाता है कि कैसे व्यक्तिगत पैराग्राफ को छवियों के रूप में रेंडर किया जाए, जिसमें तालिका कोशिकाओं के पैराग्राफ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित करें।

यह JavaScript उदाहरण `file.html` से HTML पढ़ता है जो एप्लिकेशन की कार्य निर्देशिका में स्थित है और इसे [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) को पास करता है। यह टेक्स्ट फ़्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ़्रेम में केवल आयातित कंटेंट रहे। आयताकार आकार स्लाइड के प्रत्येक पक्ष पर 10 पॉइंट मार्जिन छोड़ता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें। जब प्रस्तुति टेक्स्ट को वेबसाइट पर पुन: उपयोग किया जाता है, तो आप स्थानीय जोर को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स शैलियों को ले जाए बिना संरक्षित रखना चाह सकते हैं। निर्यातकर्ता कितनी दूर तक फ़ॉर्मेटिंग इनहेरिटेंस का पालन करता है, इसे नियंत्रित करने के लिए [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) सेट करें।

[नमूना प्रस्तुति](text-inheritance.pptx) को डाउनलोड करें और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक टेक्स्ट शैप है जिसमें टेक्स्ट "Inherited text; explicit red 18pt" है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ़्रेम की प्रथम-स्तर की टेक्स्ट शैली नीला टेक्स्ट और इटैलिक प्रदान करती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा पोर्शन, "explicit red 18pt", स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्नलिखित पूर्ण उदाहरण वही पैराग्राफ तीन बार निर्यात करता है। यह निर्यात मेथड को [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) पास करता है और प्रत्येक परिणाम को एक अलग UTF-8 HTML फ़ाइल के रूप में लिखता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

उत्पन्न HTML में प्रथम पोर्शन, "Inherited text; " के लिए निम्नलिखित CSS होता है। तालिका संबंधित घोषणाओं को सूचीबद्ध करती है; अन्य उत्पन्न गुण स्पष्टता के लिए छोड़े गए हैं।

| आउटपुट | प्रथम पोर्शन के लिए संबंधित CSS | रूप |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt में Calibri में, यदि वह फ़ॉन्ट उपलब्ध हो। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पृष्ठ या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पृष्ठ या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली प्रदान करता है। |

दूसरा पोर्शन सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt` और `font-weight:bold` बनाए रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। इनहेरिटेंस को सीमित करने से पैराग्राफ या पोर्शन को स्पष्ट रूप से असाइन किया गया फ़ॉर्मेटिंग नहीं हटता।

फ़ाइलों को एक ही ब्राउज़र में खोलकर तुलना करें। दो प्रतिबंधित मोड में, छोड़ी गई CSS प्रॉपर्टी को गंतव्य पृष्ठ की शैली या ब्राउज़र डिफ़ॉल्ट द्वारा हल किया जाता है, इसलिए अंतिम रूप इस पर निर्भर करता है कि HTML कहाँ उपयोग किया जाता है।

### **HTML क्लिपबोर्ड फ्रैगमेंट उत्पन्न करें**

[TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/setaddclipboardfragmentheader/) का उपयोग करके [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) के आउटपुट को चुनें। `false` के साथ मेथड सामान्य HTML लौटाता है। `true` के साथ लौटाई गई स्ट्रिंग Windows क्लिपबोर्ड हेडर से शुरू होती है। उसके `StartHTML` और `EndHTML` फ़ील्ड HTML के UTF-8 बाइट ऑफ़सेट देते हैं, जबकि `StartFragment` और `EndFragment` पेस्ट करने के लिए कंटेंट की पहचान करते हैं।

यह उदाहरण दो स्वरूपित पैराग्राफ को सामान्य HTML (`html`) और HTML क्लिपबोर्ड फ्रैगमेंट (`clipboardHtml`) के रूप में निर्यात करता है। एप्लिकेशन फिर इस फ्रैगमेंट को सिस्टम क्लिपबोर्ड पर लिख सकता है। यदि क्लिपबोर्ड API कच्चे बाइट्स की अपेक्षा करता है, तो फ़्रैगमेंट को बिना बाइट ऑर्डर मार्क (BOM) के UTF-8 में एन्कोड करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, 400, 100);
    const paragraphs = shape.getTextFrame().getParagraphs();
    paragraphs.clear();
    paragraphs.addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    const options = new slides.TextToHtmlConversionOptions();
    options.setAddClipboardFragmentHeader(false);
    const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);

    options.setAddClipboardFragmentHeader(true);
    const clipboardHtml = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ को छवि के रूप में रेंडर करें**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) से फ़ाइल या स्ट्रीम में सहेजें। आपको कंटेनिंग शैप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ पैरेन्ट संग्रह में नहीं मिलता, वैध रेंडरिंग बाउंड नहीं है, या रेंडर नहीं किया जा सकता तो [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) `null` लौटा सकता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई छवि को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

उदाहरण एक प्रस्तुति बनाता है जिसमें एक स्लाइड है और उसकी पहली शैप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाले टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्नलिखित उदाहरण इंडेक्स 1 पर स्थित दूसरे पैराग्राफ को चुनता है और स्केल पैरामीटर के बिना [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) को कॉल करता है। यह जाँचता है कि शैप में आवश्यक पैराग्राफ है और रेंडरिंग ने छवि वापस की है, फिर [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) को PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक उपयोग के बाद छवि को डिस्पोज़ करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ छवि](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

`scaleX` और `scaleY` पैरामीटर स्वीकार करने वाले [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) ओवरलोड का उपयोग करके क्षैतिज और लंबवत स्केल फैक्टर सेट करें। निम्नलिखित उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को उसकी डिफ़ॉल्ट चौड़ाई एवं ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG छवि के रूप में सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` का स्केल फैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के तौर पर, दोनों फैक्टर्स के लिए `2` चौड़ाई और ऊँचाई को लगभग दो गुना बनाता है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फैक्टर्स आमतौर पर ज़ूम या उच्च-रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर्स छोटे चित्र बनाते हैं जिनमें कम विवरण होता है। समान फैक्टर्स का उपयोग करके पैराग्राफ का आस्पेक्ट रेश्यो सुरक्षित रखें; अलग क्षैतिज और लंबवत फैक्टर्स आउटपुट को स्वतंत्र रूप से खींचते हैं।

[Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) के साथ पूरी शैप रेंडर करना तब उपयोगी रहता है जब आउटपुट में शैप की भरावट, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। पैराग्राफ-केवल छवि के लिए, [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। लाइन रैपिंग को निष्क्रिय करने के लिए [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) को `false` सेट करें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर वास्तविक बाउंड्री कैसे प्राप्त करूँ?**

पैराग्राफ की बाउंडिंग आयत प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करें। व्यक्तिगत पोर्शन की बाउंडिंग के लिए [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) प्रदान किया जाता है।

**पैराग्राफ संरेखण (बाएँ, दाएँ, केंद्र या बराबर) कहाँ नियंत्रित होता है?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) पैराग्राफ-स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेटिंग कुछ भी हो।

हर लाइन में विभिन्न फ़ॉन्ट आकारों वाले पोर्शन को ऊर्ध्वाधर रूप से संरेखित करने के लिए देखें [Align Fonts Within a Line](/slides/hi/nodejs-java/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के भाग के लिए प्रमाणन भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट शामिल हो सकता है।