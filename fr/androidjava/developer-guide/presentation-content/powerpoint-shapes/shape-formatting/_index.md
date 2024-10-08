---
title: Formatage des formes
type: docs
weight: 20
url: /fr/androidjava/shape-formatting/
keywords: "Format de forme, format des lignes, styles de jointure, remplissage en dégradé, remplissage en motif, remplissage d'image, remplissage en couleur solide, rotation des formes, effets de biseau 3D, effet de rotation 3D, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Formatage des formes dans une présentation PowerPoint en Java"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont constituées de lignes, vous pouvez formater les formes en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone qu'elles contiennent) sont remplies.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour Android via Java** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint.

## **Formater les lignes**

À l'aide d'Aspose.Slides, vous pouvez spécifier votre style de ligne préféré pour une forme. Ces étapes décrivent une telle procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez une couleur pour les lignes de forme.
5. Définissez la largeur des lignes de forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) pour la ligne de forme.
7. Définissez le [style de tiret](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) pour la ligne de forme.
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java illustre une opération où nous avons formaté un rectangle `AutoShape` :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique de type rectangle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Définit la couleur de remplissage pour la forme rectangle
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Applique un certain formatage sur les lignes du rectangle
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Définit la couleur pour la ligne du rectangle
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formater les styles de jointure**
Voici les 3 options de type de jointure :

* Ronde
* Miter
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes à un angle (ou un coin de forme), il utilise le paramètre **Ronde**. Cependant, si vous souhaitez dessiner une forme avec des angles très aigus, vous pouvez sélectionner **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce Java montre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de type de jointure Miter, Biseau et Ronde :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {

    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute 3 formes automatiques de rectangle
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Définit la couleur de remplissage pour la forme rectangle
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Définit la largeur de la ligne
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Définit la couleur pour la ligne du rectangle
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Définit le style de jointure
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Ajoute du texte à chaque rectangle
    ((IAutoShape)shp1).getTextFrame().setText("Style de jointure Miter");
    ((IAutoShape)shp2).getTextFrame().setText("Style de jointure Biseau");
    ((IAutoShape)shp3).getTextFrame().setText("Style de jointure Ronde");

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage en dégradé**
Dans PowerPoint, le remplissage en dégradé est une option de formatage qui vous permet d'appliquer un dégradé continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux ou plusieurs couleurs dans une configuration où une couleur s'estompe progressivement et se transforme en une autre couleur.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage en dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies en utilisant les méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java illustre une opération où l'effet de remplissage en dégradé a été utilisé sur une ellipse :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Applique le formatage de dégradé à l'ellipse
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Définit la direction du dégradé
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Ajoute 2 arrêts de dégradé
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Écrit le fichier PPTX sur le disque
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage en motif**
Dans PowerPoint, le remplissage en motif est une option de formatage qui vous permet d'appliquer un design à deux couleurs composé de points, de rayures, de hachures croisées ou de cases à une forme. De plus, vous pouvez sélectionner vos couleurs préférées pour le premier plan et l'arrière-plan de votre motif.

Aspose.Slides fournit plus de 45 styles prédéfinis qui peuvent être utilisés pour formater des formes et enrichir les présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage en motif à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forme sur `Pattern`.
5. Définissez votre style de motif préféré pour la forme.
6. Définissez la [couleur d'arrière-plan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--) pour le [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
7. Définissez la [couleur de premier plan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--) pour le [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre une opération où un remplissage en motif a été utilisé pour embellir un rectangle :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Définit le type de remplissage sur Motif
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Définit le style de motif
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Définit les couleurs d'arrière-plan et de premier plan du motif
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage d'image**
Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet de placer une image à l'intérieur d'une forme. Essentiellement, vous pouvez utiliser une image comme arrière-plan d'une forme.

Voici comment utiliser Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forme sur `Picture`.
5. Définissez le mode de remplissage d'image sur Tile.
6. Créez un objet `IPPImage` en utilisant l'image qui sera utilisée pour remplir la forme.
7. Définissez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur le `IPPImage` récemment créé.
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment remplir une forme avec une image :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Définit le type de remplissage sur Image
    shp.getFillFormat().setFillType(FillType.Picture);

    // Définit le mode de remplissage d'image
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Définit l'image
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplissage en couleur solide**
Dans PowerPoint, le remplissage en couleur solide est une option de formatage qui vous permet de remplir une forme avec une seule couleur. La couleur choisie est généralement une couleur unie. La couleur est appliquée en tant qu'arrière-plan de la forme sans effets spéciaux ni modifications.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de couleur solide à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment appliquer un remplissage de couleur solide à une boîte dans PowerPoint :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Définit le type de remplissage sur Solide
    shape.getFillFormat().setFillType(FillType.Solid);

    // Définit la couleur pour le rectangle
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. De cette façon, par exemple, si vous définissez un faible niveau de transparence, l'objet de diapositive ou l'arrière-plan derrière (la forme) transparaît.

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Utilisez `new Color` avec le composant alpha défini.
5. Enregistrez l'objet sous forme de fichier PowerPoint.

Ce code Java illustre le processus :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une forme solide
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Ajoute une forme transparente au-dessus de la forme solide
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Écrit le fichier PPTX sur le disque
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Faire pivoter des formes**
Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Faites pivoter la forme selon le nombre de degrés nécessaires.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment faire pivoter une forme de 90 degrés :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Fait pivoter la forme de 90 degrés
    shp.setRotation(90);

    // Écrit le fichier PPTX sur le disque
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des effets de biseau 3D**
Aspose.Slides vous permet d'ajouter des effets de biseau 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Définissez vos paramètres préférés pour les propriétés [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de la forme.
5. Écrivez la présentation sur le disque.

Ce code Java vous montre comment ajouter des effets de biseau 3D à une forme :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une forme à la diapositive
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Définit les propriétés ThreeDFormat de la forme
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Écrit la présentation sous forme de fichier PPTX
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un effet de rotation 3D**
Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) à la diapositive.
4. Spécifiez vos figures préférées pour [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) et [LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--).
5. Écrivez la présentation sur le disque.

Ce code Java montre comment appliquer des effets de rotation 3D à une forme :

```java
// Crée une instance de la classe Presentation
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

    // Écrit la présentation sous forme de fichier PPTX
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Réinitialiser le formatage**

Ce code Java montre comment réinitialiser le formatage dans une diapositive et restaurer la position, la taille et le formatage de chaque forme qui possède un espace réservé sur le [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide) à leurs valeurs par défaut :

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // chaque forme sur la diapositive qui a un espace réservé sur la mise en page sera rétablie
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```