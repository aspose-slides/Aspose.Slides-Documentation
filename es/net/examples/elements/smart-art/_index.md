---
title: SmartArt
type: docs
weight: 140
url: /es/net/examples/elements/smart-art/
keywords:
- SmartArt
- agregar SmartArt
- acceder a SmartArt
- eliminar SmartArt
- diseño de SmartArt
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con SmartArt en Aspose.Slides for .NET: cree, edite, convierta y dé estilo a diagramas con C# para presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños usando **Aspose.Slides for .NET**.

## **Agregar SmartArt**
Inserte un gráfico SmartArt usando uno de los diseños predefinidos.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Acceder a SmartArt**
Recupere el primer objeto SmartArt en una diapositiva.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Eliminar SmartArt**
Elimine una forma SmartArt de la diapositiva.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Cambiar diseño de SmartArt**
Actualice el tipo de diseño de un gráfico SmartArt existente.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```