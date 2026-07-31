---
title: Android पर PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
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
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ पैराग्राफ फ़ॉर्मेटिंग में महारत हासिल करें—PPT, PPTX और ODP प्रेज़ेंटेशन में Java में संरेखण, स्पेसिंग एवं शैली को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides जावा में PowerPoint टेक्स्ट, अनुच्छेद और पोर्शन के साथ काम करने के लिए आवश्यक सभी इंटरफ़ेस और क्लासेस प्रदान करता है।

* Aspose.Slides वह [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस प्रदान करता है जिससे आप पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रीटर्न से बनाया जाता है)।
* Aspose.Slides वह [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) इंटरफ़ेस प्रदान करता है जिससे आप पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `IParagraph` ऑब्जेक्ट में एक या कई पोर्शन (iPortions ऑब्जेक्ट्स का संग्रह) हो सकते हैं।
* Aspose.Slides वह [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) इंटरफ़ेस प्रदान करता है जिससे आप टेक्स्ट और उसकी फ़ॉर्मेटिंग प्रॉपर्टीज़ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं।

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग प्रॉपर्टीज़ वाले टेक्स्ट को संभाल सकता है।

## **एकाधिक टेक्स्ट पोर्शन वाले कई पैराग्राफ जोड़ें**

इन चरणों से आप 3 पैराग्राफ और प्रत्येक पैराग्राफ में 3 पोर्शन वाला टेक्स्ट फ़्रेम जोड़ना सीखेंगे:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक Rectangle प्रकार का [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) से जुड़ा हुआ ITextFrame प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) ऑब्जेक्ट बनाएँ और उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) के `IParagraphs` संग्रह में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) ऑब्जेक्ट बनाएँ (डिफ़ॉल्ट पैराग्राफ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` ऑब्जेक्ट को प्रत्येक `IParagraph` के IPortion संग्रह में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. प्रत्येक पोशन पर `IPortion` ऑब्जेक्ट द्वारा प्रदान किए गए फ़ॉर्मेटिंग प्रॉपर्टीज़ का उपयोग करके अपनी पसंदीदा फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
// एक Presentation क्लास का उदाहरण बनाते हैं जो PPTX फ़ाइल का प्रतिनिधित्व करती है
// पहली स्लाइड तक पहुँच रहे हैं
// Rectangle प्रकार का AutoShape जोड़ें
// AutoShape का TextFrame प्राप्त करें
// विभिन्न टेक्स्ट फ़ॉर्मेट्स के साथ पैराग्राफ और पोर्शन बनाएं
    // PPTX को डिस्क पर लिखें
```

## **पैराग्राफ बुलेट्स प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. चयनित स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. ऑटोषेप के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएँ।
7. पैराग्राफ के बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर सेट करें।
8. पैराग्राफ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
10. बुलेट का रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
13. दूसरा पैराग्राफ जोड़ें और चरण 7‑13 को दोहराएँ।
14. प्रेज़ेंटेशन को सहेजें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ऑटोशेप जोड़ता और पहुँचता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // ऑटोशेप के टेक्स्ट फ़्रेम तक पहुँचता है
    ITextFrame txtFrm = aShp.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    txtFrm.getParagraphs().removeAt(0);

    // एक पैराग्राफ बनाता है
    Paragraph para = new Paragraph();

    // पैराग्राफ बुलेट शैली और प्रतीक सेट करता है
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // पैराग्राफ टेक्स्ट सेट करता है
    para.setText("Welcome to Aspose.Slides");

    // बुलेट इंडेंट सेट करता है
    para.getParagraphFormat().setIndent(25);

    // बुलेट रंग सेट करता है
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को सत्य सेट करता है ताकि अपना बुलेट रंग उपयोग किया जा सके

    // बुलेट की ऊँचाई सेट करता है
    para.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para);

    // दूसरा पैराग्राफ बनाता है
    Paragraph para2 = new Paragraph();

    // पैराग्राफ बुलेट प्रकार और शैली सेट करता है
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // पैराग्राफ टेक्स्ट जोड़ता है
    para2.setText("This is numbered bullet");

    // बुलेट इंडेंट सेट करता है
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को सत्य सेट करता है ताकि अपना बुलेट रंग उपयोग किया जा सके

    // बुलेट की ऊँचाई सेट करता है
    para2.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para2);
    
    // संशोधित प्रेजेंटेशन को सहेजता है
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र बुलेट्स प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. ऑटोषेप के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएँ।
7. [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) में चित्र लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) पर सेट करें और चित्र सेट करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट का रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
// एक Presentation क्लास को इंस्टैंसिएट करता है जो PPTX फ़ाइल का प्रतिनिधित्व करती है
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = presentation.getSlides().get_Item(0);

    // बुलेट्स के लिए इमेज को इंस्टैंसिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // ऑटोशेप जोड़ता और पहुँचता है
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // ऑटोशेप के टेक्स्टफ़्रेम तक पहुँचता है
    ITextFrame textFrame = autoShape.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    textFrame.getParagraphs().removeAt(0);

    // नया पैराग्राफ बनाता है
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // पैराग्राफ बुलेट शैली और इमेज सेट करता है
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // बुलेट की ऊँचाई सेट करता है
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्टफ़्रेम में जोड़ता है
    textFrame.getParagraphs().add(paragraph);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // प्रेज़ेंटेशन को PPT फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **बहु‑स्तरीय बुलेट्स प्रबंधित करें**

बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहु‑स्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. नई स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. ऑटोषेप के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएँ और गहराई 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ बनाएँ और गहराई 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ बनाएँ और गहराई 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ बनाएँ और गहराई 3 सेट करें।
10. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
// एक Presentation क्लास को इंस्टैंसिएट करता है जो PPTX फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);

    // ऑटोशेप जोड़ता और पहुँचता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame text = aShp.addTextFrame("");

    // डिफ़ॉल्ट पैराग्राफ को साफ़ करता है
    text.getParagraphs().clear();

    // पहला पैराग्राफ जोड़ता है
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para1.getParagraphFormat().setDepth((short)0);

    // दूसरा पैराग्राफ जोड़ता है
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para2.getParagraphFormat().setDepth((short)1);

    // तीसरा पैराग्राफ जोड़ता है
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para3.getParagraphFormat().setDepth((short)2);

    // चौथा पैराग्राफ जोड़ता है
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para4.getParagraphFormat().setDepth((short)3);

    // पैराग्राफ को संग्रह में जोड़ता है
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम क्रमांकित सूची वाला पैराग्राफ प्रबंधित करें**

[IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) प्रॉपर्टी और अन्य प्रदान करता है जिससे आप कस्टम क्रमांक या फ़ॉर्मेटिंग वाले पैराग्राफ को प्रबंधित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. उस स्लाइड तक पहुँचें जिसमें पैराग्राफ है।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. ऑटोषेप के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास से पहला पैराग्राफ बनाएँ और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को 2 सेट करें।
7. `Paragraph` क्लास से दूसरा पैराग्राफ बनाएँ और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास से तीसरा पैराग्राफ बनाएँ और `NumberedBulletStartWith` को 7 सेट करें।
9. नए पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए ऑटोशेप के टेक्स्ट फ़्रेम तक पहुँचता है
    ITextFrame textFrame = shape.getTextFrame();

    // डिफ़ॉल्ट मौजूदा पैराग्राफ को हटाता है
    textFrame.getParagraphs().removeAt(0);

    // पहली सूची
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **पैराग्राफ के लिए पहली‑पंक्ति इंडेंट सेट करें**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड का उपयोग करके आप पैराग्राफ की पहली‑पंक्ति इंडेंट को नियंत्रित कर सकते हैं। यह मेथड केवल पैराग्राफ की बायाँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करता है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

