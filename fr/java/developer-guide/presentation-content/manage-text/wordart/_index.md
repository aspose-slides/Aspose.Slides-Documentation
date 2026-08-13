---
title: Créer et appliquer des effets WordArt en Java
linktitle: WordArt
type: docs
weight: 110
url: /fr/java/wordart/
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
- effet d'ombre extérieure
- effet d'ombre intérieure
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour Java. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en Java."
---
## **Vue d'ensemble**

Les effets WordArt vous permettent d’ajouter du texte visuellement attrayant et stylisé à vos présentations PowerPoint. Avec Aspose.Slides, les développeurs peuvent créer, personnaliser et gérer le WordArt de façon programmatique, comme dans Microsoft PowerPoint—sans nécessiter l’installation d’Office. Cet article donne un aperçu du travail avec le WordArt, y compris comment appliquer des transformations de texte, des styles de remplissage, des contours, des ombres et d’autres options de formatage pour rendre le contenu de votre présentation plus expressif et engageant. Le WordArt vous permet de traiter le texte comme un objet graphique. Il s’agit d’effets ou de modifications spéciales appliqués au texte pour le rendre plus attrayant ou visible.

## **Création d’un modèle WordArt simple et application à un texte**

**Utilisation d’Aspose.Slides**  

Tout d’abord, nous créons un texte simple avec ce code Java :

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
Ensuite, nous définissons une hauteur de police supérieure pour rendre l’effet plus visible grâce à ce code :

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Utilisation de Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le volet de droite, vous pouvez choisir un effet WordArt prédéfini. Dans le volet de gauche, vous pouvez préciser les paramètres d’un nouveau WordArt.

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Utilisation d’Aspose.Slides**

Ici, nous appliquons le motif de couleur [SmallGrid](https://reference.aspose.com/slides/fr/java/com.aspose.slides/PatternStyle#SmallGrid) au texte et ajoutons un contour noir d’une largeur de 1 grâce à ce code :

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

## **Application d’autres effets WordArt**

**Utilisation de Microsoft PowerPoint**

Depuis l’interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet Forme (elle reste effective même lorsqu’aucune propriété Format 3D n’est définie).

### **Application des effets d’ombre**

Ici, nous ne visons que les propriétés liées à un texte. Nous appliquons l’effet d’ombre à un texte avec ce code Java :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

L’API Aspose.Slides prend en charge trois types d’ombres : OuterShadow, InnerShadow et PresetShadow.

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies).

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous ne disposez que d’un type d’ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Utilisation d’Aspose.Slides**

Aspose.Slides vous permet réellement d’appliquer deux types d’ombres simultanément : InnerShadow et PresetShadow.

**Remarques :**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l’effet OuterShadow est appliqué.  
- Si OuterShadow et InnerShadow sont utilisés simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, sous PowerPoint 2013, l’effet est doublé. Mais sous PowerPoint 2007, l’effet OuterShadow est appliqué.

### **Application du rendu aux textes**

Nous ajoutons un rendu au texte avec cet exemple de code Java :

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Application de l’effet Lueur aux textes**

Nous appliquons l’effet de lueur au texte pour le faire briller ou se démarquer avec ce code :

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Le résultat de l’opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Vous pouvez modifier les paramètres d’ombre, de rendu et de lueur. Les propriétés des effets sont définies séparément pour chaque portion de texte. 

{{% /alert %}} 

### **Utilisation des transformations dans WordArt**

Nous utilisons la propriété Transform (appliquée à l’ensemble du bloc de texte) avec ce code :

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Microsoft PowerPoint et Aspose.Slides pour Java offrent un certain nombre de types de transformation prédéfinis. 

{{% /alert %}} 

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, suivez : **Format** → **Effet de texte** → **Transformation**

**Utilisation d’Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l’énumération TextShapeType. 

### **Application d’effets 3D aux textes et aux formes**

Nous appliquons un effet 3D à une forme de texte avec cet exemple de code :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Le texte et sa forme résultants :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Java :

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Le résultat de l’opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

L’application d’effets 3D aux textes ou à leurs formes et les interactions entre les effets sont régies par certaines règles.

Considérez une scène pour un texte et la forme qui le contient. L’effet 3D comprend la représentation de l’objet 3D et la scène sur laquelle l’objet a été placé.

- Lorsque la scène est définie à la fois pour la figure et le texte, la scène de la figure obtient la priorité ; la scène du texte est ignorée.  
- Lorsque la figure n’a pas sa propre scène mais possède une représentation 3D, la scène du texte est utilisée.  
- Dans le cas contraire—si la forme n’a initialement aucun effet 3D—la forme reste plate et l’effet 3D ne s’applique qu’au texte.

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Application d’effets d’ombre extérieure aux textes**
Aspose.Slides pour Java fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ioutershadow/) et [**IInnerShadow**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinnershadow/) qui permettent d’appliquer des effets d’ombre à un texte contenu dans un [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/). Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).  
2. Obtenez la référence d’une diapositive en utilisant son indice.  
3. Ajoutez une AutoShape de type Rectangle à la diapositive.  
4. Accédez au TextFrame associé à l’AutoShape.  
5. Définissez la propriété FillType de l’AutoShape sur NoFill.  
6. Instanciez la classe OuterShadow.  
7. Définissez la propriété BlurRadius de l’ombre.  
8. Définissez la Direction de l’ombre.  
9. Définissez la Distance de l’ombre.  
10. Définissez la propriété RectanglelAlign sur TopLeft.  
11. Définissez la PresetColor de l’ombre sur Black.  
12. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d’exemple en Java—une implémentation des étapes ci‑dessus—vous montre comment appliquer l’effet d’ombre extérieure à un texte :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Désactiver le remplissage de la forme au cas où nous voulons obtenir l'ombre du texte
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter une ombre extérieure et définir tous les paramètres nécessaires
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

## **Application de l’effet d’ombre intérieure aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).  
2. Obtenez une référence de la diapositive.  
3. Ajoutez une AutoShape de type Rectangle.  
4. Activez InnerShadowEffect.  
5. Définissez tous les paramètres nécessaires.  
6. Définissez la ColorType sur Scheme.  
7. Définissez la couleur du schéma.  
8. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d’exemple (basé sur les étapes ci‑dessus) vous montre comment appliquer l’effet d’ombre intérieure au texte d’une forme en Java :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Activer l'effet InnerShadow
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Définir tous les paramètres nécessaires
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Définir le type de couleur comme Schéma
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

### Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex., arabe, chinois) ?

Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices système.

### Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?

Oui, vous pouvez appliquer les effets WordArt aux formes des masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications effectuées sur la disposition du masque seront reflétées sur toutes les diapositives associées.

### Les effets WordArt influent-ils sur la taille du fichier de présentation ?

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages dégradés peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage ajoutées, mais la différence reste généralement négligeable.

### Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?

Oui, vous pouvez rendre les diapositives contenant du WordArt sous forme d’images (par ex., PNG, JPEG) à l’aide de la méthode `getImage` des interfaces [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.