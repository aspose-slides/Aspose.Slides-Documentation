---
title: Osadzanie czcionek w prezentacjach przy użyciu PHP
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/php-java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides dla PHP via Java. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w systemie docelowym. Pomaga to zachować podziały wierszy, odstępy między tekstem i układ slajdów.

Aspose.Slides for PHP via Java umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem klasy [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/) zwracanej przez [Presentation::getFontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getFontsManager). Możesz również zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane czcionki są dostępne dla Aspose.Slides i że jej licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts), aby wyświetlić listę czcionek zapisanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), a następnie zapisz prezentację.

Poniższy przykład wyświetla osadzone czcionki w pliku `EmbeddedFonts.pptx` i usuwa czcionkę Calibri, jeśli jest obecna:
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

Usunięcie osadzonej czcionki usuwa jej zapisane dane czcionki; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w systemie docelowym, tekst może nadal jej używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/php-java/font-substitution/), co może wpłynąć na układ.

## **Inspekcja danych czcionki i uprawnień do osadzania**

Użyj klasy [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/) , aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [FontsManager::getFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getFonts), aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [FontData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontstyletype/) do [FontsManager::getFontBytes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getFontBytes). Metoda zwraca dane binarne dla tego stylu czcionki lub `null`, gdy żądana czcionka lub styl jest niedostępny. Nie przekazuj wyniku `null` do [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), ponieważ ta metoda wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embeddinglevel/) jest wyliczeniem flag, które raportuje ograniczenia osadzania zapisane w czcionce:
- `Installable` zezwala na osadzanie i trwałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano zezwolenie od prawnego właściciela czcionki, gdy jest jedyną flagą uprawnienia do użycia.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie oraz pozwala na edycję i zapis dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem, które zabrania osadzania jedynie podzbioru glifów. Gdy ta flaga jest obecna, osadz wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które zezwala na osadzenie tylko bitmapowych wersji czcionki, a nie danych wektorowych. Jeśli czcionka nie posiada bitmapowych wersji, nie może być osadzona.

Pierwsze cztery wartości opisują uprawnienia do użycia, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `Installable` ma wartość zero, maskuj bity uprawnień do użycia i porównuj wynik z `Installable` zamiast sprawdzać go jako flagę. Aktualne czcionki powinny ustawiać maksymalnie jeden bit uprawnień do użycia. Dla kompatybilności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocnik wybiera najmniej restrykcyjne uprawnienie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład audytuje dane regular, pogrubione, kursywa i pogrubiona‑kursywa dostępne dla każdej czcionki zwróconej przez `FontsManager::getFonts`. Pomija niedostępne style, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i druku, ponieważ wynik pozostaje edytowalny, oraz czcionki, które są już osadzone. Jeśli jakikolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.
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

Ta inspekcja raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że uzyskałeś czcionkę legalnie, ani nie zastępuje sprawdzenia umowy licencyjnej czcionki przed rozpowszechnianiem osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), aby osadzić czcionkę. Jej przeciążenia przyjmują albo obiekt [FontData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontdata/) , albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedfontcharacters/) kontroluje, które znaki zostaną uwzględnione:
- [All](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji, przeznaczonej głównie do oglądania.

Poniższy przykład używa [FontsManager::getFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getFonts), aby pobrać czcionki użyte w pliku `Fonts.pptx` i osadzi te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.
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

## **Kompresja osadzonych czcionek**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#compressEmbeddedFonts) zmniejsza dane osadzonych czcionek poprzez usunięcie nieużywanych znaków. Działa na czcionkach już osadzonych, więc stopień redukcji rozmiaru zależy od tego, ile nieużywanych danych czcionki zawiera prezentacja.

Poniższy przykład kompresuje czcionki w pliku `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:
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

Zachowaj oryginalny plik, jeśli odbiorcy mogą później potrzebować dodać tekst. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli początkowo osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka będzie nadal zastępowana podczas renderowania?**

Wywołaj [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getSubstitutions) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zamieni. Sprawdź także ustawienia [font substitution](/slides/pl/php-java/font-substitution/) oraz zasady [font fallback](/slides/pl/php-java/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których sama czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję należy podjąć w oparciu o środowisko docelowe. Jeśli wymagane czcionki są dostępne na każdym komputerze, który otwiera lub renderuje prezentację, ich osadzanie może zwiększyć niepotrzebnie rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, o ile licencje na nie to pozwalają.