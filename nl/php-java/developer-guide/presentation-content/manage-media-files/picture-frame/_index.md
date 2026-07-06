---
title: Beheer afbeeldingsframes in presentaties met PHP
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/php-java/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff eigenschap
- afbeeldingsframe opmaak
- afbeeldingsframe eigenschappen
- relatieve schaal
- afbeeldingseffect
- aspectratio
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Voeg afbeeldingsframes toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Introductie**

Een afbeeldingframe is een vorm die een afbeelding bevat – het is als een foto in een lijst.

U kunt een afbeelding aan een dia toevoegen via een afbeeldingframe. Op deze manier formatteert u de afbeelding door het afbeeldingframe te formatteren.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters — [JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt) — die gebruikers in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingframe**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Haal via zijn index een referentie naar een dia op. 
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.
4. Specificeer de breedte en hoogte van de afbeelding.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) op basis van de breedte en hoogte van de afbeelding via de `addPictureFrame`‑methode die wordt blootgesteld door het vorm‑object dat hoort bij de refererende dia.
6. Voeg het afbeeldingframe (dat de afbeelding bevat) toe aan de dia.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe u een afbeeldingframe maakt:

```php
  # Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Instantieert de Image-klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Schrijft het PPTX-bestand naar de schijf
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Afbeeldingsframes stellen u in staat snel dia’s te maken op basis van afbeeldingen. Wanneer u een afbeeldingframe combineert met de opslaan‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. U wilt wellicht deze pagina’s raadplegen: converteer [image to JPG](https://products.aspose.com/slides/nl/php-java/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Maak een afbeeldingframe met relatieve schaal**

Door de relatieve schaal van een afbeelding aan te passen, kunt u een complexer afbeeldingframe maken. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Haal via zijn index een referentie naar een dia op. 
3. Voeg een afbeelding toe aan de afbeeldingcollectie van de presentatie.
4. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.
5. Specificeer de relatieve breedte en hoogte van de afbeelding in het afbeeldingframe.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe u een afbeeldingframe met relatieve schaal maakt:

```php
  # Instantieert de Presentation-klasse die de PPTX voorstelt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Instantieert de Image-klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Stelt de relatieve schaal van breedte en hoogte in
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Schrijft het PPTX-bestand naar de schijf
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rasterafbeeldingen extraheren uit afbeeldingframes**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/)‑objecten en opslaan in PNG, JPG en andere formaten. Het onderstaande code‑voorbeeld toont hoe u een afbeelding uit het document “sample.pptx” kunt extraheren en opslaan in PNG‑formaat.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **SVG‑afbeeldingen extraheren uit afbeeldingframes**

Wanneer een presentatie SVG‑graphics bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/)‑vormen zijn geplaatst, laat Aspose.Slides for PHP via Java u de originele vector‑afbeeldingen met volledige getrouwheid ophalen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingframe kunt extraheren:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Transparantie van een afbeelding ophalen**

Aspose.Slides maakt het mogelijk de transparantie‑effecten op een afbeelding op te halen. Deze PHP‑code demonstreert de bewerking:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides maakt het mogelijk de helderheid‑ en contrast‑effecten op een afbeelding op te halen. De [Luminance](https://reference.aspose.com/slides/nl/php-java/aspose.slides/luminance/)‑klasse vertegenwoordigt dit afbeeldings‑transformatie‑effect.

Deze PHP‑code laat zien hoe u de helderheid‑ en contrastinstellingen van een afbeeldingframe ophaalt:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Afbeeldingsframe‑opmaak**

Aspose.Slides biedt veel opmaakopties die op een afbeeldingframe kunnen worden toegepast. Met die opties kunt u een afbeeldingframe aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Haal via zijn index een referentie naar een dia op. 
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.
4. Specificeer de breedte en hoogte van de afbeelding.
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/)‑methode die wordt blootgesteld door het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑object dat hoort bij de refererende dia.
6. Voeg het afbeeldingframe (dat de afbeelding bevat) toe aan de dia.
7. Stel de lijnkleur van het afbeeldingframe in.
8. Stel de lijndikte van het afbeeldingframe in.
9. Roteer het afbeeldingframe door een positieve of negatieve waarde op te geven.
   * Een positieve waarde roteert de afbeelding met de klok mee. 
   * Een negatieve waarde roteert de afbeelding tegen de klok in.
10. Voeg het afbeeldingframe (dat de afbeelding bevat) opnieuw toe aan de dia.
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat het opmaakproces van een afbeeldingframe zien:

