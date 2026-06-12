---
title: Beheer presentatie‑BLOB's op Android voor efficiënt geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Beheer BLOB‑gegevens in Aspose.Slides voor Android via Java om PowerPoint‑ en OpenDocument‑bestandsbewerkingen te stroomlijnen voor efficiënte presentatie‑verwerking."
---
## **Overzicht**

Aspose.Slides biedt BLOB-gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugengebruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel toont hoe u BLOB-gebaseerde verwerking kunt gebruiken om grote media toe te voegen aan een presentatie, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is doorgaans een groot object (foto, presentatie, document of media) dat in binair formaat is opgeslagen.

Aspose.Slides voor Android via Java stelt u in staat om BLOB's voor objecten te gebruiken op een manier die het geheugengebruik vermindert wanneer er met grote bestanden wordt gewerkt.

{{% alert title="Info" color="info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream resulteert in het kopiëren van de inhoud van de presentatie en veroorzaakt een traag laden. Daarom raden we, wanneer u een grote presentatie wilt laden, sterk aan om het pad naar het presentatiebestand te gebruiken en niet de stream.
{{% /alert %}}

## **BLOB gebruiken om geheugengebruik te verminderen**

### **Een groot bestand via BLOB aan een presentatie toevoegen**

[Aspose.Slides](/slides/nl/androidjava/) voor Java stelt u in staat om grote bestanden (in dit geval een groot videobestand) via een BLOB-proces toe te voegen om het geheugengebruik te verminderen.

Deze Java-code laat zien hoe u een groot videobestand via het BLOB-proces aan een presentatie kunt toevoegen:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Maakt een nieuwe presentatie waaraan de video wordt toegevoegd
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Laten we de video aan de presentatie toevoegen - we kozen voor het KeepLocked‑gedrag omdat we
        //niet van plan om het "veryLargeVideo.avi" bestand te benaderen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Slaat de presentatie op. Terwijl een grote presentatie wordt gegenereerd, blijft het geheugengebruik
        // blijft laag gedurende de levenscyclus van het pres-object 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Een groot bestand via BLOB uit een presentatie exporteren**
Aspose.Slides voor Android via Java stelt u in staat om grote bestanden (in dit geval een audio- of videobestand) via een BLOB-proces uit presentaties te exporteren. U kunt bijvoorbeeld een groot mediabestand uit een presentatie moeten halen, maar wilt niet dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB-proces te exporteren, houdt u het geheugengebruik laag.

Deze Java-code demonstreert de beschreven bewerking:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Vergrendelt het bronbestand en laadt het NIET in het geheugen
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Maak de instantie van Presentation, vergrendel het bestand "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Laten we elke video naar een bestand opslaan. Om hoog geheugenverbruik te voorkomen, hebben we een buffer nodig die wordt gebruikt
    // om de gegevens van de video‑stream van de presentatie over te dragen naar een stream voor een nieuw aangemaakt videobestand.
    byte[] buffer = new byte[8 * 1024];

    // Itereert door de video's
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opent de video‑stream van de presentatie. Let op, we hebben er bewust voor gekozen om geen eigenschappen te benaderen
        // zoals video.BinaryData – omdat deze eigenschap een byte‑array retourneert die de volledige video bevat, waardoor
        // bytes in het geheugen worden geladen. We gebruiken video.GetStream, dat een Stream teruggeeft – en vereist NIET
        //  dat we de volledige video in het geheugen laden.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
    // Indien nodig kunt u dezelfde stappen toepassen voor audiobestanden. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Een afbeelding als BLOB aan een presentatie toevoegen**
Met methoden van de interface [**IImageCollection**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) en de klasse [**ImageCollection** ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ImageCollection) kunt u een grote afbeelding als stream toevoegen zodat deze als BLOB wordt behandeld.

Deze Java-code laat zien hoe u een grote afbeelding via het BLOB-proces kunt toevoegen:
```java
String pathToLargeImage = "large_image.jpg";

// maakt een nieuwe presentatie waaraan de afbeelding wordt toegevoegd.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Laten we de afbeelding aan de presentatie toevoegen - we kiezen KeepLocked‑gedrag omdat we
		// NIET van plan zijn om het "largeImage.png" bestand te benaderen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Slaat de presentatie op. Terwijl een grote presentatie wordt gegenereerd, blijft het geheugengebruik
		// laag gedurende de levenscyclus van het pres‑object
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Geheugen en grote presentaties**

Normaal gesproken hebben computers veel tijdelijk geheugen nodig om een grote presentatie te laden. Alle inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie is geladen) wordt niet meer gebruikt.

Stel een grote PowerPoint‑presentatie (large.pptx) voor die een video van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt beschreven in deze Java-code:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen.

### **Een grote presentatie als BLOB laden**
Via een proces met een BLOB kunt u een grote presentatie laden met weinig geheugen. Deze Java-code beschrijft de implementatie waarbij het BLOB-proces wordt gebruikt om een groot presentatiebestand (large.pptx) te laden:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **De map voor tijdelijke bestanden wijzigen**
Wanneer het BLOB-proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de opslaginstellingen wijzigen met `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Wanneer u `TempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken.
{{% /alert %}}

### **Presentatie‑objecten vrijgeven om geheugen vrij te maken**
Zorg er bij het verwerken van grote presentaties voor dat de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het gebruikte geheugen wordt vrijgemaakt. Roep `dispose()` aan nadat u klaar bent met de presentatie om onbeheerde bronnen vrij te geven.
```java
Presentation presentation = new Presentation("large.pptx");

// ...verwerk de presentatie...
presentation.save("large.pdf", SaveFormat.Pdf);

// Geef bronnen expliciet vrij.
presentation.dispose();
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden beschouwd als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het gehele presentatiebestand is ook onderhevig aan BLOB‑verwerking bij het laden of opslaan. Deze objecten worden beheerd door BLOB‑beleidsregels die u in staat stellen het geheugengebruik te regelen en, wanneer nodig, naar tijdelijke bestanden uit te schuiven.

**Waar kan ik de BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) in combinatie met [BlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/blobmanagementoptions/). Daar stelt u de in‑memory‑limiet voor BLOB in, staat u tijdelijke bestanden toe of niet, kiest u de hoofdmap voor tijdelijke bestanden en selecteert u het gedrag voor bronvergrendeling.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe balanceer ik snelheid versus geheugen?**

Ja. BLOB in het geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; het verlagen van de geheugengrens verschuift meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard tegen de prijs van extra I/O. Gebruik de methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) om de juiste balans te vinden voor uw werklast en omgeving.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijvoorbeeld gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en het gebruik van bronvergrendeling kan het piek‑RAM‑gebruik aanzienlijk verminderen en de verwerking stabiliseren voor zeer grote presentaties.

**Kan ik BLOB‑beleidsregels gebruiken bij het laden vanuit streams in plaats van schijfbestanden?**

Ja. dezelfde regels zijn van toepassing op streams: de presentatie‑instantie kan de invoer‑stream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, waardoor het geheugengebruik voorspelbaar blijft tijdens de verwerking.