---
title: Formatera presentationstext i .NET
linktitle: Textformatering
type: docs
weight: 50
url: /sv/net/text-formatting/
keywords:
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- teckensnittsegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit-egenskap
- textram ankare
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Anpassa teckensnitt, färger, justering med mer."
---
## **Översikt**

Den här artikeln visar hur man formaterar text i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för .NET. Den täcker bakgrundsfärger, transparens, teckenavstånd, teckensnitts‑egenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbstopp och språkinställningar.

Om inget annat anges använder exemplen [sample.pptx](sample.pptx). Den första formen på den första bilden är en textruta och dess första stycke innehåller texten som visas nedan. Både bild‑ och form‑index är nollbaserade. Exempel som markerar fet text använder effektiv formatering, inklusive ärvd fet formatering:

![Sample text](sample_text.png)

För att hitta och markera bokstavlig text eller reguljära uttryck, se [Sök och ersätt text](/slides/sv/net/search-and-replace-text/).

## **Ange bakgrundsfärg för text**

Använd [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) för att ange standardmarkeringsfärg för ett stycke, eller använd [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) för enskilda textdelar.

Följande exempel anger en ljusgrå markering som standard för det första stycket. Explixita markeringsfärger på enskilda delar har företräde framför detta standardvärde:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ställ in markeringsfärgen för hela stycket.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![The gray paragraph](gray_paragraph.png)

Kodexemplet nedan demonstrerar hur man anger bakgrundsfärg för **textdelar med ett fet stil**:

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
        // Ställ in markeringsfärgen för textdelen.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Resultatet:

![The gray text portions](gray_text_portions.png)

## **Justera textstycken**

Använd [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) för att ange styckejustering i en textruta. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ställ in styckets justering till centrerad.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![The aligned paragraph](aligned_paragraph.png)

## **Justera teckensnitt inom en rad**

Använd [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) för att vertikalt justera textdelar med olika teckenstorlekar inom en rad. Denna inställning gäller hela stycket och styr justeringen inom varje rad.

Följande fristående exempel skapar fyra etiketterade textrutor på en bild. Varje stycke innehåller samma text i 18, 36 och 54 punkter, med olika teckenjustering. Det använder Arial, inaktiverar autofit och radbrytning och håller textrutorna tillräckligt stora för en enda rad.

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

Resultatet:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Teckenjustering använder teckenmetrik, så de synliga kanterna på enskilda bokstäver nödvändigtvis inte exakt linjerar. Exemplet innehåller både en versal bokstav och en nedgående del för att tydligt visa skillnaden mellan baseline‑ och bottenjustering. Teckensnittstillgänglighet och ersättning, de använda tecknen och skillnaden i teckenstorlek påverkar resultatet. Ram­dimensioner, marginaler, radavstånd, radbrytning och autofit påverkar också layouten; använd samma teckensnitt och layoutinställningar vid jämförelser av lägen.

Den här inställningen skiljer sig från [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), som styr horisontell styckejustering, och [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), som placerar textblocket vertikalt inom sin form. Upphöjd och nedsänkt formatering via [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) flyttar enskilda delar relativt till baseline istället för att ange teckenjustering för styckets rader.

## **Ange transparens för text**

