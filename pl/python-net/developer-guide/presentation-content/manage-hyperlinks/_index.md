---
title: Zarządzanie hiperlinkami w prezentacji w Pythonie
linktitle: Zarządzanie hiperlinkami
type: docs
weight: 20
url: /pl/python-net/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperlink
- utwórz hiperlink
- sformatuj hiperlink
- usuń hiperlink
- zaktualizuj hiperlink
- hiperlink tekstowy
- hiperlink slajdu
- hiperlink kształtu
- hiperlink obrazu
- hiperlink wideo
- modyfikowalny hiperlink
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperlinki w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET, korzystając z przykładów w Pythonie."
---
## **Wprowadzenie**

Hiperlink łączy zawartość prezentacji ze stroną internetową lub z miejscem w obrębie prezentacji. W programie PowerPoint hiperlinki zazwyczaj spełniają dwa cele:

* Otwieranie strony internetowej z tekstu, kształtu lub ramki multimedialnej.
* Przejście do innego slajdu, na przykład z spisu treści.

Aspose.Slides for Python via .NET umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperlinkami na poszczególnych elementach oraz jak uzyskać dostęp do hiperlinków na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}

Możesz także edytować prezentacje przy użyciu [darmowego edytora Aspose PowerPoint online](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **Dodawanie hiperlinków URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperlink, określa obszar klikalny: fragment tekstu łączy wybrany tekst, natomiast kształt lub ramka łączy obiekt slajdu.

W prezentacjach zawierających względne hiperlinki zobacz [Manage the Hyperlink Base](/slides/pl/python-net/presentation-properties/#manage-the-hyperlink-base), aby odczytać, zmienić lub wyczyścić bazę dokumentu.

### **Dodawanie hiperlinków URL do tekstu**

Aby połączyć tekst ze stroną internetową, przypisz [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) do właściwości [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

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

### **Dodawanie hiperlinków URL do kształtów i ramek multimedialnych**

Przypisz URL do właściwości [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) prostokąta, aby cały jego obszar był klikalny. [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) podpowiada czytelnikowi, dokąd prowadzi link, gdy najedzie kursorem na prostokąt. Te same właściwości mają zastosowanie do ramek obrazu, audio i wideo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Użycie hiperlinków do stworzenia spisu treści**

Wewnętrzne hiperlinki pozwalają czytelnikom przeskakiwać ze spisu treści do konkretnego slajdu. Poniższy przykład używa [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/), aby połączyć tekst „Page 2” na pierwszym slajdzie z drugim slajdem.

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

## **Formatowanie hiperlinków**

Możesz zmienić kolor połączonego tekstu, odtwarzać lub zatrzymywać dźwięk po aktywacji linku oraz ustawić podpowiedź wyświetlaną po najechaniu.

### **Kolor**

Właściwość [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) klasy [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) określa, czy hiperlink używa koloru hiperlinku prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

W tym przykładzie ustawienie [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) w pierwszym linku sprawia, że jego tekst jest czerwony. Drugi link zachowuje kolor hiperlinku prezentacji.

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

Hiperlink może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj następujących właściwości, aby skonfigurować te zachowania:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) określa audio powiązane z hiperlinkiem.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) kontroluje, czy aktywacja hiperlinku zatrzymuje poprzedni dźwięk.

#### **Dodanie dźwięku do hiperlinku**

Przycisk na pierwszym slajdzie używa [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) do odtworzenia pliku WAV po kliknięciu. Na drugim slajdzie oddzielny przycisk używa [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) do zatrzymania odtwarzania i pozostawienia czytelnika na tym slajdzie.

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

#### **Wyodrębnianie dźwięku z hiperlinku**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperlinku pierwszego kształtu do pamięci za pomocą [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) oraz [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

Po przypisaniu hiperlinku do tekstu lub kształtu możesz zaktualizować następujące właściwości [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/):

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ustawia tekst wyświetlany jako podpowiedź dla linku.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, jeśli ma zastosowanie.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) kontroluje, czy aktywacja linku dodaje jego docelowy adres do listy przeglądanych hiperlinków.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) kontroluje, czy hiperlink jest podświetlany po kliknięciu.

## **Usuwanie hiperlinków z prezentacji**

Użyj [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), aby zebrać kontenery hiperlinków, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj jedynie [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) lub [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); usunięcie akcji kliknięcia nie usuwa odpowiadającej akcji najechania.

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

