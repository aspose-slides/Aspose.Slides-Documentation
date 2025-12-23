---
title: Améliorez vos présentations avec AutoFit en PHP
linktitle: Paramètres Autofit
type: docs
weight: 30
url: /fr/php-java/manage-autofit-settings/
keywords:
- zone de texte
- autofit
- ne pas autofit
- adapter le texte
- réduire le texte
- envelopper le texte
- redimensionner la forme
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les paramètres AutoFit dans Aspose.Slides pour PHP afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** — il redimensionne automatiquement la zone de texte afin que son texte y tienne toujours. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur—pour lui permettre de contenir plus de texte.  
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur—pour éliminer l’espace redondant.  

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’ajustement automatique pour une zone de texte : 

* **Ne pas ajuster automatiquement**  
* **Réduire le texte en cas de dépassement**  
* **Redimensionner la forme pour ajuster le texte**  
* **Envelopper le texte dans la forme**  

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java propose des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d’ajustement automatique des zones de texte dans les présentations.

## **Redimensionner une forme pour ajuster le texte**

Si vous voulez que le texte d’une boîte s’ajuste toujours à cette boîte après des modifications, vous devez utiliser l’option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code PHP montre comment spécifier qu’un texte doit toujours s’ajuster à sa boîte dans une présentation PowerPoint :
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


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) afin que tout le texte y tienne. Si le texte devient plus court, l’effet inverse se produit. 

## **Ne pas ajuster automatiquement**

Si vous voulez qu’une zone de texte ou une forme conserve ses dimensions quels que soient les changements apportés au texte qu’elle contient, vous devez utiliser l’option **Ne pas ajuster automatiquement**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code PHP montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
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


Lorsque le texte devient trop long pour sa boîte, il déborde. 

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa boîte, l’option **Réduire le texte en cas de dépassement** vous permet de spécifier que la taille et l’espacement du texte doivent être diminués afin qu’il tienne dans la boîte. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code PHP montre comment spécifier qu’un texte doit être réduit en cas de dépassement dans une présentation PowerPoint :
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
Lorsque l’option **Réduire le texte en cas de dépassement** est utilisée, le réglage n’est appliqué que lorsque le texte devient trop long pour sa boîte. 
{{% /alert %}}

## **Envelopper le texte**

Si vous voulez que le texte d’une forme soit enveloppé à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce réglage, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) sur `true`.

Ce code PHP montre comment utiliser le réglage Envelopper le texte dans une présentation PowerPoint :
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
Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne. 
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte influencent‑elles l’AutoFit ?**  
Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit s’active plus tôt — il réduit la police ou redimensionne la forme plus rapidement. Vérifiez et ajustez les marges avant d’affiner l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**  
Les sauts forcés restent en place, et l’AutoFit adapte la taille de la police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’intensité avec laquelle l’AutoFit doit rétrécir le texte.

**La modification de la police du thème ou le déclenchement d’une substitution de police affecte‑t-elle les résultats de l’AutoFit ?**  
Oui. Substituer une police avec des métriques de glyphes différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.