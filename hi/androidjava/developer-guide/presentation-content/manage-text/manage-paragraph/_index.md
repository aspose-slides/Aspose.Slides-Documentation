---
title: Android पर PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधन
type: docs
weight: 40
url: /hi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
  - पैराग्राफ़ को छवि में
  - टेक्स्ट को छवि में
  - पैराग्राफ़ निर्यात करें
  - PowerPoint
  - प्रस्तुति
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ पैराग्राफ़, हिस्से, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री और पैराग्राफ़ छवियों को कैसे बनाएँ और फ़ॉर्मेट करें सीखें।"
---
## **सारांश**

Aspose.Slides for Android via Java टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ और हिस्सों की पदानुक्रम में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) टेक्स्ट फ़्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके हिस्सों तथा पैराग्राफ‑स्तर फॉर्मेटिंग तक पहुंच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) पैराग्राफ के भीतर टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक हिस्सा अपना स्वयं का टेक्स्ट और अक्षर‑स्तर फॉर्मेटिंग रख सकता है।

इस प्रकार एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फॉर्मेटिंग के साथ टेक्स्ट रख सकता है, कई हिस्सों का उपयोग करके।

## **पैराग्राफ बनाना और फॉर्मेट करना**

आकार के टेक्स्ट फ़्रेम में पैराग्राफ बनाएं और हिस्सों का उपयोग करके व्यक्तिगत टेक्स्ट रन को फॉर्मेट करें। यह अनुभाग दिखाता है कि प्रत्येक पैराग्राफ में कई हिस्सों को कैसे मिलाएँ और विभिन्न रंग, फ़ॉन्ट आकार और शैली कैसे लागू करें।

### **कई हिस्सों के साथ पैराग्राफ बनाना**

