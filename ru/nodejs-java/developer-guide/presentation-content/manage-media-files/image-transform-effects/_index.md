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
- дуотон
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
description: "Применяйте, объединяйте, проверяйте, удаляйте и верифицируйте эффекты преобразования изображения для кадров изображений с Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides представляет настройки изображения как упорядоченную коллекцию операций преобразования изображения. Для кадра изображения начните с [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) кадра и получите доступ к [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без перезаписи оригинальных байтов изображения.

В этой статье показан полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного пути PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) — это элемент слайда, который владеет соответствующей заливкой изображения, геометрией, настройками обрезки и другим форматированием уровня рамки.

Поэтому операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Когда один и тот же [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) передаётся в [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) более одного раза, каждый новый кадр получает собственный [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) и собственную коллекцию преобразований. Применение градации серого к одному кадру не делает остальные кадры градацией серого, даже если они используют один и тот же встроенный ресурс изображения.

Та же модель [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) используется и другими заливками изображений, например, формой или фоном слайда. Приведённые ниже примеры сосредоточены на кадрах изображения.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждый недопустимый параметр сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` … `100`, процент; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue — от `0` включительно до `360` исключительно, в градусах; amount — от `-100` до `100`, процент. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue — от `0` включительно до `360` исключительно, в градусах; saturation и luminance — от `-100` до `100`, процент. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующие альфа‑значения остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Радиус — неотрицательное значение, измеряется в пунктах; `grow` — логическое, определяющее, может ли размытие выйти за пределы оригинального изображения. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Неотрицательный процент. Используйте `0` … `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` — сохраняет исходную альфу. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` … `100`, процент непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` … `100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, прозрачность 35 % соответствует модулю альфа 65 %.

## **Применение яркости и контрастности**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) возвращает операцию [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Ее скалярные настройки задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

Ниже показан пример, увеличивающий яркость на 15 % и контрастность на 20 %, после чего отображается предварительный просмотр без изменения встроенного изображения:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) — это расширение картинок Office 2010 и менее переносимо, чем стандартный эффект luminance DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после обратного прохода PPTX, используйте [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты можно применять независимо к разным кадрам, использующим один ресурс изображения. Ниже пример, создающий пять кадров и применяющий градацию серого, дуотон, оттенок, настройку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) содержит два независимо редактируемых цветовых параметра: `color1` сопоставляется тёмным пикселям, а `color2` — светлым. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) заменяет каждый пиксель фиксированным цветом, сохраняя альфу. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), который сопоставляет один исходный цвет другому и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых меток на отсканированной странице от фона. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) сохраняет промежуточные оттенки серого. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) переводит яркость в чёрный или белый, в то время как [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 % включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Увеличение порога делает больше оттенков чёрными, потому что больше их попадает ниже порога отсечения.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая надпись указывает исходный уровень серого от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три кадра. Образец с меткой 96 имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Оригинальные образцы градации серого рядом с результатами чёрно‑белого преобразования при порогах яркости 20 % и 60 %](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) затрагивает все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размытие может выйти за пределы оригинальных границ изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Он умножает каждое существующее альфа‑значение, поэтому частично прозрачные пиксели сохраняют относительные различия. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) присваивает один альфа‑значение всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) переводит альфу в два уровня по порогу.

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

Другие операции альфа без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), который делает каждую ненулевую альфу полностью непрозрачной; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), который делает каждую альфу ниже 100 % полностью прозрачной; и [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), который меняет альфу на `100% - alpha`.

## **Построение упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в разном порядке могут дать различное изображение.

Например, градация серого, за которой следует оттенок, сначала удаляет хроматическую информацию, а затем перекрашивает полученную яркость. Оттенок, за которым следует градация серого, удаляет оттенок снова. Аналогично, замена альфа может переопределить альфа‑значения, вычисленные предыдущими операциями, тогда как модуляция альфа сохраняет их относительные различия.

Ниже пример, создающий цепочку из четырёх операций, сохраняющий её в PPTX, повторно открывающий презентацию, проверяющий типы и порядок операций и рендерящий результат после повторного открытия:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, хотя не всегда это имеет смысл. Фиксированная замена цвета удаляет вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дуотона удаляет два выбранных цвета; операции альфа‑ceiling, floor, replace или bi‑level могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку согласно требуемой последовательности обработки пикселей, а не как набор несвязанных флагов форматирования.


<!-- visual-explanation:image-transform-effects:start -->
[![Одно и то же изображение проходит через градацию серого, а затем оттенок, и оттенок, а затем градацию серого. Два конечных изображения в градации серого имеют разные тона.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*В этом иллюстративном рендере Aspose.Slides for .NET 26.11 220° оттенок при 25 % оставляет градацию серого без изменений. Применение того же оттенка до градации серого даёт другие тона.*
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и эффективных значений**

Редактируемой операцией считается объект, хранящийся в [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) раскрывает записываемые `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) — `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) — `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/).

Некоторые операции, включая [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/) и [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить такие настройки, удалите операцию и добавьте замену в нужном месте.

Эффективные данные, возвращаемые `getEffective()`, вычисляются и являются только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, которые использует рендерер, но это не отдельная поверхность редактирования. Ниже пример, перечисляющий цепочку и проверяющий эффективные значения, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация серого, альфа‑ceiling и альфа‑inverse, тоже имеют объект эффективных данных, но нет скалярных настроек для вывода. Их присутствие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите цель, а затем удалите её после перечисления. Для удаления всей цепочки используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/).

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

Удаление или очистка преобразований изменяют только форматирование изображения. Они не удаляют, не перекомпрессируют и не изменяют повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

## **Учёт форматов презентаций и целей экспорта**

Преобразования изображения происходят в DrawingML, поэтому PPTX — предпочтительный редактируемый формат для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и обычные альфа‑операции, имеют наибольшие шансы выжить при обратном проходе PPTX. Всегда открывайте сгенерированный файл и проверяйте коллекцию, если требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартная операция luminance DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемой операцией [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Предпочтительно использовать [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) для постоянных настроек яркости и контрастности.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемой части или приблизительно воспроизвести вид. Не используйте PPT для проверки сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML и другие визуальные форматы применяет поддерживаемую цепочку к визуальному представлению. Эти выводы не содержат редактируемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/); растровые форматы зап Flatten результат в пиксели, а экспорт документов/векторов хранит собственное представление рендеринга.
- Эффекты не делают связанное изображение самодостаточным. Рендеринг связанного изображения всё равно зависит от доступности связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному отображать граничные случаи, особенно когда объединяются несколько альфа‑ или цветоквантовых операций. Для критических выводов тестируйте как редактируемый обратный проход, так и финальный формат экспорта с той же версией Aspose.Slides, которая используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/), используемому в заливке изображения. Основные байты [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) остаются неизменными.

**Будут ли два кадра, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) и свою коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учтите, как каждая операция влияет на результат предыдущей, потому что операции замены и порога могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Изменяйте операцию, хранящуюся в коллекции преобразований, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверяйте файл, открывая его повторно. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортов сохраняют только внешний вид, а не редактируемые операции преобразования.