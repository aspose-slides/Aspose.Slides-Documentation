---
title: Java में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पैराग्राफ, भाग, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएँ और स्वरूपित करें, सीखें।"
---
## **परिचय**

Aspose.Slides for Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और भागों की पदानुक्रम में प्रस्तुत करता है:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) एक आकार में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और उसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और उसके भागों और पैराग्राफ-स्तर के फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक भाग का अपना टेक्स्ट और कैरेक्टर-स्तर का फॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ विभिन्न फोंट, रंग, आकार और अन्य फॉर्मेटिंग के साथ टेक्स्ट को कई भागों का उपयोग करके रख सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **एकाधिक भागों के साथ पैराग्राफ बनाना**

नीचे दिए गए चरण तीन पैराग्राफ़ों के साथ एक टेक्स्ट फ्रेम बनाते हैं, प्रत्येक में तीन भाग होते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. उसके अनुक्रमणिका के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ़ में तीन भाग रखने के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली भाग मौजूद है।
7. प्रत्येक भाग का टेक्स्ट सेट करें।
8. कैरेक्टर-स्तर के फॉर्मेटिंग को [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से लागू करें।
9. परिवर्तित प्रस्तुति को सहेजें।

यह Java उदाहरण इन चरणों को लागू करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **बुलेटेड और क्रमांकित सूचियां बनाना**

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकित बिंदु संबंधित वस्तुओं को आसानी से स्कैन करने में मदद करते हैं। Aspose.Slides में, सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. उसके अनुक्रमणिका के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक प्रतीक बुलेट बनाएँ के लिए एक [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) का उपयोग कर एक प्रतीक बुलेट बनाएँ।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. एक दूसरा पैराग्राफ बनाएँ और [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति सहेजें।

यह Java उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चित्र बुलेट का उपयोग करना**

चित्र बुलेट आपको प्रतीक या संख्या के बजाय एक कस्टम छवि का उपयोग करने की अनुमति देते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. उसके अनुक्रमणिका के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें और उसका [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) प्राप्त करें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट छवि लोड करें और उसे प्रस्तुति की इमेज कलेक्शन में [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) के माध्यम से छवि असाइन करें और बुलेट की ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. परिवर्तित प्रस्तुति को सहेजें।

यह Java उदाहरण चित्र बुलेट बनाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **बहु-स्तरीय सूची बनाना**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) सेट करें ताकि पैराग्राफ़ सूची के विभिन्न स्तरों पर रखें। शीर्ष स्तर की गहराई `0` है।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ़ बनाएं और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) मान को क्रमशः `0`, `1`, `2`, और `3` पर सेट करें।
5. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Java उदाहरण चार-स्तरीय बुलेटेड सूची बनाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **कस्टम मूल्यों पर क्रमांकित सूची आइटम शुरू करना**

एक क्रमांकित पैराग्राफ़ के लिए प्रारंभिक संख्या सेट करने हेतु [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएं और स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ़ों के लिए [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Java उदाहरण प्रत्येक पैराग्राफ़ को एक कस्टम प्रारंभिक संख्या असाइन करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पैराग्राफ लेआउट और अंत गुण नियंत्रण**

### **पहली पंक्ति का इंडेंट सेट करें**

एक पैराग्राफ की पहली पंक्ति के इंडेंट को नियंत्रित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करें। यह विधि केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग तब करें जब आपको पूरी पैराग्राफ को स्थानांतरित करना हो। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ़ बनाता है और विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मानों को लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ़ बनाएं और उनके लिए विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
7. परिवर्तित प्रस्तुति सहेजें।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ़ों का पहली पंक्ति इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट एक पैराग्राफ लेआउट है जिसमें पहली पंक्ति बाकी पंक्तियों के बाएँ शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) से बनाते हैं। पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएँ शिफ्ट करने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) इस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, `setMarginLeft` को सकारात्मक मान दें और `setIndent` को नकारात्मक मान दें।

यह फॉर्मेटिंग ग्रंथसूचियों, संदर्भों, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप की गई पंक्तियों को पहली पंक्ति के पहले अक्षर के बजाय पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ़ के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) को सकारात्मक मान दें।
6. [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) को नकारात्मक मान देकर हैंगिंग इंडेंट प्रभाव बनाएं।
7. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
8. परिवर्तित प्रस्तुति सहेजें।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ़ों का हैंगिंग इंडेंट](hanging_indent.png)

### **पैराग्राफ अंत रन गुण सेट करें**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) पैराग्राफ के अंत चिह्न के फॉर्मेटिंग को नियंत्रित करता है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ़ बनाएं और उनमें टेक्स्ट भाग जोड़ें।
4. दूसरे पैराग्राफ़ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) के साथ फॉर्मेट असाइन करें और प्रस्तुति सहेजें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **रेन्डर की गई लाइनों की गणना**

