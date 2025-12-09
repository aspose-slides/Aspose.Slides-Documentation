---
title: Управление фонами презентаций в .NET
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/net/presentation-background/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, используя подсказки коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **главного слайда** (применяется к нескольким слайдам сразу).

![PowerPoint background](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите тип заливки фона слайда [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) у [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример C# показывает, как задать синий сплошной цвет в качестве фона обычного слайда:
```cs
// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Установите цвет фона слайда в синий.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Сохраните презентацию на диск.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд служит шаблоном, который управляет форматированием всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется к каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у главного слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) (через `masters`) в значение `OwnBackground`.
3. Установите тип заливки фона главного слайда [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в `Solid`.
4. Используйте [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) , чтобы задать сплошной цвет фона.
5. Сохраните изменённую презентацию.

Следующий пример C# показывает, как задать сплошной цвет (лесной зелёный) в качестве фона главного слайда:
```cs
// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Установите цвет фона для главного слайда в лесной зелёный.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Сохраните презентацию на диск.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить градиентный фон для слайда**

Градиент — графический эффект, создаваемый плавным изменением цвета. Когда используется в качестве фона слайда, градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите тип заливки фона слайда [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) у [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы настроить параметры градиента.
5. Сохраните изменённую презентацию.

Следующий пример C# показывает, как задать градиентный цвет в качестве фона слайда:
```cs
// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Примените градиентный эффект к фону.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Сохраните презентацию на диск.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фонa слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите тип заливки фона слайда [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) у [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы назначить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример C# показывает, как задать изображение в качестве фона слайда:
```c#
 // Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Установите свойства фонового изображения.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Загрузите изображение.
    IImage image = Images.FromFile("Tulips.jpg");
    // Добавьте изображение в коллекцию изображений презентации.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Сохраните презентацию на диск.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


Следующий образец кода показывает, как установить тип заливки фона в «мозаичное изображение» и изменить свойства мозаики:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Установить изображение, используемое для заливки фона.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Установить режим заливки изображения в Tile и настроить свойства плитки.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Подробнее: [**Текстура из мозаичного изображения**](/slides/ru/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код C# демонстрирует, как изменить прозрачность фонового изображения слайда:
```cs
var transparencyValue = 30; // Например.

// Получить коллекцию операций трансформации изображения.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Найти существующий эффект прозрачности с фиксированным процентом.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Установить новое значение прозрачности.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) .

Используя свойство `background` класса [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) , вы можете получить эффективный фон для слайда.

Следующий пример C# показывает, как получить эффективное значение фона слайда:
```cs
// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Получите эффективный фон, учитывая мастер, макет и тему.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон снова будет наследоваться от соответствующего [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/) слайда (т.е. от [theme background](/slides/ru/net/presentation-theme/)).

**Что происходит с фоном, если я позже изменю тему презентации?**

Если у слайда есть собственная заливка, она останется неизменной. Если фон наследуется от [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/), он обновится в соответствии с [new theme](/slides/ru/net/presentation-theme/).