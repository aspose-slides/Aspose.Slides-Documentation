---
title: Conector
type: docs
weight: 190
url: /es/net/examples/elements/connector/
keywords:
- ejemplo de conector
- añadir conector
- acceder al conector
- eliminar conector
- reconectar formas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Dibuja y controla conectores en C# con Aspose.Slides: agrega, enruta, reencamina, establece puntos de conexión, flechas y estilos para enlazar formas en PPT, PPTX y ODP."
---

Muestra cómo conectar formas con conectores y cambiar sus destinos usando **Aspose.Slides for .NET**.

## Añadir un conector

Inserte una forma de conector entre dos puntos en la diapositiva.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## Acceder a un conector

Recupere la primera forma de conector añadida a una diapositiva.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## Eliminar un conector

Elimine un conector de la diapositiva.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## Reconectar formas

Adjunte un conector a dos formas asignando los destinos de inicio y fin.
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
