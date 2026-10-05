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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF на Java с помощью Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в Java предлагает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к итоговым документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [сохранить](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Класс [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) предоставляет метод [сохранить](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в виде "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

Ниже приведён пример, который загружает презентацию и сохраняет все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose предлагает бесплатный онлайн‑инструмент [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для живой реализации процедуры, описанной здесь.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитать его паролем или указать, как должен проходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример, который экспортирует презентацию в PDF 1.5 с качеством JPEG = 90, разрешением изображения = 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Сохранить вложенные OLE‑файлы как вложения PDF**

Если презентация содержит вложенную книгу Excel, вы можете захотеть, чтобы получатели PDF смогли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) со значением `true`, чтобы сохранить вложенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но вложенный файл не включается как вложение. Установка опции в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить вложенный файл отдельно. OLE‑объект не становится интерактивным листом Excel на странице PDF.

Ниже приведён пример, который загружает презентацию, уже содержащую вложенную книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например в Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите вложенную книгу.
3. Сохраните вложение и откройте его в Excel, чтобы изучить данные, либо откройте его напрямую, если просмотрщик позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 допускает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Пример использует настройку соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.

{{% /alert %}}

### **Конвертировать PowerPoint в PDF с учётом скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующем PDF.

Ниже приведён пример, который экспортирует презентацию в PDF, включая любые скрытые слайды.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в защищённый паролем PDF**

Ниже приведён пример, который экспортирует презентацию в PDF, требующий пароль `password` для открытия. Права доступа позволяют печатать, включая печать высокого качества.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), позволяющий выявлять замену шрифтов во время процесса конвертации презентации в PDF.

Ниже приведён пример, который экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда недоступный шрифт заменяется при экспорте.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/java/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Ниже приведён пример, который экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Ниже приведён пример, который копирует первый слайд из презентации в новую презентацию со размером слайда 612 × 792 points (8,5 × 11 дюймов). Он масштабирует содержимое слайда, чтобы оно поместилось, и экспортирует единственный слайд в PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Удалить пустой слайд, с которым была создана новая презентация.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**

Ниже приведён пример, который экспортирует презентацию в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов на основе разных стандартов соответствия:

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

{{% alert color="info" title="Note" %}}

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), чтобы установить пароль и определить права доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) со значением `true` в классе [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Сможет ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) и [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Java](/slides/ru/java/)
- [Справочник API Aspose.Slides for Java](https://reference.aspose.com/slides/java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)