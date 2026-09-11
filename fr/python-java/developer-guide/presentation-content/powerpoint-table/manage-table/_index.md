---
title: Gérer les tableaux de présentation en Python
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/python-java/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et modifier des tableaux dans des diapositives PowerPoint avec Aspose.Slides pour Python via Java. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableau."
---
## **Introduction**

Un tableau dans PowerPoint est un moyen efficace d’afficher des informations. Les informations dans une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) , la classe [Cell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/) et d’autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans tous les types de présentations.

## **Create a Table from Scratch**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive par son indice.
3. Définissez une liste de largeurs de colonnes.
4. Définissez une liste de hauteurs de lignes.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable) .
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) d’une [Cell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/) .
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) .
10. Enregistrez la présentation modifiée.

Ce code Python montre comment créer un tableau dans une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancie une classe Presentation qui représente un fichier PPTX
presentation = Presentation()
try:

    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Ajoute une forme de tableau à la diapositive
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définit le format des bordures pour chaque cellule
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Fusionne les cellules 1 et 2 de la ligne 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Ajoute du texte à la cellule fusionnée
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Enregistre la présentation sur le disque
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numbering in a Standard Table**

Dans un tableau standard, la numérotation des cellules est simple et basée sur zéro. La première cellule d’un tableau est indexée : 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d’un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code Python montre comment créer un tableau avec une numérotation de cellules standard :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancie une classe Presentation qui représente un fichier PPTX
presentation = Presentation()
try:

    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajoute une forme de tableau à la diapositive
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définit le format des bordures pour chaque cellule
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # Enregistre la présentation sur le disque
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access an Existing Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .

2. Obtenez une référence à la diapositive contenant le tableau via son indice.

3. Initialise une variable pour un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) et affectez‑lui `None`.

4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) jusqu’à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez ne contient qu’un seul tableau, vous pouvez simplement vérifier toutes les formes qu’elle contient. Lorsqu’une forme est identifiée comme un tableau, vous pouvez l’utiliser comme objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/). Mais si la diapositive que vous traitez contient plusieurs tableaux, il vaut mieux rechercher le tableau dont vous avez besoin via son [getAlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText).

5. Utilisez l’objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) pour travailler avec le tableau. Dans l’exemple ci‑dessous, nous mettons à jour le texte de la première colonne de la deuxième ligne.

6. Enregistrez la présentation modifiée.

Ce code Python montre comment accéder à un tableau existant et le manipuler :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Instancie la classe Presentation qui représente un fichier PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Initialise la référence du tableau.
    table = None

    # Parcourt les formes et définit une référence au tableau trouvé
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Définit le texte pour la première colonne de la deuxième ligne
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Enregistre la présentation modifiée sur le disque
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Find the Cell That Owns a Text Frame**

Lorsque du code de traitement de texte générique reçoit un [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) d’un tableau, utilisez la méthode [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentCell) pour récupérer la [Cell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/) propriétaire. Pour un cadre texte de cellule de tableau, [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentCell) renvoie le propriétaire et [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentShape) renvoie `None`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les méthodes en lecture seule [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/#getFirstColumnIndex) et [Cell.getFirstRowIndex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/#getFirstRowIndex) . [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentCell) fournit également une navigation en lecture seule : elle renvoie le propriétaire sans en changer la possession. Vérifiez toujours que la cellule renvoyée n’est pas `None` avant de l’utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/python-java/search-and-replace-text/) .

## **Align Text in a Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) du tableau.
5. Accédez au [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) de l’objet [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) .
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code Python montre comment aligner le texte dans un tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Crée une instance de la classe Presentation
presentation = Presentation()
try:

    # Obtient la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Ajoute la forme de tableau à la diapositive
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Accède au cadre texte
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Accède au premier paragraphe du cadre texte.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Accède à la première portion du paragraphe.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Aligne le texte verticalement
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Enregistre la présentation sur le disque
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set Text Formatting on the Table Level**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive par son indice.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) depuis la diapositive.
4. Définissez la hauteur de la police du texte avec [setFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. Définissez l’alignement et la marge droite avec [setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Définissez le type de texte vertical avec [setTextVerticalType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Enregistrez la présentation modifiée.

Ce code Python montre comment appliquer vos options de formatage préférées au texte d’un tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Crée une instance de la classe Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Supposons que la première forme de la première diapositive soit un tableau
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Définit la hauteur de la police des cellules du tableau
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Définit l'alignement du texte des cellules du tableau et la marge droite en un appel
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Définit le type de texte vertical des cellules du tableau
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Get Table Style Properties**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de pouvoir les réutiliser pour un autre tableau ou ailleurs. Ce code Python montre comment obtenir les propriétés de style à partir d’un style prédéfini de tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # modifier le thème de préréglage de style par défaut

    # Obtient le préréglage de style du tableau
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Applique le préréglage de style récupéré à un autre tableau
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lock Aspect Ratio of a Table**

Le rapport d’aspect d’une forme géométrique est le rapport de ses dimensions dans différents axes. Aspose.Slides fournit la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/fr/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) pour vous permettre de verrouiller le réglage du rapport d’aspect pour les tableaux et autres formes.

Ce code Python montre comment verrouiller le rapport d’aspect d’un tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # inverser
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/#setRightToLeft) , et les paragraphes possèdent [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setRightToLeft). L’utilisation des deux garantit l’ordre RTL correct et le rendu à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [verrous de forme](/slides/fr/python-java/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image dans une cellule en tant qu’arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).