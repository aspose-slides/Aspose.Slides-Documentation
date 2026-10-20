---
title: Конвертировать PPT и PPTX в PDF на JavaScript [включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества, пригодные для поиска, используя Aspose.Slides для Node.js, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и т.д.) в формат PDF с помощью JavaScript предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в документы PDF, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Для конвертации презентации в PDF передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Note** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF-файлы максимально соответствуют оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Заголовки и нижние колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя параметры экспорта по умолчанию.

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
Aspose предлагает бесплатный онлайн‑конвертер [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или задать способ выполнения процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать обработку метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются в PNG, а текст сжимается методом Flate.

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

### **Автоматический выбор сжатия изображений**

Когда презентация содержит множество фотографий или скриншотов, уменьшение размера экспортируемого PDF может облегчить его отправку по электронной почте или загрузку. Вызовите [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) с `true`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

Следующий пример загружает существующую презентацию, включает автоматический выбор сжатия изображений и сохраняет её как PDF‑документ. Все остальные параметры экспорта PDF сохраняются со значениями по умолчанию.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Уменьшение значения, передаваемого в [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/), понижает качество JPEG‑изображений, тогда как уменьшение значения, передаваемого в [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/), позволяет понижать разрешение изображений, что может уменьшить детали. Включение автоматического выбора сжатия само по себе не меняет ни одну из этих настроек.

Выбор алгоритмов сжатия изображений требует дополнительного времени обработки и памяти. Сокращение размера зависит от изображений в презентации и настроек экспорта; фиксированное уменьшение не гарантировано для каждой презентации.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если в презентации присутствует встроенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным рабочей книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) с `true`, чтобы сохранить встроенные OLE‑файлы в виде вложений в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но вложенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивным листом Excel на странице PDF.

Следующий пример загружает презентацию, в которой уже содержится встроенная рабочая книга Excel, и экспортирует её в PDF с вложенной рабочей книгой.

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

Для проверки результата:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения, например в Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, или откройте сразу, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В данном примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в качестве страниц в результирующем PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

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

### **Конвертировать PowerPoint в защищенный паролем PDF**

Следующий пример экспортирует презентацию в PDF, который требует пароль `password` для открытия. Разрешения доступа позволяют печать, включая печать высокого качества.

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

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), позволяющий обнаружить замену шрифтов в процессе конвертации презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда недоступный шрифт заменяется во время экспорта.

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
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/nodejs-java/font-substitution/).
{{% /alert %}}

### **Обрабатывать шрифты без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может отображаться полужирным за счёт синтетического утолщения, которое искусственно делает обычные глифы толще. Когда такой текст выглядит слишком тяжёлым или иначе отличается от требуемого вида в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) с `true`. Этот параметр рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В демонстрационной презентации два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. Следующий пример загружает презентацию, включает растрирование неподдерживаемых стилей шрифтов и экспортирует её в PDF:

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

Ниже показаны предварительные просмоторы с отключённым и включённым параметром. В этом примере при отключённом параметре полужирный текст имеет более тяжёлые штрихи. При включённом параметре его штрихи легче; обычный текст остаётся без изменений. Сравните результаты, прежде чем выбрать настройку для своей презентации.

| Параметр отключён (`false`, значение по умолчанию) | Параметр включён (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В данном примере включение параметра превращает только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят мягче при увеличении до 800 %. Обычный текст остаётся доступным для поиска. При отключённом параметре обе строки остаются текстом.

Этот параметр расторможивает текст, отформатированный как полужирный, когда у шрифта нет отдельного жирного начертания. [Замена шрифтов](/slides/ru/nodejs-java/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

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

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 pt (8,5 × 11 дюймов). Он масштабирует содержимое слайда, чтобы оно помещалось, и экспортирует один слайд в PDF.

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

    // Удалить пустой слайд, который был создан в новой презентации.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме слайдов с примечаниями**

Следующий пример экспортирует презентацию в PDF, помещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создает несколько PDF‑файлов в зависимости от разных стандартов соответствия:

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
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF в JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — также поддерживаются.
{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как одну фигуру. Отдельные элементы пути не сохраняются как отдельное содержимое и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) для установки пароля и определения разрешений доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) с `true` в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующем PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете управлять качеством изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) и [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивации.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Node.js через Java](/slides/ru/nodejs-java/)
- [Справочник API Aspose.Slides для Node.js через Java](https://reference.aspose.com/slides/nodejs-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)