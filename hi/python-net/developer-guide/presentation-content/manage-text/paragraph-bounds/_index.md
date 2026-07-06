---
title: Python में प्रस्तुतियों से पैराग्राफ़ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ़ सीमाएँ
type: docs
weight: 43
url: /hi/python-net/paragraph-bounds/
keywords:
- पैराग्राफ़ सीमाएँ
- पैराग्राफ़ निर्देशांक
- पैराग्राफ़ आकार
- टेक्स्ट फ्रेम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python में .NET के माध्यम से पैराग्राफ़ सीमाएँ कैसे प्राप्त करें सीखें, ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides में पैराग्राफ़ की सीमाएँ, आकार और निर्देशांक कैसे प्राप्त करें। यह दिखाता है कि कैसे [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) से पैराग्राफ़ आयत प्राप्त करें [Paragraph.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/get_rect/) का उपयोग करके, तालिका सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ़ के निर्देशांक कैसे प्राप्त करें, और माप इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल परिवर्तन, तथा प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **पैराग्राफ़ के आयताकार निर्देशांक प्राप्त करें**

[Paragraph.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/get_rect/) का उपयोग करके पैराग्राफ़ का बाउंडिंग आयत प्राप्त करें।

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **तालिका सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ़ का आकार प्राप्त करें**

तालिका सेल टेक्स्ट फ्रेम में [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) का आकार और निर्देशांक प्राप्त करने के लिए, [Paragraph.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/get_rect/) का उपयोग करें। लौटाया गया आयत तालिका सेल टेक्स्ट फ्रेम के सापेक्ष होता है, इसलिए जब आपको स्लाइड‑स्तर के निर्देशांक चाहिए तो तालिका स्थिति और सेल ऑफ़सेट जोड़ें।

निम्नलिखित उदाहरण तालिका सेल के भीतर पैराग्राफ़ की सीमाएँ प्राप्त करता है और स्लाइड पर आयतें बनाता है ताकि उन सीमाओं को विज़ुअलाइज़ किया जा सके:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ़ निर्देशांक किस इकाई में मापे जाते हैं?**

वे पॉइंट्स में मापे जाते हैं, जहाँ 1 इंच बराबर 72 पॉइंट्स होता है। यह स्लाइड पर सभी निर्देशांक और मापों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ़ की सीमाओं को प्रभावित करती है?**

हाँ। यदि [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/) [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के लिए सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जो पैराग्राफ़ की वास्तविक सीमाओं को बदल देता है।

**क्या पैराग्राफ़ निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**

हाँ। पॉइंट्स को पिक्सेल में इस सूत्र से बदलें: pixels = points x (DPI / 72). परिणाम रेंडरिंग या निर्यात के लिए चुनी गई DPI पर निर्भर करता है।

**मैं "प्रभावी" पैराग्राफ़ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करूँ, जिसमें शैली विरासत को ध्यान में रखा जाए?**

[effective paragraph formatting data structure](/slides/hi/python-net/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL और अधिक के लिए अंतिम समेकित मान लौटाता है।