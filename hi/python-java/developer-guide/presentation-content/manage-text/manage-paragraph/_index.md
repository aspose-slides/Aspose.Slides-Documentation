---
title: Python के माध्यम से Java में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधन
type: docs
weight: 40
url: /hi/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- HTML आयात
- टेक्स्ट से HTML
- पैराग्राफ़ से HTML
- पैराग्राफ़ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ़ निर्यात
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ पैराग्राफ़, पोर्शन, बुलेट, क्रमांकित सूचियां, इंडेंट, HTML सामग्री, और पैराग्राफ़ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ, और पोर्शन की पदानुक्रम में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) एक आकृति में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ‑स्तर फ़ॉर्मैटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर फ़ॉर्मैटिंग हो सकता है।

इसलिए एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मैटिंग के साथ टेक्स्ट रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्न चरण तीन पैराग्राफ वाले एक टेक्स्ट फ्रेम को बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें ताकि तीन पोर्शन हो सकें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) के माध्यम से कैरेक्टर‑स्तर फ़ॉर्मैटिंग लागू करें।
9. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण इन चरणों को लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **बुलेटेड और क्रमांकित सूचियां बनाएं**

### **बुलेटेड या क्रमांकित सूची बनाएं**

बुलेट और नंबरिंग संबंधित आइटम को स्कैन करने में आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स [BulletFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित की जाती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक प्रतीक बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Symbol) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Numbered) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह Python उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चित्र बुलेट का उपयोग करें**

चित्र बुलेट आपको प्रतीक या संख्या के बजाय एक कस्टम छवि उपयोग करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट छवि लोड करें और उसे प्रस्तुति की इमेज कलेक्शन में एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Picture) पर सेट करें।
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#getPicture) के माध्यम से छवि असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण एक चित्र बुलेट बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **बहु‑स्तरीय सूची बनाएं**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDepth) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाकर स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाकर उनके बुलेट प्रतीक कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDepth) मान क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Python उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **कस्टम प्रारंभिक मानों के साथ क्रमांकित सूची आइटम सेट करें**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) का उपयोग करके क्रमांकित पैराग्राफ के प्रारंभिक नंबर को निर्धारित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाकर एक स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. संबंधित पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) को क्रमशः `2`, `3`, और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह Python उदाहरण प्रत्येक पैराग्राफ के लिए एक कस्टम प्रारंभिक नंबर असाइन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पैराग्राफ लेआउट और अंत गुणधर्म नियंत्रित करें**

### **पहली‑पंक्ति का इंडेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करके पैराग्राफ की पहली‑पंक्ति का इंडेंट नियंत्रित किया जाता है। यह विधि केवल पहले पंक्ति को पैराग्राफ के बाएँ मार्जिन के सापेक्ष ले जाती है। सकारात्मक मान पहली पंक्ति को दाईं ओर शिफ़्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को ले जाने के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) का उपयोग करें। केवल पहली पंक्ति को ले जाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान लागू करता है ताकि दिखाया जा सके कि पहली‑पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिए विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ इंडेंट कैसे सेट किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफों की पहली‑पंक्ति का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जहाँ पहली पंक्ति बाकी पंक्तियों से बायीं ओर शुरू होती है। Aspose.Slides में इसे आप [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) के साथ बना सकते हैं। पैराग्राफ बॉडी के सापेक्ष पहली पंक्ति को बाईं ओर ले जाने के लिए नकारात्मक मान पास करें।

व्यवहार में, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) को सकारात्मक मान और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) को नकारात्मक मान दें।

यह फ़ॉर्मैटिंग बिब्लियोग्राफी, रेफ़रेंसेज़, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित किया जाना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) को सकारात्मक मान दें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) को नकारात्मक मान दें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफों का हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन गुणधर्म सेट करें**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) पैराग्राफ अंत चिह्न के फ़ॉर्मैटिंग को नियंत्रित करता है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) लोड करके एक स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) बनाएं।
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLatinFont) सेट करें।
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) के साथ फ़ॉर्मैट असाइन करें और प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **रेंडर की गई लाइनों की गणना करें**

