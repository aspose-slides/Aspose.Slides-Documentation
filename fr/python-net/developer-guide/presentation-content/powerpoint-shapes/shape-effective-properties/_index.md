---
title: Obtenir les propriétés effectives des formes à partir des présentations avec Python
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/python-net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- jeu de lumières
- forme de biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via .NET calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint et OpenDocument."
---

## **Vue d'ensemble**

Dans ce sujet, vous apprendrez les concepts de **effetives** et **locales**. Lorsque des valeurs sont définies directement aux niveaux suivants :

1. Dans les propriétés de la portion de texte sur la diapositive.
2. Dans le style de texte de la forme prototype sur la diapositive de disposition ou maître (si le cadre de texte en possède un).
3. Dans les paramètres de texte globaux de la présentation.

ces valeurs sont appelées **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Lorsque l’application doit déterminer comment la portion de texte doit apparaître, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en appelant la méthode `get_effective` sur le format local.

L’exemple suivant montre comment obtenir les valeurs effectives pour un format de cadre de texte et un format de portion de texte.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Obtenir les propriétés de caméra effectives**

Aspose.Slides for Python via .NET vous permet de récupérer les propriétés de caméra effectives. La classe [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) représente un objet immuable qui contient ces propriétés. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour la classe [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

L’exemple suivant montre comment obtenir les propriétés de caméra effectives :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propriétés de caméra effectives =")
	print("Type :", str(three_d_effective_data.camera.camera_type))
	print("Champ de vision :", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom :", str(three_d_effective_data.camera.zoom))
```

## **Obtenir les propriétés du jeu de lumières effectives**

Aspose.Slides for Python via .NET vous permet de récupérer les propriétés effectives d’un jeu de lumières. La classe [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) représente un objet immuable qui contient ces propriétés. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour la classe [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

L’exemple suivant montre comment obtenir les propriétés du jeu de lumières effectives :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propriétés du jeu de lumières effectives =")
	print("Type :", str(three_d_effective_data.light_rig.light_type))
	print("Direction :", str(three_d_effective_data.light_rig.direction))
```

## **Obtenir les propriétés de biseau de forme effectives**

Aspose.Slides for Python via .NET vous permet de récupérer les propriétés effectives d’un biseau de forme. La classe [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) représente un objet immuable qui contient les propriétés de relèvement de face (biseau) d’une forme. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour la classe [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

L’exemple suivant montre comment obtenir les propriétés effectives d’un biseau de forme :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propriétés du relèvement de la face supérieure du biseau =")
	print("Type :", str(three_d_effective_data.bevel_top.bevel_type))
	print("Largeur :", str(three_d_effective_data.bevel_top.width))
	print("Hauteur :", str(three_d_effective_data.bevel_top.height))
```

## **Obtenir les propriétés du cadre de texte effectives**

Avec Aspose.Slides for Python via .NET, vous pouvez récupérer les propriétés effectives d’un cadre de texte. La classe [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) contient les propriétés de formatage effectif du cadre de texte.

L’exemple suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Type d’ancrage :", str(text_frame_format_effective_data.anchoring_type))
	print("Type d’ajustement :", str(text_frame_format_effective_data.autofit_type))
	print("Type de texte vertical :", str(text_frame_format_effective_data.text_vertical_type))
	print("Marges")
	print("   Gauche :", str(text_frame_format_effective_data.margin_left))
	print("   Haut :", str(text_frame_format_effective_data.margin_top))
	print("   Droite :", str(text_frame_format_effective_data.margin_right))
	print("   Bas :", str(text_frame_format_effective_data.margin_bottom))
```

## **Obtenir les propriétés du style de texte effectives**

Avec Aspose.Slides for Python via .NET, vous pouvez récupérer les propriétés effectives d’un style de texte. La classe [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) contient les propriétés de style de texte effectives.

L’exemple suivant montre comment obtenir les propriétés de style de texte effectives :

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Format de paragraphe effectif pour le niveau de style #{str(i)} =")

        print("Profondeur :", str(effectiveStyleLevel.depth))
        print("Retrait :", str(effectiveStyleLevel.indent))
        print("Alignement :", str(effectiveStyleLevel.alignment))
        print("Alignement de police :", str(effectiveStyleLevel.font_alignment))
```

## **Obtenir la hauteur de police effective**

Avec Aspose.Slides for Python via .NET, vous pouvez récupérer la hauteur de police effective. L’exemple ci‑dessous montre comment la hauteur de police effective d’une portion de texte change lorsque vous définissez des valeurs locales de hauteur de police à différents niveaux de la structure de la présentation.

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

    print("Hauteur de police effective juste après la création :")
    print("Portion #0 :", portion0.portion_format.get_effective().font_height)
    print("Portion #1 :", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Hauteur de police effective après définition de la hauteur de police par défaut de la présentation :")
    print("Portion #0 :", portion0.portion_format.get_effective().font_height)
    print("Portion #1 :", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Hauteur de police effective après définition de la hauteur de police par défaut du paragraphe :")
    print("Portion #0 :", portion0.portion_format.get_effective().font_height)
    print("Portion #1 :", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Hauteur de police effective après définition de la hauteur de police de la portion #0 :")
    print("Portion #0 :", portion0.portion_format.get_effective().font_height)
    print("Portion #1 :", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Hauteur de police effective après définition de la hauteur de police de la portion #1 :")
    print("Portion #0 :", portion0.portion_format.get_effective().font_height)
    print("Portion #1 :", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Obtenir le format de remplissage de tableau effectif**

Avec Aspose.Slides for Python via .NET, vous pouvez récupérer le format de remplissage effectif pour différentes parties logiques d’un tableau. La classe [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) contient les propriétés de format de remplissage effectif. Notez que le format de cellule a toujours la priorité sur le format de ligne, une ligne a la priorité sur le format de colonne, et une colonne a la priorité sur le format du tableau entier.

Ainsi, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) sont finalement utilisées pour dessiner le tableau. L’exemple suivant montre comment obtenir le format de remplissage effectif pour les différents niveaux du tableau :

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

**Comment savoir si j’ai récupéré un « instantané » plutôt qu’un « objet vivant », et quand dois‑je relire les propriétés effectives ?**

Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez des paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**Le changement de la diapositive de disposition/maître affecte‑t‑il les propriétés effectives déjà récupérées ?**

Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour — il faut le demander de nouveau après avoir modifié la disposition ou le maître.

**Puis‑je modifier des valeurs via EffectiveData ?**

Non. EffectiveData est en lecture seule. Effectuez les modifications dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans la disposition/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut (les paramètres par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?**

Pas directement. EffectiveData renvoie la valeur finale. Pour en connaître la source, examinez les valeurs locales au niveau de la portion/paragraphe/cadre de texte et les styles de texte au niveau de la disposition/maître/presentation afin de voir où la première définition explicite apparaît.

**Pourquoi les valeurs EffectiveData ressemblent parfois aux valeurs locales ?**

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’était nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand faut‑il utiliser les propriétés effectives et quand se contenter des locales ?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après application de toute l’héritage (par ex., pour aligner les couleurs, retraits ou tailles). Si vous avez besoin de modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.