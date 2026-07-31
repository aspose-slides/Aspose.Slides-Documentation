---
title: जावास्क्रिप्ट में PowerPoint टेक्स्ट पैराग्राफ़ का प्रबंधन
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ़ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ़ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावा द्वारा पैराग्राफ़ फ़ॉर्मेटिंग में महारत हासिल करें—PPT, PPTX और ODP प्रेज़ेंटेशन में संरेखण, स्पेसिंग और शैली को जावास्क्रिप्ट में अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides जावा में PowerPoint के टेक्स्ट, पैराग्राफ और पोर्शन के साथ काम करने के लिए आवश्यक सभी क्लासेस प्रदान करता है।

* Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) क्लास प्रदान करता है जो आपको पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है। एक `TextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा बनाया जाता है)।
* Aspose.Slides [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास प्रदान करता है जो आपको पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है। एक `Paragraph` ऑब्जेक्ट में एक या कई पोर्शन हो सकते हैं (टेक्स्ट पोर्शन ऑब्जेक्ट्स का संग्रह)।
* Aspose.Slides [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) क्लास प्रदान करता है जो आपको टेक्स्ट और उनके फ़ॉर्मेटिंग प्रॉपर्टीज़ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है।

एक `Paragraph` ऑब्जेक्ट अपने अंतर्निहित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग गुणों वाले टेक्स्ट को संभालने में सक्षम है।

## **एकाधिक पैराग्राफ़ जिनमें कई पोर्शन हों जोड़ें**

इन चरणों से आप 3 पैराग्राफ़ वाले टेक्स्ट फ़्रेम को और प्रत्येक पैराग्राफ़ में 3 पोर्शन को कैसे जोड़ें, दिखाया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. उस [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) से संबंधित `ITextFrame` प्राप्त करें।
5. दो [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) ऑब्जेक्ट बनाएँ और उन्हें [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) की `IParagraphs` कलेक्शन में जोड़ें।
6. प्रत्येक नई `Paragraph` के लिए तीन [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट बनाएँ (डिफ़ॉल्ट पैराग्राफ़ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `Portion` को उस `Paragraph` की `IPortion` कलेक्शन में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `Portion` ऑब्जेक्ट द्वारा प्रदान किए गए फ़ॉर्मेटिंग प्रॉपर्टीज़ का उपयोग करके प्रत्येक पोर्शन पर अपनी वांछित फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड पैराग्राफ़ जो पोर्शन रखते हैं, उन्हें जोड़ने के चरणों का कार्यान्वयन है:

```javascript
// एक Presentation क्लास का उदाहरण बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँच रहे हैं
    var slide = pres.getSlides().get_Item(0);
    // Rectangle प्रकार का AutoShape जोड़ें
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape का TextFrame प्राप्त करें
    var tf = ashp.getTextFrame();
    // विभिन्न टेक्स्ट फ़ॉर्मेट के साथ Paragraphs और Portions बनाएँ
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

