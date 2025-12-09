---
title: Экспорт математических уравнений из презентаций в .NET
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/net/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обеспечьте беспрепятственный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides for .NET — сохраняйте форматирование и повышайте совместимость."
---

## **Введение**

Aspose.Slides for .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML — популярный формат или стандарт для математических уравнений и подобного контента, используемого в вебе и многих приложениях. 

{{% /alert %}}

## **Сохранить математические уравнения как MathML**

Хотя человеку легко написать код для некоторых форматов уравнений, таких как LaTeX, ему сложно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML широко используется как формат вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:
```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```


## **FAQ**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать как весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)), так и отдельный блок ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) не экспортируются как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в приложениях и в вебе.

**Поддерживается ли экспорт формул внутри таблиц, SmartArt, групп и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (т.е. настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML оригинальную презентацию?**

Нет. Запись MathML является сериализацией содержимого формулы; она не изменяет файл презентации.