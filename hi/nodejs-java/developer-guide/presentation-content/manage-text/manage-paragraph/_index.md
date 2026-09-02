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
- HTML आयात
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
description: "Aspose.Slides for Node.js via Java के साथ पैराग्राफ, भाग, बुलेट, क्रमांकित सूची, इंडेंट, HTML सामग्री, और पैराग्राफ छवियां बनाना और स्वरूपित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java पाठ को टेक्स्ट फ्रेम, पैराग्राफ और भागों की पदानुक्रम के रूप में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) shape में पाठ कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके भागों तथा पैराग्राफ‑स्तर के स्वरूपण तक पहुंच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक भाग का अपना टेक्स्ट और अक्षर‑स्तर का स्वरूपण हो सकता है।

इस प्रकार एक पैराग्राफ कई भागों वाले विभिन्न फ़ॉन्ट, रंग, आकार और अन्य स्वरूपण वाले टेक्स्ट को शामिल कर सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **कई भागों वाले पैराग्राफ बनाना**

निम्नलिखित चरण तीन पैराग्राफ वाले टेक्स्ट फ्रेम को बनाते हैं, प्रत्येक में तीन भाग होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन भाग रखने के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली भाग मौजूद है।
7. प्रत्येक भाग का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/getportionformat/) के माध्यम से अक्षर‑स्तर का स्वरूपण लागू करें।
9. परिवर्तित प्रस्तुति को सहेजें।

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

## **बुलेटेड और क्रमांकित सूची बनाना**

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकन संबंधित वस्तुओं को तेज़ी से स्कैन करने में मदद करते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
6. सिम्बल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें और बुलेट अक्षर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग, और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. एक दूसरा पैराग्राफ बनाएं और [BulletFormat.setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह JavaScript उदाहरण सिम्बल बुलेट और क्रमांकित बुलेट बनाता है:
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

### **चित्र बुलेट का उपयोग करें**

चित्र बुलेट आपको सिम्बल या संख्या के बजाय एक कस्टम चित्र का उपयोग करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
5. बुलेट छवि लोड करें और इसे प्रस्तुति की इमेज संग्रह में [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/settype/) को [BulletType.Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/getpicture/) के माध्यम से चित्र असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. परिवर्तित प्रस्तुति को सहेजें।

यह JavaScript उदाहरण चित्र बुलेट बनाता है:
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

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setdepth/) को सेट करें ताकि पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सके। शीर्ष स्तर की गहराई `0` है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setdepth/) मान को क्रमशः `0`, `1`, `2`, `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह JavaScript उदाहरण चार-स्तरीय बुलेटेड सूची बनाता है:
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

एक क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या सेट करने हेतु [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) बनाएं और स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
2. Shape के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith] को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह JavaScript उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारंभिक संख्या असाइन करता है:
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

## **पैराग्राफ लेआउट और अंत गुणों को नियंत्रित करना**

### **पहली पंक्ति का इंडेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित करें। यह विधि केवल पैराग्राफ की बाईं मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएं शिफ्ट करता है, जबकि शेष पंक्तियां पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) का उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान लागू करता है ताकि दर्शाया जा सके कि पहली पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. परिवर्तित प्रस्तुति को सहेजें।

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
![पैराग्राफ की पहली पंक्ति का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों के बाएं शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) से बना सकते हैं। प्रथम पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएं ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ बॉडी की बायीं स्थिति को निर्धारित करता है, और [ParagraphFormat.setIndent] पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह स्वरूपण ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ के लिए उपयोगी है जहाँ लिपटे हुए पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) को सकारात्मक मान पास करके पैराग्राफ बनाएं।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. परिवर्तित प्रस्तुति को सहेजें।

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
![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **पैराग्राफ अंत रन गुण सेट करें**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) पैराग्राफ के अंत चिह्न के स्वरूपण को नियंत्रित करता है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) बनाएं या लोड करें और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट भाग जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) बनाएं।
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) को सेट करें।
6. स्वरूप को [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) के साथ असाइन करें और प्रस्तुति को सहेजें।

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

## **पैराग्राफ सामग्री आयात और निर्यात**

### **पैराग्राफ में HTML टेक्स्ट आयात करना**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और भागों में परिवर्तित करें।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुंचें और एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
3. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML स्ट्रिंग को परिभाषित या पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) को पास करें।
6. परिवर्तित प्रस्तुति को सहेजें।

यह JavaScript उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:
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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) बनाएं या लोड करें।
2. स्लाइड तक पहुंचें और वह [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. Shape के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
4. शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह स्वनिर्भर JavaScript उदाहरण एक टेक्स्ट शेप बनाता है और उसके सभी पैराग्राफ निर्यात करता है:
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

### **पैराग्राफ को छवि के रूप में रेंडर करना**

[Paragraph.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getImage) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) से फ़ाइल में सुरक्षित करें। आपको समेटे हुए शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ नहीं मिला, वैध रेंडरिंग बॉन्ड नहीं है, या रेंडर नहीं किया जा सकता, तो [Paragraph.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getImage) `null` लौटा सकता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई छवि को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

निम्न टेक्स्ट बॉक्स में तीन पैराग्राफ हैं:
![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण दूसरा पैराग्राफ एक सामान्य टेक्स्ट शेप में डिफ़ॉल्ट स्केल पर रेंडर करता है और लौटाए गए छवि को PNG प्रारूप में सहेजता है। `finally` ब्लॉक सुनिश्चित करता है कि छवि सही रूप से डिस्पोज़ हो।

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

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

`scaleX` और `scaleY` पैरामीटर स्वीकार करने वाले [Paragraph.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getImage) ओवरलोड का उपयोग करके क्षैतिज और ऊर्ध्वक स्केल फैक्टर सेट करें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG छवि के रूप में सहेजता है।

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

`1` का स्केल फैक्टर उस अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर्स के लिए `2` सेट करने से छवि की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे पिक्सेल चार गुना हो जाते हैं। बड़े फैक्टर आमतौर पर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से कम फैक्टर छोटे चित्र बनाते हैं जिनमें कम विवरण होता है। समान फैक्टर रखकर पैराग्राफ का एस्पेक्ट अनुपात संरक्षित रहता है; अलग क्षैतिज और ऊर्ध्वक फैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

पूरे शेप को [Shape.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) से रेंडर करना तब उपयोगी होता है जब आउटपुट में शेप की भरावट, बॉर्डर या अन्य दृश्य संदर्भ शामिल करने की आवश्यकता हो। केवल पैराग्राफ छवि के लिए, [Paragraph.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getImage) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से निष्क्रिय कर सकता हूँ?**  
हाँ। लाइन रैपिंग को बंद करने के लिए [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/setwraptext/) को सेट करें ताकि लाइनों को टेक्स्ट फ्रेम के किनारों पर न तोड़ा जाए।

**मैं किसी विशेष पैराग्राफ की स्लाइड पर सटीक सीमा कैसे प्राप्त कर सकता हूँ?**  
पैराग्राफ की बाउंडिंग रेक्टेंगल प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/getrect/) उपयोग करें। व्यक्तिगत भाग की सीमाएँ प्राप्त करने के लिए [Portion.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getRect) का उपयोग करें।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, केंद्र, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**  
[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setalignment/) एक पैराग्राफ‑स्तर की सेटिंग है और व्यक्तिगत भाग के स्वरूपण से स्वतंत्र रूप से पूरे पैराग्राफ पर लागू होती है।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफिंग भाषा सेट कर सकता हूँ?**  
हाँ। व्यक्तिगत भागों के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट शामिल हो सके।