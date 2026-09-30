---
title: Gérer les lignes et les colonnes dans les tableaux PowerPoint avec Java
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/java/manage-rows-and-columns/
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
- mise en forme du texte de la ligne
- mise en forme du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérez les lignes et les colonnes d’un tableau dans PowerPoint avec Aspose.Slides pour Java et accélérez la modification des présentations ainsi que les mises à jour des données."
---
## **Introduction**

Aspose.Slides for Java vous permet de gérer la structure et la mise en forme des tableaux dans les présentations PowerPoint grâce aux classes [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) et à l’interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Vous pouvez désigner une ligne d’en‑tête, cloner ou supprimer des lignes et des colonnes, et appliquer la mise en forme du texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples Java. Il montre également comment récupérer le style prédéfini d’un tableau afin de le réutiliser. Les indices de lignes et de colonnes d’un tableau sont zéro‑based.

## **Contrôler la hauteur des lignes**

Utilisez [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une limite inférieure, pas d’une hauteur fixe. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) renvoie la hauteur réelle. Accédez à la ligne via [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme de la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial 18 pt, avec retour à la ligne et des marges supérieures et inférieures de 6 pt ; le texte plus long de la deuxième colonne s’enroule sur plusieurs lignes. L’exemple augmente la hauteur minimale à 100 points, puis la réduit à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

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

Avec la présentation fournie, augmenter la hauteur minimale ajoute de l’espace à la ligne. La réduire le supprime, mais la hauteur réelle reste supérieure à 20 points parce que le texte et les marges des cellules nécessitent plus d’espace. Réduire uniquement la hauteur minimale ne peut pas forcer la ligne en dessous de l’espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d’espace vertical.
- **Enroulement et largeur de colonne :** avec l’enroulement activé, réduire la largeur de colonne avec [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) peut générer davantage de lignes. Une colonne plus large peut réduire l’espace vertical requis.
- **Marges des cellules :** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) et [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) ajoutent de l’espace vertical. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) et [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) réduisent la largeur disponible pour le texte et peuvent entraîner un enroulement supplémentaire.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d’espace vertical détermine la limite inférieure imposée par le contenu pour toute la ligne. Pour raccourcir la ligne, vous devrez éventuellement réduire le texte, la taille de police ou les marges, ou élargir une colonne.

Les images ci‑dessous montrent le même tableau à la même échelle. Dans les résultats illustrés, les hauteurs réelles étaient de 70, 100 et 55,2 points : la dernière ligne est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [minimum augmenté](row-height-increased.pptx) et [minimum réduit](row-height-decreased.pptx).

| Original : minimum 70 pt, réel 70 pt | Augmenté : minimum 100 pt, réel 100 pt | Réduit : minimum 20 pt, réel 55,2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après augmentation du minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après réduction du minimum de la première ligne à 20 points ; le texte enroulé maintient la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Définir la première ligne comme en‑tête**

Utilisez la méthode [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Accédez au tableau stocké comme première forme de la diapositive.
4. Activez le format d’en‑tête pour sa première ligne.
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme de la première diapositive. Il active le format d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

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

## **Cloner une ligne ou une colonne de tableau**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur mise en forme. Vous pouvez ajouter une copie à la fin du tableau ou l’insérer à une position précise.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Clonez les lignes requises.
6. Clonez les colonnes requises.
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` contenant au moins une diapositive. Il crée un tableau de trois colonnes et cinq lignes, avec des dimensions spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’index 3 (quatrième position). Le tableau résultant possède sept lignes et cinq colonnes. Le paramètre `false` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte aucune cellule fusionnée.

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

## **Supprimer une ligne ou une colonne d’un tableau**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans un tableau. La suppression d’un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Supprimez la deuxième ligne et la deuxième colonne.
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau de trois fois trois et supprime la ligne et la colonne d’indice 1, laissant un tableau de deux fois deux dans `TestTable_out.pptx`. Les dimensions sont en points. Le paramètre `false` désactive la suppression de lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte aucune cellule fusionnée.

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

## **Définir la mise en forme du texte au niveau de la ligne du tableau**

Appliquez la mise en forme du texte à une ligne entière pour garder les cellules cohérentes. Vous pouvez définir les propriétés de police, la mise en forme des paragraphes et la direction du texte sans formater chaque cellule séparément.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez au tableau de la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour la première ligne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pour la première ligne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième ligne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme de la première diapositive et au moins deux lignes. Il applique du texte de 25 pt, un alignement à droite et une marge de paragraphe droite de 20 pt à la première ligne, puis définit le texte vertical dans la deuxième ligne.

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

## **Définir la mise en forme du texte au niveau de la colonne du tableau**

Appliquez la mise en forme du texte à une colonne entière pour garder les cellules cohérentes. Vous pouvez définir les propriétés de police, la mise en forme des paragraphes et la direction du texte sans formater chaque cellule séparément.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez au tableau de la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour la première colonne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pour la première colonne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pour la deuxième colonne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme de la première diapositive et au moins deux colonnes. Il applique du texte de 25 pt, un alignement à droite et une marge de paragraphe droite de 20 pt à la première colonne, puis définit le texte vertical dans la deuxième colonne.

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

## **Obtenir les propriétés du style de tableau**

Utilisez la méthode [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) pour récupérer le style prédéfini appliqué à un tableau et le réutiliser sur un autre tableau. Cela identifie le style plutôt que les substituts de mise en forme individuels des cellules.

L’exemple crée un tableau, applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1), puis lit à nouveau le style. Il affiche la valeur entière correspondant à `DarkStyle1` et enregistre le tableau dans `table.pptx`.

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

**Puis‑je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs de texte par-dessus ce thème.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides ne disposent pas de tri ou de filtres intégrés. Triez vos données en mémoire d’abord, puis repopulez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec une mise en forme locale ; la mise en forme au niveau de la cellule prévaut sur le style du tableau.