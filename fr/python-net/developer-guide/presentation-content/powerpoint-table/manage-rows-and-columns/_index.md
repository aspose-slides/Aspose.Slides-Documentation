---
title: Gérer les lignes et les colonnes des tableaux PowerPoint avec Python
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/python-net/manage-rows-and-columns/
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
- formatage du texte de ligne
- formatage du texte de colonne
- style de tableau
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les lignes et les colonnes des tableaux PowerPoint avec Aspose.Slides for Python via .NET et accélérez la modification des présentations et la mise à jour des données."
---
## **Introduction**

Aspose.Slides for Python via .NET vous permet de gérer la structure et le formatage des tableaux dans les présentations PowerPoint via la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Vous pouvez désigner une ligne d'en-tête, cloner ou supprimer des lignes et des colonnes, et appliquer le formatage du texte à une ligne ou une colonne entière.

Cet article explique ces opérations avec des exemples Python. Il montre également comment récupérer le préréglage de style d'un tableau afin de le réutiliser. Les indices des lignes et des colonnes d'un tableau commencent à zéro.

## **Contrôle de la hauteur des lignes**

Utilisez [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) pour définir la hauteur minimale d'une ligne en points. C'est une limite inférieure, pas une hauteur fixe. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) renvoie la hauteur réelle et est en lecture seule. Accédez à la ligne via [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

L'exemple charge [row-height-input.pptx](row-height-input.pptx), qui contient un tableau comme première forme sur la première diapositive. Sa première ligne commence à 70 points. Les cellules utilisent du texte Arial 18 points, avec retour à la ligne, et des marges supérieures et inférieures de 6 points; le texte plus long de la deuxième colonne s'enroule sur plusieurs lignes. L'exemple augmente le minimum à 100 points, puis le réduit à 20 points, imprime la hauteur réelle après chaque modification et enregistre les deux résultats.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Avec la présentation fournie, augmenter le minimum ajoute de l'espace à la ligne. Le réduire supprime cet espace supplémentaire, mais la hauteur réelle reste supérieure à 20 points car le texte et les marges des cellules nécessitent plus d'espace. Réduire uniquement le minimum ne peut pas forcer la ligne à être inférieure à l'espace requis par son contenu.

Plusieurs facteurs influencent la hauteur réelle :
- **Texte et taille de police :** un texte plus long, des sauts de ligne explicites ou une police plus grande peuvent nécessiter plus d'espace vertical.
- **Retour à la ligne et largeur de colonne :** avec le retour à la ligne activé, une [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) plus étroite peut produire plus de lignes. Une colonne plus large peut réduire l'espace requis verticalement.
- **Marges des cellules :** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) et [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) ajoutent de l'espace vertical. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) et [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) réduisent la largeur disponible pour le texte et peuvent entraîner un retour à la ligne supplémentaire.

Pour ce tableau sans cellules fusionnées, la cellule qui nécessite le plus d'espace vertical détermine la limite inférieure imposée par le contenu pour toute la ligne. Pour raccourcir la ligne, vous devrez peut-être également réduire le texte, la taille de la police ou les marges, ou élargir une colonne.

Les images ci‑dessous montrent le même tableau à la même échelle. Dans cet exemple, les hauteurs réelles étaient de 70, 100 et 55.2 points : la ligne finale est restée plus haute que son minimum de 20 points. Les mesures exactes du texte peuvent varier selon les polices disponibles dans votre environnement. Téléchargez les résultats enregistrés : [minimum augmenté](row-height-increased.pptx) et [minimum réduit](row-height-decreased.pptx).

| Original : minimum 70 pt, réel 70 pt | Augmenté : minimum 100 pt, réel 100 pt | Réduit : minimum 20 pt, réel 55.2 pt |
| --- | --- | --- |
| ![Tableau original avec une première ligne de 70 points.](row-height-before.png) | ![Tableau après avoir augmenté le minimum de la première ligne à 100 points.](row-height-increased.png) | ![Tableau après avoir réduit le minimum de la première ligne à 20 points ; le texte renvoyé maintient la ligne plus haute que le minimum.](row-height-decreased.png) |

## **Définir la première ligne comme en‑tête**

