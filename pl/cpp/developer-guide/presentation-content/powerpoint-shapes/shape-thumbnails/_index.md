---
title: Tworzenie miniatur kształtów prezentacji w C++
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/cpp/shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów ze slajdów PowerPoint przy użyciu Aspose.Slides dla C++ – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides jest używany do tworzenia plików prezentacji, w których każda strona jest slajdem. Slajdy te można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Czasami jednak programiści mogą potrzebować obejrzeć obrazy kształtów oddzielnie w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga generować miniatury obrazów kształtów slajdu. Sposób użycia tej funkcji opisano w tym artykule.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu dla kształtu slajdu z wymiarami określonymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides dla C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz obraz miniatury kształtu referowanego slajdu w domyślnej skali.
4. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład generuje miniaturę kształtu.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Generowanie miniatury z użytkownikowo określonym współczynnikiem skalowania**
Aby wygenerować miniaturę kształtu dowolnego kształtu slajdu przy użyciu Aspose.Slides dla C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz obraz miniatury referowanego slajdu z granicami kształtu.
4. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład generuje miniaturę z użytkownikowo określonym współczynnikiem skalowania.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skalowanie wzdłuż osi X i Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Utworzenie miniatury kształtu opartej na granicach wyglądu**
Ta metoda tworzenia miniatur kształtów pozwala programistom generować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona przez granice slajdu. Aby wygenerować miniaturę dowolnego kształtu slajdu w granicach jego wyglądu, użyj poniższego przykładowego kodu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wygląd.
4. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład tworzy miniaturę przy generowaniu miniatury z użytkownikowo określonym współczynnikiem skalowania.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skalowanie wzdłuż osi X i Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/), i inne. Kształty mogą być również [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/cpp/shape-effect/) (cienie, poświaty itp.).

**Co się dzieje, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; znacznik ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy kształty grupowe, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/) oraz [SmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane systemowo wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/cpp/custom-font/) (lub [skonfigurować zamiany czcionek](/slides/pl/cpp/font-substitution/)), aby uniknąć niechcianych zastąpień i przeskładania tekstu.