---
title: Substitution de police - API Java PowerPoint
linktitle: Substitution de police
type: docs
weight: 70
url: /php-java/font-substitution/
keywords: "Police, police de substitution, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Substituer une police dans PowerPoint"
---

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qu'il faut faire dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accessible) de cette manière :

1. Charger la présentation pertinente.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de substitution de police de la présentation.
6. Générer l'image de la diapositive pour observer l'effet.

Ce code PHP démontre le processus de substitution de police :

```php
  # Charge une présentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Charge la police source qui sera remplacée
    $sourceFont = new FontData("SomeRareFont");
    # Charge la nouvelle police
    $destFont = new FontData("Arial");
    # Ajoute une règle de police pour le remplacement de police
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Ajoute la règle à la collection de règles de substitution de police
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Ajoute une collection de règles de police à la liste des règles
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # La police Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Sauvegarde l'image sur le disque au format JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 

Vous voudrez peut-être voir [**Remplacement de police**](/slides/php-java/font-replacement/).

{{% /alert %}}