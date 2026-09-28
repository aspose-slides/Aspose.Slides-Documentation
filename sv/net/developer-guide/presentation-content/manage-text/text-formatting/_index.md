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
- typsnittsegenskaper
- typsnittsfamilj
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
description: "Formatera och styla text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Anpassa typsnitt, färger, justering och mer."
---
## **Översikt**

Den här artikeln visar hur du formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Den täcker bakgrundsfärger, transparens, teckenavstånd, teckensegenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbavstånd och språkinställningar.

Om inget annat anges använder exemplen [sample.pptx](sample.pptx). Den första formen på dess första bild är en textruta, och dess första stycke innehåller texten som visas nedan. Både bild- och formindex är nollbaserade. Exempel som markerar fetstilade delar använder effektiv formatering, inklusive ärvd fetstilformattering:

![Exempeltext](sample_text.png)

För att hitta och markera bokstavlig text eller reguljära uttryck‑matchningar, se [Sök och ersätt text](/slides/sv/net/search-and-replace-text/).

## **Ange textbakgrundsfärg**

Använd [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaultportionformat/) för att ange standardfärgen för markering av ett stycke, eller använd [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/highlightcolor/) för enskilda textdelar.

Följande exempel sätter en ljusgrå markering som standard för det första stycket. Explicita markeringsfärger på enskilda delar har företräde framför detta standardvärde:

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

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan visar hur du anger bakgrundsfärgen för **textdelar med fet stil**:

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

![De gråa textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [IParagraphFormat.Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) för att ange styckejustering inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur du justerar stycket till **centrum**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ställ in styckets justering till centrum.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ange transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/fillformat/). I exemplen nedan är `alpha = 50` ett ARGB-alfa‑kanalvärde på skalan 0–255, inte en transparensprocent.

Kodexemplet nedan visar hur du applicerar transparens på **hela stycket**:

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

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur du applicerar transparens på **textdelar med fet stil**:

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

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/spacing/) för att öka eller minska avståndet mellan tecken i en textruta. Exemplen lägger till 3 punkters avstånd; negativa värden komprimerar texten.

Följande C#‑kod visar hur du expanderar teckenavståndet i **hela stycket**:

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

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur du expanderar teckenavståndet i **textdelar med fet stil**:

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

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tätare ut än samma text som visas i PowerPoint. Detta kan ske eftersom PowerPoint kan ignorera kerningdata för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att få den renderade utgången närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det berörda typsnittet. Ställ in [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/kerningminimalsize/) på ett värde som är större än den faktiska teckenstorleken. Detta exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden. Det kontrollerar effektiva typsnittsnamn, inklusive ärvda typsnitt, och sätter ett tröskelvärde på 100 punkter för delar som använder Roboto. Detta inaktiverar kerning för matchande delar med en teckenstorlek under 100 punkter:

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

För matchande text under tröskeln förhindrar denna inställning kerning och kan hjälpa till att anpassa Aspose.Slides‑renderingen till PowerPoints visuella utdata för typsnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera texttypsnitts‑egenskaper**

Typsnittsegenskaper kan ställas in på styckennivå via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaultportionformat/) eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/).

Följande exempel sätter det första styckets standardtypsnitt till 12‑punkts Times New Roman med fet, kursiv och prickad understrykning. Explicita format på enskilda delar har företräde framför dessa standardinställningar:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ange typsnittsegenskaperna för stycket.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Resultatet:

![Typsnittsegenskaperna för stycket](font_properties_for_paragraph.png)

Följande exempel applicerar 13‑punkts Times New Roman, kursiv formatering och en prickad understrykning på delar vars effektiva formatering är fet:

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
        // Ställ in typsnittsegenskaperna för textdelen.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Resultatet:

![Typsnittsegenskaperna för textdelarna](font_properties_for_text_portions.png)

## **Ange textrotation**

Använd [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/textverticaltype/) för att ange en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till [TextVerticalType.Vertical270](https://reference.aspose.com/slides/sv/net/aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

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

![Textrotationen](text_rotation.png)

## **Ange anpassad rotation för textramlar**

Använd [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/rotationangle/) för att ange en anpassad rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).

Kodexemplet nedan roterar textramlen med 3 grader medurs inom formen:

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

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spacebefore/), och [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/spacewithin/) för att kontrollera styckeavstånd. Dessa egenskaper används enligt följande:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radhöjden.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande exempel sätter avståndet inom det första stycket till 200 % av radhöjden (dubbelradavstånd):

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

![Radavståndet inom stycket](line_spacing.png)

## **Styr radbrytning**

Regler för radbrytning i stycken är användbara i smala textblock och presentationer som blandar latinsk och östasiatisk text. Följande egenskaper tillhör [IParagraphFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/), så de gäller för hela stycket:

- [LatinLineBreak] styr latinska radbrytningsregler. I blandad text kan en ändring också påverka var intilliggande östasiatisk text och interpunktion radbryts.
- [EastAsianLineBreak] styr östasiatiska radbrytningsregler, inklusive restriktioner på tecken i början och slutet av en rad.

