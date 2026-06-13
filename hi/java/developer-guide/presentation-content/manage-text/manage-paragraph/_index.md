---
title: Java में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/java/manage-paragraph/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- नंबरेड सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ निर्यात
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पैराग्राफ फ़ॉर्मेटिंग में महारत हासिल करें—Java में PPT, PPTX और ODP प्रेजेंटेशन में संरेखण, स्पेसिंग और शैली को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides वह सभी इंटरफ़ेस और क्लास प्रदान करता है जिनकी आपको Java में PowerPoint टेक्स्ट, पैराग्राफ और पोर्शन के साथ काम करने के लिए आवश्यकता है।

* Aspose.Slides द्वारा प्रदान किया गया [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) इंटरफ़ेस आपको पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की सुविधा देता है। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा निर्मित होता है)।
* Aspose.Slides द्वारा प्रदान किया गया [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) इंटरफ़ेस आपको पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की सुविधा देता है। एक `IParagraph` ऑब्जेक्ट में एक या कई पोर्शन हो सकते हैं (iPortions ऑब्जेक्ट का संग्रह)।
* Aspose.Slides द्वारा प्रदान किया गया [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) इंटरफ़ेस आपको टेक्स्ट और उनके फ़ॉर्मेटिंग गुणों का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की सुविधा देता है।

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग गुणों वाले टेक्स्ट को संभाल सकता है।

## **एकाधिक पोर्शन वाले कई पैराग्राफ जोड़ें**

इन चरणों में दिखाया गया है कि कैसे 3 पैराग्राफ और प्रत्येक पैराग्राफ में 3 पोर्शन वाला एक टेक्स्ट फ़्रेम जोड़ें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. स्लाइड में एक Rectangle [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. उस [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) से जुड़ा ITextFrame प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) ऑब्जेक्ट बनाएं और उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) की `IParagraphs` कलेक्शन में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट पैराग्राफ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` ऑब्जेक्ट को प्रत्येक `IParagraph` की IPortion कलेक्शन में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `IPortion` ऑब्जेक्ट द्वारा उजागर फ़ॉर्मेटिंग गुणों का उपयोग करके प्रत्येक पोर्शन पर अपनी पसंदीदा फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन सेव करें।

यह Java कोड पैराग्राफ़ में पोर्शन जोड़ने के चरणों का कार्यान्वयन है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
Presentation pres = new Presentation();
try {
    // पहले स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape का TextFrame पहुँचें
    ITextFrame tf = ashp.getTextFrame();

    // विभिन्न टेक्स्ट फ़ॉर्मेट वाले Paragraphs और Portions बनाएं
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //PPTX को डिस्क पर लिखें
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ बुलेट्स प्रबंधित करें**

बुलेट सूचियां आपको जानकारी को तेज़ी और कुशलता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. चयनित स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) को एक्सेस करें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. पैराग्राफ के लिए बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर निर्धारित करें।
8. पैराग्राफ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
10. बुलेट का रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नए पैराग्राफ को `TextFrame` पैराग्राफ कलेक्शन में जोड़ें।
13. दूसरा पैराग्राफ जोड़ें और चरण 7 से 13 तक की प्रक्रिया दोहराएँ।
14. प्रेजेंटेशन को सेव करें।

यह Java कोड आपको बुलेट पैराग्राफ जोड़ने का तरीका दर्शाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाता है
Presentation pres = new Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame txtFrm = aShp.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ हटाता है
    txtFrm.getParagraphs().removeAt(0);

    // एक पैराग्राफ बनाता है
    Paragraph para = new Paragraph();

    // पैराग्राफ बुलेट शैली और चिह्न सेट करता है
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // पैराग्राफ टेक्स्ट सेट करता है
    para.setText("Welcome to Aspose.Slides");

    // बुलेट इंडेंट सेट करता है
    para.getParagraphFormat().setIndent(25);

    // बुलेट रंग सेट करता है
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग हो सके

    // बुलेट ऊँचाई सेट करता है
    para.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
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
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग हो सके

    // बुलेट ऊँचाई सेट करता है
    para2.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para2);
    
    // संशोधित प्रेजेंटेशन को सेव करता है
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र बुलेट्स प्रबंधित करें**

बुलेट सूचियां आपको जानकारी को तेज़ी और कुशलता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) को एक्सेस करें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) में इमेज लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) सेट करें और इमेज निर्धारित करें।
9. पैराग्राफ `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट का रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ को `TextFrame` पैराग्राफ कलेक्शन में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड आपको चित्र बुलेट जोड़ने और प्रबंधित करने का तरीका दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाता है
Presentation presentation = new Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    ISlide slide = presentation.getSlides().get_Item(0);

    // बुलेट्स के लिए इमेज बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // autoshape के टेक्स्टफ़्रेम को एक्सेस करता है
    ITextFrame textFrame = autoShape.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ हटाता है
    textFrame.getParagraphs().removeAt(0);

    // एक नया पैराग्राफ बनाता है
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // पैराग्राफ बुलेट शैली और इमेज सेट करता है
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // बुलेट की ऊँचाई सेट करता है
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    textFrame.getParagraphs().add(paragraph);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // प्रेजेंटेशन को PPT फ़ाइल के रूप में लिखता है
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **बहु-स्तरीय बुलेट्स प्रबंधित करें**

