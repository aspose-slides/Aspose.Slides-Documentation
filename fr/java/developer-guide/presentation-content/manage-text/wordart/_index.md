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
description: "Créer et personnaliser les effets WordArt dans Aspose.Slides pour Java. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en Java."
---

## **À propos de WordArt ?**
WordArt ou Word Art est une fonctionnalité qui vous permet d’appliquer des effets aux textes pour les faire ressortir. Avec WordArt, par exemple, vous pouvez créer un contour autour d’un texte ou le remplir d’une couleur (ou d’un dégradé), ajouter des effets 3D, etc. Vous pouvez également incliner, plier et étirer la forme d’un texte. 

{{% alert color="primary" %}} 
WordArt vous permet de traiter un texte comme un objet graphique. En général, WordArt consiste en des effets ou modifications spéciales appliqués aux textes pour les rendre plus attrayants ou visibles. 
{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l’un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d’effets qui s’applique à un texte ou à sa forme. 

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour Java 20.10, nous avons implémenté la prise en charge de WordArt et apporté des améliorations à cette fonctionnalité dans les versions ultérieures d’Aspose.Slides pour Java. 

Avec Aspose.Slides pour Java, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d’effets) en Java et l’appliquer aux textes. 

## **Créer un modèle WordArt simple et l’appliquer à un texte**

**Utilisation d’Aspose.Slides** 

Tout d’abord, nous créons un texte simple à l’aide de ce code Java :
``` java
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

Ensuite, nous augmentons la hauteur de police du texte pour rendre l’effet plus visible grâce à ce code :
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Utilisation de Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :
![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres d’un nouveau WordArt. 

Voici quelques-uns des paramètres ou options disponibles :
![todo:image_alt_text](image-20200930114015-3.png)

**Utilisation d’Aspose.Slides**

Ici, nous appliquons la couleur de motif [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) au texte et ajoutons une bordure noire d’une largeur de 1 px au texte à l’aide de ce code :
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


Le texte résultant :
![todo:image_alt_text](image-20200930114108-4.png)

## **Appliquer d’autres effets WordArt**

**Utilisation de Microsoft PowerPoint**

Depuis l’interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :
![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet Forme (elle reste effective même lorsqu’aucune propriété Format 3D n’est définie). 

### **Appliquer des effets d’ombre**

Ici, nous voulons définir les propriétés relatives uniquement à un texte. Nous appliquons l’effet d’ombre à un texte à l’aide de ce code Java :
``` java
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
```


L’API Aspose.Slides prend en charge trois types d’ombres : OuterShadow, InnerShadow et PresetShadow.  
Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous pouvez n’utiliser qu’un type d’ombre. Voici un exemple :
![todo:image_alt_text](image-20200930114225-6.png)

**Utilisation d’Aspose.Slides**

Aspose.Slides permet en fait d’appliquer deux types d’ombres simultanément : InnerShadow et PresetShadow.  

**Remarques :**
- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l’effet OuterShadow est appliqué.  
- Si OuterShadow et InnerShadow sont utilisés simultanément, l’effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l’effet est doublé. Mais dans PowerPoint 2007, c’est l’effet OuterShadow qui est appliqué.  

### **Appliquer l’affichage aux textes**

Nous ajoutons l’affichage au texte à l’aide de cet exemple de code Java :
``` java
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
```


### **Appliquer l’effet de lueur aux textes**

Nous appliquons l’effet de lueur au texte pour le faire briller ou le faire ressortir à l’aide de ce code :
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Le résultat de l’opération :
![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Vous pouvez modifier les paramètres d’ombre, d’affichage et de lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte. 
{{% /alert %}} 

### **Utiliser les transformations dans WordArt**

Nous utilisons la propriété Transform ( inhérente à l’ensemble du bloc de texte) avec ce code :
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Le résultat :
![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint et Aspose.Slides pour Java offrent un certain nombre de types de transformation prédéfinis. 
{{% /alert %}} 

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, suivez : **Format** → **TextEffect** → **Transform**  

**Utilisation d’Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l’énumération TextShapeType.  

### **Appliquer des effets 3D aux textes et aux formes**

Nous appliquons un effet 3D à une forme de texte à l’aide de cet exemple de code :
``` java
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
```


Le texte résultant et sa forme :
![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Java :
``` java
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
```


Le résultat de l’opération :
![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
L’application des effets 3D aux textes ou à leurs formes et les interactions entre les effets sont basées sur certaines règles.

Considérez une scène pour un texte et la forme contenant ce texte. L’effet 3D comprend la représentation de l’objet 3D et la scène sur laquelle l’objet est placé.

- Lorsque la scène est définie à la fois pour la forme et le texte, la scène de la forme a la priorité supérieure — la scène du texte est ignorée.  
- Lorsque la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée.  
- Sinon — lorsqu’une forme n’a initialement aucun effet 3D — la forme reste plane et l’effet 3D ne s’applique qu’au texte.  

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Appliquer des effets d’ombre extérieure aux textes**
Aspose.Slides pour Java fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) et [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) qui vous permettent d’appliquer des effets d’ombre à un texte contenu dans un [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame). Suivez ces étapes :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
2. Obtenez la référence d’une diapositive en utilisant son index.  
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

Ce code d’exemple en Java — une implémentation des étapes ci‑dessus — montre comment appliquer l’effet d’ombre extérieure à un texte :
```java
Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Désactiver le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter une ombre extérieure et définir tous les paramètres nécessaires
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Enregistrer la présentation sur le disque
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Appliquer l’effet d’ombre intérieure aux formes**
Suivez ces étapes :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
2. Obtenez une référence de la diapositive.  
3. Ajoutez une AutoShape de type Rectangle.  
4. Activez InnerShadowEffect.  
5. Définissez tous les paramètres nécessaires.  
6. Définissez la propriété ColorType sur Scheme.  
7. Définissez la couleur du schéma.  
8. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code d’exemple (basé sur les étapes ci‑dessus) montre comment ajouter un connecteur entre deux formes en Java :
```java
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

    // Activer l'effet d'ombre intérieure
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

**Puis-je utiliser les effets WordArt avec différentes polices ou scripts (par ex., arabe, chinois) ?**  
Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices système.

**Puis-je appliquer les effets WordArt aux éléments du masque des diapositives ?**  
Oui, vous pouvez appliquer les effets WordArt aux formes sur les masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la mise en page du masque seront reflétées sur toutes les diapositives associées.

**Les effets WordArt affectent-ils la taille du fichier de présentation ?**  
Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages en dégradé peuvent légèrement augmenter la taille du fichier en raison des métadonnées de formatage supplémentaires, mais la différence est généralement négligeable.

**Puis-je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**  
Oui, vous pouvez rendre les diapositives contenant des WordArt en images (par ex., PNG, JPEG) en utilisant la méthode `getImage` des interfaces [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.