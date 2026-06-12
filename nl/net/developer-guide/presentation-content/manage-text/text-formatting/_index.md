---
title: Tekst in presentaties opmaken in .NET
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/net/text-formatting/
keywords:
- tekst markeren
- reguliere expressie
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Formatteer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel toont hoe u tekst opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET. Het behandelt markering, achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstverankering, tabs en taalinstellingen.

In de onderstaande voorbeelden gebruiken we een bestand genaamd "sample.pptx", dat een enkel tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Tekst markeren**

Gebruik de [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/) methode wanneer u tekst moet markeren die overeenkomt met een specifiek voorbeeld binnen een tekstframe. De methode past een markeringskleur toe op overeenkomstige tekstdelen en kan worden gebruikt met [TextSearchOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/) om te bepalen hoe de zoekopdracht wordt uitgevoerd, bijvoorbeeld om alleen hele woorden te matchen.

Het code‑voorbeeld hieronder markeert alle verschijningen van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Haal de eerste vorm op van de eerste dia.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Markeer het woord "try" in de vorm.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Markeer het woord "to" in de vorm.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/) methode markeert tekstuele overeenkomsten die gevonden worden met een reguliere expressie. In .NET wordt deze API aangeboden via [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).

Het code‑voorbeeld hieronder markeert alle woorden die **zeven of meer tekens** bevatten:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Markeer alle woorden met zeven of meer tekens.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Achtergrondkleur van tekst instellen**

Gebruik [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) om de standaard markeringskleur voor een alinea in te stellen, of gebruik [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/highlightcolor/) voor individuele tekstgedeelten.

De volgende code toont hoe u de achtergrondkleur voor de **hele alinea** instelt:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de markeringskleur in voor de hele alinea.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de achtergrondkleur voor **tekstgedeelten met een vette opmaak** instelt:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Stel de markeringskleur in voor het tekstgedeelte.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst alinea’s uitlijnen**

Gebruik [IParagraphFormat.Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) om de uitlijning van alinea’s binnen een tekstframe in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

De volgende code toont hoe u de alinea **centraalt**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de uitlijning van de alinea in op gecentreerd.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [IPortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/fillformat/). In de voorbeelden hieronder is `alpha = 50` een ARGB‑alfakanaalwaarde op de schaal 0‑255, geen transparantie‑percentage.

De volgende code toont hoe u transparantie toepast op de **hele alinea**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de vulkleur van de tekst in op een transparante kleur.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

De volgende code toont hoe u transparantie toepast op **tekstgedeelten met een vette opmaak**:

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
            // Stel de transparantie van het tekstgedeelte in.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/spacing/) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen.

De volgende C#‑code toont hoe u de tekenafstand in de **hele alinea** vergroot:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Opmerking: gebruik negatieve waarden om de tekenafstand te comprimeren.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Vergroot de tekenafstand.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de tekenafstand in **tekstgedeelten met een vette opmaak** vergroot:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Opmerking: gebruik negatieve waarden om de tekenafstand te comprimeren.
            portion.PortionFormat.Spacing = 3;  // Vergroot de tekenafstand.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de weergave dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/kerningminimalsize/) in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen om de weergave van Aspose.Slides te laten overeenstemmen met de visuele output van PowerPoint voor de getroffen lettertypen.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) of per onderdeel via [IPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/).

De volgende code zet het lettertype en de tekststijl voor de **hele alinea**: hij past lettergrootte, vet, cursief, gestippelde onderstreping en het Times New Roman‑lettertype toe op alle gedeelten in de alinea.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de lettertype‑eigenschappen voor de alinea in.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het code‑voorbeeld hieronder past gelijkaardige eigenschappen toe op **tekstgedeelten met een vette opmaak**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Stel de lettertype-eigenschappen voor het tekstgedeelte in.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/textverticaltype/) om een vooraf gedefinieerde tekstrichting binnen een vorm in te stellen.

De volgende code stelt de tekstrichting van de vorm in op `Vertical270`, waarmee de tekst **90 graden tegen de klok in** wordt geroteerd:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/rotationangle/) om een aangepaste rotatiehoek voor een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) in te stellen.

Het code‑voorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacebefore/) en [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacewithin/) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als een percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

De volgende code toont hoe u de regelafstand binnen de alinea specificeert:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autofit‑type voor tekstframes instellen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst zich gedraagt wanneer ze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst krimpt, overlapt of de vorm automatisch verkleint/groot maakt.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Anker van tekstframes instellen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Tabulatie van tekst instellen**

Gebruik [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaulttabsize/) en [IParagraphFormat.Tabs](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/tabs/) om tab‑posities in een alinea te configureren.

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

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Controle‑taal instellen**

Aspose.Slides biedt [IPortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/languageid/), waarmee u de controle‑taal voor een tekstgedeelte kunt instellen. De controle‑taal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code toont hoe u de controle‑taal voor een tekstgedeelte instelt:

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

    // Stel de Id van een controle-taal in.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/) om de standaardtaal voor tekst die tijdens het laden of aanmaken van een presentatie wordt gecreëerd, te definiëren.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Voeg een nieuwe rechthoekvorm toe met tekst.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Controleer de taal van het eerste tekstgedeelte.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Standaardtekststijl instellen**

Om standaard‑tekstopmaak op presentatieniveau toe te passen, gebruikt u [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/defaulttextstyle/).

De volgende code stelt een standaard vet lettertype met een grootte van 14 pt in voor alle tekst in de dia’s van een nieuwe presentatie.

```cs
using (var presentation = new Presentation())
{
    // Haal het alinea‑formaat van het hoogste niveau op.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, ook al is deze oorspronkelijk in kleine letters getypt. Wanneer u zo’n tekstgedeelte met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst exact zoals ingevoerd. Om de weergave te laten overeenkomen, controleert u [TextCapType](https://reference.aspose.com/slides/nl/net/aspose.slides/textcaptype/) en zet u de geretourneerde tekenreeks om in hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![Het All‑Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe u de tekst met het **All Caps**‑effect extrahereert:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruikt u [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/). Loop door de cellen en werk elke cel bij via [ICell.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/textframe/) en alinea‑opmaak via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/paragraphformat/).

**Hoe pas ik een kleurverloop toe op tekst in een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruikt u [IPortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/fillformat/). Stel [IFillFormat.FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformat/filltype/) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.