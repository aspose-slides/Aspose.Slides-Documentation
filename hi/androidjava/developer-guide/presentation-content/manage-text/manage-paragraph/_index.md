---
title: Android पर PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
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
  - पैराग्राफ़ प्रॉपर्टीज़
  - HTML आयात करें
  - टेक्स्ट को HTML में बदलें
  - पैराग्राफ़ को HTML में बदलें
  - पैराग्राफ़ को इमेज में बदलें
  - टेक्स्ट को इमेज में बदलें
  - पैराग्राफ़ निर्यात करें
  - PowerPoint
  - प्रेजेंटेशन
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ पैराग्राफ़, भाग, बुलेट, क्रमांकित सूचियों, इंडेंट, HTML सामग्री, और पैराग्राफ़ इमेज कैसे बनाएं और फ़ॉर्मेट करें, सीखें।"
---
## **Overview**

Aspose.Slides for Android via Java पाठ को टेक्स्ट फ्रेम, पैराग्राफ और भागों (Portions) की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) एक शैप (shape) में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके भागों तथा पैराग्राफ‑स्तरीय फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) एक पैराग्राफ के भीतर टेक्स्ट के भाग को दर्शाता है। प्रत्येक भाग का अपना टेक्स्ट और कैरेक्टर‑स्तरीय फॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ कई भागों का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग के साथ पाठ धारण कर सकता है।

## **Create and Format Paragraphs**

### **Create Paragraphs with Multiple Portions**

निम्न चरण तीन पैराग्राफ़ वाले एक टेक्स्ट फ्रेम को बनाते हैं, प्रत्येक में तीन भाग होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. इसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) ऑब्जेक्ट जोड़ें ताकि वह तीन भाग रख सके। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली भाग मौजूद है।
7. प्रत्येक भाग का टेक्स्ट सेट करें।
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से कैरेक्टर‑स्तरीय फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रस्तुति को सहेजें।

यह Android via Java उदाहरण इन चरणों को लागू करता है:

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

## **Create Bulleted and Numbered Lists**

### **Create a Bulleted or Numbered List**

बुलेट और नम्बरिंग संबंधित आइटमों को आसानी से स्कैन करने में मदद करती है। Aspose.Slides में सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. इसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक प्रतीक बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाएँ।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति सहेजें।

यह Android via Java उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

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

### **Use Picture Bullets**

पिक्चर बुलेट आपको प्रतीक या संख्या के बजाय कस्टम इमेज उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. इसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसकी [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रस्तुति के इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#getPicture--) के माध्यम से इमेज असाइन करें और बुलेट की ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह Android via Java उदाहरण एक पिक्चर बुलेट बनाता है:

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

### **Create a Multilevel List**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसकी टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाकर उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) मान क्रमशः `0`, `1`, `2` और `3` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Android via Java उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

### **Start Numbered List Items at Custom Values**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या निर्धारित की जा सकती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर एक स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
2. शैप की टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. संबंधित पैराग्राफ के लिए [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Android via Java उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारम्भिक संख्या असाइन करता है:

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

## **Control Paragraph Layout and End Properties**

### **Set a First-Line Indent**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित किया जाता है। यह मेथड केवल पहली पंक्ति को पैराग्राफ की बाएँ सीमा से संबंधित स्थानांतरित करता है। सकारात्मक मान पहली पंक्ति को दायें शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूर्ण पैराग्राफ को स्थानांतरित करने के लिए आप [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग कर सकते हैं। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का प्रयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान लागू करता है जिससे पहला‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है, देखा जा सके।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिए विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ इंडेंट कैसे सेट किया जाता है:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Set a Hanging Indent**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में इसे आप [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) के साथ नकारात्मक मान पास करके प्राप्त कर सकते हैं।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, जबकि [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान दें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों आदि में उपयोगी है जहाँ रैप्ड लाइन्स को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले कैरेक्टर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाकर लक्ष्य स्लाइड तक पहुँचें।
2. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
3. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. पैराग्राफ बनाकर प्रत्येक के लिए सकारात्मक मान के साथ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) सेट करें।
5. हैंगिंग इन्डेंट प्रभाव बनाने के लिए नकारात्मक मान के साथ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट किया जाता है:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Set End Paragraph Run Properties**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) पैराग्राफ के अंत चिन्ह की फ़ॉर्मेटिंग को नियंत्रित करता है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ की अंत‑मर्क पर फ़ॉन्ट आकार और लैटिन फ़ॉन्ट सेट करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) लोड करके स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट भाग जोड़ें।
4. दूसरे पैराग्राफ के अंत‑मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/) बनाएँ।
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. फ़ॉर्मेट को [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) के साथ असाइन करें और प्रस्तुति सहेजें।

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

## **Count Rendered Lines**

