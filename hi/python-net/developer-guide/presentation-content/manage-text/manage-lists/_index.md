---
title: "प्रेजेंटेशन में Python के माध्यम से बुलेटेड और क्रमांकित सूचियों का प्रबंधन"
linktitle: "सूचियों का प्रबंधन"
type: docs
weight: 70
url: /hi/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाने और स्वरूपित करने का तरीका सीखें।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों को बनाने और स्वरूपित करने की सुविधा देता है। एक सूची आइटम एक पैराग्राफ है जिसका बुलेट सेटिंग उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित किया जाता है।

Paragraph.paragraph_format प्रॉपर्टी का उपयोग करके आप पैराग्राफ‑स्तर की सूची सेटिंग्स तक पहुँच सकते हैं। मुख्य प्रवेश बिंदु ParagraphFormat.bullet है, जो एक BulletFormat ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ, आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांक शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- एक कस्टम प्रतीक के साथ बुलेटेड सूची बनाना
- चित्र बुलेट बनाना
- पैराग्राफ गहराई सेट करके बहु‑स्तरीय सूची बनाना
- क्रमांकित सूची बनाना
- मौजूदा प्रस्तुति में सूची स्वरूपण का निरीक्षण और परिवर्तन करना

## **बुलेटेड सूची बनाना**

बुलेटेड सूची बनाने के लिए, Paragraph ऑब्जेक्ट को एक TextFrame में जोड़ें और BulletFormat.type को BulletType.SYMBOL पर सेट करें। उसके बाद आप BulletFormat.char, BulletFormat.color, और BulletFormat.height सेट करके बुलेट की उपस्थिति को नियंत्रित कर सकते हैं।

निम्नलिखित Python कोड स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

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

## **क्रमांकित सूची बनाना**

जब आइटम्स का क्रम महत्वपूर्ण हो तो क्रमांकित सूचियों का उपयोग करें। BulletFormat.type को BulletType.NUMBERED पर सेट करें। आप BulletFormat.numbered_bullet_style के साथ क्रमांक स्वरूप चुन सकते हैं या जब सूची को 1 से अलग मान से शुरू करना हो तो BulletFormat.numbered_bullet_start_with सेट कर सकते हैं।

निम्नलिखित Python कोड दिखाता है कि स्लाइड में क्रमांकित सूची कैसे बनाएं:

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

![क्रमांकित बुलेट](numbered_bullets.png)

## **चित्र बुलेट बनाना**

Aspose.Slides आपको नियमित बुलेट प्रतीक को एक चित्र से बदलने की अनुमति देता है। चित्र बुलेट सबसे अच्छे सरल चित्रों के साथ काम करते हैं जो छोटे आकार में भी पढ़ने योग्य रहें, जैसे आइकन या छोटे पारदर्शी PNG फाइलें।

 {{% alert color="primary" %}}
आदर्श रूप से, यदि आप नियमित बुलेट प्रतीक को चित्र से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाले सरल ग्राफिक को चुनना सबसे बेहतर है। ऐसे चित्र कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह से काम करते हैं।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, Presentation.images में एक चित्र जोड़ें और लौटाए गए चित्र ऑब्जेक्ट को BulletFormat.picture को असाइन करें। चित्र असाइन करने से पहले BulletFormat.type को BulletType.PICTURE पर सेट करें।

मान लीजिए हमारे पास एक "image.png" है:

![बुलेटों के लिए चित्र](picture_for_bullets.png)

निम्नलिखित Python कोड दिखाता है कि स्लाइड में चित्र बुलेट कैसे बनाएं:

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

## **बहु‑स्तरीय सूची बनाना**

सूची आइटम को विभिन्न स्तरों पर रखने के लिए ParagraphFormat.depth का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, आदि।

निम्नलिखित Python कोड दिखाता है कि बहु‑स्तरीय बुलेटेड सूची कैसे बनाएं:

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

![बहु‑स्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलना**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुँचें और उसके ParagraphFormat.bullet सेटिंग्स को अपडेट करें। वही प्रॉपर्टी जो सूचनाएँ बनाने के लिए उपयोग की जाती हैं, उन्हें PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचनाओं की जाँच या संशोधन के लिए भी उपयोग किया जा सकता है।

निम्नलिखित Python कोड टेक्स्ट फ़्रेम में पहले पैराग्राफ को क्रमांकित सूची शैली में बदलता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और क्रमांकित सूचियों को PDF या छवियों में निर्यात किया जा सकता है?**

हां। Aspose.Slides सूची स्वरूपण को बनाए रखता है जब लक्ष्य प्रारूप संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं को समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति को लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके ParagraphFormat.bullet सेटिंग्स को जांचें या अपडेट करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?**

हां। सूची आइटम टेक्स्ट में यूनिकोड अक्षर हो सकते हैं, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियों का निर्माण कर सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट उन अक्षरों को समर्थन करते हैं जिनकी आपको आवश्यकता है।