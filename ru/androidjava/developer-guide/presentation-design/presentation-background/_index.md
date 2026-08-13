---
title: Управление фонами презентаций на Android
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Android на Java, с советами по коду для улучшения ваших презентаций."
---
## **Введение**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (один слайд) или **главного слайда** (применяется к нескольким слайдам сразу).

![Фон PowerPoint](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фона слайда в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) у [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать синий сплошной цвет в качестве фона обычного слайда:

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

Aspose.Slides позволяет задать сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд выступает в роли шаблона, контролирующего форматирование всех слайдов, поэтому при выборе сплошного цвета для фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Установите [BackgroundType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/backgroundtype/) главного слайда (через `getMasters`) в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фона главного слайда в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) у [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать сплошной цвет (зеленый) в качестве фона главного слайда:

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

Градиент — это графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фона слайда в `Gradient`.
4. Вызовите метод [getGradientFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) у [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/), чтобы настроить нужные параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать градиентный цвет в качестве фона слайда:

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

    // Добавьте цвета градиента. Без градиентных остановок фон откатывается к стандартному градиенту от черного к белому.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Сохраните презентацию на диск.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайда.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фона слайда в `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [getPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) у [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/), чтобы назначить изображение фоном.
7. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать изображение в качестве фона слайда:

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

Следующий образец кода демонстрирует, как установить тип заливки фона в виде чересстрочного изображения и изменить свойства мозаики:

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

    // Установите изображение, используемое для заливки фона.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Установите режим заливки изображения в Tile и настройте свойства тайла.
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
Подробнее: [**Изображение как текстура мозаики**](/slides/ru/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на Java показывает, как изменить прозрачность фонового изображения слайда:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Например.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получите коллекцию операций трансформации изображения.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Найдите существующий эффект фиксированного процентного уровня прозрачности.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Установите новое значение прозрачности.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и [EffectFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

С помощью метода `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslide/) можно получить эффективный фон слайда.

Следующий пример на Java показывает, как получить эффективное значение фона слайда:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получите эффективный фон с учётом главного слайда, макета и темы.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

### Можно ли сбросить пользовательский фон и восстановить фон темы/макета?

Да. Удалите пользовательскую заливку слайда, и фон вновь будет наследоваться от соответствующего слайда [макет](/slides/ru/androidjava/slide-layout/)/[главный](/slides/ru/androidjava/slide-master/) (т.е. от [фон темы](/slides/ru/androidjava/presentation-theme/)).

### Что происходит с фоном, если я позже изменю тему презентации?

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [макет](/slides/ru/androidjava/slide-layout/)/[главный](/slides/ru/androidjava/slide-master/), он обновится в соответствии с [новой темой](/slides/ru/androidjava/presentation-theme/).