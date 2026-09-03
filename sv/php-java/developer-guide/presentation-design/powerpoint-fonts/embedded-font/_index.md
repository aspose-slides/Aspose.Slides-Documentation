---
title: Bädda in teckensnitt i presentationer med PHP
linktitle: Inbäddade teckensnitt
type: docs
weight: 40
url: /sv/php-java/embedded-font/
keywords:
- lägga till teckensnitt
- bädda in teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för PHP via Java. Lägg till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddade teckensnitt lagrar teckensnittsdata i en PowerPoint-presentation. När en visare stöder inbäddade teckensnitt kan den visa text med dessa teckensnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för PHP via Java låter dig hämta, lägga till och ta bort inbäddade teckensnitt via klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/) som returneras av [Presentation::getFontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getFontsManager). Du kan också minska storleken på inbäddade teckensnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX-filer. Innan du bäddar in ett teckensnitt, säkerställ att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) för att lista teckensnitten som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/php-java/font-substitution/), vilket kan påverka layouten.

## **Inspektera teckensnittsdata och inbäddningsbehörigheter**

Använd klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/) för att inspektera teckensnitt innan de bäddas in. Anropa [FontsManager::getFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getFonts) för att hämta teckensnitten som används i presentationen. För varje teckensnitt, skicka ett [FontData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontdata/)-objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontstyletype/)-värdet till [FontsManager::getFontBytes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getFontBytes). Metoden returnerar de binära data för den teckensnittsstilen, eller `null` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `null`‑resultat till [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar de inbäddningsrestriktioner som lagras i teckensnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att teckensnittets licens tillåter det.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från teckensnittets juridiska ägare när den är det enda användarbehörighetsflagget.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och möjliggör att dokumentet kan redigeras och sparas.
- `NoSubsetting` är en extra restriktion som förbjuder att bara en delmängd av teckenbitarna bäddas in. Bädda in alla tecken när detta flagga är närvarande.
- `BitmapOnly` är en extra restriktion som endast tillåter inbäddning av bitmap‑slag, inte konturdata. Om teckensnittet saknar bitmap‑slag kan det inte bäddas in.

De första fyra värdena beskriver användarbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, maskera användarbehörighetsbitarna och jämför resultatet med `Installable` istället för att kontrollera det som ett flagga. Nuvarande teckensnitt bör sätta högst en användarbehörighetsbit. För kompatibilitet med äldre teckensnitt som sätter mer än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fetstil, kursiv och fet‑kursiv‑data som är tillgängliga för varje teckensnitt som returneras av `FontsManager::getFonts`. Det hoppar över otillgängliga stilar, begränsade teckensnitt, endast‑bitmap‑teckensnitt, teckensnitt som är begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, samt teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddas alla tecken för den teckensnittsfamiljen in.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Denna inspektion rapporterar de restriktioner som kodas i varje teckensnittfil. Den beviljar inte en licens, bevisar att du har skaffat teckensnittet lagligt, eller ersätter kontrollen av teckensnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade teckensnitt**

Använd [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) för att bädda in ett teckensnitt. Dess överlagringar accepterar antingen ett [FontData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontdata/)-objekt eller en byte‑array som innehåller teckensnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedfontcharacters/) bäddar in alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och ange ny text.
- [OnlyUsed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedfontcharacters/) bäddar bara in de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som främst är avsedd för visning.

Följande exempel använder [FontsManager::getFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getFonts) för att hämta teckensnitten som används i `Fonts.pptx` och bäddar in de som ännu inte är inbäddade. Teckensnitten som ska läggas till måste vara tillgängliga på maskinen som kör koden. Befintliga inbäddade teckensnitt behåller sina nuvarande teckenuppsättningar.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Komprimera inbäddade teckensnitt**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#compressEmbeddedFonts) minskar inbäddade teckensnittsdata genom att ta bort oanvända tecken. Den fungerar på teckensnitt som redan är inbäddade, så storleksminskningen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Behåll originalfilen om mottagare kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen bäddade in alla tecken.

## **Vanliga frågor**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas under rendering?**

Anropa [FontsManager::getSubstitutions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getSubstitutions) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera också [font substitution](/slides/sv/php-java/font-substitution/)‑inställningarna och [font fallback](/slides/sv/php-java/fallback-font/)‑reglerna. Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som teckensnittet självt saknar.

**Bör jag bädda in vanliga teckensnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de erforderliga teckensnitten är tillgängliga på varje maskin som öppnar eller renderar presentationen kan inbäddning av dem innebära onödig filstorlek. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.