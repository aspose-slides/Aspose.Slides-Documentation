---
title: Hantera script-specifika temafonter i .NET
linktitle: Script-specifika temafonter
type: docs
weight: 15
url: /sv/net/script-specific-font-mappings/
keywords:
- script-specifikt teckensnitt
- temateckensnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana-teckensnitt
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Inspektera, lägga till, ersätta och ta bort script-specifika teckensnittsmappningar i PowerPoint-teman med Aspose.Slides för .NET."
---
## **Översikt**

Ett presentationstema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta gör att flerspråkig text som fortfarande använder temats teckensnitt kan följa ett samordnat teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [IFontScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/ifontscheme/) innehåller en huvudteckensnittssamling, som vanligtvis används för rubriker, och en sekundär teckensnittssamling, som vanligtvis används för brödtext. Förutom deras latinska och östasiatiska teckensnittsegenskaper, exponerar båda samlingarna mappningar från skriftsystem‑taggar till teckensnittsfamiljenamn via gränssnittet [IFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/ifonts/).

Den här artikeln visar hur man inspekterar och ändrar dessa mappningar i presentationens huvudtema och verifierar att ändringarna överlever en spara‑och‑läs‑om‑cykel.

## **Förstå skript‑taggar**

Skriptfont‑metoderna använder fyrabokstaviga BCP 47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skripttag | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliska |
| `Arab` | Arabiska |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiska |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats teckensnittsschema, inte enskilda textdelar. En presentation kan definiera olika mappningar för huvud- och sekundärsamlingarna, och den kan utelämna mappningar för vissa skript.

## **Åtkomst och inspektion av skriptfont‑mappningar**

Använd [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/) för att komma åt presentationens tema på nivå. Egenskaperna [FontScheme.Major](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/major/) och [FontScheme.Minor](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/minor/) returnerar de två [IFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/ifonts/)‑samlingarna.

Anropa [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/getscriptfontmap/) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [IFonts.GetScriptFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/getscriptfont/) med dess skripttagg. `GetScriptFont` returnerar `null` när den samlingen inte definierar den begärda mappningen.

## **Ändra mappningar och verifiera beständighet**

Använd [IFonts.SetScriptFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/setscriptfont/) för att skapa en mappning eller ersätta dess nuvarande teckensnittsfamilj. Använd [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/removescriptfont/) för att ta bort en mappning.

Det följande end‑to‑end‑exemplet läser alla befintliga huvud‑ och sekundärmappningar, slår upp den japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort Thaana‑sekundärmappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplet först en Thaana‑mappning endast när ingen redan är definierad.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Verifieringen använder samma `null`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats returnerar `GetScriptFont("Thaa")` `null` för den sekundära samlingen.

## **Skilj på temamappningar från andra teckensnittinställningar**

Skript‑specifika temamappningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, substitution och reservteckensnitt:

| Mekanism | Syfte | Effekt av att ändra en temamappning |
|---|---|---|
| Skript‑specifik temafont‑mappning | Väljer ett huvud‑ eller sekundärt temafont för ett skriftsystem. | Text som fortfarande använder motsvarande temafont kan lösa till den nya mappade familjen. |
| Teckensnitt tilldelat explicit till en textdel | Fixerar det begärda teckensnittet på den delen i stället för att förlita sig på temat. | Textdelen kan förbli oförändrad eftersom dess direkta formatering åsidosätter temavalet. |
| Teckensnittssubstitution | Ersätter ett begärt teckensnitt när det inte är tillgängligt eller när en substitutionsregel gäller. | Den sker efter att ett teckensnitt har begärts; den omdefinierar inte temats skript‑mappning. |
| Teckensnittsförrättning | Tillhandahåller glyfer som det valda teckensnittet saknar, ofta för specifika Unicode‑intervall. | Den fyller i saknade glyfer; den ändrar inte den lagrade temamappningen. |

För mer information om de två sista mekanismerna, se [Font Substitution](/slides/sv/net/font-substitution/) och [Fallback Fonts](/slides/sv/net/fallback-font/).

Att ändra en mappning i [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/) påverkar bara innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaarv från ett master‑, layout‑ eller bild‑tema, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentationens temamappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa såsom [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) eller [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/). Se [Custom Fonts](/slides/sv/net/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar bara att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla nödvändiga glyfer, eller ger den avsedda layouten. Rendera representativ text för varje obligatoriskt skriftsystem till en bild eller PDF och inspektera utdata. Detta fångar saknade teckensnitt, ofullständig glyf‑täckning, reserv‑beteende och layout‑förändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/net/convert-powerpoint/) för exempel på rendering och export.

## **FAQ**

**Vad returnerar `GetScriptFont` när ett skript inte är mappat?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/getscriptfont/) returnerar `null` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller sekundära teckensnittssamlingen.

**Lägger `SetScriptFont` till en andra mappning när skriptet redan finns?**

Nej. [IFonts.SetScriptFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fonts/setscriptfont/) skapar mappningen när den saknas och ersätter den mappade teckensnittsfamiljen när samma skripttagg redan finns.

**Varför ändrade en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema via en åsidosättning, eller påverkas av substitution eller reservvidrendering. En presentation‑nivå skript‑mappning styr bara text vars effektiva formatering fortfarande refererar till den temateckensnittssamlingen.

**Är spara och öppna igen tillräckligt för att validera flerspråkig output?**

Nej. Att öppna igen verifierar beständigheten för temadata. Du bör också rendera representativ text från varje obligatoriskt skriftsystem för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller nödvändiga glyfer.