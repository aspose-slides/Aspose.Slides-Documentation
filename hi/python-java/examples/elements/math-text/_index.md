---
title: गणितीय पाठ
type: docs
weight: 160
url: /hi/python-java/examples/elements/math-text/
keywords:
- कोड उदाहरण
- गणितीय पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के गणितीय पाठ उदाहरणों का पता लगाएँ: PPT, PPTX, और ODP प्रस्तुतियों में समीकरण, भिन्न, मैट्रिक्स और प्रतीकों को बनाएं और स्वरूपित करें।"
---
यह लेख गणितीय पाठ आकृतियों के साथ काम करने और समीकरणों को स्वरूपित करने के लिए **Aspose.Slides for Python via Java** का उपयोग दर्शाता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले आयात करता है, फिर JVM चलने के बाद API को आयात करता है।

## **गणितीय पाठ जोड़ें**

एक गणितीय आकृति बनाएं जिसमें एक भिन्न और पायथागोरस सूत्र शामिल हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड में एक गणितीय आकृति जोड़ें।
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # गणितीय अनुच्छेद तक पहुंचें।
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # एक साधारण भिन्न जोड़ें: x / y।
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # समीकरण जोड़ें: c² = a² + b²।
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **गणितीय पाठ तक पहुंचें**

स्लाइड पर एक गणितीय अनुच्छेद वाली आकृति को खोजें।

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # नीचे पाए जा सकने वाली एक गणितीय आकृति जोड़ें।
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # वह पहली आकृति खोजें जिसका गणितीय अनुच्छेद हो।
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # उदाहरण: एक भिन्न बनाएँ (यहाँ नहीं जोड़ा गया)।
        fraction = MathematicalText("x").divide("y")

        # आवश्यकतानुसार math_paragraph या fraction का उपयोग करें।
finally:
    presentation.dispose()
```

## **गणितीय पाठ हटाएं**

स्लाइड से एक गणितीय आकृति को हटाएं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # गणितीय आकृति हटाएँ।
finally:
    presentation.dispose()
```

## **गणितीय पाठ स्वरूपित करें**

गणितीय भाग के लिए फ़ॉन्ट गुण सेट करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```