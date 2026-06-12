---
title: Beheer presentatie‑BLOB’s in C++ voor efficiënt geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Beheer BLOB‑gegevens in Aspose.Slides voor C++ om PowerPoint‑ en OpenDocument‑bestandsbewerkingen te stroomlijnen voor efficiënt presentatiebeheer."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugengebruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatie‑bestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking kunt gebruiken om grote media aan een presentatie toe te voegen, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot item (foto, presentatie, document of media) dat is opgeslagen in binaire formaten.

Aspose.Slides for C++ stelt u in staat BLOB’s te gebruiken voor objecten op een manier die het geheugengebruik vermindert wanneer grote bestanden betrokken zijn.

## **BLOB gebruiken om geheugengebruik te verminderen**

### **Een groot bestand via BLOB aan een presentatie toevoegen**

[Aspose.Slides](/slides/nl/cpp/) for C++ stelt u in staat grote bestanden (in dit geval een groot videobestand) via een proces met BLOB’s toe te voegen om het geheugengebruik te verminderen.

Deze C++ code toont hoe u een groot videobestand via het BLOB‑proces aan een presentatie kunt toevoegen:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Creëert een nieuwe presentatie waaraan de video zal worden toegevoegd
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Laten we de video aan de presentatie toevoegen - we hebben gekozen voor het KeepLocked‑gedrag omdat we
// niet van plan zijn het bestand "veryLargeVideo.avi" te openen.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, blijft het geheugengebruik
// laag gedurende de levenscyclus van het pres‑object 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Een groot bestand via BLOB uit een presentatie exporteren**
Aspose.Slides for C++ stelt u in staat grote bestanden (in dit geval een audio‑ of videobestand) via een proces met BLOB’s uit presentaties te exporteren. Bijvoorbeeld, u wilt een groot mediabestand uit een presentatie halen zonder dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren, blijft het geheugengebruik laag.

Deze code in C++ demonstreert de beschreven bewerking:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Creëert een instantie van Presentation, vergrendelt het bestand "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Laten we elke video naar een bestand opslaan. Om hoog geheugengebruik te voorkomen, hebben we een buffer nodig die zal worden gebruikt
// om de gegevens van de videostream van de presentatie over te dragen naar een stream voor een nieuw aangemaakt videobestand.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Opent de videostream van de presentatie. Let op, we hebben opzettelijk vermeden om methoden
	// zoals video->get_BinaryData - omdat deze methode een byte‑array retourneert die een volledige video bevat, wat vervolgens
	// bytes laadt in het geheugen. We gebruiken video->GetStream, die een Stream retourneert - en VOOR
	// niet vereist dat we de volledige video in het geheugen laden.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Het geheugengebruik zal laag blijven, ongeacht de grootte van de video of presentatie,
}

// Indien nodig kunt u dezelfde stappen toepassen voor audiobestanden.
```

### **Een afbeelding als BLOB aan een presentatie toevoegen**
Met methoden van de [**IImageCollection**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) interface en de [**ImageCollection**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.image_collection) klasse kunt u een grote afbeelding als stream toevoegen zodat deze als BLOB wordt behandeld.

Deze C++ code toont hoe u een grote afbeelding via het BLOB‑proces kunt toevoegen:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// maakt een nieuwe presentatie waaraan de afbeelding zal worden toegevoegd.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Laten we de afbeelding aan de presentatie toevoegen - we kiezen KeepLocked-gedrag omdat we
// NIET van plan zijn om het bestand "largeImage.png" te openen.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, blijft het geheugengebruik 
// laag gedurende de levenscyclus van het pres‑object
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Geheugen en grote presentaties**

Typisch, om een grote presentatie te laden, hebben computers veel tijdelijk geheugen nodig. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waarvan de presentatie werd geladen) wordt niet meer gebruikt.

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een video‑bestand van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt beschreven in deze C++ code:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Maar deze methode gebruikt ongeveer 1,6 GB tijdelijk geheugen.

### **Een grote presentatie als BLOB laden**

Via het proces met een BLOB kunt u een grote presentatie laden terwijl u weinig geheugen gebruikt. Deze C++ code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentatiebestand (large.pptx) te laden:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **De map voor tijdelijke bestanden wijzigen**

Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u wilt dat de tijdelijke bestanden in een andere map worden bewaard, kunt u de instellingen voor opslag wijzigen met `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Wanneer u `TempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken. 
{{% /alert %}}

### **Presentatieobjecten vrijgeven om geheugen vrij te maken**

Wanneer u grote presentaties verwerkt, zorg er dan voor dat de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie correct wordt vrijgegeven zodat het gealloceerde geheugen wordt vrijgegeven. Roep `Dispose()` aan nadat u klaar bent met het gebruiken van de presentatie om onbeheerste bronnen vrij te maken.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...verwerk de presentatie...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Geef expliciet de bronnen vrij.
presentation->Dispose();
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het hele presentatie‑bestand wordt ook via BLOB verwerkt wanneer het wordt geladen of opgeslagen. Deze objecten worden beheerd door BLOB‑beleidsregels die u in staat stellen het geheugengebruik te beheren en, indien nodig, naar tijdelijke bestanden uit te schrijven.

**Waar configureer ik de BLOB‑verwerkingsregels tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/) met [BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/blobmanagementoptions/). Daar stelt u de in‑memory limiet voor BLOB in, staat u tijdelijke bestanden toe of niet, kiest u het hoofdpad voor tijdelijke bestanden, en selecteert u het gedrag voor source‑locking.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe balanseer ik snelheid versus geheugen?**

Ja. Het in‑memory houden van BLOB maximaliseert de snelheid maar verhoogt het RAM‑gebruik; een lagere geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Gebruik de methode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) om de juiste balans te vinden voor uw workload en omgeving.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijvoorbeeld gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/blobmanagementoptions/) zijn ontworpen voor dergelijke scenario's: het inschakelen van tijdelijke bestanden en het gebruiken van source‑locking kan het piek‑RAM‑gebruik aanzienlijk verlagen en de verwerking stabiliseren voor zeer grote decks.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van schijf‑bestanden?**

Ja. Dezelfde regels gelden voor streams: de presentatie‑instantie kan de invoer‑stream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer toegestaan, waardoor het geheugengebruik voorspelbaar blijft tijdens de verwerking.