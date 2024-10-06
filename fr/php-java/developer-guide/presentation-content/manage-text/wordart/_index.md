---
title: WordArt
type: docs
weight: 110
url: /php-java/wordart/
---

## **À propos de WordArt?**
WordArt ou Art de mots est une fonctionnalité qui vous permet d'appliquer des effets aux textes pour les faire ressortir. Avec WordArt, par exemple, vous pouvez contourner un texte ou le remplir avec une couleur (ou un dégradé), ajouter des effets 3D, etc. Vous avez également la possibilité d'incliner, de plier et d'étirer la forme d'un texte.

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme vous le feriez pour un objet graphique. En général, WordArt se compose d'effets ou de modifications spéciales apportées aux textes pour les rendre plus attrayants ou visibles.

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l'un des modèles de WordArt prédéfinis. Un modèle de WordArt est un ensemble d'effets qui est appliqué à un texte ou à sa forme.

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour PHP via Java 20.10, nous avons implémenté la prise en charge de WordArt et amélioré la fonctionnalité dans les versions ultérieures d'Aspose.Slides pour PHP via Java.

Avec Aspose.Slides pour PHP via Java, vous pouvez facilement créer votre propre modèle de WordArt (un effet ou combinaison d'effets) et l'appliquer aux textes.

## Créer un modèle WordArt simple et l'appliquer à un texte

**Utiliser Aspose.Slides** 

Tout d'abord, nous créons un texte simple à l'aide de ce code PHP :

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
Maintenant, nous réglons la hauteur de la police du texte à une valeur plus grande pour rendre l'effet plus visible à travers ce code :

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Utiliser Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres pour un nouveau WordArt.

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Utiliser Aspose.Slides**

Ici, nous appliquons la couleur de motif [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) au texte et ajoutons une bordure de texte noire de 1 pixel de large à l'aide de ce code :

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

## Appliquer d'autres effets WordArt

**Utiliser Microsoft PowerPoint**

À partir de l'interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, des effets d'ombre, de réflexion et de lueur peuvent être appliqués à un texte ; des effets de Format 3D et de Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Douces Bords peut être appliquée à un Objet Forme (elle a toujours un effet lorsque aucune propriété de Format 3D n'est définie). 

### Appliquer des effets d'ombre

Ici, nous avons l'intention de définir les propriétés relatives à un texte uniquement. Nous appliquons l'effet d'ombre à un texte à l'aide de ce code :

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

L'API Aspose.Slides prend en charge trois types d'ombres : OuterShadow, InnerShadow et PresetShadow.

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies).

**Utiliser Microsoft PowerPoint**

Dans PowerPoint, vous pouvez utiliser un type d'ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Utiliser Aspose.Slides**

Aspose.Slides permet en fait d'appliquer deux types d'ombres à la fois : InnerShadow et PresetShadow.

**Notes :**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué.
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, l'effet OuterShadow est appliqué.

### Appliquer une réflexion aux textes

Nous ajoutons une réflexion au texte à l'aide de cet exemple de code :

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

### Appliquer un effet de lueur aux textes

Nous appliquons l'effet de lueur au texte pour le faire briller ou ressortir à l'aide de ce code :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez changer les paramètres pour l'ombre, la réflexion et la lueur. Les propriétés des effets sont définies sur chaque portion du texte séparément.

{{% /alert %}} 

### Utiliser des transformations dans WordArt

Nous utilisons la propriété Transform (inhérente à l'ensemble du bloc de texte) à travers ce code :
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

À la fois Microsoft PowerPoint et Aspose.Slides pour PHP via Java offrent un certain nombre de types de transformation prédéfinis.

{{% /alert %}} 

**Utiliser PowerPoint**

Pour accéder aux types de transformation prédéfinis, allez dans : **Format** -> **Effet de texte** -> **Transformer**

**Utiliser Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l'énumération TextShapeType. 

### Appliquer des effets 3D aux textes et aux formes

Nous définissons un effet 3D à une forme de texte à l'aide de ce code d'exemple :

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

Le texte résultant et sa forme :

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

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L'application d'effets 3D aux textes ou à leurs formes et les interactions entre les effets sont basées sur certaines règles.

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D contient la représentation de l'objet 3D et la scène sur laquelle l'objet a été placé.

- Lorsque la scène est définie pour la figure et le texte, la scène de la figure a une priorité plus élevée : la scène de texte est ignorée.
- Lorsque la figure n'a pas sa propre scène mais a une représentation 3D, la scène de texte est utilisée.
- Sinon, lorsque la forme n'a pas d'effet 3D d'origine, la forme est plate et l'effet 3D n'est appliqué qu'au texte.

Ces descriptions sont liées aux méthodes ThreeDFormat.getLightRig() et ThreeDFormat.getCamera().

{{% /alert %}} 

## **Appliquer des effets d'ombre externe aux textes**
Aspose.Slides pour PHP via Java fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) et [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) qui vous permettent d'appliquer des effets d'ombre à un texte porté par [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez une AutoShape de type Rectangle à la diapositive.
4. Accédez à la TextFrame associée à l'AutoShape.
5. Définissez le FillType de l'AutoShape sur NoFill.
6. Instanciez la classe OuterShadow.
7. Définissez le BlurRadius de l'ombre.
8. Définissez la Direction de l'ombre.
9. Définissez la Distance de l'ombre.
10. Définissez le RectangleAlign sur TopLeft.
11. Définissez la couleur prédéfinie de l'ombre sur Noir.
12. Écrivez la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d'exemple — une implémentation des étapes ci-dessus — vous montre comment appliquer l'effet d'ombre externe à un texte :

```php
  $pres = new Presentation();
  try {
    # Obtenez une référence de la diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoutez une AutoShape de type Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # Désactivez le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Ajoutez une ombre externe et définissez tous les paramètres nécessaires
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Écrivez la présentation sur le disque
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Appliquer un effet d'ombre interne aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Obtenez une référence de la diapositive.
3. Ajoutez une AutoShape de type Rectangle.
4. Activez l'effet InnerShadowEffect.
5. Définissez tous les paramètres nécessaires.
6. Définissez le ColorType sur Scheme.
7. Définissez la couleur du schéma.
8. Écrivez la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d'exemple (basé sur les étapes ci-dessus) vous montre comment ajouter un connecteur entre deux formes :

```php
  $pres = new Presentation();
  try {
    # Obtenez une référence de la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoutez une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Activez l'InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Définissez tous les paramètres nécessaires
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Définissez ColorType sur Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Définissez la couleur du schéma
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Enregistrez la présentation
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```