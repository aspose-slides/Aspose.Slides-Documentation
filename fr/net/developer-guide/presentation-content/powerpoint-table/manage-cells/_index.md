---
title: Gérer les cellules de tableau dans les présentations en .NET
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/net/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en C#: identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière-plan ainsi que les images avec Aspose.Slides pour .NET."
---
## **Aperçu**

Aspose.Slides vous permet d’accéder aux cellules d’un tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou division, changer la couleur d’arrière‑plan d’une cellule et ajouter une image à l’intérieur d’une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le format des cellules via leurs propriétés, et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro pour accéder aux cellules de tableau dans l’ordre `(column, row)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est bien un tableau. Il parcourt ensuite toutes les lignes et toutes les colonnes et utilise [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) pour identifier les cellules dans des zones fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l’ordre `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), ainsi que les coordonnées de départ de la région, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) et [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Supprimer les bordures des cellules du tableau**

Créez une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Les largeurs des colonnes, les hauteurs des lignes et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de chaque cellule sur [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), les rendant invisibles.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Ajouter des bordures de cellule diagonales**

Utilisez [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) pour tracer une ligne du coin supérieur gauche vers le coin inférieur droit, et [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) pour tracer une ligne du coin inférieur gauche vers le coin supérieur droit. Une diagonale peut marquer un en‑tête de coin ; les deux diagonales peuvent former un X pour indiquer qu’une cellule n’est pas applicable.

Chaque diagonale est un [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Dans son [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), définissez [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) sur [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) et choisissez une [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Réglez la [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) de la ligne en points.

L’exemple crée trois cellules dans une même ligne : une diagonale rouge descendante, une diagonale bleue ascendante et les deux diagonales. Il laisse les bordures supérieure, inférieure, gauche et droite inchangées.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Une diagonale est une propriété de formatage, pas une division de cellule. Chaque cellule conserve un seul [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) ; les zones de part et d’autre d’une diagonale ne peuvent pas être éditées indépendamment.

Le tableau enregistré, rendu dans Microsoft PowerPoint :

![Trois cellules de tableau montrant une diagonale rouge du coin supérieur gauche au coin inférieur droit, une diagonale bleue du coin inférieur gauche au coin supérieur droit, et les deux diagonales formant un X.](diagonal-cell-borders.png)

*De gauche à droite : diagonale descendante (rouge, 3 pt), diagonale ascendante (bleu, 5 pt) et les deux diagonales.*

## **Fusionner des cellules de tableau**

Utilisez [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Indiquez les cellules aux coins supérieurs gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4 × 4 avec des colonnes et des lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s’étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au format de la cellule fusionnée, utilisez sa position en haut à gauche : `table[1, 1]` dans cet exemple. Les autres positions de la plage fusionnée restent parties de la grille du tableau, de sorte que les indices des cellules situées en dehors de la plage ne changent pas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Diviser des cellules de tableau**

La fusion des cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne dans la grille et modifier les indices de colonne des cellules situées à droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et des lignes de 70 points et appelle [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table[1, 1]` et `table[2, 1]`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à l’alimentation de données, utilisez [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) pour diviser le long d’une frontière de ligne existante, ou [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) pour diviser le long d’une frontière de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Division de colonne : `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec les cellules `(1, 2)` et `(1, 3)` fusionnées verticalement. En partant de la position inférieure, il utilise [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) et [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) pour localiser l’origine et vérifie les deux étendues. `SplitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale de deux colonnes, utilisez plutôt `SplitByColSpan(1)`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Récupérer les cellules résultantes du tableau après la division.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) renvoie `False`. Des zones plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son format restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du format de la cellule (remplissage, bordures, marges). Remplissez les cellules après la division et définissez explicitement tout format de texte requis.

La présentation enregistrée contient les cellules distinctes « Product A » et « Product B » avec le format du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) pour plus de détails.

<!-- visual-explanation:manage-cells:start -->
[![La cellule fusionnée à la colonne 1, lignes 2 et 3 se divise en Product A et Product B avec les mêmes indices de grille.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*La division en étendue de ligne utilise la frontière existante. Product A et Product B occupent respectivement (1, 2) et (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Diviser une cellule à une hauteur spécifique**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) prend la hauteur de la partie supérieure en points. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) prend le nombre de lignes de la grille existante dans la partie supérieure. Pour centrer une cellule de 40 points dans la colonne de droite, soustrayez 40 de la hauteur réelle de la cellule et répartissez l’espace restant également au-dessus et en dessous.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

La première division ajoute une ligne à la grille, laissant les 90 points inférieurs à `[1, 1]`. La seconde division cible cette cellule et ajoute une autre ligne en dessous. La colonne de droite contient maintenant `[1, 0]` à 50 points (`margin`), `[1, 1]` à 40 points, et `[1, 2]` à 50 points (`margin`). La cellule de gauche s’étend sur les trois lignes à sa hauteur d’origine de 140 points.

![La cellule de gauche s’étend sur toute la hauteur du tableau à côté de trois cellules avec « Middle » au centre.](split-by-height.png)

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il définit le [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) sur solide et le [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) sur rouge pour la cellule `(2, 3)`, située dans la troisième colonne et la quatrième ligne.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Il charge l’image avec [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) et l’ajoute à la collection d’images de la présentation avec [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Il associe ensuite l’image au remplissage d’image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son ratio d’aspect. Les largeurs des colonnes et les hauteurs des lignes sont exprimées en points. L’image chargée est automatiquement libérée par son instruction using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Puis‑je définir des épaisseurs et des styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/), [bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/), [left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/) et [right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) possèdent des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer.

**Que se passe‑t‑il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les carreaux sont recalculés.

**Puis‑je attribuer un hyperlien à tout le contenu d’une cellule ?**

Les [Hyperlinks](/slides/fr/net/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre texte de la cellule ou au niveau de l’ensemble du tableau/forme. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes dans une même cellule ?**

Oui. Le cadre texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (segments) avec un formatage indépendant : famille de police, style, taille et couleur.