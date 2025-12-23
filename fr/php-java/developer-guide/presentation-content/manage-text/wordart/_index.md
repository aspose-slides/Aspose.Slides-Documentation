---
title: Créer et appliquer des effets WordArt en PHP
linktitle: WordArt
type: docs
weight: 110
url: /fr/php-java/wordart/
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
- PHP
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour PHP via Java. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel."
---

## **À propos de WordArt ?**
WordArt ou Word Art est une fonctionnalité qui vous permet d’appliquer des effets au texte pour le faire ressortir. Avec WordArt, par exemple, vous pouvez tracer le contour d’un texte ou le remplir d’une couleur (ou d’un dégradé), ajouter des effets 3D, etc. Vous pouvez également incliner, plier et étirer la forme d’un texte.  

{{% alert color="primary" %}}  

WordArt vous permet de traiter un texte comme un objet graphique. En général, WordArt se compose d’effets ou de modifications spéciales appliquées aux textes pour les rendre plus attractifs ou remarquables.  

{{% /alert %}}  

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez choisir l’un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d’effets qui s’applique à un texte ou à sa forme.  

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour PHP via Java 20.10, nous avons implémenté la prise en charge de WordArt et amélioré la fonctionnalité dans les versions ultérieures d’Aspose.Slides pour PHP via Java.  

Avec Aspose.Slides pour PHP via Java, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d’effets) et l’appliquer aux textes.  

## **Créer un modèle WordArt simple et l’appliquer à du texte**

**Utilisation d’Aspose.Slides**  

Tout d’abord, nous créons un texte simple avec ce code PHP :  
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
  
Ensuite, nous augmentons la hauteur de police du texte afin que l’effet soit plus visible grâce à ce code :  
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```
  

**Utilisation de Microsoft PowerPoint**  

Accédez au menu des effets WordArt dans Microsoft PowerPoint :  

![todo:image_alt_text](image-20200930113926-1.png)  

Dans le panneau de droite, vous pouvez choisir un effet WordArt prédéfini. Dans le panneau de gauche, vous pouvez spécifier les paramètres d’un nouveau WordArt.  

Voici quelques paramètres ou options disponibles :  

![todo:image_alt_text](image-20200930114015-3.png)  

**Utilisation d’Aspose.Slides**  

Ici, nous appliquons la couleur de motif [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) au texte et ajoutons une bordure noire d’une largeur de 1 grâce à ce code :  
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```
  

Le texte résultant :  

![todo:image_alt_text](image-20200930114108-4.png)  

## **Appliquer d’autres effets WordArt**

**Utilisation de Microsoft PowerPoint**  

Depuis l’interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :  

![todo:image_alt_text](image-20200930114129-5.png)  

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet forme (elle reste effective même sans propriété Format 3D).  

### **Appliquer des effets d’Ombre**

Ici, nous ne visons que les propriétés liées à un texte. Nous appliquons l’effet d’ombre à un texte avec ce code :  
```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```
  

L’API Aspose.Slides prend en charge trois types d’ombres : OuterShadow, InnerShadow et PresetShadow.  

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies).  

**Utilisation de Microsoft PowerPoint**  

Dans PowerPoint, vous ne pouvez utiliser qu’un type d’ombre. Voici un exemple :  

![todo:image_alt_text](image-20200930114225-6.png)  

**Utilisation d’Aspose.Slides**  

Aspose.Slides vous permet réellement d’appliquer simultanément deux types d’ombres : InnerShadow et PresetShadow.  

**Remarques :**  

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l’effet OuterShadow est appliqué.  
- Si OuterShadow et InnerShadow sont utilisés simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, sous PowerPoint 2013, l’effet est doublé ; sous PowerPoint 2007, l’effet OuterShadow est appliqué.  

### **Appliquer des effets de Réflexion au texte**

Nous ajoutons la réflexion au texte avec cet extrait de code :  
```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```
  

### **Appliquer des effets de Lueur au texte**

Nous appliquons l’effet de lueur au texte pour le faire briller ou ressortir avec ce code :  
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```
  

Résultat de l’opération :  

![todo:image_alt_text](image-20200930114621-7.png)  

{{% alert color="primary" %}}  

Vous pouvez modifier les paramètres d’ombre, de réflexion et de lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte.  

{{% /alert %}}  

### **Utiliser les transformations dans WordArt**

Nous utilisons la propriété Transform (héritée par l’ensemble du bloc de texte) avec ce code :  
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```
  

