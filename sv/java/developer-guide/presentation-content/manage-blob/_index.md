---
title: Hantera presentations-BLOB:er i Java för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/java/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägg till BLOB
- exportera BLOB
- lägg till bild som BLOB
- minska minnet
- minnesanvändning
- stor presentation
- temporär fil
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera BLOB-data i Aspose.Slides för Java för att effektivisera PowerPoint- och OpenDocument-filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides erbjuder BLOB-baserad hantering av stora binära data i presentationer för att minska minnesanvändningen när man arbetar med stora bilder, ljud, video och presentationsfiler.

Den här artikeln visar hur du använder BLOB-baserad behandling för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort objekt (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides for Java låter dig använda BLOBs för objekt på ett sätt som minskar minnesanvändningen när stora filer är inblandade.

{{% alert title="Info" color="info" %}}
För att kringgå vissa begränsningar när man interagerar med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att läsa in en stor presentation via dess ström leder till att presentationens innehåll kopieras och ger långsam laddning. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du avser att läsa in en stor presentation.
{{% /alert %}}

## **Använd BLOB för att minska minnesanvändning**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/java/) for Java låter dig lägga till stora filer (i detta fall en stor videofil) via en process som involverar BLOBs för att minska minnesanvändningen.

Den här Java-koden visar hur du lägger till en stor videofil via BLOB-processen i en presentation:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Skapar en ny presentation som videon kommer att läggas till
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Låt oss lägga till videon i presentationen - vi valde KeepLocked-beteendet eftersom vi
        //inte har för avsikt att komma åt filen "veryLargeVideo.avi" filen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Sparar presentationen. Medan en stor presentation skrivs ut, förblir minnesanvändningen
        //låg genom hela presentationens livscykel 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportera en stor fil via BLOB från presentation**

Aspose.Slides for Java låter dig exportera stora filer (i detta fall en ljud- eller videofil) via en process som involverar BLOBs från presentationer. Till exempel kan du behöva extrahera en stor medi Fil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB-processen håller du minnesanvändningen låg.

Den här Java-koden demonstrerar den beskrivna operationen:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Låser källfilen och LÄSER IN den INTE i minnet
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Skapa Presentation‑instansen, lås filen "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som ska användas
    // för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
    byte[] buffer = new byte[8 * 1024];

    // Itererar genom videorna
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öppnar presentationens videoström. Observera att vi medvetet undvek att komma åt egenskaper
        // som video.BinaryData - eftersom denna egenskap returnerar en byte‑array som innehåller hela videon, vilket i sin tur
        // gör att byte laddas in i minnet. Vi använder video.GetStream, vilket returnerar en Stream - och gör INTE
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
        // Minnesanvändningen förblir låg oavsett videons eller presentationens storlek.
    }
    // Vid behov kan du tillämpa samma steg för ljudfiler. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Lägg till en bild som BLOB i en presentation**

Med metoder från gränssnittet [**IImageCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImageCollection) och klassen [**ImageCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ImageCollection) kan du lägga till en stor bild som en ström för att behandla den som ett BLOB.

Den här Java-koden visar hur du lägger till en stor bild via BLOB-processen:

```java
String pathToLargeImage = "large_image.jpg";

// creates a new presentation to which the image will be added.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Let's add the image to the presentation - we choose KeepLocked behavior because we do
		// NOT intend to access the "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Saves the presentation. While a large presentation gets outputted, the memory consumption
		// stays low through the pres object's lifecycle
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

Vanligtvis kräver inläsning av en stor presentation mycket tillfälligt minne. Allt presentationens innehåll läses in i minnet och filen (från vilken presentationen lästes in) slutar användas.

Tänk på en stor PowerPoint-presentation (large.pptx) som innehåller en 1,5 GB videofil. Den standardmetod som används för att läsa in presentationen beskrivs i denna Java-kod:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Men denna metod förbrukar cirka 1,6 GB tillfälligt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar ett BLOB kan du läsa in en stor presentation med lite minne. Den här Java-koden beskriver implementeringen där BLOB-processen används för att läsa in en stor presentationsfil (large.pptx):

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

### **Ändra mappen för tillfälliga filer**

När BLOB-processen används skapar datorn tillfälliga filer i standardmappen för tillfälliga filer. Om du vill att de tillfälliga filerna ska lagras i en annan mapp kan du ändra lagringsinställningarna med `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
När du använder `TempFilesRootPath` skapar Aspose.Slides inte automatiskt en mapp för att lagra tillfälliga filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Disposera presentationsobjekt för att frigöra minne**

Vid bearbetning av stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-instansen tas bort på rätt sätt så att minnet den använde frigörs. Anropa `dispose()` efter att du är klar med presentationen för att frigöra ohanterade resurser.

```java
Presentation presentation = new Presentation("large.pptx");

// ...bearbeta presentationen...
presentation.save("large.pdf", SaveFormat.Pdf);

// Frigör resurser explicit.
presentation.dispose();
```

## **FAQ**

**Vilken data i en Aspose.Slides-presentation behandlas som BLOB och styrs av BLOB-alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. hela presentationsfilen hanteras också med BLOB när den läses in eller sparas. Dessa objekt styrs av BLOB-policyer som låter dig hantera minnesanvändning och skriva till tillfälliga filer vid behov.

**Var konfigurerar jag BLOB-hanteringsregler vid inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/) med [BlobManagementOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/blobmanagementoptions/). Där anger du gränsen för BLOB i minnet, tillåter eller förbjuder tillfälliga filer, väljer rotökvägen för temp‑filer och väljer beteende för källlåsning.

**Påverkar BLOB-inställningar prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att behålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; att sänka minnesgränsen flyttar mer arbete till tillfälliga filer, vilket minskar RAM på bekostnad av extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) för att hitta rätt balans för din arbetsbelastning och miljö.

**Hjälper BLOB-alternativ när man öppnar extremt stora presentationer (t.ex. i gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera tillfälliga filer och använda källlåsning kan avsevärt minska maximal RAM‑användning och stabilisera bearbetning av mycket stora presentationer.

**Kan jag använda BLOB-policyer när jag laddar från strömmar istället för diskfiler?**

Ja. samma regler gäller för strömmar: presentationsinstansen kan äga och låsa inmatningsströmmen (beroende på valt låsningsläge), och tillfälliga filer används när de är tillåtna, vilket håller minnesanvändningen förutsägbar under bearbetning.