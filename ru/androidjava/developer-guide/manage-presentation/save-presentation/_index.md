---
title: Сохранить презентацию
type: docs
weight: 80
url: /ru/androidjava/save-presentation/
---

## **Обзор**
{{% alert color="primary" %}} 

[Открытие презентации](/slides/ru/androidjava/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации.

{{% /alert %}} 

Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) содержит содержимое презентации. Создавая презентацию с нуля или модифицируя существующую, вы захотите сохранить презентацию. С Aspose.Slides для Android через Java ее можно сохранить как **файл** или **поток**. Эта статья объясняет, как сохранить презентацию различными способами:

## **Сохранение презентации в файл**
Сохраните презентацию в файл, вызвав метод [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Просто передайте имя файла и [**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat) в метод [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-).

Примеры, приведенные ниже, показывают, как сохранить презентацию с помощью Aspose.Slides для Android через Java.

```java
// Создание объекта Presentation, представляющего файл PPT
Presentation pres = new Presentation();
try {
    // ...выполнение некоторых действий...
    
    // Сохраните вашу презентацию в файл
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Сохранение презентации в поток**
Можно сохранить презентацию в поток, передав выходной поток в метод [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Существуют различные типы потоков, в которые можно сохранить презентацию. В следующем примере мы создаем новый файл презентации, добавляем текст в фигуру и сохраняем презентацию в поток.

```java
// Создание объекта Presentation, представляющего файл PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Добавление текста в фигуру
    shape.getTextFrame().setText("Этот демонстрационный пример показывает, как создать файл PowerPoint и сохранить его в поток.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранение презентации с заданным типом представления**
Aspose.Slides для Android через Java предоставляет возможность установить тип представления для сгенерированной презентации, когда она открывается в PowerPoint, через класс [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties). Свойство [**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-) используется для установки типа представления с помощью перечисления [**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType).

```java
// Открытие файла презентации
Presentation pres = new Presentation();
try {
    // Установка типа представления
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Сохранение презентации
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этого предоставляется класс [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions), в котором вы можете установить свойство Conformance при сохранении файла презентации. Если вы установите его значение как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict), тогда выходной файл презентации будет сохранен в строгом формате Open XML.

Следующий образец кода создает презентацию и сохраняет ее в строгом формате Office Open XML. При вызове метода [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для презентации объект [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) передается с установленным свойством Conformance как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Создание объекта Presentation, представляющего файл PPT
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить фигуру типа линия
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Установить параметры сохранения в строгом формате Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Сохраните вашу презентацию в файл
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP-архив, который имеет ограничение в 4 ГБ (2^32 байта) на несжатый размер файла, сжатый размер файла и общий размер архива, а также ограничение в 65,535 (2^16-1) файлов в архиве. Расширения формата ZIP64 увеличивают эти ограничения до 2^64.

Новое свойство [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/) позволяет вам выбрать, когда использовать расширения формата ZIP64 для сохраненного файла Office Open XML.

Это свойство предоставляет следующие режимы:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) означает, что расширения формата ZIP64 будут использоваться только в том случае, если презентация выходит за указанные выше ограничения. Это режим по умолчанию.
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) означает, что расширения формата ZIP64 не будут использоваться.
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) означает, что расширения формата ZIP64 всегда будут использоваться.

Следующее код демонстрирует, как сохранить презентацию в формате PPTX с расширениями формата ZIP64:

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Сохранение в режиме Zip64Mode.Never вызовет [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/), если презентацию невозможно сохранить в формате ZIP32.

{{% /alert %}}

## **Сохранение обновлений прогресса в процентах**
Интерфейс новый [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) был добавлен к интерфейсу [**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions) и абстрактному классу [**SaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions). Интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) представляет собой объект обратного вызова для сохранения обновлений прогресса в процентах.

Следующие фрагменты кода показывают, как использовать интерфейс [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback):

```java
// Открытие файла презентации
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // Используйте процентное значение прогресса здесь
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% файл преобразован");
    }
}
```

{{% alert title="Информация" color="info" %}}

Используя свой API, Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), которое позволяет пользователям разделять свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из данной презентации как новые файлы PowerPoint (PPTX или PPT).

{{% /alert %}}