---
title: Gérer les paramètres d'ajustement automatique
type: docs
weight: 30
url: /php-java/manage-autofit-settings/
keywords: "Textbox, Ajustement automatique, Présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Définir les paramètres d'ajustement automatique pour la zone de texte dans PowerPoint"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** pour la zone de texte : il redimensionne automatiquement la zone de texte pour s'assurer que son texte y rentre toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmente sa hauteur—pour permettre d'accueillir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour éliminer l'espace redondant.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d'ajustement automatique pour une zone de texte : 

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de débordement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour PHP via Java propose des options similaires—certaines propriétés sous la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d'ajustement automatique pour les zones de texte dans les présentations.

## **Redimensionner la forme pour ajuster le texte**

Si vous souhaitez que le texte dans une zone s'ajuste toujours dans cette zone après des modifications apportées au texte, vous devez utiliser l'option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code PHP vous montre comment spécifier qu'un texte doit toujours tenir dans sa zone dans une présentation PowerPoint :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour s'assurer que tout le texte y rentre. Si le texte devient plus court, l'inverse se produit.

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions, peu importe les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas ajuster automatiquement**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code PHP vous montre comment spécifier qu'une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Lorsque le texte devient trop long pour sa zone, il déborde.

## **Réduire le texte en cas de débordement**

Si un texte devient trop long pour sa zone, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour le faire entrer dans sa zone. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code PHP vous montre comment spécifier qu'un texte doit être réduit en cas de débordement dans une présentation PowerPoint :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le paramètre est appliqué uniquement lorsque le texte devient trop long pour sa zone.

{{% /alert %}}

## **Envelopper le texte**

Si vous souhaitez que le texte dans une forme soit enveloppé à l'intérieur de cette forme lorsque le texte dépasse la bordure de la forme (uniquement la largeur), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce paramètre, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `true`.

Ce code PHP vous montre comment utiliser le paramètre Envelopper le texte dans une présentation PowerPoint :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}}

Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte s'étend au-delà des bords de la forme le long d'une seule ligne.

{{% /alert %}}