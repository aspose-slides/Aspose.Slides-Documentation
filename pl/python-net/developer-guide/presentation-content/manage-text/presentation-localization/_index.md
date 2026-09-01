---
title: Automatyzuj lokalizację prezentacji w Pythonie
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/python-net/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w Pythonie przy użyciu Aspose.Slides, włączając wartości domyślne oraz wielojęzyczne akapity."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia konfigurowanie metadanych korekty dla poszczególnych fragmentów tekstu. Użyj [BasePortionFormat.language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/language_id/) aby określić język korekty, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/spell_check/) aby zezwolić lub wyłączyć sprawdzanie pisowni oraz [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/proof_disabled/) aby kontrolować szerszy stan „nie‑korygować”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różnych reguł korekty.

Ten artykuł wyjaśnia, jak przypisać język do określonego tekstu, ustawić domyślny język dla nowego tekstu przy użyciu [LoadOptions.default_text_language](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/default_text_language/), zbudować wielojęzyczne akapity, wybrać pomiędzy `spell_check` a `proof_disabled` oraz zachować zamierzone ustawienia przy użyciu [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Właściwości te przechowują metadane dla aplikacji prezentacji; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słownikach ani nie zwracają listy błędnie napisanych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu przez [Portion.portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/portion_format/) i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions.default_text_language](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/default_text_language/) aby określić język korekty, który Aspose.Slides przydziela nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma wyraźnie określony język.

Poniższy przykład tworzy prezentację, w której nowy tekst korzysta z niemieckich reguł korekty:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Użyj wielu języków w jednym akapicie**

[Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) zawiera kolekcję fragmentów tekstu. Utwórz osobny [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) dla każdego języka i ustaw jego `language_id` niezależnie.

Ten przykład tworzy jeden akapit z fragmentami w języku angielskim i francuskim:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[PortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane w [BasePortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/). Uzyskaj dostęp do formatu fragmentu poprzez [Portion.portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/portion_format/) i ustaw [BasePortionFormat.spell_check](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/spell_check/) aby kontrolować, czy aplikacja prezentacji może sprawdzać pisownię tego fragmentu. Domyślna wartość to `False`: `True` zezwala na sprawdzanie pisowni, natomiast `False` je wyłącza.

Ustawienie dotyczy pojedynczych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc mieć różne wartości. [BasePortionFormat.language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/language_id/) i `spell_check` pełnią uzupełniające role: `language_id` określa język korekty, a `spell_check` decyduje, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/proof_disabled/) również kontroluje korektę, ale reprezentuje szerszy stan „nie korygować” jako [NullableBool](https://reference.aspose.com/slides/pl/python-net/aspose.slides/nullablebool/). Używaj `spell_check`, gdy potrzebujesz bezpośredniego przełącznika Boolean specjalnie dla sprawdzania pisowni. Używaj `proof_disabled`, gdy musisz zachować lub jawnie kontrolować metadane „brak korekty” prezentacji, w tym jej stan `NOT_DEFINED`. Jeśli ustawisz obie właściwości, utrzymaj ich wartości spójne; nie łącz `spell_check = True` z `proof_disabled = slides.NullableBool.TRUE`.

Właściwości te konfigurują metadane korekty używane przez PowerPoint i inne aplikacje prezentacyjne. Aspose.Slides nie używa ich do uruchamiania sprawdzania pisowni opartego na słownikach ani do zwracania listy błędnie napisanych słów.

Poniższy kompletny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty dwóm fragmentom w tym samym akapicie, zapisuje wynik, otwiera go ponownie i weryfikuje zapisane wartości:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) łączy sąsiadujące fragmenty, które mają takie samo formatowanie. Różnica w samym `spell_check` nie wystarczy, aby utrzymać fragmenty oddzielnie; po połączeniu wynikowy fragment zachowuje wartość `spell_check` pierwszego fragmentu. Jeśli fragmenty potrzebują różnych ustawień sprawdzania pisowni, wywołaj `join_portions_with_same_formatting` przed nadaniem tych ustawień lub sprawdź granice wynikowego fragmentu i ponownie zastosuj ustawienia później. Fragmenty z różnymi wartościami `language_id` pozostają oddzielne, ponieważ ich formatowanie językowe się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [BasePortionFormat.language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/language_id/) przechowuje metadane korekty dla pisowni i gramatyki; nie zmienia treści tekstu. Tłumacz tekst osobno, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty steruje czcionkami, dzieleniem wyrazów lub zawijaniem linii?**

Nie. Identyfikator języka służy wyłącznie korekcie. Renderowanie i układ tekstu zależą głównie od dostępnych [fonts](/slides/pl/python-net/powerpoint-fonts/), systemu pisma i ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [font substitution](/slides/pl/python-net/font-substitution/) lub [embed fonts](/slides/pl/python-net/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do osobnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać `default_text_language` czy `language_id`?**

Używaj [LoadOptions.default_text_language](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/default_text_language/) gdy chcesz ustawić domyślny język dla nowo tworzonego tekstu. Używaj [BasePortionFormat.language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/language_id/) gdy konkretny fragment wymaga wyraźnego języka korekty lub gdy akapit zawiera wiele języków.