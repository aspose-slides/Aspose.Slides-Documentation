---
title: Сохранение презентаций в JavaScript
linktitle: Сохранить презентации
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
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как сохранять презентации в JavaScript с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Обзор**

[Open Presentations in JavaScript](/slides/ru/nodejs-java/open-presentation/) описал, как использовать класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, её нужно сохранить по окончании работы. С помощью Aspose.Slides для Node.js вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже показан пример сохранения презентации с помощью Aspose.Slides.
```js
// Создаёт экземпляр класса Presentation, представляющего файл презентации.
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

Вы можете сохранить презентацию в поток, передав выходной поток методу `save` класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В приведённом примере мы создаём новую презентацию и сохраняем её в файловый поток.
```js
// Создаёт экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Сохранить презентацию в поток.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальный вид, который PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) со значением из перечисления [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/).
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), выходной файл будет сохранён в строгом формате Office Open XML.

Ниже пример создания презентации и её сохранения в строгом формате Office Open XML.
```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Создаёт экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Сохранить презентацию в строгом формате Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML — это ZIP‑архив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 увеличивают эти ограничения до 2^64.

Метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) позволяет выбрать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Этот метод может использоваться со следующими режимами:

- [IfNecessary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) использует расширения ZIP64 только если презентация превышает вышеуказанные ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) никогда не использует расширения ZIP64.
- [Always](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) всегда использует расширения ZIP64.

Ниже показан код, демонстрирующий сохранение презентации в формате PPTX с включёнными расширениями ZIP64:
```js
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
При сохранении с использованием [Zip64Mode.Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) будет выброшено исключение [PptxException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет генерироваться.

В приведённом коде презентация сохраняется в PPTX без обновления её миниатюры.
```js
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
Эта опция помогает сократить время, требуемое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Отчёт о прогрессе сохранения в процентах**

Отчёт о прогрессе сохранения настраивается через метод [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) класса [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) и его подклассов. Передайте Java‑прокси, реализующий интерфейс [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); во время экспорта обратный вызов будет получать периодические обновления в процентах.

Ниже приведены фрагменты кода, показывающие, как использовать `IProgressCallback`.
```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Используйте значение процента прогресса здесь.
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
Aspose разработала бесплатное приложение [PowerPoint Splitter](https://products.aspose.app/slides/splitter) на основе собственного API. Приложение позволяет разбить презентацию на несколько файлов, сохранив выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) **не является потокобезопасным**; сохраняйте его только из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/nodejs-java/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/nodejs-java/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.