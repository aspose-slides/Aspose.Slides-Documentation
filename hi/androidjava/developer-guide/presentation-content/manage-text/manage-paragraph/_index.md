---
title: एंड्रॉइड पर पॉवरपॉइंट टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- नंबरड लिस्ट
- बुलेटेड लिस्ट
- पैराग्राफ प्रॉपर्टीज़
- HTML आयात करें
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ पैराग्राफ, पोर्शन, बुलेट, नंबरड लिस्ट, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज बनाना और फॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Android via Java पाठ को टेक्स्ट फ़्रेम, पैराग्राफ, और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) वह टेक्स्ट कंटेनर है जो एक शेप में स्थित होता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) टेक्स्ट फ़्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ‑स्तरीय फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तरीय फॉर्मेटिंग हो सकता है।

एक पैराग्राफ इसलिए विभिन्न फ़ॉन्ट, रंग, आकार, और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन के माध्यम से समेट सकता है।

## **पैराग्राफ बनाएं और स्वरूपित करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित चरण तीन पैराग्राफ वाला टेक्स्ट फ़्रेम बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के द्वारा संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करके दो और [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) ऑब्जेक्ट टेक्स्ट फ़्रेम में जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन होने के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से कैरेक्टर‑स्तरीय फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

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

## **बुलेटेड और नंबरड लिस्ट बनाएं**

### **बुलेटेड या नंबरड लिस्ट बनाएं**

बुलेट और नंबरिंग संबंधित आइटम को जल्दी स्कैन करने में मदद करती है। Aspose.Slides में लिस्ट सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के द्वारा संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. सिंबल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाएं।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग, और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
11. नंबरड बुलेट शैली कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह Android via Java उदाहरण एक सिंबल बुलेट और एक नंबरड बुलेट बनाता है:

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

### **पिक्चर बुलेट्स का उपयोग करें**

पिक्चर बुलेट्स आपको सिंबल या नंबर के बजाय कस्टम इमेज इस्तेमाल करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के द्वारा संबंधित स्लाइड तक पहुँचें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसकी [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
4. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज लोड करें और उसे प्रेजेंटेशन की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#getPicture--) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

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

### **मल्टीलेवल लिस्ट बनाएं**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रख सकते हैं। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाकर उनके बुलेट सिंबल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) मान क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह Android via Java उदाहरण चार‑स्तरीय बुलेटेड लिस्ट बनाता है:

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

### **नंबरड लिस्ट आइटम्स को कस्टम वैल्यू पर शुरू करें**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके नंबरड पैराग्राफ की प्रारंभिक संख्या निर्धारित की जा सकती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाकर स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
2. शेप के टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन नंबरड पैराग्राफ बनाएँ।
4. प्रत्येक पैराग्राफ के लिए [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह Android via Java उदाहरण प्रत्येक पैराग्राफ को एक कस्टम प्रारंभिक संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ को नियंत्रित करें**

### **फ़र्स्ट‑लाइन इंडेंट सेट करें**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति की इंडेंट नियंत्रित की जाती है। यह विधि केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाईं ओर शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) का उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) का प्रयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान लागू करके दर्शाता है कि फ़र्स्ट‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाकर उन पर विभिन्न [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में इसे आप [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) के साथ नकारात्मक मान पास करके प्राप्त कर सकते हैं।

व्यावहारिक रूप से, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान दें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों आदि में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
4. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) को सकारात्मक मान दें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) पैराग्राफ के अंत चिह्न के फ़ॉर्मेट को नियंत्रित करता है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट साइज और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) लोड करें और कोई स्लाइड एक्सेस करें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाकर उन पर टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) और [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) के साथ फ़ॉर्मेट असाइन करें और प्रेजेंटेशन को सहेजें।

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

## **रेंडर की गई लाइनों की गणना करें**

[IParagraph.getLinesCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) का उपयोग करके आप टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा कब्जा की गई लाइनों की संख्या गिन सकते हैं, जिसमें स्वचलित रैपिंग भी शामिल है। यह प्रेजेंटेशन टेम्प्लेट में टेक्स्ट की लंबाई और लेआउट चेक करने में उपयोगी है।

