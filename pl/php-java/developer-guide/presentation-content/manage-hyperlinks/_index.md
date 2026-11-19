---
title: Zarządzaj hiperłączami prezentacji w PHP
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/php-java/manage-hyperlinks/
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
- PHP
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint oraz OpenDocument za pomocą Aspose.Slides dla PHP poprzez Java, wykorzystując przykłady w PHP."
---
## **Wprowadzenie**

Hiperłącze łączy zawartość prezentacji z witryną internetową lub lokalizacją w obrębie prezentacji. W programie PowerPoint hiperłącza zazwyczaj spełniają dwa cele:

* Otwierają witrynę internetową z tekstu, kształtu lub ramki multimedialnej.  
* Przejmują do innego slajdu, na przykład z spisu treści.

Aspose.Slides for PHP via Java umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej. Zakładają one, że PHP/Java Bridge oraz wrapper Aspose.Slides dla PHP są zainicjowane. Członkowie API bez strony referencyjnej PHP odwołują się do podstawowego API Javy.

{{% alert color="info" title="Uwaga" %}}
Możesz również edytować prezentacje przy użyciu [bezpłatnego edytora online Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL witryny do tekstu, kształtu lub ramki multimedialnej. Element, do którego przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy wybrany tekst, natomiast kształt lub ramka łączy cały obiekt slajdu.

W prezentacjach zawierających względne hiperłącza zobacz [Zarządzanie bazą hiperłączy](/slides/pl/php-java/presentation-properties/#manage-the-hyperlink-base), aby odczytać, zmienić lub wyczyścić bazę na poziomie dokumentu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst z witryną, przekaż obiekt [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) do metody [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

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

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Wywołaj metodę [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) na prostokącie, aby cały jego obszar stał się klikalny. Użyj [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) aby wyświetlić podpowiedź o miejscu docelowym, gdy użytkownik najeżdża myszką na prostokąt. Obie metody mają również zastosowanie do ramek obrazu, audio i wideo.

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

## **Użyj hiperłączy do utworzenia spisu treści**

Hiperłącza wewnętrzne pozwalają czytelnikom przeskoczyć ze spisu treści do określonego slajdu. Poniższy przykład używa [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) do połączenia tekstu „Strona 2” na pierwszym slajdzie z drugim slajdem.

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

## **Formatuj hiperłącza**

Możesz zmienić kolor połączonego tekstu, odtworzyć lub zatrzymać dźwięk po aktywacji linku oraz ustawić podpowiedź wyświetlaną po najechaniu.

### **Kolor**

Metoda [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) klasy [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcjonalność ta została wprowadzona w PowerPoint 2019; starsze wersje nie obsługują tego ustawienia.

W tym przykładzie metoda [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) sprawia, że pierwszy link używa czerwonego wypełnienia fragmentu tekstu. Drugi link zachowuje domyślny kolor hiperłącza prezentacji.

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

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj poniższych metod, aby skonfigurować te zachowania:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) określa dźwięk powiązany z hiperłączem.  
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Przycisk na pierwszym slajdzie używa [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) do odtworzenia audio z pliku `sampleaudio.wav`, gdy czytelnik kliknie, aby przejść dalej. Na drugim slajdzie oddzielny przycisk używa [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) do zatrzymania odtwarzania i pozostawienia czytelnika na tym slajdzie.

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

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci przy użyciu metod [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) oraz [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

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

### **Podpowiedź i ustawienia interakcji**

Po przypisaniu hiperłącza do tekstu lub kształtu możesz wywołać następujące metody klasy [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) ustawia tekst wyświetlany jako podpowiedź dla linku.  
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.  
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) kontroluje, czy aktywacja linku dodaje jego cel do listy przeglądanych hiperłączy.  
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) lub [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); usunięcie akcji kliknięcia nie usuwa odpowiedniej akcji po najechaniu.

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

Dla bezwarunkowego usunięcia metoda [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednocześnie. Aby przeprowadzić selektywne czyszczenie obejmujące mastery, układy i notatki, zobacz sekcję [Raportowanie, czyszczenie i weryfikacja hiperłącz](#report-sanitize-and-verify-hyperlinks).

### **Wyczyść hiperłącza przed zamianą tekstu SmartArt**

Podczas zamiany akapitu w istniejącym węźle SmartArt, czyszczenie jego fragmentów tekstu może pozostawić aktywne stare hiperłącze. Pobierz akapit za pomocą [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/). Przed wyczyszczeniem fragmentów wywołaj [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) na ramce tekstowej kształtu węzła wyświetlającego akapit, a następnie [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) na zwróconym obiekcie. Usuwa to wszystkie hiperłącza w tej ramce, w tym linki w innych akapitach.

Założeniem przykładu jest, że trzeci kształt na pierwszym slajdzie pliku `SmartArtHyperlink.pptx` jest grafiką SmartArt. Przykład zamienia pierwszy akapit czwartego węzła. W tej prezentacji pierwszy kształt węzła wyświetla ten akapit.

Po dodaniu obu fragmentów przykład odczytuje ich efektywne formatowanie za pomocą [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/). Dla tego formatowania metoda [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) zwraca nowe hiperłącze dla pierwszego fragmentu i `null` dla drugiego.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): drugi fragment nie ma hiperłącza.
} finally {
    $presentation->dispose();
}
```

## **Zbuduj kompletny spis hiperłączy**

Przed udostępnieniem prezentacji zinwentaryzuj jej interaktywne akcje oraz linki internetowe. Metoda [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Inspekcję należy przeprowadzić zarówno pod kątem [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) jak i [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba typy akcji, więc pełny raport wymaga do dwóch rekordów na kontener.

Skanowanie jedynie hiperłączy na poziomie kształtu może pominąć linki przypisane do fragmentów tekstu. Zapytaj o odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytania w zakresie prezentacji, slajdu i ramki tekstowej**

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) jest dostępna poprzez [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) i [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). Każdy zakres obsługuje te same zapytania:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) zwraca kontenery z akcją kliknięcia.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) zwraca kontenery z akcją najechania.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) zwraca kontenery z jedną lub obiema akcjami.

Ten przykład przypisuje akcje kliknięcia i najechania do kształtu i jego tekstu oraz akcję makra do oddzielnego przycisku. Porównuje liczbę kontenerów zwróconych przez [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) z licznościami dla poszczególnych typów aktywacji. Zapytanie ramki tekstowej liczy jedynie linki w tekście. Akcje samego kształtu pojawiają się w zapytaniach slajdu i prezentacji.

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

W tym przykładzie zapytania prezentacji i slajdu zwracają po trzy kontenery kliknięć, dwa kontenery najechań i trzy kontenery zawierające dowolną akcję. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i celów**

Użyj [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) aby zinterpretować akcję przed określeniem jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartość | Znaczenie w audycie |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Nawigacja wewnętrzna do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otworzenie pliku lub innej prezentacji; należy ocenić osobno od URL‑ów internetowych. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele za pomocą [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) oraz konkretne cele wewnętrzne za pomocą [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). Działania wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza braku akcji. Zachowaj wartość zwróconą przez [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) gdy różni się ona od znormalizowanego URL oraz dołącz podpowiedź zwróconą przez [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/), gdy jest dostępna.

### **Raportowanie, czyszczenie i weryfikacja hiperłącz**

Ten przykład otwiera prezentację z poprzedniego przykładu i zapisuje jeden rekord JSON na każdą akcję. Używa [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) do zebrania kontenerów na zwykłych slajdach, masterach, układach i notatkach, włączając mastery notatek i materiały rozdawane, jeśli istnieją. Zlicza każdy kontener raz, stosuje politykę opisaną poniżej i ponownie otwiera zapisaną prezentację, aby sprawdzić zarówno akcje kliknięcia, jak i najechania.

Raport zapisuje indeks slajdu (liczony od 1) oraz [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) tam, gdzie jest dostępny. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczane oddzielnie; inne typy kontenerów zachowują nazwę typu w czasie wykonania. Każdy kontener otrzymuje lokalny identyfikator raportowy, aby jego dwie akcje można było ze sobą skorelować. Raport przechowuje typy akcji jako stałe całkowite zdefiniowane w wyliczeniu PHP.

Ta celowo restrykcyjna polityka aplikacji dopuszcza jedynie bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Te odrzucenia są decyzjami politycznymi, a nie oceną bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dopuszczonych hostów i inne kontrole dla swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audytuje metadane bez podążania za linkami ani uruchamiania akcji.

W celu naprawy kontener [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) obsługuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) oraz [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i akcje najechania są usuwane oddzielnie. Ustaw `$replaceExternalClicks` na `false`, aby usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najechania i wszystko poza zewnętrznym linkiem lub konkretnym przeskokiem slajdu jako potencjalnie nieobsługiwane. To podpowiedź przeglądu, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/php-java/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [obrazy](/slides/pl/php-java/convert-powerpoint-to-png/) i [wideo](/slides/pl/php-java/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

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

Przy danych utworzonych powyżej raport zawiera pięć wierszy akcji. Link najechania na plik oraz makro kliknięcie są usunięte, podczas gdy linki HTTPS i wewnętrzna nawigacja slajdów pozostają. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również wywołuje gałąź zastąpienia. Kontener z dozwolonym kliknięciem i zabronionym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), które usuwa oba typy akcji w wybranym zakresie niezależnie od polityki. Weryfikacja tutaj sprawdza jedynie akcje hiperłącza; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w pojedynczy slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów mastera, aby działało na wszystkich slajdach?**

Tak. Elementy mastera i układu obsługują hiperłącza. Linki na tych elementach są dostępne w trakcie pokazu na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz rozważania eksportowe w sekcji [Raportowanie, czyszczenie i weryfikacja hiperłącz](#report-sanitize-and-verify-hyperlinks).