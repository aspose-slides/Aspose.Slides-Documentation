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
- предопределенный тип представления
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

[Open Presentations in C#](/slides/ru/net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вы захотите сохранить её после завершения работы. С Aspose.Slides для .NET вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.

```cs
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Выполните здесь некоторые действия...

    // Сохраните презентацию в файл.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `Save` класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Презентацию можно записать во многие типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

```cs
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
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pptxoptions/), установив его свойство conformance при сохранении. Если задать `Conformance.Iso29500_2008_Strict`, выходной файл будет сохранён в строгом формате Office Open XML.

Пример ниже создаёт презентацию и сохраняет её в строгом формате Office Open XML.

```cs
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

Файл Office Open XML является ZIP‑архивом, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве до 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Свойство [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/zip64mode/) позволяет выбрать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Это свойство поддерживает следующие режимы:

- `IfNecessary` использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения ZIP64.
- `Always` всегда использует расширения ZIP64.

Следующий код демонстрирует, как сохранить презентацию в файл PPTX с включёнными расширениями ZIP64:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
При сохранении с `Zip64Mode.Never` будет выброшено исключение [PptxException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с крупными презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от ваших требований вы можете предпочесть более быструю обработку или более мелкие файлы.

Aspose.Slides предоставляет свойство [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/compressionlevel/), позволяющее указать уровень сжатия, используемый при сохранении презентации в формате Office Open XML.

Доступные уровни сжатия:

- **None**: Сжатие не применяется. Файлы сохраняются как есть.
- **Level1**: Самое быстрое сжатие с наименьшим коэффициентом сжатия.
- **Level2**: Сжатие быстрее, с немного лучшим коэффициентом, чем **Level1**.
- **Level3**: Обеспечивает лучшее сжатие, чем **Level2**, с умеренным влиянием на время обработки.
- **Level4**: Лучше сжимает, чем **Level3**.
- **Level5**: Улучшенное сжатие по сравнению с **Level4**, но требует дополнительного времени обработки.
- **Level6**: Стандартное сжатие, обеспечивающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- **Level7**: Лучше сжимает, чем **Level6**, но процесс медленнее.
- **Level8**: Лучше сжимает, чем **Level7**.
- **Level9**: Максимальное сжатие. Дает наименьший размер файла, но требует наибольшего времени обработки.

Следующий пример демонстрирует, как сохранить презентацию в файл PPTX *без сжатия*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) управляет генерацией миниатюры при сохранении презентации в формате PPTX:

- Если установить `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установить `false`, сохраняется текущая миниатюра. Если у презентации нет миниатюры, она не будет создана.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.

```cs
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

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iprogresscallback/) используется через свойство `ProgressCallback`, открытое интерфейсом [ISaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/). Присвойте реализацию [IProgressCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iprogresscallback/) свойству `ProgressCallback`, чтобы получать обновления прогресса сохранения в процентах.

Следующие фрагменты кода показывают, как использовать `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
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
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), использующее собственный API. Приложение позволяет разбивать презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **Вопросы и ответы**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементное «быстрое сохранение» не поддерживается.

**Является ли сохранение одного и того же экземпляра Presentation из нескольких потоков потокобезопасным?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/net/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Hyperlinks](/slides/ru/net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [document properties](/slides/ru/net/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.