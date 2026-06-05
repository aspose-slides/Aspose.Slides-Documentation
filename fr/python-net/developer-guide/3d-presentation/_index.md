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
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint en Python avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="primary" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la propriété [Shape.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/three_d_format/) pour appliquer un formatage 3D à une forme. La propriété expose [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/), qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la propriété [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/). Cela applique le formatage 3D au cadre de texte au lieu du corps de la forme.

Les propriétés les plus importantes sont :

| Propriété | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/camera/) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/light_rig/) | Préréglage d'éclairage, direction et rotation de la lumière. | Modifier l'apparence des reflets et des ombres sur la surface 3D. |
| [material](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/material/) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [extrusion_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_color/) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/depth/) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment avec les réglages de chanfrein et de matériau. |
| [bevel_top](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/bevel_top/) et [bevel_bottom](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/bevel_bottom/) | Arêtes surélevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et pointue. |
| [contour_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/contour_color/) et [contour_width](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/contour_width/) | Contour autour de l'objet 3D. | Mettre en évidence les limites de l'objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de façon convaincante en 3D :

- Paramètres de caméra, car la vue de face par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence le rendu de la lumière.
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte sur sa face avant, applique le formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

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

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3‑D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API caméra.

![Panneau de rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via [ThreeDFormat.camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/camera/) :

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Utilisez la caméra lorsque vous devez changer la façon dont le spectateur voit l'objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et de la profondeur**

L'extrusion rend une forme épaisse en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Définissez [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) pour l'épaisseur et [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_color/) pour la couleur des côtés :

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Utilisez [ThreeDFormat.depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/depth/) lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec le chanfrein, le matériau et les effets de texte. Dans de nombreux scénarios de forme, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/extrusion_height/) est le réglage le plus clair car il exprime directement l'extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en conservant les mêmes paramètres de caméra, de lumière, de matériau et d'extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d'extrusion plus sombre aux côtés :

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

Le rendu conserve le dégradé sur la face avant et rend l'extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l'orange et extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme :

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme surface latérale 3D :

![Rectangle 3D rendu avec une photo remplissant la face avant et extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D des formes affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un remplissage motif, applique une transformation WordArt et configure les paramètres 3D sur [TextFrameFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/) :

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

Le texte est rendu comme une lettrine 3D courbée et extrudée :

![Texte 3D rendu avec une transformation WordArt arquée, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/python-net/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/python-net/convert-powerpoint-to-video/).

Gardez ces points à l'esprit :

- Les images et les PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du rig lumineux, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/python-net/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que préservé comme réglages 3D modifiables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs ; ils ne peuvent pas être pivotés par le spectateur. Dans le PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le supporte.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D séparé inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit l'extrusion soit la profondeur. En pratique, ajoutez également un rig lumineux et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [Shape.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/three_d_format/) pour le corps de la forme et [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/) pour le texte.

**Les effets 3D apparaissent‑ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d'images de diapositives, de la sortie PDF, de la sortie HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l'application de l'héritage et des paramètres du thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/python-net/shape-effective-properties/) pour lire les valeurs finales de caméra, de rig lumineux, de chanfrein et les valeurs 3D associées.