Utilisez la propriété [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) pour marquer la première ligne pour le formatage d'en‑tête. Son apparence dépend du style de tableau appliqué au tableau.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Accédez au tableau stocké comme première forme sur la diapositive.
4. Activez le formatage d'en‑tête pour sa première ligne.
5. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` avec un tableau comme première forme sur la première diapositive. Il active le formatage d'en‑tête pour la première ligne et enregistre `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner une ligne ou une colonne de tableau**

Clonez des lignes ou des colonnes pour réutiliser leur contenu et leur formatage. Vous pouvez ajouter une copie à la fin du tableau ou l'insérer à une position spécifique.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Clonez les lignes requises.
6. Clonez les colonnes requises.
7. Enregistrez la présentation modifiée.

L'exemple nécessite `Test.pptx` avec au moins une diapositive. Il crée un tableau avec trois colonnes et cinq lignes, les dimensions étant spécifiées en points. Il ajoute des copies de la première ligne et de la première colonne, puis insère des copies de la deuxième ligne et de la deuxième colonne à l'index 3 (la quatrième position). Le tableau résultant possède sept lignes et cinq colonnes. L'argument `False` désactive le clonage dans les lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte pas de cellules fusionnées.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer une ligne ou une colonne d’un tableau**

Supprimez les lignes ou colonnes qui ne sont plus nécessaires dans un tableau. Supprimer un élément décale les indices des lignes ou colonnes qui le suivent.

1. Créez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Définissez les largeurs des colonnes et les hauteurs des lignes.
4. Ajoutez un tableau avec la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Supprimez la deuxième ligne et la deuxième colonne.
6. Enregistrez la présentation modifiée.

Cet exemple crée un tableau de trois par trois et supprime la ligne et la colonne à l'index 1, laissant un tableau de deux par deux dans `TestTable_out.pptx`. Les dimensions sont en points. L'argument `False` désactive la suppression des lignes ou colonnes fusionnées adjacentes ; ce tableau ne comporte pas de cellules fusionnées.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le formatage du texte au niveau de la ligne du tableau**

Appliquez le formatage du texte à une ligne entière pour garder ses cellules cohérentes. Vous pouvez définir les propriétés de police, le formatage de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Définissez [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) pour la première ligne.
4. Définissez [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) et [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) pour la première ligne.
5. Définissez [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pour la deuxième ligne.
6. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` avec un tableau comme première forme sur la première diapositive et au moins deux lignes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première ligne, puis définit le texte vertical dans la deuxième ligne.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le formatage du texte au niveau de la colonne du tableau**

Appliquez le formatage du texte à une colonne entière pour garder ses cellules cohérentes. Vous pouvez définir les propriétés de police, le formatage de paragraphe et la direction du texte sans formater chaque cellule individuellement.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez au tableau sur la première diapositive.
3. Définissez [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) pour la première colonne.
4. Définissez [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) et [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) pour la première colonne.
5. Définissez [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pour la deuxième colonne.
6. Enregistrez la présentation modifiée.

L'exemple nécessite `table.pptx` avec un tableau comme première forme sur la première diapositive et au moins deux colonnes. Il applique un texte de 25 points, un alignement à droite et une marge de paragraphe droite de 20 points à la première colonne, puis définit le texte vertical dans la deuxième colonne.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les propriétés du style de tableau**

Utilisez la propriété [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) pour récupérer le préréglage appliqué à un tableau et le réutiliser sur un autre tableau. Cela identifie le préréglage plutôt que les remplacements de formatage de cellules individuelles.

L'exemple crée un tableau, applique [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), et lit le préréglage. Il affiche `True` lorsque le préréglage récupéré correspond au préréglage appliqué et enregistre le tableau dans `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/mise en page/maître, et vous pouvez toujours remplacer les remplissages, bordures et couleurs du texte au-dessus de ce thème.

**Puis-je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides n’ont pas de tri ou de filtres intégrés. Triez d’abord vos données en mémoire, puis repopulez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes bandées (à rayures) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes bandées, puis remplacez les cellules spécifiques par un formatage local ; le formatage au niveau de la cellule prime sur le style du tableau.