लाइन‑ब्रेकिंग और लाइन‑एंड पंक्चर पर प्रभाव डालने वाले पैराग्राफ नियमों के लिए, देखें **[Control Line Breaking](/slides/hi/python-java/text-formatting/#control-line-breaking)** तथा **[Control Hanging Punctuation](/slides/hi/python-java/text-formatting/#control-hanging-punctuation)**।

[Paragraph.getLinesCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा लिये गये लाइनों की संख्या गिनी जा सकती है, जिसमें स्वतः रैपिंग भी शामिल है। यह प्रस्तुति टेम्प्लेट में टेक्स्ट लंबाई और लेआउट की जाँच के लिए उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParagraphs) में एक आइटम होता है और यह कई रेंडर की गई लाइनों को घेरे रख सकता है। पैराग्राफ के भीतर स्पष्ट लाइन‑ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वतः रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। इसलिए पैराग्राफों या लाइन‑ब्रेक अक्षरों की गिनती रेंडर की गई लाइन गिनती नहीं देती।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों को गिनता है, शेप को संकुचित करता है, और फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फ़िट निष्क्रिय है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वतः छोटा किए या शेप को रिसाइज़ किए। शेप की माप इकाई पॉइंट्स में है। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन‑काउंट का योग करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

इन टेक्स्ट और मापों के साथ, शेप को संकरी करने पर लाइन‑काउंट बढ़ता है, जबकि छोटे स्ट्रिंग से बदलने पर घटता है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटो‑फ़िट सेटिंग्स पर निर्भर करती है। टेम्प्लेट जाँचते समय लक्षित वातावरण के फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

लाइन‑काउंट अकेले यह निर्धारित नहीं करता कि टेक्स्ट कंटेनर से बाहर निकलेगा या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एकल लाइन भी रैपिंग बंद होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात करें**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचे और उसके डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) को पास करें।
6. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#exportToHtml) का उपयोग करके पैराग्राफ की चयनित रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) का इंस्टेंस बनाकर वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#exportToHtml) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Python उदाहरण पहले टेक्स्ट शेप से सभी पैराग्राफ निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और इमेज ऑब्जेक्ट लौटाता है। इसे `save` मेथड से फ़ाइल या स्ट्रीम में सहेजा जा सकता है। आपको कंटेनर शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) `None` भी लौट सकता है यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं किया जा सका। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लीजिए हमारे पास `sample.pptx` नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को सामान्य टेक्स्ट शेप में डिफ़ॉल्ट स्केल पर रेंडर करता है और PNG फ़ॉर्मेट में इमेज सहेजता है। `finally` ब्लॉक इमेज को सही तरीके से डिस्पोज़ करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) के ओवरलोड का उपयोग करें जो `scale_x` और `scale_y` पैरामीटर लेता है ताकि क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट किए जा सकें। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना स्केल पर रेंडर करता है, और PNG इमेज के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

स्केल फैक्टर `1` उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर `2` करने पर इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे पिक्सेल चार गुना बढ़ जाते हैं। बड़े फैक्टर ज़ूम या हाई‑रेज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फैक्टर इस्तेमाल करने से पैराग्राफ का आस्पेक्ट रेशियो बरकरार रहता है; अलग‑अलग क्षैतिज व आयताकार फैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

पूरे शेप को [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) से रेंडर करना तब उपयोगी रहता है जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल करने की आवश्यकता हो। केवल पैराग्राफ‑इमेज के लिए, [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह डिसेबल कर सकता हूँ?**

हाँ। [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) को सेट करके रैपिंग को निष्क्रिय किया जा सकता है, जिससे लाइनों का टूटना टेक्स्ट फ्रेम के किनारों पर नहीं होता।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

[Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टेंगल प्राप्त किया जा सकता है। [Portion.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getRect) व्यक्तिगत पोर्शन की बाउंड्स देता है।

**पैराग्राफ एलाइनमेंट (बाएँ, दाएँ, सेंटर या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) पैराग्राफ‑स्तर की सेटिंग है और यह सभी पोर्शन फ़ॉर्मैटिंग के बावजूद पूरे पैराग्राफ पर लागू होती है।

**क्या मैं पैराग्राफ के किसी भाग की प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) सेट करके एक पैराग्राफ में कई भाषाओं का टेक्स्ट रखा जा सकता है।