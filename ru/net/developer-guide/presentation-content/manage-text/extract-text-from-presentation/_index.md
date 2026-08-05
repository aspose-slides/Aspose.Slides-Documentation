---
title: Продвинутое извлечение текста из презентаций в .NET
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/ru/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получить текст
- получить текст со слайда
- получить текст из презентации
- получить текст из PowerPoint
- получить текст из OpenDocument
- получить текст из PPT
- получить текст из PPTX
- получить текст из ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, работаете ли вы с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важным для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено подробное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides для .NET. Вы узнаете, как систематически перебрать элементы презентации, чтобы точно получить необходимое текстовое содержимое.

## **Извлечение текста со слайда**

Aspose.Slides для .NET предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/ru/net/aspose.slides.util/) , которое включает класс [SlideUtil](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/). Этот класс предлагает несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextboxes/). Этот метод принимает объект типа [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/) в качестве параметра. При выполнении метод сканирует весь слайд на предмет текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст из первого слайда презентации:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextframes/), предоставляемый классом [SlideUtil](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Во-первых, объект [IPresentation](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
1. Во-вторых, значение `Boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста из презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/), включающий информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Категоризированное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/net/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` — Неотсортированный текст без учёта его положения на слайде.
- `Arranged` — Текст, упорядоченный в том же порядке, что и на слайде.

Неотсортированный режим можно использовать, когда важна скорость; он быстрее, чем упорядоченный режим.

[IPresentationText](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationtext/) представляет сырой текст, извлечённый из презентации. Его свойство `SlidesText` возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/ru/net/aspose.slides/islidetext/). Каждый объект представляет текст на соответствующем слайде. Объект типа [ISlideText](https://reference.aspose.com/slides/ru/net/aspose.slides/islidetext/) имеет следующие свойства:

- `Text` — Текст внутри фигур слайда.
- `MasterText` — Текст внутри фигур мастер‑слайда, связанного с этим слайдом.
- `LayoutText` — Текст внутри фигур шаблона слайда, связанного с этим слайдом.
- `NotesText` — Текст внутри фигур слайда заметок, связанного с этим слайдом.
- `CommentsText` — Текст внутри комментариев, связанных с этим слайдом.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [крупные презентации](/slides/ru/net/open-presentation/), делая его подходящим для сценариев обработки в реальном времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да. Aspose.Slides может извлекать текст из множества элементов слайда, включая таблицы и объекты, связанные с диаграммами, что позволяет получать доступ к текстовому содержимому и анализировать его в типовых структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя у неё есть [определённые ограничения](/slides/ru/net/licensing/), например обработка только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.