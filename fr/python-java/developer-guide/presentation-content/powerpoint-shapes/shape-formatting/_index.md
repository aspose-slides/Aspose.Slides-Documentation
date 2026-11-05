---
title: Formater les formes PowerPoint en Python via Java
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/python-java/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme croquis
- style de jointure
- remplissage en dégradé
- remplissage de motif
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
description: "Apprenez à formater les formes PowerPoint en Python via Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et un contrôle total."
---
## **Introduction**

Formatez les formes dans PowerPoint en ajustant leurs contours, remplissages et effets. Aspose.Slides pour Python via Java vous permet de contrôler ces paramètres par programmation, y compris la transparence, la rotation et le formatage 3D.

![Options de formatage des formes dans PowerPoint](format-shape-powerpoint.png)

Aspose.Slides pour Python via Java fournit des classes et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Format des lignes**

Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) pour contrôler le contour d’une forme. Cet exemple crée un rectangle non rempli avec un contour bleu en pointillés. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) sélectionne une ligne composée épaisse‑fine, tandis que [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) définit sa largeur à 7 points et [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) sélectionne le motif de tirets.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Les lignes formatées dans la présentation](formatted-lines.png)

### **Définir des modèles de tirets de ligne personnalisés**

Utilisez [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) lorsque les styles de ligne prédéfinis ne fournissent pas les longueurs de tiret et les espaces dont vous avez besoin, par exemple pour des contours de marque ou des schémas techniques. L’attribution d’un modèle change automatiquement le style de tiret de la ligne en [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Les entrées du tableau alternent entre longueurs de tiret et d’espace, en commençant par un tiret. Chaque valeur est un multiple de la largeur de la ligne : `[4, 2]` à une largeur de 3 points produit un tiret de 12 points suivi d’un espace de 6 points. Utilisez des paires de valeurs finies et non négatives pour définir des segments complets de tiret‑espace. L’exemple utilise des valeurs positives afin que chaque tiret et chaque espace soient visibles.

Cet exemple crée cinq lignes bleues de même longueur et avec des terminaisons plates. Les trois premières comparent des modèles à une largeur de 3 points. La quatrième répète le premier modèle à deux fois la largeur, doublant ainsi les longueurs du tiret et de l’espace. La cinquième passe d’un modèle personnalisé à une ligne pleine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Rétablir la dernière ligne en style plein.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour revenir à un style pointillé prédéfini, passez [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) à [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Le style sélectionné contrôle l’apparence de la ligne.

Le résultat dans PowerPoint, de haut en bas : **{4, 2}, 3 pt** ; **{1, 2}, 3 pt** ; **{6, 2, 1, 2}, 3 pt** ; **{4, 2}, 6 pt** ; et **Solid, 3 pt**.

![Trois modèles de tirets personnalisés, une ligne plus large utilisant le premier modèle, et une ligne pleine dans PowerPoint](custom-dash-patterns.png)

### **Définir les terminaisons de ligne**

Utilisez [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) pour définir les extrémités d’une ligne ouverte. La classe [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) propose trois styles de terminaisons explicites :

- `Flat` : Le tracé s’arrête à l’extrémité.
- `Round` : Une terminaison semi‑circulaire dépasse l’extrémité de la moitié de la largeur de la ligne.
- `Square` : Une terminaison carrée dépasse l’extrémité de la moitié de la largeur de la ligne.

La classe comprend également `NotDefined`, ce qui signifie qu’aucun style de terminaison n’est explicitement attribué.

Les terminaisons diffèrent des pointes de flèche, qui ajoutent des symboles aux extrémités de la ligne, et des jointures, qui contrôlent les coins entre les segments de ligne. Cet exemple désactive les pointes de flèche via [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) et [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) afin de ne comparer que les formes de terminaisons.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat dans PowerPoint, de haut en bas : **Flat**, **Round** et **Square**.

![Capuchons plats, ronds et carrés sur des lignes épaisses identiques dans PowerPoint](line-caps.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à la ligne d’une forme un aspect dessiné à la main. Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) pour accéder aux paramètres de ligne, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) pour accéder aux paramètres de croquis, et [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) pour sélectionner une valeur dans la classe [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Le code Python suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

La valeur retournée par [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) représente le paramètre attribué directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de mise en page, utilisez [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) et lisez le type de croquis à partir du format de ligne effectif retourné, comme indiqué ci‑dessous. La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage. Cet exemple nécessite une présentation existante contenant au moins une forme sur la première diapositive et affiche les deux valeurs :

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

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Le style de jointure contrôle la façon dont deux segments de contour se rencontrent à un coin. Utilisez **Round** pour des coins arrondis, **Miter** pour des coins pointus, ou **Bevel** pour des coins aplatis.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Cet exemple crée trois rectangles noirs avec des contours bleus de 15 points de large. Il utilise [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) pour définir respectivement les valeurs miter, bevel et round de [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) afin de comparer le rendu des coins.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Limiter les jointures en biseau aux coins pointus**

Utilisez [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) avec [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) fixé à [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) pour limiter l’extension d’un coin pointu.

La limite est un rapport entre la distance des coins interne et externe de la jointure et la largeur de la ligne. Par exemple, une valeur de `8` autorise une longueur de biseau allant jusqu’à huit fois la largeur de la ligne ; il ne s’agit pas d’une mesure en points. Si le coin dépasse la limite, PowerPoint utilise une jointure biseautée à cet endroit. Une limite plus grande permet des pointes plus aiguës. Ce paramètre affecte uniquement les jointures en biseau et n’a aucun impact visible lorsque le coin reste à l’intérieur des deux limites.

Cet exemple crée deux triangles identiques, non remplis, avec des contours de 20 points de large. Le triangle de gauche utilise une limite de `2`, et celui de droite une limite de `8`. Chaque triangle mesure 80 points de large sur 160 points de haut, ce qui donne à son coin supérieur un rapport longueur‑biseau / largeur de ligne d’environ `4,12`. Par conséquent, PowerPoint biseau le sommet gauche et conserve le sommet droit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat dans PowerPoint : **Miter limit 2** à gauche et **miter limit 8** à droite.

![Un sommet biseauté avec une limite de biseau 2 et un sommet pointu avec une limite de biseau 8 dans PowerPoint](miter-limits.png)

## **Remplissage en dégradé**

Un remplissage en dégradé mélange des couleurs à travers une forme. Cet exemple remplit une ellipse avec un dégradé linéaire à 45 degrés du rouge au violet en utilisant [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). La méthode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) place les arrêts de couleur à 0 et 1, le début et la fin du dégradé. Vider les arrêts existants garantit que seules ces deux couleurs sont utilisées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choisir un style de rendu de dégradé](/slides/fr/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le dégradé stocké dans la présentation.

### **Définir l’angle du dégradé linéaire**

Utilisez [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) pour contrôler l’orientation d’un remplissage [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). L’angle est mesuré en degrés et augmente dans le sens des aiguilles d’une montre : `0` va de gauche à droite, `90` de haut en bas, `180` de droite à gauche et `270` de bas en haut. Les angles fractionnaires sont pris en charge. Les angles finis en dehors de `[0, 360)` sont normalisés à une révolution ; par exemple, `-45` devient `315` et `360` devient `0`.

Cet exemple crée six rectangles avec des arrêts de couleur rouge, vert et bleu identiques aux positions `0`, `0.5` et `1`. L’échelle est désactivée afin que l’angle puisse être comparé indépendamment des proportions des rectangles. Les angles, de gauche à droite, sont `0`, `45` et `90` dans la première rangée, et `135`, `180` et `270` dans la deuxième rangée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Dégradés linéaires à 0, 45 et 90 degrés dans la rangée supérieure, et 135, 180 et 270 degrés dans la rangée inférieure](linear-gradient-angles.png)

