---
title: Hantera bildramar i presentationer med PHP
linktitle: Bildram
type: docs
weight: 10
url: /sv/php-java/picture-frame/
keywords:
- bildram
- lägga till bildram
- skapa bildram
- lägga till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskära bild
- beskuret område
- StretchOff‑egenskap
- formatering av bildram
- egenskaper för bildram
- relativ skala
- bildeffekt
- aspektförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild—den är som en bild i en ram.  

Du kan lägga till en bild på en bildspelssida via en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tip" color="primary" %}} 
Aspose tillhandahåller gratiskonverterare—[JPEG to PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG to PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 
{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildspelsreferens via dess index. 
3. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) baserat på bildens bredd och höjd via `addPictureFrame`‑metoden som exponeras av form‑objektet som är associerat med den refererade bilden.
6. Lägg till en bildram (innehållande bilden) på bilden.
7. Skriv den modifierade presentationen som en PPTX‑fil.

Den här PHP‑koden visar hur du skapar en bildram:

```php
  # Skapar en instans av Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Skapar en instans av Image-klassen
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
Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in‑/utdata‑operationer för att konvertera bilder från ett format till ett annat. Du kan vilja se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/php-java/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Skapa en bildram med relativ skalning**

Genom att ändra en bilds relativa skalning kan du skapa en mer avancerad bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildspelsreferens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Skriv den modifierade presentationen som en PPTX‑fil.

Den här PHP‑koden visar hur du skapar en bildram med relativ skalning:

```php
  # Instansiera Presentation-klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Instansiera Image-klassen
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Lägg till bildram med bildens motsvarande höjd och bredd
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ställer in relativ skalning för bredd och höjd
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

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/)‑objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

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

När en presentation innehåller SVG‑grafik placerad i [PictureFrame]‑former låter Aspose.Slides för PHP via Java dig hämta de ursprungliga vektorbilderna med full integritet. Genom att gå igenom bildens form‑samling kan du identifiera varje [PictureFrame], kontrollera om den underliggande [PPImage] innehåller SVG‑innehåll, och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Följande kodexempel visar hur du extraherar en SVG‑bild från en bildram:

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

## **Hämta transparens för en bild**

Aspose.Slides låter dig hämta transparenseffekten som applicerats på en bild. Den här PHP‑koden demonstrerar operationen:

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

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrke‑ och kontrasteffekten som applicerats på en bild. Klassen [Luminance](https://reference.aspose.com/slides/sv/php-java/aspose.slides/luminance/) representerar denna bildtransformations‑effekt.

Den här PHP‑koden visar hur du får ljusstyrke‑ och kontrastinställningarna från en bildram:

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

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildspelsreferens via dess index. 
3. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa ett `PictureFrame` baserat på bildens bredd och höjd via [addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/)‑metoden som exponeras av [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/)‑objektet som är associerat med den refererade bilden.
6. Lägg till bildramen (innehållande bilden) på bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (innehållande bilden) på bilden.
11. Skriv den modifierade presentationen som en PPTX‑fil.

Den här PHP‑koden demonstrerar processen för formatering av bildram:

```php
  # Instansierar Presentation-klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Instansierar Image-klassen
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Lägger till bildram med bildens motsvarande höjd och bredd
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Applicerar viss formatering på PictureFrameEx
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

{{% alert title="Tip" color="primary" %}}
Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa gallerier från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 
{{% /alert %}}

## **Lägg till en bild som en länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar istället för att bädda in filerna direkt i presentationer. Den här PHP‑koden visar hur du lägger till en bild och video i en platshållare:

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

Den här PHP‑koden visar hur du beskär en befintlig bild på en bild:

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
    # Lägger till en PictureFrame på en bild
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

## **Ta bort beskurna områden i en bildram**

Om du vill ta bort de beskurna områdena av en bild som finns i en ram kan du använda metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Denna metod returnerar den beskurna bilden eller originalbilden om beskärning inte behövs.

Den här PHP‑koden demonstrerar operationen:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Hämtar PictureFrame från den första bilden
    $picFrame = $slide->getShapes()->get_Item(0);
    # Tar bort beskurna områden i PictureFrame‑bilden och returnerar den beskurna bilden
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Sparar resultatet
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) lägger till den beskurna bilden i presentationens bildsamling. Om bilden enbart används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/), kan denna inställning minska presentationsstorleken. Annars ökar antalet bilder i den resulterande presentationen.

Denna metod konverterar WMF/EMF‑metafiler till raster‑PNG‑bilder i beskärningsoperationen. 
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med metoden [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) . Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på samma sätt som PowerPoints **Picture Format -> Compress Pictures -> Resolution**‑funktion.

Följande PHP‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimera bilden med en målupplösning på 150 DPI (web-upplösning) och ta bort beskurna områden.
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

Eller genom att använda ett eget DPI‑värde direkt:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimera bilden till 150 DPI (web-upplösning), ta bort beskurna områden.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också tas bort för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG, tillämpas ingen kompression. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑bilder. 
{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner, kan du använda metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) för att sätta *Lock Aspect Ratio*-inställningen.

Den här PHP‑koden visar hur du låser en forms bildförhållande:

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
    # sätt formen så att den bevarar bildförhållandet vid storleksändring
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Denna *Lock Aspect Ratio*-inställning bevarar bara bildförhållandet för formen och inte bilden den innehåller. 
{{% /alert %}}

## **Använd egenskapen StretchOff**

Genom att använda metoderna [setStretchOffsetLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) och [setStretchOffsetBottom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) från klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) kan du specificera en fyllningsrektangel.

När stretchning anges för en bild skalas en källrektangel för att passa den specificerade fyllningsrektangeln. varje kant av fyllningsrektangeln definieras av en procentuell förskjutning från motsvarande kant av formens omgränsningsruta. En positiv procentsats anger en infogning medan en negativ procentsats anger en utstickning.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en bildspelsreferens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllningsläge.
7. Lägg till en bild för att fylla formen.
8. Ange bildens förskjutningar från motsvarande kant av formens omgränsningsruta
9. Skriv den modifierade presentationen som en PPTX‑fil.

Den här PHP‑koden demonstrerar en process där StretchOff‑egenskapen används:

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
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
    # Sätter bilden för att fylla formen
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Anger bildens förskjutningar från motsvarande kant av formens omkadningsruta
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

Aspose.Slides stödjer både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/). Listan över stödda format överlappar generellt med funktionerna i bildspels- och bildkonverteringsmotorn.

**Hur påverkar det PPTX‑storlek och prestanda att lägga till dussintals stora bilder?**

Att bädda in stora bilder ökar filstorlek och minnesförbrukning; att länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides erbjuder möjlighet att lägga till bilder via länkar för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas eller skalas?**

Använd [shape locks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/getpictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller skalning). Låsningsmekanismen stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/).

**Bevaras SVG‑vektorkvaliteten vid export av en presentation till PDF/bilder?**

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/php-java/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; det faktum att den ursprungliga SVG‑filen sparas som en vektor bekräftas av extraheringsbeteendet.