---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w Pythonie
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/python-net/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zamiana tekstu
- wyrażenie regularne
- ramka tekstowa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Te możliwości są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów i innych zautomatyzowanych procesach przetwarzania dokumentów.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetlenie dosłownego tekstu | [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_text/) |
| Podświetlenie dopasowań wyrażeniem regularnym | [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_regex/) |
| Zamiana dosłownego tekstu | [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_text/) |
| Zamiana dopasowań wyrażeniem regularnym | [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_regex/) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na dosłownym tekście użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/), aby kontrolować dopasowanie:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/whole_words_only/) ogranicza dopasowania do całych słów.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/case_sensitive/) kontroluje, czy uwzględniać wielkość znaków.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/include_notes/) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje wyrażeń regularnych używają ciągu wzorca, więc reguły dopasowania, takie jak wrażliwość na wielkość liter i granice słów, są definiowane w samym wyrażeniu.

## **Identyfikacja właściciela ramki tekstowej**

Typowe przepływy przetwarzania tekstu często otrzymują [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/) i [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/), aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Właścicielski [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) | `None` |
| Komórka tabeli | `None` | Właścicielski [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) |

Obie właściwości są tylko do odczytu. Odczytanie ich nie przemieszcza ramki tekstowej ani nie zmienia jej właściciela. Ogólny kod powinien sprawdzać obie wartości pod kątem `None` i obsługiwać sytuację, gdy żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/get_all_text_frames/), aby przeiterować wszystkie ramki tekstowe w prezentacji. Dla kształtów raportuje nazwę kształtu, typ w czasie wykonywania Pythona oraz slajd, na którym się znajduje. Dla komórek tabeli raportuje współrzędne kolumny i wiersza (zerowe) oraz slajd, w którym się znajduje.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Dla zawartości SmartArt iteruj przez kształty w [SmartArtNode.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartnode/shapes/) i uzyskaj dostęp do każdego [ISmartArtShape.text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Rama tekstowa może być powiązana z odpowiednim kształtem poprzez [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/), natomiast [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/) ma wartość `None`. Dlatego gałąź kształtu w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Podświetlenie tekstu**

Użyj metody [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/), aby podświetlić dopasowania dosłownego tekstu w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko całe słowo **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Podświetl każde wystąpienie "try" w ramce tekstowej.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Podświetl tylko całe słowo "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetlenie tekstu przy użyciu wyrażeń regularnych**

Metoda [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające co najmniej siedem znaków:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetlenie tekstu w całej prezentacji**

Użyj [Presentation.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_text/) i [Presentation.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_regex/), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowne wyrażenie oraz wszystkie adresy e‑mail:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Zamiana tekstu w ramce tekstowej**

Użyj [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) dla dosłownego tekstu i [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z ciągu znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zamienia etykiety wersji:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zamienionego.

## **Zamiana tekstu w całej prezentacji**

Użyj [Presentation.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_text/) i [Presentation.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_regex/), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii i redakcji.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Jak mogę przeszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Uzyskaj ramkę tekstową kształtu i wywołaj [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) lub [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować całe słowa z poprawną wielkością liter?**

Ustaw [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/whole_words_only/) i [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/case_sensitive/) na `True` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. Dla wyrażeń regularnych zdefiniuj granice słów i wrażliwość na wielkość liter w samym wzorcu.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdu?**

Tak. Ustaw [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/include_notes/) na `True` przy używaniu operacji dosłownego tekstu na poziomie prezentacji.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) i [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, przeanalizuj wynik, aby upewnić się, że zamiana używa pożądanego stylu.