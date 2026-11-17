---
title: Управление эффектами преобразования изображений в презентациях с PHP
linktitle: Эффекты преобразования изображений
type: docs
weight: 11
url: /ru/php-java/image-transform-effects/
keywords:
- преобразование изображения
- эффект изображения
- яркость
- контраст
- градация серого
- двухтонный
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Применяйте, связывайте, проверяйте, удаляйте и верифицируйте эффекты преобразования изображений для рамок изображений с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides представляет корректировки изображений как упорядоченную коллекцию операций преобразования изображения. Для рамки изображения начните с [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) и обратитесь к [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без переписывания оригинальных байтов изображения.

Эта статья демонстрирует полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, вычисленных значений, удаления и проверки обратного прохода PPTX.

## **Понимание владения эффектом и повторного использования изображений**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно хранит коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) — это форма слайда, которая владеет соответствующей заливкой изображения, геометрией, настройками обрезки и другими параметрами уровня рамки.

Поэтому операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Когда один и тот же `PPImage` передаётся в [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) более одного раза, каждая новая рамка изображения получает собственный `Picture` и собственную коллекцию преобразований. Применение градации серого к одной рамке не делает другие рамки градацией серого, несмотря на то что все они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture::getImageTransform` используется и другими заливками изображений, например заливкой формы или фоном слайда. Примеры ниже сосредоточены на рамках изображения.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы измерения. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` по `100`, процент; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Оттенок `0` включительно до `360` исключительно, в градусах; количество `-100` по `100`, процент. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Оттенок `0` включительно до `360` исключительно, в градусах; насыщенность и яркость `-100` по `100`, процент. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Заменяющий цвет использует значения каналов от `0` до `255`. Существующие альфа‑значения остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — логическое значение, определяющее, может ли размытие выйти за пределы оригинальных границ. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательный процент. Используйте `0` по `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачный, `100` — сохраняет исходную альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` по `100`, процент непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` по `100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа = 65 %.

## **Применение яркости и контраста**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) возвращает операцию [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Ее скалярные настройки задаются при создании операции. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) возвращает вычисленные только для чтения значения, которые можно проверять или записывать в журнал.

Следующий пример увеличивает яркость на 15 % и контраст на 20 %, затем отображает превью без изменения встроенного изображения:

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

`Luminance` — стандартный эффект яркости и контраста DrawingML. Когда эти настройки должны оставаться редактируемыми после обратного прохода PPTX, откройте сохранённую презентацию и проверьте как тип операции, так и её вычисленные значения.

## **Применение цветовых преобразований**

Цветовые эффекты можно применять независимо к разным рамкам, использующим один ресурс изображения. Следующий пример создаёт пять рамок и применяет градацию серого, дуотон, оттенок, HSL‑регулировку и замену цвета.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) содержит два независимо редактируемых параметра цвета: `color1` задаёт тёмные пиксели, `color2` — светлые. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) заменяет каждый пиксель фиксированным цветом, сохраняя альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), который сопоставляет один исходный цвет другому и раскрывает оба формата цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых отметок на сканированной странице от фона. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) сохраняет промежуточные оттенки серого. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) переводит яркость в чёрный или белый, а [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 % включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Увеличение порога переводит больше оттенков в чёрный, поскольку больше пикселей попадает ниже порога.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в каталог, содержащий скрипт PHP. Каждая подпись указывает исходный уровень серого по шкале от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентацию.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три рамки. Образец, помеченный 96, имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) воздействует на все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размытый край может выходить за пределы оригинальных границ изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) вместо этого назначает одно значение альфа всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) преобразует альфа в два уровня на основе порога.

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

Другие операции альфа без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), который делает каждый ненулевой альфа полностью непрозрачным; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), который меняет альфа на `100% - alpha`.

## **Построение упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в разном порядке могут дать различный результат.

Например, градация серого, а затем оттенок сначала удаляют цветовую информацию, а затем перекрашивают результат яркости. Оттенок, а затем градация серого удаляют оттенок обратно. Аналогично, замена альфа может переопределить альфа‑значения, рассчитанные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример строит цепочку из четырёх операций, сохраняет её как PPTX, открывает презентацию заново, проверяет типы операций и их порядок и рендерит открытый результат:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цвет, альфа и размытие отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дуотона убирает два выбранных цвета; а операции альфа‑потолок, пол, замена или двууровневое преобразование могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку в соответствии с требуемой последовательностью обработки пикселей, а не как набор несортированных флагов форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*В этом иллюстративном рендере Aspose.Slides for .NET 26.11 изображение проходит через градацию серого, затем оттенок, и наоборот; два итоговых изображения в градации серого имеют разные тона.*
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и вычисленных значений**

Редактируемая операция хранится в `Picture::getImageTransform`. В зависимости от эффекта она может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) раскрывает записываемые значения `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) — `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) — `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/).

Некоторые операции, включая [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), и [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), не раскрывают свои параметры создания как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в требуемой позиции.

Эффективные данные, возвращаемые `getEffective()`, вычисляются и доступны только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, используемых рендерером, но не представляют собой отдельный слой редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑инверсия, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите цель, а затем удалите её после перечисления. Используйте [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) для удаления всей цепочки.

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

Удаление или очистка трансформ меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

## **Учёт форматов презентаций и целей экспорта**

Преобразования изображения возникли в DrawingML, поэтому PPTX — предпочтительный редактируемый формат для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой портируемостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и общие альфа‑операции, имеют наибольшие шансы пережить обратный проход PPTX. Всегда открывайте сгенерированный файл и проверяйте коллекцию, если требуется сохранность.
- Двоичный формат PPT предшествовал полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT как формат проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другой визуальный вывод применяет поддерживаемую цепочку к отрисованному результату. Эти выводы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы «сплющивают» результат в пиксели, а экспорт документов или векторов хранит собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. Рендеринг связанного изображения всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда объединяются несколько альфа‑ или цветоквантизационных операций. Для критически важного вывода тестируйте как редактируемый обратный проход, так и конечный формат экспорта с той же версией Aspose.Slides, используемой в продакшн.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат `Picture`, используемому в заливке изображения. Байт‑данные базового `PPImage` остаются без изменений.

**Будут ли две рамки, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование `PPImage` избегает дублирования данных изображения, но каждая рамка обычно имеет отдельный `Picture` и отдельную коллекцию преобразований.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, так как операции замены и порога могут отсеять ранее созданные цветовые или альфа‑детали.

**Почему вычисленные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции, где доступны записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки трансформаций?**

Используйте PPTX и проверьте файл, открыв его повторно. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортированных изображений сохраняют только внешний вид, а не редактируемые операции трансформации.