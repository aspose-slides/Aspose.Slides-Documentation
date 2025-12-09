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

[Open Presentations in C#](/slides/ru/net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаете ли вы презентацию с нуля или изменяете существующую, вам понадобится сохранить её после завершения. С Aspose.Slides для .NET вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Передайте имя файла и формат сохранения в метод. В следующем примере показано, как сохранить презентацию с помощью Aspose.Slides.
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

Вы можете сохранить презентацию в поток, передав поток вывода в метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.
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

Aspose.Slides позволяет установить начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, с помощью класса [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). Установите свойство [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) значением из перечисления [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить `Conformance.Iso29500_2008_Strict`, выходной файл будет сохранён в строгом формате Office Open XML.

В примере ниже создаётся презентация и сохраняется в строгом формате Office Open XML.
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

Файл Office Open XML представляет собой ZIP‑архив, который налагает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Свойство [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

Это свойство предоставляет следующие режимы:

- `IfNecessary` использует расширения формата ZIP64 только если презентация превышает вышеуказанные ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения формата ZIP64.
- `Always` всегда использует расширения формата ZIP64.

В следующем коде демонстрируется, как сохранить презентацию как PPTX с включёнными расширениями формата ZIP64:
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
При сохранении с `Zip64Mode.Never` будет выброшено исключение [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет создана.

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


{{% alert title="Информация" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) используется через свойство `ProgressCallback`, предоставляемое интерфейсом [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). Присвойте реализации [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) свойству `ProgressCallback`, чтобы получать обновления о прогрессе сохранения в процентах.

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


{{% alert title="Информация" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), использующее её собственный API. Приложение позволяет разбивать презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементное «быстрое сохранение» не поддерживается.

**Безопасно ли сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/net/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Поддерживаются стандартные [свойства документа](/slides/ru/net/presentation-properties/) и они будут записаны в файл при сохранении.