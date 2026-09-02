---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu PHP
linktitle: Zarządzanie polem tekstowym
type: docs
weight: 20
url: /pl/php-java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodawanie tekstu
- aktualizacja tekstu
- tworzenie pola tekstowego
- sprawdzanie pola tekstowego
- dodawanie kolumny tekstu
- dodawanie hiperłącza
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ułatwia tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for PHP via Java udostępnia klasę [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) umożliwiającą dodanie kształtu zawierającego tekst.

{{% alert title="Info" color="info" %}}

Aspose.Slides udostępnia również klasę [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) , która pozwala dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane za pomocą klasy `Shape` mogą zawierać tekst. Natomiast kształty dodane za pomocą klasy [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) mogą zawierać tekst.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Dlatego, pracując z kształtem, do którego chcesz dodać tekst, powinieneś sprawdzić i potwierdzić, że został on rzutowany przy użyciu klasy `AutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), która jest właściwością klasy `AutoShape`. Zobacz sekcję [Update Text](/slides/pl/php-java/manage-textbox/#update-text) na tej stronie.

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) z typem kształtu ustawionym na [Rectangle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapetype/#Rectangle) w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu `AutoShape`.
4. Dodaj `TextFrame` do obiektu `AutoShape`, które będzie zawierało tekst. W poniższym przykładzie dodaliśmy następujący tekst: *Aspose TextBox*
5. Na koniec zapisz plik PPTX za pomocą obiektu `Presentation`. 

Ten kod PHP — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```php
  # Tworzy instancję Presentation
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd w prezentacji
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaje AutoShape z typem ustawionym na Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Dodaje TextFrame do prostokąta
    $ashp->addTextFrame(" ");
    # Uzyskuje dostęp do ramki tekstowej
    $txtFrame = $ashp->getTextFrame();
    # Tworzy obiekt Paragraph dla ramki tekstowej
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Tworzy obiekt Portion dla akapitu
    $portion = $para->getPortions()->get_Item(0);
    # Ustawia tekst
    $portion->setText("Aspose TextBox");
    # Zapisuje prezentację na dysku
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [isTextBox](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/istextbox/) z klasy [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) , pozwalającą badać kształty i identyfikować pola tekstowe.

![Pole tekstowe i kształt](istextbox.png)

Ten kod PHP pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Zauważ, że jeśli po prostu dodasz autoshape za pomocą metody `addAutoShape` z klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/) , metoda `isTextBox` autoshape zwróci `false`. Jednak po dodaniu tekstu do autoshape przy użyciu metody `addTextFrame` lub `setText`, właściwość `isTextBox` zwróci `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() zwraca false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() zwraca true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() zwraca false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() zwraca true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() zwraca false
$shape3->addTextFrame("");
// shape3->isTextBox() zwraca false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() zwraca false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() zwraca false
```

## **Znajdź kształt, który jest właścicielem ramki tekstowej**

W ogólnym kodzie przetwarzania tekstu możesz otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj metody [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape) , aby przejść z powrotem do właściciela, czyli [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/).

Dla ramki tekstowej należącej do [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) lub innego kształtu zawierającego tekst, [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape) zwraca właściciela, a [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell) zwraca `null`. Obie metody zapewniają nawigację tylko do odczytu, więc ich wywołanie nie zmienia własności. Zawsze sprawdzaj zwróconą wartość za pomocą `java_is_null` przed dostępem do kształtu.

Pełny przykład identyfikujący właścicieli kształtów i komórek tabel, w tym kształty powiązane z węzłami SmartArt, znajdziesz w sekcji [Search and Replace Text](/slides/pl/php-java/search-and-replace-text/).

## **Dodawanie kolumn do pola tekstowego**

Aspose.Slides udostępnia metody [setColumnCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setcolumncount/) i [setColumnSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setcolumnspacing/) z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/) , które umożliwiają dodawanie kolumn do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz ustawić odstęp między kolumnami wyrażony w punktach.

Ten kod demonstruje opisane działanie:

```php
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd w prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaje AutoShape z typem ustawionym na Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Dodaje TextFrame do prostokąta
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Pobiera format tekstu z TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Określa liczbę kolumn w TextFrame
    $format->setColumnCount(3);
    # Określa odstęp między kolumnami
    $format->setColumnSpacing(10);
    # Zapisuje prezentację
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodawanie kolumn do ramki tekstowej**

Aspose.Slides for PHP via Java udostępnia metodę [setColumnCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setcolumncount/) z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/) , która pozwala dodać kolumny w ramkach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej.

Ten kod PHP pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aktualizacja tekstu**

Aspose.Slides umożliwia zmianę lub aktualizację tekstu zawartego w polu tekstowym lub wszystkich tekstów zawartych w prezentacji. 

Ten kod PHP demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Sprawdza czy kształt obsługuje ramkę tekstową (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Iteruje przez akapity w ramce tekstowej
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Iteruje przez każdy fragment w akapicie
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Zmienia tekst

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Zmienia formatowanie

            }
          }
        }
      }
    }
    # Zapisuje zmodyfikowaną prezentację
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodanie pola tekstowego z hiperłączem** 

Możesz wstawić odnośnik wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy są kierowani do otwarcia odnośnika. 

Aby dodać pole tekstowe zawierające odnośnik, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu AutoShape.
4. Dodaj `TextFrame` do obiektu `AutoShape`, które zawiera *Aspose TextBox* jako domyślny tekst. 
5. Zainicjuj klasę `HyperlinkManager`. 
6. Przypisz odnośnik za pomocą metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) powiązanej z wybraną częścią `TextFrame`.
7. Na koniec zapisz plik PPTX za pomocą obiektu `Presentation`. 

Ten kod PHP — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd w prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaje obiekt AutoShape z typem ustawionym na Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Rzutuje kształt na AutoShape
    $pptxAutoShape = $shape;
    # Uzyskuje dostęp do właściwości ITextFrame powiązanej z AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Dodaje tekst do ramki
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Ustawia hiperłącze dla tekstu fragmentu
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Zapisuje prezentację PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a tekstowym placeholderem podczas pracy z master slajdami?**

Placeholder ([placeholder](/slides/pl/php-java/manage-placeholder/)) dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) i może być nadpisany w [układach](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie modyfikując tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do autoshapes, które posiadają ramki tekstowe, i wyklucz obiekty osadzone ([charts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/)), przeglądając ich kolekcje osobno lub pomijając te typy obiektów.