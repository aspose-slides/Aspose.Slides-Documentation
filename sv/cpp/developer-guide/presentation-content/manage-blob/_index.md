---
title: Hantera presentations-BLOBs i C++ för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Hantera BLOB-data i Aspose.Slides för C++ för att effektivisera PowerPoint- och OpenDocument-filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides tillhandahåller BLOB-baserad hantering av stora binära data i presentationer för att hjälpa till att minska minnesförbrukningen när du arbetar med stora bilder, ljud, video och presentationsfiler.

Denna artikel visar hur du använder BLOB-baserad bearbetning för att lägga till stora media i en presentation, exportera stora media från en presentation och läsa in stora presentationer mer effektivt. Den förklarar också hur tillfälliga filer kan användas under bearbetning och hur du ändrar mappen som används för att lagra dem.

## **Om BLOB**

**BLOB** (**Binary Large Object**) är vanligtvis ett stort föremål (foto, presentation, dokument eller media) som sparas i binära format.

Aspose.Slides för C++ låter dig använda BLOBs för objekt på ett sätt som minskar minnesförbrukningen när stora filer är involverade.

## **Använd BLOB för att minska minnesförbrukning**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/cpp/) för C++ låter dig lägga till stora filer (i det här fallet en stor videofil) genom en process som involverar BLOBs för att minska minnesförbrukningen.

Denna C++-kod visar hur du lägger till en stor videofil via BLOB-processen i en presentation:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Skapar en ny presentation som videon ska läggas till i
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Låt oss lägga till videon i presentationen - vi valde KeepLocked-beteendet eftersom vi
// inte avser att komma åt filen "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Sparar presentationen. När en stor presentation genereras, förblir minnesförbrukningen
// förblir låg under presentationens livscykel
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Exportera en stor fil via BLOB från en presentation**

Aspose.Slides för C++ låter dig exportera stora filer (i det här fallet en ljud- eller videofil) genom en process som involverar BLOBs från presentationer. Till exempel kan du behöva extrahera en stor mediefil från en presentation men inte vilja att filen laddas in i datorns minne. Genom att exportera filen via BLOB-processen kan du hålla minnesförbrukningen låg.

Denna kod i C++ demonstrerar den beskrivna operationen:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Skapar en instans av Presentation, låser filen "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som kommer att användas
// för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Itererar genom videorna
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Öppnar presentationens videoström. Observera att vi avsiktligt undvek att anropa metoder
	// som video->get_BinaryData - eftersom denna metod returnerar en byte-array som innehåller hela videon, vilket då
	// leder till att bytes laddas in i minnet. Vi använder video->GetStream, som returnerar en Stream - och gör INTE
	// kräver att vi laddar hela videon i minnet.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Minnesanvändningen kommer att förbli låg oavsett videons eller presentationens storlek,
}

// Om behövs kan du tillämpa samma steg för ljudfiler.
```

### **Lägg till en bild som BLOB i en presentation**

Med metoder från gränssnittet [**IImageCollection**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_image_collection) och klassen [**ImageCollection** ](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.image_collection)class kan du lägga till en stor bild som en ström för att behandla den som en BLOB.

Denna C++-kod visar hur du lägger till en stor bild via BLOB-processen:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// skapar en ny presentation som bilden kommer att läggas till.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Låt oss lägga till bilden i presentationen - vi väljer KeepLocked-beteendet eftersom vi
// INTE planerar att komma åt filen "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Sparar presentationen. När en stor presentation genereras, förblir minnesförbrukningen 
// låg under presentationens livscykel
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Minne och stora presentationer**

Vanligtvis kräver det mycket temporärt minne att läsa in en stor presentation. Allt innehåll i presentationen laddas in i minnet och filen (från vilken presentationen lästes in) slutar användas.

Tänk på en stor PowerPoint-presentation (large.pptx) som innehåller en 1,5 GB videofil. Den standardmetod för att läsa in presentationen beskrivs i denna C++-kod:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Men denna metod förbrukar cirka 1,6 GB temporärt minne.

### **Läs in en stor presentation som BLOB**

Genom processen som involverar en BLOB kan du läsa in en stor presentation samtidigt som du använder lite minne. Denna C++-kod beskriver implementeringen där BLOB-processen används för att läsa in en stor presentationsfil (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Ändra mappen för temporära filer**

När BLOB-processen används skapar datorn temporära filer i standardmappen för temporära filer. Om du vill att de temporära filerna ska sparas i en annan mapp kan du ändra lagringsinställningarna med `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
När du använder `TempFilesRootPath` skapar Aspose.Slides inte automatiskt en mapp för att lagra temporära filer. Du måste skapa mappen manuellt. 
{{% /alert %}}

### **Disposera presentationsobjekt för att frigöra minne**

När du bearbetar stora presentationer, se till att [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instansen tas korrekt ner så att det minne den upptog frigörs. Anropa `Dispose()` efter att du har slutat använda presentationen för att frigöra ohanterade resurser.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **FAQ**

**Vilken data i en Aspose.Slides-presentation behandlas som BLOB och styrs av BLOB‑alternativ?**

Stora binära objekt såsom bilder, ljud och video behandlas som BLOB. Hela presentationsfilen involverar också BLOB‑hantering när den läses in eller sparas. Dessa objekt styrs av BLOB‑policyer som låter dig hantera minnesanvändning och spilla över till temporära filer vid behov.

**Var konfigurerar jag BLOB‑hanteringsregler under inläsning av en presentation?**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/) med [BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/blobmanagementoptions/). Där ställer du in minnesgränsen för BLOB, tillåter eller förbjuder temporära filer, väljer rotvägen för temporära filer och väljer beteende för källlåsning.

**Påverkar BLOB‑inställningarna prestanda, och hur balanserar jag hastighet mot minne?**

Ja. Att hålla BLOB i minnet maximerar hastigheten men ökar RAM‑förbrukningen; en lägre minnesgräns flyttar mer arbete till temporära filer, vilket minskar RAM på bekostnad av extra I/O. Använd metoden [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) för att hitta rätt balans för din arbetsbelastning och miljö.

**Hjälper BLOB‑alternativen när man öppnar extremt stora presentationer (t.ex. gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/blobmanagementoptions/) är utformade för sådana scenarier: att aktivera temporära filer och använda källlåsning kan avsevärt minska maxminnesanvändning och stabilisera bearbetningen av mycket stora presentationer.

**Kan jag använda BLOB‑policyer när jag läser in från strömmar istället för diskfiler?**

Ja. samma regler gäller för strömmar: presentations‑instansen kan äga och låsa inmatningsströmmen (beroende på valt låsläge), och temporära filer används när det är tillåtet, vilket håller minnesanvändningen förutsägbar under bearbetning.