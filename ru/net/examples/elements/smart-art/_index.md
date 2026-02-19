---
title: SmartArt
type: docs
weight: 140
url: /ru/net/examples/elements/smart-art/
keywords:
- SmartArt
- добавить SmartArt
- доступ к SmartArt
- удалить SmartArt
- макет SmartArt
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте со SmartArt в Aspose.Slides for .NET: создавайте, редактируйте, конвертируйте и оформляйте диаграммы с помощью C# для презентаций PowerPoint и OpenDocument."
---
Эта статья демонстрирует, как добавлять графику SmartArt, получать к ней доступ, удалять её и менять макеты с помощью **Aspose.Slides for .NET**.

## **Add SmartArt**
Вставьте графику SmartArt, используя один из встроенных макетов.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Access SmartArt**
Получите первый объект SmartArt на слайде.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Remove SmartArt**
Удалите форму SmartArt со слайда.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Change SmartArt Layout**
Обновите тип макета существующей графики SmartArt.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```