### **Mettre à l’échelle un dégradé linéaire avec la forme**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepte une valeur [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Définissez‑la explicitement sur `False_` pour conserver l’angle géométrique du dégradé lorsque les proportions de la forme changent, ou sur `True_` pour faire évoluer le dégradé avec la largeur et la hauteur de la forme. Avec l’échelle activée, l’angle visible peut différer de l’angle assigné sur une forme non carrée.

L’exemple suivant utilise un angle de `45` degrés et les mêmes arrêts de couleur que dans la comparaison d’angles. La colonne de gauche utilise `False_` ; la colonne de droite utilise `True_`. Chaque colonne contient un rectangle large au-dessus d’un rectangle haut. Les deux commencent avec les mêmes dimensions larges ; modifier la largeur et la hauteur du deuxième rectangle montre comment le remplissage réagit au redimensionnement sans changer les paramètres du dégradé.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Rectangles larges et hauts avec un dégradé de 45 degrés, comparant LinearGradientScaled False à gauche et True à droite](linear-gradient-scaling.png)

Avec l’échelle désactivée, les bandes de couleur diagonales conservent la même orientation dans les deux rectangles. Avec l’échelle activée, les bandes s’étirent avec les proportions de la forme. Cela facilite la reproduction du dégradé d’un modèle lorsqu’on adapte une forme à une taille différente. Sur un carré, activer l’échelle ne modifie pas l’aspect de ce dégradé de `45` degrés.

