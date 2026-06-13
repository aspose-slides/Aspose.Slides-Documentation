---
title: गणितीय पाठ
type: docs
weight: 160
url: /hi/python-net/examples/elements/math-text/
keywords:
- गणितीय पाठ
- गणितीय पाठ जोड़ें
- गणितीय पाठ तक पहुँचें
- गणितीय पाठ हटाएँ
- गणितीय पाठ स्वरूपित करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में गणितीय पाठ के साथ काम करें: समीकरण, भिन्न, मूल, स्क्रिप्ट, स्वरूपण बनाएं और संपादित करें, और PPT तथा PPTX के लिए परिणाम रेंडर करें।"
---
**Aspose.Slides for Python via .NET** का उपयोग करके गणितीय पाठ आकृतियों के साथ काम करने और समीकरणों को स्वरूपित करने को दर्शाता है।

## **गणितीय पाठ जोड़ें**

एक गणितीय आकृति बनाएं जिसमें एक भिन्न और पायथागोरस सूत्र हो।

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # स्लाइड में एक गणितीय आकार जोड़ें।
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # गणितीय पैराग्राफ तक पहुँचें।
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # एक सरल भिन्न जोड़ें: x / y।
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # समीकरण जोड़ें: c² = a² + b²।
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **गणितीय पाठ तक पहुँचें**

स्लाइड पर वह आकृति खोजें जिसमें गणितीय अनुच्छेद हो।

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # गणितीय पैराग्राफ वाले पहले आकार को खोजें।
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **गणितीय पाठ हटाएँ**

स्लाइड से एक गणितीय आकृति मिटाएँ।

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार गणितीय पाठ वाला आकार है।
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **गणितीय पाठ स्वरूपित करें**

गणितीय भाग के लिए फॉन्ट गुण सेट करें।

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार गणितीय पाठ वाला आकार है।
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```