पूरा पैराग्राफ ले जाना हो तो [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) उपयोग करें। केवल पहली पंक्ति ले जानी हो तो [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न इंडेंट मान लागू करता है ताकि पहली‑पंक्ति इंडेंट का पैराग्राफ लेआउट पर प्रभाव दिखाया जा सके।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएँ और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफों की पहली‑पंक्ति इंडेंट](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्त‍ि शेष पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में आप यह प्रभाव [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड से बनाते हैं। पैराग्राफ बॉडी के सापेक्ष पहली पंक्ति को बाएँ ले जाने के लिए इंडेंट को नकारात्मक मान पर सेट करें।

व्यवहार में, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य पैराग्राफों में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले कैरेक्टर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफों का हैंगिंग इंडेंट](hanging_indent.png)

## **एंड पैराग्राफ रन प्रॉपर्टीज़ प्रबंधित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. स्लाइड की स्थिति के आधार पर उस स्लाइड का रेफ़रेंस प्राप्त करें जिसमें पैराग्राफ है।
1. स्लाइड में एक आयताकार [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आयताकार में दो पैराग्राफ वाले एक [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) जोड़ें।
1. पैराग्राफ के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ के End प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML टेक्स्ट को पैराग्राफ में इम्पोर्ट करें**

Aspose.Slides पैराग्राफ में HTML टेक्स्ट को इम्पोर्ट करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. `autoshape` के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और जोड़ें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएँ।
8. पढ़े गए TextReader की HTML सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेज़ेंटेशन को सहेजें।

```java
// खाली प्रेज़ेंटेशन इंस्टेंस बनाएँ
Presentation pres = new Presentation();
try {
    // प्रेज़ेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML सामग्री को समायोजित करने के लिए AutoShape जोड़ें
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // आकार में टेक्स्ट फ़्रेम जोड़ें
    ashape.addTextFrame("");

    // जोड़े गए टेक्स्ट फ़्रेम में सभी पैराग्राफ साफ़ करें
    ashape.getTextFrame().getParagraphs().clear();

    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करें
    TextReader tr = new StreamReader("file.html");

    // टेक्स्ट फ़्रेम में HTML स्ट्रीम रीडर से टेक्स्ट जोड़ें
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // प्रेज़ेंटेशन सहेजें
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ टेक्स्ट को HTML में एक्सपोर्ट करें**

Aspose.Slides पैराग्राफ में स्थित टेक्स्ट को HTML में एक्सपोर्ट करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और वांछित प्रेज़ेंटेशन लोड करें।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. HTML में एक्सपोर्ट किए जाने वाले टेक्स्ट वाले आकार तक पहुँचें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) तक पहुँचें।
5. एक `StreamWriter` का उदाहरण बनाएँ और नया HTML फ़ाइल जोड़ें।
6. `StreamWriter` को प्रारंभिक इंडेक्स प्रदान करें और अपनी पसंदीदा पैराग्राफ को एक्सपोर्ट करें।

```java
// प्रेज़ेंटेशन फ़ाइल लोड करें
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // प्रेज़ेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // इच्छित इंडेक्स
    int index = 0;

    // जोड़ा गया आकार एक्सेस कर रहे हैं
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // आउटपुट HTML फ़ाइल बना रहे हैं
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //पहले पैराग्राफ को HTML के रूप में निकाल रहे हैं
    // पैराग्राफ शुरू होने का इंडेक्स और कॉपी करने वाले कुल पैराग्राफ प्रदान कर डेटा को HTML में लिख रहे हैं
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ को इमेज़ के रूप में सहेजें**

इस अनुभाग में हम दो उदाहरणों को देखेंगे जो यह दर्शाते हैं कि कैसे [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित टेक्स्ट पैराग्राफ को इमेज़ के रूप में सहेजा जा सकता है। दोनों उदाहरण में आकार से पैराग्राफ वाला इमेज़ प्राप्त करना, पैराग्राफ की सीमाएँ गणना करना और इसे बिटमैप इमेज़ के रूप में एक्सपोर्ट करना शामिल है। ये तरीक़े आपको PowerPoint प्रेज़ेंटेशन से विशिष्ट टेक्स्ट भागों को निकालने और उन्हें अलग‑अलग इमेज़ के रूप में सहेजने की अनुमति देते हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकते हैं।

मान लेते हैं कि हमारे पास sample.pptx नाम की एक प्रेज़ेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला आकार एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ को इमेज़ के रूप में प्राप्त करते हैं। इसके लिए हम प्रस्तुति की पहली स्लाइड से आकार की इमेज़ निकालते हैं और फिर आकार के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ की सीमाएँ गणना करते हैं। पैराग्राफ को एक नए बिटमैप इमेज़ पर पुनः ड्रॉ किया जाता है और PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ को सटीक आयाम और फ़ॉर्मेटिंग के साथ अलग‑अलग इमेज़ के रूप में सहेजना हो।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // रूप को मेमोरी में बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से आकार का बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // आउटपुट छवि के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सल)।
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // पैराग्राफ बिटमैप केवल प्राप्त करने के लिए आकार बिटमैप को क्रॉप करें।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

परिणाम:

![पैराग्राफ इमेज़](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले तरीके को स्केलिंग फैक्टर जोड़कर विस्तारित करते हैं। आकार को प्रस्तुतिकरण से निकाला जाता है और `2` स्केलिंग फैक्टर के साथ इमेज़ के रूप में सहेजा जाता है। इससे पैराग्राफ को एक्सपोर्ट करने पर उच्च‑रिज़ॉल्यूशन आउटपुट मिलता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ की सीमाएँ गणना की जाती हैं। स्केलिंग तब उपयोगी होती है जब अधिक विस्तृत इमेज़ की आवश्यकता हो, जैसे उच्च‑गुणवत्ता वाले प्रिंट सामग्री में उपयोग के लिये।

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्केलिंग के साथ आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से आकार का बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // आउटपुट छवि के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सल)।
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // केवल पैराग्राफ बिटमैप प्राप्त करने के लिए आकार बिटमैप को क्रॉप करें।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) का उपयोग करके रैपिंग बंद कर सकते हैं ताकि लाइनें फ़्रेम किनारों पर नहीं टूटें।

**मैं किसी विशिष्ट पैराग्राफ की सटीक स्लाइड पर सीमा कैसे प्राप्त करूँ?**

आप पैराग्राफ (और यहाँ तक कि एकल पोर्शन) की बाउंडिंग आयत प्राप्त कर सकते हैं जिससे उसकी स्लाइड पर सटीक स्थिति और आकार ज्ञात हो जाता है।

**पैराग्राफ संरेखण (बायाँ/दायाँ/केन्द्र/जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[Alignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/) में होती है; यह पूरे पैराग्राफ पर लागू होती है चाहे व्यक्तिगत पोर्शन को कैसे भी फ़ॉर्मेट किया गया हो।

**क्या मैं केवल पैराग्राफ के भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), इसलिए एक ही पैराग्राफ में कई भाषाएँ सह-अस्तित्व में रह सकती हैं।