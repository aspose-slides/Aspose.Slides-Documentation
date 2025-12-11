---
title: Сохранение презентаций на Android
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/androidjava/save-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как сохранять презентации на Java с помощью Aspose.Slides for Android — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Обзор**

[Открыть презентации на Android](/slides/ru/androidjava/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вам понадобится сохранить её после завершения работы. С Aspose.Slides для Android вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides.
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Выполните здесь некоторую работу...

    // Сохраните презентацию в файл.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток в метод `save` класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Сохраните презентацию в поток.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) со значением из перечисления [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/).
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/) и задайте его свойство `conformance` при сохранении. Если установить [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), выходной файл будет сохранён в строгом формате Office Open XML.

Ниже пример, создающий презентацию и сохраняющий её в строгом формате Office Open XML.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Сохраните презентацию в строгом формате Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Метод [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) позволяет выбрать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Этот метод может использоваться со следующими режимами:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) использует расширения ZIP64 только если презентация превышает вышеуказанные ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) никогда не использует расширения ZIP64.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) всегда использует расширения ZIP64.

Ниже показан код, демонстрирующий, как сохранить презентацию как PPTX с включёнными расширениями ZIP64:
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
При сохранении с использованием [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) будет выброшено исключение [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) управляет генерацией миниатюры при сохранении презентации в формате PPTX:

- Если установить `true`, миниатюра будет обновлена во время сохранения. Это значение по умолчанию.
- Если установить `false`, текущая миниатюра будет сохранена. Если у презентации нет миниатюры, она не будет создаваться.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="Информация" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) используется через метод `setProgressCallback`, объявленный в интерфейсе [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/) и абстрактном классе [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/). Передайте реализацию [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) в `setProgressCallback`, чтобы получать обновления о прогрессе сохранения в процентах.

Ниже приведены фрагменты кода, показывающие, как использовать `IProgressCallback`.
```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Используйте здесь значение процента прогресса.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Информация" color="info" %}}
Aspose разработал [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter) на основе собственного API. Приложение позволяет разделять презентацию на несколько файлов, сохраняя выбранные слайды как новые PPTX или PPT файлы.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), когда записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) **не является потокобезопасным** (/slides/ru/androidjava/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/androidjava/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задавать/сохранять метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Поддерживаются стандартные [свойства документа](/slides/ru/androidjava/presentation-properties/), которые будут записаны в файл при сохранении.