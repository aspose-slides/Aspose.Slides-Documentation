---
title: Python के माध्यम से Java में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - टेक्स्ट जोड़ें
  - पैराग्राफ जोड़ें
  - टेक्स्ट प्रबंधित करें
  - पैराग्राफ प्रबंधित करें
  - बुलेट प्रबंधित करें
  - पैराग्राफ इंडेंट
  - हैंगिंग इंडेंट
  - पैराग्राफ बुलेट
  - नंबरड सूची
  - बुलेटेड सूची
  - पैराग्राफ गुण
  - HTML आयात करें
  - टेक्स्ट को HTML में
  - पैराग्राफ को HTML में
  - पैराग्राफ को इमेज में
  - टेक्स्ट को इमेज में
  - पैराग्राफ एक्सपोर्ट करें
  - PowerPoint
  - प्रेजेंटेशन
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके पैराग्राफ, पोर्शन, बुलेट, नंबरड सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **सारांश**

Aspose.Slides for Python via Java पाठ को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन और पैराग्राफ-स्तर फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर-लेवल फॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ कई पोर्शन का उपयोग कर विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **एक ही पैराग्राफ में कई पोर्शन बनाएं**

निम्नलिखित चरण तीन पैराग्राफ वाला टेक्स्ट फ्रेम बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन शामिल करने के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) के माध्यम से कैरेक्टर-लेवल फ़ॉर्मेटिंग लागू करें।
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


## **बुलेटेड और नंबरड सूचियाँ बनाएं**

### **बुलेटेड या नंबरड सूची बनाएं**

बुलेट और नंबरिंग संबंधित आइटम्स को स्कैन करने में आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स [BulletFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित की जाती हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. सिम्बॉल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Symbol) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग, और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. एक दूसरा पैराग्राफ बनाएं और [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Numbered) पर सेट करें।
11. नंबरड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह Python उदाहरण एक सिम्बॉल बुलेट और एक नंबरड बुलेट बनाता है:

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


### **चित्र बुलेट्स का उपयोग करें**

चित्र बुलेट्स आपको सिम्बॉल या नंबर के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रस्तुति की इमेज कलेक्शन में [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Picture) पर सेट करें।
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#getPicture) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
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


### **बहु-स्तरीय सूची बनाएं**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDepth) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर का डेप्थ `0` होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट सिम्बॉल सेट करें।
4. उनके [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDepth) मान को क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह Python उदाहरण चार-स्तरीय बुलेटेड सूची बनाता है:

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


### **कस्टम मानों से नंबरड सूची आइटम शुरू करें**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) का उपयोग करके नंबरड पैराग्राफ के प्रारम्भिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाएं और एक स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. तीन नंबरड पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह Python उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारम्भिक नंबर असाइन करता है:

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

## **पैराग्राफ लेआउट और अंत गुण नियंत्रित करें**

### **पहली पंक्ति इंडेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करके पैराग्राफ की पहली पंक्ति इंडेंट को नियंत्रित किया जाता है। यह मेथड केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही हिलाता है। एक सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरी पैराग्राफ को स्थानांतरित करने की आवश्यकता हो तो आप [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) का उपयोग करें। केवल पहली पंक्ति को ही मोव करने के लिए आप [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ इंडेंट कैसे सेट करें:

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
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

![पैराग्राफ की पहली पंक्ति इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट एक पैराग्राफ लेआउट है जिसमें पहली पंक्ति बाकी पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, आप इसे [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) के माध्यम से बना सकते हैं। पैराग्राफ बॉडी के सापेक्ष पहली पंक्ति को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यवहार में, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए आप [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) को सकारात्मक मान और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) को नकारात्मक मान पास करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ में उपयोगी है जहाँ रैप हुई लाइनों को पैराग्राफ बॉडी के नीचे संरेखित करना आवश्यक होता है, पहली पंक्ति के पहले कैरेक्टर के नीचे नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) को सकारात्मक मान से सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट करें:

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

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **पैराग्राफ अंत रन गुण सेट करें**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) पैराग्राफ के अंत मार्क की फ़ॉर्मेटिंग को नियंत्रित करता है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत मार्क को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) बनाएं।
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLatinFont) सेट करें।
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) के साथ फ़ॉर्मेट असाइन करें और प्रस्तुति को सहेजें।

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


## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) में पास करें।
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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#exportToHtml) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाकर वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात किए जाने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#exportToHtml) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Python उदाहरण पहले टेक्स्ट शेप से सभी पैराग्राफ़ निर्यात करता है:

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

### **एक पैराग्राफ को इमेज के रूप में रेंडर करें**

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक इमेज ऑब्जेक्ट लौटाता है। आप `save` मेथड से इसे फ़ाइल या स्ट्रीम में सहेज सकते हैं। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं हो पा रहा है तो [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) `None` लौटा सकता है। सहेजने से पहले परिणाम जांचें और उपयोग के बाद रिटर्नेड इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लीजिये हमारे पास `sample.pptx` नाम की एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स है।

![The text box with three paragraphs](paragraph_to_image_input.png)

निम्नलिखित उदाहरण डिफ़ॉल्ट स्केल पर एक नियमित टेक्स्ट शेप में दूसरे पैराग्राफ को रेंडर करता है और PNG फ़ॉर्मेट में लौटाई गई इमेज को सहेजता है। `finally` ब्लॉक यह सुनिश्चित करता है कि इमेज सही ढंग से डिस्पोज़ हो।

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

`scale_x` और `scale_y` पैरामीटर को स्वीकार करने वाले [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) ओवरलोड का उपयोग करके क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट करें। नीचे दिया गया उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर वह अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर्स के लिए `2` सेट करने पर इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे पिक्सेल चार गुना हो जाते हैं। बड़े फैक्टर्स ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से नीचे के फैक्टर्स छोटा इमेज कम विवरण के साथ बनाते हैं। समान फैक्टर्स का प्रयोग करके पैराग्राफ का पहलू अनुपात बनाए रखें; अलग-अलग क्षैतिज और ऊर्ध्विक फैक्टर्स आउटपुट को स्वतंत्र रूप से स्ट्रेच करेंगे।

पूरा शेप [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) के साथ रेंडर करना उपयोगी रहता है जब आउटपुट में शेप का फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना आवश्यक हो। सिर्फ पैराग्राफ‑केवल इमेज के लिए, [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) प्रयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**  
हाँ। लाइन रैपिंग को अक्षम करने के लिए [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) सेट करें ताकि लाइनों को टेक्स्ट फ्रेम की सीमाओं पर नहीं तोड़ा जाए।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमा कैसे प्राप्त कर सकता हूँ?**  
पैराग्राफ की बाउंडिंग रेक्टेंगल प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का उपयोग करें। व्यक्तिगत पोर्शन की सीमाओं के लिए [Portion.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getRect) उपलब्ध है।

**पैराग्राफ संरेखण (बाएँ, दाएँ, केंद्र, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**  
[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) एक पैराग्राफ‑स्तर की सेटिंग है और व्यक्तिगत पोर्शन फ़ॉर्मेटिंग से स्वतंत्र रूप से पूरे पैराग्राफ पर लागू होती है।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**  
हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, जिससे एक पैराग्राफ कई भाषाओं में टेक्स्ट रख सकता है।