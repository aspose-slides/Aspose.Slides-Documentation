---
title: Zarządzanie hiperłączami prezentacji w Pythonie przy użyciu Java
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
- hiperłącze modyfikowalne
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona za pośrednictwem Java, korzystając z przykładów w Pythonie."
---
## **Wprowadzenie**

Hiperłącze łączy zawartość prezentacji z witryną internetową lub miejscem w obrębie prezentacji. W programie PowerPoint hiperłącza zazwyczaj służą dwóm celom:

* Otworzyć witrynę z tekstu, kształtu lub ramki multimedialnej.  
* Przejść do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for Python via Java umożliwia dodawanie tych łączy, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}

Możesz także edytować prezentacje przy użyciu [darmowego edytora Aspose PowerPoint online](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL witryny do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypisujesz hiperłącze, określa obszar klikalny: fragment tekstu łączy wybrany tekst, a kształt lub ramka łączy obiekt slajdu.

W prezentacjach zawierających względne hiperłącza zobacz [Zarządzanie bazą hiperłączy](/slides/pl/python-java/presentation-properties/#manage-the-hyperlink-base), aby odczytać, zmienić lub wyczyścić bazę na poziomie dokumentu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst z witryną, przekaż [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) do metody [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) fragmentu tekstu, jak pokazano poniżej. Klikalny stanie się tylko ten fragment tekstu.

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

Aby uczynić kształt lub ramkę klikalną, wywołaj jej metodę [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

Takie samo podejście stosuje się do ramek obrazu, audio i wideo: przypisz hiperłącze do ramki i wywołaj [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip), jeśli jest to potrzebne.

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

Hiperłącza wewnętrzne pozwalają czytelnikom przejść z tabeli treści do konkretnego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick), aby połączyć tekst „Page 2” na pierwszym slajdzie z drugim slajdem.

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

Metoda [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) klasy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, a drugie zachowuje domyślny kolor hiperłącza.

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

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) określa dźwięk powiązany z hiperłączem.  
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład wczytuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym samym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

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

Poniższy przykład otwiera prezentację utworzoną powyżej i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci przy użyciu [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) oraz [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

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

Po przypisaniu hiperłącza do tekstu lub kształtu możesz wywołać następujące metody klasy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) ustawia tekst, który podglądający może wyświetlić jako wskazówkę do łącza.  
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.  
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) kontroluje, czy aktywacja łącza dodaje jego docelowy adres do listy przeglądanych hiperłączy.  
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks), aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba rodzaje aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); usunięcie akcji kliknięcia nie usuwa jej odpowiednika przy najechaniu myszą.

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

Dla bezwarunkowego usunięcia, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) usuwa oba rodzaje aktywacji w wybranym zakresie w jednym wywołaniu. Dla selektywnego czyszczenia i obejmowania masterów, układów i notatek, zobacz [Raport, oczyszczenie i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj pełny inwentarz hiperłącz**

Przed rozpowszechnieniem prezentacji zinwentaryzuj jej interaktywne akcje oraz linki internetowe. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) zwraca kontenery hiperłączy, takie jak obiekty [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) i [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), a nie płaską listę ciągów URL. Sprawdź zarówno [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick), jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba działania, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie tylko hiperłącz na poziomie kształtu może pominąć linki dołączone do fragmentów tekstu. Zapytaj odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) jest dostępna poprzez [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) oraz [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) zwraca kontenery z akcją kliknięcia.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) zwraca kontenery z akcją najechania myszą.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` zewnętrznym linkiem kliknięcia, linkiem pliku przy najechaniu, wewnętrzną nawigacją slajdu, linkiem tekstowym przy najechaniu oraz akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

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

W tym przykładzie zapytania prezentacji i slajdu zwracają po trzy kontenery kliknięcia, dwa kontenery najechania i trzy kontenery z dowolną akcją. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i cele**

Użyj [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType), aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otwarcie pliku lub innej prezentacji; przeglądaj oddzielnie od URL‑ów internetowych. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele przy użyciu [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) oraz konkretne wewnętrzne cele przy użyciu [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Akcje wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal), gdy różni się od znormalizowanego URL, oraz dołącz podpowiedź z [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip), jeśli jest dostępna.

### **Raport, oczyszczenie i weryfikacja hiperłączy**

Poniższy przykład w Pythonie odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i wykorzystuje równość referencji, aby uniknąć podwójnego przetworzenia tego samego kontenera. Zapytania prezentacji obejmują zwykłe slajdy; dla inwentaryzacji całego pakietu wyraźnie zapytuje także mastery, układy, notatki oraz mastery notatek i materiałów rozdawniczych, gdy są obecne.

Raport zapisuje indeks slajdu (liczony od 1) oraz [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId), gdy jest dostępny. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie wykonania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje mogły być ze sobą powiązane. Raport przechowuje typy akcji jako stałe liczbowe zdefiniowane w enumeracji Java.

Ta celowo restrykcyjna polityka aplikacji dopuszcza wyłącznie bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Są to decyzje polityki, a nie ocena bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole dla swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audytuje metadane bez podążania za linkami i bez uruchamiania akcji.

Do naprawy kontenerów [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) i [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Tutaj niedozwolone zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne niedozwolone kliknięcia i akcje przy najechaniu są usuwane niezależnie. Ustaw `replace_external_clicks` na `False`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje przy najechaniu i wszystko poza zewnętrznym linkiem lub określonym skokiem slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądu, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-java/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/python-java/convert-powerpoint-to-png/) i [video](/slides/pl/python-java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

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

Z utworzonego wyżej wejścia raport zawiera pięć wierszy akcji. Link pliku przy najechaniu i makroklik zostają usunięte, natomiast linki HTTPS i wewnętrzna nawigacja slajdu pozostają. Weryfikacja wypisuje zero niedozwolonych akcji. Wejście zawierające niedozwolony zewnętrzny URL kliknięcia również uruchamia gałąź zastąpienia. Kontener z dozwolonym kliknięciem i niedozwolonym najechaniem zachowuje akcji kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), które usuwa oba typy aktywacji w wybranym zakresie, niezależnie od polityki. Weryfikacja tutaj sprawdza jedynie akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innych treści aktywnych i nie weryfikuje wyeksportowanego pliku PDF ani HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w pojedynczy slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu głównego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu głównego i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz rozważania dotyczące eksportu w [Raport, oczyszczenie i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).