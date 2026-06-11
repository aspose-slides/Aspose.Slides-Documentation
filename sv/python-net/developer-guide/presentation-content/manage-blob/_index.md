---
title: Hantera BLOB:er i presentationer med Python för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/python-net/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägg till BLOB
- exportera BLOB
- lägg till bild som BLOB
- reducera minne
- minnesförbrukning
- stor presentation
- temporär fil
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera BLOB-data i Aspose.Slides för Python via .NET för att effektivisera PowerPoint- och OpenDocument-filoperationer för effektiv presentationhantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB-baserad hantering av stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när du arbetar med stora bilder, ljud, video och presentationsfiler.

Denna artikel visar hur du använder BLOB-baserad bearbetning för att lägga till stora medier i en presentation, exportera stora medier från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur temporära filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort föremål (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides för Python via .NET låter dig använda BLOB:ar för objekt på ett sätt som minskar minnesförbrukningen när stora filer är inblandade.

## **Använd BLOB för att minska minnesförbrukningen**

### **Lägg till stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/python-net/) för .NET gör det möjligt att lägga till stora filer (i det här fallet en stor videofil) via en process som involverar BLOB:ar för att minska minnesförbrukningen.

Denna Python‑kod visar hur du lägger till en stor videofil via BLOB‑processen i en presentation:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Skapar en ny presentation till vilken videon kommer att läggas till
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Låt oss lägga till videon i presentationen - vi valde KeepLocked-beteendet eftersom vi
        # inte avser att komma åt filen "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Sparar presentationen. Medan en stor presentation genereras, förblir minnesförbrukningen
        # låg genom hela pres-objektets livscykel 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportera stor fil via BLOB från presentation**

Aspose.Slides för Python via .NET låter dig exportera stora filer (i det här fallet en ljud‑ eller videofil) via en process som involverar BLOB:ar från presentationer. Till exempel kan du behöva extrahera en stor mediefil från en presentation men inte vill att filen laddas in i datorns minne. Genom att exportera filen via BLOB‑processen kan du hålla minnesförbrukningen låg.

Denna kod i Python demonstrerar den beskrivna operationen:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som kommer att användas
	# för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itererar genom videorna
    index = 0
    # Om nödvändigt kan du tillämpa samma steg för ljudfiler. 
    for video in pres.videos:
		# Öppnar presentationens videoström. Observera att vi avsiktligt undvek att komma åt egenskaper
		# som video.BinaryData - eftersom den här egenskapen returnerar en byte-array som innehåller en hel video, vilket sedan
		# gör att bytes läses in i minnet. Vi använder video.GetStream, som returnerar Stream - och gör INTE
		#  kräva att vi laddar hela videon i minnet.
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

### **Lägg till bild som BLOB i presentation**

Med metoder från klassen [**ImageCollection**](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/) kan du lägga till en stor bild som en ström för att behandla den som en BLOB.

Denna Python‑kod visar hur du lägger till en stor bild via BLOB‑processen:

```py
import aspose.slides as slides

# skapar en ny presentation till vilken bilden kommer att läggas till.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Minne och stora presentationer**

Vanligtvis kräver inläsning av en stor presentation mycket temporärt minne. Allt innehåll i presentationen läses in i minnet och filen (som presentationen lästes in från) slutar användas.

Tänk på en stor PowerPoint‑presentation (large.pptx) som innehåller en 1,5 GB videofil. Den standardmetod som används för att läsa in presentationen beskrivs i denna Python‑kod:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Men denna metod förbrukar cirka 1,6 GB temporärt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar en BLOB kan du läsa in en stor presentation med lite minne. Denna Python‑kod beskriver implementeringen där BLOB‑processen används för att läsa in en stor presentationsfil (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Ändra mappen för temporära filer**

När BLOB‑processen används skapar datorn temporära filer i standardmappen för temporära filer. Om du vill att de temporära filerna ska sparas i en annan mapp kan du ändra lagringsinställningarna med `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
När du använder `temp_files_root_path` skapar Aspose.Slides inte automatiskt en mapp för att lagra temporära filer. Du måste skapa mappen manuellt.
{{% /alert %}}

### **Frigör presentationsobjekt för att släppa minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instansen avskaffas korrekt så att minnet den upptog frigörs. Det rekommenderade sättet är att använda kontext‑hanteraren (`with slides.Presentation(...) as presentation:`) som visas i exemplen ovan; den stänger automatiskt presentationen och frigör ohanterade resurser när blocket avslutas.

Om du skapar en presentation utan ett `with`‑block, anropa explicit `presentation.dispose()` när du är klar med den, och ta bort eventuella återstående referenser så att Pythons skräpsamlare kan återta minnet.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...processa presentationen...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Frigör resurser explicit.
presentation.dispose()
```

## **FAQ**

**Vilken data i en Aspose.Slides‑presentation behandlas som BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. Hela presentationsfilen omfattas också av BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och skriva ut till temporära filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler vid inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/) tillsammans med [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOB, tillåter eller förbjuder temporära filer, väljer rotvägen för temporära filer och väljer låsningsbeteende för källan.

**Påverkar BLOB‑inställningarna prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att behålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till temporära filer, vilket minskar RAM på bekostnad av extra I/O. Justera tröskeln för [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/sv/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) för att hitta rätt balans för din arbetsbelastning och miljö.

**Hjälper BLOB‑alternativen när man öppnar extremt stora presentationer (t.ex. gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera temporära filer och använda låsning av källan kan avsevärt minska topp‑RAM‑användning och stabilisera bearbetning av mycket stora presentationer.

**Kan jag använda BLOB‑policyer när jag läser in från strömmar istället för diskfiler?**

Ja. Samma regler gäller för strömmar: presentationsinstansen kan äga och låsa indataströmmen (beroende på valt låsningsläge), och temporära filer används när det är tillåtet, vilket håller minnesanvändningen förutsägbar under bearbetning.