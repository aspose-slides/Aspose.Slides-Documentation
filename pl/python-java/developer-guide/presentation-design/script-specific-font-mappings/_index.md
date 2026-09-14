---
title: Zarządzanie czcionkami motywu specyficznymi dla skryptu w Pythonie za pośrednictwem Javy
linktitle: Czcionki motywu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/python-java/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki motywu
- prezentacja wielojęzyczna
- system pisma
- czcionka cyrylica
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Sprawdzaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficznych dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla Pythona za pośrednictwem Javy."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to wielojęzyczny tekst, który nadal korzysta z czcionek motywu, aby zachować spójną schemat czcionek, używając jednocześnie odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaana i innych pism.

Motyw zawiera [FontScheme](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontscheme/), który posiada główną kolekcję czcionek, zazwyczaj używaną dla nagłówków, oraz drugorzędną kolekcję czcionek, zazwyczaj używaną dla tekstu głównego. Oprócz ustawień czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania od znaczników systemu pisma do nazw rodzin czcionek poprzez klasę [Fonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w głównym motywie prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie znaczników skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów skryptu BCP 47 do identyfikacji systemów pisma. Typowe wartości obejmują:

| Script tag | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla głównej i drugorzędnej kolekcji oraz może pomijać mapowania dla niektórych skryptów.

## **Uzyskiwanie dostępu i przeglądanie mapowań czcionek skryptowych**

Użyj [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasterTheme), aby uzyskać dostęp do motywu na poziomie prezentacji. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontscheme/#getMajor) i [FontScheme.getMinor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontscheme/#getMinor) zwracają dwie kolekcje [Fonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/).

Wywołaj [Fonts.getScriptFontMap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#getScriptFontMap), aby pobrać wszystkie mapowania z kolekcji. Aby wyszukać jeden system pisma, wywołaj [Fonts.getScriptFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#getScriptFont) z jego znacznikiem skryptu. `getScriptFont` zwraca `None`, gdy ta kolekcja nie definiuje żądanego mapowania.

## **Modyfikowanie mapowań i weryfikacja trwałości**

Użyj [Fonts.setScriptFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#setScriptFont), aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [Fonts.removeScriptFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#removeScriptFont), aby usunąć mapowanie.

Poniższy kompletny przykład odczytuje wszystkie istniejące mapowania główne i drugorzędne, wyszukuje główną czcionkę japońską, zmienia główną czcionkę cyrylicy, usuwa mapowanie Thaana w drugorzędnej kolekcji, zapisuje prezentację i ponownie ją otwiera, aby zweryfikować oba zmiany. Aby krok usunięcia był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie Thaana tylko wtedy, gdy nie jest już zdefiniowane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Weryfikacja używa takiego samego zachowania `None` jak zwykłe wyszukiwanie: po zapisaniu usunięcia, `getScriptFont("Thaa")` zwraca `None` dla drugorzędnej kolekcji.

## **Rozróżnienie mapowań motywu od innych ustawień czcionek**

Mapowanie czcionki motywu specyficzne dla skryptu uczestniczy w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, substytucja i awaryjne ładowanie:

| Mechanizm | Cel | Efekt zmiany mapowania motywu |
|---|---|---|
| Mapowanie czcionki motywu specyficzne dla skryptu | Wybiera główną lub drugorzędną czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać przypisany do nowej zmapowanej rodziny. |
| Czcionka przypisana wyraźnie do fragmentu tekstu | Utrwala żądaną rodzinę czcionek w tym fragmencie zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Substytucja czcionki | Zastępuje żądaną czcionkę, gdy nie jest dostępna lub gdy obowiązuje reguła substytucji. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Zapasowa czcionka | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia przechowywanego mapowania motywu. |

Więcej informacji o dwóch ostatnich mechanizmach można znaleźć w [Substytucja czcionek](/slides/pl/python-java/font-substitution/) i [Czcionki zapasowe](/slides/pl/python-java/fallback-font/).

Zmiana mapowania w [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasterTheme) wpływa tylko na treść, której efektywne formatowanie nadal zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, lub używać jawnie przypisanej czcionki. Sprawdź te poziomy, gdy widoczny rezultat nie podąża za mapowaniem na poziomie prezentacji.

## **Umożliwienie dostępu do zmapowanych czcionek i weryfikacja rezultatu**

Mapowanie skryptu przechowuje nazwę rodziny czcionek; nie instalują i nie ładują odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda zmapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides za pośrednictwem źródła niestandardowego, takiego jak [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFonts) lub [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Zobacz [Niestandardowe czcionki](/slides/pl/python-java/custom-font/) po dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify lub generuje zamierzony układ. Renderuj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. Dzięki temu wykryjesz brakujące czcionki, niepełne pokrycie glifów, zachowanie awaryjnego ładowania oraz zmiany układu przed udostępnieniem prezentacji. Zobacz [Konwertowanie prezentacji PowerPoint](/slides/pl/python-java/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `getScriptFont`, gdy skrypt nie jest zmapowany?**

`[Fonts.getScriptFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#getScriptFont)` zwraca `None`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub drugorzędnej kolekcji czcionek.

**Czy `setScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. `[Fonts.setScriptFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fonts/#setScriptFont)` tworzy mapowanie, gdy brakuje, i zastępuje zmapowaną rodzinę czcionek, gdy znacznik skryptu już istnieje.

**Dlaczego zmiana mapowania motywu nie spowodowała zmiany niektórego tekstu?**

Tekst może mieć jawnie przypisaną czcionkę, dziedziczyć inny motyw poprzez nadpisanie lub być pod wpływem substytucji lub awaryjnego ładowania podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą do weryfikacji wielojęzycznego wyniku?**

Nie. Ponowne otwarcie weryfikuje trwałość danych motywu. Należy również renderować reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić, że zmapowane czcionki są dostępne i zawierają niezbędne glify.