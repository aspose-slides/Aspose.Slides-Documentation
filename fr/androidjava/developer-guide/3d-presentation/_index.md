---
title: Créer des effets 3D dans les présentations sur Android
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint sur Android avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java peut créer, modifier, conserver et rendre le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" %}}
Cet article porte sur les effets de formatage 3D des formes et du texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [IShape.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pour appliquer un formatage 3D à une forme. La méthode renvoie [IThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/), qui contrôle la scène 3D de cette forme.

Pour le texte, utilisez la méthode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les membres d'API les plus importants sont :

| Membre API | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Préréglage de lumière, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) et [setMaterial](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Matériau de surface, par ex. plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getDepth--) et [setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Affiner la profondeur pour les formes ou le texte, surtout avec les paramètres de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) et [getBevelBottom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate tranchante. |
| [getContourColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), et [setContourWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contour autour de l'objet 3D. | Mettre en évidence la frontière de l'objet dans le rendu. |

## **Créer une forme 3D**

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car la lumière rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence la façon dont la lumière est rendue.
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique un formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

L'image de diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3‑D. Les valeurs de rotation X, Y et Z correspondent à la rotation définie via l'API de la caméra.

![Volet Rotation 3‑D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) :

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

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter extrusion et profondeur**

L'extrusion donne à une forme un aspect épais en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés de couleur d'extrusion et de hauteur d'extrusion](img_02_02.png)

Définissez [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) pour l'épaisseur et [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) pour la couleur des côtés :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Utilisez [IThreeDFormat.setDepth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec le chanfrein, le matériau et les effets de texte. Dans de nombreux scénarios de formes, `setExtrusionHeight` est le paramètre le plus clair car il exprime directement l'extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en utilisant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d'extrusion plus sombre aux côtés :

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

La sortie rendue conserve le dégradé sur la face avant et rend l'extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l'orange et extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme :

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme la surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D des formes affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un remplissage en motif, applique une transformation WordArt et configure les paramètres 3D sur [ITextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/) :

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

Le texte est rendu comme une lettrage 3D courbé et extrudé :

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez les diapositives en [PNG](/slides/fr/androidjava/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/).

Gardez ces points à l'esprit :

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivote par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du dispositif d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/androidjava/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

### Aspose.Slides peut‑il créer des présentations 3D interactives ?

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs sous forme de scènes 3D que le spectateur peut faire pivoter. Dans le PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le prend en charge.

### Quelle est la différence entre un modèle 3D et un effet 3D ?

Un modèle 3D est un objet 3D séparé inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

### Quels paramètres sont nécessaires pour une forme 3D visible ?

Au minimum, définissez une rotation de la caméra et soit l'extrusion, soit la profondeur. En pratique, définissez également un dispositif d'éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

### Puis‑je appliquer des effets 3D aux formes et au texte ?

Oui. Utilisez [IShape.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) pour le corps de la forme et [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) pour le texte.

### Les effets 3D apparaissent‑ils lors de l'exportation vers des images, PDF, HTML ou des images vidéo ?

Oui. Aspose.Slides rend les effets 3D lors de la production d'images de diapositives, de sorties PDF, HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

### Puis‑je lire les valeurs 3D finales après l'application de l'héritage et des paramètres de thème ?

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/androidjava/shape-effective-properties/) pour lire les valeurs finales de caméra, dispositif d'éclairage, chanfrein et autres valeurs 3D associées.