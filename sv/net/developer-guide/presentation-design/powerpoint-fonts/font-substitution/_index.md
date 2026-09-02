---
title: Konfigurera teckensnittsbyte i presentationer i .NET
linktitle: Teckensnittsbyte
type: docs
weight: 70
url: /sv/net/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- ersätt teckensnitt
- teckensnittsersättning
- bytesregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konfigurera teckensnittsbytesregler och granska ersatta teckensnitt i Aspose.Slides för .NET när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittsbytesfunktion gör det möjligt för Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Bytet påverkar det renderade resultatet; det ändrar inte teckensnittet som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan granska de byten som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla resultatet konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittsbyten**

Använd metoden [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) för att avgöra vilka teckensnitt som kommer att bytas när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar det ursprungliga och det ersatta teckensnittets namn.

Följande C#‑exempel listar alla teckensnittsbyten för en presentation:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Hämta teckensnittsbyten för utvalda bilder**

Använd överlagringen av [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) med ett `int[] slides`‑argument för att endast granska de byten som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, letar efter bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till jämförelse är indexeringen i samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) noll‑baserad, så samma bild nås som `presentation.Slides[0]`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med ett steg.

Anropa överlagringen via egenskapen [Presentation.FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/fontsmanager/). Den returnerar endast de byten som bestäms under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller det ursprungliga och det ersatta teckensnittets namn. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, bytesregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsubstrulecollection/) och [externt inlästa teckensnitt](/slides/sv/net/custom-font/).

Samma byte kan krävas av mer än en utvald bild. Deduplikera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerat byte och skapar sedan en sorterad lista över unika teckensnittsmappningar:

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

[IFontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/)‑gränssnittet erbjuder båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd den när |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) utan argument | Du behöver byten för hela presentationen. |
| [GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) med `int[] slides` | Du behöver byten för ett urval av bilder, inkrementell kontroll eller partiell export. |

## **Ange teckensnittsbytesregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen till egenskapen [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande C#‑exempel ersätter `SomeRareFont` med `Arial` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Ersättnings‑teckensnittet måste vara tillgängligt för Aspose.Slides.

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
För en ovillkorlig ändring av de teckensnitt som används i hela en presentation, se [Teckensnittsersättning](/slides/sv/net/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Teckensnittsbytesregler är en del av den standardiserade teckensnittsurvalsprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller läs in det som ett [externt teckensnitt](/slides/sv/net/custom-font/).

Denna begränsning gäller ekvationslayouten. Bytesreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittsbyte?**

[Teckensnittsersättning](/slides/sv/net/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittsbyte väljer ett teckensnitt för renderat resultat när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas teckensnittsbytesregler?**

Reglerna deltar i [teckensnittsurvalsekvensen](/slides/sv/net/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen teckensnittsbytesregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsurvalsprocess. Resultatet beror på vilka teckensnitt som finns i körmiljön.

**Kan jag ladda in externa teckensnitt för att undvika byte?**

Ja. Du kan [ladda in externa teckensnitt](/slides/sv/net/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och för att följa deras licensvillkor.

**Kan teckensnittsbytesresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva byte på en annan.

**Hur kan jag göra teckensnittsurvalet konsekvent vid batchkonverteringar?**

Använd samma teckensnittsfiler och versioner på varje maskin eller container, [ladda in nödvändiga externa teckensnitt](/slides/sv/net/custom-font/) och [bädda in teckensnitt](/slides/sv/net/embedded-font/) när licensen tillåter. Du kan även anropa [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getsubstitutions/) före export för att identifiera oväntade byten.