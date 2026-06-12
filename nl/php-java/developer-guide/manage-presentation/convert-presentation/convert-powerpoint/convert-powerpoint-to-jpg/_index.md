---
title: Converteer PPT en PPTX naar JPG in PHP
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/php-java/convert-powerpoint-to-jpg/
keywords: 
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar JPG
- presentatie naar JPG
- dia naar JPG
- PPT naar JPG
- PPTX naar JPG
- PowerPoint opslaan als JPG
- presentatie opslaan als JPG
- dia opslaan als JPG
- PPT opslaan als JPG
- PPTX opslaan als JPG
- PPT exporteren naar JPG
- PPTX exporteren naar JPG
- PHP
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in PHP met Aspose.Slides for PHP met snelle, betrouwbare codevoorbeelden."
---
## **Inleiding**

Het converteren van PowerPoint- en OpenDocument‑presentaties naar JPG‑afbeeldingen helpt bij het delen van dia’s, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides stelt u in staat PPTX‑, PPT‑ en ODP‑bestanden om te zetten naar JPEG‑afbeeldingen van hoge kwaliteit. Deze gids legt verschillende converteermethoden uit.

Met deze functies is het eenvoudig om uw eigen presentatie‑viewer te implementeren en een miniatuur voor elke dia te maken. Dit kan handig zijn als u de dia’s wilt beschermen tegen kopiëren of de presentatie in alleen‑lezen‑modus wilt tonen. Aspose.Slides maakt het mogelijk de hele presentatie of een specifieke dia om te zetten naar afbeeldingsformaten.

## **PowerPoint PPT/PPTX naar JPG converteren**

Hieronder staan de stappen om PPT/PPTX naar JPG te converteren:

1. Maak een instantie van het type [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.  
2. Haal het dia‑object van het type [Dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) op uit de collectie [Presentation::getSlides()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#getSlides--) .  
3. Maak een miniatuur van elke dia en zet deze vervolgens om naar JPG. De methode [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) wordt gebruikt om een miniatuur van een dia te verkrijgen. De methode getImage moet worden aangeroepen vanaf de gewenste [Dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) en de schaalwaarden van de resulterende miniatuur worden als argumenten meegegeven.  
4. Nadat u de dia‑miniatuur hebt verkregen, roept u de **IImage::save(String formatName, int imageFormat)**‑methode aan vanuit het miniatuurobject. Geef de resulterende bestandsnaam en het afbeeldingsformaat door.  

{{% alert color="primary" %}}

**Opmerking**: De conversie van PPT/PPTX naar JPG verschilt van de conversie naar andere typen in de Aspose.Slides‑API. Voor andere typen gebruikt u doorgaans de methode [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/save/), maar hier moet u de **IImage::save(String formatName, int imageFormat)**‑methode inzetten.  

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Maakt een afbeelding op volledige schaal
      $slideImage = $sld->getImage(1.0, 1.0);
      # Slaat de afbeelding op schijf op in JPEG-formaat
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

## **PowerPoint PPT/PPTX naar JPG converteren met aangepaste afmetingen**
Om de afmeting van de resulterende miniatuur en JPG‑afbeelding aan te passen, kunt u de *ScaleX*- en *ScaleY*-waarden instellen door ze door te geven aan de methoden [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definieert afmetingen
    $desiredX = 1200;
    $desiredY = 800;
    # Haalt geschaalde waarden van X en Y op
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Maakt een afbeelding op volledige schaal
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Slaat de afbeelding op schijf op in JPEG-formaat
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

## **Reacties renderen bij het opslaan van dia's als afbeeldingen**
Aspose.Slides for PHP via Java biedt een functionaliteit waarmee u opmerkingen in de dia’s van een presentatie kunt weergeven wanneer u die dia’s converteert naar afbeeldingen. Deze PHP‑code demonstreert de werking:

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

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG afbeeldingen samenvoegen, [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort.  

Met dezelfde principes als in dit artikel beschreven, kunt u afbeeldingen van het ene formaat naar het andere converteren. Zie voor meer informatie de volgende pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/php-java/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-svg/); converteer [SVG naar PNG](https://products.aspose.com/slides/nl/php-java/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

**Ondersteunt deze methode batch‑conversie?**  

Ja, Aspose.Slides staat batch‑conversie van meerdere dia’s naar JPG toe in één enkele operatie.

**Worden SmartArt, diagrammen en andere complexe objecten ondersteund bij de conversie?**  

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, diagrammen, tabellen, vormen en meer. De weergave‑nauwkeurigheid kan echter enigszins afwijken van PowerPoint, vooral bij aangepaste of ontbrekende lettertypen.

**Zijn er beperkingen op het aantal dia’s dat verwerkt kan worden?**  

Aspose.Slides zelf legt geen strikte limieten op het aantal dia’s dat u kunt verwerken. Bij zeer grote presentaties of hoge resoluties kunt u echter een out‑of‑memory‑fout tegenkomen.

## **Zie ook**

Zie andere opties om PPT/PPTX naar afbeelding te converteren, bijvoorbeeld:

- [PPT/PPTX naar SVG conversie](/slides/nl/php-java/render-a-slide-as-an-svg-image/).