---
title: Zarządzaj hiperłączami prezentacji na Androidzie
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/androidjava/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- aktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w środowisku Java, korzystając z przykładów w języku Java."
---
## **Wprowadzenie**

Hiperłącze łączy treść prezentacji ze stroną internetową lub lokalizacją w obrębie prezentacji. W PowerPoint hiperłącza zazwyczaj służą dwóm celom:

* Otworzyć stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejść do innego slajdu, na przykład z indeksu.

Aspose.Slides for Android via Java umożliwia dodawanie tych odnośników, kontrolowanie ich wyglądu i dźwięku, aktualizowanie właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz również edytować prezentacje za pomocą [darmowego edytora Aspose PowerPoint online](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu linkuje wybrany tekst, natomiast kształt lub ramka linkuje obiekt slajdu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst ze stroną internetową, przekaż [Hyperlink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/hyperlink/) do metody [setHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

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

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, wywołaj jego metodę [setHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście ma zastosowanie do ramek obrazu, audio i wideo: przypisz hiperłącze do ramki i w razie potrzeby wywołaj [setTooltip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

Poniższy przykład czyni prostokąt klikalnym:

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

## **Użyj hiperłączy do utworzenia spisu treści**

Wewnętrzne hiperłącza umożliwiają czytelnikom przeskoczenie z spisu treści do konkretnego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) do połączenia tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Formatuj hiperłącza**

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) interfejsu [IHyperlink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Ta funkcja została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, drugie zachowuje domyślny kolor hiperłącza.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj następujących metod, aby skonfigurować te zachowania:

- [IHyperlink.setSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) określa audio powiązane z hiperłączem.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i wiąże go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

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

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera prezentację utworzoną powyżej i odczytuje audio hiperłącza pierwszego kształtu do pamięci za pomocą [getSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getSound--) oraz [getBinaryData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Ustawienia podpowiedzi i interakcji**

Po przypisaniu hiperłącza do tekstu lub kształtu możesz wywołać następujące metody interfejsu [IHyperlink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/):

- [setTooltip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ustawia tekst, który widz może wyświetlić jako podpowiedź dla linku.
- [setTargetFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.
- [setHistory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) kontroluje, czy aktywacja linku dodaje jego docelowy adres do listy przeglądanych hiperłączy.
- [setHighlightClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); usunięcie akcji kliknięcia nie usuwa jej odpowiednika po najechaniu myszą.

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

Dla bezwarunkowego usunięcia, [removeAllHyperlinks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) usuwa oba typy aktywacji w wybranym zasięgu w jednym wywołaniu. Aby przeprowadzić selektywne czyszczenie oraz objąć misje, układy i notatki, zobacz [Raportowanie, sanitację i weryfikację hiperłączy](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj kompletny spis hiperłączy**

Przed udostępnieniem prezentacji, zinwentaryzuj jej interaktywne akcje oraz linki internetowe. [getAnyHyperlinks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdź zarówno [getHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba działania, więc pełny raport wymaga do dwóch wierszy na kontener.

Skany tylko na poziomie kształtów mogą pominąć linki dołączone do fragmentów tekstu. Zapytaj odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc aktualizować lub usuwać ich akcje.

### **Zapytania w zakresie prezentacji, slajdu i ramki tekstowej**

Interfejs [IHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/) jest dostępny poprzez [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), oraz [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) zwraca kontenery z akcją kliknięcia.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) zwraca kontenery z akcją najechania myszą.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem pliku przy najechaniu, wewnętrzną nawigacją slajdu, linkiem tekstowym przy najechaniu oraz akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumę akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

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

W tym przykładzie zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięcia, dwa kontenery najechania oraz trzy kontenery z dowolną akcją. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i docelowych miejsc**

Użyj [IHyperlink.getActionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getActionType--) aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację webową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otworzenie pliku lub innej prezentacji; analizuj oddzielnie od URL‑ów webowych. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania mediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nie rozpoznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele za pomocą [getExternalUrl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) oraz konkretne wewnętrzne cele za pomocą [getTargetSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) gdy różni się ona od znormalizowanego URL oraz uwzględnij podpowiedź zwróconą przez [getTooltip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) jeśli jest dostępna.

### **Raportowanie, sanitacja i weryfikacja hiperłączy**

Poniższy przykład w języku Java odczytuje istniejącą prezentację (użyj pliku utworzonego wyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera ją, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa równości referencyjnej, aby nie przetwarzać tego samego kontenera dwa razy. Zapytania prezentacji obejmują zwykłe slajdy; aby uzyskać inwentaryzację całego pakietu, zapytuje także wyraźnie mistrzy, układy, notatki oraz ich mistrze notatek i rozdania, gdy są dostępne.

Raport zapisuje indeks slajdu liczony od jedynki oraz [getSlideId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) tam, gdzie jest dostępny. [ISlideComponent.getSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecomponent/#getSlide--) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mistrze, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie wykonania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje mogły być skorelowane. Raport przechowuje typy akcji jako stałe liczbowe zdefiniowane w wyliczeniu Java.

Ta celowo restrykcyjna polityka aplikacji zezwala tylko na bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plików, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Te odrzucenia są decyzjami polityki, a nie werdyktem bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole dla twojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audytuje metadane bez podążania za linkami czy uruchamiania akcji.

Do naprawy, [getHyperlinkManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager-) kontenera obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) oraz [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i zabronione akcje najechania są usuwane osobno. Ustaw `replaceExternalClicks` na `false`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania oraz wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądu, a nie test możliwości lub gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/) mogą zachować hiperłącza, zależnie od akcji, opcji eksportu i przeglądarki. Rasterowe [obrazy](/slides/pl/androidjava/convert-powerpoint-to-png/) i [wideo](/slides/pl/androidjava/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
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
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
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
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

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

Przy wejściu utworzonym powyżej raport zawiera pięć wierszy akcji. Link pliku na najechanie i makro kliknięcia są usunięte, natomiast linki HTTPS i wewnętrzna nawigacja slajdu pozostają. Weryfikacja wypisuje zero niedozwolonych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia demonstruje również gałąź zastępowania. Kontener z dozwolonym kliknięciem i zabronionym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), które usuwa oba typy aktywacji w wybranym zakresie bez względu na politykę. Weryfikacja tutaj sprawdza jedynie akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej zawartości aktywnej i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w pojedynczy slajd. Aby utworzyć nawigację do sekcji, podlinkuj pierwszy slajd w tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu wzorcowego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu wzorcowego i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu na slajdach wykorzystujących dany wzorzec lub układ.

**Czy hiperłącza będą zachowane podczas eksportu do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz rozważania eksportowe w sekcji [Raportowanie, sanitacja i weryfikacja hiperłączy](#report-sanitize-and-verify-hyperlinks).