---
title: Операции Low-Code с презентациями в .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /ru/net/low-code-presentation-operations/
keywords:
- API low-code для презентаций
- конвертировать презентацию
- объединять презентации
- перебирать слайды
- перебирать фигуры
- перебирать текст
- собирать фигуры
- сжимать презентацию
- удалять неиспользуемые мастер‑слайды
- удалять неиспользуемые макетные слайды
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

Пространство имён [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/) предоставляет статические вспомогательные классы для распространённых операций с презентациями. Эти вспомогательные классы упаковывают часто используемые сценарии объектной модели в целевые методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные классы low‑code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/net/aspose.slides/) при необходимости детального контроля над отдельными слайдами, мастерами, макетами, фигурами, параметрами экспорта или связями между элементами презентации.

В следующей таблице суммированы доступные вспомогательные классы:

| Helper | Применение |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/) | Конвертирование презентации в другой формат прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) | Удаление неиспользуемых мастеров и макетов и уменьшение данных встраиваемых шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.AutoByExtension](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/autobyextension/) когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат из пути вывода и записывает результат.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/) также предоставляет отдельные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, если необходимо проверить или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен через выбранный вспомогательный класс. См. [Convert Presentation](/net/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.Process](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/process/) для объединения полных файлов презентаций одним вызовом. Входные презентации должны быть одного формата.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Вспомогательный класс подходит, когда все слайды необходимо добавить к единому результату без отдельного выбора или переназначения. Используйте полную объектную модель, если нужно объединить выбранные слайды, применить целевой мастер или макет, явно сохранить разделы или согласовать различные размеры слайдов. См. [Merge Presentations](/net/merge-presentation/) для этих сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов по коллекциям и удобен для инспекции или изменения форматирования по всей презентации.

Следующий пример использует [ForEach.Slide](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/paragraph/), и [ForEach.Portion](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/portion/) для инспекции соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, мастер‑ и макетные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы по коллекциям, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль родитель‑дочерних связей.

## **Собирать фигуры**

Используйте [Collect.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/shapes/) когда вам нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это удобно, если один и тот же набор будет отфильтрован, подсчитан или обработан более одного раза.

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

Используйте [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/) вместо этого, когда каждую фигуру можно обработать сразу и сохранять полученный результат не требуется.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) может удалять неиспользуемые структурные элементы и уменьшать данные встраиваемых шрифтов:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) удаляет макетные слайды, которые не используют обычные слайды.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) удаляет мастер‑слайды, которые больше не используются.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/compressembeddedfonts/) удаляет неиспользуемые символы из встроенных шрифтов.

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

Удаляйте неиспользуемые макеты перед неиспользуемыми мастерами, чтобы мастер, который станет неупомянутым после очистки макетов, тоже мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные мастера, макеты или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/net/slide-master/) и [Embedded Font](/net/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Используйте low‑code вспомогательные классы, когда стандартная операция применяется к полному файлу или презентации и не требует детального контроля над отдельными элементами. Применяйте полную объектную модель, если необходимо выбрать конкретные слайды, управлять связями мастеров и макетов, проверять промежуточное состояние или настраивать поведение, не доступное через вспомогательный класс.

**Может ли Merger объединять презентации разных форматов файлов?**

Нет. [Merger.Process](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/process/) требует, чтобы входные презентации были в одном и том же формате. Сначала конвертируйте входные файлы в общий формат, например с помощью [Convert.AutoByExtension](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/autobyextension/), а затем объедините полученные файлы.

**Обрабатывает ли ForEach мастер‑, макетные и слайды заметок?**

[ForEach.Slide](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/slide/) перебирает обычные слайды презентации. Операции [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/paragraph/) и [ForEach.Portion](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/portion/) по умолчанию включают обычные, мастер‑ и макетные слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.Shape и Collect.Shapes?**

Используйте [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/) для немедленной обработки каждой фигуры через обратный вызов. Применяйте [Collect.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/shapes/) когда нужен перечислимый результат, который можно сохранить, отфильтровать, подсчитать или пройти несколько раз.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, мастеров или встроенных шрифтов с неиспользуемыми символами. Если таких элементов нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, сделанные ForEach или Compress, автоматически?**

Нет. Эти вспомогательные классы работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) вызовите [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи результата.

## **Связанные статьи**

- [Конвертировать презентацию](/net/convert-presentation/)
- [Объединить презентации](/net/merge-presentation/)
- [Мастер слайда](/net/slide-master/)
- [Управление текстовым полем](/net/manage-textbox/)
- [Встроенный шрифт](/net/embedded-font/)