---
title: "Hantera presentations‑BLOBs i Python via Java för effektiv minnesanvändning"
linktitle: "Hantera BLOB"
type: docs
weight: 10
url: /sv/python-java/manage-blob/
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
- Python
- Java
- Aspose.Slides
description: "Hantera BLOB-data i Aspose.Slides för Python via Java för att förenkla PowerPoint- och OpenDocument-filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB-baserad hantering för stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när man arbetar med stora bilder, ljud, video och presentationsfiler.

Denna artikel visar hur man använder BLOB-baserad bearbetning för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur temporära filer kan användas under bearbetning och hur man ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort objekt (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides för Python via Java låter dig använda BLOBs för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

{{% alert color="info" title="Note" %}}
För att kringgå vissa begränsningar vid interaktion med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att läsa in en stor presentation via dess ström resulterar i en kopiering av presentationens innehåll och orsakar långsam inläsning. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du avser att läsa in en stor presentation.
{{% /alert %}}

## **Använd BLOB för att minska minnesförbrukning**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/python-java/) för Python via Java låter dig lägga till stora filer (i detta fall en stor videofil) genom en process som involverar BLOBs för att minska minnesförbrukningen.

Denna Python‑kod visar hur du lägger till en stor videofil via BLOB‑processen i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Skapa en ny presentation som videon ska läggas till i.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Behåll strömmen låst eftersom vi inte avser att komma åt videofilen.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Spara presentationen samtidigt som minnesförbrukningen hålls låg.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Exportera en stor fil via BLOB från en presentation**

Aspose.Slides för Python via Java låter dig exportera stora filer (i detta fall en ljud‑ eller videofil) genom en process som involverar BLOBs från presentationer. Till exempel kan du behöva extrahera en stor medi fil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB‑processen kan du hålla minnesförbrukningen låg.

Denna kod i Python demonstrerar den beskrivna operationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Lås källfilen istället för att läsa in den i minnet.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Överför videodata genom en buffert för att hålla minnesförbrukningen låg.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Använd strömmen istället för att läsa in hela videon i en byte‑array.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Om nödvändigt, tillämpa samma steg på ljudfiler.
finally:
    presentation.dispose()
```

### **Lägg till en bild som BLOB i en presentation**

Med metoder från klassen [ImageCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/) kan du lägga till en stor bild som en ström för att få den behandlad som en BLOB.

Denna Python‑kod visar hur du lägger till en stor bild via BLOB‑processen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Skapa en ny presentation som bilden ska läggas till i.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Behåll strömmen låst eftersom vi inte avser att komma åt bildfilen.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Spara presentationen samtidigt som minnesförbrukningen hålls låg.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Minne och stora presentationer**

Vanligtvis kräver inläsning av en stor presentation mycket tillfälligt minne. Allt presentationens innehåll laddas in i minnet och filen (från vilken presentationen laddades) slutar användas.

Tänk på en stor PowerPoint‑presentation (large.pptx) som innehåller en 1,5 GB videofil. Den standardmetod för att läsa in presentationen beskrivs i denna Python‑kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Men denna metod förbrukar omkring 1,6 GB tillfälligt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar en BLOB kan du läsa in en stor presentation med lite minne. Denna Python‑kod beskriver implementeringen där BLOB‑processen används för att läsa in en stor presentationsfil (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Ändra mappen för temporära filer**

När BLOB‑processen används skapar din dator temporära filer i standardmappen för temporära filer. Om du vill att de temporära filerna ska sparas i en annan mapp kan du ändra lagringsinställningarna med [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
När du använder [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) skapar inte Aspose.Slides automatiskt en mapp för att lagra temporära filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Frigör presentationsobjekt för att släppa minne**

När du bearbetar stora presentationer, se till att instansen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) avsörjs korrekt så att det minne den upptog frigörs. Anropa [Presentation.dispose](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#dispose) efter att du har avslutat användningen av presentationen för att frigöra osäkra resurser.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...bearbeta presentationen...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Frigör resurser explicit.
    presentation.dispose()
```

## **FAQ**

**Vilken data i en Aspose.Slides‑presentation behandlas som BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. Hela presentationsfilen involverar också BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och överföra till temporära filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler under inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/) med [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/). Där anger du minnesgränsen för BLOB, tillåter eller förbjuder temporära filer, väljer rot‑sökvägen för temporära filer och väljer beteende för kilslåsning av källan.

**Påverkar BLOB‑inställningar prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; att sänka minnesgränsen flyttar mer arbete till temporära filer, vilket minskar RAM på bekostnad av extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) för att hitta rätt balans för din arbetsbelastning och miljö.

**Hjälper BLOB‑alternativ när man öppnar extremt stora presentationer (t.ex. flera gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera temporära filer och använda kilslåsning kan avsevärt minska topp‑RAM‑användning och stabilisera bearbetningen av mycket stora presentationer.

**Kan jag använda BLOB‑policyer när jag läser från strömmar istället för diskfiler?**

Ja. Samma regler gäller för strömmar: presentationsinstansen kan äga och låsa inmatningsströmmen (beroende på valt låsläge), och temporära filer används när det är tillåtet, vilket håller minnesanvändningen förutsägbar under bearbetning.