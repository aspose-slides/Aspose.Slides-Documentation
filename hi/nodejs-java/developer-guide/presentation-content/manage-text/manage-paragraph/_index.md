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
  - पैराग्राफ प्रॉपर्टीज़
  - HTML आयात करें
  - टेक्स्ट को HTML में
  - पैराग्राफ को HTML में
  - पैराग्राफ को इमेज में
  - टेक्स्ट को इमेज में
  - पैराग्राफ निर्यात करें
  - PowerPoint
  - प्रेजेंटेशन
  - Node.js
  - जावास्क्रिप्ट
  - Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML कंटेंट, और पैराग्राफ इमेज कैसे बनाएँ और फ़ॉर्मेट करें सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ एवं पोर्शन की पदानुक्रम में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन एवं पैराग्राफ‑स्तर की फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) एक पैराग्राफ के भीतर टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर की फ़ॉर्मेटिंग हो सकती है।

इस प्रकार, एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाना और फ़ॉर्मेट करना**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाना**

निम्नलिखित चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [Paragraph] ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन होने के लिए पर्याप्त [Portion] ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat] के माध्यम से कैरेक्टर‑स्तर की फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

यह जावास्क्रिप्ट उदाहरण इन चरणों को लागू करता है:

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

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांक संबंधित आइटम्स को स्कैन करने में आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat] के माध्यम से परिभाषित किया जाता है।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक प्रतीक बुलेट के लिए [Paragraph] बनाएँ।
7. [BulletFormat.setType] को [BulletType.Symbol] सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट की ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [BulletFormat.setType] को [BulletType.Numbered] सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह जावास्क्रिप्ट उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

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

चित्र बुलेट आपको प्रतीक या संख्या के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. [AutoShape] जोड़ें और उसके [TextFrame] तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रेजेंटेशन की इमेज कलेक्शन में [PPImage] के रूप में जोड़ें।
6. [Paragraph] बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType] को [BulletType.Picture] सेट करें।
8. इमेज को [BulletFormat.getPicture] के माध्यम से असाइन करें और बुलेट की ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन सहेजें।

यह जावास्क्रिप्ट उदाहरण एक चित्र बुलेट बनाता है:

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

[ParagraphFormat.setDepth] सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखें। शीर्ष स्तर की गहराई `0` है।

1. [Presentation] बनाएं और एक स्लाइड तक पहुँचें।
2. [AutoShape] जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीक कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.setDepth] मान क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

यह जावास्क्रिप्ट उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

[BulletFormat.setNumberedBulletStartWith] का उपयोग करके क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या सेट करें।

1. [Presentation] बनाएं और एक [AutoShape] को स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith] को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

यह जावास्क्रिप्ट उदाहरण प्रत्येक पैराग्राफ के लिए कस्टम प्रारंभिक संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टी को नियंत्रित करना**

### **पहली लाइन का इंडेंट सेट करें**

[ParagraphFormat.setIndent] का उपयोग करके पैराग्राफ की पहली लाइन का इंडेंट नियंत्रित करें। यह विधि केवल पैराग्राफ की बाएँ मार्जिन के सापेक्ष पहली लाइन को ही ले जाती है। एक सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइन्स पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

[ParagraphFormat.setMarginLeft] का उपयोग तब करें जब आपको पूरी पैराग्राफ को ले जाना हो। केवल पहली लाइन को ले जाना हो तो [ParagraphFormat.setIndent] उपयोग करें।

नीचे का उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent] मान लागू करता है ताकि यह दिखाया जा सके कि पहली लाइन का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [ParagraphFormat.setIndent] मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की पहली लाइन का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन बाकी लाइनों के बाएँ से शुरू होती है। Aspose.Slides में, आप इसे [ParagraphFormat.setIndent] से बनाते हैं। पैराग्राफ बॉडी की सापेक्ष पहली लाइन को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat.setMarginLeft] पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent] इस मार्जिन के सापेक्ष पहली लाइन की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ के लिए उपयोगी है जहाँ रैप्ड लाइन्स को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएं और प्रत्येक पैराग्राफ के लिए [ParagraphFormat.setMarginLeft] को सकारात्मक मान पास करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat.setIndent] को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[Paragraph.setEndParagraphPortionFormat] पैराग्राफ के एंड मार्क की फ़ॉर्मेटिंग को नियंत्रित करता है। नीचे का उदाहरण दूसरे पैराग्राफ के एंड मार्क को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. [Presentation] बनाएं या लोड करें और एक स्लाइड तक पहुँचें।
2. [AutoShape] जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के एंड मार्क के लिए एक [PortionFormat] बनाएं।
5. [BasePortionFormat.setFontHeight] और [BasePortionFormat.setLatinFont] सेट करें।
6. [Paragraph.setEndParagraphPortionFormat] के साथ फ़ॉर्मेट असाइन करें और प्रेजेंटेशन सहेजें।

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