बुलेट सूचियां आपको जानकारी को तेज़ी और कुशलता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहु-स्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. नई स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) को एक्सेस करें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं और गहराई को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ इंस्टेंस बनाएं और गहराई को 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ इंस्टेंस बनाएं और गहराई को 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ इंस्टेंस बनाएं और गहराई को 3 सेट करें।
10. नए पैराग्राफ को `TextFrame` पैराग्राफ कलेक्शन में जोड़ें।
11. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड आपको बहु-स्तरीय बुलेट्स जोड़ने और प्रबंधित करने का तरीका दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाता है
Presentation pres = new Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाई गई autoshape का टेक्स्ट फ्रेम एक्सेस करता है
    ITextFrame text = aShp.addTextFrame("");

    // डिफ़ॉल्ट पैराग्राफ हटाता है
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

    // पैराग्राफ को कलेक्शन में जोड़ता है
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

## **कस्टम नंबरड लिस्ट के साथ पैराग्राफ प्रबंधित करें**

[IBulletFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) प्रॉपर्टी और अन्य सुविधाएं प्रदान करता है जिससे आप कस्टम नंबरिंग या फ़ॉर्मेटिंग के साथ पैराग्राफ को प्रबंधित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. पैराग्राफ युक्त स्लाइड को एक्सेस करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) को एक्सेस करें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को 2 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नए पैराग्राफ को `TextFrame` पैराग्राफ कलेक्शन में जोड़ें।
10. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड आपको कस्टम नंबरिंग या फ़ॉर्मेटिंग के साथ पैराग्राफ जोड़ने और प्रबंधित करने का तरीका दर्शाता है:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाई गई autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame textFrame = shape.getTextFrame();

    // डिफ़ॉल्ट मौजूदा पैराग्राफ हटाता है
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

## **पैराग्राफ के लिए प्रथम-लाइन इंडेंट सेट करें**

पहले लाइन के इंडेंट को नियंत्रित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड का उपयोग करें। यह मेथड केवल पैराग्राफ के बाएं मार्जिन के सापेक्ष पहली लाइन को ही स्थानांतरित करता है। सकारात्मक मान पहली लाइन को दाईं ओर शिफ्ट करता है, जबकि शेष लाइनों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

