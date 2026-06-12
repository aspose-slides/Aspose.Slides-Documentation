---
title: Presentaties renderen met fallback-lettertypen in PHP
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/php-java/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Presentaties renderen met fallback-lettertypen in Aspose.Slides voor PHP via Java – houd tekst consistent over PPT, PPTX en ODP met stapsgewijze codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentaties weer te geven met behulp van fallback-lettertype‑regels. Dit artikel laat zien hoe u een collectie van fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst aan de `FontsManager::setFontFallBackRulesCollection`‑methode.

Zodra de collectie van fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens handelingen zoals opslaan, renderen en het converteren van de presentatie. Het voorbeeld laat zien hoe de geconfigureerde regels te gebruiken bij het renderen van een miniatuur van een dia en het opslaan ervan als PNG‑afbeelding.

## **Slide weergeven met fallback‑lettertype‑regels**

Het volgende voorbeeld omvat deze stappen:

1. [maak collectie van fallback‑lettertype‑regels](/slides/nl/php-java/create-fallback-fonts-collection/).
1. [Verwijderen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) een fallback‑lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
1. Stel de regels‑collectie in op [getFontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑methode.
1. Met de [Presentation.save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#save-java.lang.String-int-)‑methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback‑lettertype‑regels‑collectie is ingesteld op [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager), worden deze regels toegepast tijdens elke bewerking op de presentatie: opslaan, renderen, converteren, enzovoort.

```php
  # Maak een nieuw exemplaar van een regelsverzameling
  $rulesList = new FontFallBackRulesCollection();
  # Maak een aantal regels
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Proberen om fallback-lettertype "Tahoma" uit de geladen regels te verwijderen
    $fallBackRule->remove("Tahoma");
    # En de regels bijwerken voor het opgegeven bereik
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Ook kunnen we bestaande regels uit de lijst verwijderen
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Een voorbereide regelslijst toewijzen voor gebruik
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Miniatuur renderen met behulp van de geïnitialiseerde regelsverzameling en opslaan als JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # De afbeelding opslaan op schijf in JPEG-formaat
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
[Lees meer over hoe u PPT en PPTX naar JPG kunt converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}