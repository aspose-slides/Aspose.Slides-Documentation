---
title: Python में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/python-net/manage-paragraph/
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
- पैराग्राफ़ प्रॉपर्टीज़
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को छवि में
- टेक्स्ट को छवि में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पैराग्राफ़ फ़ॉर्मेटिंग में निपुण बनें—PowerPoint और OpenDocument प्रस्तुतियों में संरेखन, स्पेसिंग और शैली को अनुकूलित करें, Python में दर्शकों को आकर्षित करने के लिए."
---
## **परिचय**

Aspose.Slides वह क्लासेज़ प्रदान करता है जिनकी आपको Python में PowerPoint टेक्स्ट के साथ काम करने की आवश्यकता है।

* Aspose.Slides वह [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) क्लास प्रदान करता है जो टेक्स्ट फ्रेम ऑब्जेक्ट बनाता है। एक `TextFrame` ऑब्जेक्ट एक या अधिक पैराग्राफ़ रख सकता है (प्रत्येक पैराग्राफ़ कैरिज रिटर्न द्वारा अलग किया जाता है)।
* Aspose.Slides वह [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास प्रदान करता है जो पैराग्राफ़ ऑब्जेक्ट बनाता है। एक `Paragraph` ऑब्जेक्ट एक या अधिक टेक्स्ट पोर्शन रख सकता है।
* Aspose.Slides वह [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) क्लास प्रदान करता है जो टेक्स्ट पोर्शन ऑब्जेक्ट बनाता है और उनके फ़ॉर्मेटिंग प्रॉपर्टीज़ को निर्दिष्ट करता है।

एक `Paragraph` ऑब्जेक्ट अपने अंतर्निहित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग प्रॉपर्टीज़ वाले टेक्स्ट को संभाल सकता है।

## **एकाधिक पोर्शन वाले कई पैराग्राफ़ जोड़ें**

ये चरण दर्शाते हैं कि कैसे तीन पैराग्राफ़ वाला टेक्स्ट फ़्रेम जोड़ें, प्रत्येक में तीन पोर्शन हों:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. इंडेक्स द्वारा लक्ष्य स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. उस [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) से जुड़ा हुआ [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त करें।
1. दो [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) ऑब्जेक्ट बनाएं और उन्हें [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ़ कलेक्शन में जोड़ें (डिफ़ॉल्ट पैराग्राफ़ के साथ मिलकर यह तीन पैराग्राफ़ बनाता है)।
1. प्रत्येक पैराग्राफ़ के लिए तीन [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) ऑब्जेक्ट बनाएं और उन्हें उस पैराग्राफ़ की पोर्शन कलेक्शन में जोड़ें।
1. प्रत्येक पोर्शन के लिए टेक्स्ट सेट करें।
1. प्रत्येक टेक्स्ट पोर्शन पर इच्छित फ़ॉर्मेटिंग लागू करें, जो [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) द्वारा उजागर प्रॉपर्टीज़ से संभव है।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python कोड इन चरणों को लागू करता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास को इंस्टैंशिएट करके नई PPTX फ़ाइल बनाएँ।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक आयताकार AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShape के TextFrame तक पहुँचें।
    text_frame = shape.text_frame

    # पैराग्राफ़ और पोर्शन बनाते हैं; फ़ॉर्मेटिंग नीचे लागू की गई है।
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX को डिस्क पर सहेजें।
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ जानकारी को तेज़ी और दक्षता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ़ अक्सर पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. उसके इंडेक्स द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएं।
1. पैराग्राफ़ के बुलेट टाइप को `SYMBOL` सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
1. पैराग्राफ़ का टेक्स्ट सेट करें।
1. पैराग्राफ़ के लिए बुलेट इंडेंट सेट करें।
1. बुलेट का रंग सेट करें।
1. बुलेट का आकार (ऊँचाई) सेट करें।
1. पैराग्राफ़ को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ़ कलेक्शन में जोड़ें।
1. दूसरा पैराग्राफ़ जोड़ें और चरण 7‑12 दोहराएँ।
1. प्रस्तुति को सहेजें।

यह Python कोड बुलेटेड पैराग्राफ़ जोड़ने का तरीका दर्शाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation का एक इंस्टैंस बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक AutoShape जोड़ें और उसका एक्सेस करें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape के टेक्स्ट फ्रेम तक पहुँचें।
    text_frame = shape.text_frame

    # डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # एक पैराग्राफ़ बनाएं।
    paragraph = slides.Paragraph()

    # पैराग्राफ़ के बुलेट स्टाइल और प्रतीक सेट करें।
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # पैराग्राफ़ का टेक्स्ट सेट करें।
    paragraph.text = "Welcome to Aspose.Slides"

    # बुलेट इंडेंट सेट करें।
    paragraph.paragraph_format.indent = 25

    # बुलेट का रंग सेट करें।
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # बुलेट की ऊँचाई सेट करें।
    paragraph.paragraph_format.bullet.height = 100

    # पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph)

    # दूसरा पैराग्राफ़ बनाएं।
    paragraph2 = slides.Paragraph()

    # पैराग्राफ़ के बुलेट प्रकार और शैली सेट करें।
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # पैराग्राफ़ का टेक्स्ट सेट करें।
    paragraph2.text = "This is numbered bullet"

    # बुलेट इंडेंट सेट करें।
    paragraph2.paragraph_format.indent = 25

    # बुलेट का रंग सेट करें।
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # बुलेट की ऊँचाई सेट करें।
    paragraph2.paragraph_format.bullet.height = 100

    # पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph2)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **चित्र बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ जानकारी को तेज़ी और दक्षता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र बुलेट पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. उसके इंडेक्स द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएं।
1. एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) में छवि लोड करें।
1. बुलेट टाइप को [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) सेट करें और छवि असाइन करें।
1. पैराग्राफ़ का टेक्स्ट सेट करें।
1. बुलेट के लिए पैराग्राफ़ इंडेंट सेट करें।
1. बुलेट का रंग सेट करें।
1. बुलेट की ऊँचाई सेट करें।
1. नया पैराग्राफ़ [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ़ कलेक्शन में जोड़ें।
1. दूसरा पैराग्राफ़ जोड़ें और चरण 8‑12 दोहराएँ।
1. प्रस्तुति को सहेजें।

यह Python कोड चित्र बुलेट्स जोड़ने और प्रबंधित करने का तरीका दर्शाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # बुलेट छवि लोड करें।
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # एक AutoShape जोड़ें और उसका एक्सेस करें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape के TextFrame तक पहुँचें।
    text_frame = auto_shape.text_frame

    # डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # नया पैराग्राफ़ बनाएं।
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # पैराग्राफ़ के बुलेट प्रकार को Picture सेट करें और छवि असाइन करें।
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # बुलेट की ऊँचाई सेट करें।
    paragraph.paragraph_format.bullet.height = 100

    # पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # प्रस्तुति को PPT फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **बहु‑स्तरीय बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ जानकारी को तेज़ी और दक्षता से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहु‑स्तरीय बुलेट पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. उसके इंडेक्स द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. उस [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएं और उसकी गहराई को 0 सेट करें।
1. उसी क्लास से दूसरा पैराग्राफ़ बनाएं और उसकी गहराई को 1 सेट करें।
1. तीसरा पैराग्राफ़ बनाएं और उसकी गहराई को 2 सेट करें।
1. चौथा पैराग्राफ़ बनाएं और उसकी गहराई को 3 सेट करें।
1. नए पैराग्राफ़ को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ़ कलेक्शन में जोड़ें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड बहु‑स्तरीय बुलेट्स को जोड़ने और प्रबंधित करने का तरीका दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेजेंटेशन इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]
    
    # एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape का TextFrame एक्सेस करें।
    text_frame = auto_shape.text_frame
    
    # डिफ़ॉल्ट पैराग्राफ़ साफ़ करें।
    text_frame.paragraphs.clear()

    # पहला पैराग्राफ़ जोड़ें।
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph1.paragraph_format.depth = 0

    # दूसरा पैराग्राफ़ जोड़ें।
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph2.paragraph_format.depth = 1

    # तीसरा पैराग्राफ़ जोड़ें।
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph3.paragraph_format.depth = 2

    # चौथा पैराग्राफ़ जोड़ें।
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph4.paragraph_format.depth = 3

    # पैराग्राफ़ को संग्रह में जोड़ें।
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम क्रमांकित सूचियों के साथ पैराग्राफ़ प्रबंधित करें**

[BulletFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/) क्लास `numbered_bullet_start_with` प्रॉपर्टी (और अन्य) प्रदान करता है जिससे पैराग्राफ़ के लिए कस्टम नंबरिंग और फ़ॉर्मेटिंग को नियंत्रित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. उन स्लाइड तक पहुँचें जहाँ पैराग्राफ़ जोड़ने हैं।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. पहला [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाएं और `numbered_bullet_start_with` को 2 सेट करें।
1. दूसरा [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाएं और `numbered_bullet_start_with` को 3 सेट करें।
1. तीसरा [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाएं और `numbered_bullet_start_with` को 7 सेट करें।
1. पैराग्राफ़ को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) की कलेक्शन में जोड़ें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड कस्टम क्रमांकन और फ़ॉर्मेटिंग के साथ पैराग्राफ़ जोड़ने व प्रबंधित करने को दर्शाता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape जोड़ें और उसका एक्सेस करें।
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape का TextFrame एक्सेस करें।
    text_frame = shape.text_frame

    # डिफ़ॉल्ट मौजूदा पैराग्राफ़ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # पहला क्रमांकित आइटम बनाएं (शुरुआत 2 से, गहराई स्तर 4)।
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # दूसरा क्रमांकित आइटम बनाएं (शुरुआत 3 से, गहराई स्तर 4)।
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # तीसरा क्रमांकित आइटम बनाएं (शुरुआत 7 से, गहराई स्तर 4)।
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ़ के प्रथम‑लाइन इंडेंट सेट करें**

[ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ़ के प्रथम‑लाइन इंडेंट को नियंत्रित किया जाता है। यह प्रॉपर्टी केवल पैराग्राफ़ के बाएँ मार्जिन के सापेक्ष पहली लाइन को ही स्थानांतरित करती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनें पैराग्राफ़ बॉडी के साथ संगत रहती हैं।

जब आपको पूरे पैराग्राफ़ को ले जाना हो तो [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) इस्तेमाल करें। केवल पहली लाइन को ले जाने के लिए [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) का प्रयोग करें।

निम्न उदाहरण कई पैराग्राफ़ बनाता है और विभिन्न `indent` मानों को लागू करता है ताकि प्रथम‑लाइन इंडेंट पैराग्राफ़ लेआउट को कैसे प्रभावित करता है दिखाया जा सके।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
5. कई पैराग्राफ़ बनाएं और उनके लिए विभिन्न [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
6. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ़ इंडेंट सेट करने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ़ों का प्रथम‑लाइन इंडेंट](first_line_indent.png)

## **पैराग्राफ़ के हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह लेआउट है जिसमें पहली लाइन बाकी लाइनों से बायीं ओर शुरू होती है। Aspose.Slides में आप यह प्रभाव [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी से बना सकते हैं। `indent` को नकारात्मक मान सेट करने से पहली लाइन पैराग्राफ़ बॉडी के सापेक्ष बाएँ शिफ्ट होती है।

व्यवहार में, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) पैराग्राफ़ बॉडी की बायीं स्थिति तय करता है, और [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष तय करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `margin_left` और नकारात्मक `indent` सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों में उपयोगी है जहाँ लिपटी हुई लाइनों को पैराग्राफ़ बॉडी के नीचे संरेखित करना आवश्यक होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
5. प्रत्येक पैराग्राफ़ के लिए सकारात्मक [margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
7. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ़ के हैंगिंग इंडेंट को सेट करने का तरीका दिखाता है:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ़ों का हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ़ के अंत‑पोर्टेशन फ़ॉर्मेट प्रबंधित करें**

जब आपको पैराग्राफ़ के “अंत” (अंतिम टेक्स्ट पोर्शन के बाद लागू होने वाला फ़ॉर्मेट) को नियंत्रित करने की आवश्यकता हो, तो `end_paragraph_portion_format` प्रॉपर्टी का उपयोग करें। नीचे दिया गया उदाहरण दूसरे पैराग्राफ़ के अंत में बड़े Times New Roman फ़ॉन्ट को लागू करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) फ़ाइल बनाएं या खोलें।
1. इंडेक्स द्वारा लक्ष्य स्लाइड प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) का उपयोग करके दो पैराग्राफ़ बनाएं।
1. एक [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) बनाएं, 48‑pt Times New Roman सेट करें और इसे पैराग्राफ़ के अंत‑पोर्टेशन फ़ॉर्मेट के रूप में लागू करें।
1. इसे पैराग्राफ़ के `end_paragraph_portion_format` को असाइन करें (दूसरे पैराग्राफ़ के अंत पर लागू होता है)।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दूसरे पैराग्राफ़ के अंत‑पोर्टेशन फ़ॉर्मेट को सेट करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML टेक्स्ट को पैराग्राफ़ में आयात करें**

Aspose.Slides पैराग्राफ़ में HTML टेक्स्ट को आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं।
1. इंडेक्स द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. उस [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. स्रोत HTML फ़ाइल पढ़ें।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएं।
1. HTML सामग्री को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) की पैराग्राफ़ कलेक्शन में जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न Python कोड इन चरणों को लागू करके HTML टेक्स्ट को पैराग्राफ़ में आयात करता है।

```python
import aspose.slides as slides

# एक खाली Presentation इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # प्रस्तुति की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML सामग्री को समायोजित करने के लिए एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ़ साफ़ करें।
    shape.text_frame.paragraphs.clear()

    # HTML फ़ाइल लोड करें।
    with open("file.html", "rt") as html_stream:
        # HTML फ़ाइल से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ें।
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # प्रस्तुति को सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ़ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) का instance बनाएं और लक्ष्य प्रस्तुति लोड करें।
1. इंडेक्स द्वारा इच्छित स्लाइड तक पहुँचें।
1. वह शैप चुनें जिसमें निर्यात करने के लिए टेक्स्ट है।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. HTML आउटपुट लिखने के लिए फ़ाइल स्ट्रीम खोलें।
1. प्रारंभिक इंडेक्स निर्दिष्ट करें और आवश्यक पैराग्राफ़ निर्यात करें।

यह Python उदाहरण पैराग्राफ़ टेक्स्ट को HTML में निर्यात करने का तरीका दर्शाता है।

```python
import aspose.slides as slides

# प्रेजेंटेशन फ़ाइल लोड करें।
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # प्रेजेंटेशन की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # लक्ष्य शैप इंडेक्स।
    index = 0

    # इंडेक्स द्वारा शैप तक पहुँचें।
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # निर्यात के लिए प्रारंभिक पैराग्राफ़ इंडेक्स और कुल पैराग्राफ़ संख्या प्रदान करके पैराग्राफ डेटा को HTML में लिखें।
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **पैराग्राफ़ को छवि के रूप में सहेजें**

इस खंड में हम दो उदाहरणों को देखें जो दिखाते हैं कि कैसे [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास द्वारा प्रतिनिधित्व किया गया टेक्स्ट पैराग्राफ़ को छवि के रूप में सहेजा जा सकता है। दोनों उदाहरणों में पैराग्राफ़ वाला शैप का चित्र प्राप्त किया जाता है, शैप में पैराग्राफ़ की सीमाएँ गणना की जाती हैं, और उसे बिटमैप छवि के रूप में निर्यात किया जाता है। ये तरीकों से आप PowerPoint प्रस्तुति के विशिष्ट टेक्स्ट भागों को अलग‑अलग छवियों के रूप में निकाल सकते हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकते हैं।

मान लीजिए हमारे पास sample.pptx नामक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शैप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरा पैराग्राफ़ छवि के रूप में प्राप्त करते हैं। इसके लिए हम प्रस्तुति की पहली स्लाइड से शैप की छवि निकालते हैं और फिर शैप के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ़ की सीमाएँ गणना करते हैं। पैराग्राफ़ को नई बिटमैप छवि पर फिर से ड्रॉ किया जाता है और PNG प्रारूप में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको एक विशिष्ट पैराग्राफ़ को अलग छवि के रूप में सहेजना हो और टेक्स्ट के आकार और फ़ॉर्मेटिंग को बरकरार रखना हो।

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # शेप को मेमोरी में एक बिटमैप के रूप में सहेजें।
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से एक शेप बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # आउटपुट छवि के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

परिणाम:

![पैराग्राफ़ छवि](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पहले दृष्टिकोण को स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। शैप को प्रस्तुति से निकाला जाता है और `2` स्केलिंग फ़ैक्टर के साथ छवि के रूप में सहेजा जाता है। इस प्रकार पैराग्राफ़ निर्यात करते समय उच्च रेज़ॉल्यूशन आउटपुट मिलता है। फिर स्केल को ध्यान में रखकर पैराग्राफ़ की सीमाएँ गणना की जाती हैं। स्केलिंग तब उपयोगी होती है जब अधिक विस्तृत छवि की आवश्यकता होती है, जैसे उच्च‑गुणवत्ता वाले प्रिंट सामग्री में।

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # शेप को मेमोरी में एक बिटमैप के रूप में सहेजें।
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से एक शेप बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ़ की सीमाएँ गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # आउटपुट छवि के लिए निर्देशांक और आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम में लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/)) का उपयोग करके रैपिंग बंद करें ताकि लाइनें फ्रेम के किनारों पर नहीं टूटें।

**मैं एक विशिष्ट पैराग्राफ़ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त करूँ?**

आप पैराग्राफ़ (और यहाँ तक कि एकल पोर्शन) के बाउंडिंग रेक्टेंगल को प्राप्त कर सकते हैं जिससे उसकी सटीक स्थिति और आकार पता चलता है।

**पैराग्राफ़ संरेखण (बाएं/दाएं/केंद्र/जस्टिफाई) कहाँ नियंत्रित होता है?**

[Alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) एक पैराग्राफ़‑स्तर सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/) में होती है; यह पूरे पैराग्राफ़ पर लागू होती है चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ़ के केवल एक हिस्से (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/)), इसलिए एक ही पैराग्राफ़ में कई भाषाओं का सह-अस्तित्व संभव है।