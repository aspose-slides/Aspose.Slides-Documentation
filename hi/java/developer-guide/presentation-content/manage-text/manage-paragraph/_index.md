---
title: Java में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ़ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ़ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलेट
- नंबरड सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पैराग्राफ़, पोर्शन, बुलेट, नंबरड सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ़ इमेज बनाना व फ़ॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) टेक्स्ट कंटेनर को एक आकार में दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन व पैराग्राफ‑स्तर के फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट एवं कैरेक्टर‑स्तर फ़ॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को शामिल कर सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

एक आकार के टेक्स्ट फ्रेम में पैराग्राफ बनाइए और व्यक्तिगत टेक्स्ट रन को स्वरूपित करने के लिए पोर्शन का उपयोग करें। यह अनुभाग दिखाता है कि प्रत्येक पैराग्राफ में कई पोर्शन को कैसे जोड़ा जाए तथा विभिन्न रंग, फ़ॉन्ट आकार और स्टाइल कैसे लागू किए जाएँ।

### **कई भागों के साथ पैराग्राफ बनाना**

निम्न Java उदाहरण तीन पैराग्राफ बनाता है, प्रत्येक में तीन टेक्स्ट रन होते हैं जो [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) संग्रह से प्राप्त होते हैं। यह डिफ़ॉल्ट पैराग्राफ और उसके खाली पोर्शन को पुन: उपयोग करता है, फिर शेष पैराग्राफ और पोर्शन जोड़ता है। फ़ॉर्मेटिंग [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ का पहला पोर्शन लाल, बोल्ड और 15 पॉइंट है; दूसरा नीला, इटैलिक और 18 पॉइंट है। तीसरा पोर्शन अपनी डिफ़ॉल्ट फ़ॉर्मेटिंग बरकरार रखता है:

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

## **बुलेटेड और नंबरड सूचियाँ बनाना**

पैराग्राफ टेक्स्ट को प्रतीक, संख्या या कस्टम इमेज के साथ सूचियों में व्यवस्थित करें। इस अनुभाग के उदाहरण बुलेट फ़ॉर्मेटिंग, मल्टी‑लेवल सूचियों और कस्टम प्रारंभिक संख्या को कवर करते हैं।

### **बुलेटेड या नंबरड सूची बनाना**

बुलेट और क्रमांकित आइटम संबंधित बिंदुओं को आसानी से स्कैन करने में मदद करते हैं। Aspose.Slides में सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

यह Java उदाहरण एक ही टेक्स्ट फ्रेम में एक प्रतीक बुलेट और एक नंबरड आइटम जोड़ता है। [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) बुलेट प्रकार चुनता है, जबकि [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) प्रतीक प्रदान करता है और [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) क्रमांक शैली चुनता है। दोनों आइटम काले बुलेट के साथ 100 % ऊँचाई और पैराग्राफ इंडेंट 25 पॉइंट के साथ हैं:

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

चित्र बुलेट आपको प्रतीक या संख्या के बजाय कस्टम इमेज इस्तेमाल करने की अनुमति देता है।

यह Java उदाहरण एक इमेज को प्रस्तुति की इमेज कलेक्शन में [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) के रूप में जोड़ता है और उसे पैराग्राफ बुलेट के रूप में उपयोग करता है। यह [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) को चित्र बुलेट के रूप में सेट करता है और इमेज को [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) के द्वारा निर्धारित करता है। [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) को 100 % पर सेट किया जाता है ताकि बुलेट का आकार पैराग्राफ टेक्स्ट के अनुपात में रहे:

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

### **मल्टी‑लेवल सूची बनाना**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहराई `0` है।

यह Java उदाहरण चार पैराग्राफ को 0 से 3 तक की गहराई मूल्य [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) से असाइन करता है, जिससे एक ही टेक्स्ट फ्रेम में पदानुक्रम बनता है। प्रत्येक पैराग्राफ एक प्रतीक बुलेट का उपयोग करता है, जहाँ [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) गोल बुलेट और हाइफ़न के बीच बदलता रहता है ताकि निकटवर्ती स्तरों को अलग किया जा सके:

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

### **कस्टम मानों से नंबरड सूची शुरू करना**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके नंबरड पैराग्राफ के प्रारंभिक संख्या को सेट किया जा सकता है।

यह Java उदाहरण तीन पैराग्राफ के लिए [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) को नंबरिंग के लिए सेट करता है और क्रमशः 2, 3 और 7 के मानों के साथ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) असाइन करता है। प्रारंभिक मान प्रत्येक पैराग्राफ के लिए अलग‑अलग कॉन्फ़िगर किया गया है, जिससे प्रदर्शित संख्याएँ मान छोड़ सकती हैं:

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

