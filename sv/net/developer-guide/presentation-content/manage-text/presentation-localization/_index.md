---
title: Automatisera presentationslokalisering i .NET
linktitle: Presentationslokalisering
type: docs
weight: 100
url: /sv/net/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- undertryck stavningskontroll
- korrekturspråk
- språk-id
- flerspråkig text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument‑presentationstext i .NET med Aspose.Slides, inklusive standardvärden och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för .NET låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/) för att identifiera korrekturspråket, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/spellcheck/) för att tillåta eller undertrycka stavningskontroller, och [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/proofdisabled/) för att styra det bredare “ingen korrektur”-tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Denna artikel förklarar hur du tilldelar ett språk till specifik text, anger standardspråket för ny text med [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/defaulttextlanguage/), bygger flerspråkiga stycken, väljer mellan `SpellCheck` och `ProofDisabled`, samt bevarar de avsedda inställningarna när du använder [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/joinportionswithsameformatting/). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ange korrekturspråk för text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/), nå den önskade textdelen via [IPortion.PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/portionformat/), och tilldela dess språkidentifierare. Följande exempel skapar en form, sätter brittisk engelska som korrekturspråk och sparar resultatet med [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Ange standardspråk för ny text**

Använd [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/defaulttextlanguage/) för att specificera korrekturspråket som Aspose.Slides tilldelar ny skapad text. Denna inställning är användbar när de flesta eller alla nya texter i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Använd flera språk i ett stycke**

Ett [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/) för varje språk och sätt dess `LanguageId` oberoende av varandra.

Detta exempel skapar ett stycke med engelska och franska delar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Aktivera eller undertrycka stavningskontroll för enskilda delar**

[IPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/) ärver de gemensamma textegenskaperna som definieras av [IBasePortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/). Nå en delens format via [IPortion.PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/portionformat/) och sätt [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/spellcheck/) för att styra om ett presentationsprogram får kontrollera stavning för den delen. Standardvärdet är `false`: `true` tillåter stavningskontroll, medan `false` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför ha olika värden. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/languageid/) och `SpellCheck` fyller kompletterande funktioner: `LanguageId` identifierar korrekturspråket, medan `SpellCheck` bestämmer om stavningskontroller är tillåtna för delen.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/proofdisabled/) styr också korrektur, men det representerar det bredare “gör ingen korrektur”-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/). Använd `SpellCheck` när du endast behöver en direkt boolesk växel för stavningskontroller. Använd `ProofDisabled` när du vill bevara eller explicit styra presentationens “ingen korrektur”-metadata, inklusive dess `NotDefined`‑tillstånd. Om du sätter båda egenskaperna, håll deras värden konsistenta; kombinera inte `SpellCheck = true` med `ProofDisabled = NullableBool.True`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att köra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, läser in den, tilldelar olika stavningskontroll‑inställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/joinportionswithsameformatting/) kombinerar intilliggande delar som har samma formatering. En skillnad i `SpellCheck` ensam hindrar inte sådana delar från att slås ihop; efter sammanslagning behåller den resulterande delen `SpellCheck`‑värdet från den första delen. Om delar behöver olika stavningskontroll‑inställningar, anropa `JoinPortionsWithSameFormatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `LanguageId`‑värden förblir separata eftersom deras korrekturspråksformatering skiljer sig.

## **FAQ**

**Översätter ett språk‑ID texten?**

Nej. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och sätt sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket typsnitt, avstavning eller radbrytning?**

Nej. Språkidentifieraren är bara för korrektur. Textrendering och layout beror främst på tillgängliga [fonts](/slides/sv/net/powerpoint-fonts/), skriftsystemet och text‑ramens inställningar. För pålitlig rendering, tillhandahåll de nödvändiga typsnitten, konfigurera [font substitution](/slides/sv/net/font-substitution/), eller [embed fonts](/slides/sv/net/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, enligt exemplet med flerspråkigt stycke.

**Ska jag använda `DefaultTextLanguage` eller `LanguageId`?**

Använd [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/defaulttextlanguage/) när du vill ha ett standardvärde för ny skapad text. Använd [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.