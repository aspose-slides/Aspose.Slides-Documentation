---
title: Konfigurera typsnittsbyte i presentationer med Python via Java
linktitle: Typsnittsbyte
type: docs
weight: 70
url: /sv/python-java/font-substitution/
keywords:
- typsnitt
- ersättningsfont
- typsnittsbyte
- byta typsnitt
- typsnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Konfigurera typsnittsbytesregler och inspektera ersatta typsnitt i Aspose.Slides för Python via Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Typsnittsbyte tillåter Aspose.Slides att använda ett tillgängligt typsnitt i stället för ett typsnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar den renderade utdata; den ändrar inte det typsnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket typsnitt som ska användas när ett specifikt typsnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade typsnitt.

Om ett typsnitt är tillgängligt men saknar en dedikerad fet stil, se [Hantera typsnitt utan en dedikerad fet stil](/slides/sv/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Det avsnittet förklarar hur man rasteriserar den påverkade texten under PDF‑export och vilka konsekvenser det har för textmarkering, sökning och skalning.

## **Hämta typsnittsbyte**

Använd metoden [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) för att avgöra vilka typsnitt som kommer att ersättas när presentationen renderas. Metoden returnerar objekt av typen [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) som identifierar de ursprungliga och ersatta typsnittsnamnen.

Följande Python‑exempel listar alla typsnittsbyten för en presentation:

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

## **Hämta typsnittsbyte för valda bilder**

Använd överlagringen av [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) med ett Java‑heltalarray‑argument för att inspektera endast de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokaliserar bilder som är beroende av otillgängliga typsnitt, förbereder ett minimalt typsnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. I kontrast använder åtkomstmetoden [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) en noll‑baserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Tänk på denna skillnad när du bygger arrayen för att undvika fel med ett steg.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Den returnerar endast de substitutioner som bestämdes under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och ersatta typsnittsnamnen. Resultatet speglar den aktuella typsnitts‑miljön, konfigurerade reservregler, substitutionregler lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) och [externally loaded fonts](/slides/sv/python-java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett typsnittsinventarium eller en preflight‑rapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista med unika typsnittsmappningar:

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

Klassen [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) erbjuder båda överlagringarna. Välj den som passar omfattningen av renderingsoperationen:

| Överlagring | När den ska användas |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) utan argument | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) med ett Java‑heltalarray | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange typsnittsbytesregler**

För att specificera vilket typsnitt Aspose.Slides ska använda när ett käll‑typsnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa typsnittsdefinitioner för käll‑ och ersättningstypsnitt.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Rendera eller konvertera presentationen.

Följande Python‑exempel ersätter `Arial` med `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande typsnittet måste vara tillgängligt för Aspose.Slides.

```python
import jpime
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
För en ovillkorlig ändring av de typsnitt som används i hela en presentation, se [Typsnittsbyte](/slides/sv/python-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för typsnitt i matematiska ekvationer**

Typsnittsbytesregler är en del av standardprocessen för typsnittsval som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt typsnitt med det tillgängliga typsnitt som specificerats i en regel.

Office‑Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva exakt det typsnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter med ett annat matematiskt typsnitt, exempelvis **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [external font](/slides/sv/python-java/custom-font/).

Denna begränsning gäller för ekvationslayout. De ovan beskrivna substitutionreglerna gäller fortfarande för vanlig presentations­text.

## **FAQ**

**Vad är skillnaden mellan typsnittsbyte och typsnittsbyte?**  
[Font replacement](/slides/sv/python-java/font-replacement/) ändrar medvetet ett typsnitt till ett annat i hela presentationen. Typsnittsbyte väljer ett typsnitt för den renderade utdata när det konfigurerade villkoret uppfylls, exempelvis när det ursprungliga typsnittet är otillgängligt.

**När tillämpas substitutionregler?**  
Reglerna deltar i [font selection sequence](/slides/sv/python-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt käll‑typsnittet.

**Vad händer när ett typsnitt saknas och ingen substitutionregel är konfigurerad?**  
Aspose.Slides väljer det närmaste tillgängliga typsnittet enligt sin typsnittsväljningsprocess. Resultatet beror på vilka typsnitt som finns i körningsmiljön.

**Kan jag ladda externa typsnitt för att undvika substitution?**  
Ja. Du kan [load external fonts](/slides/sv/python-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose typsnitt med biblioteket?**  
Nej. Du ansvarar för att tillhandahålla typsnitt och att följa deras licensvillkor.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**  
Ja. Installerade typsnitt och sökvägar för typsnitt varierar mellan operativsystem, så ett typsnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra typsnittsvalet konsekvent i batch‑konverteringar?**  
Använd samma typsnittsfiler och versioner på varje maskin eller container, [load required external fonts](/slides/sv/python-java/custom-font/), och [embed fonts](/slides/sv/python-java/embedded-font/) när licensen tillåter det. Du kan också anropa [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) före export för att identifiera oväntade substitutioner.