पूरे पैराग्राफ को स्थानांतरित करने के लिए आप [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग कर सकते हैं। केवल पहली लाइन को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न इंडेंट मान लागू करता है ताकि यह दिखाया जा सके कि प्रथम-लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड को एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सेव करें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ़ों की प्रथम-लाइन इंडेंट](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों के बाईं ओर शुरू होती है। Aspose.Slides में आप इसे [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड से बना सकते हैं। इंडेंट को नकारात्मक मान पर सेट करने से पहली लाइन पैराग्राफ बॉडी के सापेक्ष बाईं ओर शिफ्ट होती है।

व्यवहार में, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाईं स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, `MarginLeft` को सकारात्मक मान और `Indent` को नकारात्मक मान सेट करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप की गई लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना आवश्यक होता है, न कि पहली लाइन के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड को एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. प्रत्येक पैराग्राफ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए एक नकारात्मक [Indent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सेव करें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ़ों की हैंगिंग इंडेंट](hanging_indent.png)

## **एंड पैराग्राफ रन प्रॉपर्टीज़ प्रबंधित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. पैराग्राफ युक्त स्लाइड का रेफ़रेंस उसकी स्थिति के माध्यम से प्राप्त करें।
1. स्लाइड में एक आयताकार [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आयत में दो पैराग्राफ वाला एक [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) जोड़ें।
1. पैराग्राफ के लिए `FontHeight` और फ़ॉन्ट टाइप सेट करें।
1. पैराग्राफ के लिए End प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको PowerPoint में पैराग्राफ के End प्रॉपर्टीज़ सेट करने का तरीका दिखाता है:

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

## **HTML टेक्स्ट को पैराग्राफ में आयात करें**

Aspose.Slides HTML टेक्स्ट को पैराग्राफ में आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. `autoshape` का [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) जोड़ें और एक्सेस करें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं।
8. पढ़े गए TextReader की सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड पैराग्राफ में HTML टेक्स्ट आयात करने के चरणों का कार्यान्वयन है:

```java
// खाली प्रेजेंटेशन इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML सामग्री को समायोजित करने के लिए AutoShape जोड़ें
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // शेप में टेक्स्ट फ्रेम जोड़ें
    ashape.addTextFrame("");

    // जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ साफ़ करें
    ashape.getTextFrame().getParagraphs().clear();

    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करें
    TextReader tr = new StreamReader("file.html");

    // टेक्स्ट फ्रेम में HTML स्ट्रीम रीडर से टेक्स्ट जोड़ें
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // प्रेजेंटेशन सेव करें
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं और इच्छित प्रेजेंटेशन लोड करें।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस एक्सेस करें।
3. वह शेप एक्सेस करें जिसमें वह टेक्स्ट है जिसे HTML में निर्यात किया जाएगा।
4. शेप का [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) एक्सेस करें।
5. `StreamWriter` की एक इंस्टेंस बनाएं और नया HTML फ़ाइल जोड़ें।
6. StreamWriter को एक प्रारंभिक इंडेक्स प्रदान करें और अपनी पसंदीदा पैराग्राफ निर्यात करें।

यह Java कोड आपको PowerPoint पैराग्राफ टेक्स्ट को HTML में निर्यात करने का तरीका दर्शाता है:

```java
// प्रेजेंटेशन फ़ाइल लोड करें
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // इच्छित इंडेक्स
    int index = 0;

    // जोड़ा गया शेप एक्सेस करना
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // आउटपुट HTML फ़ाइल बनाना
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //पहले पैराग्राफ को HTML के रूप में निकालना
    // पैराग्राफ शुरू होने वाले इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ प्रदान करके पैराग्राफ डेटा को HTML में लिख रहा है
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ को इमेज के रूप में सेव करें**

इस अनुभाग में हम दो उदाहरणों को देखेंगे जो दिखाते हैं कि कैसे [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ को इमेज के रूप में सेव किया जा सकता है। दोनों उदाहरणों में शेप से इमेज प्राप्त करने, पैराग्राफ की बाउंड्स निकालने और उसे बिटमैप इमेज के रूप में एक्सपोर्ट करने की प्रक्रिया शामिल है। ये तरीके आपको PowerPoint प्रेजेंटेशन से विशिष्ट टेक्स्ट भाग निकालने और उन्हें अलग‑अलग इमेज के रूप में सेव करने की सुविधा देते हैं।

मान लीजिए हमारे पास `sample.pptx` नामक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, और पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ को इमेज के रूप में प्राप्त करते हैं। इसके लिए हम पहले स्लाइड की शेप की इमेज निकालते हैं, फिर शेप के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ की बाउंड्स गणना करते हैं और उसे नए बिटमैप इमेज पर ड्रॉ करके PNG फॉर्मेट में सेव करते हैं। यह विधि तब उपयोगी होती है जब आपको एक विशिष्ट पैराग्राफ को सटीक आकार और फ़ॉर्मेटिंग के साथ अलग इमेज के रूप में बचाना हो।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // शेप को मेमोरी में एक बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से एक शेप बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // आउटपुट इमेज के लिए कॉर्डिनेट्स और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // पैराग्राफ बिटमैप केवल प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले दृष्टिकोण को स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। शेप को `2` के स्केल फ़ैक्टर के साथ इमेज के रूप में एक्सट्रैक्ट किया जाता है, जिससे उच्च रिज़ॉल्यूशन आउटपुट मिलता है। पैराग्राफ बाउंड्स को स्केल को ध्यान में रखकर गणना किया जाता है। स्केलिंग तब उपयोगी होती है जब आपको अधिक विस्तृत इमेज चाहिए, जैसे कि हाई‑क्वालिटी प्रिंट सामग्री में उपयोग के लिए।

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्केलिंग के साथ शेप को मेमोरी में एक बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से एक शेप बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // आउटपुट इमेज के लिए कॉर्डिनेट्स और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // केवल पैराग्राफ बिटमैप प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) का उपयोग करके रैपिंग को बंद करें ताकि लाइनें फ्रेम के किनारों पर टूटें नहीं।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

आप पैराग्राफ (और यहां तक कि एकल पोर्शन) के बाउंडिंग रेक्टेंगल को प्राप्त कर सकते हैं ताकि उसकी सटीक स्थिति और आकार पता चल सके।

**पैराग्राफ संरेखण (बाएँ/दाएँ/केंद्रीकृत/जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[Alignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphformat/) में मौजूद है; यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के केवल एक भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन‑स्तर पर सेट की जाती है ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), इसलिए एक ही पैराग्राफ में कई भाषाएँ coexist कर सकती हैं।