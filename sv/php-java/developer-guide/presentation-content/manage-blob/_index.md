---
title: Hantera presentations‑BLOB:er i PHP för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/php-java/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägg till BLOB
- exportera BLOB
- lägg till bild som BLOB
- minska minne
- minnesförbrukning
- stor presentation
- temporär fil
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera BLOB‑data i Aspose.Slides för PHP via Java för att effektivisera PowerPoint- och OpenDocument‑filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB-baserad hantering av stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när du arbetar med stora bilder, ljud, video och presentationsfiler.

Denna artikel visar hur du använder BLOB-baserad bearbetning för att lägga till stora media i en presentation, exportera stora media från en presentation och ladda stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort objekt (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides for PHP via Java låter dig använda BLOB:ar för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

{{% alert title="Info" color="info" %}}
För att kringgå vissa begränsningar vid interaktion med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att ladda en stor presentation via dess ström resulterar i en kopiering av presentationens innehåll och kan leda till långsam laddning. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du avser att ladda en stor presentation.
{{% /alert %}}

## **Använd BLOB för att minska minnesförbrukningen**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/php-java/) för Java låter dig lägga till stora filer (i det här fallet en stor videofil) via en process som involverar BLOB:ar för att minska minnesförbrukningen.

Den här Java-exemplet visar hur du lägger till en stor videofil via BLOB-processen i en presentation:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Skapar en ny presentation som videon kommer att läggas till
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Låt oss lägga till videon i presentationen - vi valde beteendet KeepLocked eftersom vi
      # inte avser att komma åt filen "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Sparar presentationen. Medan en stor presentation skrivs ut, förblir minnesförbrukningen
      # låg under hela presentationens livscykel
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Exportera en stor fil via BLOB från en presentation**

Aspose.Slides for PHP via Java låter dig exportera stora filer (i det här fallet en ljud- eller videofil) via en process som involverar BLOB:ar från presentationer. Till exempel kan du behöva extrahera en stor mediFil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB-processen håller du minnesförbrukningen låg.

Denna kod visar den beskrivna operationen:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Låser källfilen och laddar INTE in den i minnet
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # skapa Presentation's instance, lås filen "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som kommer att användas
    # för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itererar genom videorna
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Öppnar presentations‑videoströmmen. Observera att vi avsiktligt undvek att åtkomma egenskaper
      # som video.BinaryData - eftersom den egenskapen returnerar en byte‑array som innehåller hela videon, vilket i sin tur
      # får byte att laddas in i minnet. Vi använder video.GetStream, som returnerar Stream - och laddar INTE
      # in hela videon i minnet.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Minnesanvändningen förblir låg oavsett videons eller presentationens storlek.
    }
    # Vid behov kan du tillämpa samma steg för ljudfiler.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Lägg till en bild som BLOB i en presentation**

Med metoder från klassen [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) kan du lägga till en stor bild som en ström för att behandla den som ett BLOB.

Denna PHP-kod visar hur du lägger till en stor bild via BLOB-processen:

```php
  $pathToLargeImage = "large_image.jpg";
  # skapar en ny presentation som bilden kommer att läggas till.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Låt oss lägga till bilden i presentationen - vi väljer KeepLocked‑beteende eftersom vi
      # INTE avser att komma åt filen "largeImage.png" filen.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Sparar presentationen. Medan en stor presentation skrivs ut, är minnesförbrukningen
      # låg under hela presentationens livscykel
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Minne och stora presentationer**

Vanligtvis kräver inläsning av en stor presentation mycket temporärt minne. Allt presentationens innehåll laddas in i minnet och filen (från vilken presentationen laddades) slutar användas.

Tänk på en stor PowerPoint-presentation (large.pptx) som innehåller en 1,5 GB videofil. Den vanliga metoden för att ladda presentationen beskrivs i denna PHP-kod:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Men denna metod förbrukar omkring 1,6 GB temporärt minne.

### **Läs in en stor presentation som BLOB**

Genom en process som involverar ett BLOB kan du ladda en stor presentation med lite minne. Denna PHP-kod beskriver implementeringen där BLOB-processen används för att läsa in en stor presentationsfil (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ändra mappen för temporära filer**

När BLOB-processen används skapar din dator temporära filer i standardmappen för temporära filer. Om du vill att de temporära filerna ska sparas i en annan mapp kan du ändra lagringsinställningarna med `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
När du använder `setTempFilesRootPath` skapar Aspose.Slides inte automatiskt en mapp för att lagra temporära filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Frigör presentationsobjekt för att släppa minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instansen avlastas korrekt så att det minne den upptog frigörs. Anropa `dispose()` efter att du har avslutat användningen av presentationen för att frigöra oorganiserade resurser.

```php
$presentation = new Presentation("large.pptx");

# ...bearbeta presentationen...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Frigör resurser explicit.
$presentation->dispose();
```

## **FAQ**

**Vilken data i en Aspose.Slides-presentation behandlas som BLOB och styrs av BLOB-alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. Hela presentationsfilen omfattas också av BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och spilla över till temporära filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler när en presentation läses in?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/) tillsammans med [BlobManagementOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOB, tillåter eller förbjuder temporära filer, väljer rotmappen för temporära filer och väljer beteende för källlåsning.

**Påverkar BLOB‑inställningarna prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till temporära filer, vilket minskar RAM‑användningen men medför extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) för att hitta rätt balans för ditt arbetsflöde och din miljö.

**Hjälper BLOB‑alternativen när man öppnar extremt stora presentationer (t.ex. flera gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera temporära filer och använda källlåsning kan avsevärt minska topp‑RAM‑användningen och stabilisera bearbetningen av mycket stora presentationer.

**Kan jag använda BLOB‑policyer när jag läser in från strömmar istället för diskfiler?**

Ja. samma regler gäller för strömmar: presentationsinstansen kan äga och låsa inmatningsströmmen (beroende på valt låsläge), och temporära filer används när de är tillåtna, vilket gör minnesanvändningen förutsägbar under bearbetning.