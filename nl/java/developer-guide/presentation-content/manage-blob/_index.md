---
title: Beheer Presentatie BLOB's in Java voor Efficiënt Geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Beheer BLOB-gegevens in Aspose.Slides voor Java om PowerPoint- en OpenDocument-bestandbewerkingen te stroomlijnen voor een efficiënt beheer van presentaties."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking kunt gebruiken om grote media aan een presentatie toe te voegen, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden tijdens de verwerking kunnen worden gebruikt en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot item (foto, presentatie, document of media) dat in binaire formaten wordt opgeslagen. 

Aspose.Slides for Java stelt u in staat BLOB's te gebruiken voor objecten op een manier die het geheugenverbruik vermindert wanneer grote bestanden betrokken zijn. 

{{% alert title="Info" color="info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream resulteert in het kopiëren van de presentatiewaarde en veroorzaakt een trage lading. Daarom raden we u bij het laden van een grote presentatie sterk aan om het bestandspad van de presentatie te gebruiken in plaats van de stream.
{{% /alert %}}

## **BLOB gebruiken om het geheugenverbruik te verminderen**

### **Een groot bestand via BLOB aan een presentatie toevoegen**

[Aspose.Slides](/slides/nl/java/) for Java stelt u in staat grote bestanden (in dit geval een groot videobestand) via een proces met BLOB's toe te voegen om het geheugenverbruik te verminderen. 

Deze Java-code laat zien hoe u een groot videobestand via het BLOB‑proces aan een presentatie kunt toevoegen:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Maak een nieuwe presentatie waaraan de video wordt toegevoegd
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Laten we de video aan de presentatie toevoegen - we kozen het KeepLocked‑gedrag omdat we
        // niet van plan zijn het bestand "veryLargeVideo.avi" te benaderen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Slaat de presentatie op. Terwijl een grote presentatie wordt uitgevoerd, blijft het geheugengebruik
        // laag gedurende de levensduur van het pres‑object 
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

Aspose.Slides for Java stelt u in staat grote bestanden (in dit geval een audio‑ of videobestand) via een proces met BLOB's uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk een groot mediabestand uit een presentatie halen, maar wilt het bestand niet in het geheugen van uw computer laden. Door het bestand via het BLOB‑proces te exporteren, houdt u het geheugenverbruik laag. 

Deze Java‑code demonstreert de beschreven bewerking:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Vergrendelt het bronbestand en laadt het NIET in het geheugen
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Maak een instantie van Presentation, vergrendel het bestand "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Laten we elke video opslaan naar een bestand. Om hoog geheugengebruik te voorkomen, hebben we een buffer nodig die zal worden gebruikt
    // om de gegevens van de videostream van de presentatie over te dragen naar een stream voor een nieuw aangemaakt videobestand.
    byte[] buffer = new byte[8 * 1024];

    // Loopt door de video's
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opent de videostream van de presentatie. Let op, we hebben opzettelijk vermeden eigenschappen te benaderen
        // zoals video.BinaryData - omdat deze eigenschap een byte‑array retourneert die de volledige video bevat, wat vervolgens
        // ervoor zorgt dat bytes in het geheugen worden geladen. We gebruiken video.GetStream, dat een Stream retourneert - en NIET
        //  vereist dat we de volledige video in het geheugen laden.
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

Met methoden van de interface [**IImageCollection**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) en de klasse [**ImageCollection**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ImageCollection) kunt u een grote afbeelding als stream toevoegen zodat deze als een BLOB wordt behandeld. 

Deze Java‑code laat zien hoe u een grote afbeelding via het BLOB‑proces kunt toevoegen:

```java
String pathToLargeImage = "large_image.jpg";

// maakt een nieuwe presentatie waaraan de afbeelding wordt toegevoegd.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Laten we de afbeelding aan de presentatie toevoegen - we kiezen het KeepLocked‑gedrag omdat we
		// NIET van plan zijn het bestand "largeImage.png" te benaderen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Slaat de presentatie op. Terwijl een grote presentatie wordt uitgevoerd, blijft het geheugengebruik
		// laag gedurende de levensduur van het pres‑object
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

Doorgaans hebben computers veel tijdelijk geheugen nodig om een grote presentatie te laden. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie werd geladen) wordt niet meer gebruikt. 

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een video van 1,5 GB bevat. De standaardmethode om de presentatie te laden staat beschreven in deze Java‑code:

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

Via een proces met een BLOB kunt u een grote presentatie laden met weinig geheugen. Deze Java‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentatiedocument (large.pptx) te laden:

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

Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de opslaginstellingen wijzigen met `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Wanneer u `TempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken. 
{{% /alert %}}

### **Presentatieobjecten vrijgeven om geheugen vrij te maken**

Bij het verwerken van grote presentaties dient u ervoor te zorgen dat de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het gebruikte geheugen wordt vrijgemaakt. Roep `dispose()` aan nadat u klaar bent met de presentatie om onbeheerste resources vrij te geven.

```java
Presentation presentation = new Presentation("large.pptx");

// ...verwerk de presentatie...
presentation.save("large.pdf", SaveFormat.Pdf);

// Maak de bronnen expliciet vrij.
presentation.dispose();
```

## **Veelgestelde vragen**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het volledige presentatiebestand valt ook onder BLOB‑verwerking bij het laden of opslaan. Deze objecten worden beheerst door BLOB‑beleid dat u in staat stelt het geheugengebruik te beheren en, indien nodig, naar tijdelijke bestanden uit te schrijven.

**Waar configureer ik BLOB‑verwerkingsregels tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) met [BlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/blobmanagementoptions/). Daar stelt u de in‑memory‑limiet voor BLOB in, staat u tijdelijke bestanden toe of niet, kiest u de basismap voor tijdelijke bestanden en selecteert u het gedrag van bronvergrendeling.

**Hebben BLOB‑instellingen invloed op de prestaties, en hoe balanseer ik snelheid versus geheugen?**

Ja. Het in‑memory houden van BLOB’s maximaliseert de snelheid maar verhoogt het RAM‑verbruik; het verlagen van de geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) om de juiste balans voor uw werklast en omgeving te vinden.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijvoorbeeld gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en het gebruiken van bronvergrendeling kan het piek‑RAM‑gebruik aanzienlijk verminderen en de verwerking van zeer grote presentaties stabiliseren.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van disk‑bestanden?**

Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream beheersen en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, waardoor het geheugengebruik voorspelbaar blijft tijdens de verwerking.