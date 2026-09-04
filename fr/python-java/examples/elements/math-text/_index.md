---
title: Texte mathématique
type: docs
weight: 160
url: /fr/python-java/examples/elements/math-text/
keywords:
- exemple de code
- texte mathématique
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Explorez les exemples de texte mathématique d'Aspose.Slides pour Python via Java : créez et mettez en forme des équations, des fractions, des matrices et des symboles dans les présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec des formes de texte mathématique et mettre en forme des équations à l’aide de **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l’API une fois la JVM en cours d’exécution.

## **Ajouter du texte mathématique**

Créez une forme mathématique contenant une fraction et la formule pythagoricienne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme mathématique à la diapositive.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # Accéder au paragraphe mathématique.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # Ajouter une fraction simple : x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Ajouter une équation : c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **Accéder au texte mathématique**

Localisez une forme qui contient un paragraphe mathématique sur la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme mathématique qui peut être trouvée ci-dessous.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # Trouver la première forme qui contient un paragraphe mathématique.
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

        # Exemple : créer une fraction (non ajoutée ici).
        fraction = MathematicalText("x").divide("y")

        # Utiliser math_paragraph ou fraction selon les besoins.
finally:
    presentation.dispose()
```

## **Supprimer le texte mathématique**

Supprimez une forme mathématique de la diapositive.

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

    # Supprimer la forme mathématique.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **Formater le texte mathématique**

Définissez les propriétés de police pour une portion mathématique.

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