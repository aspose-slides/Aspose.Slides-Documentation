---
title: Grupo de Shapes
type: docs
weight: 170
url: /pt/net/examples/elements/group-shape/
keywords:
- grupo
- adicionar shape de grupo
- acessar shape de grupo
- remover shape de grupo
- desagrupar shapes
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie shapes agrupados no Aspose.Slides for .NET: crie, aninhe, alinhe, reordene e estilize grupos de shapes com exemplos em C# em apresentações PPT, PPTX e ODP."
---
Exemplos de criação de grupos de shapes, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for .NET**.

## **Adicionar um Grupo de Shapes**

Crie um grupo contendo duas shapes básicas.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Acessar um Grupo de Shapes**

Recupere o primeiro grupo de shapes de um slide.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Remover um Grupo de Shapes**

Exclua um grupo de shapes do slide.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Desagrupar Shapes**

Mova as shapes para fora de um contêiner de grupo.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Mova a shape para fora do grupo.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```