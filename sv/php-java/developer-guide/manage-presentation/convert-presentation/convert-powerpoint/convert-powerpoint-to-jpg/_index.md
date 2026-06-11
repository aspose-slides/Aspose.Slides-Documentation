---
title: Konvertera PPT och PPTX till JPG i PHP
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/php-java/convert-powerpoint-to-jpg/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till JPG
- presentation till JPG
- bild till JPG
- PPT till JPG
- PPTX till JPG
- spara PowerPoint som JPG
- spara presentation som JPG
- spara bild som JPG
- spara PPT som JPG
- spara PPTX som JPG
- exportera PPT till JPG
- exportera PPTX till JPG
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX) bilder till högkvalitativa JPG-bilder i PHP med Aspose.Slides för PHP med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder hjälper till med att dela bilder, optimera prestanda och bädda in innehåll i webbplatser eller applikationer. Aspose.Slides låter dig omvandla PPTX-, PPT- och ODP-filer till JPEG-bilder av hög kvalitet. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyr för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller demonstrera presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera PowerPoint PPT/PPTX till JPG**

1. Skapa en instans av typen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta bildobjektet av typen [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/) från samlingen [Presentation::getSlides()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#getSlides--).
3. Skapa miniatyren för varje bild och konvertera den sedan till JPG. Metoden [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) används för att hämta en miniatyr av en bild. Metoden [getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) måste anropas från den önskade bilden av typen [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/), där skalan för den resulterande miniatyren skickas in i metoden.
4. När du har fått bildminiatyren, anropa metoden [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) från miniatyrobjektet. Skicka det resulterande filnamnet och bildformatet till den.

{{% alert color="primary" %}}
**Note**: Konvertering från PPT/PPTX till JPG skiljer sig från konvertering till andra typer i Aspose.Slides API. För andra typer använder du vanligen metoden [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/save/), men här behöver du metoden [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Skapar en bild i full skala
      $slideImage = $sld->getImage(1.0, 1.0);
      # Sparar bilden till disk i JPEG-format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konvertera PowerPoint PPT/PPTX till JPG med anpassade dimensioner**

För att ändra dimensionen på den resulterande miniatyren och JPG-bilden kan du ange *ScaleX*- och *ScaleY*-värdena genom att skicka dem till metoderna [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage):
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definierar dimensioner
    $desiredX = 1200;
    $desiredY = 800;
    # Hämtar skalade värden för X och Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Skapar en bild i full skala
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Sparar bilden till disk i JPEG-format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rendera kommentarer när du sparar bilder som bilder**

Aspose.Slides för PHP via Java erbjuder en funktion som gör att du kan rendera kommentarer i en presentations bilder när du konverterar dessa bilder till bildfiler. Den här PHP-koden demonstrerar operationen:
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose tillhandahåller en [GRATIS Collage-webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du sammanfoga [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare.

Med samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/php-java/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingens noggrannhet kan dock variera något jämfört med PowerPoint, särskilt när du använder anpassade eller saknade teckensnitt.

**Finns det några begränsningar för antalet bilder som kan bearbetas?**

Aspose.Slides själv inför inga strikta begränsningar för antalet bilder du kan bearbeta. Du kan dock stöta på minnesfel när du arbetar med stora presentationer eller högupplösta bilder.

## **Se även**

Se andra alternativ för att konvertera PPT/PPTX till bild, till exempel:
- [PPT/PPTX till SVG-konvertering](/slides/sv/php-java/render-a-slide-as-an-svg-image/).