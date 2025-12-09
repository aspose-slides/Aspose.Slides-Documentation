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
- предопределенный тип просмотра
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

[Open Presentations in C#](/slides/ru/net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, по окончании работы вы захотите её сохранить. С помощью Aspose.Slides for .NET вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.
```cs
// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Выполните здесь необходимые действия...

    // Сохраните презентацию в файл.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.
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


## **Сохранение презентаций с предопределённым типом просмотра**

Aspose.Slides позволяет задать начальный вид, который PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). Установите свойство [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) значением из перечисления [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) и задайте его свойство conformance при сохранении. Если вы задаёте `Conformance.Iso29500_2008_Strict`, выходной файл сохраняется в строгом формате Office Open XML.

Ниже пример, создающий презентацию и сохраняющий её в строгом формате Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Сохраните презентацию в строгом формате Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, накладывающий ограничения 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничение в 65 535 (2^16‑1) файлов. Расширения формата ZIP64 повышают эти ограничения до 2^64.

Свойство [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) позволяет выбрать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Это свойство предоставляет следующие режимы:

- `IfNecessary` использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения ZIP64.
- `Always` всегда использует расширения ZIP64.

Ниже приведён код, демонстрирующий, как сохранить презентацию как PPTX с включёнными расширениями ZIP64:
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
При сохранении с `Zip64Mode.Never` генерируется исключение [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет генерироваться.

В приведённом ниже коде презентация сохраняется в PPTX без обновления её миниатюры.
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

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) используется через свойство `ProgressCallback`, предоставляемое интерфейсом [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). Присвойте реализации [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) свойство `ProgressCallback`, чтобы получать обновления о прогрессе сохранения в процентах.

Ниже приведены фрагменты кода, показывающие, как использовать `IProgressCallback`.
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
Aspose разработала бесплатное приложение [PowerPoint Splitter](https://products.aspose.app/slides/splitter), использующее собственный API. Приложение позволяет разбить презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При каждом сохранении создаётся полный целевой файл; инкрементное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) не является потокобезопасным; сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Hyperlinks](/slides/ru/net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Поддерживаются стандартные [свойства документа](/slides/ru/net/presentation-properties/), которые будут записаны в файл при сохранении.