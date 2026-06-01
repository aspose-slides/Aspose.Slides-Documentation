---
title: "Продвинутое извлечение текста из презентаций в .NET"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/net/extract-text-from-presentation/
keywords:
- "извлечение текста"
- "извлечение текста со слайда"
- "извлечение текста из презентации"
- "извлечение текста из PowerPoint"
- "извлечение текста из OpenDocument"
- "извлечение текста из PPT"
- "извлечение текста из PPTX"
- "извлечение текста из ODP"
- "получение текста"
- "получение текста со слайда"
- "получение текста из презентации"
- "получение текста из PowerPoint"
- "получение текста из OpenDocument"
- "получение текста из PPT"
- "получение текста из PPTX"
- "получение текста из ODP"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Overview**

Извлечение текста из презентаций — распространённая, но одновременно важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важным для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for .NET. Вы узнаете, как систематически перебрать элементы презентации, чтобы точно получить необходимый текстовый контент.

## **Extract Text from a Slide**

Aspose.Slides for .NET предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/ru/net/aspose.slides.util/), в котором находится класс [SlideUtil](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextboxes/). Метод принимает объект типа [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/) в качестве параметра. При выполнении метод сканирует весь слайд в поиске текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/), сохраняющий любое форматирование текста.

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

## **Extract Text from a Presentation**

Чтобы просканировать текст во всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextframes/) класса [SlideUtil](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Сначала объект [IPresentation](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлечён текст.
2. Затем значение `Boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/), включающий информацию о форматировании текста. Ниже приведён код, который сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

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

## **Categorized and Fast Text Extraction**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Аргумент‑перечисление [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/net/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` — Неупорядоченный текст без учёта его положения на слайде.
- `Arranged` — Текст упорядочен в том же порядке, что и на слайде.

Неупорядоченный режим можно использовать, когда важна скорость; он работает быстрее, чем упорядоченный режим.

[IPresentationText](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationtext/) представляет собой необработанный текст, извлечённый из презентации. Его свойство `SlidesText` возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/ru/net/aspose.slides/islidetext/). Каждый объект представляет текст соответствующего слайда. Объект типа [ISlideText](https://reference.aspose.com/slides/ru/net/aspose.slides/islidetext/) имеет следующие свойства:

- `Text` — Текст внутри фигур слайда.
- `MasterText` — Текст внутри фигур мастер‑слайда, связанного с этим слайдом.
- `LayoutText` — Текст внутри фигур шаблона слайда, связанного с этим слайдом.
- `NotesText` — Текст внутри фигур заметок слайда, связанного с этим слайдом.
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

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [large presentations](/slides/ru/net/open-presentation/), что делает его подходящим для сценариев реального времени или пакетной обработки.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Да. Aspose.Slides может извлекать текст из многих элементов слайда, включая таблицы и объекты, связанные с диаграммами, позволяя получать и анализировать текстовое содержание в типичных структурах презентаций.

**Do I need a special Aspose.Slides license to extract text from presentations?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя она имеет [certain limitations](/slides/ru/net/licensing/), например обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.