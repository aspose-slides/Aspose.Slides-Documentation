---
title: Экспорт математических уравнений из презентаций в .NET
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/net/exporting-math-equations/
keywords:
- экспорт математических уравнений
- экспорт уравнений в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Экспорт математических уравнений из презентаций PowerPoint в LaTeX или MathML непосредственно с помощью Aspose.Slides для .NET."
---
## **Введение**

Aspose.Slides for .NET позволяет экспортировать математические уравнения из презентаций. Например, вам может понадобиться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения напрямую в LaTeX или в MathML — популярный стандарт для математического контента, используемый в вебе и многих приложениях.

{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может преобразовать уравнение PowerPoint напрямую в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Уравнение хранится в текстовом кадре как [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/). Используйте [MathPortion.MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/mathparagraph/) чтобы получить [IMathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/), а затем вызовите [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/tolatex/). Метод возвращает строку, которую можно сохранить, отобразить, отправить в другое приложение или дальше обработать.

В следующем примере рассматриваются все текстовые кадры на каждом слайде, находятся все математические порции и каждая формула записывается в отдельный файл `.tex`:

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextboxes/) возвращает все текстовые кадры, найденные на слайде. Проверка типа [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) отделяет подлинные редактируемые уравнения от обычного текста и изображений.

LaTeX‑движки и шаблоны документов поддерживают не одинаковый набор команд, пакетов и Unicode‑символов. Проверьте возвращённую строку с помощью LaTeX‑движка, используемого в вашем приложении. Если символ или элемент Office Math не имеет подходящего представления в этой среде, замените его в возвращённой строке командой, специфичной для проекта, либо пропустите уравнение и зафиксируйте проблему для последующего рассмотрения.

## **Сохранение математических уравнений в MathML**

В то время как человеку легко писать код для некоторых форматов уравнений, таких как LaTeX, писать код для MathML сложнее, поскольку он предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется как формат вывода и печати во многих областях. 

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

## **FAQ**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать либо весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые порции без [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) не экспортируемы как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспортируется стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые порции с [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) (то есть подлинные формулы PowerPoint), они экспортируются. Если формула вложена как изображение, она не экспортируется.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; оригинальный файл презентации не изменяется.