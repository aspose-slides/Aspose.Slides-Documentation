---
title: Hantera skript‑specifika temateckensnitt i JavaScript
linktitle: Skript‑specifika temateckensnitt
type: docs
weight: 15
url: /sv/nodejs-java/script-specific-font-mappings/
keywords:
- skript‑specifikt teckensnitt
- temateckensnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana‑teckensnitt
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspektera, lägg till, ersätt och ta bort skript‑specifika teckensnittsmappningar i PowerPoint‑teman med Aspose.Slides för Node.js."
---
## **Översikt**

Ett presentations­tema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta gör att flerspråkig text som fortfarande använder temats teckensnitt kan följa ett samordnat teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaa‑skriftsystem och andra skript.

Temats [FontScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) innehåller en huvud‑(major) teckensnittssamling, som vanligtvis används för rubriker, och en mindre (minor) teckensnittssamling, som vanligtvis används för brödtext. Förutom deras latin‑ och östasiatiska teckensnittsinställningar, exponerar båda samlingarna mappar från skriftsystem‑taggar till teckensnittsfamiljenamn via klassen [Fonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/).

Denna artikel visar hur man granskar och ändrar dessa mappar i presentationens master‑tema samt verifierar att ändringarna överlever en spara‑och‑läs‑om‑cykel.

## **Förstå skripttaggar**

Skriftsnittsmetoderna använder fyrabokstavsbeteckningar enligt BCP 47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Script tag | Writing system |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Dessa mappar tillhör temats teckensnittsschema, inte enskilda textdelar. En presentation kan definiera olika mappar för huvud‑ och mindre samlingar, och den kan utelämna mappar för vissa skript.

## **Åtkomst och inspektion av skriptfontsmappningar**

Använd [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/) för att komma åt presentationens tema på hög nivå. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontscheme/) returnerar respektive [Fonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/)‑samlingar.

Anropa [Fonts.getScriptFontMap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) för att hämta alla mappar i en samling. För att slå upp ett enskilt skriftsystem, anropa [Fonts.getScriptFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) med dess skripttagg. `getScriptFont` returnerar `null` när den samlingen inte definierar den efterfrågade mappen.

## **Modifiera mappningar och verifiera beständighet**

Använd [Fonts.setScriptFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) för att skapa en ny mappning eller ersätta den befintliga teckensnittsfamiljen. Använd [Fonts.removeScriptFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) för att ta bort en mappning.

Följande end‑to‑end‑exempel läser alla befintliga huvud‑ och mindre mappar, söker upp det japanska huvud‑teckensnittet, ändrar det kyrilliska huvud‑teckensnittet, tar bort den mindre Thaa‑mappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat, skapar exemplet en Thaa‑mappning endast om ingen redan är definierad.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Verifieringen använder samma `null`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats, returnerar `getScriptFont("Thaa")` `null` för den mindre samlingen.

## **Skilj på temamappningar från andra teckensnittsinställningar**

Skript‑specifika temamappningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, substitution och fallback:

| Mechanism | Purpose | Effect of changing a theme mapping |
|---|---|---|
| Script-specific theme font mapping | Selects a major or minor theme font for a writing system. | Text that still uses the corresponding theme font can resolve to the new mapped family. |
| Font assigned explicitly to a text portion | Fixes the requested font family on that portion instead of relying on the theme. | The portion may remain unchanged because its direct formatting overrides the theme choice. |
| Font substitution | Replaces a requested font when that font is unavailable or when a substitution rule applies. | It acts after a font has been requested; it does not redefine the theme's script mapping. |
| Font fallback | Supplies glyphs that the selected font does not contain, often for specific Unicode ranges. | It fills missing glyph coverage; it does not change the stored theme mapping. |

För mer information om de två sista mekanismerna, se [Font Substitution](/slides/sv/nodejs-java/font-substitution/) och [Fallback Fonts](/slides/sv/nodejs-java/fallback-font/).

Att ändra en mappning i [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getmastertheme/) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaarv från en master, layout eller bild, eller använda ett explicit tilldelat teckensnitt. Granska dessa nivåer när det synliga resultatet inte följer presentationens temamappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skriptmappning lagrar bara ett teckensnittsfamiljenamn; den installerar eller laddar inte själva teckensnittet. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa, exempelvis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) eller [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/). Se [Custom Fonts](/slides/sv/nodejs-java/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar bara att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla nödvändiga glyfer eller skapar den avsedda layouten. Rendera representativ text för varje obligatoriskt skriftsystem till en bild eller PDF och granska resultatet. Detta fångar saknade teckensnitt, ofullständig glyfkostnad, fallback‑beteende och layoutförändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/nodejs-java/convert-powerpoint/) för exempel på rendering och export.

## **Vanliga frågor**

**Vad returnerar `getScriptFont` när ett skript inte är mappat?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) returnerar `null` när den efterfrågade skript‑mappningen inte är definierad i den huvud‑ eller mindre teckensnittssamlingen.

**Lägger `setScriptFont` till en andra mappning när skriptet redan finns?**

Nej. [Fonts.setScriptFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fonts/) skapar mappningen när den saknas och ersätter den mappade teckensnittsfamiljen när samma skripttagg redan finns.

**Varför ändrade en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema genom en överskuggning, eller påverkas av substitution eller fallback under rendering. En presentation‑nivå skript‑mappning styr endast text vars effektiva formatering fortfarande refererar till den tematiska teckensnittssamlingen.

**Räcker det att spara och öppna igen för att validera flerspråkigt resultat?**

Nej. Att öppna igen verifierar bara att temadatan är beständig. Man bör också rendera representativ text från varje obligatoriskt skriftsystem för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller de nödvändiga glyferna.