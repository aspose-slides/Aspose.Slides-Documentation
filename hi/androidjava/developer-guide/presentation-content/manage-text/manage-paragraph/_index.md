---
title: Android पर PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/androidjava/manage-paragraph/
keywords:
- पाठ जोड़ें
- पैराग्राफ़ जोड़ें
- पाठ प्रबंधित करें
- पैराग्राफ़ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात करें
- पाठ को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को इमेज में
- पाठ को इमेज में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ पैराग्राफ़ फ़ॉर्मेटिंग में महारत हासिल करें—Java में PPT, PPTX और ODP प्रेजेंटेशन में संरेखण, अंतराल और शैली को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides जावा में PowerPoint पाठ, पैराग्राफ और भागों के साथ काम करने के लिए आवश्यक सभी इंटरफ़ेस और क्लासेज़ प्रदान करता है।

* Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस प्रदान करता है जिससे आप पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा बनाया जाता है)।
* Aspose.Slides [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) इंटरफ़ेस प्रदान करता है जिससे आप भागों का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `IParagraph` ऑब्जेक्ट में एक या कई भाग (iPortions ऑब्जेक्ट की संग्रह) हो सकते हैं।
* Aspose.Slides [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) इंटरफ़ेस प्रदान करता है जिससे आप पाठ और उनके स्वरूपण गुणों का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं।

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न स्वरूपण गुणों वाले पाठ को संभालने में सक्षम है।

## **एकाधिक पैराग्राफ़ों में कई टेक्स्ट पोर्शन जोड़ें**

इन चरणों में दिखाया गया है कि 3 पैराग्राफ़ और प्रत्येक पैराग्राफ़ में 3 पोर्शन वाले टेक्स्ट फ्रेम को कैसे जोड़ें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. उस [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) से जुड़ा ITextFrame प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) ऑब्जेक्ट बनाएं और उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) की `IParagraphs` संग्रह में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट पैराग्राफ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` ऑब्जेक्ट को प्रत्येक `IParagraph` के IPortion संग्रह में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `IPortion` ऑब्जेक्ट द्वारा उजागर किए गए स्वरूपण गुणों का उपयोग करके प्रत्येक पोर्शन पर अपने पसंदीदा स्वरूपण फ़ीचर लागू करें।
9. संशोधित प्रेजेंटेशन सहेजें।

यह जावा कोड पैराग्राफ़ों में पोर्शन जोड़ने के चरणों का कार्यान्वयन है:

```java
// एक Presentation क्लास का इंस्टेंस बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँच रहा है
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape का TextFrame एक्सेस करें
    ITextFrame tf = ashp.getTextFrame();

    // विभिन्न टेक्स्ट फ़ॉर्मेट के साथ Paragraphs और Portions बनाएं
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

    // PPTX को डिस्क पर लिखें
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ बुलेट प्रबंधित करें**

बुलेट सूचियां जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ़ पढ़ने और समझने में हमेशा आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape की [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. पैराग्राफ के बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर सेट करें।
8. पैराग्राफ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
10. बुलेट के लिए एक रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नई पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
13. दूसरा पैराग्राफ जोड़ें और चरण 7 से 13 तक की प्रक्रिया दोहराएँ।
14. प्रेजेंटेशन सहेजें।

यह जावा कोड आपको बुलेट पैराग्राफ़ कैसे जोड़ें दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame txtFrm = aShp.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    txtFrm.getParagraphs().removeAt(0);

    // एक पैराग्राफ बनाता है
    Paragraph para = new Paragraph();

    // पैराग्राफ बुलेट शैली और प्रतीक सेट करता है
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // पैराग्राफ का टेक्स्ट सेट करता है
    para.setText("Welcome to Aspose.Slides");

    // बुलेट इंडेंट सेट करता है
    para.getParagraphFormat().setIndent(25);

    // बुलेट रंग सेट करता है
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग कर सकें

    // बुलेट ऊँचाई सेट करता है
    para.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para);

    // दूसरा पैराग्राफ बनाता है
    Paragraph para2 = new Paragraph();

    // पैराग्राफ बुलेट प्रकार और शैली सेट करता है
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // पैराग्राफ का टेक्स्ट जोड़ता है
    para2.setText("This is numbered bullet");

    // बुलेट इंडेंट सेट करता है
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग कर सकें

    // बुलेट ऊँचाई सेट करता है
    para2.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.getParagraphs().add(para2);
    
    // संशोधित प्रेजेंटेशन सहेजता है
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चित्र बुलेट प्रबंधित करें**

