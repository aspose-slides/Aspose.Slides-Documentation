---
title: Tworzenie miniatur kształtów prezentacji w PHP
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/php-java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for PHP via Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wstęp**

Aspose.Slides jest używany do tworzenia plików prezentacji, w których każda strona jest slajdem. Te slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak czasami programiści mogą potrzebować wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga wygenerować miniatury obrazów kształtów slajdu. Jak korzystać z tej funkcji, opisano w tym artykule.
Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu z wymiarami zdefiniowanymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for PHP via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz [miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) z referowanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Utwórz obraz w pełnej skali
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Zapisz obraz na dysku w formacie PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generowanie miniatury z określonym przez użytkownika współczynnikiem skalowania**
Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for PHP via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz [miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) z referowanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie określonego współczynnika skalowania:

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Utwórz obraz w pełnej skali
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Zapisz obraz na dysku w formacie PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Utworzenie miniatury wyglądu kształtu opartej na granicach**
Ta metoda tworzenia miniatur kształtów pozwala programistom generować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona do granic slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury referowanego slajdu, używając granic kształtu jako wyglądu.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykładowy kod opiera się na powyższych krokach:

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Utwórz obraz w pełnej skali
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Zapisz obraz na dysku w formacie PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/), oraz inne. Kształty mogą być również [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/php-java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/php-java/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/php-java/font-substitution/)), aby uniknąć niepożądanych zastąpień i zmian układu tekstu.