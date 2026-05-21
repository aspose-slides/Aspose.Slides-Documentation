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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDFs в Java с использованием Aspose.Slides для Android, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Android предоставляет несколько преимуществ, включая совместимость на разных устройствах и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конверсия PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides for Android via Java вставляет информацию о своей API и номер версии в выводимые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Note** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выводимых документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

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

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF**[https://products.aspose.app/slides/ru/conversion/ppt-to-pdf](), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для практической реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), позволяющие настроить результатирующий PDF, установить пароль защиты PDF или указать, как должен проходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```java
// Создайте экземпляр класса PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Установите качество для JPG‑изображений.
pdfOptions.setJpegQuality((byte)90);

// Установите DPI для изображений.
pdfOptions.setSufficientResolution(300);

/// Установите поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового контента.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Определите режим соответствия PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Сохраните презентацию в виде PDF‑документа.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды в виде страниц в результирующем PDF.

Этот код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Добавьте скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохраните презентацию в формате PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в PDF с паролем**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/):

```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Установите пароль PDF и разрешения доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Сохраните презентацию в формате PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код показывает, как обнаружить замену шрифтов:

```java
public static void main(String[] args) {
    // Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Установите обратный вызов предупреждений в параметрах PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Сохраните презентацию в формате PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Реализация обратного вызова предупреждений.
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

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот код демонстрирует, как конвертировать только конкретные слайды из презентации PowerPoint в PDF:

```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Установите массив номеров слайдов.
    int[] slides = { 1, 3 };

    // Сохраните презентацию в формате PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF с заданным размером слайда:

```java
float slideWidth = 612;
float slideHeight = 792;

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
Presentation resizedPresentation = new Presentation();

try {
    // Установите пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Клонируйте первый слайд из исходной презентации.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохраните изменённую презентацию в PDF с заметками.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме «Заметки слайда»**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Настройте параметры PDF с размещением заметок.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Сохраните презентацию в PDF с заметками.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процесс конвертации, соответствующий [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, генерирующий несколько PDF‑файлов на основе разных стандартов соответствия:

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнить конвертации [PDF в HTML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические объекты, такие как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно выполнить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Android via Java](/slides/ru/androidjava/)
- [API‑справочник Aspose.Slides for Android via Java](https://reference.aspose.com/slides/ru/androidjava/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)