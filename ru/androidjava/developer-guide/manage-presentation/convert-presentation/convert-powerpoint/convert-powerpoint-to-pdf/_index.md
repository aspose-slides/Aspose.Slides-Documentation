---
title: Преобразование PPT и PPTX в PDF на Android [Включены расширенные функции]
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
description: "Конвертируйте PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в Java с использованием Aspose.Slides для Android, с быстрыми примерами кода и расширенными параметрами конверсии."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Android предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конверсия PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides for Android via Java вставляет информацию о версии API в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально близкое соответствие полученных PDF оригинальным презентациям. Элементы и свойства рендерятся точно, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конверсия PowerPoint в PDF**

Стандартный процесс конверсии PowerPoint‑в‑PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

Следующий код показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```java
// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Сохранить презентацию в PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF** https://products.aspose.app/slides/conversion/ppt-to-pdf, демонстрирующий процесс конверсии презентации в PDF. Вы можете протестировать процесс с помощью этого конвертера.

{{% /alert %}}

## **Конверсия PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — которые позволяют настроить получаемый PDF, установить пароль защиты или задать порядок выполнения конверсии.

### **Конверсия PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий конверсию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.
```java
// Создать объект класса PdfOptions.
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

// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Сохранить презентацию в виде PDF‑документа.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конверсия PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

Пример кода, показывающий конверсию презентации PowerPoint в PDF с включёнными скрытыми слайдами:
```java
// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать объект класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Добавить скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохранить презентацию в PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конверсия PowerPoint в защищённый паролем PDF**

Этот пример кода демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/):
```java
// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Создать объект класса PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Установить пароль PDF и права доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Сохранить презентацию в PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время конверсии презентации в PDF.

Пример кода, показывающий, как обнаружить замену шрифтов:
```java
public static void main(String[] args) {
    // Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
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

Подробности о получении обратных вызовов при замене шрифтов см. в статье [Getting Warning Callbacks for Fonts Substitution](/slides/ru/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Дополнительную информацию о замене шрифтов можно найти в статье [Font Substitution](/slides/ru/androidjava/font-substitution/).

{{% /alert %}} 

## **Конверсия выбранных слайдов PowerPoint в PDF**

Следующий код демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```java
// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Установить массив номеров слайдов.
    int[] slides = { 1, 3 };

    // Сохранить презентацию в PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Конверсия PowerPoint в PDF с пользовательским размером слайда**

Пример кода, показывающий конверсию презентации PowerPoint в PDF с заданным размером слайда:
```java
float slideWidth = 612;
float slideHeight = 792;

// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Создать новую презентацию с изменённым размером слайда.
Presentation resizedPresentation = new Presentation();

try {
    // Установить пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Клонировать первый слайд из оригинальной презентации.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохранить изменённую презентацию в PDF с заметками.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Конверсия PowerPoint в PDF в режиме слайдов с заметками**

Пример кода, показывающий конверсию презентации PowerPoint в PDF, включающего заметки:
```java
// Создать объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Настроить параметры PDF с разметкой заметок.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Сохранить презентацию в PDF с заметками.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процесс конверсии, соответствующий [Руководству по доступности веб‑контента (WCAG)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Пример кода, демонстрирующий процесс конверсии PowerPoint в PDF, генерирующий несколько PDF согласно разным стандартам соответствия:
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


{{% alert title="Примечание" color="warning" %}} 

Aspose.Slides поддерживает операции конверсии PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Другие операции конверсии PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — тоже поддерживаются.

{{% /alert %}}

## **FAQ**

**Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетную конверсию множества файлов PPT или PPTX в PDF. Вы можете последовательно обрабатывать файлы программно.

**Можно ли защитить полученный PDF паролем?**

Конечно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы задать пароль и определить разрешения доступа во время конверсии.

**Как включить скрытые слайды в PDF?**

Вызовите метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы добавить скрытые слайды в результирующий PDF.

**Сохраняет ли Aspose.Slides высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/).

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Android via Java](/slides/ru/androidjava/)
- [API‑справочник Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)