---
title: Изменение размера и ориентации страницы заметок в .NET
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/net/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- книжные заметки
- размер раздаточного листа
- PowerPoint
- презентация
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для .NET, смена ориентации, проверка сохранённых размеров и экспорт заметок или раздаточных листов в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.NotesSize](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/notessize/) для доступа к настройкам страницы заметок презентации. Он возвращает объект [INotesSize](https://reference.aspose.com/slides/ru/net/aspose.slides/inotessize/) с доступным для записи свойством [Size](https://reference.aspose.com/slides/ru/net/aspose.slides/inotessize/size/). Хотя сам объект настроек только для чтения, вы можете присвоить новые размеры его свойству size.

Ширина и высота задаются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек — это 12,5 × 8⅓ дюйма. Эти настройки применяются ко всей презентации, а не к отдельной странице заметок слайда.

| Setting | Purpose |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/notessize/) | Управляет размерами страницы заметок и размерами страниц, используемыми при экспорте раздаточных материалов. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slidesize/) | Управляет обычными размерами слайдов презентации через [ISlideSize](https://reference.aspose.com/slides/ru/net/aspose.slides/islidesize/). |

Изменение любой из настроек не меняет автоматически другую. Поворот ориентации страницы заметок также не вращает обычные слайды. См. [Slide Size](/slides/ru/net/slide-size/) для изменения размеров обычных слайдов.

Примеры ниже используют существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую хотя бы один слайд с примечаниями. Каждый пример можно запускать независимо.

## **Чтение размера и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — книжная, одинаковые размеры — квадратная страница. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Переход в альбомную ориентацию без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длину обеих сторон, в том числе при пользовательском размере бумаги. Условие ниже запрещает переключать уже альбомную страницу обратно в книжную и оставляет квадратную страницу без изменений.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Для книжной ориентации используйте то же присваивание, когда `size.Width > size.Height`. Не заменяйте размеры A4 или Letter, если только не хотите изменить размер бумаги.

## **Установка и проверка пользовательского размера страницы заметок**

Присвойте оба измерения одновременно, затем используйте [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи презентации. Этот пример задаёт альбомную страницу 900 × 600 точек, сохраняет её как PPTX и снова открывает файл, чтобы проверить сохранённые значения. Сравнение допускает погрешность 0,01 точки для чисел с плавающей запятой; это не гарантирует абсолютную точность для каждого формата файла.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Ожидаемый результат: `900 x 600 points` и `Size preserved: True`. Проверка только что открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страницы определяют доступную область для макетов заметок или раздаточных листов. Они не активируют эти макеты сами по себе: необходимо также настроить параметры экспорта. Экспорт обычных слайдов продолжает использовать размеры слайда.

### **Экспорт заметок в PDF и PNG**

Присвойте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notescommentslayoutingoptions/) свойству [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/slideslayoutoptions/), чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage/) и [RenderingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notespositions/) оставляет заметки на одной странице; заметки, не помещающиеся полностью, могут быть усечены. PDF использует страницы 900 × 600 точек. При масштабе изображения 1 × 1, указанном ниже, PNG будет 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели — растровый вывод, размеры которого также зависят от масштаба рендеринга.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Для экспорта PDF с длинными заметками режим [BottomFull](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notespositions/) добавляет дополнительные страницы при необходимости. Не используйте этот режим с вызовом рендеринга одиночного слайда выше, так как он его не поддерживает. После изменения размеров проверьте вывод на предмет обрезанных заметок и расположения существующих объектов notes‑master; изменение только размеров страницы не гарантирует, что весь контент поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/net/convert-powerpoint-to-pdf-with-notes/) для более подробного описания экспорта заметок.

### **Экспорт раздаточных материалов в PDF**

Для размещения нескольких миниатюр слайдов на одной странице используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handoutlayoutingoptions/). В следующем примере задаётся страница 900 × 600 точек и используется [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ru/net/aspose.slides.export/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальный предустановленный вариант управляет порядком слайдов; ориентация страницы берётся из её ширины и высоты.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Изменение размера страницы меняет область, доступную для сетки раздаточных листов, не затрагивая размеры исходных слайдов. Для изображений раздаточных листов используйте [Presentation.GetImages](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages/) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных листов на уровне презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздаточного листа. См. [Handout Mode](/slides/ru/net/convert-powerpoint-in-handout-mode/) для вариантов макета.

## **Размер страницы в средствах просмотра, экспорте и печати**

Сохраняйте различие между размером, хранящимся в презентации, экспортируемым размером страницы и размером бумаги при печати:

- **Средства просмотра презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила компоновки. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; преобразование формата в этом приложении может их нормализовать.
- **Форматы экспорта:** Примеры PDF с заметками и раздаточными листами выше используют заданные размеры страницы. Растровые изображения используют целочисленные размеры пикселей и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в результате изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтеров:** Выбор бумаги, автоматический поворот и параметры «подогнать к странице» могут менять физический вывод без изменения размеров, сохранённых в презентации или PDF. Для конкретного размера бумаги согласуйте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Можно ли установить размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне презентации. У отдельных слайдов может быть разное содержание заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Для изменения размеров самих слайдов используйте настройки обычного размера слайда.

**Почему сохранённый или распечатанный результат имеет иной размер?**

Сначала откройте вновь сохранённую презентацию и сравните её размеры заметок. Если они изменились, проверьте, изменило ли сохранение или конвертация файла в другом приложении настройки страницы. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбранный тип бумаги принтера.