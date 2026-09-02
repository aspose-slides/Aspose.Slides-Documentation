---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w Pythonie
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/python-net/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zastępowanie tekstu
- wyrażenie regularne
- ramka tekstowa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET może wyszukiwać, podświetlać i zastępować tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Te możliwości są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów oraz innych zautomatyzowanych przepływach przetwarzania dokumentów.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl dosłowny tekst | [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_text/) |
| Podświetl dopasowania wyrażenia regularnego | [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_regex/) |
| Zastąp dosłowny tekst | [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_text/) |
| Zastąp dopasowania wyrażenia regularnego | [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_regex/) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na dosłownym tekście użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/), aby kontrolować dopasowanie:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/whole_words_only/) ogranicza dopasowania do pełnych wyrazów.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/case_sensitive/) kontroluje, czy wielkość znaków musi się zgadzać.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/include_notes/) uwzględnia notatki slajdów w operacjach wyszukiwania, zastępowania i podświetlania na poziomie prezentacji.

Operacje wyrażenia regularnego używają ciągu wzorca, więc reguły dopasowywania, takie jak rozróżnianie wielkości liter i granice wyrazów, są definiowane w wyrażeniu.

## **Podświetl tekst**

Użyj metody [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/), aby podświetlić dopasowania dosłownego tekstu w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** oraz następnie podświetla tylko pełny wyraz **"to"**.

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

    # Podświetl tylko pełny wyraz "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/) podświetla dopasowania tekstu znalezione przy pomocy wyrażenia regularnego w ramce tekstowej.

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

## **Podświetl tekst w całej prezentacji**

Użyj [Presentation.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_text/) i [Presentation.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/highlight_regex/), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowny termin oraz wszystkie adresy e‑mail:

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

## **Zastąp tekst w ramce tekstowej**

Użyj [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) dla dosłownego tekstu i [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast budować ramkę tekstową od czystego ciągu.

Poniższy przykład ujednolicaja wariant pisowni, a następnie zastępuje etykiety wersji:

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zastępczego.

## **Zastąp tekst w całej prezentacji**

Użyj [Presentation.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_text/) i [Presentation.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_regex/), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacjach terminologii oraz redakcji.

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

**Jak mogę wyszukiwać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Uzyskaj ramkę tekstową kształtu i wywołaj [TextFrame.highlight_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) lub [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować pełne wyrazy z poprawną wielkością liter?**

Ustaw [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/whole_words_only/) i [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/case_sensitive/) na `True`, a następnie przekaż opcje do metody podświetlania lub zastępowania tekstu dosłownego. Dla wyrażeń regularnych określ granice wyrazów i rozróżnianie wielkości liter w samym wzorcu.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textsearchoptions/include_notes/) na `True` podczas używania operacji dosłownego tekstu na poziomie prezentacji.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame.replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_text/) i [TextFrame.replace_regex](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/replace_regex/) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.