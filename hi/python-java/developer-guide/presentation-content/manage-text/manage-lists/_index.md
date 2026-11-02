---
title: Python via Java का उपयोग करके प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 60
url: /hi/python-java/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरीय सूची
- बुलेट बनाएँ
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड सूचियों, चित्र बुलेट, बहु-स्तरीय सूचियाँ और क्रमांकित सूचियों को बनाना और स्वरूपित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियाँ बनाने और स्वरूपित करने की अनुमति देता है। सूची आइटम एक पैराग्राफ होता है जिसका बुलेट सेटिंग पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित किया जाता है।

Use the [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) method to access paragraph-level list settings. मुख्य प्रवेश बिंदु है [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), जो एक [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, चिन्ह, चित्र, रंग, आकार, क्रमांकन शैली और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- कस्टम चिन्ह के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके बहु-स्तरीय सूची बनाएं
- क्रमांकित सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण की जांच और परिवर्तन करें
- पैराग्राफ टेक्स्ट के साथ वास्तविक सूची मार्कर और नंबर पढ़ें

## **बुलेटेड सूची बनाएँ**

बुलेटेड सूची बनाने के लिए, एक [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) में [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें और [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) पर सेट करें। उसके बाद आप बुलेट की उपस्थिति को नियंत्रित करने के लिए [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) और [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) का उपयोग कर सकते हैं।

निम्नलिखित Python कोड दिखाता है कि स्लाइड पर बुलेटेड सूची कैसे बनाई जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![प्रतीक बुलेट](symbol_bullets.png)

## **संख्यांकित सूची बनाएँ**

जब आइटम का क्रम महत्वपूर्ण हो, तो क्रमांकित सूचियों का उपयोग करें। [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) पर सेट करें। आप क्रमांकन स्वरूप को [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) से चुन सकते हैं या सूची को 1 से अलग मान पर शुरू करने के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) का उपयोग कर सकते हैं।

निम्नलिखित Python कोड दिखाता है कि स्लाइड पर क्रमांकित सूची कैसे बनाई जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![संख्यांकित बुलेट](numbered_bullets.png)

## **चित्र बुलेट बनाएँ**

Aspose.Slides आपको नियमित बुलेट चिन्ह को छवि से बदलने की अनुमति देता है। चित्र बुलेट छोटे आकार में पठनीय रहने वाली सरल छवियों के साथ सबसे बेहतर काम करते हैं, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" title="Note" %}}
यदि आप नियमित बुलेट चिन्ह को छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली सरल ग्राफिक चुनें। ऐसी छवियाँ कस्टम बुलेट चिन्ह के रूप में अच्छी तरह काम करती हैं।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) में एक छवि जोड़ें और लौटाए गए छवि ऑब्जेक्ट को [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) को असाइन करें। असाइन करने से पहले [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) पर सेट करें।

मान लीजिए हमारे पास "image.png" नाम की एक छवि है:

![बुलेट के लिए चित्र](picture_for_bullets.png)

निम्नलिखित Python कोड दिखाता है कि स्लाइड पर चित्र बुलेट कैसे बनाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![चित्र बुलेट](picture_bullets.png)

## **बहु-स्तरीय सूची बनाएँ**

सूची आइटम को विभिन्न स्तरों पर रखने के लिए [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 इसके नीचे नेस्टेड है, आदि।

निम्नलिखित Python कोड दिखाता है कि बहु-स्तरीय बुलेटेड सूची कैसे बनाई जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![बहु-स्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची स्वरूपण को बदलने के लिए, लक्ष्य पैराग्राफ तक पहुंचें और उसके [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) सेटिंग्स को अपडेट करें। सूचियों को बनाने के लिए उपयोग की गई वही गुण PPT, PPTX या ODP फ़ाइल से लोड की गई सूचियों की जांच या संशोधन में उपयोग किए जा सकते हैं।

निम्नलिखित Python कोड एक टेक्स्ट फ्रेम में पहले पैराग्राफ को क्रमांकित सूची शैली के साथ बदलता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वास्तविक बुलेट मान पढ़ें**

प्रस्तुति सामग्री निकालते समय, सूची मार्करों को पैराग्राफ टेक्स्ट के साथ रखें। [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) को कॉल करें और प्रभावी बुलेट फ़ॉर्मेट प्राप्त करने के लिए `getBullet` तक पहुँचें। `getActualBulletValue` पढ़ने से पहले उसके `getType` की जाँच करें।

संख्यांकित सूचियों के लिए, इन तीन मानों में अंतर करें:

- `getNumberedBulletStyle` स्वरूप निर्धारित करता है, जैसे बिंदु के साथ अरबी संख्या या बिंदु के साथ छोटे अक्षर।
- `getNumberedBulletStartWith` क्रमांकित पैराग्राफ समूह के लिए प्रारंभिक संख्या निर्दिष्ट करता है।
- `getActualBulletValue` किसी विशेष पैराग्राफ के लिए स्वरूपित मार्कर लौटाता है। उदाहरण के लिए, 5 से शुरू होने वाली सूची में दूसरा आइटम `6.` लौटाएगा।

हर पैराग्राफ के साथ [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) को संरक्षित रखें ताकि उसका नेस्टिंग स्तर बना रहे। वास्तविक मार्कर पूरी पदानुक्रम को एन्कोड नहीं करता: नेस्टेड आइटम `c.` जैसे मान लौटा सकता है न कि `6.c.` जैसा संयुक्त लेबल।

निम्नलिखित स्व-पोर्टेबल उदाहरण सूचियों को बनाता है, उन्हें प्रस्तुति में सहेजता है, और फिर प्रस्तुति को पुनः लोड करके प्रत्येक पैराग्राफ का टेक्स्ट, गहराई, बुलेट प्रकार और वास्तविक मान रिपोर्ट करता है। छोटा नीला चित्र मार्कर इनलाइन SVG से बनाया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # बिना बाहरी छवि फ़ाइल के एक चित्र मार्कर बनाएं।
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

स्रोत सूचियाँ नीचे दर्शाई गई हैं।

![5 से शुरू होने वाली सूचियां, नेस्टेड अक्षर और रोमन-नंबर आइटम, एक प्रतीक मार्कर, बुलेट के बिना पैराग्राफ, और एक नीला चित्र मार्कर](actual_bullet_values.png)

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
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

[BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/) के लिए, `getActualBulletValue` `None` (Java `null`) लौटाता है, न कि खाली स्ट्रिंग। इन प्रकारों को अलग से संभालें: पहला कोई मार्कर नहीं रखता, जबकि दूसरा बुलेट छवि को अलग से निकालने की आवश्यकता होती है। एक चित्र बुलेट केवल टेक्स्ट मार्कर निकालकर पुन: निर्मित नहीं किया जा सकता।

## **FAQ**

**क्या बुलेटेड और क्रमांकित सूचियों को PDF या छवियों में निर्यात किया जा सकता है?**

हां। Aspose.Slides सूची स्वरूपण को बनाए रखता है जब लक्ष्य स्वरूप संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुंचें, उसके [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) सेटिंग्स की जांच या अपडेट करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?**

हां। सूची आइटम टेक्स्ट Unicode अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों का समर्थन करते हैं।