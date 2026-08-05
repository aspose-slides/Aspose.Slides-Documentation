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
- granice wizualne
- granice kształtu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for PHP via Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides jest używany do tworzenia plików prezentacji, w których każda strona jest slajdem. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak czasami programiści mogą potrzebować wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga wygenerować miniatury obrazów kształtów slajdu. Jak używać tej funkcji opisano w tym artykule.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu z wymiarami zdefiniowanymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for PHP via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
3. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) odwołanego slajdu w domyślnej skali.
4. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy kod przykładowy pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

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

## **Generowanie miniatury ze skalowaniem określonym przez użytkownika**
Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for PHP via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
3. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) odwołanego slajdu z wymiarami określonymi przez użytkownika.
4. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy kod przykładowy pokazuje, jak wygenerować miniaturę kształtu na podstawie określonego czynnika skalowania:

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
Ta metoda tworzenia miniatur kształtów umożliwia programistom wygenerowanie miniatury w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona przez granice slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
3. Pobierz obraz miniatury odwołanego slajdu z granicami kształtu jako wyglądu.
4. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy kod przykładowy opiera się na powyższych krokach:

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

## **Uzyskanie rzeczywistych granic wizualnych kształtu**

Właściwości ramki [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` i `Shape::getHeight()` — opisują prostokąt przechowywany w modelu prezentacji. Treść rzeczywiście renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Rotacja, kontury, zakończenia strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmieniać zajęty obszar.

Użyj [Shape::getVisualBounds](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getVisualBounds), aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycięty do slajdu, więc jego współrzędne mogą być ujemne, gdy treść wykracza poza początek slajdu.

Poniższy przykład pobiera i porównuje ramkę oraz granice wizualne:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Ten sam [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) można wykorzystać do wyrównywania pobliskich kształtów do jego lewej, prawej, górnej lub dolnej krawędzi; rezerwowania wystarczającej przestrzeni w wygenerowanym układzie; lub wykrywania treści poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape::getVisualBounds](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getVisualBounds), gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [Shape::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage), gdy musisz wyrenderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` rozmiaruje obraz na podstawie granic kształtu, włączając ustawienia konturu, podczas gdy `ShapeThumbnailBounds::Appearance` rozmiaruje go na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast `Shape::getVisualBounds` zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazów można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/), oraz inne. Kształty można również [eksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) zapisując zawartość kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/php-java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/php-java/custom-font/) (lub [skonfigurować zamienniki czcionek](/slides/pl/php-java/font-substitution/)), aby uniknąć niepożądanych zamienników i przerywania tekstu.