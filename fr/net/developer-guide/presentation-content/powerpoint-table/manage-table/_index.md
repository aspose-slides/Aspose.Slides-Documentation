---
title: Gérer les tableaux de présentation dans .NET
linktitle: Gérer le tableau
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
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour .NET. Découvrez des exemples de code C# simples pour rationaliser vos flux de travail de tableaux."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , la classe [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) ainsi que d'autres types pour vous permettre de créer, mettre à jour et gérer les tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

Créez un tableau en spécifiant sa position, la largeur des colonnes et la hauteur des lignes. Après l'avoir ajouté à une diapositive, vous pouvez formater les bordures des cellules, fusionner des cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Définissez un tableau des largeurs de colonnes en points.
4. Définissez un tableau des hauteurs de lignes en points.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa propriété [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) .
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple ci‑dessous crée un tableau de trois colonnes et cinq lignes à (100, 50) points. Il applique des bordures rouges d'une largeur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous le nom `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les indices des cellules sont basés sur zéro et utilisent l'ordre (colonne, ligne). La première cellule a pour indice (0, 0).

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et des hauteurs de lignes de 70 points et des bordures de cellules rouges d'une largeur de 5 points. Les coordonnées illustrent les indices des cellules ; l'exemple laisse les cellules vides et enregistre le tableau sous le nom `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d'une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive contenant le tableau par son indice.
3. Parcourez les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) et arrêtez‑vous lorsqu'un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `UpdateExistingTable.pptx` et trouve le premier tableau de la première diapositive. Il définit la cellule à la colonne 0, ligne 1 sur `New` et enregistre le résultat sous le nom `table1_out.pptx`. L'entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit comporter au moins une colonne et deux lignes.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser le minimum demandé, consultez [Contrôler la hauteur de ligne](/slides/fr/net/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) d'un tableau, utilisez la propriété [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) pour récupérer la [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) propriétaire. Pour un cadre de texte de cellule de tableau, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) est défini et [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) vaut `null`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les propriétés en lecture seule [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) et [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) est également en lecture seule : il permet de naviguer vers le propriétaire sans en changer la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `null` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voyez [Recherche et remplacement de texte](/slides/fr/net/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l'ancrage vertical et la direction du texte des cellules individuelles d'un tableau. L'exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) du tableau.
5. Accédez au premier [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) et définissez son texte et sa couleur.
6. Définissez le [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) et le [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) de la cellule.
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il formate le texte de la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne et enregistre le résultat sous le nom `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Définir le format du texte au niveau du tableau**

Utilisez [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) pour appliquer le formatage du texte à toutes les cellules d'un tableau. Ses surcharges acceptent le formatage de portion, de paragraphe et de cadre de texte, ce qui vous permet de définir ces propriétés sans parcourir les cellules individuellement.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) de la diapositive.
4. Définissez la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pour le texte.
5. Définissez l'[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et le [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Définissez le [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il fixe la taille de police à 25 points, aligne les paragraphes à droite avec une marge droite de 20 points et rend le texte vertical. La présentation formatée est enregistrée sous le nom `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Obtenir les propriétés de style du tableau**

Utilisez [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) pour lire ou assigner un style pré‑défini à un tableau. Cet exemple applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) à un tableau, affiche le nom du style pré‑défini et assigne le même style à un deuxième tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Verrouiller le ratio d'aspect d'un tableau**

Le ratio d'aspect d'un tableau est le rapport entre sa largeur et sa hauteur. Utilisez [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) pour verrouiller ce ratio pour un tableau.

L'exemple ci‑dessous ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l'état actuel du verrouillage, active le verrouillage du ratio d'aspect, affiche l'état mis à jour (`True`) et enregistre le résultat sous le nom `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte dans ses cellules ?**

Oui. Le tableau expose une propriété [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , et les paragraphes possèdent [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . En utilisant les deux, vous assurez l'ordre RTL correct et le rendu à l'intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [verrous de forme](/slides/fr/net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tableaux.

**L'insertion d'une image dans une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).