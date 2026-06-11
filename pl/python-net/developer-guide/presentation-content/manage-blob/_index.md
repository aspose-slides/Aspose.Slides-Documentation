---
title: Zarządzanie BLOB-ami w prezentacjach przy użyciu Python dla efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/python-net/manage-blob/
keywords:
- duży obiekt
- duży element
- duży plik
- dodaj BLOB
- eksportuj BLOB
- dodaj obraz jako BLOB
- zmniejsz pamięć
- zużycie pamięci
- duża prezentacja
- plik tymczasowy
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla Pythona via .NET, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę opartą na BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękami, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże media do prezentacji, eksportować duże media z prezentacji oraz ładować duże prezentacje bardziej efektywnie. Wyjaśnia również, jak w trakcie przetwarzania można używać plików tymczasowych oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub media) zapisywany w formatach binarnych.

Aspose.Slides for Python via .NET pozwala używać BLOB‑ów dla obiektów w sposób, który zmniejsza zużycie pamięci, gdy występują duże pliki.

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik poprzez BLOB do prezentacji**

[Aspose.Slides](/slides/pl/python-net/) for .NET pozwala dodać duże pliki (w tym przypadku duży plik wideo) za pomocą procesu obejmującego BLOB‑y, aby zmniejszyć zużycie pamięci.

Ten przykład w Pythonie pokazuje, jak dodać duży plik wideo poprzez proces BLOB do prezentacji:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Tworzy nową prezentację, do której zostanie dodane wideo
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Dodajmy wideo do prezentacji - wybraliśmy zachowanie KeepLocked, ponieważ
        # nie zamierzamy uzyskiwać dostępu do pliku "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Zapisuje prezentację. Podczas gdy duża prezentacja jest generowana, zużycie pamięci
        # pozostaje niskie przez cały cykl życia obiektu pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Eksportuj duży plik poprzez BLOB z prezentacji**

Aspose.Slides for Python via .NET pozwala eksportować duże pliki (w tym przypadku plik audio lub wideo) za pomocą procesu obejmującego BLOB‑y z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik poprzez proces BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod w Pythonie demonstruje opisane działanie:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Zapiszmy każdy film do pliku. Aby zapobiec wysokiemu zużyciu pamięci, potrzebny jest bufor, który zostanie użyty
	# do przeniesienia danych ze strumienia wideo prezentacji do strumienia dla nowo utworzonego pliku wideo.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Iteruje przez filmy
    index = 0
    # W razie potrzeby możesz zastosować te same kroki dla plików audio. 
    for video in pres.videos:
		# Otwiera strumień wideo prezentacji. Proszę zauważyć, że celowo unikaliśmy dostępu do właściwości
		# takich jak video.BinaryData - ponieważ ta właściwość zwraca tablicę bajtów zawierającą pełne wideo, co potem
		# powoduje wczytywanie bajtów do pamięci. Używamy video.GetStream, które zwróci Stream - i NIE
		#  wymaga od nas wczytania całego wideo do pamięci.
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

### **Dodaj obraz jako BLOB w prezentacji**

Za pomocą metod z klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) możesz dodać duży obraz jako strumień, aby został potraktowany jako BLOB.

Ten kod w Pythonie pokazuje, jak dodać duży obraz poprzez proces BLOB:

```py
import aspose.slides as slides

# tworzy nową prezentację, do której zostanie dodany obraz.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Pamięć i duże prezentacje**

Zazwyczaj, aby załadować dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego prezentacja została wczytana) przestaje być używany.

Weźmy pod uwagę dużą prezentację PowerPoint (large.pptx), która zawiera 1,5 GB plik wideo. Standardowa metoda ładowania prezentacji jest opisana w tym kodzie w Pythonie:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Jednak ta metoda zużywa około 1,6 GB pamięci tymczasowej.

### **Załaduj dużą prezentację jako BLOB**

Poprzez proces obejmujący BLOB możesz załadować dużą prezentację przy minimalnym użyciu pamięci. Ten kod w Pythonie opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Zmień folder dla plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym folderze dla plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania, używając `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Podczas używania `temp_files_root_path`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie. 
{{% /alert %}}

### **Zwolnij obiekty prezentacji, aby zwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) jest prawidłowo zwalniana, aby pamięć, którą zajmowała, została zwolniona. Zalecanym sposobem jest użycie menedżera kontekstu (`with slides.Presentation(...) as presentation:`) tak jak pokazano w powyższych przykładach; automatycznie zamyka prezentację i zwalnia zasoby niezarządzane po zakończeniu bloku.

Jeśli tworzysz prezentację bez bloku `with`, wywołaj explicite `presentation.dispose()` po zakończeniu jej używania oraz usuń wszystkie pozostałe odwołania, aby mechanizm zbierania śmieci Pythona mógł odzyskać pamięć.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...przetwórz prezentację...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Jawnie zwolnij zasoby.
presentation.dispose()
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, dźwięki i wideo, są traktowane jako BLOB. Pełny plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisywania. Obiekty te są zarządzane przez polityki BLOB, które pozwalają kontrolować użycie pamięci i przechowywać dane w plikach tymczasowych w razie potrzeby.

**Gdzie konfiguruje się reguły obsługi BLOB podczas ładowania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB w pamięci, zezwalasz lub zabraniasz plików tymczasowych, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zrównoważyć szybkość względem pamięci?**

Tak. Przechowywanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Dostosuj próg [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/pl/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/), aby osiągnąć właściwą równowagę dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu wyjątkowo dużych prezentacji (np. kilku gigabajtów)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/blobmanagementoptions/) są przeznaczone do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacznie obniżyć szczytowe użycie RAM i ustabilizować przetwarzanie bardzo dużych zestawów slajdów.

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast plików dyskowych?**

Tak. Te same zasady obowiązują dla strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, co utrzymuje przewidywalne użycie pamięci podczas przetwarzania.