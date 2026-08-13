---
title: Android पर प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 60
url: /hi/androidjava/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाने और स्वरूपित करने का तरीका सीखें।"
---
## **अवलोकन**

Aspose.Slides for Android via Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों को बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम वह अनुच्छेद है जिसका बुलेट सेटिंग उसके अनुच्छेद फ़ॉर्मेट के माध्यम से नियंत्रित होती है।

पैराग्राफ-स्तर की सूची सेटिंग तक पहुँचने के लिए [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) मेथड का उपयोग करें। मुख्य प्रवेश बिंदु [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) है, जो एक [IBulletFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांकन शैली और प्रारम्भिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके बहु-स्तरीय सूची बनाएं
- क्रमांकित सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण का निरीक्षण और बदलाव करें

## **बुलेटेड सूची बनाना**

बुलेटेड सूची बनाने के लिए, एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) में पैराग्राफ जोड़ें और [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें। इसके बाद आप बुलेट की उपस्थिति को नियंत्रित करने के लिए [IBulletFormat.setChar](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#getColor--) और [IBulletFormat.setHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) सेट कर सकते हैं।

निम्नलिखित Java कोड स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

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

## **क्रमांकित सूची बनाना**

जब आइटम क्रम मायने रखता है, तो क्रमांकित सूचियों का उपयोग करें। [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें। आप क्रमांकन फ़ॉर्मेट को [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) से चुन सकते हैं या जब सूची को 1 से अलग मान से शुरू करना हो तो [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) सेट कर सकते हैं।

निम्नलिखित Java कोड स्लाइड में क्रमांकित सूची बनाने का तरीका दर्शाता है:

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

## **चित्र बुलेट बनाना**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को एक छवि से बदलने की अनुमति देता है। चित्र बुलेट छोटे आकार में भी स्पष्ट रहने वाली सरल छवियों के साथ सबसे बेहतर काम करते हैं, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" %}}
आदर्श रूप से, यदि आप सामान्य बुलेट प्रतीक को एक छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली एक सरल ग्राफ़िक चुनना सबसे अच्छा है। ऐसी छवियाँ कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह कार्य करती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से अनुशंसा करते हैं कि आप ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग किए जाने पर भी स्पष्ट और दृष्टिगत रूप से प्रभावी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [Presentation.getImages](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getImages--) में जोड़ें और लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट को [IBulletFormat.getPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#getPicture--) को असाइन करें। छवि असाइन करने से पहले [IBulletFormat.setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/bullettype/) पर सेट करें।

मान लीजिए हमारे पास "image.png" है:

![A picture for the bullets](picture_for_bullets.png)

निम्नलिखित Java कोड स्लाइड में चित्र बुलेट बनाने का तरीका दर्शाता है:

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

## **बहु-स्तरीय सूची बनाना**

विभिन्न स्तरों पर सूची आइटम रखने के लिए [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, और इसी तरह आगे।

निम्नलिखित Java कोड बहु-स्तरीय सूची बनाने का तरीका दिखाता है:

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

## **मौजूदा सूची बदलना**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुँचें और उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग को अपडेट करें। सूची बनाने के लिए उपयोग की गई वही विधियाँ PPT, PPTX या ODP फ़ाइल से लोड की गई सूचियों की जाँच या संशोधन के लिए भी उपयोग की जा सकती हैं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या बुलेटेड और क्रमांकित सूचियों को PDF या छवियों में निर्यात किया जा सकता है?

हां। Aspose.Slides सूची स्वरूपण को बनाए रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

### क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग की जाँच या अपडेट करें, और प्रस्तुति सहेजें।

### क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?

हां। सूची आइटम टेक्स्ट Unicode अक्षरों को समायोजित कर सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट उन अक्षरों का समर्थन करते हैं।