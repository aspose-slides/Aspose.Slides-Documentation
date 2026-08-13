---
title: Uzyskaj efektywne właściwości kształtów z prezentacji w .NET
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/net/shape-effective-properties/
keywords:
- właściwości kształtów
- właściwości kamery
- zestaw oświetlenia
- kształt ze sfazowaniem
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla .NET oblicza i stosuje efektywne właściwości kształtów w celu precyzyjnego renderowania PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne to wartości, które są ustawiane bezpośrednio na określonym poziomie formatowania, na przykład:

1. Właściwości portion na slajdzie.  
1. Style tekstu kształtu prototypu na układzie lub slajdzie głównym, gdy kształt ramki tekstowej portion posiada je.  
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „takiego jak renderowane”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać, wywołując metodę `GetEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać efektywne wartości. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) z ramką tekstową i przynajmniej jedną częścią.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Dane formatowania efektywnego reprezentują bieżące wyliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformateffectivedata/), mogą być buforowane wewnętrznie. Ponowne wywołanie `GetEffective` po zmianie formatowania nadrzędnego lub dziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać poprzedniego stanu. Jeśli potrzebujesz zachować efektywne wartości do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobieranie efektywnych właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icameraeffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Pobieranie efektywnych właściwości Light Rig**

Aspose.Slides umożliwia pobranie efektywnych właściwości Light Rig. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilightrigeffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Pobieranie efektywnych właściwości kształtu Bevel**

Aspose.Slides umożliwia pobranie efektywnych właściwości wybrzuszenia (bevel) kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości reliefu powierzchni kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapebeveleffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Pobieranie efektywnych właściwości ramki tekstowej**

Korzystając z Aspose.Slides, można uzyskać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Pobieranie efektywnych właściwości stylu tekstu**

Korzystając z Aspose.Slides, można uzyskać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Pobieranie efektywnej wartości wysokości czcionki**

Korzystając z Aspose.Slides, można uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Pobieranie efektywnego formatu wypełnienia dla tabeli**

Korzystając z Aspose.Slides, można uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórek ma wyższy priorytet niż formatowanie wierszy, formatowanie wierszy ma wyższy priorytet niż formatowanie kolumn, a formatowanie kolumn ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### Czy `GetEffective` zwraca migawkę?

Nie zawsze. Dane efektywne reprezentują wyliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `GetEffective` może ponownie obliczyć formatowanie i odświeżyć buforowane dane, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

### Kiedy ponownie odczytać efektywne właściwości?

Wywołaj ponownie `GetEffective` po zmianie formatowania lokalnego, stylów nadrzędnych, formatowania układu, formatowania mistrza lub domyślnych ustawień prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

### Czy zmiana lub usunięcie układu/slajdu mistrza wpływa na już pobrane efektywne właściwości?

Tak, zmiana zostanie odzwierciedlona przy następnym wywołaniu `GetEffective`. Jeśli źródło formatowania nadrzędnego zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się przestarzałe. Po ponownym wywołaniu `GetEffective` Aspose.Slides ponownie oceni drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą się zmienić.

### Czy mogę modyfikować wartości poprzez obiekty danych efektywnych?

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Zmiany wprowadzaj w obiektach formatowania lokalnego, a następnie ponownie pobieraj wartości efektywne.

### Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, układu/mistrza ani w ustawieniach globalnych?

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje domyślne wartości PowerPoint i Aspose.Slides. Ta rozstrzygnięta wartość staje się częścią bieżących danych efektywnych.

### Czy z efektywnej wartości czcionki mogę określić, który poziom dostarczył rozmiar lub krój?

Nie bezpośrednio. Dane efektywne zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź lokalne wartości w portion, paragrafie, ramce tekstowej i stylach tekstu na poziomach układu, mistrza i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicite definicja.

### Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?

Ponieważ wartość lokalna okazała się ostateczna (nie było potrzebne wyższe dziedziczenie). W takich przypadkach wartość efektywna pokrywa się z lokalną.

### Kiedy powinienem używać danych efektywnych, a kiedy tylko lokalnych?

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak renderowany” po zastosowaniu całego dziedziczenia, np. do dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, modyfikuj właściwości lokalne, a potem, w razie potrzeby, ponownie odczytaj dane efektywne, aby zweryfikować rezultat.