---
title: Beheer presentatie BLOB's in PHP voor efficiënt geheugenverbruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/php-java/manage-blob/
keywords:
- groot object
- groot item
- groot bestand
- BLOB toevoegen
- BLOB exporteren
- afbeelding toevoegen als BLOB
- geheugen verminderen
- geheugengebruik
- grote presentatie
- tijdelijk bestand
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: Beheer BLOB-gegevens in Aspose.Slides voor PHP via Java om PowerPoint- en OpenDocument-bestandsbewerkingen te stroomlijnen voor een efficiënte presentatieafhandeling.
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking kunt gebruiken om grote media aan een presentatie toe te voegen, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot item (foto, presentatie, document of media) dat in binaire formaten wordt opgeslagen.  

Aspose.Slides voor PHP via Java maakt het mogelijk om BLOB’s te gebruiken voor objecten op een manier die het geheugenverbruik vermindert wanneer er grote bestanden bij betrokken zijn.

{{% alert title="Info" color="info" %}}
Om bepaalde beperkingen bij het omgaan met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream resulteert in het kopiëren van de presentatiewaarde en veroorzaakt een trage laadtijd. Daarom raden wij, wanneer u een grote presentatie wilt laden, sterk aan om het pad van het presentiebestand te gebruiken en niet de stream.
{{% /alert %}}

## **Gebruik BLOB om geheugenverbruik te verminderen**

### **Voeg een groot bestand via BLOB toe aan een presentatie**

[Aspose.Slides](/slides/nl/php-java/) voor Java maakt het mogelijk om grote bestanden (in dit geval een groot videobestand) via een BLOB‑proces toe te voegen om het geheugenverbruik te verminderen.

Deze Java‑code toont hoe u een groot videobestand via het BLOB‑proces aan een presentatie kunt toevoegen:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Maakt een nieuwe presentatie waaraan de video wordt toegevoegd
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Laten we de video aan de presentatie toevoegen - we hebben gekozen voor het KeepLocked-gedrag omdat we
      # niet van plan zijn om het bestand "veryLargeVideo.avi" te benaderen.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, blijft het geheugenverbruik
      # laag gedurende de levensduur van het pres-object
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

### **Exporteer een groot bestand via BLOB uit een presentatie**
Aspose.Slides voor PHP via Java maakt het mogelijk om grote bestanden (in dit geval een audio‑ of videobestand) via een BLOB‑proces uit presentaties te exporteren. Bijvoorbeeld, u wilt een groot mediabestand uit een presentatie extraheren zonder dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren houdt u het geheugenverbruik laag.

Deze code demonstreert de beschreven bewerking:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Vergrendelt het bronbestand en laadt het NIET in het geheugen
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Maak een instantie van Presentation, vergrendel het bestand "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Laten we elke video opslaan naar een bestand. Om hoog geheugenverbruik te voorkomen, hebben we een buffer nodig die zal worden gebruikt
    # om de gegevens van de video‑stream van de presentatie over te brengen naar een stream voor een nieuw aangemaakt videobestand.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itereert door de video's
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Opent de video‑stream van de presentatie. Let op, we hebben er bewust voor gekozen om geen eigenschappen te benaderen
      # zoals video.BinaryData - omdat deze eigenschap een byte‑array retourneert die een volledige video bevat, waardoor
      # bytes in het geheugen worden geladen. We gebruiken video.GetStream, die een Stream teruggeeft - en LAADT NIET
      # van ons vereist om de volledige video in het geheugen te laden.
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
      # Het geheugenverbruik blijft laag, ongeacht de grootte van de video of de presentatie.
    }
    # Indien nodig kun je dezelfde stappen toepassen voor audiobestanden.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Voeg een afbeelding als BLOB toe aan een presentatie**
Met methoden uit de [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/)‑klasse kunt u een grote afbeelding als stream toevoegen zodat deze wordt behandeld als een BLOB.

Deze PHP‑code laat zien hoe u een grote afbeelding via het BLOB‑proces kunt toevoegen:

```php
  $pathToLargeImage = "large_image.jpg";
  # maakt een nieuwe presentatie waaraan de afbeelding zal worden toegevoegd.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Laten we de afbeelding aan de presentatie toevoegen - we kiezen voor KeepLocked-gedrag omdat we
      # NIET van plan zijn om het bestand "largeImage.png" te benaderen.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, blijft het geheugenverbruik
      # laag gedurende de levensduur van het pres‑object
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

## **Geheugen en grote presentaties**

Typisch gezien hebben computers veel tijdelijk geheugen nodig om een grote presentatie te laden. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie werd geladen) wordt niet meer gebruikt.  

Stel u een grote PowerPoint‑presentatie (large.pptx) voor die een video‑bestand van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt beschreven in deze PHP‑code:

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

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen.  

### **Laad een grote presentatie als BLOB**

Via het BLOB‑proces kunt u een grote presentatie laden terwijl u weinig geheugen gebruikt. Deze PHP‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentiebestand (large.pptx) te laden:

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

### **Verander de map voor tijdelijke bestanden**

Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de opslaginstellingen wijzigen met `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Wanneer u `setTempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden in op te slaan. U moet de map handmatig aanmaken.  
{{% /alert %}}

### **Disposeer presentatie‑objecten om geheugen vrij te geven**

Bij het verwerken van grote presentaties moet u ervoor zorgen dat de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie correct wordt disposed zodat het gebruikte geheugen wordt vrijgegeven. Roep `dispose()` aan nadat u klaar bent met de presentatie om onbeheerde bronnen vrij te maken.

```php
$presentation = new Presentation("large.pptx");

# ...verwerk de presentatie...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Expliciet bronnen vrijgeven.
$presentation->dispose();
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**  
Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het volledige presentiebestand wordt ook via BLOB verwerkt wanneer het wordt geladen of opgeslagen. Deze objecten worden beheerd door BLOB‑beleid dat u in staat stelt het geheugenverbruik te regelen en naar tijdelijke bestanden te spillen wanneer dat nodig is.

**Waar kan ik BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**  
Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/) met [BlobManagementOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/blobmanagementoptions/). Daar stelt u de in‑memory‑limiet voor BLOB in, staat u tijdelijke bestanden toe of niet, kiest u de root‑pad voor tijdelijke bestanden en selecteert u het gedrag voor bron‑locking.

**Beïnvloeden BLOB‑instellingen de prestaties en hoe balanceer ik snelheid versus geheugen?**  
Ja. BLOB in geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; een lagere geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/)‑methode om de juiste balans voor uw workload en omgeving te vinden.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijv. gigabytes)?**  
Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario’s: het inschakelen van tijdelijke bestanden en het gebruiken van bron‑locking kan het piek‑RAM‑verbruik aanzienlijk verlagen en de verwerking van zeer grote decks stabiliseren.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van schijf‑bestanden?**  
Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream bezitten en locken (afhankelijk van de gekozen lock‑modus), en tijdelijke bestanden worden gebruikt wanneer dit is toegestaan, waardoor het geheugenverbruik voorspelbaar blijft tijdens de verwerking.