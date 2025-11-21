---
title: SmartArt
type: docs
weight: 140
url: /es/net/examples/elements/smartart/
keywords:
- Ejemplo de SmartArt
- agregar SmartArt
- acceder a SmartArt
- eliminar SmartArt
- diseño de SmartArt
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y edite SmartArt en C# con Aspose.Slides: agregue nodos, cambie diseños y estilos, convierta a formas con precisión y exporte a PPT, PPTX y ODP."
---

Muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar diseños usando **Aspose.Slides for .NET**.

## Agregar SmartArt

Inserte un gráfico SmartArt usando uno de los diseños incorporados.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## Acceder a SmartArt

Recupere el primer objeto SmartArt en una diapositiva.
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## Eliminar SmartArt

Elimine una forma SmartArt de la diapositiva.
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## Cambiar diseño de SmartArt

Actualice el tipo de diseño de un gráfico SmartArt existente.
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
