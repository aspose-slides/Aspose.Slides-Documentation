---
title: Formatowanie tekstu prezentacji w .NET
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/net/text-formatting/
keywords:
- wyrównywanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy znaków
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstępy między wierszami
- właściwość autofit
- zakotwiczenie ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Dostosuj czcionki, kolory, wyrównanie i wiele innych."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET. Obejmuje kolory tła, przezroczystość, odstępy znaków, właściwości czcionki, obrót, odstępy akapitów, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

Jeśli nie zaznaczono inaczej, przykłady używają [sample.pptx](sample.pptx). Pierwszy obiekt na pierwszym slajdzie jest polem tekstowym, a jego pierwszy akapit zawiera tekst pokazany poniżej. Indeksy slajdów i obiektów zaczynają się od zera. Przykłady wybierające pogrubione fragmenty używają formatowania efektywnego, w tym dziedziczonego pogrubienia:

![Przykładowy tekst](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/net/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/), aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/), aby ustawić go dla poszczególnych fragmentów tekstu.

Poniższy przykład ustawia jasnoszare podświetlenie jako domyślne dla pierwszego akapitu. Jawne kolory podświetlenia w poszczególnych fragmentach mają pierwszeństwo przed tym domyślnym:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ustaw kolor podświetlenia dla całego akapitu.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Ustaw kolor podświetlenia dla fragmentu tekstu.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Wynik:

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana i tak dalej.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ustaw wyrównanie akapitu do środka.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Wyrównaj czcionki w linii**

Użyj [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/), aby pionowo wyrównać fragmenty tekstu o różnych rozmiarach czcionki w jednej linii. To ustawienie dotyczy całego akapitu i kontroluje wyrównanie w każdej jego linii.

Poniższy, samodzielny przykład tworzy cztery opisane pola tekstowe na jednym slajdzie. Każdy akapit zawiera ten sam tekst w rozmiarach 18, 36 i 54 punktów, przy różnym wyrównaniu czcionki. Używa Arial, wyłącza autofit i zawijanie oraz utrzymuje ramki tekstowe wystarczająco duże dla jednej linii.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Wynik:

![Porównanie wyrównania czcionki: Baseline, Top, Center i Bottom przy mieszanych rozmiarach czcionki](font_alignment.png)

Wyrównanie czcionki wykorzystuje metryki czcionki, więc widoczne krawędzie poszczególnych liter nie muszą dokładnie się pokrywać. Przykład zawiera zarówno wielką literę, jak i literę z opuszczonym ogonkiem, aby pokazać różnicę między wyrównaniem do linii bazowej a do dołu. Dostępność czcionki i jej podmiana, użyte znaki oraz różnica w rozmiarach czcionek wpływają na rezultat. Wymiary ramki, marginesy, odstępy wierszy, zawijanie i autofit również wpływają na układ; przy porównywaniu trybów używaj tych samych czcionek i ustawień układu.

To ustawienie różni się od [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), które kontroluje poziome wyrównanie akapitu, oraz od [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), które pozycjonuje blok tekstu pionowo w obrębie kształtu. Formatowanie indeksu górnego i dolnego przez [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) przesuwa poszczególne fragmenty względem linii bazowej zamiast ustawiać wyrównanie czcionki dla linii akapitu.

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0–255, a nie procentowa wartość przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ustaw półprzezroczyste czarne wypełnienie dla tekstu.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Ustaw przezroczystość fragmentu tekstu.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Wynik:

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstępy znaków w tekście**

Użyj [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/), aby rozciągnąć lub zmniejszyć odstępy między znakami w polu tekstowym. Przykłady dodają 3 punkty odstępu; wartości ujemne zmniejszają odstęp.

Poniższy kod C# pokazuje, jak rozciągnąć odstęp znaków w **całym akapicie**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Uwaga: użyj wartości ujemnych, aby skompresować odstępy znaków.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Rozszerz odstępy znaków.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Wynik:

