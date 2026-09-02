---
title: Gérer les tableaux de présentation en .NET
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/net/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- mise en forme du texte
- style de tableau
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour .NET. Découvrez des exemples de code C# simples pour simplifier vos flux de travail de tableaux."
---
## **Introduction**

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. L'information dans une grille de cellules (organisees en lignes et colonnes) est simple et facile a comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/fr/net/aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/fr/net/aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/) et d'autres types pour vous permettre de creer, mettre a jour et gerer des tableaux dans tous les types de presentations. 

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) .
2. Obtenez la référence d'une diapositive via son indice. 
3. Définissez un tableau `columnWidth` .
4. Définissez un tableau `rowHeight` .
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) à la diapositive grâce à la méthode [AddTable](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addtable/) .
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/) pour appliquer le formatage aux bordures supérieures, inferieures, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau. 
8. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/) . 
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/textframe/) .
10. Enregistrez la présentation modifiee.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Ajoute une forme de tableau à la diapositive
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
// Fusionne les cellules 1 et 2 de la ligne 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Ajoute du texte à la cellule fusionnée
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Enregistre la présentation sur le disque
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, la numerotation des cellules est simple et commence a zero. La première cellule d'un tableau a l'indice 0,0 (colonne 0, ligne 0). 

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numerotees ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code C# cree le tableau standard 4 × 4 numerote ci-dessous et definit le format des bordures pour chacune de ses cellules :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Accéder à un tableau existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) .
2. Obtenez une référence à la diapositive contenant le tableau via son indice. 
3. Créez un objet [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) et le définir sur null. 
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) jusqu\'à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez ne contient qu\'un seul tableau, vous pouvez simplement verifier toutes les formes qu\'elle contient. Lorsqu\'une forme est identifiee comme un tableau, vous pouvez la convertir en un objet [Table](https://reference.aspose.com/slides/fr/net/aspose.slides/table/) . Mais si la diapositive contient plusieurs tableaux, il est prefere de rechercher le tableau necessaire via son [AlternativeText](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/alternativetext/) .

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) pour travailler avec le tableau. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne au tableau. 
6. Enregistrez la présentation modifiee.

```c#
using Aspose.Slides;

// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Initialise le TableEx à null
    ITable tbl = null;

    // Parcourt les formes et définit une référence au tableau trouvé
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Définit le texte pour la première colonne de la deuxième ligne
    tbl[0, 1].TextFrame.Text = "New";

    // Enregistre la présentation modifiée sur le disque
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) d'un tableau, utilisez la propriété [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) pour récupérer la [ICell](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/) propriétaire. Pour un cadre de texte d'une cellule de tableau, [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) est défini et [ITextFrame.ParentShape](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentshape/) est `null`, bien que le tableau lui‑même soit une forme.

Les coordonnées de la cellule sont disponibles via les propriétés en lecture seule [ICell.FirstColumnIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/firstcolumnindex/) et [ICell.FirstRowIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/firstrowindex/) . [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) est également en lecture seule : elle fournit une navigation vers le propriétaire mais ne change pas la possession. Vérifiez toujours que la cellule retournée n'est pas `null` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voyez [Search and Replace Text](/slides/fr/net/search-and-replace-text/) .

## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) .
2. Obtenez la référence d'une diapositive via son indice. 
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) à la diapositive. 
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) à partir du tableau. 
5. Accédez à l'[IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) de l'[ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) .
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiee.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtient la première diapositive 
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

## **Définir le format du texte au niveau du tableau**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) classe.
2. Obtenez la référence d'une diapositive via son indice. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) depuis la diapositive.
4. Définissez la [FontHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/fontheight/) pour le texte. 
5. Définissez l'[Alignment](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/alignment/) et le [MarginRight](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/marginright/) .
6. Définissez le [TextVerticalType](https://reference.aspose.com/slides/fr/net/aspose.slides/textframeformat/textverticaltype/) .
7. Enregistrez la présentation modifiee. 

```c#
using Aspose.Slides;

// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supposons que la première forme de la première diapositive est un tableau

// Définit la hauteur de police des cellules du tableau
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Définit l'alignement du texte et la marge droite des cellules du tableau en un appel
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Définit le type vertical du texte des cellules du tableau
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez utiliser ces détails pour un autre tableau ou ailleurs. Ce code C# montre comment obtenir les propriétés de style à partir d'un style de tableau prédéfini :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // modifier le thème du style prédéfini par défaut

    // Obtenir le style prédéfini du tableau.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Appliquer le style prédéfini récupéré à un autre tableau.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Verrouiller le rapport d'aspect d'un tableau**

Le rapport d'aspect d'une forme géométrique est le rapport de ses dimensions dans différentes directions. Aspose.Slides fournit la propriété `AspectRatioLocked` pour vous permettre de verrouiller le réglage du rapport d'aspect pour les tableaux et autres formes. 

Ce code C# montre comment verrouiller le rapport d'aspect pour un tableau :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte dans ses cellules ?**

Oui. Le tableau expose une propriété [RightToLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/table/righttoleft/) , et les paragraphes possèdent [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraphformat/righttoleft/) . Utiliser les deux garantit le bon ordre RTL et le rendu correct à l'intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [shape locks](/slides/fr/net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tableaux.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).