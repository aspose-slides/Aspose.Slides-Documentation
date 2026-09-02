---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w .NET
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/net/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- układ oświetlenia
- kształt fazowania
- rama tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla .NET, aby rozróżnić formatowanie kształtu lokalne, dziedziczone i efektywne w prezentacjach PowerPoint."
---
## **Zrozumienie właściwości lokalnych, dziedziczonych i efektywnych**

PowerPoint formatowanie może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie jest jego **wartością lokalną**. Jeśli ta wartość nie jest ustawiona, PowerPoint sprawdza źródła formatowania nadrzędnego, takie jak domyślny format akapitu, styl tekstu, układ lub slajd master, motyw lub domyślne ustawienia prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, jest **wartością efektywną** — wartością używaną do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna [FontHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/fontheight/) jest wtedy `float.NaN`, co oznacza „nie ustawiono tutaj”. Fragment może odziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/geteffective/) na formacie fragmentu zwraca ostateczną rozwiązana wysokość.

Używaj dwóch rodzajów danych formatowania w różnych celach:

- Odczytaj lub zmień lokalny obiekt formatu, taki jak [IPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest definiowana.
- Odczytaj obiekt danych efektywnych, taki jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformateffectivedata/), gdy potrzebujesz ostatecznego, wyrenderowanego wyniku. Dane efektywne są tylko do odczytu.

## **Porównanie wartości lokalnych, dziedziczonych i efektywnych**

Poniższy kompletny przykład tworzy kształt i stosuje wysokości czcionki na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne muszą być odczytane ponownie po zmianach formatowania.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Zdefiniuj wartości dziedziczone na dwóch różnych poziomach.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Lokalna wartość w fragmencie nadpisuje obie wartości dziedziczone.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Zmiana wartości dziedziczonej nie nadpisuje istniejącej lokalnej wartości.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Wyczyść lokalną wartość. Fragment teraz ponownie dziedziczy z akapitu.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Wyczyść wartość akapitu. Domyślna wartość prezentacji dostarcza teraz wynik.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Odczytaj dane efektywne po poprzednich zmianach.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Priorytet w tym przykładzie to formatowanie lokalne fragmentu, następnie formatowanie akapitu, a na końcu domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest taka sama: bardziej szczegółowa, jawnie określona wartość wygrywa, a [GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/geteffective/) zwraca ostateczny wynik.

## **Uzyskanie efektywnych właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/geteffective/) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, zakotwiczenie, automatyczne dopasowanie i pionowy kierunek tekstu.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/pl/net/aspose.slides/itextstyle/geteffective/) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/geteffective/) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcia i wypunktowanie.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/geteffective/) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

Dla kolejnego przykładu plik `text-formatting.pptx` musi zawierać co najmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnej pozycji w kolekcji kształtów; kod wyszukuje odpowiedni obiekt i weryfikuje go przed użyciem.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Uzyskanie efektywnych właściwości 3D**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/geteffective/) zwraca jeden obiekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/) który grupuje wszystkie rozwiązane ustawienia 3D. Jego właściwości [Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/beveltop/) i [BevelBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) udostępniają odpowiednie dane efektywne. Odczytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

Dla tego przykładu plik `shape-3d.pptx` musi zawierać co najmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub fazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Uzyskanie efektywnego formatowania tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów między jawnie określonymi wypełnieniami priorytet jest następujący: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki jest ostatecznym formatem używanym do rysowania tej komórki.

Dla tego przykładu plik `table-formatting.pptx` musi zawierać co najmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć co najmniej jeden wiersz i jedną kolumnę. Kod wyszukuje obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) zamiast zakładać, że `Shapes[0]` jest tabelą.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywny [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/filltype/), a następnie odczytaj właściwość odpowiednią dla tego typu — na przykład [SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) dla wypełnienia jednolitego.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj ponownie `GetEffective` po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalne formatowanie obiektu;
- domyślne ustawienia akapitu lub ramki tekstowej;
- styl tabeli, tabelę, kolumnę, wiersz lub format komórki;
- formatowanie układu lub slajdu master;
- dane motywu lub domyślne ustawienia na poziomie prezentacji;
- układ lub master przypisany do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może wewnętrznie buforować niektóre dane efektywne, a późniejsze wywołanie `GetEffective` może odświeżyć te dane. Jeśli potrzebujesz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarne — takie jak wysokość czcionki, kolor, wyrównanie lub szerokość fazowania — do własnych zmiennych przed wprowadzeniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatu, a następnie wywołaj `GetEffective`, aby zweryfikować wynik. Obiekty danych efektywnych są same w sobie tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, a nie jej źródło. Przeglądaj odpowiednie lokalne obiekty od najbardziej szczegółowego poziomu w kierunku zewnętrznym. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, master, motyw i domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `float.NaN` lub `null`, wskazują, że wyszukiwanie kontynuuje się na kolejnym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiednią domyślną wartość PowerPointa lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden lokalny obiekt nie definiuje jej explicite.

**Dlaczego wartość efektywna czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała obliczenia dziedziczenia. Jest to oczekiwane, gdy właściwość jest jawnie ustawiona na obiekcie i żadna bardziej szczegółowa reguła jej nie nadpisuje.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby przejrzeć lub edytować konkretny poziom formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po zastosowaniu dziedziczenia, reguł motywu oraz odpowiednich stylów. [Pełny przykład porównania](#compare-local-inherited-and-effective-values) demonstruje oba w tym samym przepływie pracy.