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
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint en Python via Java avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d’ensemble**

Aspose.Slides for Python via Java peut créer, modifier, préserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l’extrusion, les chanfreins, l’éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}

Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne traite pas de l’insertion ou de la modification de fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.

{{% /alert %}}

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides`, démarre la JVM si nécessaire, puis importe l’API. L’exemple de remplissage d’image nécessite un fichier `image.jpg` dans le répertoire de travail.

## **Concepts de formatage 3D**

Utilisez [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getThreeDFormat) pour appliquer un formatage 3D à une forme. L’objet de format retourné contrôle la scène 3D pour cette forme.

Pour le texte, utilisez [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#getThreeDFormat). Cela applique le formatage 3D au cadre de texte plutôt qu’au corps de la forme.

Les membres d’API les plus importants sont :

| Membre API | Ce qu’il contrôle | Quand l’utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getCamera) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l’objet dans l’espace 3D ou correspondre à un préréglage de rotation 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getLightRig) | Préréglage d’éclairage, direction et rotation de la lumière. | Modifier l’apparence des reflets et des ombres sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getMaterial) et [setMaterial](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#setMaterial) | Matériau de surface, tel que plat, mat, plastique ou métal. | Rendre la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getExtrusionHeight) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Distance d’extension de la forme vers l’arrière à partir de sa face avant. | Transformer une forme plane en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getExtrusionColor) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur latérale avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getDepth) et [setDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#setDepth) | Profondeur 3D supplémentaire utilisée par le formatage 3D PowerPoint. | Affiner la profondeur des formes ou du texte, notamment avec les réglages de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getBevelTop) et [getBevelBottom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getBevelBottom) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d’une face plate et nette. |
| [getContourColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getContourWidth) et [setContourWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#setContourWidth) | Contour autour de l’objet 3D. | Mettre en évidence les limites de l’objet dans la sortie rendue. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d’apparaître de façon crédible en 3D :

- Paramètres de caméra, car la vue avant par défaut peut masquer l’extrusion.
- Paramètres de lumière, car l’éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence le rendu de la lumière.
- Paramètres d’extrusion ou de profondeur, car une forme plane a besoin d’épaisseur.

L’exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique le formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

L’image de la diapositive rendue montre le rectangle comme un bloc épais 3D :

![Rectangle bleu 3D rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D se configure depuis le volet 3‑D Rotation. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API caméra.

![Volet 3‑D Rotation de PowerPoint avec les valeurs X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via le format 3D renvoyé par [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getThreeDFormat) :

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

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l’objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et une profondeur**

L’extrusion rend une forme épaisse en l’étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d’extrusion et hauteur d’extrusion](img_02_02.png)

Définissez la hauteur d’extrusion pour l’épaisseur et la couleur d’extrusion pour la couleur latérale :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Utilisez le réglage de profondeur lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec le chanfrein, le matériau et les effets de texte. Dans de nombreux scénarios de forme, la hauteur d’extrusion est le réglage le plus explicite car il exprime directement l’extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en conservant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d’extrusion plus sombre aux côtés :

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

La sortie rendue conserve le dégradé sur la face avant et rend l’extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l’orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l’image à la présentation et attribuez‑lui le remplissage de la forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

L’image est rendue sur la face avant, tandis que l’extrusion est rendue comme surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et réglages de caméra.

L’exemple suivant crée du texte avec un remplissage motif, applique une transformation WordArt et configure les paramètres 3D sur [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/) :

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

Le texte est rendu comme une lettrage 3D courbé et extrudé :

![Texte 3D rendu avec une transformation WordArt en forme d’arc, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Comportement d’exportation et de rendu**

Aspose.Slides préserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s’applique lorsque vous rendez des diapositives en PNG, exportez en PDF, exportez en HTML ou générez des images‑cadres pour la conversion vidéo.

Gardez ces points à l’esprit :

- Les images et PDF exportés ne sont pas interactifs. L’objet ne peut pas être pivoté par le spectateur après l’exportation.
- L’apparence finale dépend de la combinaison de caméra, rig lumineux, matériau, extrusion, remplissage et mise à l’échelle de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, utilisez l’API de formatage effectif.
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que préservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs ; le spectateur ne peut pas faire pivoter la scène 3D. En PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le prend en charge.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou du texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit l’extrusion soit la profondeur. En pratique, définissez aussi un rig lumineux et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getThreeDFormat) pour le corps de la forme et [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#getThreeDFormat) pour le texte.

**Les effets 3D apparaissent‑ils lors de l’exportation vers des images, PDF, HTML ou des images‑cadres vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d’images de diapositives, de la sortie PDF, de la sortie HTML et des cadres utilisés pour la conversion vidéo. La sortie exportée contient l’apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs finales 3D après l’application de l’héritage et des paramètres de thème ?**

Oui. Utilisez [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getEffective) pour lire les valeurs finales de caméra, rig lumineux, chanfrein et autres paramètres 3D.