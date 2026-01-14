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

**Polices incorporées dans PowerPoint** sont utiles lorsque vous voulez que votre présentation s’affiche correctement sur n’importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité, vous avez encore plus de raisons d’incorporer votre police. Sinon (sans polices incorporées), le texte ou les nombres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles déroutants. 

La classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) et la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) contiennent la plupart des méthodes dont vous avez besoin pour travailler avec des polices incorporées dans les présentations PowerPoint.

## **Obtenir et supprimer des polices incorporées**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) pour vous permettre d’obtenir (ou de découvrir) les polices incorporées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (exposée par la même classe) est utilisée.

Ce code PHP vous montre comment obtenir et supprimer des polices incorporées d’une présentation :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rend une diapositive contenant un cadre texte qui utilise la police incorporée "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Enregistre l'image sur le disque au format JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Obtient toutes les polices incorporées
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
    # Rend la présentation ; la police "Calibri" est remplacée par une police existante
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Enregistre l'image sur le disque au format JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Enregistre la présentation sans la police "Calibri" incorporée sur le disque
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter des polices incorporées**

En utilisant la classe [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) et deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), vous pouvez choisir votre règle (d’incorporation) préférée pour incorporer les polices dans une présentation. Ce code PHP vous montre comment incorporer et ajouter des polices à une présentation :
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


## **Compresser les polices incorporées**

Pour vous permettre de compresser les polices incorporées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts) (exposée par la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Ce code PHP vous montre comment compresser les polices PowerPoint incorporées :
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

**Comment puis‑je savoir qu’une police spécifique de la présentation sera quand même substituée lors du rendu malgré son incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/php-java/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/php-java/fallback-font/) : si la police est indisponible ou restreinte, un secours sera utilisé.

**Vaut‑il la peine d’incorporer des polices « système » comme Arial/Calibri ?**

En général non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), incorporer les polices système peut éliminer le risque de substitutions inattendues.