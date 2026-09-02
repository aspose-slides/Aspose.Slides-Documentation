---
title: Получить и обновить информацию о презентации в .NET
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/net/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с использованием .NET для более быстрых выводов и более умных проверок контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные документа без создания полной модели объектов презентации. Это полезно, когда необходимо классифицировать файлы, составить инвентаризацию или проверить свойства перед тем, как решить, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируется лёгкая инспекция с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/) и [IPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/), а также целевые обновления с помощью [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/).

## **Проверка формата презентации**

Используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) чтобы проверить файл без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Свойство [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/loadformat/) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Создание лёгкой инвентаризации презентаций**

Когда вы обрабатываете большое количество файлов презентаций, может потребоваться компактная инвентаризация для проверки, индексации или системы управления документами. В этом сценарии используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) для получения объекта [IPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/), а затем вызовите [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/), дают следующие значения инвентаризации:

| Свойство | Значение в инвентаризации |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/slides/ru/) | Общее количество слайдов. |
| [HiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/hiddenslides/) | Количество скрытых слайдов. |
| [Notes](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/notes/) | Количество слайдов, содержащих заметки. |
| [Paragraphs](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/paragraphs/) | Общее количество абзацев, если доступно. |
| [Words](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/words/) | Общее количество слов. |
| [MultimediaClips](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/multimediaclips/) | Общее количество аудио- и видеоклипов. |

Следующий пример читает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и выводит компактную инвентаризацию. Он также комбинирует [HeadingPairs](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/headingpairs/) с [TitlesOfParts](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/titlesofparts/) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Каждый [IHeadingPair](https://reference.aspose.com/slides/ru/net/aspose.slides/iheadingpair/) поставляет имя группы и количество элементов в этой группе. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/titlesofparts/) представляет собой плоский упорядоченный массив, поэтому следует использовать количество последовательно указанных заголовков, заданных каждой парой заголовков.

### **Хранимые метаданные и ограничения формата**

Свойства инвентаризации, возвращаемые [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектов презентации для повторного вычисления этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, которое последним сохраняло файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчётов слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедийных клипов, а также пар заголовков и названий частей. Доступность зависит от того, какие свойства были записаны производителем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства сводки документа. Если свойство отсутствует или не было обновлено производителем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не вычисляет его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не соответствуют каждому расширенному свойству PowerPoint. Метаданные о скрытых слайдах, слайдах‑заметках, мультимедиа, паре заголовков и названиях частей могут быть недоступны, и свойства инвентаризации могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентаризаций и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/), также можно изменить без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Примените изменения с помощью [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), а затем запишите привязанную презентацию с помощью [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Следующее изображение показывает исходные свойства документа PowerPoint презентации.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Следующее изображение показывает изменённые свойства документа PowerPoint презентации.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и параметров защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/net/password-protected-presentation/) → Защита презентаций паролем
- [Write-Protect Presentations](/slides/ru/net/write-protected-presentation/) → Защита презентаций от записи

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/fontsmanager/). Вызовите [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getembeddedfonts/) для получения встроенных шрифтов и [FontsManager.GetFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для рендеринга, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и сколько их?**

Когда достаточно метаданных документа, прочитайте [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/hiddenslides/) через [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) и [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Это подходит для лёгкой инвентаризации. Если презентация была изменена в памяти, сохранённые метаданные могут быть отсутствующими или устаревшими, либо требуется проверка живых значений: пройдите по [Presentation.Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) и проверьте свойство [Slide.Hidden](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/hidden/) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и прочитайте [Presentation.SlideSize](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slidesize/). Проверьте [ISlideSize.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/ru/net/aspose.slides/islidesize/size/) и [ISlideSize.Orientation](https://reference.aspose.com/slides/ru/net/aspose.slides/islidesize/orientation/) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждый [Chart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chart/) и проверьте [ChartData.DataSourceType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/datasourcetype/). Для внешней книги Excel прочитайте [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности ресурса требует отдельной проверки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Единого свойства сложности не существует. Пройдите по [Presentation.Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) и коллекции [IBaseSlide.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/shapes/) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы, и измерьте представительный рендер или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.