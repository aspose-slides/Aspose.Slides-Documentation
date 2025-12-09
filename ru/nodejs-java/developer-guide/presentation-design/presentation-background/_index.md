---
title: Управление фонами презентаций на JavaScript
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/nodejs-java/presentation-background/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js, а также получите советы по коду, чтобы улучшить ваши презентации."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **мастер‑слайда** (применяется к нескольким слайдам сразу).

![Фон PowerPoint](powerpoint-background.png)

## **Установка сплошного цветного фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует мастер‑слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) фона слайда в значение `Solid`.
4. Воспользуйтесь методом [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на JavaScript показывает, как установить синий сплошной цвет в качестве фона обычного слайда:
```js
// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Установите цвет фона слайда в синий.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Сохраните презентацию на диск.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Установка сплошного цветного фона для мастер‑слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер‑слайда в презентации. Мастер‑слайд выступает в роли шаблона, контролирующего форматирование всех слайдов, поэтому при выборе сплошного цвета для его фона он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) мастер‑слайда (через `getMasters`) в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) фона мастер‑слайда в значение `Solid`.
4. Воспользуйтесь методом [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на JavaScript показывает, как установить сплошной цвет (зелёный) в качестве фона мастер‑слайда:
```js
// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Установите цвет фона для мастер‑слайда в лесной зеленый.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Сохраните презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Установка градиентного фона для слайда**

Градиент — это графический эффект, создаваемый постепённым изменением цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет установить градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) фона слайда в значение `Gradient`.
4. Воспользуйтесь методом [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) класса [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) для настройки требуемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на JavaScript показывает, как установить градиентный цвет в качестве фона слайда:
```js
// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Примените градиентный эффект к фону.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Сохраните презентацию на диск.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Установка изображения в качестве фона слайда**

Помимо сплошных и градиентных заполнений, Aspose.Slides позволяет использовать изображения в качестве фоновых.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) фона слайда в значение `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фонового.
5. Добавьте изображение в коллекцию изображений презентации.
6. Воспользуйтесь методом [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) класса [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на JavaScript показывает, как установить изображение в качестве фона слайда:
```js
// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Установите свойства фонового изображения.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Загрузите изображение.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Добавьте изображение в коллекцию изображений презентации.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Сохраните презентацию на диск.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Следующий образец кода показывает, как установить тип заполнения фона в виде мозаичного изображения и изменить свойства плитки:
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Установите изображение, используемое для фонового заполнения.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Установите режим заливки изображения в режим Tile и настройте свойства плитки.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
Читать дальше: [**Мозаичное изображение как текстура**](/slides/ru/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменение прозрачности фонового изображения**

Возможно, вам потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на JavaScript показывает, как изменить прозрачность фонового изображения слайда:
```js
var transparencyValue = 30; // Например.

// Получить коллекцию операций трансформации изображения.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Найти существующий эффект прозрачности фиксированного процента.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Установить новое значение прозрачности.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Получение значения фона слайда**

Aspose.Slides предоставляет класс `BackgroundEffectiveData` для получения эффективных значений фона слайда. Этот класс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/).

Используя метод `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/), вы можете получить эффективный фон слайда.

Следующий пример на JavaScript показывает, как получить эффективное значение фона слайда:
```js
// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Получите эффективный фон, учитывая мастер‑слайд, макет и тему.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Могу ли я сбросить пользовательский фон и восстановить фон темы/уровня?**

Да. Удалите пользовательское заполнение слайда, и фон будет снова наследоваться от соответствующего [layout](/slides/ru/nodejs-java/slide-layout/)/[master](/slides/ru/nodejs-java/slide-master/) слайда (т.е. от [theme background](/slides/ru/nodejs-java/presentation-theme/)).

**Что происходит с фоном, если позже изменить тему презентации?**

Если у слайда собственное заполнение, оно останется без изменений. Если фон наследуется от [layout](/slides/ru/nodejs-java/slide-layout/)/[master](/slides/ru/nodejs-java/slide-master/), он обновится в соответствии с [new theme](/slides/ru/nodejs-java/presentation-theme/).