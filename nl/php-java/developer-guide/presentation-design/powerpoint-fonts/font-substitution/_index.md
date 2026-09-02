---
title: Lettertype‑substitutie configureren in presentaties met PHP
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/php-java/font-substitution/
keywords:
- lettertype
- substitutie‑lettertype
- lettertype‑substitutie
- lettertype vervangen
- lettertype‑vervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Configureer lettertype‑substitutieregels en inspecteer gesubstitueerde lettertypes in Aspose.Slides voor PHP via Java bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertype‑substitutie stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De substitutie heeft invloed op de gerenderde output; het wijzigt niet het lettertype dat aan de presentatie‑inhoud is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een specifiek lettertype niet beschikbaar is, en u kunt de substituties bekijken die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypes.

## **Lettertype‑substituties ophalen**

Gebruik de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/) methode om te bepalen welke lettertypes worden gesubstitueerd wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstitutioninfo/)‑objecten die de originele en gesubstitueerde lettertypenamen identificeren.

Het volgende PHP‑voorbeeld geeft alle lettertype‑substituties voor een presentatie weer:

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

## **Lettertype‑substituties ophalen voor geselecteerde dia's**

Gebruik de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/) overload met een `int[] slides`‑argument om alleen de substituties te bekijken die nodig zijn om specifieke dia's te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie stapsgewijs controleert, dia’s opspoort die afhankelijk zijn van niet‑beschikbare lettertypes, een minimaal lettertype‑pakket voor een server of container voorbereidt, of rendering‑verschillen diagnosticeert zonder ongerelateerde dia’s te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Daarentegen gebruikt de [Presentation::getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlides) collectie‑accessor nul‑gebaseerde indexering, zodat dezelfde dia wordt benaderd met `$presentation->getSlides()->get_Item(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation::getFontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getFontsManager) methode. Deze retourneert alleen de substituties die bepaald zijn tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstitutioninfo/)‑object dat de originele en gesubstitueerde lettertypenamen bevat. Het resultaat weerspiegelt de actuele lettertype‑omgeving, geconfigureerde fallback‑regels, substitutieregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstrulecollection/), en [extern geladen lettertypes](/slides/nl/php-java/custom-font/).

Dezelfde substitutie kan nodig zijn voor meer dan één geselecteerde dia. De‑duplicateer de resultaten wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld rapporteert elke geretourneerde substitutie en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/) klasse biedt beide overloads. Kies er één op basis van de reikwijdte van de rendering‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/) zonder argumenten | U heeft substituties nodig voor de gehele presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/) met `int[] slides` | U heeft substituties nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en het vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstcondition/) conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met de [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) methode.
6. Render of converteer de presentatie.

Het volgende PHP‑voorbeeld substitueert `Arial` voor `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

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
Voor een onvoorwaardelijke wijziging van de lettertypes die in de hele presentatie worden gebruikt, zie [Font Replacement](/slides/nl/php-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige formule‑lettertypes**

Lettertype‑substitutieregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens rendering en conversie wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office‑Math‑formules hebben een extra vereiste. Als een formule **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de formule te berekenen en te renderen. Een regel die een ander wiskundig lettertype, zoals **STIX Two Math**, substitueert, kan **Cambria Math** niet vervangen voor dit doel, en rendering kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/php-java/custom-font/).

Deze beperking geldt voor de formule‑lay‑out. De hierboven beschreven substitutieregels blijven van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/php-java/font-replacement/) verandert opzettelijk één lettertype in een ander door de hele presentatie heen. Lettertype‑substitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/php-java/font-selection-sequence/) tijdens rendering en conversie. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides kiest het meest passende beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de in de runtime‑omgeving beschikbare lettertypes.

**Kan ik externe lettertypes laden om substitutie te vermijden?**

Ja. U kunt [external fonts](/slides/nl/php-java/custom-font/) laden zodat Aspose.Slides ze kan gebruiken tijdens rendering en conversie.

**Distribueert Aspose lettertypes met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypes en het respecteren van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypes en zoeklocaties verschillen per besturingssysteem, waardoor een lettertype dat op de ene machine beschikbaar is, op een andere machine substitutie kan vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [load required external fonts](/slides/nl/php-java/custom-font/), en [embed fonts](/slides/nl/php-java/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [FontsManager::getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte substituties te identificeren.