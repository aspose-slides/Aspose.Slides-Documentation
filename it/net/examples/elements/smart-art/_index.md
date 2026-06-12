---
title: SmartArt
type: docs
weight: 140
url: /it/net/examples/elements/smart-art/
keywords:
- SmartArt
- aggiungi SmartArt
- accedi a SmartArt
- rimuovi SmartArt
- layout SmartArt
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con SmartArt in Aspose.Slides per .NET: crea, modifica, converti e personalizza diagrammi con C# per presentazioni PowerPoint e OpenDocument."
---
Questo articolo dimostra come aggiungere grafica SmartArt, accedervi, rimuoverla e modificare i layout utilizzando **Aspose.Slides for .NET**.

## **Aggiungi SmartArt**

Inserisci una grafica SmartArt utilizzando uno dei layout predefiniti.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Accedi a SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Rimuovi SmartArt**

Elimina una forma SmartArt dalla diapositiva.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Modifica Layout SmartArt**

Aggiorna il tipo di layout di una grafica SmartArt esistente.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```