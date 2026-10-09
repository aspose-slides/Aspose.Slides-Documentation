---
title: Appliquer des effets de forme dans les présentations avec PHP
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

Bien que les effets dans PowerPoint puissent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/php-java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets de PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

![Effet d'ombre](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus esthétiques que d’autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Preset sont des combinaisons de deux effets ou plus qui sont reconnues comme étant agréables. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides for PHP via Java prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou afin d’adapter le design de votre présentation.

### **Appliquer une ombre extérieure**

Utilisez une ombre extérieure pour faire ressortir une carte ou un panneau par rapport à l’arrière-plan de la diapositive. L’ombre dépasse les bords de la forme, créant l’impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, sa direction, sa distance et son rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code PHP montre comment appliquer l’[effet d'ombre extérieure](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) à un rectangle :

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

Lors de la reproduction du style visuel d’un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect en retrait. Une ombre extérieure s’étend à l’extérieur de la forme et la fait apparaître surélevée, tandis qu’une ombre interne ombre l’intérieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), puis configurez l’ombre renvoyée par [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Des valeurs de rayon de flou plus élevées produisent des bords plus doux.

Cet exemple PHP crée une carte bleu clair avec une ombre interne gris foncé et l’enregistre au format PPTX. La direction de l’ombre est de 225 degrés, sa distance est de 7 points et son rayon de flou est de 6 points :

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

Pour supprimer l’ombre interne, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) sur le format d’effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides for PHP via Java, vous pouvez ajouter une réflexion miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus soigné et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code PHP montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) à une forme :

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

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for PHP via Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés telles que la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant et saisissant à votre présentation. Il est facile à mettre en œuvre avec un code minimal, améliorant l’aspect général de vos diapositives.

Ce code PHP montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) à une forme :

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

Pour appliquer un effet de bords doux dans Aspose.Slides for PHP via Java, vous pouvez créer une transition lisse et floue autour des contours d’une forme. Cet effet ajoute un rendu plus subtil et raffiné, parfait pour les conceptions qui nécessitent une apparence douce et délicate. Vous pouvez facilement ajuster des paramètres tels que le rayon pour obtenir l’effet souhaité sur diverses formes de votre présentation.

Ce code PHP montre comment appliquer l’[effet de bords doux](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) à une forme :

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

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**  
Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**  
Vous pouvez appliquer des effets à diverses formes, notamment les autoshapes, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets aux formes groupées ?**  
Oui, vous pouvez appliquer des effets aux formes groupées. L’effet sera appliqué à l’ensemble du groupe.