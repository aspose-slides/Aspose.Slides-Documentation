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
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как сохранять презентации в .NET с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Open Presentations in C#](/slides/ru/net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, по завершении её нужно сохранить. С Aspose.Slides для .NET вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Передайте имени файла и формат сохранения в метод. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Выполните некоторую работу здесь...

    // Сохраните презентацию в файл.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `Save` класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Сохраните презентацию в поток.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/). Установите свойство [LastView](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/lastview/) в значение из перечисления [ViewType](https://reference.aspose.com/slides/ru/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить `Conformance.Iso29500_2008_Strict`, выходной файл будет сохранён в строгом формате Office Open XML. В примере ниже создаётся презентация и сохраняется в строгом формате Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Сохраните презентацию в строгом формате Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, накладывающий ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве до 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64. Свойство [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/zip64mode/) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML. Это свойство поддерживает следующие режимы:

- `IfNecessary` использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения ZIP64.
- `Always` всегда использует расширения ZIP64.

Ниже приведён код, демонстрирующий, как сохранить презентацию в файл PPTX с включёнными расширениями ZIP64:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
При сохранении с `Zip64Mode.Never` генерируется [PptxException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с большими презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от требований вы можете предпочесть более быструю обработку или более маленькие файлы. Aspose.Slides предоставляет свойство [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/compressionlevel/), которое позволяет указать уровень сжатия, используемый при сохранении презентации в формате Office Open XML. Доступны следующие уровни сжатия:

- **None**: Сжатие не применяется. Файлы сохраняются как есть.
- **Level1**: Самое быстрое сжатие с самым низким коэффициентом сжатия.
- **Level2**: Быстрее, чем Level1, с несколько лучшим коэффициентом сжатия.
- **Level3**: Обеспечивает лучшее сжатие, чем Level2, с умеренным влиянием на время обработки.
- **Level4**: Обеспечивает лучшее сжатие, чем Level3.
- **Level5**: Улучшает сжатие по сравнению с Level4, требуя дополнительного времени обработки.
- **Level6**: Стандартное сжатие, обеспечивающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- **Level7**: Обеспечивает лучшее сжатие, чем Level6, но с более медленной обработкой.
- **Level8**: Обеспечивает лучшее сжатие, чем Level7.
- **Level9**: Максимальное сжатие. Даёт наименьший размер файла, но требует самое длительное время обработки.

В следующем примере показано, как сохранить презентацию в файл PPTX *без сжатия*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Этот пример демонстрирует, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установить `true`, миниатюра обновляется при сохранении. Это значение по умолчанию.
- Если установить `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет создана.

В коде ниже презентация сохраняется в PPTX без обновления миниатюры.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iprogresscallback/) используется через свойство `ProgressCallback`, предоставляемое интерфейсом [ISaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/). Присвойте реализации [IProgressCallback] свойство `ProgressCallback`, чтобы получать обновления прогресса сохранения в процентах. Ниже приведены фрагменты кода, показывающие, как использовать `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Используйте здесь значение процента прогресса.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Компания Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter) с использованием собственного API. Приложение позволяет разбить презентацию на несколько файлов, сохранив выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживается ли «быстрое сохранение» (инкрементное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный файл назначения; инкрементное «быстрое сохранение» не поддерживается.

**Безопасно ли сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) [не является потокобезопасным]; сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Hyperlinks](/slides/ru/net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Могу ли я задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [document properties](/slides/ru/net/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.