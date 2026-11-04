---
title: Appliquer des effets de forme aux présentations avec PHP
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/php-java/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides for PHP via Java — créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/php-java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets de PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de Préréglage sont des combinaisons de deux effets ou plus qui sont connues pour être réussies. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides for PHP via Java prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre au design de votre présentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau sur le fond de la diapositive. L'ombre s'étend au-delà des bords de la forme, créant l'impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, sa direction, sa distance et son rayon de flou pour correspondre à l'éclairage et au style de votre modèle.

Ce code PHP montre comment appliquer l'[effet d'ombre externe](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) à un rectangle:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effet d'ombre](shadow_effect.png)

### **Appliquer une ombre interne**

Lors de la reproduction du style visuel d'un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect en retrait. Une ombre externe s'étend à l'extérieur de la forme et la fait apparaître surélevée, tandis qu'une ombre interne ombre l'intérieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), puis configurez l'ombre renvoyée par [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Des valeurs de rayon de flou plus grandes produisent des bords plus doux.

Cet exemple PHP crée une carte bleu clair avec une ombre interne gris foncé et l'enregistre en tant que fichier PPTX. La direction de l'ombre est de 225 degrés, sa distance est de 7 points et son rayon de flou est de 6 points :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l'ombre interne, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) sur le format d'effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides for PHP via Java, vous pouvez ajouter une réflexion semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l'esthétique de vos présentations en donnant aux formes un aspect plus soigné et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code PHP montre comment appliquer l'[effet de réflexion](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) à une forme :

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effet de réflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for PHP via Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide les formes à ressortir et ajoute un élément visuel attrayant et frappant à votre présentation. Il est facile à mettre en œuvre avec peu de code, améliorant l'aspect général de vos diapositives.

Ce code PHP montre comment appliquer l'[effet de lueur](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) à une forme :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides for PHP via Java, vous pouvez créer une transition lisse et floue autour des bords d'une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions nécessitant une apparence douce et plus légère. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l'effet désiré sur diverses formes de votre présentation.

Ce code PHP montre comment appliquer l'[effet de bords doux](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) à une forme :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effet de bords doux](soft_edges_effect.png)

## **Appliquer un effet de flou**

Utilisez le flou de forme pour adoucir le remplissage et le contour d'une forme tout en la gardant modifiable. Appelez [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) sur le format d'effet de la forme. Le rayon est mesuré en points (1/72 pouce) : utilisez une valeur non négative, les valeurs plus grandes produisant un flou plus intense. Un rayon de zéro laisse l'apparence inchangée.

Le paramètre [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) contrôle les limites visibles de l'effet. Avec `false`, le flou est limité aux limites peintes d'origine, y compris le contour. Avec `true`, le flou peut dépasser ces limites. Aucun des deux réglages ne modifie la position ou les dimensions de la forme.

La comparaison ci‑dessus utilise le même remplissage, contour et dimensions de forme tout au long. La première ligne utilise `grow = false` ; la seconde utilise `grow = true`.

![Rectangle original comparé avec des rayons de flou de 5 et 15 points, avec grow désactivé et activé](shape_blur_comparison.png)

Cet exemple PHP crée un rectangle orange avec un contour bleu foncé, applique un flou de 5 points, puis le met à jour à un flou de 15 points en appelant de nouveau [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Il enregistre les deux états flous, puis appelle [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) et enregistre la forme sans flou.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le flou de forme affecte simultanément le remplissage et le contour. Un effet de bords doux estompe les bords de la forme, tandis que le flou d'ombre adoucit uniquement l'ombre. Les effets de transformation d'image agissent sur le contenu de l'image ; cet exemple applique le flou directement au format d'effet de la forme sans convertir la forme en image.

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l'ombre, la réflexion et la lueur, sur une même forme pour créer un aspect plus dynamique.

**Quelles formes puis-je affecter avec des effets ?**

Vous pouvez appliquer des effets à diverses formes, y compris les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis-je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets aux formes groupées. L'effet s'appliquera à l'ensemble du groupe.