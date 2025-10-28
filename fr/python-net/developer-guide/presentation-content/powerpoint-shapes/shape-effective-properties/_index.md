---
title: Obtenir les propriétés effectives d'une forme à partir de présentations avec Python
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/python-net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Python via .NET calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint et OpenDocument."
---

## **Vue d’ensemble**

Dans ce sujet, vous apprendrez les concepts de propriétés **effectives** et **locales**. Lorsque des valeurs sont définies directement aux niveaux suivants :

1. Dans les propriétés de la portion de texte sur la diapositive.
2. Dans le style de texte de la forme prototype sur le masque ou la diapositive maîtresse (si le cadre de texte en possède un).
3. Dans les paramètres de texte globaux de la présentation.

ces valeurs sont appelées valeurs **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Lorsque l'application doit déterminer comment la portion de texte doit apparaître, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en appelant la méthode `get_effective` sur le format local.

L'exemple suivant montre comment obtenir les valeurs effectives pour un format de cadre de texte et un format de portion de texte.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Obtenir les propriétés effectives de la caméra**

Aspose.Slides for Python via .NET allows you to retrieve the effective camera properties. The [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) class represents an immutable object that contains these properties. An instance of [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

L'exemple suivant montre comment obtenir les propriétés effectives de la caméra :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **Obtenir les propriétés effectives du système d'éclairage**

Aspose.Slides for Python via .NET allows you to retrieve the effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) class represents an immutable object that contains these properties. An instance of [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

L'exemple suivant montre comment obtenir les propriétés effectives du système d'éclairage :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **Obtenir les propriétés effectives du biseau de forme**

Aspose.Slides for Python via .NET allows you to retrieve the effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) class represents an immutable object that contains a shape’s face‑relief (bevel) properties. An instance of [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

L'exemple suivant montre comment obtenir les propriétés effectives d'un biseau de forme :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```

## **Obtenir les propriétés effectives du cadre de texte**

Using Aspose.Slides for Python via .NET, you can retrieve the effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) class contains the effective text frame formatting properties.

L'exemple suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```

## **Obtenir les propriétés effectives du style de texte**

Using Aspose.Slides for Python via .NET, you can retrieve the effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) class contains the effective text style properties.

L'exemple suivant montre comment obtenir les propriétés effectives du style de texte :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```

## **Obtenir la hauteur de police effective**

Using Aspose.Slides for Python via .NET, you can retrieve the effective font height. The example below demonstrates how a text portion’s effective font height changes as you set local font height values at different levels of the presentation structure.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Obtenir le format de remplissage effectif du tableau**

Using Aspose.Slides for Python via .NET, you can retrieve the effective fill formatting for different logical parts of a table. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) class contains the effective fill formatting properties. Note that cell formatting always has higher priority than row formatting, a row has higher priority than a column, and a column has higher priority than the whole table.

Therefore, [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) properties are ultimately used to draw the table. The following example shows how to get the effective fill formatting for the different table levels:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Comment savoir si j'ai obtenu un "instantané" plutôt qu'un "objet vivant", et quand devrais-je relire les propriétés effectives ?**

Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mise à jour.

**Le changement du masque/diapositive maître affecte-t‑il les propriétés effectives déjà récupérées ?**

Oui, mais seulement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour ; il faut le demander de nouveau après avoir modifié le masque ou le maître.

**Puis‑je modifier les valeurs via EffectiveData ?**

Non. EffectiveData est en lecture seule. Apportez les modifications dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans le masque/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue fait partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je dire quel niveau a fourni la taille ou la police ?**

Pas directement. EffectiveData renvoie la valeur finale. Pour connaître la source, examinez les valeurs locales au niveau de la portion/paragraphe/cadre de texte ainsi que les styles de texte au niveau du masque/maître/présentation afin de repérer la première définition explicite.

**Pourquoi les valeurs EffectiveData apparaissent parfois identiques aux valeurs locales ?**

Parce que la valeur locale s’est avérée finale ( aucune héritage de niveau supérieur n’était nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

**Quand dois‑je utiliser les propriétés effectives, et quand me contenter des propriétés locales ?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après l’application de tout l’héritage (par ex., pour aligner les couleurs, retraits ou tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.