Dessa regler ersätter inte [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/wraptext/), som möjliggör automatisk radbrytning inom en textram. De påverkar layouten när radbrytning sker; de infogar inte radbrytningstecken. En explicit radbrytning tvingar en ny rad inom stycket oberoende av tillgänglig bredd.

Följande fristående exempel skapar ett smalt textblock som innehåller kinesisk och latinsk text. Det sätter båda radbrytningsegenskaperna explicit och sparar "line_breaking.pptx". För att experimentera med någon av reglerna, ändra den egenskapens värde medan de andra inställningarna hålls oförändrade. Exemplet använder 24‑punkts Arial och SimSun med en rambredd på 160 punkter och noll horisontella textram‑marginaler. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/autofittype/) är satt till [TextAutofitType.None](https://reference.aspose.com/slides/sv/net/aspose.slides/textautofittype/) så att textstorlek och ramdimensioner förblir fasta.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/hangingpunctuation/) låter berättigad interpunktion sträcka sig förbi textens högra kant istället för att ta nästa rad. Den gäller för hela stycket och skiljer sig från ett hängande indrag.

Följande fristående exempel aktiverar hängande interpunktion i en 100‑punkts bred textram och sparar "hanging_punctuation.pptx". Med 24‑punkts Arial och noll horisontella textram‑marginaler förblir den sista punkten efter "sentence" och sträcker sig förbi den högra textkanten. Ställ in egenskapen på [NullableBool.False](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/) för jämförelse: med dessa inställningar upptar punkten en egen rad. Radbrytning är aktiverad och autofit är inaktiverat för att hålla den tillgängliga bredden fast.

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

Inte varje interpunktion kan hänga. De [typsnitt- och layoutvillkor som beskrivits ovan](#conditions-and-limitations) gäller också för denna jämförelse: att ändra typsnitt, tillgänglig bredd, marginaler eller autofit‑inställningar kan ta bort den synliga skillnaden.

## **Ange autofit-typ för textramlar**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/autofittype/) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten krymper, rinner över eller automatiskt ändrar storlek på formen. Följande exempel konfigurerar formen att ändra storlek för att passa sin text och sparar resultatet till "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

För att räkna rader efter automatisk radbrytning och se hur text- eller formbredd ändrar resultatet, se [Räkna renderade rader](/slides/sv/net/manage-paragraph/). Radantalet ensamt visar inte om texten överflödar sin behållare.

## **Ange ankare för textramlar**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/anchoringtype/) definierar hur text placeras vertikalt inne i en form, till exempel överst, i mitten eller nederst. Följande exempel ankare texten till botten av den första formen och sparar resultatet till "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Ange texttabulering**

Använd [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/defaulttabsize/) och [IParagraphFormat.Tabs](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/tabs/) för att konfigurera tabbstopp i ett stycke. Följande exempel sätter standardtabbintervallet till 100 punkter och lägger till ett vänsterjusterat tabbstopp vid 30 punkter. Dessa inställningar påverkar text som innehåller tabulatortecken.

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

![Styckets tabbstopp](paragraph_tabs.png)

## **Ange korrekturspråk**

Aspose.Slides tillhandahåller [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/), som låter dig ange korrekturspråket för en textdel. Korrekturspråket bestämmer vilket språk som används för stavnings- och grammatikkontroller i PowerPoint.

Följande exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden och minst ett stycke. Det ersätter det första styckets innehåll med "1。", sätter SimSun som dess typsnitt och tilldelar det förenklade kinesiska korrekturspråket (`zh-CN`). Det sparar resultatet till "proofing_language.pptx":

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

// Ställ in korrekturspråket till förenklad kinesiska.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Ange standardspråk**

Använd [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/defaulttextlanguage/) för att definiera standardspråket för text som skapas när en presentation laddas eller skapas. Följande exempel skapar en presentation med amerikansk engelska som standardspråk för text, lägger till en textruta och skriver ut `en-US` för dess första textdel.

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

// Kontrollera det första delens språk.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ange standardtextstil**

För att applicera standardtextformatering på presentationsnivå, använd [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/defaulttextstyle/).

Följande exempel sätter ett 14‑punkts fet stil-typsnitt som standard för översta stycken i en ny presentation och sparar den till "default_text_style.pptx". Text kan ärva dessa standardvärden om inte mer specifik formatering åsidosätter dem.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Hämta styckeformatet på toppnivå.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extrahera text med versaler‑effekt**

I PowerPoint gör tillämpning av teffekten **All Caps** att text visas med stora bokstäver på bilden även om den ursprungligen skrevs med små bokstäver. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/net/aspose.slides/textcaptype/) och konvertera den returnerade strängen till stora bokstäver när värdet är `All`.

Detta exempel kräver "sample2.pptx" med en textruta som den första formen på den första bilden. Dess första stycke första del innehåller "Hello, Aspose!" med All Caps‑effekten applicerad, som visas nedan.

![All Caps‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur du extraherar texten med den **All Caps**‑effekt som tillämpats:

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

## **Vanliga frågor**

**Hur ändrar jag text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/textframe/) och styckeformatering via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/paragraphformat/).

**Hur applicerar jag en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/fillformat/). Ställ in [IFillFormat.FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformat/filltype/) till [FillType.Gradient](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.