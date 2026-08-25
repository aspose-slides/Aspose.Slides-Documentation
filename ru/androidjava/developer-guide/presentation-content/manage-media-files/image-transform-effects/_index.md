---
title: Управление эффектами преобразования изображений в презентациях на Android
linktitle: Эффекты преобразования изображений
type: docs
weight: 11
url: /ru/androidjava/image-transform-effects/
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
- Android
- Java
- Aspose.Slides
description: "Применяйте, комбинируйте, проверяйте, удаляйте и верифицируйте эффекты преобразования изображений для рамок картинок с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Aspose.Slides представляет корректировки изображений как упорядоченную коллекцию операций преобразования изображений. Для рамки изображения начните с [ISlidesPicture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Возвращаемый [IImageTransformOperationCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без переписывания исходных байтов изображения.

В этой статье показан полный workflow для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки round‑trip PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и картинка, её отображающая, – это разные объекты:

- [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/) относится к заполнению изображения и ссылается на ресурс изображения, одновременно храня коллекцию преобразования изображения.
- [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) – это форма слайда, владеющая соответствующим заполнением изображения, геометрией, настройками обрезки и другими параметрами уровня рамки.

Следовательно, операции преобразования изображения не модифицируют байты в [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) более одного раза, каждый новый кадр получает собственный `ISlidesPicture` и собственную коллекцию преобразований. Применение градации серого к одной рамке не делает остальные рамки серыми, даже если они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture.getImageTransform` используется и другими заполнениями изображений, например, фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | от `-100` до `100`, процентов; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Значения RGB и альфа‑канала, используемые `android.graphics.Color`, находятся в диапазоне от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` — от `0` (включительно) до `360` (исключительно) градусов; `amount` — от `-100` до `100` процентов. |
| [addHSLEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` — от `0` (включительно) до `360` (исключительно) градусов; `saturation` и `luminance` — от `-100` до `100` процентов. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующие альфа‑значения остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | `radius` – неотрицательное, измеряется в пунктах; `grow` – Boolean, определяющий, может ли размытый контент выходить за пределы оригинального изображения. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Неотрицательный процент. Используйте `0`‑`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` — сохраняет исходную альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | от `0` до `100`, процентов непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | от `0` до `100`, процентов альфа‑порога. Значения ниже порога становятся прозрачными; значения, равные или превышающие порог, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа = 65 %.

## **Применение яркости и контрастности**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibrightnesscontrast/). Ее скалярные параметры задаются при создании операции. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) возвращает вычисленные только для чтения значения, которые можно проверить или записать в лог.

В следующем примере яркость увеличивается на 15 %, а контрастность — на 20 %, после чего отображается предварительный просмотр без изменения встроенного изображения:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/brightnesscontrast/) — расширение эффекта изображения Office 2010 и менее переносимо, чем стандартный эффект luminance DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после round‑trip PPTX, используйте [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) и проверьте результат после повторного открытия файла. Раздел ограничений форматов объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты можно применять независимо к разным кадрам, использующим один ресурс изображения. В следующем примере создаются пять кадров и применяются градация серого, дуо‑тон, оттенок, настройка HSL и замена цвета.

[IDuotone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iduotone/) содержит два независимо редактируемых параметра цвета: `color1` сопоставляется тёмным пикселям, `color2` — светлым. Это делает его хорошим примером эффекта, настройки которого сложнее, чем один скаляр.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) заменяет цвет каждого пикселя фиксированным цветом, сохраняя альфа‑канал. Он отличается от [addColorChangeEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), который сопоставляет один исходный цвет другому и раскрывает форматы как исходного, так и целевого цвета.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) воздействует на все цветовые каналы, включая альфа. Установите `grow` в `true`, если размытый край может выходить за пределы оригинального изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Он умножает каждое существующее альфа‑значение, поэтому частично прозрачные пиксели остаются пропорционально различными. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) вместо этого присваивает одно альфа‑значение всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) переводит альфа‑значения в два уровня по заданному порогу.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Другие альфа‑операции без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), который делает каждую ненулевую альфу полностью непрозрачной; [addAlphaFloorEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), который делает каждую альфу ниже 100 % полностью прозрачной; и [addAlphaInverseEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), который меняет альфу на `100% - alpha`.

## **Построение упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и т.д. Поэтому одинаковые операции в разном порядке могут давать разный результат.

Например, градация серого, а затем оттенок сначала удаляют цветовую информацию, а потом перекрашивают полученную яркость. Оттенок, а затем градация серого снова убирает оттенок. Аналогично, замена альфа может переопределить значения, вычисленные более ранними операциями, а альфа‑модуляция сохраняет их относительные различия.

В следующем примере создаётся цепочка из четырёх операций, сохраняется как PPTX, презентация повторно открывается, проверяются типы операций и их порядок, после чего отображается результат повторного открытия:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытия отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариации RGB, созданные предыдущими цветовыми эффектами; градация серого после дуо‑тона удаляет два выбранных цвета; операции альфа‑ceiling, floor, replacement или bi‑level могут отбросить альфа‑детали, созданные ранее. Строьте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не как набор несортированных флагов форматирования.

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `ISlidesPicture.getImageTransform`. В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [IBlur](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iblur/) раскрывает записываемые `radius` и `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ialphamodulatefixed/) — `amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ialphabilevel/) — `threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itint/) и [IAlphaReplace](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ialphareplace/), не раскрывают свои параметры создания как записываемые свойства. Чтобы изменить их, удалите операцию и добавьте замену на требуемой позиции.

