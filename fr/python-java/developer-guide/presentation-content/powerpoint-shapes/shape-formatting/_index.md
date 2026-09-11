---
title: Mise en forme des formes PowerPoint en Python via Java
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/python-java/shape-formatting/
keywords:
- mise en forme de forme
- mise en forme de ligne
- effet de croquis
- ligne de forme croquis
- mise en forme du style de jointure
- remplissage dégradé
- remplissage en motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rendu noir et blanc de forme
- rendu en niveaux de gris de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en Python via Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la manière dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java fournit des classes et des méthodes qui vous permettent de mettre en forme des formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Format des lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [style de ligne](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [style de tiret](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de la ligne pour la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code suivant montre comment mettre en forme un rectangle [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Définit la couleur de remplissage pour la forme rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Applique le formatage aux lignes du rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Définit la couleur de la ligne du rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à la ligne d’une forme un aspect dessiné à la main. Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getLineFormat) pour accéder aux paramètres de ligne, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/lineformat/#getSketchFormat) pour accéder aux paramètres de croquis, et [SketchFormat.setSketchType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sketchformat/#setSketchType) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linesketchtype/).

Le code Python suivant montre comment appliquer l’effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linesketchtype/#Curved), lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None_](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linesketchtype/#None) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpyruntime = jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Accéder au format de ligne de la forme et à son format de croquis.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Appliquer un effet de croquis.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Lire l'effet de croquis assigné directement à la forme.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Supprimer l'effet de croquis.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

La valeur renvoyée par [SketchFormat.getSketchType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sketchformat/#getSketchType) représente le paramètre assigné directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de mise en page, utilisez [LineFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/lineformat/#getEffective), accédez à `LineFormatEffectiveData.getSketchFormat` et lisez `SketchFormatEffectiveData.getSketchType`. La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Format des styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code Python suivant montre comment trois rectangles (comme illustré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute trois formes auto de type Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Définit la couleur de remplissage pour chaque forme rectangle.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Définit la largeur de la ligne.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Définit la couleur de la ligne de chaque rectangle.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Définit le style de jointure.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Ajoute du texte à chaque rectangle.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de mise en forme qui vous permet d’appliquer un fondu continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de façon à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec leurs positions définies en utilisant la méthode [addPresetColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gradientstopcollection/#addPresetColor) de la collection de points d’arrêt du dégradé exposée par la classe [GradientFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gradientformat/).
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un effet de remplissage dégradé à une ellipse :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Applique le formatage dégradé à l'ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Définit la direction du dégradé.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Ajoute deux arrêts de dégradé.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'ellipse avec remplissage dégradé](gradient-fill.png)

## **Remplissage en motif**

Dans PowerPoint, le remplissage en motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore — tel que des points, des bandes, des hachures croisées ou des carreaux—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage en motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [Background Color](https://reference.aspose.com/slides/fr/python-java/aspose.slides/patternformat/#getBackColor) du motif.
1. Définir la [Foreground Color](https://reference.aspose.com/slides/fr/python-java/aspose.slides/patternformat/#getForeColor) du motif.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un remplissage en motif à un rectangle :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Définit le type de remplissage à Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Définit le style de motif.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Définit les couleurs d'arrière-plan et de premier plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le rectangle avec remplissage en motif](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d'image sur `Tile` (ou tout autre mode préféré).
1. Créer un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `SlidesPicture.setImage`.
1. Enregistrer la présentation modifiée au format PPTX.

Supposons que nous disposions d’un fichier « lotus.png » contenant l’image suivante :

![The lotus picture](lotus.png)

Le code Python suivant montre comment remplir une forme avec cette image :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Définit le type de remplissage à Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Définit le mode de remplissage d'image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Charge une image et l'ajoute aux ressources de la présentation.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Définit l'image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La forme avec remplissage d'image](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setPictureFillMode) : Définit le mode de remplissage d'image — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileAlignment) : Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileFlip) : Contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileOffsetX) : Définit le déplacement horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileOffsetY) : Définit le déplacement vertical de la tuile (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileScaleX) : Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#setTileScaleY) : Définit l’échelle verticale de la tuile en pourcentage.

Le code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de mosaïque :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    first_slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto rectangle.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Définit le type de remplissage de la forme à Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Charge l'image et l'ajoute aux ressources de la présentation.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Assigne l'image à la forme.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configure le mode de remplissage d'image et les propriétés de mosaïquage.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les options de mosaïque](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de mise en forme qui remplit une forme avec une seule couleur uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de la forme sur `Solid`.
1. Assigner votre couleur de remplissage préférée à la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Python suivant montre comment appliquer un remplissage couleur unie à un rectangle dans une diapositive PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Définit le type de remplissage à Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Définit la couleur de remplissage.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La forme avec remplissage couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant à l’arrière‑plan ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) sur `Solid`.
1. Utiliser [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto rectangle solide.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ajoute une forme auto rectangle transparente au-dessus de la forme solide.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme sur l’angle souhaité.
1. Enregistrer la présentation.

Le code Python suivant montre comment faire pivoter une forme de 5 degrés :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instancie la classe Presentation qui représente un fichier de présentation.
presentation = Presentation()
try:
    # Récupère la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoute une forme auto de type Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Fait pivoter la forme de 5 degrés.
    shape.setRotation(5)

    # Enregistre le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer des effets de biseau 3D à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme à la diapositive.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Définir les propriétés ThreeDFormat de la forme.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Enregistrer la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) à la diapositive.
1. Utiliser les méthodes [setCameraType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/camera/#setCameraType) et [setLightType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/lightrig/#setLightType) pour définir la rotation 3D.
1. Enregistrer la présentation.

Le code Python suivant montre comment appliquer des effets de rotation 3D à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Crée une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Enregistre la présentation au format PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setBlackWhiteMode) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc en soi, et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normale.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent une coloration grise, `BlackWhite` n’utilise que le noir et blanc, `Black` et `White` forcent une couleur unique, `Color` préserve la coloration normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Le code Python suivant crée une forme colorée et la fait apparaître en gris en mode d’affichage noir et blanc :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Conservez le remplissage orange en mode couleur, mais affichez la forme en gris en mode noir et blanc.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En mode couleur normale, le rectangle conserve son remplissage orange. En workflow d’affichage noir et blanc, il utilise une coloration grise parce que son mode est réglé sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, l’aperçu ou d’autres workflows qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Le code Python suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec des espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le formatage des formes influence-t-il la taille finale du fichier de présentation ?**

Seulement de façon minime. Les images et médias intégrés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes d’une diapositive qui partagent le même formatage afin de pouvoir les regrouper ?**

Comparer les propriétés clés de formatage de chaque forme — remplissage, contour et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérer leurs styles comme identiques et regrouper logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Enregistrez des formes d’exemple avec les styles souhaités dans une présentation modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et ré‑appliquez leur formatage là où cela est requis.