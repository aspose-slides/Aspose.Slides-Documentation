---
title: Gérer les lignes et les colonnes des tableaux PowerPoint avec JavaScript
linktitle: Lignes et Colonnes
type: docs
weight: 20
url: /fr/nodejs-java/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête de tableau
- cloner la ligne
- cloner la colonne
- copier la ligne
- copier la colonne
- supprimer la ligne
- supprimer la colonne
- formatage du texte de la ligne
- formatage du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les lignes et les colonnes d'un tableau PowerPoint avec JavaScript et Aspose.Slides pour Node.js via Java, et accélérez la modification des présentations ainsi que les mises à jour de données."
---
## **Introduction**

Aspose.Slides for Node.js via Java vous permet de gérer la structure et le formatage des tableaux dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) . Vous pouvez désigner une ligne d'en‑tête, dupliquer ou supprimer des lignes et des colonnes, et appliquer un formatage de texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples JavaScript. Il montre également comment récupérer le préréglage de style d'un tableau afin de le réutiliser. Les indices des lignes et des colonnes d'un tableau commencent à zéro.

## **Control Row Height**

Utilisez [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) pour définir la hauteur minimale d'une ligne en points. Il s'agit d'une limite inférieure, et non d'une hauteur fixe. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) renvoie la hauteur réelle. Accédez à la ligne via [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

L'exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme de la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial 18 points, avec retour à la ligne, et des marges supérieures et inférieures de 6 points ; le texte plus long de la deuxième colonne s'étend sur plusieurs lignes. L'exemple augmente le minimum à 100 points, puis le réduit à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Avec la présentation fournie, augmenter le minimum ajoute de l'espace à la ligne. Le réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points car le texte et les marges des cellules nécessitent plus d'espace. Réduire le minimum seul ne peut pas forcer la ligne à être inférieure à l'espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d'espace vertical.
- **Retour à la ligne et largeur de colonne :** avec le retour à la ligne activé, réduire la largeur de la colonne avec [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) peut créer plus de lignes. Une colonne plus large peut réduire l'espace vertical requis.
- **Marges des cellules :** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) et [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) ajoutent de l'espace vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) et [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) réduisent la largeur disponible pour le texte et peuvent provoquer un retour à la ligne supplémentaire.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d'espace vertical détermine la limite inférieure imposée par le contenu pour toute la ligne. Pour raccourcir la ligne, vous devrez peut-être aussi réduire le texte, diminuer la taille de la police ou les marges, ou élargir une colonne.

Les images ci-dessous montrent le même tableau à la même échelle. Dans les résultats illustrés, les hauteurs réelles étaient de 70, 100 et 55,2 points : la dernière ligne est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [minimum augmenté](row-height-increased.pptx) et [minimum réduit](row-height-decreased.pptx).

| Original : minimum 70 pt, hauteur réelle 70 pt | Augmenté : minimum 100 pt, hauteur réelle 100 pt | Réduit : minimum 20 pt, hauteur réelle 55,2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après avoir augmenté le minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après avoir diminué le minimum de la première ligne à 20 points ; le texte renvoyé à la ligne maintient la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Utilisez la méthode [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Accédez au tableau stocké comme première forme sur la diapositive.
4. Activez le format d'en‑tête pour sa première ligne.
5. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` contenant un tableau comme première forme de la première diapositive. Il active le format d'en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clone a Table Row or Column**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin du tableau ou l'insérer à une position spécifique.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Clonez les lignes requises.
6. Clonez les colonnes requises.
7. Enregistrez la présentation modifiée.

L'exemple nécessite `Test.pptx` avec au moins une diapositive. Il crée un tableau avec trois colonnes et cinq lignes, les dimensions étant spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l'index 3 (la quatrième position). Le tableau résultant possède sept lignes et cinq colonnes. L'argument `false` désactive le clonage dans des lignes ou colonnes fusionnées adjacentes ; ce tableau n'a pas de cellules fusionnées.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remove a Row or Column from a Table**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans un tableau. La suppression d'un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Supprimez la deuxième ligne et la deuxième colonne.
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau de trois par trois et supprime la ligne et la colonne à l'index 1, laissant un tableau de deux par deux dans `TestTable_out.pptx`. Les dimensions sont en points. L'argument `false` désactive la suppression de lignes ou colonnes fusionnées adjacentes ; ce tableau n'a pas de cellules fusionnées.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Row Level**

Appliquez un formatage de texte à une ligne entière pour garder ses cellules cohérentes. Vous pouvez définir les propriétés de police, le formatage du paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pour la première ligne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pour la première ligne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième ligne.
6. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` avec un tableau comme première forme sur la première diapositive et au moins deux lignes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première ligne, puis définit du texte vertical dans la deuxième ligne.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Column Level**

Appliquez un formatage de texte à une colonne entière pour garder ses cellules cohérentes. Vous pouvez définir les propriétés de police, le formatage du paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pour la première colonne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pour la première colonne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième colonne.
6. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` avec un tableau comme première forme sur la première diapositive et au moins deux colonnes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première colonne, puis définit du texte vertical dans la deuxième colonne.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get Table Style Properties**

Utilisez la méthode [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) pour récupérer le préréglage appliqué à un tableau et le réutiliser sur un autre tableau. Cela identifie le préréglage plutôt que les remplacements de formatage individuels des cellules.

L'exemple crée un tableau, applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1), puis lit le préréglage. Il affiche la valeur entière correspondant à `DarkStyle1` et enregistre le tableau dans `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs du texte par-dessus ce thème.

**Puis-je trier les lignes d'un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides n'ont pas de tri ou de filtres intégrés. Triez d'abord vos données en mémoire, puis remplissez à nouveau les lignes du tableau dans cet ordre.

**Puis-je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques par un formatage local ; le formatage au niveau de la cellule prime sur le style du tableau.