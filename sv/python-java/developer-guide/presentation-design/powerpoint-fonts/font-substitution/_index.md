---
title: "Konfigurera teckensnittssubstitution i presentationer med Python via Java"
linktitle: "Teckensnittssubstitution"
type: docs
weight: 70
url: /sv/python-java/font-substitution/
keywords:
- teckensnitt
- substituera teckensnitt
- teckensnittssubstitution
- ersätt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och granska ersatta teckensnitt i Aspose.Slides för Python via Java vid rendering eller konvertering av PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittssubstitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar den renderade utdata; den ändrar inte det teckensnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstitutioninfo/)-objekt som identifierar original- och ersatte teckensnittsnamn.

Följande Python‑exempel listar alla teckensnittssubstitutioner för en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen av [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) med ett Java‑heltalarray‑argument för att endast granska de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation steg för steg, lokalerar bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller behållare, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder åtkomstmetoden [Presentation.getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) noll‑baserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med ett steg.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getFontsManager). Den returnerar endast de substitutioner som bestäms under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstitutioninfo/)-objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutionregler lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstrulecollection/) och [externt inlästa teckensnitt](/slides/sv/python-java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittsmappningar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/)-klassen tillhandahåller båda överlagringarna. Välj en utifrån omfattningen av renderingoperationen:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ställ in teckensnittssubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Rendera eller konvertera presentationen.

Följande Python‑exempel substituerar `Arial` med `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande teckensnittet måste vara tillgängligt för Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/sv/python-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för teckensnitt i matematiska ekvationer**

Teckensnittssubstitutionsregler är en del av den standardiserade teckensnittsurvalsprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva just det teckensnittet för att beräkna och rendera ekvationens layout. En regel som ersätter med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/python-java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan font replacement och font substitution?**

[Font replacement](/slides/sv/python-java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Font substitution väljer ett teckensnitt för den renderade utdata när det konfigurerade villkoret är uppfyllt, till exempel när originalteckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/python-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan nå källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsurvalsprocess. Resultatet beror på vilka teckensnitt som finns i körmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/python-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och för att följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt skiljer sig åt mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsvalet konsekvent i batch‑konverteringar?**

Använd samma teckensnitts‑filer och versioner på varje maskin eller behållare, [ladda erforderliga externa teckensnitt](/slides/sv/python-java/custom-font/) och [bädda in teckensnitt](/slides/sv/python-java/embedded-font/) när licensen tillåter det. Du kan också anropa [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) före export för att identifiera oväntade substitutioner.