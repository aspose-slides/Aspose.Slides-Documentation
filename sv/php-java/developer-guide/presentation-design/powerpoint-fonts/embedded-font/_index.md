---
title: Bädda in teckensnitt i presentationer med PHP
linktitle: Inbäddning av teckensnitt
type: docs
weight: 40
url: /sv/php-java/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- teckensnittsinbäddning
- hämta inbäddat teckensnitt
- lägg till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Bädda in TrueType-teckensnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java, vilket säkerställer exakt rendering på alla plattformar."
---
## **Introduktion**

**Inbäddade teckensnitt i PowerPoint** är användbara när du vill att din presentation ska visas korrekt när den öppnas på valfritt system eller enhet. Om du använde ett tredjeparts- eller icke‑standardteckensnitt eftersom du var kreativ med ditt arbete, har du ännu fler skäl att bädda in ditt teckensnitt. Annars (utan inbäddade teckensnitt) kan texter eller siffror på dina bildspel, layouten, formateringen osv. förändras eller förvandlas till förvirrande rektanglar. 

Klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager), klassen [FontData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontdata/) och klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) innehåller de flesta metoderna du behöver för att arbeta med inbäddade teckensnitt i PowerPoint‑presentationer.

## **Hämta och ta bort inbäddade teckensnitt**

Aspose.Slides tillhandahåller metoden [getEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (exponerad av klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager)) för att låta dig hämta (eller ta reda på) vilka teckensnitt som är inbäddade i en presentation. För att ta bort teckensnitt används metoden [removeEmbeddedFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (exponerad av samma klass).

Denna PHP‑kod visar hur du hämtar och tar bort inbäddade teckensnitt från en presentation:

```php
  # Instansierar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderar en bild som innehåller en textram som använder det inbäddade "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sparar bilden till disk i JPEG-format
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Hämtar alla inbäddade teckensnitt
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Hittar teckensnittet "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Tar bort teckensnittet "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderar presentationen; teckensnittet "Calibri" ersätts med ett befintligt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Sparar bilden till disk i JPEG-format
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Sparar presentationen utan inbäddat "Calibri"-teckensnitt till disk
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till inbäddade teckensnitt**

Genom att använda klassen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedfontcharacters/) och två överlagringar av metoden [addEmbeddedFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) kan du välja din föredragna (inbäddnings)regel för att bädda in teckensnitt i en presentation. Denna PHP‑kod visar hur du bäddar in och lägger till teckensnitt i en presentation:

```php
  # Laddar presentationen
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
    # Sparar presentationen till disk
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Komprimera inbäddade teckensnitt**

För att låta dig komprimera de teckensnitt som är inbäddade i en presentation och minska dess filstorlek, tillhandahåller Aspose.Slides metoden [compressEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#compressEmbeddedFonts) (exponerad av klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/)).

Denna PHP‑kod visar hur du komprimerar inbäddade PowerPoint‑teckensnitt:

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

**Hur kan jag se att ett specifikt teckensnitt i presentationen fortfarande kommer att ersättas vid rendering trots inbäddning?**

Kontrollera [substitution information](/slides/sv/php-java/font-substitution/) i teckensnittshanteraren och [fallback/substitution rules](/slides/sv/php-java/fallback-font/): om teckensnittet är otillgängligt eller begränsat, kommer ett reservteckensnitt att användas.

**Är det värt att bädda in ”system”‑teckensnitt som Arial/Calibri?**

Vanligtvis nej—de är nästan alltid tillgängliga. Men för full portabilitet i ”tunna” miljöer (Docker, en Linux‑server utan förinstallerade teckensnitt) kan inbäddning av systemteckensnitt eliminera risken för oväntade ersättningar.