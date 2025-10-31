---
title: Экспорт математических уравнений из презентаций на Python
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
description: "Обеспечьте бесшовный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides for Python via .NET — сохраняйте форматирование и повышайте совместимость."
---

## **Введение**

Aspose.Slides for Python via .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь уравнения с конкретных слайдов и повторно использовать их в другой программе или платформе.

{{% alert color="primary" %}}
Вы можете экспортировать уравнения в MathML — широко используемый стандарт представления математического контента в Интернете и во многих приложениях.
{{% /alert %}}

## **Сохранить математические уравнения как MathML**

Хотя люди могут легко писать LaTeX, MathML обычно генерируется автоматически приложениями. Поскольку MathML основан на XML, программы могут надёжно читать и разбирать его, поэтому он часто используется как формат вывода и печати во многих областях.

Следующий пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

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

## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать как весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)), так и отдельный блок ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) не экспортируются как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в приложениях и в Интернете.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (то есть настоящие формулы PowerPoint), они экспортируются. Если формула вставлена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML оригинальную презентацию?**

Нет. Запись MathML — это сериализация содержимого формулы; оригинальный файл презентации не изменяется.