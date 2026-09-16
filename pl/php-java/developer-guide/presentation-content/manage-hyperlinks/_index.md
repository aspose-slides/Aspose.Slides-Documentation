---
title: Zarządzanie odnośnikami w prezentacji w PHP
linktitle: Zarządzanie odnośnikami
type: docs
weight: 20
url: /pl/php-java/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj odnośnik
- utwórz odnośnik
- formatuj odnośnik
- usuń odnośnik
- aktualizuj odnośnik
- odnośnik tekstowy
- odnośnik slajdu
- odnośnik kształtu
- odnośnik obrazu
- odnośnik wideo
- zmienny odnośnik
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj odnośniki w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java, korzystając z przykładów w PHP."
---
## **Wprowadzenie**

Odnośnik hipertekstowy łączy zawartość prezentacji ze stroną internetową lub lokalizacją w obrębie prezentacji. W programie PowerPoint odnośniki hipertekstowe zazwyczaj spełniają dwie funkcje:

* Otwieranie strony internetowej z tekstu, kształtu lub ramki multimedialnej.
* Przejście do innego slajdu, na przykład z tabeli treści.

Aspose.Slides for PHP via Java umożliwia dodawanie tych odnośników, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z odnośnikami na pojedynczych elementach oraz jak uzyskać dostęp do odnośników na poziomie prezentacji, slajdu lub ramki tekstowej. Zakładają, że PHP/Java Bridge i wrapper Aspose.Slides PHP są zainicjowane. Członkowie API bez strony odwołania PHP linkują do odpowiedniego API Java.

{{% alert color="info" title="Note" %}}
Możesz także edytować prezentacje za pomocą [darmowego edytora online Aspose PowerPoint](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodawanie odnośników URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, do którego przypisujesz odnośnik, określa obszar klikalny: fragment tekstu linkuje zaznaczony tekst, natomiast kształt lub ramka linkuje obiekt slajdu.

### **Dodawanie odnośników URL do tekstu**

Aby połączyć tekst ze stroną internetową, przekaż [Hyperlink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/) metodzie [setHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/sethyperlinkclick/) fragmentu tekstu, jak pokazano poniżej. Klikalny będzie tylko ten fragment tekstu.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Dodawanie odnośników URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, wywołaj ich metodę [setHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/sethyperlinkclick/). Odnośnik należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście obowiązuje dla ramek obrazów, dźwięku i wideo: przypisz odnośnik do ramki i wywołaj [setTooltip](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/settooltip/), jeśli jest to potrzebne.

Poniższy przykład czyni prostokąt klikalnym:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Używanie odnośników do tworzenia tabeli treści**

Odnośniki wewnętrzne pozwalają czytelnikom przeskakiwać z tabeli treści do określonego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) do połączenia tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Formatowanie odnośników**

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/setcolorsource/) klasy [Hyperlink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/) określa, czy odnośnik używa koloru odnośnika prezentacji, czy formatowania fragmentu tekstu. Aby zastosować niestandardowy kolor tekstu, wybierz [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa odnośniki tekstowe do tego samego slajdu. Pierwszy używa czerwonego wypełnienia tekstu, drugi zachowuje domyślny kolor odnośnika.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Dźwięk**

Odnośnik może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj poniższych metod, aby skonfigurować te zachowania:

- [Hyperlink::setSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/setsound/) określa dźwięk powiązany z odnośnikiem.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/setstopsoundonclick/) kontroluje, czy aktywacja odnośnika zatrzymuje poprzedni dźwięk.

#### **Dodawanie dźwięku do odnośnika**

Poniższy przykład wczytuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do kolejnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacyjnej.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Wyodrębnianie dźwięku z odnośnika**

