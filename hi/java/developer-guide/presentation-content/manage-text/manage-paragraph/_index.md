---
title: Java में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- पाठ जोड़ें
- पैराग्राफ जोड़ें
- पाठ प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात करें
- पाठ को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- पाठ को इमेज में
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और फ़ॉर्मेट करें, जानें।"
---
## **परिचय**

Aspose.Slides for Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में प्रदर्शित करता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और उसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और उसकी पोर्शन और पैराग्राफ-स्तर फ़ॉर्मेटिंग तक पहुंच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और अक्षर-स्तर फ़ॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित चरण तीन पैराग्राफ के साथ एक टेक्स्ट फ्रेम बनाते हैं, जिनमें प्रत्येक में तीन पोर्शन होते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिये पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से अक्षर-स्तर फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को सहेजें।

यह जावा उदाहरण इन चरणों को लागू करता है:

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

## **बुलेटेड और क्रमांकित सूचियाँ बनाएं**

### **बुलेटेड या क्रमांकित सूची बनाएं**

बुलेट और क्रमांकित सूची संबंधित वस्तुओं को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. इंडेक्स के द्वारा संबंधित स्लाइड तक पहुंचें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. सिंबल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) बनाएं।
6. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/) सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
7. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
8. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
9. दूसरा पैराग्राफ बनाएं और [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/) सेट करें।
10. क्रमांकित बुलेट शैली कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
11. प्रेज़ेंटेशन को सहेजें।

यह जावा उदाहरण एक सिंबल बुलेट और एक क्रमांकित बुलेट बनाता है:

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

### **चित्र बुलेट का उपयोग करें**

चित्र बुलेट आपको सिंबल या नंबर के बजाय कस्टम छवि उपयोग करने की अनुमति देते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. इंडेक्स के द्वारा संबंधित स्लाइड तक पहुंचें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें और उसके [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रेज़ेंटेशन की इमेज कलेक्शन में [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/) सेट करें।
8. इमेज को [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#getPicture--) के माध्यम से असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को सहेजें।

यह जावा उदाहरण एक चित्र बुलेट बनाता है:

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

### **बहु-स्तरीय सूची बनाएं**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setDepth-short-) मानों को क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

यह जावा उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

### **क्रमांकित सूची आइटम को कस्टम मानों से शुरू करें**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके एक क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या निर्धारित करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाएं और एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) को स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिए [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3` और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

यह जावा उदाहरण प्रत्येक पैराग्राफ को कस्टम शुरुआती संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ नियंत्रित करें**

### **पहली पंक्ति का इंडेंट सेट करें**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित किया जाता है। यह विधि केवल पहली पंक्ति को पैराग्राफ के बाएँ मार्जिन के सापेक्ष स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मानों को लागू करता है ताकि पहली पंक्ति के इंडेंट का पैराग्राफ लेआउट पर प्रभाव दिखाया जा सके।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को सहेजें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की पहली पंक्ति का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में आप इस प्रभाव को [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) के साथ बना सकते हैं। पहले पंक्ति को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति को परिभाषित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति को परिभाषित करता है। हैंगिंग इंडेंट बनाने के लिए, `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों आदि के लिए उपयोगी है, जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले कैरेक्टर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) को सकारात्मक मान पास करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) पैराग्राफ के अंत निशान के फ़ॉर्मेट को नियंत्रित करता है। निम्नलिखित उदाहरण दूसरे पैराग्राफ के अंत निशान को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत निशान के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) के साथ फ़ॉर्मेट असाइन करें और प्रेज़ेंटेशन को सहेजें।

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

## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में बदलें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुंचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
6. संशोधित प्रेज़ेंटेशन को सहेजें।

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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाएं और इच्छित प्रेज़ेंटेशन लोड करें।
2. स्लाइड तक पहुंचें और वह [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) तक पहुंचें।
4. शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

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

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[IParagraph.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getImage--) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजें। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getImage--) `null` लौटा सकता है यदि पैराग्राफ को उसके पैरेंट कलेक्शन में नहीं पाया जाता, वैध रेंडरिंग बाउंड नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास sample.pptx नामक एक प्रेज़ेंटेशन फाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्नलिखित उदाहरण दूसरे पैराग्राफ को नियमित टेक्स्ट शेप में डिफ़ॉल्ट स्केल पर रेंडर करता है और परिणामस्वरूप PNG फ़ॉर्मेट में इमेज सहेजता है। `finally` ब्लॉक सुनिश्चित करता है कि इमेज सही तरीके से डिस्पोज़ हो।

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

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में पैराग्राफ को स्केलिंग के साथ रेंडर करें**

[IParagraph.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getImage-float-float-) का वह ओवरलोड उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर स्वीकार करता है, जिससे क्षैतिज और लंबवत स्केल फैक्टर सेट होते हैं। नीचे दिया गया उदाहरण एक तालिका बनाता है, उसके पहले सेल में पैराग्राफ को दो गुना चौड़ाई और ऊँचाई पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर्स के लिए `2` उपयोग करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे पिक्सेल चार गुना होते हैं। बड़े फैक्टर्स आम तौर पर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन वे मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर्स छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फैक्टर्स का उपयोग करके पैराग्राफ का अस्पेक्ट रेशियो बना रहता है; अलग-अलग क्षैतिज और लंबवत फैक्टर्स आउटपुट को स्वतंत्र रूप से खींचते हैं।

[IShape.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getImage--) के साथ पूरी शेप को रेंडर करना उपयोगी रहता है जब आउटपुट में शेप की फिल, बॉर्डर या अन्य दृश्य कंटेक्स्ट शामिल होना आवश्यक हो। केवल पैराग्राफ‑केवल इमेज के लिए, [IParagraph.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getImage--) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**

हाँ। लाइन रैपिंग अक्षम करने के लिए [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) को सेट करें ताकि लाइनें टेक्स्ट फ्रेम के किनारों पर न टूटें।

**मैं किसी विशिष्ट पैराग्राफ के स्लाइड पर ठीक बाउंड्स कैसे प्राप्त कर सकता हूँ?**

[IParagraph.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getRect--) का उपयोग करके पैराग्राफ की बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getRect--) व्यक्तिगत पोर्शन की बाउंड्स प्रदान करता है।

**पैराग्राफ एलाइनमेंट (बाएँ, दाएँ, केंद्र या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होता है, व्यक्तिगत पोर्शन फ़ॉर्मेट से अलग।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करके आप एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट रख सकते हैं।