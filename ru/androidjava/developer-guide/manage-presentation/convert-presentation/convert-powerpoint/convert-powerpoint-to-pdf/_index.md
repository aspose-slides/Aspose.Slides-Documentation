---
title: Конвертировать PPT и PPTX в PDF на Android [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/androidjava/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поисковые PDF в Java с помощью Aspose.Slides для Android, с быстрыми примерами кода и расширенными параметрами конвертации."
---

## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Android предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides можно конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java вставляет информацию о своём API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Note** что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы точно соответствуют оригинальным презентациям. При конвертации точно сохраняются элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным уровнем качества.

Этот код показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Сохраните презентацию в формате PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF**[https://products.aspose.app/slides/conversion/ppt-to-pdf](), демонстрирующий процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для практической реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), которые позволяют модифицировать получаемый PDF, защищать его паролем или задавать порядок выполнения конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать желаемое качество растровых изображений, определить способ обработки метафайлов, указать уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий конвертацию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.
```java
// Создать экземпляр класса PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Установить качество JPG‑изображений.
pdfOptions.setJpegQuality((byte)90);

// Установить DPI для изображений.
pdfOptions.setSufficientResolution(300);

/// Установить поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установить уровень сжатия текста для текстового содержимого.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Определить режим соответствия PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Сохранить презентацию как PDF‑документ.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертация PowerPoint в PDF с включёнными скрытыми слайдами**

Если презентация содержит скрытые слайды, можно использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в качестве страниц в результирующий PDF.

Этот код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```java
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать экземпляр класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Добавить скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохранить презентацию как PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертация PowerPoint в PDF с паролем**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/):
```java
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать экземпляр класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Установить пароль PDF и права доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Сохранить презентацию как PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время конвертации презентации в PDF.

Этот код показывает, как обнаружить замену шрифтов:
```java
public static void main(String[] args) {
    // Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Установить обработчик предупреждений в параметрах PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Сохранить презентацию в PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Реализация обработчика предупреждений.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/androidjava/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код демонстрирует, как конвертировать только определённые слайды презентации PowerPoint в PDF:
```java
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Установить массив номеров слайдов.
    int[] slides = { 1, 3 };

    // Сохранить презентацию как PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
```java
float slideWidth = 612;
float slideHeight = 792;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Создать новую презентацию с изменённым размером слайда.
Presentation resizedPresentation = new Presentation();

try {
    // Установить пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Клонировать первый слайд из оригинальной презентации.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохранить изменённую презентацию в PDF с примечаниями.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Конвертация PowerPoint в PDF в режиме «Слайды с примечаниями»**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий примечания:
```java
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Настроить параметры PDF с расположением заметок.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Сохранить презентацию в PDF с примечаниями.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF по любому из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), а также [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Поддерживаются также конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}

## **FAQ**

**Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Сохраняет ли Aspose.Slides высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя такие методы, как `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы обеспечить высокое качество изображений в PDF.

**Поддерживает ли Aspose.Slides стандарты PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Android via Java](/slides/ru/androidjava/)
- [Справочник API Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)