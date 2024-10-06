---
title: Formatage des Formes
type: docs
weight: 20
url: /java/shape-formatting/
keywords: "Format de forme, format de lignes, styles de jointure, remplissage dégradé, remplissage par motif, remplissage par image, remplissage de couleur unie, rotation des formes, effets de biseau 3d, effet de rotation 3d, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Formatage des formes dans une présentation PowerPoint en Java"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Les formes étant composées de lignes, vous pouvez les formater en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone en elles) sont remplies. 

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour Java** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint. 

## **Format des Lignes**

En utilisant Aspose.Slides, vous pouvez spécifier votre style de ligne préféré pour une forme. Ces étapes décrivent une telle procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Définissez une couleur pour les lignes de la forme.
5. Définissez la largeur pour les lignes de la forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) pour la ligne de la forme.
7. Définissez le [style de traits](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) pour la ligne de la forme. 
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java démontre une opération où nous avons formaté un rectangle `AutoShape` :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds autoshape of rectangle type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Sets the fill color for the rectangle shape
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Applies some formatting on the rectangle's lines
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Sets the color for the rectangle's line
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Writes the PPTX file to disk
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Styles de Jointure**
Voici les 3 options de type de jointure :

* Rond
* Miter
* Biseauté

Par défaut, lorsque PowerPoint joint deux lignes à un angle (ou un coin de forme), il utilise le paramètre **Rond**. Cependant, si vous souhaitez dessiner une forme avec des angles très aigus, vous voudrez peut-être sélectionner **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce Java démontre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de type de jointure Miter, Biseauté et Rond :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {

    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds 3 rectangle autoshapes
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Sets the fill color for the rectangle shape
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Sets the line's width
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Sets the color for the rectangle's line
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Sets the Join Style
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Adds text to each rectangle
    ((IAutoShape)shp1).getTextFrame().setText("Style de jointure Miter");
    ((IAutoShape)shp2).getTextFrame().setText("Style de jointure Biseauté");
    ((IAutoShape)shp3).getTextFrame().setText("Style de jointure Rond");

    // Writes the PPTX file to disk
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage Dégradé**
Dans PowerPoint, le Remplissage Dégradé est une option de formatage qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus dans une configuration où une couleur s'estompe et se transforme progressivement en une autre couleur. 

Voici comment utiliser Aspose.Slides pour appliquer un remplissage dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies à l'aide des méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java démontre une opération où l'effet de remplissage dégradé était utilisé sur une ellipse :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds an ellipse autoshape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Applies the gradient formatting to the ellipse
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Sets the direction of the gradient
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Add 2 gradient stops
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Writes the PPTX file to disk
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage par Motif**
Dans PowerPoint, le Remplissage par Motif est une option de formatage qui vous permet d'appliquer un design bicolore composé de points, de rayures, de hachures croisées ou de carreaux à une forme. De plus, vous pouvez sélectionner vos couleurs préférées pour l'avant-plan et l'arrière-plan de votre motif. 

Aspose.Slides fournit plus de 45 styles prédéfinis qui peuvent être utilisés pour formater des formes et enrichir des présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage par motif à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) de la forme sur `Pattern`.
5. Spécifiez votre style de motif préféré pour la forme. 
6. Définissez la [Couleur d'arrière-plan](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) pour le [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
7. Définissez la [Couleur de premier plan](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) pour le [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java démontre une opération où un remplissage par motif a été utilisé pour embellir un rectangle : 

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds a rectangle autoshape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Sets the fill type to Pattern
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Sets the pattern style
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Sets the pattern back and fore colors
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Writes the PPTX file to disk
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage par Image**
Dans PowerPoint, le Remplissage par Image est une option de formatage qui vous permet de placer une image à l'intérieur d'une forme. Essentiellement, vous pouvez utiliser une image comme arrière-plan d'une forme. 

Voici comment utiliser Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) de la forme sur `Picture`.
5. Définissez le mode de remplissage de l'image sur Tuilé.
6. Créez un objet `IPPImage` en utilisant l'image qui sera utilisée pour remplir la forme.
7. Définissez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur le `IPPImage` récemment créé.
8. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment remplir une forme avec une image :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add a rectangle autoshape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Sets the fill type to Picture
    shp.getFillFormat().setFillType(FillType.Picture);

    // Sets the picture fill mode
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Sets the picture
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Writes the PPTX file to disk
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage de Couleur Unie**
Dans PowerPoint, le Remplissage de Couleur Unie est une option de formatage qui vous permet de remplir une forme avec une seule couleur. La couleur choisie est typiquement une couleur unie. La couleur est appliquée en tant qu'arrière-plan de la forme sans effets ou modifications spéciaux. 

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de couleur unie à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment appliquer le remplissage de couleur unie à une boîte dans PowerPoint :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds a rectangle autoshape
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Sets the fill type to Solid
    shape.getFillFormat().setFillType(FillType.Solid);

    // Sets the color for the rectangle
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Writes the PPTX file to disk
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. De cette manière, par exemple, si vous définissez un faible niveau de transparence, l'objet de la diapositive ou l'arrière-plan derrière (la forme) apparaît à travers. 

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Utilisez `new Color` avec le composant alpha défini.
5. Enregistrez l'objet en tant que fichier PowerPoint. 

Ce code Java démontre le processus :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds a solid shape
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Adds a transparent shape over the solid shape
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Writes the PPTX file to disk
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Faire Pivoter les Formes**
Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
4. Faites pivoter la forme du degré nécessaire. 
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment faire pivoter une forme de 90 degrés :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds a rectangle autoshape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rotates the shape by 90 degrees
    shp.setRotation(90);

    // Writes the PPTX file to disk
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des Effets de Biseau 3D**
Aspose.Slides vous permet d'ajouter des effets de biseau 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
3. Définissez vos paramètres préférés pour les propriétés [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) de la forme. 
4. Écrivez la présentation sur disque.

Ce code Java vous montre comment ajouter des effets de biseau 3D à une forme :

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds a shape to the slide
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Sets the shape's ThreeDFormat properties
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Writes the presentation as a PPTX file
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un Effet de Rotation 3D**
Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index. 
3. Ajoutez une [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) à la diapositive.
3. Spécifiez vos chiffres préférés pour [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) et [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--).
4. Écrivez la présentation sur disque. 

Ce code Java vous montre comment appliquer des effets de rotation 3D à une forme :

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Writes the presentation as a PPTX file
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Réinitialiser le Formatage**

Ce code Java vous montre comment réinitialiser le formatage dans une diapositive et revenir à la position, à la taille et au formatage par défaut de chaque forme qui a un espace réservé sur [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutSlide) :

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // each shape on the slide that has a placeholder on the layout will be reverted
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```