---
title: Zarządzanie hiperłączami w prezentacji w Java
linktitle: Zarządzanie hiperłączami
type: docs
weight: 20
url: /pl/java/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatuj hiperłącze
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
- Java
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides for Java, przy użyciu przykładów w Javie."
---
## **Wprowadzenie**

Hiperłącze łączy zawartość prezentacji ze stroną internetową lub lokalizacją w ramach prezentacji. W programie PowerPoint hiperłącza zazwyczaj spełniają dwa cele:

* Otworzyć stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejść do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for Java pozwala dodawać te linki, kontrolować ich wygląd i dźwięk, aktualizować ich właściwości oraz usuwać je. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}

Możesz także edytować prezentacje za pomocą [bezpłatnego edytora Aspose PowerPoint online](https://products.aspose.app/slides/pl/editor).

{{% /alert %}} 

## **Dodawanie hiperłączy URL**

Możesz przypisać adres URL witryny do tekstu, kształtu lub ramki multimedialnej. Element, do którego przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy zaznaczony tekst, natomiast kształt lub ramka łączy obiekt slajdu.

### **Dodawanie hiperłączy URL do tekstu**

Aby połączyć tekst ze stroną internetową, przekaż obiekt [Hyperlink](https://reference.aspose.com/slides/pl/java/com.aspose.slides/hyperlink/) do metody [setHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) fragmentu tekstu, jak pokazano poniżej. Klikalny stanie się tylko ten fragment tekstu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dodawanie hiperłączy URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, wywołaj metodę [setHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) danego obiektu. Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście dotyczy ramek obrazu, dźwięku i wideo: przypisz hiperłącze do ramki i wywołaj [setTooltip](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) w razie potrzeby.

Poniższy przykład sprawia, że prostokąt jest klikalny:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Użycie hiperłączy do stworzenia spisu treści**

Wewnętrzne hiperłącza umożliwiają czytelnikom przeskok ze spisu treści do konkretnego slajdu. Poniższy przykład używa metody [setInternalHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) do połączenia tekstu „Strona 2” na pierwszym slajdzie z drugim slajdem.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatowanie hiperłączy**

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setColorSource-int-) interfejsu [IHyperlink](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/) określa, czy hiperłącze używa koloru hiperłącza z prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, a drugie zachowuje domyślny kolor hiperłącza.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Dźwięk**

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj poniższych metod, aby skonfigurować te zachowania:

- [IHyperlink.setSound](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) określa dźwięk powiązany z hiperłączem.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodanie dźwięku do hiperłącza**

Poniższy przykład wczytuje plik `sampleaudio.wav` i kojarzy go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując przy tym żadnej akcji nawigacyjnej.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Wyodrębnienie dźwięku z hiperłącza**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci przy użyciu metod [getSound](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getSound--) oraz [getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Podpowiedź (Tooltip) i ustawienia interakcji**

Po przypisaniu hiperłącza do tekstu lub kształtu możesz wywołać następujące metody interfejsu [IHyperlink](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/):

- [setTooltip](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ustawia tekst, który użytkownik może zobaczyć jako podpowiedź do linku.
- [setTargetFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, jeśli ma to zastosowanie.
- [setHistory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) kontroluje, czy aktywacja linku dodaje jego cel do listy przeglądanych hiperłączy.
- [setHighlightClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuwanie hiperłączy z prezentacji**

Użyj metody [getAnyHyperlinks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich modyfikacją. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); usunięcie akcji kliknięcia nie usuwa odpowiadającej jej akcji najechania myszą.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Do bezwarunkowego usunięcia, metoda [removeAllHyperlinks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) usuwa oba typy aktywacji w wybranym zakresie jednocześnie. Do selektywnego czyszczenia i objęcia masterów, układów i notatek zobacz sekcję [Raportowanie, czyszczenie i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).

## **Tworzenie pełnego spisu hiperłączy**

Przed rozpowszechnieniem prezentacji warto skatalogować jej interaktywne akcje oraz linki internetowe. Metoda [getAnyHyperlinks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/), a nie płaską listę łańcuchów URL. Przeglądaj zarówno [getHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) każdego kontenera. Są one niezależne: ten sam kontener może udostępniać obie akcje, więc pełny raport wymaga maksymalnie dwóch wierszy na kontener.

Skupianie się jedynie na hiperłączach poziomu kształtu może pominąć linki dołączone do fragmentów tekstu. Zapytaj o odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytania w zakresie prezentacji, slajdu i ramki tekstowej**

Interfejs [IHyperlinkQueries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/) jest dostępny przez [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) oraz [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) zwraca kontenery z akcją kliknięcia.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) zwraca kontenery z akcją najechania myszą.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy plik `hyperlink-audit-input.pptx` zawierający zewnętrzne hiperłącze kliknięcia, link pliku na najechanie, wewnętrzną nawigację po slajdach, link tekstowy na najechanie oraz akcję makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W tym przykładzie zapytania prezentacji i slajdu zwracają po trzy kontenery kliknięć, dwa kontenery najechań i trzy kontenery z jedną z akcji. Zapytanie ramki tekstowej zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i docelowych miejsc**

Użyj [IHyperlink.getActionType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getActionType--) aby zinterpretować akcję przed analizą jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/hyperlinkactiontype/) obejmują nie tylko nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otworzenie pliku lub innej prezentacji; przeglądaj oddzielnie od URL‑ów internetowych. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Zewnętrzne cele odczytuj za pomocą [getExternalUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getExternalUrl--) a konkretne cele wewnętrzne przez [getTargetSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Akcje wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza braku akcji w kontenerze. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) gdy różni się ona od znormalizowanego URL oraz uwzględnij podpowiedź zwróconą przez [getTooltip](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getTooltip--) jeśli jest dostępna.

### **Raportowanie, czyszczenie i weryfikacja hiperłączy**

Poniższy przykład w języku Java odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa porównania referencji, aby nie przetworzyć tego samego kontenera dwa razy. Zapytania prezentacji obejmują zwykłe slajdy; aby uzyskać inwentaryzację całego pakietu, explicite zapytuje także mastery, układy, notatki oraz mastery notatek i materiałów rozdających, gdy są obecne.

Raport zapisuje jednocześnie indeks slajdu (liczony od 1) oraz [getSlideId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getSlideId--) tam, gdzie jest dostępny. [ISlideComponent.getSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecomponent/#getSlide--) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane po ich zakresie. Kontenery kształtów i formatowania fragmentów tekstu są oznaczane oddzielnie; inne typy kontenerów zachowują nazwę typu w czasie wykonania. Każdy kontener otrzymuje lokalny identyfikator raportowy, aby jego dwie akcje mogły być ze sobą powiązane. Typy akcji są zapisywane jako stałe całkowite zdefiniowane w enumeracji Java.

Ta celowo restrykcyjna polityka aplikacji dopuszcza wyłącznie bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Odrzucenia wynikają z decyzji polityki, a nie z oceny bezpieczeństwa Aspose.Slides. Same HTTPS nie gwarantują zaufania: dodaj listy dozwolonych hostów i inne weryfikacje w swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audytuje metadane bez podążania za linkami ani uruchamiania akcji.

W ramach naprawy, metodą [getHyperlinkManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager-) kontenera można używać [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) oraz [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Tutaj zakazane zewnętrzne linki kliknięcia są zamieniane na stałą stronę docelową HTTPS; pozostałe zakazane kliknięcia i zakazane akcje najechania są usuwane niezależnie. Ustaw `replaceExternalClicks` na `false`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania oraz wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądu, a nie test zdolności ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/java/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [obrazy](/slides/pl/java/convert-powerpoint-to-png/) i [wideo](/slides/pl/java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych formatów wyjściowych.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serializuj płaskie wiersze tego raportu bez dodatkowej zależności JSON.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Przy danych wejściowych utworzonych powyżej raport zawiera pięć wierszy akcji. Link pliku na najechanie i makro kliknięcia są usuwane, natomiast linki HTTPS i wewnętrzna nawigacja slajdów pozostają. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zakazany zewnętrzny URL kliknięcia demonstracyjnie uruchamia gałąź zastępowania. Kontener z dozwolonym kliknięciem i zakazanym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od metody [removeAllHyperlinks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), która usuwa oba typy aktywacji w wybranym zakresie bez względu na politykę. Weryfikacja tutaj sprawdza wyłącznie akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej treści aktywnej, a także nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w pojedynczy slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu master, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu master i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz uwagi dotyczące eksportu w sekcji [Raportowanie, czyszczenie i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).