---
title: Rendre les présentations avec des polices de secours en PHP
linktitle: Rendre les présentations
type: docs
weight: 30
url: /fr/php-java/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Rendre les présentations avec des polices de secours dans Aspose.Slides pour PHP via Java – garder le texte cohérent entre PPT, PPTX et ODP avec des exemples de code étape par étape."
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de polices de secours](/slides/fr/php-java/create-fallback-fonts-collection/).
2. [Supprimer](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
3. Définissez la collection de règles à l'aide de la méthode [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--).
4. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation dans le même format, ou l'enregistrer dans un autre. Après que la collection de règles de polices de secours soit définie sur [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), ces règles sont appliquées lors de toutes les opérations sur la présentation : enregistrement, rendu, conversion, etc.
```php
  # Créer une nouvelle instance d'une collection de règles
  $rulesList = new FontFallBackRulesCollection();
  # créer un certain nombre de règles
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Tentative de suppression de la police FallBack "Tahoma" des règles chargées
    $fallBackRule->remove("Tahoma");
    # Et mise à jour des règles pour la plage spécifiée
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Nous pouvons également supprimer toutes les règles existantes de la liste
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Attribution d'une liste de règles préparée pour l'utilisation
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendu de la vignette en utilisant la collection de règles initialisée et enregistrement au format JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Enregistrer l'image sur le disque au format JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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


{{% alert color="primary" %}}
En savoir plus sur la façon de [Convertir PPT et PPTX en JPG avec PHP](/slides/fr/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}