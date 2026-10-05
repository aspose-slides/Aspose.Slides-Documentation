---
title: Конвертировать PPT и PPTX в PDF на JavaScript [Включены расширенные функции]
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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF с помощью Aspose.Slides для Node.js, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и т.д.) в формат PDF с помощью JavaScript предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать подстановки шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к получаемым документам.

## **Преобразования PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , а затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) . Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) , который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертировании презентации в PDF Aspose.Slides заполняет поле Application значением «*Aspose.Slides*», а поле PDF Producer — значением в формате «*Aspose.Slides v XX.XX*». **Примечание** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая близкое соответствие полученных PDF оригиналам. Элементы и атрибуты точно воспроизводятся при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Обычный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

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

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) , который демонстрирует процесс конвертации презентации в PDF. Вы можете выполнить тест с помощью этого конвертера для практической реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) , позволяющие настроить полученный PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются в PNG и применяется сжатие текста Flate.

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

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) с `true`, чтобы сохранить встроенные OLE‑файлы как вложения в получаемом PDF.

Значение по умолчанию — `false`: предварительный образ или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка опции в `true` дополнительно включает данные файла. Предпросмотр остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с вложенной книгой.

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

1. Откройте экспортированный PDF в средстве просмотра, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** просмотрщика и найдите вложенную книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, или откройте напрямую, если просмотрщик позволяет. Предпросмотр на странице PDF отделён от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Данный пример использует настройку соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в виде страниц в получаемом PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

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

### **Конвертировать PowerPoint в PDF, защищённый паролем**

В следующем примере презентация экспортируется в PDF, требующий пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

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

### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) , позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение выводится только при подстановке недоступного шрифта во время экспорта.

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

{{% alert color="info" title="Note" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/nodejs-java/font-substitution/) .
{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

В следующем примере слайды 1 и 3 из презентации экспортируются в PDF. Номера слайдов в этом массиве начинаются с единицы, и исходная презентация должна содержать как минимум три слайда.

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

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется под размер и экспортируется как один слайд в PDF.

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

## **Конвертировать PowerPoint в PDF в режиме примечаний к слайду**

В следующем примере презентация экспортируется в PDF, при этом примечания докладчика каждого слайда помещаются под слайдом. Используйте презентацию, содержащую примечания докладчика, чтобы увидеть результат.

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

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) . Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создает несколько PDF‑файлов на основе разных стандартов соответствия:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнить преобразования [PDF в HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF в JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) . Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) с `true` в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) , чтобы включить скрытые слайды в получаемый PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) , чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) , включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы отвечают требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Node.js через Java](/slides/ru/nodejs-java/)
- [Ссылка API Aspose.Slides для Node.js через Java](https://reference.aspose.com/slides/nodejs-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)