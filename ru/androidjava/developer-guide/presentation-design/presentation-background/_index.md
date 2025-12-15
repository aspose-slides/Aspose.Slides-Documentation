---
title: Управление фоновыми изображениями презентации на Android
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/androidjava/presentation-background/
keywords:
- фон презентации
- фон слайда
- сплошной цвет
- градиентный цвет
- фоновое изображение
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

## **Обзор**

Сплошные цвета, градиенты и изображения обычно используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **главного слайда** (применяется сразу к нескольким слайдам).

![Фон PowerPoint](powerpoint-background.png)

## **Задать сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите тип заполнения [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) фона слайда в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) у [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать синий сплошной цвет в качестве фона обычного слайда:
```java
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


## **Задать сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд выступает в роли шаблона, который управляет форматированием всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется к каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) главного слайда (через `getMasters`) в значение `OwnBackground`.
3. Установите тип заполнения [FillType] фонa главного слайда в `Solid`.
4. Вызовите метод [getSolidFillColor] для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать сплошной цвет (зеленый) в качестве фона главного слайда:
```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Установите цвет фона для главного слайда в лесной зелёный.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Сохраните презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Задать градиентный фон для слайда**

Градиент — графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите тип заполнения [FillType] фонa слайда в `Gradient`.
4. Вызовите метод [getGradientFormat] у [FillFormat] для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать градиентный цвет в качестве фона слайда:
```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Примените градиентный эффект к фону.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Сохраните презентацию на диск.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Задать изображение в качестве фона слайда**

Помимо сплошных и градиентных заполнений, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите тип заполнения [FillType] фонa слайда в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [getPictureFillFormat] у [FillFormat] для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на Java показывает, как задать изображение в качестве фона слайда:
```java
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


Следующий образец кода показывает, как задать тип заполнения фона в виде плиточного изображения и изменить свойства наложения:
```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Установите изображение, используемое для заполнения фоном.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Установите режим заливки изображения в Плитку и настройте свойства плитки.
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


{{% alert color="primary" %}}
Подробнее: [**Плиточное изображение как текстура**](/slides/ru/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на Java показывает, как изменить прозрачность фонового изображения слайда:
```java
int transparencyValue = 30; // Например.

// Получить коллекцию операций преобразования изображения.
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
```


## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс открывает доступ к эффективным [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

С помощью метода `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/) вы можете получить эффективный фон слайда.

Следующий пример на Java показывает, как получить эффективное значение фона слайда:
```java
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

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательское заполнение слайда, и фон будет снова наследоваться от соответствующего слайда [layout](/slides/ru/androidjava/slide-layout/)/[master](/slides/ru/androidjava/slide-master/) (т.е. от [theme background](/slides/ru/androidjava/presentation-theme/)).

**Что происходит с фоном, если я позже изменю тему презентации?**

Если у слайда есть собственное заполнение, оно останется без изменений. Если фон наследуется от [layout](/slides/ru/androidjava/slide-layout/)/[master](/slides/ru/androidjava/slide-master/), он будет обновлён в соответствии с [new theme](/slides/ru/androidjava/presentation-theme/).