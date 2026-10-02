---
title: "JavaScript में PowerPoint टेक्स्ट पैराग्राफ को प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - "टेक्स्ट जोड़ें"
  - "पैराग्राफ जोड़ें"
  - "टेक्स्ट प्रबंधित करें"
  - "पैराग्राफ प्रबंधित करें"
  - "बुलेट प्रबंधित करें"
  - "पैराग्राफ इंडेंट"
  - "हैंगिंग इंडेंट"
  - "पैराग्राफ बुलेट"
  - "नंबरड सूची"
  - "बुलेटेड सूची"
  - "पैराग्राफ प्रॉपर्टीज़"
  - "HTML आयात करें"
  - "टेक्स्ट को HTML में"
  - "पैराग्राफ को HTML में"
  - "पैराग्राफ को इमेज में"
  - "टेक्स्ट को इमेज में"
  - "पैराग्राफ निर्यात करें"
  - "PowerPoint"
  - "प्रेज़ेंटेशन"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java के साथ पैराग्राफ, पोर्शन, बुलेट, नंबरड लिस्ट, इंडेंट, HTML कंटेंट और पैराग्राफ इमेज कैसे बनाएं और फ़ॉर्मेट करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन के पदानुक्रम के रूप में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) shape में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन तथा पैराग्राफ‑स्तर फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन अपना स्वयं का टेक्स्ट और कैरेक्टर‑स्तर फ़ॉर्मेटिंग रख सकता है।

इस प्रकार एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को सम्मिलित कर सकता है।

## **पैराग्राफ बनाएं और स्वरूपित करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्न चरण तीन पैराग्राफ वाला टेक्स्ट फ्रेम बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) के माध्यम से कैरेक्टर‑स्तर फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण इन चरणों को लागू करता है:

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

## **बुलेटेड और नंबरेड सूचियाँ बनाएं**

### **बुलेटेड या नंबरेड सूची बनाएं**

बुलेट और नंबरिंग से संबंधित आइटम आसानी से स्कैन किए जा सकते हैं। Aspose.Slides में सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक सिम्बल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) बनाएँ।
7. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएँ और [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) पर सेट करें।
11. नंबर्ड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण एक सिम्बल बुलेट और एक नंबर्ड बुलेट बनाता है:

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

### **चित्र बुलेट उपयोग करें**

चित्र बुलेट आपको सिम्बल या नंबर के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज लोड करें और उसे प्रेज़ेंटेशन की इमेज कलेक्शन में एक [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) बनाएँ और उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण एक चित्र बुलेट बनाता है:

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

### **बहु‑स्तरीय सूची बनाएं**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाकर स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाएँ और उनके बुलेट सिम्बल कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) मान क्रमशः `0`, `1`, `2` और `3` रखें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

### **कस्टम प्रारम्भिक मानों के साथ नंबर्ड सूची आइटम शुरू करें**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) का उपयोग करके नंबर्ड पैराग्राफ के प्रारम्भिक नंबर को निर्धारित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाकर एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन नंबर्ड पैराग्राफ बनाएँ।
4. संबंधित पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारम्भिक नंबर असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ को नियंत्रित करें**

### **पहली‑लाइन इंडेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करके पैराग्राफ की पहली‑लाइन इंडेंट नियंत्रित की जाती है। यह मेथड केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली लाइन को ले जाता है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

पूरे पैराग्राफ को ले जाने के लिए आप [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) का उपयोग करते हैं। केवल पहली लाइन को ले जाने के लिए आप [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करते हैं।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मान लागू करता है ताकि दिखाया जा सके कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करती है।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाएँ और उनके लिए विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को बचाएँ।

यह कोड दर्शाता है कि पैराग्राफ इंडेंट कैसे सेट करें:

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

![पैराग्राफ की पहली‑लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन बाकी लाइनों से बाईं ओर शुरू होती है। Aspose.Slides में आप इसे [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) के साथ प्राप्त कर सकते हैं। पैराग्राफ बॉडी के सापेक्ष पहली लाइन को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ बॉडी की बायीँ स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफ़ी, रेफ़रेंसेज़, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ के लिए उपयोगी है जहाँ लाइन‑ब्रेक को पैराग्राफ बॉडी के नीचे संरेखित किया जाना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) को सकारात्मक मान पास करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को बचाएँ।

यह कोड दर्शाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट करें:

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

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) पैराग्राफ के एंड मार्क की फ़ॉर्मेटिंग को नियंत्रित करता है। निम्न उदाहरण दूसरे पैराग्राफ के एंड مار्क को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाएँ या लोड करें और स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएँ और उनके टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के एंड मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) बनाएँ।
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) सेट करें।
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) के साथ फ़ॉर्मेट असाइन करें और प्रेज़ेंटेशन को बचाएँ।

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

