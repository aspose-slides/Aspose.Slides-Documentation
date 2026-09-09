---
title: Hantera presentations BLOBs i Python via Java för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/python-java/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägga till BLOB
- exportera BLOB
- lägga till bild som BLOB
- reducera minne
- minnesförbrukning
- stor presentation
- tillfällig fil
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera BLOB‑data i Aspose.Slides för Python via Java för att effektivisera PowerPoint‑ och OpenDocument‑filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB‑baserad hantering av stora binära data i presentationer för att minska minnesförbrukningen när du arbetar med stora bilder, ljud, video och presentationsfiler.

Den här artikeln visar hur du använder BLOB‑baserad behandling för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

En **BLOB** (**Binary Large Object**, binärt stort objekt) är vanligtvis ett stort föremål (foto, presentation, dokument eller media) som sparas i binärt format.

Aspose.Slides för Python via Java låter dig använda BLOBs för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

{{% alert color="info" title="Obs" %}}
För att kringgå vissa begränsningar vid interaktion med strömmar kan Aspose.Slides kopiera strömmens innehåll. Att läsa in en stor presentation via dess ström kommer att resultera i en kopiering av presentationens innehåll och orsaka långsam inläsning. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg och inte dess ström när du tänker läsa in en stor presentation.
{{% /alert %}}

## **Använd BLOBs för att minska minnesförbrukningen**

### **Lägg till en stor fil i en presentation med BLOBs**

[Aspose.Slides](/slides/sv/python-java/) för Python via Java låter dig lägga till stora filer (i detta fall en stor videofil) genom en process som involverar BLOBs för att minska minnesförbrukningen.

Denna Python‑kod visar hur du lägger till en stor videofil via BLOB‑processen till en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Skapa en ny presentation till vilken videon ska läggas till.
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

### **Exportera en stor fil från en presentation med BLOBs**
Aspose.Slides för Python via Java låter dig exportera stora filer (i detta fall en ljud‑ eller videofil) genom en BLOB‑process från presentationer. Till exempel kan du behöva extrahera en stor medi fil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB‑processen håller du minnesförbrukningen låg.

Denna Python‑kod demonstrerar den beskrivna operationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Lås källfilen istället för att ladda den i minnet.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Överför videodata genom en buffert för att hålla minnesförbrukningen låg.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Använd strömmen istället för att ladda hela videon i en byte array.
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
Med metoder från [ImageCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/)‑klassen kan du lägga till en stor bild som en ström så att den behandlas som en BLOB.

Denna Python‑kod visar hur du lägger till en stor bild via BLOB‑processen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Skapa en ny presentation till vilken bilden ska läggas till.
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

Vanligtvis kräver inläsning av en stor presentation mycket tillfälligt minne. Allt presentationens innehåll laddas in i minnet och filen (från vilken presentationen lästes) slutar användas.

Tänk dig en stor PowerPoint‑presentation (large.pptx) som innehåller en 1,5 GB videofil. Standardmetoden för att läsa in presentationen beskrivs i denna Python‑kod:

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

Genom att använda BLOB‑hantering kan du läsa in en stor presentation samtidigt som du använder lite minne. Denna Python‑kod visar hur du använder BLOB‑hantering för att läsa in en stor presentationsfil (large.pptx):

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

### **Ändra mappen för tillfälliga filer**

När BLOB‑processen används skapar datorn tillfälliga filer i standardmappen för tillfälliga filer. Om du vill att de tillfälliga filerna ska lagras i en annan mapp kan du ändra lagringsinställningarna med [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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

{{% alert color="info" title="Obs" %}}
När du använder [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) skapar inte Aspose.Slides automatiskt en mapp för att lagra tillfälliga filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Avsluta presentationsobjekt för att frigöra minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instansen avslutas korrekt så att det minne den upptog frigörs. Anropa [Presentation.dispose](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#dispose) när du är klar med presentationen för att frigöra ohanterade resurser.

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

**Vilken data i en Aspose.Slides‑presentation behandlas som en BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt som bilder, ljud och video behandlas som BLOBs. Hela presentationsfilen omfattas också av BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och överföra tillfälliga filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler vid presentationens inläsning?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/) tillsammans med [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOBs, tillåter eller förbjuder tillfälliga filer, väljer rot‑sökväg för tillfälliga filer och anger låsningsbeteende för källan.

**Påverkar BLOB‑inställningar prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOBs i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till tillfälliga filer, vilket minskar RAM‑användningen på bekostnad av extra I/O. Använd metoden [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) för att hitta rätt balans för din arbetsbelastning och din miljö.

**Hjälper BLOB‑alternativ när man öppnar extremt stora presentationer (t.ex. flera gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blobmanagementoptions/) är designat för sådana scenarier: att möjliggöra tillfälliga filer och använda käll‑låsning kan avsevärt minska topp‑RAM‑användning och stabilisera bearbetning av mycket stora bildspel.

**Kan jag använda BLOB‑policyer när jag läser in från strömmar istället för diskfiler?**

Ja. Samma regler gäller för strömmar: presentationsinstansen kan äga och låsa inmatningsströmmen (beroende på valt låsningsläge), och tillfälliga filer används när de är tillåtna, vilket håller minnesanvändningen förutsägbar under bearbetning.