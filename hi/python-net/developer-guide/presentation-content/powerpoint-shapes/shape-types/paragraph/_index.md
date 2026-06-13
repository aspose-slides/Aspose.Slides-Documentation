---
title: Python में प्रस्तुतियों से पैराग्राफ सीमाएं प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/python-net/paragraph/
keywords:
  - पैराग्राफ सीमाएं
  - टेक्स्ट भाग सीमाएं
  - पैराग्राफ समन्वय
  - भाग समन्वय
  - पैराग्राफ आकार
  - टेक्स्ट भाग आकार
  - टेक्स्ट फ़्रेम
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET में पैराग्राफ और टेक्स्ट‑भाग सीमाएं कैसे प्राप्त करें, यह सीखें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में पैराग्राफ और टेक्स्ट भागों की सीमाएं, आकार, और समन्वय कैसे प्राप्त करें, यह समझाता है। यह `get_rect()` का उपयोग करके `TextFrame` में पैराग्राफ का आयत प्राप्त करने, टेबल सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ और भाग के समन्वय प्राप्त करने, तथा मापन इकाइयों, टेक्स्ट रैपिंग के सीमाओं पर प्रभाव, पिक्सेल रूपांतरण, और प्रभावी पैराग्राफ फ़ॉर्मेटिंग मानों जैसी महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ और भाग के समन्वय प्राप्त करें**

Aspose.Slides for Python via .NET का उपयोग करके, डेवलपर अब TextFrame की पैराग्राफ संग्रह में पैराग्राफ के आयताकार समन्वय प्राप्त कर सकते हैं। यह आपको पैराग्राफ के भाग संग्रह में भाग के समन्वय प्राप्त करने की अनुमति भी देता है। इस विषय में, हम एक उदाहरण की मदद से दिखाएंगे कि कैसे पैराग्राफ के आयताकार समन्वय तथा पैराग्राफ के भीतर भाग की स्थिति प्राप्त की जाए।

## **पैराग्राफ के आयताकार समन्वय प्राप्त करें**

नया मेथड **GetRect()** जोड़ा गया है। यह पैराग्राफ की सीमाओं का आयत प्राप्त करने की अनुमति देता है।

```py
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल को दर्शाता है
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **टेबल सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ और भाग का आकार प्राप्त करें** ##

टेबल सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) या [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) का आकार और समन्वय प्राप्त करने के लिए, आप [IPortion.GetRect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportion/) और [IParagraph.GetRect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iparagraph/) मेथड्स का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित ऑपरेशन को दर्शाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **आम प्रश्न**

**पैराग्राफ और टेक्स्ट भागों के लिए लौटाए गए समन्वय किस इकाई में मापे जाते हैं?**

प्वाइंट्स में, जहाँ 1 इंच = 72 प्वाइंट्स। यह स्लाइड पर सभी समन्वय और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमाओं को प्रभावित करती है?**

हां। यदि [wrapping](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/) [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में सक्रिय है, तो टेक्स्ट क्षेत्र की चौड़ाई में फिट होने के लिए टूट जाता है, जिससे पैराग्राफ की वास्तविक सीमाएँ बदल जाती हैं।

**क्या पैराग्राफ के समन्वय को निर्यातित छवि में पिक्सेल में भरोसेमंद रूप से मैप किया जा सकता है?**

हां। प्वाइंट्स को पिक्सेल में इस प्रकार बदलें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "effective" पैराग्राफ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**

[effective paragraph formatting data structure](/slides/hi/python-net/shape-effective-properties/) का उपयोग करें; यह इंडेंट्स, स्पेसिंग, रैपिंग, RTL आदि के लिए अंतिम संयुक्त मान लौटाता है।