Poniższy przykład otwiera prezentację utworzoną powyżej i odczytuje dźwięk odnośnika pierwszego kształtu do pamięci za pomocą [getSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/getsound/) i [getBinaryData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Etykieta podpowiedzi i ustawienia interakcji**

Po przypisaniu odnośnika do tekstu lub kształtu możesz wywołać następujące metody klasy [Hyperlink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/settooltip/) ustawia tekst, który przeglądający może wyświetlić jako podpowiedź dla odnośnika.
- [setTargetFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/settargetframe/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.
- [setHistory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/sethistory/) kontroluje, czy aktywacja odnośnika dodaje jego docelowy adres do listy przeglądanych odnośników.
- [setHighlightClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/sethighlightclick/) kontroluje, czy odnośnik jest podświetlany po kliknięciu.

## **Usuwanie odnośników z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) aby zebrać kontenery odnośników, w tym odnośniki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); usunięcie akcji kliknięcia nie usuwa odpowiednika po najechaniu myszy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Do bezwarunkowego usunięcia, [removeAllHyperlinks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Do selektywnego czyszczenia i objęcia mistrzów, układów i notatek zobacz sekcję [Raportowanie, czyszczenie i weryfikacja odnośników](#report-sanitize-and-verify-hyperlinks).

## **Tworzenie pełnego spisu odnośników**

Przed dystrybucją prezentacji, zinwentaryzuj jej interaktywne akcje oraz linki internetowe. [getAnyHyperlinks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdź zarówno [getHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba działania, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie jedynie odnośników na poziomie kształtu może pominąć linki przypisane do fragmentów tekstu. Zamiast tego zapytaj o odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytania o zakresy prezentacji, slajdu i ramki tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/) jest dostępna przez [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), oraz [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/gethyperlinkqueries/). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) zwraca kontenery z akcją kliknięcia.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) zwraca kontenery z akcją najechania myszy.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem pliku po najechaniu, wewnętrzną nawigacją slajdu, linkiem tekstowym po najechaniu oraz akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumę akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

W tym przykładzie zapytania prezentacji i slajdu każdy zwracają trzy kontenery kliknięcia, dwa kontenery najechania oraz trzy kontenery z dowolną akcją. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i docelowych adresów**

Użyj [Hyperlink::getActionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/getactiontype/) aby zinterpretować akcję przed interpretacją jej docelowego adresu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzny odnośnik; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub rozpoczęcie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otworzenie pliku lub innej prezentacji; analizuj oddzielnie od URL‑ów internetowych. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele za pomocą [getExternalUrl](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/getexternalurl/) oraz konkretne wewnętrzne cele za pomocą [getTargetSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/gettargetslide/). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza braku akcji w kontenerze. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) gdy różni się od znormalizowanego URL i dołącz etykietę podpowiedzi zwróconą przez [getTooltip](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/gettooltip/), jeśli jest dostępna.

### **Raportowanie, czyszczenie i weryfikacja odnośników**

Poniższy przykład PHP odczytuje istniejącą prezentację (użyj pliku stworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera ją, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa równości referencji, aby nie przetwarzać tego samego kontenera dwa razy. Zapytania prezentacji obejmują zwykłe slajdy; aby uzyskać inwentaryzację całego pakietu, zapytania explicite obejmują także mistrzów, układy, notatki oraz mistrzów notatek i rozdania, jeśli są obecne.

Raport zapisuje indeks slajdu zaczynający się od 1 oraz [getSlideId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getSlideId--) gdy jest dostępny. [ISlideComponent::getSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecomponent/#getSlide--) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mistrze, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone oddzielnie; inne typy kontenerów zachowują nazwę typu w czasie działania. Każdy kontener otrzymuje lokalny identyfikator raportowy, aby dwie jego akcje mogły zostać skorelowane. Raport przechowuje typy akcji jako stałe liczbowe zdefiniowane w wyliczeniu PHP.

Ta celowo restrykcyjna polityka aplikacji zezwala tylko na bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Te odrzuty są decyzjami polityki, a nie werdyktem bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole dla swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL. Przykład audytuje metadane bez podążania za linkami ani uruchamiania akcji.

W celu naprawy, [getHyperlinkManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) kontenera obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) oraz [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i zabronione akcje po najechaniu są usuwane samodzielnie. Ustaw `$replaceExternalClicks` na `false`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje po najechaniu oraz wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. To jest wskazówka przeglądu, a nie test zdolności lub gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/php-java/convert-powerpoint-to-html/) mogą zachować odnośniki, zależnie od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/php-java/convert-powerpoint-to-png/) i [video](/slides/pl/php-java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych odnośników; oznacz każdą akcję przy audycie dla tych wyjść.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Przy danych wejściowych stworzonych powyżej, raport zawiera pięć wierszy akcji. Link pliku po najechaniu i makro‑klik zostają usunięte, natomiast linki HTTPS i wewnętrzna nawigacja slajdu pozostają. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również uruchamia gałąź zastąpienia. Kontener z dozwolonym kliknięciem i zabronionym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), które usuwa oba typy aktywacji w wybranym zakresie niezależnie od polityki. Weryfikacja tutaj sprawdza jedynie akcje odnośników; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale odnośnik wewnętrzny wskazuje indywidualny slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem w tej sekcji.

**Czy mogę dołączyć odnośnik do elementów slajdu-mistrza, aby działał na wszystkich slajdach?**

Tak. Elementy slajdu‑mistrza i układu obsługują odnośniki. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach używających odpowiedniego mistrza lub układu.

**Czy odnośniki będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować odnośniki; obrazy rastrowe i wideo nie mogą. Zobacz uwagi dotyczące eksportu w sekcji [Raportowanie, czyszczenie i weryfikacja odnośników](#report-sanitize-and-verify-hyperlinks).