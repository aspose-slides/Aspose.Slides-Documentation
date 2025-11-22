---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /ru/net/exporting-math-equations/
keywords: "Экспорт математических уравнений, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Экспорт математических уравнений PowerPoint в C# или .NET"
---

## **Введение**

Aspose.Slides for .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и аналогичного контента, используемого в вебе и во многих приложениях. 

{{% /alert %}}

## **Сохранить математические уравнения в MathML**

Хотя людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им сложно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях. 

В этом примере кода показано, как экспортировать математическое уравнение из презентации в MathML:
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


## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать либо весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко используется в приложениях и в интернете.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/), то есть настоящие формулы PowerPoint, они экспортируются. Если формула внедрена как изображение, экспорт не производится.

**Изменяет ли экспорт в MathML исходную презентацию?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; она не изменяет файл презентации.