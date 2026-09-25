---
title: Créer des effets 3D dans les présentations avec Python
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
- présentation
- Python
- Aspose.Slides
description: "Appliquez et rendez les effets 3D pour les formes et le texte PowerPoint en Python avec Aspose.Slides. Configurez la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut créer, modifier, préserver et rendre le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les biseaux, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte de PowerPoint. Il ne traite pas de l'insertion ou de la modification de fichiers de modèles 3D autonomes. Lors de l'exportation d'une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la propriété [Shape.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/three_d_format/) pour appliquer un formatage 3D à une forme. Cette propriété expose [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/), qui contrôle la scène 3D de cette forme.

Pour le texte, utilisez la propriété [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/). Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les propriétés les plus importantes sont :

| Propriété | Ce qu'elle contrôle | Quand l'utiliser |
|---|---|---|
| [camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/camera/) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/light_rig/) | Préréglage d'éclairage, direction et rotation de la lumière. | Modifier l'apparence des reflets et des ombres sur la surface 3D. |
| [material](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/material/) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [extrusion_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_color/) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/depth/) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment en combinaison avec les réglages de biseau et de matériau. |
| [bevel_top](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/bevel_top/) et [bevel_bottom](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/bevel_bottom/) | Arêtes relevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et nette. |
| [contour_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/contour_color/) et [contour_width](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/contour_width/) | Contour autour de l'objet 3D. | Mettre en évidence les limites de l'objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'avoir un aspect convaincant en 3D :

- Paramètres de caméra, car la vue avant par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l’éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface affecte la façon dont la lumière est rendue.
- Paramètres d'extrusion ou de profondeur, car une forme plate nécessite de l'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant et applique un formatage 3D. Les valeurs de rotation de la caméra sont en degrés, et la hauteur d'extrusion est de 100 points. L'exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

L'image de la diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3-D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API caméra.

![Volet Rotation 3-D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [ThreeDFormat.camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/camera/). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique, et définit ses rotations X, Y et Z respectivement à 20, 30 et 40 degrés. Il configure la forme en mémoire sans enregistrer de fichier :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter extrusion et profondeur**

L'extrusion donne à une forme un aspect épais en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint liés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Définissez [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) pour l'épaisseur et [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_color/) pour la couleur des côtés. Cet exemple donne à un rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

La propriété [ThreeDFormat.depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/depth/) définit la profondeur d'une forme 3D. La propriété [extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) contrôle la hauteur de l'effet d'extrusion, comme le montre cet exemple.

## **Utiliser des remplissages dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en utilisant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un dégradé du bleu à l'orange à la face avant et une couleur orange foncé à l'extrusion de 150 points. Les arrêts du dégradé à 0 et 100 marquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

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
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Le rendu conserve le dégradé sur la face avant et rend séparément l'extrusion :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l'orange et extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme. Cet exemple nécessite un fichier existant nommé "image.jpg" dans le répertoire de travail. Il étire l'image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ou rendre de fichier :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Rectangle 3D rendu avec un remplissage photo sur la face avant et extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un motif grille orange et blanc, applique une arche vers le haut, et configure les paramètres 3D via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/). La hauteur d'extrusion et la profondeur sont en points, et la rotation de la lumière est en degrés. Le remplissage et le contour de la forme sont masqués afin que seul le texte soit visible. L'exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Conserver le texte à plat sur une forme 3D**

Pour garder le texte lisible tout en conservant l'apparence 3D d'une forme, définissez [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/keep_text_flat/) via [TextFrame.text_frame_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/text_frame_format/). Lorsque la valeur est `True`, le texte reste en dehors de la scène 3D. Lorsqu'elle est `False`, le texte participe à la scène et suit son orientation 3D.

Ce réglage ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [Shape.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/three_d_format/). Il diffère également de la rotation ordinaire. [Shape.rotation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/rotation/) fait pivoter la forme dans le plan de la diapositive, tandis que [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/rotation_angle/) contrôle la rotation personnalisée du texte dans sa boîte englobante. Conserver le texte en dehors de la scène 3D ne réinitialise aucune de ces rotations.

L'exemple autonome suivant crée un rectangle bleu avec du texte et le clone à côté de l'original. Les deux formes ont le même formatage 3D ; seul le réglage du texte diffère : `False` à gauche et `True` à droite. Les angles de la caméra sont en degrés, et la hauteur d'extrusion est de 40 points. L'exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

À gauche, le texte suit l'orientation 3D. À droite, il reste à plat et plus lisible. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : keep_text_flat est False à gauche et True à droite](keep_text_flat.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/python-net/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/python-net/convert-powerpoint-to-video/).

Gardez ces points à l'esprit :

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du système d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés effectives de forme](/slides/fr/python-net/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDFs ou pages HTML exportés interactifs en tant que scènes 3D que le spectateur peut faire pivoter. Dans les fichiers PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le supporte.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que la rotation, l'extrusion, le biseau, l'éclairage et le matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit l'extrusion soit la profondeur. En pratique, définissez également un système d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres nets.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [Shape.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/three_d_format/) pour le corps de la forme et [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/) pour le texte.

**Les effets 3D apparaîtront‑ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la création d'images de diapositives, de fichiers PDF, de sorties HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l'application de l'héritage et des paramètres du thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Shape Effective Properties](/slides/fr/python-net/shape-effective-properties/) pour lire les valeurs finales de caméra, de système d'éclairage, de biseau et les valeurs 3D associées.