```php
  # Instantieert de Presentation-klasse die de PPTX voorstelt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Instantieert de Image-klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Voegt een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Past enige opmaak toe op PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Schrijft het PPTX-bestand naar de schijf
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt [samensmelten] of foto‑roosters wilt [maken](https://products.aspose.app/slides/nl/collage/photo-grid), kunt u deze dienst gebruiken. 

{{% /alert %}}

## **Een afbeelding als koppeling toevoegen**

Om grote presentaties te voorkomen, kunt u afbeeldingen (of video's) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze PHP‑code toont hoe u een afbeelding en een video in een placeholder kunt toevoegen:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Afbeeldingen bijsnijden**

Deze PHP‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```php
  $pres = new Presentation();
  # Creëert een nieuw afbeeldingobject
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt een PictureFrame toe aan een dia
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Bijsnijdt de afbeelding (percentagewaarden)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Slaat het resultaat op
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bijsnijden van gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding die in een frame zit wilt verwijderen, kunt u de methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden niet nodig is.

Deze PHP‑code demonstreert de bewerking:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Haalt het PictureFrame op van de eerste dia
    $picFrame = $slide->getShapes()->get_Item(0);
    # Verwijdert bijgesneden gebieden van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Slaat het resultaat op
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) voegt de bijgesneden afbeelding toe aan de afbeeldingcollectie van de presentatie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/), kan deze instelling de presentatiegrootte verkleinen. Anders neemt het aantal afbeeldingen in de uiteindelijke presentatie toe.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de methode [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) . Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan op dezelfde manier als de PowerPoint‑functie **Afbeeldingsopmaak → Afbeeldingen comprimeren → Resolutie**.

De volgende PHP‑voorbeelden tonen hoe u een afbeelding in een presentatie kunt comprimeren door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Controleer het resultaat van de compressie.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Of door direct een aangepaste DPI‑waarde te gebruiken:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Comprimeer de afbeelding tot 150 DPI (webresolutie), waarbij bijgesneden gebieden worden verwijderd.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode zet de afbeelding om naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen eveneens worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verminderd afhankelijk van de resolutie, op dezelfde manier als PowerPoint bij hoge‑resolutie JPEG's.

{{% /alert %}}

## **Verhoudingsvergrendeling**

Als u wilt dat een vorm die een afbeelding bevat zijn verhoudingen behoudt, zelfs nadat u de afmetingen van de afbeelding verandert, kunt u de methode [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) gebruiken om de instelling *Verhoudingsvergrendeling* in te stellen.

Deze PHP‑code laat zien hoe u de verhoudingsvergrendeling van een vorm toepast:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # stel de vorm in om de aspectratio te behouden bij het schalen
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="OPMERKING" color="warning" %}} 

Deze instelling *Verhoudingsvergrendeling* behoudt alleen de verhoudingen van de vorm en niet van de afbeelding die erin zit.

{{% /alert %}}

## **De StretchOff‑eigenschap gebruiken**

Met de methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) en [setStretchOffsetBottom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) van de [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/)‑klasse kunt u een vulrechthoek opgeven.

Wanneer er rekwerk wordt gespecificeerd voor een afbeelding, wordt een bronrechthoek geschaald om te passen binnen de opgegeven vulrechthoek. Elke rand van de vulrechthoek wordt gedefinieerd door een percentage‑offset ten opzichte van de corresponderende rand van de begrenzings­box van de vorm. Een positief percentage geeft een inlage aan, een negatief percentage een uitsteeksel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Haal via zijn index een referentie naar een dia op.
3. Voeg een rechthoek `AutoShape` toe. 
4. Maak een afbeelding.
5. Stel het vultype van de vorm in.
6. Stel de afbeelding‑vulmodus van de vorm in.
7. Voeg een afbeelding toe om de vorm te vullen.
8. Specificeer afbeeldings‑offsets ten opzichte van de corresponderende rand van de begrenzings­box van de vorm.
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze PHP‑code demonstreert een proces waarbij de StretchOff‑eigenschap wordt gebruikt:

```php
  # Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Instantieert de ImageEx-klasse
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt een AutoShape toe ingesteld op rechthoek
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Stelt het vultype van de vorm in
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Stelt de afbeeldingvulmodus van de vorm in
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Stelt de afbeelding in om de vorm te vullen
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Specificeert de afbeeldingsoffsets ten opzichte van de corresponderende rand van de begrenzingsbox van de vorm
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Schrijft het PPTX-bestand naar de schijf
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor een afbeeldingframe?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeeldingsobject dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/). De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de slide‑ en afbeeldingconversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de PPTX‑grootte en -prestaties?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen koppelen helpt de presentatiegrootte te beperken, maar vereist dat de externe bestanden beschikbaar blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeeldingsobject vergrendelen tegen onbedoeld verplaatsen of schalen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/getpictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of schalen uit te schakelen). Het vergrendelingsmechanisme wordt ondersteund voor diverse vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/).

**Is de vector‑getrouwheid van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/php-java/convert-powerpoint-to-png/) kan het resultaat afhankelijk van de exportinstellingen gerasterd worden; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractiegedrag.