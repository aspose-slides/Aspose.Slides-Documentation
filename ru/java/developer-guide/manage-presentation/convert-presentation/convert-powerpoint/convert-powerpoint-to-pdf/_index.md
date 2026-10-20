---
title: Конвертировать PPT и PPTX в PDF на Java [Включены расширенные функции]
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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF на Java с использованием Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на Java предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides можно конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java вставляет информацию о своем API и номер версии в генерируемые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в формате "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете указать Aspose.Slides изменять или удалять эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

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

{{% alert color="info" title="Note" %}}

Aspose предлагает бесплатный онлайн‑инструмент [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или задать порядок выполнения процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и многое другое.

В следующем примере экспортируется презентация в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

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

Если в презентации много фотографий или скриншотов, сокращение размера экспортируемого PDF упростит её отправку по электронной почте или загрузку. Вызовите [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) с параметром `true`, чтобы автоматически выбрать наилучший алгоритм сжатия для каждого изображения при экспорте в PDF.

В следующем примере загружается существующая презентация, включается автоматический выбор сжатия изображений и сохраняется как PDF‑документ. Все остальные параметры экспорта PDF остаются со значениями по умолчанию.

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

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение значения, передаваемого в [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-), уменьшает качество JPEG‑изображения, а понижение значения, передаваемого в [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-), позволяет понизить разрешение изображений, что также может сократить детали. Включение автоматического выбора сжатия само по себе не изменяет эти параметры.

Выбор алгоритмов сжатия изображений требует дополнительных ресурсов процессора и памяти. Степень уменьшения размера зависит от изображений в презентации и настроек экспорта; фиксированного снижения для каждой презентации не гарантируется.

### **Сохранение встроенных OLE‑файлов как вложений PDF**

Если в презентации присутствует встроенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к её данным. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) с параметром `true`, чтобы сохранять встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию `false`: на странице PDF отображается превью‑изображение или значок OLE‑объекта, но сам встроенный файл не включается как вложение. При установке параметра в `true` дополнительно включаются данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную рабочую книгу Excel, и экспортируется в PDF с прикреплённой книгой.

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

Для проверки результата:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например в Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встраивание файлов, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения Aspose.Slides. Пример использует настройку соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.

{{% /alert %}}

### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, используйте метод [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) из класса [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) чтобы включить скрытые слайды как страницы в результирующий PDF.

В следующем примере экспортируется презентация в PDF с включением всех скрытых слайдов.

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

### **Конвертация PowerPoint в PDF с паролем**

В следующем примере экспортируется презентация в PDF, открытие которого требует пароль `password`. Права доступа позволяют печать, в том числе печать в высоком качестве.

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

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) в классе [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время конвертации презентации в PDF.

В следующем примере экспортируется презентация в PDF и выводятся предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда при экспорте используется недоступный шрифт.

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

Подробнее о замене шрифтов см. в статье [Font Substitution](/slides/ru/java/font-substitution/).

{{% /alert %}} 

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть жирным за счёт синтетического утолщения, которое искусственно увеличивает толщину обычных глифов. Когда такой текст выглядит слишком тяжёлым или отличается от ожидаемого в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) с параметром `true`. Этот параметр рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В образце презентации две текстовые рамки: одна с обычным текстом, другая — с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. В следующем примере загружается презентация, включается растеризация неподдерживаемых стилей шрифта и экспортируется в PDF:

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

Ниже показаны предварительные просмотр отключённого и включённого вывода. В этом примере при отключённом параметре полужирный текст имеет более тяжёлые штрихи. При включённом параметре штрихи становятся тоньше; обычный текст остаётся без изменений. Сравните результаты перед тем, как выбрать настройку для вашей презентации.

| Параметр отключён (`false`, значение по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В данном примере включение параметра преобразует только полужирный текст в растровое изображение: его нельзя выбрать, скопировать или искать как текст без OCR, и его границы выглядят мягче при 800 % увеличении. Обычный текст остаётся доступным для поиска. При отключённом параметре оба фрагмента остаются текстом.

Этот параметр растеризует текст, отформатированный как жирный, когда у шрифта нет отдельного жирного начертания. [Font substitution](/slides/ru/java/font-substitution/) вместо этого выбирает другой шрифт, если оригинал недоступен.

## **Конвертация выбранных слайдов PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве нумеруются с единицы, и входная презентация должна содержать как минимум три слайда.

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

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 points (8,5 × 11 дюймов). Содержимое слайда масштабируется под размер и экспортируется в PDF как один слайд.

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

    // Удалить пустой слайд, который был создан в новой презентации.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертация PowerPoint в PDF в режиме заметок слайдов**

В следующем примере презентация экспортируется в PDF, при этом заметки докладчика каждого слайда помещаются под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

В этом коде демонстрируется процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) и [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Поддерживаются также специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) и [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические объекты, такие как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете пройтись по своим файлам и программно выполнить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) с параметром `true` в классе [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) чтобы включить скрытые слайды в результирующий PDF.

**Поддерживает ли Aspose.Slides высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) и [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) в классе [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF‑файлы, соответствующие [различным стандартам](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for Java Documentation](/slides/ru/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)