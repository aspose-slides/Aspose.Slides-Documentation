---
title: Opmaak van presentatietekst in .NET
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/net/text-formatting/
keywords:
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
- automatisch passend eigenschap
- tekstframe anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, automatisch passend gedrag, tekstverankering, tabstops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak en de eerste alinea bevat de hieronder weergegeven tekst. Zowel dia‑ als vorm‑indexen zijn nul‑gebaseerd. Voorbeelden die vetgedrukte gedeeltes selecteren, gebruiken effectieve opmaak, inclusief geërfde vetopmaak:

![Sample text](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/net/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) voor individuele tekstgedeeltes.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeeltes hebben voorrang op deze standaard:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de markeerkleur in voor de hele alinea.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The gray paragraph](gray_paragraph.png)

De code‑voorbeeld hieronder toont hoe je de achtergrondkleur instelt voor **tekstgedeeltes met een vet lettertype**:

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
        // Stel de markeerkleur in voor het tekstgedeelte.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The gray text portions](gray_text_portions.png)

## **Alinea‑tekst uitlijnen**

Gebruik [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) om de uitlijning van de alinea binnen een tekstvak in te stellen. De waarde kan gecentreerd, links­uitgelijnd, rechts­uitgelijnd, uitgevuld, enz. zijn.

Het volgende code‑voorbeeld toont hoe je de alinea **centraal** uitlijnt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de uitlijning van de alinea in op gecentreerd.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The aligned paragraph](aligned_paragraph.png)

## **Lettertypen binnen een regel uitlijnen**

Gebruik [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) om tekstgedeeltes met verschillende lettergrootten binnen een regel verticaal uit te lijnen. Deze instelling geldt voor de hele alinea en regelt de uitlijning binnen elke regel.

Het volgende zelf­standige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst met 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt automatisch passend en regelafbreking uit, en houdt de tekstvakken groot genoeg voor één regel.

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

Het resultaat:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Lettertype‑uitlijning maakt gebruik van lettertype‑metrieken, dus de zichtbare randen van individuele letters komen niet per‑se exact op één lijn. Het voorbeeld bevat zowel een hoofdletter als een descender om het verschil tussen basislijn‑ en onderkant‑uitlijning te illustreren. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens en het verschil in lettergrootte beïnvloeden het resultaat. Frame‑afmetingen, marges, regelafstand, afbreking en automatisch passend beïnvloeden eveneens de lay‑out; gebruik dezelfde lettertypen en lay‑outinstellingen bij het vergelijken van modi.

Deze instelling verschilt van [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), die horizontale alinea‑uitlijning regelt, en van [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) verplaatst individuele gedeeltes ten opzichte van de basislijn in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die aan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) is toegewezen. In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op de schaal 0–255, geen transparantie‑percentage.

