---
title: Présentation 3D
type: docs
weight: 232
url: /fr/nodejs-java/3d-presentation/
---

## **Aperçu**

Depuis Aspose.Slides for Java 20.9, il est possible de créer du 3D dans les présentations. PowerPoint 3D est un moyen de donner vie aux présentations. Montrez des objets du monde réel avec une présentation 3D, démontrez le modèle 3D de votre futur projet d’entreprise, le modèle 3D du bâtiment ou de son intérieur, le modèle 3D du personnage de jeu, ou simplement une représentation 3D de vos données. 

Les modèles 3D PowerPoint peuvent être créés à partir de formes 2D, en appliquant des effets tels que : rotation 3D, profondeur et extrusion 3D, dégradé 3D, texte 3D, etc. La liste des fonctionnalités 3D appliquées aux formes se trouve dans la classe **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. L’instance de la classe peut être obtenue :

- Méthode **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** pour créer un modèle 3D PowerPoint.  
- Méthode **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** pour créer du texte 3D (WordArt).

Tous les effets implémentés dans **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** peuvent être utilisés tant pour les formes que pour le texte. Jetons un coup d’œil rapide aux principales méthodes de la classe **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. Dans l’exemple suivant, nous créons une forme rectangulaire 2D avec du texte. En obtenant la vue de la caméra sur la forme, nous modifions sa rotation pour la faire apparaître comme un modèle 3D. En définissant une lumière plate et sa direction vers le haut du modèle 3D, nous ajoutons davantage de volume au modèle. Le changement des matériaux, de la hauteur d’extrusion et de la couleur rend le modèle 3D plus vivant.  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Voici le modèle 3D résultant :

![todo:image_alt_text](img_01_01.png)

## **Rotation 3D**

La rotation d’un modèle 3D dans PowerPoint peut être effectuée via le menu :

![todo:image_alt_text](img_02_01.png)

Pour faire pivoter un modèle 3D avec l’API Aspose.Slides, utilisez la méthode **[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)**, puis définissez la rotation de la caméra par rapport à la forme 3D :
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... définir les autres paramètres de la scène 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **Profondeur et extrusion 3D**

Les méthodes **[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** et **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** sont utilisées pour créer une extrusion sur la forme :
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... définir les autres paramètres de la scène 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


Dans PowerPoint, la profondeur de la forme se règle via :

![todo:image_alt_text](img_02_02.png)

## **Dégradé 3D**

Un dégradé 3D peut apporter plus de volume à une forme PowerPoint 3D :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Voici à quoi cela ressemble :

![todo:image_alt_text](img_02_03.png)
  
Vous pouvez également créer un dégradé d’image :
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. configuration 3D : shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propriétés
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


Voici le résultat :

![todo:image_alt_text](img_02_04.png)

## **Texte 3D (WordArt)**

Pour créer un texte 3D (WordArt), procédez comme suit :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // configurer l'effet de transformation WordArt "Arch Up"
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Voici le résultat :

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Les effets 3D seront‑ils conservés lors de l’exportation d’une présentation vers des images/PDF/HTML ?**

Oui. Le moteur 3D de Slides rend les effets 3D lors de l’exportation vers les formats pris en charge ([images](/slides/fr/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), etc.).

**Puis‑je récupérer les valeurs « effectives » (finales) des paramètres 3D qui tiennent compte des thèmes, de l’héritage, etc. ?**

Oui. Slides fournit des API pour [lire les valeurs effectives](/slides/fr/nodejs-java/shape-effective-properties/) (y compris pour le 3D — éclairage, chapeaux, etc.) afin que vous puissiez voir les paramètres appliqués finalisés.

**Les effets 3D fonctionnent‑ils lors de la conversion d’une présentation en vidéo ?**

Oui. Lors de la [génération des images pour la vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/), les effets 3D sont rendus de la même façon que pour les [images exportées](/slides/fr/nodejs-java/convert-powerpoint-to-png/).