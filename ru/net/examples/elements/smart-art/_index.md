---
title: SmartArt
type: docs
weight: 140
url: /ru/net/examples/elements/smartart/
keywords:
- пример SmartArt
- добавить SmartArt
- доступ к SmartArt
- удалить SmartArt
- макет SmartArt
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и редактируйте SmartArt на C# с помощью Aspose.Slides: добавляйте узлы, меняйте макеты и стили, точно преобразуйте в формы и экспортируйте в PPT, PPTX и ODP."
---

Показывает, как добавлять графику SmartArt, получать к ней доступ, удалять её и изменять макеты с помощью **Aspose.Slides for .NET**.

## Добавить SmartArt

Вставьте графику SmartArt, используя один из встроенных макетов.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## Доступ к SmartArt

Получите первый объект SmartArt на слайде.
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## Удалить SmartArt

Удалите форму SmartArt со слайда.
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## Изменить макет SmartArt

Обновите тип макета существующей графики SmartArt.
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
