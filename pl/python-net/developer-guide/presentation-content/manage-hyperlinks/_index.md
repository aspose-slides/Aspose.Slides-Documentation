---
title: Zarządzanie hiperłączami w prezentacji w Pythonie
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/python-net/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- zaktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET, korzystając z przykładów w Pythonie."
---
## **Wprowadzenie**

Hiperłącze łączy treść prezentacji ze stroną internetową lub lokalizacją w obrębie prezentacji. W programie PowerPoint hiperłącza zwykle służą dwóm celom:

* Otwórz stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejdź do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for Python via .NET umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz także edytować prezentacje za pomocą [darmowego internetowego edytora Aspose PowerPoint](https://products.aspose.app/slides/pl/editor).
{{% /alert %}}

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: część tekstu łączy zaznaczony tekst, natomiast kształt lub ramka łączy obiekt slajdu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst ze stroną internetową, przypisz [Hyperlink](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/) do właściwości [hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/hyperlink_click/) części tekstu, jak pokazano poniżej. Tylko ta część tekstu stanie się klikalna.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, ustaw jej właściwość [hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/hyperlink_click/). Hiperłącze należy do samego obiektu, a nie do części tekstu wewnątrz niego.

To samo podejście dotyczy ramek obrazu, audio i wideo: przypisz hiperłącze do ramki i, jeśli potrzebne, ustaw [tooltip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/tooltip/) linku.

Poniższy przykład sprawia, że prostokąt jest klikalny:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Użyj hiperłączy do utworzenia spisu treści**

Wewnętrzne hiperłącza pozwalają czytelnikom przejść ze spisu treści do konkretnego slajdu. Poniższy przykład używa [set_internal_hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) do powiązania tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatuj hiperłącza**

### **Kolor**

Właściwość [color_source](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/color_source/) obiektu [Hyperlink](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji, czy formatowania części tekstu. Aby zastosować niestandardowy kolor tekstu, wybierz [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia części. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, natomiast drugie zachowuje domyślny kolor hiperłącza.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Dźwięk**

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać dźwięk, który już odtwarzany jest. Użyj poniższych właściwości, aby skonfigurować te zachowania:

- [Hyperlink.sound](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/sound/) określa dźwięk powiązany z hiperłączem.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/stop_sound_on_click/) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera powyżej utworzoną prezentację i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci przy użyciu [sound](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/sound/) oraz [binary_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Ustawienia podpowiedzi i interakcji**

Możesz zaktualizować następujące właściwości [Hyperlink](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/) po przypisaniu hiperłącza do tekstu lub kształtu:

- [tooltip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/tooltip/) ustawia tekst, który widz może wyświetlić jako podpowiedź dla linku.
- [target_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/target_frame/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, jeśli ma to zastosowanie.
- [history](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/history/) kontroluje, czy aktywacja linku dodaje jego docelowy adres do listy oglądanych hiperłączy.
- [highlight_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/highlight_click/) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [get_any_hyperlinks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) aby zebrać kontenery hiperłączy, w tym linki części tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj jedynie [remove_hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) lub [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); usunięcie akcji kliknięcia nie usuwa jej odpowiednika mouse-over.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Do bezwarunkowego usunięcia, [remove_all_hyperlinks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednocześnie. Do selektywnego czyszczenia i obejmowania masterów, układów i notatek, zobacz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj kompletną inwentaryzację hiperłączy**

Przed rozpowszechnieniem prezentacji, zinwentaryzuj jej interaktywne akcje oraz linki internetowe. [get_any_hyperlinks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdź zarówno [hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) jak i [hyperlink_mouse_over](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba działania, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie tylko hiperłącz na poziomie kształtów może pominąć linki dołączone do części tekstu. Zapytaj zamiast tego odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstu**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/) jest dostępna poprzez [Presentation.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/hyperlink_queries/), oraz [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/hyperlink_queries/). Każdy zakres obsługuje te same zapytania:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) zwraca kontenery z akcją kliknięcia.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) zwraca kontenery z akcją najechania myszą.
- [get_any_hyperlinks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem mouse-over do pliku, wewnętrzną nawigacją slajdów, linkiem mouse-over tekstu oraz akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstu wyklucza własne linki otaczającego kształtu.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Dla tego przykładu zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięcia, dwa kontenery mouse-over oraz trzy kontenery z jedną z akcji. Zapytanie ramki tekstu zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i cele**

Użyj [Hyperlink.action_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/action_type/) aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `HYPERLINK` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JUMP_SPECIFIC_SLIDE` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Wbudowana nawigacja pokazu slajdów, rozwiązywana w kontekście pokazu. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `START_MACRO` | Uruchomienie makra. |
| `START_PROGRAM` | Uruchomienie programu. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Otwórz plik lub inną prezentację; przeglądaj osobno od adresów URL. |
| `START_STOP_MEDIA` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NO_ACTION`, `UNKNOWN` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele z [external_url](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/external_url/) i konkretne wewnętrzne cele z [target_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/target_slide/). Akcje wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj [external_url_original](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/external_url_original/), gdy różni się od znormalizowanego URL, i uwzględnij [tooltip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/tooltip/), gdy jest dostępny.

### **Raportuj, sanitizuj i weryfikuj hiperłącza**

Poniższy przykład w Pythonie odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i zapytuje każdy zakres slajdu raz, aby uniknąć podwójnego przetwarzania. Zapytania prezentacji obejmują zwykłe slajdy; aby uzyskać inwentaryzację całego pakietu, przykład zapytuje zwykłe slajdy, mastery, układy, notatki oraz mastery notatek i materiałów pomocniczych, jeśli są dostępne.

Raport zapisuje indeks slajdu zaczynający się od jedynki oraz [slide_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/slide_id/) , jeśli jest dostępny. Zbieracz zachowuje slajd właściciela i zakres wraz z każdym zwróconym kontenerem. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i kontenery formatowania części tekstu są oznaczone osobno; inne typy kontenerów zachowują swoją nazwę typu w czasie wykonywania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje można było powiązać.

Ta celowo restrykcyjna polityka aplikacji dopuszcza tylko bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plików, inne akcje pokazu slajdów, nieznane akcje oraz inne schematy URL. Te odrzucenia są decyzjami politycznymi, a nie oceną bezpieczeństwa Aspose.Slides. HTTPS sam w sobie nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole w swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL. Przykład audytuje metadane bez podążania za linkami lub wykonywania akcji.

W celu naprawy, [hyperlink_manager] kontenera obsługuje [set_external_hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) oraz [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i akcje mouse-over są usuwane niezależnie. Ustaw `replace_external_clicks` na `False`, aby zamiast tego usunąć wszystkie naruszenia polityki. Wybierz stronę zamienną zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu w raporcie używa konserwatywnej polityki przeglądu PDF: oznacza akcje mouse-over oraz wszystko oprócz zewnętrznego linku lub konkretnego skoku slajdu jako potencjalnie nieobsługiwane. Jest to wskazówka przeglądu, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Obrazy rastrowe [images](/slides/pl/python-net/convert-powerpoint-to-png/) i [video](/slides/pl/python-net/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję podczas audytu pod kątem tych wyjść.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Przy utworzonym powyżej wejściu raport zawiera pięć wierszy akcji. Link mouse-over do pliku i kliknięcie makra są usunięte, natomiast linki HTTPS i wewnętrzna nawigacja slajdów pozostają. Weryfikacja wyświetla zero zakazanych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również wywołuje gałąź zamiany. Kontener z dozwolonym kliknięciem i zabronionym mouse-over zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [remove_all_hyperlinks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), które usuwa oba typy aktywacji w całym wybranym zakresie niezależnie od polityki. Weryfikacja tutaj sprawdza tylko akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **Najczęściej zadawane pytania**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w konkretny slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu master, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu master i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz informacje o eksporcie w [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).