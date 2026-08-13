---
title: "Экспорт математических уравнений из презентаций в .NET"
linktitle: "Экспорт уравнений"
type: docs
weight: 30
url: /ru/net/exporting-math-equations/
keywords:
- экспортировать математические уравнения
- экспортировать уравнения в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Экспортировать математические уравнения из презентаций PowerPoint в LaTeX или MathML напрямую с помощью Aspose.Slides для .NET."
---
## **Введение**

Aspose.Slides для .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="info" %}} 
Вы можете экспортировать уравнения напрямую в LaTeX или в MathML — популярный стандарт для математического контента, используемый в интернете и во многих приложениях.
{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может преобразовать математическое уравнение PowerPoint напрямую в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Математическое уравнение хранится в текстовом фрейме как [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/). Используйте [MathPortion.MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/mathparagraph/) чтобы получить [IMathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/), а затем вызовите [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/tolatex/). Метод возвращает строку, которую вы можете сохранить, отобразить, отправить в другое приложение или обработать дальше.

Следующий пример просматривает каждый текстовый фрейм на каждом слайде, находит все математические части и записывает каждое уравнение в отдельный файл `.tex`:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextboxes/) возвращает все текстовые фреймы, найденные на слайде. Проверка типа [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) отделяет настоящие редактируемые уравнения от обычного текста и изображений.

Движки LaTeX и шаблоны документов не поддерживают одинаковый набор команд, пакетов или символов Unicode. Проверьте возвращённую строку с помощью LaTeX‑движка, используемого в вашем приложении. Если символ или элемент Office Math не имеет подходящего представления в этой среде, замените его в возвращённой строке командой, специфичной для проекта, либо пропустите уравнение и зафиксируйте проблему для последующего рассмотрения.

## **Сохранение математических уравнений в MathML**

Хотя людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им сложно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы без труда читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Вопросы и ответы**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**  
Вы можете экспортировать как весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/)), так и отдельный блок ([MathBlock](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**  
Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**  
Экспорт нацелен на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для представления, которое широко используется в различных приложениях и в интернете.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**  
Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) (т.е. настоящие формулы PowerPoint), они экспортируются. Если формула встроена как изображение, она не экспортируется.

**Изменяется ли оригинальная презентация при экспорте в MathML?**  
Нет. Запись MathML представляет собой сериализацию содержимого формулы; она не изменяет файл презентации.