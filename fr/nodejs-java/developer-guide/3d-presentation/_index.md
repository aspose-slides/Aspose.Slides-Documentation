---
title: Créer des effets 3D dans les présentations avec Node.js
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint dans Node.js avec Aspose.Slides. Configurer la caméra, l’éclairage, le matériau, l’extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les biseaux, l’éclairage, le matériau, les remplissages dégradés ou image, et le texte 3D.

{{% alert color="primary" %}}
Cet article porte sur les effets de formatage 3D des formes et du texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` pour appliquer un formatage 3D à une forme. L’objet [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/) retourné contrôle la scène 3D pour cette forme.

Pour le texte, utilisez [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. Cela applique le formatage 3D au cadre de texte plutôt qu’au corps de la forme.

Les membres d’API les plus importants sont :

| Membre API | Ce qu’il contrôle | Quand l’utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getCamera) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l’objet dans l’espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getLightRig) | Préréglage de lumière, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getMaterial) et [setMaterial](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setMaterial) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Distance à laquelle la forme s’étend vers l’arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Couleur des faces extrudées. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getDepth) et [setDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setDepth) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment avec les paramètres de biseau et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelTop) et [getBevelBottom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Arêtes relevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d’une face plate et tranchante. |
| [getContourColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getContourWidth) et [setContourWidth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contour autour de l’objet 3D. | Mettre en évidence la frontière de l’objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de réglages avant d’apparaître de manière convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l’extrusion.
- Paramètres d’éclairage, car l’éclairage rend les faces et les côtés lisibles.
- Paramètres du matériau, car la surface influence la façon dont la lumière est rendue.
- Paramètres d’extrusion ou de profondeur, car une forme plate nécessite de l’épaisseur.

L’exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique le formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’image de diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée à partir du volet Rotation 3D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API de la caméra.

![Volet Rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via le format 3D retourné par `shape.getThreeDFormat()` :

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l’objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et une profondeur**

L’extrusion rend une forme épaisse en l’étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d’extrusion et hauteur d’extrusion](img_02_02.png)

Définissez la hauteur d’extrusion pour l’épaisseur et la couleur d’extrusion pour la couleur des côtés :

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Utilisez le réglage de profondeur lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec les effets de biseau, de matériau et de texte. Dans de nombreux scénarios de forme, la hauteur d’extrusion est le réglage le plus clair car elle exprime directement l’extrusion visible.

## **Utiliser des remplissages dégradés ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage d’image à la face avant tout en utilisant les mêmes paramètres de caméra, de lumière, de matériau et d’extrusion.

Cet exemple applique un remplissage dégradé à la forme et une couleur d’extrusion plus sombre aux côtés :

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Le rendu conserve le dégradé sur la face avant et rend l’extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l’orange et extrusion orange](img_02_03.png)

Pour utiliser un remplissage d’image à la place, ajoutez l’image à la présentation et affectez‑la au remplissage de la forme :

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

![Rectangle 3D rendu avec un remplissage photo sur la face avant et extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets similaires à WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L’exemple suivant crée du texte avec un remplissage à motif, applique une transformation WordArt et configure les paramètres 3D sur [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/):

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Texte 3D rendu avec une transformation WordArt arquée, remplissage à motif orange et extrusion sombre](img_02_05.png)

## **Comportement d’exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme d’un résultat 2D. Cela s’applique lorsque vous rendez des diapositives vers [PNG](/slides/fr/nodejs-java/convert-powerpoint-to-png/), exportez vers [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), exportez vers [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), ou générez des images‑phares pour [video conversion](/slides/fr/nodejs-java/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et PDF exportés ne sont pas interactifs. L’objet ne peut pas être tourné par le spectateur après l’exportation.
- L’apparence finale dépend de la combinaison de la caméra, du système d’éclairage, du matériau, de l’extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou issues du thème, lisez les [effective shape properties](/slides/fr/nodejs-java/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D modifiables.

## **FAQ**

**Aspose.Slides peut-il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs en tant que scènes 3D que le spectateur peut faire pivoter. Dans un PPTX, le formatage 3D reste modifiable dans PowerPoint lorsque le format le permet.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à un texte PowerPoint ordinaire, tel que la rotation, l’extrusion, le biseau, l’éclairage et le matériau. Cet article traite des effets 3D.

**Quels réglages sont nécessaires pour qu’une forme 3D soit visible ?**

Au minimum, définissez une rotation de caméra et soit l’extrusion, soit la profondeur. En pratique, définissez également un système d’éclairage et un matériau afin que les faces rendues aient des reflets et des ombres nets.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` pour le corps de la forme et [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` pour le texte.

**Les effets 3D apparaîtront‑ils lors de l’exportation vers des images, PDF, HTML ou des images‑phares vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la production d’images de diapositive, de sorties PDF, HTML et d’images‑phares utilisées pour la conversion vidéo. La sortie exportée contient l’apparence rendue, pas un objet 3D modifiable.

**Puis‑je lire les valeurs 3D finales après l’application de l’héritage et des réglages de thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Shape Effective Properties](/slides/fr/nodejs-java/shape-effective-properties/) pour lire les valeurs finales de caméra, de système d’éclairage, de biseau et les valeurs 3D associées.