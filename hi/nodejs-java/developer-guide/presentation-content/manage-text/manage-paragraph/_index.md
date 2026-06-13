---
title: JavaScript में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/nodejs-java/manage-paragraph/
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
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ निर्यात करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js (Java के माध्यम से) के साथ पैराग्राफ फ़ॉर्मेटिंग में महारत हासिल करें—PPT, PPTX और ODP प्रेजेंटेशनों में संरेखण, स्पेसिंग और शैली को JavaScript में अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides वह सभी क्लास और क्लासेस प्रदान करता है जिनकी आपको Java में PowerPoint टेक्स्ट, पैराग्राफ और पोर्शन के साथ काम करने की आवश्यकता होती है।

- Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) क्लास प्रदान करता है जिससे आप पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `TextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ करेज़ रिटर्न द्वारा बनाया जाता है)।
- Aspose.Slides [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास प्रदान करता है जिससे आप पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `Paragraph` ऑब्जेक्ट में एक या कई पोर्शन हो सकते हैं (टेक्स्ट पोर्शन ऑब्जेक्ट्स का संग्रह)।
- Aspose.Slides [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) क्लास प्रदान करता है जिससे आप टेक्स्ट और उनकी फ़ॉर्मेटिंग प्रॉपर्टीज़ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं।

एक `Paragraph` ऑब्जेक्ट अपने अंतर्निहित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग प्रॉपर्टीज़ वाले टेक्स्ट को संभालने में सक्षम है।

## **एक साथ कई पोर्शन वाले कई पैराग्राफ जोड़ें**

इन चरणों में दिखाया गया है कि 3 पैराग्राफ और प्रत्येक पैराग्राफ में 3 पोर्शन वाले एक टेक्स्ट फ़्रेम को कैसे जोड़ें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयत [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) से संबद्ध `ITextFrame` प्राप्त करें।
5. दो [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) ऑब्जेक्ट बनाएं और उन्हें [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) के `IParagraphs` संग्रह में जोड़ें।
6. हर नए `Paragraph` के लिए तीन [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट Paragraph के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `Portion` ऑब्जेक्ट को संबंधित `Paragraph` के IPortion संग्रह में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `Portion` ऑब्जेक्ट द्वारा उपलब्ध फ़ॉर्मेटिंग प्रॉपर्टीज़ का उपयोग करके प्रत्येक पोर्शन पर अपनी वांछित फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

```javascript
// एक Presentation क्लास का इनस्टेंस बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुंच रहे हैं
    var slide = pres.getSlides().get_Item(0);
    // Rectangle प्रकार का AutoShape जोड़ें
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape का TextFrame एक्सेस करें
    var tf = ashp.getTextFrame();
    // विभिन्न टेक्स्ट फ़ॉर्मेट वाले Paragraphs और Portions बनाएँ
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // PPTX को डिस्क पर लिखें
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैराग्राफ बुलेट्स का प्रबंधन**

बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) का [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. पैराग्राफ के लिए बुलेट `Type` को `Symbol` सेट करें और बुलेट अक्षर निर्धारित करें।
8. पैराग्राफ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ का `Indent` सेट करें।
10. बुलेट का रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
13. दूसरा पैराग्राफ जोड़ें और चरण 7 से 13 तक की प्रक्रिया दोहराएँ।
14. प्रेजेंटेशन को सहेजें।

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंशिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // Autoshape जोड़ता और एक्सेस करता है
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Autoshape के टेक्स्ट फ़्रेम को एक्सेस करता है
    var txtFrm = aShp.getTextFrame();
    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    txtFrm.getParagraphs().removeAt(0);
    // एक पैराग्राफ बनाता है
    var para = new aspose.slides.Paragraph();
    // पैराग्राफ बुलेट स्टाइल और सिम्बल सेट करता है
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // पैराग्राफ टेक्स्ट सेट करता है
    para.setText("Welcome to Aspose.Slides");
    // बुलेट इंडेंट सेट करता है
    para.getParagraphFormat().setIndent(25);
    // बुलेट रंग सेट करता है
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor को true सेट करता है ताकि अपना बुलेट रंग उपयोग किया जा सके
    // बुलेट ऊँचाई सेट करता है
    para.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para);
    // दूसरा पैराग्राफ बनाता है
    var para2 = new aspose.slides.Paragraph();
    // पैराग्राफ बुलेट टाइप और स्टाइल सेट करता है
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // पैराग्राफ टेक्स्ट जोड़ता है
    para2.setText("This is numbered bullet");
    // बुलेट इंडेंट सेट करता है
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor को true सेट करता है ताकि अपना बुलेट रंग उपयोग किया जा सके
    // बुलेट ऊँचाई सेट करता है
    para2.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para2);
    // संशोधित प्रेजेंटेशन को सहेजता है
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चित्र बुलेट्स का प्रबंधन**

बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) का [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. इमेज को [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में सेट करें और इमेज निर्धारित करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ का `Indent` सेट करें।
11. बुलेट का रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन को सहेजें।

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंसिएट करता है
var presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड को एक्सेस करता है
    var slide = presentation.getSlides().get_Item(0);
    // बुलेट्स के लिए इमेज को इनस्टैंसिएट करता है
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Autoshape जोड़ता और एक्सेस करता है
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // autoshape के टेक्स्टफ़्रेम को एक्सेस करता है
    var textFrame = autoShape.getTextFrame();
    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    textFrame.getParagraphs().removeAt(0);
    // एक नया पैराग्राफ बनाता है
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // पैराग्राफ बुलेट स्टाइल और इमेज सेट करता है
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // बुलेट की ऊँचाई सेट करता है
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    textFrame.getParagraphs().add(paragraph);
    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // प्रेजेंटेशन को PPT फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **बहु‑स्तरीय बुलेट्स का प्रबंधन**

बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। बहु‑स्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. नई स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) का [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएं और गहराई को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ बनाएं और गहराई को 1 सेट करें।
8. तीसरा पैराग्राफ बनाएं और गहराई को 2 सेट करें।
9. चौथा पैराग्राफ बनाएं और गहराई को 3 सेट करें।
10. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेजेंटेशन को सहेजें।

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड को एक्सेस करता है
    var slide = pres.getSlides().get_Item(0);
    // Autoshape जोड़ता और एक्सेस करता है
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // बनाए गए Autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    var text = aShp.addTextFrame("");
    // डिफ़ॉल्ट पैराग्राफ को साफ़ करता है
    text.getParagraphs().clear();
    // पहला पैराग्राफ जोड़ता है
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट लेवल सेट करता है
    para1.getParagraphFormat().setDepth(0);
    // दूसरा पैराग्राफ जोड़ता है
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट लेवल सेट करता है
    para2.getParagraphFormat().setDepth(1);
    // तीसरा पैराग्राफ जोड़ता है
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट लेवल सेट करता है
    para3.getParagraphFormat().setDepth(2);
    // चौथा पैराग्राफ जोड़ता है
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट लेवल सेट करता है
    para4.getParagraphFormat().setDepth(3);
    // पैराग्राफ को कलेक्शन में जोड़ता है
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ का प्रबंधन**

[BulletFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/) क्लास [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) प्रॉपर्टी व अन्य प्रदान करता है जो आपको कस्टम क्रमांकन या फ़ॉर्मेटिंग के साथ पैराग्राफ प्रबंधित करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. पैराग्राफ वाला स्लाइड एक्सेस करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) का [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) को 2 सेट करें।
7. `Paragraph` क्लास से दूसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास से तीसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // बनाए गए autoshape के टेक्स्ट फ़्रेम को एक्सेस करता है
    var textFrame = shape.getTextFrame();
    // डिफ़ॉल्ट मौजूदा पैराग्राफ को हटाता है
    textFrame.getParagraphs().removeAt(0);
    // पहली सूची
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **पैराग्राफ के लिए प्रथम‑लाइन इंडेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड का उपयोग करके पैराग्राफ की प्रथम‑लाइन इंडेंट को नियंत्रित करें। यह मेथड केवल पैराग्राफ की बाएँ मार्जिन के सापेक्ष पहली लाइन को ही स्थानांतरित करता है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि शेष लाइने पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरा पैराग्राफ स्थानांतरित करना हो तो [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) का उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न इंडेंट मान लागू करता है जिससे दिखाया जा सके कि प्रथम‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![पैराग्राफ की प्रथम‑लाइन इंडेंट](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों से बाएँ शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड से बनाते हैं। इंडेंट को नकारात्मक मान सेट करें जिससे पहली लाइन पैराग्राफ बॉडी के सापेक्ष बाएँ खिसक जाये।

व्यवहार में, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) उस मार्जिन के सापेक्ष पहली लाइन की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, एक सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप्ड लाइनों को पहली लाइन के पहले अक्षर के नीचे बजाय पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ के लिए एंड पैराग्राफ रन प्रॉपर्टीज़ का प्रबंधन**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. पैराग्राफ वाला स्लाइड उसकी स्थिति के माध्यम से रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. आयत में दो पैराग्राफ वाला एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें।
5. पैराग्राफ के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
6. पैराग्राफ के लिए एंड प्रॉपर्टीज़ सेट करें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML टेक्स्ट को पैराग्राफ में आयात करें**

Aspose.Slides पैराग्राफ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को जोड़ें और एक्सेस करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं।
8. पढ़े गए TextReader की HTML फ़ाइल सामग्री को TextFrame के [ParagraphCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन को सहेजें।

```javascript
// खाली प्रेजेंटेशन इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // HTML कंटेंट को समायोजित करने के लिए AutoShape जोड़ रहे हैं
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // शेप में टेक्स्ट फ़्रेम जोड़ना
    ashape.addTextFrame("");
    // जोड़े गए टेक्स्ट फ़्रेम में सभी पैराग्राफ साफ़ कर रहे हैं
    ashape.getTextFrame().getParagraphs().clear();
    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड कर रहे हैं
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // HTML स्ट्रीम रीडर से टेक्स्ट को टेक्स्ट फ़्रेम में जोड़ रहे हैं
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // प्रेजेंटेशन सहेज रहे हैं
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैराग्राफ़ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ़ों में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और इच्छित प्रेजेंटेशन लोड करें।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. HTML में निर्यात करने वाले टेक्स्ट वाले शेप को एक्सेस करें।
4. शेप [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को एक्सेस करें।
5. `StreamWriter` का एक इंस्टेंस बनाएं और नई HTML फ़ाइल जोड़ें।
6. StreamWriter को एक प्रारंभिक इंडेक्स दें और अपनी वांछित पैराग्राफ निर्यात करें।

```javascript
// प्रेजेंटेशन फ़ाइल लोड करें
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // वांछित इंडेक्स
    var index = 0;
    // जोड़ा गया शेप एक्सेस कर रहे हैं
    var ashape = slide.getShapes().get_Item(index);
    // आउटपुट HTML फ़ाइल बना रहे हैं
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // पहले पैराग्राफ को HTML के रूप में निकाल रहे हैं
    // पैराग्राफ शुरुआती इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ प्रदान करके पैराग्राफ डेटा को HTML में लिख रहे हैं
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैराग्राफ को इमेज के रूप में सहेजें**

इस अनुभाग में, हम दो उदाहरणों की जाँच करेंगे जो दिखाते हैं कि कैसे [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ को इमेज के रूप में सहेजा जा सकता है। दोनों उदाहरण में शेप से पैराग्राफ वाली इमेज प्राप्त करना (`getImage` मेथड्स का उपयोग करके) [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) क्लास से, शेप के टेक्स्ट फ़्रेम में पैराग्राफ की सीमाएँ गणना करना, और उसे बिटमैप इमेज के रूप में निर्यात करना शामिल है। ये विधियाँ आपको PowerPoint प्रेजेंटेशनों से टेक्स्ट के विशिष्ट भाग निकालने और उन्हें अलग‑अलग इमेज के रूप में सहेजने की अनुमति देती हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकते हैं।

मान लीजिए हमारे पास sample.pptx नामक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, और पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में, हम दूसरे पैराग्राफ को इमेज के रूप में प्राप्त करते हैं। ऐसा करने के लिए, हम प्रेजेंटेशन की पहली स्लाइड से शेप की इमेज निकालते हैं और फिर शेप के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ की सीमाएँ गणना करते हैं। फिर पैराग्राफ को नई बिटमैप इमेज पर पुनः ड्रॉ किया जाता है, जिसे PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से उपयोगी है जब आपको किसी विशेष पैराग्राफ को अलग इमेज के रूप में सहेजना हो और टेक्स्ट के सटीक आयाम और फ़ॉर्मेटिंग बरकरार रखना हो।

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्वरूप को स्मृति में एक bitmap के रूप में सहेजें.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // स्मृति से एक shape bitmap बनाएं.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // आउटपुट इमेज के निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // shape bitmap को क्रॉप करके केवल पैराग्राफ bitmap प्राप्त करें.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![पैराग्राफ इमेज](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में, हम पिछले तरीके को पैराग्राफ इमेज में स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। शेप को प्रेजेंटेशन से निकाला जाता है और `2` के स्केलिंग फ़ैक्टर के साथ इमेज के रूप में सहेजा जाता है। यह पैराग्राफ निर्यात करते समय उच्च रिज़ॉल्यूशन आउटपुट प्रदान करता है। पैराग्राफ की सीमाएँ स्केल को ध्यान में रखकर गणना की जाती हैं। स्केलिंग विशेष रूप से तब उपयोगी होती है जब अधिक विस्तृत इमेज की आवश्यकता हो, उदाहरण के लिए उच्च‑गुणवत्ता वाले प्रिंटेड सामग्री में उपयोग के लिए।

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्केलिंग के साथ shape को स्मृति में bitmap के रूप में सहेजें.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // स्मृति से एक shape bitmap बनाएं.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // आउटपुट इमेज के निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // shape bitmap को क्रॉप करके केवल पैराग्राफ bitmap प्राप्त करें.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम में लाइन रैपिंग को पूरी तरह बंद कर सकता/सकती हूँ?**  
हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/setwraptext/)) का उपयोग करके रैपिंग बंद कर सकते हैं ताकि लाइनें फ्रेम के किनारों पर नहीं टूटें।

**मैं किसी विशिष्ट पैराग्राफ के स्लाइड पर सटीक बाउंड्स कैसे प्राप्त कर सकता/सकती हूँ?**  
आप पैराग्राफ (और यहां तक कि एकल पोर्शन) का बाउंडिंग रेक्टैंगल प्राप्त करके स्लाइड पर उसका सटीक स्थान और आकार जान सकते हैं।

**पैराग्राफ अलाइनमेंट (बाएँ/दाएँ/केंद्र/जस्टिफाई) कहाँ नियंत्रित होता है?**  
[setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setalignment/) [ParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/) में पैराग्राफ‑स्तर की सेटिंग के लिए एक मेथड है; यह व्यक्तिगत पोर्शन फ़ॉर्मेटिंग से निरपेक्ष पूरे पैराग्राफ पर लागू होता है।

**क्या मैं पैराग्राफ का केवल एक हिस्सा (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता/सकती हूँ?**  
हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), इसलिए एक ही पैराग्राफ में कई भाषाएँ मौजूद रह सकती हैं।