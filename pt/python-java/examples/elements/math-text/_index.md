---
title: Texto Matemático
type: docs
weight: 160
url: /pt/python-java/examples/elements/math-text/
keywords:
- exemplo de código
- texto matemático
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Explore exemplos de texto matemático do Aspose.Slides for Python via Java: crie e formate equações, frações, matrizes e símbolos em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com formas de texto matemático e formatar equações usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e então importa a API após a JVM estar em execução.

## **Adicionar Texto Matemático**

Crie uma forma matemática contendo uma fração e a fórmula de Pitágoras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma matemática ao slide.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # Acessar o parágrafo matemático.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # Adicionar uma fração simples: x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Adicionar equação: c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **Acessar Texto Matemático**

Localize uma forma que contenha um parágrafo matemático no slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma matemática que pode ser encontrada abaixo.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # Encontrar a primeira forma que contém um parágrafo matemático.
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

        # Exemplo: criar uma fração (não adicionada aqui).
        fraction = MathematicalText("x").divide("y")

        # Usar math_paragraph ou fraction conforme necessário.
finally:
    presentation.dispose()
```

## **Remover Texto Matemático**

Exclua uma forma matemática do slide.

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

    # Remover a forma matemática.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **Formatar Texto Matemático**

Defina propriedades de fonte para uma parte matemática.

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