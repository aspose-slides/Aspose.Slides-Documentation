---
title: SmartArt
type: docs
weight: 140
url: /es/net/examples/elements/smartart/
keywords:
- Ejemplo de SmartArt
- Agregar SmartArt
- Acceder a SmartArt
- Eliminar SmartArt
- Diseño de SmartArt
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear y editar SmartArt en C# con Aspose.Slides: agregar nodos, cambiar diseños y estilos, convertir a formas con precisión y exportar a PPT, PPTX y ODP."
---

Muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños utilizando **Aspose.Slides for .NET**.

## **Agregar SmartArt**

Inserte un gráfico SmartArt utilizando uno de los diseños incorporados.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## **Acceder a SmartArt**

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


## **Eliminar SmartArt**

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


## **Cambiar diseño de SmartArt**

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
