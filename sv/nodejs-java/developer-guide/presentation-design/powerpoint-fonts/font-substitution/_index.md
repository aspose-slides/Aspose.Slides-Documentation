---
title: Konfigurera teckensnittssubstitution i presentationer med JavaScript
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/nodejs-java/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittssubstitution
- ersätt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och inspektera ersatta teckensnitt i Aspose.Slides för Node.js via Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittssubstitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte det teckensnitt som är tilldelat presentationsinnehållet.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt inte är tillgängligt, och du kan inspektera de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla resultatet konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) för att bestämma vilka teckensnitt som kommer att ersättas när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstitutioninfo/) objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande JavaScript‑exempel listar alla teckensnittssubstitutioner för en presentation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen av [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) med en array av bildindex för att endast inspektera de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, lokaliserar bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta irrelevanta bilder.

Överlagringen förväntar sig en Java‑primitiv `int[]`. Skapa den med `java.newArray("int", [...])`; en vanlig JavaScript‑array konverteras till `Integer[]` och matchar inte denna överlagring.

Arrayen innehåller ett-baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder samlingsåtkomsten [Presentation.getSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslides/) nollbaserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Tänk på denna skillnad när du bygger arrayen för att undvika avläsningsfel.

Anropa överlagringen via [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getfontsmanager/). Den returnerar endast de substitutioner som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstitutioninfo/) objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutioner lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstrulecollection/) och [externalt laddade teckensnitt](/slides/sv/nodejs-java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista med unika teckensnittsmappningar:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/)‑klassen tillhandahåller båda överlagringarna. Välj den som passar omfattningen av renderingsoperationen:

| Överlagring | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) utan argument | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) med en Java `int[]` av bildindex | Du behöver substitutioner för ett markerat område, stegvis kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att specificera vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt inte är tillgängligt:

1. Läs in presentationen.  
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitt.  
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Rendera eller konvertera presentationen.

Följande JavaScript‑exempel ersätter `Arial` med `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande teckensnittet måste vara tillgängligt för Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
För en ovillkorlig ändring av de teckensnitt som används i hela en presentation, se [Font Replacement](/slides/sv/nodejs-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvations‑teckensnitt**

Teckensnittssubstitutionsregler är en del av den standardiserade teckensnittsväljprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office‑Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externalt teckensnitt](/slides/sv/nodejs-java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentations‑text.

## **Vanliga frågor**

**Vad är skillnaden mellan font replacement och font substitution?**  
[Font replacement](/slides/sv/nodejs-java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Font substitution väljer ett teckensnitt för det renderade resultatet när den konfigurerade villkoret uppfylls, exempelvis när originalteckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**  
Reglerna deltar i [font selection sequence](/slides/sv/nodejs-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**  
Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljprocess. Resultatet beror på vilka teckensnitt som finns i körmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**  
Ja. Du kan [load external fonts](/slides/sv/nodejs-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**  
Nej. Du är ansvarig för att tillhandahålla teckensnitt och följa deras licensvillkor.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**  
Ja. Installerade teckensnitt och sökvägar skiljer sig mellan operativsystem, så ett teckensnitt som finns på en maskin kan behöva substitueras på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batchkonverteringar?**  
Använd samma teckensnittsfiler och versioner på varje maskin eller container, [load required external fonts](/slides/sv/nodejs-java/custom-font/), och [embed fonts](/slides/sv/nodejs-java/embedded-font/) när licensen tillåter det. Du kan också anropa [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) innan export för att identifiera oväntade substitutioner.