---
title: Zarządzanie czcionkami motywu specyficznymi dla skryptu w Javie
linktitle: Czcionki motywu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/java/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki motywu
- wielojęzyczna prezentacja
- system pisma
- czcionka cyrylicy
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thanaa
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficznych dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to tekst wielojęzyczny, który nadal korzysta z czcionek motywu, aby stosować spójną schemat czcionek przy użyciu odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych pism.

Motyw [IFontScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/) zawiera główną kolekcję czcionek, zwykle używaną dla nagłówków, oraz pomocniczą kolekcję czcionek, zwykle używaną dla tekstu podstawowego. Oprócz ustawień czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma na nazwy rodzin czcionek poprzez interfejs [IFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w głównym motywie prezentacji oraz sprawdzić, czy zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów skryptu BCP 47 do identyfikacji systemów pisma. Typowe wartości obejmują:

| Tag skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla głównej i pomocniczej kolekcji oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przeglądanie mapowań czcionek skryptowych**

Użyj [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasterTheme--) aby uzyskać dostęp do motywu na poziomie prezentacji. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/#getMajor--) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/#getMinor--) zwracają dwie kolekcje [IFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifonts/).

Wywołaj [IFonts.getScriptFontMap](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#getScriptFontMap--) aby pobrać wszystkie mapowania z kolekcji. Aby odszukać konkretny system pisma, wywołaj [IFonts.getScriptFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) z odpowiednim tagiem skryptu. `getScriptFont` zwraca `null`, gdy ta kolekcja nie definiuje żądanego mapowania.

## **Modyfikowanie mapowań i weryfikacja trwałości**

Użyj [IFonts.setScriptFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [IFonts.removeScriptFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) aby usunąć mapowanie.

Poniższy przykład end-to-end odczytuje wszystkie istniejące mapowania główne i pomocnicze, wyszukuje główną czcionkę japońską, zmienia główną czcionkę cyrylicy, usuwa pomocnicze mapowanie Thaana, zapisuje prezentację i ponownie ją otwiera, aby zweryfikować oba zmiany. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie Thaana tylko wtedy, gdy nie jest jeszcze zdefiniowane.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Weryfikacja używa takiego samego zachowania `null` jak zwykłe odszukiwanie: po zapisaniu usunięcia, `getScriptFont("Thaa")` zwraca `null` dla pomocniczej kolekcji.

## **Rozróżnienie mapowań motywu od innych ustawień czcionek**

Mapowania motywu specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, podstawianie i awaryjne czcionki:

| Mechanizm | Cel | Skutek zmiany mapowania motywu |
|---|---|---|
| Mapowanie czcionki motywu specyficzne dla skryptu | Wybiera główną lub pomocniczą czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać przemapowany na nową rodzinę. |
| Czcionka przypisana jawnie do fragmentu tekstu | Ustawia żądaną rodzinę czcionek w tym fragmencie zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Podstawianie czcionek | Zastępuje żądaną czcionkę, gdy nie jest dostępna lub gdy obowiązuje reguła podstawiania. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Awaryjne czcionki | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania motywu. |

Więcej informacji o dwóch ostatnich mechanizmach znajdziesz w [Podstawianie czcionek](/slides/pl/java/font-substitution/) i [Czcionki awaryjne](/slides/pl/java/fallback-font/).

Zmiana mapowania w [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasterTheme--) wpływa tylko na zawartość, której efektywne formatowanie nadal zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, lub używać jawnie przypisanej czcionki. Sprawdź te poziomy, gdy widoczny wynik nie odzwierciedla mapowania na poziomie prezentacji.

## **Udostępnienie mapowanych czcionek i weryfikacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionki; nie instaluję ani nie ładuje odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides poprzez niestandardowe źródło, takie jak [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lub [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Zobacz [Niestandardowe czcionki](/slides/pl/java/custom-font/) w celu zapoznania się z dostępnymi opcjami ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify lub generuje zamierzony układ. Wygeneruj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. Dzięki temu wykryjesz brakujące czcionki, niekompletny zakres glifów, zachowanie awaryjne oraz zmiany układu przed dystrybucją prezentacji. Zobacz [Konwertowanie prezentacji PowerPoint](/slides/pl/java/convert-powerpoint/) w celu przykładów renderowania i eksportu.

## **FAQ**

**Co zwraca `getScriptFont`, gdy skrypt nie jest mapowany?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) zwraca `null`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub pomocniczej kolekcji czcionek.

**Czy `setScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. [IFonts.setScriptFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) tworzy mapowanie, gdy brakuje, i zastępuje istniejącą rodzinę czcionek, gdy ten sam tag skryptu już istnieje.

**Dlaczego zmiana mapowania motywu nie zmieniła niektórego tekstu?**

Tekst może mieć jawnie przypisaną czcionkę, dziedziczyć inny motyw poprzez nadpisanie lub być wpływany przez podstawianie lub awaryjne czcionki podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą do weryfikacji wielojęzycznego wyjścia?**

Nie. Ponowne otwarcie weryfikuje trwałość danych motywu. Dodatkowo należy wygenerować reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić, że mapowane czcionki są dostępne i zawierają niezbędne glify.