बुलेट सूचियां जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ़ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape की [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) में इमेज लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) पर सेट करें और इमेज सेट करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट के लिए एक रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नई पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन सहेजें।

यह जावा कोड आपको चित्र बुलेट कैसे जोड़ें और प्रबंधित करें दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = presentation.getSlides().get_Item(0);

    // बुलेट्स के लिए इमेज इंस्टैंसिएट करता है
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // autoshape का टेक्स्टफ़्रेम एक्सेस करता है
    ITextFrame textFrame = autoShape.getTextFrame();

    // डिफ़ॉल्ट पैराग्राफ़ को हटाता है
    textFrame.getParagraphs().removeAt(0);

    // एक नया पैराग्राफ़ बनाता है
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // पैराग्राफ़ बुलेट शैली और इमेज सेट करता है
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // बुलेट ऊँचाई सेट करता है
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
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

## **बहु-स्तरीय बुलेट प्रबंधित करें**

बुलेट सूचियां जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहु-स्तरीय बुलेट पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. नई स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape की [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं और गहराई को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ इंस्टेंस बनाएं और गहराई को 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ इंस्टेंस बनाएं और गहराई को 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ इंस्टेंस बनाएं और गहराई को 3 सेट करें।
10. नई पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेजेंटेशन सहेजें।

यह जावा कोड आपको बहु-स्तरीय बुलेट कैसे जोड़ें और प्रबंधित करें दिखाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape जोड़ता और एक्सेस करता है
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame text = aShp.addTextFrame("");

    // डिफ़ॉल्ट पैराग्राफ़ को साफ़ करता है
    text.getParagraphs().clear();

    // पहला पैराग्राफ़ जोड़ता है
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para1.getParagraphFormat().setDepth((short)0);

    // दूसरा पैराग्राफ़ जोड़ता है
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para2.getParagraphFormat().setDepth((short)1);

    // तीसरा पैराग्राफ़ जोड़ता है
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para3.getParagraphFormat().setDepth((short)2);

    // चौथा पैराग्राफ़ जोड़ता है
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // बुलेट स्तर सेट करता है
    para4.getParagraphFormat().setDepth((short)3);

    // पैराग्राफ़ों को संग्रह में जोड़ता है
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

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ प्रबंधित करें**

[IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) प्रॉपर्टी और अन्य प्रदान करता है जिससे आप कस्टम क्रमांक या स्वरूपण के साथ पैराग्राफ़ों को प्रबंधित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. पैराग्राफ़ वाले स्लाइड तक पहुँचें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को 2 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ इंस्टेंस बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ इंस्टेंस बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नई पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेजेंटेशन सहेजें।

यह जावा कोड आपको कस्टम क्रमांकित या स्वरूपित पैराग्राफ़ कैसे जोड़ें और प्रबंधित करें दिखाता है:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए autoshape के टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame textFrame = shape.getTextFrame();

    // डिफ़ॉल्ट मौज़ूद पैराग्राफ़ को हटाता है
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

## **पैराग्राफ के लिए प्रथम-रेखा इंडेंट सेट करें**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड का उपयोग करके पैराग्राफ की प्रथम-रेखा इंडेंट को नियंत्रित करें। यह मेथड केवल पैराग्राफ की बायीं मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करता है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने की आवश्यकता होने पर [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न इंडेंट मान लागू करता है जिससे प्रथम-रेखा इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है प्रदर्शित हो।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ इंडेंट कैसे सेट करें दिखाता है:

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

![पैराग्राफ़ों की प्रथम-रेखा इंडेंट](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों के बाएँ शुरू होती है। Aspose.Slides में आप इस प्रभाव को [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड से बनाते हैं। इंडेंट को नकारात्मक मान सेट करके पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएँ ले जाते हैं।

व्यवहार में, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बायीँ स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए एक सकारात्मक `MarginLeft` मान और एक नकारात्मक `Indent` मान सेट करें।

यह स्वरूपण बिब्लियोग्राफी, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ लपेटी गई पंक्तियों को पैराग्राफ बॉडी के अंतर्गत संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए एक नकारात्मक [Indent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट करें दिखाता है:

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

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसकी स्थिति के माध्यम से पैराग्राफ़ वाले स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक आयताकार [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आयत में दो पैराग्राफ़ों के साथ एक [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) जोड़ें।
1. पैराग्राफ़ों के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ़ों के लिए End प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह जावा कोड आपको PowerPoint में पैराग्राफ़ों के लिए End प्रॉपर्टीज़ कैसे सेट करें दिखाता है:

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

## **HTML टेक्स्ट को पैराग्राफ़ों में आयात करें**

Aspose.Slides पैराग्राफ़ों में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. `autoshape` का [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) जोड़ें और पहुंचें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएं।
8. पढ़े गए TextReader की HTML फ़ाइल सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन सहेजें।

यह जावा कोड पैराग्राफ़ों में HTML टेक्स्ट आयात करने के चरणों का कार्यान्वयन है:

```java
// खाली प्रेजेंटेशन इंस्टेंस बनाएँ
Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML सामग्री को समायोजित करने के लिए AutoShape जोड़ रहे हैं
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // शेप में टेक्स्ट फ्रेम जोड़ें
    ashape.addTextFrame("");

    // जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ़ साफ़ करें
    ashape.getTextFrame().getParagraphs().clear();

    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करें
    TextReader tr = new StreamReader("file.html");

    // टेक्स्ट फ्रेम में HTML स्ट्रीम रीडर से टेक्स्ट जोड़ें
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // प्रेजेंटेशन सहेजें
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ़ों में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और इच्छित प्रेजेंटेशन लोड करें।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. HTML में निर्यात किए जाने वाले टेक्स्ट वाले शेप तक पहुँचें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) तक पहुँचें।
5. एक `StreamWriter` इंस्टेंस बनाएं और नई HTML फ़ाइल जोड़ें।
6. StreamWriter को एक प्रारंभिक इंडेक्स प्रदान करें और अपने पसंदीदा पैराग्राफ़ निर्यात करें।

यह जावा कोड आपको PowerPoint पैराग्राफ़ टेक्स्ट को HTML में निर्यात कैसे करें दिखाता है:

```java
// प्रस्तुति फ़ाइल लोड करें
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // प्रस्तुति की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // इच्छित इंडेक्स
    int index = 0;

    // जोड़ी गई शेप तक पहुँच रहे हैं
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // आउटपुट HTML फ़ाइल बना रहे हैं
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //पहला पैराग्राफ़ HTML के रूप में निकाल रहे हैं
    // पैराग्राफ़ डेटा को HTML में लिख रहे हैं, पैराग्राफ़ शुरूआती इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ़ प्रदान करके
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **पैराग्राफ को इमेज के रूप में सहेजें**

इस अनुभाग में, हम दो उदाहरणों की जाँच करेंगे जो दिखाते हैं कि [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ़ को इमेज के रूप में कैसे सहेजा जाए। दोनों उदाहरणों में शेप की इमेज प्राप्त करना शामिल है जिसमें पैराग्राफ़ शामिल है, `getImage` मेथड्स का उपयोग करके [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस से, पैराग्राफ़ के बाउंड्स की गणना करना, और उसे बिटमैप इमेज के रूप में निर्यात करना शामिल है। ये दृष्टिकोण आपको PowerPoint प्रेजेंटेशनों से टेक्स्ट के विशिष्ट भागों को निकालने और अलग-अलग इमेज के रूप में सहेजने की सुविधा देते हैं, जो विभिन्न परिस्थितियों में उपयोगी हो सकते हैं।

मान लें कि हमारे पास sample.pptx नाम की एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![तीन पैराग्राफ़ों के साथ टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरा पैराग्राफ़ इमेज के रूप में प्राप्त करते हैं। ऐसा करने के लिए, हम प्रेजेंटेशन की पहली स्लाइड से शेप की इमेज निकालते हैं और फिर शेप के टेक्स्ट फ्रेम में दूसरे पैराग्राफ़ के बाउंड्स की गणना करते हैं। पैराग्राफ़ को फिर नई बिटमैप इमेज पर पुनःरेखित किया जाता है, जिसे PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको किसी विशिष्ट पैराग्राफ़ को अलग इमेज के रूप में सहेजना हो और उसके आकार और स्वरूपण को सटीक रूप से संरक्षित रखना हो।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // आकृति को मेमोरी में एक बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से एक आकृति बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // आउटपुट इमेज के लिए कॉर्डिनेट्स और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // आकृति बिटमैप को काटें ताकि केवल पैराग्राफ़ बिटमैप प्राप्त हो।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

परिणाम:

![पैराग्राफ़ इमेज](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले दृष्टिकोण का विस्तार करते हैं और पैराग्राफ़ इमेज में स्केलिंग फैक्टर जोड़ते हैं। शेप को प्रेजेंटेशन से निकाला जाता है और `2` स्केलिंग फैक्टर के साथ इमेज के रूप में सहेजा जाता है। यह पैराग्राफ़ निर्यात करते समय उच्च रेज़ॉल्यूशन आउटपुट की अनुमति देता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ़ बाउंड्स की गणना की जाती है। स्केलिंग तब उपयोगी होती है जब अधिक विस्तृत इमेज की आवश्यकता होती है, उदाहरण के लिए उच्च‑गुणवत्ता वाली प्रिंटेड सामग्रियों में।

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // स्केलिंग के साथ आकृति को मेमोरी में बिटमैप के रूप में सहेजें।
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // मेमोरी से आकृति बिटमैप बनाएं।
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // आउटपुट इमेज के लिए कॉर्डिनेट्स और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // आकृति बिटमैप को काटें ताकि केवल पैराग्राफ़ बिटमैप प्राप्त हो।
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से बंद कर सकता हूँ?**

हाँ। लाइन रैपिंग को बंद करने के लिए टेक्स्ट फ्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) का उपयोग करें ताकि लाइनों को फ्रेम के किनारों पर नहीं तोड़ा जाए।

**मैं किसी विशिष्ट पैराग्राफ़ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त कर सकता हूँ?**

आप पैराग्राफ़ (और यहाँ तक कि एकल पोर्शन) का बाउंडिंग रेक्टेंगल निकाल सकते हैं जिससे आप स्लाइड पर उसकी सटीक स्थिति और आकार जान सकें।

**पैराग्राफ़ संरेखण (बायाँ/दायाँ/केंद्रीय/जस्टिफाई) कहाँ नियंत्रित होता है?**

[Alignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) एक पैराग्राफ‑लेवल सेटिंग है [ParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/) में; यह पूरे पैराग्राफ़ पर लागू होती है चाहे व्यक्तिगत पोर्शन का स्वरूपण कुछ भी हो।

**क्या मैं पैराग्राफ़ के केवल एक भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), इसलिए एक पैराग्राफ़ में कई भाषाएँ मौजूद हो सकती हैं।