निम्न Android via Java उदाहरण तीन पैराग्राफ बनाता है, प्रत्येक में तीन टेक्स्ट रन होते हैं, जो [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--) द्वारा लौटाए गए संग्रह में होते हैं। यह डिफ़ॉल्ट पैराग्राफ और उसके खाली हिस्से को पुन: उपयोग करता है, फिर शेष पैराग्राफ और हिस्से जोड़ता है। फॉर्मेटिंग [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ का पहला हिस्सा लाल, बोल्ड और 15 पॉइंट है; दूसरा हिस्सा नीला, इटैलिक और 18 पॉइंट है। तीसरा हिस्सा अपनी डिफ़ॉल्ट फॉर्मेटिंग को बनाए रखता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **बुलेटेड और क्रमांकित सूचियाँ बनाना**

पैराग्राफ टेक्स्ट को प्रतीकों, संख्याओं या कस्टम छवियों के साथ सूचियों में व्यवस्थित करें। इस अनुभाग के उदाहरण बुलेट फॉर्मेटिंग, बहु‑स्तर सूचियों और कस्टम प्रारंभिक संख्याओं को कवर करते हैं।

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और नंबरिंग संबंधित आइटमों को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित होती हैं।

यह Android via Java उदाहरण समान टेक्स्ट फ़्रेम में एक प्रतीक बुलेट और एक क्रमांकित आइटम जोड़ता है। [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) बुलेट प्रकार चुनता है, जबकि [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) प्रतीक प्रदान करता है और [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) क्रमांकन शैली चुनता है। दोनों आइटम काले बुलेट का उपयोग करते हैं, ऊँचाई 100 प्रतिशत और पैराग्राफ इंडेंट 25 पॉइंट है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

चित्र बुलेट आपको प्रतीक या संख्या के बजाय कस्टम छवि उपयोग करने की अनुमति देता है।

यह Android via Java उदाहरण एक छवि को प्रस्तुति की छवि संग्रह में एक [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) के रूप में जोड़ता है और उसे पैराग्राफ बुलेट के रूप में उपयोग करता है। यह बुलेट प्रकार के लिए [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) को कॉल करता है और छवि को [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) के माध्यम से असाइन करता है। [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) को 100 प्रतिशत पर सेट किया गया है ताकि बुलेट पैराग्राफ टेक्स्ट के अनुपात में आकार ले:

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

### **बहु‑स्तर सूची बनाना**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखें। शीर्ष स्तर की गहराई `0` है।

यह Android via Java उदाहरण [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) मानों को 0‑3 तक चार पैराग्राफ़ों के लिए असाइन करता है, जिससे एक ही टेक्स्ट फ़्रेम में पदक्रम बनता है। प्रत्येक पैराग्राफ प्रतीक बुलेट का उपयोग करता है, जहाँ [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) गोल बुलेट और हाइफ़न के बीच बदलता रहता है ताकि क्रमागत स्तरों को अलग किया जा सके:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **कस्टम मानों पर क्रमांकित सूची आइटम शुरू करें**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके क्रमांकित पैराग्राफ के प्रारंभिक नंबर को सेट करें।

यह Android via Java उदाहरण तीन पैराग्राफ के लिए क्रमांकन उपयोग करने हेतु [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) सेट करता है और [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) मान 2, 3, और 7 असाइन करता है। प्रत्येक पैराग्राफ के लिए प्रारंभिक मान अलग‑अलग कॉन्फ़िगर किया जाता है, जिससे प्रदर्शित संख्याएँ मानों को छोड़ सकती हैं:

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

## **पैराग्राफ लेआउट और अंत गुण नियंत्रित करना**

पहली पंक्ति और रैप की गई पंक्तियों की स्थिति को नियंत्रित करने के लिए पैराग्राफ मार्जिन और इंडेंट समायोजित करें। आप पैराग्राफ अंत चिन्ह को दृश्यमान टेक्स्ट हिस्सों से अलग भी फॉर्मेट कर सकते हैं।

### **पहली‑लाइन इंडेंट सेट करें**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मेथड का उपयोग करके पैराग्राफ की पहली‑लाइन इंडेंट को नियंत्रित करें। यह सेटिंग केवल पैराग्राफ की बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करें।

निम्न उदाहरण तीन पैराग्राफ को समान [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 पॉइंट और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान 0, 20 और 40 पॉइंट देता है। पहली पंक्तियाँ क्रमशः अधिक ऑफ़सेट पर शुरू होती हैं, जबकि रैप की गई पंक्तियाँ समान बाएँ मार्जिन बनाए रखती हैं:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![पैराग्राफ़ों की प्रथम‑रेखा इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जहाँ पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में आप इस प्रभाव को [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) प्रॉपर्टी से बनाते हैं। `Indent` को नकारात्मक मान पर सेट करके पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएँ ले जाएँ।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों में उपयोगी है जहाँ रैप की गई पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्न Android via Java उदाहरण [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) मान 40 और 60 पॉइंट को [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान -20 और -30 पॉइंट के साथ जोड़ता है। प्रत्येक पैराग्राफ में पहली पंक्ति रैप की गई पंक्तियों से बाएँ शुरू होती है; दूसरे पैराग्राफ में गहरी हैंगिंग इंडेंट है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![पैराग्राफ़ों की हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करें**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) मेथड पैराग्राफ अंत चिन्ह की फॉर्मेटिंग को नियंत्रित करता है। निम्न उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) बनाता है जिसमें [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 पॉइंट और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) Times New Roman पर सेट है। यह फॉर्मेट दूसरे पैराग्राफ के अंत चिन्ह को असाइन करता है, जबकि दृश्यमान टेक्स्ट हिस्से अपरिवर्तित रहते हैं:

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

## **रेंडर की गई लाइनों की गिनती**

लाइन‑ब्रेकिंग और लाइन‑अंत पंक्चुएशन पर प्रभाव डालने वाले पैराग्राफ नियमों के लिए देखें [Control Line Breaking](/slides/hi/androidjava/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/androidjava/text-formatting/#control-hanging-punctuation)。

[IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा कवर्ड लाइनों की गिनती करें, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रस्तुति टेम्प्लेट में टेक्स्ट लंबाई और लेआउट की जाँच करते समय उपयोगी है।

एक पैराग्राफ [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन‑ब्रेक नई पंक्ति बनाता है बिना नया पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। इसलिए केवल पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनने से रेंडर की गई लाइन गिनती नहीं मिलती।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकुचित करता है, फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। उदाहरण रैपिंग को [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) से सक्षम करता है और ऑटो‑फ़िट को [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) से निष्क्रिय करता है, ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से छोटा किए या शेप को पुनः आकारित किए। प्रत्येक माप [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) से किया जाता है। शेप आकार पॉइंट में है। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ़्रेम में कुल लाइनों की गिनती जोड़ता है।

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

इन टेक्स्ट और इन आयामों के साथ, शेप को संकुचित करने से लाइन गिनती बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने से घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटो‑फ़िट सेटिंग्स पर निर्भर करती है। टेम्प्लेट की जाँच करते समय लक्ष्य पर्यावरण के लिए नियत फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी रैपिंग निष्क्रिय होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री का आयात और निर्यात**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ को बाहरी उपयोग के लिए निर्यात करें। यह अनुभाग यह भी दर्शाता है कि कैसे व्यक्तिगत पैराग्राफ़ों को छवियों के रूप में रेंडर किया जाए, जिसमें तालिका सेल में पैराग्राफ़ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ़ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और हिस्सों में परिवर्तित करें।

यह Android via Java उदाहरण फ़ाइल से HTML पढ़ता है और मार्कअप को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) को पास करता है। यह टेक्स्ट फ़्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ़्रेम में केवल आयातित सामग्री हो। आयताकार शेप स्लाइड के प्रत्येक किनारे पर 10‑पॉइंट मार्जिन छोड़ता है:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML में निर्यात करें। जब प्रस्तुति टेक्स्ट को वेबसाइट पर पुन: उपयोग किया जाता है, तो आप स्थानीय इम्फ़ेसिस को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स शैली ले जाने से बचा सकते हैं। निर्यातकर्ता कितनी दूर तक फ़ॉर्मेटिंग इनहेरिटेंस को फॉलो करे, इसे नियंत्रित करने के लिए [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) सेट करें।

[sample presentation](text-inheritance.pptx) डाउनलोड करें और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक टेक्स्ट शेप है जिसमें टेक्स्ट "Inherited text; explicit red 18pt" है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और आकार 28 pt प्रदान करती है।
- टेक्स्ट फ़्रेम की प्रथम‑स्तर शैली नीले टेक्स्ट और इटैलिक प्रदान करती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा हिस्सा, "explicit red 18pt", स्पष्ट रूप से लाल टेक्स्ट और आकार 18 pt सेट करता है।

निम्न पूर्ण उदाहरण वही पैराग्राफ तीन बार निर्यात करता है। यह [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) को निर्यात मेथड में पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल के रूप में लिखता है:

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

उत्पन्न HTML में प्रथम हिस्से, "Inherited text; " के लिए निम्न CSS है। तालिका संबंधित घोषणाओं को सूचीबद्ध करती है; अन्य उत्पन्न गुण स्पष्टता के लिए छोड़े गए हैं।

| आउटपुट | प्रथम हिस्से के लिए प्रासंगिक CSS | स्वरूप |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt में Calibri, यदि वह फ़ॉन्ट उपलब्ध हो। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली प्रदान करता है। |

दूसरा हिस्सा सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt` और `font-weight:bold` रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। इनहेरिटेंस को प्रतिबंधित करने से पैराग्राफ या हिस्से को स्पष्ट रूप से असाइन की गई फ़ॉर्मेटिंग नहीं हटती।

फाइलें उसी ब्राउज़र में खोलें ताकि तुलना कर सकें। दो प्रतिबंधित मोड में छोड़ी गई CSS प्रॉपर्टीज़ गंतव्य पेज की शैलियों या ब्राउज़र डीफ़ॉल्ट द्वारा हल की जाती हैं, इसलिए अंतिम स्वरूप उपयोग की गई HTML स्थान पर निर्भर करता है।

### **पैराग्राफ को छवि के रूप में रेंडर करें**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजें। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं।

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) `null` भी लौट सकता है यदि पैराग्राफ उसके पैरेंट संग्रह में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं है, या रेंडर नहीं हो सका। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाई गई छवि को डिस्पोज करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें एक स्लाइड है और उसकी पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण इंडेक्स 1 पर दूसरे पैराग्राफ को चुनता है और [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) को बिना स्केल पैरामीटर के कॉल करता है। यह जांचता है कि शेप में आवश्यक पैराग्राफ मौजूद है और रेंडरिंग इमेज लौटाती है, फिर [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से PNG में सहेजता है। `finally` ब्लॉक उपयोग के बाद इमेज को डिस्पोज करता है।

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

![पैराग्राफ छवि](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड उपयोग करके `float scaleX` और `float scaleY` पैरामीटर पास करें, जिससे क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट हो। निम्न उदाहरण एक तालिका बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG छवि के रूप में सहेजता है।

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

स्केल फैक्टर `1` अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिये, दोनों फैक्टर `2` सेट करने से छवि की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना होती है, अर्थात चार गुना पिक्सेल बनते हैं। बड़े फैक्टर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से छोटे फैक्टर छोटे विवरण वाली छवियाँ बनाते हैं। समान फैक्टर का उपयोग करने से पैराग्राफ का अनुपात बना रहता है; अलग‑अलग क्षैतिज और ऊर्ध्वाधर फैक्टर आउटपुट को स्वतंत्र रूप से फैलाते हैं।

[IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) के साथ पूरे शेप को रेंडर करना तब उपयोगी रहता है जब आउटपुट को शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल करना हो। केवल पैराग्राफ‑केवल छवि के लिये, [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के अंदर लाइन रैपिंग पूरी तरह निष्क्रिय कर सकता हूँ?**

हां। लाइन रैपिंग को निष्क्रिय करने के लिए [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को सेट करें, ताकि लाइनों का टूटना टेक्स्ट फ़्रेम के किनारों पर न हो।

**मैं विशिष्ट पैराग्राफ की ऑन‑स्लाइड बाउंड्स कैसे प्राप्त करूँ?**

[IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) व्यक्तिगत हिस्से की सीमाएं प्रदान करता है।

**पैराग्राफ संरेखण (बाएँ, दाएँ, केन्द्र, जस्टिफ़ाइ​ड) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तर सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत हिस्से का फॉर्मेटिंग कुछ भी हो।

प्रत्येक पंक्ति में विभिन्न फ़ॉन्ट आकारों वाले हिस्सों को लंबवत संरेखित करने हेतु देखें [Align Fonts Within a Line](/slides/hi/androidjava/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के हिस्से के लिये प्रूफिंग भाषा सेट कर सकता हूँ?**

हां। प्रत्येक हिस्से के लिये [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करें, ताकि एक पैराग्राफ कई भाषाओं में टेक्स्ट रख सके।