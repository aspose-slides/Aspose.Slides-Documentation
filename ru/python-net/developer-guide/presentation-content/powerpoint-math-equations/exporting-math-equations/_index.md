---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /python-net/exporting-math-equations/
keywords: "Экспорт математических уравнений, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Экспорт математических уравнений PowerPoint на Python"
---

Aspose.Slides для Python через .NET позволяет вам экспортировать математические уравнения из презентаций. Например, вам может понадобиться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и подобного контента, которые встречаются в Интернете и во многих приложениях.

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, они испытывают трудности с написанием кода для MathML, потому что последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код написан в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях.

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_math_shape(0, 0, 500, 50)
    mathParagraph = autoShape.text_frame.paragraphs[0].portions[0].math_paragraph

    mathParagraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as stream:
        mathParagraph.write_as_math_ml(stream)
```