---
title: जावास्क्रिप्ट में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
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
- HTML आयात करें
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से छवि
- टेक्स्ट से छवि
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ छवियों को कैसे बनाएं और स्वरूपित करें, सीखें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ, और पोर्शन की पदानुक्रम में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) टेक्स्ट फ़्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और पोर्शन तथा पैराग्राफ-स्तरीय स्वरूपण तक पहुंच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरैक्टर-स्तर स्वरूपण हो सकता है।

इसलिए एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार, और अन्य स्वरूपण वाले टेक्स्ट को सम्मिलित कर सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

एक आकार के टेक्स्ट फ़्रेम में पैराग्राफ बनाएं और व्यक्तिगत टेक्स्ट रन को स्वरूपित करने के लिए पोर्शन का उपयोग करें। यह अनुभाग दिखाता है कि प्रत्येक पैराग्राफ में कई पोर्शन को कैसे मिलाया जाए और विभिन्न रंग, फ़ॉन्ट आकार, और शैलियों को कैसे लागू किया जाए।

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाना**

निम्नलिखित JavaScript उदाहरण तीन पैराग्राफ बनाता है, प्रत्येक में तीन टेक्स्ट रन होते हैं, जिन्हें [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) द्वारा लौटाए गए संग्रह से प्राप्त किया जाता है। यह डिफ़ॉल्ट पैराग्राफ और उसकी खाली पोर्शन को पुन: उपयोग करता है, फिर शेष पैराग्राफ और पोर्शन जोड़ता है। स्वरूपण [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) के माध्यम से लागू किया जाता है: प्रत्येक पैराग्राफ की पहली पोर्शन लाल, बोल्ड, और 15 पॉइंट है; दूसरी नीली, इटैलिक, और 18 पॉइंट; तीसरी अपनी डिफ़ॉल्ट स्वरूपण बनाए रखती है:

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

## **बुलेटेड और क्रमांकित सूचियाँ बनाना**

पैराग्राफ टेक्स्ट को प्रतीकों, संख्याओं, या कस्टम छवियों के साथ सूचियों में व्यवस्थित करें। इस अनुभाग के उदाहरण बुलेट स्वरूपण, बहु-स्तरीय सूचियों, और कस्टम शुरूआती संख्याओं को कवर करते हैं।

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकन संबंधित आइटम को तेज़ी से स्कैन करने में मदद करते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

यह JavaScript उदाहरण एक ही टेक्स्ट फ़्रेम में एक प्रतीक बुलेट और एक क्रमांकित आइटम जोड़ता है। [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) बुलेट प्रकार चुनता है, जबकि [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) प्रतीक प्रदान करता है और [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) क्रमांकन शैली चुनता है। दोनों आइटम काले बुलेट के साथ 100 % ऊँचाई और 25 पॉइंट पैराग्राफ इंडेंट के साथ हैं:

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

### **चित्र बुलेट का उपयोग करना**

चित्र बुलेट आपको प्रतीक या संख्या के बजाय एक कस्टम छवि का उपयोग करने की अनुमति देता है।

यह JavaScript उदाहरण `image.png` को एप्लिकेशन की कार्य निर्देशिका से लोड करता है, उसे प्रस्तुति की इमेज संग्रह में एक [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) के रूप में जोड़ता है और पैराग्राफ बुलेट के रूप में उपयोग करता है। यह [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) को कॉल करके चित्र बुलेट का उपयोग करता है और छवि को [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) के माध्यम से असाइन करता है। [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) को 100 % पर सेट किया जाता है ताकि बुलेट पैराग्राफ टेक्स्ट के सापेक्ष आकार ले सके:

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

### **बहु-स्तरीय सूची बनाना**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रख सकते हैं। शीर्ष स्तर का गहराई `0` है।

