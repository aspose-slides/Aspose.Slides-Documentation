---
title: Utwórz miniatury kształtów prezentacji w .NET
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/net/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderuj kształt
- renderowanie kształtu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides dla .NET – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wstęp**

Aspose.Slides for .NET służy do tworzenia plików prezentacji, w których każda strona jest slajdem. Te slajdy mogą być przeglądane poprzez otwarcie plików prezentacji w programie Microsoft PowerPoint. Czasami programiści potrzebują jednak wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides for .NET pomaga wygenerować miniatury kształtów slajdu. Jak używać tej funkcji, opisano w tym artykule.
Artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu dla slajdu z wymiarami określonymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz miniaturę kształtu odwołanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Przykład poniżej generuje miniaturę kształtu.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Generowanie miniatury ze skalowaniem określonym przez użytkownika**
Aby wygenerować miniaturę kształtu dowolnego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury odwołanego slajdu z granicami kształtu.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Przykład poniżej generuje miniaturę ze skalowaniem określonym przez użytkownika.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skalowanie wzdłuż osi X i Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Utworzenie miniatury o wyglądzie opartym na granicach kształtu**
Ta metoda tworzenia miniatur kształtów umożliwia programistom wygenerowanie miniatury w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu. Aby wygenerować miniaturę dowolnego kształtu slajdu w granicach jego wyglądu, użyj poniższego przykładu kodu:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury odwołanego slajdu z granicami kształtu jako wygląd.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Przykład poniżej tworzy miniaturę ze skalowaniem określonym przez użytkownika.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skalowanie wzdłuż osi X i Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/), i inne. Kształty można także [eksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/) zapisując zawartość kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/net/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flagę ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy obsługiwane są grupowane kształty, wykresy, SmartArt i inne złożone obiekty?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/), oraz [SmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartart/)) może zostać zapisany jako miniatura lub jako SVG.

**Czy zainstalowane systemowo czcionki wpływają na jakość miniatur dla kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/net/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/net/font-substitution/)), aby uniknąć niepożądanych zamienników i przemieszczeń tekstu.