Résultat :  

![todo:image_alt_text](image-20200930114712-8.png)  

{{% alert color="primary" %}}  

PowerPoint et Aspose.Slides pour PHP via Java offrent un certain nombre de types de transformation prédéfinis.  

{{% /alert %}}  

**Utilisation de PowerPoint**  

Pour accéder aux types de transformation prédéfinis, suivez : **Format** → **TextEffect** → **Transform**  

**Utilisation d’Aspose.Slides**  

Pour sélectionner un type de transformation, utilisez l’énumération TextShapeType.  

### **Appliquer des effets 3D au texte et aux formes**

Nous appliquons un effet 3D à une forme de texte avec ce code d’exemple :  
```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```
  

Le texte et sa forme résultants :  

![todo:image_alt_text](image-20200930114816-9.png)  

Nous appliquons un effet 3D au texte avec ce code PHP :  
```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```
  

Résultat de l’opération :  

![todo:image_alt_text](image-20200930114905-10.png)  

{{% alert color="primary" %}}  

L’application d’effets 3D aux textes ou à leurs formes ainsi que les interactions entre effets sont régies par certaines règles.  

Considérez une scène pour un texte et la forme contenant ce texte. L’effet 3D comprend la représentation de l’objet 3D et la scène sur laquelle l’objet est placé.  

- Si la scène est définie à la fois pour la forme et pour le texte, la scène de la forme a la priorité ; la scène du texte est ignorée.  
- Si la forme ne possède pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée.  
- Sinon—si la forme n’a initialement aucun effet 3D—la forme reste plate et l’effet 3D ne s’applique qu’au texte.  

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera().  

{{% /alert %}}  

## **Appliquer des effets d’Ombre externe au texte**  
Aspose.Slides pour PHP via Java propose les classes [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) et [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) qui permettent d’appliquer des effets d’ombre à un texte contenu dans un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. Obtenez la référence d’une diapositive en utilisant son indice.  
3. Ajoutez une AutoShape de type Rectangle à la diapositive.  
4. Accédez au TextFrame associé à l’AutoShape.  
5. Définissez le FillType de l’AutoShape sur NoFill.  
6. Instanciez la classe OuterShadow.  
7. Définissez le BlurRadius de l’ombre.  
8. Définissez la Direction de l’ombre.  
9. Définissez la Distance de l’ombre.  
10. Définissez le RectanglelAlign sur TopLeft.  
11. Définissez le PresetColor de l’ombre sur Black.  
12. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code d’exemple —mise en œuvre des étapes ci‑dessus— montre comment appliquer l’effet d’ombre externe à un texte :  
```php
  $pres = new Presentation();
  try {
    # Obtenir la référence de la diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Ajouter un TextFrame au rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # Désactiver le remplissage de la forme au cas où nous voulons obtenir l'ombre du texte
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Ajouter une ombre externe et définir tous les paramètres nécessaires
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Enregistrer la présentation sur le disque
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
  

## **Appliquer des effets d’Ombre interne aux formes**  
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. Obtenez la référence de la diapositive.  
3. Ajoutez une AutoShape de type Rectangle.  
4. Activez InnerShadowEffect.  
5. Définissez tous les paramètres nécessaires.  
6. Définissez le ColorType sur Scheme.  
7. Définissez la couleur du schéma.  
8. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code d’exemple (basé sur les étapes ci‑dessus) montre comment ajouter un connecteur entre deux formes :  
```php
  $pres = new Presentation();
  try {
    # Obtenir la référence de la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Ajouter un TextFrame au rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Activer InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Définir tous les paramètres nécessaires
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Définir ColorType comme Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Définir la couleur du schéma
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Enregistrer la présentation
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
  

## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex. arabe, chinois) ?**  

Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices système.

**Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?**  

Oui, vous pouvez appliquer des effets WordArt aux formes des masques maîtres, y compris les espaces réservés au titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées au masque se répercutent sur toutes les diapositives associées.

**Les effets WordArt influent‑ils sur la taille du fichier de présentation ?**  

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages en dégradé peuvent augmenter modestement la taille du fichier en raison des métadonnées de formatage supplémentaires, mais la différence est généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**  

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (PNG, JPEG, etc.) en utilisant la méthode `getImage` des interfaces [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). Cela vous permet de prévisualiser le rendu en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.