एक पैराग्राफ [ITextFrame.getParagraphs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParagraphs--) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेरे हो सकता है। पैराग्राफ के भीतर स्पष्ट लाइन‑ब्रेक नई पंक्ति उत्पन्न करता है लेकिन नया पैराग्राफ नहीं बनाता। स्वचलित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करती है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक जोड़े। इसलिए पैराग्राफ गिनना या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर की गई लाइन काउंट नहीं देता।

नीचे दिया गया उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों को गिनता है, शेप को संकरा करता है, फिर टेक्स्ट को छोटा स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटॉफिट निष्क्रिय है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वतः छोटा किए या शेप का आकार बदले। शेप पारिमाण पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ़्रेम में कुल लाइन काउंट जोड़ता है।

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

इन टेक्स्ट और परिमाणों के साथ, शेप को संकरा करने से लाइन काउंट बढ़ता है, जबकि छोटा स्ट्रिंग रखने से घटता है। सटीक काउंट फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट साइज, मार्जिन, इंडेंटेशन, रैपिंग, और ऑटॉफिट सेटिंग्स पर निर्भर कर सकते हैं। टेम्प्लेट जांचते समय लक्ष्य वातावरण के लिए नियोजित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन काउंट यह निर्धारित नहीं करता कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटॉफिट व्यवहार भी मायने रखते हैं; जब रैपिंग निष्क्रिय हो तो एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ कंटेंट आयात और निर्यात करें**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके आप HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाएं।
2. स्लाइड तक पहुँचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
3. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह Android via Java उदाहरण HTML को टेक्स्ट फ़्रेम में आयात करता है:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके आप चयनित पैराग्राफ रेंज को HTML के रूप में एक्सपोर्ट कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाकर इच्छित प्रेजेंटेशन लोड करें।
2. स्लाइड तक पहुँचें और वह [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप की [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. वापस मिलने वाले HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Android via Java उदाहरण पहले टेक्स्ट शेप के सभी पैराग्राफ को एक्सपोर्ट करता है:

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

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजा जा सकता है। आपको पूरे शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) `null` भी लौट सकता है यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं हो सका। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लेते हैं कि हमारे पास `sample.pptx` नाम की एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, और पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![The text box with three paragraphs](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर दूसरे पैराग्राफ को रेंडर करता है और PNG फ़ॉर्मेट में इमेज को सहेजता है। `finally` ब्लॉक इमेज को सही से डिस्पोज़ करने को सुनिश्चित करता है।

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

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि क्षैतिज और ऊर्ध्वाधर स्केल फ़ैक्टर सेट हों। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना स्केल करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

स्केल फ़ैक्टर `1` अक्ष को उसकी डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर `2` रखने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटे इमेज बनाते हैं जिनमें कम विवरण होता है। समान फ़ैक्टर उपयोग करने से पैराग्राफ का एस्पेक्ट रेशियो बना रहता है; अलग-अलग क्षैतिज और ऊर्ध्वाधर फ़ैक्टर आउटपुट को अलग‑अलग खींचते हैं।

पूरे शेप को [IShape.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getImage--) से रेंडर करना तब उपयोगी है जब आउटपुट में शेप की फ़िल, बॉर्डर, या अन्य विज़ुअल संदर्भ भी शामिल होना चाहिए। केवल पैराग्राफ इमेज के लिए [IParagraph.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getImage--) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के अंदर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**

हाँ। रैपिंग को अक्षम करने के लिए [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) को सेट करें ताकि लाइनों का टूटना फ़्रेम के किनारों पर न हो।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बॉण्ड्स कैसे प्राप्त करूँ?**

पैराग्राफ की बाउंडिंग रेक्टंगल प्राप्त करने के लिए [IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getRect--) का उपयोग करें। व्यक्तिगत पोर्शन की बाउंडिंग के लिए [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getRect--) उपयोग करें।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, मध्य, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफ़िंग लैंग्वेज सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।