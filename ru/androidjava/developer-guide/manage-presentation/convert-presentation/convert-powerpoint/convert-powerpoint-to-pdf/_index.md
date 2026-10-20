---
title: Конвертация PPT и PPTX в PDF на Android [Включены расширенные функции]
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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поисковые PDF в Java с помощью Aspose.Slides для Android, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Android предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), а затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Примечание" %}}
Aspose.Slides for Android via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в виде "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете указать Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Всю презентацию в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы максимально соответствуют оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимально высоким качеством.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}
Aspose предлагает бесплатный онлайн [конвертер PowerPoint в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для практической реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или указать, как должен выполняться процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным на 90, разрешением изображения 300 DPI, метафайлы сохраняются в формате PNG и используется Flate‑сжатие текста.

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

### **Автоматический выбор сжатия изображений**

Если в презентации содержится много фотографий или скриншотов, уменьшение размера экспортируемого PDF может облегчить его отправку по электронной почте или загрузку. Вызовите [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) с параметром `true`, чтобы автоматически выбрать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

В следующем примере загружается существующая презентация, включается автоматический выбор сжатия изображений и сохраняется как PDF‑документ. Все остальные параметры экспорта PDF сохраняют значения по умолчанию.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Уменьшение значения, передаваемого в [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-), снижает качество JPEG‑изображения, а уменьшение значения, передаваемого в [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-), позволяет понизить разрешение изображений, что может уменьшить детализацию. Включение автоматического выбора сжатия само по себе не изменяет эти параметры.

Выбор алгоритмов сжатия изображений требует дополнительного времени обработки и памяти. Сокращение размера зависит от изображений в презентации и настроек экспорта; фиксированное уменьшение не гарантировано для каждой презентации.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если в презентации содержится встроенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным рабочей книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) с параметром `true`, чтобы сохранить встроенные OLE‑файлы как вложения в результирующий PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную рабочую книгу Excel, и экспортируется в PDF с вложенной рабочей книгой.

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

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** (Вложений) смотрителя и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, либо откройте напрямую, если просмотрщик позволяет. Превью на странице PDF отличается от вложения.

{{% alert color="info" title="Примечание" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встроенные файлы, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В данном примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF со скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) класса [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

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

В следующем примере презентация экспортируется в PDF, требующий пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

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

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение выводится только в случае, когда недоступный шрифт заменяется при экспорте.

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

{{% alert color="info" title="Примечание" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/androidjava/font-substitution/).
{{% /alert %}}

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у используемого шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть жирным за счёт синтетического утолщения, которое искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от желаемого отображения в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) с параметром `true`. Этот параметр отображает затронутый текст как растровое изображение во время экспорта PDF и может улучшить его внешний вид для некоторых шрифтов. Значение по умолчанию — `false`.

Примерная презентация содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. В следующем примере презентация загружается, включается растеризация неподдерживаемых стилей шрифтов, и экспортируется в PDF:

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

Ниже показаны предварительные просмотры вывода с отключённым и включённым параметром. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённом параметре. При включённом параметре его штрихи становятся тоньше; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Параметр отключён (`false`, по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение параметра преобразует только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, и его контуры выглядят мягче при увеличении 800 %. Обычный текст остаётся доступным для поиска. При отключённом параметре обе строки остаются текстом.

Этот параметр растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного жирного начертания. [Font Substitution](/slides/ru/androidjava/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

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

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется до подходящего размера и экспортируется в PDF как один слайд.

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

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов на основе различных стандартов соответствия:

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

{{% alert color="info" title="Примечание" %}}
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать файлы PDF в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

**Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы путей не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Часто задаваемые вопросы**

**Можно ли массово конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно выполнить процесс конвертации.

**Можно ли защитить конвертированный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) с параметром `true` в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете управлять качеством изображений, используя такие методы, как [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) и [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) в классе [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), чтобы обеспечить изображения высокого качества в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Android через Java](/slides/ru/androidjava/)
- [Справочник API Aspose.Slides для Android через Java](https://reference.aspose.com/slides/androidjava/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)