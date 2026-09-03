---
title: Zarządzanie polami tekstowymi w prezentacjach w .NET
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/net/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- aktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz, identyfikuj, formatuj i aktualizuj pola tekstowe w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET."
---
## **Wprowadzenie**

W Aspose.Slides for .NET tekst slajdu jest przechowywany w ramach tekstowych, które należą do kształtów. Interfejs [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) reprezentuje najczęściej występujący kształt zawierający tekst i udostępnia jego tekst za pośrednictwem właściwości [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Uwaga" %}}
Każdy automatyczny kształt implementuje [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), ale nie każdy kształt jest automatycznym kształtem ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji należy sprawdzić, czy kształt implementuje `IAutoShape`, zanim uzyska się dostęp do jego tekstu.
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj automatyczny kształt do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Współrzędne i wymiary przekazywane do [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addautoshape/) są mierzone w punktach. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/addtextframe/) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdź, czy kształt jest polem tekstowym**

Użyj właściwości [AutoShape.IsTextBox](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/istextbox/), aby określić, czy automatyczny kształt jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne automatyczne kształty.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład analizuje każdy automatyczny kształt w prezentacji:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Nowo dodany automatyczny kształt nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Możesz dostarczyć ten tekst za pomocą [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/addtextframe/) lub [ITextFrame.Text](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/text/). Dodanie lub przypisanie pustego łańcucha pozostawia `IsTextBox` ustawione na `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Pierwsze dwie wywołania wypisują `True`; ostatnie dwa wypisują `False`.

## **Znajdź kształt, który jest właścicielem ramki tekstowej**

Kod przetwarzający tekst może otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) bez znajomości, który obiekt prezentacji go zawiera. Użyj właściwości tylko do odczytu [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/), aby przejść z powrotem do jego właściciela – obiektu [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/).

Dla ramki tekstowej będącej własnością automatycznego kształtu lub innego kształtu zawierającego tekst, `ParentShape` zawiera właściciela, a [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) ma wartość `null`. Sprawdź zwróconą wartość przed jej użyciem. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, włączając kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/net/search-and-replace-text/).

## **Dodaj kolumny do pola tekstowego**

Właściwość [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/columncount/) dzieli ramkę tekstową na kolumny, a [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/columnspacing/) ustawia przerwę między kolumnami w punktach. Oba ustawienia należą do [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/) i mogą być zmieniane poprzez ramkę tekstową istniejącego pola tekstowego. Tekst przepływa między kolumnami w obrębie tego samego kształtu; nie kontynuuje się w innym kształcie.

Poniższy przykład tworzy pole tekstowe z trzema kolumnami i odstępem 10 punktów między kolumnami, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Wyodrębnij tekst z poszczególnych kolumn**

Użyj [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/splittextbycolumns/), aby pobrać tekst przypisany do każdej wizualnej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden łańcuch dla każdej kolumny, w kolejności odczytu opartej na kolumnach. Ramka jednokolumnowa zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym łańcuchem. Łańcuchy zawierają wyłącznie czysty tekst; formatowanie na poziomie fragmentu nie jest zachowywane.

Jest to przydatne, gdy potrzebujesz:

- Wyodrębnić tekst, zachowując kolejność odczytu opartą na kolumnach.
- Indeksować lub porównywać zawartość slajdów z wieloma kolumnami.
- Eksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Zbadać, jak tekst jest redystrybuowany po zmianie [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/columnspacing/), czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozmieszczony w bieżącej [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/); nie przepuszcza automatycznie tekstu między oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, więc upewnij się, że wymagane czcionki są dostępne, gdy istotna jest spójność wyników.

Poniższy przykład ładuje prezentację, znajduje pierwszy automatyczny kształt wielokolumnowy z ramką tekstową, odczytuje jego skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do osobnego pliku. Kształty, które nie dostarczają ramki tekstowej, są pomijane.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Aktualizuj tekst**

Aby zaktualizować tekst w całej prezentacji, iteruj po slajdach i kształtach, wybieraj automatyczne kształty i edytuj ich fragmenty tekstu. Praca na poziomie fragmentu pozwala zmieniać zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zastępuje każde wystąpienie `years` słowem `months` w tekście automatycznych kształtów i pogrubia każdy zmieniony fragment:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Ta iteracja aktualizuje tekst wyłącznie w automatycznych kształtach. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga przeglądania odpowiednich kolekcji tych obiektów.

## **Dodaj pole tekstowe z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, więc tylko ten fragment działa jako klikalny link. Użyj [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), aby powiązać fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go do prezentacji:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym na slajdzie głównym lub układu?**

[placeholder](/slides/pl/net/manage-placeholder/) może dziedziczyć swoją pozycję i formatowanie z [slajdu wzorcowego](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslide/) lub [slajdu układu](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przejmuje zachowania symbolu zastępczego po zmianie układu.

**Jak zastąpić tekst, nie zmieniając go w wykresach, tabelach ani w SmartArt?**

Ogranicz przeglądanie do kształtów implementujących [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), tak jak pokazano w przykładzie Aktualizuj tekst. Wykresy, tabele i SmartArt przechowują tekst w swoich własnych modelach obiektów, więc nie są modyfikowane przez tę pętlę.