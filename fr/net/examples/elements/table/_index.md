---
title: Tableau
type: docs
weight: 120
url: /fr/net/examples/elements/table/
keywords:
- exemple de tableau
- ajouter un tableau
- accéder au tableau
- supprimer le tableau
- fusionner des cellules
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et formater des tableaux en C# avec Aspose.Slides : insérer des données, fusionner des cellules, styliser les bordures, aligner le contenu, et importer/exporter pour PPT, PPTX et ODP."
---

Exemples d'ajout de tableaux, d'accès à ceux-ci, de suppression et de fusion de cellules à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.
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


## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.
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


## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.
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


## **Fusionner les cellules du tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.
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