Эффективные данные, возвращаемые `getEffective()`, вычислены и доступны только для чтения. Они полезны для разрешения цветов, зависящих от темы, и чтения нормализованных значений, которые использует рендерер, но не являются отдельной поверхностью редактирования. В следующем примере перечисляется цепочка и проверяются эффективные значения там, где соответствующий API их предоставляет:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Эффекты без параметров, такие как градация серого, альфа‑ceiling и альфа‑inverse, всё равно имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) для удаления одной операции по индексу. Поскольку индексы сдвигаются после удаления, сначала найдите цель, а затем удалите её после перечисления. Для удаления всей цепочки примените [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Удаление или очистка преобразований меняет только форматирование картинки. Это не удаляет, не пересжимает и не изменяет повторно используемый ресурс [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).

## **Учёт форматов презентаций и целевых экспортов**

Преобразования изображений происходят в DrawingML, поэтому PPTX — предпочтительный редактируемый формат для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и общие альфа‑операции, имеют наибольшие шансы выжить round‑trip PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, если требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартный эффект luminance DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibrightnesscontrast/). Предпочтительно использовать [addLuminanceEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) для постоянных настроек яркости и контрастности.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. При сохранении в PPT могут быть опущены неподдерживаемые операции, цепочка может быть сокращена до поддерживаемого подмножества или приблизительно воспроизведена. Не используйте PPT для проверки сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML и другие визуальные форматы применяет поддерживаемую цепочку к визуальному представлению. Эти выводы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы фиксируют результат в пикселях, а экспорт в документы/векторные форматы хранит собственное представление рендеринга.
- Эффекты не делают связанное изображение самодостаточным. Рендеринг связанной картинки всё равно зависит от доступности связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному отображать граничные случаи, особенно при комбинировании нескольких альфа‑ или цветоквантизационных операций. Для критических выводов тестируйте как редактируемый round‑trip, так и финальный экспортный формат тем же Aspose.Slides, который используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции относятся к `ISlidesPicture`, используемому в заполнении изображения. Байт‑данные базового `IPPImage` остаются неизменными.

**Будут ли два кадра, использующие одно и то же изображение, разделять свои эффекты?**

Нет. Повторное использование `IPPImage` исключает дублирование данных изображения, но каждый кадр обычно имеет отдельный `ISlidesPicture` и отдельную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, поскольку операции замены и порога могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Изменяйте операцию, хранящуюся в коллекции, где доступны записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, повторно открыв его. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортов сохраняют только внешний вид, а не редактируемые операции преобразования.