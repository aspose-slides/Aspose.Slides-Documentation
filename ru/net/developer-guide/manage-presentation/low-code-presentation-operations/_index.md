---
title: Операции презентаций с низким кодом в .NET
linktitle: API с низким кодом
type: docs
weight: 50
url: /ru/net/low-code-presentation-operations/
keywords:
- API презентаций с низким кодом
- конвертировать презентацию
- объединять презентации
- перебирать слайды
- перебирать фигуры
- перебирать текст
- собирать фигуры
- сжимать презентацию
- удалить неиспользуемые мастер-слайды
- удалить неиспользуемые макетные слайды
- сжимать встроенные шрифты
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в .NET для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) предоставляет статические вспомогательные классы для обычных операций с презентациями. Эти помощники оборачивают часто используемые рабочие процессы объектной модели в целевые методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные средства low‑code наиболее полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/), когда требуется тонкое управление отдельными слайдами, мастерами, макетами, фигурами, параметрами экспорта или связями между элементами презентации.

Следующая таблица суммирует доступные помощники:

| Помощник | Для чего используется |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Конвертирование презентации в другой формат прямым вызовом «файл‑в‑файл». |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Удаление неиспользуемых мастеров/макетов, уменьшение данных встроенных шрифтов и сжатие изображений. |

## **Конвертировать презентацию**

Используйте [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути выходного файла и записывает результат.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) также предоставляет выделенные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо проверить или изменить презентацию перед экспортом или настроить параметр экспорта, который не раскрыт выбранным помощником. См. [Convert Presentation](/slides/ru/net/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) для объединения полных файлов презентаций одной командой. Входные презентации должны иметь одинаковый формат файла.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Этот помощник уместен, когда все слайды должны быть добавлены к одному результату без индивидуального выбора или переназначения. Используйте полную объектную модель, когда нужно объединить выбранные слайды, применить целевой мастер или макет, явно сохранить разделы или согласовать разные размеры слайдов. См. [Merge Presentations](/slides/ru/net/merge-presentation/) для этих сценариев.

## **Итерация по элементам презентации**

Класс [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов перебора и удобен для инспекции или изменения форматирования по всей презентации.

Следующий пример использует [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), и [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) для инспекции соответствующих элементов:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

По умолчанию обход фигур и текста по всей презентации включает обычные, мастер‑ и макетные слайды. Перегруженные варианты с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль родитель‑дочерних отношений.

## **Собрать фигуры**

Используйте [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/), когда вам нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигурой. Это удобно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Используйте [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) вместо этого, когда каждую фигуру можно обрабатывать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) может удалять неиспользуемые структурные элементы и уменьшать данные встроенных шрифтов:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) удаляет макетные слайды, на которые не ссылаются обычные слайды.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) удаляет мастер‑слайды, которые больше не используются.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) удаляет неиспользуемые символы из встроенных шрифтов.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые мастера, чтобы мастер, ставший неотreferenced после очистки макетов, также мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные мастера, макеты или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/slides/ru/net/slide-master/) и [Embedded Font](/slides/ru/net/embedded-font/).

### **Сжать всю презентацию**

Aspose.Slides for .NET 26.11 добавляет [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Он объединяет удаление неиспользуемых макетных/мастер‑слайдов, подмножество используемых символов в встроенных шрифтах и сжатие изображений до 150 DPI. Используйте отдельные операции выше, когда нужно контролировать, какие изменения применяются.

Установите [Aspose.Slides for .NET](/slides/ru/net/installation/) 26.11 или новее и укажите `input.pptx`. Сохраните в отдельный файл: удалённые макеты, символы шрифтов и обрезанные пиксели изображений могут потребоваться для последующего редактирования.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Сжать изображения с выбранным разрешением**

Используйте [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) для обработки подходящих изображений без удаления макетов или подмножества шрифтов. В этом примере используется 96 DPI; выберите другое значение [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) для ваших потребностей вывода.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Оба помощника используют следующий диапазон обработки изображений:

| Содержание | Обработка |
| --- | --- |
| Растровые изображения и заливка фигур изображениями на обычных, мастер‑ и макетных слайдах, включая сгруппированные фигуры | Подлежат сжатию. |
| Изображения, уже имеющие требуемое разрешение или ниже | Не увеличиваются. Обрезанные области всё равно могут быть удалены. |
| Обрезанные области изображений | Скрытые пиксели удаляются навсегда, а смещения обрезки сбрасываются. |
| Фоны слайдов и заливки ячеек таблиц | Не обрабатываются этими помощниками. |
| Внутреннее содержание диаграмм/SmartArt, GIF и векторные форматы, такие как SVG, EMF и WMF | Вне задокументированного диапазона сжатия изображений. |

В версии 26.11 [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) предотвращает уменьшение разрешения необрезанных изображений, но **не сохраняет обрезанные пиксели**. Обрезанное изображение всё равно может быть записано с удалёнными скрытыми областями. Ни один из помощников не предоставляет параметр сохранения обрезки. Для индивидуального контроля см. [пример сжатия по отдельному изображению](/slides/ru/net/examples/optimization-batch/compression/).

Сравните внешний вид и размер файла результата перед заменой оригинала. Экономия зависит от исходных изображений, их отображаемого размера и неиспользуемого контента; сжатие не гарантирует уменьшения файла. См. [Embedded Fonts](/slides/ru/net/embedded-font/) для последствий подмножества шрифтов.

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Используйте low‑code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, когда нужно выбирать конкретные слайды, управлять связями мастеров и макетов, инспектировать промежуточное состояние или настраивать поведение, не раскрытое помощником.

**Может ли Merger объединять презентации разных форматов файлов?**

Нет. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) требует, чтобы входные презентации имели один и тот же формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), затем объедините полученные файлы.

**Обрабатывает ли ForEach мастер‑, макет‑ и слайды заметок?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) перебирает обычные слайды презентации. По всей презентации [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) и [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) включают обычные, мастер‑ и макетные слайды по умолчанию. Используйте их перегрузки с `includeNotes` = `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.Shape и Collect.Shapes?**

Используйте [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) для немедленной обработки каждой фигуры через обратный вызов. Используйте [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) когда нужен перечислимый результат, который можно сохранять, фильтровать, подсчитывать или обходить многократно.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Экономия зависит от неиспользуемых макетов/мастер‑слайдов, встроенных шрифтов с неиспользуемыми символами и изображений, которые выгодно сжать. Помощники [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) могут оставить размер без изменений или даже увеличить его для некоторых входных данных. Сравнивайте оба показателя — размер и качество отображения — и сохраняйте оригинал.

**Сохраняются ли изменения, сделанные ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) вызовите [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), чтобы записать результат.

## **Связанные статьи**

- [Convert Presentation](/slides/ru/net/convert-presentation/)
- [Merge Presentations](/slides/ru/net/merge-presentation/)
- [Slide Master](/slides/ru/net/slide-master/)
- [Manage Text Box](/slides/ru/net/manage-textbox/)
- [Embedded Font](/slides/ru/net/embedded-font/)