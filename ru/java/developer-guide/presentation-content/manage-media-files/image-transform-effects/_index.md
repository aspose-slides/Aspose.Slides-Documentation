---
title: Управление эффектами трансформации изображений в презентациях с Java
linktitle: Эффекты трансформации изображений
type: docs
weight: 11
url: /ru/java/image-transform-effects/
keywords:
- трансформация изображения
- эффект изображения
- яркость
- контраст
- оттенок серого
- дутон
- тон
- HSL
- замена цвета
- размытие
- прозрачность
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Применяйте, комбинируйте, просматривайте, удаляйте и проверяйте эффекты трансформации изображений для рамок изображений с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides представляет настройки изображений как упорядоченную коллекцию операций преобразования изображений. Для рамки изображения начните с её [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Возвращаемая [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без перезаписи оригинальных байтов изображения.

Эта статья демонстрирует полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного прохода PPTX.

## **Понимание владения эффектами и повторного использования изображений**

Ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию операций преобразования изображения.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) — это форма слайда, которая владеет соответствующей заливкой изображения, геометрией, параметрами обрезки и другими параметрами уровня рамки.

Поэтому операции преобразования изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) более одного раза, каждый новый кадр изображения получает собственный `ISlidesPicture` и собственную коллекцию преобразований. Применение шкалы серого к одной рамке не делает остальные рамки серыми, даже если все они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture.getImageTransform` также используется другими заливками изображений, такими как форма или фон слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы измерения. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отвергнуть недопустимые данные при сохранении или когда PowerPoint открывает файл.

| Операция | Параметры | Допустимый диапазон и единица |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | от `-100` до `100`, в процентах; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Оттенок (`hue`) включительно от `0` до `360` исключая `360`, в градусах; количество (`amount`) от `-100` до `100`, в процентах. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Оттенок (`hue`) включительно от `0` до `360` исключая `360`, в градусах; насыщенность и яркость от `-100` до `100`, в процентах. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующие значения альфа остаются без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — логическое значение, определяющее, может ли размытое содержимое выйти за пределы оригинальных границ. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Неотрицательный процент. Используйте диапазон от `0` до `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` — сохраняет исходную альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | От `0` до `100`, процент непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | От `0` до `100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует параметру модуляции альфа = 65 %.

## **Применение яркости и контрастности**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Ее скалярные параметры задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) возвращает рассчитанные только для чтения значения, которые можно просмотреть или записать в журнал.

Следующий пример увеличивает яркость на 15 % и контрастность на 20 %, а затем выводит превью, не изменяя встроенное изображение:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) — расширение эффектов изображений Office 2010 и менее переносим, чем стандартный эффект яркости DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после обратного прохода PPTX, используйте [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие более подробно.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным кадрам изображений, использующим один ресурс изображения. В следующем примере создаются пять кадров и применяются шкала серого, дутон, оттенок, настройка HSL и замена цвета.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) содержит два независимо редактируемых параметра цвета: `color1` сопоставляется тёмным пикселям, а `color2` — светлым. Это делает его полезным примером эффекта, настройки которого сложнее, чем один скаляр.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) заменяет цвет каждого пикселя на один фиксированный цвет, сохраняет альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), который сопоставляет один исходный цвет с другим и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых отметок на отсканированной странице от фона. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) сохраняет промежуточные оттенки серого. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) сопоставляет яркость чёрному или белому, тогда как [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 % включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Повышение порога делает больше оттенков чёрными, поскольку больше их попадает ниже порога.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая метка показывает исходный уровень серого по шкале от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Откройте получившуюся презентацию в PowerPoint, чтобы сравнить три кадра. Образец с меткой 96 имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Исходные шкалы серого рядом с черно-белыми результатами при порогах яркости 20% и 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) воздействует на все цветовые каналы, включая альфа. Установите `grow` в `true`, если размытый край может выйти за пределы оригинальных границ изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели остаются пропорционально различными. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) наоборот присваивает одно значение альфа всем пикселям. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) преобразует альфа в два уровня на основе порога.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Другие альфа‑операции без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) — делает каждый ненулевой альфа полностью непрозрачным; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) — делает каждый альфа ниже 100 % полностью прозрачным; и [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) — меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: выход операции 0 становится входом операции 1 и так далее. Следовательно, одинаковые операции в разных порядках могут давать разные изображения.

