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
- wyszukiwanie kształtu
- klonowanie kształtu
- usuwanie kształtu
- ukrywanie kształtu
- zmiana kolejności kształtu
- pobranie ID kształtu interop
- alternatywny tekst kształtu
- punkt dopasowania kształtu
- wstępne dopasowanie kształtu
- geometria kształtu
- formaty układu kształtu
- kształt jako SVG
- kształt do SVG
- wyrównanie kształtu
- odbijanie kształtu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, dostosowywać, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty prezentacji przy użyciu Aspose.Slides for .NET."
---
## **Przegląd**

Aspose.Slides for .NET reprezentuje kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty oraz źródłem ich kolejności nakładania: indeks `0` to najdalej w tle kształt, natomiast ostatni indeks to kształt najbliżej przodu.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak niezawodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty dopasowania, a potem pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównanie i ustawienia odbicia. Każdy przykład jest niezależny, dzięki czemu możesz używać tylko operacji wymaganych w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/name/) jest przydatny dla szablonów kontrolowanych przez programistów i łatwo go sprawdzić w panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetext/) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany w celu zapewnienia dostępności i nie jest gwarantowany jako unikalny. Nie wykorzystuj cichego, znaczącego tekstu dostępności jako klucza bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/officeinteropshapeid/) jest identyfikatorem tylko do odczytu, który jest unikalny w obrębie slajdu i odpowiada identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Użyj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odwołania w trakcie życia kształtu. Sklonowany lub odtworzony kształt to inny kształt i otrzymuje własny identyfikator.

Powiązana właściwość [UniqueId](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/uniqueid/) ma zasięg prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy jej traktować jako trwałego klucza zewnętrznego. Jeśli długoterminowa tożsamość jest istotna, zachowaj mapowanie w danych aplikacji i sprawdź, czy oczekiwany kształt nadal istnieje.

Praktyczny przykład odczytu i aktualizacji zarówno tytułu, jak i opisu tekstu alternatywnego, znajdziesz w [Manage Alternative Text Titles and Descriptions](/slides/pl/net/presentation-accessibility/). Używaj tekstu alternatywnego, aby wyjaśnić znaczenie elementu wizualnego czytelnikom i utrzymuj go oddzielnie od nazw kształtów używanych w kodzie do ich znajdowania.

Poniższy przykład wyszukuje po `Name` przy użyciu porównania porządkowego i zgłasza interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

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

## **Identyfikowanie i modyfikowanie wstępnych dopasowań kształtu**

