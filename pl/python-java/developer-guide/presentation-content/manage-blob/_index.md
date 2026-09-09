---
title: Z zarządzanie BLOB-ami prezentacji w Pythonie przy użyciu Java w celu efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/python-java/manage-blob/
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
- Java
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla Pythona przy użyciu Java, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę opartą na BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże multimedia do prezentacji, wyeksportować duże multimedia z prezentacji oraz ładować duże prezentacje bardziej efektywnie. Wyjaśnia także, jak w trakcie przetwarzania można wykorzystywać pliki tymczasowe oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub multimedia) zapisywany w formatach binarnych.

Aspose.Slides for Python via Java pozwala używać BLOB‑ów dla obiektów w sposób zmniejszający zużycie pamięci, gdy pracujemy z dużymi plikami.

{{% alert color="info" title="Uwaga" %}}
Aby obejść pewne ograniczenia przy interakcji ze strumieniami, Aspose.Slides może skopiować zawartość strumienia. Ładowanie dużej prezentacji poprzez jej strumień spowoduje kopiowanie zawartości prezentacji i prowadzi do wolnego ładowania. Dlatego, gdy zamierzasz ładować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji, a nie jej strumienia.
{{% /alert %}}

## **Używanie BLOBów w celu zmniejszenia zużycia pamięci**

### **Dodanie dużego pliku do prezentacji przy użyciu BLOBów**

[Aspose.Slides](/slides/pl/python-java/) for Python via Java pozwala dodać duże pliki (w tym przypadku duży plik wideo) w procesie z wykorzystaniem BLOB‑ów, aby zmniejszyć zużycie pamięci.

Ten kod w Pythonie pokazuje, jak dodać duży plik wideo poprzez proces BLOB do prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Utwórz nową prezentację, do której zostanie dodane wideo.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Zachowaj strumień zablokowany, ponieważ nie zamierzamy uzyskiwać dostępu do pliku wideo.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Zapisz prezentację, utrzymując niskie zużycie pamięci.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Eksport dużego pliku z prezentacji przy użyciu BLOBów**

Aspose.Slides for Python via Java umożliwia eksport dużych plików (w tym przypadku pliku audio lub wideo) w procesie z wykorzystaniem BLOB‑ów z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik przez proces BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod w Pythonie demonstruje opisaną operację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Zablokuj plik źródłowy zamiast ładować go do pamięci.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Przesyłaj dane wideo przez bufor, aby utrzymać niskie zużycie pamięci.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Użyj strumienia zamiast ładować całe wideo do tablicy bajtów.
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
    # W razie potrzeby zastosuj te same kroki do plików audio.
finally:
    presentation.dispose()
```

### **Dodanie obrazu jako BLOB do prezentacji**

Za pomocą metod klasy [ImageCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/) możesz dodać duży obraz jako strumień, aby był traktowany jako BLOB.

Ten kod w Pythonie pokazuje, jak dodać duży obraz poprzez proces BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Utwórz nową prezentację, do której zostanie dodany obraz.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Zachowaj strumień zablokowany, ponieważ nie zamierzamy uzyskać dostępu do pliku obrazu.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Zapisz prezentację, utrzymując niskie zużycie pamięci.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Pamięć i duże prezentacje**

Typowo, aby załadować dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego prezentacja została załadowana) przestaje być używany.

Rozważ dużą prezentację PowerPoint (large.pptx), która zawiera plik wideo o wielkości 1,5 GB. Standardowa metoda ładowania prezentacji jest opisana w tym kodzie Python:

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

Jednak metoda ta zużywa około 1,6 GB pamięci tymczasowej.

### **Ładowanie dużej prezentacji jako BLOB**

Korzystając z obsługi BLOB, możesz załadować dużą prezentację przy bardzo małym zużyciu pamięci. Ten kod w Pythonie pokazuje, jak używać obsługi BLOB do ładowania dużego pliku prezentacji (large.pptx):

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

### **Zmiana folderu dla plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym folderze plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania używając [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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

{{% alert color="info" title="Uwaga" %}}
Gdy używasz [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie.
{{% /alert %}}

### **Zwolnienie obiektów prezentacji w celu zwolnienia pamięci**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) jest prawidłowo zwalniana, aby pamięć, którą zajmowała, została zwolniona. Wywołaj [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose) po zakończeniu używania prezentacji, aby zwolnić niezarządzane zasoby.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...przetwarzaj prezentację...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Jawnie zwolnij zasoby.
    presentation.dispose()
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, audio i wideo, są traktowane jako BLOB‑y. Cały plik prezentacji również podlega obsłudze BLOB przy jego ładowaniu lub zapisywaniu. Obiekty te są zarządzane przez polityki BLOB, które pozwalają kontrolować użycie pamięci i przechowywanie danych w plikach tymczasowych w razie potrzeby.

**Gdzie mogę skonfigurować zasady obsługi BLOB podczas ładowania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB‑ów, zezwalasz lub blokujesz pliki tymczasowe, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zbalansować szybkość versus pamięć?**

Tak. Przechowywanie BLOB‑ów w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy na pliki tymczasowe, redukując RAM kosztem dodatkowego I/O. Użyj metody [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory), aby uzyskać odpowiedni balans dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu niezwykle dużych prezentacji (np. gigabajtowych)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blobmanagementoptions/) jest zaprojektowane właśnie do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i ustabilizować przetwarzanie bardzo dużych prezentacji.

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast z plików dyskowych?**

Tak. Te same zasady obowiązują dla strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, co utrzymuje przewidywalne zużycie pamięci podczas przetwarzania.