---
title: Python via Java का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- पैराग्राफ
- पाठ स्वरूपण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python via Java में फ़ॉन्ट नियंत्रित करें: कस्टम फ़ॉन्ट एम्बेड, प्रतिस्थापित, और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियों को स्पष्ट, ब्रांड-सेफ और सुसंगत रखा जा सके।"
---
## **अवलोकन**

Aspose.Slides आपको कोड से सीधे प्रस्तुति पाठ में फ़ॉन्ट गुणों का प्रबंधन करने देती है। आप स्लाइड में आकृतियों, टेक्स्ट फ़्रेम, पैराग्राफ़ और हिस्सों (Portion) के माध्यम से पाठ तक पहुँच सकते हैं और फिर चयनित पाठ पर स्वरूपण लागू कर सकते हैं।

यह लेख प्रस्तुति में मौजूदा पाठ के लिए फ़ॉन्ट‑संबंधी गुणों को कॉन्फ़िगर करने के बारे में बताता है, जिसमें फ़ॉन्ट परिवार, बोल्ड और इटैलिक शैलियों, पैराग्राफ़ संरेखण और फ़ॉन्ट रंग शामिल हैं। यह एक टेक्स्ट बॉक्स बनाने, उसमें टेक्स्ट जोड़ने और फ़ॉन्ट परिवार, बोल्ड, इटैलिक, अंडरलाइन, फ़ॉन्ट आकार और रंग जैसी फ़ॉन्ट गुण सेट करने तथा परिणाम को PPTX फ़ाइल के रूप में सहेजने का भी प्रदर्शन करता है।

## **फ़ॉन्ट‑संबंधी गुणों का प्रबंधन**
{{% alert color="info" title="Note" %}} 

प्रेजेंटेशन में आम तौर पर टेक्स्ट और छवियों दोनों का मिश्रण होता है। टेक्स्ट को विभिन्न तरीकों से स्वरूपित किया जा सकता है, चाहे वह विशिष्ट अनुभागों और शब्दों को उजागर करने के लिए हो या कॉर्पोरेट शैली के अनुरूप बनाने के लिए। टेक्स्ट फ़ॉर्मेटिंग उपयोगकर्ताओं को प्रस्तुति की सामग्री की दिखावट को विविध बनाने में मदद करती है। यह लेख Aspose.Slides for Python via Java का उपयोग करके स्लाइड पर टेक्स्ट पैराग्राफ़ के फ़ॉन्ट गुणों को कॉन्फ़िगर करने का तरीका बताता है।

{{% /alert %}} 

Python via Java के लिए Aspose.Slides का उपयोग करके पैराग्राफ़ के फ़ॉन्ट गुणों को प्रबंधित करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएँ।
2. इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में [Placeholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/) आकृतियों तक पहुँचें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) के रूप में उपयोग करें।
4. [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) द्वारा प्रकट [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) प्राप्त करें।
5. पैराग्राफ़ को जस्टिफ़ाइ करें।
6. किसी [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) के पाठ [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) तक पहुँचें।
7. [FontData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट निर्धारित करें और टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) का **Font** तदनुसार सेट करें।
   1. फ़ॉन्ट को बोल्ड सेट करें।
   1. फ़ॉन्ट को इटैलिक सेट करें।
8. [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) वस्तु द्वारा प्रकट [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) का उपयोग करके फ़ॉन्ट रंग सेट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

ऊपर बताए गए चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रस्तुति लेता है और उसकी एक स्लाइड के फ़ॉन्ट को स्वरूपित करता है। निम्नलिखित स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट्स के द्वारा किए गए परिवर्तन को दर्शाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट शैली को बदलता है।

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में पाठ**|

|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: समान पाठ को अद्यतन स्वरूप के साथ**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# प्रस्तुति लोड करें।
presentation = Presentation("FontProperties.pptx")
try:
    # पहले स्लाइड तक पहुंचें और उसके पहले दो प्लेसहोल्डर्स के टेक्स्ट फ्रेम तक पहुंचें।
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # प्रत्येक टेक्स्ट फ्रेम में पहला पैराग्राफ एक्सेस करें।
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # प्रत्येक पैराग्राफ में पहला पोर्शन एक्सेस करें।
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # नए फ़ॉन्ट परिभाषित करें और असाइन करें।
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # फ़ॉन्ट को बोल्ड और इटैलिक सेट करें।
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # फ़ॉन्ट रंग सेट करें।
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # प्रस्तुति सहेजें।
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पाठ फ़ॉन्ट गुण सेट करें**
{{% alert color="info" title="Note" %}} 

जैसा कि **फ़ॉन्ट‑संबंधी गुणों का प्रबंधन** में बताया गया है, एक [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) का उपयोग पैराग्राफ़ में समान स्वरूप शैली वाले पाठ को रखने के लिए किया जाता है। यह लेख Aspose.Slides for Python via Java का उपयोग करके एक टेक्स्ट बॉक्स बनाता है, उसमें कुछ टेक्स्ट डालता है और फिर किसी विशिष्ट फ़ॉन्ट तथा विभिन्न फ़ॉन्ट गुण निर्धारित करता है।

{{% /alert %}} 

टेक्स्ट बॉक्स बनाने और उसके भीतर के टेक्स्ट के फ़ॉन्ट गुण सेट करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएँ।
2. इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में **Rectangle** प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) से जुड़े भराव (fill) शैली को हटाएँ।
5. [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
6. [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
7. [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) से जुड़े [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) वस्तु तक पहुँचें।
8. उस [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) के लिए उपयोग किए जाने वाले फ़ॉन्ट को निर्धारित करें।
9. [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) वस्तु द्वारा प्रकट संबंधित गुणों का उपयोग करके बोल्ड, इटैलिक, अंडरलाइन, रंग और ऊँचाई जैसे अन्य फ़ॉन्ट गुण सेट करें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

ऊपर बताए गए चरणों का कार्यान्वयन नीचे दिया गया है।

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for Python via Java द्वारा सेट कुछ फ़ॉन्ट गुणों वाला पाठ**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें और एक आयत जोड़ें।
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # आकार का भराव हटाएँ।
    shape.getFillFormat().setFillType(FillType.NoFill)

    # आकार के टेक्स्ट फ्रेम में टेक्स्ट जोड़ें।
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # फ़ॉन्ट परिवार सेट करें।
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # बोल्ड, इटैलिक, अंडरलाइन और फ़ॉन्ट आकार सेट करें।
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # फ़ॉन्ट रंग सेट करें।
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # प्रस्तुति सहेजें।
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```