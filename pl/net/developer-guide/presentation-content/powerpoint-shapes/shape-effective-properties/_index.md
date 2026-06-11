---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w .NET
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/net/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw oświetlenia
- kształt fazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj, jak Aspose.Slides dla .NET oblicza i stosuje efektywne właściwości kształtu, aby precyzyjnie renderować prezentacje PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne to wartości ustawiane bezpośrednio na określonym poziomie formatowania, na przykład:

1. Właściwości fragmentu na slajdzie.  
2. Style tekstu prototypowego kształtu na układzie lub slajdzie głównym, jeśli kształt ramki tekstowej fragmentu ma je.  
3. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być określone lub pominięte na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „tak jak zostanie wyrenderowane”, rozwiązuje łańcuch dziedziczenia i zwraca **wartości efektywne**. Można je uzyskać, wywołując metodę `GetEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) z ramką tekstową i co najmniej jednym fragmentem.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Dane formatowania efektywnego reprezentują bieżące obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformateffectivedata/), mogą być buforowane wewnętrznie. Ponowne wywołanie `GetEffective` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować wartości efektywne do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobranie efektywnych właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icameraeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Pobranie efektywnych właściwości zestawu oświetlenia**

Aspose.Slides umożliwia pobranie efektywnych właściwości zestawu oświetlenia. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilightrigeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości zestawu oświetlenia. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Pobranie efektywnych właściwości fazowanego kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości fazowanego kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości reliefu kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapebeveleffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformateffectivedata/), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości górnego fazowania kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Pobranie efektywnych właściwości ramki tekstowej**

Przy użyciu Aspose.Slides możesz pobrać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) z ramką tekstową.

```csharp
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

## **Pobranie efektywnych właściwości stylu tekstu**

Przy użyciu Aspose.Slides możesz pobrać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) z ramką tekstową.

```csharp
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

## **Pobranie efektywnej wartości wysokości czcionki**

Przy użyciu Aspose.Slides możesz uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```csharp
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

## **Pobranie efektywnego formatu wypełnienia tabeli**

Przy użyciu Aspose.Slides możesz pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/).

```csharp
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

**Czy `GetEffective` zwraca migawkę?**

Nie zawsze. Dane efektywne reprezentują wyliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `GetEffective` może ponownie przeliczyć formatowanie i odświeżyć buforowane dane, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj `GetEffective` ponownie po zmianie formatowania lokalnego, stylów rodzica, formatowania układu, formatowania szablonu lub domyślnych ustawień prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

**Czy zmiana lub usunięcie slajdu układu/głównego wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostanie odzwierciedlona przy następnym wywołaniu `GetEffective`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `GetEffective` Aspose.Slides ponownie oceni drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

**Czy mogę modyfikować wartości za pomocą obiektów danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają jedynie obliczone wartości. Wprowadzaj zmiany w lokalnych obiektach formatowania, a następnie ponownie pobieraj efektywne wartości.

**Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/głównym, ani w ustawieniach globalnych?**

Wartość efektywna zostaje określona przez mechanizm domyślny, który obejmuje domyślne ustawienia PowerPointa i Aspose.Slides. Rozwiązana wartość staje się częścią bieżących danych efektywnych.

**Na podstawie efektywnej wartości czcionki, czy mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź wartości lokalne w fragmencie, akapicie, ramce tekstowej oraz stylach tekstu na poziomach układu, szablonu i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicite definicja.

**Dlaczego wartości efektywne czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie było potrzeby dziedziczenia z wyższego poziomu). W takich przypadkach wartość efektywna jest taka sama jak lokalna.

**Kiedy powinienem używać efektywnych właściwości, a kiedy pracować tylko z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak zostanie wyrenderowane” po zastosowaniu całego dziedziczenia, np. do dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli potrzebujesz zmienić formatowanie na konkretnym poziomie, modyfikuj właściwości lokalne, a następnie, w razie potrzeby, odczytaj ponownie dane efektywne, aby zweryfikować rezultat.