Transparens för text styrs via alfakomponenten i färgen som tilldelas [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på 0–255‑skalan, inte en procentandel transparens.

Kodexemplet nedan visar hur man använder transparens på **hela stycket**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ställ in en semitransparent svart fyllning för texten.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![The transparent paragraph](transparent_paragraph.png)

Följande kodexempel visar hur man använder transparens på **textdelar med ett fet stil**:

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
        // Ställ in transparensen för textdelen.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Resultatet:

![The transparent text portions](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) för att öka eller minska avståndet mellan tecken i en textruta. Exemplen lägger till 3 punkter avstånd; negativa värden minskar avståndet.

Följande C#‑kod visar hur man ökar teckenavståndet i **hela stycket**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Obs: Använd negativa värden för att komprimera teckenavståndet.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Utöka teckenavståndet.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man ökar teckenavståndet i **textdelar med ett fet stil**:

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
        // Obs: Använd negativa värden för att komprimera teckenavståndet.
        portion.PortionFormat.Spacing = 3;  // Utöka teckenavståndet.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Resultatet:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika teckensnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan bero på att PowerPoint ignorerar kerning‑data för vissa teckensnitt, även när teckensnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att få renderingen närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det berörda teckensnittet. Sätt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) till ett värde som är större än den faktiska teckenstorleken. Detta exempel kräver *presentation.pptx* med en textruta som den första formen på den första bilden. Det kontrollerar effektiva teckensnittsnamn, inklusive ärvda teckensnitt, och sätter ett tröskelvärde på 100 punkter för delar som använder Roboto. Detta inaktiverar kerning för matchande delar med en teckenstorlek under 100 punkter:

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

För matchande text under tröskeln förhindrar denna inställning kerning och kan hjälpa Aspose.Slides‑renderingen att matcha PowerPoints visuella resultat för teckensnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera teckensnittsegenskaper för text**

Teckensnittsegenskaper kan anges på stycknivå via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Följande exempel anger det första styckets standardteckensnitt till 12‑punkt Times New Roman med fet, kursiv och prickad understrykning. Explixit formatering på enskilda delar har företräde framför dessa standardvärden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ställ in teckensnittsegenskaperna för stycket.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Följande exempel tillämpar 13‑punkt Times New Roman, kursiv formatering och prickad understrykning på delar vars effektiva formatering är fet:

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
        // Ställ in teckensnittsegenskaperna för textdelen.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Resultatet:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Styr normalisering av texthöjd**

Använd [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) när du återger mall‑typografi eller undersöker skillnader i teckenhöjd. I PowerPoint sträcker eller komprimerar aktivering av normalisering enskilda tecken vertikalt för att ge dem en enhetlig synlig höjd inom textdelen. Det garanterar inte lika texthöjd mellan olika teckensnitt.

Ställ in egenskapen till [NullableBool.True eller False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) för att explicit aktivera eller inaktivera normalisering. `NullableBool.NotDefined` lämnar den lokala inställningen odefinierad så att delen ärver värdet, exempelvis från styckets [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/). Det betyder inte `False`. Använd [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) och läs [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) för att erhålla det lösta booleska värdet.

Följande fristående exempel kräver att **Arial** är installerat. Det skapar två textblock med samma versala bokstäver, gemena bokstäver, nedgående delar och tecken med diakritik i 54 punkter. Båda styckena har normalisering aktiverad som standard. Det övre avsnittet inaktiverar den uttryckligen; det nedre ärver den. Ram‑storlekar, marginaler och styckeavstånd är identiska, med radbrytning och autofit inaktiverade för att hålla jämförelsen konsekvent. Exemplet skriver ut `False: False` och `NotDefined: True` och sparar *text_height_normalization.pptx*.

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

Jämförelsen nedan exporterades från den sparade presentationen. Den övre raden har normalisering inaktiverad (`False`); den nedre ärver den aktiverade inställningen (`NotDefined` → `True`). Behåll Arial installerat för att återge detta utseende.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalisering ändrar teckenhöjd utan att ändra det tilldelade [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)-värdet, som specificerar teckenstorlek i punkter. Stycke‑[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) styr radavstånd, medan textrute‑[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) styr hur text eller dess behållare anpassas. Dessa inställningar har olika syften och kan påverka layouten oberoende av varandra. Läs mer om styckeformatering och arv under [Hantera stycke](/slides/sv/net/manage-paragraph/).

## **Tillämpa och ta bort genomstrykning**

Använd [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) på en textdel för att visa korrigeringar, avbrutna termer eller tidigare priser utan att ta bort originaltexten. Sätt den till [TextStrikethroughType.Single eller Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) för en respektive två linjer genom texten.

För att ta bort genomstrykning, tilldela `TextStrikethroughType.None`. Detta inaktiverar effekten explicit, även om omgivande formatering specificerar genomstrykning. Däremot lämnar `TextStrikethroughType.NotDefined` den lokala inställningen odefinierad, så att delen ärver formatering, exempelvis från stycket. Det garanterar inte att genomstrykning tas bort. Använd [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) för att läsa den resulterande formateringen, inklusive ärvda värden.

Följande fristående exempel skapar tre prisjämförelser. Varje stycke har separata delar för etikett, tidigare pris och aktuellt pris, så endast det tidigare priset påverkas. Den första raden tillämpar och sedan tar bort genomstrykning; de andra raderna behåller enkel respektive dubbel genomstrykning. Ändring av denna egenskap bevarar texten och dess övriga formatering, inklusive det feta tidigare priset.

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

// Applicera genomstrykning, ta sedan bort den explicit från det första föregående priset.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Resultatet, från topp till botten: ingen genomstrykning, enkel genomstrykning och dubbel genomstrykning.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Ange textrotation**

Använd [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) för att ange en fördefinierad textriktning inom en form.

Följande kodexempel sätter textriktningen i formen till [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Resultatet:

![The text rotation](text_rotation.png)

## **Visa siffror sida vid sida i vertikal text**

För att hålla ett tvåsiffrigt tal ihop i en vertikal japansk etikett, placera båda siffrorna i en textruta och sätt [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) på den delen. Exemplet använder [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) och 40‑punkt MS Gothic för båda etiketterna. Endast värdet på [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) som tilldelas den numeriska delen skiljer sig.

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

I PowerPoint visar den vänstra etiketten (`True`) siffrorna upprätt och sida vid sida mellan 和 och 年. Den högra etiketten (`False`) har paret roterat 90 grader medurs. De omgivande japanska tecknen förblir upprätt i båda etiketterna.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Ange anpassad rotation för textramar**

Använd [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) för att ange en egen rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Kodexemplet nedan roterar textramen 3 grader medurs inom formen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Resultatet:

![The custom text rotation](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) och [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) för att styra styckeavstånd. Dessa egenskaper används så här:

* Använd ett positivt värde för att ange radavstånd som procent av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande exempel anger avstånd inom det första stycket till 200 % av radens höjd (dubbelradigt):

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

Resultatet:

![The line spacing within the paragraph](line_spacing.png)

## **Styr radbrytning**

Regler för radbrytning i stycken är användbara i smala textblock och presentationer som blandar latin och östasiatisk text. Följande egenskaper tillhör [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), så de gäller hela stycket:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) styr latinbaserade radbrytningsregler. I blandad text kan en ändring även påverka var angränsande östasiatisk text och interpunktion bryts.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) styr östasiatiska radbrytningsregler, inklusive begränsningar för tecken i början och slutet av en rad.

