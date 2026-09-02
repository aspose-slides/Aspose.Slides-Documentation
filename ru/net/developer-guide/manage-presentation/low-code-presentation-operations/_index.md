---
title: Операции low-code презентаций в .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /ru/net/low-code-presentation-operations/
keywords:
- low-code API презентаций
- конвертация презентации
- объединение презентаций
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удаление неиспользуемых мастер‑слайдов
- удаление неиспользуемых макетных слайдов
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в .NET для конвертации и объединения презентаций, перебора содержимого, сбора фигур и сокращения размера презентации."
---
## **Обзор**

Пространство имён [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/) предоставляет статические вспомогательные классы для общих операций с презентациями. Эти вспомогательные классы инкапсулируют часто используемые рабочие процессы объектной модели в специализированных методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные функции low‑code наиболее полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/net/aspose.slides/) при необходимости детального управления отдельными слайдами, шаблонами, макетами, фигурами, параметрами экспорта или взаимосвязями между элементами презентации.

Ниже представлена таблица с доступными вспомогательными классами:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/) | Конвертация презентации в другой формат с прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) | Удаление неиспользуемых шаблонов и макетов и уменьшение встроенных данных шрифтов. |

## **Конвертация презентации**

Используйте [Convert.AutoByExtension](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/autobyextension/) когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути к выходному файлу и записывает результат.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо изучить или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен в выбранном помощнике. См. [Convert Presentation](/slides/ru/net/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединение презентаций**

Используйте [Merger.Process](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/process/) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь одинаковый файловый формат.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к одному результату без индивидуального выбора или переопределения. Используйте полную объектную модель, когда нужно объединять выбранные слайды, применять целевой шаблон или макет, явно сохранять секции или согласовать разные размеры слайдов. См. [Merge Presentations](/slides/ru/net/merge-presentation/) для таких сценариев.

## **Итерация по элементам презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов перебора коллекций и удобен для проверки или изменения параметров по всей презентации.

В следующем примере используются [ForEach.Slide](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/paragraph/) и [ForEach.Portion](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/portion/) для проверки соответствующих элементов:

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

По умолчанию обход всех фигур и текста в презентации включает обычные, шаблонные и макетные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация перед вызовом обратного вызова или детальный контроль родитель‑дочерних отношений.

## **Сбор фигур**

Используйте [Collect.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/shapes/) когда нужен набор всех фигур в презентации, а не обратный вызов для каждой фигуры. Это удобно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

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

Применяйте [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжатие содержимого презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных шрифтов:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) удаляет макетные слайды, на которые не ссылаются обычные слайды.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) удаляет шаблонные слайды, которые больше не используются.
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

Сначала удаляйте неиспользуемые макетные слайды, а затем неиспользуемые шаблоны, чтобы шаблон, ставший неиспользуемым после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться исходные шаблоны, макеты или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/slides/ru/net/slide-master/) и [Embedded Font](/slides/ru/net/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Используйте low‑code помощники, когда стандартная операция применяется к целому файлу или презентации и не требует детального управления отдельными элементами. Применяйте полную объектную модель, если необходимо выбрать конкретные слайды, управлять связями шаблонов и макетов, изучать промежуточное состояние или настраивать поведение, которое помощник не раскрывает.

**Может ли Merger объединять презентации разных файловых форматов?**

Нет. [Merger.Process](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/merger/process/) требует, чтобы входные презентации имели один и тот же формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.AutoByExtension](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/convert/autobyextension/), а затем объедините полученные файлы.

**Обрабатывает ли ForEach шаблонные, макетные и слайды заметок?**

[ForEach.Slide](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/slide/) проходит только по обычным слайдам презентации. По всей презентации [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/paragraph/) и [ForEach.Portion](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/portion/) включают обычные, шаблонные и макетные слайды по умолчанию. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.Shape и Collect.Shapes?**

Применяйте [ForEach.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/shape/) для непосредственной обработки каждой фигуры через обратный вызов. Используйте [Collect.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/collect/shapes/) когда нужен перечисляемый результат, который можно сохранить, отфильтровать, подсчитать или пройти несколько раз.

**Всегда ли Compress уменьшает размер файла презентации?**

Не обязательно. Результат зависит от наличия неиспользуемых макетов, шаблонов или встроенных шрифтов с неиспользуемыми символами. Если таких элементов нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/) вызовите [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи результата.

## **Связанные статьи**

- [Convert Presentation](/slides/ru/net/convert-presentation/)
- [Merge Presentations](/slides/ru/net/merge-presentation/)
- [Slide Master](/slides/ru/net/slide-master/)
- [Manage Text Box](/slides/ru/net/manage-textbox/)
- [Embedded Font](/slides/ru/net/embedded-font/)