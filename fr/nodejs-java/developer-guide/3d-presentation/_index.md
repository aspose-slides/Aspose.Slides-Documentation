---
title: Créer des effets 3D dans les présentations avec Node.js
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint dans Node.js avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getThreeDFormat) pour appliquer un formatage 3D à une forme. La méthode renvoie [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/), qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la méthode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les membres d'API les plus importants sont :

| Membre d'API | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getCamera) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getLightRig) | Préréglage de lumière, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getMaterial) et [setMaterial](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setMaterial) | Matériau de la surface, tel que plat, mat, plastique ou métal. | Rendre la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | À quelle distance la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Couleur des faces extrudées. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage avant. |
| [getDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getDepth) et [setDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setDepth) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, en particulier avec les réglages de chanfrein et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelTop) et [getBevelBottom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et nette. |
| [getContourColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getContourWidth) et [setContourWidth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contour autour de l'objet 3D. | Mettre en évidence la bordure de l'objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de façon convaincante en 3D :

- Paramètres de caméra, car la vue avant par défaut peut masquer l'extrusion.
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influe sur la façon dont la lumière est rendue.
- Paramètres d'extrusion ou de profondeur, car une forme plate nécessite de l'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant et applique un formatage 3D. Les valeurs de rotation de la caméra sont en degrés, et la hauteur d'extrusion est de 100 points. L'exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

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

L'image de la diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le volet Rotation 3D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API caméra.

![Volet Rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getCamera). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique et définit ses rotations X, Y et Z respectivement à 20, 30 et 40 degrés. Il configure la forme en mémoire sans enregistrer de fichier :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et une profondeur**

L'extrusion donne à une forme un aspect épais en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés de couleur et de hauteur d'extrusion](img_02_02.png)

Utilisez [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) pour définir l'épaisseur et [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) pour accéder à la couleur des côtés. Cet exemple donne à un rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

La méthode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setDepth) définit la profondeur d'une forme 3D. La méthode [setExtrusionHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) contrôle la hauteur de l'effet d'extrusion, comme le montre cet exemple.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant et conserver les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un dégradé du bleu à l'orange à la face avant et une couleur orange foncé à l'extrusion de 150 points. Les arrêts du dégradé à 0 et 100 indiquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

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

Le rendu conserve le dégradé sur la face avant et rend séparément l'extrusion :

![Rectangle 3D rendu avec un remplissage en dégradé du bleu à l'orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et affectez‑la au remplissage de la forme. Cet exemple nécessite un fichier existant nommé "image.jpg" dans le répertoire de travail. Il étire l'image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ou rendre un fichier :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un motif de grille orange et blanc, applique une arche ascendante et configure les paramètres 3D via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). La hauteur d'extrusion et la profondeur sont exprimées en points, et la rotation de la lumière en degrés. Le remplissage et le contour de la forme sont masqués afin que seul le texte soit visible. L'exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

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
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
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

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Conserver le texte à plat sur une forme 3D**

Pour que le texte reste lisible tout en conservant l'apparence 3D d'une forme, appelez [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Lorsque la valeur est `true`, le texte reste en dehors de la scène 3D. Lorsqu'elle est `false`, le texte participe à la scène et suit son orientation 3D.

Ce paramètre ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getThreeDFormat). Il diffère également d'une rotation ordinaire. [Shape.setRotation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#setRotation) fait pivoter la forme dans le plan de la diapositive, tandis que [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) contrôle la rotation personnalisée du texte dans sa boîte englobante. Conserver le texte hors de la scène 3D ne réinitialise aucun de ces angles.

L'exemple autonome suivant crée un rectangle bleu avec du texte et le duplique à côté de l'original. Les deux formes ont le même formatage 3D ; seul le paramètre texte diffère : `false` à gauche et `true` à droite. Les angles de la caméra sont en degrés, et la hauteur d'extrusion est de 40 points. L'exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

À gauche, le texte suit l'orientation 3D. À droite, il reste à plat et plus lisible. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : le texte suit l'orientation 3D à gauche et reste à plat à droite](keep_text_flat.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme de résultat 2D. Cela s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/nodejs-java/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être pivoté par le spectateur après l'exportation.
- L'apparence finale dépend de la combinaison de la caméra, du groupe de lumières, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés de forme effectives](/slides/fr/nodejs-java/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètre 3D éditable.

## **FAQ**

**Peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne transforme pas les images, PDF ou pages HTML exportés en scènes 3D interactives que le spectateur pourrait faire pivoter. Dans le format PPTX, le formatage 3D reste éditable dans PowerPoint lorsqu'il est pris en charge.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que la rotation, l’extrusion, le chanfrein, l’éclairage et le matériau. Cet article traite des effets 3D.

**Quels paramètres sont nécessaires pour une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit une extrusion, soit une profondeur. En pratique, définissez également un groupe de lumières et un matériau afin que les faces rendues possèdent des reflets et des ombres nets.

**Puis‑je appliquer des effets 3D à la fois aux formes et au texte ?**

Oui. Utilisez [Shape.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getThreeDFormat) pour le corps de la forme et [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) pour le texte.

**Les effets 3D apparaîtront‑ils lors de l'exportation vers des images, PDF, HTML ou des images‑vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d'images de diapositives, de la sortie PDF, HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'aspect rendu, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l'application de l'héritage et des paramètres du thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés de forme effectives](/slides/fr/nodejs-java/shape-effective-properties/) pour lire les valeurs finales de la caméra, du groupe de lumières, du chanfrein et des paramètres 3D associés.