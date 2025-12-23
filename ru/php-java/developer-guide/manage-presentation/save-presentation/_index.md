---
title: Сохранение презентаций в PHP
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/php-java/save-presentation/
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
- PHP
- Aspose.Slides
description: "Узнайте, как сохранять презентации с помощью Aspose.Slides для PHP через Java — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Обзор**

[Open Presentations in PHP](/slides/ru/php-java/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вам понадобится сохранить её после окончания работы. С Aspose.Slides для PHP вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Чтобы вызвать метод, передайте имя файла и формат сохранения. В следующем примере показано, как сохранить презентацию с помощью Aspose.Slides.
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Выполните здесь некоторую работу...

    // Сохраните презентацию в файл.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав поток вывода в метод `save` класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Сохраните презентацию в поток.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) со значением из перечисления [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/).
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) и установите его свойство conformance при сохранении. Если вы зададите [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), выходной файл будет сохранён в строгом формате Office Open XML.

В примере ниже создаётся презентация и сохраняется в строгом формате Office Open XML.
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Сохраните презентацию в строгом формате Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 снимают эти ограничения до 2^64.

Метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

Этот метод может использоваться со следующими режимами:

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) никогда не использует расширения ZIP64.
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) всегда использует расширения ZIP64.

В следующем коде демонстрируется, как сохранить презентацию как PPTX с включёнными расширениями ZIP64:
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

При сохранении с использованием [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) выбрасывается исключение [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.

{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установить `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установить `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не генерируется.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Информация" color="info" %}}

Эта опция помогает уменьшить время, необходимое для сохранения презентации в формате PPTX.

{{% /alert %}}

## **Сохранение прогресса в процентах**

Отчёт о прогрессе сохранения настраивается через метод [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) класса [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) и его наследников. Предоставьте Java‑прокси, реализующий интерфейс [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); во время экспорта обратный вызов получает периодические обновления в процентах.

В следующих фрагментах кода показано, как использовать `IProgressCallback`.
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Используйте здесь значение процента прогресса.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Информация" color="info" %}}

Aspose разработала бесплатное приложение [PowerPoint Splitter](https://products.aspose.app/slides/splitter) на основе собственного API. Приложение позволяет разбить презентацию на несколько файлов, сохранив выбранные слайды как новые файлы PPTX или PPT.

{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При каждом сохранении создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) **не является потокобезопасным** (/slides/ru/php-java/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними файлами при сохранении?**

[Гиперссылки](/slides/ru/php-java/manage-hyperlinks/) сохраняются. Внешние файлы, связанные, например, видео по относительным путям, автоматически не копируются — убедитесь, что указанные пути остаются доступными.

**Можно ли задавать/сохранять метаданные документа (Автор, Название, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/php-java/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.