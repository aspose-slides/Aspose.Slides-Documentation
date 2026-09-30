---
title: Gérer les lignes et colonnes dans les tableaux PowerPoint avec PHP
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/php-java/manage-rows-and-columns/
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
- formatage du texte de ligne
- formatage du texte de colonne
- style de tableau
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les lignes et colonnes de tableau PowerPoint avec Aspose.Slides for PHP via Java et accélérez l'édition de présentations et les mises à jour de données."
---
## **Introduction**

Aspose.Slides for PHP via Java vous permet de gérer la structure et le formatage des tableaux dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Vous pouvez désigner une ligne d’en‑tête, cloner ou supprimer des lignes et des colonnes, et appliquer un formatage de texte à toute une ligne ou colonne.

Cet article explique ces opérations avec des exemples PHP. Il montre également comment récupérer le style prédéfini d’un tableau afin de le réutiliser. Les indices des lignes et des colonnes d’un tableau sont basés sur zéro.

## **Contrôle de la hauteur des lignes**

Utilisez [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une borne inférieure, pas d’une hauteur fixe. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) renvoie la hauteur réelle. Accédez à la ligne via [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme sur la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial 18 points, avec retour à la ligne et des marges supérieures et inférieures de 6 points ; le texte plus long de la deuxième colonne se répartit sur plusieurs lignes. L’exemple augmente le minimum à 100 points, puis le réduit à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Avec la présentation fournie, augmenter le minimum ajoute de l’espace à la ligne. Le réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points car le texte et les marges des cellules nécessitent plus de place. Réduire uniquement le minimum ne peut pas forcer la ligne en dessous de l’espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :

- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d’espace vertical.  
- **Retour à la ligne et largeur de colonne :** avec le retour à la ligne activé, réduire la largeur de la colonne avec [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) peut produire davantage de lignes. Une colonne plus large peut réduire l’espace vertical requis.  
- **Marges des cellules :** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) et [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) ajoutent de l’espace vertical. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) et [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) réduisent la largeur disponible pour le texte et peuvent entraîner un retour à la ligne supplémentaire.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d’espace vertical détermine la limite inférieure dictée par le contenu pour l’ensemble de la ligne. Pour raccourcir la ligne, il peut également être nécessaire de réduire le texte, la taille de police ou les marges, ou d’élargir une colonne.

Les images ci‑dessous montrent le même tableau à la même échelle. Dans les résultats illustrés, les hauteurs réelles étaient de 70, 100 et 55,2 points : la dernière ligne est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [minimum augmenté](row-height-increased.pptx) et [minimum réduit](row-height-decreased.pptx).

| Original : minimum 70 pt, réel 70 pt | Augmenté : minimum 100 pt, réel 100 pt | Réduit : minimum 20 pt, réel 55,2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après augmentation du minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après réduction du minimum de la première ligne à 20 points ; le texte renvoyé garde la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Définir la première ligne comme en‑tête**

Utilisez la méthode [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) pour marquer la première ligne comme en‑tête. Son apparence dépend du style de tableau appliqué.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Accédez au tableau stocké comme première forme sur la diapositive.  
4. Activez le format d’en‑tête pour sa première ligne.  
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive. Il active le format d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cloner une ligne ou une colonne de tableau**

Cloner des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin du tableau ou l’insérer à une position spécifique.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs des colonnes et les hauteurs des lignes.  
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
5. Clonez les lignes requises.  
6. Clonez les colonnes requises.  
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` avec au moins une diapositive. Il crée un tableau de trois colonnes et cinq lignes, les dimensions étant spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’indice 3 (quatrième position). Le tableau résultant possède sept lignes et cinq colonnes. Le paramètre `false` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte aucune cellule fusionnée.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Supprimer une ligne ou une colonne d’un tableau**

Supprimez les lignes ou colonnes dont vous n’avez plus besoin dans un tableau. La suppression d’un élément décale les indices des lignes ou colonnes suivantes.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Accédez à la première diapositive.  
3. Définissez les largeurs des colonnes et les hauteurs des lignes.  
4. Ajoutez un tableau avec la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
5. Supprimez la deuxième ligne et la deuxième colonne.  
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau de trois par trois et supprime la ligne et la colonne à l’indice 1, laissant un tableau de deux par deux dans `TestTable_out.pptx`. Les dimensions sont en points. Le paramètre `false` désactive la suppression des lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte aucune cellule fusionnée.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Appliquer le formatage du texte au niveau des lignes du tableau**

Appliquez un formatage du texte à toute une ligne pour que ses cellules restent cohérentes. Vous pouvez définir les propriétés de police, le format de paragraphe et l’orientation du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Accédez au tableau sur la première diapositive.  
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour la première ligne.  
4. Utilisez [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) pour la première ligne.  
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) pour la deuxième ligne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux lignes. Il applique un texte de 25 points, un alignement à droite et une marge droite de 20 points au paragraphe de la première ligne, puis définit du texte vertical dans la deuxième ligne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Appliquer le formatage du texte au niveau des colonnes du tableau**

Appliquez un formatage du texte à toute une colonne pour que ses cellules restent cohérentes. Vous pouvez définir les propriétés de police, le format de paragraphe et l’orientation du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Accédez au tableau sur la première diapositive.  
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour la première colonne.  
4. Utilisez [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) pour la première colonne.  
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) pour la deuxième colonne.  
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` contenant un tableau comme première forme sur la première diapositive et au moins deux colonnes. Il applique un texte de 25 points, un alignement à droite et une marge droite de 20 points au paragraphe de la première colonne, puis définit du texte vertical dans la deuxième colonne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés du style de tableau**

Utilisez la méthode [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) pour récupérer le style prédéfini appliqué à un tableau et le réutiliser sur un autre tableau. Cette méthode identifie le style prédéfini plutôt que les surcharges de formatage individuelles des cellules.

L’exemple crée un tableau, applique [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) et lit le style prédéfini. Il affiche la valeur entière correspondant à `DarkStyle1` et enregistre le tableau dans `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/mise en page/maître, et vous pouvez toujours remplacer les remplissages, bordures et couleurs de texte par-dessus ce thème.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides ne disposent pas de tri ou de filtres intégrés. Triez vos données en mémoire d’abord, puis rejouez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule prévaut sur le style du tableau.