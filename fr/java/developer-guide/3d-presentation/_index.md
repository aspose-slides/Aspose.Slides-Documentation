---
title: Créer des effets 3D dans les présentations avec Java
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint en Java avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Java peut créer, modifier, conserver et rendre le format 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l’extrusion, les chanfreins, l’éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne s’agit pas d’insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive en image, PDF ou HTML, Aspose.Slides rend ces effets 3D dans le résultat 2D exporté.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/).`getThreeDFormat()` pour appliquer le format 3D à une forme. L’objet de format renvoyé contrôle la scène 3D pour cette forme.

Pour le texte, utilisez [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Cela applique le format 3D au cadre de texte plutôt qu’au corps de la forme.

Les membres d’API les plus importants sont :

| Membre d’API | Ce qu’il contrôle | Quand l’utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getCamera--) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l’objet dans l’espace 3D ou appliquer un préréglage de rotation 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getLightRig--) | Préréglage de lumière, direction et rotation de la lumière. | Modifier l’apparence des reflets et des ombres sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getMaterial--) et [setMaterial](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Matériau de la surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Distance à laquelle la forme s’étend vers l’arrière depuis sa face avant. | Transformer une forme plane en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur latérale avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getDepth--) et [setDepth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondeur 3D supplémentaire utilisée par le formatage 3D PowerPoint. | Ajuster finement la profondeur des formes ou du texte, notamment avec les paramètres de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getBevelTop--) et [getBevelBottom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d’une face plane et nette. |
| [getContourColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#getContourWidth--), et [setContourWidth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contour autour de l’objet 3D. | Mettre en évidence la frontière de l’objet dans le rendu final. |

## **Créer une forme 3D**

Une forme a généralement besoin de quatre types de paramètres avant d’apparaître réellement en 3D :

- Paramètres de caméra, car la vue frontale par défaut peut masquer l’extrusion.
- Paramètres de lumière, car l’éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence le rendu de la lumière.
- Paramètres d’extrusion ou de profondeur, car une forme plane nécessite de l’épaisseur.

L’exemple suivant crée un rectangle, ajoute du texte sur sa face avant, applique le formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’image rendue montre le rectangle sous forme d’un bloc 3D épais :

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet 3‑D Rotation. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API caméra.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via le format 3D retourné par `shape.getThreeDFormat()` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l’objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive ; cela change le point de vue 3D utilisé par PowerPoint et Aspose.Slides lors du rendu.

## **Ajouter extrusion et profondeur**

L’extrusion rend une forme épaisse en l’étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Définissez la hauteur d’extrusion pour l’épaisseur et la couleur d’extrusion pour la couleur latérale :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Utilisez le paramètre de profondeur lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner profondeur avec chanfrein, matériau et effets de texte. Dans de nombreux scénarios de forme, la hauteur d’extrusion est le réglage le plus explicite car elle exprime directement l’extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en conservant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d’extrusion plus sombre aux côtés :

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Le rendu conserve le dégradé sur la face avant et rend l’extrusion séparément :

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Pour utiliser un remplissage image, ajoutez l’image à la présentation et affectez‑la au remplissage de la forme :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

L’image est rendue sur la face avant, tandis que l’extrusion apparaît comme la surface latérale 3D :

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour des effets de type WordArt où chaque lettre doit être extrudée, dotée de matériau, d’éclairage et de paramètres de caméra.

L’exemple suivant crée du texte avec un remplissage motif, applique une transformation WordArt et configure les paramètres 3D sur [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/) :

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le texte est rendu comme des lettres 3D courbées et extrudées :

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Comportement à l’exportation et au rendu**

Aspose.Slides préserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s’applique lorsque vous rendez des diapositives en [PNG](/slides/fr/java/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/java/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/java/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et PDF exportés ne sont pas interactifs. L’objet ne peut pas être pivoté par le spectateur après l’exportation.
- L’apparence finale dépend de la combinaison caméra, rig de lumière, matériau, extrusion, remplissage et mise à l’échelle de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/java/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètre 3D éditable.

## **FAQ**

### Aspose.Slides peut‑il créer des présentations 3D interactives ?

Aspose.Slides crée et rend les effets 3D PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs : le spectateur ne peut pas pivoter la scène 3D. En PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le prend en charge.

### Quelle est la différence entre un modèle 3D et un effet 3D ?

Un modèle 3D est un objet 3D séparé inséré dans la présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

### Quels paramètres sont nécessaires pour qu’une forme 3D soit visible ?

Au minimum, définissez une rotation de caméra et soit l’extrusion soit la profondeur. En pratique, ajoutez également un rig de lumière et un matériau afin que les faces rendues affichent des reflets et des ombres nets.

### Puis‑je appliquer des effets 3D aux formes et au texte ?

Oui. Utilisez [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/).`getThreeDFormat()` pour le corps de la forme et [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` pour le texte.

### Les effets 3D apparaissent‑ils lors de l’exportation vers des images, PDF, HTML ou images vidéo ?

Oui. Aspose.Slides rend les effets 3D lors de la génération d’images de diapositives, de la sortie PDF, HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l’apparence rendue, pas un objet 3D éditable.

### Puis‑je lire les valeurs 3D finales après l’héritage et les paramètres du thème ?

Oui. Utilisez les API de formatage effectif décrites dans [Shape Effective Properties](/slides/fr/java/shape-effective-properties/) pour lire les valeurs finales de caméra, rig de lumière, chanfrein et autres paramètres 3D.