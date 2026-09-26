---
title: Изменение размера и ориентации страницы заметок в PHP
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/php-java/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- портретные заметки
- размер раздаточного листа
- PowerPoint
- презентация
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для PHP через Java, переключение ориентации, проверка сохранённых размеров и экспорт заметок или раздаточных листов в PDF и изображения."
---
## **Обзор**

Используйте [Presentation::getNotesSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getnotessize/) для доступа к настройкам страницы заметок презентации. Он возвращает объект [NotesSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notessize/), у которого метод [setSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notessize/setsize/) задает размеры страницы. Хотя сам объект настроек заменить нельзя, новые размеры можно задать через этот метод.

Ширина и высота указываются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек — это 12,5 × 8 ⅓ дюйма. Эти настройки применяются к презентации в целом, а не к отдельной странице заметок слайда.

| Настройка | Назначение |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getnotessize/) | Управляет размерами страницы заметок и размерами страниц, используемыми при экспорте раздаточных материалов. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getslidesize/) | Управляет обычными размерами слайдов презентации через [SlideSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/). |

Изменение любой из настроек не приводит к автоматическому изменению другой. Изменение ориентации страницы заметок также не вращает обычные слайды. Смотрите раздел [Slide Size](/slides/ru/php-java/slide-size/) для изменения размеров обычных слайдов.

Примеры ниже используют существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию с как минимум одним слайдом, содержащим заметки докладчика. Каждый пример можно запускать независимо после загрузки PHP/Java Bridge и обертки Aspose.Slides для PHP. Числовые значения, возвращаемые Java, преобразуются в PHP‑значения с помощью `java_values` перед сравнением или вычислением.

## **Чтение размеров и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, одинаковые размеры — квадратная страница. Этот пример выводит фактические размеры в точках, не полагаясь на стандартный размер бумаги.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Переход к альбомной ориентации без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длину обеих сторон, включая пользовательский размер бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портрет и оставляет квадратную страницу без изменений.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Для портретной ориентации используйте тот же оператор, когда `java_values($size->getWidth()) > java_values($size->getHeight())`. Не подставляйте размеры A4 или Letter, если только вы не хотите одновременно изменить размер бумаги.

## **Установка и проверка пользовательского размера страницы заметок**

Задайте обе величины одновременно, затем используйте [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/save/) для записи презентации. Этот пример задаёт альбомную страницу 900 × 600 точек, сохраняет её как PPTX и снова открывает сохранённый файл для проверки сохранённого значения. При сравнении допускается погрешность 0,01 точки для значений с плавающей точкой; это не гарантирует точность для всех форматов файлов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Ожидаемый результат — `900 x 600 points` и `Size preserved: true`. Проверка вновь открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страницы определяют доступную область для макетов заметок или раздаточных листов. Они не включают эти макеты автоматически: необходимо также настроить параметры экспорта. Экспорт обычных слайдов по‑прежнему использует размеры слайда.

### **Экспорт заметок в PDF и PNG**

Назначьте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/) свойству [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage) и [RenderingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notespositions/) оставляет заметки на одной странице; заметки, которые не помещаются, могут быть усечены. PDF использует страницы 900 × 600 точек. При масштабе изображения 1 × 1, используемом ниже, PNG имеет 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели — растровый вывод, размеры которого также зависят от масштаба рендеринга.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Для экспорта PDF с длинными заметками режим [BottomFull](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notespositions/) позволяет создавать дополнительные страницы по мере необходимости. Не используйте этот режим с вызовом одиночного слайда изображения выше, который его не поддерживает. После изменения размеров проверьте результат на наличие обрезанных заметок и расположение существующих объектов мастера заметок; изменение только размеров страницы не гарантирует, что всё содержимое поместится. См. раздел [Convert PowerPoint to PDF with Notes](/slides/ru/php-java/convert-powerpoint-to-pdf-with-notes/) для дополнительной информации об экспорте заметок.

### **Экспорт раздаточных листов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. В следующем примере задаётся страница 900 × 600 точек и используется [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ru/php-java/aspose.slides/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальный предустановленный тип управляет порядком слайдов; ориентация страницы берётся из её ширины и высоты.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Изменение размера страницы изменяет область, доступную для сетки раздаточных листов, без изменения размеров исходных слайдов. Для изображений раздаточных листов используйте [Presentation::getImages](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getimages/) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных листов на уровне презентации использует размеры страницы заметок, тогда как отдельный вызов получения изображения слайда не создаёт страницу раздаточного листа. См. раздел [Handout Mode](/slides/ru/php-java/convert-powerpoint-in-handout-mode/) для вариантов макетов.

## **Размер страницы в просмотрах, экспорте и печати**

Сохраняйте различие между размером, хранящимся в презентации, экспортируемым размером страницы и размером бумаги при печати:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила макета. Если другое приложение сохраняет файл, откройте его вновь и проверьте размеры; конверсия формата в том приложении может их нормализовать.
- **Форматы экспорта:** Примеры PDF для заметок и раздаточных листов выше используют настроенные размеры страниц. Растровые изображения используют целочисленные размеры в пикселях и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размеры страницы заметок.
- **Драйверы принтеров:** Выбор бумаги, автоматическое вращение и настройки «подогнать к странице» могут изменить физический вывод без изменения размеров, сохранённых в презентации или PDF. Для конкретного размера бумаги сопоставьте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Можно ли задать размер заметок только для одного слайда?**

Размер страницы заметок — это настройка уровня презентации. У отдельных слайдов может быть различное содержимое заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размера обычных слайдов, когда нужно изменить сами слайды.

**Почему сохранённый или печатный результат имеет другой размер?**

Сначала откройте сохранённую презентацию вновь и сравните её размеры страницы заметок. Если они изменились, проверьте, изменил ли формат конвертации в другом приложении настройки страницы. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги в принтере.