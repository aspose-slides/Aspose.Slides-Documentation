---
title: Управление фонами презентаций в Java
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/java/presentation-background/
keywords:
- фон презентации
- фон слайда
- сплошной цвет
- градиентный цвет
- фон изображения
- прозрачность фона
- свойства фона
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Java, с советами по коду, чтобы улучшить ваши презентации."
---
## **Введение**

Сплошные цвета, градиенты и изображения обычно используются в качестве фонa слайдов. Вы можете установить фон для **обычного слайда** (один слайд) или **главного слайда** (применяется к нескольким слайдам одновременно).

![PowerPoint background](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/#getSolidFillColor--) у [FillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как установить синий сплошной цвет в качестве фона обычного слайда:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Установите цвет фона слайда в синий.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Сохраните презентацию на диск.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд служит шаблоном, который управляет форматированием всех слайдов, поэтому при выборе сплошного цвета для фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Установите у главного слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/backgroundtype/) (через `getMasters`) в `OwnBackground`.
3. Установите у фона главного слайда свойство [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/#getSolidFillColor--) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как установить сплошной цвет (зелёный) в качестве фона главного слайда:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Установите цвет фона главного слайда в зеленый.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Сохраните презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить градиентный фон для слайда**

Градиент — графический эффект, создаваемый постепённым изменением цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в `Gradient`.
4. Вызовите метод [getGradientFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/#getGradientFormat--) у [FillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/) для настройки требуемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как установить градиентный цвет в качестве фона слайда:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Примените градиентный эффект к фону.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Добавьте градиентные цвета. Без градиентных остановок фон возвращается к стандартному градиенту от чёрного к белому.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Сохраните презентацию на диск.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/backgroundtype/) в `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [getPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/#getPictureFillFormat--) у [FillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как установить изображение в качестве фона слайда:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Установите свойства фонового изображения.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Загрузите изображение.
    IImage image = Images.fromFile("Tulips.jpg");
    // Добавьте изображение в коллекцию изображений презентации.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Сохраните презентацию на диск.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Следующий образец кода демонстрирует, как задать тип заливки фона как «повторяющееся изображение» и изменить свойства повторения:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Установите изображение, используемое для заполнения фона.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Установите режим заполнения изображения в режим Плитка и настройте свойства плитки.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Подробнее: [**Тайловая картинка как текстура**](/slides/ru/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы подчеркнуть содержимое. Следующий код на Java показывает, как изменить прозрачность фонового изображения слайда:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Например.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получить коллекцию операций трансформации изображения.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Найти существующий эффект прозрачности с фиксированным процентом.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Установить новое значение прозрачности.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить значение фонового параметра слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и [EffectFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

С помощью метода `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseslide/) вы можете получить эффективный фон слайда.

Следующий пример на Java показывает, как получить эффективное значение фона слайда:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получите эффективный фон, учитывая мастер‑слайд, макет и тему.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?

Да. Удалите пользовательскую заливку слайда, и фон будет вновь унаследован от соответствующего [layout](/slides/ru/java/slide-layout/)/[master](/slides/ru/java/slide-master/) слайда (то есть [theme background](/slides/ru/java/presentation-theme/)).

### Что произойдёт с фоном, если я позже изменю тему презентации?

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/java/slide-layout/)/[master](/slides/ru/java/slide-master/), он будет обновлён в соответствии с [new theme](/slides/ru/java/presentation-theme/).