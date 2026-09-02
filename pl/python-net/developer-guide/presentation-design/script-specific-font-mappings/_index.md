---
title: Zarządzanie czcionkami tematu specyficznymi dla skryptu w Pythonie
linktitle: Czcionki tematu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/python-net/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki tematu
- prezentacja wielojęzyczna
- system pisma
- czcionka cyrylicy
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Sprawdzaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficzne dla skryptu w tematach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to tekstom wielojęzycznym, które nadal używają czcionek motywu, korzystanie ze spójnego schematu czcionek przy jednoczesnym zastosowaniu odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych skryptów.

Motyw zawiera [FontScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/), w którym znajduje się główna kolekcja czcionek, zwykle używana w nagłówkach, oraz pomocnicza kolekcja czcionek, zazwyczaj stosowana w treści. Oprócz właściwości czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma na nazwy rodzin czcionek za pośrednictwem klasy [Fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/).

Ten artykuł pokazuje, jak sprawdzić i zmodyfikować te mapowania w motywie nadrzędnym prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych podtagów BCP 47, aby identyfikować systemy pisma. Typowe wartości to:

| Script tag | Writing system |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania dotyczą schematu czcionek motywu, a nie poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla kolekcji głównej i pomocniczej oraz może pomijać mapowania niektórych skryptów.

## **Dostęp i przegląd mapowania czcionek skryptów**

Użyj [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/), aby uzyskać dostęp do motywu na poziomie prezentacji. Właściwości [FontScheme.major](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/major/) i [FontScheme.minor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/minor/) zwracają dwie kolekcje [Fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/).

Wywołaj [Fonts.get_script_font_map](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/get_script_font_map/), aby pobrać wszystkie mapowania z kolekcji. Aby odszukać konkretny system pisma, wywołaj [Fonts.get_script_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/get_script_font/) z jego tagiem skryptu. `get_script_font` zwraca `None`, gdy dana kolekcja nie definiuje żądanego mapowania.

## **Modyfikowanie mapowań i weryfikacja trwałości**

Użyj [Fonts.set_script_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/set_script_font/), aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [Fonts.remove_script_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/remove_script_font/), aby usunąć mapowanie.

Poniższy przykład end‑to‑end odczytuje wszystkie istniejące mapowania główne i pomocnicze, wyszukuje główną czcionkę japońską, zmienia główną czcionkę cyrylicy, usuwa mapowanie thaany w kolekcji pomocniczej, zapisuje prezentację i ponownie ją otwiera, aby zweryfikować oba zmiany. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie thaany tylko wtedy, gdy nie jest jeszcze zdefiniowane.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Weryfikacja korzysta z takiego samego zachowania `None` jak zwykłe wyszukiwanie: po zapisaniu usunięcia `get_script_font("Thaa")` zwraca `None` dla kolekcji pomocniczej.

## **Rozróżnienie mapowań motywu od innych ustawień czcionek**

Mapowanie czcionki motywu specyficzne dla skryptu uczestniczy w wyborze czcionki, ale rozwiązuje inny problem niż bezpośrednie formatowanie tekstu, podmiana i zapasowa czcionka:

| Mechanizm | Cel | Skutek zmiany mapowania motywu |
|---|---|---|
| Script-specific theme font mapping | Wybiera główną lub pomocniczą czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać przypisany do nowej rodziny czcionek. |
| Font assigned explicitly to a text portion | Ustawia wymaganą rodzinę czcionek dla tego fragmentu, zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Font substitution | Zastępuje żądaną czcionkę, gdy jest niedostępna lub gdy obowiązuje reguła podmiany. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Font fallback | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania motywu. |

Po więcej informacji o ostatnich dwóch mechanizmach zobacz [Font Substitution](/slides/pl/python-net/font-substitution/) oraz [Fallback Fonts](/slides/pl/python-net/fallback-font/).

Zmiana mapowania w [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/) wpływa tylko na zawartość, której efektywne formatowanie nadal zależy od tego motywu. Tekst może dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, albo używać explicite przypisanej czcionki. Sprawdź te poziomy, gdy widoczny rezultat nie odpowiada mapowaniu na poziomie prezentacji.

## **Udostępnienie mapowanych czcionek i weryfikacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionek; nie instaluję ani nie ładuję odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides poprzez niestandardowe źródło, takie jak [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/load_external_fonts/) lub [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/document_level_font_sources/). Zobacz [Custom Fonts](/slides/pl/python-net/custom-font/) w celu poznania dostępnych opcji ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify ani że generuje zamierzony układ. Wygeneruj reprezentatywny tekst dla każdego wymaganego systemu pisma jako obraz lub PDF i sprawdź wynik. To wykryje brakujące czcionki, niepełne pokrycie glifów, zachowanie zapasowe oraz zmiany układu przed dystrybucją prezentacji. Zobacz [Convert PowerPoint Presentations](/slides/pl/python-net/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `get_script_font`, gdy skrypt nie jest mapowany?**

[Fonts.get_script_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/get_script_font/) zwraca `None`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub pomocniczej kolekcji czcionek.

**Czy `set_script_font` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. [Fonts.set_script_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fonts/set_script_font/) tworzy mapowanie, gdy go brakuje, i zastępuje istniejącą rodzinę czcionek, gdy dany tag skryptu jest już obecny.

**Dlaczego zmiana mapowania motywu nie zmieniła niektórych tekstów?**

Tekst może mieć explicite przypisaną czcionkę, dziedziczyć inny motyw poprzez nadpisanie lub być poddany podmianie albo zapasowi podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą do walidacji wielojęzycznego wyjścia?**

Nie. Ponowne otwarcie weryfikuje jedynie trwałość danych motywu. Należy także renderować reprezentatywny tekst dla każdego wymaganego systemu pisma, aby potwierdzić dostępność mapowanych czcionek i obecność niezbędnych glifów.