---
title: Hantera skript‑specifika temateckensnitt i Python
linktitle: Skript‑specifika temateckensnitt
type: docs
weight: 15
url: /sv/python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Inspektera, lägg till, ersätt och ta bort skript‑specifika teckensnittsmappningar i PowerPoint‑teman med Aspose.Slides för Python via .NET."
---
## **Översikt**

Ett presentations tema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta möjliggör flerspråkig text som fortfarande använder temats teckensnitt att följa ett enhetligt teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [FontScheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/) innehåller en huvudteckensnittssamling som vanligtvis används för rubriker och en sekundär teckensnittssamling som vanligtvis används för brödtext. Förutom deras latin- och östasiatiska teckensnittsegenskaper exponeras mappningar från skriftsystem‑taggar till teckensnittsfamiljenamn genom klassen [Fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/).

Denna artikel visar hur man inspekterar och ändrar dessa mappningar i presentationens huvudtema och verifierar att ändringarna överlever en spar‑och‑läs‑cykel.

## **Förstå skripttaggar**

Skriptteckensnittsmetoderna använder fyrabokstaviga BCP 47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skripttagg | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliska |
| `Arab` | Arabiska |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiska |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats teckensnittsschema, inte enskilda textstycken. En presentation kan definiera olika mappningar för huvud‑ och sekundärsamlingarna och kan utelämna mappningar för vissa skript.

## **Åtkomst och inspektion av skriptteckensnittsmappningar**

Använd [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/) för att nå presentations‑nivåns tema. Egenskaperna [FontScheme.major](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/major/) och [FontScheme.minor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/minor/) returnerar de två [Fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/)-samlingarna.

Anropa [Fonts.get_script_font_map](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/get_script_font_map/) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [Fonts.get_script_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/get_script_font/) med dess skripttagg. `get_script_font` returnerar `None` när den samlingen inte definierar den begärda mappningen.

## **Ändra mappningar och verifiera beständighet**

Använd [Fonts.set_script_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/set_script_font/) för att skapa en mappning eller ersätta dess nuvarande teckensnittsfamilj. Använd [Fonts.remove_script_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/remove_script_font/) för att ta bort en mappning.

Följande end‑to‑end‑exempel läser alla befintliga huvud‑ och sekundärmappningar, slår upp det japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort Thaana‑sekundärmappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplet först en Thaana‑mappning endast när ingen sådan redan är definierad.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Verifieringen använder samma `None`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats returnerar `get_script_font("Thaa")` `None` för sekundärsamlingen.

## **Skilja temamappningar från andra teckensnittsinställningar**

Skript‑specifika temamappningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, ersättning och återfalla:

| Mekanism | Syfte | Effekt av att ändra en temamappning |
|---|---|---|
| Skript‑specifik temateckensnittsmappning | Väljer ett huvud‑ eller sekundärt temateckensnitt för ett skriftsystem. | Text som fortfarande använder motsvarande temateckensnitt kan lösa till den nya mappade familjen. |
| Teckensnitt som tilldelas explicit till ett textstycke | Fixerar den begärda teckensnittsfamiljen på det stycket istället för att förlita sig på temat. | Stycket kan förbli oförändrat eftersom dess direkta formatering åsidosätter temavalet. |
| Teckensnittsersättning | Ersätter ett begärt teckensnitt när det inte är tillgängligt eller när en ersättningsregel gäller. | Det sker efter att ett teckensnitt har begärts; det omdefinierar inte temats skript‑mappning. |
| Teckensnittsåterfalla | Tillhandahåller tecken som det valda teckensnittet saknar, ofta för specifika Unicode‑intervall. | Det fyller i saknade tecken; det ändrar inte den lagrade temamappningen. |

För mer information om de två sista mekanismerna, se [Font Substitution](/slides/sv/python-net/font-substitution/) och [Fallback Fonts](/slides/sv/python-net/fallback-font/).

Att ändra en mappning i [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaarv från ett master‑, layout‑ eller bild‑tema, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentations‑nivåns mappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållet till Aspose.Slides via en anpassad källa såsom [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/load_external_fonts/) eller [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/document_level_font_sources/). Se [Custom Fonts](/slides/sv/python-net/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar endast att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla erforderliga tecken eller producerar den avsedda layouten. Rendera representativ text för varje nödvändigt skriftsystem till en bild eller PDF och inspektera resultatet. Detta fångar saknade teckensnitt, ofullständig teckentäckning, återfallsbeteende och layoutändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/python-net/convert-powerpoint/) för renderings‑ och exportexempel.

## **Vanliga frågor**

**Vad returnerar `get_script_font` när ett skript inte är mappat?**

[Fonts.get_script_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/get_script_font/) returnerar `None` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller sekundära teckensnittssamlingen.

**Lägger `set_script_font` till en andra mappning när skriptet redan finns?**

Nej. [Fonts.set_script_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fonts/set_script_font/) skapar mappningen när den saknas och ersätter den mappade teckensnittsfamiljen när samma skripttagg redan är närvarande.

**Varför ändrade en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema genom ett överskuggning, eller påverkas av ersättning eller återfalla vid rendering. En presentations‑nivåns skript‑mappning styr endast text vars effektiva formatering fortfarande hänvisar till den temateckensnittssamlingen.

**Är sparande och återöppning tillräckligt för att validera flerspråkig output?**

Nej. Återöppning verifierar beständighet av temadata. Du bör också rendera representativ text från varje nödvändigt skriftsystem för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller de nödvändiga tecknen.