---
title: "Python via Java के माध्यम से प्रस्तुतियों में लाइन आकृतियों को जोड़ना"
linktitle: "लाइन"
type: docs
weight: 50
url: /hi/python-java/line/
keywords:
- "लाइन"
- "लाइन बनाएं"
- "लाइन जोड़ें"
- "साधारण लाइन"
- "लाइन कॉन्फ़िगर करें"
- "लाइन अनुकूलित करें"
- "डैश शैली"
- "तीर सिरा"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को व्यवस्थित करना सीखें। गुण, विधियों और उदाहरणों की खोज करें।"
---
## **परिचय**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन आकृतियां जोड़ने की अनुमति देता है। यह लेख दिखाता है कि एक साधारण लाइन कैसे बनाएं और लाइन को इस प्रकार अनुकूलित करें कि वह तीर जैसा दिखे।

आप सीखेंगे कि स्लाइड में लाइन आकृति कैसे जोड़ें, उसकी दृश्य उपस्थिति को कैसे समायोजित करें, और अद्यतन प्रस्तुति को सहेजें। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और फ़िल रंग पर केंद्रित हैं।

## **एक साधारण लाइन बनाएं**

प्रस्तुति की चयनित स्लाइड में एक साधारण लाइन जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
- इंडेक्स द्वारा एक स्लाइड का रेफरेंस प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट की [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) विधि का उपयोग करके एक लाइन आकृति जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निम्नलिखित उदाहरण प्रस्तुति की पहली स्लाइड में एक लाइन जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# प्रस्तुति (Presentation) क्लास का उदाहरण बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक लाइन आकृति जोड़ें।
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक एरो-आकार की लाइन बनाएं**

Aspose.Slides for Python via Java भी डेवलपर्स को लाइन गुण कॉन्फ़िगर करने की अनुमति देता है जिससे लाइन अधिक आकर्षक दिखे। लाइन को तीर जैसा बनाना चाहते हैं, तो नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
- इंडेक्स द्वारा एक स्लाइड का रेफरेंस प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट की [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) विधि का उपयोग करके एक लाइन आकृति जोड़ें।
- Aspose.Slides for Python via Java द्वारा प्रदान की गई शैलियों में से एक को [line style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linestyle/) के रूप में सेट करें।
- लाइन की चौड़ाई सेट करें।
- Aspose.Slides for Python via Java द्वारा प्रदान की गई शैलियों में से एक को [dash style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linedashstyle/) के रूप में सेट करें।
- लाइन की शुरुआत में [arrowhead style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linearrowheadstyle/) और [length](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linearrowheadlength/) सेट करें।
- लाइन के अंत में [arrowhead style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linearrowheadstyle/) और [length](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linearrowheadlength/) सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक लाइन आकृति जोड़ें।
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # लाइन पर फ़ॉर्मेटिंग लागू करें।
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित लाइन को कनेक्टर में बदल सकता हूँ ताकि वह आकृतियों से 'स्नैप' हो सके?**

नहीं। एक नियमित लाइन (एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) प्रकार की [Line](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/)) स्वतः कनेक्टर नहीं बनती। इसे आकृतियों से स्नैप करने के लिए समर्पित [Connector](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/python-java/connector/) का उपयोग करें।

**यदि लाइन के गुण थीम से विरासत में मिले हों और अंतिम मान निर्धारित करना कठिन हो तो मुझे क्या करना चाहिए?**

[लाइन और उसके फ़िल के प्रभावी गुण पढ़ें](/slides/hi/python-java/shape-effective-properties/) — ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखती हैं।

**क्या मैं एक लाइन को संपादन (हिलाने, आकार बदलने) से लॉक कर सकता हूँ?**

हाँ। शैलियों में [lock objects](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/#getAutoShapeLock) उपलब्ध होते हैं जो आपको [editing operations को निषिद्ध करने](/slides/hi/python-java/applying-protection-to-presentation/) की अनुमति देते हैं।