पैराग्राफ नियम जो स्वतः रैपिंग और लाइन अंत में विराम चिह्न को प्रभावित करते हैं, उनके लिए देखें [Control Line Breaking](/slides/hi/nodejs-java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/nodejs-java/text-formatting/#control-hanging-punctuation)।

[Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करके आप टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा ओक्यूपाइड लाइनों की संख्या गिन सकते हैं, जिसमें स्वतः रैपिंग शामिल है। यह प्रेज़ेंटेशन टेम्पलेट में टेक्स्ट लंबाई और लेआउट जांचने में उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs) में एक आइटम है, और वह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वतः रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। Hence, counting पैराग्राफ या लाइन‑ब्रेक कैरेक्टर रेंडर की गई लाइन गिनती नहीं देता।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों को गिनता है, शेप को संकरी करता है, फिर टेक्स्ट को एक छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे, टेक्स्ट या शेप को स्वतः छोटा न हो। शेप का आयाम पॉइंट्स में है। अंत में, उदाहरण एक नया पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन गिनती को जोड़ता है।

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

इन टेक्स्ट और आयामों के साथ, शेप को संकुचित करने से लाइन गिनती बढ़ती है, जबकि छोटा स्ट्रिंग रखने से गिनती घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, उपस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटोफ़िट सेटिंग्स पर निर्भर करती है। टेम्पलेट जांचते समय लक्षित वातावरण के लिए इरादित फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाइयाँ, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी रैपिंग बंद होने पर उपलब्ध चौड़ाई को पार कर सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात करें**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके आप HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
3. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
4. स्रोत HTML स्ट्रिंग को परिभाषित या पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) को पास करें।
6. संशोधित प्रेज़ेंटेशन को बचाएँ।

यह JavaScript उदाहरण HTML को एक टेक्स्ट फ्रेम में आयात करता है:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके आप चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं या लोड करें।
2. स्लाइड तक पहुँचें और उस [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) को खोजें जिसमें टेक्स्ट है।
3. शेप के [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) को कॉल करें।
5. लौटे हुए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह स्वायत्त JavaScript उदाहरण एक टेक्स्ट शेप बनाता है और उसके सभी पैराग्राफ निर्यात करता है:

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

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) के साथ फ़ाइल में सहेजा जा सकता है। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ अपने पैरेंट कलेक्शन में नहीं पाया जा सकता, वैध रेंडरिंग बाउंड नहीं है, या रेंडर नहीं हो सकता, तो [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) `null` लौटाता है। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

निम्न टेक्स्ट बॉक्स में तीन पैराग्राफ हैं:

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर द्वितीय पैराग्राफ को एक सामान्य टेक्स्ट शेप में रेंडर करता है और परिणाम को PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक इमेज को सही ढंग से डिस्पोज़ करने को सुनिश्चित करता है।

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

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) के उस ओवरलोड का उपयोग करें जो `scaleX` और `scaleY` पैरामीटर स्वीकार करता है ताकि क्षैतिज और ऊर्ध्वाधर स्केल फ़ैक्टर सेट किए जा सकें। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना स्केल पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फ़ैक्टर उस अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिये, दोनों फ़ैक्टर `2` रखने से इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रिज़ोल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फ़ैक्टर रखने से पैराग्राफ का ऐस्पेक्ट रेशियो बना रहता है; अलग‑अलग क्षैतिज और ऊर्ध्वाधर फ़ैक्टर आउटपुट को स्वतंत्र रूप से विस्तृत करते हैं।

जब आउटपुट में शेप का फ़िल, बॉर्डर या अन्य विज़ुअल कंटेक्स्ट शामिल होना आवश्यक हो, तो [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) के साथ पूरी शेप को रेंडर करना उपयोगी रहता है। केवल पैराग्राफ‑केवल इमेज के लिये, [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। रैपिंग को निष्क्रिय करने के लिये [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) को सेट करें ताकि लाइनों को टेक्स्ट फ्रेम के किनारों पर तोड़ा न जाए।

**मैं किसी विशिष्ट पैराग्राफ की ऑन‑स्लाइड बाउंड्स कैसे प्राप्त कर सकूँ?**

पैराग्राफ का बाउंडिंग रेक्टेंगल प्राप्त करने के लिये [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करें। व्यक्तिगत पोर्शन के बाउंड्स के लिये [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect) देखें।

**पैराग्राफ एलाइन्मेंट (बाएँ, दाएँ, मध्य, या जस्टिफाई) कहाँ नियंत्रित होता है?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) पैराग्राफ‑स्तर सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेटिंग कुछ भी हो।

प्रत्येक लाइन में विभिन्न फ़ॉन्ट आकारों वाले पोर्शन को वर्टिकली एलाइन करने के लिये देखें [Align Fonts Within a Line](/slides/hi/nodejs-java/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के कुछ हिस्सों के लिये प्रूफिंग लैंग्वेज सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिये [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट शामिल हो सके।