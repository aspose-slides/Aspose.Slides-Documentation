---
title: Gérer les lignes et les colonnes
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de table, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Gérez les lignes et les colonnes des tables dans les présentations PowerPoint en Python"
---

Pour vous permettre de gérer les lignes et les colonnes d'une table dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) et de nombreux autres types.

## **Définir la première ligne comme en-tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive via son index.
3. Créez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) et définissez-le sur null.
4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) pour trouver la table pertinente.
5. Définissez la première ligne de la table comme son en-tête.

Ce code Python vous montre comment définir la première ligne d'une table comme son en-tête :

```python
import aspose.slides as slides

# Instancie la classe Presentation
with slides.Presentation("table.pptx") as pres:
    # Accède à la première diapositive
    sld = pres.slides[0]

    # Initialise la TableEx null
    tbl = None

    # Itère à travers les formes et définit une référence à la table
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Définit la première ligne d'une table comme son en-tête 
    tbl.first_row = True
    
    # Enregistre la présentation sur le disque
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner la ligne ou la colonne d'une table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) à la diapositive via la méthode `add_table(x, y, column_widths, row_heights)`.
6. Clonez la ligne de la table.
7. Clonez la colonne de la table.
8. Enregistrez la présentation modifiée.

Ce code Python vous montre comment cloner la ligne ou la colonne d'une table PowerPoint :

```python
 import aspose.slides as slides

# Instancie la classe Presentation
with slides.Presentation() as presentation:

    # Accède à la première diapositive
    sld = presentation.slides[0]

    # Définit les colonnes avec largeurs et les lignes avec hauteurs
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Ajoute une forme de table à la diapositive
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Ajoute du texte à la cellule 1 de la ligne 1
    table.rows[0][0].text_frame.text = "Ligne 1 Cellule 1"

    # Ajoute du texte à la cellule 2 de la ligne 1
    table.rows[1][0].text_frame.text = "Ligne 1 Cellule 2"

    # Clone la ligne 1 à la fin de la table
    table.rows.add_clone(table.rows[0], False)

    # Ajoute du texte à la cellule 1 de la ligne 2
    table.rows[0][1].text_frame.text = "Ligne 2 Cellule 1"

    # Ajoute du texte à la cellule 2 de la ligne 2
    table.rows[1][1].text_frame.text = "Ligne 2 Cellule 2"

    # Clone la ligne 2 comme la 4ème ligne de la table
    table.rows.insert_clone(3,table.rows[1], False)

    # Clone la première colonne à la fin
    table.columns.add_clone(table.columns[0], False)

    # Clone la 2ème colonne à l'index 4ème colonne
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Enregistre la présentation sur le disque
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer une ligne ou une colonne d'une table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) à la diapositive via la méthode `add_table(x, y, column_widths, row_heights)`.
6. Supprimez la ligne de la table.
7. Supprimez la colonne de la table.
8. Enregistrez la présentation modifiée.

Ce code Python vous montre comment supprimer une ligne ou une colonne d'une table :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la mise en forme du texte au niveau de la ligne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez `font_height` des cellules de la première ligne.
5. Définissez `alignment` et `margin_right` des cellules de la première ligne.
6. Définissez `text_vertical_type` des cellules de la deuxième ligne.
7. Enregistrez la présentation modifiée.

Ce code Python illustre l'opération.

```python
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Définit la hauteur de police des cellules de la première ligne
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Définit l'alignement du texte et la marge droite des cellules de la première ligne
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Définit le type vertical du texte des cellules de la deuxième ligne
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # Enregistre la présentation sur le disque
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la mise en forme du texte au niveau de la colonne de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation,
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) pertinent depuis la diapositive.
4. Définissez `font_height` des cellules de la première colonne.
5. Définissez `alignment` et `margin_right` des cellules de la première colonne.
6. Définissez `text_vertical_type` des cellules de la deuxième colonne.
7. Enregistrez la présentation modifiée.

Ce code Python illustre l'opération :

```python
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Définit la hauteur de police des cellules de la première colonne
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Définit l'alignement du texte et la marge droite des cellules de la première colonne 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Définit le type vertical du texte des cellules de la deuxième colonne
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Enregistre la présentation sur le disque
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les propriétés de style de la table**

Aspose.Slides vous permet de récupérer les propriétés de style pour une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code Python vous montre comment obtenir les propriétés de style à partir d'un style de table prédéfini :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```