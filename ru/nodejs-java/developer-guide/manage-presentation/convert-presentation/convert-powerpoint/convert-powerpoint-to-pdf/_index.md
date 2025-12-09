---
title: Конвертировать PPT и PPTX в PDF на JavaScript [Включены расширенные функции]
linktitle: Конвертировать PPT и PPTX в PDF
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
  - ODP в PDF
  - конвертировать ODP в PDF
  - сохранить PowerPoint как PDF
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - JavaScript
  - Node.js
  - Aspose.Slides for Node.js via Java
description: "Узнайте, как конвертировать презентации PPT, PPTX и ODP в PDF на JavaScript с помощью Aspose.Slides. Реализуйте расширенные функции, такие как защита паролем, стандарты соответствия и пользовательские параметры для создания высококачественных доступных PDF-документов."
---

## **Обзор**

Преобразование презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и др.) в формат PDF с помощью JavaScript предоставляет несколько преимуществ, включая совместимость на различных устройствах и сохранение макета и форматирования вашей презентации. В этом руководстве демонстрируется, как конвертировать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java вставляет информацию о своей API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

Этот код демонстрирует, как конвертировать презентацию (PPT, PPTX, ODP и др.) в PDF:
```js
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Сохраните презентацию в формате PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), которые позволяют настроить полученный PDF, защитить PDF паролем или указать, как должен выполняться процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Пример кода ниже демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```js
// Создайте экземпляр класса PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Установите качество JPG‑изображений.
pdfOptions.setJpegQuality(java.newByte(90));

// Установите DPI для изображений.
pdfOptions.setSufficientResolution(300);

// Установите поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержания.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Определите режим соответствия PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Сохраните презентацию как PDF‑документ.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертировать PowerPoint в PDF с учётом скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды в качестве страниц в результирующий PDF.

Этот JavaScript код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```js
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Добавьте скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохраните презентацию как PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Конвертировать PowerPoint в PDF, защищённый паролем**

Этот JavaScript код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions):
```js
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создайте экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Установите пароль PDF и разрешения доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Сохраните презентацию как PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот JavaScript код показывает, как обнаружить замену шрифтов:
```js
// Установите обратный вызов предупреждений в параметрах PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Сохраните презентацию как PDF.
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

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов во время процесса рендеринга см. [Получение обратных вызовов при замене шрифтов](/slides/ru/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения более подробной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот JavaScript код демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```js
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Установите массив номеров слайдов.
    let slides = java.newArray("int", [1, 3]);

    // Сохраните презентацию как PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот JavaScript код демонстрирует, как конвертировать презентацию PowerPoint в PDF с заданным размером слайда:
```js
const slideWidth = 612;
const slideHeight = 792;

// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Установите пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Клонируйте первый слайд из исходной презентации.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохраните изменённую презентацию в PDF с заметками.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Конвертировать PowerPoint в PDF в режиме слайдов заметок**

Этот JavaScript код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```js
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Настройте параметры PDF с разметкой заметок.
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

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любые из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот JavaScript код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать файлы PDF в популярные форматы. Вы можете выполнить конвертации [PDF в HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF в JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — также поддерживаются.

{{% /alert %}} 

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Конечно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), чтобы установить пароль и определить разрешения доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы, такие как `setJpegQuality` и `setSufficientResolution`, в классе [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Node.js через Java](/slides/ru/nodejs-java/)
- [Справочник API Aspose.Slides для Node.js через Java](https://reference.aspose.com/slides/nodejs-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)