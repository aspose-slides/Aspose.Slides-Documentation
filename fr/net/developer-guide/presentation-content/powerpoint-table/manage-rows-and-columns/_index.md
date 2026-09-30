---
title: Gérer les lignes et les colonnes des tableaux PowerPoint en .NET
linktitle: Lignes et Colonnes
type: docs
weight: 20
url: /fr/net/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en‑tête de tableau
- cloner ligne
- cloner colonne
- copier ligne
- copier colonne
- supprimer ligne
- supprimer colonne
- formatage du texte de la ligne
- formatage du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les lignes et les colonnes des tableaux PowerPoint avec Aspose.Slides pour .NET et accélérez la modification des présentations ainsi que les mises à jour de données."
---
## **Introduction**

Aspose.Slides for .NET vous permet de gérer la structure et le formatage des tables dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) et l’interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Vous pouvez désigner une ligne d’en‑tête, cloner ou supprimer des lignes et des colonnes, et appliquer le formatage du texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples C#. Il montre également comment récupérer le préréglage de style d’une table afin de le réutiliser. Les indices des lignes et des colonnes d’une table commencent à zéro.

## **Contrôler la hauteur des lignes**

Utilisez [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une borne inférieure, pas d’une hauteur fixe. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) renvoie la hauteur réelle et est en lecture seule. Accédez à la ligne via [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient une table comme première forme sur la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial de 18 points, un renvoi à la ligne et des marges supérieures et inférieures de 6 points ; le texte plus long dans la deuxième colonne se renvoie sur plusieurs lignes. L’exemple augmente le minimum à 100 points, puis le diminue à 20 points, imprime la hauteur réelle après chaque modification et enregistre les deux résultats.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Avec la présentation fournie, augmenter le minimum ajoute de l’espace à la ligne. Le diminuer supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points parce que le texte et les marges des cellules nécessitent plus de place. Réduire seulement le minimum ne peut pas forcer la ligne en dessous de l’espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d’espace vertical.  
- **Renvoi à la ligne et largeur de colonne :** avec le renvoi activé, une [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) plus étroite peut générer plus de lignes. Une colonne plus large peut réduire l’espace vertical requis.  
- **Marges de cellule :** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) et [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) ajoutent de l’espace vertical. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) et [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) réduisent la largeur disponible pour le texte et peuvent provoquer un renvoi supplémentaire.

Pour cette table sans cellules fusionnées, la cellule qui nécessite le plus d’espace vertical détermine la limite inférieure imposée par le contenu pour toute la ligne. Pour raccourcir la ligne, il peut également être nécessaire de raccourcir le texte, de réduire la taille de la police ou les marges, ou d’élargir une colonne.

Les images ci‑dessous montrent la même table à la même échelle. Dans cet exemple, les hauteurs réelles étaient de 70, 100 et 55,2 points : la ligne finale est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [increased minimum](row-height-increased.pptx) et [decreased minimum](row-height-decreased.pptx).

| Original : minimum 70 pt, actual 70 pt | Increased : minimum 100 pt, actual 100 pt | Decreased : minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après avoir augmenté le minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après avoir diminué le minimum de la première ligne à 20 points ; le texte renvoyé garde la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Définir la première ligne comme en‑tête**

Utilisez la propriété [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Accédez à la table stockée comme première forme sur la diapositive.  
4. Activez le format d’en‑tête pour sa première ligne.  
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant une table comme première forme sur la première diapositive. Il active le format d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Cloner une ligne ou une colonne de tableau**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin du tableau ou l’insérer à une position spécifique.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs de colonnes et les hauteurs de lignes.  
4. Ajoutez une table avec la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).  
5. Clonez les lignes requises.  
6. Clonez les colonnes requises.  
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` contenant au moins une diapositive. Il crée une table de trois colonnes et cinq lignes, avec des dimensions spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’indice 3 (quatrième position). La table résultante possède sept lignes et cinq colonnes. L’argument `false` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; cette table ne possède pas de cellules fusionnées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Supprimer une ligne ou une colonne d'un tableau**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans une table. La suppression d’un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs de colonnes et les hauteurs de lignes.  
4. Ajoutez une table avec la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).  
5. Supprimez la deuxième ligne et la deuxième colonne.  
6. Enregistrez la présentation modifiée.

Cet exemple crée une table trois‑par‑trois et supprime la ligne et la colonne à l’indice 1, laissant une table deux‑par‑deux dans `TestTable_out.pptx`. Les dimensions sont en points. L’argument `false` désactive la suppression de lignes ou colonnes fusionnées adjacentes ; cette table ne possède pas de cellules fusionnées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Définir le formatage du texte au niveau de la ligne du tableau**

Appliquez le formatage du texte à une ligne entière pour garder la cohérence des cellules. Vous pouvez définir les propriétés de police, le formatage des paragraphes et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Accédez à la table sur la première diapositive.  
3. Définissez [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pour la première ligne.  
4. Définissez [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) pour la première ligne.  
5. Définissez [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) pour la deuxième ligne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant une table comme première forme sur la première diapositive et au moins deux lignes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première ligne, puis définit le texte vertical dans la deuxième ligne.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Définir le formatage du texte au niveau de la colonne du tableau**

Appliquez le formatage du texte à une colonne entière pour garder la cohérence des cellules. Vous pouvez définir les propriétés de police, le formatage des paragraphes et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Accédez à la table sur la première diapositive.  
3. Définissez [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pour la première colonne.  
4. Définissez [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) pour la première colonne.  
5. Définissez [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) pour la deuxième colonne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant une table comme première forme sur la première diapositive et au moins deux colonnes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première colonne, puis définit le texte vertical dans la deuxième colonne.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Obtenir les propriétés du style de tableau**

Utilisez la propriété [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) pour récupérer le préréglage appliqué à une table et le réutiliser sur une autre table. Cela identifie le préréglage plutôt que les modifications de formatage individuelles des cellules.

L’exemple crée une table, applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), puis lit le préréglage. Il affiche `DarkStyle1` et enregistre la table dans `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à une table déjà créée ?**

Oui. La table hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs du texte par-dessus ce thème.

**Puis‑je trier les lignes d’une table comme dans Excel ?**

Non, les tables Aspose.Slides ne possèdent pas de fonction de tri ou de filtres intégrée. Triez d’abord vos données en mémoire, puis repopulez les lignes de la table dans cet ordre.

**Puis‑je avoir des colonnes à bandes (zébrées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule l’emporte sur le style du tableau.