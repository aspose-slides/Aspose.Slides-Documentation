---
title: Python के माध्यम से Java में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
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
- पैराग्राफ इन्डेंट
- हैंगिंग इन्डेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को छवि में
- टेक्स्ट को छवि में
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियां, इन्डेंट, HTML सामग्री, और पैराग्राफ छवियां कैसे बनाएं और स्वरूपित करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java पाठ को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) शेप में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन तथा पैराग्राफ-स्तर के स्वरूपण तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरक्टर‑लेवल स्वरूपण हो सकता है।

इस प्रकार, एक पैराग्राफ कई पोर्शन का उपयोग करके अलग‑अलग फ़ॉन्ट, रंग, आकार और अन्य स्वरूपण के साथ टेक्स्ट रख सकता है।

## **पैराग्राफ बनाएं और स्वरूपित करें**

### **कई पोर्शन वाले पैराग्राफ बनाएं**

निम्नलिखित चरण त्रि‑पैराग्राफ वाले एक टेक्स्ट फ्रेम बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करके दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) ऑब्जेक्ट टेक्स्ट फ्रेम में जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें ताकि उनमें तीन पोर्शन हों। डिफ़ॉल्ट पैराग्राफ में पहले से एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) के माध्यम से कैरक्टर‑लेवल स्वरूपण लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

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


## **बुलेटेड और क्रमांकित सूची बनाएं**

### **बुलेटेड या क्रमांकित सूची बनाएं**

बुलेट और क्रमांकित सूची आइटमों को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक सिम्बल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Symbol) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Numbered) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह Python उदाहरण सिम्बल बुलेट और क्रमांकित बुलेट बनाता है:

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

चित्र बुलेट आपको सिम्बल या संख्या के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसकी [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज लोड करें और उसे प्रेजेंटेशन की इमेज कलेक्शन में [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [BulletFormat.setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setType) को [BulletType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bullettype/#Picture) पर सेट करें।
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#getPicture) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

यह Python उदाहरण चित्र बुलेट बनाता है:

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
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. चार पैराग्राफ बनाकर उनके बुलेट सिम्बॉल कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDepth) मान क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

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


### **क्रमांकित सूची आइटम को कस्टम मान से शुरू करें**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) का प्रयोग करके क्रमांकित पैराग्राफ के प्रारंभिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाकर एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) को स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. प्रत्येक पैराग्राफ के लिए [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ को नियंत्रित करें**

### **पहली‑लाइन इन्डेंट सेट करें**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करके पैराग्राफ की पहली‑लाइन इन्डेंट को नियंत्रित किया जाता है। यह विधि केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली लाइन को ही स्थानांतरित करती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनें पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) का उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान लागू करता है ताकि दिखाया जा सके कि पहली‑लाइन इन्डेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिए विभिन्न [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड पैराग्राफ इन्डेंट सेट करने का उदाहरण दिखाता है:

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

![पैराग्राफ की पहली‑लाइन इन्डेंट](first_line_indent.png)

### **हैंगिंग इन्डेंट सेट करें**

हैंगिंग इन्डेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों से बायीं ओर शुरू होती है। Aspose.Slides में यह प्रभाव [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) के साथ बनाया जाता है। पैराग्राफ बॉडी के सापेक्ष पहली लाइन को बायीं ओर ले जाने हेतु नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) पहली लाइन की उस मार्जिन के सापेक्ष स्थिति तय करता है। हैंगिंग इन्डेंट बनाने हेतु, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) को सकारात्मक मान और [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) को नकारात्मक मान पास करें।

यह स्वरूपण ग्रंथसूची, संदर्भ, शब्दकोष प्रविष्टियों आदि में उपयोगी है जहाँ रैप की गई लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. पैराग्राफ बनाकर प्रत्येक के लिए सकारात्मक मान के साथ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginLeft) सेट करें।
6. हैंगिंग इन्डेंट प्रभाव बनाने हेतु नकारात्मक मान के साथ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setIndent) पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड पैराग्राफ के लिए हैंगिंग इन्डेंट सेट करने का उदाहरण दिखाता है:

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

![पैराग्राफ की हैंगिंग इन्डेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) पैराग्राफ एंड मार्क की स्वरूपण को नियंत्रित करता है। निम्न उदाहरण द्वितीय पैराग्राफ के एंड मार्क को फॉन्ट साईज़ और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) लोड करें और किसी स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट पोर्शन जोड़ें।
4. द्वितीय पैराग्राफ के एंड मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) बनाएँ।
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) और [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLatinFont) सेट करें।
6. फ़ॉर्मेट को [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) के साथ असाइन करें और प्रेजेंटेशन को सहेजें।

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