## **पैराग्राफ बुलेट्स को प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी रूप से व्यवस्थित करने और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ इंस्टेंस बनाएँ।
7. पैराग्राफ़ के लिए बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर निर्धारित करें।
8. पैराग्राफ़ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ़ का `Indent` सेट करें।
10. बुलेट का रंग निर्धारित करें।
11. बुलेट की ऊँचाई सेट करें।
12. नई पैराग्राफ़ को `TextFrame` की पैराग्राफ़ कलेक्शन में जोड़ें।
13. दूसरा पैराग्राफ़ जोड़ें और चरण 7 से 13 को दोहराएँ।
14. प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड आपको पैराग्राफ बुलेट जोड़ना दिखाता है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // ऑटोशेप जोड़ता है और उसकी पहुँच प्राप्त करता है
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // ऑटोशेप के टेक्स्ट फ़्रेम तक पहुँचता है
    var txtFrm = aShp.getTextFrame();
    // डिफ़ॉल्ट पैराग्राफ़ को हटाता है
    txtFrm.getParagraphs().removeAt(0);
    // एक पैराग्राफ़ बनाता है
    var para = new aspose.slides.Paragraph();
    // पैराग्राफ़ बुलेट शैली और प्रतीक सेट करता है
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // पैराग्राफ़ का टेक्स्ट सेट करता है
    para.setText("Welcome to Aspose.Slides");
    // बुलेट इंडेंट सेट करता है
    para.getParagraphFormat().setIndent(25);
    // बुलेट का रंग सेट करता है
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // अपना बुलेट रंग उपयोग करने के लिए IsBulletHardColor को true सेट करता है
    // बुलेट की ऊँचाई सेट करता है
    para.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para);
    // दूसरा पैराग्राफ़ बनाता है
    var para2 = new aspose.slides.Paragraph();
    // पैराग्राफ़ बुलेट प्रकार और शैली सेट करता है
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // पैराग्राफ़ का टेक्स्ट जोड़ता है
    para2.setText("This is numbered bullet");
    // बुलेट इंडेंट सेट करता है
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // अपना बुलेट रंग उपयोग करने के लिए IsBulletHardColor को true सेट करता है
    // बुलेट की ऊँचाई सेट करता है
    para2.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para2);
    // संशोधित प्रेज़ेंटेशन को सेव करता है
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चित्र बुलेट्स को प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी रूप से व्यवस्थित करने और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ इंस्टेंस बनाएँ।
7. [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में छवि लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) पर सेट करें और छवि निर्धारित करें।
9. पैराग्राफ़ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ़ का `Indent` सेट करें।
11. बुलेट का रंग निर्धारित करें।
12. बुलेट की ऊँचाई सेट करें।
13. नई पैराग्राफ़ को `TextFrame` की पैराग्राफ़ कलेक्शन में जोड़ें।
14. दूसरा पैराग्राफ़ जोड़ें और पूर्व चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड आपको चित्र बुलेट जोड़ना और प्रबंधित करना दिखाता है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slide = presentation.getSlides().get_Item(0);
    // बुलेट्स के लिए इमेज बनाता है
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ऑटोशेप जोड़ता है और उसकी पहुँच प्राप्त करता है
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // ऑटोशेप के टेक्स्टफ़्रेम तक पहुँचता है
    var textFrame = autoShape.getTextFrame();
    // डिफ़ॉल्ट पैराग्राफ़ को हटाता है
    textFrame.getParagraphs().removeAt(0);
    // एक नया पैराग्राफ़ बनाता है
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // पैराग्राफ़ बुलेट शैली और इमेज सेट करता है
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // बुलेट की ऊँचाई सेट करता है
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    textFrame.getParagraphs().add(paragraph);
    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // प्रेज़ेंटेशन को PPT फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **बहु-स्तरीय बुलेट्स को प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी रूप से व्यवस्थित करने और प्रस्तुत करने में मदद करती हैं। बहु-स्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. नई स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ़ बनाएं और गहराई (depth) को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ़ बनाएं और गहराई को 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ़ बनाएं और गहराई को 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ़ बनाएं और गहराई को 3 सेट करें।
10. नई पैराग्राफ़ को `TextFrame` की पैराग्राफ़ कलेक्शन में जोड़ें।
11. संशोधित प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड आपको बहु-स्तरीय बुलेट्स जोड़ना और प्रबंधित करना दिखाता है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // ऑटोशेप जोड़ता है और उसकी पहुँच प्राप्त करता है
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुँचता है
    var text = aShp.addTextFrame("");
    // डिफ़ॉल्ट पैराग्राफ़ को साफ़ करता है
    text.getParagraphs().clear();
    // पहला पैराग्राफ़ जोड़ता है
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट स्तर सेट करता है
    para1.getParagraphFormat().setDepth(0);
    // दूसरा पैराग्राफ़ जोड़ता है
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट स्तर सेट करता है
    para2.getParagraphFormat().setDepth(1);
    // तीसरा पैराग्राफ़ जोड़ता है
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट स्तर सेट करता है
    para3.getParagraphFormat().setDepth(2);
    // चौथा पैराग्राफ़ जोड़ता है
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // बुलेट स्तर सेट करता है
    para4.getParagraphFormat().setDepth(3);
    // पैराग्राफ़ को कलेक्शन में जोड़ता है
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // प्रस्तुति को PPTX फ़ाइल के रूप में लिखता है
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ़ प्रबंधित करें**

[BulletFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/) क्लास [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) प्रॉपर्टी और अन्य प्रदान करता है जो आपको कस्टम क्रमांकित या फ़ॉर्मेटेड पैराग्राफ़ प्रबंधित करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उस स्लाइड तक पहुँचें जिसमें पैराग्राफ़ है।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास से पहला पैराग्राफ़ बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) को 2 सेट करें।
7. `Paragraph` क्लास से दूसरा पैराग्राफ़ बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास से तीसरा पैराग्राफ़ बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नई पैराग्राफ़ को `TextFrame` की पैराग्राफ़ कलेक्शन में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड आपको कस्टम क्रमांकित या फ़ॉर्मेटेड पैराग्राफ़ जोड़ना और प्रबंधित करना दिखाता है:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुँचता है
    var textFrame = shape.getTextFrame();
    // डिफ़ॉल्ट मौज़ूद पैराग्राफ़ को हटाता है
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

## **पैराग्राफ़ के पहले-लाइन इंडेंट को सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड का उपयोग करके आप पैराग्राफ़ की पहली लाइन के इंडेंट को नियंत्रित कर सकते हैं। यह मेथड केवल पहली लाइन को पैराग्राफ़ के बाएँ मार्जिन के सापेक्ष स्थानांतरित करता है। एक सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनें पैराग्राफ़ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरी पैराग्राफ़ को लेजाना हो, तो [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) का प्रयोग करें। केवल पहली लाइन को लेजाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) का प्रयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ़ बनाता है और विभिन्न इंडेंट मान लागू करता है ताकि दिखाया जा सके कि पहली लाइन का इंडेंट पैराग्राफ़ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
5. कई पैराग्राफ़ बनाएँ और उनके लिए अलग‑अलग [Indent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
6. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को सेव करें।

यह कोड आपको पैराग्राफ़ इंडेंट सेट करने का तरीका दिखाता है:

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

परिणाम:

![पैराग्राफ़ की पहली-लाइन इंडेंट](first_line_indent.png)

## **पैराग्राफ़ के हैंगिंग इंडेंट को सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ़ लेआउट है जिसमें पहली लाइन शेष लाइनों से बाईं ओर शुरू होती है। Aspose.Slides में आप इस प्रभाव को [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मेथड से बना सकते हैं। पहली लाइन को बाएँ ले जाने के लिए इंडेंट को नकारात्मक मान सेट करें।

व्यवहार में, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ़ बॉडी की बायीं स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष सेट करता है। हैंगिंग इंडेंट बनाने के लिए, सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफ़ी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ़ बॉडी के नीचे संरेखित होना चाहिए न कि पहली लाइन के पहले कैरेक्टर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
5. प्रत्येक पैराग्राफ़ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
7. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को सेव करें।

यह कोड आपको पैराग्राफ़ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

परिणाम:

![पैराग्राफ़ की हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ़ के End Run प्रॉपर्टीज़ को प्रबंधित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
1. उसकी पोजीशन के आधार पर पैराग्राफ़ वाले स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आयत में दो पैराग्राफ़ वाले [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को जोड़ें।
1. पैराग्राफ़ के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ़ के End प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Javascript कोड आपको PowerPoint में पैराग्राफ़ के End प्रॉपर्टीज़ सेट करने का तरीका दिखाता है:

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

## **HTML टेक्स्ट को पैराग्राफ़ में आयात करें**

Aspose.Slides HTML टेक्स्ट को पैराग्राफ़ में आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें.
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. `AutoShape` की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) जोड़ें और पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ़ इंस्टेंस बनाएं।
8. पढ़े हुए TextReader की सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेज़ेंटेशन को सेव करें।

यह Javascript कोड पैराग्राफ़ में HTML टेक्स्ट आयात करने के चरणों का कार्यान्वयन है:

```javascript
// खाली प्रस्तुति इंस्टेंस बनाएँ
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // HTML सामग्री को समाहित करने के लिए AutoShape जोड़ें
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // शेप में टेक्स्ट फ्रेम जोड़ें
    ashape.addTextFrame("");
    // जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ़ साफ़ करें
    ashape.getTextFrame().getParagraphs().clear();
    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड कर रहे हैं
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // HTML स्ट्रीम रीडर से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ रहे हैं
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // प्रेज़ेंटेशन सहेज रहे हैं
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैराग्राफ़ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ़ में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाकर आवश्यक प्रेज़ेंटेशन लोड करें।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. उस आकार तक पहुँचें जिसमें वह टेक्स्ट है जिसे HTML में निर्यात किया जाना है।
4. आकार की [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुँचें।
5. एक `StreamWriter` की इंस्टेंस बनाकर नया HTML फ़ाइल जोड़ें।
6. `StreamWriter` को प्रारंभिक इंडेक्स प्रदान करें और अपनी इच्छित पैराग्राफ़ निर्यात करें।

यह Javascript कोड आपको PowerPoint पैराग्राफ़ टेक्स्ट को HTML में निर्यात करने का तरीका दिखाता है:

```javascript
// प्रस्तुति फ़ाइल लोड करें
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // प्रेज़ेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // वांछित इंडेक्स
    var index = 0;
    // जोड़ा गया शेप एक्सेस कर रहे हैं
    var ashape = slide.getShapes().get_Item(index);
    // आउटपुट HTML फ़ाइल बना रहे हैं
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // पहले पैराग्राफ़ को HTML के रूप में निकाल रहे हैं
    // पैराग्राफ़ प्रारंभिक इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ़ प्रदान करके पैराग्राफ़ डेटा को HTML में लिख रहे हैं
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पैराग्राफ़ को इमेज के रूप में सेव करें**

इस अनुभाग में हम दो उदाहरणों का अन्वेषण करेंगे जो दिखाते हैं कि कैसे आप [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) क्लास द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ़ को इमेज के रूप में सेव कर सकते हैं। दोनों उदाहरणों में `getImage` मेथड से [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) क्लास का उपयोग करके पैराग्राफ़ वाले आकार की इमेज प्राप्त करना, आकार के भीतर पैराग्राफ़ के बाउंड्स की गणना करना, और इसे बिटमैप इमेज के रूप में एक्सपोर्ट करना शामिल है। ये तरीके आपको PowerPoint प्रेज़ेंटेशन से विशिष्ट टेक्स्ट भागों को निकालने और उन्हें अलग-अलग इमेज के रूप में सेव करने की सुविधा देते हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकता है।

मान लीजिए हमारे पास sample.pptx नामक एक प्रेज़ेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला आकार तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ़ को इमेज के रूप में प्राप्त करते हैं। इसके लिए हम प्रेज़ेंटेशन की पहली स्लाइड से आकार की इमेज निकालते हैं और फिर आकार के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ़ के बाउंड्स की गणना करते हैं। पैराग्राफ़ को नई बिटमैप इमेज पर पुनः ड्रॉ किया जाता है और PNG फ़ॉर्मेट में सेव किया जाता है। यह विधि तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ़ को अलग इमेज के रूप में सेव करना हो जबकि टेक्स्ट के सटीक आयाम और फ़ॉर्मेटिंग बनाए रखनी हो।

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // मेमोरी से आकार का बिटमैप बनाएं।
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // आउटपुट इमेज के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए आकार बिटमैप को क्रॉप करें।
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

परिणाम:

![पैराग्राफ़ इमेज](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले दृष्टिकोण को स्केलिंग फैक्टर जोड़कर विस्तारित करते हैं। आकार को प्रेज़ेंटेशन से निकालकर `2` के स्केलिंग फैक्टर के साथ इमेज के रूप में सेव किया जाता है। यह पैराग्राफ़ को एक्सपोर्ट करते समय उच्च रिज़ॉल्यूशन आउटपुट देता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ़ बाउंड्स की गणना की जाती है। स्केलिंग तब उपयोगी होती है जब अधिक विस्तृत इमेज की आवश्यकता हो, जैसे उच्च गुणवत्ता वाली प्रिंट सामग्री में उपयोग के लिए।

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्केलिंग के साथ आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से आकार का बिटमैप बनाएं।
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // आउटपुट इमेज के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए आकार बिटमैप को क्रॉप करें।
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

**क्या मैं टेक्स्ट फ़्रेम के अंदर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/setwraptext/)) का उपयोग करके रैपिंग बंद कर दें ताकि लाइनों का फ्रेम के किनारों पर टूटना न हो।

**मैं किसी विशिष्ट पैराग्राफ़ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

आप पैराग्राफ़ (और यहाँ तक कि किसी एकल पोर्शन) का बाउंडिंग रैक्टेंगल प्राप्त कर सकते हैं जिससे उसकी स्लाइड पर सटीक स्थिति और आकार ज्ञात हो सके।

**पैराग्राफ़ संरेखण (बाएँ/दाएँ/केंद्र/जस्टिफ़ाइ) कहाँ नियंत्रित किया जाता है?**

[setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setalignment/) एक मेथड है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/) में पैराग्राफ‑स्तर की सेटिंग के लिए है; यह पूरे पैराग्राफ़ पर लागू होता है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ़ के केवल एक हिस्से (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), इसलिए एक ही पैराग्राफ़ में कई भाषाएँ coexist कर सकती हैं।