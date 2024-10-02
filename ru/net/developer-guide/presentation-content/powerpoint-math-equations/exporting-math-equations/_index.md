---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /ru/net/exporting-math-equations/
keywords: "Экспорт математических уравнений, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Экспорт математических уравнений PowerPoint на C# или .NET"
---

Aspose.Slides для .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может понадобиться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и аналогичного контента, встречающегося в Интернете и во многих приложениях. 

{{% /alert %}}

Хотя людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им сложно написать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, так как его код написан в формате XML, поэтому MathML обычно используется в качестве формата вывода и печати в многих областях.

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