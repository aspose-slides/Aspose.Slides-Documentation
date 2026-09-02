---
title: Zarządzanie czcionkami motywu specyficznymi dla skryptu w PHP
linktitle: Czcionki motywu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/php-java/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki motywu
- prezentacja wielojęzyczna
- system pisma
- czcionka cyrylicy
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Przeglądaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficzne dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Dzięki temu tekst wielojęzyczny, który nadal korzysta z czcionek motywu, może podążać za jedną spójną schematyką czcionek, używając jednocześnie odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych pism.

[FontScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/) motywu zawiera główną kolekcję czcionek, zwykle używaną w nagłówkach, oraz drugorzędną kolekcję czcionek, zwykle używaną w treści. Oprócz ustawień czcionek łacińskich i wschodnioazjatyckich, obie kolekcje [Fonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/) udostępniają mapowania z tagów systemów pisma na nazwy rodzin czcionek.

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w motywie głównym prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapis‑odczyt.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów BCP 47, aby zidentyfikować systemy pisma. Typowe wartości to:

| Tag skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla głównych i drugorzędnych kolekcji oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przeglądanie mapowań czcionek skryptowych**

Użyj [Presentation::getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasterTheme), aby uzyskać dostęp do motywu na poziomie prezentacji. Metody [MasterTheme::getFontScheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/#getMajor) i [FontScheme::getMinor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontscheme/#getMinor) zapewniają dostęp do dwóch kolekcji [Fonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/).

Wywołaj [Fonts::getScriptFontMap](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#getScriptFontMap), aby pobrać wszystkie mapowania z kolekcji. Aby odszukać konkretny system pisma, wywołaj [Fonts::getScriptFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#getScriptFont) z jego tagiem skryptu. `Fonts::getScriptFont` zwraca `null`, gdy dana kolekcja nie definiuje żądanego mapowania.

## **Modyfikacja mapowań i weryfikacja trwałości**

Użyj [Fonts::setScriptFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#setScriptFont), aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [Fonts::removeScriptFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#removeScriptFont), aby usunąć mapowanie.

Poniższy przykład end‑to‑end odczytuje wszystkie istniejące mapowania główne i drugorzędne, odszukuje japońską czcionkę główną, zmienia czcionkę cyrylicy głównej, usuwa mapowanie thaany drugorzędnej, zapisuje prezentację i ponownie ją otwiera, aby zweryfikować obie zmiany. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie thaany tylko wtedy, gdy nie jest jeszcze zdefiniowane.

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

Weryfikacja używa tego samego zachowania `null` co zwykłe odszukiwanie: po zapisaniu usunięcia `Fonts::getScriptFont("Thaa")` zwraca `null` dla kolekcji drugorzędnej.

## **Rozróżnianie mapowań motywu od innych ustawień czcionek**

Mapowania tematyczne specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, podstawianie i fallback:

| Mechanizm | Cel | Skutek zmiany mapowania motywu |
|---|---|---|
| Mapowanie czcionki tematycznej specyficzne dla skryptu | Wybiera główną lub drugorzędną czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać przemapowany na nową rodzinę. |
| Czcionka przypisana explicite do fragmentu tekstu | Ustala żądaną rodzinę czcionek w tym fragmencie zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego formatowanie bezpośrednie nadpisuje wybór motywu. |
| Podstawianie czcionek | Zastępuje żądaną czcionkę, gdy nie jest dostępna lub gdy obowiązuje reguła podstawiania. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptowego w motywie. |
| Fallback czcionek | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania motywu. |

Więcej informacji o dwóch ostatnich mechanizmach znajdziesz w [Font Substitution](/slides/pl/php-java/font-substitution/) i [Fallback Fonts](/slides/pl/php-java/fallback-font/).

Zmiana mapowania w [Presentation::getMasterTheme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasterTheme) wpływa wyłącznie na zawartość, której skuteczne formatowanie nadal zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, albo używać explicite przypisanej czcionki. Przeglądaj te poziomy, gdy widoczny efekt nie odzwierciedla mapowania na poziomie prezentacji.

## **Udostępnianie mapowanych czcionek i walidacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionek; nie instaluje ani nie ładuje odpowiadającego pliku czcionki. Dla spójnego renderowania i eksportu każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides poprzez niestandardowe źródło, takie jak [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/#loadExternalFonts) lub [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Zobacz [Custom Fonts](/slides/pl/php-java/custom-font/) po dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify ani że generuje zamierzony układ. Renderuj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. Dzięki temu wykryjesz brakujące czcionki, niepełne pokrycie glifów, zachowanie fallbacku oraz zmiany układu przed rozpowszechnieniem prezentacji. Zobacz [Convert PowerPoint Presentations](/slides/pl/php-java/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `Fonts::getScriptFont`, gdy skrypt nie jest zmapowany?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#getScriptFont) zwraca `null`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub drugorzędnej kolekcji czcionek.

**Czy `Fonts::setScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. [Fonts::setScriptFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fonts/#setScriptFont) tworzy mapowanie, gdy go brakuje, i zastępuje istniejącą rodzinę czcionek, gdy ten sam tag skryptu jest już obecny.

**Dlaczego zmiana mapowania motywu nie zmieniła niektórego tekstu?**

Tekst może mieć explicite przypisaną czcionkę, dziedziczyć inny motyw poprzez nadpisanie lub być poddany podstawianiu lub fallbackowi podczas renderowania. Mapowanie skryptowe na poziomie prezentacji kontroluje wyłącznie tekst, którego skuteczne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą, aby zweryfikować wielojęzyczny wynik?**

Nie. Ponowne otwarcie weryfikuje jedynie trwałość danych motywu. Dodatkowo renderuj reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić dostępność mapowanych czcionek oraz ich pełne pokrycie glifów.