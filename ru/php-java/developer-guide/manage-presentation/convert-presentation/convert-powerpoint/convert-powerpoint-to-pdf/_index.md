---
title: Конвертация PowerPoint в PDF
linktitle: Конвертация PowerPoint в PDF
type: docs
weight: 40
url: /ru/php-java/convert-powerpoint-to-pdf/
keywords: "Конвертация PowerPoint, Презентация, PowerPoint в PDF, PPT в PDF, PPTX в PDF, Сохранить PowerPoint как PDF, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "Конвертация презентации PowerPoint в PDF. Сохраните PowerPoint как PDF с соблюдением стандартов совместимости или доступности."

---
## **Обзор**

В этой статье объясняется, как вы можете конвертировать форматы файлов PowerPoint в PDF с помощью PHP. Освещаются широкий спектр тем, например:

- Конвертация PPT в PDF
- Конвертация PPTX в PDF
- Конвертация ODP в PDF
- Конвертация PowerPoint в PDF

## **Конвертации PowerPoint в PDF на Java**

Используя Aspose.Slides, вы можете конвертировать презентации в этих форматах в PDF:

* PPT
* PPTX
* ODP

Чтобы конвертировать презентацию в PDF, вы просто должны передать имя файла в качестве аргумента в классе [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), а затем сохранить презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-). Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) предоставляет метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-), который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides для PHP через Java напрямую записывает информацию об API и номер версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides для PHP через Java заполняет поле Приложение значением '*Aspose.Slides*' и поле Производитель PDF значением в формате '*Aspose.Slides v XX.XX*'. **Обратите внимание**, что вы не можете запретить Aspose.Slides для PHP через Java изменять или удалять эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* целую презентацию в PDF
* конкретные слайды в презентации в PDF
* презентацию 

Aspose.Slides экспортирует презентации в PDF таким образом, что содержимое результирующих PDF очень похоже на таковое в оригинальных презентациях. Эти известные элементы и атрибуты часто правильно отображаются при конвертации презентации в PDF:

* изображения
* текстовые поля и другие фигуры
* тексты и их форматирование
* абзацы и их форматирование
* гиперссылки
* заголовки и колонтитулы
* маркеры
* таблицы

## **Конвертация PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием стандартных параметров. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF с использованием оптимальных настроек на максимальных уровнях качества.

Этот PHP-код показывает, как конвертировать PowerPoint в PDF:

```php
  # Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # Сохранение презентации в формате PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации процедуры, описанной здесь, вы можете провести тест с конвертером.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions), которые позволяют вам настраивать PDF (результат процесса конвертации), защищать PDF паролем или даже указывать, как должен проходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете установить желаемые настройки качества для изображений JPG, указать, как должны обрабатываться метафайлы, установить уровень сжатия для текстов и т.д.

Этот PHP-код демонстрирует операцию, в которой PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Создание экземпляра класса PdfOptions
    $pdfOptions = new PdfOptions();
    # Установка качества Jpeg
    $pdfOptions->setJpegQuality(90);
    # Установка поведения для метафайлов
    $pdfOptions->setSaveMetafilesAsPng(true);
    # Установка уровня сжатия для текстов
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # Определение стандарта PDF
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # Сохранение презентации в формате PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать пользовательский параметр — свойство [ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) из класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) — чтобы указать Aspose.Slides включить скрытые слайды в виде страниц в результирующем PDF.

Этот PHP-код показывает, как конвертировать презентацию PowerPoint в PDF с включением скрытых слайдов:

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Создание экземпляра класса PdfOptions
    $pdfOptions = new PdfOptions();
    # Включение скрытых слайдов
    $pdfOptions->setShowHiddenSlides(true);
    # Сохранение презентации в формате PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Конвертация PowerPoint в PDF с защитой паролем**

Этот PHP-код показывает, как конвертировать PowerPoint в PDF с защитой паролем (используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)):

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Создание экземпляра класса PdfOptions
    $pdfOptions = new PdfOptions();
    # Установка пароля PDF и разрешений на доступ
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # Сохранение презентации в формате PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) в классе [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/), который позволяет вам обнаруживать замены шрифтов в процессе конвертации презентации в PDF.

Этот PHP-код показывает, как обнаружить замены шрифтов:

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("Предупреждение о замене шрифта: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о получении обратных вызовов для замены шрифтов в процессе рендеринга смотрите [Получение обратных вызовов о замене шрифтов](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов смотрите статью [Замена шрифтов](https://docs.aspose.com/slides/php-java/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов в PowerPoint в PDF**

Этот PHP-код показывает, как конвертировать конкретные слайды в презентации PowerPoint в PDF:

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Установка массива позиций слайдов
    $slides = array(1, 3 );
    # Сохранение презентации в формате PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот PHP-код показывает, как конвертировать PowerPoint в PDF, когда указан размер слайда:

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # Установка типа и размера слайда
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертация PowerPoint в PDF в режиме заметок слайдов**

Этот PHP-код показывает, как конвертировать PowerPoint в PDF заметок:

```php
// Создание экземпляра класса Presentation, который представляет файл PowerPoint
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет вам использовать процесс конвертации, соответствующий [Руководящим принципам по доступности веб-контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот PHP-код демонстрирует операцию конвертации PowerPoint в PDF, в которой получены несколько PDF на основе различных стандартов соответствия:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка операций конвертации PDF в Aspose.Slides позволяет вам также конвертировать PDF в наиболее популярные форматы файлов. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}