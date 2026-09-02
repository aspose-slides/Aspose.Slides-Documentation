---
title: Zarządzanie czcionkami motywu specyficznymi dla skryptu w JavaScript
linktitle: Czcionki motywu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/nodejs-java/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionek motywu
- wielojęzyczna prezentacja
- system pisma
- czcionka cyrylicy
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Przeglądaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficznych dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla Node.js."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to wielojęzyczny tekst, który nadal korzysta z czcionek motywu, zachowując spójną schematykę czcionek przy jednoczesnym użyciu odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych skryptów.

[FontScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontscheme/) motywu zawiera główną kolekcję czcionek, zazwyczaj używaną dla nagłówków, oraz podrzędną kolekcję czcionek, zazwyczaj używaną dla treści. Oprócz ustawień czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma na nazwy rodzin czcionek poprzez klasę [Fonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w motywie głównym prezentacji oraz jak zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów BCP 47, aby identyfikować systemy pisma. Typowe wartości to:

| Tag skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla głównej i podrzędnej kolekcji oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przegląd mapowań czcionek skryptowych**

Użyj [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getmastertheme/), aby uzyskać dostęp do motywu na poziomie prezentacji. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontscheme/) i [FontScheme.getMinor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontscheme/) zwracają dwie kolekcje [Fonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/).

Wywołaj [Fonts.getScriptFontMap](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/), aby pobrać wszystkie mapowania z kolekcji. Aby odszukać konkretny system pisma, wywołaj [Fonts.getScriptFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/) z jego tagiem skryptu. `getScriptFont` zwraca `null`, gdy dana kolekcja nie definiuje żądanego mapowania.

## **Modyfikacja mapowań i weryfikacja trwałości**

Użyj [Fonts.setScriptFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/), aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [Fonts.removeScriptFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/), aby usunąć mapowanie.

Poniższy przykład end‑to‑end odczytuje wszystkie istniejące mapowania główne i podrzędne, odszukuje japońską czcionkę główną, zmienia czcionkę cyrylicy głównej, usuwa mapowanie thaany w kolekcji podrzędnej, zapisuje prezentację i otwiera ją ponownie, aby zweryfikować obie zmiany. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie thaany tylko wtedy, gdy nie jest jeszcze zdefiniowane.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Weryfikacja używa takiego samego zachowania `null` jak zwykłe odszukiwanie: po zapisaniu usunięcia, `getScriptFont("Thaa")` zwraca `null` dla kolekcji podrzędnej.

## **Rozróżnianie mapowań motywu od innych ustawień czcionek**

Mapowania motywu specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, podstawianie i fallback:

| Mechanizm | Cel | Efekt zmiany mapowania motywu |
|---|---|---|
| Mapowanie czcionki motywu specyficzne dla skryptu | Wybiera główną lub podrzędną czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać rozwiązany do nowej rodziny czcionek. |
| Czcionka przypisana wyraźnie do fragmentu tekstu | Ustala żądaną rodzinę czcionek na tym fragmencie zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Podstawianie czcionek | Zastępuje żądaną czcionkę, gdy nie jest dostępna lub gdy obowiązuje reguła podstawiania. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Fallback czcionek | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania motywu. |

Po więcej informacji o dwóch ostatnich mechanizmach zobacz [Font Substitution](/slides/pl/nodejs-java/font-substitution/) oraz [Fallback Fonts](/slides/pl/nodejs-java/fallback-font/).

Zmiana mapowania w [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getmastertheme/) wpływa tylko na zawartość, której efektywne formatowanie nadal zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu albo używać wyraźnie przypisanej czcionki. Przeglądaj te poziomy, gdy widoczny efekt nie odpowiada mapowaniu na poziomie prezentacji.

## **Udostępnianie mapowanych czcionek i walidacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionek; nie instaluje ani nie ładuje odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides poprzez niestandardowe źródło, takie jak [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) lub [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/). Zobacz [Custom Fonts](/slides/pl/nodejs-java/custom-font/) po dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi, że czcionka jest dostępna, zawiera wszystkie wymagane glify ani że generuje zamierzony układ. Wygeneruj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i przeanalizuj wynik. Dzięki temu wykryjesz brakujące czcionki, niepełne pokrycie glifów, zachowanie fallbacku oraz zmiany układu przed dystrybucją prezentacji. Zobacz [Convert PowerPoint Presentations](/slides/pl/nodejs-java/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `getScriptFont`, gdy skrypt nie jest mapowany?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/) zwraca `null`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub podrzędnej kolekcji czcionek.

**Czy `setScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. [Fonts.setScriptFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fonts/) tworzy mapowanie, gdy go brakuje, i zastępuje istniejącą rodzinę czcionek, gdy ten sam tag skryptu jest już obecny.

**Dlaczego zmiana mapowania motywu nie zmieniła niektórego tekstu?**

Tekst może mieć wyraźnie przypisaną czcionkę, dziedziczyć inny motyw przez nadpisanie lub być poddany podstawianiu lub fallbackowi podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie wciąż odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą do walidacji wielojęzycznego wyjścia?**

Nie. Ponowne otwarcie weryfikuje trwałość danych motywu. Dodatkowo należy wyrenderować reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić dostępność mapowanych czcionek i ich pełne pokrycie glifów.