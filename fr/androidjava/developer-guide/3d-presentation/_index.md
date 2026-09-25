---
title: Créer des effets 3D dans les présentations sur Android
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- Présentation 3D
- Rotation 3D
- Profondeur 3D
- Extrusion 3D
- Dégradé 3D
- Texte 3D
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint sur Android avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java peut créer, modifier, conserver et rendre le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne traite pas de l'insertion ou de la modification de fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive en image, PDF ou HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [IShape.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pour appliquer un formatage 3D à une forme. La méthode renvoie [IThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/), qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la méthode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les membres d'API les plus importants sont :

| Membre API | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Préréglage de lumière, direction et rotation de la lumière. | Modifier l'apparence des reflets et des ombres sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) et [setMaterial](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Couleur des côtés extrudés. | Rendre la profondeur visible ou assortir la couleur des côtés au remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getDepth--) et [setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, surtout avec les réglages de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) et [getBevelBottom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Arêtes relevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et tranchante. |
| [getContourColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) et [getContourWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) et [setContourWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contour autour de l'objet 3D. | Mettre en évidence la limite de l'objet dans la sortie rendue. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de façon convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.
- Paramètres du matériau, car la surface influence la façon dont la lumière est rendue.
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant, et applique un formatage 3D. Les valeurs de rotation de la caméra sont en degrés, et la hauteur d'extrusion est de 100 points. L'exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

L'image rendue de la diapositive montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3-D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API de la caméra.

![Volet Rotation 3-D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique, et définit ses rotations X, Y et Z à 20, 30 et 40 degrés respectivement. Il configure la forme en mémoire sans enregistrer de fichier :

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

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter de l'extrusion et de la profondeur**

L'extrusion fait paraître une forme épaisse en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés de couleur et de hauteur d'extrusion](img_02_02.png)

Utilisez [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) pour définir l'épaisseur et [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) pour accéder à la couleur latérale. Cet exemple donne au rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

La méthode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) définit la profondeur d'une forme 3D. La méthode [setExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) contrôle la hauteur de l'effet d'extrusion, comme le montre cet exemple.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant et continuer à utiliser les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un dégradé du bleu à l'orange à la face avant et une couleur orange foncé à l'extrusion de 150 points. Les arrêts du dégradé à 0 et 100 marquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

![Rectangle 3D rendu avec un remplissage en dégradé du bleu à l'orange et extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme. Cet exemple nécessite un fichier existant nommé "image.jpg" dans le répertoire de travail. Il étire l'image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ni rendre de fichier :

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Rectangle 3D rendu avec un remplissage photo sur la face avant et extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un motif grille orange‑blanc, applique une arche vers le haut, et configure les paramètres 3D via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). La hauteur d'extrusion et la profondeur sont en points, et la rotation de la lumière est en degrés. Le remplissage et le contour de la forme sont masqués afin que seul le texte soit visible. L'exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Conserver le texte à plat sur une forme 3D**

Pour que le texte reste lisible tout en conservant l'apparence 3D d'une forme, appelez [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Lorsque la valeur est `true`, le texte reste en dehors de la scène 3D. Lorsqu'elle est `false`, le texte participe à la scène et suit son orientation 3D.

Ce paramètre ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [IShape.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Il diffère également d'une rotation ordinaire. [IShape.setRotation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#setRotation-float-) fait pivoter la forme dans le plan de la diapositive, tandis que [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) contrôle la rotation personnalisée du texte dans son cadre. Conserver le texte hors de la scène 3D ne réinitialise aucun de ces angles.

L'exemple autonome suivant crée un rectangle bleu avec du texte et le clone à côté de l'original. Les deux formes ont le même formatage 3D ; seul le paramètre de texte diffère : `false` à gauche et `true` à droite. Les angles de la caméra sont en degrés, et la hauteur d'extrusion est de 40 points. L'exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

À gauche, le texte suit l'orientation 3D. À droite, il reste plat et plus facile à lire. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : le texte suit l'orientation 3D à gauche et reste plat à droite](keep_text_flat.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans le résultat comme une sortie 2D. Cela s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/androidjava/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/).

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du dispositif d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/androidjava/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que conservé en tant que paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut-il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs en tant que scènes 3D que le spectateur peut faire pivoter. En PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le prend en charge.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit une extrusion, soit une profondeur. En pratique, il est également recommandé de définir un dispositif d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis-je appliquer des effets 3D à la fois aux formes et au texte ?**

Oui. Utilisez [IShape.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pour le corps de la forme et [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pour le texte.

**Les effets 3D apparaîtront-ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d'images de diapositives, de la sortie PDF, de la sortie HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis-je lire les valeurs 3D finales après l'application de l'héritage et des paramètres de thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/androidjava/shape-effective-properties/) pour lire la caméra finale, le dispositif d'éclairage, le chanfrein et les valeurs 3D associées.