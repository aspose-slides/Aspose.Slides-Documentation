---
title: Получить границы фрагмента текста из презентаций в .NET
linktitle: Границы фрагмента
type: docs
weight: 47
url: /ru/net/portion-bounds/
keywords:
- границы фрагмента текста
- фрагмент текста
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как получить границы фрагмента текста в презентациях PowerPoint с помощью Aspose.Slides для .NET."
---
## **Обзор**

Фрагмент текста представляет собой конкретный кусок текста внутри абзаца и позволяет работать с этим куском независимо от окружающего содержимого. В Aspose.Slides фрагменты могут использоваться, когда необходимо получить границы текстового куска, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник фрагмента, используя [IPortion.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getrect/). Также показано, как получить координаты начала фрагмента, используя [IPortion.GetCoordinates](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getcoordinates/). Кроме того, рассмотрены распространённые сценарии, связанные с фрагментами, такие как применение гиперссылки к отдельному куску текста, понимание того, как форматирование наследуется через фрагмент, абзац, текстовый кадр и тему, а также обработка случаев, когда указанный шрифт недоступен.

## **Получить границы фрагмента текста**

Используйте [IPortion.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getrect/) для получения ограничивающего прямоугольника фрагмента текста:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Получить координаты фрагмента текста**

Используйте [IPortion.GetCoordinates](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/getcoordinates/) для получения координат начала фрагмента текста:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [assign a hyperlink](/slides/ru/net/manage-hyperlinks/) отдельному фрагменту; только этот кусок будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет фрагмент, а что берётся из абзаца или текстового кадра?**

Свойства уровня фрагмента имеют наивысший приоритет. Если свойство не задано на [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/), Aspose.Slides берёт его из [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/). Если оно не задано и там, Aspose.Slides использует стиль из [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) или [theme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/theme/).

**Что происходит, если указанный для фрагмента шрифт отсутствует на целевом компьютере или сервере?**

Применяются [Font substitution rules](/slides/ru/net/font-selection-sequence/). Текст может перераспределяться: могут измениться метрики, переносы и ширина, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного фрагмента независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) могут отличаться от соседних фрагментов.