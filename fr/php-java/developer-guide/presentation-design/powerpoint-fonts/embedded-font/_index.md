---
title: Intégrer des polices dans les présentations avec PHP
linktitle: Intégration de police
type: docs
weight: 40
url: /fr/php-java/embedded-font/
keywords:
- ajouter police
- intégrer police
- intégration de police
- obtenir police intégrée
- ajouter police intégrée
- supprimer police intégrée
- compresser police intégrée
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Intégrez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, garantissant un rendu précis sur toutes les plateformes."
---

**Polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation s’affiche correctement lorsqu’elle est ouverte sur n’importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d’intégrer votre police. Sinon (sans polices intégrées), le texte ou les chiffres de vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

La classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) la classe [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) ainsi que leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec les polices intégrées dans les présentations PowerPoint.

## **Obtenir et supprimer les polices intégrées**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) pour vous permettre d’obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code PHP vous montre comment obtenir et supprimer les polices intégrées d’une présentation :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rendu d’une diapositive contenant un cadre de texte qui utilise la police intégrée "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Enregistre l’image sur le disque au format JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Récupère toutes les polices intégrées
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Recherche la police "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Supprime la police "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Rendu de la présentation; "Calibri" font is replaced with an existing one
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Enregistre l’image sur le disque au format JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Enregistre la présentation sans la police "Calibri" intégrée sur le disque
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter des polices intégrées**

En utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) et les deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) vous pouvez choisir la règle d’intégration qui vous convient pour intégrer les polices dans une présentation. Ce code PHP vous montre comment intégrer et ajouter des polices à une présentation :
```php
  # Charge la présentation
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Enregistre la présentation sur le disque
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Ce code PHP vous montre comment compresser les polices PowerPoint intégrées :
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment savoir qu’une police spécifique dans la présentation sera tout de même substituée lors du rendu malgré son intégration ?**

Vérifiez les [informations de substitution](/slides/fr/php-java/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/php-java/fallback-font/) : si la police est indisponible ou restreinte, un secours sera utilisé.

**Vale-t-il la peine d’intégrer les polices « système » comme Arial/Calibri ?**

En général, non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), intégrer les polices système peut éliminer le risque de substitutions inattendues.