Dessa regler ersätter inte [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), som möjliggör automatisk radbrytning inom en textruta. De påverkar layouten när radbrytning sker; de infogar inte radbrytningstecken. En explicit radbrytning tvingar en ny rad i stycket oberoende av tillgänglig bredd.

Följande fristående exempel skapar ett smalt textblock med kinesisk och latin text. Det sätter båda radbrytningsegenskaperna explicit och sparar *line_breaking.pptx*. För att experimentera med någon av reglerna, ändra dess värde medan de övriga inställningarna förblir oförändrade. Exemplet använder 24‑punkt Arial och SimSun med en rambredd på 160 punkter och noll horisontella marginaler för textrutan. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) är satt till [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) så att textstorlek och ramdimensioner förblir fasta.

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

## **Styr hängande interpunktion**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) låter berättigad interpunktion sträcka sig utanför textlinjens högra kant istället för att ta nästa rad. Den gäller hela stycket och skiljer sig från ett hängande indrag.

Följande fristående exempel aktiverar hängande interpunktion i en 100‑punkt bred textruta och sparar *hanging_punctuation.pptx*. Med 24‑punkt Arial och noll horisontella marginaler förblir den sista punkten efter “sentence” och sträcker sig utanför den högra kanten. Sätt egenskapen till [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) för att jämföra: med dessa inställningar hamnar punkten på en egen rad. Radbrytning är aktiverad och autofit inaktiverat för att hålla den tillgängliga bredden fast.

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

