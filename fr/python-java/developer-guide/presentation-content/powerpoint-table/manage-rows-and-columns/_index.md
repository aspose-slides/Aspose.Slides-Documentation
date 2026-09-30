---
title: Gérer les lignes et les colonnes des tableaux PowerPoint avec Python
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/python-java/manage-rows-and-columns/
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
- Python
- Aspose.Slides
description: "Gérez les lignes et les colonnes des tables PowerPoint avec Aspose.Slides pour Python via Java et accélérez la modification des présentations et les mises à jour de données."
---
## **Introduction**

Aspose.Slides for Python via Java vous permet de gérer la structure et le formatage des tables dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Vous pouvez désigner une ligne d’en-tête, cloner ou supprimer des lignes et des colonnes, et appliquer le formatage du texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples Python. Il montre également comment récupérer le style prédéfini d’une table afin de le réutiliser. Les indices des lignes et des colonnes de la table sont basés sur zéro.

## **Contrôler la hauteur des lignes**

Utilisez [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) pour définir la hauteur minimale d’une ligne en points. Il s’agit d’une limite inférieure, pas d’une hauteur fixe. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) renvoie la hauteur réelle. Accédez à la ligne via [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

L’exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient une table comme première forme de la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial 18 points, avec retour à la ligne et des marges supérieures et inférieures de 6 points; le texte plus long de la deuxième colonne s’enroule sur plusieurs lignes. L’exemple augmente le minimum à 100 points, puis le diminue à 20 points, affiche la hauteur réelle après chaque modification et enregistre les deux résultats.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Avec la présentation fournie, augmenter le minimum ajoute de l'espace à la ligne. Le réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points car le texte et les marges des cellules nécessitent plus d'espace. Diminuer uniquement le minimum ne peut pas contraindre la ligne à descendre en dessous de l'espace requis par son contenu.

Plusieurs facteurs influent sur la hauteur réelle :
- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d'espace vertical.
- **Enroulement et largeur de colonne :** avec l'enroulement activé, réduire la largeur de la colonne avec [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) peut produire plus de lignes. Une colonne plus large peut réduire l'espace requis verticalement.
- **Marges de cellule :** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) et [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) ajoutent de l'espace vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) et [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) réduisent la largeur disponible pour le texte et peuvent provoquer un enroulement supplémentaire.

Pour cette table sans cellules fusionnées, la cellule qui nécessite le plus d'espace vertical détermine la limite inférieure dictée par le contenu pour toute la ligne. Pour raccourcir la ligne, vous devez également réduire le texte, diminuer la taille de police ou les marges, ou élargir une colonne.

Les images ci‑dessous montrent la même table à la même échelle. Dans les résultats illustrés, les hauteurs réelles étaient de 70, 100 et 55,2 points : la ligne finale est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [minimum augmenté](row-height-increased.pptx) et [minimum diminué](row-height-decreased.pptx).

| Original : minimum 70 pt, réel 70 pt | Augmenté : minimum 100 pt, réel 100 pt | Diminué : minimum 20 pt, réel 55,2 pt |
| --- | --- | --- |
| ![Table originale avec une première ligne de 70 points.](row-height-before.png) | ![Table après avoir augmenté le minimum de la première ligne à 100 points.](row-height-increased.png) | ![Table après avoir diminué le minimum de la première ligne à 20 points ; le texte renvoyé garde la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Définir la première ligne comme en-tête**

Utilisez la méthode [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) pour marquer la première ligne comme format d’en‑tête. Son apparence dépend du style de table appliqué à la table.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Accédez à la table stockée comme première forme de la diapositive.
4. Activez le format d’en‑tête pour sa première ligne.
5. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` avec une table comme première forme de la première diapositive. Il active le format d’en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cloner une ligne ou une colonne de table**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin de la table ou l’insérer à une position précise.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez une table avec la méthode [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Clonez les lignes requises.
6. Clonez les colonnes requises.
7. Enregistrez la présentation modifiée.

L’exemple nécessite `Test.pptx` contenant au moins une diapositive. Il crée une table avec trois colonnes et cinq lignes, les dimensions étant spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l’indice 3 (la quatrième position). La table résultante possède sept lignes et cinq colonnes. L’argument `False` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; cette table ne possède aucune cellule fusionnée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer une ligne ou une colonne d’une table**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans une table. La suppression d’un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez une table avec la méthode [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Supprimez la deuxième ligne et la deuxième colonne.
6. Enregistrez la présentation modifiée.

Cet exemple crée une table 3 × 3 et supprime la ligne et la colonne à l’indice 1, laissant une table 2 × 2 dans `TestTable_out.pptx`. Les dimensions sont en points. L’argument `False` désactive la suppression de lignes ou colonnes fusionnées adjacentes ; cette table ne possède aucune cellule fusionnée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le formatage du texte au niveau de la ligne de table**

Appliquez le formatage du texte à une ligne entière pour que ses cellules restent cohérentes. Vous pouvez définir les propriétés de police, le format de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accédez à la table sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pour la première ligne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) pour la première ligne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pour la deuxième ligne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` avec une table comme première forme de la première diapositive et au moins deux lignes. Il applique du texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première ligne, puis définit le texte vertical dans la deuxième ligne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le formatage du texte au niveau de la colonne de table**

Appliquez le formatage du texte à une colonne entière pour que ses cellules restent cohérentes. Vous pouvez définir les propriétés de police, le format de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accédez à la table sur la première diapositive.
3. Utilisez [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pour la première colonne.
4. Utilisez [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) pour la première colonne.
5. Utilisez [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pour la deuxième colonne.
6. Enregistrez la présentation modifiée.

L’exemple nécessite `table.pptx` avec une table comme première forme de la première diapositive et au moins deux colonnes. Il applique du texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première colonne, puis définit le texte vertical dans la deuxième colonne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir les propriétés du style de table**

Utilisez la méthode [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) pour récupérer le style prédéfini appliqué à une table et le réutiliser sur une autre table. Cela identifie le style prédéfini plutôt que les remplacements de formatage cellule par cellule.

L’exemple crée une table, applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1), puis lit le style prédéfini. Il affiche la valeur entière correspondant à `DarkStyle1` et enregistre la table dans `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à une table déjà créée ?**

Oui. La table hérite du thème de la diapositive/mise en page/maître, et vous pouvez toujours remplacer les remplissages, bordures et couleurs de texte au‑delà de ce thème.

**Puis‑je trier les lignes d’une table comme dans Excel ?**

Non, les tables Aspose.Slides ne disposent pas de tri ou de filtres intégrés. Triez d’abord vos données en mémoire, puis remplissez à nouveau les lignes de la table dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule a priorité sur le style de la table.