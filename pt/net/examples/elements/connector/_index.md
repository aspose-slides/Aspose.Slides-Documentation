---
title: Conector
type: docs
weight: 190
url: /pt/net/examples/elements/connector/
keywords:
- conector
- adicionar conector
- acessar conector
- remover conector
- reconectar formas
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como adicionar, roteirizar e estilizar conectores entre formas usando Aspose.Slides for .NET, com exemplos em C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como conectar formas com conectores e alterar seus alvos usando **Aspose.Slides for .NET**.

## **Adicionar um Conector**

Insira uma forma de conector entre dois pontos no slide.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Acessar um Conector**

Recupere a primeira forma de conector adicionada a um slide.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Remover um Conector**

Exclua um conector do slide.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Reconectar Formas**

Anexe um conector a duas formas atribuindo alvos de início e fim.

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