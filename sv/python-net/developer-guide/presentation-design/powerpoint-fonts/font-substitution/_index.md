---
title: Konfigurera teckensnittssubstitution i presentationer med Python
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/python-net/font-substitution/
keywords:
- teckensnitt
- ersättnings-teckensnitt
- teckensnittssubstitution
- ersätta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Konfigurera regler för teckensnittssubstitution och inspektera ersatta teckensnitt i Aspose.Slides för Python via .NET när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Fontsubstitution låter Aspose.Slides använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte teckensnittet som är tilldelat presentationsinnehållet.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt är otillgängligt, och du kan inspektera de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utskriften konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [FontsManager.get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande Python‑exempel listar alla teckensnittssubstitutioner för en presentation:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd [FontsManager.get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) med en lista över bildindex för att inspektera endast de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokaliserar bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

Listan innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från så är samlingen [Presentation.slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) noll‑baserad, så samma bild nås som `presentation.slides[0]`. Håll denna skillnad i åtanke när du bygger listan för att undvika fel med ett index.

Anropa metoden via egenskapen [Presentation.fonts_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/fonts_manager/). Den returnerar endast de substitutioner som bestäms under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnitts­miljön, konfigurerade reservregler, substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ifontsubstrulecollection/), och [externally loaded fonts](/slides/sv/python-net/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Dedupliera resultaten när du skapar ett teckensnitts‑inventarium eller en preflight‑rapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista med unika teckensnittsmappningar:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Klassen [FontsManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/) erbjuder båda formerna av metoden. Välj den som passar omfattningen av renderingsoperationen:

| Metodanrop | Använd när |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Du behöver substitutioner för hela presentationen. |
| [get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Du behöver substitutioner för ett valt område, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att specificera vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittsdefinitioner för käll- och ersättningsteckensnittet.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstrule/) med villkoret [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen till egenskapen [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Rendera eller konvertera presentationen.

Följande Python‑exempel substituerar `Arial` för `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Ersättningsteckensnittet måste vara tillgängligt för Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
För en ovillkorlig förändring av teckensnitten som används i hela presentationen, se [Font Replacement](/slides/sv/python-net/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Substitutionsregler för teckensnitt är en del av den standardiserade teckensnittsvalprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva just det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som substituerar ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [external font](/slides/sv/python-net/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentations‑text.

## **Vanliga frågor**

**Vad är skillnaden mellan font replacement och font substitution?**

[Font replacement](/slides/sv/python-net/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat genom hela presentationen. Font substitution väljer ett teckensnitt för renderad output när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/python-net/font-selection-sequence/) under rendering och konvertering. Med `WHEN_INACCESSIBLE` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljsprocess. Resultatet beror på vilka teckensnitt som finns i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [load external fonts](/slides/sv/python-net/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och för att följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batch‑konverteringar?**

Använd samma teckensnittsfiler och versioner på varje maskin eller container, [load required external fonts](/slides/sv/python-net/custom-font/), och [embed fonts](/slides/sv/python-net/embedded-font/) när licensen tillåter det. Du kan också anropa [FontsManager.get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) före export för att identifiera oväntade substitutioner.