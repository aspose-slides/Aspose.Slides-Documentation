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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF с помощью Aspose.Slides для Node.js, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint и OpenDocument (PPT, PPTX, ODP и т.д.) в формат PDF с помощью JavaScript предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертации PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода `save`. Класс [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) предоставляет метод `save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Node.js via Java вставляет информацию о своей версии API в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в виде "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF исходным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

Этот код показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```js
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Сохранить презентацию в PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose предлагает бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с опциями**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/) — которые позволяют настроить получаемый PDF, установить пароль для PDF или задать порядок выполнения процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими опциями**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, показывающий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```js
// Создать экземпляр класса PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Установить качество JPG‑изображений.
pdfOptions.setJpegQuality(java.newByte(90));

// Установить DPI для изображений.
pdfOptions.setSufficientResolution(300);

// Задать поведение для метафайлов.
pdfOptions.setSaveMetafilesAsPng(true);

// Установить уровень сжатия текста для текстового контента.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Определить режим соответствия PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Сохранить презентацию в PDF‑документ.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды в виде страниц в результирующий PDF.

Этот JavaScript‑код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```js
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создать экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Добавить скрытые слайды.
    pdfOptions.setShowHiddenSlides(true);

    // Сохранить презентацию в PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Конвертировать PowerPoint в PDF с защитой паролем**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions):

```js
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Создать экземпляр класса PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Установить пароль PDF и разрешения доступа.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Сохранить презентацию в PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions), позволяющий обнаруживать замену шрифтов во время процесса преобразования презентации в PDF.

Этот JavaScript‑код показывает, как обнаружить замену шрифтов:

```js
// Установить обработчик предупреждений в параметрах PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Сохранить презентацию в PDF.
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
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Задать массив номеров слайдов.
    let slides = java.newArray("int", [1, 3]);

    // Сохранить презентацию в PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:

```js
const slideWidth = 612;
const slideHeight = 792;

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Создать новую презентацию с изменённым размером слайда.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Установить пользовательский размер слайда.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Клонировать первый слайд из оригинальной презентации.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Сохранить изменённую презентацию в PDF с заметками.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**

Этот JavaScript‑код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```js
// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Настроить параметры PDF с макетом заметок.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Сохранить презентацию в PDF с заметками.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот JavaScript‑код демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с различными стандартами соответствия:

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
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/nodejs-java/conversion/pdf-to-html/), [PDF в JPG](https://products.aspose.com/slides/ru/nodejs-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/nodejs-java/conversion/pdf-to-png/). Поддерживаются также другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/nodejs-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/nodejs-java/conversion/pdf-to-tiff/).
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию множества файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как `setJpegQuality` и `setSufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PdfOptions), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Node.js via Java](/slides/ru/nodejs-java/)
- [API‑Reference Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/ru/nodejs-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)