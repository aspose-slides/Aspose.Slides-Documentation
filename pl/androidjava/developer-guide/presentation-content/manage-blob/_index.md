---
title: Zarządzanie BLOB‑ami prezentacji na Androidzie dla efektywnego użycia pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla Androida za pomocą Java, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę opartą na BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB, aby dodać duże media do prezentacji, wyeksportować duże media z prezentacji oraz ładować duże prezentacje bardziej efektywnie. Wyjaśnia również, jak można używać plików tymczasowych podczas przetwarzania oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub media) zapisywany w formatach binarnych. 

Aspose.Slides for Android via Java pozwala używać BLOB‑ów do obiektów w sposób, który zmniejsza zużycie pamięci przy dużych plikach.

{{% alert title="Info" color="info" %}}
Aby obejść niektóre ograniczenia przy interakcji z strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji za pośrednictwem jej strumienia spowoduje kopiowanie zawartości prezentacji i prowadzić do wolnego ładowania. Dlatego, gdy zamierzasz wczytać dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji, a nie jej strumienia.
{{% /alert %}}

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik przez BLOB do prezentacji**

[Aspose.Slides](/slides/pl/androidjava/) for Java pozwala dodawać duże pliki (w tym przypadku duży plik wideo) za pomocą procesu wykorzystującego BLOB‑y, aby zmniejszyć zużycie pamięci.

Ten przykład w języku Java pokazuje, jak dodać duży plik wideo przy użyciu procesu BLOB do prezentacji:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tworzy nową prezentację, do której zostanie dodane wideo
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Dodajmy wideo do prezentacji - wybraliśmy zachowanie KeepLocked, ponieważ nie zamierzamy
        // uzyskać dostępu do pliku "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Zapisuje prezentację. Podczas gdy duża prezentacja jest generowana, zużycie pamięci
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
Aspose.Slides for Android via Java pozwala na eksportowanie dużych plików (w tym przypadku pliku audio lub wideo) za pomocą procesu wykorzystującego BLOB‑y z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik został załadowany do pamięci komputera. Eksportując plik przy użyciu procesu BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod w języku Java demonstruje opisaną operację:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Blokuje plik źródłowy i NIE ładuje go do pamięci
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// tworzy instancję Presentation, blokując plik "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Zapiszmy każdy film do pliku. Aby zapobiec dużemu zużyciu pamięci, potrzebny jest bufor, który zostanie użyty
    // do przesyłania danych ze strumienia wideo prezentacji do strumienia nowo utworzonego pliku wideo.
    byte[] buffer = new byte[8 * 1024];

    // Iteruje po wideo
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Otwiera strumień wideo prezentacji. Proszę zauważyć, że celowo uniknęliśmy dostępu do właściwości
        // takich jak video.BinaryData - ponieważ ta właściwość zwraca tablicę bajtów zawierającą pełny film, co
        // powoduje ładowanie bajtów do pamięci. Używamy video.GetStream, który zwraca Stream - i nie
        //  wymaga od nas ładowania całego wideo do pamięci.
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

### **Dodaj obraz jako BLOB w prezentacji**
Korzystając z metod interfejsu [**IImageCollection**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) i klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ImageCollection), możesz dodać duży obraz jako strumień, aby był traktowany jako BLOB.

Ten kod w języku Java pokazuje, jak dodać duży obraz przy użyciu procesu BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// tworzy nową prezentację, do której zostanie dodany obraz.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Dodajmy obraz do prezentacji - wybieramy zachowanie KeepLocked, ponieważ nie
		// Nie zamierzamy uzyskać dostępu do pliku "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Zapisuje prezentację. Podczas gdy duża prezentacja jest generowana, zużycie pamięci
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

Zazwyczaj, aby wczytać dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego prezentacja została wczytana) przestaje być używany. 

Weźmy pod uwagę dużą prezentację PowerPoint (large.pptx), która zawiera plik wideo o wielkości 1,5 GB. Standardowa metoda ładowania prezentacji została opisana w tym kodzie Java:

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

Za pomocą procesu wykorzystującego BLOB możesz wczytać dużą prezentację przy minimalnym użyciu pamięci. Ten kod Java opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

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

### **Zmień folder dla plików tymczasowych**

Gdy używany jest proces BLOB, komputer tworzy pliki tymczasowe w domyślnym folderze dla plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania używając `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Kiedy używasz `TempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie. 
{{% /alert %}}

### **Zwolnij obiekty Presentation, aby zwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) jest poprawnie zwalniana, aby pamięć, którą zajmowała, została zwolniona. Wywołaj `dispose()` po zakończeniu korzystania z prezentacji, aby zwolnić niezarządzane zasoby.

```java
Presentation presentation = new Presentation("large.pptx");

// ...przetwarzaj prezentację...
presentation.save("large.pdf", SaveFormat.Pdf);

// Jawnie zwolnij zasoby.
presentation.dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, audio i wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisywania. Te obiekty są zarządzane przez polityki BLOB, które pozwalają kontrolować użycie pamięci i przenoszenie danych do plików tymczasowych w razie potrzeby.

**Gdzie konfiguruje się zasady obsługi BLOB podczas ładowania prezentacji?**

Użyj [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci dla BLOB, zezwalasz lub zakazujesz plików tymczasowych, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zbalansować prędkość względem pamięci?**

Tak. Trzymanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Użyj metody [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), aby uzyskać odpowiednią równowagę dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu niezwykle dużych prezentacji (np. gigabajtowych)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/blobmanagementoptions/) są przeznaczone do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i ustabilizować przetwarzanie bardzo dużych zestawów.

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast plików dyskowych?**

Tak. Same zasady obowiązują przy strumieniach: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy są dozwolone, co utrzymuje przewidywalne zużycie pamięci podczas przetwarzania.