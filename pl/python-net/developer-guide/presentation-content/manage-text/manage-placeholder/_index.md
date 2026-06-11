---
title: Zarządzanie polami zastępczymi w prezentacjach przy użyciu Pythona
linktitle: Zarządzanie polami zastępczymi
type: docs
weight: 10
url: /pl/python-net/manage-placeholder/
keywords:
- pole zastępcze
- tekstowe pole zastępcze
- obrazowe pole zastępcze
- wykresowe pole zastępcze
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Bezproblemowo zarządzaj polami zastępczymi w Aspose.Slides dla Pythona poprzez .NET: zamieniaj tekst, dostosowuj podpowiedzi i ustawiaj przezroczystość obrazów w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia programowe zarządzanie polami zastępczymi prezentacji. Ten artykuł wyjaśnia, jak znajdować pola zastępcze na slajdach i zmieniać ich tekst, ustawiać własny tekst podpowiedzi dla układów pól zastępczych oraz regulować przezroczystość obrazu używanego jako tło pola zastępczego. Zawiera także krótkie FAQ, które wyjaśnia różnicę między podstawowymi polami zastępczymi a lokalnymi kształtami, opisuje, jak zmiany pól zastępczych mogą być stosowane przez układy lub wzorce oraz wskazuje zarządzanie polami zastępczymi nagłówka i stopki.

## **Zmiana tekstu w polach zastępczych**

Przy użyciu Aspose.Slides for Python możesz znajdować i modyfikować pola zastępcze na slajdach w prezentacji. Aspose.Slides pozwala modyfikować tekst w polu zastępczym.

**Wymaganie wstępne:** Potrzebujesz prezentacji zawierającej pole zastępcze. Taką prezentację możesz utworzyć w programie Microsoft PowerPoint.

Oto jak używać Aspose.Slides do zastąpienia tekstu w polu zastępczym:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i przekaż prezentację jako argument.
1. Pobierz referencję do slajdu według jego indeksu.
1. Przejrzyj kształty, aby znaleźć pole zastępcze.
1. Zmien tekst przy użyciu [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).
1. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak zmienić tekst w polu zastępczym:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Przejdź przez kształty, aby znaleźć pola zastępcze.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Zmień tekst w każdym polu zastępczym.
            shape.text_frame.text = "This is Placeholder"

    # Zapisz prezentację na dysku.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw tekst podpowiedzi dla pola zastępczego**

Standardowe i wstępnie przygotowane układy zawierają domyślny tekst podpowiedzi pola zastępczego, taki jak **Kliknij, aby dodać tytuł** lub **Kliknij, aby dodać podtytuł**. Za pomocą Aspose.Slides możesz zastąpić te podpowiedzi własnym tekstem w układach pól zastępczych.

Poniższy przykład w Pythonie pokazuje, jak ustawić tekst podpowiedzi dla pola zastępczego:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Przejdź przez kształty, aby znaleźć pola zastępcze.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw przezroczystość obrazu w polu zastępczym**

Aspose.Slides pozwala ustawić przezroczystość obrazu tła w polu zastępczym tekstu. Dostosowując przezroczystość obrazu w tej ramce, możesz wyeksponować albo tekst, albo obraz, w zależności od ich kolorów.

Poniższy przykład w Pythonie pokazuje, jak ustawić przezroczystość obrazu tła wewnątrz kształtu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Czym jest podstawowe pole zastępcze i czym różni się od lokalnego kształtu na slajdzie?**

Podstawowe pole zastępcze jest oryginalnym kształtem w układzie lub wzorcu, z którego dziedziczy kształt na slajdzie — typ, pozycja i niektóre formatowanie pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma podstawowego pola zastępczego, dziedziczenie nie ma zastosowania.

**Jak mogę zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiednie pole zastępcze w układzie lub wzorcu. Slajdy oparte na tych układach/wzorcu automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe pola zastępcze nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zakresie (zwykłe slajdy, układy, wzorzec, notatki/ulotki), aby włączać lub wyłączać te pola zastępcze oraz ustawiać ich zawartość.