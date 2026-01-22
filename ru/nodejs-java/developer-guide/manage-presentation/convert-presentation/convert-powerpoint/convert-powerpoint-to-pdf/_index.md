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
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF с помощью Aspose.Slides для Node.js, с быстрыми примерами кода и расширенными параметрами конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и т.д.) в формат PDF на JavaScript предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Node.js via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в формате "*Aspose.Slides v XX.XX*". **Примечание** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Всю презентацию в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая, что полученные PDF‑файлы максимально соответствуют оригинальным презентациям. Элементы и атрибуты точно воспроизводятся при конвертации, включая:

* Изображения
* Текстовые блоки и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

Этот код показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```js
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Сохраните презентацию в формате PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 
Aspose предлагает бесплатный онлайн [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или задать порядок выполнения процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать порядок обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Пример кода ниже демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```js
// Создайте экземпляр класса PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Установите качество для JPG‑изображений.
pdfOptions.setJpegQuality(java.newByte(90));

// Установите DPI для изображений.
pdfOptions.setSufficientResolution(300);

// Установите поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержимого.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Определите режим соответствия PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Сохраните презентацию как PDF‑документ.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертировать PowerPoint в PDF с учетом скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды как страницы в результирующий PDF.

Этот JavaScript‑код показывает, как конвертировать презентацию PowerPoint в PDF с включением скрытых слайдов:
```js
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Добавьте скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохраните презентацию в формате PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертировать PowerPoint в защищённый паролем PDF**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions):
```js
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Установите пароль PDF и разрешения доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Сохраните презентацию в формате PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот JavaScript‑код показывает, как обнаружить замену шрифтов:
```js
// Установите обработчик предупреждений в параметрах PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Сохраните презентацию в формате PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 
Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/nodejs-java/font-substitution/).
{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот JavaScript‑код демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```js
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Установите массив номеров слайдов.
    let slides = java.newArray("int", [1, 3]);

    // Сохраните презентацию в формате PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF с заданным размером слайда:
```js
const slideWidth = 612;
const slideHeight = 792;

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Установите пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Клонируйте первый слайд из исходной презентации.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохраните изменённую презентацию в PDF с примечаниями.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Конвертировать PowerPoint в PDF в режиме слайдов с заметками**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```js
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Настройте параметры PDF с раскладкой заметок.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Сохраните презентацию в PDF с заметками.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Стандарты доступности и соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот JavaScript‑код демонстрирует процесс конвертации PowerPoint в PDF, который создает несколько PDF‑файлов в соответствии с разными стандартами соответствия:
```js
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


{{% alert title="Примечание" color="warning" %}} 
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнить конвертацию [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — также поддерживаются.
{{% /alert %}}

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя такие методы, как `setJpegQuality` и `setSufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) для обеспечения высококачественных изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы отвечают требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Node.js через Java](/slides/ru/nodejs-java/)
- [Справочник API Aspose.Slides для Node.js через Java](https://reference.aspose.com/slides/nodejs-java/)
- [Бесплатные онлайн-конвертеры Aspose](https://products.aspose.app/slides/conversion)