Les paramètres d’angle et d’échelle s’appliquent aux dégradés linéaires. Ils ne contrôlent pas les remplissages [GradientShape.Radial] ou [GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Combiner l’angle avec la direction du dégradé**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) sélectionne un style de dégradé parmi la classe [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); ce n’est pas un substitut à un angle numérique. Pour un dégradé linéaire, les styles de coin peuvent modifier la zone de distribution des couleurs sans changer l’angle assigné via [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Conservez la direction identique lors de la comparaison d’angles ou d’échelle.

L’exemple suivant applique les mêmes paramètres dans un ordre inverse. Les deux rectangles ont le même aspect : attribuer la direction avant ou après l’angle ne change pas le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remplissage de motif**

Un remplissage de motif applique un motif bicolore, comme des points, des rayures ou des damiers. Cet exemple utilise [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) pour sélectionner un motif treillis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) fournit le fond gris clair, et [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) fournit la couleur jaune du motif.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Un remplissage d’image utilise une image à l’intérieur d’une forme. Cet exemple nécessite une image locale et utilise [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) pour la charger dans la collection d’images de la présentation. Le paramètre [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) mis en mode « tiled » répète l’image dans le rectangle. L’image source utilisée ici est affichée ci‑dessous :

![L’image du lotus](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![La forme avec remplissage d’image](picture-fill.png)

### **Tuiler l’image comme texture**

Si vous souhaitez définir une image en mode tuilé comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) : Définit le mode de remplissage d’image — soit `Tile` soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment) : Spécifie l’alignement des tuiles dans la forme.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip) : Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX) : Définit le déplacement horizontal de la tuile (en points) depuis l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY) : Définit le déplacement vertical de la tuile (en points) depuis l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX) : Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY) : Définit l’échelle verticale de la tuile en pourcentage.

Cet exemple nécessite une image locale et configure [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) pour la répéter à 50 % de sa taille originale. Des déplacements de −32 points déplacent les tuiles horizontalement et verticalement ; l’alignement en bas‑à‑droite et le retournement dans les deux directions déterminent l’arrangement de la texture répétée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Les options de tuilage](tile-options.png)

## **Remplissage couleur unie**

Un remplissage plein donne à une forme une couleur unique et uniforme. Cet exemple utilise [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) pour définir le mode de remplissage plein et attribue le jaune via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), puis enregistre le rectangle dans une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![La forme avec remplissage couleur unie](solid-color-fill.png)

### **Copier les couleurs tout en conservant les références de thème**

Utilisez [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) pour copier une définition de couleur, y compris son type de couleur, sa référence de thème et ses transformations. Ceci est utile lorsqu’on transfère une couleur de remplissage entre des formes qui doivent continuer à suivre le thème de la présentation. La méthode ne copie que la couleur : elle ne copie pas le type de remplissage, le contour ou d’autres formatages de forme. Définissez explicitement le type de remplissage de la destination avec [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

Cet exemple crée trois rectangles, de gauche à droite : la source, une copie sensible au thème, et une copie RGB fixe. La source utilise [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) pour référencer la première couleur d’accent et ajoute une teinte via [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add). La copie RGB utilise la couleur de remplissage effective de la source, de sorte que les trois semblent identiques au départ. L’appel à [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) définit une valeur RGB fixe et supprime les transformations de couleur existantes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # Les références de thème suivent la nouvelle couleur d'accent ; la valeur RVB fixe ne le fait pas.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Avant le changement de thème, les trois remplissages sont identiques :

![Source, destination copyFrom et destination RGB fixe avec remplissages bleus identiques](color-copy-before.png)

Après le changement de thème, la source et la copie sensible au thème suivent la nouvelle couleur d’accent et conservent leur teinte. La copie RGB fixe reste bleue :

![Source et destination copyFrom avec remplissages orange, tandis que la destination RGB fixe reste bleue](color-copy-after.png)

La définition copiée est indépendante de la source. Modifier ultérieurement la référence de thème de la source, attribuer une autre couleur, ou ajouter ou supprimer ses transformations ne modifie pas la destination. Un changement de thème affecte toujours les deux formes car chacune se réfère indépendamment à la même couleur de thème.

En enregistrant et en rouvrant le PPTX, le type de couleur copié, la référence de thème et la collection de transformations restent tels que renvoyés par [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType) et [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) ; ils ne sont pas aplatis en RGB.

Lors de la copie entre différents contextes de thème, comme des présentations avec des palettes d’accent différentes, la référence copiée est résolue par rapport au thème de destination. La même référence et les mêmes transformations peuvent donc produire une couleur visible différente. Consultez [Thème de la présentation](/slides/fr/python-java/presentation-theme/) pour plus d’informations sur la configuration des couleurs de thème.

## **Utiliser le fond de la diapositive comme remplissage de forme**

Utilisez [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) lorsqu’une forme doit correspondre au fond de la diapositive, par exemple dans un modèle de présentation. Définissez d’abord le type de remplissage avec [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) sur [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) afin de supprimer tout remplissage explicite. Avec cette combinaison, la forme utilise le fond de la diapositive au lieu de son remplissage de style. Activer uniquement le drapeau ne supprime pas un remplissage explicite existant.

Cela diffère de [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) : le remplissage de fond couvre les objets situés derrière la forme avec la zone correspondante du fond de la diapositive, tandis que « No Fill » laisse ces objets visibles. Un dégradé reste aligné avec la diapositive plutôt que de redémarrer à l’intérieur de chaque forme.

L’exemple suivant crée un fond maître hérité par la diapositive et place une bande magenta derrière trois rectangles. Le rectangle de gauche utilise le fond, le rectangle du milieu n’a aucun remplissage, et le rectangle de droite passe du remplissage de fond à un remplissage orange explicite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Hériter du dégradé depuis le maître.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Ajouter cet objet en premier afin qu'il apparaisse derrière les rectangles.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Désactiver le remplissage de fond avant d'appliquer un remplissage explicite.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Remplissage de fond, aucun remplissage et remplissage orange explicite sur une bande magenta](background-fill.png)

