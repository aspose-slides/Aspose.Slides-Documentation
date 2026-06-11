---
title: Zarządzanie BLOB‑ami prezentacji w C++ dla efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/cpp/manage-blob/
keywords:
- duży obiekt
- duży element
- duży plik
- dodaj BLOB
- eksportuj BLOB
- dodaj obraz jako BLOB
- zmniejsz zużycie pamięci
- zużycie pamięci
- duża prezentacja
- plik tymczasowy
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla C++, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże multimedia do prezentacji, eksportować duże multimedia z prezentacji oraz wczytywać duże prezentacje efektywniej. Wyjaśnia również, jak można używać plików tymczasowych podczas przetwarzania oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub multimedia) zapisywany w formacie binarnym.

Aspose.Slides for C++ pozwala korzystać z BLOB‑ów dla obiektów w sposób zmniejszający zużycie pamięci, gdy w grę wchodzą duże pliki.

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik przez BLOB do prezentacji**

[Aspose.Slides](/slides/pl/cpp/) for C++ umożliwia dodanie dużych plików (w tym przypadku dużego pliku wideo) przy użyciu procesu opartego na BLOB, aby zmniejszyć zużycie pamięci.

Ten kod C++ pokazuje, jak dodać duży plik wideo przez proces BLOB do prezentacji:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Tworzy nową prezentację, do której zostanie dodane wideo
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Dodajmy wideo do prezentacji - wybraliśmy zachowanie KeepLocked, ponieważ
// nie zamierzamy uzyskać dostępu do pliku "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Zapisuje prezentację. Podczas generowania dużej prezentacji, zużycie pamięci
// pozostaje niskie podczas całego cyklu życia obiektu pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Eksportuj duży plik przez BLOB z prezentacji**
Aspose.Slides for C++ umożliwia eksportowanie dużych plików (w tym przypadku pliku audio lub wideo) przy użyciu procesu opartego na BLOB z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik przez proces BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod C++ demonstruje opisaną operację:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

//	Tworzy instancję Presentation i blokuje plik "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
//	Zapiszmy każdy film do pliku. Aby zapobiec wysokiemu zużyciu pamięci, potrzebny jest bufor, który będzie używany
//	do przeniesienia danych ze strumienia wideo prezentacji do strumienia nowo utworzonego pliku wideo.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	//	Otwiera strumień wideo prezentacji. Należy zauważyć, że celowo unikaliśmy dostępu do metod
	//	takich jak video->get_BinaryData - ponieważ ta metoda zwraca tablicę bajtów zawierającą pełny film, co powoduje
	//	załadowanie bajtów do pamięci. Używamy video->GetStream, który zwróci Stream - i NIE wymaga
	//	załadowania całego filmu do pamięci.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	//	Zużycie pamięci pozostanie niskie niezależnie od rozmiaru filmu lub prezentacji,
}

//	Jeśli konieczne, możesz zastosować te same kroki dla plików audio.
```

### **Dodaj obraz jako BLOB do prezentacji**
Korzystając z metod interfejsu [**IImageCollection**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_image_collection) oraz klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.image_collection), możesz dodać duży obraz jako strumień, aby był traktowany jako BLOB.

Ten kod C++ pokazuje, jak dodać duży obraz przez proces BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// creates a new presentation to which the image will be added.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Let's add the image to the presentation - we choose KeepLocked behavior because we do
// NOT intend to access the "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Saves the presentation. While a large presentation gets outputted, the memory consumption 
// stays low through the pres object's lifecycle
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Pamięć i duże prezentacje**

Zazwyczaj, aby wczytać dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego została wczytana) przestaje być używany.

Rozważ dużą prezentację PowerPoint (large.pptx), która zawiera plik wideo o rozmiarze 1,5 GB. Standardowa metoda wczytywania prezentacji opisana jest w tym kodzie C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Jednak metoda ta zużywa około 1,6 GB pamięci tymczasowej.

### **Wczytaj dużą prezentację jako BLOB**

Przy użyciu procesu opartego na BLOB możesz wczytać dużą prezentację przy minimalnym zużyciu pamięci. Ten kod C++ opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Zmień folder dla plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym folderze przeznaczonym na pliki tymczasowe. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania za pomocą `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Kiedy używasz `TempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć ten folder ręcznie.
{{% /alert %}}

### **Zwolnij obiekty prezentacji, aby zwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) jest prawidłowo zwalniana, aby zwolnić zajętą pamięć. Wywołaj `Dispose()` po zakończeniu pracy z prezentacją, aby zwolnić niezarządzane zasoby.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...przetwarzaj prezentację...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Jawnie zwolnij zasoby.
presentation->Dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, audio oraz wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB przy jego wczytywaniu lub zapisywaniu. Obiekty te są zarządzane przez polityki BLOB, które umożliwiają kontrolowanie użycia pamięci oraz przechodzenie do plików tymczasowych w razie potrzeby.

**Gdzie konfiguruje się zasady obsługi BLOB podczas wczytywania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/) z [BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB, zezwalasz lub zakazujesz plików tymczasowych, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak wyważyć szybkość kontra pamięć?**

Tak. Trzymanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi większą część pracy do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Użyj metody [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/), aby uzyskać właściwą równowagę dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu ekstremalnie dużych prezentacji (np. gigabajtowych)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/blobmanagementoptions/) są przeznaczone do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i stabilizować przetwarzanie bardzo dużych zestawów slajdów.

**Czy mogę stosować zasady BLOB przy ładowaniu z strumieni zamiast plików dyskowych?**

Tak. Te same zasady dotyczą strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, co utrzymuje przewidywalne zużycie pamięci podczas przetwarzania.