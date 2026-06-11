---
title: Zarządzanie BLOB‑ami prezentacji w JavaScript dla efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj danymi BLOB w JavaScript przy użyciu Aspose.Slides dla Node.js, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże media do prezentacji, wyeksportować duże media z prezentacji oraz ładować duże prezentacje bardziej wydajnie. Wyjaśnia również, jak można wykorzystać pliki tymczasowe podczas przetwarzania oraz jak zmienić katalog, w którym są przechowywane.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub media) zapisany w formacie binarnym.

Aspose.Slides for Node.js via Java umożliwia użycie BLOB‑ów dla obiektów w sposób zmniejszający zużycie pamięci, gdy pracuje się z dużymi plikami.

{{% alert title="Info" color="info" %}}
Aby obejść niektóre ograniczenia przy pracy z strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji przez jej strumień spowoduje kopiowanie zawartości prezentacji i wolniejsze ładowanie. Dlatego, gdy zamierzasz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji, a nie jej strumienia.
{{% /alert %}}

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik przez BLOB do prezentacji**

[Aspose.Slides](/slides/pl/nodejs-java/) for Node.js via Java umożliwia dodanie dużych plików (w tym przypadku dużego pliku wideo) poprzez proces wykorzystujący BLOB‑y, aby zmniejszyć zużycie pamięci.

Ten kod JavaScript pokazuje, jak dodać duży plik wideo poprzez proces BLOB do prezentacji:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Tworzy nową prezentację, do której zostanie dodane wideo
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Dodajmy wideo do prezentacji - wybraliśmy zachowanie KeepLocked, ponieważ
        // nie zamierzamy uzyskiwać dostępu do pliku "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Zapisuje prezentację. Podczas generowania dużej prezentacji, zużycie pamięci
        // pozostaje niskie przez cały cykl życia obiektu pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Eksportuj duży plik przez BLOB z prezentacji**

Aspose.Slides for Node.js via Java umożliwia eksportowanie dużych plików (na przykład pliku audio lub wideo) poprzez proces oparty na BLOB‑ach z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik mediów z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik przez proces BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod JavaScript demonstruje opisane działanie:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Blokuje plik źródłowy i NIE ładuje go do pamięci
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// tworzy instancję Presentation i blokuje plik "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Zapiszmy każdy film do pliku. Aby zapobiec wysokiemu zużyciu pamięci, potrzebny jest bufor, który zostanie użyty
    // do przeniesienia danych ze strumienia wideo prezentacji do strumienia nowo utworzonego pliku wideo.
    var buffer = new byte[8 * 1024];
    // Iteruje przez wideo
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Otwiera strumień wideo z prezentacji. Proszę zauważyć, że celowo unikaliśmy dostępu do właściwości
        // takich jak video.BinaryData - ponieważ ta właściwość zwraca tablicę bajtów zawierającą całe wideo, co
        // powoduje załadowanie bajtów do pamięci. Używamy video.GetStream, który zwróci Stream - i NIE
        // wymaga od nas załadowania całego wideo do pamięci.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Zużycie pamięci pozostanie niskie, niezależnie od rozmiaru wideo lub prezentacji.
    }
    // W razie potrzeby możesz zastosować te same kroki dla plików audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Dodaj obraz jako BLOB w prezentacji**

Za pomocą metod z klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) oraz [**ImageCollection**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) możesz dodać duży obraz jako strumień, aby został potraktowany jako BLOB.

Ten kod JavaScript pokazuje, jak dodać duży obraz poprzez proces BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// tworzy nową prezentację, do której zostanie dodany obraz.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Dodajmy obraz do prezentacji - wybieramy zachowanie KeepLocked, ponieważ nie zamierzamy
        // uzyskać dostępu do pliku "largeImage.png".
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Zapisuje prezentację. Podczas generowania dużej prezentacji zużycie pamięci
        // pozostaje niskie w całym cyklu życia obiektu pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Pamięć i duże prezentacje**

Zwykle, aby załadować dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik, z którego prezentacja została wczytana, przestaje być używany.

Weźmy pod uwagę dużą prezentację PowerPoint (large.pptx), zawierającą plik wideo o rozmiarze 1,5 GB. Standardowa metoda ładowania prezentacji jest przedstawiona w tym kodzie JavaScript:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Jednak ta metoda zużywa około 1,6 GB pamięci tymczasowej.

### **Załaduj dużą prezentację jako BLOB**

Poprzez proces wykorzystujący BLOB możesz wczytać dużą prezentację, używając niewiele pamięci. Ten kod JavaScript opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Zmień folder dla plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym katalogu plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania za pomocą `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Kiedy używasz `setTempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie.
{{% /alert %}}

### **Uwalnianie obiektów prezentacji w celu zwolnienia pamięci**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) jest prawidłowo zwalniana, aby pamięć, którą zajmowała, została zwolniona. Wywołaj `dispose()` po zakończeniu pracy z prezentacją, aby zwolnić niezarządzane zasoby.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, dźwięk i wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisu. Obiekty te są zarządzane przez polityki BLOB, które pozwalają kontrolować zużycie pamięci i przenoszenie danych do plików tymczasowych w razie potrzeby.

**Gdzie konfiguruje się reguły obsługi BLOB podczas ładowania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB, zezwalasz lub blokujesz pliki tymczasowe, określasz ścieżkę główną dla plików tymczasowych oraz wybierasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zrównoważyć szybkość kontra pamięć?**

Tak. Trzymanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy na pliki tymczasowe, zmniejszając RAM kosztem dodatkowego I/O. Skorzystaj z metody [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), aby osiągnąć odpowiednią równowagę dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu niezwykle dużych prezentacji (np. gigabajtowych)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/blobmanagementoptions/) są przeznaczone do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i ustabilizować przetwarzanie bardzo dużych zestawów slajdów.

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast plików dyskowych?**

Tak. Te same reguły obowiązują dla strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, co utrzymuje przewidywalne zużycie pamięci podczas przetwarzania.