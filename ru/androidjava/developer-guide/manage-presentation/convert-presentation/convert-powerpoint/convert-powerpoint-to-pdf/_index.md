---
title: Преобразование PPT и PPTX в PDF на Android [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/androidjava/convert-powerpoint-to-pdf/
keywords:
  - преобразовать PowerPoint
  - преобразовать презентацию
  - PowerPoint в PDF
  - презентация в PDF
  - PPT в PDF
  - преобразовать PPT в PDF
  - PPTX в PDF
  - преобразовать PPTX в PDF
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
description: "Преобразуйте PowerPoint PPT/PPTX в PDF высокого качества, поддерживающий поиск, в Java с помощью Aspose.Slides для Android, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в PDF‑формат на Android дает несколько преимуществ, включая совместимость с различными устройствами и сохранение разметки и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, вызвав метод `save`. Класс [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java вставляет информацию о своей версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer строкой вида "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Отдельные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркированные списки
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать заданную презентацию в PDF, используя оптимальные настройки с максимальным уровнем качества.

Ниже показан пример кода, демонстрирующего, как конвертировать презентацию (PPT, PPTX, ODP и др.) в PDF:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Сохраните презентацию в формате PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF** ([**PowerPoint to PDF converter**](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf)), который демонстрирует процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) — которые позволяют настроить полученный PDF, защитить его паролем или задать порядок выполнения процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочитаемый уровень качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже приведён пример кода, показывающий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Установите качество JPG‑изображений.
pdfOptions.setJpegQuality((byte)90);

// Установите DPI для изображений.
pdfOptions.setSufficientResolution(300);

/// Установите поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержимого.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Определите режим соответствия PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Сохраните презентацию в виде PDF‑документа.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) для включения скрытых слайдов в качестве страниц в результирующий PDF.

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включив скрытые слайды:

```java
import com.aspose.slides.*;

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

### **Конвертация PowerPoint в PDF с защитой паролем**

Следующий пример показывает, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

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

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Пример кода, показывающий, как обнаружить замену шрифтов:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Установите обработчик предупреждений в параметрах PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Сохраните презентацию в формате PDF.
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

{{%  alert color="info"  %}} 

Для получения дополнительной информации о замене шрифтов обратитесь к статье [Font Substitution](/slides/ru/androidjava/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Пример кода, демонстрирующий, как конвертировать только определённые слайды презентации PowerPoint в PDF:

```java
import com.aspose.slides.*;

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

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Пример кода, показывающий, как конвертировать презентацию PowerPoint в PDF с заданным размером слайда:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
Presentation resizedPresentation = new Presentation();

try {
    // Установите пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Клонируйте первый слайд из оригинальной презентации.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Удалите пустой слайд, с которым была создана новая презентация.
    resizedPresentation.getSlides().removeAt(1);

    // Сохраните изменённую презентацию в формате PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертация PowerPoint в PDF в режиме «Заметки»**

Пример кода, демонстрирующий, как конвертировать презентацию PowerPoint в PDF, включив заметки:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Настройте параметры PDF с расположением заметок.
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

## **Доступность и стандарты соответствия PDFs**

Aspose.Slides позволяет использовать процесс конвертации, соответствующий [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Ниже показан пример кода, реализующего процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с разными стандартами соответствия:

```java
import com.aspose.slides.*;

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-png/). Поддерживаются также конвертации в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/ru/java/conversion/pdf-to-xml/).

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические объекты, такие как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

### Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

### Можно ли защитить полученный PDF паролем?

Безусловно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время конвертации.

### Как включить скрытые слайды в PDF?

Вызовите метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

### Может ли Aspose.Slides сохранять высокое качество изображений в PDF?

Да, вы можете управлять качеством изображений, используя методы `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/), обеспечивая высокое качество изображений в вашем PDF.

### Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя соблюдение требований доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Android via Java](/slides/ru/androidjava/)
- [Справочник API Aspose.Slides for Android via Java](https://reference.aspose.com/slides/ru/androidjava/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)