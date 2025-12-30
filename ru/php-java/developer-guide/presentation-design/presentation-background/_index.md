---
title: Управление фонами презентаций в PHP
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/php-java/presentation-background/
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
- PHP
- Aspose.Slides
description: "Узнайте, как задавать динамические фоновые изображения в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, с советами по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете установить фон для **обычного слайда** (один слайд) или **главного слайда** (применяется к нескольким слайдам сразу).

![PowerPoint background](powerpoint-background.png)

## **Установка сплошного цветного фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство фона слайда [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) у [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример PHP демонстрирует, как установить синий сплошной цвет в качестве фона обычного слайда:
```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Установите цвет фона слайда в синий.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Сохраните презентацию на диск.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Установка сплошного цветного фона для главного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона главного слайда презентации. Главный слайд выступает шаблоном, который контролирует форматирование всех слайдов, поэтому при выборе сплошного цвета для фона главного слайда он применяется ко каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) главного слайда (через `getMasters`) в `OwnBackground`.
3. Установите свойство фона главного слайда [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример PHP демонстрирует, как установить сплошной цвет (зелёный) в качестве фона главного слайда:
```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Установите цвет фона для главного слайда в Forest Green.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Сохраните презентацию на диск.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Установка градиентного фона для слайда**

Градиент — это графический эффект, создаваемый плавным изменением цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет установить градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство фона слайда [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Gradient`.
4. Вызовите метод [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) у [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы настроить предпочтительные параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример PHP демонстрирует, как установить градиентный цвет в качестве фона слайда:
```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Примените градиентный эффект к фону.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Сохраните презентацию на диск.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Установка изображения в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите свойство фона слайда [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) у [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы назначить изображение фоном.
7. Сохраните изменённую презентацию.

Следующий пример PHP демонстрирует, как установить изображение в качестве фона слайда:
```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Установите свойства фонового изображения.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Загрузите изображение.
    $image = Images::fromFile("Tulips.jpg");
    // Добавьте изображение в коллекцию изображений презентации.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Сохраните презентацию на диск.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Следующий образец кода показывает, как установить тип заливки фона в изображение‑мозаику и изменить свойства мозаики:
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Установите изображение, используемое для заливки фона.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Установите режим заливки картинкой в режим "мозаика" и настройте свойства мозаики.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}

Читать подробнее: [**Tile Picture As Texture**](/slides/ru/php-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Изменение прозрачности фонового изображения**

Возможно, вы захотите отрегулировать прозрачность фонового изображения слайда, чтобы содержание слайда выделялось. Следующий код PHP показывает, как изменить прозрачность фонового изображения слайда:
```php
$transparencyValue = 30; // Например.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **Получение значения фона слайда**

Aspose.Slides предоставляет класс `BackgroundEffectiveData` для получения эффективных значений фона слайда. Этот класс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/).

С помощью метода `getBackground` класса [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) можно получить эффективный фон слайда.

Следующий пример PHP демонстрирует, как получить эффективное значение фона слайда:
```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Получите эффективный фон, учитывая мастер, макет и тему.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Можно ли сбросить пользовательский фон и вернуть фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон снова будет наследоваться от соответствующего [layout](/slides/ru/php-java/slide-layout/)/[master](/slides/ru/php-java/slide-master/) слайда (т.е. от [theme background](/slides/ru/php-java/presentation-theme/)).

**Что происходит с фоном, если позже изменить тему презентации?**

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/php-java/slide-layout/)/[master](/slides/ru/php-java/slide-master/), он обновится в соответствии с новой темой.