Het code‑voorbeeld hieronder laat zien hoe je transparantie toepast op de **hele alinea**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel een semitransparante zwarte vulling in voor de tekst.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The transparent paragraph](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe je transparantie toepast op **tekstgedeeltes met een vet lettertype**:

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
        // Stel de transparantie van het tekstgedeelte in.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The transparent text portions](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten spacing toe; negatieve waarden verkleinen de tekst.

Het volgende C#‑code‑voorbeeld laat zien hoe je de tekenafstand in de **hele alinea** vergroot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Opmerking: gebruik negatieve waarden om de tekenafstand samen te trekken.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Uitbreiden van de tekenafstand.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe je de tekenafstand in **tekstgedeeltes met een vet lettertype** vergroot:

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
        // Opmerking: gebruik negatieve waarden om de tekenafstand samen te trekken.
        portion.PortionFormat.Spacing = 3;  // Uitbreiden van de tekenafstand.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dat kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in PowerPoint is ingeschakeld.

Om de weergave dichter bij PowerPoint te brengen, kun je kerning uitschakelen voor tekstgedeeltes die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertype‑namen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeeltes die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeeltes met een lettergrootte onder 100 punten:

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

Voor tekst die onder de drempel ligt, voorkomt deze instelling kerning en kan helpen om de weergave van Aspose.Slides beter af te stemmen op de visuele output van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) of op individuele gedeeltes via [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeeltes heeft voorrang op deze standaarden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de lettertype‑eigenschappen in voor de alinea.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeeltes waarvan de effectieve opmaak vet is:

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
        // Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) bij het reproduceren van sjabloon‑typografie of bij het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt of comprimeert het inschakelen van normalisatie individuele tekens verticaal zodat ze een uniforme zichtbare hoogte krijgen binnen de tekstgedeelte. Het garandeert geen gelijke teksthoogten tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True of False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling ongedefinieerd zodat het gedeelte de waarde erft, bijvoorbeeld van de alinea‑[DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/). Het betekent niet `False`. Gebruik [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) en lees [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) om de geëvalueerde Boole‑waarde te verkrijgen.

Het volgende zelf­standige voorbeeld vereist **Arial** geïnstalleerd. Het maakt twee tekstblokken met dezelfde hoofdletters, kleine letters, descenders en geaccentueerde tekens op 54 punten. Beide alinea’s hebben normalisatie standaard ingeschakeld. Het bovenste gedeelte schakelt het expliciet uit; het onderste erft het. De frame‑groottes, marges en alinea‑afstand zijn identiek, met afbreking en automatisch passend uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld schrijft `False: False` en `NotDefined: True`, en slaat “text_height_normalization.pptx” op.

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

De onderstaande vergelijking is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)‑waarde te wijzigen, die de lettergrootte in punten aangeeft. Alinea‑[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) regelt regelafstand, terwijl tekst‑frame‑[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doelen en kunnen de algehele lay‑out onafhankelijk van elkaar beïnvloeden. Zie voor meer over alinea‑opmaak en overerving [Alinea beheren](/slides/nl/net/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) op een tekstgedeelte om correcties, geannuleerde termen of oude prijzen te tonen zonder de oorspronkelijke tekst te verwijderen. Stel in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) voor één of twee doorstreepte lijnen.

Om doorhalen te verwijderen, ken `TextStrikethroughType.None` toe. Dit schakelt het effect expliciet uit, zelfs als de omringende opmaak doorstreping specificeert. Daarentegen laat `TextStrikethroughType.NotDefined` de lokale instelling ongedefinieerd, zodat het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorstreping wordt verwijderd. Gebruik [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) om de resulterende opmaak, inclusief geërfde waarden, uit te lezen.

Het volgende zelf­standige voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft aparte gedeeltes voor het label, de oude prijs en de nieuwe prijs, zodat alleen de oude prijs wordt beïnvloed. De eerste rij past doorstreping toe en verwijdert deze vervolgens; de andere rijen behouden enkel‑respectievelijk dubbele doorstreping. Het wijzigen van deze eigenschap behoudt de tekst en andere opmaak, inclusief het vetgedrukte oude bedrag.

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

// Pas doorhaling toe, en verwijder deze vervolgens expliciet van de eerste vorige prijs.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Het resultaat, van boven naar beneden: geen doorstreping, enkele doorstreping en dubbele doorstreping.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The text rotation](text_rotation.png)

## **Aangepaste rotatie voor tekstvakken instellen**

Gebruik [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) om een aangepaste rotatiehoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Het code‑voorbeeld hieronder draait het tekstvak met 3 graden met de klok mee binnen de vorm:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The custom text rotation](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) en [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als een percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

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

Het resultaat:

![The line spacing within the paragraph](line_spacing.png)

## **Regelafbreking regelen**

Regels voor regelafbreking van alinea’s zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende eigenschappen behoren tot [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), dus ze zijn van toepassing op een volledige alinea:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) regelt de regelafbrekingsregels voor Latijn. In gemengde tekst kan het wijzigen hiervan ook beïnvloeden waar aangrenzende Oost‑Aziatische tekst en interpunctie afbreken.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) regelt de regelafbrekingsregels voor Oost‑Aziatische tekst, inclusief beperkingen op tekens aan het begin en einde van een regel.

