---
title: Переобразование PPT и PPTX в PDF с помощью JavaScript [Включены расширенные возможности]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественные, пригодные для поиска PDF с помощью Aspose.Slides для Node.js, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и т.д.) в формат PDF с помощью JavaScript предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как преобразовать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выводимым документам.

## **Конверсия PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Примечание" %}}

Aspose.Slides for Node.js via Java вставляет информацию о своей API и номер версии в выводимые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer строкой вида "*Aspose.Slides v XX.XX*". **Примечание**, что изменить или удалить эту информацию из выводимых документов с помощью Aspose.Slides нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF полностью соответствуют оригинальным презентациям. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркированные списки
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с настройками экспорта по умолчанию.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}

Aspose предлагает бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или указать, как должен выполняться процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Сохранение встроенных OLE‑файлов как вложений PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) со значением `true`, чтобы сохранить встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или иконка OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивным листом Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с прикреплённой книгой.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмоторщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмоторщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Примечание" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встроенные файлы, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В данном примере используется значение соответствия PDF по умолчанию и не демонстрируется экспорт PDF/A.

{{% /alert %}}

### **Конвертация PowerPoint в PDF с учётом скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующем PDF.

В следующем примере презентация экспортируется в PDF, включая все скрытые слайды.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертация PowerPoint в PDF, защищённый паролем**

В следующем примере презентация экспортируется в PDF, открытие которого требует пароль `password`. Права доступа позволяют печатать, включая печать высокого качества.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение печатается только при замене недоступного шрифта во время экспорта.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Обработка шрифтов без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у используемого шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического полужирного начертания, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от ожидаемого в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) со значением `true`. Этот параметр рендерит затронутый текст как растровое изображение при экспортировании в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

Примерная презентация содержит два текстовых блока: один с обычным текстом, второй с полужирным форматированием того же шрифта, у которого нет отдельного полужирного начертания. В следующем примере презентация загружается, включается растеризация неподдерживаемых стилей шрифтов, и экспортируется в PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ниже показаны предварительные просмотры при отключённом и включённом параметре. В этом примере при отключённом параметре полужирный текст имеет более тяжёлые штрихи. При включённом параметре штрихи легче; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для своей презентации.

| Параметр отключён (`false`, значение по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В данном примере включение параметра преобразует только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его кромки выглядят мягче при увеличении до 800 %. Обычный текст остаётся searchable. При отключённом параметре обе строки остаются текстом.

Этот параметр растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного полужирного начертания. [Font substitution](/slides/ru/nodejs-java/font-substitution/) вместо этого выбирает другой шрифт, если исходный недоступен.

## **Конвертация выбранных слайдов PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в массиве начинаются с 1, и входная презентация должна содержать как минимум три слайда.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд презентации копируется в новую презентацию с размером слайда 612 × 792 pt (8,5 × 11 дюймов). Содержимое слайда масштабируется для заполнения и экспортируется в PDF как единичный слайд.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Удалить пустой слайд, с которым была создана новая презентация.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертация PowerPoint в PDF в режиме заметок к слайдам**

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Также поддерживаются другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/).

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) со значением `true` в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) и [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for Node.js via Java Documentation](/slides/ru/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)