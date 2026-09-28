---
title: Tekst in presentaties opmaken in .NET
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
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatie‑hoek
- tekstkader
- regelafstand
- autofit‑eigenschap
- anker van tekstkader
- tabulatie van tekst
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Formatteer en styleer tekst in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, ankerinstellingen, tab‑stops en taalinstellingen.

Tenzij anders aangegeven, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea bevat de hieronder weergegeven tekst. Zowel dia‑ als vormindices zijn nulgebaseerd. Voorbeelden die vette delen selecteren, gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/net/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/highlightcolor/) voor individuele tekstdelen.

Het volgende voorbeeld stelt een lichtgrijze markering in als de standaard voor de eerste alinea. Expliciete markeerkleuren op individuele delen hebben voorrang op deze standaard:

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

![De grijze alinea](gray_paragraph.png)

Het onderstaande code‑voorbeeld laat zien hoe u de achtergrondkleur kunt instellen voor **tekstgedeelten met een vet lettertype**:

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

## **Tekst­alinea's uitlijnen**

Gebruik [IParagraphFormat.Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) om de alinia‑uitlijning binnen een tekstkader in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** kunt uitlijnen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Stel de uitlijning van de alinea in op midden.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

Teksttransparantie wordt geregeld via de alfa‑component van de kleur die is toegewezen aan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/fillformat/). In de onderstaande voorbeelden is `alpha = 50` een ARGB alfa‑kanaalwaarde op de schaal 0–255, geen transparantiepercentage.

Het onderstaande code‑voorbeeld toont hoe u transparantie toepast op de **hele alinea**:

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

Gebruik [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/spacing/) om de ruimte tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten afstand toe; negatieve waarden verkleinen de tekst.

De volgende C#‑code toont hoe u de tekenafstand in de **hele alinea** kunt uitbreiden:

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

Het onderstaande code‑voorbeeld toont hoe u de tekenafstand in **tekstgedeelten met een vet lettertype** kunt uitbreiden:

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

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in PowerPoint‑instellingen is ingeschakeld.

Om de renderoutput dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/kerningminimalsize/) in op een waarde die groter is dan de feitelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertype‑namen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Hierdoor wordt kerning uitgeschakeld voor overeenkomende gedeelten met een lettergrootte kleiner dan 100 punten:

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

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan helpen om de weergave van Aspose.Slides te laten overeenkomen met de visuele output van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaultportionformat/) of op individuele gedeelten via [IPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en een gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaardinstellingen:

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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/textverticaltype/) om een vooraf gedefinieerde tekstrichting binnen een vorm in te stellen.

Het onderstaande code‑voorbeeld stelt de tekstrichting in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nl/net/aspose.slides/textverticaltype/), waardoor de tekst **90 graden tegen de klok in** wordt geroteerd:

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

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/rotationangle/) om een aangepaste rotatie‑hoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).

Het onderstaande code‑voorbeeld roteert het tekstkader met 3 graden met de klok mee binnen de vorm:

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

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacebefore/) en [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/spacewithin/) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele afstand):

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

## **Regelafbreking beheersen**

Regels voor regelafbreking van alinea’s zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende eigenschappen behoren tot [IParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/), dus ze gelden voor een hele alinea:

- [LatinLineBreak](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/latinlinebreak/) regelt de Latijnse regelafbrekingsregels. In gemengde tekst kan het aanpassen ervan ook invloed hebben op waar aangrenzende Oost‑Aziatische tekst en interpunctie worden afgebroken.
- [EastAsianLineBreak](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/eastasianlinebreak/) regelt de Oost‑Aziatische regelafbrekingsregels, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/wraptext/), die automatisch afbreken binnen een tekstkader mogelijk maakt. Ze beïnvloeden de layout wanneer afbreken plaatsvindt; ze voegen geen regeleinde‑tekens toe. Een expliciete regeleinde‑invoeging dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbrekings‑eigenschappen expliciet in en slaat “line_breaking.pptx” op. Om met één van de regels te experimenteren, wijzig de waarde van die eigenschap terwijl de andere instellingen ongewijzigd blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een kaderbreedte van 160 punten en nul horizontale marges. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/autofittype/) is ingesteld op [TextAutofitType.None](https://reference.aspose.com/slides/nl/net/aspose.slides/textautofittype/) zodat tekstgrootte en kaderafmetingen vast blijven.

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

## **Hangende interpunctie beheersen**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/hangingpunctuation/) laat toe dat in aanmerking komende interpunctie voorbij de rechterrand van de tekstlijn uitsteekt in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punten breed tekstkader in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale marges blijft de laatste punt achter “sentence” staan en steekt hij uit voorbij de rechterrand. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Wrapping is ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en layout‑voorwaarden die eerder zijn beschreven](#conditions-and-limitations) gelden ook voor deze vergelijking: wijzig het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstkaders instellen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/autofittype/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of de vorm automatisch herschaalt. Het volgende voorbeeld configureert de vorm zodat deze wordt herschaald om de tekst te laten passen en slaat het resultaat op als “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Om het aantal regels na automatisch afbreken te tellen en te zien hoe tekst‑ of vormbreedte het resultaat wijzigt, zie [Rendered Lines tellen](/slides/nl/net/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstkaders instellen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als “text_anchor.pptx”.

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

Gebruik [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/defaulttabsize/) en [IParagraphFormat.Tabs](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/tabs/) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 punten en voegt een links-uitgelijnde tab‑stop toe op 30 punten. Deze instellingen hebben invloed op tekst met tab‑tekens.

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

## **Controlertaal voor proeflezen instellen**

Aspose.Slides biedt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/), waarmee u de proefleestaal voor een tekstdeling kunt instellen. De proefleestaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en ten minste één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese proefleestaal (`zh-CN`) toe. Het resultaat wordt opgeslagen als “proofing_language.pptx”:

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

## **Standaardtaal instellen**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/) om de standaardtaal voor tekst te definiëren die wordt aangemaakt bij het laden of maken van een presentatie. Het volgende voorbeeld maakt een presentatie met Amerikaans‑Engels als standaardteksttaal, voegt een tekstvak toe en drukt `en-US` af voor de eerste tekstdeling.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Voeg een nieuwe rechthoekvorm toe met tekst.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Controleer de taal van de eerste tekstgedeelte.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Standaardtekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruikt u [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/defaulttextstyle/).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea’s van het hoogste niveau in een nieuwe presentatie en slaat deze op als “default_text_style.pptx”. Tekst kan deze standaard overerven tenzij specifiekere opmaak deze overschrijft.

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

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is ingevoerd. Wanneer u een dergelijk tekstdeling opvraagt met Aspose.Slides, retourneert de library de tekst precies zoals deze is ingevoerd. Om overeen te komen met de weergegeven tekst, controleert u [TextCapType](https://reference.aspose.com/slides/nl/net/aspose.slides/textcaptype/) en zet u de geretourneerde tekenreeks om in hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. De eerste alinea’s eerste gedeelte bevat “Hello, Aspose!” met het All‑Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All‑Caps‑effect](all_caps_effect.png)

Het onderstaande code‑voorbeeld laat zien hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

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

Om tekst in een tabel op een dia te wijzigen, gebruikt u [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/). Loop door de cellen en werk elke cel bij via [ICell.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/textframe/) en alinea‑opmaak via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/paragraphformat/).

**Hoe pas ik een gradientkleur toe op tekst in een PowerPoint‑dia?**

Om een gradientkleur op tekst toe te passen, gebruikt u [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/fillformat/). Stel [IFillFormat.FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformat/filltype/) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) en configureer de gradientstops, richting en transparantie.