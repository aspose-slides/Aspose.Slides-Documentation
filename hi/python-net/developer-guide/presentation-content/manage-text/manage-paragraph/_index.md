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
- पैराग्राफ से छवि
- टेक्स्ट से छवि
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पैराग्राफ स्वरूपण में महारत हासिल करें—PowerPoint और OpenDocument प्रस्तुतियों में संरेखण, स्पेसिंग और शैली को ऑप्टिमाइज़ करें, ताकि दर्शकों को आकर्षित किया जा सके।"
---
## **परिचय**

Aspose.Slides उन क्लासों को प्रदान करता है जिनकी आपको Python में PowerPoint पाठ के साथ काम करने के लिए आवश्यकता है।

* Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) क्लास प्रदान करता है जो टेक्स्ट फ्रेम ऑब्जेक्ट बनाने के लिए उपयोग होती है। एक `TextFrame` ऑब्जेक्ट में एक या अधिक पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा अलग किया जाता है)।
* Aspose.Slides [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास प्रदान करता है जो पैराग्राफ ऑब्जेक्ट बनाने के लिए उपयोग होती है। एक `Paragraph` ऑब्जेक्ट में एक या अधिक टेक्स्ट हिस्से हो सकते हैं।
* Aspose.Slides [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) क्लास प्रदान करता है जो टेक्स्ट पोर्शन ऑब्जेक्ट बनाने और उनके स्वरूपण गुण निर्धारित करने के लिए उपयोग होती है।

`Paragraph` ऑब्जेक्ट अपने अंतर्निहित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न स्वरूपण गुणों वाले पाठ को संभाल सकता है।

## **स्थापना**

```bash
pip install aspose.slides
```

## **कई हिस्सों वाले कई पैराग्राफ जोड़ें**

इन चरणों में वह तरीका दिखाया गया है जिससे आप ऐसा टेक्स्ट फ्रेम जोड़ सकते हैं जिसमें तीन पैराग्राफ हों, प्रत्येक में तीन हिस्से हों:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स से लक्ष्य स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. उस [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) से जुड़ा [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त करें।
1. दो [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) ऑब्जेक्ट बनाकर उन्हें [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ संग्रह में जोड़ें (डिफ़ॉल्ट पैराग्राफ के साथ मिलकर तीन पैराग्राफ बनते हैं)।
1. प्रत्येक पैराग्राफ के लिए तीन [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) ऑब्जेक्ट बनाकर उन्हें उस पैराग्राफ के पोर्शन संग्रह में जोड़ें।
1. प्रत्येक पोर्शन के लिए टेक्स्ट सेट करें।
1. प्रत्येक टेक्स्ट पोर्शन पर इच्छित स्वरूपण लागू करें, जिसे [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) द्वारा प्रदान की गई प्रॉपर्टीज़ से किया जा सकता है।
1. संशोधित प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड इन चरणों को लागू करता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# नई PPTX फ़ाइल बनाने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक आयताकार AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShape के TextFrame तक पहुँचें।
    text_frame = shape.text_frame

    # पैराग्राफ और पोर्शन बनाएं; स्वरूपण नीचे लागू किया गया है।
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX को डिस्क पर सहेजें।
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ अक्सर पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स से लक्ष्य स्लाइड तक पहुंचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप का [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ बनाएँ।
1. पैराग्राफ का बुलेट प्रकार `SYMBOL` सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
1. पैराग्राफ का टेक्स्ट सेट करें।
1. पैराग्राफ के लिए बुलेट इंडेंट सेट करें।
1. बुलेट का रंग सेट करें।
1. बुलेट का आकार (ऊँचाई) सेट करें।
1. पैराग्राफ को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ संग्रह में जोड़ें।
1. दूसरा पैराग्राफ जोड़ें और चरण 7‑12 दोहराएँ।
1. प्रेजेंटेशन सहेजें।

यह Python कोड बुलेटेड पैराग्राफ जोड़ने का तरीका दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुति का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक AutoShape जोड़ें और उस तक पहुँचें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाई गई AutoShape का टेक्स्ट फ्रेम एक्सेस करें।
    text_frame = shape.text_frame

    # डिफ़ॉल्ट पैराग्राफ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # एक पैराग्राफ बनाएं।
    paragraph = slides.Paragraph()

    # पैराग्राफ का बुलेट स्टाइल और चिह्न सेट करें।
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # पैराग्राफ का टेक्स्ट सेट करें।
    paragraph.text = "Welcome to Aspose.Slides"

    # बुलेट इंडेंट सेट करें।
    paragraph.paragraph_format.indent = 25

    # बुलेट का रंग सेट करें।
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # बुलेट की ऊँचाई सेट करें।
    paragraph.paragraph_format.bullet.height = 100

    # पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph)

    # दूसरा पैराग्राफ बनाएं।
    paragraph2 = slides.Paragraph()

    # पैराग्राफ का बुलेट प्रकार और स्टाइल सेट करें।
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # पैराग्राफ का टेक्स्ट सेट करें।
    paragraph2.text = "This is numbered bullet"

    # बुलेट इंडेंट सेट करें।
    paragraph2.paragraph_format.indent = 25

    # बुलेट का रंग सेट करें।
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # बुलेट की ऊँचाई सेट करें।
    paragraph2.paragraph_format.bullet.height = 100

    # पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph2)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **चित्र बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स से लक्ष्य स्लाइड तक पहुंचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप का [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके एक पैराग्राफ बनाएँ और उसका टेक्स्ट सेट करें।
1. एक छवि लोड करके उसे प्रेजेंटेशन की इमेज कलेक्शन में [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) के रूप में जोड़ें।
1. बुलेट प्रकार `PICTURE` सेट करें और बुलेट को [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) सौंपें।
1. बुलेट की ऊँचाई सेट करें।
1. नया पैराग्राफ [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ संग्रह में जोड़ें।
1. प्रेजेंटेशन सहेजें।

यह Python कोड चित्र बुलेट्स जोड़ने और प्रबंधित करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # बुलेट छवि लोड करें।
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # एक AutoShape जोड़ें और उसे एक्सेस करें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाई गई AutoShape का TextFrame एक्सेस करें।
    text_frame = auto_shape.text_frame

    # डिफ़ॉल्ट पैराग्राफ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # नया पैराग्राफ बनाएं।
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # पैराग्राफ का बुलेट प्रकार Picture सेट करें और छवि असाइन करें।
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # बुलेट की ऊँचाई सेट करें।
    paragraph.paragraph_format.bullet.height = 100

    # पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # प्रस्तुति को PPT फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **बहुस्तरीय बुलेट्स प्रबंधित करें**

बुलेट सूचियाँ आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहुस्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स से लक्ष्य स्लाइड तक पहुंचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) का [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ बनाएँ और उसकी गहराई 0 सेट करें।
1. दूसरा पैराग्राफ बनाकर उसकी गहराई 1 सेट करें।
1. तीसरा पैराग्राफ बनाकर उसकी गहराई 2 सेट करें।
1. चौथा पैराग्राफ बनाकर उसकी गहराई 3 सेट करें।
1. नए पैराग्राफों को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ संग्रह में जोड़ें।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड बहुस्तरीय बुलेट्स को जोड़ने और प्रबंधित करने का तरीका दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुति का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]
    
    # एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाई गई AutoShape का TextFrame एक्सेस करें।
    text_frame = shape.text_frame
    
    # डिफ़ॉल्ट पैराग्राफ साफ़ करें।
    text_frame.paragraphs.clear()

    # पहला पैराग्राफ जोड़ें।
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph1.paragraph_format.depth = 0

    # दूसरा पैराग्राफ जोड़ें।
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph2.paragraph_format.depth = 1

    # तीसरा पैराग्राफ जोड़ें।
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph3.paragraph_format.depth = 2

    # चौथा पैराग्राफ जोड़ें।
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # बुलेट स्तर सेट करें।
    paragraph4.paragraph_format.depth = 3

    # पैराग्राफों को संग्रह में जोड़ें।
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम क्रमांकित सूचियों के साथ पैराग्राफ प्रबंधित करें**

[BulletFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/) क्लास `numbered_bullet_start_with` प्रॉपर्टी (और अन्य) प्रदान करती है जिससे पैराग्राफ के लिए कस्टम क्रमांकन और स्वरूपण नियंत्रित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. वह स्लाइड एक्सेस करें जिसमें पैराग्राफ होंगे।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप का [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ हटाएँ।
1. पहला [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाकर `numbered_bullet_start_with` को 2 सेट करें।
1. दूसरा [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाकर `numbered_bullet_start_with` को 3 सेट करें।
1. तीसरा [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) बनाकर `numbered_bullet_start_with` को 7 सेट करें।
1. पैराग्राफों को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के संग्रह में जोड़ें।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड कस्टम क्रमांकन और स्वरूपण वाले पैराग्राफ जोड़ने और प्रबंधित करने का प्रदर्शन करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # एक AutoShape जोड़ें और उसे एक्सेस करें।
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाई गई AutoShape का TextFrame एक्सेस करें।
    text_frame = shape.text_frame

    # डिफ़ॉल्ट मौजूदा पैराग्राफ हटाएँ।
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

## **पैराग्राफ के प्रथम‑लाइन इंडेंट सेट करें**

[ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी का उपयोग करके आप पैराग्राफ की प्रथम‑लाइन इंडेंट नियंत्रित कर सकते हैं। यह प्रॉपर्टी केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष प्रथम पंक्ति को ही ले जाती है। सकारात्मक मान प्रथम पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

यदि आपको पूरी पैराग्राफ को ले जाना हो तो [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) उपयोग करें। केवल प्रथम पंक्तिके लिये [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न `indent` मूल्यों को लागू करके दिखाता है कि प्रथम‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्ष्य स्लाइड एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएँ और उनके लिये अलग‑अलग [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
6. पैराग्राफों को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन सहेजें।

यह कोड पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफों की पहली पंक्ति का इंडेंट](first_line_indent.png)

## **पैराग्राफ के हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट एक ऐसा पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों की बाएँ ओर शुरू होती है। Aspose.Slides में आप इस प्रभाव को [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी से प्राप्त कर सकते हैं। `indent` को नकारात्मक मान देकर पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएँ ले जाएँ।

व्यावहारिक रूप से, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, जबकि [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रथम पंक्ति की स्थिति को उसके मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिये सकारात्मक `margin_left` मान और नकारात्मक `indent` मान सेट करें।

यह स्वरूपण बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों और अन्य उन पैराग्राफ़ों में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के अंतर्गत संरेखित रहना चाहिए, न कि प्रथम पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. लक्ष्य स्लाइड एक्सेस करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएँ और प्रत्येक के लिये सकारात्मक [margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव उत्पन्न करने के लिये नकारात्मक [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
7. पैराग्राफों को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन सहेजें।

यह कोड पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

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

![पैराग्राफों का हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ के अंत‑पोर्शन फ़ॉर्मेट प्रबंधित करें**

जब आपको पैराग्राफ के “अन्त” (अंतिम टेक्स्ट पोर्शन के बाद लागू स्वरूपण) को नियंत्रित करने की आवश्यकता हो, तो `end_paragraph_portion_format` प्रॉपर्टी का उपयोग करें। नीचे दिया गया उदाहरण दूसरे पैराग्राफ के अंत में बड़े आकार के Times New Roman फ़ॉन्ट को लागू करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) फ़ाइल बनाएँ या खोलें।
1. इंडेक्स द्वारा लक्ष्य स्लाइड प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) का उपयोग करके दो पैराग्राफ बनाएँ।
1. 48‑pt Times New Roman सेट किए हुए एक [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) बनाएँ और इसे पैराग्राफ के अंत‑पोर्शन फ़ॉर्मेट के रूप में लागू करें।
1. इसे पैराग्राफ की `end_paragraph_portion_format` प्रॉपर्टी में असाइन करें (दूसरे पैराग्राफ के अंत पर लागू होगा)।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दूसरे पैराग्राफ के लिए अंत‑पैराग्राफ फ़ॉर्मेट सेट करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# डिफ़ॉल्ट पैराग्राफ हटाएँ।
	shape.text_frame.paragraphs.clear()

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

## **HTML टेक्स्ट को पैराग्राफ में आयात करें**

Aspose.Slides पैराग्राफ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी इंडेक्स से लक्ष्य स्लाइड एक्सेस करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) को एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से डिफ़ॉल्ट पैराग्राफ हटाएँ।
1. स्रोत HTML फ़ाइल पढ़ें।
1. HTML सामग्री को [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के पैराग्राफ संग्रह में जोड़ें।
1. संशोधित प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड HTML टेक्स्ट को पैराग्राफ में आयात करने के लिए इन चरणों को लागू करता है।

```python
import aspose.slides as slides

# खाली Presentation उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # प्रस्तुति की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML सामग्री को समायोजित करने के लिए एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ साफ़ करें।
    shape.text_frame.paragraphs.clear()

    # HTML फ़ाइल लोड करें।
    with open("file.html", "rt") as html_stream:
        # HTML फ़ाइल से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ें।
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाकर लक्ष्य प्रेजेंटेशन लोड करें।
1. इंडेक्स द्वारा वांछित स्लाइड एक्सेस करें।
1. वह शैप चुनें जिसमें निर्यात करने के लिये टेक्स्ट है।
1. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) को एक्सेस करें।
1. HTML आउटपुट लिखने के लिये फ़ाइल स्ट्रीम खोलें।
1. प्रारम्भिक इंडेक्स निर्धारित करें और आवश्यक पैराग्राफ निर्यात करें।

यह Python उदाहरण पैराग्राफ टेक्स्ट को HTML में निर्यात करने का तरीका दिखाता है।

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # प्रस्तुति की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # लक्ष्य शैप इंडेक्स।
    index = 0

    # इंडेक्स द्वारा शैप तक पहुँचें।
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # निर्यात करने के लिए प्रारम्भिक पैराग्राफ इंडेक्स और कुल पैराग्राफ संख्या प्रदान करके पैराग्राफ डेटा को HTML में लिखें।
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **पैराग्राफ को छवि के रूप में सहेजें**

इस खंड में हम दो उदाहरणों का अन्वेषण करेंगे जो दिखाते हैं कि कैसे [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास द्वारा प्रतिनिधित्व किए गये टेक्स्ट पैराग्राफ को छवि के रूप में सहेजा जा सकता है। दोनों उदाहरण में शैप की छवि प्राप्त करना, पैराग्राफ की सीमाओं की गणना करना और उसे बिटमैप छवि के रूप में निर्यात करना शामिल है। ये तरीके आपको PowerPoint प्रस्तुति से विशिष्ट टेक्स्ट भाग निकाल कर अलग‑अलग छवियों के रूप में सहेजने की सुविधा देते हैं।

मान लीजिए हमारे पास sample.pptx नामक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शैप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाले टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ को छवि के रूप में प्राप्त करते हैं। इसके लिये हम पहले स्लाइड के शैप की छवि निकालते हैं, फिर शैप के टेक्स्ट फ्रेम में दूसरे पैराग्राफ की सीमाएँ निकालते हैं और उसे नए बिटमैप छवि पर पुनः बनाते हैं, जिसे PNG प्रारूप में सहेजा जाता है। यह विधि तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ को अलग छवि के रूप में सहेजना हो और टेक्स्ट के आयाम व स्वरूपण को बरकरार रखना हो।

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से आकार का बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ की सीमाओं की गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # आउटपुट छवि के लिए निर्देशांक और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ बिटमैप प्राप्त करने के लिए आकार के बिटमैप को काटें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

परिणाम:

![पैराग्राफ छवि](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले दृष्टिकोण को स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। शैप को प्रस्तुति से निकाल कर `2` स्केल फ़ैक्टर के साथ छवि के रूप में सहेजा जाता है, जिससे निर्यात में उच्च रिज़ॉल्यूशन मिलता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ की सीमाएँ निकालते हैं। स्केलिंग तब उपयोगी होती है जब अधिक विवरण वाली छवि की आवश्यकता हो, जैसे उच्च‑गुणवत्ता वाले प्रिंट सामग्री में।

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से आकार का बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ की सीमाओं की गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # आउटपुट छवि के लिए निर्देशांक और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ बिटमैप प्राप्त करने के लिए आकार के बिटमैप को काटें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?

हां। टेक्स्ट फ्रेम की रैपिंग सेटिंग ([wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/)) को बंद करके आप लाइन रैपिंग को बंद कर सकते हैं ताकि लाइनें फ्रेम के किनारों पर नहीं टूटें।

### मैं विशेष पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त करूँ?

आप पैराग्राफ (और यहां तक कि एकल पोर्शन) का बाउंडिंग रेक्टेंगल प्राप्त कर सकते हैं जिससे उसके सटीक स्थान और आकार का पता चलता है।

### पैराग्राफ संरेखण (बाएँ/दाएँ/केन्द्र/समरूप) कहाँ नियंत्रित होता है?

[Alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) पैराग्राफ‑स्तर की सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/) में होती है; यह पूरे पैराग्राफ पर लागू होती है चाहे व्यक्तिगत पोर्शन की स्वरूपण कुछ भी हो।

### क्या मैं पैराग्राफ के केवल एक भाग (जैसे एक शब्द) के लिए वर्तनी‑जांच भाषा सेट कर सकता हूँ?

हां। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/)), इसलिए एक ही पैराग्राफ में कई भाषाएँ साथ-साथ मौजूद हो सकती हैं।