## **पैराग्राफ लेआउट और अंत गुणों का नियंत्रण**

पहली पंक्ति और रैप की गई पंक्तियों की स्थिति को नियंत्रित करने के लिए पैराग्राफ मार्जिन और इंडेंट समायोजित करें। आप पैराग्राफ एंड मार्क को दृश्यमान टेक्स्ट पोर्शन से अलग भी स्वरूपित कर सकते हैं।

### **पहली‑लाइन इंडेंट सेट करना**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड का उपयोग करके पैराग्राफ की पहली‑लाइन इंडेंट को नियंत्रित करें। यह सेटिंग केवल पैराग्राफ की बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरी पैराग्राफ को स्थानांतरित करने की आवश्यकता हो, तब [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) उपयोग करें।

निम्न उदाहरण तीन पैराग्राफ को समान [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 पॉइंट और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) मान 0, 20, और 40 पॉइंट देता है। पहली पंक्तियों का ऑफ़सेट क्रमशः बड़ा होता है, जबकि रैप की गई पंक्तियों का बायाँ मार्जिन समान रहता है:

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

![पैराग्राफों की पहली‑लाइन इन्डेंट](first_line_indent.png)

### **हैंगिंग इन्डेंट सेट करना**

हैंगिंग इन्डेंट वह पैराग्राफ लेआउट है जहाँ पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में इसे आप [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) प्रॉपर्टी के साथ प्राप्त करते हैं। `Indent` को नकारात्मक मान पर सेट करने से प्रथम पंक्ति पैराग्राफ बॉडी के सापेक्ष बाईं ओर चलती है।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष परिभाषित करता है। हैंगिंग इन्डेंट बनाने के लिये, `MarginLeft` को सकारात्मक मान और `Indent` को नकारात्मक मान दें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों आदि में उपयोगी है जहाँ रैप‑की गई पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्न Java उदाहरण में [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) को 40 और 60 पॉइंट, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) को क्रमशः -20 और -30 पॉइंट दिया गया है। प्रत्येक पैराग्राफ में पहली पंक्ति रैप‑की गई पंक्तियों से बाएँ शुरू होती है; दूसरे पैराग्राफ में हैंगिंग इन्डेंट अधिक गहरा है:

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

![पैराग्राफों की हैंगिंग इन्डेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करना**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) मेथड पैराग्राफ एंड मार्क की फ़ॉर्मेटिंग को नियंत्रित करता है। निम्न उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) बनाता है जिसमें [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 पॉइंट और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) Times New Roman पर सेट किया गया है। यह फ़ॉर्मेट दूसरे पैराग्राफ के एंड मार्क पर लागू किया जाता है, जबकि दृश्यमान टेक्स्ट पोर्शन अपरिवर्तित रहता है:

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

## **रेंडर की गई लाइनों की गणना**

