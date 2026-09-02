---
title: Format des formes PowerPoint en Python
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/python-net/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme en croquis
- format du style de jointure
- remplissage en dégradé
- remplissage par motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en Python avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont constituées de lignes, vous pouvez les formater en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format de forme PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python fournit des classes et des propriétés qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formatage des lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [line style](https://reference.aspose.com/slides/fr/python-net/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [dash style](https://reference.aspose.com/slides/fr/python-net/aspose.slides/linedashstyle/) de la forme.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Définir la couleur de remplissage pour la forme rectangle.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Appliquer le formatage aux lignes du rectangle.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Définir la couleur de la ligne du rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à une ligne de forme un aspect dessiné à la main. Utilisez [Shape.line_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/line_format/) pour accéder aux paramètres de ligne, [LineFormat.sketch_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/lineformat/sketch_format/) pour accéder aux paramètres de croquis, et [SketchFormat.sketch_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sketchformat/sketch_type/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/linesketchtype/).

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Accéder au format de ligne de la forme et à son format de croquis.
    sketch_format = shape.line_format.sketch_format

    # Appliquer un effet de croquis.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lire l'effet de croquis assigné directement à la forme.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Supprimer l'effet de croquis.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

La valeur renvoyée par `SketchFormat.sketch_type` représente le paramètre attribué directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [LineFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/lineformat/get_effective/), accédez à la propriété `sketch_format` de l’objet retourné, et lisez sa propriété `sketch_type`. La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

	# Obtenir la première diapositive.
	slide = presentation.slides[0]

	# Ajouter trois formes auto de type Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Définir la couleur de remplissage pour chaque forme rectangle.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Définir la largeur de la ligne.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Définir la couleur de la ligne de chaque rectangle.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Définir le style de jointure.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Ajouter du texte à chaque rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Enregistrer le fichier PPTX sur le disque.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de formatage qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) de la forme sur `GRADIENT`.
1. Ajoutez vos deux couleurs préférées avec des positions définies à l’aide des méthodes `add` de la collection `gradient_stops` exposée par la classe [GradientFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/gradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Appliquer un formatage en dégradé à l'ellipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Définir la direction du dégradé.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Ajouter deux arrêts de dégradé.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'ellipse avec remplissage en dégradé](gradient-fill.png)

## **Remplissage par motif**

Dans PowerPoint, le remplissage par motif est une option de formatage qui vous permet d’appliquer un motif bicolore – tel que des points, des rayures, des hachures croisées ou des carreaux – à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes qu’il doit utiliser.

Voici comment appliquer un remplissage par motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) de la forme sur `PATTERN`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la propriété [back_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/patternformat/back_color/) du motif.
1. Définissez la propriété [fore_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/patternformat/fore_color/) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Définir le type de remplissage sur Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Définir le style de motif.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Définir les couleurs d'arrière-plan et de premier plan du motif.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le rectangle avec remplissage par motif](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet d’insérer une image à l’intérieur d’une forme – en utilisant effectivement l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) de la forme sur `PICTURE`.
1. Définissez le mode de remplissage d'image sur `TILE` (ou un autre mode préféré).
1. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Assignez cette image à la propriété `picture.image` du `picture_fill_format` de la forme.
1. Enregistrez la présentation modifiée au format PPTX.

![L'image lotus](lotus.png)

```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Définir le type de remplissage sur Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Définir le mode de remplissage d'image.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Charger une image et l'ajouter aux ressources de la présentation.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Définir l'image.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme avec remplissage d'image](picture-fill.png)

### **Utiliser l'image en tant que texture carrelée**

Si vous souhaitez définir une image carrelée comme texture et personnaliser le comportement de carrelage, vous pouvez utiliser les propriétés suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Définit le mode de remplissage de l'image — soit `TILE` soit `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_alignment/): Spécifie l’alignement des carreaux à l’intérieur de la forme.
- [tile_flip](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_flip/): Contrôle si le carreau est retourné horizontalement, verticalement ou les deux.
- [tile_offset_x](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_offset_x/): Définit le décalage horizontal du carreau (en points) depuis l’origine de la forme.
- [tile_offset_y](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_offset_y/): Définit le décalage vertical du carreau (en points) depuis l’origine de la forme.
- [tile_scale_x](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_scale_x/): Définit l’échelle horizontale du carreau en pourcentage.
- [tile_scale_y](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/tile_scale_y/): Définit l’échelle verticale du carreau en pourcentage.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    first_slide = presentation.slides[0]

    # Ajouter une forme auto rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Définir le type de remplissage de la forme sur Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Charger l'image et l'ajouter aux ressources de la présentation.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Assigner l'image à la forme.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configurer le mode de remplissage d'image et les propriétés de carrelage.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les options de carrelage](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de formatage qui remplit une forme avec une seule couleur uniforme. Cette couleur de fond simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) de la forme sur `SOLID`.
1. Assignez votre couleur de remplissage préférée à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Définir le type de remplissage sur Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Définir la couleur de remplissage.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, de dégradé, d’image ou de texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment faire :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le type de remplissage sur `SOLID`.
1. Utilisez `Color.from_argb` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]
    
    # Ajouter une forme auto rectangle solide.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ajouter une forme auto rectangle transparente au-dessus de la forme solide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez la propriété `rotation` de la forme sur l’angle souhaité.
1. Enregistrez la présentation.

```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Faire pivoter la forme de 5 degrés.
    shape.rotation = 5

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Ajouter une forme à la diapositive.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Définir les propriétés ThreeDFormat de la forme.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Enregistrer la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [camera_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/camera/camera_type/) et le [light_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/lightrig/light_type/) de la forme pour spécifier la rotation 3D.
1. Enregistrez la présentation.

```python
import aspose.slides as slides

# Créer une instance de la classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Enregistrer la présentation au format PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'effet de rotation 3D](3D-rotation-effect.png)

## **Réinitialiser le formatage**

Le code Python suivant montre comment réinitialiser le formatage d’une diapositive et ramener la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille du fichier de la présentation finale ?**

Seulement de façon minimale. Les images et les médias intégrés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment puis‑je détecter les formes d’une diapositive qui partagent un format identique afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Conservez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.