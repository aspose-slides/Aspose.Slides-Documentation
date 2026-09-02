---
title: Управление эффектами преобразования изображения в презентациях с JavaScript
linktitle: Эффекты преобразования изображения
type: docs
weight: 11
url: /ru/nodejs-java/image-transform-effects/
keywords:
- преобразование изображения
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
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Применяйте, объединяйте, проверяйте, удаляйте и проверяйте эффекты преобразования изображения для рамок изображений с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides представляет коррекцию изображений как упорядоченную коллекцию операций преобразования изображения. Для рамки изображения начните с [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) рамки и получите доступ к [Picture.getImageTransform](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) позволяет добавить, перечислять, проверять, удалять и очищать эффекты без перезаписи оригинальных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверка обратного раунда PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) — это форма слайда, владеющая соответствующей заливкой изображения, геометрией, настройками обрезки и другими параметрами уровня кадра.

Поэтому операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/). Когда один и тот же [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) передаётся в [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/) более одного раза, каждый новый кадр получает свой собственный [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) и собственную коллекцию преобразований. Применение градации серого к одному кадру не делает остальные кадры серыми, даже если они используют один и тот же встроенный ресурс изображения.

Та же модель [Picture.getImageTransform](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) используется и другими заливками изображений, например, фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах изображения.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждый выходящий за пределы параметр сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | от `-100` до `100`, процентов; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Оттенок от `0` (включительно) до `360` (исключительно) градусов; количество от `-100` до `100` процентов. |
| [addHSLEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Оттенок от `0` (включительно) до `360` (исключительно) градусов; насыщенность и яркость от `-100` до `100` процентов. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующие значения альфа остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — булево значение, определяющее, может ли размытый контент выходить за пределы оригинальных границ. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Неотрицательный процент. Используйте `0`‑`100` для обычного масштабирования непрозрачности: `0` полностью прозрачно, `100` сохраняет существующую альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | От `0` до `100` процентов непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | От `0` до `100` процентов порога альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачность соответствует фиксированной модуляции альфа 65 %.

## **Применение яркости и контрастности**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) возвращает операцию [BrightnessContrast](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/). Ее скалярные настройки задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/) возвращает вычисленные только для чтения значения, которые можно проверить или записать в журнал.

Следующий пример увеличивает яркость на 15 % и контрастность на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/) — расширение эффекта изображения Office 2010 и менее переносимо, чем стандартный эффект яркости DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после обратного раунда PPTX, используйте [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным кадрам, использующим один ресурс изображения. Следующий пример создаёт пять кадров и применяет градацию серого, дутон, оттенок, настройку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/duotone/) содержит два независимо редактируемых цветовых параметра: `color1` сопоставляет тёмные пиксели, а `color2` — светлые. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) заменяет каждый пиксель фиксированным цветом, сохраняя альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/), который сопоставляет один исходный цвет с другим и раскрывает форматы обоих цветов.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) влияет на все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размытие может выходить за пределы оригинальных границ изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют относительные различия. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) вместо этого назначает одно значение альфа всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) преобразует альфа в два уровня на основе порога.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

К другим альфа‑операциям без параметров относятся [addAlphaCeilingEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/), который делает каждую ненулевую альфа полностью непрозрачной; [addAlphaFloorEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/), который делает каждую альфа ниже 100 % полностью прозрачной; и [addAlphaInverseEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и т.д. Следовательно, одинаковые операции в разном порядке могут дать различное изображение.

Например, градация серого, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают полученную яркость. Оттенок, а затем градация серого убирает оттенок обратно. Аналогично, замена альфа может переопределить значения, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример строит цепочку из четырёх операций, сохраняет её как PPTX, повторно открывает презентацию, проверяет типы и порядок операций и отображает результат после повторного открытия:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но такие комбинации не всегда полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную более ранними цветовыми эффектами; градация серого после дутон удаляет два выбранных цвета; а операции альфа‑потолок, пол, замена или би‑уровень могут отбросить детали альфа, созданные ранее. Формируйте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не как набор несортированных флагов форматирования.

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в [Picture.getImageTransform](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/). В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/blur/) раскрывает записываемые `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/alphamodulatefixed/) раскрывает записываемый `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/alphabilevel/) раскрывает записываемый `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorformat/).

Некоторые операции, включая [BrightnessContrast](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tint/) и [AlphaReplace](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в требуемой позиции.

Эффективные данные, возвращаемые `getEffective()`, вычисляются и доступны только для чтения. Они полезны для разрешения цветов, зависящих от темы, и чтения нормализованных значений, которые использует рендерер, но не являются отдельной поверхностью редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения, где соответствующий API их предоставляет:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑инверсия, всё равно имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции являются важной информацией.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужную операцию, а затем удалите её после перечисления. Для удаления всей цепочки используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Удаление или очистка преобразований меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет используемый повторно [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) ресурс.

## **Учёт форматов презентаций и целевых экспортов**

Преобразования изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не все операции имеют одинаковую переносимость:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и общие альфа‑операции, имеют наибольший шанс сохраниться после обратного раунда PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, когда требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартная операция luminance DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемой операцией [BrightnessContrast](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/brightnesscontrast/). Предпочитайте [addLuminanceEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/) для постоянных коррекций яркости и контрастности.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно представить её. Не используйте PPT как формат проверки сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к отображаемому виду. Эти выводы не содержат редактируемого [ImageTransformOperationCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagetransformoperationcollection/); растровые форматы фиксируют результат в пикселях, а экспорты документов/векторов хранят собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. Рендеринг связанной картинки всё равно зависит от доступности связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантующих операций. Для критически важного вывода тестируйте как редактируемый обратный раунд, так и окончательный экспортный формат тем же набором Aspose.Slides, который используется в продакшене.

## **FAQ**

**Изменяют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/), используемому в заливке изображения. Байты базового [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) остаются неизменными.

**Будут ли два кадра, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный [Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) и собственную коллекцию преобразований.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция изменяет результат предыдущей, потому что операции замены и пороговые операции могут отбрасывать ранние цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют собой вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции трансформаций, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки трансформаций?**

Используйте PPTX и проверьте файл, открыв его повторно. Legacy PPT не может полностью представить модель эффектов DrawingML, а форматы экспортов сохраняют только внешний вид, а не редактируемые операции трансформации.