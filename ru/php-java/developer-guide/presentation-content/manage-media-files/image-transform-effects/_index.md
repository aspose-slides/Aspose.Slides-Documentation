---
title: Управление эффектами трансформации изображений в презентациях с PHP
linktitle: Эффекты трансформации изображений
type: docs
weight: 11
url: /ru/php-java/image-transform-effects/
keywords:
- трансформация изображения
- эффект изображения
- яркость
- контраст
- градация серого
- дутон
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа‑эффект
- цепочка эффектов
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Применяйте, связывайте, просматривайте, удаляйте и проверяйте эффекты трансформации изображений для кадров с Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides представляет коррекцию изображений как упорядоченную коллекцию операций трансформации изображений. Для рамки изображения начните с [Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/) и получите доступ к [Picture::getImageTransform](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/getimagetransform/). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без переписывания оригинальных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контрастности, цветовых трансформаций, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного раунда PPTX.

## **Понимание владения эффектом и повторного использования изображений**

Исходный ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию трансформаций изображения.
- [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) — это элемент слайда, который владеет соответствующей заливкой изображения, геометрией, настройками обрезки и другими параметрами уровня кадра.

Следовательно, операции трансформации изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/). Когда один и тот же `PPImage` передается в [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/) более одного раза, каждый новый кадр изображения получает собственный `Picture` и собственную коллекцию трансформаций. Применение градации серого к одному кадру не делает остальные кадры серыми, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture::getImageTransform` используется и другими заливками изображений, например фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы измерения. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недействительные данные при сохранении или при открытии файла в PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` через `100`, процент; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Оттенок – от `0` (включительно) до `360` (исключительно) градусов; количество – от `-100` до `100` процентов. |
| [addHSLEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Оттенок — от `0` включительно до `360` исключительно, в градусах; насыщенность и светлота — от `-100` до `100` процентов. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Заменяющий цвет использует значения каналов от `0` до `255`. Существующие значения альфа остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — логическое значение, определяющее, может ли размытое содержимое выходить за оригинальные границы. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательный процент. Используйте от `0` до `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` сохраняет существующее значение альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` до `100` процентов непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` до `100` процентов порога альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, — непрозрачными. |

Для фиксированного модулирования альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа 65 %.

## **Применение яркости и контрастности**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) возвращает операцию [Luminance](https://reference.aspose.com/slides/ru/php-java/aspose.slides/luminance/). Ее скалярные настройки задаются при создании операции. [Luminance::getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/luminance/geteffective/) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

Следующий пример увеличивает яркость на 15 % и контрастность на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` — это стандартный эффект яркости и контрастности DrawingML. Когда эти настройки должны оставаться редактируемыми после обратного раунда PPTX, откройте сохранённую презентацию заново и проверьте как тип операции, так и её эффективные значения.

## **Применение цветовых трансформаций**

Цветовые эффекты могут применяться независимо к разным кадрам изображений, которые используют один ресурс изображения. Следующий пример создаёт пять кадров и применяет градацию серого, дутон, оттенок, настройку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/duotone/) содержит два независимо редактируемых параметра цвета: `color1` задаёт тёмные пиксели, а `color2` — светлые. Это делает его полезным примером эффекта, настройки которого сложнее одной скалярной величины.

```php
use aspose\slides\Images;
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

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) заменяет цвет каждого пикселя на один фиксированный цвет, при этом сохраняет альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), который отображает один исходный цвет в другой и раскрывает форматы как исходного, так и целевого цвета.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) влияет на все цветовые каналы, включая альфа. Установите `grow` в `true`, если размытый край может выходить за пределы оригинального кадра изображения.

Для однородной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели остаются пропорционально различными. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) вместо этого присваивает одно значение альфа всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) преобразует альфа в два уровня на основе порога.

```php
use aspose\slides\Images;
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

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

К другим альфа‑операциям без параметров относятся [addAlphaCeilingEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), который делает каждую ненулевую альфа полностью непрозрачной; [addAlphaFloorEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), который делает каждую альфа ниже 100 % полностью прозрачной; и [addAlphaInverseEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в разном порядке могут дать разный результат.

Например, градация серого, за которой следует оттенок, сначала удаляет хроматическую информацию, а затем перекрашивает полученную яркость. Оттенок, за которым следует градация серого, снова удаляет оттенок. Аналогично, замена альфа может переопределить значения альфа, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример строит цепочку из четырёх операций, сохраняет её как PPTX, открывает презентацию заново, проверяет типы операций и их порядок, и отображает результат повторного открытия:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размывающие операции отдельными цепочками. Их можно комбинировать, но не все комбинации полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную более ранними цветовыми эффектами; градация серого после дутон удаляет два выбранных цвета; а операции альфа‑потолка, пола, замены или двухуровневой обработки могут отбрасывать детали альфа, созданные ранее. Стройте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не рассматривайте её элементы как неупорядоченные флаги форматирования.

## **Просмотр редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `Picture::getImageTransform`. В зависимости от эффекта она может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/ru/php-java/aspose.slides/blur/) раскрывает записываемые значения `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/alphamodulatefixed/) раскрывает записываемый `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/alphabilevel/) раскрывает записываемый `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorformat/).

Некоторые операции, включая [Luminance](https://reference.aspose.com/slides/ru/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tint/) и [AlphaReplace](https://reference.aspose.com/slides/ru/php-java/aspose.slides/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте заменяющую в требуемой позиции.

Эффективные данные, возвращаемые `getEffective()`, вычисляются и являются только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, используемых рендерером, но не являются иной поверхностью редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
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
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑инверс, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции являются важной информацией.

## **Удаление или очистка трансформаций изображений**

Используйте [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перечисления. Используйте [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagetransformoperationcollection/clear/) для удаления всей цепочки.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
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
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Удаление или очистка трансформаций меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).

## **Учтите форматы презентаций и целевые форматы экспорта**

Трансформации изображений возникают в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, градация серого, дутон, оттенок, HSL, размытие и распространённые альфа‑операции, имеют наибольший шанс выжить после обратного раунда PPTX. Всегда открывайте сгенерированный файл заново и проверяйте коллекцию, если требуется сохранение.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT в качестве формата проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к отображаемому виду. Эти выходы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы уплощают результат в пиксели, а документные или векторные экспорты хранят собственное представление рендеринга.
- Эффекты не делают связанную картинку автономной. Рендеринг связанного изображения всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному отображать граничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантизационных операций. Для критически важного вывода тестируйте как редактируемый обратный раунд, так и конечный экспортный формат с той же версией Aspose.Slides, что используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты трансформации изображения встроенные данные изображения?**

Нет. Операции принадлежат `Picture`, используемому в заливке изображения. Байт‑данные базового `PPImage` остаются неизменными.

**Будут ли два кадра изображения, использующие один и тот же ресурс, совместно использовать свои эффекты?**

Нет. Повторное использование `PPImage` избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный `Picture` и отдельную коллекцию трансформаций изображения.

**Можно ли комбинировать цветовые, размывающие и альфа‑эффекты?**

Да. Коллекция допускает их в одной упорядоченной цепочке. Учтите, как каждая операция влияет на результат предыдущей, поскольку операции замены и пороговые операции могут отбрасывать ранее созданные детали цвета или альфа.

**Почему эффективные значения доступны только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции трансформаций, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки трансформаций?**

Используйте PPTX и проверяйте файл, открывая его заново. Устаревший PPT не может полностью представить модель эффектов DrawingML, а экспортируемые форматы сохраняют только внешний вид, а не редактируемые операции трансформации.