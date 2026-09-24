---
title: Python में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - पाठ जोड़ें
  - पैराग्राफ जोड़ें
  - टेक्स्ट प्रबंधित करें
  - पैराग्राफ प्रबंधित करें
  - बुलेट प्रबंधित करें
  - पैराग्राफ इंडेंट
  - हैंंगिंग इंडेंट
  - पैराग्राफ बुलेट
  - क्रमांकित सूची
  - बुलेटेड सूची
  - पैराग्राफ गुण
  - HTML आयात करें
  - टेक्स्ट को HTML में
  - पैराग्राफ को HTML में
  - पैराग्राफ को इमेज में
  - टेक्स्ट को इमेज में
  - पैराग्राफ निर्यात करें
  - PowerPoint
  - प्रेज़ेंटेशन
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज बनाना और स्वरूपित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via .NET टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) टेक्स्ट कंटेनर को एक आकार में दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन तथा पैराग्राफ-स्तरीय स्वरूपण तक पहुंच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और अक्षर-स्तरीय स्वरूपण हो सकता है।

इस प्रकार एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य स्वरूपण वाले टेक्स्ट को सम्मिलित कर सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित चरण तीन पैराग्राफ वाले टेक्स्ट फ्रेम को बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके सूचकांक के द्वारा संबंधित स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करके दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) वस्तुएँ टेक्स्ट फ्रेम में जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) वस्तुएँ जोड़ें ताकि प्रत्येक में तीन पोर्शन हों। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/portion_format/) के माध्यम से अक्षर-स्तरीय स्वरूपण लागू करें।
9. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण इन चरणों को लागू करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **बुलिटेड और क्रमांकित सूचियां बनाना**

