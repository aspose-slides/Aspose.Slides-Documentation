---
title: Conector
type: docs
weight: 190
url: /es/net/examples/elements/connector/
keywords:
- conector
- añadir conector
- acceder al conector
- eliminar conector
- volver a conectar formas
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo añadir, encaminar y dar estilo a los conectores entre formas usando Aspose.Slides for .NET, con ejemplos en C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo conectar formas con conectores y cambiar sus destinos usando **Aspose.Slides for .NET**.

## **Agregar un Conector**

Inserte una forma de conector entre dos puntos en la diapositiva.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Acceder a un Conector**

Recupere la primera forma de conector añadida a una diapositiva.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Eliminar un Conector**

Elimine un conector de la diapositiva.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Volver a Conectar Formas**

Adjunte un conector a dos formas asignando los destinos de inicio y fin.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```