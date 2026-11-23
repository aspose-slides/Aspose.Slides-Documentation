---
title: Presentatietekst opmaken in .NET
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
- autofit-eigenschap
- tekstframe anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Formatteren en stijlen van tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑verankering, tab‑stops en taalinstellingen.

tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak en de eerste alinea bevat de onderstaande tekst. Zowel dia‑ als vorm‑indexen beginnen bij nul. Voorbeelden die vette delen selecteren, gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoek en vervang tekst](/slides/nl/net/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang op deze standaard:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de markeerkleur in voor de volledige alinea.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de achtergrondkleur instelt voor **tekstgedeelten met een vet lettertype**:

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

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst‑alinea's uitlijnen**

Gebruik [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) om de alinea‑uitlijning binnen een tekstframe in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld enzovoort zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** uitlijnt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de uitlijning van de alinea in op centrum.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertypes binnen een regel uitlijnen**

Gebruik [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) om tekstgedeelten met verschillende lettergrootten binnen een regel verticaal uit te lijnen. Deze instelling geldt voor de hele alinea en bepaalt de uitlijning binnen elke regel ervan.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst op 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omloop uit, en houdt de tekstframes groot genoeg voor één regel.

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

![Vergelijking van baseline-, boven-, midden- en onder‑lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning gebruikt lettertype‑metrieken, dus de zichtbare randen van individuele letters komen niet per se precies op één lijn. Het voorbeeld bevat zowel een hoofdletter als een dalende letter om het verschil tussen baseline‑ en onder‑uitlijning te laten zien. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑afmetingen, marges, regelafstand, omloop en autofit beïnvloeden ook de layout; gebruik dezelfde lettertypen en layoutinstellingen bij het vergelijken van de modi.

Deze instelling verschilt van [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), die de horizontale alinea‑uitlijning regelt, en [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) verschuift individuele gedeelten ten opzichte van de baseline in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie van tekst instellen**

Transparantie van tekst wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de 0‑255‑schaal, geen transparantie‑percentage.

Het code‑voorbeeld hieronder toont hoe u transparantie toepast op de **hele alinea**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel een halftransparante zwarte vulling in voor de tekst.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten afstand toe; negatieve waarden verkleinen de tekst.

De volgende C#‑code toont hoe u de tekenafstand in de **hele alinea** vergroot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Vergroot de tekenafstand.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

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
        // Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
        portion.PortionFormat.Spacing = 3;  // Vergroot de tekenafstand.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan door Aspose.Slides gerenderde tekst er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in de PowerPoint‑instellingen is ingeschakeld.

Om de gerenderde output dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert de effectieve lettertype‑namen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeelten met een lettergrootte onder 100 punten:

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

Voor tekst die onder de drempel valt, voorkomt deze instelling kerning en kan het helpen de weergave van Aspose.Slides af te stemmen op de visuele output van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekst‑lettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) of op individuele gedeelten via [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaardinstellingen:

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

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

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
        // Stel de lettertype-eigenschappen in voor het tekstgedeelte.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) bij het reproduceren van sjabloon‑typografie of bij het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt het inschakelen van normalisatie individuele tekens verticaal uit of comprimeert ze om een uniforme zichtbare hoogte binnen het tekstgedeelte te geven. Het garandeert geen gelijke teksthoogten tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) om normalisatie expliciet in te schakelen of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling onveranderd, zodat het gedeelte de waarde erft, bijvoorbeeld van de alinea‑[DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/). Het betekent niet `False`. Gebruik [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) en lees [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) om de uiteindelijke Booleaanse waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist dat **Arial** geïnstalleerd is. Het maakt twee tekstblokken die dezelfde hoofdletters, kleine letters, dalende tekens en accented tekens bevatten op 54 punten. Beide alinea's schakelen normalisatie standaard in. Het bovenste gedeelte schakelt het expliciet uit; het onderste gedeelte erft het. De frame‑groottes, marges en alinea‑afstand zijn identiek, met omloop en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld print `False: False` en `NotDefined: True`, en slaat vervolgens “text_height_normalization.pptx” op.

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

De vergelijking hieronder is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial 54-punt tekst met normalisatie uitgeschakeld bovenaan en geërfde normalisatie ingeschakeld beneden](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) te wijzigen, die de lettergrootte in punten aangeeft. Alinea‑[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) regelt de regelafstand, terwijl tekst‑frame‑[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst of de container zich aanpast om te passen. Deze instellingen hebben verschillende doeleinden en kunnen de algehele layout onafhankelijk beïnvloeden. Voor meer over alinea‑opmaak en overerving, zie [Beheer alinea](/slides/nl/net/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) op een tekstgedeelte om correcties, geannuleerde termen of vorige prijzen weer te geven zonder de originele tekst te verwijderen. Stel het in op [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) voor één of twee doorhalingsstrepen.

Om doorhalen te verwijderen, ken `TextStrikethroughType.None` toe. Dit schakelt het effect expliciet uit, zelfs als de omliggende opmaak doorhalen specificeert. Daarentegen laat `TextStrikethroughType.NotDefined` de lokale instelling ongedefinieerd, waardoor het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) om de resulterende opmaak te lezen, inclusief geërfde waarden.

Het volgende zelfstandige voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft afzonderlijke gedeelten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het daarna; de andere rijen behouden respectievelijk enkel en dubbel doorhalen. Het wijzigen van deze eigenschap behoudt de tekst en de overige opmaak, inclusief de vetgedrukte vorige prijs.

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

Het resultaat, van boven naar beneden: geen doorhalen, enkel doorhalen en dubbel doorhalen.

![Vorige prijzen zonder doorhalen, met enkel doorhalen, en met dubbel doorhalen](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), waardoor de tekst **90 graden tegen de klok in** wordt geroteerd:

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

![De tekstrotatie](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om een tweecijferig getal bij elkaar te houden in een verticaal Japans label, plaatst u beide cijfers in één tekstgedeelte en stelt u [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) voor dat gedeelte in. Het voorbeeld gebruikt [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) en 40‑punt MS Gothic voor beide labels. Alleen de waarde van [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) die aan het numerieke gedeelte is toegewezen, verschilt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

In PowerPoint toont het linkerlabeled (`True`) de cijfers rechtop en naast elkaar tussen 和 en 年. In het rechterlabel (`False`) wordt het paar 90 graden met de klok mee geroteerd. De omringende Japanse tekens blijven in beide labels rechtop.

![PowerPoint‑vergelijking van verticale datum‑labels met rechtopstaande cijfers links en geroteerde cijfers rechts](vertical_date.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) om een aangepaste rotatiehoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Het code‑voorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

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

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) en [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als een percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de ruimte binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

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

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking regelen**

Regels voor alinea‑regelafbreking zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende eigenschappen behoren tot [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), zodat ze op een volledige alinea van toepassing zijn:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) regelt de regelafbrekingsregels voor Latijn. In gemengde tekst kan het aanpassen hiervan ook beïnvloeden waar aangrenzende Oost‑Aziatische tekst en interpunctie worden afgebroken.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) regelt de regelafbrekingsregels voor Oost‑Aziatisch, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), die automatisch omloop binnen een tekstframe inschakelt. Ze beïnvloeden de layout wanneer omloop plaatsvindt; ze voegen geen regelbreektekens in. Een expliciete regelbreuk dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbrekings‑eigenschappen expliciet in en slaat “line_breaking.pptx” op. Om met één van de regels te experimenteren, verandert u de waarde van die eigenschap terwijl de andere instellingen gelijk blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekst‑frame‑marges. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) is ingesteld op [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) laat in aanmerking komende interpunctie uitsteken voorbij de rechterkant van de tekstlijn in plaats van de volgende regel in te nemen. Het geldt voor de hele alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punt breed tekstframe in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de laatste punt achter “sentence” en strekt zich uit voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omloop is ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk interpunctieteken kan hangen. De [lettertype‑ en layout‑voorwaarden beschreven hierboven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstframes instellen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst krimpt, overlapt of de vorm automatisch aanpast. Het volgende voorbeeld configureert de vorm zo dat deze zich aanpast aan de tekst en slaat het resultaat op in “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Om het aantal regels te tellen na automatische omloop en te zien hoe tekst‑ of vormbreedte het resultaat beïnvloedt, zie [Aantal gerenderde regels](/slides/nl/net/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstframes instellen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in “text_anchor.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Tekst‑tabulatie instellen**

Gebruik [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) en [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaardtab‑intervallen in op 100 punten en voegt een links‑gealigneerde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst met tab‑tekens.

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

![De alinea‑tabs](paragraph_tabs.png)

## **Proefleestaal instellen**

Aspose.Slides biedt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) waarmee u de proefleestaal voor een tekstgedeelte kunt instellen. De proefleestaal bepaalt de taal die in PowerPoint wordt gebruikt voor spelling‑ en grammaticacontrole.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en minimaal één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese proefleestaal toe (`zh-CN`). Het slaat het resultaat op in “proofing_language.pptx”:

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

Bij het kopiëren van meertalige tekst uit een sjabloon moet u zowel [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) als [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) behouden. Het volgende zelfstandige voorbeeld maakt een bron‑gedeelte met VS‑Engels als taal en Frans als alternatieve taal en kopieert de tekst en identificatoren naar een gedeelte in een nieuwe presentatie.

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

Om een bron zonder alternatieve taal te testen, laat u de toewijzing van `"fr-FR"` weg. De alternatieve identifier is dan `null`, en dezelfde kopieer‑instructie behoudt de afwezigheid zonder een standaardwaarde in te voeren, zelfs als de bestemming eerder een alternatieve taal had toegewezen.

Deze identificatoren worden opgeslagen als taal‑metadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint kiest voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) om de standaardtaal voor tekst te definiëren die tijdens het laden of maken van een presentatie wordt aangemaakt. Het volgende voorbeeld maakt een presentatie met VS‑Engels als standaardteksttaal, voegt een tekstvak toe en print `en-US` voor het eerste tekstgedeelte.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Voeg een nieuw rechthoekig vorm toe met tekst.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Controleer de taal van het eerste tekstgedeelte.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Standaardtekst‑stijl instellen**

Om standaardtekst‑opmaak op presentatieniveau toe te passen, gebruik [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea's op het hoogste niveau in een nieuwe presentatie en slaat het op als “default_text_style.pptx”. Tekst kan deze standaarden erven tenzij specifiekere opmaak ze overschrijft.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Haal het alineaformaat van het hoogste niveau op.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt getoond op de dia, zelfs als deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst exact terug zoals ingevoerd. Om de weergegeven tekst overeen te laten komen, controleer [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) en zet de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat “Hello, Aspose!” met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe u de tekst met het **All Caps**‑effect kunt extraheren:

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

**Hoe pas ik een gradientkleur toe op tekst in een PowerPoint‑dia?**

Om een gradientkleur op tekst toe te passen, gebruik [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Stel [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) en configureer de gradientstops, richting en transparantie.

Gerelateerde functie: [Tekst opmaken binnen dia's](/slides/nl/features/text-formatting/).