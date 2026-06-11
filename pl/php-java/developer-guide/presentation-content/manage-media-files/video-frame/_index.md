---
title: Zarządzanie ramkami wideo w prezentacjach przy użyciu PHP
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/php-java/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębnij wideo
- pobierz wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP w środowisku Java. Szybki przewodnik instruktażowy."
---
## **Wprowadzenie**

Dobrze dobrane wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców.  

PowerPoint pozwala na dodanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia klasy [Video](https://reference.aspose.com/slides/pl/php-java/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) , oraz inne powiązane typy.

## **Utwórz osadzone ramki wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu poprzez jego indeks. 
3. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/php-java/aspose.slides/video/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
4. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) , aby utworzyć ramkę dla wideo. 
5. Zapisz zmodyfikowaną prezentację. 

Ten kod PHP pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Ładuje wideo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Pobiera pierwszy slajd i dodaje ramkę wideo
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Zapisuje prezentację na dysku
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternatywnie możesz dodać wideo, przekazując jego ścieżkę bezpośrednio do metody [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Utwórz ramki wideo z wideo ze źródeł internetowych**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą linku internetowego.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu poprzez jego indeks. 
3. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/php-java/aspose.slides/video/) i przekaż link do wideo. 
4. Ustaw miniaturkę dla ramki wideo. 
5. Zapisz prezentację. 

Ten kod PHP pokazuje, jak dodać wideo z sieci do slajdu w prezentacji PowerPoint:

```php
  # Tworzy obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Zarządzaj napisami wideo**

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Dodaj napisy do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Dodaj wideo do prezentacji. 
3. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) do slajdu. 
4. Użyj kolekcji [CaptionsCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/) , zwróconej przez [getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/#getCaptionTracks) , aby dodać ścieżkę napisów WebVTT. 
5. Zapisz zmodyfikowaną prezentację. 

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Dodaje nową ścieżkę napisów z pliku WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/) oferuje również przeciążenie, które pozwala dodać napisy ze strumienia.

**Wyodrębnij napisy z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Wczytaj prezentację, która zawiera wideo. 
2. Znajdź docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) . 
3. Iteruj przez kolekcję [getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/#getCaptionTracks) . 
4. Zapisz każdą ścieżkę napisów do pliku `.vtt` . 

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Zapisuje ścieżkę napisów do pliku WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF-8.

**Usuń napisy z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Wczytaj prezentację, która zawiera wideo. 
2. Uzyskaj docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) . 
3. Usuń ścieżki napisów z kolekcji [getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/#getCaptionTracks) . 
4. Zapisz zmodyfikowaną prezentację. 

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // typ: VideoFrame

    // Usuwa wszystkie napisy z ramki wideo.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#clear) .

## **Wyodrębnij wideo ze slajdów**

Oprócz dodawania wideo do slajdów, Aspose.Slides pozwala wyodrębnić wideo osadzone w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) aby wczytać prezentację zawierającą wideo. 
2. Iteruj przez wszystkie obiekty [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/) . 
3. Iteruj przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) w celu znalezienia [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) . 
4. Zapisz wideo na dysku. 

Ten kod PHP pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```php
  # Tworzy obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Pobiera rozszerzenie pliku
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/setplaymode/) (automatyczny lub po kliknięciu) oraz [pętlę odtwarzania](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/setplayloopmode/) . Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodajesz wideo online, osadzany jest link i miniaturka, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącej VideoFrame bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/videoframe/setembeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ zawartości](https://reference.aspose.com/slides/pl/php-java/aspose.slides/video/getcontenttype/) , który możesz odczytać i wykorzystać, np. przy zapisywaniu na dysku.