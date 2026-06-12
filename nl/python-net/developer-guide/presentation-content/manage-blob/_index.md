---
title: Beheer BLOB's in presentaties met Python voor efficiënt geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/python-net/manage-blob/
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
- Aspose.Slides
description: "Beheer BLOB-gegevens in Aspose.Slides voor Python via .NET om PowerPoint- en OpenDocument-bestandsbewerkingen te stroomlijnen voor een efficiënte verwerking van presentaties."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatiebestanden.

Dit artikel laat zien hoe je BLOB‑gebaseerde verwerking kunt gebruiken om grote media aan een presentatie toe te voegen, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden tijdens de verwerking kunnen worden gebruikt en hoe je de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is gewoonlijk een groot item (foto, presentatie, document of media) dat in binair formaat is opgeslagen.

Aspose.Slides for Python via .NET stelt je in staat BLOB‑s te gebruiken voor objecten op een manier die het geheugenverbruik verlaagt wanneer grote bestanden betrokken zijn.

## **Gebruik BLOB om Geheugenverbruik te Verminderen**

### **Groot Bestand via BLOB aan een Presentatie Toevoegen**

[Aspose.Slides](/slides/nl/python-net/) for .NET maakt het mogelijk om grote bestanden (in dit geval een groot videobestand) via een BLOB‑proces toe te voegen om het geheugenverbruik te verminderen.

Deze Python‑code laat zien hoe je een groot videobestand via het BLOB‑proces aan een presentatie toevoegt:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Maakt een nieuwe presentatie waaraan de video wordt toegevoegd
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Laten we de video toevoegen aan de presentatie - we kozen het KeepLocked-gedrag omdat we
        # niet van plan zijn het bestand "veryLargeVideo.avi" te benaderen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Slaat de presentatie op. Terwijl een grote presentatie wordt gegenereerd, blijft het geheugengebruik
        # laag gedurende de levensduur van het pres-object 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Groot Bestand via BLOB uit Presentatie Exporteren**
Aspose.Slides for Python via .NET maakt het mogelijk om grote bestanden (bijvoorbeeld een audio‑ of videobestand) via een BLOB‑proces uit presentaties te exporteren. Bijvoorbeeld, je wilt een groot mediabestand uit een presentatie halen zonder dat het bestand in het geheugen van je computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren, houd je het geheugenverbruik laag.

Deze Python‑code demonstreert de beschreven bewerking:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Laten we elke video opslaan naar een bestand. Om hoog geheugenverbruik te voorkomen, hebben we een buffer nodig die gebruikt zal worden
	# om de gegevens van de videostream van de presentatie over te dragen naar een stream voor een nieuw aangemaakt videobestand.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Doorloopt de video's
    index = 0
    # Indien nodig kun je dezelfde stappen toepassen op audiobestanden. 
    for video in pres.videos:
		# Opent de videostream van de presentatie. Merk op dat we opzettelijk toegang tot eigenschappen hebben vermeden
		# zoals video.BinaryData - omdat deze eigenschap een byte‑array teruggeeft met de volledige video, waardoor
		# bytes in het geheugen worden geladen. We gebruiken video.GetStream, dat een Stream teruggeeft – en dit
		#  vereist niet dat we de hele video in het geheugen laden.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Afbeelding als BLOB aan Presentatie Toevoegen**
Met methoden uit de [**ImageCollection**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/)‑klasse kun je een grote afbeelding als stream toevoegen zodat deze als BLOB wordt behandeld.

Deze Python‑code laat zien hoe je een grote afbeelding via het BLOB‑proces toevoegt:

```py
import aspose.slides as slides

# maakt een nieuwe presentatie waaraan de afbeelding zal worden toegevoegd.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Geheugen en Grote Presentaties**

Normaal gesproken vereisen computers veel tijdelijk geheugen om een grote presentatie te laden. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie is geladen) wordt niet langer gebruikt.

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een video van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt getoond in deze Python‑code:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen.

### **Grote Presentatie als BLOB Laden**

Via een BLOB‑proces kun je een grote presentatie laden met weinig geheugen. Deze Python‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentiebestand (large.pptx) te laden:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Map voor Tijdelijke Bestanden Wijzigen**

Wanneer het BLOB‑proces wordt gebruikt, maakt je computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als je wilt dat de tijdelijke bestanden in een andere map worden bewaard, kun je de opslaginstelling wijzigen met `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Wanneer je `temp_files_root_path` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. Je moet de map handmatig aanmaken.
{{% /alert %}}

### **Presentatie‑objecten Vrijgeven om Geheugen te Bevrijden**

Bij het verwerken van grote presentaties moet je ervoor zorgen dat de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie correct wordt vrijgegeven, zodat het gebruikte geheugen wordt vrijgemaakt. De aanbevolen manier is om de contextmanager (`with slides.Presentation(...) as presentation:`) te gebruiken, zoals getoond in de voorbeelden hierboven; die sluit de presentatie automatisch en vrijgeeft niet‑beheerde bronnen wanneer het blok wordt verlaten.

Als je een presentatie maakt zonder een `with`‑blok, roep dan expliciet `presentation.dispose()` aan nadat je klaar bent met het gebruik ervan, en verwijder eventuele resterende referenties zodat de garbage collector van Python het geheugen kan terugwinnen.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...verwerk de presentatie...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Expliciet de bronnen vrijgeven.
presentation.dispose()
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en worden gecontroleerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden als BLOB behandeld. Het volledige presentatiebestand omvat ook BLOB‑verwerking bij het laden of opslaan. Deze objecten worden beheerd door BLOB‑beleid dat je in staat stelt het geheugenverbruik te regelen en, indien nodig, uit te vloeien naar tijdelijke bestanden.

**Waar configureer ik BLOB‑verwerkingsregels tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/) met [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/blobmanagementoptions/). Daar stel je de in‑memory‑limiet voor BLOB in, sta je tijdelijke bestanden toe of niet, kies je de hoofdmap voor tijdelijke bestanden en bepaal je het vergrendelingsgedrag van de bron.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe vind ik de juiste balans tussen snelheid en geheugen?**

Ja. BLOB in het geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; het verlagen van de geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Pas de drempel `max_blobs_bytes_in_memory` aan om de juiste balans voor jouw werklast en omgeving te vinden.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijv. meerdere gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario’s: het inschakelen van tijdelijke bestanden en het gebruiken van bronvergrendeling kan het piek‑RAM‑verbruik aanzienlijk verlagen en de verwerking van zeer grote decks stabiliseren.

**Kan ik BLOB‑beleid gebruiken bij het laden vanaf streams in plaats van schijf‑bestanden?**

Ja. dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, zodat het geheugenverbruik voorspelbaar blijft tijdens de verwerking.