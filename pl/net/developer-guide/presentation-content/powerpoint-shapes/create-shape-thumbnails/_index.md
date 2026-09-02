---
title: Tworzenie miniatur kształtów prezentacji w .NET
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/net/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- wizualne granice
- granice kształtu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint za pomocą Aspose.Slides for .NET – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for .NET służy do tworzenia plików prezentacji, w których każda strona jest slajdem. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Czasami jednak programiści potrzebują wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides for .NET pomaga generować miniatury obrazów kształtów slajdu. Jak korzystać z tej funkcji opisano w tym artykule.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu z wymiarami określonymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**

Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury kształtu referowanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

Poniższy przykład generuje miniaturę kształtu.

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

## **Generowanie miniatury z czynnikiem skalowania określonym przez użytkownika**

Aby wygenerować miniaturę kształtu dowolnego kształtu slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

Poniższy przykład generuje miniaturę z czynnikiem skalowania określonym przez użytkownika.

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

## **Tworzenie miniatury wyglądu kształtu opartej na granicach**

Ta metoda tworzenia miniatur kształtów pozwala programistom generować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona do granic slajdu. Aby wygenerować miniaturę dowolnego kształtu slajdu w granicach jego wyglądu, użyj poniższego przykładu kodu:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wygląd.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

Poniższy przykład tworzy miniaturę z czynnikiem skalowania określonym przez użytkownika.

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

## **Uzyskiwanie rzeczywistych wizualnych granic kształtu**

Właściwości ramki [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) — jej właściwości `X`, `Y`, `Width` i `Height` — opisują prostokąt przechowywany w modelu prezentacji. Rzeczywiście renderowana zawartość może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Obrót, kontury, groty strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmieniać zajmowany obszar.

Użyj [GetVisualBounds](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getvisualbounds/), aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycinany do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

[GetVisualBounds](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getvisualbounds/) nie jest obecnie zadeklarowane w interfejsie [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/). Dlatego zachowaj kształt uzyskany z kolekcji kształtów slajdu jako wartość interfejsu i rzutuj go tylko podczas wywoływania metody.

Poniższy przykład pobiera i porównuje ramkę oraz wizualne granice:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Ten sam [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) można wykorzystać do wyrównywania sąsiednich kształtów do jego krawędzi `Left`, `Right`, `Top` lub `Bottom`; rezerwowania wystarczającej przestrzeni w generowanym układzie; lub wykrywania zawartości poza dozwolonym obszarem. Wizualne granice są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie zapisana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [GetVisualBounds](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getvisualbounds/), gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [IShape.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getimage/), gdy musisz renderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` określa rozmiar obrazu na podstawie granic kształtu, włączając ustawienia konturu, podczas gdy `ShapeThumbnailBounds.Appearance` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [GetVisualBounds](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getvisualbounds/) zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/), oraz inne. Kształty można także [eksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/), zapisując ich zawartość jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` wykorzystuje geometrię kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/net/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [zapewnić wymagane czcionki](/slides/pl/net/custom-font/) (lub [skonfigurować zastąpienia czcionek](/slides/pl/net/font-substitution/)), aby uniknąć niechcianych zamian i przemieszczeń tekstu.