स्वचालित रैपिंग और लाइन समाप्तियों पर विराम चिह्न को प्रभावित करने वाले पैराग्राफ नियमों के लिए, देखें [Control Line Breaking](/slides/hi/nodejs-java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/nodejs-java/text-formatting/#control-hanging-punctuation)।

[Paragraph.getLinesCount] का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा घेरती हुई लाइनों की संख्या गिनी जा सकती है, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रेजेंटेशन टेम्प्लेट में टेक्स्ट लंबाई और लेआउट जाँचते समय उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs] में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक एक नई लाइन फ़ोर्स करता है बिना दूसरा पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करती है बिना टेक्स्ट में स्पष्ट लाइन ब्रेक डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर की गई लाइन गिनती नहीं देता।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकीर्ण करता है, और फिर टेक्स्ट को छोटा स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट निष्क्रिय है ताकि शेप चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से छोटा या शेप को रिसाइज़ किए। शेप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन गिनतियों को जोड़ता है।

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

इस टेक्स्ट और इन आयामों के साथ, शेप को संकीर्ण करने से लाइन गिनती बढ़ती है, जबकि छोटा स्ट्रिंग डालने से घटती है। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग, और ऑटोफ़िट सेटिंग्स के आधार पर सटीक गिनती बदल सकती है। टेम्प्लेट जाँचते समय लक्ष्य पर्यावरण के लिए इरादित फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से अधिक हो रहा है या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाइयाँ, पैराग्राफ एवं लाइन स्पेसिंग, और ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; रैपिंग निष्क्रिय होने पर एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ कंटेंट आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml] का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित करें।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड तक पहुँचें और एक [AutoShape] जोड़ें।
3. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML स्ट्रिंग को परिभाषित या पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml] में पास करें।
6. संशोधित प्रेजेंटेशन सहेजें।

यह जावास्क्रिप्ट उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.exportToHtml] का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें।

1. [Presentation] क्लास का एक इंस्टेंस बनाएं या लोड करें।
2. स्लाइड तक पहुँचें और टेक्स्ट वाला [AutoShape] खोजें।
3. शेप के [TextFrame] तक पहुँचें।
4. शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml] को कॉल करें।
5. परिणामी HTML स्ट्रिंग को फ़ाइल में लिखें।

यह स्वतंत्र जावास्क्रिप्ट उदाहरण एक टेक्स्ट शेप बनाता है और सभी पैराग्राफ निर्यात करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

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
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
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

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[Paragraph.getImage] एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage] लौटाता है। परिणाम को [IImage.save] के साथ फ़ाइल में सहेजें। आपको कंटेनर शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[Paragraph.getImage] `null` लौट सकता है यदि पैराग्राफ अपने पैरेंट कलेक्शन में नहीं मिला, वैध रेंडर बाउंड्स नहीं हैं, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ कर दें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

निम्न टेक्स्ट बॉक्स में तीन पैराग्राफ हैं:

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण नियमित टेक्स्ट शेप में दूसरे पैराग्राफ को डिफ़ॉल्ट स्केल पर रेंडर करता है और परिणाम इमेज को PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक इमेज को सही ढंग से डिस्पोज़ करता है।

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

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

`scaleX` और `scaleY` पैरामीटर्स को स्वीकार करने वाले [Paragraph.getImage] ओवरलोड का उपयोग करके क्षैतिज एवं ऊर्ध्वाधर स्केल फ़ैक्टर सेट करें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फ़ैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर के लिए `2` डालने पर इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आकार से दुगुनी हो जाती है, जिससे पिक्सेल चार गुना बढ़ जाते हैं। बड़े फ़ैक्टर आमतौर पर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। बराबर फ़ैक्टर रहने से पैराग्राफ का अनुपात बना रहता है; विभिन्न क्षैतिज और ऊर्ध्वाधर फ़ैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना आवश्यक हो, तो [Shape.getImage] के साथ पूरी शेप रेंडर करना उपयोगी रहता है। पैराग्राफ‑केवल इमेज के लिए, [Paragraph.getImage] का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। [TextFrameFormat.setWrapText] को फ़ॉल्स सेट करके रैपिंग बंद करें, जिससे लाइनें टेक्स्ट फ्रेम के किनारों पर नहीं तोड़ेंगी।

**मैं किसी विशिष्ट पैराग्राफ की ऑन‑स्लाइड बाउंड्स कैसे प्राप्त कर सकता हूँ?**

[Paragraph.getRect] का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। व्यक्तिगत पोर्शन की बाउंड्स के लिए [Portion.getRect] देखें।

**पैराग्राफ संरेखण (बायां, दायां, केंद्र या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[ParagraphFormat.setAlignment] एक पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन की फ़ॉर्मेटिंग कुछ भी हो।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId] सेट करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सके।