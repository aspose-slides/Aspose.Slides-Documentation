---
title: जावा में प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 60
url: /hi/java/manage-lists/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाने और स्वरूपित करने के बारे में जानें।"
---
## **अवलोकन**

Aspose.Slides for Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों को बनाने और स्वरूपित करने देता है। एक सूची आइटम एक पैराग्राफ है जिसके बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित होते हैं।

पैराग्राफ-स्तर की सूची सेटिंग्स तक पहुँचने के लिए [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) मेथड का प्रयोग करें। मुख्य एंट्री पॉइंट है [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), जो एक [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांकन शैली, और प्रारम्भिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि:

- कस्टम प्रतीक के साथ एक बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके एक बहु-स्तरीय सूची बनाएं
- एक क्रमांकित सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण की जाँच और परिवर्तन करें
- पैराग्राफ टेक्स्ट के साथ वास्तविक सूची मार्कर और संख्याएँ पढ़ें

## **बुलेटेड सूची बनाना**

एक बुलेटेड सूची बनाने के लिए, एक [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) में [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें और [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol) पर सेट करें। फिर आप बुलेट की रूपरेखा को नियंत्रित करने के लिए [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--), और [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) सेट कर सकते हैं।

निम्नलिखित Java कोड एक स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

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

![प्रतीक बुलेट](symbol_bullets.png)

## **क्रमांकित सूची बनाना**

जब वस्तुओं का क्रम महत्वपूर्ण हो तो क्रमांकित सूचियों का उपयोग करें। [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered) पर सेट करें। आप क्रमांकन प्रारूप को [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) के साथ चुन सकते हैं या जब सूची 1 से अलग मान से शुरू होनी चाहिए तब [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) सेट कर सकते हैं।

निम्नलिखित Java कोड एक स्लाइड में क्रमांकित सूची बनाने का दिखाता है:

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

![क्रमांकित बुलेट](numbered_bullets.png)

## **चित्र बुलेट बनाना**

Aspose.Slides आपको नियमित बुलेट प्रतीक को छवि से बदलने की अनुमति देता है। चित्र बुलेट छोटे आकार में पठनीय रहने वाली सरल छवियों के साथ सबसे बेहतर काम करता है, जैसे आइकन या छोटे पारदर्शी PNG फाइलें।

{{% alert color="info" title="Note" %}}
आदर्श रूप से, यदि आप नियमित बुलेट प्रतीक को छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली सरल ग्राफ़िक चुनना सबसे अच्छा है। ऐसी छवियां कस्टम बुलेट प्रतीकों के रूप में अच्छी कार्य करती हैं।
{{% /alert %}}

एक चित्र बुलेट बनाने के लिए, [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) में एक छवि जोड़ें और लौटाए गए छवि ऑब्जेक्ट को [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) को असाइन करें। छवि असाइन करने से पहले [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) को [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) पर सेट करें।

मान लीजिए हमारे पास "image.png" है:

![बुलेट के लिए एक चित्र](picture_for_bullets.png)

निम्नलिखित Java कोड एक स्लाइड में चित्र बुलेट बनाने का दिखाता है:

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

![चित्र बुलेट](picture_bullets.png)

## **बहु-स्तरीय सूची बनाना**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) का उपयोग करके सूची आइटमों को विभिन्न स्तरों पर रखें। स्तर 0 शीर्ष स्तर है, स्तर 1 इसके नीचे नेस्टेड होता है, आदि।

निम्नलिखित Java कोड बहु-स्तरीय बुलेटेड सूची बनाने का दिखाता है:

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

![बहु-स्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलना**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुँचें और उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग्स को अद्यतन करें। सूची बनाने के लिए उपयोग की गई वही प्रॉपर्टीज़ PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचियों की जाँच या संशोधन के लिए भी उपयोग की जा सकती हैं।

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

## **वास्तविक बुलेट मान पढ़ें**

प्रस्तुति सामग्री निकालते समय, सूची मार्कर को पैराग्राफ टेक्स्ट के साथ रखें। प्रभावी बुलेट फ़ॉर्मेट प्राप्त करने के लिए [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) को कॉल करें और [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) तक पहुँचें। [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) पढ़ने से पहले उसके [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) की जाँच करें।

क्रमांकित सूचियों के लिए, इन तीन मानों में अंतर करें:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) स्वरूप निर्धारित करता है, जैसे बिंदु के बाद अरबी अंक या छोटे अक्षर।
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) क्रमांकित पैराग्राफ़ समूह के लिए प्रारम्भिक संख्या निर्दिष्ट करता है।
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) किसी विशेष पैराग्राफ़ के लिए स्वरूपित मार्कर लौटाता है। उदाहरण के लिए, 5 से शुरू होने वाली सूची का दूसरा आइटम `6.` देता है।

प्रत्येक पैराग्राफ के साथ [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) को संरक्षित रखें ताकि नेस्टिंग स्तर बना रहे। वास्तविक मार्कर पूरी पदानुक्रम को एन्कोड नहीं करता: एक नेस्टेड आइटम `c.` लौट सकता है जबकि संयुक्त लेबल जैसे `6.c.` नहीं।

निम्नलिखित स्वतंत्र उदाहरण सूचियों को बनाता है, उन्हें प्रस्तुति में सहेजता है, और प्रस्तुति को पुनः लोड करके प्रत्येक पैराग्राफ का टेक्स्ट, गहराई, बुलेट प्रकार, और वास्तविक मान रिपोर्ट करता है। छोटा नीला चित्र मार्कर इनलाइन SVG से बनाया गया है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // बिना बाहरी छवि फ़ाइल के एक चित्र मार्कर बनाएं।
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

नीचे स्रोत सूचियां प्रदर्शित हैं।

![सूचियां जो 5 से शुरू होती हैं, नेस्टेड अक्षर और रोमन-नंबर आइटम, एक प्रतीक मार्कर, बुलेट के बिना पैराग्राफ, और नीला चित्र मार्कर](actual_bullet_values.png)

रिपोर्ट PowerPoint में दिखाए गए मार्करों से मेल खाती है:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) के लिए, [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` लौटाता है, खाली स्ट्रिंग नहीं। इन प्रकारों को अलग से संभालें: पहला कोई मार्कर नहीं रखता, जबकि दूसरा बुलेट छवि को अलग से निकालने की आवश्यकता रखता है। एक चित्र बुलेट केवल टेक्स्ट मार्कर निकाल कर पुनः उत्पन्न नहीं किया जा सकता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और क्रमांकित सूचियों को PDF या छवियों में निर्यात किया जा सकता है?**

हां। Aspose.Slides सूची स्वरूपण को बरकरार रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) सेटिंग्स की जाँच या अद्यतन करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?**

हां। सूची आइटम का टेक्स्ट Unicode अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियां बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों को समर्थन देते हैं।