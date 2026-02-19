---
title: Tableau
type: docs
weight: 120
url: /fr/net/examples/elements/table/
keywords:
- tableau
- ajouter un tableau
- accéder au tableau
- supprimer le tableau
- fusionner les cellules
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec les tableaux dans Aspose.Slides for .NET : créez, formatez, fusionnez des cellules, appliquez des styles, importez des données et exportez avec des exemples C# pour PPT, PPTX et ODP."
---
Exemples d'ajout de tableaux, d'accès à ceux-ci, de suppression et de fusion de cellules à l'aide d'**Aspose.Slides for .NET**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Accéder au premier tableau sur la diapositive.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Fusionner les cellules d'un tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```