---
title: Gestion des tableaux de présentation avec Python
linktitle: Gestion du tableau
type: docs
weight: 10
url: /fr/python-net/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- mise en forme du texte
- style de tableau
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créez et modifiez des tableaux dans les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableaux."
---

## **Vue d'ensemble**

Un tableau dans PowerPoint est un moyen efficace de présenter des informations. Les informations organisées dans une grille de cellules (lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) et d’autres types associés pour vous aider à créer, mettre à jour et gérer des tableaux dans n’importe quelle présentation.

## **Créer des tableaux à partir de zéro**

Cette section montre comment créer un tableau à partir de zéro dans Aspose.Slides en ajoutant une forme de tableau à une diapositive, en définissant ses lignes et colonnes, et en définissant des tailles précises. Vous verrez également comment remplir les cellules avec du texte, ajuster l’alignement et les bordures, et personnaliser l’apparence du tableau.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à une diapositive par son indice.
3. Définir un tableau des largeurs de colonnes.
4. Définir un tableau des hauteurs de lignes.
5. Ajouter un [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
6. Parcourir chaque [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) et formater ses bordures supérieure, inférieure, droite et gauche.
7. Fusionner les deux premières cellules de la première ligne du tableau.
8. Accéder au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) d’une [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. Ajouter du texte au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Enregistrer la présentation modifiée.

L’exemple Python suivant montre comment créer un tableau dans une présentation :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Définir le format des bordures pour chaque cellule.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Fusionner les cellules de (ligne 0, colonne 0) à (ligne 1, colonne 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Ajouter du texte à la cellule fusionnée.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Enregistrer la présentation sur le disque.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Numérotation dans les tableaux standard**

Dans un tableau standard, la numérotation des cellules est simple et basée sur zéro. La première cellule d’un tableau est indexée comme (0, 0) (colonne 0, ligne 0).

Par exemple, dans un tableau de 4 colonnes et 4 lignes, les cellules sont numérotées comme suit :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

L’exemple Python suivant montre comment référencer les cellules en utilisant cette numérotation à base zéro :
```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```


## **Accéder à un tableau existant**

Cette section explique comment localiser et travailler avec un tableau existant dans une présentation à l’aide d’Aspose.Slides. Vous apprendrez à trouver le tableau sur une diapositive, à accéder à ses lignes, colonnes et cellules, et à mettre à jour le contenu ou le formatage.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à la diapositive qui contient le tableau par son indice.
3. Parcourir tous les objets [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) jusqu’à trouver le tableau.
4. Utiliser l’objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) pour travailler avec le tableau.
5. Enregistrer la présentation modifiée.

{{% alert color="info" %}}
Si la diapositive contient plusieurs tableaux, il est préférable de rechercher le tableau dont vous avez besoin par sa propriété `alternative_text`.
{{% /alert %}}

L’exemple Python suivant montre comment accéder à un tableau existant et le manipuler :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancier la classe Presentation pour charger un fichier PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    table = None

    # Parcourir les formes et référencer le premier tableau trouvé.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Définir le texte de la première cellule de la première ligne.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Aligner le texte dans les tableaux**

Cette section montre comment contrôler l’alignement du texte à l’intérieur des cellules de tableau à l’aide d’Aspose.Slides. Vous apprendrez à définir l’alignement horizontal et vertical des cellules pour garder votre contenu clair et cohérent.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à la diapositive par son indice.
3. Ajouter un objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
4. Accéder à un objet [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) du tableau.
5. Aligner le texte verticalement.
6. Enregistrer la présentation modifiée.

L’exemple Python suivant montre comment aligner le texte dans un tableau :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Créer une instance de la classe Presentation.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centrer le texte et définir l'orientation verticale.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Enregistrer la présentation sur le disque.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le formatage du texte au niveau du tableau**

Cette section montre comment appliquer le formatage du texte au niveau du tableau dans Aspose.Slides afin que chaque cellule hérite d’un style cohérent et unifié. Vous apprendrez à définir globalement la taille de police, les alignements et les marges.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à la diapositive par son indice.
3. Ajouter un [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
4. Définir la taille de police (hauteur de police) pour le texte.
5. Définir l’alignement des paragraphes et les marges.
6. Définir l’orientation verticale du texte.
7. Enregistrer la présentation modifiée.

L’exemple Python suivant montre comment appliquer vos options de formatage préférées au texte d’un tableau :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Définir la taille de police pour toutes les cellules du tableau.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Définir le texte aligné à droite et une marge droite pour toutes les cellules du tableau.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Définir l'orientation verticale du texte pour toutes les cellules du tableau.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Appliquer les styles de tableau intégrés**

Aspose.Slides vous permet de formater les tableaux en utilisant des styles prédéfinis directement dans le code. L’exemple montre la création d’un tableau, l’application d’un style intégré, et l’enregistrement du résultat — une façon efficace d’assurer un formatage cohérent et professionnel.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Verrouiller le rapport d’aspect des tableaux**

Le rapport d’aspect d’une forme est le rapport de ses dimensions. Aspose.Slides fournit la propriété `aspect_ratio_locked`, qui permet de verrouiller le rapport d’aspect pour les tableaux et autres formes.

L’exemple Python suivant montre comment verrouiller le rapport d’aspect d’un tableau :
```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour tout le tableau et le texte de ses cellules ?**

Oui. Le tableau expose la propriété [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) et les paragraphes possèdent [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). L’utilisation des deux garantit l’ordre RTL correct et le rendu à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez [shape locks](/slides/fr/python-net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).