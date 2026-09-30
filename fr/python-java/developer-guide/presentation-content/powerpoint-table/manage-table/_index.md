---
title: Gérer les tables de présentation en Python
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/python-java/manage-table/
keywords:
- ajouter tableau
- créer tableau
- accéder tableau
- rapport d'aspect
- aligner texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour Python via Java. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableaux."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit les classes [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) et [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) ainsi que d'autres types pour vous permettre de créer, mettre à jour et gérer les tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

Créez un tableau en spécifiant sa position, la largeur des colonnes et la hauteur des lignes. Après l'avoir ajouté à une diapositive, vous pouvez formater les bordures des cellules, fusionner des cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Définissez une liste de largeurs de colonnes en points.
4. Définissez une liste de hauteurs de lignes en points.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa méthode [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple ci-dessous crée un tableau avec trois colonnes et cinq lignes à (100, 50) points. Il applique des bordures rouges d'une épaisseur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous le nom `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les indices des cellules commencent à zéro et utilisent l'ordre (colonne, ligne). La première cellule a l'index (0, 0).

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et hauteurs de lignes de 70 points et des bordures rouges d'une épaisseur de 5 points. Les coordonnées illustrent les indices des cellules ; l'exemple laisse les cellules vides et enregistre le tableau sous le nom `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d'une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez la classe [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant le tableau par son indice.
3. Parcourez les objets [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) et arrêtez‑vous lorsqu'un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `UpdateExistingTable.pptx` et trouve le premier tableau sur la première diapositive. Il définit la cellule à la colonne 0, ligne 1 à `New` et enregistre le résultat sous le nom `table1_out.pptx`. L'entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit comporter au moins une colonne et deux lignes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser la hauteur minimale demandée, consultez [Contrôler la hauteur des lignes](/slides/fr/python-java/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) d'un tableau, utilisez la méthode [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) pour récupérer la [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) propriétaire. Pour un cadre de texte de cellule de tableau, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) renvoie le propriétaire et [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) renvoie `None`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les méthodes en lecture seule [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) et [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) offre également une navigation en lecture seule : elle renvoie le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `None` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voir [Rechercher et remplacer du texte](/slides/fr/python-java/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l'ancrage vertical et la direction du texte de chaque cellule de tableau. L'exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) du tableau.
5. Accédez au premier [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) et définissez son texte et sa couleur.
6. Définissez l'ancrage vertical de la cellule et la direction du texte en utilisant [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) et [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il formate le texte dans la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne et enregistre le résultat sous le nom `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le formatage du texte au niveau du tableau**

Utilisez [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) pour appliquer le formatage du texte à toutes les cellules d'un tableau. Ses surcharges acceptent le formatage de partie, de paragraphe et de cadre de texte, ce qui vous permet de définir ces propriétés sans parcourir chaque cellule.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) de la diapositive.
4. Définissez la taille de police en utilisant [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pour le texte.
5. Définissez l'alignement du paragraphe et la marge droite en utilisant [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Définissez la direction du texte en utilisant [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il définit la taille de police à 25 points, aligne à droite les paragraphes avec une marge droite de 20 points et rend le texte vertical. La présentation formatée est enregistrée sous le nom `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir les propriétés de style du tableau**

Utilisez [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) pour lire le style prédéfini d'un tableau et [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) pour l'assigner. Cet exemple applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) à un tableau, affiche la valeur du style prédéfini et assigne le même style à un second tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verrouiller le rapport d'aspect d'un tableau**

Le rapport d'aspect d'un tableau est le rapport entre sa largeur et sa hauteur. Utilisez [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) pour verrouiller ce rapport pour un tableau.

L'exemple ci‑dessus ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l'état actuel du verrou, active le verrouillage du rapport d'aspect, affiche l'état mis à jour (`True`) et enregistre le résultat sous le nom `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), et les paragraphes disposent de [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). L'utilisation des deux garantit l'ordre RTL correct et le rendu à l'intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez [shape locks](/slides/fr/python-java/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrouillages s'appliquent également aux tableaux.

**L'insertion d'une image dans une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [remplissage d'image](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).