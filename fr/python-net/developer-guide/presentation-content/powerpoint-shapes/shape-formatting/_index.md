---
title: Formatage des formes PowerPoint en Python
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/python-net/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme croquis
- format du style de jointure
- dégradé
- remplissage motif
- remplissage image
- remplissage texture
- remplissage couleur unie
- transparence de forme
- rendu noir et blanc de forme
- rendu en niveaux de gris de forme
- rotation de forme
- effet biseautage 3D
- effet rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en Python avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Formatez les formes dans PowerPoint en ajustant leurs contours, remplissages et effets. Aspose.Slides for Python via .NET vous permet de contrôler ces paramètres de manière programmatique, y compris la transparence, la rotation et le formatage 3D.

![Options de formatage des formes dans PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET fournit des classes et des propriétés qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

Utilisez [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) pour contrôler le contour d’une forme. Cet exemple crée un rectangle non rempli avec un contour bleu en pointillés. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) sélectionne une ligne composée épaisse‑fine, tandis que [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) définit sa largeur à 7 points et [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) sélectionne le motif de pointillé.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

### **Définir des motifs de pointillé personnalisés**

Utilisez [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) lorsque les styles de ligne prédéfinis ne fournissent pas les longueurs de tirets et les intervalles dont vous avez besoin, par exemple pour des contours de marque ou des diagrammes techniques. L’attribution d’un motif définit automatiquement [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) sur [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Les entrées de la liste alternent entre longueurs de tiret et d’espace, en commençant par un tiret. Chaque valeur est un multiple de la largeur de ligne : `[4, 2]` à une largeur de 3 points produit un tiret de 12 points suivi d’un espace de 6 points. Utilisez des paires de valeurs finies et non négatives pour définir des segments complets de tiret‑espace. L’exemple utilise des valeurs positives afin que chaque tiret et chaque espace soient visibles.

Cet exemple crée cinq lignes bleues de même longueur et avec des caps plats. Les trois premières comparent des motifs à une largeur de 3 points. La quatrième répète le premier motif à deux fois la largeur, doublant ainsi les longueurs du tiret et de l’espace. La cinquième passe d’un motif personnalisé à une ligne pleine.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Retourner la dernière ligne à un style plein.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Pour revenir à un style en pointillé prédéfini, attribuez [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) à [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Le style sélectionné contrôle l’apparence de la ligne.

Le résultat dans PowerPoint, de haut en bas : **{4, 2}, 3 pt** ; **{1, 2}, 3 pt** ; **{6, 2, 1, 2}, 3 pt** ; **{4, 2}, 6 pt** ; et **Solid, 3 pt**.

![Trois motifs de pointillé personnalisés, une ligne plus large utilisant le premier motif, et une ligne pleine dans PowerPoint](custom-dash-patterns.png)

### **Définir les extrémités de ligne**

Utilisez [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) pour définir les extrémités d’une ligne ouverte. L’énumération [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) fournit trois styles de cap explicites :

- `FLAT` : le trait s’arrête à l’extrémité.
- `ROUND` : un cap semi‑circulaire se prolonge au‑delà de l’extrémité de la moitié de la largeur de ligne.
- `SQUARE` : un cap carré se prolonge au‑delà de l’extrémité de la moitié de la largeur de ligne.

L’énumération comprend également `NOT_DEFINED`, ce qui signifie qu’aucun style de cap n’est explicitement assigné.

Les caps sont différents des pointes de flèche, qui ajoutent des symboles aux extrémités de ligne, et des joints, qui contrôlent les coins entre les segments de ligne. Cet exemple désactive les pointes de flèche via [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) et [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) afin que seules les formes de cap soient comparées.

L’exemple suivant crée trois lignes horizontales autrement identiques, de 20 points de largeur. De haut en bas, elles utilisent respectivement des caps plats, ronds et carrés. Leurs points d’extrémité partagent les mêmes coordonnées horizontales ; les caps ronds et carrés s’étendent de 10 points au‑delà de chaque extrémité.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat dans PowerPoint, de haut en bas : **Flat**, **Round**, et **Square**.

![Caps plats, ronds et carrés sur des lignes épaisses identiques dans PowerPoint](line-caps.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à la ligne d’une forme l’aspect d’un dessin à la main. Utilisez [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) pour accéder aux paramètres de ligne, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) pour accéder aux paramètres de croquis, et [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Le code Python suivant montre comment appliquer un effet [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , lire la valeur explicitement assignée et supprimer l’effet avec [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

La valeur renvoyée par [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) représente le paramètre assigné directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de disposition, utilisez [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), accédez à [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) et lisez [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). La valeur effective reflète le format réellement appliqué après résolution de l’héritage. Cet exemple nécessite une présentation existante contenant au moins une forme sur la première diapositive et affiche les deux valeurs :

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

* Arrondi
* Mitre
* Biseau

Le style de jointure contrôle la façon dont deux segments de contour se rejoignent à un coin. Utilisez **Arrondi** pour des coins arrondis, **Mitre** pour des coins pointus, ou **Biseau** pour des coins aplatis.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Cet exemple crée trois rectangles noirs avec des contours bleus de 15 points de largeur. Il définit [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) sur les valeurs mitre, biseau et arrondi de [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) respectivement, afin de comparer la façon dont les coins sont dessinés.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Limiter les jointures mitre aux coins pointus**

Utilisez [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) avec [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) fixé à [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) pour limiter la distance qu’un coin pointu peut atteindre.

La limite est un rapport entre la distance des coins interne et externe du joint et la largeur de ligne. Par exemple, une valeur de `8` autorise une longueur de mitre pouvant atteindre huit fois la largeur de ligne ; ce n’est pas une mesure en points. Si le coin dépasserait la limite, PowerPoint utilise un joint biseauté à cet endroit. Une limite plus grande permet des pointes plus aiguës. Ce réglage n’affecte que les joints mitre et n’a aucun effet visible lorsque le coin reste dans les deux limites.

Cet exemple crée deux triangles non remplis identiques avec des contours de 20 points de largeur. Le triangle de gauche utilise une limite de `2`, et celui de droite une limite de `8`. Chaque triangle mesure 80 points de largeur et 160 points de hauteur, donnant au coin supérieur un rapport longueur‑mitre / largeur‑ligne d’environ `4.12`. Ainsi, PowerPoint biseautera le sommet gauche et conservera le sommet droit.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat dans PowerPoint : **Miter limit 2** à gauche et **miter limit 8** à droite.

![Un sommet biseauté avec une limite de mitre 2 et un sommet pointu avec une limite de mitre 8 dans PowerPoint](miter-limits.png)

## **Remplissage en dégradé**

Un remplissage en dégradé mélange les couleurs à travers une forme. Cet exemple remplit une ellipse avec un dégradé linéaire à 45 degrés du rouge au violet en utilisant [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). La méthode [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) place les arrêts de couleur à 0 et 1, le début et la fin du dégradé. Effacer les arrêts existants garantit que seules ces deux couleurs sont utilisées.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choose a Gradient Rendering Style](/slides/fr/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage en dégradé stocké dans la présentation.

### **Définir l’angle du dégradé linéaire**

Utilisez [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) pour contrôler l’orientation d’un remplissage [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). L’angle est mesuré en degrés et augmente dans le sens des aiguilles d’une montre : `0` va de gauche à droite, `90` de haut en bas, `180` de droite à gauche, et `270` de bas en haut. Les angles fractionnaires sont pris en charge. Les angles finis en dehors de `[0, 360)` sont normalisés sur un tour complet ; par exemple, `-45` devient `315` et `360` devient `0`.

Cet exemple crée six rectangles avec des arrêts de couleur rouge, vert et bleu identiques aux positions `0`, `0.5` et `1`. Le redimensionnement est désactivé afin que l’angle puisse être comparé indépendamment des proportions des rectangles. Les angles, de gauche à droite, sont `0`, `45` et `90` dans la première rangée, et `135`, `180` et `270` dans la deuxième rangée.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat dans PowerPoint :

![Dégradés linéaires à 0, 45 et 90 degrés dans la rangée supérieure, et à 135, 180 et 270 degrés dans la rangée inférieure](linear-gradient-angles.png)

### **Redimensionner un dégradé linéaire avec la forme**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) accepte une valeur [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Réglez‑la explicitement sur `FALSE` pour conserver l’angle géométrique du dégradé lorsque les proportions de la forme changent, ou sur `TRUE` pour redimensionner le dégradé avec la largeur et la hauteur de la forme. Avec le redimensionnement activé, l’angle visible peut différer de l’angle assigné sur une forme non carrée.

L’exemple suivant utilise un angle de `45` degrés et les mêmes arrêts de couleur que dans la comparaison d’angles. La colonne de gauche utilise `FALSE` ; la colonne de droite utilise `TRUE`. Chaque colonne contient un rectangle large au-dessus d’un rectangle haut. Les deux commencent avec les mêmes dimensions larges ; la modification de la largeur et de la hauteur du deuxième rectangle démontre comment le remplissage réagit au redimensionnement sans changer ses réglages de dégradé.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat dans PowerPoint, avec le redimensionnement désactivé à gauche et activé à droite :

![Rectangles larges et hauts avec un dégradé à 45 degrés, comparant linear_gradient_scaled FALSE à gauche avec TRUE à droite](linear-gradient-scaling.png)

Avec le redimensionnement désactivé, les bandes de couleur diagonales conservent la même orientation dans les deux rectangles. Avec le redimensionnement activé, les bandes s’étirent avec les proportions de la forme. Cela aide à reproduire le dégradé d’un modèle lors de l’adaptation d’une forme à une taille différente. Sur un carré, activer le redimensionnement ne modifie pas l’apparence de ce dégradé à `45` degrés.

Les deux réglages, angle et redimensionnement, s’appliquent aux dégradés linéaires. Ils ne contrôlent pas les remplissages [GradientShape.RADIAL ou GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Combiner l’angle avec la direction du dégradé**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) sélectionne un style de dégradé dans l’énumération [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); ce n’est pas un substitut à un angle numérique. Pour un dégradé linéaire, les styles de coin peuvent modifier la zone de répartition des couleurs sans changer [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Conservez la direction inchangée lors de la comparaison des angles ou du redimensionnement.

L’exemple suivant applique les mêmes réglages dans un ordre inverse. Les deux rectangles ont la même apparence : attribuer la direction avant ou après l’angle ne change pas le résultat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplissage de motif**

Un remplissage de motif applique un motif à deux couleurs, tel que des points, des bandes ou des carreaux. Cet exemple utilise [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) pour sélectionner un motif de treillis. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) fournit le fond gris clair, et [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) fournit la couleur jaune du motif.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Un remplissage d’image utilise une image à l’intérieur d’une forme. Cet exemple nécessite une image locale et utilise [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) pour la charger dans la collection d’images de la présentation. Le réglage de [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) sur le mode mosaïque répète l’image à l’intérieur du rectangle. L’image source utilisée ici est affichée ci‑dessous :

![L’image lotus](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Mosaïquer l’image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les propriétés suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): définit le mode de remplissage d’image — soit `TILE` soit `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): spécifie l’alignement des tuiles dans la forme.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): définit le décalage horizontal de la tuile (en points) depuis l’origine de la forme.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): définit le décalage vertical de la tuile (en points) depuis l’origine de la forme.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): définit l’échelle horizontale de la tuile en pourcentage.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): définit l’échelle verticale de la tuile en pourcentage.

Cet exemple nécessite une image locale et configure [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) pour la répéter à 50 % de sa taille d’origine. Des décalages de –32 points déplacent les tuiles horizontalement et verticalement ; l’alignement en bas‑à‑droite et le retournement dans les deux directions déterminent l’arrangement de la texture répétée.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les options de mosaïque](tile-options.png)

## **Remplissage de couleur unie**

Un remplissage uni donne à une forme une couleur unique et uniforme. Cet exemple définit [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur le mode de remplissage uni et attribue le jaune via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), puis enregistre le rectangle dans une présentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Utiliser l’arrière‑plan de la diapositive comme remplissage de forme**

Utilisez [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) lorsqu’une forme doit correspondre à l’arrière‑plan de la diapositive, par exemple dans un modèle de présentation. Définissez d’abord [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) afin de supprimer tout remplissage explicite. Avec cette combinaison, la forme utilise l’arrière‑plan de la diapositive au lieu de son propre remplissage de style. Activer uniquement le drapeau ne supprime pas un remplissage explicite existant.

Cela diffère de [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) : le remplissage d’arrière‑plan couvre les objets derrière la forme avec la zone correspondante de l’arrière‑plan de la diapositive, tandis que aucun remplissage laisse ces objets visibles. Un dégradé reste aligné avec la diapositive plutôt que de redémarrer à l’intérieur de chaque forme.

L’exemple suivant crée un arrière‑plan maître hérité par la diapositive et place une bande magenta derrière trois rectangles. Le rectangle de gauche utilise l’arrière‑plan, le rectangle du milieu n’a aucun remplissage, et le rectangle de droite passe du remplissage d’arrière‑plan à un remplissage orange explicite.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Hériter du dégradé du maître.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Ajouter cet objet en premier afin qu'il apparaisse derrière les rectangles.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Désactiver le remplissage d'arrière-plan avant d'appliquer un remplissage explicite.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat, de gauche à droite : **remplissage d’arrière‑plan**, **pas de remplissage**, et **remplissage explicite**. La bande magenta est masquée par les rectangles gauche et droit mais reste visible à travers le rectangle du milieu.

![Remplissage d’arrière‑plan, pas de remplissage et remplissage orange explicite sur une bande magenta](background-fill.png)

Le même comportement s’applique à un arrière‑plan défini directement sur la diapositive ou hérité d’une disposition. La forme utilise l’arrière‑plan résolu de la diapositive ; l’exemple laisse les arrière‑plans de la diapositive et de la disposition indéfinis afin que le maître le fournisse.

## **Définir la transparence**

Pour un remplissage uni, le composant alpha de la couleur contrôle l’opacité : 0 est totalement transparent et 255 est totalement opaque. Cet exemple utilise une valeur alpha de 128 pour un rectangle jaune, le rendant environ 50 % transparent afin que le rectangle en dessous reste visible. La couleur est assignée via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Utilisez [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) pour faire pivoter une forme dans le plan de la diapositive. L’angle est mesuré en degrés ; cet exemple fait pivoter un rectangle de 5 degrés dans le sens des aiguilles d’une montre et enregistre la présentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseautage 3D**

Utilisez [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) pour donner de la profondeur à une forme et des bords biseautés. Cet exemple crée une ellipse verte avec un contour orange, définit [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) à 4 points, et applique un biseau supérieur circulaire d’une largeur et d’une hauteur de 6 points via [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Une caméra orthographique frontale et un éclairage à trois points rendent le biseau visible.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’effet de biseautage 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

La vue 3D d’une forme est contrôlée par les paramètres de sa caméra. Cet exemple utilise [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) avec des angles de latitude, de longitude et de révolution de 40, 35 et 20 degrés respectivement. Il sélectionne une caméra isométrique via [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) et un éclairage équilibré via [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), puis enregistre le rectangle formaté.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir‑et‑blanc des formes**

La propriété [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) indique comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir‑et‑blanc. Elle n’active pas l’affichage noir‑et‑blanc à elle seule et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normale.

Utilisez une valeur de l’énumération [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `AUTOMATIC` laisse l’application de rendu choisir la conversion, `GRAY` et `LIGHT_GRAY` utilisent des tons de gris, `BLACK_WHITE` n’utilise que le noir et le blanc, `BLACK` et `WHITE` imposent une couleur unique, `COLOR` conserve les couleurs normales, et `HIDDEN` omet la forme en mode noir‑et‑blanc. `NOT_DEFINED` signifie qu’aucun mode au niveau de la forme n’est assigné.

Cet exemple crée un rectangle orange et définit [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) sur gris. La forme enregistrée conserve son remplissage orange pour un affichage en couleur normale et demande un rendu gris aux applications qui respectent les paramètres d’affichage noir‑et‑blanc :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

En mode couleur normale, le rectangle conserve son remplissage orange. Dans un flux de travail d’affichage noir‑et‑blanc, il utilise le gris parce que son mode est réglé sur `GRAY`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, l’aperçu ou d’autres flux qui honorent les paramètres d’affichage noir‑et‑blanc de la présentation.

## **Réinitialiser le formatage**

Utilisez [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) pour restaurer la position, la taille et le formatage des espaces réservés de diapositive à partir de leurs espaces réservés de disposition correspondants. Cet exemple nécessite une présentation existante avec des espaces réservés liés à la disposition et réinitialise chaque diapositive avant l’enregistrement. Les formes sans espace réservé correspondant dans la disposition ne sont pas réinitialisées.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le formatage des formes affecte‑t‑il la taille finale du fichier de présentation ?**

Les couleurs, styles de ligne et paramètres d’effet ajoutent généralement peu de données comparés aux images et médias incorporés. Les remplissages d’image peuvent augmenter la taille du fichier car leurs images sont stockées dans la présentation.

**Comment détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les propriétés clés de formatage de chaque forme — remplissage, contour et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, traitez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Enregistrez des formes d’exemple avec les styles souhaités dans un diaporama modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.