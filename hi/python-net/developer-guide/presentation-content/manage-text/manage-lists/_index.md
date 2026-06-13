---
title: Python में प्रस्तुतियों में बुलेटेड और नंबरित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 70
url: /hi/python-net/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- नंबरित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरिकीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरिकीय और नंबरित सूचियां बनाना और स्वरूपित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबरित सूचियों को बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम वह पैराग्राफ है जिसके बुलेट सेटिंग्स पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित की जाती हैं।

पैराग्राफ-स्तरीय सूची सेटिंग्स तक पहुंचने के लिए [Paragraph.paragraph_format] प्रॉपर्टी का उपयोग करें। मुख्य प्रवेश बिंदु है [ParagraphFormat.bullet], जो एक [BulletFormat] ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ, आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, नंबरिंग शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- एक कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके बहु‑स्तरिकीय सूची बनाएं
- नंबरित सूची बनाएं
- एक मौजूदा प्रस्तुति में सूची स्वरूपण देखें और बदलें

## **बुलेटेड सूची बनाना**

बुलेटेड सूची बनाने के लिए, एक [Paragraph] ऑब्जेक्ट को एक [TextFrame] में जोड़ें और [BulletFormat.type] को [BulletType.SYMBOL] पर सेट करें। फिर आप [BulletFormat.char], [BulletFormat.color], और [BulletFormat.height] को सेट करके बुलेट का रूप निर्धारित कर सकते हैं।

नीचे दिया गया Python कोड स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![प्रतीक बुलेट](symbol_bullets.png)

## **नंबरित सूची बनाना**

जब आइटमों का क्रम महत्वपूर्ण हो तो नंबरित सूचियों का उपयोग करें। [BulletFormat.type] को [BulletType.NUMBERED] पर सेट करें। आप [BulletFormat.numbered_bullet_style] के साथ नंबरिंग फ़ॉर्मेट चुन सकते हैं या जब सूची 1 से नहीं बल्कि किसी अन्य संख्या से शुरू होनी चाहिए तो [BulletFormat.numbered_bullet_start_with] सेट कर सकते हैं।

नीचे दिया गया Python कोड स्लाइड में नंबरित सूची बनाने का प्रदर्शन करता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![नंबरित बुलेट](numbered_bullets.png)

## **चित्र बुलेट बनाना**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को छवि से बदलने की सुविधा देता है। चित्र बुलेट सर्वोत्तम तब काम करते हैं जब वे सरल छवियों हों जो छोटे आकार में भी पठनीय रहें, जैसे आइकॉन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="primary" %}}
यदि आप सामान्य बुलेट प्रतीक को छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली सरल ग्राफ़िक चुनना सबसे अच्छा रहता है। ऐसी छवियाँ कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से सलाह देते हैं कि वह छवि चुनें जो सूची में बुलेट के रूप में उपयोग होने पर भी स्पष्ट और दृश्य रूप से प्रभावी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [Presentation.images] में जोड़ें और लौटाए गए छवि ऑब्जेक्ट को [BulletFormat.picture] को असाइन करें। असाइन करने से पहले [BulletFormat.type] को [BulletType.PICTURE] पर सेट करें।

मान लीजिए हमारे पास "image.png" है:

![बुलेट के लिए चित्र](picture_for_bullets.png)

नीचे दिया गया Python कोड स्लाइड में चित्र बुलेट बनाने का प्रदर्शन करता है:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![चित्र बुलेट](picture_bullets.png)

## **बहु‑स्तरिकीय सूची बनाना**

सूची आइटमों को विभिन्न स्तरों पर रखने के लिए [ParagraphFormat.depth] का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, आदि।

नीचे दिया गया Python कोड बहु‑स्तरिकीय बुलेटेड सूची बनाने का प्रदर्शन करता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![बहु‑स्तरिकीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलना**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुंचें और उसके [ParagraphFormat.bullet] सेटिंग्स को अपडेट करें। सूची बनाने के लिए उपयोग किए गए वही गुण लोड की गई PPT, PPTX, या ODP फ़ाइल से प्राप्त सूचियों को निरीक्षण या संशोधित करने के लिए उपयोग किए जा सकते हैं।

नीचे दिया गया Python कोड टेक्स्ट फ़्रेम के पहले पैराग्राफ को नंबरित सूची शैली में बदलता है:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या बुलेटेड और नंबरित सूचनाओं को PDF या छवियों में निर्यात किया जा सकता है?**

हां। Aspose.Slides सूची स्वरूपण को सुरक्षित रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुंचें, उसके [ParagraphFormat.bullet] सेटिंग्स को निरीक्षण या अपडेट करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?**

हां। सूची आइटम का टेक्स्ट Unicode अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियां बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में प्रयुक्त फ़ॉन्ट्स उन अक्षरों को समर्थन देते हों।