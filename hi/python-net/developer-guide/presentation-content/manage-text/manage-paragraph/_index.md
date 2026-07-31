---
title: Python में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
type: docs
weight: 40
url: /hi/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ़ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ़ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलेट
- नंबरित सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पैराग्राफ़ फ़ॉर्मेटिंग को महारत हासिल करें—PowerPoint और OpenDocument प्रेजेंटेशन में संरेखण, स्पेसिंग और शैली को अनुकूलित करें ताकि Python में दर्शकों को आकर्षित किया जा सके।"
---
## **परिचय**

Aspose.Slides वह वर्ग प्रदान करता है जो आपको Python में PowerPoint टेक्स्ट के साथ काम करने के लिए आवश्यक हैं।

* Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) क्लास प्रदान करता है जो टेक्स्ट फ्रेम ऑब्जेक्ट बनाता है। एक `TextFrame` ऑब्जेक्ट में एक या अधिक पैराग्राफ़ हो सकते हैं (प्रत्येक पैराग्राफ़ कैरिज रिटर्न द्वारा अलग किया जाता है)।
* Aspose.Slides [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास प्रदान करता है जो पैराग्राफ़ ऑब्जेक्ट बनाता है। एक `Paragraph` ऑब्जेक्ट में एक या अधिक टेक्स्ट पोर्शन हो सकते हैं।
* Aspose.Slides [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) क्लास प्रदान करता है जो टेक्स्ट पोर्शन ऑब्जेक्ट बनाता है और उनकी फ़ॉर्मेटिंग प्रॉपर्टीज़ निर्दिष्ट करता है।

एक `Paragraph` ऑब्जेक्ट अपने अंतर्निर्हित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग प्रॉपर्टीज़ वाला टेक्स्ट संभाल सकता है।

## **कई पोर्शन वाले कई पैराग्राफ़ जोड़ना**

ये चरण दिखाते हैं कि कैसे एक टेक्स्ट फ्रेम जोड़ें जिसमें तीन पैराग्राफ़ हों, प्रत्येक में तीन पोर्शन हों:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स के द्वारा लक्ष्य स्लाइड का रेफरेंस प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) से जुड़ा हुआ [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त करें।
1. दो [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) ऑब्जेक्ट बनाएँ और उन्हें [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) की पैराग्राफ़ कलेक्शन में जोड़ें (डिफ़ॉल्ट पैराग्राफ़ के साथ, इससे तीन पैराग्राफ़ बनते हैं)।
1. प्रत्येक पैराग्राफ़ के लिए, तीन [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) ऑब्जेक्ट बनाएँ और उन्हें उस पैराग्राफ़ के पोर्शन कलेक्शन में जोड़ें।
1. प्रत्येक पोर्शन के लिए टेक्स्ट सेट करें।
1. [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) द्वारा प्रदत्त प्रॉपर्टीज़ का उपयोग करके प्रत्येक टेक्स्ट पोर्शन पर वांछित फ़ॉर्मेटिंग लागू करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड इन चरणों को लागू करता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# नई PPTX फ़ाइल बनाने के लिए Presentation क्लास का इंस्टैंस बनाते हैं।
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

## **पैराग्राफ़ बुलेट्स का प्रबंधन**

बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। बुलेटेड पैराग्राफ़ अक्सर पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स के द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame] से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएँ।
1. पैराग्राफ़ के बुलेट प्रकार को `SYMBOL` सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
1. पैराग्राफ़ का टेक्स्ट सेट करें।
1. पैराग्राफ़ के लिए बुलेट इंडेंट सेट करें।
1. बुलेट का रंग सेट करें।
1. बुलेट का आकार (ऊँचाई) सेट करें।
1. पैराग्राफ़ को [TextFrame] की पैराग्राफ़ कलेक्शन में जोड़ें।
1. दूसरा पैराग्राफ़ जोड़ें और चरण 7–12 दोहराएँ।
1. प्रेजेंटेशन को सहेजें।

