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
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Java, с советами по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фоновых изображений слайдов. Вы можете установить фон для **обычного слайда** (одного слайда) или **мастер‑слайда** (применяется к нескольким слайдам сразу).

![PowerPoint background](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует мастер‑слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фона слайда в `Solid`.
4. Используйте метод [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) на [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример Java показывает, как установить синий сплошной цвет в качестве фона обычного слайда:
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


## **Установить сплошной цвет фона для мастер‑слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер‑слайда в презентации. Мастер‑слайд служит шаблоном, управляющим форматированием всех слайдов, поэтому при выборе сплошного цвета фона мастер‑слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) мастер‑слайда (через `getMasters`) в `OwnBackground`.
3. Установите свойство [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фона мастер‑слайда в `Solid`.
4. Используйте метод [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) для задания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример Java показывает, как установить сплошной цвет (зелёный) в качестве фона мастер‑слайда:
```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Установите цвет фона для мастер-слайда в лесной зелёный.
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

Градиент — это графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фонового изображения слайда градиенты могут придать презентации более художественный и профессиональный вид. Aspose.Slides позволяет установить градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фона слайда в `Gradient`.
4. Используйте метод [getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) на [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы настроить требуемые параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример Java показывает, как установить градиентный цвет в качестве фона слайда:
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


## **Установить изображение в качестве фонового изображения слайда**

Помимо сплошных и градиентных заливок Aspose.Slides позволяет использовать изображения в качестве фоновых изображений слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фона слайда в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фонового изображения слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте метод [getPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) на [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы назначить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример Java показывает, как установить изображение в качестве фона слайда:
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


Следующий образец кода показывает, как установить тип заливки фона как растровое изображение, наложенное плиткой, и изменить свойства наложения:
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

    // Установите режим заливки изображения в Плитка и настройте свойства плитки.
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
Подробнее: [**Текстурировать изображение плиткой**](/slides/ru/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код Java показывает, как изменить прозрачность фонового изображения слайда:
```java
int transparencyValue = 30; // Например.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Получить значение фоновых свойств слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фоновых свойств слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Используя метод `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/), вы можете получить эффективный фон для слайда.

Следующий пример Java показывает, как получить эффективное значение фоновых свойств слайда:
```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получите эффективный фон, учитывая мастер, макет и тему.
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

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет снова наследован от соответствующего [layout](/slides/ru/java/slide-layout/)/[master](/slides/ru/java/slide-master/) (т.е. от [theme background](/slides/ru/java/presentation-theme/)).

**Что произойдёт с фоном, если позже я изменю тему презентации?**

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/java/slide-layout/)/[master](/slides/ru/java/slide-master/), он обновится в соответствии с [new theme](/slides/ru/java/presentation-theme/).