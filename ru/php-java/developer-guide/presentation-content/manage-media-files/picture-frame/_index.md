---
title: Управление рамками изображений в презентациях с использованием PHP
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
- SVG‑изображение
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

Рамка изображения — это элемент слайда, который отображает изображение. В Aspose.Slides ресурс изображения и элемент, который его отображает, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), тогда как [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) управляет положением изображения, размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании рамок.

Рамки могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно быть сохранено, прежде чем применять форматирование или оптимизацию.

## **Добавить и отформатировать встроенное изображение**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку с помощью [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт рамку с оригинальными размерами изображения и применяет форматирование линии и вращение:

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

Рамка управляет отображаемой геометрией; изменение размера рамки не изменяет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использовать относительный масштаб**

[PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) предоставляет относительные масштабирование ширины и высоты рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescalewidth/) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительный масштаб полезен, когда рабочий процесс требует сохранять связь с исходным размером изображения вместо ручного расчёта конечных размеров.

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

Относительный масштаб изменяет параметры масштаба рамки; он не пере‑семплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым безопасным выбором для переносимости и предсказуемого рендеринга. Связанное изображение сохраняет внешний путь через метод [Picture::setLinkPathLong](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/setlinkpathlong/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс будет недоступен, связанное изображение может не отображаться ожидаемым образом. Для презентаций, которые необходимо отправлять по почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавить связанное изображение**

Следующий пример создаёт рамку и указывает её на локальный файл изображения. Он охватывает только связывание изображений; связывание видео — отдельный медиа‑рабочий процесс, который намеренно не смешан в данном примере.

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

Используйте ссылки, когда управление внешними файлами намеренно. Не используйте их просто как замену сжатию: небольшая PPTX с повреждёнными зависимостями изображений обычно менее полезна, чем большая автономная презентация.

## **Извлечь изображения из рамок**

Перед извлечением изображения из существующей презентации проверьте, что элемент действительно является [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) и что он содержит встроенное изображение. Связанные рамки могут не содержать байты изображения, которые можно извлечь тем же способом.

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

Сохранение через [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save) конвертирует извлечённое изображение в запрошенный формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не конвертированный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечь SVG‑изображение**

Для SVG‑рисунка [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/). Это позволяет получить SVG‑данные напрямую, без растеризации изображения.

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

Сохранение SVG‑контента как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно рендерит векторный контент в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтовая копия оригинального встроенного SVG; используйте встроенные данные [SvgImage::getSvgData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/getsvgdata/), когда требуется сам векторный ресурс.

## **Обрезать изображение**

Обрезка изменяет видимую часть изображения внутри рамки. Значения обрезки в [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) задаются в процентах от исходных размеров изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она только меняет видимую область.

Следующий пример безопасно находит рамку и применяет значения обрезки:

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные участки можно физически удалить, как описано в следующем разделе.

## **Удалить данные обрезанных изображений**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «отклонения» обрезки.

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF с помощью этого метода растеризует результат в PNG.

## **Сжать растровые изображения**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалять обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено в размере или обрезано, и `false`, когда изменений не потребовалось.

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

При необходимости можно передать пользовательское положительное значение DPI вместо предопределённого.

Сжатие предназначено для растровых изображений. SVG и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, основываясь на максимально большом размере, при котором изображение будет фактически просматриваться или экспортироваться, а не применяя самое низкое DPI глобально.

## **Управление эффектами преобразования изображений**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые преобразования, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и проверку обратного пути, см. [Image Transform Effects](/php-java/image-transform-effects/).

## **Блокировать геометрию рамки**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для рамки. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) сохраняет пропорции формы при её изменении размеров.

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

Блокировка применяется к форме рамки. Она не принуждает исходное изображение к пере‑семплированию или постоянному изменению пропорций.

## **Настроить значения StretchOffset**

Когда режим заполнения изображения — растягивание, значения stretch‑offset в [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса рамки. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Параметры обрезки выбирают, какая часть исходного изображения будет видна; stretch‑offset изменяет прямоугольник, в который растягивается видимое заполнение изображения.

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

Используйте stretch‑offset для позиционирования заполнения. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Основные компромиссы проще управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по указанным путям или местоположениям.
- **Обрезка** изначально нелокальная. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удалены или не удалены во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для переэтонированных растровых изображений, но теряется исходное разрешение. Его следует применять после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Экспорт слайдов в растровый формат всегда преобразует отрисовываемый слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [PPImage], когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для крупных презентаций оптимизация изображений обычно наиболее эффективна при выборочном применении: храните логотипы и схемы как векторный контент, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) — это элемент на слайде, который отображает изображение и хранит параметры геометрии и форматирования уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут надёжно поддерживаться.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Сохраняйте оригинальное исходное изображение вне презентации, если может потребоваться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип элемента перед использованием членов, специфичных для рамки изображения. Проверка `java_instanceof` против [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) избегает неверных приведения и позволяет коду обрабатывать слайды, не содержащие рамок изображения.