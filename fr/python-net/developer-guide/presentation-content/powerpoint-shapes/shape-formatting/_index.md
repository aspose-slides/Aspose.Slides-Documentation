---
title: Formater les formes PowerPoint en Python
linktitle: Formatage des formes
type: docs
weight: 20
url: /fr/python-net/shape-formatting/
keywords:
- mise en forme de forme
- mise en forme de ligne
- mise en forme du style de jointure
- remplissage dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage de couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en Python avec Aspose.Slides — définissez les styles de remplissage, de ligne et d'effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---

## **Vue d'ensemble**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format de forme PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python fournit des classes et des propriétés qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Mettre en forme les lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme.  
Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) de la forme.
1. Définir la couleur de ligne de la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment mettre en forme un `AutoShape` rectangle :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Définit la couleur de remplissage pour la forme rectangle.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Applique le formatage aux lignes du rectangle.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Définit la couleur de la ligne du rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Mettre en forme les styles de jointure**

Voici les trois options de type de jointure :

* Arrondi
* Arête
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (comme à l'angle d'une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles aigus, vous pourriez préférer l’option **Arête**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code Python suivant montre comment trois rectangles (comme indiqué sur l'image ci‑above) ont été créés en utilisant les paramètres de type de jointure Miter, Bevel et Round :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

	# Récupère la première diapositive.
	slide = presentation.slides[0]

	# Ajoute trois formes automatiques de type Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Définit la couleur de remplissage pour chaque forme rectangle.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Définit la largeur de la ligne.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Définit la couleur de la ligne de chaque rectangle.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Définit le style de jointure.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Ajoute du texte à chaque rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Enregistre le fichier PPTX sur le disque.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```


## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de mise en forme qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme à `GRADIENT`.
1. Ajouter vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection `gradient_stops` exposée par la classe [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un effet de remplissage dégradé à une ellipse :

```python
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme automatique de type Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Applique un format de dégradé à l'ellipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Définit la direction du dégradé.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Ajoute deux arrêts de dégradé.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![L'ellipse avec remplissage dégradé](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d'appliquer un motif à deux couleurs — comme des points, des rayures, des hachures ou des carreaux — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l'arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l'attrait visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme à `PATTERN`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir le [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) du motif.
1. Définir le [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) du motif.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un remplissage de motif à un rectangle :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme automatique de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Définit le type de remplissage sur Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Définit le style du motif.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Définit les couleurs d'arrière-plan et de premier plan du motif.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de mise en forme qui vous permet d'insérer une image à l'intérieur d'une forme — utilisant effectivement l'image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme à `PICTURE`.
1. Définir le mode de remplissage d'image sur `TILE` (ou un autre mode préféré).
1. Créer un objet [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) à partir de l'image que vous souhaitez utiliser.
1. Attribuer cette image à la propriété `picture.image` du `picture_fill_format` de la forme.

L'image lotus :

![L'image lotus](lotus.png)

Le code Python suivant montre comment remplir une forme avec l'image :

```python
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme automatique de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Définit le type de remplissage sur Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Définit le mode de remplissage d'image.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Charge une image et l'ajoute aux ressources de la présentation.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Définit l'image.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La forme avec remplissage d'image](picture-fill.png)

### **Mosaïquer l'image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du mosaïquage, vous pouvez utiliser les propriétés suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Définit le mode de remplissage d'image — soit `TILE`, soit `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Spécifie l'alignement des tuiles à l'intérieur de la forme.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Définit le décalage horizontal de la tuile (en points) par rapport à l'origine de la forme.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Définit le décalage vertical de la tuile (en points) par rapport à l'origine de la forme.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Définit l'échelle horizontale de la tuile en pourcentage.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Définit l'échelle verticale de la tuile en pourcentage.

L'exemple de code suivant montre comment ajouter une forme rectangle avec un remplissage d'image en mosaïque et configurer les options de tuile :

```py
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    first_slide = presentation.slides[0]

    # Ajoute une forme auto rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Définit le type de remplissage de la forme sur Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Charge l'image et l'ajoute aux ressources de la présentation.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Assigne l'image à la forme.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configure le mode de remplissage d'image et les propriétés de mosaïquage.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Les options de mosaïque](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme avec une couleur unique et uniforme. Cette couleur d'arrière‑plan simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme à `SOLID`.
1. Attribuer votre couleur de remplissage préférée à la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme automatique de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Définit le type de remplissage sur Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Définit la couleur de remplissage.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l'opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant à l'arrière‑plan ou aux objets sous‑jacent d'être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le type de remplissage à `SOLID`.
1. Utiliser `Color.from_argb` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]
    
    # Ajoute une forme auto rectangle solide.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ajoute une forme auto rectangle transparente au-dessus de la forme solide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d'éléments visuels avec des besoins d'alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir la propriété `rotation` de la forme à l'angle souhaité.
1. Enregistrer la présentation.

Le code Python suivant montre comment faire pivoter une forme de 5 degrés :

```python
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Fais pivoter la forme de 5 degrés.
    shape.rotation = 5

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d'appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) :

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la forme pour définir les paramètres du biseau.
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer des effets de biseau 3D à une forme :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Ajoutez une forme à la diapositive.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Définissez les propriétés ThreeDFormat de la forme.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Enregistrez la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![L'effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d'appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) :

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définir le [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) et le [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) de la forme pour définir la rotation 3D.
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer des effets de rotation 3D à une forme :

```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Enregistrez la présentation au format PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![L'effet de rotation 3D](3D-rotation-effect.png)

## **Réinitialiser la mise en forme**

Le code Python suivant montre comment réinitialiser la mise en forme d'une diapositive et ramener la position, la taille et la mise en forme de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) aux paramètres par défaut :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la disposition.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement légèrement. Les images et médias incorporés occupent la majeure partie de l'espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n'ajoutent pratiquement aucune taille supplémentaire.

**Comment puis‑je détecter les formes sur une diapositive qui partagent un même formatage afin de les grouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d'effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure du style.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d'exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d'une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin, et réappliquez leur formatage où cela est requis.