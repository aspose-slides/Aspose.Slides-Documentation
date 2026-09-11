---
title: Obtenir les propriétés effectives d'une forme depuis les présentations en Python via Java
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/python-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme à chanfrein
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides pour Python via Java afin de distinguer le formatage local, hérité et effectif des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

Le formatage PowerPoint peut provenir de plusieurs endroits. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de formatage parentes, telles qu’un défaut de paragraphe, un style de texte, une mise en page ou diapositive maître, un thème ou des valeurs par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui reste après la résolution de toute la hiérarchie est la **valeur effective** — la valeur utilisée pour rendre l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa valeur locale [getFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#getFontHeight) est alors `float("nan")`, ce qui signifie « non définie ici ». La portion peut hériter d’une hauteur de son paragraphe, du style de texte par défaut de la présentation ou d’une autre source applicable. L’appel à [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) sur le format de la portion renvoie la hauteur finale résolue.

Utilisez les deux types de données de formatage à des fins différentes :

- Lire ou modifier un objet de format local, tel que [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/), lorsque vous devez contrôler où une valeur est définie.
- Lire un objet de données effectives, tel que `PortionFormatEffectiveData`, lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police aux niveaux de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux ainsi que la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de formatage.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Lire les données effectives après les changements précédents.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Définir des valeurs héritées à deux niveaux différents.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Une valeur locale sur la portion remplace les deux valeurs héritées.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Modifier une valeur héritée ne remplace pas une valeur locale existante.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Effacer la valeur locale. La portion hérite maintenant du paragraphe à nouveau.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Effacer la valeur du paragraphe. Le défaut de la présentation fournit maintenant le résultat.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La priorité dans cet exemple est le formatage local de la portion, puis le formatage du paragraphe, puis le défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe reste le même : une valeur explicite plus spécifique l’emporte, et [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

Le formatage du texte est réparti sur plusieurs objets :

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#getEffective) résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.
- [TextStyle.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textstyle/#getEffective) résout le formatage des paragraphes pour chaque niveau de style de texte.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#getEffective) résout les propriétés du paragraphe telles que l’alignement, l'indentation et les puces.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) résout les propriétés de caractères telles que la hauteur de police, la police, la couleur, le gras et l’italique.

Pour l’exemple suivant, `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) avec un cadre de texte non vide. L’AutoShape peut se trouver à n’importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Obtenir les propriétés 3D effectives**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getEffective) renvoie un objet `ThreeDFormatEffectiveData` qui regroupe tous les paramètres 3D résolus. Ses méthodes `getCamera`, `getLightRig`, `getBevelTop` et `getBevelBottom` exposent les données effectives correspondantes. Lire ces paramètres associés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d’éclairage ou de chanfrein à cette forme si vous souhaitez que la sortie contienne des valeurs différentes des valeurs par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Obtenir le formatage de tableau effectif**

Le formatage d’un tableau peut provenir du style de tableau ainsi que des formats appliqués à l’ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre des remplissages explicitement définis, la priorité est la cellule, la ligne, la colonne, puis le tableau complet. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche une [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) au lieu de supposer que `getShapes().get_Item(0)` est un tableau.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Si vous avez besoin de la couleur plutôt que du seul type de remplissage, vérifiez d’abord le `getFillType` effectif, puis lisez la méthode applicable à ce type — par exemple, `getSolidFillColor` pour un remplissage plein.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de formatage au moment où elle est résolue. Appelez à nouveau [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, notamment :

- le formatage local de l’objet ;
- les valeurs par défaut du paragraphe ou du cadre de texte ;
- un style de tableau, un tableau, une colonne, une ligne ou un format de cellule ;
- le formatage de la mise en page ou de la diapositive maître ;
- les données du thème ou les valeurs par défaut au niveau de la présentation ;
- la mise en page ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme une capture permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) peut rafraîchir ces données. Si vous devez comparer les valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin — par exemple une hauteur de police, une couleur, un alignement ou une largeur de chanfrein — dans vos propres variables avant d’effectuer la modification.

Pour modifier une valeur, mettez à jour l’objet de format local approprié, puis appelez [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#getEffective) pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**

Les données effectives contiennent la valeur finale, pas sa source. Examinez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la mise en page, le maître, le thème et les valeurs par défaut de la présentation. Les valeurs indéfinies comme `float("nan")` ou `None` indiquent que la recherche se poursuit à un autre niveau.

**Que se passe-t-il lorsqu’aucun niveau ne définit une propriété ?**

Aspose.Slides résout la valeur par défaut PowerPoint ou de la bibliothèque appropriée. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**

La valeur locale a remporté le calcul d’héritage. C’est attendu lorsque la propriété est explicitement définie sur l’objet et qu’aucune règle plus spécifique ne la remplace.

**Quand dois‑je utiliser des données locales plutôt que des données effectives ?**

Utilisez les données locales pour inspecter ou modifier un niveau de formatage spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après l’héritage, les règles de thème et les styles applicables ont été résolus. L’[exemple complet de comparaison](#compare-local-inherited-and-effective-values) montre les deux dans le même flux de travail.