---
title: Tekst van presentaties opmaken in .NET
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/net/text-formatting/
keywords:
- paragraaf uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertype-familie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autopas-eigenschap
- tekstframe-anker
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

In dit artikel wordt getoond hoe je tekst in PowerPoint‑ en OpenDocument‑presentaties kunt opmaken met Aspose.Slides voor .NET. Er wordt aandacht besteed aan achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstankering, tab‑stops en taalinrichtingen.

In de voorbeelden hieronder gebruiken we een bestand met de naam “sample.pptx”, dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of regex‑overeenkomsten te zoeken en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/net/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/highlightcolor/) voor individuele tekstgedeelten.

De volgende code‑voorbeeld laat zien hoe je de achtergrondkleur voor de **hele alinea** instelt:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de markeerkleur in voor de volledige alinea.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De grijze alinea](gray_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe je de achtergrondkleur voor **tekstgedeelten met een vette opmaak** instelt:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst alinea's uitlijnen**

Gebruik [IParagraphFormat.Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) om de uitlijning van een alinea binnen een tekstframe te bepalen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enz. zijn.

De volgende code‑voorbeeld laat zien hoe je de alinea **centraalt**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de uitlijning van de alinea in op gecentreerd.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie van tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/fillformat/). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op een schaal van 0‑255, geen transparantiepercentage.

De volgende code‑voorbeeld laat zien hoe je transparantie toepast op de **hele alinea**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Resultaat:

![De transparante alinea](transparent_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe je transparantie toepast op **tekstgedeelten met een vette opmaak**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Letterafstand voor tekst instellen**

Gebruik [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/spacing/) om de afstand tussen tekens in een tekstvak te vergroten of te verkleinen.

De volgende C#‑code toont hoe je de letterafstand in de **hele alinea** vergroot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Vergroot de tekenafstand.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De letterafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld laat zien hoe je de letterafstand in **tekstgedeelten met een vette opmaak** vergroot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.PortionFormat.Spacing = 3;  // Vergroot de tekenafstand.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De letterafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in PowerPoint is ingeschakeld.

Om de weergave dichter bij PowerPoint te laten komen, kun je kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/kerningminimalsize/) in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen om de rendering van Aspose.Slides meer in lijn te brengen met de visuele weergave van PowerPoint voor getroffen lettertypen.

## **Teksteigenschappen van lettertype beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) of per gedeelte via [IPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de volledige alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Stel de lettertype-eigenschappen in voor de alinea.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het onderstaande code‑voorbeeld past vergelijkbare eigenschappen toe op **tekstgedeelten met een vette opmaak**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/textverticaltype/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende code‑voorbeeld zet de tekstoriëntatie in de vorm op `Vertical270`, waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/rotationangle/) om een aangepaste rotatiehoek voor een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) in te stellen.

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacebefore/) en [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacewithin/) om de alinea‑afstand te controleren. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om regelafstand in punten op te geven.

De volgende code‑voorbeeld laat zien hoe je de regelafstand binnen de alinea specificeert:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autopasstype voor tekstframes instellen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik deze eigenschap om te bepalen of de tekst krimpt, overlapt of de vorm automatisch herschaalt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

Om het aantal regels na automatisch afbreken te tellen en te zien hoe de breedte van tekst of vorm het resultaat verandert, zie [Count Rendered Lines](/slides/nl/net/manage-paragraph/). Alleen het aantal regels geeft geen indicatie of tekst buiten de container valt.

## **Anker van tekstframes instellen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Teksttabulatie instellen**

Gebruik [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaulttabsize/) en [IParagraphFormat.Tabs](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/tabs/) om tab‑stops in een alinea te configureren.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De alinea tabs](paragraph_tabs.png)

## **Proeflezer taal instellen**

Aspose.Slides biedt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/), waarmee je de proeflezer‑taal voor een tekstgedeelte kunt instellen. De proeflezer‑taal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code‑voorbeeld toont hoe je de proeflezer‑taal voor een tekstgedeelte instelt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Stel de Id van een proeflezer‑taal in.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Voeg een nieuw rechthoekvorm toe met tekst.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Controleer de taal van het eerste tekstgedeelte.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Standaard tekststijl instellen**

Om standaard tekstopmaak op presentatieniveau toe te passen, gebruik je [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/defaulttextstyle/).

De volgende code‑voorbeeld laat zien hoe je een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst in alle dia’s van een nieuwe presentatie.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Tekst extraheren met het hoofdlettereffect**

In PowerPoint maakt het toepassen van het **All Caps**‑lettertype‑effect dat tekst in hoofdletters wordt weergegeven op de dia, zelfs als de tekst oorspronkelijk in kleine letters is getypt. Wanneer je een dergelijk tekstgedeelte met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst precies zoals ingevoerd. Om de weergegeven tekst te matchen, controleer je [TextCapType](https://reference.aspose.com/slides/nl/net/aspose.slides/textcaptype/) en zet je de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Stel, we hebben het volgende tekstvak op de eerste dia van het bestand sample2.pptx.

![Het hoofdlettereffect](all_caps_effect.png)

De volgende code‑voorbeeld laat zien hoe je de tekst met het **All Caps**‑effect kunt extraheren:

```cs
using Aspose.Slides;

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

**Hoe tekst in een tabel op een dia aanpassen?**

Gebruik [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) om tekst in een tabel te wijzigen. Loop door de cellen en werk elke cel bij via [ICell.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/textframe/) en stel de alinea‑opmaak in via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/paragraphformat/).

**Hoe een verloopkleur op tekst in een PowerPoint-dia toepassen?**

Gebruik [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/fillformat/) om een verloopkleur op tekst toe te passen. Stel [IFillFormat.FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformat/filltype/) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.