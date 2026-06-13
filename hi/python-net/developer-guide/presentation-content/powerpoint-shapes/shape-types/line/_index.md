---
title: प्रस्तुति में Python के साथ रेखा आकार बनाएं
linktitle: रेखा
type: docs
weight: 50
url: /hi/python-net/line/
keywords:
- रेखा
- रेखा बनाएं
- रेखा जोड़ें
- साधारण रेखा
- रेखा कॉन्फ़िगर करें
- रेखा अनुकूलित करें
- डैश शैली
- तीर सिरा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुति में Aspose.Slides for Python via .NET के साथ रेखा स्वरूपण को संशोधित करना सीखें। गुणों, विधियों और उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET विभिन्न प्रकार के आकारों को स्लाइड्स में जोड़ने को समर्थन देता है। इस विषय में, हम आकारों के साथ काम शुरू करेंगे, स्लाइड्स में रेखाएँ जोड़कर। Aspose.Slides का उपयोग करके, डेवलपर्स केवल साधारण रेखाएँ ही नहीं, बल्कि कुछ आकर्षक रेखाएँ भी स्लाइड्स पर बना सकते हैं।

## **साधारण रेखाएँ बनाएँ**

Aspose.Slides का उपयोग करके एक स्लाइड में एक साधारण रेखा को साधारण विभाजनकर्ता या कनेक्टर के रूप में जोड़ें। प्रस्तुति में चयनित स्लाइड में एक साधारण रेखा जोड़ने के लिए, निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. `add_auto_shape` मेथड का उपयोग करके, [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) ऑब्जेक्ट पर प्रकार `LINE` की एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिए गए उदाहरण में, प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी गई है।

```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # प्रकार LINE की एक ऑटो शैप जोड़ें।
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **तीर के आकार वाली रेखाएँ बनाएँ**

Aspose.Slides आपको रेखा गुणों को कॉन्फ़िगर करने देता है ताकि वह अधिक दृश्यात्मक रूप से आकर्षक बन सके। नीचे, हम रेखा के कुछ गुणों को इस प्रकार कॉन्फ़िगर करते हैं कि वह तीर जैसा दिखे। निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. `add_auto_shape` मेथड का उपयोग करके, [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) ऑब्जेक्ट पर प्रकार `LINE` की एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. [line style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. रेखा के [dash style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linedashstyle/) को सेट करें।
1. रेखा के प्रारंभ बिंदु के लिए [arrowhead style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linearrowheadstyle/) और लंबाई सेट करें।
1. रेखा के समाप्ति बिंदु के लिए arrowhead style और लंबाई सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # प्रकार LINE की एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # रेखा पर फ़ॉर्मेटिंग लागू करें।
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक सामान्य रेखा को कनेक्टर में बदल सकता हूँ ताकि वह आकृतियों से “स्नैप” हो जाए?**

नहीं। एक सामान्य रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जिसका प्रकार [LINE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapetype/)) स्वचालित रूप से कनेक्टर नहीं बनती। इसे आकृतियों से स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/python-net/aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/python-net/connector/) का उपयोग करें।

**यदि एक रेखा के गुण थीम से विरासत में मिले हों और अंतिम मान निर्धारित करना कठिन हो तो मुझे क्या करना चाहिए?**

[प्रभावी गुण पढ़ें](/slides/hi/python-net/shape-effective-properties/) के माध्यम से [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilinefillformateffectivedata/) क्लासेस को पढ़ें—ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं रेखा को संपादन (स्थानांतरण, आकार बदलने) से रोक सकता हूँ?**

हाँ। आकार [lock objects](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/auto_shape_lock/) प्रदान करते हैं जो आपको [संपादन कार्यों को अक्षम करने](/slides/hi/python-net/applying-protection-to-presentation/) की अनुमति देते हैं।