---
title: Créer des présentations 3D en Python
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Générez des présentations 3D interactives en Python avec Aspose.Slides sans effort. Exportez rapidement aux formats PowerPoint et OpenDocument pour une utilisation polyvalente."
---

## **Vue d'ensemble**

Comment créez‑vous habituellement une présentation PowerPoint 3D ? Microsoft PowerPoint vous permet d’ajouter des modèles 3D, d’appliquer des effets 3D aux formes, de créer du texte 3D, d’insérer des graphiques 3D et de construire des animations 3D.

La création d’effets 3D a un fort impact et constitue souvent le moyen le plus simple de transformer un diaporama standard en une présentation 3D. Depuis Aspose.Slides 20.9, un nouveau **moteur 3D multiplateforme** a été ajouté. Ce moteur permet d’exporter et de rasteriser des formes et du texte avec des effets 3D. Dans les versions antérieures, les formes avec des effets 3D étaient rendues à plat ; maintenant elles peuvent être rendues avec un **vrai rendu 3D**. Vous pouvez également créer des formes avec des effets 3D via l’API Aspose.Slides.

Dans l’API Aspose.Slides, pour transformer une forme en forme PowerPoint 3D, utilisez la propriété [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) qui expose les membres de la classe [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) :

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) et [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) : définir les chanfreins, choisir un type de chanfrein (p. ex., Angle, Cercle, SoftRound) et préciser la hauteur et la largeur du chanfrein.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) : simuler le mouvement de la caméra autour de l’objet ; en ajustant la rotation, le zoom et d’autres propriétés de la caméra, vous pouvez manipuler les formes comme des modèles 3D dans PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) et [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) : définir les propriétés du contour pour que la forme ressemble à un objet PowerPoint 3D.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/), [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) et [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) : rendre une forme tridimensionnelle en définissant sa profondeur ou en l’extrudant.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) : créer des effets d’éclairage sur une forme 3D ; similaire à la caméra, vous pouvez définir la rotation de la lumière par rapport à la forme 3D et choisir un type de lumière.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) : sélectionner un matériau pour rendre la forme 3D plus réaliste. Les matériaux prédéfinis incluent Métal, Plastique, Poudre, Mat, etc.

Toutes les fonctionnalités 3D peuvent être appliquées aux formes comme au texte. Les sections suivantes montrent comment accéder à ces propriétés, puis les examiner pas à pas.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

La vignette rendue ressemble à cela :

![todo:image_alt_text](img_01_01.png)

## **Rotation 3D**

Vous pouvez faire pivoter les formes PowerPoint 3D dans l’espace tridimensionnel pour ajouter de l’interactivité. Pour faire pivoter une forme 3D dans PowerPoint, utilisez le menu suivant :

![todo:image_alt_text](img_02_01.png)

Dans l’API Aspose.Slides, vous contrôlez la rotation 3D d’une forme via la propriété [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) :

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... définir d'autres paramètres de scène 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **Profondeur 3D et Extrusion**

Pour ajouter une troisième dimension à votre forme et la rendre véritablement 3D, utilisez les propriétés [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) et [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) :

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... définir d'autres paramètres de scène 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

Dans PowerPoint, vous utilisez généralement le menu **Profondeur** pour régler la profondeur d’une forme 3D :

![todo:image_alt_text](img_02_02.png)

## **Dégradé 3D**

Un dégradé peut être utilisé pour remplir une forme PowerPoint 3D. Créons une forme avec un remplissage dégradé et appliquons‑lui un effet 3D :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)
   
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Et voici le résultat :

![todo:image_alt_text](img_02_03.png)

En plus des remplissages en dégradé, vous pouvez remplir les formes avec une image :

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... configurer 3D : shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* propriétés

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Voici à quoi cela ressemble :

![todo:image_alt_text](img_02_04.png)

## **Texte 3D (WordArt)**

Aspose.Slides vous permet d’appliquer des effets 3D au texte également. Pour créer du texte 3D, vous pouvez utiliser l’effet de transformation WordArt :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # configurer l'effet de transformation WordArt \"Arch Up\"
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Voici le résultat :

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Les effets 3D seront-ils conservés lors de l'exportation d'une présentation vers des images/PDF/HTML ?**

Oui. Le moteur 3D de Slides rend les effets 3D lors de l'exportation vers les formats pris en charge ([images](/slides/fr/python-net/convert-powerpoint-to-png/), [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), etc.).

**Puis‑je récupérer les valeurs « effectives » (finales) des paramètres 3D qui tiennent compte des thèmes, de l'héritage, etc. ?**

Oui. Slides propose des API pour [lire les valeurs effectives](/slides/fr/python-net/shape-effective-properties/) (y compris pour la 3D — éclairage, chanfreins, etc.) afin que vous puissiez voir les paramètres appliqués réellement.

**Les effets 3D fonctionnent‑ils lors de la conversion d'une présentation en vidéo ?**

Oui. Lors de la [génération des images pour la vidéo](/slides/fr/python-net/convert-powerpoint-to-video/), les effets 3D sont rendus exactement comme pour les [images exportées](/slides/fr/python-net/convert-powerpoint-to-png/).