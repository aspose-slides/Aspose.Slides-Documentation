---
title: Osadzanie czcionek w prezentacjach w Pythonie przy użyciu Java
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/python-java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides for Python via Java. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w systemie docelowym. Pomaga to zachować podziały wierszy, odstępy między tekstem i układ slajdów.

Aspose.Slides for Python via Java umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pomocą klasy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) zwracanej przez [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getFontsManager). Można także zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [getEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) aby wyświetlić listę czcionek przechowywanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [removeEmbeddedFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), a następnie zapisz prezentację.

Poniższy przykład wyświetla osadzone czcionki w pliku `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Usunięcie osadzonej czcionki usuwa jej zapisane dane; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w systemie docelowym, tekst może nadal jej używać. W przeciwnym razie renderowanie może wymagać podstawienia czcionki, co może wpłynąć na układ.

## **Sprawdzanie danych czcionki i uprawnień do osadzania**

Użyj klasy [FontsManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/) aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [FontsManager.getFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFonts), aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [FontData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontstyletype/), do [FontsManager.getFontBytes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFontBytes). Metoda zwraca dane binarne dla tego stylu czcionki lub `None`, gdy żądana czcionka lub styl są niedostępne. Nie przekazuj wyniku `None` do [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), ponieważ metoda ta wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embeddinglevel/) jest wyliczeniem flag, które raportuje ograniczenia osadzania zapisane w czcionce:
- `Installable` zezwala na osadzanie i trwałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano pozwolenie od prawnego właściciela czcionki, gdy jest jedyną flagą uprawnienia użycia.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie i pozwala na edytowanie oraz zapisywanie dokumentu.
- `NoSubsetting` jest dodatkowymi ograniczeniem, które zabrania osadzania tylko podzbioru glifów. Gdy ta flaga jest obecna, osadź wszystkie znaki.
- `BitmapOnly` jest dodatkowymi ograniczeniem, które zezwala na osadzenie tylko bitmapowych wersji czcionki, a nie danych konturów. Jeśli czcionka nie ma bitmapowych wersji, nie może być osadzona.

Pierwsze cztery wartości opisują uprawnienia do użycia, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `Installable` ma wartość zero, maskuj bity uprawnienia użycia i porównuj wynik z `Installable` zamiast sprawdzać ją jako flagę. Aktualne czcionki powinny ustawiać co najwyżej jeden bit uprawnienia użycia. Dla zgodności ze starszymi czcionkami, które ustawiają więcej niż jeden, pomocnicza metoda poniżej wybiera najmniej restrykcyjne uprawnienie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład audytuje regularne, pogrubione, kursywne i pogrubiono‑kursywne dane dostępne dla każdej czcionki zwróconej przez `getFonts`. Pomija niedostępne style, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i drukowania, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli jakikolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

To sprawdzenie raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że czcionka została nabyta legalnie, ani nie zastępuje weryfikacji umowy licencyjnej czcionki przed rozpowszechnieniem osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [addEmbeddedFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#addEmbeddedFont), aby osadzić czcionkę. Przeciążenia przyjmują albo obiekt [FontData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontdata/), albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embedfontcharacters/) określa, które znaki są dołączane:
- [All](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do wyświetlania.

Poniższy przykład używa [getFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFonts), aby pobrać czcionki użyte w `Fonts.pptx` i osadzi te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kompresja osadzonych czcionek**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#compressEmbeddedFonts) zmniejsza dane osadzonych czcionek, usuwając nieużywane znaki. Działa na czcionkach, które już są osadzone, więc redukcja rozmiaru zależy od ilości nieużywanych danych czcionki w prezentacji.

Poniższy przykład kompresuje czcionki w pliku `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą później potrzebować dodać tekst. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli pierwotnie osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka zostanie nadal podstawiona podczas renderowania?**

Wywołaj [getSubstitutions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zamieni. Sprawdź także ustawienia podstawiania czcionek oraz reguły awaryjnego wyboru czcionki. Awaryjny wybór obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których dana czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję opieraj na środowisku docelowym. Jeśli wymagane czcionki są dostępne na każdej maszynie otwierającej lub renderującej prezentację, ich osadzenie może zwiększyć niepotrzebnie rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, o ile licencje na to zezwalają.