---
title: Zarządzaj BLOB‑ami prezentacji w PHP dla efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides dla PHP via Java, aby usprawnić operacje na plikach PowerPoint i OpenDocument oraz efektywnie obsługiwać prezentacje."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę BLOB‑ów dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci przy pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB‑ach do dodawania dużych mediów do prezentacji, eksportowania dużych mediów z prezentacji oraz bardziej efektywnego ładowania dużych prezentacji. Wyjaśnia także, jak w trakcie przetwarzania można korzystać z plików tymczasowych i jak zmienić folder ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) jest zwykle dużym elementem (zdjęcie, prezentacja, dokument lub media) zapisywanym w formatach binarnych. 

Aspose.Slides for PHP via Java umożliwia użycie BLOB‑ów dla obiektów w sposób redukujący zużycie pamięci, gdy występują duże pliki.

{{% alert title="Info" color="info" %}}
Aby obejść pewne ograniczenia przy interakcji ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji poprzez jej strumień spowoduje skopiowanie zawartości prezentacji i spowolni ładowanie. Dlatego, gdy zamierzasz ładować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji, a nie jej strumienia.
{{% /alert %}}

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik jako BLOB do prezentacji**

[Aspose.Slides](/slides/pl/php-java/) for Java umożliwia dodanie dużych plików (w tym przypadku dużego pliku wideo) przy użyciu procesu obejmującego BLOB, aby zmniejszyć zużycie pamięci.

Ten przykład w Java pokazuje, jak dodać duży plik wideo przy użyciu procesu BLOB do prezentacji:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Tworzy nową prezentację, do której zostanie dodane wideo
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Dodajmy wideo do prezentacji – wybraliśmy zachowanie KeepLocked, ponieważ nie zamierzamy
      # uzyskać dostępu do pliku "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Zapisuje prezentację. Podczas generowania dużej prezentacji zużycie pamięci
      # pozostaje niskie w całym cyklu życia obiektu pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Eksportuj duży plik przy użyciu BLOB z prezentacji**
Aspose.Slides for PHP via Java umożliwia eksportowanie dużych plików (w tym przypadku pliku audio lub wideo) przy użyciu procesu obejmującego BLOB z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik został wczytany do pamięci komputera. Eksportując plik przy użyciu procesu BLOB, utrzymujesz niskie zużycie pamięci.

Ten kod demonstruje opisaną operację:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Blokuje plik źródłowy i NIE ładuje go do pamięci
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Tworzy instancję Presentation, blokuje plik "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Zapiszmy każde wideo do pliku. Aby zapobiec dużemu zużyciu pamięci, potrzebny jest bufor, który będzie używany
    # do przenoszenia danych ze strumienia wideo w prezentacji do strumienia nowo utworzonego pliku wideo.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Przechodzi przez wszystkie wideo
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Otwiera strumień wideo w prezentacji. Proszę zauważyć, że celowo uniknęliśmy dostępu do właściwości
      # takich jak video.BinaryData - ponieważ ta właściwość zwraca tablicę bajtów zawierającą całe wideo, co
      # powoduje załadowanie bajtów do pamięci. Używamy video.GetStream, który zwróci Stream - i nie
      # wymaga od nas załadowania całego wideo do pamięci.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Zużycie pamięci pozostanie niskie niezależnie od rozmiaru wideo lub prezentacji.
    }
    # W razie potrzeby możesz zastosować te same kroki dla plików audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Dodaj obraz jako BLOB do prezentacji**
Przy pomocy metod klasy [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) możesz dodać duży obraz jako strumień, aby był traktowany jako BLOB.

Ten kod PHP pokazuje, jak dodać duży obraz przy użyciu procesu BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # tworzy nową prezentację, do której zostanie dodany obraz.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Dodajmy obraz do prezentacji – wybieramy zachowanie KeepLocked, ponieważ nie
      # zamierzamy uzyskać dostępu do pliku "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Zapisuje prezentację. Podczas generowania dużej prezentacji zużycie pamięci
      # pozostaje niskie w całym cyklu życia obiektu pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Pamięć i duże prezentacje**

Zazwyczaj, aby załadować dużą prezentację, komputery potrzebują dużo pamięci tymczasowej. Cała zawartość prezentacji jest wczytywana do pamięci, a plik, z którego prezentacja została wczytana, przestaje być używany. 

Rozważ dużą prezentację PowerPoint (large.pptx) zawierającą plik wideo o wielkości 1,5 GB. Standardowa metoda ładowania prezentacji jest opisana w tym kodzie PHP:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Jednak metoda ta zużywa około 1,6 GB pamięci tymczasowej. 

### **Ładuj dużą prezentację jako BLOB**

Przy użyciu procesu obejmującego BLOB możesz wczytać dużą prezentację, używając niewiele pamięci. Ten kod PHP opisuje implementację, w której proces BLOB jest używany do wczytania dużego pliku prezentacji (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Zmień folder dla plików tymczasowych**

Kiedy proces BLOB jest używany, komputer tworzy pliki tymczasowe w domyślnym folderze dla plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania przy użyciu `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Kiedy używasz `setTempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć ten folder ręcznie. 
{{% /alert %}}

### **Zwolnij obiekty prezentacji, aby uwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) jest odpowiednio zwolniona, aby pamięć, którą zajmowała, została zwolniona. Wywołaj `dispose()` po zakończeniu pracy z prezentacją, aby uwolnić niezarządzane zasoby.

```php
$presentation = new Presentation("large.pptx");

# ...przetwórz prezentację...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Jawnie zwolnij zasoby.
$presentation->dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**

Duże obiekty binarne, takie jak obrazy, audio i wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisywania. Obiekty te są regulowane przez polityki BLOB, które umożliwiają zarządzanie użyciem pamięci i przenoszenie danych do plików tymczasowych w razie potrzeby.

**Gdzie konfiguruję zasady obsługi BLOB podczas ładowania prezentacji?**

Użyj klasy [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/) wraz z [BlobManagementOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci RAM dla BLOB, zezwalasz lub blokujesz pliki tymczasowe, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.

**Czy ustawienia BLOB wpływają na wydajność i jak zbalansować szybkość względem pamięci?**

Tak. Przechowywanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej operacji do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Użyj metody [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), aby osiągnąć odpowiednią równowagę dla swojego obciążenia i środowiska.

**Czy opcje BLOB pomagają przy otwieraniu wyjątkowo dużych prezentacji (np. gigabajtowych)?**

Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/blobmanagementoptions/) są przeznaczone do takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacznie zmniejszyć szczytowe użycie RAM i ustabilizować przetwarzanie bardzo dużych zestawów slajdów.

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast plików na dysku?**

Tak. Te same zasady dotyczą strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy jest to dozwolone, co utrzymuje przewidywalne zużycie pamięci podczas przetwarzania.