---
title: Optimaliseer Afbeeldingsbeheer in Presentaties met PHP
linktitle: Beheer Afbeeldingen
type: docs
weight: 10
url: /nl/php-java/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor PHP via Java, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen vanuit een bestand, internet of andere locaties op dia's invoegen. Evenzo kun je met Aspose.Slides afbeeldingen toevoegen aan dia's in je presentaties via verschillende methoden. 

{{% alert  title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken vanuit afbeeldingen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als je een afbeelding wilt toevoegen als frame-object—vooral als je standaard opmaakopties wilt gebruiken om de grootte aan te passen, effecten toe te voegen, enzovoort—zie [Picture Frame](/slides/nl/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}
Je kunt invoer-/uitvoerbewerkingen met afbeeldingen en PowerPoint-presentaties manipuleren om een afbeelding van het ene formaat naar het andere te converteren. Zie deze pagina's: converteer [image to JPG](https://products.aspose.com/slides/nl/php-java/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-png/); converteer [PNG to JPG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-svg/); converteer [SVG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt één of meerdere afbeeldingen van je computer aan een dia in een presentatie toevoegen. Deze voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Afbeeldingen van het internet toevoegen aan dia's**

Als de afbeelding die je wilt toevoegen aan een dia niet op je computer beschikbaar is, kun je de afbeelding direct van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe je een afbeelding van het internet aan een dia toevoegt:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Afbeeldingen toevoegen aan slide masters**

Een slide master is de bovenste dia die informatie (thema, lay-out, enz.) over alle onderliggende dia's opslaat en beheert. Als je een afbeelding aan een slide master toevoegt, verschijnt die afbeelding op elke dia die onder die master valt. 

Deze Java-voorbeeldcode laat zien hoe je een afbeelding aan een slide master toevoegt:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Afbeeldingen toevoegen als dia-achtergronden**

Je kunt ervoor kiezen om een afbeelding te gebruiken als achtergrond voor een specifieke dia of meerdere dia's. In dat geval moet je bekijken hoe je [Set an Image as a Slide Background](/slides/nl/php-java/presentation-background/#set-an-image-as-a-slide-background) gebruikt. 

## **SVG toevoegen aan presentaties**
Je kunt elke afbeelding in een presentatie toevoegen of invoegen met de [addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/) methode die behoort tot de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/) klasse.

Om een afbeeldingsobject te maken op basis van een SVG‑afbeelding, kun je het volgende doen:

1. Maak een SvgImage object om het in ImageShapeCollection in te voegen
2. Maak een PPImage object van ISvgImage
3. Maak een PictureFrame object met de PPImage klasse

Deze voorbeeldcode laat zien hoe je de bovenstaande stappen implementeert om een SVG‑afbeelding aan een presentatie toe te voegen:
```php
  # Instantieer Presentation-klasse die PPTX-bestand voorstelt
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVG converteren naar een set vormen**
De SVG‑conversie van Aspose.Slides naar een set vormen werkt vergelijkbaar met de PowerPoint‑functionaliteit die wordt gebruikt om met SVG‑afbeeldingen te werken:

![PowerPoint Popup Menu](img_01_01.png)

De functionaliteit wordt geleverd door een van de overloads van de [addGroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addgroupshape/) methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/) klasse die een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) object als eerste argument neemt.

Deze voorbeeldcode laat zien hoe je de beschreven methode gebruikt om een SVG‑bestand te converteren naar een set vormen:

```php
  # Maak een nieuwe presentatie
  $presentation = new Presentation();
  try {
    # Lees de inhoud van het SVG-bestand
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Maak een SvgImage-object
    $svgImage = new SvgImage($svgContent);
    # Haal de dia-grootte op
    $slideSize = $presentation->getSlideSize()->getSize();
    # Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-grootte
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Sla de presentatie op in PPTX-formaat
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Afbeeldingen toevoegen als EMF aan dia's**
Aspose.Slides for PHP via Java stelt je in staat EMF‑afbeeldingen te genereren vanuit Excel‑bladen en de afbeeldingen als EMF toe te voegen aan dia's met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe je de beschreven taak uitvoert:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Sla het werkboek op naar stream
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Afbeeldingen vervangen in de Image Collection**

Aspose.Slides stelt je in staat afbeeldingen die in de Image Collection van een presentatie zijn opgeslagen (inclusief die gebruikt door dia‑vormen) te vervangen. Deze sectie toont verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) instantie, of een andere afbeelding die al in de collectie aanwezig is.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding met de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede benadering laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) object en vervang je de doelafbeelding met dat object.
5. In de derde benadering vervang je de doelafbeelding met een afbeelding die al bestaat in de Image Collection van de presentatie.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```php
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
$presentation = new Presentation("sample.pptx");
try {
    // De eerste manier.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // De tweede manier.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // De derde manier.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Sla de presentatie op naar een bestand.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Met de gratis Aspose [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig teksten animeren, GIF's maken vanuit teksten, enz. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bronpixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [picture](/slides/nl/php-java/picture-frame/) wordt geschaald op de dia en van eventuele compressie bij opslaan.

**Wat is de beste manier om hetzelfde logo op tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay-out en vervang het in de Image Collection van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen, waarna individuele delen bewerkbaar zijn met standaard vorm‑eigenschappen.

**Hoe kan ik één afbeelding instellen als achtergrond voor meerdere dia's tegelijk?**

[Assign the image as the background](/slides/nl/php-java/presentation-background/) op de master‑dia of de betreffende lay-out—alle dia's die die master/lay-out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat de presentatie "opblazen" in grootte door veel afbeeldingen?**

Herbruik één afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij opslaan, en houd veel gebruikte graphics bij voorkeur op de master.