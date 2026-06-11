---
title: Hantera presentations‑BLOBs i JavaScript för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/nodejs-java/manage-blob/
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
- tillfällig fil
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera BLOB‑data i JavaScript med Aspose.Slides för Node.js för att förenkla PowerPoint‑ och OpenDocument‑filoperationer för effektiv presentationhantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB-baserad hantering av stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när man arbetar med stora bilder, ljud, video och presentationsfiler.

Den här artikeln visar hur du använder BLOB-baserad bearbetning för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort objekt (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides för Node.js via Java låter dig använda BLOBs för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

{{% alert title="Info" color="info" %}}
För att kringgå vissa begränsningar vid interaktion med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att läsa in en stor presentation via dess ström leder till att presentationens innehåll kopieras och gör inläsningen långsam. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du avser att läsa in en stor presentation.
{{% /alert %}}

## **Använd BLOB för att minska minnesförbrukning**

### **Lägg till stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/nodejs-java/) för Node.js via Java låter dig lägga till stora filer (i det här fallet en stor videofil) via en process som involverar BLOBs för att minska minnesförbrukningen.

Detta JavaScript‑exempel visar hur du lägger till en stor videofil via BLOB‑processen i en presentation:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Skapar en ny presentation som videon kommer att läggas till
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Vi lägger till videon i presentationen - vi valde KeepLocked beteendet eftersom vi
        // inte avser att komma åt filen "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Sparar presentationen. Medan en stor presentation skapas, förblir minnesförbrukningen
        // låg under hela pres objektets livscykel
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

### **Exportera stor fil via BLOB från presentation**

Aspose.Slides för Node.js via Java låter dig exportera stora filer (i det här fallet en ljud‑ eller videofil) via en process som involverar BLOBs från presentationer. Till exempel kan du behöva extrahera en stor mediFil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB‑processen håller du minnesförbrukningen låg.

Denna kod i JavaScript demonstrerar den beskrivna operationen:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Låser källfilen och laddar INTE in den i minnet
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// skapa Presentation‑instansen, lås "hugePresentationWithAudiosAndVideos.pptx"‑filen.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som kommer att användas
    // för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
    var buffer = new byte[8 * 1024];
    // Itererar igenom videorna
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Öppnar presentationens videoström. Observera att vi avsiktligt undvek att komma åt egenskaper
        // som video.BinaryData - eftersom den egenskapen returnerar en bytearray som innehåller en hel video, vilket då
        // gör att byte laddas in i minnet. Vi använder video.GetStream, som kommer att returnera en Stream - och laddar INTE
        // kräver att vi laddar hela videon i minnet.
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
        // Minnesanvändningen kommer att förbli låg oavsett videons eller presentationens storlek.
    }
    // Om nödvändigt kan du tillämpa samma steg för ljudfiler.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Lägg till bild som BLOB i presentation**

Med metoder från klassen [**ImageCollection**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ImageCollection) och [**ImageCollection** ](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ImageCollection) kan du lägga till en stor bild som en ström för att få den behandlad som en BLOB.

Denna JavaScript‑kod visar hur du lägger till en stor bild via BLOB‑processen:

```javascript
var pathToLargeImage = "large_image.jpg";
// skapar en ny presentation som bilden kommer att läggas till.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Låt oss lägga till bilden i presentationen - vi väljer KeepLocked beteendet eftersom vi
        // INTE avser att komma åt filen "largeImage.png".
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Sparar presentationen. Medan en stor presentation genereras, förblir minnesförbrukningen
        // förblir låg under hela pres objektets livscykel
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

## **Minne och stora presentationer**

Vanligtvis kräver inläsning av en stor presentation mycket temporärt minne. Allt presentationens innehåll laddas in i minnet och filen (från vilken presentationen lästes in) slutar användas.

Tänk på en stor PowerPoint‑presentation (large.pptx) som innehåller en 1,5 GB videofil. Den vanliga metoden för att läsa in presentationen beskrivs i denna JavaScript‑kod:

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

Men denna metod förbrukar omkring 1,6 GB temporärt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar en BLOB kan du läsa in en stor presentation med lite minne. Denna JavaScript‑kod beskriver implementeringen där BLOB‑processen används för att läsa in en stor presentationsfil (large.pptx):

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

### **Ändra mappen för tillfälliga filer**

När BLOB‑processen används skapar din dator tillfälliga filer i standardmappen för tillfälliga filer. Om du vill att de tillfälliga filerna ska lagras i en annan mapp kan du ändra lagringsinställningarna med `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
När du använder `setTempFilesRootPath` skapar Aspose.Slides inte automatiskt en mapp för att lagra tillfälliga filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Disposera presentationsobjekt för att frigöra minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instansen tas bort korrekt så att det minne den upptog frigörs. Anropa `dispose()` efter att du är klar med presentationen för att frigöra ohanterade resurser.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Vilken data i en Aspose.Slides‑presentation behandlas som BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. Hela presentationsfilen omfattas också av BLOB‑hantering när den laddas eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och svalla över till tillfälliga filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler vid inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/) med [BlobManagementOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOB, tillåter eller förbjuder tillfälliga filer, väljer rotmappen för tillfälliga filer och väljer lås‑beteende för källan.

**Påverkar BLOB‑inställningar prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till tillfälliga filer, vilket minskar RAM på bekostnad av extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) för att hitta rätt balans för din arbetsbelastning och ditt miljö.

**Hjälper BLOB‑alternativ när man öppnar extremt stora presentationer (t.ex. flera gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera tillfälliga filer och använda käll‑låsning kan avsevärt minska max RAM‑bruk och stabilisera bearbetningen för mycket stora presentationer.

**Kan jag använda BLOB‑policyer när jag laddar från strömmar istället för från diskfiler?**

Ja. samma regler gäller för strömmar: presentationsinstansen kan äga och låsa inmatningsströmmen (beroende på valt låsläge), och tillfälliga filer används när det är tillåtet, vilket håller minnesanvändningen förutsägbar under bearbetning.