यह JavaScript उदाहरण चार पैराग्राफ को 0 से 3 तक के [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) मान असाइन करता है, जिससे एक ही टेक्स्ट फ़्रेम के भीतर पदानुक्रम बनता है। प्रत्येक पैराग्राफ एक प्रतीक बुलेट का उपयोग करता है, जहाँ [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) गोल बुलेट और हाइफ़न के बीच बदलता है ताकि समान स्तर के बीच अंतर स्पष्ट हो सके:

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

### **कस्टम मानों से क्रमांकित सूची आइटम शुरू करना**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) का उपयोग करके क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या सेट की जा सकती है।

यह JavaScript उदाहरण तीन पैराग्राफ के लिए क्रमांकन उपयोग करने हेतु [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) सेट करता है और [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) को क्रमशः 2, 3, और 7 पर सेट करता है। प्रारंभिक मान प्रत्येक पैराग्राफ के लिए अलग‑अलग कॉन्फ़िगर किया गया है, जिससे प्रदर्शित संख्याएँ मान छोड़ सकती हैं:

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

## **पैराग्राफ लेआउट और अंत गुण नियंत्रण करना**

पहली पंक्ति और रैप्ड लाइनों की स्थिति को नियंत्रित करने हेतु पैराग्राफ मार्जिन और इंडेंट समायोजित करें। आप पैराग्राफ अंत चिह्न को दृश्यमान टेक्स्ट पोर्शन से अलग भी स्वरूपित कर सकते हैं।

### **पहली‑पंक्ति इंडेंट सेट करना**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड का उपयोग करके पैराग्राफ की पहली‑पंक्ति इंडेंट को नियंत्रित किया जाता है। यह सेटिंग केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

यदि आपको पूरे पैराग्राफ को स्थानांतरित करना हो, तो [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) उपयोग करें।

निम्नलिखित उदाहरण तीन पैराग्राफ को समान [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 20 पॉइंट और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मान 0, 20, और 40 पॉइंट असाइन करता है। पहली पंक्तियाँ क्रमशः बड़े ऑफ़सेट पर शुरू होती हैं, जबकि रैप्ड लाइनों की बाएँ मार्जिन समान रहती है:

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

![पैराग्राफ की पहली‑पंक्ति इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष लाइनों से बाएँ शुरू होती है। Aspose.Slides में इस प्रभाव को प्राप्त करने के लिए आप [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड को नकारात्मक मान के साथ उपयोग कर सकते हैं।

व्यवहार में, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति तय करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक बाएँ मार्जिन और नकारात्मक इंडेंट सेट करें।

यह स्वरूपण ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियाँ आदि के लिए उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित किया जाना चाहिए न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्नलिखित JavaScript उदाहरण [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) को 40 और 60 पॉइंट, तथा [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) को क्रमशः ‑20 और ‑30 पॉइंट सेट करता है। प्रत्येक पैराग्राफ में पहली पंक्ति रैप्ड लाइनों से बाएँ शुरू होती है; दूसरे पैराग्राफ में हैंगिंग इंडेंट गहरा है:

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

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करना**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) मेथड पैराग्राफ अंत चिह्न के स्वरूपण को नियंत्रित करता है। निम्नलिखित उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) बनाता है जिसमें [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) को 48 पॉइंट और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) को Times New Roman पर सेट किया गया है। यह फ़ॉर्मेट दूसरे पैराग्राफ के अंत चिह्न पर असाइन किया जाता है, जबकि दृश्यमान टेक्स्ट पोर्शन अपरिवर्तित रहता है:

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

## **रेंडर की गई लाइनों की गिनती**