### **बुललेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांक संबंधित आइटम को स्कैन करना आसान बनाते हैं। Aspose.Slides में सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके सूचकांक के द्वारा संबंधित स्लाइड तक पहुंचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
6. एक सिम्बल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/type/) को [BulletType.SYMBOL](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएं और [BulletFormat.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/type/) को [BulletType.NUMBERED](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह Python उदाहरण एक सिम्बल बुलेट और एक क्रमांकित बुलेट बनाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **चित्र बुलेट्स का उपयोग करें**

चित्र बुलेट आपको सिम्बल या नंबर के बजाय एक कस्टम छवि का उपयोग करने देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके सूचकांक के द्वारा संबंधित स्लाइड तक पहुंचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें और उसका [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
5. बुलेट छवि लोड करें और उसे प्रस्तुति के इमेज संग्रह में एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/type/) को [BulletType.PICTURE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat.picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/picture/) के माध्यम से छवि असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण एक चित्र बुलेट बनाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **बहुस्तरीय सूची बनाएं**

[ParagraphFormat.depth](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/depth/) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट सिम्बॉल कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.depth](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/depth/) मानों को क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह Python उदाहरण चार स्तर की बुलेटेड सूची बनाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **कस्टम मानों से क्रमांकित सूची आइटम शुरू करें**

क्रमांकित पैराग्राफ के लिए प्रारंभिक नंबर सेट करने हेतु [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएं और एक स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिए [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) को क्रमशः `2`, `3` और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह Python उदाहरण प्रत्येक पैराग्राफ के लिए कस्टम प्रारंभिक नंबर असाइन करता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ लेआउट और अंत गुण नियंत्रित करें**

### **पहली पंक्ति इंडेंट सेट करें**

[ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ की पहली पंक्ति इंडेंट नियंत्रित की जाती है। यह प्रॉपर्टी केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही ले जाती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को ले जाना हो तो आप [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) का उपयोग करें। केवल पहली पंक्ति को ले जाना हो तो [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मानों को लागू करके दिखाता है कि पहली पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएं।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ इंडेंट सेट करने का तरीका दर्शाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ की पहली-पंक्ति इंडेंट](first_line_indent.png)

### **हैँगिंग इंडेंट सेट करें**

हैँगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों के बाएँ स्थित होती है। Aspose.Slides में आप इस प्रभाव को [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी से बना सकते हैं। `indent` को नकारात्मक मान पर सेट करने से पहली पंक्ति पैराग्राफ बॉडी के सापेक्ष बाएँ की ओर चलती है।

व्यवहार में, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, जबकि [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष परिभाषित करता है। हैँगिंग इंडेंट बनाने हेतु एक सकारात्मक `margin_left` मान और नकारात्मक `indent` मान सेट करें।

यह स्वरूपण ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और उन पैराग्राफ़ों के लिए उपयोगी है जहाँ लिपटनी वाली पंक्तियाँ पैराग्राफ बॉडी के नीचे संरेखित होनी चाहिए, न कि पहली पंक्ति के प्रथम अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएं।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) मान सेट करें।
6. हैँगिंग इंडेंट प्रभाव बनाने हेतु नकारात्मक [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ के लिए हैँगिंग इंडेंट सेट करने का तरीका दिखाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करें**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) प्रॉपर्टी पैराग्राफ अंत मार्क के स्वरूपण को नियंत्रित करती है। निम्न उदाहरण दूसरे पैराग्राफ के अंत मार्क को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) बनाएं।
5. [PortionFormat.font_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/font_height/) और [PortionFormat.latin_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/latin_font/) सेट करें।
6. स्वरूप को [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) को असाइन करें और प्रस्तुति को सहेजें।

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **रेंडर की गई लाइनों की गिनती**

[Paragraph.get_lines_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/get_lines_count/) का उपयोग करके टेक्स्ट लेआउट के बाद किसी पैराग्राफ द्वारा घेर ली गई लाइनों की संख्या गिनी जा सकती है, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट लंबाई और लेआउट की जाँच के लिए उपयोगी है।

एक पैराग्राफ [TextFrame.paragraphs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/paragraphs/) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई पंक्ति बनाएगा, लेकिन नया पैराग्राफ नहीं बनाएगा। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनने से रेंडर की गई लाइन गिनती नहीं मिलती।

निम्न उदाहरण एक टेक्स्ट आकार बनाता है, उसकी लाइनों की गिनती करता है, आकार को संकीर्ण करता है, और फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फिट निष्क्रिय है ताकि आकार की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वचालित रूप से छोटा किए या आकार को पुनः आकारित किए। आकार की माप इकाइयाँ पॉइंट में हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन गिनती को जोड़ता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

इन टेक्स्ट और इन मापों के साथ, आकार को संकीर्ण करने से लाइन गिनती बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने पर कम होती है। सटीक गिनतियाँ फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटो‑फिट सेटिंग्स पर निर्भर करती हैं। टेम्पलेट की जाँच करते समय लक्ष्य माहौल के लिए इरादा किए गए फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर निकलेगा या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फिट व्यवहार भी महत्वपूर्ण हैं; यहां तक कि एक ही लाइन भी तब बहुत बड़ी हो सकती है जब रैपिंग निष्क्रिय हो।

## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphcollection/add_from_html/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. एक स्लाइड तक पहुंचें और एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphcollection/add_from_html/) को पास करें।
6. संशोधित प्रस्तुति को सहेजें।

यह Python उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphcollection/export_to_html/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का उदाहरण बनाएं और वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुंचें और वह [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphcollection/export_to_html/) को कॉल करें।
5. लौटाई गई HTML स्ट्रिंग को एक फ़ाइल में लिखें।

यह Python उदाहरण पहले टेक्स्ट आकार से सभी पैराग्राफ निर्यात करता है:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) `get_image` मेथड प्रदान करता है जिससे एक व्यक्तिगत पैराग्राफ को सीधे रेंडर किया जा सकता है। यह मेथड एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) लौटाता है जिसे आप [IImage.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/save/) के साथ फ़ाइल या स्ट्रीम में सहेज सकते हैं। आपको समग्र आकार को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ नहीं मिला, कोई वैध रेंडरिंग बाउंड नहीं है, या रेंडर नहीं किया जा सकता, तो `get_image` `None` लौटाता है। सहेजने से पहले परिणाम की जाँच करें और संसाधनों को मुक्त करने हेतु इमेज को कॉन्टेक्स्ट मैनेजर के रूप में उपयोग करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास `sample.pptx` नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला आकार तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर सामान्य टेक्स्ट आकार में दूसरे पैराग्राफ को रेंडर करता है और PNG फ़ॉर्मेट में लौटाई गई इमेज को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

`get_image` को क्षैतिज और लम्बवत स्केल फ़ैक्टर पास करके रेंडर किए गए पैराग्राफ का आकार नियंत्रित किया जाता है। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

`1` का स्केल फ़ैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर को `2` पर सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर सामान्यतः ज़ूम या उच्च‑रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फ़ैक्टर का उपयोग करके पैराग्राफ का आस्पेक्ट रेशियो सुरक्षित रखें; अलग‑अलग क्षैतिज और लम्बवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

यदि आउटपुट में आकार की भराव, सीमा या अन्य दृश्य संदर्भ शामिल करना आवश्यक हो तो [Shape.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/) के साथ पूरे आकार को रेंडर करना उपयोगी रहता है। केवल पैराग्राफ‑इमेज के लिए `Paragraph.get_image` का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**  
हाँ। रैपिंग को अक्षम करने के लिए [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/) सेट करें ताकि लाइनों को टेक्स्ट फ्रेम के किनारों पर नहीं तोड़ा जाए।

**मैं किसी विशिष्ट पैराग्राफ की सटीक ऑन‑स्लाइड सीमाएँ कैसे प्राप्त करूँ?**  
[Paragraph.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/get_rect/) का उपयोग करके पैराग्राफ की बाउंडिंग आयत प्राप्त करें। व्यक्तिगत पोर्शन की सीमाएँ प्राप्त करने के लिए [Portion.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_rect/) देखें।

**पैराग्राफ संरेखण (बायाँ, दायाँ, केंद्र या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**  
[ParagraphFormat.alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) एक पैराग्राफ‑स्तरीय सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का स्वरूपण कुछ भी हो।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**  
हाँ। व्यक्तिगत पोर्शन के लिए [PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) सेट करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सके।