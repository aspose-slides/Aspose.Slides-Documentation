---
title: Osadzanie czcionek w prezentacjach przy użyciu Pythona
linktitle: Osadzanie czcionki
type: docs
weight: 40
url: /pl/python-net/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- skompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w technologii .NET, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wstęp**

**Osadzanie czcionek w PowerPoint** zapewnia, że Twoja prezentacja zachowuje zamierzony wygląd na różnych systemach. Niezależnie od tego, czy używasz unikalnych czcionek w celach kreatywnych, czy standardowych, osadzanie czcionek zapobiega zakłóceniom tekstu i układu.

Jeśli użyłeś czcionki zewnętrznej lub niestandardowej, ponieważ byłeś kreatywny w swojej pracy, masz jeszcze więcej powodów, aby osadzić tę czcionkę. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylizacja itp. mogą ulec zmianie lub zamienić się w mylące prostokąty.

Użyj klas [FontsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontdata/) i [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) do zarządzania osadzonymi czcionkami.

## **Pobieranie i usuwanie osadzonych czcionek**

Łatwo pobieraj lub usuwaj osadzone czcionki z prezentacji za pomocą metod [get_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) i [remove_embedded_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Ten kod w Pythonie pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
    with slides.Presentation("EmbeddedFonts.pptx") as presentation:
        slide = presentation.slides[0]

        # Renderuj slajd zawierający ramkę tekstową używającą osadzonej czcionki 'FunSized'.
        with slide.get_image(draw.Size(960, 720)) as image:
            image.save("picture1_out.png", slides.ImageFormat.PNG)

        fonts_manager = presentation.fonts_manager

        # Pobierz wszystkie osadzone czcionki.
        embedded_fonts = fonts_manager.get_embedded_fonts()

        # Znajdź czcionkę 'Calibri'.
        font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

        # Usuń czcionkę 'Calibri'.
        fonts_manager.remove_embedded_font(font_data)

        # Renderuj slajd; czcionka 'Calibri' zostanie zastąpiona istniejącą.
        with slide.get_image(draw.Size(960, 720)) as image:
            image.save("picture2_out.png", slides.ImageFormat.PNG)

        # Zapisz prezentację bez osadzonej czcionki 'Calibri' na dysku.
        presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Dodawanie osadzonych czcionek**

Korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/embedfontcharacters/) oraz dwóch przeciążeń metody [add_embedded_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/add_embedded_font/), możesz wybrać preferowaną regułę (osadzania) w celu osadzenia czcionek w prezentacji. Ten kod w Pythonie pokazuje, jak osadzić i dodać czcionki do prezentacji:

```python
import aspose.slides as slides

# Załaduj prezentację.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Zapisz prezentację na dysku.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Kompresja osadzonych czcionek**

Optymalizuj rozmiar pliku, kompresując osadzone czcionki za pomocą [compress_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Przykładowy kod kompresji:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak mogę stwierdzić, że konkretna czcionka w prezentacji zostanie zastąpiona podczas renderowania pomimo osadzenia?**

Sprawdź [informacje o zastępowaniu](/slides/pl/python-net/font-substitution/) w menedżerze czcionek oraz [reguły awaryjnego/zastępowania](/slides/pl/python-net/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka awaryjna.

**Czy warto osadzać czcionki „systemowe”, takie jak Arial/Calibri?**

Zazwyczaj nie — są prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych zastąpień.