## **रेंडर की गई लाइनों की गिनती करें**

[Paragraph.getLinesCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getLinesCount) का उपयोग करके टेक्स्ट लेआउट के बाद किसी पैराग्राफ द्वारा उपयोग की गई लाइनों की संख्या गिनी जा सकती है, जिसमें स्वचालित रैपिंग शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट लंबाई और लेआउट की जाँच में उपयोगी है।

एक पैराग्राफ [TextFrame.getParagraphs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParagraphs) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वचालित रैप उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक कैरेक्टर डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर की गिनती रेंडर की गई लाइनों की संख्या नहीं देती।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकीर्ण करता है, फिर टेक्स्ट को एक छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फ़िट बंद है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वचालित रूप से छोटा किए या शेप को रिसाइज़ किए। शेप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़कर टेक्स्ट फ्रेम में कुल लाइनों की गिनती करता है।

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

इन टेक्स्ट और आकारों के साथ, शेप को संकीर्ण करने से लाइनों की संख्या बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने से घटती है। फ़ॉन्ट उपलब्धता, फ़ॉन्ट साइज, मार्जिन, इन्डेंटेशन, रैपिंग और ऑटो‑फ़िट सेटिंग्स के आधार पर सटीक गिनती बदल सकती है। टेम्पलेट की जाँच करते समय लक्ष्य वातावरण के लिए इच्छित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन काउंट यह निर्धारित नहीं करता कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; जब रैपिंग बंद हो तो एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री का आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) का उपयोग करके HTML मार्क‑अप को टेक्स्ट फ्रेम के पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
3. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#addFromHtml) में पास करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह Python उदाहरण टेक्स्ट फ्रेम में HTML आयात करता है:

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

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाकर वांछित प्रेजेंटेशन लोड करें।
2. स्लाइड तक पहुँचें और वह [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
4. प्रारम्भिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphcollection/#exportToHtml) को कॉल करें।
5. लौटे हुए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह Python उदाहरण पहली टेक्स्ट शेप के सभी पैराग्राफ निर्यात करता है:

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

### **पैराग्राफ को छवि के रूप में रेंडर करें**

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक इमेज ऑब्जेक्ट लौटाता है। परिणाम को `save` मेथड के साथ फ़ाइल या स्ट्रीम में सहेजा जा सकता है। शेप को पूरी तरह रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ को उसके पैरेंट कलेक्शन में नहीं पाया जाता, वैध रेंडर बाउंड नहीं होते, या रेंडर नहीं किया जा सकता, तो [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) `None` लौटाता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास `sample.pptx` नामक एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाला एक टेक्स्ट बॉक्स है।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर दूसरे पैराग्राफ को रेंडर करता है और PNG फॉर्मेट में इमेज सहेजता है। `finally` ब्लॉक इमेज को सही तरीके से डिस्पोज़ करता है।

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

[Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) ओवरलोड का प्रयोग करें जो `scale_x` और `scale_y` पैरामीटर लेता है ताकि क्षैतिज और लंबवत स्केल फैक्टर सेट किए जा सकें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना स्केल करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

स्केल फैक्टर `1` उस अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर के लिए `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे पिक्सेल चार गुना होते हैं। बड़े फैक्टर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से नीचे के फैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फैक्टर का प्रयोग करके पैराग्राफ का पहलू अनुपात बरकरार रखें; विभिन्न क्षैतिज‑वर्टिकल फैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करेंगे।

[Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) के साथ पूरे शेप को रेंडर करना उपयोगी है जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ‑केवल इमेज के लिए [Paragraph.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) का प्रयोग करें।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह डिसेबल कर सकता हूँ?**

हाँ। रैपिंग को डिसेबल करने के लिए [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) को सेट करें, ताकि लाइनों को टेक्स्ट फ्रेम के किनारों पर नहीं तोड़ें।

**मैं किसी विशिष्ट पैराग्राफ की सटीक ऑन‑स्लाइड बाउंड्स कैसे प्राप्त करूँ?**

[Paragraph.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getRect) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। व्यक्तिगत पोर्शन की बाउंड्स के लिए [Portion.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getRect) उपयोग करें।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, मध्य, या जस्टिफ़ाई) कहाँ नियंत्रित किया जाता है?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का स्वरूपण कुछ भी हो।

**क्या मैं पैराग्राफ के किसी हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।