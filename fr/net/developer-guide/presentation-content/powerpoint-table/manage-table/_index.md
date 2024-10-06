---
title: Gérer la Table
type: docs
weight: 10
url: /net/manage-table/
keywords: "Table, créer une table, accéder à la table, rapport d'aspect de la table, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer et gérer une table dans des présentations PowerPoint en C# ou .NET"
---

Une table dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations dans une grille de cellules (organisées en lignes et en colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tables dans tous les types de présentations.

## **Créer une Table de Zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Itérez à travers chaque [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) pour appliquer un formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne de la table.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code C# vous montre comment créer une table dans une présentation :

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Définit des colonnes avec des largeurs et des lignes avec des hauteurs
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Ajoute une forme de table à la diapositive
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Définit le format de bordure pour chaque cellule
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Fusionne les cellules 1 & 2 de la ligne 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Ajoute du texte à la cellule fusionnée
tbl.Rows[0][0].TextFrame.Text = "Cellules fusionnées";

// Enregistre la présentation sur le disque
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numérotation dans une Table Standard**

Dans une table standard, la numérotation des cellules est simple et indexée à partir de zéro. La première cellule d'une table est indexée comme 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d'une table avec 4 colonnes et 4 lignes sont numérotées de cette manière :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code C# vous montre comment spécifier la numérotation pour les cellules dans une table :

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Définit des colonnes avec des largeurs et des lignes avec des hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de table à la diapositive
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Enregistre la présentation sur le disque
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Accéder à une Table Existante**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive contenant la table via son index.
3. Créez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) et définissez-le sur null.
4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) jusqu'à ce que la table soit trouvée.

   Si vous soupçonnez que la diapositive avec laquelle vous traitez contient une seule table, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsque vous identifiez une forme comme une table, vous pouvez la typecaster comme un objet [Table](https://reference.aspose.com/slides/net/aspose.slides/table/). Mais si la diapositive avec laquelle vous traitez contient plusieurs tables, alors il est préférable de rechercher la table dont vous avez besoin via son [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pour travailler avec la table. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne à la table.
6. Enregistrez la présentation modifiée.

Ce code C# vous montre comment accéder à une table existante et y travailler :

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Initialise null TableEx
    ITable tbl = null;

    // Itère à travers les formes et définit une référence à la table trouvée
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Définit le texte pour la première colonne de la deuxième ligne
    tbl[0, 1].TextFrame.Text = "Nouveau";

    // Enregistre la présentation modifiée sur le disque
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Aligner le Texte dans la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive via son index.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) à partir de la table.
5. Accédez à l'[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) de l'[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code C# vous montre comment aligner le texte dans une table :

```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtient la première diapositive 
ISlide slide = presentation.Slides[0];

// Définit des colonnes avec des largeurs et des lignes avec des hauteurs
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Ajoute la forme de table à la diapositive
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accède au cadre de texte
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Crée l'objet Paragraph pour le cadre de texte
IParagraph paragraph = txtFrame.Paragraphs[0];

// Crée l'objet Portion pour le paragraphe
IPortion portion = paragraph.Portions[0];
portion.Text = "Texte ici";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligne le texte verticalement
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Enregistre la présentation sur le disque
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Définir le Formatage du Texte au Niveau de la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive via son index.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à partir de la diapositive.
4. Définissez la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pour le texte.
5. Définissez l'[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et le [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Définissez le [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Enregistrez la présentation modifiée.

Ce code C# vous montre comment appliquer vos options de formatage préférées au texte dans une table :

```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supposons que la première forme de la première diapositive soit une table

// Définit la hauteur de police des cellules de la table
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Définit l'alignement du texte et la marge droite des cellules de la table en un seul appel
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Définit le type de texte vertical des cellules de la table
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Obtenir les Propriétés de Style de la Table**

Aspose.Slides vous permet de récupérer les propriétés de style d'une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code C# vous montre comment obtenir les propriétés de style à partir d'un style prédéfini de table :

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // change le style prédéfini par défaut 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Verrouiller le Rapport d'Aspect de la Table**

Le rapport d'aspect d'une forme géométrique est le rapport de ses tailles dans différentes dimensions. Aspose.Slides propose la propriété `AspectRatioLocked` pour vous permettre de verrouiller le paramètre de rapport d'aspect pour les tables et autres formes.

Ce code C# vous montre comment verrouiller le rapport d'aspect pour une table :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Verrouiller le rapport d'aspect défini : {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // inverse

    Console.WriteLine($"Verrouiller le rapport d'aspect défini : {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```