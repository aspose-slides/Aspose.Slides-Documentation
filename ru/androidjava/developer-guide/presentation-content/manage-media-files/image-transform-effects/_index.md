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
- градация
- дуотон
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа‑эффект
- цепочка эффектов
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте, комбинируйте, просматривайте, удаляйте и проверяйте эффекты преобразования изображений для рамок рисунков с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides представляет корректировки изображения как упорядоченную коллекцию операций преобразования изображения. Для рамы изображения начните с рамы [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Возвращаемая [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без переписывания исходных байтов изображения.

Эта статья демонстрирует полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки PPTX‑кругового обхода.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) принадлежит заливке изображения и ссылается на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) — это форма слайда, которая владеет соответствующей заливкой изображения, геометрией, настройками обрезки и другими параметрами уровня кадра.

Поэтому операции преобразования изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) более одного раза, каждая новая рама получает свой собственный `ISlidesPicture` и свою собственную коллекцию преобразований. Применение градации к одной раме не делает остальные рамы градационными, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture.getImageTransform` также используется другими заливками изображений, например, фигурой или фоном слайда. Примеры ниже сосредоточены на рамах изображения.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` до `100`, процент; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Значения каналов RGB и альфа, используемые `android.graphics.Color`, находятся в диапазоне от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` от `0` включительно до `360` исключая, в градусах; `amount` от `-100` до `100`, процент. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` от `0` включительно до `360` исключая, в градусах; насыщенность и яркость от `-100` до `100`, процент. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующие альфа‑значения остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | `radius` неотрицателен и измеряется в пунктах; `grow` — булево значение, которое определяет, может ли размытый контент выходить за пределы оригинального изображения. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Неотрицательный процент. Используйте `0`‑`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачный, `100` — сохраняет существующее значение альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑`100`, процент непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑`100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированного модулирования альфа прозрачность и непрозрачность являются дополнительными. Например, 35 % прозрачности соответствует модуляции альфа‑значения 65 %.

## **Применение яркости и контрастности**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Её скалярные настройки задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

Ниже представленный пример увеличивает яркость на 15 % и контрастность на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) — расширение Office 2010 для эффектов изображения и менее переносимо, чем стандартный эффект яркости DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после кругового обхода PPTX, используйте [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) и проверьте результат после повторного открытия файла. Раздел о ограничениях формата объясняет это различие более детально.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к различным рамам изображения, которые используют один ресурс изображения. Следующий пример создаёт пять рам и применяет градацию, дуотон, оттенок, настройку HSL и замену цвета.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) содержит два независимо редактируемых параметра цвета: `color1` сопоставляет тёмные пиксели, а `color2` — светлые пиксели. Это делает его полезным примером эффекта, настройки которого сложнее, чем одно скалярное значение.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) заменяет каждый пиксель фиксированным цветом, сохраняя альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), который отображает один исходный цвет в другой и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых отметок на отсканированной странице от фона. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) сохраняет промежуточные оттенки серого. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) преобразует яркость в чёрный или белый, в то время как [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) применяет порог к непрозрачности.

Порог яркости диапазон от 0 % до 100 %, включительно. Пиксели ниже порога становятся чёрными. Пиксели на пороге или выше него становятся белыми. Увеличение порога делает больше оттенков чёрными, поскольку больше их попадает ниже границы.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая метка показывает исходный уровень серого в диапазоне от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три рамы. Образец с меткой 96 имеет около 38 % яркости (96 из 255). Он переходит в белый при пороге 20 % и в чёрный при пороге 60 %.

![Исходные градации серого рядом с черно‑белыми результатами при порогах яркости 20% и 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) воздействует на все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размытие может выйти за пределы оригинальных границ изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) вместо этого задаёт одно значение альфа для всех пикселей. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) преобразует альфа в два уровня на основе порога.

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

К другим операциям без параметров относятся [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) — делает каждый ненулевой альфа полностью непрозрачным; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) — делает каждый альфа ниже 100 % полностью прозрачным; и [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) — меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в разном порядке могут дать различное изображение.

Например, градация, за которой следует оттенок, сначала удаляет хроматическую информацию, а затем перекрашивает результат яркости. Оттенок, за которым следует градация, снова удаляет оттенок. Аналогично, замена альфа может переопределить значения альфа, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Ниже показан пример создания цепочки из четырёх операций, сохранения её как PPTX, повторного открытия презентации, проверки как типов операций, так и их порядка, и отрисовки результата после повторного открытия:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие‑операции отдельными цепочками. Их можно комбинировать, но не всегда это полезно. Фиксированная замена цвета удаляет RGB‑вариацию, созданную более ранними цветовыми эффектами; градация после дуотона удаляет два выбранных цвета; а операции альфа‑потолок, пол, замена или би‑уровень могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не рассматривайте её элементы как неупорядоченные флаги форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — объект, хранящийся в `ISlidesPicture.getImageTransform`. В зависимости от эффекта она может непосредственно раскрывать записываемые члены. Например, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) раскрывает записываемые значения `radius` и `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) — записываемый `amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) — записываемый `threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), и [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в необходимой позиции.

Эффективные данные, возвращаемые `getEffective()`, вычисляются и являются только для чтения. Они полезны для разрешения цветов, зависящих от темы, и чтения нормализованных значений, используемых рендерером, но не представляют собой дополнительную поверхность редактирования. Ниже пример перечисления цепочки и проверки эффективных значений, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация, альфа‑потолок и альфа‑обратный, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите цель, а затем удалите её после перечисления. Используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) для полной очистки цепочки.

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

Удаление или очистка преобразований изменяет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).

## **Учет форматов презентаций и целей экспорта**

Преобразования изображения происходят в DrawingML, поэтому PPTX — предпочтительный редактируемый формат для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, градация, дуотон, оттенок, HSL, размытие и распространённые альфа‑операции, имеют наибольшие шансы выжить при круговом обходе PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, когда сохранность важна.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартная операция яркости DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Предпочтительнее [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) для постоянных настроек яркости и контрастности.
- Двоичный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT как формат проверки сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к полученному изображению. Эти выводы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы «запекают» результат в пиксели, а экспорт в документы/векторные форматы хранит собственное представление рендеринга.
- Эффекты не делают связанную картинку самодостаточной. Рендеринг связанного изображения всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать пограничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантующих операций. Для критических результатов тестируйте как редактируемый круговой обход, так и финальный экспортный формат с той же версией Aspose.Slides, которая используется в продакшене.

## **Вопросы и ответы**

**Изменяют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции относятся к `ISlidesPicture`, используемому заливкой изображения. Байты базового `IPPImage` остаются без изменений.

**Будут ли две рамы изображения, использующие один и тот же ресурс, делить свои эффекты?**

Нет. Повторное использование `IPPImage` избавляет от дублирования данных изображения, но каждая рама обычно имеет отдельный `ISlidesPicture` и отдельную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, потому что операции замены и пороговые операции могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции преобразований, где доступны записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, повторно открыв его. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортов сохраняют лишь внешний вид, а не редактируемые операции преобразования.