Deze regels vervangen niet [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), die automatische afbreking binnen een tekstvak inschakelt. Ze beïnvloeden de lay‑out wanneer afbreking plaatsvindt; ze voegen geen regelafbrekings‑tekens in. Een expliciete regelafbreking dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelf­standige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbrekings‑eigenschappen expliciet in en slaat “line_breaking.pptx” op. Om een van beide regels te testen, wijzig je de waarde van die eigenschap terwijl je de andere instellingen ongewijzigd laat. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en horizontale tekst‑frame‑marges op nul. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) is ingesteld op [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

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

## **Hangende interpunctie regelen**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) laat toegestane interpunctie voorbij de rechterrand van de tekstlijn uitsteken in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelf­standige voorbeeld schakelt hangende interpunctie in een 100‑punt breed tekstvak in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de laatste punt na “sentence” staan en reikt voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen zit de punt op een aparte regel. Afbreking is ingeschakeld en automatisch passend is uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑outvoorwaarden die hierboven zijn beschreven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of automatisch passend kan het zichtbare verschil wegnemen.

## **Automatisch passend type voor tekstvakken instellen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of de vorm automatisch schaalt. Het volgende voorbeeld configureert de vorm zodat deze wordt geschaald om de tekst te passen en slaat het resultaat op als “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Om het aantal regels na automatische afbreking te tellen en te zien hoe tekst‑ of vorm‑breedte het resultaat beïnvloedt, zie [Aantal gerenderde regels tellen](/slides/nl/net/manage-paragraph/). Alleen het aantal regels geeft geen aan of tekst buiten de container overlapt.

## **Anker van tekstvakken instellen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als “text_anchor.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Tabulatie voor tekst instellen**

Gebruik [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) en [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) om tabstops in een alinea in te stellen. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 punten en voegt een links‑uitgelijnde tabstop toe op 30 punten. Deze instellingen beïnvloeden tekst met tab‑tekens.

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

Het resultaat:

![The paragraph tabs](paragraph_tabs.png)

## **Taal voor proeflezen instellen**

Aspose.Slides biedt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), waarmee je de proeflees‑taal voor een tekstgedeelte kunt instellen. De proefleestaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en kent de vereenvoudigde Chinees proefleestaal toe (`zh-CN`). Het slaat het resultaat op als “proofing_language.pptx”:

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

// Stel de proefleestaal in op Vereenvoudigd Chinees.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Taal‑metadata kopiëren**

Wanneer je meertalige tekst uit een sjabloon kopieert, bewaar zowel [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) als [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Het volgende zelf­standige voorbeeld maakt een bron‑gedeelte met Amerikaans‑Engels als taal en Frans als alternatieve taal en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

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
// Als de bron geen alternatieve taal heeft, maakt null de bestemmingswaarde leeg.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Om een bron zonder alternatieve taal te proberen, laat je de toewijzing van `"fr-FR"` weg. De alternatieve identifier is dan `null`, en dezelfde kopie‑instructie behoudt de afwezigheid zonder een standaardwaarde in te voeren, zelfs als de bestemming eerder een alternatieve taal had toegewezen.

Deze identifiers vormen taal‑metadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint selecteert voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) om de standaardtaal voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie te definiëren. Het volgende voorbeeld maakt een presentatie met Amerikaans‑Engels als standaard‑teksttaal, voegt een tekstvak toe en drukt `en-US` af voor het eerste tekstgedeelte.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Voeg een nieuw rechthoekvorm met tekst toe.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Controleer de taal van het eerste gedeelte.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Standaard‑tekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea’s van eerste niveau in een nieuwe presentatie en slaat het op als “default_text_style.pptx”. Tekst kan deze standaarden erven tenzij specifiekere opmaak ze overschrijft.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Verkrijg het alineaformaat van het bovenste niveau.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Tekst met All‑Caps‑effect extraheren**

In PowerPoint zorgt het toepassen van de **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer je zo’n tekstgedeelte met Aspose.Slides ophaalt, geeft de bibliotheek de tekst exact terug zoals ingevoerd. Om de weergegeven tekst overeen te laten komen, controleer je [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) en zet je de teruggegeven string om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat “Hello, Aspose!” met het All‑Caps‑effect toegepast, zoals hieronder weergegeven.

![The All Caps effect](all_caps_effect.png)

Het code‑voorbeeld hieronder laat zien hoe je de tekst met het **All Caps**‑effect extraheert:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Doorloop de cellen en werk elke cel bij via [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) en alinea‑opmaak via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Hoe pas ik een gradient‑kleur toe op tekst in een PowerPoint‑dia?**

Om een gradient‑kleur op tekst toe te passen, gebruik [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Stel [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.

Gerelateerde functie: [Tekst binnen dia’s opmaken](/slides/nl/features/text-formatting/).