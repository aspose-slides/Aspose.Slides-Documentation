---
title: Zarządzaj polami tekstowymi w prezentacjach przy użyciu PHP
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/php-java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- zaktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz, identyfikuj, formatuj i aktualizuj pola tekstowe w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Wprowadzenie**

W Aspose.Slides dla PHP poprzez Java, tekst slajdu jest przechowywany w ramkach tekstowych, które należą do kształtów. Klasa [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia jego tekst poprzez metodę [AutoShape::getTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Każdy auto‑kształt dziedziczy po [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), ale nie każdy kształt jest auto‑kształtem ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji użyj `java_instanceof`, aby sprawdzić, czy kształt jest [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/), zanim uzyskasz dostęp do jego tekstu.
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj auto‑kształt do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Następujący przykład tworzy prostokątne pole tekstowe:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Współrzędne i wymiary przekazywane do [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) są mierzone w punktach. [AutoShape::addTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#addTextFrame) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzenie, czy kształt jest polem tekstowym**

Użyj metody [AutoShape::isTextBox](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#isTextBox), aby określić, czy auto‑kształt jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne auto‑kształty.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład sprawdza każdy auto‑kształt w prezentacji:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Nowo dodany auto‑kształt nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Możesz dostarczyć ten tekst za pomocą [AutoShape::addTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#addTextFrame) lub [TextFrame::setText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#setText). Dodanie lub przypisanie pustego łańcucha spowoduje, że [AutoShape::isTextBox](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#isTextBox) zwróci `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Pierwsze dwa wywołania wypisują `true`; ostatnie dwa wypisują `false`.

## **Znajdź kształt, który posiada ramkę tekstową**

Ogólny kod przetwarzający tekst może otrzymać [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj tylko‑do‑odczytu metody [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape), aby wrócić do jego właściciela – [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/).

Dla ramki tekstowej będącej własnością auto‑kształtu lub innego kształtu zawierającego tekst, [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape) zwraca właściciela, a [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell) zwraca `null`. Sprawdź zwróconą wartość przy pomocy `java_is_null`, zanim uzyskasz do niej dostęp. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, w tym kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/php-java/search-and-replace-text/).

## **Dodawanie kolumn do pola tekstowego**

Metoda [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setColumnCount) dzieli ramkę tekstową na kolumny, natomiast [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setColumnSpacing) ustawia odstęp między kolumnami w punktach. Oba ustawienia należą do [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/) i można je zmienić poprzez ramkę tekstową istniejącego pola tekstowego. Tekst przepływa między kolumnami wewnątrz tego samego kształtu; nie przechodzi do innego kształtu.

Poniższy przykład tworzy trzykolumnowe pole tekstowe z odstępem 10 punktów między kolumnami, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Wyodrębnianie tekstu z poszczególnych kolumn**

Użyj [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#splitTextByColumns), aby pobrać tekst przypisany do każdej widocznej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden łańcuch dla każdej kolumny, w kolejności odczytu kolumnowego. Ramka tekstowa z jedną kolumną zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym łańcuchem. Łańcuchy zawierają wyłącznie czysty tekst; formatowanie na poziomie fragmentów nie jest zachowywane.

Jest to przydatne, gdy potrzebujesz:

- Wyodrębnić tekst zachowując kolejność odczytu w kolumnach.
- Indeksować lub porównać zawartość wielokolumnowych slajdów.
- Eksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Sprawdzić, jak tekst jest redystrybuowany po zmianie liczby kolumn za pomocą [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setColumnCount), odstępu za pomocą [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setColumnSpacing), czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozmieszczony w bieżącym [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/); nie przepływa automatycznie tekstu między oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, dlatego upewnij się, że wymagane czcionki są dostępne, gdy istotna jest spójność wyników.

Poniższy przykład ładuje prezentację, znajduje pierwszy auto‑kształt wielokolumnowy z ramką tekstową, odczytuje skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do oddzielnego pliku. Kształty, które nie posiadają ramki tekstowej, są pomijane.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Aktualizacja tekstu**

Aby zaktualizować tekst w całej prezentacji, przeiteruj slajdy i kształty, wybierz auto‑kształty i edytuj ich fragmenty tekstu. Praca na poziomie fragmentów pozwala zmieniać zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zastępuje każde wystąpienie `years` słowem `months` w tekście auto‑kształtu i sprawia, że każdy zmieniony fragment jest pogrubiony:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ta iteracja aktualizuje tekst tylko w auto‑kształtach. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga iteracji ich własnych kolekcji.

## **Dodanie pola tekstowego z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, więc tylko ten fragment działa jako klikalny link. Użyj [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), aby powiązać fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem tekstowym na slajdzie master lub układu?**

[Placeholder](/slides/pl/php-java/manage-placeholder/) może dziedziczyć pozycję i formatowanie z [master slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) lub [layout slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przejmuje zachowania symbolu po zmianie układu.

**Jak mogę zamienić tekst bez zmiany tekstu w wykresach, tabelach lub SmartArt?**

Ogranicz iterację do obiektów [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/), jak pokazano w przykładzie Aktualizacja tekstu. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektów, więc nie są modyfikowane przez tę pętlę.