ऑटोमैटिक रैपिंग और लाइन समाप्तियों पर विराम चिह्न को प्रभावित करने वाले पैराग्राफ नियमों के लिए, देखें [Control Line Breaking](/slides/hi/java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/java/text-formatting/#control-hanging-punctuation)।

[IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा घेरें गए लाइनों, जिसमें ऑटोमैटिक रैपिंग शामिल है, की गिनती करें। यह प्रस्तुति टेम्पलेट में टेक्स्ट लंबाई और लेआउट जांचते समय उपयोगी है।

एक पैराग्राफ [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) में एक वस्तु है, और वह कई रेन्डर की गई लाइनों को घेर सकता है। एक स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर एक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। ऑटोमैटिक रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है बिना टेक्स्ट में स्पष्ट लाइन ब्रेक डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेन्डर की गई लाइन गिनती नहीं देता।

निम्न उदाहरण एक टेक्स्ट आकार बनाता है, उसकी लाइनों की गिनती करता है, आकार को संकरा करता है, और फिर टेक्स्ट को छोटी स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि आकार की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से घटाए या आकार का आकार बदले। आकार के आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में कुल लाइन गिनती का योग करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

इस टेक्स्ट और इन आयामों के साथ, आकार को संकरा करने से लाइन गिनती बढ़ती है, जबकि टेक्स्ट को छोटी स्ट्रिंग से बदलने से यह घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता और प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग, और ऑटोफ़िट सेटिंग्स पर निर्भर हो सकती है। टेम्प्लेट जांचते समय लक्षित पर्यावरण के लिए निर्धारित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाइयाँ, पैराग्राफ और लाइन स्पेसिंग, और ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; रैपिंग अक्षम होने पर एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और भागों में बदलें।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और इच्छित प्रस्तुति लोड करें।
2. एक स्लाइड तक पहुँचें और एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) जोड़ें।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
6. परिवर्तित प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके पैराग्राफ की चयनित रेंज को HTML के रूप में निर्यात करें।

1. एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और इच्छित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट हो।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) तक पहुँचें।
4. निर्दिष्ट पैराग्राफ़ इंडेक्स और निर्यात करने वाले पैराग्राफ़ों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) कॉल करें।
5. वापसी में मिला HTML स्ट्रिंग फ़ाइल में लिखें।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ को इमेज के रूप में रेंडर करना**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) सीधे एक व्यक्तिगत पैराग्राफ को रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ फ़ाइल या स्ट्रीम में सहेजें। आपको संलग्न आकार को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) `null` लौट सकता है यदि पैराग्राफ नहीं मिला, वैध रेंडरिंग बाउंड नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लीजिए हमारे पास sample.pptx नामक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला आकार तीन पैराग्राफ़ों वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ़ों वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को एक सामान्य टेक्स्ट आकार में डिफ़ॉल्ट स्केल पर रेंडर करता है और लौटाए गए इमेज को PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक इमेज को सही ढंग से डिस्पोज़ करने को सुनिश्चित करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड जिसका `float scaleX` और `float scaleY` पैरामीटर हैं, का उपयोग करके क्षैतिज और लंबवत स्केल फैक्टर सेट करें। निम्न उदाहरण एक टेबल बनाता है, उसके पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` का स्केल फैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर के लिए `2` एक इमेज बनाता है जिसकी चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आकार से दो गुना होती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर आमतौर पर ज़ूम या उच्च-रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर का उपयोग करके पैराग्राफ का आस्पेक्ट रेशियो संरक्षित रखें; विभिन्न क्षैतिज और लंबवत फ़ैक्टर आउटपुट को अलग‑अलग खींचते हैं।

[IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) के साथ पूरे आकार को रेंडर करना तब भी उपयोगी है जब आउटपुट में आकार की भराव, बॉर्डर या अन्य दृश्य संदर्भ शामिल हों। केवल पैराग्राफ इमेज के लिए, [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूं?**

हाँ। लाइन रैपिंग को अक्षम करने के लिए [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) सेट करें ताकि लाइनों का टेक्स्ट फ्रेम के किनारों पर टूटना न हो।

**मैं किसी विशेष पैराग्राफ के स्लाइड पर सटीक बाउंड्स कैसे प्राप्त कर सकता हूँ?**

[IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) एक व्यक्तिगत भाग की बाउंड्स प्रदान करता है।

**पैराग्राफ संरेखण (बायाँ, दायाँ, केंद्र, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) एक पैराग्राफ-स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत भागों का फॉर्मेटिंग जो भी हो।

विभिन्न फ़ॉन्ट आकारों वाले भागों को प्रत्येक लाइन में लंबवत संरेखित करने के लिए, देखें [Align Fonts Within a Line](/slides/hi/java/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के किसी भाग के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत भागों के लिए [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।