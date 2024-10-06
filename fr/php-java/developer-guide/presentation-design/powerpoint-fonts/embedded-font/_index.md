---
title: Police embarquée - PowerPoint Java API
linktitle: Police embarquée
type: docs
weight: 40
url: /php-java/embedded-font/
keywords: "Polices, polices embarquées, ajouter des polices, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Utiliser des polices embarquées dans une présentation PowerPoint"

---

**Les polices embarquées dans PowerPoint** sont utiles lorsque vous voulez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, alors vous avez encore plus de raisons d'embarquer votre police. Sinon (sans polices embarquées), les textes ou chiffres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) et leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec les polices embarquées dans les présentations PowerPoint.

## **Obtenir ou supprimer les polices embarquées d'une présentation**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) pour vous permettre d'obtenir (ou de découvrir) les polices embarquées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code PHP vous montre comment obtenir et supprimer les polices embarquées d'une présentation :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rends une diapositive contenant un cadre de texte qui utilise "FunSized" embarqué
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sauvegarde l'image sur le disque au format JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Obtient toutes les polices embarquées
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Trouve la police "Calibri"
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
    # Rends la présentation ; la police "Calibri" est remplacée par une existante
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sauvegarde l'image sur le disque au format JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Sauvegarde la présentation sans la police "Calibri" embarquée sur le disque
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des polices embarquées à une présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) et deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), vous pouvez sélectionner votre règle de préférence (d'embed) pour embarquer les polices dans une présentation. Ce code PHP vous montre comment embarquer et ajouter des polices à une présentation :

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
    # Sauvegarde la présentation sur le disque
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Compresser les polices embarquées**

Pour vous permettre de compresser les polices embarquées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Ce code PHP vous montre comment compresser les polices PowerPoint embarquées :

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