यह Python कोड बुलेटेड पैराग्राफ़ जोड़ने का तरीका दिखाता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# एक प्रस्तुति इंस्टांस बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक AutoShape जोड़ें और पहुँचें।
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

    # बुलेट का इंडेंट सेट करें।
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

    # बुलेट का इंडेंट सेट करें।
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

## **पिक्चर बुलेट्स का प्रबंधन**

बुलेटेड सूचियाँ आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। पिक्चर बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स के द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame] से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएँ।
1. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) में एक चित्र लोड करें।
1. बुलेट प्रकार को [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) सेट करें और चित्र असाइन करें।
1. पैराग्राफ़ का टेक्स्ट सेट करें।
1. बुलेट के लिए पैराग्राफ़ इंडेंट सेट करें।
1. बुलेट का रंग सेट करें।
1. बुलेट की ऊँचाई सेट करें।
1. नए पैराग्राफ़ को [TextFrame] की पैराग्राफ़ कलेक्शन में जोड़ें।
1. दूसरा पैराग्राफ़ जोड़ें और चरण 8–12 दोहराएँ।
1. प्रेजेंटेशन को सहेजें।

यह Python कोड पिक्चर बुलेट्स जोड़ने और प्रबंधित करने का तरीका दिखाता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # बुलेट छवि लोड करें।
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # एक AutoShape जोड़ें और पहुँचें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape के TextFrame तक पहुँचें।
    text_frame = auto_shape.text_frame

    # डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # एक नया पैराग्राफ़ बनाएं।
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # पैराग्राफ़ का बुलेट प्रकार Picture सेट करें और चित्र असाइन करें।
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # बुलेट की ऊँचाई सेट करें।
    paragraph.paragraph_format.bullet.height = 100

    # पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
    text_frame.paragraphs.add(paragraph)

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # प्रेजेंटेशन को PPT फ़ाइल के रूप में सहेजें।
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **मल्टीलेवल बुलेट्स का प्रबंधन**

बुलेटेड सूचियाँ आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। मल्टीलेवल बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स के द्वारा लक्ष्य स्लाइड तक पहुँचें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape] की [TextFrame] तक पहुँचें।
1. [TextFrame] से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. [Paragraph] क्लास का उपयोग करके पहला पैराग्राफ़ बनाएँ और उसकी डेप्थ को 0 सेट करें।
1. दूसरा पैराग्राफ़ बनाएँ और उसकी डेप्थ को 1 सेट करें।
1. तीसरा पैराग्राफ़ बनाएँ और उसकी डेप्थ को 2 सेट करें।
1. चौथा पैराग्राफ़ बनाएँ और उसकी डेप्थ को 3 सेट करें।
1. नए पैराग्राफ़ को [TextFrame] की पैराग्राफ़ कलेक्शन में जोड़ें।
1. प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड मल्टीलेवल बुलेट्स जोड़ने और प्रबंधित करने का तरीका दिखाता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# एक प्रस्तुति इंस्टांस बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]
    
    # एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape के TextFrame तक पहुँचें।
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

    # पैराग्राफ़ को कलेक्शन में जोड़ें।
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम नंबरिंग वाली सूचियों के साथ पैराग्राफ़ का प्रबंधन**

[BulletFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/bulletformat/) क्लास `numbered_bullet_start_with` प्रॉपर्टी (और अन्य) प्रदान करती है जो पैराग्राफ़ के लिए कस्टम नंबरिंग और फ़ॉर्मेटिंग को नियंत्रित करती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उस स्लाइड तक पहुँचें जिसमें पैराग्राफ़ होंगे।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शेप की [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame] से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
1. पहला [Paragraph] बनाएँ और `numbered_bullet_start_with` को 2 सेट करें।
1. दूसरा [Paragraph] बनाएँ और `numbered_bullet_start_with` को 3 सेट करें।
1. तीसरा [Paragraph] बनाएँ और `numbered_bullet_start_with` को 7 सेट करें।
1. पैराग्राफ़ को [TextFrame] की कलेक्शन में जोड़ें।
1. प्रेजेंटेशन को सहेजें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # एक AutoShape जोड़ें और पहुँचें।
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # बनाए गए AutoShape के TextFrame तक पहुँचें।
    text_frame = shape.text_frame

    # डिफ़ॉल्ट मौजूदा पैराग्राफ़ हटाएँ।
    text_frame.paragraphs.remove_at(0)

    # पहला क्रमांकित आइटम बनाएं (शुरुआत 2 से, गहरा स्तर 4)।
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # दूसरा क्रमांकित आइटम बनाएं (शुरुआत 3 से, गहरा स्तर 4)।
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # तीसरा क्रमांकित आइटम बनाएं (शुरुआत 7 से, गहरा स्तर 4)।
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ़ के लिए फर्स्ट-लाइन इंडेंट सेट करें**

