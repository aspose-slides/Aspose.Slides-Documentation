---
title: Сохранить Презентацию
type: docs
weight: 80
url: /ru/java/save-presentation/
---

## **Обзор**
{{% alert color="primary" %}} 

[Открытие Презентации](/slides/ru/java/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) для открытия презентации. Эта статья объясняет, как создать и сохранить презентации.

{{% /alert %}} 

Класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) содержит содержание презентации. Создавая презентацию с нуля или изменяя существующую, в конце концов, вам нужно сохранить презентацию. С Aspose.Slides для Java это можно сохранить как **файл** или **поток**. Эта статья объясняет, как сохранить презентацию разными способами:

## **Сохранить Презентацию в Файл**
Сохраните презентацию в файл, вызвав метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Просто передайте имя файла и [**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) в метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-).

Примеры, которые следуют, показывают, как сохранить презентацию с Aspose.Slides для Java.

```java
// Создайте объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();
try {
    // ...выполните некоторые действия здесь...
    
    // Сохраните свою презентацию в файл
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Сохранить Презентацию в Поток**
Можно сохранить презентацию в поток, передав выходной поток в метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Существует множество типов потоков, в которые можно сохранить презентацию. В приведенном ниже примере мы создали новый файл презентации, добавили текст в фигуру и сохранили презентацию в поток.

```java
// Создайте объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Добавьте текст в фигуру
    shape.getTextFrame().setText("Этот демонстрационный пример показывает, как создать файл PowerPoint и сохранить его в поток.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранить Презентацию с Предустановленным Типом Видения**
Aspose.Slides для Java предоставляет возможность установить тип представления для созданной презентации, когда она открывается в PowerPoint через класс [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties). Свойство [**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) используется для установки типа представления с помощью перечисления [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType).

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

## **Сохранение Презентаций в Строгом Формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этой цели предоставляется класс [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions), где вы можете установить свойство Conformance при сохранении файла презентации. Если вы установите его значение как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict), файл выходной презентации будет сохранен в строгом формате Open XML.

Следующий пример кода создает презентацию и сохраняет ее в строгом формате Office Open XML. При вызове метода [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для презентации объект [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) передается ему с установленным свойством Conformance как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Создайте объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте автофигуру типа линия
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Установите параметры сохранения в строгом формате Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Сохраните вашу презентацию в файл
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранение Презентаций в Формате Office Open XML в Режиме Zip64**

Файл Office Open XML представляет собой ZIP-архив, который имеет ограничение в 4 ГБ (2^32 байта) на не сжатый размер файла, сжатый размер файла и общий размер архива, а также ограничение в 65 535 (2^16-1) файлов в архиве. Расширения формата ZIP64 увеличивают эти пределы до 2^64.

Новое свойство [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) позволяет выбирать, когда использовать расширения формата ZIP64 для сохраненного файла Office Open XML.

Это свойство предоставляет следующие режимы:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) означает, что расширения формата ZIP64 будут использоваться только в том случае, если презентация выходит за пределы вышеперечисленных ограничений. Это режим по умолчанию.
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) означает, что расширения формата ZIP64 не будут использованы. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) означает, что расширения формата ZIP64 всегда будут использоваться.

Следующий код демонстрирует, как сохранить презентацию в формате PPTX с расширениями формата ZIP64:

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

Сохранение в режиме Zip64Mode.Never вызовет [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.

{{% /alert %}}

## **Обновления Прогресса Сохранения в Процентах**
Новый интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) был добавлен в интерфейс [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) и абстрактный класс [**SaveOptions** ](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions). Интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) представляет собой объект обратного вызова для обновлений прогресса сохранения в процентах.  

Следующие примеры кода показывают, как использовать интерфейс [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback):

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
        // Используйте значение процента прогресса здесь
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% файл конвертирован");
    }
}
```

{{% alert title="Информация" color="info" %}}

Используя собственное API, Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), которое позволяет пользователям разделять свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из данной презентации как новые файлы PowerPoint (PPTX или PPT). 

{{% /alert %}}