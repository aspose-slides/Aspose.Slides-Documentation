---
title: Konwertowanie PPT i PPTX do JPG w PHP
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/php-java/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do JPG
- prezentacja do JPG
- slajd do JPG
- PPT do JPG
- PPTX do JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- PHP
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na obrazy JPG wysokiej jakości w PHP przy użyciu Aspose.Slides for PHP, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu treści w witrynach internetowych lub aplikacjach. Aspose.Slides umożliwia przekształcenie plików PPTX, PPT i ODP w obrazy JPEG wysokiej jakości. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo jest zaimplementować własny podgląd prezentacji i utworzyć miniaturę dla każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub przedstawić prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub wybrany slajd do formatów obrazów.

## **Konwertowanie PowerPoint PPT/PPTX do JPG**

1. Utwórz instancję typu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Pobierz obiekt slajdu typu [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/) z kolekcji [Presentation::getSlides()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#getSlides--).
3. Utwórz miniaturę każdego slajdu, a następnie przekonwertuj ją na JPG. Metoda [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage) jest używana do uzyskania miniatury slajdu. Metodę [getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage) należy wywołać na wybranym slajdzie typu [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/), a skalowanie wynikowej miniatury przekazywane jest jako argumenty.
4. Po uzyskaniu miniatury slajdu wywołaj metodę [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) na obiekcie miniatury. Przekaż nazwę pliku wyjściowego oraz format obrazu.

{{% alert color="primary" %}}
**Uwaga**: konwersja PPT/PPTX do JPG różni się od konwersji do innych typów w API Aspose.Slides. Dla innych typów zazwyczaj używa się metody [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/save/), ale tutaj potrzebna jest metoda [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Tworzy obraz w pełnej skali
      $slideImage = $sld->getImage(1.0, 1.0);
      # Zapisuje obraz na dysku w formacie JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konwertowanie PowerPoint PPT/PPTX do JPG z niestandardowymi wymiarami**

Aby zmienić wymiary wynikowej miniatury i obrazu JPG, możesz ustawić wartości *ScaleX* i *ScaleY*, przekazując je do metod [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definiuje wymiary
    $desiredX = 1200;
    $desiredY = 800;
    # Pobiera przeskalowane wartości X i Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Tworzy obraz w pełnej skali
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Zapisuje obraz na dysku w formacie JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Renderowanie komentarzy przy zapisywaniu slajdów jako obrazy**

Aspose.Slides for PHP via Java udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas ich konwertowania na obrazy. Ten kod PHP demonstruje działanie:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose udostępnia [DARMOWĄ aplikację Collage w sieci](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej.

Używając tych samych zasad opisanych w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Aby uzyskać więcej informacji, zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/php-java/conversion/image-to-jpg/); konwertuj [JPG na obraz](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-image/); konwertuj [JPG na PNG](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-png/), konwertuj [PNG na JPG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-jpg/); konwertuj [PNG na SVG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-svg/), konwertuj [SVG na PNG](https://products.aspose.com/slides/pl/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne elementy. Dokładność renderowania może nieznacznie różnić się od PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

**Czy istnieją ograniczenia liczby slajdów, które można przetworzyć?**

Aspose.Slides nie narzuca sztywnych limitów liczby slajdów, które można przetworzyć. Jednak przy dużych prezentacjach lub obrazach wysokiej rozdzielczości może wystąpić błąd braku pamięci.

## **Zobacz także**

Zobacz inne opcje konwersji PPT/PPTX na obraz, takie jak:

- [Konwersja PPT/PPTX do SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/).