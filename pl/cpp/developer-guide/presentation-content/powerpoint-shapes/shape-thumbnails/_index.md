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
- granice wizualne
- granice kształtu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for C++ – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides służy do tworzenia plików prezentacji, w których każda strona to slajd. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Czasami programiści potrzebują wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga generować miniatury obrazów kształtów slajdu. Jak korzystać z tej funkcji opisano w tym artykule.  
W artykule wyjaśniono, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.  
- Generowanie miniatury kształtu slajdu z wymiarami określonymi przez użytkownika.  
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**

Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do dowolnego slajdu przy użyciu jego identyfikatora lub indeksu.  
1. Pobierz obraz miniatury kształtu referowanego slajdu w domyślnej skali.  
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniżej znajduje się przykład generujący miniaturę kształtu.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Generowanie miniatury z czynnikiem skalowania określonym przez użytkownika**

Aby wygenerować miniaturę kształtu dowolnego kształtu slajdu przy użyciu Aspose.Slides for C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do dowolnego slajdu przy użyciu jego identyfikatora lub indeksu.  
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu.  
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład generuje miniaturę z czynnikiem skalowania określonym przez użytkownika.

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

## **Utworzenie miniatury wyglądu kształtu opartej na granicach**

Ta metoda tworzenia miniatur kształtów umożliwia programistom generowanie miniatury w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona przez granice slajdu. Aby wygenerować miniaturę dowolnego kształtu slajdu w granicach jego wyglądu, użyj poniższego przykładu kodu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do dowolnego slajdu przy użyciu jego identyfikatora lub indeksu.  
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wygląd.  
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład tworzy miniaturę przy użyciu czynnika skalowania określonego przez użytkownika.

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

## **Uzyskanie rzeczywistych granic wizualnych kształtu**

Właściwości ramki [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` i `IShape::get_Height()` — opisują prostokąt przechowywany w modelu prezentacji. Rzeczywista zawartość renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Obrót, kontury, grotki strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmienić zajmowany obszar.

Użyj [Shape::GetVisualBounds](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getvisualbounds/) aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca [RectangleF](https://reference.aspose.com/slides/pl/cpp/system.drawing/rectanglef/) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycięty do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getvisualbounds/) nie jest obecnie zadeklarowane w interfejsie [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/). Dlatego zachowaj kształt pobrany z kolekcji kształtów slajdu jako wartość interfejsu i rzutuj go tylko przy wywoływaniu metody.

Poniższy przykład pobiera i porównuje ramkę oraz granice wizualne:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Ten sam [RectangleF](https://reference.aspose.com/slides/pl/cpp/system.drawing/rectanglef/) może być używany do wyrównywania pobliskich kształtów do krawędzi `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` lub `RectangleF::get_Bottom()`, do zarezerwowania wystarczającej przestrzeni w wygenerowanym układzie lub do wykrywania zawartości poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie zapisane ramki mogą nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape::GetVisualBounds](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getvisualbounds/), gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [IShape::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/getimage/), gdy musisz wyrenderować kształt. Przy użyciu [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` określa rozmiar obrazu na podstawie granic kształtu, w tym ustawień konturu, podczas gdy `ShapeThumbnailBounds::Appearance` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [Shape::GetVisualBounds](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getvisualbounds/) zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazów można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/), i inne. Kształty można także [eksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/) zapisując zawartość kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/cpp/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [udostępnić wymagane czcionki](/slides/pl/cpp/custom-font/) (lub [skonfigurować substytucje czcionek](/slides/pl/cpp/font-substitution/)), aby uniknąć niechcianych zastąpień i przelotów tekstu.