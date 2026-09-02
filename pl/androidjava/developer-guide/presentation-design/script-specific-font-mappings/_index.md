---
title: Zarządzanie czcionkami tematycznymi specyficznymi dla skryptu na Androidzie
linktitle: Czcionki tematyczne specyficzne dla skryptu
type: docs
weight: 15
url: /pl/androidjava/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki tematu
- wielojęzykowa prezentacja
- system pisma
- czcionka cyryliczna
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Sprawdzaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficznych dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Motyw prezentacji może wybrać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to wielojęzykowy tekst, który nadal korzysta z czcionek motywu, aby stosować spójną schemat czcionek, używając jednocześnie odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaana i innych pism.

Motyw zawiera interfejs [IFontScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/), który posiada kolekcję czcionek głównych, zazwyczaj używaną do nagłówków, oraz kolekcję czcionek pomocniczych, zazwyczaj używaną w treści. Oprócz ustawień czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma do nazw rodzin czcionek za pośrednictwem interfejsu [IFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w głównym motywie prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów skryptów BCP 47 do identyfikacji systemów pisma. Typowe wartości obejmują:

| Tag skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla kolekcji głównych i pomocniczych oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przeglądanie mapowań czcionek skryptowych**

Użyj [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getMasterTheme--) aby uzyskać dostęp do motywu na poziomie prezentacji. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/#getMajor--) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/#getMinor--) zwracają dwie kolekcje [IFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifonts/).

Wywołaj [IFonts.getScriptFontMap](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) aby pobrać wszystkie mapowania z kolekcji. Aby wyszukać jeden system pisma, wywołaj [IFonts.getScriptFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) z odpowiednim tagiem skryptu. `getScriptFont` zwraca `null`, gdy ta kolekcja nie definiuje żądanego mapowania.

## **Modyfikowanie mapowań i weryfikacja trwałości**

Użyj [IFonts.setScriptFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) aby utworzyć mapowanie lub zastąpić obecną rodzinę czcionek. Użyj [IFonts.removeScriptFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) aby usunąć mapowanie.

Poniższy kompleksowy przykład odczytuje wszystkie istniejące mapowania główne i pomocnicze, wyszukuje czcionkę japońską (główną), zmienia czcionkę cyrylicy (główną), usuwa mapowanie Thaana (pomocnicze), zapisuje prezentację i otwiera ją ponownie w celu weryfikacji obu zmian. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie Thaana tylko wtedy, gdy nie jest jeszcze zdefiniowane.

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

Weryfikacja wykorzystuje takie samo zachowanie `null` jak zwykłe wyszukiwanie: po zapisaniu usunięcia, `getScriptFont("Thaa")` zwraca `null` dla kolekcji pomocniczej.

## **Rozróżnienie mapowań motywu od innych ustawień czcionek**

Mapowania motywu specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, podmiana i awaryjne użycie czcionki:

| Mechanizm | Cel | Skutek zmiany mapowania w motywie |
|---|---|---|
| Mapowanie czcionki motywu specyficzne dla skryptu | Wybiera główną lub pomocniczą czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może rozwiązać się do nowej przypisanej rodziny. |
| Czcionka przypisana bezpośrednio do fragmentu tekstu | Ustalona rodzina czcionki dla tego fragmentu zamiast polegania na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Podstawianie czcionki | Zastępuje żądaną czcionkę, gdy jest ona niedostępna lub gdy obowiązuje reguła podstawiania. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Awaryjne użycie czcionki | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania w motywie. |

Po więcej informacji o dwóch ostatnich mechanizmach zobacz [Podstawianie czcionek](/slides/pl/androidjava/font-substitution/) oraz [Czcionki awaryjne](/slides/pl/androidjava/fallback-font/).

Zmiana mapowania w [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getMasterTheme--) wpływa tylko na treść, której efektywne formatowanie wciąż zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, lub używać explicite przypisanej czcionki. Sprawdź te poziomy, gdy widoczny wynik nie odpowiada mapowaniu na poziomie prezentacji.

## **Udostępnienie mapowanych czcionek i walidacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionki; nie instaluję ani nie ładuje odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides za pośrednictwem własnego źródła, takiego jak [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lub [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Zobacz [Niestandardowe czcionki](/slides/pl/androidjava/custom-font/) po dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify lub zapewnia zamierzone rozmieszczenie. Wyrenderuj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. Dzięki temu wykryjesz brakujące czcionki, niepełne pokrycie glifów, zachowanie awaryjne i zmiany układu przed udostępnieniem prezentacji. Zobacz [Konwertowanie prezentacji PowerPoint](/slides/pl/androidjava/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `getScriptFont`, gdy skrypt nie jest mapowany?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) zwraca `null`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub pomocniczej kolekcji czcionek.

**Czy `setScriptFont` dodaje drugi mapping, gdy skrypt już istnieje?**

Nie. [IFonts.setScriptFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) tworzy mapowanie, gdy jest brakujące, i zastępuje mapowaną rodzinę czcionek, gdy ten sam tag skryptu już istnieje.

**Dlaczego zmiana mapowania w motywie nie zmieniła niektórego tekstu?**

Tekst może mieć explicite przypisaną czcionkę, dziedziczyć inny motyw przez nadpisanie lub być wpływany przez podmianę lub awaryjne użycie podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą, aby zweryfikować wielojęzykowy wynik?**

Nie. Ponowne otwarcie weryfikuje trwałość danych motywu. Dodatkowo wyrenderuj reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić, że mapowane czcionki są dostępne i zawierają niezbędne glify.