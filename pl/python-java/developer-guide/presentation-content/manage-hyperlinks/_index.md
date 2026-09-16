---
title: Zarządzaj hiperłączami prezentacji w Pythonie przy użyciu Java
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/python-java/manage-hyperlinks/
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
- Java
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via Java, używając przykładów w Pythonie."
---
## **Wprowadzenie**

Hiperłącze łączy zawartość prezentacji z witryną internetową lub miejscem w obrębie prezentacji. W programie PowerPoint hiperłącza zwykle służą dwóm celom:

* Otwórz witrynę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejdź do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for Python via Java umożliwia dodawanie tych łączy, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz również edytować prezentacje za pomocą [bezpłatnego internetowego edytora Aspose PowerPoint](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL witryny do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy wybrany tekst, natomiast kształt lub ramka łączy obiekt slajdu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst z witryną, przekaż [Hyperlink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/) do metody [setHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#setHyperlinkClick) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, wywołaj jej metodę [setHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setHyperlinkClick). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście dotyczy ramek obrazów, dźwięku i wideo: przypisz hiperłącze do ramki i wywołaj [setTooltip](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setTooltip), jeśli jest to potrzebne.

Poniższy przykład sprawia, że prostokąt jest klikalny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Użyj hiperłączy do utworzenia spisu treści**

Wewnętrzne hiperłącza pozwalają czytelnikom przechodzić ze spisu treści do konkretnego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) do połączenia tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatuj hiperłącza**

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setColorSource) klasy [Hyperlink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji czy formatowania fragmentu tekstu. Aby zastosować niestandardowy kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w programie PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwszy używa czerwonego wypełnienia tekstu, natomiast drugi zachowuje domyślny kolor hiperłącza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Dźwięk**

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać dźwięk już odtwarzany. Użyj następujących metod, aby skonfigurować te zachowania:

- [Hyperlink.setSound](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setSound) określa dźwięk powiązany z hiperłączem.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera prezentację utworzoną powyżej i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci za pomocą [getSound](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getSound) i [getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Podpowiedź i ustawienia interakcji**

Możesz wywołać następujące metody [Hyperlink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/) po przypisaniu hiperłącza do tekstu lub kształtu:

- [setTooltip](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setTooltip) ustawia tekst, który widz może wyświetlić jako podpowiedź dla łącza.
- [setTargetFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setTargetFrame) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.
- [setHistory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setHistory) kontroluje, czy aktywacja łącza dodaje jego cel do listy przeglądanych hiperłączy.
- [setHighlightClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#setHighlightClick) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks), aby zebrać kontenery hiperłączy, w tym linki do fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); usunięcie akcji kliknięcia nie usuwa jej odpowiednika przy najechaniu myszą.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Dla bezwarunkowego usunięcia, [removeAllHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Dla selektywnego czyszczenia i objęcia slajdów-mistrzów, układów i notatek, zobacz [Raport, Sanityzacja i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj kompletny spis hiperłączy**

Przed dystrybucją prezentacji, sporządź inwentaryzację jej interaktywnych akcji oraz linków internetowych. [getAnyHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) zwraca kontenery hiperłączy, takie jak obiekty [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) i [PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/), a nie płaską listę ciągów URL. Sprawdź zarówno [getHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getHyperlinkClick), jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getHyperlinkMouseOver) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać obie akcje, więc kompletny raport wymaga do dwóch wierszy na kontener.

Skanowanie wyłącznie hiperłączy na poziomie kształtu może pominąć linki do fragmentów tekstu. Zapytaj odpowiedni zakres zamiast tego i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/) jest dostępna przez [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getHyperlinkQueries) i [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getHyperlinkQueries). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) zwraca kontenery z akcją kliknięcia.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) zwraca kontenery z akcją najechania myszą.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem najechania pliku, wewnętrzną nawigacją slajdu, linkiem najechania tekstu i akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dla tego przykładu zapytania prezentacji i slajdu zwracają po trzy kontenery kliknięć, dwa kontenery najechania i trzy kontenery posiadające dowolną akcję. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i miejsca docelowe**

Użyj [Hyperlink.getActionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getActionType), aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację sieciową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź adres URL i jego schemat. |
| `JumpSpecificSlide` | Nawigacja wewnętrzna do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja w pokazie slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub rozpoczęcie pokazu niestandardowego. |
| `StartMacro` | Wykonaj makro. |
| `StartProgram` | Uruchom program. |
| `OpenFile`, `OpenPresentation` | Otwórz plik lub inną prezentację; przeglądaj oddzielnie od adresów URL. |
| `StartStopMedia` | Rozpocznij lub zatrzymaj odtwarzanie multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele z [getExternalUrl](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getExternalUrl) oraz konkretne wewnętrzne cele z [getTargetSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getTargetSlide). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal), gdy różni się ona od znormalizowanego URL, i uwzględnij podpowiedź zwróconą przez [getTooltip](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlink/#getTooltip), gdy jest dostępna.

### **Raport, Sanityzacja i weryfikacja hiperłączy**

Poniższy przykład w Pythonie odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa równości referencji, aby uniknąć podwójnego przetwarzania tego samego kontenera. Zapytania prezentacji obejmują zwykłe slajdy; dla inwentaryzacji całego pakietu explicite zapytuje również mistrze, układy, notatki oraz mistrze notatek i materiałów rozdawniczych, jeśli występują.

Raport zapisuje indeks slajdu zaczynający się od 1 oraz [getSlideId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getSlideId), gdy jest dostępny. [getSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getSlide) podaje slajd właściciela dla obsługiwanych kontenerów. Mistrze, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują swoją nazwę typu w czasie wykonywania. Każdy kontener otrzymuje raportowy identyfikator lokalny, aby jego dwie akcje mogły być powiązane. Raport przechowuje typy akcji jako stałe liczbowe zdefiniowane w wyliczeniu Javy.

Ta celowo restrykcyjna polityka aplikacji zezwala wyłącznie na bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdu. Odrzuca makra, programy, akcje plików, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Odmowy te są decyzjami politycznymi, a nie werdyktem bezpieczeństwa Aspose.Slides. Same HTTPS nie zapewniają zaufania: dodaj listy dozwolonych hostów i inne kontrole w aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL. Przykład audytuje metadane bez podążania za linkami i uruchamiania akcji.

W celu naprawy, [getHyperlinkManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getHyperlinkManager) obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) i [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i akcje najechania są usuwane niezależnie. Ustaw `replace_external_clicks` na `False`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania i wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. Jest to wskazówka przeglądu, a nie test zdolności ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-java/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/python-java/convert-powerpoint-to-png/) i [video](/slides/pl/python-java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Przy stworzonej powyżej danej wejściowej raport zawiera pięć wierszy akcji. Link najechania pliku i kliknięcie makra zostały usunięte, natomiast linki HTTPS oraz wewnętrzna nawigacja slajdu pozostały. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również uruchamia gałąź zastąpienia. Kontener z dozwolonym kliknięciem i zabronionym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), które usuwa oba typy aktywacji w wybranym zakresie bez względu na politykę. Weryfikacja tutaj sprawdza tylko akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie waliduje wyeksportowanego pliku PDF ani HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze kieruje do pojedynczego slajdu. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu‑mistrza, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu‑mistrza i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu na slajdach używających danego mistrza lub układu.

**Czy hiperłącza będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz rozważania eksportu w sekcji [Raport, Sanityzacja i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).