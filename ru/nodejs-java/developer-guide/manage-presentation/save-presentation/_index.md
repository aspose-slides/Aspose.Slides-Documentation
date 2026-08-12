---
title: Сохранение презентаций в JavaScript
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/nodejs-java/save-presentation/
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
- предопределённый тип просмотра
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как сохранять презентации с помощью Aspose.Slides для Node.js через Java — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Open Presentations in JavaScript](/slides/ru/nodejs-java/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вы захотите сохранить её после завершения. С Aspose.Slides для Node.js вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Передайте методу имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Выполните здесь некоторую работу...

    // Сохраните презентацию в файл.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав поток вывода методу `save` класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Презентацию можно записать в множество типов потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Сохраните презентацию в поток.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций с предопределённым типом просмотра**

Aspose.Slides позволяет установить начальный просмотр, который PowerPoint использует при открытии сгенерированной презентации, с помощью класса [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setLastView) со значением из перечисления [ViewType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранить презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/) и установите его свойство conformance при сохранении. Если установить [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), выходной файл будет сохранён в строгом формате Office Open XML.

Пример ниже создаёт презентацию и сохраняет её в строгом формате Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Сохраните презентацию в строгом формате Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, который накладывает ограничения 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает архив 65 535 (2^16‑1) файлами. Расширения формата ZIP64 повышают эти ограничения до 2^64.

Метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

- [IfNecessary](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#IfNecessary) использует расширения формата ZIP64 только если презентация превышает указанные ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Never) никогда не использует расширения формата ZIP64.
- [Always](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Always) всегда использует расширения формата ZIP64.

Следующий код демонстрирует, как сохранить презентацию в файл PPTX с включёнными расширениями формата ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
При сохранении с [Zip64Mode.Never](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Never) будет выброшено исключение [PptxException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxexception/), если презентацию невозможно сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с большими презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от требований вы можете предпочесть более быструю обработку или меньший размер выходных файлов.

Aspose.Slides предоставляет метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), который позволяет указать уровень сжатия, используемый при сохранении презентации в формате Office Open XML.

Доступны следующие уровни сжатия:

- **None**: Не применяется сжатие. Файлы сохраняются как есть.
- **Level1**: Самое быстрое сжатие с самым низким коэффициентом сжатия.
- **Level2**: Более быстрое сжатие с немного лучшим коэффициентом, чем **Level1**.
- **Level3**: Обеспечивает лучшее сжатие, чем **Level2**, с умеренным влиянием на время обработки.
- **Level4**: Обеспечивает лучшее сжатие, чем **Level3**.
- **Level5**: Предоставляет улучшенное сжатие по сравнению с **Level4** с дополнительным временем обработки.
- **Level6**: Стандартное сжатие, предлагающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- **Level7**: Обеспечивает лучшее сжатие, чем **Level6**, но с более медленной обработкой.
- **Level8**: Обеспечивает лучшее сжатие, чем **Level7**.
- **Level9**: Максимальное сжатие. Производит самый маленький размер файла ценой самого длительного времени обработки.

Следующий пример демонстрирует, как сохранить презентацию в файл PPTX *без сжатия*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установить `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установить `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не генерируется.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Отчёт о прогрессе сохранения в процентах**

Отчёт о прогрессе сохранения настраивается через метод [setProgressCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) у класса [SaveOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/) и его наследников. Предоставьте Java‑прокси, реализующий интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/); во время экспорта обратный вызов будет получать периодические обновления в процентах.

Следующие фрагменты кода показывают, как использовать `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Используйте здесь значение процента прогресса.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), используя собственный API. Приложение позволяет разбивать презентацию на несколько файлов, сохраняя выбранные слайды в новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), когда записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Является ли сохранение одного и того же экземпляра Presentation из нескольких потоков потокобезопасным?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/nodejs-java/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

Гиперссылки ([Hyperlinks](/slides/ru/nodejs-java/manage-hyperlinks/)) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Могу ли я установить/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/nodejs-java/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.