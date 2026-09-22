---
title: Сохранение презентаций в .NET
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/net/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предустановленный тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- .NET
- C#
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки на C# с помощью Aspose.Slides для .NET, а также настройте вывод PPTX и отчет о прогрессе."
---
## **Обзор**

После того как вы создадите презентацию или [откроете существующую](/slides/ru/net/open-presentation/), используйте метод [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи результата. Aspose.Slides для .NET может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и доступные параметры вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) методу [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Значение формата определяет тип файла, который создает Aspose.Slides.

В следующем примере создается презентация и сохраняется в файл PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Сохранение презентаций в их исходном формате**

Для примеров обнаружения файлов и потоков, поведения только что созданных презентаций и различий между исходным и выходным форматами см. [Определение исходного формата презентации](/slides/ru/net/detect-presentation-source-format/).

В приложении пакетной обработки входной формат может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат из свойства [IPresentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/sourceformat/). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/sourceformat/) методу [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/tosaveformat/) для получения соответствующего значения [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/), а затем используйте [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи изменённой презентации.

В следующем полном примере обрабатывается каждый файл во входном каталоге, обновляется его заголовок и сохраняется в выходном каталоге в том же формате, из которого был загружен:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/tosaveformat/) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он сопоставляет только форматы источника презентаций; не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недопустимого значения [SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/sourceformat/) приводит к возникновению [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если необходимо сохранять эти наследованные подтипы, сохраняйте оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени выходного файла и формата.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без указания конечного пути к файлу, передайте записываемый [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) и значение [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) методу [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Такой подход полезен, когда вывод должен быть возвращён из веб‑сервиса, сохранён в базе данных или обработан в памяти.

В следующем примере новая презентация сохраняется в файловый поток:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Сохранение презентаций с предопределённым типом представления**

Вы можете указать представление, в котором PowerPoint изначально открывает сохранённую презентацию. Установите свойство [ViewProperties.LastView](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/lastview/) в значение [ViewType](https://reference.aspose.com/slides/ru/net/aspose.slides/viewtype/) перед сохранением.

В следующем примере конфигурируется представление Slide Master как начальное представление:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/) и установите его свойство [Conformance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/conformance/) в `Conformance.Iso29500_2008_Strict`. Затем передайте параметры методу [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждой записи, общий размер архива и количество записей. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения ZIP64 повышают соответствующие ограничения по размеру и количеству записей.

Используйте свойство [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/zip64mode/) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- `IfNecessary` использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- `Never` отключает расширения ZIP64.
- `Always` всегда записывает расширения ZIP64.

В следующем примере расширения ZIP64 всегда включаются для выводимой презентации:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Если `Zip64Mode` установлен в `Never` и презентация не помещается в стандартные ограничения ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX вы можете сбалансировать скорость сохранения и размер файла, установив свойство [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/compressionlevel/). Перечисление [CompressionLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.export/compressionlevel/) предоставляет следующие значения:

- `None` сохраняет данные без сжатия.
- `Level1` обеспечивает самое быстрое сжатие и самый большой сжатый результат.
- `Level2`‑`Level5` постепенно отдают предпочтение меньшему размеру вывода в ущерб скорости сохранения.
- `Level6` балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- `Level7` и `Level8` ещё больше отдают предпочтение меньшему размеру вывода в ущерб скорости сохранения.
- `Level9` обеспечивает самое сильное сжатие и требует наибольшего времени обработки.

В следующем примере презентация сохраняется без сжатия:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

В следующем примере используется максимальный уровень сжатия:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Сохранение презентаций без обновления миниатюры**

При сохранении презентации в формате PPTX свойство [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/refreshthumbnail/) управляет её миниатюрой документа:

- `true` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `false` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides не генерирует её.

В следующем примере презентация сохраняется без обновления её миниатюры:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Чтобы отслеживать процесс сохранения, реализуйте интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iprogresscallback/) и назначьте эту реализацию свойству [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isaveoptions/progresscallback/). Затем Aspose.Slides будет вызывать метод [IProgressCallback.Reporting](https://reference.aspose.com/slides/ru/net/aspose.slides/iprogresscallback/reporting/) с значениями прогресса во время экспортa.

В следующем примере прогресс экспорта PDF выводится в консоль:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), основанный на API Aspose.Slides. Он сохраняет выбранные слайды презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементальное или «быстрое сохранение»?**

Нет. Каждая операция сохранения записывает полный выходной файл, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/net/multithreading/). Доступ к каждому экземпляру и его сохранение допускаются только из одного потока одновременно.

**Что происходит с гиперссылкам и внешними связанными файлами при сохранении презентации?**

[Hyperlinks](/slides/ru/net/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохранённая презентация должна по‑прежнему иметь доступ к их расположениям.

**Могу ли я сохранить метаданные документа, такие как автор, заголовок, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/net/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.