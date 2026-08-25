---
title: Управление рамками изображений в презентациях с помощью PHP
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/php-java/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG-изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Рамка изображения — это форма слайда, которая отображает изображение. В Aspose.Slides ресурс изображения и форма, которая его отображает, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), в то время как [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) контролирует позицию изображения, его размер, форматирование линий, вращение, кадрирование, эффекты изображения и другие настройки уровня рамки.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый PPImage и используйте этот ресурс изображения при создании рамок изображений.

Рамки изображений могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо того, чтобы хранить байты изображения в презентации. Выбор влияет на портативность, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создает рамку с исходными размерами изображения и применяет форматирование линий и вращение:

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

Рамка изображения контролирует отображаемую геометрию; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующем кадрировании или сжатии изображения.

## **Использование относительного масштаба**

[PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) предоставляет относительное масштабирование ширины и высоты рамки через методы [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescalewidth/) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительный масштаб полезен, когда процесс необходимо сохранить соотношение с исходным размером изображения вместо ручного расчёта конечных размеров.

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

Относительный масштаб изменяет настройки масштаба рамки; он не переотбирает и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым безопасным вариантом для портативности и предсказуемого отображения. Связанное изображение хранит внешний путь через метод [Picture::setLinkPathLong](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/setlinkpathlong/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в файле PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, которое открывает или отображает презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступным, связанное изображение может не отобразиться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или отображать в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавить связанное изображение**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Он работает только с привязкой изображений; привязка видео — отдельный медиа‑процесс и намеренно не смешана в этом примере.

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

Используйте ссылки, когда внешнее управление файлами является намеренным. Не используйте их просто как замену сжатию: небольшой PPTX с битыми зависимостями изображений обычно менее полезен, чем более крупная автономная презентация.

## **Извлечение изображений из рамок**

Перед извлечением изображения из существующей презентации проверьте, что форма действительно является [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) и содержит встроенное изображение. Связанные рамки изображений могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечь растровое изображение**

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

Сохранение через [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save) преобразует извлечённое изображение в запрошенный формат вывода. Если вам нужны кодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечь SVG‑изображение**

Для SVG‑изображения [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/). Это позволяет получить данные SVG напрямую, не растрируя изображение сначала.

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

Сохранение SVG‑содержимого как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязательно преобразует векторное содержимое в пиксели. Экспорт слайдов в PDF или SVG также является процессом рендеринга, поэтому экспортированную графику нельзя рассматривать как побайтную копию оригинального встроенного SVG; используйте данные [SvgImage::getSvgData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/getsvgdata/) встроенного ресурса, когда нужен сам векторный ресурс.

## **Кадрировать изображение**

Кадрирование меняет видимую часть изображения внутри рамки. Значения кадрирования на [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Кадрирование изначально не удаляет скрытые пиксели из встроенного изображения; оно лишь меняет видимую область.

Следующий пример надёжно находит рамку изображения и применяет значения кадрирования:

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

Поскольку скрытые данные изображения всё ещё присутствуют, кадрирование можно изменить позже без потери оригинальных пикселей. Если важен размер файла более, чем обратимость, области кадрирования можно физически удалить, как описано в следующем разделе.

## **Удаление данных обрезанных участков изображения**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) удаляет данные изображения за пределами текущего прямоугольника кадрирования и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для обратного кадрирования.

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки продолжают нуждаться в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее число изображений. Кадрирование содержимого WMF или EMF этим методом растрирует результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено по размеру или обрезано, и `false`, когда изменение не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturescompression/), когда достаточно стандартного целевого разрешения:

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

Вместо предопределённого значения можно передать пользовательское положительное DPI, когда требуется конкретный целевой размер.

Сжатие предназначено для растровых изображений. SVG‑ и метафайлы не уменьшаются этим растровым процессом. Также помните, что уменьшение разрешения и удалённые обрезанные области невозможно восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из наибольшего размера, с которым изображение будет фактически просматриваться или экспортироваться, а не применяя минимальное DPI глобально.

## **Управление эффектами трансформации изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые преобразования, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и проверку обратного хода, см. [Image Transform Effects](/slides/ru/php-java/image-transform-effects/).

## **Блокировка геометрии рамки изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) сохраняет пропорции формы при её изменении размера.

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

Блокировка применяется к форме рамки изображения. Она не принуждает исходное изображение к переотбору или постоянному изменению соотношения сторон.

## **Настройка значений StretchOffset**

Когда режим заполнения изображения установлен в «stretch», значения stretch‑offset на [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) определяют прямоугольник заполнения относительно ограничивающего окна рамки. Положительные проценты создают отступ от края, отрицательные — выдачу наружу.

Это отличается от кадрирования. Значения кадрирования выбирают, какая часть исходного изображения видима; stretch‑offset изменяет прямоугольник, в который растягивается видимая заливка изображения.

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

Используйте stretch‑offset для размещения заполнения. Используйте свойства кадрирования, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Основные компромиссы проще управляются, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются самым надёжным вариантом для совместного использования и серверного рендеринга, но большие растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или расположениям.
- **Кадрирование** изначально не разрушительно. Скрытые пиксели остаются встроенными, пока области кадрирования явно не удаляются или не удаляются во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но оно жертвует исходным разрешением. Применять его следует после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важно сохранять векторность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрендеренный слайд в пиксели.
- **Повторяющиеся изображения** следует по возможности переиспользовать существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/), а не многократно загружать один и тот же файл в процесс презентации.

Для больших презентаций оптимизация изображений обычно наиболее эффективна при избирательном применении: храните логотипы и схемы как векторный контент, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) — это форма на слайде, отображающая изображение и хранящая геометрию и форматирование уровня рамки, такие как размер, вращение, значения кадрирования, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть портативной, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут быть надёжно поддержаны.

**Уменьшает ли кадрирование размер файла PPTX?**

Не самостоятельно. Обычные настройки кадрирования скрывают части исходного изображения, но сохраняют пиксели. Используйте [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Сохраняйте оригинальное исходное изображение вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует работать с SVG‑изображениями?**

Сохраняйте SVG‑содержимое как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растр, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных привидений типов при чтении существующих слайдов?**

Проверяйте тип формы перед использованием членов, специфичных для рамки изображения. Проверка `java_instanceof` против [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) предотвращает недопустимые приведения типов и позволяет коду обрабатывать слайды, не содержащие рамок изображения.