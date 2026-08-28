---
title: PowerPoint टेक्स्ट पैराग्राफ को Python में प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात करें
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और स्वरूपित करें, सीखें।"
---
## **परिचय**

Aspose.Slides for Python via .NET टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की अनुक्रमिका के रूप में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ‑स्तरीय स्वरूपण तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) एक पैराग्राफ के भीतर टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तरीय स्वरूपण हो सकता है।

इसलिए एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य स्वरूपण के साथ टेक्स्ट रख सकता है, यह कई पोर्शन का उपयोग करके संभव होता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation] क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. स्लाइड पर एक आयताकार [AutoShape] जोड़ें।
4. [TextFrame] तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [Paragraph] ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [Portion] ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion.portion_format] के माध्यम से कैरेक्टर‑स्तरीय स्वरूपण लागू करें।
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

## **बुलेटेड और क्रमांकित सूचियाँ बनाएं**

### **बुलेटेड या क्रमांकित सूची बनाएं**

बुलेट और क्रमांक सम्बन्धित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat] के माध्यम से परिभाषित किया गया है।

1. [Presentation] क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. चुनी गई स्लाइड में एक [AutoShape] जोड़ें।
4. [TextFrame] तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक प्रतीक बुलेट के लिए [Paragraph] बनाएँ।
7. [BulletFormat.type] को [BulletType.SYMBOL] सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग, और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएँ और [BulletFormat.type] को [BulletType.NUMBERED] सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह Python उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

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

चित्र बुलेट्स आपको प्रतीक या संख्या की बजाय एक कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. [Presentation] क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. एक [AutoShape] जोड़ें और उसके [TextFrame] तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रस्तुति की इमेज कलेक्शन में एक [PPImage] के रूप में जोड़ें।
6. एक [Paragraph] बनाएँ और उसका टेक्स्ट सेट करें।
7. [BulletFormat.type] को [BulletType.PICTURE] सेट करें।
8. [BulletFormat.picture] के माध्यम से इमेज असाइन करें और बुलेट की ऊँचाई सेट करें।
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

### **बहु-स्तरीय सूची बनाएं**

[ParagraphFormat.depth] सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर का डेप्थ `0` होता है।

1. एक [Presentation] बनाएं और एक स्लाइड तक पहुँचें।
2. एक [AutoShape] जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाएँ और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [ParagraphFormat.depth] मान को क्रमशः `0`, `1`, `2`, और `3` सेट करें।
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

### **कस्टम मानों से क्रमांकित सूची आइटम्स शुरू करें**

[BulletFormat.numbered_bullet_start_with] का उपयोग करके क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या सेट की जा सकती है।

1. एक [Presentation] बनाएं और एक स्लाइड में एक [AutoShape] जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. प्रत्येक पैराग्राफ के लिए [BulletFormat.numbered_bullet_start_with] को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह Python उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारंभिक संख्या असाइन करता है:

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

### **पहली पंक्ति का इंडेंट सेट करें**

[ParagraphFormat.indent] प्रॉपर्टी का उपयोग पैराग्राफ की पहली पंक्ति के इंडेंट को नियंत्रित करने के लिए करें। यह प्रॉपर्टी केवल पहली पंक्ति को पैराग्राफ की बाईं मार्जिन के सापेक्ष स्थानांतरित करती है। सकारात्मक मान पहली पंक्ति को दाईं दिशा में ले जाता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को ले जाने के लिए [ParagraphFormat.margin_left] का उपयोग करें। केवल पहली पंक्ति को ले जाने के लिए [ParagraphFormat.indent] का प्रयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat.indent] मान लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation] क्लास की एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड पर एक आयताकार [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएँ और उनके लिए विभिन्न [ParagraphFormat.indent] मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि कैसे पैराग्राफ का इंडेंट सेट किया जाए:

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

![पैराग्राफ की पहली पंक्ति का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [ParagraphFormat.indent] प्रॉपर्टी से बनाते हैं। `indent` को नकारात्मक मान पर सेट करने से पहली पंक्ति पैराग्राफ बॉडी के सापेक्ष बाईं ओर चली जाती है।

व्यावहारिक रूप से, [ParagraphFormat.margin_left] पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [ParagraphFormat.indent] उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, एक सकारात्मक `margin_left` मान और नकारात्मक `indent` मान सेट करें।

यह स्वरूपण ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों, और अन्य पैराग्राफों में उपयोगी है जहाँ रैप्ड लाइनों को पहला अक्षर नहीं, बल्कि पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए।

1. [Presentation] क्लास की एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड पर एक आयताकार [AutoShape] जोड़ें।
4. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएँ और प्रत्येक पैराग्राफ के लिए सकारात्मक [ParagraphFormat.margin_left] मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [ParagraphFormat.indent] मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड दिखाता है कि कैसे पैराग्राफ के लिए हैंगिंग इंडेंट सेट किया जाए:

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

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **पैराग्राफ अंत रन गुण सेट करें**

[Paragraph.end_paragraph_portion_format] प्रॉपर्टी पैराग्राफ अंत चिह्न के स्वरूपण को नियंत्रित करती है। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation] लोड करें और एक स्लाइड तक पहुंचें।
2. एक [AutoShape] जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएँ और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat] बनाएँ।
5. [PortionFormat.font_height] और [PortionFormat.latin_font] सेट करें।
6. फ़ॉर्मेट को [Paragraph.end_paragraph_portion_format] को असाइन करें और प्रस्तुति सहेजें।

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

## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.add_from_html] का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जाता है।

1. एक [Presentation] क्लास की इंस्टेंस बनाएँ।
2. एक स्लाइड तक पहुँचें और एक [AutoShape] जोड़ें।
3. शेप के [TextFrame] तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. [ParagraphCollection.add_from_html] को HTML स्ट्रिंग पास करें।
6. संशोधित प्रस्तुति को सहेजें।

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

[ParagraphCollection.export_to_html] का उपयोग करके चुनिंदा पैराग्राफ रेंज को HTML में निर्यात किया जाता है।

1. एक [Presentation] क्लास की इंस्टेंस बनाएँ और वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [AutoShape] खोजें जिसमें टेक्स्ट है।
3. शेप के [TextFrame] तक पहुँचें।
4. [ParagraphCollection.export_to_html] को प्रारम्भ पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ कॉल करें।
5. वापसी में प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

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

[Paragraph] सीधे एक व्यक्तिगत पैराग्राफ को रेंडर करने के लिए `get_image` मेथड प्रदान करता है। यह मेथड एक [IImage] लौटाता है जिसे आप [IImage.save] से फ़ाइल या स्ट्रीम में सहेज सकते हैं। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

`get_image` मेथड `None` भी लौटा सकता है यदि पैराग्राफ उसके पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बॉउंड्स नहीं हैं, या रेंडर नहीं किया जा सकता। इसे सहेजने से पहले परिणाम की जाँच करें और रिटर्नेड इमेज को कंटेक्स्ट मैनेजर के रूप में उपयोग करके उसके संसाधनों को रिलीज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास sample.pptx नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्नलिखित उदाहरण डिफ़ॉल्ट स्केल पर एक सामान्य टेक्स्ट शेप में दूसरे पैराग्राफ को रेंडर करता है और रिटर्नेड इमेज को PNG फॉर्मेट में सहेजता है:

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

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में पैराग्राफ को स्केलिंग के साथ रेंडर करें**

`get_image` में क्षैतिज और लंबवत स्केल फैक्टर पास करके रेंडर किए गए पैराग्राफ के आकार को नियंत्रित किया जा सकता है। नीचे दिया गया उदाहरण एक टेबल बनाता है, उसके पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है:

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

`1` का स्केल फ़ैक्टर उस अक्ष को डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर को `2` देने पर इमेज की चौड़ाई और ऊँचाई लगभग दोगुनी हो जाती है, जिससे पिक्सेल चार गुना होते हैं। बड़े फ़ैक्टर आमतौर पर ज़ूम या हाई‑रेज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन वे मेमोरी उपयोग और फ़ाइल आकार बढ़ा देते हैं। `1` से नीचे के फ़ैक्टर छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फ़ैक्टर का उपयोग करके पैराग्राफ का अनुपात बना रहता है; अलग‑अलग क्षैतिज और लंबवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेچ करते हैं।

[Shape.get_image] के साथ पूरे शेप को रेंडर करना उपयोगी रहता है जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ इमेज के लिए, `Paragraph.get_image` का उपयोग करें।

## **पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह से बंद कर सकता हूँ?**  
हाँ। रैपिंग को निष्क्रिय करने के लिए [TextFrameFormat.wrap_text] सेट करें ताकि लाइनें टेक्स्ट फ्रेम के किनारों पर नहीं टूटें।

**मैं किसी विशिष्ट पैराग्राफ के स्लाइड पर सटीक बाउंड्स कैसे प्राप्त कर सकता हूँ?**  
[Paragraph.get_rect] का उपयोग करके पैराग्राफ का बाउंडिंग आयत प्राप्त करें। [Portion.get_rect] व्यक्तिगत पोर्शन की बाउंड्स प्रदान करता है।

**पैराग्राफ एलाइमेंट (बाएँ, दाएँ, केंद्र, या जस्टिफाई) कहाँ नियंत्रित होता है?**  
[ParagraphFormat.alignment] पैराग्राफ‑स्तर की सेटिंग है और व्यक्तिगत पोर्शन फॉर्मेटिंग के बावजूद पूरे पैराग्राफ पर लागू होती है।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**  
हाँ। व्यक्तिगत पोर्शन के लिए [PortionFormat.language_id] सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।