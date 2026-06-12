---
title: "Beheer presentaties BLOB's in JavaScript voor efficiënt geheugengebruik"
linktitle: "Beheer BLOB"
type: docs
weight: 10
url: /nl/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer BLOB-gegevens in JavaScript met Aspose.Slides voor Node.js om PowerPoint- en OpenDocument-bestandsbewerkingen te stroomlijnen voor efficiënt presentatiebeheer."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking kunt gebruiken om grote media toe te voegen aan een presentatie, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map waarin ze worden opgeslagen kunt wijzigen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot item (foto, presentatie, document of media) dat bewaard wordt in binaire formaten. 

Aspose.Slides for Node.js via Java stelt u in staat BLOB's te gebruiken voor objecten op een manier die het geheugenverbruik vermindert wanneer er grote bestanden bij betrokken zijn.

{{% alert title="Info" color="info" %}}

Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream resulteert in het kopiëren van de inhoud van de presentatie en veroorzaakt een trage laadtijd. Daarom raden we sterk aan, wanneer u een grote presentatie wilt laden, het bestandspad van de presentatie te gebruiken en niet de stream.

{{% /alert %}}

## **BLOB gebruiken om geheugenverbruik te verminderen**

### **Groot bestand via BLOB toevoegen aan een presentatie**

[Aspose.Slides](/slides/nl/nodejs-java/) for Node.js via Java stelt u in staat grote bestanden (in dit geval een groot videobestand) via een BLOB‑proces toe te voegen om het geheugenverbruik te verminderen.

Deze JavaScript toont hoe u een groot videobestand via het BLOB‑proces aan een presentatie kunt toevoegen:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Maakt een nieuwe presentatie aan waaraan de video zal worden toegevoegd
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Laten we de video aan de presentatie toevoegen - we kozen voor het KeepLocked‑gedrag omdat we
        // niet van plan zijn het bestand "veryLargeVideo.avi" te benaderen.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Slaat de presentatie op. Terwijl een grote presentatie wordt uitgevoerd, blijft het geheugengebruik
        // laag gedurende de levensduur van het pres‑object.
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Groot bestand exporteren via BLOB uit een presentatie**

Aspose.Slides for Node.js via Java stelt u in staat grote bestanden (in dit geval een audio‑ of videobestand) via een BLOB‑proces uit presentaties te exporteren. Bijvoorbeeld, u wilt misschien een groot mediabestand uit een presentatie halen, maar wilt niet dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren, houdt u het geheugenverbruik laag.

Deze code in JavaScript demonstreert de beschreven bewerking:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Vergrendelt het bronbestand en laadt het NIET in het geheugen
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// maak de instantie van Presentation aan, vergrendel het bestand "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Laten we elke video naar een bestand opslaan. Om hoog geheugengebruik te voorkomen, hebben we een buffer nodig die zal worden gebruikt
    // om de gegevens van de videostream van de presentatie over te brengen naar een stream voor een nieuw aangemaakt videobestand.
    var buffer = new byte[8 * 1024];
    // Doorloopt de video's
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opent de videostream van de presentatie. Merk op dat we opzettelijk het benaderen van eigenschappen hebben vermeden
        // zoals video.BinaryData - omdat deze eigenschap een byte-array retourneert die een volledige video bevat, die dan
        // bytes in het geheugen laadt. We gebruiken video.GetStream, dat een Stream teruggeeft - en dit
        // niet vereist dat we de hele video in het geheugen laden.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Het geheugengebruik blijft laag, ongeacht de grootte van de video of presentatie.
    }
    // Indien nodig kun je dezelfde stappen toepassen voor audiobestanden.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Afbeelding toevoegen als BLOB in een presentatie**

Met methoden uit de [**ImageCollection**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) klasse en [**ImageCollection** ](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) klasse kunt u een grote afbeelding als een stream toevoegen zodat deze als een BLOB wordt behandeld.

Deze JavaScript‑code toont hoe u een grote afbeelding via het BLOB‑proces kunt toevoegen:

```javascript
var pathToLargeImage = "large_image.jpg";
// maakt een nieuwe presentatie aan waaraan de afbeelding wordt toegevoegd.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Laten we de afbeelding aan de presentatie toevoegen - we kiezen voor het KeepLocked‑gedrag omdat we
        // NIET van plan zijn het bestand "largeImage.png" te benaderen.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Slaat de presentatie op. Terwijl een grote presentatie wordt gegenereerd, blijft het geheugengebruik
        // laag gedurende de levensduur van het pres‑object.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Geheugen en grote presentaties**

Typisch vereisen computers veel tijdelijk geheugen om een grote presentatie te laden. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie werd geladen) wordt niet meer gebruikt. 

Stel u een grote PowerPoint‑presentatie (large.pptx) voor die een video van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt beschreven in deze JavaScript‑code:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen. 

### **Grote presentatie laden als BLOB**

Via een BLOB‑proces kunt u een grote presentatie laden met weinig geheugen. Deze JavaScript‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentatiedossier (large.pptx) te laden:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Map voor tijdelijke bestanden wijzigen**

Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de opslaginstellingen wijzigen met `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Wanneer u `setTempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken. 

{{% /alert %}}

### **Presentatie‑objecten vrijgeven om geheugen vrij te maken**

Zorg er bij het verwerken van grote presentaties voor dat de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het geheugen dat het bezette wordt vrijgemaakt. Roep `dispose()` aan nadat u de presentatie hebt afgerond om niet‑beheerde resources vrij te geven.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het volledige presentatiebestand wordt ook via BLOB‑verwerking behandeld bij het laden of opslaan. Deze objecten worden bestuurd door BLOB‑beleid dat u in staat stelt het geheugenverbruik te beheren en, indien nodig, naar tijdelijke bestanden uit te sjabloneren.

**Waar kan ik de BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) samen met [BlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/blobmanagementoptions/). Hier stelt u de in‑memory‑limiet voor BLOB in, staat u tijdelijke bestanden toe of niet, kiest u de hoofdmap voor tijdelijke bestanden en selecteert u het gedrag van bronvergrendeling.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe balanseer ik snelheid versus geheugen?**

Ja. BLOB in het geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; het verlagen van de geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) om de juiste balans te vinden voor uw werklast en omgeving.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijvoorbeeld meerdere gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en het gebruik van bronvergrendeling kan het piek‑RAM‑gebruik aanzienlijk verlagen en de verwerking stabiliseren voor zeer grote decks.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van schijfbestanden?**

Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream bezit en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, waardoor het geheugenverbruik voorspelbaar blijft tijdens de verwerking.