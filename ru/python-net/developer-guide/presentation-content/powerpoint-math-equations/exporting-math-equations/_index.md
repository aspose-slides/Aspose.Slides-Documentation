---
title: Экспорт математических уравнений из презентаций в Python
linktitle: Экспорт уравнений
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
description: "Обеспечьте беспрепятственный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides для Python через .NET — сохраняйте форматирование и повышайте совместимость."
---

## **Введение**

Aspose.Slides для Python через .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь уравнения из определённых слайдов и использовать их в другой программе или платформе.

{{% alert color="primary" %}}

Вы можете экспортировать уравнения в MathML — широко используемый стандарт представления математического контента в вебе и во многих приложениях.

{{% /alert %}}

## **Сохранение математических уравнений в MathML**

Хотя люди легко пишут LaTeX, MathML обычно генерируется автоматически приложениями. Поскольку MathML основан на XML, программы могут надёжно читать и разбирать его, поэтому он часто используется в качестве формата вывода и печати во многих областях.

Ниже приведён пример кода, показывающий, как экспортировать математическое уравнение из презентации в MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**Что именно экспортируется в MathML — весь абзац или отдельный блок формулы?**

Вы можете экспортировать либо целый математический абзац ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде представляет собой математическую формулу, а не обычный текст или изображение?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Части текста и изображения без [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) не экспортируются как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или стандарт?**

Экспортируется в стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в различных приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**

Да, если эти объекты содержат части текста с [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (то есть настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, экспорт не производится.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML — это сериализация содержимого формулы; оригинальный файл презентации не изменяется.