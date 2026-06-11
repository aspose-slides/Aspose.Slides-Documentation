---
title: SmartArt
type: docs
weight: 140
url: /pl/net/examples/elements/smart-art/
keywords:
- SmartArt
- dodaj SmartArt
- uzyskaj dostęp do SmartArt
- usuń SmartArt
- układ SmartArt
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Pracuj ze SmartArt w Aspose.Slides for .NET: twórz, edytuj, konwertuj i stylizuj diagramy przy użyciu C# dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak dodać grafiki SmartArt, uzyskać do nich dostęp, usunąć je oraz zmienić układy przy użyciu **Aspose.Slides for .NET**.

## **Dodaj SmartArt**

Wstaw grafikę SmartArt, używając jednego z wbudowanych układów.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Uzyskaj dostęp do SmartArt**

Pobierz pierwszy obiekt SmartArt na slajdzie.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Usuń SmartArt**

Usuń kształt SmartArt ze slajdu.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Zmień układ SmartArt**

Zaktualizuj typ układu istniejącej grafiki SmartArt.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```