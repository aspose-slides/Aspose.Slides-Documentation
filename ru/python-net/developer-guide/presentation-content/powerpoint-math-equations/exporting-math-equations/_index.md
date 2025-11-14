---
title: Экспорт математических уравнений из презентаций на Python
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/python-net/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Беспрепятственно экспортируйте математические уравнения из PowerPoint в MathML с помощью Aspose.Slides for Python via .NET — сохраняйте форматирование и повышайте совместимость."
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