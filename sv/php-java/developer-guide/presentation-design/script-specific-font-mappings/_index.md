---
title: "Hantera skript‑specifika temateckensnitt i PHP"
linktitle: "Skript‑specifika temateckensnitt"
type: docs
weight: 15
url: /sv/php-java/script-specific-font-mappings/
keywords:
- skript‑specifikt teckensnitt
- tema‑teckensnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana‑teckensnitt
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Inspektera, lägg till, ersätt och ta bort skript‑specifika teckensnittsmappningar i PowerPoint‑teman med Aspose.Slides för PHP via Java."
---
## **Översikt**

Ett presentations‑tema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta möjliggör flerspråkig text som fortfarande använder temats teckensnitt att följa ett enhetligt teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [FontScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/) innehåller en huvud‑teckensnittssamling, vanligtvis använd för rubriker, och en mindre teckensnittssamling, vanligtvis använd för brödtext. Förutom deras latin‑ och östasiatiska teckensnittsinställningar visar båda [Fonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/)‑samlingarna mappningar från skriftsystem‑taggar till teckensnittsfamiljenamn.

Denna artikel visar hur man inspekterar och modifierar dessa mappningar i presentationens master‑tema och verifierar att ändringarna överlever en spara‑och‑ladda‑cykel.

## **Förstå skript‑taggar**

Skript‑teckensnittmetoderna använder fyrbokstavsbeteckningar enligt BCP 47 för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skript‑tagg | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliska |
| `Arab` | Arabiska |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiska |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats teckensnittsschema, inte enskilda textdelar. En presentation kan definiera olika mappningar för huvud‑ och mindre samlingar, och den kan utelämna mappningar för vissa skript.

## **Kom åt och inspektera skript‑teckensnittsmappningar**

Använd [Presentation::getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasterTheme) för att komma åt presentation‑nivåns tema. Metoderna [MasterTheme::getFontScheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/#getMajor) och [FontScheme::getMinor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontscheme/#getMinor) ger åtkomst till de två [Fonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/)‑samlingarna.

Anropa [Fonts::getScriptFontMap](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#getScriptFontMap) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [Fonts::getScriptFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#getScriptFont) med dess skript‑tagg. `Fonts::getScriptFont` returnerar `null` när den samlingen inte definierar den begärda mappningen.

## **Modifiera mappningar och verifiera beständighet**

Använd [Fonts::setScriptFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#setScriptFont) för att skapa en mappning eller ersätta dess nuvarande teckensnittsfamilj. Använd [Fonts::removeScriptFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#removeScriptFont) för att ta bort en mappning.

Det följande end‑to‑end‑exemplet läser alla befintliga huvud‑ och mindre mappningar, slår upp det japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort den lilla Thaana‑mappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplet först en Thaana‑mappning endast när ingen redan är definierad.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Verifieringen använder samma `null`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats returnerar `Fonts::getScriptFont("Thaa")` `null` för den mindre samlingen.

## **Skilj temat‑mappningar från andra teckensnittsinställningar**

Skript‑specifika temamappningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, ersättning och reserv:

| Mekanism | Syfte | Effekt av att ändra en temamappning |
|---|---|---|
| Skript‑specifik temateckensnittsmappning | Väljer ett huvud‑ eller mindre temateckensnitt för ett skriftsystem. | Text som fortfarande använder motsvarande temateckensnitt kan resolve till den nya mappade familjen. |
| Teckensnitt tilldelat explicit till en textdel | Fixerar den begärda teckensnittsfamiljen på den delen istället för att förlita sig på temat. | Delen kan förbli oförändrad eftersom dess direkta formatering åsidosätter temavalet. |
| Teckensnitts­ersättning | Ersätter ett begärt teckensnitt när det teckensnittet saknas eller när en ersättningsregel gäller. | Det sker efter att ett teckensnitt har begärts; det omdefinierar inte temat´s skript‑mappning. |
| Teckensnitt‑reserv | Tillhandahåller tecken som det valda teckensnittet saknar, ofta för specifika Unicode‑områden. | Det fyller i saknad tecken‑täckning; det ändrar inte den lagrade temamappningen. |

För mer information om de två sista mekanismerna, se [Font Substitution](/slides/sv/php-java/font-substitution/) och [Fallback Fonts](/slides/sv/php-java/fallback-font/).

Att ändra en mappning i [Presentation::getMasterTheme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasterTheme) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaarv från en master, layout eller bild, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentation‑nivåns mappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa såsom [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#loadExternalFonts) eller [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Se [Custom Fonts](/slides/sv/php-java/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar endast att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla erforderliga tecken eller ger den avsedda layouten. Rendera representativ text för varje krav­språkt system till en bild eller PDF och inspektera utdata. Detta fångar saknade teckensnitt, ofullständig teckentäckning, reserv‑beteende och layout‑förändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/php-java/convert-powerpoint/) för renderings‑ och exportexempel.

## **FAQ**

**Vad returnerar `Fonts::getScriptFont` när ett skript inte är mappat?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#getScriptFont) returnerar `null` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller mindre teckensnittssamlingen.

**Lägger `Fonts::setScriptFont` till en andra mappning när skriptet redan finns?**

Nej. [Fonts::setScriptFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fonts/#setScriptFont) skapar mappningen när den saknas och ersätter det mappade teckensnittet när samma skripttagg redan finns.

**Varför förändrade en förändring av en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema via ett överskri­vnings­lager, eller påverkas av ersättning eller reserv under rendering. En skript‑mappning på presentationsnivå styr endast text vars effektiva formatering fortfarande hänvisar till den tematiska teckensnittssamlingen.

**Är det tillräckligt att spara och öppna igen för att validera flerspråkig utskrift?**

Nej. Att öppna igen verifierar beständigheten av temadata. Rendera dessutom representativ text från varje krav­språkt system för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller nödvändiga tecken.