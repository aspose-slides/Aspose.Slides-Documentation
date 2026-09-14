---
title: Hantera skript-specifika tematypsnitt i Python via Java
linktitle: Skript-specifika tematypsnitt
type: docs
weight: 15
url: /sv/python-java/script-specific-font-mappings/
keywords:
- skript-specifikt typsnitt
- tematypsnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt typsnitt
- arabiskt typsnitt
- japanskt typsnitt
- georgiskt typsnitt
- thaana-typsnitt
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Granska, lägg till, ersätt och ta bort skript-specifika typsnittsmappningar i PowerPoint-teman med Aspose.Slides för Python via Java."
---
## **Översikt**

Ett presentations tema kan välja olika typsnittsfamiljer för olika skriftsystem. Detta gör det möjligt för flerspråkig text som fortfarande använder temats typsnitt att följa ett enhetligt typsnittsschema samtidigt som lämpliga typsnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [FontScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontscheme/) innehåller en huvudtypsnittssamling, som vanligtvis används för rubriker, och en sekundärtypsnittssamling, som vanligtvis används för brödtext. Förutom deras latinska och östasiatiska typsnittsinställningar exponerar båda samlingarna mappningar från skriftsystemtaggar till typsnittsfamiljenamn via klassen [Fonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/).

Denna artikel visar hur man inspekterar och ändrar dessa mappningar i presentationens mastertema och verifierar att ändringarna överlever en spara‑och‑läs‑om‑cykel.

## **Förstå skripttaggar**

Metoderna för skript‑typsnitt använder fyrbokstavs‑BCP‑47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skript‑tagg | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliska |
| `Arab` | Arabiska |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiska |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats typsnittsschema, inte enskilda textdelar. En presentation kan definiera olika mappningar för huvud‑ och sekundärsamlingarna, och den kan utelämna mappningar för vissa skript.

## **Åtkomst och inspektion av skript‑typsnittsmappningar**

Använd [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasterTheme) för att komma åt presentationens tema på övergripande nivå. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontscheme/#getMajor) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontscheme/#getMinor) returnerar de två [Fonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/)‑samlingarna.

Anropa [Fonts.getScriptFontMap](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#getScriptFontMap) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [Fonts.getScriptFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#getScriptFont) med dess skript‑tagg. `getScriptFont` returnerar `None` när den samlingen inte definierar den begärda mappningen.

## **Modifiera mappningar och verifiera beständighet**

Använd [Fonts.setScriptFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#setScriptFont) för att skapa en mappning eller ersätta dess nuvarande typsnittsfamilj. Använd [Fonts.removeScriptFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#removeScriptFont) för att ta bort en mappning.

Det följande end‑to‑end‑exemplet läser alla befintliga huvud‑ och sekundärmappningar, slår upp det japanska huvudtypsnittet, ändrar det kyrilliska huvudtypsnittet, tar bort den sekundära Thaana‑mappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat, skapar exemplet först en Thaana‑mappning endast när ingen redan är definierad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Verifieringen använder samma `None`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats returnerar `getScriptFont("Thaa")` `None` för den sekundära samlingen.

## **Skilj på temamappningar från andra typsnittsinställningar**

Skript‑specifika temamappningar deltar i typsnittsval, men de löser ett annat problem än direkt textformatering, substitution och reservtypsnitt:

| Mekanism | Syfte | Effekt av att ändra en temamappning |
|---|---|---|
| Skript‑specifik tematypsnittsmappning | Väljer ett huvud‑ eller sekundärt tematypsnitt för ett skriftsystem. | Text som fortfarande använder motsvarande tematypsnitt kan lösa till den nya mappade familjen. |
| Typsnitt tilldelat explicit till en textdel | Fixerar den begärda typsnittsfamiljen på den delen istället för att förlita sig på temat. | Textdelen kan förbli oförändrad eftersom dess direkta formatering åsidosätter temavalet. |
| Typsnittssubstitution | Ersätter ett begärt typsnitt när det typsnittet inte är tillgängligt eller när en substitutionsregel gäller. | Det sker efter att ett typsnitt har begärts; det omdefinierar inte temats skript‑mappning. |
| Typsnittsreserv | Tillhandahåller tecken som det valda typsnittet inte innehåller, ofta för specifika Unicode‑intervall. | Det fyller i saknade tecken; det ändrar inte den lagrade temamappningen. |

För mer information om de två sista mekanismerna, se [Typsnittssubstitution](/slides/sv/python-java/font-substitution/) och [Reservtypsnitt](/slides/sv/python-java/fallback-font/).

Att ändra en mappning i [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasterTheme) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaarv från en master, layout eller bild, eller använda ett explicit tilldelat typsnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentationens temamappning.

## **Gör mappade typsnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett typsnittsfamiljenamn; den installerar eller laddar inte den motsvarande typsnittsfilen. För konsekvent rendering och export måste varje mappat typsnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa såsom [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFonts) eller [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Se [Custom Fonts](/slides/sv/python-java/custom-font/) för tillgängliga laddningsalternativ.

Att verifiera den sparade mappningen bekräftar bara att temadefinitionen bevarades. Det bevisar inte att typsnittet är tillgängligt, innehåller alla nödvändiga tecken eller producerar den avsedda layouten. Rendera representativ text för varje obligatoriskt skriftsystem till en bild eller PDF och inspektera resultatet. Detta fångar saknade typsnitt, ofullständig teckentäckning, reservbeteende och layoutändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/python-java/convert-powerpoint/) för exempel på rendering och export.

## **FAQ**

**Vad returnerar `getScriptFont` när ett skript inte är mappat?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#getScriptFont) returnerar `None` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller sekundära typsnittssamlingen.

**Lägger `setScriptFont` till en andra mappning när skriptet redan finns?**

Nej. [Fonts.setScriptFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fonts/#setScriptFont) skapar mappningen när den saknas och ersätter den mappade typsnittsfamiljen när samma skript‑tagg redan finns.

**Varför ändrade en förändring av en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat typsnitt, ärva ett annat tema via en överskrivning, eller påverkas av substitution eller reservtypsnitt under rendering. En skript‑mappning på presentationsnivå styr endast text vars effektiva formatering fortfarande hänvisar till den tematypsnittssamlingen.

**Är det tillräckligt att spara och öppna igen för att validera flerspråkigt resultat?**

Nej. Att öppna igen verifierar beständighet av temadata. Rendera också representativ text från varje obligatoriskt skriftsystem för att bekräfta att de mappade typsnitten är tillgängliga och innehåller de nödvändiga tecknen.