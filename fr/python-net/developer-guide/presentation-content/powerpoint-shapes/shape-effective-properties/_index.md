---
title: Obtenir les propriétés effectives d'une forme à partir de présentations avec Python
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/python-net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- éclairage
- forme à biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Python via .NET calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de formatage spécifique, comme par exemple :

1. Propriétés de portion sur une diapositive.  
1. Styles de texte de forme prototype sur une diapositive de mise en page ou maître, lorsqu'une forme de cadre de texte de la portion en possède un.  
1. Paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n'importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final « tel qu'affiché », il résout la chaîne d'héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `get_effective` sur l'objet de format local.

L'exemple suivant montre comment obtenir les valeurs effectives. Il suppose que la première forme de la première diapositive est un [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) avec un cadre de texte et au moins une portion.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Les données de formatage effectif représentent le formatage calculé actuel après l'application de l'héritage. Dans l'implémentation actuelle, certains objets de données effectives, tels que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iportionformateffectivedata/), peuvent être mis en cache en interne. Appeler à nouveau `get_effective` après avoir modifié le formatage parent ou hérité peut rafraîchir le cache, et un objet précédemment obtenu peut ne plus représenter l'état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, telles que la hauteur de police, la couleur de remplissage, le style de police ou l'alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d'une caméra**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'une caméra. Le type [ICameraEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icameraeffectivedata/) représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icameraeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives de la caméra. Il suppose que la première forme de la première diapositive possède un format 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Obtenir les propriétés effectives d'un éclairage**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'un éclairage. Le type [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ilightrigeffectivedata/) représente un objet immuable contenant les propriétés effectives de l'éclairage. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ilightrigeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives de l'éclairage. Il suppose que la première forme de la première diapositive possède un format 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Obtenir les propriétés effectives d'un biseau de forme**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'un biseau de forme. Le type [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapebeveleffectivedata/) représente un objet immuable contenant les propriétés effectives du relief d'une forme. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapebeveleffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives du biseau supérieur d'une forme. Il suppose que la première forme de la première diapositive possède un format 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Obtenir les propriétés effectives d'un cadre de texte**

En utilisant Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un cadre de texte. Le type [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/itextframeformateffectivedata/) contient les propriétés de formatage effectif du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est un [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) avec un cadre de texte.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Obtenir les propriétés effectives d'un style de texte**

En utilisant Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un style de texte. Le type [ITextStyleEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/itextstyleeffectivedata/) contient les propriétés de style de texte effectives.

L'exemple de code suivant montre comment obtenir les propriétés de style de texte effectives. Il suppose que la première forme de la première diapositive est un [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) avec un cadre de texte.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Obtenir la valeur effective de la hauteur de police**

En utilisant Aspose.Slides, vous pouvez obtenir la hauteur de police effective. Le code suivant démontre comment la hauteur de police effective d'une portion change après avoir défini des valeurs de hauteur de police locales à différents niveaux de la structure de la présentation.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir le format de remplissage effectif d'un tableau**

En utilisant Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d'un tableau. Le type [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/) contient les propriétés de format de remplissage effectif. Le format des cellules a une priorité supérieure à celui des lignes, le format des lignes a une priorité supérieure à celui des colonnes, et le format des colonnes a une priorité supérieure à celui du tableau complet.

En conséquence, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icellformateffectivedata/) sont utilisées pour dessiner la cellule du tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est un [Table](https://reference.aspose.com/slides/fr/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**`get_effective` renvoie-t-il un instantané ?**

Pas toujours. Les données effectives représentent le formatage calculé après l'application de l'héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel subséquent à `get_effective` peut recalculer le formatage et rafraîchir le cache, ainsi un objet précédemment obtenu ne doit pas être considéré comme un instantané durable.

**Quand devrais-je relire les propriétés effectives ?**

Appelez à nouveau `get_effective` après avoir modifié le formatage local, les styles parents, le formatage de la mise en page, le formatage du maître ou les valeurs par défaut au niveau de la présentation. L'appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

**La modification ou la suppression d'une diapositive de mise en page/maître affecte-t-elle les propriétés effectives déjà récupérées ?**

Oui, mais le changement ne sera reflété qu'au prochain appel `get_effective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives obtenues précédemment peuvent être obsolètes. Une fois `get_effective` appelé de nouveau, Aspose.Slides réévalue l'arbre de formatage et les polices, couleurs, tailles ou autres valeurs résultantes peuvent changer.

**Puis-je modifier les valeurs via les objets de données effectives ?**

Non. Les objets de données effectives exposent des valeurs calculées. Apportez les modifications aux objets de formatage local, puis récupérez à nouveau les valeurs effectives.

**Que se passe-t-il si une propriété n'est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut, qui inclut les valeurs par défaut de PowerPoint et d'Aspose.Slides. Cette valeur résolue devient partie des données effectives actuelles.

**À partir d'une valeur de police effective, puis-je savoir quel niveau a fourni la taille ou le type de police ?**

Pas directement. Les données effectives renvoient la valeur finale. Pour trouver la source, examinez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte, et des styles de texte au niveau de la mise en page, du maître et de la présentation pour voir où apparaît la première définition explicite.

**Pourquoi les valeurs effectives sont parfois identiques aux valeurs locales ?**

Parce que la valeur locale s'est avérée finale (aucune héritage de niveau supérieur n'était nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

**Quand devrais-je utiliser les propriétés effectives, et quand travailler uniquement avec les propriétés locales ?**

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu'affiché » après l'application de tout l'héritage, par exemple pour aligner les couleurs, les retraits ou les tailles. Si vous devez préserver ces valeurs indépendamment de changements de formatage ultérieurs, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.