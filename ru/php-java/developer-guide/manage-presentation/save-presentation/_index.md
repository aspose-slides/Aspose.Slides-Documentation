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
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- PHP
- Aspose.Slides
description: "Узнайте, как сохранять презентации с помощью Aspose.Slides для PHP через Java — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Открыть презентации в PHP](/slides/ru/php-java/open-presentation/) описал, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вы захотите сохранить её после завершения работы. С помощью Aspose.Slides for PHP вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Передайте методу имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Выполните некоторые действия здесь...
    // Сохраните презентацию в файл.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `save` класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Презентацию можно записать во многие типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

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

Aspose.Slides позволяет задать начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, с помощью класса [ViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#setLastView) с значением из перечисления [ViewType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewtype/).

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

Aspose.Slides позволяет сохранить презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), выходной файл будет сохранён в строгом формате Office Open XML.

Пример ниже создаёт презентацию и сохраняет её в строгом формате Office Open XML.

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

Файл Office Open XML — это ZIP‑архив, который накладывает ограничения 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setZip64Mode) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

Этот метод может использоваться со следующими режимами:
- [IfNecessary](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#IfNecessary) использует расширения формата ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Never) никогда не использует расширения формата ZIP64.
- [Always](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Always) всегда использует расширения формата ZIP64.

Следующий код демонстрирует, как сохранить презентацию в файл PPTX с включёнными расширениями формата ZIP64:

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
Если при сохранении используется [Zip64Mode.Never](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Never), будет выброшено исключение [PptxException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с большими презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от требований вы можете предпочесть более быструю обработку или меньший размер выходного файла.

Aspose.Slides предоставляет метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setCompressionLevel), который позволяет задать уровень сжатия, используемый при сохранении презентации в формате Office Open XML.

Доступны следующие уровни сжатия:
- [**None**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#None): Сжатие не применяется. Файлы сохраняются как есть.
- [**Level1**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level1): Самое быстрое сжатие с наименьшим коэффициентом сжатия.
- [**Level2**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level2): Быстрое сжатие с несколько лучшим коэффициентом сжатия, чем **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level3): Обеспечивает лучшее сжатие, чем **Level2**, с умеренным влиянием на время обработки.
- [**Level4**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level4): Обеспечивает лучшее сжатие, чем **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level5): Обеспечивает улучшенное сжатие по сравнению с **Level4** с дополнительным временем обработки.
- [**Level6**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level6): Стандартное сжатие, которое обеспечивает хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- [**Level7**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level7): Обеспечивает лучшее сжатие, чем **Level6**, но с более медленной обработкой.
- [**Level8**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level8): Обеспечивает лучшее сжатие, чем **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level9): Максимальное сжатие. Достигает наименьшего размера файла, но требует самого длительного времени обработки.

Следующий пример демонстрирует, как сохранить презентацию в файл PPTX *без сжатия*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет генерацией миниатюры при сохранении презентации в формате PPTX:
- Если установлено `true`, миниатюра обновляется при сохранении. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет создана.

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
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Сохранение прогресса в процентах**

Отчёт о прогрессе сохранения настраивается через метод [setProgressCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/#setProgressCallback) класса [SaveOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/) и его подклассов. Предоставьте Java‑прокси, реализующий интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/); во время экспорта обратный вызов получает периодические обновления в процентах.

Следующие фрагменты кода показывают, как использовать `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Используйте значение процента прогресса здесь.
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
Aspose разработала бесплатное приложение [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter) на основе собственного API. Приложение позволяет разбить презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), когда записываются только изменения?**  
Нет. При каждом сохранении создаётся полный файл назначения; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли из разных потоков сохранять один и тот же объект Presentation?**  
Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) не является потокобезопасным; сохраняйте его только из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**  
[Гиперссылки](/slides/ru/php-java/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — обеспечьте доступность указанных путей.

**Можно ли задавать/сохранять метаданные документа (Автор, Заголовок, Компания, Дата)?**  
Да. Поддерживаются стандартные [свойства документа](/slides/ru/php-java/presentation-properties/), которые будут записаны в файл при сохранении.