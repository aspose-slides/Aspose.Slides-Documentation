---
title: Osadzanie czcionek w prezentacjach przy użyciu Pythona
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w programie PowerPoint przy użyciu Aspose.Slides for Python via .NET. Używaj Pythona, aby dodawać, pobierać, usuwać i kompresować czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek przechowuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są zainstalowane w systemie docelowym. Pomaga to zachować podziały wierszy, odstępy między tekstem i układ slajdów.

Aspose.Slides for Python via .NET umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem własności [fonts_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/) obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Można również zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają z plikami PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/), aby wyświetlić listę czcionek przechowywanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [remove_embedded_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/remove_embedded_font/), a następnie zapisz prezentację.

Poniższy przykład wyświetla listę osadzonych czcionek w pliku `EmbeddedFonts.pptx` i usuwa czcionkę Calibri, jeśli jest obecna:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Usunięcie osadzonej czcionki usuwa jej przechowywane dane czcionki; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w systemie docelowym, tekst może nadal jej używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/python-net/font-substitution/), co może wpłynąć na układ.

## **Sprawdzanie danych czcionki i uprawnień do osadzania**

Użyj klasy [FontsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/), aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [get_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/), aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [FontData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontstyletype/) do [get_font_bytes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_font_bytes/). Metoda zwraca dane binarne dla tego stylu czcionki lub `None`, gdy żądana czcionka lub styl jest niedostępny. Nie przekazuj wyniku `None` do [get_font_embedding_level](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), ponieważ metoda ta wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides/embeddinglevel/) jest wyliczeniem flag, które raportuje ograniczenia osadzania przechowywane w czcionce:

- `INSTALLABLE` zezwala na osadzanie i trwałą instalację na innym systemie, zgodnie z licencją czcionki.
- `RESTRICTED` zabrania osadzania, chyba że uzyskano zezwolenie od prawnego właściciela czcionki, gdy jest jedyną flagą uprawnień użytkowania.
- `PREVIEW_PRINT` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `EDITABLE` zezwala na tymczasowe użycie i pozwala na edycję oraz zapis dokumentu.
- `NO_SUBSETTING` jest dodatkowym ograniczeniem, które zakazuje osadzania tylko podzbioru glifów. Osadź wszystkie znaki, gdy ta flaga jest obecna.
- `BITMAP_ONLY` jest dodatkowym ograniczeniem, które zezwala na osadzenie wyłącznie bitmapowych wariantów czcionki, a nie danych konturów. Jeśli czcionka nie ma wariantów bitmapowych, nie może być osadzona.

Pierwsze cztery wartości opisują zezwolenie na użycie, podczas gdy `NO_SUBSETTING` i `BITMAP_ONLY` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `INSTALLABLE` ma wartość zero, maskuj bity zezwolenia na użycie i porównuj wynik z `INSTALLABLE`. Aktualne czcionki powinny ustawiać co najwyżej jeden bit zezwolenia na użycie. Dla kompatybilności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocnik wybiera najmniej restrykcyjne zezwolenie: `EDITABLE`, następnie `PREVIEW_PRINT`, potem `RESTRICTED`.

Poniższy przykład audytuje dane regularne, pogrubione, pochylone i pogrubione‑pochylone dostępne dla każdej czcionki zwróconej przez `get_fonts`. Pomija niedostępne style, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i drukowania, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli którykolwiek dostępny styl ma `NO_SUBSETTING`, osadza wszystkie znaki dla tej rodziny czcionek.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

To sprawdzenie zgłasza ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie udowadnia, że uzyskałeś czcionkę legalnie, ani nie zastępuje sprawdzania umowy licencyjnej czcionki przed dystrybucją osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [add_embedded_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/add_embedded_font/), aby osadzić czcionkę. Jego przeciążenia przyjmują albo obiekt [FontData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontdata/), albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/embedfontcharacters/) kontroluje, które znaki zostaną uwzględnione:

- [ALL](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [ONLY_USED](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do podglądu.

Poniższy przykład używa [get_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/), aby pobrać czcionki użyte w `Fonts.pptx` i osadzi te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje aktualne zestawy znaków.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Kompresowanie osadzonych czcionek**

[compress_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) zmniejsza dane osadzonych czcionek, usuwając nieużywane znaki. Działa na czcionkach, które już są osadzone, więc zmniejszenie rozmiaru zależy od ilości nieużywanych danych czcionki w prezentacji.

Poniższy przykład kompresuje czcionki w pliku `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą później potrzebować dodać tekst. Znaki usunięte podczas kompresji nie będą już dostępne w osadzonej czcionce, nawet jeżeli początkowo osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka nadal będzie podstawiana podczas renderowania?**

Wywołaj [get_substitutions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zastąpi. Sprawdź również ustawienia [font substitution](/slides/pl/python-net/font-substitution/) i reguły [font fallback](/slides/pl/python-net/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których dana czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję opieraj na docelowym środowisku. Jeśli wymagane czcionki są dostępne na każdym komputerze, który otwiera lub renderuje prezentację, ich osadzenie może zwiększyć niepotrzebnie rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie posiadać tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, pod warunkiem że licencje na to zezwalają.