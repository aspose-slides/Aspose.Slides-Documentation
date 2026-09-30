---
title: Gérer les tableaux de présentation avec Python
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/python-net/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- ratio d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créer et modifier des tableaux dans PowerPoint et les diapositives OpenDocument avec Aspose.Slides pour Python via .NET. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableaux."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit les classes [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) et [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) ainsi que d’autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Définissez une liste de largeurs de colonnes en points.
4. Définissez une liste de hauteurs de lignes en points.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive via la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa propriété [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple ci‑dessous crée un tableau avec trois colonnes et cinq lignes aux coordonnées (100, 50) points. Il applique des bordures rouges d'une largeur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous le nom `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les indices des cellules commencent à zéro et utilisent l'ordre (colonne, ligne). La première cellule a l'indice (0, 0). En Python, accédez à une cellule avec `table.rows[row_index][column_index]` ; l'indice de ligne vient en premier dans cette expression.

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et des hauteurs de lignes de 70 points et des bordures de cellules rouges d'une largeur de 5 points. Les coordonnées illustrent les indices des cellules ; l'exemple laisse les cellules vides et enregistre le tableau sous le nom `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d'une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant le tableau par son index.
3. Parcourez les objets [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) et arrêtez‑vous lorsqu'un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple ci‑dessus ouvre `UpdateExistingTable.pptx` et trouve le premier tableau sur la première diapositive. Il place la valeur `New` dans la cellule à la colonne 0, ligne 1 et enregistre le résultat sous le nom `table1_out.pptx`. L'entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit comporter au moins une colonne et deux lignes.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser le minimum demandé, voir [Contrôle de la hauteur des lignes](/slides/fr/python-net/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code de traitement de texte générique reçoit un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) provenant d'un tableau, utilisez la propriété [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) pour récupérer la [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) propriétaire. Pour un cadre de texte d'une cellule de tableau, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) est défini et [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) est `None`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les propriétés en lecture seule [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) et [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) est également en lecture seule : elle permet de naviguer vers le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `None` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voir [Recherche et remplacement de texte](/slides/fr/python-net/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l'ancrage vertical et la direction du texte des cellules individuelles d'un tableau. L'exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) depuis le tableau.
5. Accédez au premier [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez son texte et sa couleur.
6. Définissez les propriétés [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) et [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) de la cellule.
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il formate le texte de la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne et enregistre le résultat sous le nom `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le formatage du texte au niveau du tableau**

Utilisez [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) pour appliquer le formatage du texte à toutes les cellules d'un tableau. Ses surcharges acceptent le formatage de portion, de paragraphe et de cadre de texte, ce qui permet de définir ces propriétés sans parcourir les cellules individuellement.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) depuis la diapositive.
4. Définissez la [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) du texte.
5. Définissez les propriétés [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) et [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Définissez la [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il définit la taille de police à 25 points, aligne les paragraphes à droite avec une marge droite de 20 points et rend le texte vertical. La présentation formatée est enregistrée sous le nom `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les propriétés du style du tableau**

Utilisez [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) pour lire ou attribuer le style prédéfini d'un tableau. Cet exemple applique [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) à un tableau, affiche le nom du style prédéfini et attribue le même style à un second tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Verrouiller le ratio d'aspect d'un tableau**

Le ratio d'aspect d'un tableau est le rapport entre sa largeur et sa hauteur. Utilisez [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) pour verrouiller ce ratio pour un tableau.

L'exemple ci‑dessus ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l'état actuel du verrouillage, active le verrouillage du ratio d'aspect, affiche l'état mis à jour (`True`) et enregistre le résultat sous le nom `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une propriété [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), et les paragraphes possèdent [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). En utilisant les deux, vous garantissez l'ordre RTL correct et le rendu à l'intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [verrous de forme](/slides/fr/python-net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tableaux.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).