Kształty o wstępnej geometrii mogą udostępniać punkty dopasowania, które sterują takimi cechami jak rozmiar narożnika, proporcje strzałki lub kąty łuku. Dostęp do nich uzyskuje się poprzez tylko do odczytu kolekcję [IGeometryShape.Adjustments](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/adjustments/). Sama kolekcja jest dostarczana przez kształt, ale każdy [IAdjustValue](https://reference.aspose.com/slides/pl/net/aspose.slides/iadjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj przez dopasowania i sprawdzaj tylko do odczytu właściwość [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/adjustvalue/type/), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/shapeadjustmenttype/) opisuje, co dopasowanie kontroluje. Tylko do odczytu właściwość [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/adjustvalue/name/) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy wstępny zestaw zawiera więcej niż jedno dopasowanie o tym samym typie semantycznym.

Użyj właściwości wartości odpowiadającej znaczeniu dopasowania:

| Typ dopasowania | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych narożników | [RawValue](https://reference.aspose.com/slides/pl/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Grubość ogona strzałki | `RawValue` |
| `ArrowheadLength` | Długość grotu strzałki | `RawValue` |
| `ArrowheadWidth` | Szerokość grotu strzałki | `RawValue` |
| `StartAngle` | Kąt początkowy koła lub łuku | [AngleValue](https://reference.aspose.com/slides/pl/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Kąt końcowy koła lub łuku | `AngleValue` |

`Type` i `Name` nie mogą być przypisywane. `RawValue` jest liczbą całkowitą do odczytu i zapisu w natywnych jednostkach geometrii wstępnego kształtu, natomiast `AngleValue` jest liczbą całkowitą do odczytu i zapisu wyrażoną w stopniach. Liczba, kolejność, znaczenie i dopuszczalny zakres dopasowań zależą od wstępnego [ShapeType](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/shapetype/). Wartość ważna dla jednego wstępnego kształtu może być niewłaściwa lub mieć inny efekt dla innego.

Gdy `Type` jest `ShapeAdjustmentType.Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `Name`, typ wstępny oraz istniejącą wartość i pozostaw dopasowanie niezmienione, chyba że znasz oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/net/connector/) pokazuje tę sytuację w kontekście dopasowań zagięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech wstępnych kształtów. Iteruje przez każde dopasowanie, zgłasza jego `Name` i `Type`, zmienia wartości związane z rozmiarem poprzez `RawValue`, zmienia kąty poprzez `AngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje zaokrąglony prostokąt, czterokierunkową strzałkę i kołowy wycinek.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Dodaje nagłówki dla kolumn z domyślnymi i zmodyfikowanymi kształtami.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny w swoim zamiarze i unika założeń, że konkretny indeks kolekcji ma to samo znaczenie w różnych wstępnych kształtach.

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/insertclone/) także tworzy kopię, ale umieszcza ją pod określonym indeksem z‑order. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą także zmienić rozmiar.

Przykład tworzy docelowy slajd, klonuje opisany prostokąt na przód i wstawia drugi klon na tył. Zmiany w dowolnym klonie nie modyfikują kształtu źródłowego.

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

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań podczas iteracji indeksowanej, przechodź od końca, aby każdy pozostały indeks pozostał ważny.

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

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych elementach prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż sam wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/hidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetleniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

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

Ukrycie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może zostać odnaleziony i odsłonięty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z‑order**

Nakładające się kształty są rysowane w kolejności kolekcji. [Reorder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `Count - 1` to przód.

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

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu umieszcza go na przedzie. Sfinalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną warstwę.

## **Inspekcja kształtów w układach slajdów**

Zwykłe slajdy, układy slajdów i slajdy mistrzowskie mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem, co podobnie pozycjonowany kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje dla każdego kształtu układu [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/fillformat/) oraz [LineFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/lineformat/) bez zakładania, że każdy kształt jest `AutoShape`.

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

Edycja układu może wpłynąć na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksport kształtu do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/writeassvg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera sam kształt, a nie całe tło slajdu ani sąsiadujące kształty.

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

Trzymaj prezentację otwartą podczas renderowania. Wynik zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zwolnić.

## **Wyrównywanie kształtów**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/alignshapes/) ma przeciążenia wyrównujące wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje do kształtów są konwertowane na ich bieżące indeksy tuż przed wyrównaniem.

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

Wyrównanie zmienia pozycje, a nie kolejność Z. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy rozmieszczenie poziome lub pionowe wymaga wystarczającej liczby kształtów, aby określić odstępy. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbijanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz obrót. Jej wartości `FlipH` i `FlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/net/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodbijany kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zamienia tylko dwa ustawienia odbicia. Jest to istotne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/frame/) zastępuje całą ramkę.

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

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie pozycję, rozmiar i obrót.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych ręcznie albo `OfficeInteropShapeId` dla pracy w zakresie interop slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być znaleziony, zmieniony kolejność, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`AddClone` dołącza klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `InsertClone`, aby wybrać początkowy indeks, lub `Reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji wstępnego dopasowania kształtu?**

Tylko po zweryfikowaniu dokładnego wstępnego kształtu i układu kolekcji. Preferuj iterację przez `IGeometryShape.Adjustments` i sprawdzanie `IAdjustValue.Type`; użyj `IAdjustValue.Name` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się więcej niż raz.