लाइन‑एंड पर स्वचालित रैपिंग और विराम चिह्नों को प्रभावित करने वाले पैराग्राफ नियमों के लिए देखें [Control Line Breaking](/slides/hi/java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/java/text-formatting/#control-hanging-punctuation)।

[IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा आवृत लाइनों की संख्या गिनी जा सकती है, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट की लंबाई और लेआउट जाँचने में उपयोगी है।

एक पैराग्राफ [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) का एक आइटम है, और यह कई रेंडर्ड लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन‑ब्रेक नई पंक्ति बनाता है बिना नई पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर्ड लाइनों की संख्या नहीं देता।

निम्न उदाहरण एक टेक्स्ट आकार बनाता है, उसकी लाइनों की संख्या गिनता है, आकार को संकरा करता है, फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। उदाहरण रैपिंग को सक्षम करने के लिये [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) और ऑटो‑फ़िट को निष्क्रिय करने के लिये [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) का उपयोग करता है, ताकि आकार की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वत: छोटा किए या आकार को पुनः आकारित किए। प्रत्येक माप [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करता है। आकार के माप पॉइंट में हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में कुल लाइनों की संख्या जोड़ता है।

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

इस टेक्स्ट और इन मापों के साथ, आकार को संकरा करने पर लाइनों की संख्या बढ़ती है, जबकि छोटा स्ट्रिंग डालने पर घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटो‑फ़िट सेटिंग्स पर निर्भर करती है। टेम्पलेट जांचते समय लक्षित वातावरण के फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन‑काउंट यह निर्धारित नहीं करता कि टेक्स्ट अपने कंटेनर से बाहर ओवरफ़्लो हो रहा है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ व लाइन‑स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी मायने रखता है; यहां तक कि एकल पंक्ति भी रैपिंग बंद होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ को बाहर उपयोग के लिये निर्यात करें। यह अनुभाग तालिका सेल में पैराग्राफ सहित व्यक्तिगत पैराग्राफ को इमेज के रूप में रेंडर करने का भी तरीका दिखाता है।

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ व पोर्शन में परिवर्तित करें।

यह Java उदाहरण फ़ाइल से HTML पढ़ता है और मार्कअप को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) को पास करता है। यह टेक्स्ट फ्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ्रेम में केवल आयातित सामग्री रहे। आयताकार आकार स्लाइड के प्रत्येक किनारे पर 10‑पॉइंट का मार्जिन छोड़ता है:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें। वेब साइट पर प्रस्तुति टेक्स्ट को पुनः उपयोग करते समय आप स्थानीय स्वरूपण को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स स्टाइल के बिना संरक्षित रखना चाह सकते हैं। फ़ॉर्मेटिंग इनहेरिटेंस की सीमा नियंत्रित करने के लिये [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) सेट करें।

[नमूना प्रस्तुति](text-inheritance.pptx) डाउनलोड करें और इसे एप्लिकेशन की वर्किंग डायरेक्टरी में रखें। इसकी पहली स्लाइड में एक टेक्स्ट आकार है जिसमें टेक्स्ट “Inherited text; explicit red 18pt” है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ्रेम की प्रथम‑स्तर शैली नीला टेक्स्ट और इटैलिक देती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा पोर्शन, “explicit red 18pt”, स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्न पूर्ण उदाहरण समान पैराग्राफ को तीन बार निर्यात करता है। यह [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) को निर्यात मेथड को पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल के रूप में लिखता है:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

उत्पन्न HTML में पहले पोर्शन “Inherited text; ” के लिये निम्न CSS शामिल है। तालिका संबंधित घोषणाओं को दर्शाती है; अन्य उत्पन्न प्रॉपर्टीज स्पष्टता के लिये छोड़ दी गई हैं।

| आउटपुट | पहले पोर्शन के लिए प्रासंगिक CSS | दिखावट |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt Calibri में, यदि वह फ़ॉन्ट उपलब्ध हो। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; फ़ॉन्ट परिवार और आकार आसपास के पृष्ठ या ब्राउज़र द्वारा प्रदान किया जाता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली आसपास के पृष्ठ या ब्राउज़र द्वारा प्रदान की जाती है। |

दूसरा पोर्शन सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt`, और `font-weight:bold` बनाए रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। इनहेरिटेंस को सीमित करने से पैराग्राफ या पोर्शन को स्पष्ट रूप से असाइन किए गए फ़ॉर्मेटिंग को नहीं हटाया जाता।

फ़ाइलों को एक ही ब्राउज़र में खोलें और तुलना करें। दो प्रतिबंधित मोड में छोड़ी गई CSS प्रॉपर्टीज़ को लक्ष्य पृष्ठ की स्टाइल या ब्राउज़र डिफ़ॉल्ट द्वारा हल किया जाता है, इसलिए अंतिम दिखावट इस पर निर्भर करती है कि HTML कहाँ उपयोग किया गया है।

### **HTML क्लिपबोर्ड फ्रैगमेंट उत्पन्न करना**

[TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader-boolean-) का उपयोग करके [IParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) के आउटपुट को चुना जा सकता है। `false` पर मेथड साधारण HTML लौटाता है। `true` पर लौटे स्ट्रिंग की शुरुआत Windows क्लिपबोर्ड हैडर से होती है। उसका `StartHTML` और `EndHTML` फ़ील्ड HTML के UTF‑8 बाइट ऑफ़सेट देते हैं, जबकि `StartFragment` और `EndFragment` पेस्ट करने के लिये कंटेंट को पहचानते हैं।

यह उदाहरण दो स्वरूपित पैराग्राफ को साधारण HTML (`html`) और HTML क्लिपबोर्ड फ्रैगमेंट (`clipboardHtml`) के रूप में निर्यात करता है। एप्लिकेशन तब फ्रैगमेंट को सिस्टम क्लिपबोर्ड में लिख सकता है। यदि क्लिपबोर्ड API कच्चे बाइट्स की अपेक्षा करता है, तो फ्रैगमेंट को BOM‑रहित UTF‑8 में एन्कोड करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();
    paragraphs.clear();
    paragraphs.addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
    options.setAddClipboardFragmentHeader(false);
    String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);

    options.setAddClipboardFragmentHeader(true);
    String clipboardHtml = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
} finally {
    presentation.dispose();
}
```

### **पैराग्राफ को इमेज के रूप में रेंडर करना**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजें। आपको संपूर्ण आकार को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) `null` लौटा सकता है यदि पैराग्राफ उसके पैरेंट संग्रह में नहीं मिला, वैध रेंडर बाउंड्स नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटे इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

यह उदाहरण एक प्रस्तुति के साथ है जिसमें एक स्लाइड है और उसकी पहली आकार एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण इंडेक्स 1 पर स्थित दूसरा पैराग्राफ चुनता है और [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) को बिना स्केल पैरामीटर के कॉल करता है। यह जाँचता है कि आकार में आवश्यक पैराग्राफ मौजूद है और रेंडरिंग ने इमेज लौटाई है, फिर [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) से PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक उपयोग के बाद इमेज को डिस्पोज़ करता है।

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

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि क्षैतिज और लंबवत स्केल फैक्टर निर्धारित किए जा सकें। निम्न उदाहरण एक तालिका बनाता है, उसके पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई व ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

स्केल फैक्टर `1` उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिये, दोनों फैक्टर्स के लिये `2` देने से इमेज की चौड़ाई व ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे चार गुना अधिक पिक्सेल बनते हैं। बड़े फैक्टर आमतौर पर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, परन्तु मेमोरी उपयोग व फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर छोटे इमेज बनाते हैं जिनमें विवरण कम होता है। समान फैक्टर रखें ताकि पैराग्राफ का आस्पेक्ट रेशियो बना रहे; अलग‑अलग क्षैतिज व लंबवत फैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

[IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) के साथ पूरी आकार को रेंडर करना तब उपयोगी रहता है जब आउटपुट में आकार की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल करने की आवश्यकता हो। केवल पैराग्राफ‑इमेज के लिये, [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन‑रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) को `false` पर सेट करने से रैपिंग बंद हो जाती है और लाइनों को टेक्स्ट फ्रेम के किनारे पर नहीं तोड़ा जाता।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त करूँ?**

[IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टेंगल प्राप्त करें। [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) व्यक्तिगत पोर्शन की सीमाएँ देता है।

**पैराग्राफ संरेखण (बाएं, दाएं, केंद्र या जस्टिफ़ाइड) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेटिंग कुछ भी हो।

विभिन्न फ़ॉन्ट आकारों वाले पोर्शन को प्रत्येक पंक्ति में वर्टिकली संरेखित करने के लिये देखें [Align Fonts Within a Line](/slides/hi/java/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के किसी हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिये [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करें, जिससे एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट सम्मिलित किया जा सकता है।