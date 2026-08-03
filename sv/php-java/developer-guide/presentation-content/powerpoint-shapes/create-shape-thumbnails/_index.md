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
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för PHP via Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är en bild. Dessa bilder kan visas genom att öppna presentationsfilerna med Microsoft PowerPoint. Men ibland kan utvecklare behöva visa formernas bilder separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildformerna. Hur du använder den här funktionen beskrivs i den här artikeln.
Den här artikeln förklarar hur du genererar bildminiatyrer på olika sätt:

- Generera en formminiatyr inuti en bild.
- Generera en formminiatyr för en bildform med användardefinierade dimensioner.
- Generera en formminiatyr inom gränserna för en forms utseende.

## **Generera en formminiatyr från en bild**
För att generera en formminiatyr från en bild med Aspose.Slides för PHP via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till någon bild med dess ID eller index.
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) av den refererade bilden i standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempel kod visar hur du genererar en formminiatyr från en bild:

```php
  # Skapa en Presentation-klass som representerar presentationsfilen
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

## **Generera en miniatyr med användardefinierad skalningsfaktor**
För att generera formens miniatyr av en bild med Aspose.Slides för PHP via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till någon bild med dess ID eller index.
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) av den refererade bilden med användardefinierade dimensioner.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempel kod visar hur du genererar en formminiatyr baserat på en definierad skalningsfaktor:

```php
  # Skapa en Presentation-klass som representerar presentationsfilen
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

## **Skapa en gränsbunden formutseende-miniatyr**
Denna metod för att skapa miniatyrbilder av former låter utvecklare generera en miniatyr inom formen's utseendes gränser. Den tar hänsyn till alla formeffekter. Den genererade formminiatyren är begränsad av bildens gränser. För att generera en miniatyr av en bildform inom dess utseende, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till någon bild med dess ID eller index.
1. Hämta miniatyrbilden av den refererade bilden med formens gränser som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempel kod är baserad på stegen ovan:

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

## **Hämta den faktiska visuella gränsen för en form**

Ramégenskaperna för [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` och `Shape::getHeight()`—beskriver rektangeln som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axelriktad rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt-geometri och andra renderingeffect kan alla förändra det upptagna området.

Använd [Shape::getVisualBounds](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getVisualBounds) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar en [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) i bildkoordinater. Den returnerade rektangeln är inte beskuren till bilden, så dess koordinater kan vara negativa när innehållet sträcker sig utanför bildens ursprung.

Följande exempel hämtar och jämför ramen och den visuella gränsen:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Samma [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan användas för att justera närliggande former till dess vänstra, högra, övre eller nedre kant; reservera tillräckligt med utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar det fullständiga renderade resultatet.

Använd [Shape::getVisualBounds] när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [Shape::getImage] när du behöver rendera formen. Med [ShapeThumbnailBounds] anger `ShapeThumbnailBounds::Shape` bildens storlek utifrån formens gränser, inklusive konturinställningar, medan `ShapeThumbnailBounds::Appearance` anger storleken utifrån formens utseende och begränsar resultatet till bildens gränser. I kontrast returnerar `Shape::getVisualBounds` endast den beräknade rektangeln och beskär den inte till bilden.

## **FAQ**

**Vilka bildformat kan användas när man sparar formminiatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när man renderar en miniatyr?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/php-java/shape-effect/) (skuggor, glöd osv.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga teckensnitten](/slides/sv/php-java/custom-font/) (eller [konfigurera teckensnittsbyte](/slides/sv/php-java/font-substitution/)) för att undvika oönskade reservtypsnitt och textomslag.