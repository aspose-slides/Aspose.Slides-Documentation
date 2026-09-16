---
title: Zarządzanie hiperłączami prezentacji w JavaScript
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/nodejs-java/manage-hyperlinks/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java, wykorzystując przykłady w JavaScript."
---
## **Wstęp**

Hiperłącze łączy zawartość prezentacji ze stroną internetową lub z lokalizacją w ramach samej prezentacji. W programie PowerPoint hiperłącza zazwyczaj spełniają dwa cele:

* Otworzyć stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejść do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for Node.js via Java umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz także edytować prezentacje za pomocą [bezpłatnego edytora online Aspose PowerPoint](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy zaznaczony tekst, natomiast kształt lub ramka łączy obiekt slajdu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst ze stroną internetową, przekaż [Hyperlink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink) do metody [setHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, wywołaj jej metodę [setHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setHyperlinkClick). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście dotyczy ramek obrazów, dźwięku i wideo: przypisz hiperłącze do ramki i wywołaj [setTooltip](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setTooltip), jeśli to konieczne.

Poniższy przykład sprawia, że prostokąt jest klikalny:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Użyj hiperłączy do utworzenia spisu treści**

Wewnętrzne hiperłącza pozwalają czytelnikom przeskoczyć ze spisu treści do konkretnego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick), aby połączyć tekst „Page 2” na pierwszym slajdzie z drugim slajdem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatuj hiperłącza**

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setColorSource) klasy [Hyperlink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink) określa, czy hiperłącze używa koloru hiperłącza prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkColorSource) i ustaw kolor wypełnienia fragmentu. Ta funkcja została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, natomiast drugie zachowuje domyślny kolor hiperłącza.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Dźwięk**

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj następujących metod, aby skonfigurować te zachowania:

- [Hyperlink.setSound](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setSound) określa dźwięk powiązany z hiperłączem.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci za pomocą [getSound](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getSound) i [getBinaryData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Ustawienia podpowiedzi i interakcji**

Możesz wywołać następujące metody [Hyperlink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink) po przypisaniu hiperłącza do tekstu lub kształtu:

- [setTooltip](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setTooltip) ustawia tekst, który czytelnik może wyświetlić jako podpowiedź do linku.
- [setTargetFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.
- [setHistory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setHistory) kontroluje, czy aktywacja linku dodaje jego cel do listy przeglądanych hiperłączy.
- [setHighlightClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks), aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj jedynie [removeHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); usunięcie akcji kliknięcia nie usuwa odpowiadającej akcji najechania myszą.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

W przypadku bezwarunkowego usuwania, [removeAllHyperlinks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Aby wykonać selektywne czyszczenie i obejmować mastery, układy i notatki, zobacz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj kompletną inwentaryzację hiperłączy**

Przed udostępnieniem prezentacji, zinwentaryzuj jej interaktywne akcje oraz linki internetowe. [getAnyHyperlinks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) zwraca kontenery hiperłączy, a nie płaską listę ciągów URL. Sprawdź zarówno [getHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getHyperlinkClick), jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba rodzaje akcji, więc kompletny raport wymaga do dwóch wierszy na kontener.

Skanowanie tylko hiperłączy na poziomie kształtu może pominąć linki dołączone do fragmentów tekstu. Zamiast tego zapytaj o odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries) jest dostępna przez [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) oraz [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) zwraca kontenery z akcją kliknięcia.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) zwraca kontenery z akcją najechania myszą.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem najechania myszy do pliku, wewnętrzną nawigacją slajdu, linkiem najechania myszy w tekscie oraz akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W tym przykładzie zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięć, dwa kontenery najechania myszą i trzy kontenery z jedną z akcji. Zapytanie ramki tekstowej zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i cele**

Użyj [Hyperlink.getActionType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getActionType), aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkActionType) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja w pokazie slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Wykonanie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otworzenie pliku lub innej prezentacji; przeglądać oddzielnie od adresów URL stron. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania mediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacji lub nieznana akcja wymagająca przeglądu. |

Czytaj zewnętrzne cele z [getExternalUrl](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) i konkretne wewnętrzne cele z [getTargetSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal), gdy różni się ona od znormalizowanego URL, oraz uwzględnij podpowiedź zwróconą przez [getTooltip](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#getTooltip), gdy jest dostępna.

### **Raportowanie, Sanityzacja i weryfikacja hiperłączy**

Poniższy przykład JavaScript odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa równości referencyjnej, aby uniknąć podwójnego przetwarzania tego samego kontenera. Zapytania prezentacji obejmują zwykłe slajdy; dla inwentaryzacji całego pakietu, wyraźnie zapytuje również mastery, układy, notatki oraz mastery notatek i ulotek, jeśli są obecne.

Raport zapisuje indeks slajdu liczony od jedynki oraz [getSlideId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BaseSlide#getSlideId), jeśli jest dostępny. [getSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getSlide) dostarcza slajdu właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i kontenery formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują swoją nazwę typu w czasie wykonania. Każdy kontener otrzymuje raportowy identyfikator lokalny, aby jego dwie akcje można było ze sobą skorelować. Raport przechowuje typy akcji jako stałe całkowite zdefiniowane w wyliczeniu HyperlinkActionType.

Ta celowo restrykcyjna polityka aplikacji zezwala wyłącznie na bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Odrzucenia te są decyzjami politycznymi, a nie werdyktem bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole w swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL. Przykład audytuje metadane bez podążania za linkami lub wykonywania akcji.

W celu naprawy, menedżer kontenera [getHyperlinkManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getHyperlinkManager) obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) i [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i zabronione akcje najechania myszy są usuwane niezależnie. Ustaw `replaceExternalClicks` na `false`, aby zamiast tego usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu w raporcie używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania myszy i wszystko poza zewnętrznym linkiem lub konkretnym przeskokiem slajdu jako potencjalnie nieobsługiwane. Jest to wskazówka przeglądowa, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rastry [images](/slides/pl/nodejs-java/convert-powerpoint-to-png/) i [video](/slides/pl/nodejs-java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Z wejściem utworzonym powyżej raport zawiera pięć wierszy akcji. Link najechania myszą do pliku i kliknięcie makra zostają usunięte, podczas gdy linki HTTPS i wewnętrzna nawigacja slajdu pozostają. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również testuje gałąź zamiany. Kontener z dozwolonym kliknięciem i zabronionym najechaniem myszy zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), które usuwa oba typy aktywacji w całym wybranym zakresie, niezależnie od polityki. Weryfikacja tutaj sprawdza wyłącznie akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze wskazuje konkretny slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu nadrzędnego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu nadrzędnego i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty do PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz uwagi dotyczące eksportu w sekcji [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).