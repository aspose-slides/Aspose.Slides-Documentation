---
title: Obtenir les propriétés effectives d’une forme à partir de présentations en Python
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/python-net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- dispositif d’éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides pour Python via .NET afin de distinguer la mise en forme locale, héritée et effective des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

La mise en forme PowerPoint peut provenir de plusieurs endroits. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de mise en forme parentes, telles qu’un paragraphe par défaut, un style de texte, une diapositive de mise en page ou maîtresse, un thème ou les valeurs par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui reste après la résolution de toute la hiérarchie est la **valeur effective**, qui est utilisée pour rendre l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa valeur locale [font_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ibaseportionformat/font_height/) est alors `float("nan")`, ce qui signifie « non défini ici ». La portion peut hériter d’une hauteur de son paragraphe, du style de texte par défaut de la présentation, ou d’une autre source applicable. L’appel de [get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformat/get_effective/) sur le format de la portion renvoie la hauteur résolue finale.

Utilisez les deux types de données de mise en forme à des fins différentes :
- Lire ou modifier un objet de format local, tel que [IPortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformat/), lorsque vous devez contrôler où une valeur est définie.
- Lire un objet de données effectives, tel que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformateffectivedata/), lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police aux niveaux de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux ainsi que la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de mise en forme.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Lire les données effectives après les modifications précédentes.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Définir les valeurs héritées à deux niveaux différents.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Une valeur locale sur la portion remplace les deux valeurs héritées.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Modifier une valeur héritée ne remplace pas une valeur locale existante.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Effacer la valeur locale. La portion hérite maintenant du paragraphe à nouveau.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Effacer la valeur du paragraphe. La valeur par défaut de la présentation fournit maintenant le résultat.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

La priorité dans cet exemple est la mise en forme locale de la portion, puis la mise en forme du paragraphe, puis la valeur par défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe est le même : une valeur explicite plus spécifique l’emporte, et [get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformat/get_effective/) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

La mise en forme du texte est répartie sur plusieurs objets :
- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/fr/python-net/aspose.slides/itextframeformat/get_effective/) résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/fr/python-net/aspose.slides/itextstyle/get_effective/) résout la mise en forme des paragraphes pour chaque niveau de style de texte.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iparagraphformat/get_effective/) résout les propriétés du paragraphe telles que l’alignement, l’indentation et les puces.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformat/get_effective/) résout les propriétés de caractères telles que la hauteur de police, la police, la couleur, le gras et l’italique.

Pour l’exemple suivant, `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) avec un cadre de texte non vide. L’AutoShape peut se trouver à n’importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Obtenir les propriétés 3D effectives**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformat/get_effective/) renvoie un objet [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/) qui regroupe tous les paramètres 3D résolus. Ses propriétés [camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), et [bevel_bottom](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) exposent les données effectives correspondantes. Lire ces paramètres associés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d’éclairage ou de biseau à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Obtenir la mise en forme de tableau effective**

La mise en forme du tableau peut provenir du style de tableau et des formats appliqués à l’ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre les remplissages définis explicitement, la priorité est cellule, ligne, colonne, puis l’ensemble du tableau. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche une [Table](https://reference.aspose.com/slides/fr/python-net/aspose.slides/table/) au lieu de supposer que `shapes[0]` est un tableau.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Si vous avez besoin de la couleur plutôt que seulement du type de remplissage, vérifiez d’abord le [fill_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/fill_type/) effectif, puis lisez la propriété qui s’applique à ce type, par exemple, [solid_fill_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) pour un remplissage uni.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de mise en forme au moment où elles sont résolues. Appelez `get_effective` à nouveau après avoir modifié tout ce qui peut participer à cette hiérarchie, y compris :
- le format local de l’objet ;
- les valeurs par défaut du paragraphe ou du cadre de texte ;
- un style de tableau, le tableau, une colonne, une ligne ou le format d’une cellule ;
- le format de la disposition ou de la diapositive maître ;
- les données du thème ou les valeurs par défaut au niveau de la présentation ;
- la disposition ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme une capture d’écran permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à `get_effective` peut rafraîchir ces données. Si vous devez comparer des valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin, comme la hauteur de police, la couleur, l’alignement ou la largeur du biseau, dans vos propres variables avant d’effectuer le changement.

Pour modifier une valeur, mettez à jour l’objet de format local approprié puis appelez `get_effective` pour vérifier le résultat. Les objets de données effectives eux‑même sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**  
Les données effectives contiennent la valeur finale, pas sa source. Inspectez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la disposition, le maître, le thème et les valeurs par défaut de la présentation. Les valeurs non définies telles que `float("nan")` ou `None` indiquent que la recherche se poursuit à un autre niveau.

**Que se passe-t-il lorsqu’aucun niveau ne définit une propriété ?**  
Aspose.Slides résout la valeur par défaut PowerPoint ou de la bibliothèque appropriée. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**  
La valeur locale a remporté le calcul d’héritage. Cela est attendu lorsque la propriété est explicitement définie sur l’objet et qu’aucune règle plus spécifique ne la remplace.

**Quand devrais‑je utiliser les données locales plutôt que les données effectives ?**  
Utilisez les données locales pour inspecter ou modifier un niveau de mise en forme spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après résolution de l’héritage, des règles de thème et des styles applicables. L’exemple de [comparaison complète](#compare-local-inherited-and-effective-values) montre les deux dans le même flux de travail.