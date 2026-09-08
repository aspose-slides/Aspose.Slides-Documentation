---
title: Beheer presentatie‑BLOB's in Python via Java voor efficiënt geheugengebruik
linktitle: BLOB beheren
type: docs
weight: 10
url: /nl/python-java/manage-blob/
keywords:
- groot object
- groot item
- groot bestand
- BLOB toevoegen
- BLOB exporteren
- afbeelding als BLOB toevoegen
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
description: "Beheer BLOB-gegevens in Aspose.Slides voor Python via Java om PowerPoint- en OpenDocument‑bestandsbewerkingen te stroomlijnen voor efficiënt presentatiebeheer."
---
## **Overzicht**

Aspose.Slides biedt BLOB-gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe je BLOB-gebaseerde verwerking kunt gebruiken om grote media aan een presentatie toe te voegen, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden tijdens de verwerking kunnen worden gebruikt en hoe je de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot bestand (foto, presentatie, document of media) dat in binair formaat wordt opgeslagen.

Aspose.Slides voor Python via Java stelt je in staat om BLOB's te gebruiken voor objecten op een manier die het geheugenverbruik vermindert wanneer er grote bestanden bij betrokken zijn.

{{% alert color="info" title="Opmerking" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van de stream kopiëren. Het laden van een grote presentatie via zijn stream leidt tot het kopiëren van de presentatie-inhoud en veroorzaakt een trage laadtijd. Daarom raden we bij het laden van een grote presentatie sterk aan om het pad naar het presentatie‑bestand te gebruiken en niet de stream.
{{% /alert %}}

## **BLOB gebruiken om het geheugenverbruik te verminderen**

### **Een groot bestand via BLOB aan een presentatie toevoegen**

[Aspose.Slides](/slides/nl/python-java/) voor Python via Java maakt het mogelijk om grote bestanden (in dit geval een groot videobestand) via een proces met BLOB's toe te voegen om het geheugenverbruik te verminderen.

Deze Python‑code laat zien hoe je een groot videobestand via het BLOB‑proces aan een presentatie toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Maak een nieuwe presentatie waarin de video wordt toegevoegd.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Houd de stream vergrendeld omdat we de videobestand niet willen benaderen.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Sla de presentatie op terwijl het geheugengebruik laag blijft.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Een groot bestand via BLOB uit een presentatie exporteren**

Aspose.Slides voor Python via Java maakt het mogelijk om grote bestanden (in dit geval een audio‑ of videobestand) via een BLOB‑proces uit presentaties te exporteren. Bijvoorbeeld, je wilt misschien een groot mediabestand uit een presentatie halen zonder dat het bestand in het geheugen van je computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren houd je het geheugenverbruik laag.

Deze Python‑code demonstreert de beschreven bewerking:

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
    # Indien nodig dezelfde stappen toepassen op audiobestanden.
finally:
    presentation.dispose()
```

### **Een afbeelding als BLOB aan een presentatie toevoegen**

Met methoden uit de klasse [ImageCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagecollection/) kun je een grote afbeelding als stream toevoegen zodat deze wordt behandeld als een BLOB.

Deze Python‑code laat zien hoe je een grote afbeelding via het BLOB‑proces toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Maak een nieuwe presentatie waarin de afbeelding wordt toegevoegd.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Houd de stream vergrendeld omdat we het afbeeldingsbestand niet willen benaderen.
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

Meestal vraagt het laden van een grote presentatie veel tijdelijk geheugen. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie werd geladen) wordt niet meer gebruikt.

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een video van 1,5 GB bevat. De gebruikelijke methode om de presentatie te laden wordt beschreven in deze Python‑code:

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

Deze methode gebruikt echter ongeveer 1,6 GB tijdelijk geheugen.

### **Een grote presentatie als BLOB laden**

Via het proces met een BLOB kun je een grote presentatie laden met weinig geheugen. Deze Python‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentatiebestand (large.pptx) te laden:

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

Wanneer het BLOB‑proces wordt gebruikt, maakt je computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als je wilt dat de tijdelijke bestanden in een andere map worden bewaard, kun je de opslaginstellingen wijzigen met [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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
Wanneer je [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. Je moet de map handmatig aanmaken.
{{% /alert %}}

### **Presentatie‑objecten vrijgeven om geheugen vrij te maken**

Zorg ervoor dat bij het verwerken van grote presentaties de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het geheugen dat hij gebruikte wordt vrijgemaakt. Roep [Presentation.dispose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#dispose) aan nadat je klaar bent met het gebruik van de presentatie om onbeheerste resources vrij te geven.

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
    # Expliciet bronnen vrijgeven.
    presentation.dispose()
```

## **FAQ**

**Welke data in een Aspose.Slides‑presentatie wordt behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Ook het volledige presentatie‑bestand wordt bij het laden of opslaan via BLOB‑verwerking afgehandeld. Deze objecten worden beheerd door BLOB‑beleidsregels waarmee je het geheugengebruik kunt regelen en, indien nodig, naar tijdelijke bestanden kunt uitgieten.

**Waar kan ik BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) samen met [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/). Daar stel je de in‑memory‑limiet voor BLOB in, kun je tijdelijke bestanden al dan niet toestaan, kies je de hoofdmap voor tijdelijke bestanden en selecteer je het gedrag voor bron‑locking.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe balanceer ik snelheid versus geheugen?**

Ja. BLOB in het geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; het verlagen van de geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) om de juiste balans voor jouw workload en omgeving te vinden.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijv. gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en bron‑locking kan het piek‑RAM‑verbruik aanzienlijk verminderen en de verwerking van zeer grote decks stabiliseren.

**Kan ik BLOB‑beleidsregels gebruiken bij het laden vanuit streams in plaats van schijfbestanden?**

Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoerstream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer dit is toegestaan, waardoor het geheugengebruik voorspelbaar blijft tijdens de verwerking.