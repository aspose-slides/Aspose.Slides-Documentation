---
title: Hantera bildramar i presentationer med PHP
linktitle: Bildram
type: docs
weight: 10
url: /sv/php-java/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- lägg till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskära bild
- beskuret område
- StretchOff-egenskap
- bildramformatering
- bildramegenskaper
- relativ skala
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Effektivisera ditt arbetsflöde och förbättra bilddesign."
---
## **Introduktion**

En bildram är en form som innehåller en bild – den är som en bild i en ram. 

Du kan lägga till en bild på en bildspelssida via en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tips" color="primary" %}} 
Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som gör det möjligt för användare att snabbt skapa presentationer från bilder. 
{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildslides referens via dess index. 
3. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) baserad på bildens bredd och höjd via metoden `addPictureFrame` som exponeras av shape‑objektet som är associerat med den refererade sliden.
6. Lägg till en bildram (som innehåller bilden) på sliden.
7. Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första sliden
    $sld = $pres->getSlides()->get_Item(0);
    # Instansierar Image-klassen
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Lägger till en bildram med bildens motsvarande höjd och bredd
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Skriver PPTX-filen till disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in‑/ut‑operationer för att konvertera bilder från ett format till ett annat. Du kanske vill se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/php-java/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **Skapa en bildram med relativ skalning**

Genom att ändra en bilds relativa skalning kan du skapa en mer avancerad bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildslides referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansierar Presentation-klassen som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Hämtar den första sliden
    $sld = $pres->getSlides()->get_Item(0);
    # Instansierar Image-klassen
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Lägger till en bildram med bildens motsvarande höjd och bredd
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ställer in relativ skalning av bredd och höjd
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Skriver PPTX-filen till disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/)-objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur man extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

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

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/)-former låter Aspose.Slides för PHP via Java dig hämta de ursprungliga vektorbilderna med fullständig trohet. Genom att gå igenom bildens formsamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/), kontrollera om den underliggande [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) innehåller SVG‑innehåll, och sedan spara den bilden på disk eller i en ström i dess ursprungliga SVG‑format.

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

## **Hämta genomskinlighet för en bild**

Aspose.Slides låter dig hämta den transparenseffekt som har tillämpats på en bild. Detta PHP‑kodexempel demonstrerar operationen:

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

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med dessa alternativ kan du ändra en bildram så att den matchar specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildslides referens via dess index. 
3. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa ett `PictureFrame` baserat på bildens bredd och höjd via metoden [addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/) som exponeras av [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/)-objektet som är associerat med den refererade sliden.
6. Lägg till bildramen (som innehåller bilden) på sliden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ange ett positivt eller negativt värde.  
   * Ett positivt värde roterar bilden medurs.  
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på sliden.
11. Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansierar Presentation-klassen som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Hämtar den första sliden
    $sld = $pres->getSlides()->get_Item(0);
    # Instansierar Image-klassen
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Lägger till en bildram med bildens motsvarande höjd och bredd
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Tillämpar viss formatering på PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Skriver PPTX-filen till disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tips" color="primary" %}}
Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda denna tjänst. 
{{% /alert %}}

## **Lägg till en bild som länk**

För att undvika stora presentationsfiler kan du lägga till bilder (eller videor) via länkar istället för att bädda in filerna direkt i presentationerna. Detta PHP‑kodexempel visar hur du lägger till en bild och en video i en platshållare:

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

## **Beskär bilder**

Detta PHP‑kodexempel visar hur du beskär en befintlig bild på en slide:

```php
  $pres = new Presentation();
  # Skapar nytt bildobjekt
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
    # Lägger till en bildram på en bild
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Beskär bilden (procentvärden)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Sparar resultatet
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort beskurna områden i en bild**

Om du vill ta bort de beskurna områdena i en bild som finns i en ram kan du använda metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Denna metod returnerar den beskurna bilden eller originalbilden om beskärning inte är nödvändig.

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Hämtar PictureFrame från den första sliden
    $picFrame = $slide->getShapes()->get_Item(0);
    # Tar bort beskurna områden i PictureFrame-bilden och returnerar den beskurna bilden
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Sparar resultatet
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="OBS" color="warning" %}} 
Metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/), kan denna konfiguration minska presentationens storlek. Annars ökar antalet bilder i den färdiga presentationen.

Metoden konverterar WMF/EMF‑metafiler till raster‑PNG‑bild i beskärningsoperationen. 
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på samma sätt som PowerPoints **Picture Format -> Compress Pictures -> Resolution**‑funktion.

Följande PHP‑exempel demonstrerar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Kontrollera resultatet av komprimeringen.
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

Eller genom att ange ett eget DPI‑värde direkt:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimera bilden till 150 DPI (webbupplösning) och ta bort beskurna områden.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="OBS" color="warning" %}} 
Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurade regioner kan också tas bort för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG kommer komprimering inte att tillämpas. Dessutom bevaras JPEG‑kvaliteten eller minskar något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑filer.
{{% /alert %}}

## **Lås bildförhållandet**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrar bildens dimensioner kan du använda metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) för att sätta *Lock Aspect Ratio*-inställningen.

Detta PHP‑kodexempel visar hur du låser en forms bildförhållande:

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
    # Ange att formen ska bevara bildförhållandet vid storleksändring
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="OBS" color="warning" %}} 
Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande och inte den bild den innehåller.
{{% /alert %}}

## **Använd StretchOff‑egenskapen**

Genom att använda metoderna [setStretchOffsetLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) och [setStretchOffsetBottom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) från klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) kan du ange en fyllningsrektangel.

När en stretchning specificeras för en bild skalas en källrektangel för att passa den specificerade fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell förskjutning från motsvarande kant av formens omgivningsruta. En positiv procentsats anger en inneslutning medan en negativ procentsats anger en utskjutning.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-klassen.
2. Hämta en bildslides referens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllningsläge.
7. Lägg till en bild för att fylla formen.
8. Specificera bildförskjutningar från motsvarande kant av formens omgivningsruta.
9. Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första sliden
    $slide = $pres->getSlides()->get_Item(0);
    # Instansierar ImageEx-klassen
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Lägger till en AutoShape inställd på rektangel
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ställer in formens fyllningstyp
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Ställer in formens bildfyllningsläge
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Ställer in bilden för att fylla formen
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Anger bildens offset från motsvarande kant på formens omgivningsruta
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Skriver PPTX-filen till disk
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?**

Aspose.Slides stödjer både rasterbilder (PNG, JPEG, BMP, GIF, etc.) och vektorbilder (till exempel SVG) via bildobjektet som är tilldelat en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/). Listan över stödda format överlappar i allmänhet med funktionerna i slide‑ och bildkonverteringsmotorn.

**Hur påverkar det PPTX‑storlek och prestanda att lägga till dussintals stora bilder?**

Inbäddning av stora bilder ökar filstorlek och minnesanvändning; att länka bilder hjälper hålla presentationens storlek nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides erbjuder möjligheten att lägga till bilder via länk för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas/ändras i storlek?**

Använd [shape locks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/getpictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) (till exempel inaktivera flyttning eller ändring av storlek). Låsningsmekanismen stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/).

**Bevaras SVG‑vektorfidelitet vid export av en presentation till PDF/bilder?**

Aspose.Slides tillåter extraktion av en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) som den ursprungliga vektorn. Vid [export till PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/php-java/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; det faktum att den ursprungliga SVG‑filen lagras som en vektor bekräftas av extraktionsbeteendet.