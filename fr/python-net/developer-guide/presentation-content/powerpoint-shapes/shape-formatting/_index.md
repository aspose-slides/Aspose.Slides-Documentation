---
title: Formatage des Formes
type: docs
weight: 20
url: /fr/python-net/shape-formatting/
keywords: "Format de forme, format de lignes, styles de jointure, remplissage dégradé, remplissage à motifs, remplissage d'image, remplissage en couleur uniforme, rotation des formes, effets de biseau 3D, effet de rotation 3D, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Formater les formes dans une présentation PowerPoint en Python"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont constituées de lignes, vous pouvez formater des formes en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone qui les contient) sont remplies.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour Python via .NET** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint.

## **Format des Lignes**

En utilisant Aspose.Slides, vous pouvez spécifier votre style de ligne préféré pour une forme. Ces étapes décrivent une telle procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez une couleur pour les lignes de la forme.
5. Définissez la largeur pour les lignes de la forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) pour la ligne de la forme.
7. Définissez le [style de trait](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) pour la ligne de la forme.
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre une opération où nous avons formaté un rectangle `AutoShape` :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Prseetation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Ajoute une forme rectangulaire
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Définit la couleur de remplissage pour la forme rectangle
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Applique un certain formatage sur les lignes du rectangle
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Définit la couleur pour la ligne du rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Écrit le fichier PPTX sur le disque
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **Styles de Jointure**

Voici les 3 options de type de jointure :

* Ronde
* Mitre
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes à un angle (ou le coin d'une forme), il utilise le paramètre **Rond**. Cependant, si vous souhaitez dessiner une forme avec des angles très aigus, vous voudrez peut-être sélectionner **Mitre**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce code Python démontre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de type de jointure Mitre, Biseau et Rond :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Prseetation qui représente un fichier PPTX
with slides.Presentation() as pres:
	# Obtient la première diapositive
	sld = pres.slides[0]

	# Ajoute 3 formes rectangulaires
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# Définit la couleur de remplissage pour la forme rectangle
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# Définit la largeur de la ligne
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# Définit la couleur pour la ligne du rectangle
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Définit le style de jointure
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Ajoute du texte à chaque rectangle
	shp1.text_frame.text = "Ceci est le style de jointure Mitre"
	shp2.text_frame.text = "Ceci est le style de jointure Biseau"
	shp3.text_frame.text = "Ceci est le style de jointure Rond"

	# Écrit le fichier PPTX sur le disque
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage Dégradé**

Dans PowerPoint, le remplissage dégradé est une option de formatage qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus dans une configuration où une couleur s'estompe progressivement et se transforme en une autre couleur.

Voici comment vous utilisez Aspose.Slides pour appliquer un remplissage dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies en utilisant les méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre une opération où l'effet de remplissage dégradé a été utilisé sur une ellipse :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation qui représente un fichier de présentation
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Ajoute une forme d'ellipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Applique le formatage dégradé à l'ellipse
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Définit la direction du dégradé
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Ajoute 2 arrêts de dégradé
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Écrit le fichier PPTX sur le disque
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage à Motifs**

Dans PowerPoint, le remplissage à motifs est une option de formatage qui vous permet d'appliquer un design bicolore comprenant des points, des rayures, des hachures croisées ou des carreaux à une forme. De plus, vous pouvez choisir vos couleurs préférées pour le premier plan et l'arrière-plan de votre motif.

Aspose.Slides propose plus de 45 styles prédéfinis qui peuvent être utilisés pour formater des formes et enrichir des présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment vous utilisez Aspose.Slides pour appliquer un remplissage à motifs à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme sur `Pattern`.
5. Définissez votre style de motif préféré pour la forme.
6. Définissez la couleur d'arrière-plan pour le [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. Définissez la couleur de premier plan pour le [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre une opération où un remplissage à motifs a été utilisé pour embellir un rectangle :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation qui représente un fichier de présentation
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Ajoute une forme rectangulaire
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Définit le type de remplissage sur Pattern
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Définit le style du motif
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Définit les couleurs de fond et de premier plan du motif
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Écrit le fichier PPTX sur le disque
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage d'Image**

Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet de placer une image à l'intérieur d'une forme. Essentiellement, vous pouvez utiliser une image comme arrière-plan d'une forme.

Voici comment vous utilisez Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme sur `Picture`.
5. Définissez le mode de remplissage d'image sur Carreaux.
6. Créez un objet `IPPImage` à l'aide de l'image qui sera utilisée pour remplir la forme.
7. Définissez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur l'`IPPImage` récemment créé.
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment remplir une forme avec une image :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Prseetation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Ajoute une forme rectangulaire
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Définit le type de remplissage sur Picture
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Définit le mode de remplissage d'image
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Définit l'image
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # Écrit le fichier PPTX sur le disque
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage en Couleur Unie**

Dans PowerPoint, le remplissage en couleur uniforme est une option de formatage qui vous permet de remplir une forme avec une seule couleur. La couleur choisie est généralement une couleur unie. La couleur est appliquée à l'arrière-plan de la forme sans effets ou modifications spéciales.

Voici comment vous utilisez Aspose.Slides pour appliquer un remplissage en couleur uniforme à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment appliquer le remplissage en couleur solide à une boîte dans PowerPoint :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Obtient la première diapositive
    slide = presentation.slides[0]

    # Ajoute une forme rectangulaire
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Définit le type de remplissage sur Solid
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Définit la couleur pour le rectangle
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Écrit le fichier PPTX sur le disque
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. De cette façon, par exemple, si vous définissez un faible niveau de transparence, l'objet de diapositive ou l'arrière-plan derrière (la forme) apparaîtra.

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Utilisez `Color.FromArgb` avec le composant alpha défini.
5. Sauvegardez l'objet en tant que fichier PowerPoint.

Ce code Python démontre le processus :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Ajoute une forme solide
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # Ajoute une forme transparente par dessus la forme solide
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Rotation des Formes**

Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Faites pivoter la forme du nombre de degrés nécessaires.
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment faire pivoter une forme de 90 degrés :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Ajoute une forme rectangulaire
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Fait pivoter la forme de 90 degrés
    shp.rotation = 90

    # Écrit le fichier PPTX sur le disque
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Effets de Biseau 3D**

Aspose.Slides pour Python via .NET vous permet d'ajouter des effets de biseau 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Définissez vos paramètres préférés pour les propriétés [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la forme.
5. Enregistrez la présentation sur le disque.

Ce code Python vous montre comment ajouter des effets de biseau 3D à une forme :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Ajoute une forme à la diapositive
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Définit les propriétés ThreeDFormat de la forme
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Écrit la présentation en tant que fichier PPTX
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter un Effet de Rotation 3D**

Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) à la diapositive.
4. Spécifiez vos figures préférées pour CameraType et LightType.
5. Enregistrez la présentation sur le disque.

Ce code Python vous montre comment appliquer des effets de rotation 3D à une forme :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **Réinitialiser le Formatage**

Ce code Python vous montre comment réinitialiser le formatage dans une diapositive et revenir à la position, à la taille et au formatage par défaut de chaque forme qui a un espace réservé sur [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # chaque forme sur la diapositive qui a un espace réservé sur la mise en page sera rétablie
        slide.reset()
```