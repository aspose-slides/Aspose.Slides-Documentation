---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 60
url: /hi/nodejs-java/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहुस्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहुस्तरीय और क्रमांकित सूचियों को बनाने और स्वरूपित करने के बारे में जानें।"
---
## **Overview**

Aspose.Slides for Node.js via Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबर्ड सूचियाँ बनाने और स्वरूपित करने की सुविधा देता है। एक सूची आइटम वह पैराग्राफ होता है जिसका बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित की जाती हैं।

पैराग्राफ‑स्तर की सूची सेटिंग्स तक पहुँचने के लिए [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास का उपयोग करें। मुख्य प्रवेश बिंदु `Paragraph.getParagraphFormat().getBullet()` है, जो एक [BulletFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांक शैली, और प्रारम्भिक संख्या सेट कर सकते हैं।

यह लेख दर्शाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएँ
- चित्र बुलेट बनाएँ
- पैराग्राफ डेप्थ सेट करके मल्टी‑लेवल सूची बनाएँ
- नंबर्ड सूची बनाएँ
- मौजूदा प्रस्तुतियों में सूची स्वरूपण की जाँच और परिवर्तन करें

## **Create a Bulleted List**

बुलेटेड सूची बनाने के लिए, एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) में [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें और `BulletFormat.setType` को [BulletType.Symbol](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें। आप फिर `BulletFormat.setChar`, `BulletFormat.getColor`, और `BulletFormat.setHeight` सेट करके बुलेट की उपस्थिति नियंत्रित कर सकते हैं।

निम्नलिखित JavaScript कोड दिखाता है कि स्लाइड में बुलेटेड सूची कैसे बनायीँ:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The symbol bullets](symbol_bullets.png)

## **Create a Numbered List**

जब आइटमों का क्रम महत्वपूर्ण हो, तो नंबर्ड सूचियों का उपयोग करें। `BulletFormat.setType` को [BulletType.Numbered](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें। आप `BulletFormat.setNumberedBulletStyle` से क्रमांकन प्रारूप चुन सकते हैं या `BulletFormat.setNumberedBulletStartWith` सेट करके सूची को 1 के अलावा किसी अन्य मान से शुरू कर सकते हैं।

निम्नलिखित JavaScript कोड स्लाइड में नंबर्ड सूची बनाने का तरीका दर्शाता है:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The numbered bullets](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को छवि से बदलने की अनुमति देता है। चित्र बुलेट सरल छवियों के साथ सबसे अच्छा काम करते हैं जो छोटे आकार में भी पठनीय रहें, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="primary" %}}
यदि आप सामान्य बुलेट प्रतीक को छवि से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि वाली सरल ग्राफिक चुनना सबसे अच्छा है। ऐसी छवियाँ कस्टम बुलेट प्रतीकों के रूप में अच्छी काम करती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम अत्यधिक अनुशंसा करते हैं कि ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग किए जाने पर स्पष्ट और दृश्य रूप से प्रभावी रहे।

{{% /alert %}}

चित्र बुलेट बनाने के लिए, `Presentation.getImages().addImage` के साथ एक छवि को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) में जोड़ें और लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट को `BulletFormat.getPicture().setImage` को असाइन करें। चित्र असाइन करने से पहले `BulletFormat.setType` को [BulletType.Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bullettype/) पर सेट करें।

मान लें हमारे पास "image.png" है:

![A picture for the bullets](picture_for_bullets.png)

निम्नलिखित JavaScript कोड स्लाइड में चित्र बुलेट बनाने का तरीका दिखाता है:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

परिणाम:

![The picture bullets](picture_bullets.png)

## **Create a Multilevel List**

सूची आइटमों को विभिन्न स्तरों पर रखने के लिए `ParagraphFormat.setDepth` का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, और इसी तरह।

निम्नलिखित JavaScript कोड मल्टी‑लेवल बुलेटेड सूची बनाने का तरीका दर्शाता है:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The multilevel list](multilevel_list.png)

## **Change an Existing List**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुँचें और उसके `ParagraphFormat.getBullet` सेटिंग्स को अपडेट करें। सूची बनाने के लिए प्रयोग किए गए वही गुण PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचियों की जाँच या संशोधन के लिए उपयोग किए जा सकते हैं।

निम्नलिखित JavaScript कोड एक टेक्स्ट फ़्रेम में पहले पैराग्राफ को नंबर्ड सूची शैली में बदलता है:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या बुलेटेड और नंबर्ड सूचियों को PDF या छवियों में निर्यात किया जा सकता है?**

हाँ। जब लक्ष्य स्वरूप संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है, तो Aspose.Slides सूची स्वरूपण को संरक्षित रखता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके `ParagraphFormat.getBullet` सेटिंग्स की जाँच या अपडेट करें, और फिर प्रस्तुति को बचाएँ।

**क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?**

हाँ। सूची आइटम टेक्स्ट Unicode अक्षरों को सम्मिलित कर सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों का समर्थन करते हों।