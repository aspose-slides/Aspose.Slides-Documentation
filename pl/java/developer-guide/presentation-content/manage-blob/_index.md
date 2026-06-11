---
title: Zarządzanie BLOB-ami prezentacji w Java w celu efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla Java, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę BLOB‑ów dla dużych danych binarnych w prezentacjach, pomagając zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże multimedia do prezentacji, wyeksportować duże multimedia z prezentacji oraz wczytać duże prezentacje bardziej efektywnie. Wyjaśnia również, jak można używać plików tymczasowych podczas przetwarzania oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub multimedia) zapisywany w formacie binarnym.

Aspose.Slides for Java umożliwia użycie BLOB‑ów dla obiektów w sposób, który zmniejsza zużycie pamięci, gdy zaangażowane są duże pliki.

{{% alert title="Info" color="info" %}}

Aby obejść pewne ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Wczytanie dużej prezentacji ze strumienia spowoduje skopiowanie jej zawartości i uczyni ładowanie wolnym. Dlatego, gdy zamierzasz wczytać dużą prezentację, zdecydowanie zalecamy użycie ścieżki pliku prezentacji, a nie jej strumienia.

{{% /alert %}}

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik przez BLOB do prezentacji**

[Aspose.Slides](/slides/pl/java/) for Java umożliwia dodanie dużych plików (w tym przypadku dużego pliku wideo) przy użyciu procesu opartego na BLOB, aby zmniejszyć zużycie pamięci.

Ten przykład w Javie pokazuje, jak dodać duży plik wideo przez proces BLOB do prezentacji:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tworzy nową prezentację, do której zostanie dodane wideo
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Dodajmy wideo do prezentacji – wybraliśmy zachowanie KeepLocked, ponieważ
        // nie zamierzamy uzyskiwać dostępu do pliku "veryLargeVideo.avi" file.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Zapisuje prezentację. Podczas generowania dużej prezentacji zużycie pamięci
        // pozostaje niskie przez cały cykl życia obiektu pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Eksportuj duży plik przez BLOB z prezentacji**

Aspose.Slides for Java umożliwia eksportowanie dużych plików (np. pliku audio lub wideo) przy użyciu procesu opartego na BLOB z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik przez proces BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod w Javie demonstruje opisaną operację:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Blokuje plik źródłowy i nie ładuje go do pamięci
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Utwórz instancję klasy Presentation i zablokuj plik "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Zapiszmy każde wideo do pliku. Aby zapobiec dużemu zużyciu pamięci, potrzebny jest bufor, który będzie używany
    // do przeniesienia danych ze strumienia wideo prezentacji do strumienia nowo utworzonego pliku wideo.
    byte[] buffer = new byte[8 * 1024];

    // Iteruje przez wszystkie wideo
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Otwiera strumień wideo prezentacji. Należy zauważyć, że celowo unikaliśmy dostępu do właściwości
        // takich jak video.BinaryData – ponieważ ta właściwość zwraca tablicę bajtów zawierającą pełne wideo, co
        // powoduje załadowanie bajtów do pamięci. Używamy video.GetStream, który zwraca Stream – i nie
        //  nie wymaga od nas załadowania całego wideo do pamięci.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Zużycie pamięci pozostanie niskie niezależnie od rozmiaru wideo lub prezentacji.
    }
    // W razie potrzeby możesz zastosować te same kroki dla plików audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Dodaj obraz jako BLOB do prezentacji**

Za pomocą metod z interfejsu [**IImageCollection**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImageCollection) oraz klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ImageCollection) możesz dodać duży obraz jako strumień, aby był traktowany jako BLOB.

Ten kod w Javie pokazuje, jak dodać duży obraz przez proces BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// tworzy nową prezentację, do której zostanie dodany obraz.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Dodajmy obraz do prezentacji – wybieramy zachowanie KeepLocked, ponieważ
		// NIE zamierzamy uzyskiwać dostępu do pliku "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Zapisuje prezentację. Podczas generowania dużej prezentacji zużycie pamięci
		// pozostaje niskie przez cały cykl życia obiektu pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Pamięć i duże prezentacje**

Typowo, aby wczytać dużą prezentację, komputery wymagają dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego prezentacja została wczytana) przestaje być używany.

Rozważ dużą prezentację PowerPoint (large.pptx), która zawiera 1,5 GB plik wideo. Standardowa metoda wczytywania prezentacji jest przedstawiona w tym kodzie Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Jednak metoda ta zużywa około 1,6 GB pamięci tymczasowej.

### **Wczytaj dużą prezentację jako BLOB**

Poprzez proces wykorzystujący BLOB możesz wczytać dużą prezentację używając mało pamięci. Ten kod Java opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Zmień folder plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym folderze plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania za pomocą `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Kiedy używasz `TempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie.

{{% /alert %}}

### **Zwolnij obiekty prezentacji, aby zwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) jest prawidłowo zwalniana, aby pamięć, którą zajmowała, została uwolniona. Wywołaj `dispose()` po zakończeniu pracy z prezentacją, aby zwolnić niezarządzane zasoby.

```java
Presentation presentation = new Presentation("large.pptx");

// ...przetwarzaj prezentację...
presentation.save("large.pdf", SaveFormat.Pdf);

// Jawnie zwolnij zasoby.
presentation.dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, audio i wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisywania. Obiekty te są zarządzane przez polityki BLOB, które pozwalają kontrolować zużycie pamięci i przechowywanie w plikach tymczasowych w razie potrzeby.

**Gdzie konfiguruje się zasady obsługi BLOB podczas ładowania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB, zezwalasz lub nie na pliki tymczasowe, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zbalansować szybkość wobec pamięci?**

Tak. Trzymanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Użyj metody [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) aby uzyskać właściwy balans dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu niezwykle dużych prezentacji (np. gigabajty)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/blobmanagementoptions/) są zaprojektowane do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i ustabilizować przetwarzanie bardzo dużych zestawów slajdów.

**Czy mogę stosować zasady BLOB przy ładowaniu ze strumieni zamiast plików dyskowych?**

Tak. Te same zasady obowiązują dla strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, utrzymując przewidywalne zużycie pamięci podczas przetwarzania.