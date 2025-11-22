---
title: Gérer les lignes et colonnes des tableaux PowerPoint avec Python
linktitle: Lignes et Colonnes
type: docs
weight: 20
url: /fr/python-net/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête de tableau
- cloner une ligne
- cloner une colonne
- copier une ligne
- copier une colonne
- supprimer une ligne
- supprimer une colonne
- formatage du texte de ligne
- formatage du texte de colonne
- style de tableau
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les lignes et colonnes des tableaux dans PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET et accélérez la modification des présentations et les mises à jour de données."
---

## **Aperçu**

Cet article montre comment gérer les lignes et colonnes de tableau dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python. Vous apprendrez à ajouter, insérer, cloner et supprimer des lignes ou colonnes, à marquer la première ligne comme en‑tête, à ajuster la taille et la disposition, et à appliquer le formatage du texte et le style au niveau de la ligne ou de la colonne. Chaque tâche est illustrée par des extraits de code compacts et autonomes basés sur l’API [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), afin que vous puissiez rapidement trouver un tableau sur une diapositive et remodeler sa structure pour correspondre à votre conception.

## **Définir la première ligne comme en‑tête**

Marquez la première ligne du tableau comme en‑tête afin de distinguer clairement les titres de colonne des données. Dans Aspose.Slides pour Python, activez simplement l’option *First Row* du tableau pour appliquer le format d’en‑tête défini par le style de tableau sélectionné.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.  
1. Accédez à la diapositive par son indice.  
1. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour trouver le tableau concerné.  
1. Définissez la première ligne du tableau comme en‑tête.

Ce code Python montre comment définir la première ligne d’un tableau comme son en‑tête :
```python
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Parcourir les formes et obtenir une référence au tableau.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Définir la première ligne du tableau comme en‑tête.
    table.first_row = True
    
    # Enregistrer la présentation sur le disque.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner une ligne ou une colonne de tableau**

Clonez n’importe quelle ligne ou colonne de tableau et insérez la copie à la position souhaitée dans le tableau. Le duplicata préserve le contenu des cellules, le formatage et les tailles, ce qui vous permet d’étendre les mises en page rapidement et de façon cohérente.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.  
1. Accédez à la diapositive par son indice.  
1. Définissez un tableau des largeurs de colonne.  
1. Définissez un tableau des hauteurs de ligne.  
1. Ajoutez un [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive en utilisant `add_table(x, y, column_widths, row_heights)`.  
1. Clonez une ligne de tableau.  
1. Clonez une colonne de tableau.  
1. Enregistrez la présentation modifiée.

Ce code Python montre comment cloner une ligne et une colonne d’un tableau PowerPoint :
```python
 import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les largeurs de colonnes et les hauteurs de lignes.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Ajouter un tableau à la diapositive.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Ajouter du texte à la ligne 1, colonne 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Ajouter du texte à la ligne 2, colonne 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Cloner la ligne 1 à la fin du tableau.
    table.rows.add_clone(table.rows[0], False)

    # Ajouter du texte à la ligne 1, colonne 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Ajouter du texte à la ligne 2, colonne 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Cloner la ligne 2 comme la 4e ligne du tableau.
    table.rows.insert_clone(3,table.rows[1], False)

    # Cloner la première colonne à la fin.
    table.columns.add_clone(table.columns[0], False)

    # Cloner la deuxième colonne à l'index 3 (la 4e position).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Enregistrer la présentation sur le disque.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer une ligne ou une colonne d’un tableau**

Simplifiez un tableau en supprimant n’importe quelle ligne ou colonne par indice à l’aide d’Aspose.Slides pour Python — la disposition se réajuste automatiquement tout en préservant le formatage des cellules restantes. Cela est pratique pour alléger des grilles de données ou supprimer des espaces réservés sans reconstruire le tableau.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.  
1. Accédez à la diapositive par son indice.  
1. Définissez un tableau des largeurs de colonne.  
1. Définissez un tableau des hauteurs de ligne.  
1. Ajoutez un ITable à la diapositive en utilisant `add_table(x, y, column_widths, row_heights)`.  
1. Supprimez la ligne du tableau.  
1. Supprimez la colonne du tableau.  
1. Enregistrez la présentation modifiée.

Le code Python suivant montre comment supprimer une ligne et une colonne d’un tableau :
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

Appliquez un style de texte cohérent à l’ensemble d’une ligne de tableau en une seule étape. Avec Aspose.Slides pour Python, vous pouvez définir la famille de police, la taille, l’épaisseur, la couleur et l’alignement pour toutes les cellules de la ligne simultanément afin de garder les en‑têtes ou les bandes de données uniformes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.  
1. Accédez à la diapositive par son indice.  
1. Accédez à l’objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) concerné sur la diapositive.  
1. Définissez la hauteur de police pour les cellules de la première ligne.  
1. Définissez l’alignement et la marge droite pour les cellules de la première ligne.  
1. Définissez le type de texte vertical pour les cellules de la deuxième ligne.  
1. Enregistrez la présentation modifiée.

Ce code Python illustre l’opération.
```python
import aspose.slides as slides

# Créer une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Définir la hauteur de police pour les cellules de la première ligne.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Définir l'alignement du texte et la marge droite des cellules de la première ligne.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Définir le type de texte vertical pour les cellules de la deuxième ligne.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Enregistrer la présentation sur le disque.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le formatage du texte au niveau de la colonne du tableau**

Appliquez un style de texte cohérent à l’ensemble d’une colonne de tableau en une seule fois. Avec Aspose.Slides pour Python, vous pouvez définir la famille de police, la taille, l’épaisseur, la couleur et l’alignement pour toutes les cellules d’une colonne afin de créer des bandes verticales uniformes pour les titres ou les données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation.  
1. Accédez à la diapositive par son indice.  
1. Accédez à l’objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) concerné sur la diapositive.  
1. Définissez la hauteur de police pour les cellules de la première colonne.  
1. Définissez l’alignement et la marge droite pour les cellules de la première colonne.  
1. Définissez le type de texte vertical pour les cellules de la deuxième colonne.  
1. Enregistrez la présentation modifiée.

Le code Python suivant illustre l’opération :
```python
import aspose.slides as slides

# Créer une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Définir la hauteur de police des cellules de la première colonne.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Définir l'alignement du texte et la marge droite des cellules de la première colonne.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Définir le type de texte vertical des cellules de la deuxième colonne.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Enregistrer la présentation sur le disque.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de les réutiliser pour un autre tableau ou ailleurs. Le code Python suivant montre comment obtenir les propriétés de style à partir d’un style de tableau prédéfini :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/disposition/maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs du texte au‑dessus de ce thème.

**Puis‑je trier les lignes de tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides n’ont pas de fonction de tri ou de filtres intégrée. Triez vos données en mémoire d’abord, puis repopulez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (lignes alternées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule prévale sur le style du tableau.