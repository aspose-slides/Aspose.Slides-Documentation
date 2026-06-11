---
title: Formatera presentationstext i .NET
linktitle: Textformatering
type: docs
weight: 50
url: /sv/net/text-formatting/
keywords:
- markera text
- reguljärt uttryck
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- teckensnittsegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textruta
- radavstånd
- autofit-egenskap
- textrutans förankring
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Denna artikel visar hur man formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Den täcker markering, bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textförankring, tabbstopp och språkinställningar.

I exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Markera text**

Använd [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/) när du behöver markera text som matchar ett specifikt exempel inom en textruta. Metoden applicerar en markeringsfärg på matchande textfragment och kan användas med [TextSearchOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/) för att styra hur sökningen utförs, till exempel för att bara matcha hela ord.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan bara hela ordet **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Hämta den första formen från den första bilden.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Markera ordet "try" i formen.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Markera ordet "to" i formen.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/) markerar textmatchningar som hittas med ett reguljärt uttryck. I .NET exponeras detta API på [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).

Kodexemplet nedan markerar alla ord som innehåller **sju eller fler tecken**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Markera alla ord med sju eller fler tecken.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Ange bakgrundsfärg för text**

Använd [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaultportionformat/) för att ange standardmarkeringsfärg för ett stycke, eller använd [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/highlightcolor/) för enskilda textdelar.

Följande kodexempel visar hur man anger bakgrundsfärg för **hela stycket**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ange markeringsfärgen för hela stycket.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan demonstrerar hur man anger bakgrundsfärg för **textdelar med fet stil**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Ange markeringsfärgen för textdelen.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![De gråa textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [IParagraphFormat.Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) för att ställa in styckejustering inom en textruta. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, blockjusterat med mera.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ställ in styckejusteringen till centrerad.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ange transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [IPortionFormat.FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/fillformat/). I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på 0–255‑skalan, inte en procentuell transparens.

Kodexemplet nedan visar hur man applicerar transparens på **hela stycket**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ställ in fyllningsfärgen för texten till transparent färg.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man applicerar transparens på **textdelar med fet stil**:

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
            // Ställ in transparensen för textdelen.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/spacing/) för att öka eller minska avståndet mellan tecken i en textruta.

Följande C#‑kod visar hur man ökar teckenavståndet i **hela stycket**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Obs: Använd negativa värden för att minska teckenavståndet.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Öka teckenavståndet.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man ökar teckenavståndet i **textdelar med fet stil**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Obs: Använd negativa värden för att komprimera teckenavståndet.
            portion.PortionFormat.Spacing = 3;  // Öka teckenavståndet.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan ske eftersom PowerPoint kan ignorera kerningdata för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att få den renderade utmatningen att bättre motsvara PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det berörda typsnittet. Sätt [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/kerningminimalsize/) till ett värde som är betydligt större än den faktiska typsnittsstorleken:

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

Denna inställning förhindrar att kerning tillämpas på matchande textdelar och kan hjälpa Aspose.Slides‑rendering att likna PowerPoints visuella resultat för de berörda typsnitten.

## **Hantera teckensnittsegenskaper för text**

Teckensnittsegenskaper kan anges på styckelnivå via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaultportionformat/) eller på individuella delar via [IPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/).

Följande kod sätter teckensnitt och textstil för hela stycket: den applicerar teckenstorlek, fet, kursiv, prickad understrykning och teckensnittet Times New Roman på alla delar i stycket.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Ange teckensnittsegenskaperna för stycket.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Teckensnittsegenskaperna för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan applicerar liknande egenskaper på **textdelar med fet stil**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Ange teckensnittsegenskaperna för textdelen.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Teckensnittsegenskaperna för textdelarna](font_properties_for_text_portions.png)

## **Ange textrotation**

Använd [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/textverticaltype/) för att ange en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till `Vertical270`, vilket roterar texten **90 grader moturs**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Textrotationen](text_rotation.png)

## **Ange anpassad rotation för textrutor**

Använd [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/rotationangle/) för att ange en anpassad rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).

Kodexemplet nedan roterar textrutan med 3 grader medurs inom formen:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Anpassad textroteringsvinkel](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spacebefore/) och [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spacewithin/) för att kontrollera styckeavstånd. Dessa egenskaper används enligt följande:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radhöjden.
* Använd ett negativt värde för att ange radavstånd i punkt.

Följande kodexempel visar hur man anger radavståndet inom stycket:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Radavståndet inom stycket](line_spacing.png)

## **Ange Autofit‑typ för textrutor**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/autofittype/) bestämmer hur text beter sig när den överskrider ramarna för sin behållare. Använd den för att styra om texten ska krympas, flöda över eller automatiskt anpassa formen.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Ange förankring för textrutor**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/anchoringtype/) definierar hur text placeras vertikalt i en form, exempelvis högst upp, i mitten eller längst ner.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Ange tabulering för text**

Använd [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaulttabsize/) och [IParagraphFormat.Tabs](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/tabs/) för att konfigurera tabbstopp i ett stycke.

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

Resultatet:

![Stycke‑tabbarna](paragraph_tabs.png)

## **Ange korrekturläsningsspråk**

Aspose.Slides tillhandahåller [IPortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/languageid/), vilket låter dig ange korrekturläsningsspråk för en textdel. Korrekturläsningsspråket bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur man anger korrekturläsningsspråk för en textdel:

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

    // Ställ in Id för ett korrekturläsningsspråk.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Ange standardspråk**

Använd [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/defaulttextlanguage/) för att definiera standardspråk för text som skapas vid inläsning eller skapande av en presentation.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Lägg till en ny rektangulär form med text.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Kontrollera språk för den första textdelen.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Ange standardtextstil**

För att tillämpa standardtextformatering på presentationsnivå, använd [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/defaulttextstyle/).

Följande kodexempel visar hur man ställer in ett standardfet typsnitt med storlek 14 pt för all text i en ny presentation.

```cs
using (var presentation = new Presentation())
{
    // Hämta styckeformatet på högsta nivån.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Extrahera text med “All Caps”-effekt**

I PowerPoint gör **All Caps**‑effekten att text visas med stora bokstäver på bilden även om den ursprungligen skrevs med små bokstäver. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/net/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Anta att vi har följande textruta på den första bilden i filen sample2.pptx.

![All Caps‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar text med **All Caps**‑effekten applicerad:

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

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/textframe/) och styckeformatering via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/paragraphformat/).

**Hur applicerar man gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IPortionFormat.FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/fillformat/). Ställ in [IFillFormat.FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformat/filltype/) på [FillType.Gradient](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.