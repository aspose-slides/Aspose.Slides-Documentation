---
title: Skapa miniatyrbilder av presentationsformer i PHP
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/php-java/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formåtergivning
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för PHP via Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är en bildspel. Dessa bildspel kan visas genom att öppna presentationsfilen med Microsoft PowerPoint. Ibland kan utvecklare behöva visa bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildspelsformerna. Hur du använder den här funktionen beskrivs i den här artikeln.
Den här artikeln förklarar hur man genererar miniatyrbilder av bildspel på olika sätt:

- Generera en miniatyrbild av en form i ett bildspel.
- Generera en miniatyrbild av en form för ett bildspelsform med användardefinierade dimensioner.
- Generera en miniatyrbild av en form inom gränserna för formens utseende.

## **Generera en miniatyrbild av en form från ett bildspel**

För att generera en miniatyrbild av en form från ett valfritt bildspel med Aspose.Slides för PHP via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till ett bildspel med dess ID eller index.
1. [Hämta miniatyrbilden för formen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) för det refererade bildspelet i standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en miniatyrbild av en form från ett bildspel:

```php
  # Instansiera en Presentation-klass som representerar presentationsfilen
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Skapa en bild i full skala
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Spara bilden till disk i PNG-format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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

## **Generera en miniatyrbild med användardefinierad skalningsfaktor**

För att generera formens miniatyrbild av ett bildspel med Aspose.Slides för PHP via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till ett bildspel med dess ID eller index.
1. [Hämta miniatyrbilden för formen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) för det refererade bildspelet med användardefinierade dimensioner.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en miniatyrbild av en form baserat på en definierad skalningsfaktor:

```php
  # Instansiera en Presentation-klass som representerar presentationsfilen
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Skapa en bild i full skala
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Spara bilden till disk i PNG-format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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

## **Skapa en miniatyrbild av formens utseende baserat på gränser**

Denna metod för att skapa miniatyrbilder av former låter utvecklare generera en miniatyrbild inom gränserna för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade miniatyrbilden av formen begränsas av bildspelsgränserna. För att generera en miniatyrbild av ett bildspelsform inom dess utseendes gräns, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till ett bildspel med dess ID eller index.
1. Hämta miniatyrbilden för det refererade bildspelet med formens gränser som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod är baserad på stegen ovan:

```php
  # Instansiera en Presentation-klass som representerar presentationsfilen
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Skapa en bild i full skala
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Spara bilden till disk i PNG-format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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

## **FAQ**

**Vilka bildformat kan användas när man sparar miniatyrbilder av former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/), och andra. Former kan även [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape- och Appearance-gränser när en miniatyrbild renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/php-java/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyrbild?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/)) kan sparas som en miniatyrbild eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrbilder för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/php-java/custom-font/) (eller [konfigurera typsnitts­ersättningar](/slides/sv/php-java/font-substitution/)) för att undvika oönskade reservtypsnitt och textomflyttning.