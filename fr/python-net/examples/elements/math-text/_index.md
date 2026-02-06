---
title: TexteMath
type: docs
weight: 160
url: /fr/python-net/examples/elements/math-text/
keywords:
- texte mathématique
- ajouter du texte mathématique
- accéder au texte mathématique
- supprimer le texte mathématique
- formater le texte mathématique
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travaillez avec le texte mathématique en Python à l’aide d’Aspose.Slides : créez et modifiez des équations, des fractions, des radicaux, des scripts, le formatage, et générez les résultats pour PPT et PPTX."
---
Illustre la manipulation de formes de texte mathématique et le formatage d’équations à l’aide de **Aspose.Slides for Python via .NET**.

## **Ajouter du texte mathématique**

Créez une forme mathématique contenant une fraction et la formule de Pythagore.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter une forme Math à la diapositive.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Accéder au paragraphe mathématique.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Ajouter une fraction simple : x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Ajouter l'équation : c² = a² + b².
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

## **Accéder au texte mathématique**

Localisez une forme contenant un paragraphe mathématique sur la diapositive.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Trouver la première forme qui contient un paragraphe mathématique.
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

## **Supprimer le texte mathématique**

Supprimez une forme mathématique de la diapositive.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposant que la première forme est une forme avec du texte mathématique.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formater le texte mathématique**

Définissez les propriétés de police pour une portion mathématique.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposant que la première forme est une forme avec du texte mathématique.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```