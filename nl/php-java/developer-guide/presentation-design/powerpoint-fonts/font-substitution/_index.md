---
title: Lettertypevervanging configureren in presentaties met PHP
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/php-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Stel lettertypevervangingsregels in en inspecteer vervangende lettertypen in Aspose.Slides voor PHP via Java bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde uitvoer; het verandert het toegewezen lettertype van de presentatietekst niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen die Aspose.Slides tijdens het renderen zal toepassen inspecteren. Dit helpt de uitvoer consistent te houden in omgevingen met verschillende geïnstalleerde lettertypen.

Als een lettertype beschikbaar is maar geen eigen vet teken heeft, zie [Lettertypen zonder een specifiek vet teken behandelen](/slides/nl/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe de getroffen tekst tijdens PDF‑export gerasterd kan worden en de gevolgen voor tekstselectie, zoeken en schalen.

## **Lettertypevervangingen ophalen**

Gebruik de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) objecten die de oorspronkelijke en vervangen lettertype‑namen identificeren.

Het volgende PHP‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

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

## **Lettertypevervangingen voor geselecteerde dia's ophalen**

Gebruik de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) overload met een `int[] slides` argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertypepakket voorbereidt voor een server of container, of renderingsverschillen diagnoseert zonder ongeïntegreerde dia's te verwerken.

`slides`‑array bevat één‑gebaseerde dia‑indexen: `1` duidt de eerste dia aan. In tegenstelling daarmee gebruikt de [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) collectie‑toegangsmethode nul‑gebaseerde indexering, waardoor dezelfde dia wordt benaderd als `$presentation->getSlides()->get_Item(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) methode. Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia's zijn vastgesteld. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) object dat de oorspronkelijke en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/php-java/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia nodig zijn. Verwijder duplicaten uit de resultaten wanneer u een lettertype‑inventaris of een preflight‑rapport maakt. Het volgende voorbeeld meldt elke geretourneerde vervanging en maakt vervolgens een gesorteerde lijst met unieke lettertype‑toewijzingen:

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

De [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) klasse biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Wanneer gebruiken |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) without arguments | U heeft vervangingen nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle of een gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype te specificeren dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities aan voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) aan met de [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Ken de collectie toe via de [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) methode.
6. Render of converteer de presentatie.

Het volgende PHP‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

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
Voor een onvoorwaardelijke wijziging van de lettertypen die gedurende een presentatie worden gebruikt, zie [Lettertypevervanging](/slides/nl/php-java/font-replacement/) .
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is gespecificeerd.

Office Math‑vergelijkingen hebben een aanvullende eis. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype, zoals **STIX Two Math**, vervangt, kan **Cambria Math** voor dit doel niet vervangen, en renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/php-java/custom-font/) .

Deze beperking geldt voor de vergelijking‑lay‑out. De bovenstaande vervangingsregels blijven wel van toepassing op gewone presentatietekst.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertypevervanging en lettertypevervanging?**

[Lettertypevervanging](/slides/nl/php-java/font-replacement/) verandert bewust één lettertype in een ander door de hele presentatie heen. Lettertypevervanging selecteert een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, zoals wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden vervangingsregels toegepast?**

De regels maken deel uit van de [lettertype‑selectiesequentie](/slides/nl/php-java/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bron‑lettertype.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen vervangingsregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om vervanging te voorkomen?**

Ja. U kunt [externe lettertypen laden](/slides/nl/php-java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen vervangingsresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, dus een lettertype dat op de ene machine beschikbaar is, kan op een andere substitutie vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertypebestanden en versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/php-java/custom-font/), en [lettertypen insluiten](/slides/nl/php-java/embedded-font/) wanneer de licentie het toestaat. U kunt ook [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte vervangingen te identificeren.