Dla bezwarunkowego usunięcia [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Aby dokonać selektywnego czyszczenia i objąć mistrzów, układy i notatki, zobacz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Czyszczenie hiperlinków przed zamianą tekstu SmartArt**

Gdy zamieniasz akapit w istniejącym węźle SmartArt, wyczyszczenie jego fragmentów tekstu może pozostawić stary hiperlink. Pobierz akapit przez [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Przed wyczyszczeniem fragmentów wywołaj [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) za pośrednictwem [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) na ramce tekstowej kształtu węzła, który wyświetla akapit. To usuwa każdy hiperlink w tej ramce, w tym linki w innych akapitach.

W pliku `SmartArtHyperlink.pptx` trzecim kształtem na pierwszym slajdzie jest grafika SmartArt. Przykład zamienia pierwszy akapit jego czwartego węzła. W tej prezentacji pierwszy kształt węzła wyświetla ten akapit.

Po dodaniu obu fragmentów przykład odczytuje ich efektywne formatowanie przy użyciu [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Efektywna właściwość [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) zwraca nowy hiperlink dla pierwszego fragmentu i `None` dla drugiego.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # Brak
```

## **Budowanie pełnego spisu hiperlinków**

Przed udostępnieniem prezentacji sporządź inwentarz jej interaktywnych działań oraz linków internetowych. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdzaj zarówno [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/), jak i [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba działania, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie wyłącznie hiperlinków na poziomie kształtu może pominąć linki do fragmentów tekstu. Zapytaj o odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc aktualizować lub usuwać ich działania.

### **Zapytania w zakresach Prezentacji, Slajdu i Ramki Tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) jest dostępna przez [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) oraz [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Każdy zakres obsługuje te same zapytania:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) zwraca kontenery z akcją kliknięcia.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) zwraca kontenery z akcją najechania.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) zwraca kontenery z jedną lub dwiema akcjami.

Przykład przypisuje akcje kliknięcia i najechania do kształtu i jego tekstu oraz akcję makra do oddzielnego przycisku. Porównuje kontenery zwrócone przez [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) z licznikami dla każdego typu aktywacji. Zapytanie ramki tekstowej liczy tylko linki w tekście. Działania samego kształtu pojawiają się w zapytaniach slajdu i prezentacji.

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

Dla tego przykładu zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięć, dwa kontenery najechań i trzy kontenery z dowolną akcją. Zapytanie ramki tekstowej zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i docelowych miejsc**

Użyj [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/), aby zinterpretować akcję przed zbadaniem jej docelowego miejsca. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `HYPERLINK` | Zewnętrzny hiperlink; sprawdź URL i jego schemat. |
| `JUMP_SPECIFIC_SLIDE` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Wbudowana nawigacja w trybie pokazu, rozwiązywana w kontekście pokazu. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `START_MACRO` | Uruchomienie makra. |
| `START_PROGRAM` | Uruchomienie programu. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Otworzenie pliku lub innej prezentacji; analizuj oddzielnie od URL‑ów webowych. |
| `START_STOP_MEDIA` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NO_ACTION`, `UNKNOWN` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytuj zewnętrzne miejsca docelowe z [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) oraz konkretne wewnętrzne miejsca z [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Działania wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza braku akcji. Zachowaj [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/), gdy różni się od znormalizowanego URL, oraz uwzględnij [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/), gdy jest dostępny.

### **Raportowanie, sanityzacja i weryfikacja hiperlinków**

Ten przykład otwiera prezentację z poprzedniego przykładu i zapisuje jeden rekord JSON na akcję. Używa [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), aby zebrać kontenery na zwykłych slajdach, mistrzach, układach i notatkach, włączając w to mistrze notatek i rozdawnicze, jeśli istnieją. Zapytuje każdy zakres raz, aby uniknąć podwójnego przetwarzania, stosuje opisaną niżej politykę i ponownie otwiera zapisaną prezentację, aby sprawdzić zarówno akcje kliknięcia, jak i najechania.

Raport zawiera indeks slajdu (liczony od jednego) oraz [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/), jeśli jest dostępny. Zbieracz zachowuje slajd właściciela i zakres wraz z każdym zwróconym kontenerem. Mistrze, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane po zakresie. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie działania. Każdy kontener otrzymuje raporowy identyfikator lokalny, aby jego dwie akcje można było ze sobą powiązać.

Ta celowo restrykcyjna polityka aplikacji zezwala jedynie na bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plików, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Są to decyzje polityczne, a nie ocena bezpieczeństwa Aspose.Slides. HTTPS sam w sobie nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole w swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audytuje metadane bez podążania za linkami lub wykonywania akcji.

W celu naprawy, [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) kontenera obsługuje [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) oraz [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i akcje najechania są usuwane osobno. Ustaw `replace_external_clicks` na `False`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania i wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądu, nie test zdolności ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) mogą zachować hiperlinki, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/python-net/convert-powerpoint-to-png/) i [video](/slides/pl/python-net/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperlinków; oznacz każdą akcję przy audycie tych wyjść.

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
    # Zapytaj każdy zakres slajdu raz, zachowując jego właściciela przy każdym kontenerze.
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

Przy danych utworzonych powyżej raport zawiera pięć wierszy akcji. Link najechania myszy i makro kliknięcie są usunięte, natomiast linki HTTPS i wewnętrzna nawigacja slajdów pozostają. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również wywołuje gałąź zamiany. Kontener z dozwolonym kliknięciem i zabronionym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), które usuwa oba typy aktywacji w wybranym zakresie niezależnie od polityki. Weryfikacja tutaj sprawdza jedynie akcje hiperlinków; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej treści i nie waliduje wyeksportowanego pliku PDF ani HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzny hiperlink kieruje do pojedynczego slajdu. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem w tej sekcji.

**Czy mogę dołączyć hiperlink do elementów slajdu mistrza, aby działał na wszystkich slajdach?**

Tak. Elementy slajdu mistrza i układu obsługują hiperlinki. Linki na tych elementach są dostępne podczas pokazu na slajdach korzystających z odpowiedniego mistrza lub układu.

**Czy hiperlinki będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperlinki; obrazy rastrowe i wideo nie mogą. Zobacz uwagi dotyczące eksportu w [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).