---
title: Formatowanie tekstu prezentacji w .NET
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/net/text-formatting/
keywords:
- podświetlanie tekstu
- wyrażenie regularne
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstęp między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstępy między wierszami
- właściwość automatycznego dopasowania
- kotwica ramki tekstowej
- tabulacja tekstu
- język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Dostosuj czcionki, kolory, wyrównanie i więcej."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Obejmuje on podświetlanie, kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie automatycznego dopasowania, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Podświetlanie tekstu**

Użyj metody [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/), gdy potrzebujesz podświetlić tekst pasujący do określonego wzorca w ramce tekstowej. Metoda aplikuje kolor podświetlenia do pasujących fragmentów tekstu i może być użyta razem z [TextSearchOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/), aby kontrolować sposób przeprowadzania wyszukiwania, na przykład aby dopasować tylko całe wyrazy.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** i następnie podświetla tylko pełne słowo **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Pobierz pierwszy kształt z pierwszego slajdu.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Podświetl słowo "try" w kształcie.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Podświetl słowo "to" w kształcie.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/) podświetla dopasowania tekstu znalezione za pomocą wyrażenia regularnego. W .NET to API jest udostępniane w interfejsie [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/).

Poniższy przykład kodu podświetla wszystkie słowa zawierające **siedem lub więcej znaków**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Podświetl wszystkie słowa mające siedem lub więcej znaków.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Ustaw kolor tła tekstu**

Użyj [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/defaultportionformat/), aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/highlightcolor/), aby ustawić go dla poszczególnych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Wynik:

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównywanie akapitów tekstu**

Użyj [IParagraphFormat.Alignment](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/alignment/), aby ustawić wyrównanie akapitu wewnątrz ramki tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, wyjustowana i tak dalej.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ustaw wyrównanie akapitu na środku.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana za pomocą składnika alfa koloru przypisanego do [IPortionFormat.FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/fillformat/). W poniższych przykładach `alpha = 50` oznacza wartość kanału alfa w formacie ARGB w skali 0–255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Wynik:

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstęp między znakami w tekście**

Użyj [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/spacing/), aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym.

Poniższy kod C# pokazuje, jak zwiększyć odstęp między znakami w **całym akapicie**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zwiększ odstęp między znakami.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Odstęp między znakami w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstęp między znakami w **fragmentach tekstu z pogrubioną czcionką**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
            portion.PortionFormat.Spacing = 3;  // Zwiększ odstęp między znakami.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Odstęp między znakami w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco bardziej ściśle niż ten sam tekst wyświetlany w PowerPoint. Może się tak stać, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby uzyskać wynik renderowania bliższy PowerPoint w takich przypadkach, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na wartość znacznie większą niż rzeczywisty rozmiar czcionki:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

To ustawienie zapobiega stosowaniu kerningu do pasujących fragmentów tekstu i może pomóc wyrównać renderowanie Aspose.Slides do wizualnego wyniku PowerPoint dla czcionek dotkniętych tym specyficznym zachowaniem PowerPoint.

## **Zarządzanie właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu za pomocą [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/defaultportionformat/) lub na poszczególnych fragmentach za pomocą [IPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, przerywaną podkreślenie oraz czcionkę Times New Roman do wszystkich fragmentów w akapicie.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ustaw właściwości czcionki dla akapitu.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Ustaw właściwości czcionki dla fragmentu tekstu.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Ustaw obrót tekstu**

Użyj [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/textverticaltype/), aby ustawić predefiniowaną orientację tekstu wewnątrz kształtu.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Ustaw niestandardowy obrót dla ramek tekstowych**

Użyj [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/rotationangle/), aby ustawić niestandardowy kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw interlinię akapitów**

Aspose.Slides udostępnia [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/spacebefore/) oraz [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/spacewithin/), aby kontrolować odstępy akapitów. Właściwości te są używane w następujący sposób:

* Użyj wartości dodatniej, aby określić interlinię jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić interlinię w punktach.

Poniższy przykład kodu pokazuje, jak określić interlinię w akapicie:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Interlinia w akapicie](line_spacing.png)

## **Ustaw typ automatycznego dopasowania dla ramek tekstowych**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/autofittype/) określa, jak zachowuje się tekst, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst ma się zmniejszać, wypływać poza obręb, czy automatycznie zmieniać rozmiar kształtu.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Ustaw kotwicę ramek tekstowych**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/anchoringtype/) określa, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, na przykład u góry, w środku lub na dole.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Ustaw tabulację tekstu**

Użyj [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/defaulttabsize/) oraz [IParagraphFormat.Tabs](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/tabs/), aby skonfigurować tabulatory w akapicie.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Tabulatory akapitu](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [IPortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/languageid/), który umożliwia ustawienie języka korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Ustaw Id języka korekty.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Ustaw język domyślny**

Użyj [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/defaulttextlanguage/), aby określić domyślny język dla tekstu tworzonego podczas wczytywania lub tworzenia prezentacji.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Dodaj nowy prostokątny kształt z tekstem.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Sprawdź język pierwszego fragmentu.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/defaulttextstyle/).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 punktów dla całego tekstu na wszystkich slajdach w nowej prezentacji.

```cs
using (var presentation = new Presentation())
{
    // Pobierz format akapitu najwyższego poziomu.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Wyodrębnij tekst z efektem Wielkich Liter**

W programie PowerPoint zastosowanie efektu czcionki **All Caps** powoduje wyświetlanie tekstu wielkimi literami na slajdzie, nawet jeśli został on pierwotnie wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy użyciu Aspose.Slides, biblioteka zwraca tekst dokładnie taki, jaki został wprowadzony. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/net/aspose.slides/textcaptype/) i przekształć zwrócony ciąg na wielkie litery, gdy wartość to `All`.

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

![Efekt Wielkich Liter](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/). Przejdź przez komórki i zaktualizuj każdą komórkę za pomocą [ICell.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/textframe/) oraz formatowanie akapitu przez [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/paragraphformat/).

**Jak zastosować gradientowy kolor do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [IPortionFormat.FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/fillformat/). Ustaw [IFillFormat.FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.