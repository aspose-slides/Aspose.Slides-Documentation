---
title: Optimera bildhantering i presentationer med PHP
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/php-java/image/
keywords:
- lägg till bild
- lägg till foto
- lägg till bitmap
- ersätt bild
- ersätt foto
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för PHP via Java, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra platser på bilder. På samma sätt låter Aspose.Slides dig lägga till bilder på bilder i dina presentationer genom olika procedurer. 

{{% alert  title="Tip" color="primary" %}} 
Aspose tillhandahåller gratisomvandlare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som gör det möjligt att snabbt skapa presentationer från bilder. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Om du vill lägga till en bild som ett ramobjekt—särskilt om du planerar att använda standardformateringsalternativ på den för att ändra storlek, lägga till effekter osv—se [Bildram](/slides/sv/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Du kan manipulera in/ut‑operationer som involverar bilder och PowerPoint-presentationer för att konvertera en bild från ett format till ett annat. Se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/php-java/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides stödjer operationer med bilder i dessa populära format: JPEG, PNG, GIF och andra. 

## **Lägg till lokalt lagrade bilder på bilder**

Du kan lägga till en eller flera bilder från din dator på en bild i en presentation. Den här exempel­koden visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte finns på din dator kan du lägga till bilden direkt från webben. 

Den här exempel­koden visar hur du lägger till en bild från webben på en bild :

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

## **Lägg till bilder på bildmaster**

En bildmaster är den översta bilden som lagrar och styr information (tema, layout osv.) om alla bilder under den. Så när du lägger till en bild på en bildmaster visas den bilden på varje bild under den bildmastern. 

Den här Java‑exempelkoden visar hur du lägger till en bild på en bildmaster:

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

## **Lägg till bilder som bakgrund på bilder**

Du kan besluta att använda en bild som bakgrund för en specifik bild eller flera bilder. I så fall måste du se hur du [sätter en bild som bakgrund på en bild](/slides/sv/php-java/presentation-background/#set-an-image-as-a-slide-background). 

## **Lägg till SVG i presentationer**
Du kan lägga till eller infoga vilken bild som helst i en presentation genom att använda metoden [addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/) som tillhör klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/). 

För att skapa ett bildobjekt baserat på en SVG‑bild kan du göra så här:

1. Skapa ett SvgImage‑objekt för att infoga det i ImageShapeCollection
2. Skapa ett PPImage‑objekt från ISvgImage
3. Skapa ett PictureFrame‑objekt med hjälp av PPImage‑klassen

Den här exempel­koden visar hur du implementerar stegen ovan för att lägga till en SVG‑bild i en presentation:
```php
  # Instansiera Presentation-klassen som representerar PPTX-filen
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

## **Konvertera SVG till en uppsättning former**
Aspose.Slides konvertering av SVG till en uppsättning former är liknande den funktion i PowerPoint som används för att arbeta med SVG‑bilder:

![PowerPoint Popup Menu](img_01_01.png)

Funktionaliteten tillhandahölls av en av overload‑versionerna av metoden [addGroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addgroupshape/) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/) som tar ett [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/)‑objekt som första argument.

Den här exempel­koden visar hur du använder den beskrivna metoden för att konvertera en SVG‑fil till en uppsättning former:

```php
  # Skapa ny presentation
  $presentation = new Presentation();
  try {
    # Läs SVG-filens innehåll
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

    # Skapa SvgImage-objekt
    $svgImage = new SvgImage($svgContent);
    # Hämta bildens storlek
    $slideSize = $presentation->getSlideSize()->getSize();
    # Konvertera SVG-bild till grupp av former och skala den till bildens storlek
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Spara presentation i PPTX-format
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Lägg till bilder som EMF på bilder**
Aspose.Slides för PHP via Java låter dig generera EMF‑bilder från Excel‑ark och lägga till bilderna som EMF på bilder med Aspose.Cells. 

Den här exempel­koden visar hur du utför den beskrivna uppgiften:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Spara arbetsboken till ström
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling (inklusive de som används av bildformer). Detta avsnitt visar flera tillvägagångssätt för att uppdatera bilder i samlingen. API:et erbjuder enkla metoder för att ersätta en bild med råa byte‑data, en [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)-instans eller en annan bild som redan finns i samlingen.

1. Läs in presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt målbilden med den nya bilden med hjälp av byte‑arrayen.
4. I det andra tillvägagångssättet, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)-objekt och ersätt målbilden med det objektet.
5. I det tredje tillvägagångssättet, ersätt målbilden med en bild som redan finns i presentationens bildsamling.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation("sample.pptx");
try {
    // Det första sättet.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Det andra sättet.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Det tredje sättet.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Spara presentationen till en fil.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Genom att använda Aspose GRATIS [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverteraren kan du enkelt animera texter, skapa GIF‑ar från texter osv. 
{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildens upplösning sin kvalitet efter infogning?**

Ja. Källpixlarna bevaras, men slutresultatet beror på hur [bilden](/slides/sv/php-java/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder samtidigt?**

Placera logotypen på bildmastern eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag sätta en bild som bakgrund för flera bilder samtidigt?**

[Tilldela bilden som bakgrund](/slides/sv/php-java/presentation-background/) på bildmastern eller den relevanta layouten—alla bilder som använder den master/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att presentationen växer kraftigt i storlek på grund av många bilder?**

Återanvänd en enda bildresurs i stället för dubletter, välj rimliga upplösningar, tillämpa kompression vid sparande och behåll återkommande grafik på mastern där det är lämpligt.