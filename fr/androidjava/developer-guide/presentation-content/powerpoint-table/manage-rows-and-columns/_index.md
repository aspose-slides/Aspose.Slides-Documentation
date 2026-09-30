---
title: Gérer les lignes et colonnes des tableaux PowerPoint sur Android
linktitle: Lignes et Colonnes
type: docs
weight: 20
url: /fr/androidjava/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête de tableau
- cloner ligne
- cloner colonne
- copier ligne
- copier colonne
- supprimer ligne
- supprimer colonne
- mise en forme du texte de la ligne
- mise en forme du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérer les lignes et colonnes des tableaux PowerPoint avec Aspose.Slides pour Android via Java et accélérer l'édition de présentations et les mises à jour de données."
---
## **Introduction**

Aspose.Slides for Android via Java vous permet de gérer la structure et la mise en forme des tableaux dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) et l’interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Vous pouvez désigner une ligne d’en-tête, cloner ou supprimer des lignes et des colonnes, et appliquer une mise en forme du texte à une ligne ou une colonne entière.

Cet article explique ces opérations à l’aide d’exemples Java. Il montre également comment récupérer le préréglage de style d’un tableau afin de le réutiliser. Les indices des lignes et des colonnes d’un tableau sont basés sur zéro.

## **Control Row Height**

Utilisez [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une limite inférieure, pas d’une hauteur fixe. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) renvoie la hauteur réelle. Accédez à la ligne via [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme sur la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial de 18 points, avec retour à la ligne et des marges supérieures et inférieures de 6 points ; le texte plus long dans la deuxième colonne s’enroule sur plusieurs lignes. L’exemple augmente la hauteur minimale à 100 points, puis la réduit à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Avec la présentation fournie, augmenter la hauteur minimale ajoute de l’espace à la ligne. La réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points parce que le texte et les marges des cellules nécessitent plus d’espace. Réduire uniquement la hauteur minimale ne peut pas forcer la ligne en dessous de l’espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d’espace vertical.
- **Enroulement et largeur de colonne :** avec l’enroulement activé, réduire la largeur de colonne avec [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) peut créer davantage de lignes. Une colonne plus large peut réduire l’espace vertical requis.
- **Marges des cellules :** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) et [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) ajoutent de l’espace vertical. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) et [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) réduisent la largeur disponible pour le texte et peuvent entraîner un enroulement supplémentaire.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d’espace vertical détermine la limite inférieure dictée par le contenu pour l’ensemble de la ligne. Pour raccourcir la ligne, il peut également être nécessaire de raccourcir le texte, de réduire la taille de police ou les marges, ou d’élargir une colonne.

Les images ci‑dessous montrent le même tableau à la même échelle. Dans les résultats illustrés, les hauteurs réelles étaient de 70, 100 et 55,2 points : la ligne finale est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier en fonction des polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [increased minimum](row-height-increased.pptx) et [decreased minimum](row-height-decreased.pptx).

| Original : minimum 70 pt, actual 70 pt | Increased : minimum 100 pt, actual 100 pt | Decreased : minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Utilisez la méthode [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Accédez au tableau stocké comme première forme sur la diapositive.
4. Activez la mise en forme d’en‑tête pour sa première ligne.
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive. Il active la mise en forme d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clone a Table Row or Column**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur mise en forme. Vous pouvez ajouter une copie à la fin du tableau ou l’insérer à une position précise.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Clonez les lignes requises.
6. Clonez les colonnes requises.
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` contenant au moins une diapositive. Il crée un tableau de trois colonnes et cinq lignes, avec des dimensions spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’indice 3 (la quatrième position). Le tableau résultant possède sept lignes et cinq colonnes. L’argument `false` désactive le clonage dans des lignes ou colonnes fusionnées adjacentes ; ce tableau n’a aucune cellule fusionnée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remove a Row or Column from a Table**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans un tableau. La suppression d’un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Supprimez la deuxième ligne et la deuxième colonne.
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau trois‑par‑trois et supprime la ligne et la colonne à l’indice 1, laissant un tableau deux‑par‑deux dans `TestTable_out.pptx`. Les dimensions sont en points. L’argument `false` désactive la suppression de lignes ou colonnes fusionnées adjacentes ; ce tableau n’a aucune cellule fusionnée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Row Level**

Appliquez une mise en forme du texte à une ligne entière afin d’assurer la cohérence de ses cellules. Vous pouvez définir les propriétés de police, la mise en forme des paragraphes et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour la première ligne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pour la première ligne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième ligne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux lignes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première ligne, puis définit du texte vertical dans la deuxième ligne.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Column Level**

Appliquez une mise en forme du texte à une colonne entière afin d’assurer la cohérence de ses cellules. Vous pouvez définir les propriétés de police, la mise en forme des paragraphes et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour la première colonne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pour la première colonne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième colonne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux colonnes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première colonne, puis définit du texte vertical dans la deuxième colonne.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get Table Style Properties**

Utilisez la méthode [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) pour récupérer le préréglage appliqué à un tableau et le réutiliser sur un autre tableau. Cela identifie le préréglage plutôt que les remplacements de mise en forme individuels des cellules.

L’exemple crée un tableau, applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) et lit le préréglage. Il affiche la valeur entière correspondant à `DarkStyle1` et enregistre le tableau dans `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je appliquer des thèmes ou styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive / mise en page / maître, et vous pouvez toujours remplacer les remplissages, bordures et couleurs de texte par‑dessus.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides n’ont pas de tri ou de filtres intégrés. Triez vos données en mémoire d’abord, puis reconstituez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec une mise en forme locale ; la mise en forme au niveau de la cellule prime sur le style du tableau.