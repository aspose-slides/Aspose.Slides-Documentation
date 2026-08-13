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
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, с подсказками кода для улучшения ваших презентаций."
---
## **Введение**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (один слайд) или **главного слайда** (применяется сразу к нескольким слайдам).

![Фон PowerPoint](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/net/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фона слайда в значение `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/solidfillcolor/) у [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на C# демонстрирует, как задать синий сплошной цвет в качестве фона обычного слайда:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides позволяет задать сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд выступает как шаблон, управляющий форматированием всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
2. Установите [BackgroundType](https://reference.aspose.com/slides/ru/net/aspose.slides/backgroundtype/) главного слайда (через `masters`) в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фона главного слайда в значение `Solid`.
4. Используйте [SolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/solidfillcolor/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на C# демонстрирует, как задать сплошной цвет (лесной зелёный) в качестве фона главного слайда:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Установите цвет фона Master‑слайда в лесной зелёный.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Сохраните презентацию на диск.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Установить градиентный фон для слайда**

Градиент — графический эффект, создаваемый постепённым изменением цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/net/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фона слайда в значение `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/gradientformat/) у [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/) для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на C# демонстрирует, как задать градиентный цвет в качестве фона для слайда:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/ru/net/aspose.slides/backgroundtype/) слайда в значение `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фона слайда в значение `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/picturefillformat/) у [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на C# демонстрирует, как задать изображение в качестве фона слайда:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Следующий образец кода показывает, как задать тип заливки фона как мозаичное изображение и изменить свойства мозаики:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Установите изображение, используемое для заливки фона.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Установите режим заливки изображения в плитку и настройте свойства плитки.
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

{{% alert color="info" %}}
Подробнее: [**Изображение плиткой в качестве текстуры**](/slides/ru/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Вы можете захотеть отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на C# показывает, как изменить прозрачность фонового изображения слайда:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Например.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите коллекцию операций трансформации изображения.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Найдите существующий эффект фиксированной процентной прозрачности.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Установите новое значение прозрачности.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibackgroundeffectivedata/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

С помощью свойства `background` класса [BaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslide/) вы можете получить эффективный фон слайда.

Следующий пример на C# демонстрирует, как получить эффективное значение фона слайда:

```cs
using Aspose.Slides;

// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Получите эффективный фон с учётом мастера, макета и темы.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Можно ли сбросить пользовательский фон и восстановить фон темы/макета?

Да. Удалите пользовательскую заливку слайда, и фон вновь будет наследоваться от соответствующего [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/) слайда (то есть от [theme background](/slides/ru/net/presentation-theme/)).

### Что происходит с фоном, если позже изменить тему презентации?

Если у слайда есть собственная заливка, она останется неизменной. Если фон наследуется от [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/), он обновится в соответствии с новой темой.