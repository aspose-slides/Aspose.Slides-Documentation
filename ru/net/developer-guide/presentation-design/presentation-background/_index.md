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
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, с советами по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются для фона слайдов. Вы можете установить фон для **обычного слайда** (одного слайда) или **главного слайда** (применяется к нескольким слайдам сразу).

![Фон PowerPoint](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фона слайда в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) класса [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на C# показывает, как установить синий сплошной цвет в качестве фона обычного слайда:
```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Установить цвет фона слайда в синий.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Сохранить презентацию на диск.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить сплошной цвет фона для главного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для главного слайда в презентации. Главный слайд служит шаблоном, управляющим форматированием всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) главного слайда (через `masters`) в `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фона главного слайда в `Solid`.
4. Используйте [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на C# показывает, как установить сплошной цвет (лесной зелёный) в качестве фона главного слайда:
```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Установить цвет фона мастер‑слайда в лесный зеленый.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Сохранить презентацию на диск.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить градиентный фон для слайда**

Градиент - графический эффект, создаваемый постепенным изменением цвета. Когда используется в качестве фона слайда, градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фона слайда в `Gradient`.
4. Используйте свойство [GradientFormat]((https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/)) класса [FillFormat]((https://reference.aspose.com/slides/net/aspose.slides/fillformat/)) для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на C# показывает, как установить градиентный цвет в качестве фона слайда:
```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Применить градиентный эффект к фону.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Сохранить презентацию на диск.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) слайда в `OwnBackground`.
3. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фона слайда в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) класса [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на C# показывает, как установить изображение в качестве фона слайда:
```c#
 // Создать экземпляр класса Presentation.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // Установить свойства фонового изображения.
     slide.Background.Type = BackgroundType.OwnBackground;
     slide.Background.FillFormat.FillType = FillType.Picture;
     slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     // Загрузить изображение.
     IImage image = Images.FromFile("Tulips.jpg");
     // Добавить изображение в коллекцию изображений презентации.
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

     // Сохранить презентацию на диск.
     presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
 }
```


Следующий фрагмент кода показывает, как установить тип заливки фона в виде мозаичного изображения и изменить свойства чередования:
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

    // Установить режим заливки изображения в режим Tile и настроить свойства тайла.
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
Подробнее: [**Мозаичное изображение как текстура**](/slides/ru/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на C# показывает, как изменить прозрачность фонового изображения слайда:
```cs
var transparencyValue = 30; // Например.

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
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

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Используя свойство `background` класса [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), вы можете получить эффективный фон слайда.

Следующий пример на C# показывает, как получить эффективное значение фона слайда:
```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Получить эффективный фон, учитывающий мастер‑слайд, макет и тему.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **Вопросы и ответы**

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет вновь наследоваться от соответствующего слайда [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/) (т.е. от [theme background](/slides/ru/net/presentation-theme/)).

**Что происходит с фоном, если я позже изменю тему презентации?**

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/net/slide-layout/)/[master](/slides/ru/net/slide-master/), он будет обновлен в соответствии с [new theme](/slides/ru/net/presentation-theme/).