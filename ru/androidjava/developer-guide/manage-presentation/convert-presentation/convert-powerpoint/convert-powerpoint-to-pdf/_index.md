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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поисковые PDF в Java с использованием Aspose.Slides для Android, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Android предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, определять замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и затем сохраните презентацию в PDF, используя метод [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) раскрывает метод [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java вставляет информацию о своей версии API в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов с помощью Aspose.Slides нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы максимально соответствуют оригиналам. При конвертации точно отображаются элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном уровне качества.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием параметров экспорта по умолчанию.

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

Aspose предлагает бесплатный онлайн‑инструмент [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — которые позволяют настроить результирующий PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG 90, разрешением изображений 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

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

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просмотреть слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) со значением `true`, чтобы сохранить встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивным листом Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с приложенной книгой.

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

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик позволяет.

{{% alert color="info" title="Note" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 позволяет другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Пример использует настройку соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.

{{% /alert %}}

### **Конвертировать PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

В следующем примере презентация экспортируется в PDF, включая все скрытые слайды.

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

### **Конвертировать PowerPoint в PDF, защищённый паролем**

В следующем примере презентация экспортируется в PDF, который требует пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

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

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение печатается только тогда, когда недоступный шрифт заменяется во время экспорта.

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

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/androidjava/font-substitution/).

{{% /alert %}} 

### **Обработка шрифтов без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического утолщения, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от ожидаемого в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) со значением `true`. Этот параметр рендерит затронутый текст в виде битовой карты при экспорте PDF и может улучшить его внешний вид для некоторых шрифтов. Значение по умолчанию — `false`.

Примерная презентация содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного полужирного начертания. В следующем примере презентация загружается, включается растеризация неподдерживаемых стилей шрифтов, и экспортируется в PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ниже показаны предварительные просмотры с отключённым и включённым параметром. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённом параметре. При включённом параметре его штрихи легче; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Параметр отключён (`false`, значение по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF с отключённой растеризацией неподдерживаемого стиля шрифта](unsupported-bold-disabled.png) | ![PDF с включённой растеризацией неподдерживаемого стиля шрифта](unsupported-bold-enabled.png) |

В этом примере включение параметра превращает только полужирный текст в битовую карту: его нельзя выбрать, скопировать или искать как текст без OCR, а его края выглядят мягче при 800 % масштабировании. Обычный текст остаётся доступным для поиска. При отключённом параметре обе строки остаются текстовыми.

Этот параметр растрирует текст, отформатированный как полужирный, когда у его шрифта нет отдельного полужирного начертания. [Font substitution](/slides/ru/androidjava/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с 1, и входная презентация должна содержать как минимум три слайда.

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

В следующем примере первый слайд презентации копируется в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется, чтобы поместиться, и одинокий слайд экспортируется в PDF.

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

## **Конвертировать PowerPoint в PDF в представлении слайдов с нотами**

В следующем примере презентация экспортируется в PDF, размещая примечания докладчика под каждым слайдом. Используйте презентацию, содержащую примечания докладчика, чтобы увидеть результат.

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

В этом коде демонстрируется процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с разными стандартами соответствия:

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнить конвертации [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как одну фигурку. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигурки.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетом?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) со значением `true` в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) и [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы обеспечить изображения высокого качества в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for Android via Java Documentation](/slides/ru/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)