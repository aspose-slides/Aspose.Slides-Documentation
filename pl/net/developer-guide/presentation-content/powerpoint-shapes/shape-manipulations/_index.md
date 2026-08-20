---
title: Zarządzanie kształtami prezentacji w .NET
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/net/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Sklonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odwróć kształt
- PowerPoint
- Prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odwracać kształty prezentacji za pomocą Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET reprezentuje kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty oraz źródłem ich kolejności nakładania: indeks `0` to najgłębiej położony kształt, a ostatni indeks to kształt najbardziej przybliżony do przodu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak niezawodnie zidentyfikować kształt, a potem pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównanie oraz ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji potrzebnych w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne podczas przetwarzania znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator w zależności od tego, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/name/) jest przydatny w szablonach kontrolowanych przez programistów i łatwo go sprawdzić w panelu zaznaczania PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc ustal konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetext/) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany dla dostępności i nie jest gwarantowany jako unikalny. Nie należy po cichu wykorzystywać znaczącego tekstu dostępności jako klucza bazodanowego.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/officeinteropshapeid/) to identyfikator tylko do odczytu, który jest unikalny w obrębie slajdu i odpowiada identyfikatorowi kształtu używanemu przez interop PowerPointa. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana właściwość [UniqueId](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/uniqueid/) ma zakres prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie powinna być traktowana jako trwały zewnętrzny klucz. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po `Name` przy użyciu porównania ordinalnego i zgłasza interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź interfejs przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/insertclone/) również tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności z-order. Przeciążenia przyjmujące współrzędne przemieszczają klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić jego rozmiar.

Przykład tworzy docelowy slajd, klonuje oznaczony prostokąt na przód i wstawia drugi klon z tyłu. Zmiany w którymkolwiek z klonów nie modyfikują kształtu źródłowego.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę oraz tekst alternatywny. Przypisz nowe logiczne identyfikatory do klona, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w pętli indeksowanej, przeglądaj kolekcję od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje `slide.Shapes[i]`, a nie stały element kolekcji, i nie rzutuje kształtu niepotrzebnie.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Po usunięciu liczba kształtów i indeksy późniejszych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Weź pod uwagę także łączniki, animacje i inne elementy prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/hidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne w kodzie, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą zostać przywrócone później.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt wciąż może być odnaleziony i odkryty przez użytkownika lub kod, i nadal jest częścią pliku prezentacji.

### **Zmiana kolejności Z-Order**

Nakładające się kształty są rysowane w kolejności kolekcji. [Reorder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez klonowania. Indeks `0` to tył; `Count - 1` to przód.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu umieszcza go na przodzie. Sfinalizuj kolejność Z-Order po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzony stos.

## **Inspekcja kształtów na slajdach układu**

Zwykłe slajdy, slajdy układu i slajdy nadrzędne mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie położony kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/fillformat/) i [LineFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/lineformat/) każdego kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/writeassvg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera kształt, a nie całe tło slajdu ani sąsiadujące kształty.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Trzymaj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zwolnić.

## **Wyrównywanie kształtów**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/alignshapes/) ma przeciążenia, które wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrotne odwołania do kształtów są konwertowane na ich bieżące indeksy tuż przed wyrównaniem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Wyrównanie zmienia położenia, nie kolejność Z-Order. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy pozioma lub pionowa dystrybucja wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odwracanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz rotację. Jej wartości `FlipH` i `FlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/net/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/domyślny stan.

Prezentacja wejściowa poniżej zawiera jeden nieodwrócony kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zastępuje tylko dwa ustawienia odbicia. To ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/frame/) zastępuje całą ramkę.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Zapisany kształt jest odbity poziomo i pionowo, przy zachowaniu pozycji, rozmiaru i rotacji.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych ręcznie, lub `OfficeInteropShapeId` dla prac opartych na interopie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z-Order?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Można go znaleźć, zmienić kolejność, edytować lub ponownie uczynić widocznym.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`AddClone` dołącza klon na koniec kolekcji, co jest przodem kolejności Z-Order. Użyj `InsertClone`, aby wybrać początkowy indeks, lub `Reorder` po dodaniu wszystkich kształtów.