---
title: Konfigurera teckensnittssubstitution i presentationer med JavaScript
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/nodejs-java/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittssubstitution
- ersätt teckensnitt
- teckensnittsersättning
- substitionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och granska ersatta teckensnitt i Aspose.Slides för Node.js via Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittssubstitution gör det möjligt för Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte det teckensnitt som tilldelats presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan undersöka de substitutioner som Aspose.Slides gör under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

Om ett teckensnitt är tillgängligt men saknar en dedikerad fet stil, se [Hantera teckensnitt utan en dedikerad fet stil](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Det avsnittet förklarar hur man rasteriserar den berörda texten under PDF-export och konsekvenserna för textmarkering, sökning och skalning.

## **Hämta teckensnittssubstitutioner**

Använd metoden [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)-objekt som identifierar de ursprungliga och ersatta teckensnittens namn.

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

Använd overloaden av [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) med en array av bildindex för att bara granska de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokalisera bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

Overloaden förväntar sig en Java‑primitiv `int[]`. Skapa den med `java.newArray("int", [...])`; en vanlig JavaScript‑array konverteras till `Integer[]` och matchar inte denna overload.

Arrayen innehåller en‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) samlingsåtkomsten noll‑baserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med en förskjutning.

Anropa overloaden via [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Den returnerar endast de substitutioner som bestäms under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)-objekt som innehåller de ursprungliga och ersatta teckensnittens namn. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutionsregler lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) och [externt laddade teckensnitt](/slides/sv/nodejs-java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Avdubbla resultaten när du skapar en teckensnittsinventering eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittsmappningar:

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

Klassen [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) erbjuder båda overloaderna. Välj en enligt omfattningen av renderingsoperationen:

| Overload | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Du behöver substitutioner för ett valt område, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittsdefinitioner för käll- och ersättningsteckensnittet.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande JavaScript‑exempel ersätter `Arial` med `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Ersättningsteckensnittet måste vara tillgängligt för Aspose.Slides.

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
För en villkorsfri förändring av de teckensnitt som används i hela en presentation, se [Teckensnittsersättning](/slides/sv/nodejs-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Teckensnittssubstitutionsregler är en del av den standardprocess för teckensnittsväljning som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som specificeras i en regel.

Office Math‑ekvationer har ett ytterligare krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter ett annat matematikteckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/nodejs-java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**  
[Teckensnittsersättning](/slides/sv/nodejs-java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för renderad utdata när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**  
Reglerna deltar i [teckensnittsväljningssekvens](/slides/sv/nodejs-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**  
Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som är tillgängliga i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**  
Ja. Du kan [ladda externa teckensnitt](/slides/sv/nodejs-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**  
Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**  
Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batchkonverteringar?**  
Använd samma teckensnittsfiler och versioner på varje maskin eller container, [ladda nödvändiga externa teckensnitt](/slides/sv/nodejs-java/custom-font/) och [bädda in teckensnitt](/slides/sv/nodejs-java/embedded-font/) när licensiering tillåter. Du kan också anropa [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) före export för att identifiera oväntade substitutioner.