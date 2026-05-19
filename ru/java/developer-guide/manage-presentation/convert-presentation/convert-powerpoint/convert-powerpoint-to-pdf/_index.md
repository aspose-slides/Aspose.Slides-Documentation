---
title: Конвертировать PPT и PPTX в PDF на Java [включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/java/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентацию в PDF
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
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поисковые PDF на Java с помощью Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в Java предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Презентация](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Презентация](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая близкое соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Этот код демонстрирует, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```java
// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Сохранить презентацию в PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF**[https://products.aspose.app/slides/ru/conversion/ppt-to-pdf](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Вы можете протестировать конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/) — которые позволяют настроить получаемый PDF, установить пароль на PDF или указать, как должен проходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий конвертацию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.

```java
// Создать объект класса PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Установить качество JPG‑изображений.
pdfOptions.setJpegQuality((byte)90);

// Установить DPI для изображений.
pdfOptions.setSufficientResolution(300);

// Установить поведение метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установить уровень сжатия текста для текстового содержимого.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Определить режим соответствия PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Сохранить презентацию как PDF‑документ.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в качестве страниц в получаемом PDF.

Этот код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```java
// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать объект класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Добавить скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохранить презентацию как PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертация PowerPoint в защищённый паролем PDF**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/):

```java
// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать объект класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Установить пароль PDF и разрешения доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Сохранить презентацию как PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код показывает, как обнаружить замену шрифтов:

```java
public static void main(String[] args) {
    // Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Установить обработчик предупреждений в параметрах PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Сохранить презентацию как PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
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

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов во время процесса рендеринга см. [Получение обратных вызовов предупреждений для замены шрифтов](/slides/ru/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для более подробной информации о замене шрифтов обратитесь к статье [Замена шрифтов](/slides/ru/java/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:

```java
// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
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

// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Создать новую презентацию с изменённым размером слайда.
Presentation resizedPresentation = new Presentation();

try {
    // Установить пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Клонировать первый слайд из исходной презентации.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохранить изменённую презентацию в PDF с примечаниями.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертация PowerPoint в PDF в виде заметок слайда**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```java
// Создать объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Настроить параметры PDF с макетом заметок.
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

## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-jpg/), а также [PDF в PNG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические объекты, такие как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Определённо. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Java](/slides/ru/java/)
- [Справочник API Aspose.Slides для Java](https://reference.aspose.com/slides/ru/java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)