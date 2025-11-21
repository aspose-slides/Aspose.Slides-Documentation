---
title: Gérer les tables de présentation dans .NET
linktitle: Gérer la table
type: docs
weight: 10
url: /fr/net/manage-table/
keywords:
- ajouter tableau
- créer tableau
- accéder tableau
- ratio d'aspect
- aligner texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et modifier des tables dans les diapositives PowerPoint avec Aspose.Slides pour .NET. Découvrez des exemples de code C# simples pour simplifier vos flux de travail de tables."
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de représenter des informations. Les informations dans une grille de cellules (arrangées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit les classes [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) et d’autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans toutes sortes de présentations. 

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtenez une référence à une diapositive via son indice. 
3. Définissez un tableau de `columnWidth` .
4. Définissez un tableau de `rowHeight` .
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau. 
8. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) . 
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) .
10. Enregistrez la présentation modifiée.

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Ajoute une forme de tableau à la diapositive
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Définit le format des bordures pour chaque cellule
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
// Fusionne les cellules 1 et 2 de la ligne 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Ajoute du texte à la cellule fusionnée
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Enregistre la présentation sur le disque
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **Numérotation dans un tableau standard**

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d’un tableau est indexée comme 0,0 (colonne 0, ligne 0). 

Par exemple, les cellules d’un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format des bordures pour chaque cellule
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


## **Accéder à un tableau existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtenez une référence à la diapositive contenant le tableau via son indice. 
3. Créez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) et affectez‑lui la valeur null.
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) jusqu’à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez ne contient qu’un seul tableau, vous pouvez simplement vérifier toutes les formes qu’elle contient. Lorsqu’une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) . Mais si la diapositive contient plusieurs tableaux, il est préférable de rechercher le tableau dont vous avez besoin via son [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) .
5. Utilisez l’objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pour travailler avec le tableau. Dans l’exemple ci‑dessous, nous avons ajouté une nouvelle ligne au tableau.
6. Enregistrez la présentation modifiée.

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Initialise le TableEx à null
    ITable tbl = null;

    // Parcourt les formes et définit une référence vers le tableau trouvé
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Définit le texte pour la première colonne de la deuxième ligne
    tbl[0, 1].TextFrame.Text = "New";

    // Enregistre la présentation modifiée sur le disque
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtenez une référence à une diapositive via son indice. 
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive. 
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) depuis le tableau. 
5. Accédez au [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) du [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();

// Récupère la première diapositive
ISlide slide = presentation.Slides[0];

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Ajoute la forme de tableau à la diapositive
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
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligne le texte verticalement
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Enregistre la présentation sur le disque
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **Définir le formatage du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive via son indice. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) depuis la diapositive.
4. Définissez la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) du texte. 
5. Définissez les propriétés [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Définissez la [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Enregistrez la présentation modifiée. 

```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supposons que la première forme de la première diapositive soit un tableau

// Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de pouvoir réutiliser ces informations pour un autre tableau ou ailleurs. Ce code C# montre comment obtenir les propriétés de style à partir d’un style prédéfini de tableau : 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // modifie le thème de style prédéfini par défaut
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Verrouiller le ratio d’aspect du tableau**

Le ratio d’aspect d’une forme géométrique est le rapport de ses dimensions dans les différents axes. Aspose.Slides propose la propriété `AspectRatioLocked` pour vous permettre de verrouiller le réglage du ratio d’aspect pour les tableaux et d’autres formes. 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // inverser

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau possède une propriété [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , et les paragraphes ont [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . En utilisant les deux, vous assurez le bon ordre RTL et le rendu correct à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [verrous de forme](/slides/fr/net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).