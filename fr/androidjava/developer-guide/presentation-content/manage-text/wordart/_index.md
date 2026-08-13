---
title: Créer et appliquer des effets WordArt sur Android
linktitle: WordArt
type: docs
weight: 110
url: /fr/androidjava/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet d'affichage
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre externe
- effet d'ombre interne
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour Android. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en Java."
---
## **Vue d'ensemble**

Les effets WordArt vous permettent d’ajouter du texte visuellement attrayant et stylisé à vos présentations PowerPoint. Avec Aspose.Slides, les développeurs peuvent créer, personnaliser et gérer WordArt de manière programmatique, comme dans Microsoft PowerPoint—sans avoir besoin d’Office installé. Cet article donne un aperçu du travail avec WordArt, y compris comment appliquer des transformations de texte, des styles de remplissage, des contours, des ombres et d’autres options de mise en forme pour rendre le contenu de votre présentation plus expressif et engageant. WordArt vous permet de traiter le texte comme un objet graphique. Il consiste en des effets ou des modifications spéciales appliquées au texte pour le rendre plus attrayant ou perceptible.

## **Créer un modèle WordArt simple et l’appliquer au texte**

**Using Aspose.Slides** 

Tout d'abord, nous créons un texte simple avec ce code Java : 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Ensuite, nous définissons la hauteur de police du texte à une valeur plus grande pour rendre l'effet plus visible à l'aide de ce code : 

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres d’un nouveau WordArt. 

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Ici, nous appliquons la couleur de motif [SmallGrid](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/PatternStyle#SmallGrid) au texte et ajoutons une bordure de texte noire d’une largeur de 1 à l’aide de ce code :

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Le texte résultant :

![todo:image_alt_text](image-20200930114108-4.png)

## **Appliquer d’autres effets WordArt**

**Using Microsoft PowerPoint**

Depuis l'interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet Forme (elle reste effective même lorsqu’aucune propriété Format 3D n’est définie). 

### **Appliquer des effets d’ombre**

Ici, nous avons l'intention de définir les propriétés liées uniquement à un texte. Nous appliquons l'effet d'ombre à un texte à l'aide de ce code Java :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

L'API Aspose.Slides prend en charge trois types d'ombres : OuterShadow, InnerShadow et PresetShadow. 

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Using Microsoft PowerPoint**

Dans PowerPoint, vous ne pouvez utiliser qu’un type d’ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides vous permet en réalité d’appliquer deux types d’ombres simultanément : InnerShadow et PresetShadow.

{{% alert color="info" %}} 

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, c'est l'effet OuterShadow qui s'applique. 

{{% /alert %}} 

### **Appliquer des effets de réflexion au texte**

Nous ajoutons une réflexion au texte à l'aide de cet exemple de code Java :

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Appliquer des effets de lueur au texte**

Nous appliquons l'effet de lueur au texte pour le faire briller ou se démarquer à l'aide de ce code :

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Vous pouvez modifier les paramètres de l'ombre, de la réflexion et de la lueur. Les propriétés des effets sont définies séparément pour chaque partie du texte. 

{{% /alert %}} 

### **Utiliser des transformations dans WordArt**

Nous utilisons la propriété Transform (inhérente à l’ensemble du bloc de texte) à l'aide de ce code :

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Microsoft PowerPoint et Aspose.Slides pour Android via Java offrent un certain nombre de types de transformation prédéfinis.

{{% /alert %}} 

**Using PowerPoint**

Pour accéder aux types de transformation prédéfinis, passez par : **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l’énumération TextShapeType. 

### **Appliquer des effets 3D au texte et aux formes**

Nous appliquons un effet 3D à une forme de texte à l'aide de cet exemple de code :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Le texte résultant et sa forme :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Java :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

L'application d'effets 3D aux textes ou à leurs formes et les interactions entre les effets sont basées sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D comprend la représentation d’un objet 3D et la scène sur laquelle l'objet est placé. 

- Lorsque la scène est définie à la fois pour la forme et le texte, la scène de la forme a la priorité supérieure — la scène du texte est ignorée. 
- Si la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée. 
- Sinon—si la forme n’a initialement aucun effet 3D—la forme est plate et l’effet 3D ne s’applique qu’au texte. 

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Appliquer des effets d’ombre externe au texte**
Aspose.Slides for Android via Java fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioutershadow/) et [**IInnerShadow**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinnershadow/) qui permettent d’appliquer des effets d’ombre à un texte porté par [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textframe/). Suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) .
2. Obtenir la référence d’une diapositive en utilisant son index.
3. Ajouter une AutoShape de type Rectangle à la diapositive.
4. Accéder au TextFrame associé à l’AutoShape.
5. Définir la propriété FillType de l’AutoShape sur NoFill.
6. Instancier la classe OuterShadow
7. Définir le BlurRadius de l'ombre.
8. Définir la Direction de l'ombre
9. Définir la Distance de l'ombre.
10. Définir RectangleAlign sur TopLeft.
11. Définir PresetColor de l'ombre sur Black.
12. Enregistrer la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Voici le code Java illustrant ces étapes :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Désactiver le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter une ombre externe et définir tous les paramètres nécessaires
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Enregistrer la présentation sur le disque
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Appliquer des effets d’ombre interne aux formes**
Suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) .
2. Obtenir une référence de la diapositive.
3. Ajouter une AutoShape de type Rectangle.
4. Activer InnerShadowEffect.
5. Définir tous les paramètres nécessaires.
6. Définir ColorType sur Scheme.
7. Définir la couleur du schéma.
8. Enregistrer la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ce code Java montre comment appliquer l’effet d’ombre interne à un texte :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Activer InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Définir tous les paramètres nécessaires
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Définir ColorType comme Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Définir la couleur du schéma
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Enregistrer la présentation
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Puis-je utiliser les effets WordArt avec différentes polices ou scripts (par ex. arabe, chinois) ?

Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

### Puis-je appliquer les effets WordArt aux éléments du masque des diapositives ?

Oui, vous pouvez appliquer les effets WordArt aux formes des masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la mise en page du masque seront reflétées sur toutes les diapositives associées.

### Les effets WordArt influencent-ils la taille du fichier de la présentation ?

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages dégradés peuvent augmenter légèrement la taille du fichier en raison de métadonnées de mise en forme supplémentaires, mais la différence est généralement négligeable.

### Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex. PNG, JPEG) en utilisant la méthode `getImage` des interfaces [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.