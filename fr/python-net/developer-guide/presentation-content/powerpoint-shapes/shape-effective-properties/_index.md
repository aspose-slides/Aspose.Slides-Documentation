---
title: Propriétés Effectives de Forme
type: docs
weight: 50
url: /fr/python-net/shape-effective-properties/
keywords: "Propriétés de forme, Propriétés de caméra, éclairage, forme de chanfrein, cadre de texte, style de texte, valeur de hauteur de police, format de remplissage pour tableau, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Obtenez les propriétés effectives de forme dans les présentations PowerPoint en Python"
---

Dans ce sujet, nous allons discuter des propriétés **effectives** et **locales**. Lorsque nous fixons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur le diapositive de la portion.
1. Dans le style de texte de forme prototype sur la mise en page ou la diapositive maître (si le cadre de texte de la portion en a un).
1. Dans les paramètres de texte globaux de la présentation.

alors ces valeurs sont appelées valeurs **locales**. À tout niveau, les valeurs **locales** peuvent être définies ou omises. Mais finalement, quand il s'agit du moment où l'application a besoin de savoir à quoi la portion doit ressembler, elle utilise les valeurs **effectives**. Vous pouvez obtenir des valeurs effectives en utilisant la méthode **getEffective()** à partir du format local.

L'exemple suivant montre comment obtenir des valeurs effectives.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **Obtenir les Propriétés Effectives de la Caméra**
Aspose.Slides pour Python via .NET permet aux développeurs d'obtenir les propriétés effectives de la caméra. Dans ce but, la classe **CameraEffectiveData** a été ajoutée dans Aspose.Slides. La classe CameraEffectiveData représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée comme partie de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

Le code d'exemple suivant montre comment obtenir les propriétés effectives pour la caméra.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Propriétés effectives de la caméra =")
	print("Type: " + str(threeDEffectiveData.camera.camera_type))
	print("Champ de vision: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("Zoom: " + str(threeDEffectiveData.camera.zoom))
```


## **Obtenir les Propriétés Effectives de l'Éclairage**
Aspose.Slides pour Python via .NET permet aux développeurs d'obtenir les propriétés effectives de l'Éclairage. Dans ce but, la classe **LightRigEffectiveData** a été ajoutée dans Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable qui contient les propriétés effectives de l'éclairage. Une instance de la classe **LightRigEffectiveData** est utilisée comme partie de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

Le code d'exemple suivant montre comment obtenir les propriétés effectives pour l'éclairage.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Propriétés effectives de l'éclairage =")
	print("Type: " + str(threeDEffectiveData.light_rig.light_type))
	print("Direction: " + str(threeDEffectiveData.light_rig.direction))
```


## **Obtenir les Propriétés Effectives de la Forme de Chanfrein**
Aspose.Slides pour Python via .NET permet aux développeurs d'obtenir les propriétés effectives de la Forme de Chanfrein. Dans ce but, la classe **ShapeBevelEffectiveData** a été ajoutée dans Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable qui contient les propriétés de relief de la face de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée comme partie de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

Le code d'exemple suivant montre comment obtenir les propriétés effectives pour la Forme de Chanfrein.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Propriétés effectives de la face supérieure de la forme =")
	print("Type: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("Largeur: " + str(threeDEffectiveData.bevel_top.width))
	print("Hauteur: " + str(threeDEffectiveData.bevel_top.height))
```



## **Obtenir les Propriétés Effectives du Cadre de Texte**
En utilisant Aspose.Slides pour Python via .NET, vous pouvez obtenir les propriétés effectives du Cadre de Texte. Dans ce but, la classe **TextFrameFormatEffectiveData** a été ajoutée dans Aspose.Slides qui contient les propriétés de formatage effectives du cadre de texte.

Le code d'exemple suivant montre comment obtenir les propriétés de formatage du cadre de texte effectives.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("Type d'ancrage: " + str(effectiveTextFrameFormat.anchoring_type))
	print("Type d'ajustement automatique: " + str(effectiveTextFrameFormat.autofit_type))
	print("Type vertical de texte: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("Marges")
	print("   Gauche: " + str(effectiveTextFrameFormat.margin_left))
	print("   Haut: " + str(effectiveTextFrameFormat.margin_top))
	print("   Droite: " + str(effectiveTextFrameFormat.margin_right))
	print("   Bas: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **Obtenir les Propriétés Effectives du Style de Texte**
En utilisant Aspose.Slides pour Python via .NET, vous pouvez obtenir les propriétés effectives du Style de Texte. Dans ce but, la classe **TextStyleEffectiveData** a été ajoutée dans Aspose.Slides qui contient les propriétés de style de texte effectives.

Le code d'exemple suivant montre comment obtenir les propriétés de style de texte effectives.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= Formatage de paragraphe effectif pour le niveau de style #" + str(i) + " =")

        print("Profondeur: " + str(effectiveStyleLevel.depth))
        print("Retrait: " + str(effectiveStyleLevel.indent))
        print("Alignement: " + str(effectiveStyleLevel.alignment))
        print("Alignement de la police: " + str(effectiveStyleLevel.font_alignment))

```


## **Obtenir la Valeur de Hauteur de Police Effective**
En utilisant Aspose.Slides pour Python via .NET, vous pouvez obtenir les propriétés de la Hauteur de Police Effective. Voici le code démontrant la valeur effective de hauteur de police de la portion changeant après avoir défini des valeurs de hauteur de police locales à différents niveaux de structure de présentation.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("Texte d'exemple avec la première portion")
    portion1 = slides.Portion(" et la seconde portion.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("Hauteur de police effective immédiatement après la création:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Hauteur de police effective après avoir défini la hauteur de police par défaut de l'ensemble de la présentation:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("Hauteur de police effective après avoir défini la hauteur de police par défaut du paragraphe:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("Hauteur de police effective après avoir défini la hauteur de police de la portion #0:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("Hauteur de police effective après avoir défini la hauteur de police de la portion #1:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Obtenir le Format de Remplissage Effectif pour le Tableau**
En utilisant Aspose.Slides pour Python via .NET, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques de tableau. Dans ce but, l'interface **IFillFormatEffectiveData** a été ajoutée dans Aspose.Slides qui contient les propriétés de formatage de remplissage effectives. Veuillez noter que le formatage des cellules a toujours une priorité plus élevée que le formatage des lignes, une ligne a une priorité plus élevée que la colonne et la colonne plus élevée que l'ensemble du tableau.

Ainsi, finalement, les propriétés **CellFormatEffectiveData** sont toujours utilisées pour dessiner le tableau. Le code d'exemple suivant montre comment obtenir le format de remplissage effectif pour différentes parties logiques du tableau.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```