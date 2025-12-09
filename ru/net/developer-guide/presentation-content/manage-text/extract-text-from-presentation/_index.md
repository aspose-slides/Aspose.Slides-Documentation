---
title: Продвинутое извлечение текста из презентаций в .NET
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/net/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

## **Обзор**

Извлечение текста из презентаций – распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным и их получение могут быть критически важными для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for .NET. Вы узнаете, как систематически перебрать элементы презентации для точного получения необходимого текстового содержания.

## **Извлечение текста со слайда**

Aspose.Slides for .NET предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), которое включает класс [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Этот класс раскрывает несколько перегруженных статических методов для извлечения всего текста из презентации или отдельного слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). Этот метод принимает объект типа [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) в качестве параметра. При выполнении метод просматривает весь слайд в поиске текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:
```cs
int slideIndex = 0;

// Создайте экземпляр класса Presentation, представляющего файл презентации (PPT, PPTX, ODP и т.д.).
using Presentation presentation = new Presentation("demo.pptx");

// Get a reference to the slide.
ISlide slide = presentation.Slides[slideIndex];

// Get an array of text frames from the slide.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // Переберите абзацы в текущем текстовом фрейме.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Переберите части текста в текущем абзаце.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Выведите текст текущей части.
            Console.WriteLine(portion.Text);

            // Выведите высоту шрифта текста.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Выведите имя шрифта текста.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) класса [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлечён текст.  
2. Затем значение `Boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), включающий информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.
```cs
// Создать экземпляр класса Presentation, представляющего файл презентации (PPT, PPTX, ODP и т.д.).
using Presentation presentation = new Presentation("demo.pptx");

// Get an array of text frames from all slides in the presentation.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // Перебрать абзацы в текущем текстовом фрейме.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Перебрать части текста в текущем абзаце.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Вывести текст текущей части.
            Console.WriteLine(portion.Text);

            // Вывести высоту шрифта текста.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Вывести имя шрифта текста.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Категоризированное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) также предоставляет статические методы для извлечения всего текста из презентаций:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` – необработанный текст без учёта его позиции на слайде.  
- `Arranged` – текст упорядочен в том же порядке, что и на слайде.

Неупорядоченный режим может использоваться, когда важна скорость; он быстрее упорядоченного режима.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) представляет необработанный текст, извлечённый из презентации. Он содержит свойство [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) из пространства имён [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), которое возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). Каждый объект представляет текст на соответствующем слайде. Объект типа [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) имеет следующие свойства:

- `Text` – текст внутри фигур слайда.  
- `MasterText` – текст внутри фигур мастер‑слайда, связанного с данным слайдом.  
- `LayoutText` – текст внутри фигур шаблона слайда, связанного с данным слайдом.  
- `NotesText` – текст внутри фигур слайда заметок, связанного с данным слайдом.  
- `CommentsText` – текст внутри комментариев, связанных с этим слайдом.
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже крупные презентации, что делает его подходящим для сценариев в реальном времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайда, позволяя легко получать и анализировать всё текстовое содержание.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Текст можно извлекать с помощью бесплатной пробной версии Aspose.Slides, однако она имеет определённые ограничения, например, обработку ограниченного количества слайдов. Для неограниченного использования и работы с крупными презентациями рекомендуется приобрести полную лицензию.