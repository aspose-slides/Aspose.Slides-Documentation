---
title: "Android पर PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें"
linktitle: "पैराग्राफ़ प्रबंधित करें"
type: docs
weight: 40
url: /hi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- "टेक्स्ट जोड़ें"
- "पैराग्राफ़ जोड़ें"
- "टेक्स्ट प्रबंधित करें"
- "पैराग्राफ़ प्रबंधित करें"
- "बुलेट प्रबंधित करें"
- "पैराग्राफ़ इंडेंट"
- "हैंगिंग इंडेंट"
- "पैराग्राफ़ बुलेट"
- "क्रमांकित सूची"
- "बुलेटेड सूची"
- "पैराग्राफ़ गुण"
- "HTML आयात करें"
- "टेक्स्ट को HTML"
- "पैराग्राफ़ को HTML"
- "पैराग्राफ़ को इमेज"
- "टेक्स्ट को इमेज"
- "पैराग्राफ़ निर्यात"
- "PowerPoint"
- "प्रेज़ेंटेशन"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java के साथ पैराग्राफ़, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ़ इमेज कैसे बनाएं और स्वरूपित करें, सीखें।"
---
## **परिचय**

Aspose.Slides for Android via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और उसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और पोर्शन तथा पैराग्राफ-स्तर के फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और अक्षर-स्तर फॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ में विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रखा जा सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **कई पोर्शन के साथ पैराग्राफ बनाना**

निम्नलिखित चरणों से तीन पैराग्राफ वाले एक टेक्स्ट फ्रेम का निर्माण होता है, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिये पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के द्वारा अक्षर-स्तर फॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को सहेजें।

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

## **बुलेटेड और क्रमांकित सूचियाँ बनाना**

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और नंबरिंग से संबंधित आइटम आसानी से स्कैन किए जा सकते हैं। Aspose.Slides में सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक सिंबल बुलेट के लिये एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाएँ।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेज़ेंटेशन को सहेजें।

यह Android via Java उदाहरण एक सिंबल बुलेट और एक क्रमांकित बुलेट बनाता है:

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

### **चित्र बुलेट्स का उपयोग करना**

चित्र बुलेट्स से आप एक कस्टम इमेज को सिंबल या नंबर के स्थान पर उपयोग कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसका [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) एक्सेस करें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रेज़ेंटेशन की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#getPicture--) के द्वारा इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को सहेजें।

यह Android via Java उदाहरण एक चित्र बुलेट बनाता है:

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

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाकर उनके बुलेट सिंबल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) मान क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

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

### **कस्टम मानों से क्रमांकित सूची आइटम शुरू करना**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके क्रमांकित पैराग्राफ के प्रारंभिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) को स्लाइड पर जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. प्रत्येक पैराग्राफ के लिये [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3` और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

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

## **पैराग्राफ लेआउट और अंत गुणों का नियंत्रण**

### **पहली‑लाइन इंडेंट सेट करना**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली‑लाइन इंडेंट नियंत्रित की जा सकती है। यह विधि केवल पहली लाइन को पैराग्राफ के बाएँ मार्जिन की तुलना में़ बदलती है। सकारात्मक मान पहली लाइन को दायें शिफ्ट करता है, जबकि बाकी लाइनों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

पूरे पैराग्राफ को शिफ्ट करने की आवश्यकता होने पर [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) उपयोग करें। केवल पहली लाइन को शिफ्ट करने हेतु [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) प्रयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान लागू करके दिखाता है कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिये विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को सहेजें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की पहली‑लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों के बाएँ स्थित होती है। Aspose.Slides में यह प्रभाव [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) द्वारा प्राप्त किया जाता है। पैराग्राफ बॉडी की तुलना में पहली लाइन को बाएँ ले जाने के लिये नकारात्मक मान पास करें।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी के बाएँ स्थान को निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली लाइन की स्थिति तय करता है। हैंगिंग इंडेंट बनाने के लिये `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान दें।

यह फॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, ग्लॉसरी एंट्री आदि के लिये उपयोगी है जहाँ रॅॅप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, पहली लाइन के पहले अक्षर के नीचे नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाएँ।
2. लक्षित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिये [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) को सकारात्मक मान दें।
6. हैंगिंग इंडेंट प्रभाव के लिये [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन गुण सेट करना**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) पैराग्राफ अंत चिह्न के फॉर्मेटिंग को नियंत्रित करता है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फॉन्ट साइज और लैटिन फॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) लोड करें और स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिये एक [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/) बनाएँ।
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) के द्वारा फॉर्मेट असाइन करें और प्रेज़ेंटेशन सहेजें।

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

## **पैराग्राफ सामग्री का आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. एक स्लाइड तक पहुँचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
6. संशोधित प्रेज़ेंटेशन को सहेजें।

यह Android via Java उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाकर आवश्यक प्रेज़ेंटेशन लोड करें।
2. स्लाइड तक पहुँचें और उस [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) को खोजें जिसमें टेक्स्ट है।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
4. प्रारम्भिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Android via Java उदाहरण पहले टेक्स्ट शेप से सभी पैराग्राफ निर्यात करता है:

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

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के द्वारा सहेजा जा सकता है। आपको सम्मिलित आकार को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की जरूरत नहीं।

यदि पैराग्राफ नहीं मिला, वैध रेंडरिंग बाउंड नहीं हैं, या रेंडर नहीं हो पाया तो [IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) `null` लौटा सकता है। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद रिटर्न किए गए इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लेते हैं कि हमारे पास `sample.pptx` नामक एक प्रेज़ेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर दूसरे पैराग्राफ को रेंडर करता है और PNG फ़ॉर्मेट में इमेज सहेजता है। `finally` ब्लॉक इमेज को सही ढंग से डिस्पोज़ करता है।

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

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड का उपयोग करके `float scaleX` और `float scaleY` पैरामीटर पास करके क्षैतिज और ऊर्ध्वाधर स्केल फ़ैक्टर सेट किए जा सकते हैं। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फ़ैक्टर अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिये, दोनों फ़ैक्टर को `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाता है, जिससे पिक्सेल चार गुना बढ़ जाते हैं। बड़े फ़ैक्टर ज़ूमिंग या हाई‑रिज़ॉल्यूशन आउटपुट के लिये अधिक तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर रखने से पैराग्राफ का एस्पेक्ट रेशियो बना रहता है; अलग क्षैतिज और ऊर्ध्विक फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

पूरा शेप रेंडर करने के लिये [IShape.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getImage--) उपयोगी रहता है जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य विज़ुअल कंटेक्स्ट शामिल होना आवश्यक हो। केवल पैराग्राफ‑केवल इमेज के लिये [IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। रैपिंग को निष्क्रिय करने हेतु [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को सेट करें ताकि लाइनें टेक्स्ट फ्रेम के किनारों पर न टूटें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

[IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getRect--) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getRect--) व्यक्तिगत पोर्शन की बाउंड्स देता है।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, केंद्र या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है और व्यक्तिगत पोर्शन फॉर्मेटिंग से स्वतंत्र रूप से पूरे पैराग्राफ पर लागू होती है।

**क्या मैं पैराग्राफ के हिस्से के लिये प्रमाणन भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिये [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करें, जिससे एक पैराग्राफ कई भाषाओं में टेक्स्ट रख सकता है।