Le même comportement s’applique à un fond défini directement sur la diapositive ou hérité d’une mise en page. La forme utilise le fond résolu de la diapositive ; l’exemple laisse les fonds de la diapositive et de la mise en page indéfinis afin que le maître les fournisse.

## **Définir la transparence**

Pour un remplissage plein, le composant alpha de la couleur contrôle l’opacité : 0 est complètement transparent et 255 complètement opaque. Cet exemple utilise une valeur alpha de 128 pour un rectangle jaune, le rendant approximativement 50 % transparent afin que le rectangle dessous reste visible. La couleur est attribuée via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Utilisez [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) pour faire pivoter une forme dans le plan de la diapositive. L’angle est mesuré en degrés ; cet exemple fait pivoter un rectangle de 5 degrés dans le sens des aiguilles d’une montre et enregistre la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Utilisez [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) pour donner à une forme de la profondeur et des biseaux. Cet exemple crée une ellipse verte avec un contour orange, utilise [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) pour fixer la profondeur à 4 points, et applique un biseau supérieur circulaire d’une largeur et d’une hauteur de 6 points via [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Une caméra orthographique frontale et un éclairage à trois points rendent le biseau visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

La vue 3D d’une forme est contrôlée par les paramètres de sa caméra. Cet exemple utilise [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) avec des angles de latitude, longitude et révolution de 40, 35 et 20 degrés, respectivement. Il sélectionne une caméra isométrique via [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) et un éclairage équilibré via [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), puis enregistre le rectangle formaté.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc d’elle‑même, et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normale.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent une coloration grise, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` imposent une couleur unique, `Color` préserve la coloration normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est attribué.

Cet exemple crée un rectangle orange et utilise [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) pour définir le mode sur gris. La forme enregistrée conserve son remplissage orange pour l’affichage en couleur normale et demande une coloration grise aux applications qui respectent les paramètres d’affichage noir et blanc :

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
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En mode couleur normale, le rectangle conserve son remplissage orange. Dans un flux de travail d’affichage noir et blanc, il utilise une coloration grise parce que son mode est défini sur `Gray`. Cela vous permet de préserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, la prévisualisation ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Utilisez [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) pour restaurer la position, la taille et le formatage des espaces réservés de diapositive à partir de leurs espaces réservés de mise en page correspondants. Cet exemple nécessite une présentation existante avec des espaces réservés liés à la mise en page et réinitialise chaque diapositive avant d’enregistrer. Les formes sans espace réservé de mise en page correspondant ne sont pas réinitialisées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Les couleurs, styles de ligne et paramètres d’effet ajoutent généralement peu de données comparés aux images et médias intégrés. Les remplissages d’image peuvent augmenter la taille du fichier parce que leurs images sont stockées dans la présentation.

**Comment détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, traitez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis-je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un modèle de diaporama ou un fichier .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylées dont vous avez besoin et réappliquez leur formatage là où c’est nécessaire.