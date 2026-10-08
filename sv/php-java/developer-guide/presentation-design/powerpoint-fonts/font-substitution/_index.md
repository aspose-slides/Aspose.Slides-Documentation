---
title: Konfigurera teckensnittsersättning i presentationer med PHP
linktitle: Teckensnittsersättning
type: docs
weight: 70
url: /sv/php-java/font-substitution/
keywords:
- teckensnitt
- ersättningsteckensnitt
- teckensnittsersättning
- byta teckensnitt
- teckensnittsbyte
- ersättningsregel
- bytregel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Konfigurera regler för teckensnittsersättning och inspektera ersatta teckensnitt i Aspose.Slides för PHP via Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Teckensnittsbyte gör det möjligt för Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Bytet påverkar det renderade resultatet; det ändrar inte teckensnittet som är tilldelat presentationsinnehållet.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt inte är tillgängligt, och du kan inspektera de ersättningar som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utskriften konsekvent över miljöer med olika installerade teckensnitt.

Om ett teckensnitt är tillgängligt men saknar en dedikerad fet stil, se [Hantera teckensnitt utan en dedikerad fet stil](/slides/sv/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Det avsnittet förklarar hur man rasteriserar den berörda texten under PDF‑export och vilka konsekvenser det har för textmarkering, sökning och skalning.

## **Hämta teckensnittsersättningar**

Använd metoden [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) för att bestämma vilka teckensnitt som kommer att ersättas när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande PHP‑exempel listar alla teckensnittsersättningar för en presentation:

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

## **Hämta teckensnittsersättningar för valda bilder**

Använd overload‑versionen av [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) med ett `int[] slides`‑argument för att bara inspektera de ersättningar som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, lokaliserar bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta irrelevanta bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Däremot använder åtkomstmetoden [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) en noll‑baserad indexering, så samma bild nås som `$presentation->getSlides()->get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med ett steg.

Kalla på overload‑versionen via metoden [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Den returnerar endast de ersättningar som bestäms under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, ersättningsregler lagrade i en [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), och [externt laddade teckensnitt](/slides/sv/php-java/custom-font/).

Samma ersättning kan krävas av fler än en vald bild. Avduplicera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskning. Följande exempel rapporterar varje returnerad ersättning och skapar sedan en sorterad lista med unika teckensnittsmappningar:

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

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/)‑klassen tillhandahåller båda overload‑versionerna. Välj en enligt omfattningen av renderingsoperationen:

| Overload | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) utan argument | Du behöver ersättningar för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) med `int[] slides` | Du behöver ersättningar för ett valt område, inkrementell kontroll eller partiell export. |

## **Ställ in teckensnittsersättningsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt inte är tillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitt.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande PHP‑exempel ersätter `Arial` för `SomeRareFont` när `SomeRareFont` inte är tillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande teckensnittet måste vara tillgängligt för Aspose.Slides.

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
För en ovillkorlig ändring av de teckensnitt som används i hela presentationen, se [Teckensnittsersättning](/slides/sv/php-java/font-replacement/).
{{% /alert %}}

## **Begränsningar för teckensnitt i matematiska ekvationer**

Teckensnitts ersättningsregler är en del av den standardprocess för teckensnittsval som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som specificeras i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/php-java/custom-font/).

Denna begränsning gäller för ekvationslayout. Ersättningsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittsbyte?**

[Teckensnittsersättning](/slides/sv/php-java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittsbyte väljer ett teckensnitt för renderat resultat när det konfigurerade villkoret är uppfyllt, till exempel när originalteckensnittet inte är tillgängligt.

**När tillämpas ersättningsregler?**

Reglerna deltar i [teckensnittsvalsekvens](/slides/sv/php-java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen ersättningsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsvalprocess. Resultatet beror på vilka teckensnitt som finns tillgängliga i körmiljön.

**Kan jag ladda externa teckensnitt för att undvika ersättning?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/php-java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du är ansvarig för att tillhandahålla teckensnitt och följa deras licenser.

**Kan ersättningsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt skiljer sig mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva ersättning på en annan.

**Hur kan jag göra teckensnittsvalet konsekvent i batchkonverteringar?**

Använd samma teckensnitts‑filer och versioner på varje maskin eller container, [ladda erforderliga externa teckensnitt](/slides/sv/php-java/custom-font/), och [bädda in teckensnitt](/slides/sv/php-java/embedded-font/) när licensiering tillåter. Du kan också anropa [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) före export för att identifiera oväntade ersättningar.