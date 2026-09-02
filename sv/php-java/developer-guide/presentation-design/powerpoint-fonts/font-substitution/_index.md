---
title: "Konfigurera teckensnittssubstitution i presentationer med PHP"
linktitle: "Teckensnittssubstitution"
type: docs
weight: 70
url: /sv/php-java/font-substitution/
keywords:
- teckensnitt
- substituera teckensnitt
- teckensnittssubstitution
- byt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och granska substituerade teckensnitt i Aspose.Slides för PHP via Java vid rendering eller konvertering av PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittssubstitution gör det möjligt för Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte det teckensnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent mellan miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [FontsManager::getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/) för att fastställa vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar objekt av typen [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstitutioninfo/) som identifierar de ursprungliga och substituerade teckensnittsnamnen.

Följande PHP‑exempel listar alla teckensnittssubstitutioner för en presentation:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen av [FontsManager::getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/) med argumentet `int[] slides` för att endast granska de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, hittar bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller bildindex med 1‑basering: `1` identifierar den första bilden. I kontrast använder åtkomsten [Presentation::getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlides) nollbaserad indexering, så samma bild nås som `$presentation->getSlides()->get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med ett steg.

Anropa överlagringen via metoden [Presentation::getFontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getFontsManager). Den returnerar endast de substitutioner som bestämdes under rendering av de valda bilderna. Varje resultat är ett objekt av typen [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstitutioninfo/) som innehåller de ursprungliga och substituerade teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutionregler lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstrulecollection/) och [externt inlästa teckensnitt](/slides/sv/php-java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar en teckensnitts‑inventering eller ett förhandsgransknings‑rapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittsmappningar:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/)‑klassen erbjuder båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd den när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Du behöver substitutioner för ett valt område, stegvis kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittsdefinitioner för käll- och substitutteckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen med metoden [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande PHP‑exempel substituerar `Arial` för `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det substituerade teckensnittet måste vara tillgängligt för Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/sv/php-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvations­teckensnitt**

Teckensnittssubstitutionsregler är en del av den standardiserade teckensnittsurvalsprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva just det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som substituerar ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/php-java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivs ovan gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Font replacement](/slides/sv/php-java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för det renderade resultatet när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [teckensnittsurvalssekvensen](/slides/sv/php-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsurvalsprocess. Resultatet beror på vilka teckensnitt som finns i runtime‑miljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/php-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och teckensnittsökvägar skiljer sig åt mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsurvalet konsekvent vid batchkonverteringar?**

Använd samma teckensnitts‑filer och versioner på varje maskin eller container, [ladda nödvändiga externa teckensnitt](/slides/sv/php-java/custom-font/) och [bädda in teckensnitt](/slides/sv/php-java/embedded-font/) när licensieringen tillåter. Du kan också anropa [FontsManager::getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/) före export för att identifiera oväntade substitutioner.