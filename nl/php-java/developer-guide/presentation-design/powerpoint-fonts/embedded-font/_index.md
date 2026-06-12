---
title: "Lettertypen insluiten in presentaties met PHP"
linktitle: "Lettertype insluiten"
type: docs
weight: 40
url: /nl/php-java/embedded-font/
keywords:
  - "lettertype toevoegen"
  - "lettertype insluiten"
  - "lettertype insluiting"
  - "ingesloten lettertype ophalen"
  - "ingesloten lettertype toevoegen"
  - "ingesloten lettertype verwijderen"
  - "ingesloten lettertype comprimeren"
  - "PowerPoint"
  - "OpenDocument"
  - "presentatie"
  - "PHP"
  - "Aspose.Slides"
description: "Insluiten van TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java, waardoor nauwkeurige weergave op alle platformen gegarandeerd is."
---
## **Inleiding**

**Ingesloten lettertypen in PowerPoint** zijn handig wanneer u wilt dat uw presentatie er correct uitziet wanneer deze op elk systeem of apparaat wordt geopend. Als u een lettertype van een derde partij of een niet‑standaard lettertype hebt gebruikt omdat u creatief bent geweest met uw werk, dan hebt u nog meer redenen om uw lettertype in te sluiten. Anders (zonder ingesloten lettertypen) kunnen de teksten of cijfers op uw dia’s, de lay‑out, opmaak, enz. veranderen of omgezet worden in verwarrende rechthoeken.

De [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager) klasse, [FontData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontdata/) klasse en [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/) klasse bevatten het grootste deel van de methoden die u nodig hebt om te werken met ingesloten lettertypen in PowerPoint‑presentaties.

## **Ingesloten lettertypen ophalen en verwijderen**

Aspose.Slides biedt de [getEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) methode (beschikbaar via de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager) klasse) om u de ingesloten lettertypen in een presentatie te laten ophalen (of te achterhalen). Om lettertypen te verwijderen wordt de [removeEmbeddedFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) methode (beschikbaar via dezelfde klasse) gebruikt.

Deze PHP‑code laat zien hoe u ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```php
  # Instantieert een Presentation‑object dat een presentatiedossier vertegenwoordigt
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderen van een dia met een tekstframe dat het ingesloten "FunSized"-lettertype gebruikt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sla de afbeelding op schijf in JPEG‑formaat
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Haalt alle ingesloten lettertypen op
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Zoekt het lettertype "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Verwijdert het lettertype "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderen van de presentatie; lettertype "Calibri" wordt vervangen door een bestaand lettertype
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sla de afbeelding op schijf in JPEG‑formaat
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Slaat de presentatie zonder ingesloten "Calibri"-lettertype op schijf
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ingesloten lettertypen toevoegen**

Met behulp van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedfontcharacters/) klasse en twee overloads van de [addEmbeddedFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) methode kunt u de gewenste (insluit‑)regel kiezen om de lettertypen in een presentatie in te sluiten. Deze PHP‑code laat zien hoe u lettertypen in een presentatie kunt insluiten en toevoegen:

```php
  # Laadt de presentatie
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
    # Slaat de presentatie op schijf
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ingesloten lettertypen comprimeren**

Om u in staat te stellen de ingesloten lettertypen in een presentatie te comprimeren en de bestandsgrootte te verkleinen, biedt Aspose.Slides de [compressEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#compressEmbeddedFonts) methode (beschikbaar via de [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/) klasse).

Deze PHP‑code laat zien hoe u ingesloten PowerPoint‑lettertypen kunt comprimeren:

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

## **Veelgestelde vragen**

**Hoe kan ik zien dat een specifiek lettertype in de presentatie nog steeds wordt vervangen tijdens het renderen, ondanks het insluiten?**

Bekijk de [substitutie‑informatie](/slides/nl/php-java/font-substitution/) in de font‑manager en de [fallback/substitutieregels](/slides/nl/php-java/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt een fallback gebruikt.

**Is het de moeite waard om "systeem"-lettertypen zoals Arial/Calibri in te sluiten?**

Meestal niet - ze zijn bijna altijd beschikbaar. Maar voor volledige draagbaarheid in "dunne" omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeembreek lettertypen het risico op onverwachte substituties wegnemen.