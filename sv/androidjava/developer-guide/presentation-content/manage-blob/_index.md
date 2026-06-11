---
title: Hantera presentationens BLOBs på Android för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/androidjava/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägga till BLOB
- exportera BLOB
- lägga till bild som BLOB
- minska minne
- minnesförbrukning
- stor presentation
- temporär fil
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera BLOB‑data i Aspose.Slides för Android via Java för att effektivisera PowerPoint‑ och OpenDocument‑filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides erbjuder BLOB-baserad hantering av stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när du arbetar med stora bilder, ljud, video och presentationsfiler.

Denna artikel visar hur du använder BLOB-baserad bearbetning för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort objekt (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides för Android via Java låter dig använda BLOBs för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

{{% alert title="Info" color="info" %}}
För att kringgå vissa begränsningar när du arbetar med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att läsa in en stor presentation via dess ström resulterar i kopiering av presentationens innehåll och orsakar långsam inläsning. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du avser att läsa in en stor presentation.
{{% /alert %}}

## **Använd BLOB för att minska minnesförbrukning**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/androidjava/) för Java låter dig lägga till stora filer (i detta fall en stor videofil) via en process som involverar BLOBs för att minska minnesförbrukningen.

Denna Java‑kod visar hur du lägger till en stor videofil via BLOB‑processen i en presentation:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Skapar en ny presentation som videon ska läggas till
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Låt oss lägga till videon i presentationen - vi valde KeepLocked‑beteendet eftersom vi
        // avser inte att komma åt filen "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Sparar presentationen. Medan en stor presentation exporteras, förblir minnesförbrukningen
        // förblir låg under hela presentationens livscykel 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportera en stor fil via BLOB från en presentation**

Aspose.Slides för Android via Java låter dig exportera stora filer (i detta fall en ljud‑ eller videofil) via en process som involverar BLOBs från presentationer. Till exempel kan du behöva extrahera en stor mediafil från en presentation utan att filen laddas in i datorns minne. Genom att exportera filen via BLOB‑processen kan du hålla minnesförbrukningen låg.

Denna kod i Java demonstrerar den beskrivna operationen:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Låser källfilen och LADDAR INTE den i minnet
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// skapa Presentation‑instansen, lås filen "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som kommer att användas
    // för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
    byte[] buffer = new byte[8 * 1024];

    // Itererar genom videorna
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öppnar presentationens videoström. Observera att vi medvetet undvek att komma åt egenskaper
        // som video.BinaryData - eftersom denna egenskap returnerar en bytearray som innehåller en hel video, vilket sedan
        // gör att byte laddas in i minnet. Vi använder video.GetStream, som returnerar en Stream - och LADDAR INTE
        //  kräver att vi laddar hela videon i minnet.
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
        // Minnesförbrukningen kommer att förbli låg oavsett videons eller presentationens storlek.
    }
    // Om nödvändigt kan du tillämpa samma steg för ljudfiler. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Lägg till en bild som BLOB i en presentation**

Med metoder från gränssnittet [**IImageCollection**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IImageCollection) och klassen [**ImageCollection**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ImageCollection) kan du lägga till en stor bild som en ström för att behandla den som en BLOB.

Denna Java‑kod visar hur du lägger till en stor bild via BLOB‑processen:

```java
String pathToLargeImage = "large_image.jpg";

// skapar en ny presentation som bilden kommer att läggas till.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Låt oss lägga till bilden i presentationen - vi väljer KeepLocked‑beteende eftersom vi
		// INTE avser att komma åt filen "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sparar presentationen. Medan en stor presentation exporteras, är minnesförbrukningen
		// låg under hela presentationens livscykel
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Minne och stora presentationer**

Vanligtvis kräver inläsning av en stor presentation mycket temporärt minne. All presentationens innehåll laddas in i minnet och filen (som presentationen lästes in från) slutar användas.

Tänk på en stor PowerPoint-presentation (large.pptx) som innehåller en 1,5 GB videofil. Den standardmetod som används för att läsa in presentationen beskrivs i denna Java‑kod:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Men denna metod förbrukar cirka 1,6 GB temporärt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar en BLOB kan du läsa in en stor presentation med liten minnesanvändning. Denna Java‑kod beskriver implementationen där BLOB‑processen används för att läsa in en stor presentationsfil (large.pptx):

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

### **Ändra mappen för temporära filer**

När BLOB‑processen används skapar datorn temporära filer i standardmappen för temporära filer. Om du vill att de temporära filerna ska lagras i en annan mapp kan du ändra lagringsinställningarna med `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
När du använder `TempFilesRootPath` skapar Aspose.Slides inte automatiskt en mapp för att lagra temporära filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Avsluta presentationsobjekt för att frigöra minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instansen avslutas på rätt sätt så att minnet den upptog frigörs. Anropa `dispose()` när du är klar med presentationen för att frigöra ohanterade resurser.

```java
Presentation presentation = new Presentation("large.pptx");

// ...processa presentationen...
presentation.save("large.pdf", SaveFormat.Pdf);

// Frigör resurser explicit.
presentation.dispose();
```

## **FAQ**

**Vilken data i en Aspose.Slides‑presentation behandlas som BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt som bilder, ljud och video behandlas som BLOB. Hela presentationsfilen omfattas också av BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och spilla över till temporära filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler under inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/) tillsammans med [BlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOB, tillåter eller förbjuder temporära filer, väljer rotvägen för temporära filer och väljer beteende för källlåsning.

**Påverkar BLOB‑inställningarna prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till temporära filer, vilket minskar RAM men kostar extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) för att hitta rätt balans för din arbetsbelastning och miljö.

**Hjälper BLOB‑alternativ när man öppnar extremt stora presentationer (t.ex. gigabyte?)**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera temporära filer och använda källlåsning kan avsevärt minska maximal RAM‑användning och stabilisera bearbetningen av mycket stora bildspel.

**Kan jag använda BLOB‑policyer när jag läser in från strömmar istället för diskfiler?**

Ja. samma regler gäller för strömmar: presentationsinstansen kan äga och låsa indataströmmen (beroende på valt låsläge), och temporära filer används när det är tillåtet, vilket håller minnesanvändningen förutsägbar under bearbetning.