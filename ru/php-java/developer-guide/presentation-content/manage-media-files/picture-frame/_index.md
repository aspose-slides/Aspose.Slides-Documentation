---
title: Управление кадрами изображений в презентациях с использованием PHP
linktitle: Кадр изображения
type: docs
weight: 10
url: /ru/php-java/picture-frame/
keywords:
- кадр изображения
- добавить кадр изображения
- создать кадр изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG‑изображение
- обрезка изображения
- удалить обрезанные области
- сжатие изображения
- StretchOffset
- форматирование кадра изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте, форматируйте, привязывайте, обрезайте, извлекайте и сжимайте кадры изображений в презентациях с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Кадр изображения — это объект формы слайда, отображающий изображение. В Aspose.Slides ресурс изображения и форма, которая его отображает, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), а [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) управляет положением изображения, размером, форматированием линии, вращением, обрезкой, эффектами изображения и другими настройками уровня кадра.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании кадров.

Кадры изображения могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на портативность, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, перед применением форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте кадр изображения с помощью [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/). Изображение становится частью пакета презентации, поэтому презентация остаётся самодостаточной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт кадр с исходными размерами изображения и применяет форматирование линии и вращение:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Кадр изображения управляет отображаемой геометрией; изменение размера кадра не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштабирования**

[PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) предоставляет возможность относительного масштабирования ширины и высоты кадра через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescalewidth/) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительное масштабирование удобно, когда процесс требует сохранять соотношение с размером исходного изображения вместо ручного расчёта конечных размеров.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Относительное масштабирование изменяет настройки масштаба кадра; оно не переобразует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым безопасным выбором с точки зрения портативности и предсказуемого рендеринга. Связанное изображение хранит внешний путь через метод [Picture::setLinkPathLong](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/setlinkpathlong/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранимых в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанное изображение может не отображаться должным образом. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт кадр изображения и указывает его на локальный файл изображения. Он касается только связывания изображений; связывание видео — отдельный медиа‑процесс, намеренно не смешанный в данном примере.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Используйте ссылки, когда намеренно управлять внешними файлами. Не применяйте их просто как замену сжатию: небольшая PPTX с повреждёнными зависимостями изображений обычно менее полезна, чем более крупная самодостаточная презентация.

## **Извлечение изображений из кадров**

Перед извлечением изображения из существующей презентации проверьте, что форма действительно является [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) и содержит встроенное изображение. Связанные кадры изображений могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) напрямую. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Сохранение через [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save) преобразует извлечённое изображение в запрашиваемый формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не конвертированный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/). Это позволяет получить SVG‑данные напрямую без предварительной растеризации изображения.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Сохранение SVG‑контента как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязательно преобразует векторный контент в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтная копия оригинального встроенного SVG; используйте данные [SvgImage::getSvgData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/getsvgdata/) при необходимости самого векторного ресурса.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри кадра. Значения обрезки в [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь изменяет видимую область.

Следующий пример безопасно находит кадр изображения и применяет значения обрезки:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области могут быть физически удалены, как описано в следующем разделе.

## **Удаление данных обрезанных изображений**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но представляет собой разрушительную оптимизацию: после сохранения презентации удалённые пиксели больше недоступны для последующей операции «отобрезки».

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими кадрами, эти кадры всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка контента WMF или EMF этим методом растеризует полученный результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) уменьшает разрешение растрового изображения относительно размера, в котором картинка отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено в размере или обрезано, и `false`, когда изменений не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturescompression/) при достаточном стандартном целевом разрешении:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Можно передать пользовательское положительное значение DPI вместо предопределённого, когда требуется конкретный целевой размер.

Сжатие предназначено для растровых изображений. SVG‑ и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, при котором изображение будет фактически просматриваться или экспортироваться, а не применяйте самый низкий DPI глобально.

## **Проверка эффектов изображения**

Эффекты изображения хранятся в картинке, используемой кадром. Коллекция трансформаций изображения может содержать эффекты, такие как фиксированная альфа‑модуляция для прозрачности и яркость/контраст для светлоты. Пример ниже безопасно читает оба типа эффектов из первого кадра изображения на слайде:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Эти эффекты изменяют способ рендеринга изображения в кадре; они не переписывают оригинальные байты встроенного изображения.

## **Блокировка геометрии кадра изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для кадра изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) сохраняет пропорции формы при её изменении размеров.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Блокировка применяется к форме кадра изображения. Она не заставляет исходное изображение переобразовываться или постоянно изменяться до тех же пропорций.

## **Регулировка значений StretchOffset**

Когда режим заливки изображения установлен в растяжение, значения stretch‑offset в [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) определяют прямоугольник заливки относительно ограничивающего окна кадра. Положительные проценты создают отступ от кромки, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видна; stretch‑offset меняет прямоугольник, в который растягивается видимая заливка изображения.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Используйте stretch‑offset для размещения заливки. Применяйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Соображения по хранению, размеру файлов и экспорту**

Основные компромиссы проще управлять, когда хранение изображений и форматирование кадра рассматриваются независимо:

- **Встроенные изображения** делают презентацию самодостаточной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или локациям.
- **Обрезка** изначально неразрушительна. Скрытые пиксели остаются встроенными до тех пор, пока обрезанные области явно не удаляются или не удаляются при сжатии.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но теряется исходное разрешение. Его следует применять после того, как известен конечный размер изображения на слайде.
- **SVG‑изображения** следует оставлять в формате SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать, используя уже существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/), вместо многократной загрузки одного и того же файла в процесс работы с презентацией.

Для крупных презентаций оптимизацию изображений обычно эффективнее проводить выборочно: хранить логотипы и схемы как векторный контент, сжимать фотографии в соответствии с их реальным размером отображения, удалять обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегать внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **Часто задаваемые вопросы**

**В чем разница между кадром изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) представляет ресурс изображения, ассоциированный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) — это форма на слайде, отображающая изображение и хранящая настройки уровня кадра, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли внедрять или связывать изображения?**

Внедряйте изображения, когда презентация должна быть портативной, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют пиксели. Используйте [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно безвозвратно удалить.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить хранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальный исходный файл вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует работать с SVG‑изображениями?**

Оставляйте SVG‑контент в виде SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для кадра изображения. Проверка `java_instanceof` против [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) предотвращает недопустимые приведения и позволяет коду корректно обрабатывать слайды, не содержащие кадры изображений.