पैराग्राफ नियमों के बारे में जो स्वचालित रैपिंग और लाइनों के अंत में विराम चिह्न को प्रभावित करते हैं, देखें [Control Line Breaking](/slides/hi/nodejs-java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/nodejs-java/text-formatting/#control-hanging-punctuation)।

[Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करके आप टेक्स्ट लेआउट के बाद किसी पैराग्राफ द्वारा घिरी लाइनों की संख्या गिन सकते हैं, जिसमें स्वचालित रैपिंग शामिल है। यह प्रस्तुति टेम्प्लेट में टेक्स्ट की लंबाई और लेआउट जाँचने में उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक एक नई पंक्ति उत्पन्न करता है बिना नया पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करता है बिना स्पष्ट ब्रेक को टेक्स्ट में डालें। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर्स को गिनना रेंडर लाइनों की संख्या नहीं देता।

निम्नलिखित उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकुचित करता है, और फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। यह उदाहरण [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) के साथ रैपिंग सक्षम करता है और [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) के साथ ऑटोफ़िट अक्षम करता है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से छोटा या शेप का आकार बदलें। प्रत्येक माप [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) द्वारा किया जाता है। शेप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ़्रेम के कुल लाइन काउंट को जोड़ता है।

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

इन टेक्स्ट और आयामों के साथ, शेप को संकुचित करने से लाइन काउंट बढ़ता है, जबकि छोटे स्ट्रिंग से बदलने पर घटता है। फ़ॉन्ट उपलब्धता, फ़ॉन्ट प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग, और ऑटोफ़िट सेटिंग्स के आधार पर सटीक गिनती बदल सकती है। टेम्प्लेट जाँचते समय लक्ष्य वातावरण के लिए निर्दिष्ट फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करना आवश्यक है।

केवल लाइन काउंट यह निर्धारित नहीं करता कि टेक्स्ट कंटेनर से बाहर ले जाता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ एवं लाइन स्पेसिंग, और ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी जब रैपिंग निष्क्रिय हो तो उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात करना**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ को बाहर उपयोग के लिए निर्यात करें। यह अनुभाग दिखाता है कि व्यक्तिगत पैराग्राफ को छवियों के रूप में कैसे रेंडर किया जाए, जिसमें तालिका कोशिकाओं के पैराग्राफ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जाता है।

यह JavaScript उदाहरण एप्लिकेशन की कार्य निर्देशिका में स्थित `file.html` से HTML पढ़ता है और इसे [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) को पास करता है। यह टेक्स्ट फ़्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ़्रेम में केवल आयातित सामग्री रहे। आयताकार आकार स्लाइड के प्रत्येक किनारे पर 10 पॉइंट मार्जिन छोड़ता है:

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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जाता है। जब आप प्रस्तुति टेक्स्ट को वेबसाइट पर पुनः उपयोग करना चाहते हैं, तो आप स्थानीय जोर को फॉन्ट, आकार या टेक्स्ट बॉक्स शैलियों को ले जाए बिना बनाए रख सकते हैं। निर्यातकर्ता कितनी दूर तक स्वरूपण विरासत का अनुसरण करे, इसे नियंत्रित करने के लिए [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) सेट करें।

[नमूना प्रस्तुति](text-inheritance.pptx) को एप्लिकेशन की कार्य निर्देशिका में रखें। उसकी पहली स्लाइड में एक टेक्स्ट शेप है जिसमें टेक्स्ट "Inherited text; explicit red 18pt" है। इनपुट जानबूझकर कई स्वरूपण स्तरों का प्रयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ़्रेम की प्रथम‑स्तर शैली नीला टेक्स्ट और इटैलिक प्रदान करती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा पोर्शन, "explicit red 18pt", स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्नलिखित पूर्ण उदाहरण समान पैराग्राफ को तीन बार निर्यात करता है। यह निर्यात मेथड को [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल के रूप में लिखता है:

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

उत्पन्न HTML में पहले पोर्शन, "Inherited text; ", के लिए निम्नलिखित CSS है। तालिका में संबंधित घोषणाएँ सूचीबद्ध हैं; अन्य उत्पन्न गुण स्पष्टता के लिए छोड़े गए हैं।

| आउटपुट | पहले पोर्शन के लिए प्रासंगिक CSS | दिखावट |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt में Calibri में, यदि वह फ़ॉन्ट उपलब्ध हो। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग, और इटैलिक शैली प्रदान करता है। |

दूसरा पोर्शन सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt`, और `font-weight:bold` को बरकरार रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। विरासत को सीमित करने से पैराग्राफ या पोर्शन को स्पष्ट रूप से सौंपे गए स्वरूपण को नहीं हटाया जाता।

फ़ाइलों को एक ही ब्राउज़र में खोलकर तुलना करें। दो प्रतिबंधित मोड में छोड़ी गई CSS गुणों को लक्ष्य पेज की शैली या ब्राउज़र डिफ़ॉल्ट द्वारा हल किया जाता है, इसलिए अंतिम दिखावट इस बात पर निर्भर करती है कि HTML कहाँ उपयोग किया जाता है।

### **पैराग्राफ को छवि के रूप में रेंडर करना**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) के साथ सहेजा जा सकता है। आपको संलग्न शेप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ अभिभावक संग्रह में नहीं मिला है, वैध रेंडर सीमाएँ नहीं हैं, या रेंडर नहीं किया जा सकता, तो [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) `null` लौटाता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के पश्चात लौटाई गई छवि को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

उदाहरण एक प्रस्तुति बनाता है जिसमें एक स्लाइड है और उसका पहला शेप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्नलिखित उदाहरण इंडेक्स 1 पर स्थित दूसरे पैराग्राफ को चुनता है और बिना स्केल पैरामीटर के [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) को कॉल करता है। यह जाँचता है कि शेप में आवश्यक पैराग्राफ मौजूद है और रेंडरिंग ने छवि लौटा है, फिर [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) का उपयोग करके PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक उपयोग के बाद छवि को डिस्पोज़ करता है।

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

#### **टेबल सेल में स्केलिंग सहित पैराग्राफ रेंडर करना**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) ओवरलोड का उपयोग करके `scaleX` और `scaleY` पैरामीटर पास करें और क्षैतिज तथा लंबवत स्केल फ़ैक्टर सेट करें। निम्नलिखित उदाहरण एक तालिका बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम PNG छवि के रूप में सहेजता है।

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

स्केल फ़ैक्टर `1` अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर `2` देने से छवि की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आकार के दो गुना हो जाती है, अर्थात चार गुना पिक्सेल। बड़े फ़ैक्टर ज़ूम या उच्च‑रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट पैदा करते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे चित्र बनाते हैं जिनमें विवरण कम होता है। समान फ़ैक्टर रखने से पैराग्राफ का अनुपात बरकरार रहता है; अलग‑अलग क्षैतिज और लंबवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से खिंचते हैं।

पूरे शेप को [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) से रेंडर करना तब उपयोगी होता है जब आउटपुट में शेप की फ़िल, बॉर्डर, या अन्य दृश्य संदर्भ शामिल होना आवश्यक हो। केवल पैराग्राफ छवि के लिए, [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह से निष्क्रिय कर सकता हूँ?**

हाँ। [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) को `false` सेट करके रैपिंग निष्क्रिय की जा सकती है, जिससे लाइनों को टेक्स्ट फ़्रेम के किनारों पर ब्रेक नहीं होगा।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड‑पर‑स्लाइड बाउंड्स कैसे प्राप्त करूँ?**

[Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करके पैराग्राफ का बाउंडिंग आयत प्राप्त करें। [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) एकल पोर्शन की बाउंड्स देता है।

**पैराग्राफ संरेखण (बायाँ, दायाँ, केंद्र, या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) एक पैराग्राफ‑स्तरीय सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का स्वरूपण कुछ भी हो।

विभिन्न फ़ॉन्ट आकारों वाली पोर्शन को प्रत्येक लाइन में लंबवत संरेखित करने के लिए देखें [Align Fonts Within a Line](/slides/hi/nodejs-java/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के एक हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, जिससे एक पैराग्राफ कई भाषाओं के टेक्स्ट को शामिल कर सकता है।