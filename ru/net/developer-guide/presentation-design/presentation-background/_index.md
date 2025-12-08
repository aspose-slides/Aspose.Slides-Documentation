---
title: Управление фонами презентаций в C#
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
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, а также получите советы по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения обычно используются в качестве фона слайдов. Вы можете установить фон для **обычного слайда** (один слайд) или **главного слайда** (применяется к нескольким слайдам одновременно).

![Фон PowerPoint](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите для фона слайда свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в значение `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) на объекте [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы указать сплошной цвет фона.
5. Сохраните изменённую презентацию.

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

Aspose.Slides позволяет установить сплошной цвет в качестве фона для главного слайда презентации. Главный слайд выступает в роли шаблона, который контролирует форматирование всех слайдов, поэтому при выборе сплошного цвета для фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у главного слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) (через `masters`) в значение `OwnBackground`.
3. Установите для фона главного слайда свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в значение `Solid`.
4. Используйте [SolidFillColor], чтобы указать сплошной цвет фона.
5. Сохраните изменённую презентацию.

```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Установить цвет фона для главного слайда в цвет лесного зелёного.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Сохранить презентацию на диск.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Установить градиентный фон для слайда**

Градиент — это графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите для фона слайда свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в значение `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) на объекте [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы настроить предпочтительные параметры градиента.
5. Сохраните изменённую презентацию.

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

В дополнение к сплошным и градиентным заливкам Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите для фона слайда свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) в значение `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) на объекте [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , чтобы назначить изображение в качестве фона.
7. Сохраните изменённую презентацию.

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

    // Установить режим заливки изображения в режим Плитка и настроить свойства плитки.
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
Читайте подробнее: [**Изображение плиткой в качестве текстуры**](/slides/ru/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вы захотите отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Ниже приведён пример кода C#, показывающий, как изменить прозрачность фонового изображения слайда:

```cs
var transparencyValue = 30; // Например.

// Получить коллекцию операций преобразования изображения.
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

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот интерфейс открывает доступ к эффективным [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) .

С помощью свойства `background` класса [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) можно получить эффективный фон слайда.

```cs
// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Получить эффективный фон с учётом мастера, макета и темы.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **Часто задаваемые вопросы**

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет снова наследоваться от соответствующего слайда [макета](/slides/ru/net/slide-layout/)/[главного](/slides/ru/net/slide-master/) (т.е. от [фоновой темы](/slides/ru/net/presentation-theme/)).

**Что произойдёт с фоном, если я позже изменю тему презентации?**

Если у слайда есть собственная заливка, она останется неизменной. Если фон наследуется от [макета](/slides/ru/net/slide-layout/)/[главного](/slides/ru/net/slide-master/), он обновится, чтобы соответствовать [новой теме](/slides/ru/net/presentation-theme/).