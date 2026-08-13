---
title: Java में प्रस्तुतियों में बुलेटेड और नंबरयुक्त सूचियों को प्रबंधित करें
linktitle: सूचियों को प्रबंधित करें
type: docs
weight: 60
url: /hi/java/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- नंबरयुक्त सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और नंबरयुक्त सूचियों को कैसे बनाएं और स्वरूपित करें, इसे सीखें।"
---
## **अवलोकन**

Aspose.Slides for Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबरयुक्त सूचियाँ बनाने व स्वरूपित करने देती है। एक सूची आइटम वह पैराग्राफ है जिसके बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट द्वारा नियंत्रित होते हैं।

पैराग्राफ‑स्तरीय सूची सेटिंग्स तक पहुँचने के लिए [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/#getParagraphFormat--) मेथड का उपयोग करें। मुख्य एंट्री पॉइंट है [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getBullet--), जो एक [IBulletFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट का प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांकन शैली, और प्रारम्भिक संख्या सेट कर सकते हैं।

यह लेख दर्शाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके मल्टी‑लेवल सूची बनाएं
- नंबरयुक्त सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण देखें और बदलें

## **बुलेटेड सूची बनाएँ**

बुलेटेड सूची बनाने के लिए, [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) ऑब्जेक्ट को एक [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) में जोड़ें और [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/#Symbol) पर सेट करें। फिर आप [IBulletFormat.setChar](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#getColor--) और [IBulletFormat.setHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setHeight-float-) सेट करके बुलेट की उपस्थिति नियंत्रित कर सकते हैं।

नीचे दिया गया Java कोड स्लाइड में बुलेटेड सूची बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The symbol bullets](symbol_bullets.png)

## **नंबरयुक्त सूची बनाएँ**

जब आइटम का क्रम महत्वपूर्ण हो, तो नंबरयुक्त सूचियों का उपयोग करें। [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/#Numbered) पर सेट करें। आप [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) से क्रमांकन शैली चुन सकते हैं या जब सूची 1 से अलग संख्या से शुरू हो तो [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) सेट कर सकते हैं।

नीचे दिया गया Java कोड स्लाइड में नंबरयुक्त सूची बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The numbered bullets](numbered_bullets.png)

## **चित्र बुलेट बनाएँ**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को एक चित्र से बदलने की अनुमति देता है। चित्र बुलेट सबसे अच्छा तब काम करते हैं जब वे सरल चित्र हों जो छोटे आकार में भी स्पष्ट रहें, जैसे आइकन या छोटे ट्रांसपेरेंट PNG फाइलें।

{{% alert color="info" %}}
यदि आप सामान्य बुलेट प्रतीक को एक चित्र से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाला सरल ग्राफ़िक चुनना बेहतर है। ऐसे चित्र कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करते हैं।

ध्यान रखें कि चित्र को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से सलाह देते हैं कि आप ऐसा चित्र चुनें जो सूची में बुलेट के रूप में उपयोग होने पर भी स्पष्ट और दृश्य रूप से प्रभावी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक चित्र को [Presentation.getImages](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getImages--) में जोड़ें और लौटाए गए चित्र ऑब्जेक्ट को [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#getPicture--) को असाइन करें। असाइन करने से पहले [IBulletFormat.setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/bullettype/#Picture) पर सेट करें।

मान लें हमारे पास "image.png" है:

![A picture for the bullets](picture_for_bullets.png)

नीचे दिया गया Java कोड स्लाइड में चित्र बुलेट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The picture bullets](picture_bullets.png)

## **मल्टी‑लेवल सूची बनाएँ**

सूची आइटम को विभिन्न स्तरों पर रखने के लिए [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setDepth-short-) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, और इसी तरह।

नीचे दिया गया Java कोड मल्टी‑लेवल बुलेटेड सूची बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The multilevel list](multilevel_list.png)

## **मौजूद सूची बदलें**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुँचें और उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग्स को अपडेट करें। सूची बनाने के लिए उपयोग किए गए वही गुण PPT, PPTX या ODP फ़ाइल से लोड की गई सूचियों को निरीक्षण या संशोधित करने के लिए उपयोग किए जा सकते हैं।

नीचे दिया गया Java कोड टेक्स्ट फ्रेम में पहले पैराग्राफ को नंबरयुक्त सूची शैली देने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### क्या बुलेटेड और नंबरयुक्त सूचनाएँ PDF या छवियों में निर्यात की जा सकती हैं?

हाँ। Aspose.Slides सूची स्वरूपण को सुरक्षित रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं को समर्थन देता है।

### क्या मैं मौजूदा प्रस्तुतियों में सूचनाओं को संपादित कर सकता हूँ?

हाँ। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग्स की जाँच या अद्यतन करें, और प्रस्तुति को सहेजें।

### क्या सूचनाओं में गैर‑लैटिन टेक्स्ट हो सकता है?

हाँ। सूची आइटम टेक्स्ट Unicode अक्षरों को सम्मिलित कर सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचनाएँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों को समर्थन देते हैं।