![Odstępy znaków w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak rozciągnąć odstęp znaków w **fragmentach tekstu z pogrubioną czcionką**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Uwaga: użyj wartości ujemnych, aby skompresować odstępy znaków.
        portion.PortionFormat.Spacing = 3;  // Rozszerz odstępy znaków.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Wynik:

![Odstępy znaków w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Może się tak zdarzyć, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby uzyskać wynik bardziej zbliżony do PowerPoint w takich sytuacjach, możesz wyłączyć kerning dla fragmentów tekstu używających dotkniętej czcionki. Ustaw [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na wartość większą niż rzeczywisty rozmiar czcionki. Ten przykład wymaga pliku "presentation.pptx" z polem tekstowym jako pierwszym obiektem na pierwszym slajdzie. Sprawdza skuteczne nazwy czcionek, w tym dziedziczone, i ustawia próg 100 punktów dla fragmentów używających Roboto. To wyłącza kerning dla pasujących fragmentów o rozmiarze czcionki poniżej 100 punktów:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Dla pasującego tekstu poniżej progu to ustawienie zapobiega kerningowi i może pomóc dopasować renderowanie Aspose.Slides do wizualnego wyniku PowerPoint dla czcionek dotkniętych tym specyficznym zachowaniem PowerPoint.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu przez [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) lub na poszczególnych fragmentach przez [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Poniższy przykład ustawia domyślną czcionkę pierwszego akapitu na 12‑punktowy Times New Roman z pogrubieniem, pochyleniem i kreską kropkowaną podkreślenia. Jawne formatowanie na poszczególnych fragmentach ma pierwszeństwo przed tymi domyślnymi:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ustaw właściwości czcionki dla akapitu.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład stosuje 13‑punktowy Times New Roman, pochylenie i kropkowane podkreślenie do fragmentów, których skuteczne formatowanie jest pogrubione:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pug?")';
```

Wynik:

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Kontroluj normalizację wysokości tekstu**

Użyj [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) przy odtwarzaniu typografii szablonu lub badaniu różnic w wysokości znaków. W PowerPoint włączenie normalizacji rozciąga lub kompresuje poszczególne znaki pionowo, aby miały jednolitą widoczną wysokość w obrębie fragmentu tekstu. Nie gwarantuje to równej wysokości tekstu pomiędzy różnymi czcionkami.

Ustaw właściwość na [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), aby jawnie włączyć lub wyłączyć normalizację. `NullableBool.NotDefined` pozostawia ustawienie lokalne nieokreślone, tak aby fragment dziedziczył wartość, np. z [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) akapitu. Nie oznacza to `False`. Użyj [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) i odczytaj [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/), aby uzyskać rozwiązany wartość boolowską.

Poniższy, samodzielny przykład wymaga zainstalowanego **Arial**. Tworzy dwa bloki tekstu zawierające te same wielkie litery, małe litery, litery z opuszczonymi końcówkami i znaki diakrytyczne w rozmiarze 54 punktów. Oba akapity mają włączoną normalizację domyślnie. Górny fragment wyraźnie ją wyłącza; dolny ją dziedziczy. Rozmiary ramek, marginesy i odstępy akapitów są identyczne, a zawijanie i autofit są wyłączone, aby utrzymać spójność porównania. Przykład wypisuje `False: False` i `NotDefined: True`, a następnie zapisuje „text_height_normalization.pptx”.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Porównanie poniżej zostało wyeksportowane z zapisanej prezentacji. Górny wiersz ma wyłączoną normalizację (`False`); dolny wiersz dziedziczy włączone ustawienie (`NotDefined` → `True`). Zachowaj zainstalowany Arial, aby odtworzyć ten wygląd.

![Tekst Arial 54‑punktowy z wyłączoną normalizacją powyżej i dziedziczoną normalizacją włączoną poniżej](text_height_normalization.png)

Normalizacja zmienia wysokość znaków bez zmiany przypisanej [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), która określa rozmiar czcionki w punktach. [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) akapitu kontroluje odstępy wierszy, natomiast [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ramki tekstowej kontroluje, w jaki sposób tekst lub jego kontener dostosowuje się, aby pasował. Te ustawienia służą różnym celom i mogą niezależnie wpływać na ogólny układ. Po więcej informacji o formatowaniu akapitu i dziedziczeniu zobacz [Zarządzaj akapitem](/slides/pl/net/manage-paragraph/).

## **Zastosuj i usuń przekreślenie**

Użyj [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) na fragmencie tekstu, aby wyświetlić poprawki, anulowane terminy lub poprzednie ceny bez usuwania oryginalnego tekstu. Ustaw na [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/), aby dodać jedną lub dwie linie przez tekst.

Aby usunąć przekreślenie, przypisz `TextStrikethroughType.None`. To wyraźnie wyłącza efekt, nawet jeśli otaczające formatowanie określa przekreślenie. Natomiast `TextStrikethroughType.NotDefined` pozostawia ustawienie lokalne nieokreślone, pozwalając fragmentowi dziedziczyć formatowanie, np. z akapitu. Nie gwarantuje to usunięcia przekreślenia. Użyj [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), aby odczytać wynikowe formatowanie, w tym wartości dziedziczone.

Poniższy, samodzielny przykład tworzy trzy porównania cen. Każdy akapit ma oddzielne fragmenty dla etykiety, poprzedniej ceny i bieżącej ceny, więc tylko poprzednia cena jest modyfikowana. W pierwszym wierszu najpierw stosowane jest, a potem usuwane jest przekreślenie; pozostałe wiersze zachowują pojedyncze i podwójne przekreślenie. Zmiana tej właściwości zachowuje tekst i jego pozostałe formatowanie, w tym pogrubioną poprzednią cenę.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Zastosuj przekreślenie, a następnie wyraźnie usuń je z pierwszej poprzedniej ceny.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Wynik, od góry do dołu: brak przekreślenia, pojedyncze przekreślenie i podwójne przekreślenie.

![Poprzednie ceny bez przekreślenia, z pojedynczym przekreśleniem i podwójnym przekreśleniem](strikethrough.png)

## **Ustaw obrót tekstu**

Użyj [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/), aby ustawić predefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Ustaw własny obrót dla ramek tekstowych**

Użyj [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/), aby ustawić własny kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Wynik:

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw odstępy wierszy w akapitach**

Aspose.Slides udostępnia [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) i [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/), aby kontrolować odstępy akapitów. Te właściwości stosuje się w następujący sposób:

* Użyj dodatniej wartości, aby określić odstęp wierszy jako procent wysokości linii.
* Użyj ujemnej wartości, aby określić odstęp w punktach.

Poniższy przykład ustawia odstęp w obrębie pierwszego akapitu na 200 % wysokości linii (podwójny odstęp):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Wynik:

![Odstęp wierszy w akapicie](line_spacing.png)

## **Kontroluj łamanie linii**

Reguły łamania linii akapitu są przydatne w wąskich blokach tekstu i prezentacjach, które mieszają tekst łaciński i wschodnioazjatycki. Następujące właściwości należą do [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), więc dotyczą całego akapitu:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) kontroluje reguły łamania linii łacińskich. W mieszanym tekście zmiana tej opcji może również zmienić, gdzie zawijają się sąsiednie znaki wschodnioazjatyckie i interpunkcja.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) kontroluje reguły łamania linii wschodnioazjatyckich, w tym ograniczenia dotyczące znaków na początku i końcu linii.

Te reguły nie zastępują [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), który włącza automatyczne zawijanie w ramce tekstowej. Wpływają na układ, gdy zachodzi zawijanie; nie wstawiają znaków nowej linii. Jawne wstawienie znaku nowej linii wymusza nową linię w akapicie niezależnie od dostępnej szerokości.

Poniższy, samodzielny przykład tworzy wąski blok tekstu zawierający chiński i łaciński tekst. Ustawia obie właściwości łamania linii wyraźnie i zapisuje „line_breaking.pptx”. Aby eksperymentować z dowolną regułą, zmień wartość tej właściwości, pozostawiając drugie ustawienia bez zmian. Przykład używa 24‑punktowego Arial i SimSun przy szerokości ramki 160 punktów oraz zerowych poziomych marginesów ramki tekstowej. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) jest ustawiony na [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), aby rozmiar tekstu i wymiary ramki pozostały stałe.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Kontroluj wiszącą interpunkcję**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) pozwala dopuszczalnej interpunkcji wystawać poza prawą krawędź linii tekstu zamiast zajmować następną linię. Dotyczy całego akapitu i różni się od wcięcia wiszącego.

Poniższy, samodzielny przykład włącza wiszącą interpunkcję w ramce tekstowej o szerokości 100 punktów i zapisuje „hanging_punctuation.pptx”. Przy 24‑punktowym Arial i zerowych poziomych marginesach ramki tekstowej, końcowa kropka pozostaje po słowie „zdanie” i wystaje poza prawą krawędź tekstu. Ustaw właściwość na [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), aby porównać: przy tych ustawieniach kropka zajmuje oddzielną linię. Zawijanie jest włączone, a autofit wyłączony, aby zachować stałą dostępną szerokość.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Nie każda znaku interpunkcyjny może wisieć. Warunki czcionki i układu opisane powyżej ([kontrola łamania linii](#control-line-breaking)) również mają zastosowanie do tego porównania: zmiana czcionki, dostępnej szerokości, marginesów lub ustawień autofitu może usunąć widoczną różnicę.

## **Ustaw typ autofitu dla ramek tekstowych**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) określa, jak tekst zachowuje się, gdy przekracza granice kontenera. Użyj go, aby kontrolować, czy tekst się zmniejsza, wypływa poza kształt, czy automatycznie zmienia rozmiar kształtu. Poniższy przykład konfiguruje kształt tak, aby zmieniał rozmiar w celu dopasowania tekstu i zapisuje wynik jako „autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Aby policzyć linie po automatycznym zawijaniu i zobaczyć, jak zmiana szerokości tekstu lub kształtu wpływa na wynik, zobacz [Count Rendered Lines](/slides/pl/net/manage-paragraph/). Same liczby linii nie wskazują, czy tekst wypływa poza kontener.

## **Ustaw zakotwiczenie ramek tekstowych**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. u góry, w środku lub na dole. Poniższy przykład zakotwicza tekst na dole pierwszego kształtu i zapisuje wynik jako „text_anchor.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Ustaw tabulację tekstu**

Użyj [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) i [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/), aby skonfigurować tabulatory w akapicie. Poniższy przykład ustawia domyślny odstęp tabulacji na 100 punktów i dodaje lewostronny tabulator przy 30 punktach. Te ustawienia wpływają na tekst zawierający znaki tabulacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Wynik:

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), który pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład wymaga „presentation.pptx” z polem tekstowym jako pierwszym obiektem na pierwszym slajdzie oraz przynajmniej jednego akapitu. Zastępuje zawartość pierwszego akapitu tekstem „1。”, ustawia SimSun jako czcionkę i przypisuje język korekty chiński uproszczony (`zh-CN`). Zapisuje wynik jako „proofing_language.pptx”:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Ustaw język korekty na chiński uproszczony.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Kopiuj metadane językowe**

Podczas kopiowania wielojęzycznego tekstu z szablonu zachowaj zarówno [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), jak i [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Poniższy, samodzielny przykład tworzy fragment źródłowy z językiem US English jako językiem głównym i francuskim jako językiem alternatywnym, a następnie kopiuje tekst i identyfikatory do fragmentu w nowej prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Jeśli źródło nie ma języka alternatywnego, null czyści wartość docelową.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Aby wypróbować źródło bez języka alternatywnego, pomiń przypisanie „fr-FR”. Alternatywny identyfikator będzie wtedy `null`, a to samo polecenie kopiowania zachowa jego brak bez wprowadzania wartości domyślnej, nawet jeśli docelowy fragment miał wcześniej przypisany język alternatywny.

Te identyfikatory przechowują metadane językowe. Zachowanie ich nie ustala, który słownik PowerPoint wybierze do sprawdzania pisowni lub gramatyki.

## **Ustaw domyślny język**

Użyj [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/), aby określić domyślny język tekstu tworzonego podczas ładowania lub tworzenia prezentacji. Poniższy przykład tworzy prezentację z językiem tekstu US English jako domyślnym, dodaje pole tekstowe i wypisuje `en-US` dla jego pierwszego fragmentu tekstu.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Dodaj nowy kształt prostokąta z tekstem.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Sprawdź język pierwszego fragmentu.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Poniższy przykład ustawia 14‑punktową pogrubioną czcionkę jako domyślną dla akapitów najwyższego poziomu w nowej prezentacji i zapisuje ją jako „default_text_style.pptx”. Tekst może dziedziczyć te domyślne ustawienia, chyba że bardziej szczegółowe formatowanie je nadpisze.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Pobierz format akapitu najwyższego poziomu.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint zastosowanie efektu **All Caps** powoduje, że tekst wyświetlany jest wielkimi literami na slajdzie, nawet jeśli został wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy użyciu Aspose.Slides, biblioteka zwraca dokładnie tak wpisany tekst. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) i przekształć zwrócony ciąg na wielkie litery, gdy wartość to `All`.

Przykład wymaga „sample2.pptx” z polem tekstowym jako pierwszym obiektem na pierwszym slajdzie. W pierwszym akapicie jego pierwsza część zawiera „Hello, Aspose!” z zastosowanym efektem All Caps, co widać poniżej.

![Efekt wielkich liter](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Przeglądaj komórki i aktualizuj każdą komórkę przy pomocy [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) oraz formatowanie akapitu poprzez [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Jak zastosować gradientowy kolor do tekstu na slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Ustaw [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.

Related feature: [Formatowanie tekstu w slajdach](/slides/pl/features/text-formatting/).