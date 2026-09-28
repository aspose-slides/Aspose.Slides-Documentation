---
title: Konfigurera teckensnittssubstitution i presentationer i .NET
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och inspektera substituerade teckensnitt i Aspose.Slides för .NET när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Font substitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar den renderade utdata; den ändrar inte det teckensnitt som tilldelats presentationsinnehållet.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt inte är tillgängligt, och du kan inspektera de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar de ursprungliga och substituerade teckensnittsnamnen.

Följande C#‑exempel listar alla teckensnittssubstitutioner för en presentation:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen av [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) med ett `int[] slides`‑argument för att endast inspektera de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokaliserar bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta irrelevanta bilder.

`slides`‑arrayen innehåller en‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta är indexeraren i samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) noll‑baserad, så samma bild nås som `presentation.Slides[0]`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika ett‑off‑by‑one‑fel.

Anropa överlagringen via egenskapen [Presentation.FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/fontsmanager/). Den returnerar endast de substitutioner som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och substituerade teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön och [externt laddade teckensnitt](/slides/sv/net/custom-font/). Substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsubstrulecollection/) ändrar den renderade utdata men återspeglas inte i resultatet.

Samma substitution kan krävas av mer än en vald bild. Deduplicera resultaten när du skapar ett teckensnittsinventarium eller en förkontrollrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittskartläggningar:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/)‑gränssnittet tillhandahåller båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd den när |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) utan argument | Du behöver substitutioner för hela presentationen. |
| [GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) med `int[] slides` | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt inte är tillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll‑ och substitut‑teckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen till egenskapen [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande C#‑exempel substituerar `Arial` för `SomeRareFont` när `SomeRareFont` inte är tillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det substituerade teckensnittet måste vara tillgängligt för Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
För en villkorslös ändring av de teckensnitt som används i hela presentationen, se [Font Replacement](/slides/sv/net/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvations‑teckensnitt**

Teckensnittssubstitutionsregler är en del av den standardprocess för teckensnittsval som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som specificeras av en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som substituerar ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/net/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Font replacement](/slides/sv/net/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för den renderade utdata när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet inte är tillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [teckensnittsväljssekvensen](/slides/sv/net/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan nå källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som är tillgängliga i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/net/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du är ansvarig för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batchkonverteringar?**

Använd samma teckensnitts‑filer och versioner på varje maskin eller container, [ladda erforderliga externa teckensnitt](/slides/sv/net/custom-font/) och [bädda in teckensnitt](/slides/sv/net/embedded-font/) när licensen tillåter det. Du kan också anropa [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) före export för att identifiera oväntade substitutioner.