पैराग्राफ़ की पहली लाइन के इंडेंट को नियंत्रित करने के लिए [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी का उपयोग करें। यह प्रॉपर्टी केवल पहली लाइन को पैराग्राफ़ की बाएँ मार्जिन के सापेक्ष लेती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि शेष लाइनों को पैराग्राफ़ बॉडी के अनुसार संरेखित रखता है।

[ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) का उपयोग तब करें जब आपको पूरी पैराग्राफ़ को ले जाना हो। केवल पहली लाइन को ले जाने के लिए [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ़ बनाता है और विभिन्न `indent` मान लागू करता है ताकि दिखा सके कि फर्स्ट-लाइन इंडेंट पैराग्राफ़ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
5. कई पैराग्राफ़ बनाएँ और उनके लिए विभिन्न [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
6. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड दिखाता है कि कैसे पैराग्राफ़ इंडेंट सेट किया जाता है:
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
![पैराग्राफ़ का फर्स्ट-लाइन इंडेंट](first_line_indent.png)

## **पैराग्राफ़ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ़ लेआउट है जिसमें पहली लाइन बाकी लाइनों के बाएँ शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) प्रॉपर्टी से बना सकते हैं। `indent` को नकारात्मक मान पर सेट करें ताकि पहली लाइन पैराग्राफ़ बॉडी के सापेक्ष बाएँ जाए।

व्यावहारिक रूप से, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) पैराग्राफ़ बॉडी की बाएँ स्थिति निर्धारित करता है, और [ParagraphFormat.indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) उस मार्जिन के सापेक्ष पहली लाइन की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, एक सकारात्मक `margin_left` मान और नकारात्मक `indent` मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ के लिए उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ़ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली लाइन के पहले कैरेक्टर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
5. पैराग्राफ़ बनाएँ और प्रत्येक पैराग्राफ़ के लिए एक सकारात्मक [margin_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/margin_left/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [indent](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/indent/) मान सेट करें।
7. पैराग्राफ़ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड दिखाता है कि कैसे पैराग्राफ़ के लिए हैंगिंग इंडेंट सेट किया जाता है:
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
![पैराग्राफ़ का हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ़ के अंत के पोर्शन फ़ॉर्मेट को प्रबंधित करना**

जब आपको पैराग्राफ़ के "अंत" की स्टाइलिंग को नियंत्रित करने की आवश्यकता हो (अंतिम टेक्स्ट पोर्शन के बाद लागू फ़ॉर्मेटिंग), तो `end_paragraph_portion_format` प्रॉपर्टी का उपयोग करें। नीचे दिया गया उदाहरण दूसरे पैराग्राफ़ के अंत में बड़े Times New Roman फ़ॉन्ट को लागू करता है।

1. एक [Presentation] फ़ाइल बनाएँ या खोलें।
2. इंडेक्स द्वारा लक्ष्य स्लाइड प्राप्त करें।
3. स्लाइड में एक आयताकार [AutoShape] जोड़ें।
4. शेप की [TextFrame] का उपयोग करें और दो पैराग्राफ़ बनाएँ।
5. 48-pt Times New Roman के साथ एक [PortionFormat] बनाएँ और इसे पैराग्राफ़ के end-paragraph पोर्शन फ़ॉर्मेट के रूप में लागू करें।
6. इसे पैराग्राफ़ के `end_paragraph_portion_format` को असाइन करें (दूसरे पैराग्राफ़ के अंत पर लागू)।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि कैसे दूसरे पैराग्राफ़ के लिए पैराग्राफ़ के अंत की फ़ॉर्मेटिंग सेट की जाती है:
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

## **पैराग्राफ़ में HTML टेक्स्ट आयात करना**

Aspose.Slides पैराग्राफ़ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. एक [Presentation] क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स के द्वारा लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक [AutoShape] जोड़ें।
4. [AutoShape] के [TextFrame] तक पहुँचें।
5. [TextFrame] से डिफ़ॉल्ट पैराग्राफ़ हटाएँ।
6. स्रोत HTML फ़ाइल पढ़ें।
7. पहला पैराग्राफ़ [Paragraph] क्लास का उपयोग करके बनाएँ।
8. HTML सामग्री को [TextFrame] की पैराग्राफ़ कलेक्शन में जोड़ें।
9. संशोधित प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड इन चरणों को लागू करता है ताकि HTML टेक्स्ट को पैराग्राफ़ में आयात किया जा सके।
```python
import aspose.slides as slides

# एक खाली Presentation इंस्टांस बनाएं।
with slides.Presentation() as presentation:

    # प्रस्तुति की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML सामग्री को रखने के लिए एक AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ़ साफ़ करें।
    shape.text_frame.paragraphs.clear()

    # HTML फ़ाइल लोड करें।
    with open("file.html", "rt") as html_stream:
        # HTML फ़ाइल से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ें।
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **पैराग्राफ़ टेक्स्ट को HTML में निर्यात करना**

Aspose.Slides टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation] क्लास का एक इंस्टेंस बनाएँ और लक्ष्य प्रेजेंटेशन लोड करें।
2. इंडेक्स द्वारा इच्छित स्लाइड तक पहुँचें।
3. टेक्स्ट को निर्यात करने वाले शेप को चुनें।
4. शेप की [TextFrame] तक पहुँचें।
5. HTML आउटपुट लिखने के लिए एक फ़ाइल स्ट्रीम खोलें।
6. प्रारंभिक इंडेक्स निर्दिष्ट करें और आवश्यक पैराग्राफ़ निर्यात करें।

यह Python उदाहरण दिखाता है कि कैसे पैराग्राफ़ टेक्स्ट को HTML में निर्यात किया जाता है।
```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # प्रस्तुति की पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # लक्ष्य शेप इंडेक्स।
    index = 0

    # इंडेक्स द्वारा शेप तक पहुँचें।
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # पैराग्राफ़ डेटा को HTML में लिखें, शुरूआती पैराग्राफ़ इंडेक्स और निर्यात करने वाले कुल पैराग्राफ़ों की संख्या प्रदान करके।
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **पैराग्राफ़ को इमेज के रूप में सहेजें**

इस अनुभाग में, हम दो उदाहरणों का अन्वेषण करेंगे जो दिखाते हैं कि कैसे टेक्स्ट पैराग्राफ़ को, जो [Paragraph] क्लास द्वारा दर्शाया गया है, एक इमेज के रूप में सहेजा जाता है। दोनों उदाहरणों में [Shape] क्लास के `get_image` मेथड का उपयोग करके पैराग्राफ़ वाले शेप की इमेज प्राप्त करना, शेप के टेक्स्ट फ्रेम में पैराग्राफ़ की सीमाएं गणना करना, और उसे बिटमैप इमेज के रूप में निर्यात करना शामिल है। ये विधियां आपको PowerPoint प्रेजेंटेशन से टेक्स्ट के विशिष्ट भागों को निकालने और उन्हें अलग-अलग इमेज के रूप में सहेजने की अनुमति देती हैं, जो विभिन्न परिदृश्यों में आगे उपयोग के लिए उपयोगी हो सकते हैं।

मान लीजिए हमारे पास sample.pptx नामक एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में, हम दूसरे पैराग्राफ़ को इमेज के रूप में प्राप्त करते हैं। इसके लिए, हम प्रेजेंटेशन की पहली स्लाइड से शेप की इमेज निकालते हैं और फिर शेप के टेक्स्ट फ्रेम में दूसरे पैराग्राफ़ की सीमाएं गणना करते हैं। फिर पैराग्राफ़ को एक नई बिटमैप इमेज पर पुनः ड्रॉ किया जाता है, जिसे PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से उपयोगी होती है जब आपको किसी विशिष्ट पैराग्राफ़ को अलग इमेज के रूप में सहेजना हो, जबकि टेक्स्ट की सटीक आयाम और फ़ॉर्मेटिंग संरक्षित रहे।
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # शेप को मेमोरी में बिटमैप के रूप में सहेजें।
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से एक शेप बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ़ की सीमाओं की गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # आउटपुट इमेज के लिए निर्देशांक और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

परिणाम:
![पैराग्राफ़ इमेज](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में, हम पिछले दृष्टिकोण को पैराग्राफ़ इमेज में स्केलिंग कारकों को जोड़कर विस्तारित करते हैं। शेप को प्रेजेंटेशन से निकाला जाता है और `2` के स्केलिंग फ़ैक्टर के साथ इमेज के रूप में सहेजा जाता है। इससे पैराग्राफ़ निर्यात करते समय उच्च रिज़ॉल्यूशन आउटपुट मिलता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ़ की सीमाएं गणना की जाती हैं। स्केलिंग विशेष रूप से तब उपयोगी हो सकती है जब अधिक विस्तृत इमेज की आवश्यकता हो, उदाहरण के लिए उच्च-गुणवत्ता वाली मुद्रित सामग्री में उपयोग के लिए।
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # शेप को मेमोरी में बिटमैप के रूप में सहेजें।
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # मेमोरी से एक शेप बिटमैप बनाएं।
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # दूसरे पैराग्राफ़ की सीमाओं की गणना करें।
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # आउटपुट इमेज के लिए निर्देशांक और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए शेप बिटमैप को क्रॉप करें।
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**  
हाँ। टेक्स्ट फ्रेम की रैपिंग सेटिंग ([wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/)) का उपयोग करके रैपिंग बंद कर सकते हैं ताकि लाइन्स फ्रेम के किनारों पर नहीं टूटें।

**मैं किसी विशिष्ट पैराग्राफ़ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त कर सकता हूँ?**  
आप पैराग्राफ़ (और यहाँ तक कि एकल पोर्शन) का बाउंडिंग रेक्टैंगल प्राप्त कर सकते हैं जिससे आपको स्लाइड पर उसकी सटीक स्थिति और आकार पता चल सके।

**पैराग्राफ़ संरेखण (बायाँ/दायाँ/केन्द्रित/जस्टिफ़ाई) कहाँ नियंत्रित होता है?**  
[Alignment] वह पैराग्राफ़-स्तर की सेटिंग है जो [ParagraphFormat] में होती है; यह पूरे पैराग्राफ़ पर लागू होती है चाहे व्यक्तिगत पोर्शन फ़ॉर्मेटिंग कुछ भी हो।

**क्या मैं पैराग्राफ़ के केवल एक हिस्से (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**  
हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.language_id]), इसलिए एक ही पैराग्राफ़ में कई भाषाएँ सह-अस्तित्व में हो सकती हैं।