Inte varje interpunktionstecken kan hänga. De [teckensnitt‑ och layoutvillkor som beskrivs ovan](#control-line-breaking) gäller även för denna jämförelse: byte av teckensnitt, tillgänglig bredd, marginaler eller autofit‑inställningar kan ta bort den synliga skillnaden.

## **Ange Autofit‑typ för textramar**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten krymper, rinner över eller anpassar formen automatiskt. Följande exempel konfigurerar formen att anpassa storlek för att passa texten och sparar resultatet till *autofit_type.pptx*.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

För att räkna rader efter automatisk radbrytning och se hur text‑ eller formbredd förändrar resultatet, se [Räkna renderade rader](/slides/sv/net/manage-paragraph/). Antal rader indikerar ensam inte om texten rinner över sin behållare.

## **Ange ankare för textramar**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definierar hur text placeras vertikalt inuti en form, exempelvis längst upp, i mitten eller längst ner. Följande exempel förankrar texten till botten på den första formen och sparar resultatet till *text_anchor.pptx*.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Ange tabulering för text**

Använd [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) och [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) för att konfigurera tabbstopp i ett stycke. Följande exempel sätter standardtabbsteg till 100 punkter och lägger till ett vänsterjusterat tabbstopp vid 30 punkter. Dessa inställningar påverkar text som innehåller tabulatortecken.

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

Resultatet:

![The paragraph tabs](paragraph_tabs.png)

## **Ange korrekturläsningsspråk**

Aspose.Slides erbjuder [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), som gör det möjligt att ange korrekturläsningsspråk för en textdel. Korrekturläsningsspråket bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande exempel kräver *presentation.pptx* med en textruta som den första formen på den första bilden och minst ett stycke. Det ersätter det första styckets innehåll med “1。”, sätter SimSun som teckensnitt och tilldelar det förenklade kinesiska korrekturläsningsspråket (`zh-CN`). Det sparar resultatet till *proofing_language.pptx*:

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

// Ställ in korrekturläsningsspråket till förenklad kinesiska.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Kopiera språkmetadata**

När du kopierar flerspråkig text från en mall, bevara både [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) och [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Följande fristående exempel skapar en käll-del med US English som språk och franska som alternativt språk och kopierar texten och identifierarna till en del i en ny presentation.

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
    // Om källan saknar alternativt språk, rensar null värdet i destinationen.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

För att prova en källa utan alternativt språk, utelämna tilldelningen av `"fr-FR"`. Det alternativa identifieraren blir då `null`, och samma kopieringsuttryck bevarar dess frånvaro utan att införa ett standardvärde, även om destinationen tidigare hade ett alternativt språk tilldelat.

Dessa identifierare lagrar språkmetadata. Att bevara dem fastställer inte vilket ordförråd PowerPoint väljer för stavnings‑ eller grammatikkontroller.

## **Ange standardspråk**

Använd [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) för att definiera standardspråk för text som skapas vid inläsning eller skapande av en presentation. Följande exempel skapar en presentation med US English som standardspråk för text, lägger till en textruta och skriver ut `en-US` för dess första textdel.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Lägg till en ny rektangelform med text.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Kontrollera språk för den första delen.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ange standardtextstil**

För att tillämpa standardtextformatering på presentationsnivå, använd [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Följande exempel sätter ett 14‑punkt fet stil som standard för toppnivå‑stycken i en ny presentation och sparar den till *default_text_style.pptx*. Text kan ärva dessa standarder såvida inte mer specifik formatering åsidosätter dem.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Hämta det översta styckeformatet.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extrahera text med versaler‑effekt**

I PowerPoint får man med **All Caps**‑effekten att text visas med versaler på sliden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Detta exempel kräver *sample2.pptx* med en textruta som den första formen på den första bilden. Dess första styckes första del innehåller “Hello, Aspose!” med All Caps‑effekten tillämpad, som visas nedan.

![The All Caps effect](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar text med **All Caps**‑effekten tillämpad:

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

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar jag text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) och styckeformatering via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Hur applicerar jag en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Sätt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.

Relaterad funktion: [Formatera text i slides](/slides/sv/features/text-formatting/).