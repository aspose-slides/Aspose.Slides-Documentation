---
title: Преобразование слайдов презентации в изображения в PHP
linktitle: Слайд в изображение
type: docs
weight: 35
url: /ru/php-java/convert-slide/
keywords:
- преобразовать слайд
- экспортировать слайд
- слайд в изображение
- сохранить слайд как изображение
- слайд в EMF
- слайд в PNG
- слайд в JPEG
- слайд в bitmap
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Преобразуйте слайды из презентаций PPT, PPTX и ODP в форматы PNG, JPEG, GIF, TIFF, EMF и другие форматы изображений в PHP с помощью Aspose.Slides."
---
## **Введение**

Aspose.Slides for PHP via Java может рендерить отдельные слайды из презентаций PowerPoint и OpenDocument в форматы PNG, JPEG, GIF, TIFF и другие форматы изображений.

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
2. Выберите слайд, который хотите отобразить.
3. При необходимости настройте рендеринг с помощью класса [RenderingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/) .
4. Вызовите метод [Slide::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage) . Он возвращает объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) .
5. Вызовите метод [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save) . и укажите формат вывода значением [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/) .

## **Преобразование слайда в PNG‑изображение**

Самый простой способ конвертации использует настройки рендеринга по умолчанию. Полученный объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) можно обработать в памяти или сохранить в файл.

Следующий пример PHP рендерит первый слайд и сохраняет его как PNG‑изображение:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Преобразование слайдов в изображения с пользовательскими размерами**

Используйте перегрузку [Slide::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage) , принимающую значение [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) , чтобы отобразить слайд с точными пиксельными размерами.

Следующий пример создает JPEG‑изображение размером 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Преобразование слайдов с заметками и комментариями в изображения**

По умолчанию изображения слайдов не включают заметки или комментарии. Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/) в метод [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) , чтобы управлять размещением заметок и комментариев.

Следующий пример размещает обрезанные заметки под слайдом, а комментарии — справа от него:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
При конвертации слайдов в изображения не передавайте [BottomFull](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notespositions/) в метод [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) . Заметки могут содержать более текста, чем может уместиться в фиксированном размере изображения. Используйте вместо этого [BottomTruncated](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notespositions/) .
{{% /alert %}}

## **Преобразование слайдов в изображения с использованием параметров TIFF**

Класс [TiffOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/) позволяет управлять размером, разрешением и другими свойствами создаваемого TIFF‑изображения.

Следующий пример рендерит первый слайд как TIFF‑изображение размером 2160 × 2880 при 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Поддержка TIFF не гарантируется в версиях Java ранее JDK 9.
{{% /alert %}}

## **Преобразование всех слайдов в изображения**

Пройдите по коллекции слайдов, чтобы преобразовать всю презентацию в набор изображений. Скрытые слайды включаются, если вы явно не пропустите их.

Следующий пример рендерит каждый слайд как JPEG‑изображение с горизонтальным и вертикальным коэффициентом масштабирования 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Создание вывода в формате Enhanced Metafile**

Enhanced Metafile (EMF) полезен, когда векторную графику необходимо обменивать с Microsoft Office или другими Windows‑приложениями, поддерживающими Windows‑метафайлы. В отличие от растрового изображения, EMF может сохранять векторные операции рисования, которые масштабируются без потери резкости. Однако EMF в первую очередь является форматом совместимости для приложений с поддержкой Windows‑метафайлов, а не универсальным форматом обмена. Кроме того, сложное содержимое слайдов, такое как растровые изображения и некоторые эффекты, может сохраняться как растровые элементы внутри векторного контейнера метафайла.

### **Экспорт слайда в EMF**

Метод [Slide::writeAsEmf](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#writeAsEmf) записывает слайд в целевой поток в формате EMF. Следующий пример загружает презентацию, выбирает первый слайд и записывает его в поток EMF‑файла:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Вызывающая сторона владеет потоком, переданным в [Slide::writeAsEmf](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#writeAsEmf) , и отвечает за его закрытие, как показано выше.

### **Преобразование SVG‑изображения в EMF и добавление его в презентацию**

Используйте [SvgImage::writeAsEmf](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/#writeAsEmf) , чтобы преобразовать SVG‑контент в EMF. Полученные байты можно добавить в презентацию через [ImageCollection::addImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/#addImage) , а разместить их на слайде с помощью [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addPictureFrame) .

Следующий пример создает [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/) из SVG‑разметки, преобразует его в EMF в памяти, вставляет метафайл на первый слайд и сохраняет презентацию:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Метод [SvgImage::writeAsEmf](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/#writeAsEmf) не получает владения над целевым потоком. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) сохраняет все сгенерированные данные в памяти, поэтому сброс позиции не требуется перед вызовом `toByteArray`. Возвращаемый массив байтов остаётся действительным после закрытия потока.

Генерация EMF доступна на операционных системах, поддерживаемых выбранной конфигурацией Aspose.Slides for PHP via Java и JDK, однако рендеринг может различаться между платформами при отсутствии шрифтов или графических зависимостей. Установите шрифты, используемые исходным содержимым, или настройте соответствующие замены, следуйте [требованиям платформы](/slides/ru/php-java/system-requirements/) для Aspose.Slides for PHP via Java и проверьте результат в целевом приложении, потребляющем EMF. Приложения Linux и macOS часто имеют ограниченную или непоследовательную поддержку отображения и редактирования Windows‑метафайлов.

## **Отображение цветных эмодзи**

{{% alert title="Note" color="info" %}}
Чтобы корректно отображать цветные эмодзи при конвертации слайдов презентации в изображения, шрифты эмодзи, использованные в презентации, должны быть установлены и доступны на системе, выполняющей конвертацию. Например, если презентация использует **Segoe UI Emoji**, а этот шрифт отсутствует, эмодзи могут отображаться монохромными в результирующих изображениях.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides рендеринг слайдов с анимацией?**

Нет. Метод [Slide::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage) рендерит статическое изображение слайда и не экспортирует анимацию.

**Можно ли экспортировать скрытые слайды как изображения?**

Да. Скрытые слайды могут быть отрендерены как обычные слайды. Включайте их в цикл обработки, как показано в примере выше.

**Сохраняются ли тени и другие эффекты на изображениях слайдов?**

Да. Aspose.Slides отображает тени, прозрачность и другие поддерживаемые графические эффекты на изображениях слайдов.