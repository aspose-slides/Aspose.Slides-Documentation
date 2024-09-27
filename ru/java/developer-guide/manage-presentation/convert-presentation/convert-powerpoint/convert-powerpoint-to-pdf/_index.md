---
title: Конвертация PowerPoint в PDF на Java
linktitle: Конвертация PowerPoint в PDF
type: docs
weight: 40
url: /ru/java/convert-powerpoint-to-pdf/
keywords:
- конвертация PowerPoint
- презентация
- PowerPoint в PDF
- PPT в PDF
- PPTX в PDF
- сохранить PowerPoint как PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides для Java
description: "Конвертируйте презентации PowerPoint в PDF на Java. Сохраните PowerPoint как PDF с соблюдением стандартов доступности."
---

## **Обзор**

Конвертация документов PowerPoint в формат PDF предлагает несколько преимуществ, включая обеспечение совместимости между различными устройствами и сохранение макета и форматирования вашей презентации. В этой статье показано, как конвертировать презентации в PDF-документы, использовать различные параметры для управления качеством изображения, включать скрытые слайды, защищать PDF-документы паролем, обнаруживать замены шрифтов, выбирать слайды для конвертации и применять стандарты соблюдения к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* PPT
* PPTX
* ODP

Чтобы конвертировать презентацию в PDF, вам просто нужно передать имя файла в качестве аргумента в классе [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), а затем сохранить презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-). Класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) предлагает метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides для Java непосредственно записывает информацию API и номер версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides для Java заполняет поле Application значением '*Aspose.Slides*' и поле PDF Producer значением формата '*Aspose.Slides v XX.XX*'. **Обратите внимание**, что вы не можете указать Aspose.Slides для Java изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* всю презентацию в PDF
* конкретные слайды в презентации в PDF
* презентацию 

Aspose.Slides экспортирует презентации в PDF таким образом, что содержимое полученных PDF-документов очень похоже на содержимое оригинальных презентаций. Эти известные элементы и атрибуты часто правильно отображаются при конвертации презентации в PDF:

* изображения
* текстовые поля и другие фигуры
* текст и его форматирование
* абзацы и их форматирование
* гиперссылки
* колонтитулы
* маркеры
* таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная операция конвертации PDF PowerPoint выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальных уровнях качества.

Этот код на Java показывает, как конвертировать PowerPoint в PDF:

```java
// Создает класс Presentation, который представляет файл PowerPoint
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Сохраняет презентацию как PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации процедуры, описанной здесь, вы можете провести тест с конвертером.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства в классе [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions), которые позволяют вам настраивать PDF (результат процесса конвертации), защищать PDF паролем или даже указывать, как должен проходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью настраиваемых параметров конвертации вы можете установить предпочтительное качество для растровых изображений, указать, как должны обрабатываться метафайлы, установить уровень сжатия для текстов, установить DPI для изображений и т.д.

Пример кода ниже демонстрирует операцию, в которой презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```java
// Создает класс PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Устанавливает качество для JPG изображений
pdfOptions.setJpegQuality((byte)90);

// Устанавливает DPI для изображений
pdfOptions.setSufficientResolution(300);

// Устанавливает поведение для метафайлов
pdfOptions.setSaveMetafilesAsPng(true);

// Устанавливает уровень сжатия текста для текстового контента
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Определяет режим соблюдения PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Создает класс Presentation, который представляет документ PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Сохраняет презентацию как PDF-документ
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в PDF со скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать настраиваемый параметр — свойство [ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) из класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions), чтобы указать Aspose.Slides включить скрытые слайды в качестве страниц в результирующем PDF.

Этот код на Java показывает, как конвертировать презентацию PowerPoint в PDF с включенными скрытыми слайдами:

```java
// Создает класс Presentation, который представляет файл PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Создает класс PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Добавляет скрытые слайды
    pdfOptions.setShowHiddenSlides(true);
    
    // Сохраняет презентацию как PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Конвертировать PowerPoint в PDF с защитой паролем**

Этот код на Java показывает, как конвертировать PowerPoint в защищенный паролем PDF (используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)):

```java
// Создает объект Presentation, который представляет файл PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Создает класс PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Устанавливает пароль PDF и разрешения доступа
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Сохраняет презентацию как PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--) из класса [SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/), который позволяет вам обнаруживать замены шрифтов в процессе конвертации презентации в PDF. 

Этот код на Java показывает, как обнаружить замены шрифтов: 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("Предупреждение о замене шрифта: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о получении обратных вызовов для замены шрифтов в процессе рендеринга см. [Получение предупреждений о замене шрифтов](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](https://docs.aspose.com/slides/java/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот код на Java показывает, как конвертировать конкретные слайды в презентации PowerPoint в PDF:

```java
// Создает объект Presentation, который представляет файл PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Устанавливает массив позиций слайдов
    int[] slides = { 1, 3 };
    
    // Сохраняет презентацию как PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот код на Java показывает, как конвертировать PowerPoint в PDF при задании размера слайда:

```java
// Создает объект Presentation, который представляет файл PowerPoint 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Устанавливает тип и размер слайда 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме просмотра слайдов заметок**

Этот код на Java показывает, как конвертировать PowerPoint в PDF с заметками:

```java
// Создает класс Presentation, который представляет файл PowerPoint
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Стандарты доступности и соблюдения для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, которая соответствует [Руководствам по доступности веб-контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соблюдения: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на Java демонстрирует операцию конвертации PowerPoint в PDF, в которой получаются несколько PDF на основе различных стандартов соблюдения:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка Aspose.Slides для операций конвертации PDF распространяется на возможность конвертации PDF в самые популярные форматы файлов. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Также поддерживаются другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}