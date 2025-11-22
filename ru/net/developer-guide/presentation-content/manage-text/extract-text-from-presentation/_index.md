---
title: Продвинутое извлечение текста из презентаций на C#
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/net/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как быстро и легко извлекать текст из презентаций PowerPoint с помощью Aspose.Slides для .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время и эффективно получать доступ к содержимому слайдов в ваших приложениях."
---

## **Обзор**

Извлечение текста из презентаций — распространённая, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важен для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for .NET. Вы узнаете, как систематически проходить по элементам презентации для точного получения нужного текста.

## **Извлечение текста со слайда**

Aspose.Slides for .NET предоставляет пространство имён [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), которое включает класс [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). Этот метод принимает в качестве параметра объект типа [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). При выполнении метод сканирует весь слайд на наличие текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:
```cs
int slideIndex = 0;

// Создайте экземпляр класса Presentation, который представляет файл презентации (PPT, PPTX, ODP и т.д.).
using Presentation presentation = new Presentation("demo.pptx");

// Получите ссылку на слайд.
ISlide slide = presentation.Slides[slideIndex];

// Получите массив текстовых фреймов со слайда.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Итерируйтесь по массиву текстовых фреймов.
for (int i = 0; i < textFrames.Length; i++)
{
    // Итерируйтесь по абзацам в текущем текстовом фрейме.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Итерируйтесь по текстовым сегментам в текущем абзаце.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Отобразите текст текущего текстового сегмента.
            Console.WriteLine(portion.Text);

            // Отобразите высоту шрифта текста.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Отобразите название шрифта текста.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) класса [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлечён текст.
2. Затем значение `Boolean`, указывающее, следует ли включать слайды‑шаблоны при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), включающий информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая слайды‑шаблоны.
```cs
// Создайте экземпляр класса Presentation, который представляет файл презентации (PPT, PPTX, ODP и т.д.).
using Presentation presentation = new Presentation("demo.pptx");

// Получите массив текстовых фреймов со всех слайдов презентации.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Итерируйтесь по массиву текстовых фреймов.
for (int i = 0; i < textFrames.Length; i++)
{
    // Итерируйтесь по абзацам в текущем текстовом фрейме.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Итерируйтесь по текстовым сегментам в текущем абзаце.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Отобразите текст текущего текстового сегмента.
            Console.WriteLine(portion.Text);

            // Отобразите высоту шрифта текста.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Отобразите название шрифта текста.
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


Параметр‑перечисление [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) определяет режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` - Исходный текст без учёта его положения на слайде.
- `Arranged` - Текст располагается в том же порядке, что и на слайде.

Режим `Unarranged` можно использовать, когда важна скорость; он быстрее, чем режим `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) представляет собой необработанный текст, извлечённый из презентации. Он содержит свойство [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) из пространства имён [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), которое возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). Каждый объект представляет текст на соответствующем слайде. Объект типа [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) имеет следующие свойства:

- `Text` - Текст внутри фигур слайда.
- `MasterText` - Текст внутри фигур слайда‑шаблона, связанного с этим слайдом.
- `LayoutText` - Текст внутри фигур макетного слайда, связанного с этим слайдом.
- `NotesText` - Текст внутри фигур слайда заметок, связанного с этим слайдом.
- `CommentsText` - Текст внутри комментариев, связанных с этим слайдом.
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

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже крупные презентации, что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и графиков внутри презентаций?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет определённые ограничения, например, обработку лишь ограниченного количества слайдов. Для неограниченного использования и работы с большими презентациями рекомендуется приобрести полноценную лицензию.