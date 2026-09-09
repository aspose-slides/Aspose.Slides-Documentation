---
title: Beheer presentatie-BLOB's in Python via Java voor efficiënt geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/python-java/manage-blob/
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
- Python
- Java
- Aspose.Slides
description: "Beheer BLOB-gegevens in Aspose.Slides voor Python via Java om PowerPoint- en OpenDocument-bestanden te vereenvoudigen voor een efficiënte verwerking van presentaties."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugengebruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking kunt gebruiken om grote media toe te voegen aan een presentatie, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

Een **BLOB** (**Binary Large Object**) is meestal een groot item (foto, presentatie, document of media) dat wordt opgeslagen in binaire formaten.

Aspose.Slides voor Python via Java stelt u in staat BLOB's te gebruiken voor objecten op een manier die het geheugengebruik vermindert wanneer er grote bestanden bij betrokken zijn.

{{% alert color="info" title="Opmerking" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream leidt tot het kopiëren van de presentatie‑inhoud en veroorzaakt langzaam laden. Daarom raden we sterk aan om bij het laden van een grote presentatie het pad naar het presentatiebestand te gebruiken en niet de stream.
{{% /alert %}}

## **BLOB's gebruiken om het geheugengebruik te verminderen**

### **Een groot bestand toevoegen aan een presentatie met BLOB's**

[Aspose.Slides](/slides/nl/python-java/) voor Python via Java stelt u in staat grote bestanden (in dit geval een groot videobestand) toe te voegen via een BLOB‑proces om het geheugengebruik te verminderen.

Deze Python‑code laat zien hoe u een groot videobestand via het BLOB‑proces aan een presentatie toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Maak een nieuwe presentatie waaraan de video wordt toegevoegd.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Laat de stream vergrendeld, want we zijn niet van plan het videobestand te benaderen.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Sla de presentatie op terwijl het geheugengebruik laag blijft.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Een groot bestand exporteren uit een presentatie met BLOB's**
Aspose.Slides voor Python via Java stelt u in staat grote bestanden (in dit geval een audio‑ of videobestand) via een BLOB‑proces uit presentaties te exporteren. Bijvoorbeeld, u moet misschien een groot mediabestand uit een presentatie halen, maar wilt niet dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren, blijft het geheugengebruik laag.

Deze code in Python demonstreert de beschreven handeling:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Vergrendel het bronbestand in plaats van het in het geheugen te laden.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Verplaats videogegevens via een buffer om het geheugengebruik laag te houden.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Gebruik de stream in plaats van de volledige video in een byte-array te laden.
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
    # Indien nodig, pas dezelfde stappen toe op audiobestanden.
finally:
    presentation.dispose()
```

### **Een afbeelding toevoegen als BLOB aan een presentatie**
Met methoden uit de [ImageCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagecollection/)‑klasse kunt u een grote afbeelding als stream toevoegen zodat deze wordt behandeld als een BLOB.

Deze Python‑code laat zien hoe u een grote afbeelding via het BLOB‑proces toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Maak een nieuwe presentatie waaraan de afbeelding wordt toegevoegd.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Houd de stream vergrendeld omdat we het afbeeldingsbestand niet gaan benaderen.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Sla de presentatie op terwijl het geheugengebruik laag blijft.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Geheugen en grote presentaties**

Doorgaans hebben computers veel tijdelijk geheugen nodig om een grote presentatie te laden. De gehele inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie werd geladen) wordt niet meer gebruikt.

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een videobestand van 1,5 GB bevat. De standaardmethode voor het laden van de presentatie staat beschreven in deze Python‑code:

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

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen.

### **Een grote presentatie laden als BLOB**
Door BLOB‑verwerking te gebruiken kunt u een grote presentatie laden met weinig geheugen. Deze Python‑code laat zien hoe u BLOB‑verwerking gebruikt om een groot presentatied bestand (large.pptx) te laden:

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

### **De map voor tijdelijke bestanden wijzigen**
Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de opslaginstellingen wijzigen met behulp van [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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

{{% alert color="info" title="Opmerking" %}}
Wanneer u [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken.
{{% /alert %}}

### **Presentatie‑objecten vrijgeven om geheugen vrij te maken**
Bij het verwerken van grote presentaties moet u ervoor zorgen dat de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het geheugen dat het gebruikte wordt vrijgegeven. Roep [Presentation.dispose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#dispose) aan nadat u klaar bent met de presentatie om niet‑beheerde resources vrij te maken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...verwerk de presentatie...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Resources expliciet vrijgeven.
    presentation.dispose()
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB's. Het volledige presentatied bestand wordt ook via BLOB‑verwerking behandeld bij het laden of opslaan. Deze objecten worden beheerd door BLOB‑beleid waarmee u het geheugengebruik kunt regelen en naar tijdelijke bestanden kunt uitrollen wanneer dat nodig is.

**Waar kan ik BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) in combinatie met [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/). Daar stelt u de in‑memory‑limiet voor BLOB's in, staat u tijdelijke bestanden toe of niet, kiest u de hoofdmap voor tijdelijke bestanden en selecteert u het vergrendelingsgedrag van de bron.

**Hebben BLOB‑instellingen invloed op de prestaties, en hoe balanceer ik snelheid versus geheugen?**

Ja. BLOB's in het geheugen houden maximaliseert de snelheid maar vergroot het RAM‑verbruik; het verlagen van de geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory)‑methode om de juiste balans voor uw workload en omgeving te vinden.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijv. gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/) is ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en het gebruiken van bronvergrendeling kan het piek‑RAM‑verbruik aanzienlijk verminderen en de verwerking van zeer grote presentaties stabiliseren.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van schijfbestanden?**

Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, waardoor het geheugengebruik tijdens de verwerking voorspelbaar blijft.