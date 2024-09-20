---
title: Фон презентации
type: docs
weight: 20
url: /net/presentation-background/
keywords: "фон PowerPoint, установить фон, C#, Csharp, Aspose.Slides для .NET"
description: "Установить фон в презентации PowerPoint на C# или .NET"
---

Сплошные цвета, градиенты и изображения часто используются в качестве фоновых изображений для слайдов. Вы можете установить фон как для **обычного слайда** (один слайд), так и для **мастера слайдов** (несколько слайдов сразу).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Установить сплошной цвет в качестве фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации (даже если эта презентация содержит мастер-слайд). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) для фона слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/), предоставляемое [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на C# показывает, как установить сплошной цвет (синий) в качестве фона для обычного слайда:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation())
{

    // Устанавливает цвет фона для первого ISlide на синий
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // Записывает презентацию на диск
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **Установить сплошной цвет в качестве фона для мастера слайдов**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер-слайда в презентации. Мастер-слайд действует как шаблон, который содержит и контролирует параметры форматирования для всех слайдов. Поэтому, когда вы выбираете сплошной цвет в качестве фона для мастер-слайда, этот новый фон будет использоваться для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) для мастер-слайда (`Masters`) на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) для фона мастер-слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/), предоставляемое [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на C# показывает, как установить сплошной цвет (лесной зелёный) в качестве фона для мастер-слайда в презентации:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation())
{

    // Устанавливает цвет фона для Master ISlide на лесной зелёный
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Записывает презентацию на диск
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **Установить градиентный цвет в качестве фона для слайда**

Градиент — это графический эффект, основанный на постепенном изменении цвета. Градиентные цвета, используемые в качестве фонов для слайдов, делают презентации более художественными и профессиональными. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) для фона мастер-слайда на `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/), предоставляемое [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), чтобы указать ваши предпочтительные настройки градиента.
5. Сохраните изменённую презентацию.

Этот код на C# показывает, как установить градиентный цвет в качестве фона для слайда:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // Применяет градиентный эффект к фону
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Записывает презентацию на диск
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **Установить изображение в качестве фона для слайда**

Кроме сплошных и градиентных цветов, Aspose.Slides также позволяет устанавливать изображения в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) для фона мастер-слайда на `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/), предоставляемое [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), чтобы установить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Этот код на C# показывает, как установить изображение в качестве фона для слайда:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{

    // Устанавливает условия для фонового изображения
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Загружает изображение
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap(dataDir + "Tulips.jpg");

    // Добавляет изображение в коллекцию изображений презентации
    IPPImage imgx = pres.Images.AddImage(img);

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = imgx;

    // Записывает презентацию на диск
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}

```

### **Изменить прозрачность фонового изображения**

Вы можете захотеть отрегулировать прозрачность фонового изображения слайда, чтобы сделать содержимое слайда более заметным. Этот код на C# показывает, как изменить прозрачность для фонового изображения слайда:

```c#
var transparencyValue = 30; // например

// Получает коллекцию операций трансформации изображения
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Находит эффект прозрачности с фиксированным процентом.
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Устанавливает новое значение прозрачности.
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

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/), который позволяет получить эффективные значения фонов слайдов. Этот интерфейс содержит информацию о эффективном [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) и эффективном [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Используя свойство [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) из класса [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), вы можете получить эффективное значение для фона слайда.

Этот код на C# показывает, как получить эффективное значение фона слайда:

```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("Цвет заливки: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("Тип заливки: " + effBackground.FillFormat.FillType);
```