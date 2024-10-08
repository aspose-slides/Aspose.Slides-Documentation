---
title: Présentation 3D
type: docs
weight: 232
url: /fr/python-net/3d-presentation/
keywords:
- 3D
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- présentation PowerPoint
- Python
- Aspose.Slides pour Python via .NET
description: "Présentation PowerPoint 3D en Python"
---


## Aperçu
Comment créez-vous généralement une présentation PowerPoint 3D ?
Microsoft PowerPoint permet de créer des présentations 3D en ce sens que nous pouvons y ajouter des modèles 3D, appliquer des effets 3D sur des formes, 
créer du texte 3D, télécharger des graphiques 3D dans la présentation, créer des animations 3D PowerPoint.

Créer des effets 3D a un grand impact sur l'amélioration de votre présentation en une présentation 3D, et cela peut être l'implémentation la plus simple d'une présentation 3D. 
Depuis la version 20.9 d'Aspose.Slides, un nouveau **moteur 3D multiplateforme** a été ajouté. Le nouveau moteur 3D permet 
d'exporter et de rasteriser des formes et du texte avec des effets 3D. Dans les versions précédentes, 
les formes de diapositives avec des effets 3D appliqués étaient rendues à plat. Mais maintenant, il est possible de 
rendre des formes avec un **vrai 3D**.
De plus, il est maintenant possible de créer des formes avec des effets 3D via l'API publique des Slides.

Dans l'API Aspose.Slides, pour transformer 
une forme en forme 3D PowerPoint, utilisez la propriété [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), 
qui hérite des fonctionnalités de l'interface [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat) :
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
et [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : définissez le biseau de la forme, définissez le type de biseau (par exemple, Angle, Cercle, Doux), définissez la hauteur et la largeur du biseau.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : est utilisé pour imiter les mouvements de la caméra autour de l'objet. En d'autres termes, en définissant la rotation de la caméra, le zoom et d'autres propriétés - vous pouvez manipuler vos 
formes comme un modèle 3D dans PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
et [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : définissez les propriétés de contour pour donner à la forme l'apparence d'une forme 3D PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
et [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : sont utilisés pour rendre la forme tridimensionnelle, ce qui signifie convertir une forme 2D en une forme 3D, 
en définissant sa profondeur ou en l'extrudant.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : peut créer un effet lumineux sur une forme 3D. La logique de cette propriété est proche de Camera, vous pouvez définir la rotation de la lumière 
par rapport à la forme 3D et choisir le type de lumière.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) : définir le type de matériau de la forme 3D peut apporter un effet plus vivant. La propriété fournit un ensemble de matériaux prédéfinis, tels que : 
Métal, Plastique, Poudre, Mat, etc.  

All features 3D peuvent s'appliquer aussi bien aux formes qu'au texte. Voyons comment accéder aux propriétés mentionnées ci-dessus puis les examiner en détail étape par étape :
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

La vignette rendue ressemble à ceci :

![todo:image_alt_text](img_01_01.png)

## Rotation 3D
Il est possible de faire pivoter les formes 3D PowerPoint dans un plan 3D, ce qui apporte plus d'interactivité. Pour faire pivoter une forme 3D dans PowerPoint, vous utilisez généralement le menu suivant :

![todo:image_alt_text](img_02_01.png)

Dans l'API Aspose.Slides, la rotation de forme 3D peut être gérée à l'aide de la propriété [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) :

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... définir d'autres paramètres de scène 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## Profondeur et Extrusion 3D
Pour apporter la troisième dimension à votre forme et en faire une forme 3D, utilisez les propriétés [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
et [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) :

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... définir d'autres paramètres de scène 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

En général, vous utilisez le menu Profondeur dans PowerPoint pour définir la profondeur d'une forme 3D PowerPoint :

![todo:image_alt_text](img_02_02.png)


## Dégradé 3D
Un dégradé peut être utilisé pour remplir la couleur d'une forme 3D PowerPoint. Créons une forme avec une couleur de remplissage dégradée et appliquons-lui un effet 3D :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "Dégradé 3D"
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

Et voici le résultat :

![todo:image_alt_text](img_02_03.png)

En plus d'une couleur de remplissage dégradée, il est possible de remplir les formes avec une image :
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... configurer 3D : shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* propriétés

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


Voilà à quoi cela ressemble :

![todo:image_alt_text](img_02_04.png)

## Texte 3D (WordArt)
Aspose.Slides permet également d'appliquer des effets 3D au texte. Pour créer un texte 3D, il est possible d'utiliser l'effet de transformation WordArt :

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
    shape.text_frame.text = "Texte 3D"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # configurer l'effet de transformation WordArt "Arc vers le haut"
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

Voici le résultat :

![todo:image_alt_text](img_02_05.png)


## Non pris en charge - Arriver bientôt
Les fonctionnalités 3D suivantes de PowerPoint ne sont pas encore prises en charge : 
- Biseau
- Matériau
- Contour
- Éclairage

Nous continuons d'améliorer notre moteur 3D, et ces fonctionnalités sont sujettes à une future implémentation.