पैराग्राफ नियमों के बारे में जो स्वचालित रैपिंग और लाइनों के अंत में विराम चिह्न को प्रभावित करते हैं, कृपया देखें: [Control Line Breaking](/slides/hi/androidjava/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/androidjava/text-formatting/#control-hanging-punctuation)।

[IParagraph.getLinesCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करके किसी पैराग्राफ द्वारा टेक्स्ट लेआउट के बाद घिरे हुए लाइनों की संख्या गिनी जा सकती है, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रस्तुति टेम्प्लेट में टेक्स्ट की लंबाई और लेआउट जाँचने में उपयोगी है।

एक पैराग्राफ [ITextFrame.getParagraphs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParagraphs--) का सदस्य है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नया पैराग्राफ बनाए बिना नई पंक्ति बनाता है। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डालें। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर की गई लाइन काउंट नहीं देता।

नीचे दिया गया उदाहरण एक टेक्स्ट शैप बनाता है, उसकी लाइनों की संख्या गिनता है, शैप को संकरी करता है, फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फ़िट अक्षम है ताकि शैप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से छोटा किए या शैप को रिसाइज़ किए। शैप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन काउंट को जोड़ता है।

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

इन टेक्स्ट और आयामों के साथ, शैप को संकरा करने से लाइन काउंट बढ़ेगा, जबकि छोटे स्ट्रिंग में बदलने से घटेगा। सटीक काउंट फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटो‑फ़िट सेटिंग्स के साथ बदल सकते हैं। टेम्प्लेट जाँचते समय लक्ष्य पर्यावरण के लिए इच्छित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन काउंट यह निर्धारित नहीं करता कि टेक्स्ट उसके कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी रैपिंग निष्क्रिय होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **Import and Export Paragraph Content**

### **Import HTML Text into Paragraphs**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और भागों में परिवर्तित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. एक स्लाइड तक पहुँचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
3. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और उसका डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
6. संशोधित प्रस्तुति को सहेजें।

यह Android via Java उदाहरण HTML को एक टेक्स्ट फ्रेम में इम्पोर्ट करता है:

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

### **Export Paragraph Text to HTML**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाकर वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. शैप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Android via Java उदाहरण प्रथम टेक्स्ट शैप से सभी पैराग्राफ को निर्यात करता है:

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

### **Render a Paragraph as an Image**

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजा जा सकता है। आपको संपूर्ण शैप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ को उसके पैरेंट कलेक्शन में नहीं पाया जाता, वैध रेंडरिंग बाउंड्स नहीं होते या रेंडर नहीं किया जा सकता, तो [IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) `null` लौटा सकता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ करें।

#### **Render a Paragraph at the Default Scale**

मान लें कि हमारे पास `sample.pptx` नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शैप तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स है।

![The text box with three paragraphs](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को नियमित टेक्स्ट शैप में डिफ़ॉल्ट स्केल पर रेंडर करता है और PNG फ़ॉर्मेट में लौटाए गए इमेज को सहेजता है। `finally` ब्लॉक इमेज को सही तरीके से डिस्पोज़ करना सुनिश्चित करता है।

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

![The paragraph image](paragraph_to_image_output.png)

#### **Render a Paragraph in a Table Cell with Scaling**

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड का उपयोग करके `float scaleX` और `float scaleY` पैरामीटर दिए जा सकते हैं जिससे क्षैतिज और ऊर्धवाधर स्केल फ़ैक्टर सेट होते हैं। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना स्केल पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

स्केल फ़ैक्टर `1` वह अक्ष को उसकी डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर के लिए `2` रखने पर इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे पिक्सेल चार गुना बढ़ जाते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर उपयोग करने से पैराग्राफ का आस्पेक्ट रेशियो बना रहता है; विभिन्न क्षैतिज और ऊर्धवाधर फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

पूरे शैप को [IShape.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getImage--) से रेंडर करना उपयोगी है जब आउटपुट में शैप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ‑इमेज के लिए [IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) उपयोग करें।

## **FAQ**

**Can I completely disable line wrapping inside a text frame?**

हाँ। लाइन्स को फ्रेम के किनारों पर नहीं तोड़ने के लिए रैपिंग निष्क्रिय करने हेतु [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को सेट करें।

**How can I get the exact on-slide bounds of a specific paragraph?**

एक विशिष्ट पैराग्राफ की सटीक स्लाइड पर सीमाओं को प्राप्त करने के लिए [IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getRect--) का उपयोग करें। व्यक्तिगत भाग की सीमाएँ प्राप्त करने के लिए [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getRect--) उपयोग किया जाता है।

**Where is paragraph alignment (left, right, center, or justify) controlled?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तरीय सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत भाग का फ़ॉर्मेट कुछ भी हो।

**Can I set the proofing language for part of a paragraph?**

हाँ। व्यक्तिगत भागों के लिए [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करके आप एक पैराग्राफ में कई भाषाएँ रख सकते हैं।