Например, шкала серого, а затем оттенок сначала удаляют цветовую информацию, а затем перекрашивают результат яркости. Оттенок, а затем шкала серого удаляют оттенок снова. Аналогично, замена альфа может переопределить значения альфа, рассчитанные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример создаёт цепочку из четырёх операций, сохраняет её как PPTX, открывает презентацию повторно, проверяет типы операций и их порядок, а затем выводит результат повторного открытия:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размывающие операции отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариации RGB, созданные более ранними цветовыми эффектами; шкала серого после дутон удаляет два выбранных цвета; а операции альфа‑потолок, пол, замена или двууровневые могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не рассматривайте её элементы как неупорядоченные флаги форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![То же изображение проходит через шкалу серого, затем оттенок, и оттенок, затем шкалу серого. Два конечных изображения в шкале серого имеют разные тона.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*В этом иллюстративном рендере Aspose.Slides для .NET 26.11 оттенок 220° при 25 % не меняет изображение в шкале серого. Применение того же оттенка до шкалы серого даёт другие тона.* 
<!-- visual-explanation:image-transform-effects:end -->

## **Просмотр редактируемых и эффективных значений**

Редактируемой операцией считается объект, хранящийся в `ISlidesPicture.getImageTransform`. В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) раскрывает записываемые свойства `radius` и `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) — свойство `amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) — свойство `threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) и [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), не раскрывают свои скалярные параметры создания как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену на нужной позиции.

Эффективные данные, возвращаемые `getEffective()`, рассчитаны и доступны только для чтения. Они полезны для разрешения зависимых от темы цветов и чтения нормализованных значений, которые использует рендерер, но не являются отдельной поверхностью редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как шкала серого, альфа‑потолок и альфа‑инверсия, всё равно имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка трансформов изображений**

Используйте [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите цель, а затем удалите её после перебора. Используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) для удаления всей цепочки.

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

Удаление или очистка трансформов меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).

## **Учтите форматы презентаций и целевые форматы экспорта**

Трансформы изображений происходят из DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже с PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, шкала серого, дутон, оттенок, HSL, размытие и общие альфа‑операции, имеют наибольшие шансы выжить при обратном проходе PPTX. Всегда открывайте сгенерированный файл повторно и проверяйте коллекцию, когда требуется сохранность.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартная операция яркости DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Предпочтительно использовать [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) для постоянных корректировок яркости и контрастности.
- Бинарный формат PPT предшествовал полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT как формат проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к отображаемому результату. Эти выходы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы фиксируют результат в пикселях, а экспорт в документы/векторы хранит собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. Рендеринг связанного изображения всё равно зависит от доступности связанного ресурса при загрузке презентации.

Различные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантизационных операций. Для критических результатов тестируйте как редактируемый обратный проход, так и финальный экспортный формат с той же версией Aspose.Slides, используемой в продакшене.

## **FAQ**

**Изменяют ли эффекты трансформации изображения встроенные данные изображения?**

Нет. Операции принадлежат `ISlidesPicture`, используемому заливкой изображения. Байты базового `IPPImage` остаются неизменными.

**Будут ли два кадра изображения, использующие один и тот же ресурс, делить свои эффекты?**

Нет. Повторное использование `IPPImage` избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный `ISlidesPicture` и отдельную коллекцию трансформов изображения.

**Можно ли комбинировать цветовые, размывающие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, что делает каждая операция со входом предыдущей, поскольку операции замены и пороговые операции могут отбрасывать предыдущие цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют рассчитанные значения, используемые для рендеринга, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции трансформов, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки трансформов?**

Используйте PPTX и проверяйте файл, открывая его повторно. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы экспортируемого рендеринга сохраняют только внешний вид, а не редактируемые операции трансформации.