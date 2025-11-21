---
title: Table
type: docs
weight: 120
url: /fr/net/examples/elements/table/
keywords:
- exemple de table
- ajouter une table
- accéder à la table
- supprimer une table
- fusionner les cellules
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et mettre en forme des tables en C# avec Aspose.Slides : insérer des données, fusionner des cellules, styliser les bordures, aligner le contenu et importer/exporter pour PPT, PPTX et ODP."
---

Exemples d'ajout de tables, d'accès à celles-ci, de suppression et de fusion de cellules à l'aide d'**Aspose.Slides for .NET**.

## Ajouter une table

Créer une table simple avec deux lignes et deux colonnes.
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## Accéder à une table

Récupérer la première forme de table sur la diapositive.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Accéder à la première table sur la diapositive
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## Supprimer une table

Supprimer une table d'une diapositive.
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## Fusionner les cellules d'une table

Fusionner les cellules adjacentes d'une table en une seule cellule.
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
