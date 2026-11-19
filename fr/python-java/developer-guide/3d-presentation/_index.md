---
title: Créer des effets 3D dans les présentations avec Python
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/python-java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint en Python via Java avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java peut créer, modifier, conserver et restituer le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne traite pas de l'insertion ou de la modification de fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive en image, PDF ou HTML, Aspose.Slides restitue ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) pour appliquer un formatage 3D à une forme. La méthode renvoie [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), qui contrôle la scène 3D de cette forme.

Pour le texte, utilisez la méthode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les membres d'API les plus importants sont :

| Membre d'API | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Point de vue, type d’appareil photo prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Préréglage de lumière, direction et rotation de la lumière. | Modifier l'apparence des reflets et des ombres sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur latérale avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Profondeur 3D supplémentaire utilisée par le formatage 3D PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, surtout en combinaison avec les paramètres de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Arêtes surélevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et tranchante. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Contour autour de l'objet 3D. | Mettre en évidence la frontière de l'objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de manière convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence la façon dont la lumière est rendue.
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant et applique un formatage 3D. Les valeurs de rotation de la caméra sont en degrés, et la hauteur d'extrusion est de 100 points. L'exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'image rendue de la diapositive montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3D. Les valeurs de rotation X, Y et Z correspondent à la rotation définie via l'API de la caméra.

![Volet Rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique et définit ses rotations X, Y et Z respectivement à 20, 30 et 40 degrés. Il configure la forme en mémoire sans enregistrer de fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle modifie le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

### **Copier l'orientation de la caméra d'une forme modèle**

Pour correspondre à l'orientation d'une forme modèle, lisez son préréglage de caméra avec [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) et ses angles de rotation avec [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). L'exemple ouvre `template.pptx` et copie l'orientation de la caméra de la première forme de la première diapositive vers la deuxième forme. Les deux formes possèdent déjà un éclairage 3D, et la deuxième forme n'a aucune rotation de caméra explicite.

Les angles sont en degrés. L'index `0` correspond à la latitude, l'index `1` à la longitude et l'index `2` à la révolution. Transmettez‑les à [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) dans cet ordre. Si la source renvoie `None`, elle n'a pas de rotation explicite, laissez donc les angles de la deuxième forme non définis. Une rotation explicite de `(0, 0, 0)` renvoie trois zéros et doit être copiée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lorsque vous rouvrez `camera-copy.pptx` dans PowerPoint, la flèche à droite possède le même préréglage de caméra et la même rotation que le rectangle à gauche. Les deux formes utilisent le même éclairage et la même profondeur d'extrusion.

![Un rectangle 3D bleu et une flèche droite avec une orientation de caméra correspondante, vues du dessus et à droite](camera-orientation.png)

## **Ajouter une extrusion et une profondeur**

L'extrusion donne à une forme un aspect épais en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur PowerPoint associés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Utilisez [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) pour définir l'épaisseur et [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) pour accéder à la couleur des côtés. Cet exemple donne à un rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

La méthode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) définit la profondeur d'une forme 3D. La méthode [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) contrôle la hauteur de l'effet d'extrusion, comme le montre cet exemple.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en utilisant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un dégradé du bleu à l'orange à la face avant et une couleur orange foncé à l'extrusion de 150 points. Les arrêts du dégradé à 0 et 100 marquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Le rendu conserve le dégradé sur la face avant et rend séparément l'extrusion :

![Rectangle 3D rendu avec un remplissage en dégradé bleu-à-orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme. Cet exemple nécessite un fichier existant nommé "image.jpg" dans le répertoire de travail. Il étire l'image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ni rendre de fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer un formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets similaires à WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un motif grille orange et blanc, applique une arche ascendante et configure les paramètres 3D via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). La hauteur d'extrusion et la profondeur sont en points, et la rotation de la lumière est en degrés. Le remplissage et le contour de la forme sont masqués afin que seul le texte soit visible. L'exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le texte est rendu comme une lettrine 3D courbée et extrudée :

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Conserver le texte à plat sur une forme 3D**

Pour garder le texte lisible tout en conservant l'apparence 3D d'une forme, appelez [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Lorsque la valeur est `True`, le texte reste en dehors de la scène 3D. Lorsqu'elle est `False`, le texte participe à la scène et suit son orientation 3D.

Ce paramètre ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Il diffère également de la rotation ordinaire. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) fait pivoter la forme dans le plan de la diapositive, tandis que [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) contrôle la rotation personnalisée du texte à l'intérieur de sa boîte englobante. Conserver le texte hors de la scène 3D ne réinitialise aucun de ces angles.

L'exemple autonome suivant crée un rectangle bleu avec texte et le duplique à côté de l'original. Les deux formes ont le même formatage 3D ; seul le paramètre texte diffère : `False` à gauche et `True` à droite. Les angles de la caméra sont en degrés, et la hauteur d'extrusion est de 40 points. L'exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

À gauche, le texte suit l'orientation 3D. À droite, il reste plat et plus facile à lire. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : le texte suit l'orientation 3D à gauche et reste plat à droite](keep_text_flat.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez les diapositives en [PNG](/slides/fr/python-java/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/python-java/convert-powerpoint-to-video/).

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'export.
- L'apparence finale dépend de la combinaison de la caméra, du système d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/python-java/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**  
Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs ; ils ne constituent pas des scènes 3D que le spectateur peut faire pivoter. En PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le permet.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**  
Un modèle 3D est un objet 3D séparé inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à un texte PowerPoint ordinaire, tel que la rotation, l'extrusion, le chanfrein, l'éclairage et le matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**  
Au minimum, définissez une rotation de caméra ainsi qu'une extrusion ou une profondeur. En pratique, définissez également un système d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**  
Oui. Utilisez [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) pour le corps de la forme et [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) pour le texte.

**Les effets 3D apparaîtront‑ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?**  
Oui. Aspose.Slides rend les effets 3D lors de la génération d'images de diapositives, de la sortie PDF, de la sortie HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l'application de l'héritage et des paramètres de thème ?**  
Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/python-java/shape-effective-properties/) pour lire les valeurs finales de caméra, système d'éclairage, chanfrein et autres paramètres 3D.