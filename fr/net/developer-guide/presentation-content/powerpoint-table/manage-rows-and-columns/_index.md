---
title: Gérer les lignes et les colonnes
type: docs
weight: 20
url: /fr/net/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de table, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Gérer les lignes et les colonnes des tables dans les présentations PowerPoint en C# ou .NET"

---

Pour vous permettre de gérer les lignes et les colonnes d'une table dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) et de nombreux autres types.

## **Définir la première ligne comme en-tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Créez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) et définissez-le sur null.
4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour trouver la table pertinente.
5. Définissez la première ligne de la table comme son en-tête.

Ce code C# vous montre comment définir la première ligne d'une table comme son en-tête :

```c#
// Instancie la classe Presentation
Presentation pres = new Presentation("table.pptx");

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Initialise la TableEx nulle
ITable tbl = null;

// Itère à travers les formes et définit une référence à la table
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Définit la première ligne d'une table comme son en-tête
tbl.FirstRow = true;

// Enregistre la présentation sur le disque
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Cloner une ligne ou une colonne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Clonez la ligne de la table.
7. Clonez la colonne de la table.
8. Enregistrez la présentation modifiée.

Ce code C# vous montre comment cloner une ligne ou une colonne d'une table PowerPoint :

```c#
// Instancie la classe Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accède à la première diapositive
    ISlide sld = presentation.Slides[0];

    // Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de table à la diapositive
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ajoute du texte à la cellule 1 de la ligne 1
    table[0, 0].TextFrame.Text = "Ligne 1 Cellule 1";

    // Ajoute du texte à la cellule 2 de la ligne 1
    table[1, 0].TextFrame.Text = "Ligne 1 Cellule 2";

    // Clone la ligne 1 à la fin de la table
    table.Rows.AddClone(table.Rows[0], false);

    // Ajoute du texte à la cellule 1 de la ligne 2
    table[0, 1].TextFrame.Text = "Ligne 2 Cellule 1";

    // Ajoute du texte à la cellule 2 de la ligne 2
    table[1, 1].TextFrame.Text = "Ligne 2 Cellule 2";

    // Clone la ligne 2 comme la 4ème ligne de la table
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clone la première colonne à la fin
    table.Columns.AddClone(table.Columns[0], false);

    // Clone la 2ème colonne à l'index de la 4ème colonne
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Enregistre la présentation sur le disque 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Supprimer une ligne ou une colonne d'une table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Supprimez la ligne de la table.
7. Supprimez la colonne de la table.
8. Enregistrez la présentation modifiée.

Ce code C# vous montre comment supprimer une ligne ou une colonne d'une table :

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Définir le formatage du texte au niveau de la ligne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première ligne avec [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/).
5. Définissez l'alignement des cellules de la première ligne avec [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Définissez le type vertical du texte des cellules de la deuxième ligne avec [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Enregistrez la présentation modifiée.

Ce code C# démontre l'opération.

```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supposons que la première forme sur la première diapositive soit une table

// Définit la hauteur de police des cellules de la première ligne
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Définit l'alignement du texte des cellules de la première ligne et la marge droite
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Définit le type vertical du texte des cellules de la deuxième ligne
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Enregistre la présentation sur le disque
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Définir le formatage du texte au niveau de la colonne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première colonne avec [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/).
5. Définissez l'alignement des cellules de la première colonne et la marge droite en une seule fois avec [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Définissez le type vertical du texte des cellules de la deuxième colonne avec [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Enregistrez la présentation modifiée.

Ce code C# démontre l'opération :

```c#
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Supposons que la première forme sur la première diapositive soit une table

// Définit la hauteur de police des cellules de la première colonne
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Définit l'alignement du texte des cellules de la première colonne et la marge droite en une seule fois
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Définit le type vertical du texte des cellules de la deuxième colonne
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Enregistre la présentation sur le disque
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Obtenir les propriétés de style de la table**

Aspose.Slides vous permet de récupérer les propriétés de style d'une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code C# vous montre comment obtenir les propriétés de style d'un style de table prédéfini :

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // change le style par défaut prédéfini 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```