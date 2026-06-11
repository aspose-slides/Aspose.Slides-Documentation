---
title: Zarządzanie kształtami prezentacji w PHP
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/php-java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- kształt na slajdzie
- znajdowanie kształtu
- klonowanie kształtu
- usuwanie kształtu
- ukrywanie kształtu
- zmiana kolejności kształtu
- pobieranie interop shape ID
- alternatywny tekst kształtu
- formaty układu kształtu
- kształt jako SVG
- kształt do SVG
- wyrównywanie kształtu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Naucz się tworzyć, edytować i optymalizować kształty w Aspose.Slides for PHP via Java oraz dostarczać wydajne prezentacje PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kształt na slajdzie, sklonować go, usunąć, ukryć, zmienić jego kolejność, uzyskać identyfikator Interop kształtu oraz ustawić tekst alternatywny w celu identyfikacji i dalszego przetwarzania.

Opisuje także, jak uzyskać dostęp do formatów układu dla kształtów, renderować kształt jako SVG, wyrównywać kształty na slajdzie oraz używać właściwości odbicia w poziomie i pionie. Dodatkowo artykuł zawiera krótkie FAQ dotyczące łączenia kształtów, kolejności warstw i blokowania kształtów.

## **Znajdowanie kształtu na slajdzie**
Ten temat opisuje prostą technikę ułatwiającą programistom znajdowanie konkretnego kształtu na slajdzie bez użycia jego wewnętrznego Id. Ważne jest, aby wiedzieć, że pliki prezentacji PowerPoint nie posiadają żadnego mechanizmu identyfikacji kształtów na slajdzie oprócz wewnętrznego unikalnego Id. Dla programistów może być trudne znalezienie kształtu przy użyciu tego Id. Wszystkie kształty dodane do slajdów mają jakiś tekst alternatywny. Zalecamy używanie tekstu alternatywnego do znajdowania konkretnego kształtu. Możesz użyć programu MS PowerPoint, aby określić tekst alternatywny dla obiektów, które planujesz zmieniać w przyszłości.

Po ustawieniu tekstu alternatywnego dowolnego kształtu możesz otworzyć prezentację przy użyciu Aspose.Slides for PHP via Java i przeiterować wszystkie kształty dodane do slajdu. Podczas każdej iteracji możesz sprawdzić tekst alternatywny kształtu, a kształt z pasującym tekstem alternatywnym będzie szukanym kształtem. Aby lepiej zilustrować tę technikę, stworzyliśmy metodę [findShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) wykonującą to zadanie i zwracającą znaleziony kształt.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Tekst alternatywny szukanego kształtu
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Klonowanie kształtu**
Aby sklonować kształt na slajdzie przy użyciu Aspose.Slides for PHP via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Pobierz referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu źródłowego.
1. Dodaj nowy slajd do prezentacji.
1. Sklonuj kształty z kolekcji kształtów slajdu źródłowego do nowego slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Zapisz plik PPTX na dysk
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuwanie kształtu**
Aspose.Slides for PHP via Java umożliwia programistom usunięcie dowolnego kształtu. Aby usunąć kształt z dowolnego slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Usuń kształt.
1. Zapisz plik na dysku.

```php
  # Utwórz obiekt Presentation
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj autokształt typu prostokąt
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Zapisz prezentację na dysk
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ukrywanie kształtu**
Aspose.Slides for PHP via Java umożliwia programistom ukrycie dowolnego kształtu. Aby ukryć kształt na dowolnym slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Ukryj kształt.
1. Zapisz plik na dysku.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj autokształt typu prostokąt
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Zapisz prezentację na dysk
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmiana kolejności kształtu**
Aspose.Slides for PHP via Java umożliwia programistom zmianę kolejności kształtów. Zmiana kolejności określa, który kształt znajduje się z przodu, a który z tyłu. Aby zmienić kolejność kształtu na dowolnym slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj kształt.
1. Dodaj tekst do ramki tekstowej kształtu.
1. Dodaj kolejny kształt o tych samych współrzędnych.
1. Zmień kolejność kształtów.
1. Zapisz plik na dysku.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Uzyskiwanie Interop Shape ID**
Aspose.Slides for PHP via Java umożliwia programistom uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do metody [getUniqueId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getuniqueid/), która zwraca unikalny identyfikator w zakresie prezentacji. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getofficeinteropshapeid/) została dodana do klasy [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/). Wartość zwracana przez [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getofficeinteropshapeid/) odpowiada Id obiektu Microsoft.Office.Interop.PowerPoint.Shape. Poniżej znajduje się przykładowy kod.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Pobieranie unikalnego identyfikatora kształtu w zakresie slajdu
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawianie tekstu alternatywnego dla kształtu**
Aspose.Slides for PHP via Java umożliwia programistom ustawienie AlternateText dowolnego kształtu.
Kształty w prezentacji mogą być rozróżniane za pomocą `Alternative Text` lub metody [Shape Name](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setname/).
Metody [setAlternativeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setalternativetext/) i [getAlternativeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getalternativetext/) mogą być odczytywane i ustawiane zarówno w Aspose.Slides, jak i w Microsoft PowerPoint.
Korzystając z tej metody, możesz oznaczyć kształt i wykonywać różne operacje, takie jak usuwanie, ukrywanie lub zmienianie kolejności kształtów na slajdzie.
Aby ustawić AlternateText kształtu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj dowolny kształt do slajdu.
1. Wykonaj potrzebne operacje na nowo dodanym kształcie.
1. Przejrzyj kształty, aby znaleźć żądany kształt.
1. Ustaw AlternativeText.
1. Zapisz plik na dysku.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj autokształt typu prostokąt
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Zapisz prezentację na dysk
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do formatów układu dla kształtu**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do uzyskiwania dostępu do formatów układu dla kształtu. Ten artykuł demonstruje, jak można uzyskać dostęp do formatów układu.

Poniżej znajduje się przykładowy kod.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Renderowanie kształtu jako SVG**
Teraz Aspose.Slides for PHP via Java wspiera renderowanie kształtu jako SVG. Do klasy [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) dodano metodę [writeAsSvg](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) (i jej przeciążenie). Metoda ta pozwala zapisać zawartość kształtu jako plik SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt slajdu do pliku SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyrównywanie kształtu**
Aspose.Slides umożliwia wyrównywanie kształtów względem krawędzi slajdu lub względem siebie nawzajem. W tym celu dodano przeciążoną metodę [SlidesUtil::alignShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/alignshapes/). Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapesalignmenttype/) definiuje dostępne opcje wyrównania.

**Example 1**

Poniższy kod wyrównuje kształty o indeksach 1,2 i 4 wzdłuż górnej krawędzi slajdu.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Example 2**

Przykład poniżej pokazuje, jak wyrównać całą kolekcję kształtów względem najniższego kształtu w kolekcji.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Właściwości odbicia**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym lustrzanym odbiciem kształtów za pomocą własności `flipH` i `flipV`. Obie własności są typu [NullableBool](https://reference.aspose.com/slides/pl/php-java/aspose.slides/nullablebool/) i mogą przyjmować wartości `True` (odwrócenie), `False` (brak odwrócenia) lub `NotDefined` (domyślne zachowanie). Wartości te są dostępne z obiektu [Frame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getFrame) kształtu.

Aby zmodyfikować ustawienia odbicia, tworzony jest nowy obiekt [ShapeFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/) z aktualną pozycją i rozmiarem kształtu, żądanymi wartościami `flipH` i `flipV` oraz kątem obrotu. Przypisanie tej instancji do właściwości [Frame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getFrame) kształtu i zapisanie prezentacji powoduje zastosowanie transformacji lustrzanej i zapisanie ich w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![The shape to be flipped](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odwraca go zarówno w poziomie, jak i w pionie.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Pobierz wartość odbicia w poziomie kształtu.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Pobierz wartość odbicia w pionie kształtu.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Odwróć poziomo.
    $flipV = NullableBool::True; // Odwróć poziomo.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Czy mogę łączyć kształty (union/intersect/subtract) na slajdzie tak, jak w edytorze desktopowym?**

Nie istnieje wbudowane API operacji logicznych. Możesz przybliżyć to, samodzielnie tworząc pożądany kontur — np. obliczając wynikową geometrię (przez [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/)) i tworząc nowy kształt z tym konturem, opcjonalnie usuwając oryginały.

**Jak kontrolować kolejność warstw (z‑order), aby kształt zawsze pozostawał „na wierzchu”?**

Zmieniaj kolejność wstawiania/przemieszczania w kolekcji [shapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getShapes) slajdu. Dla przewidywalnych rezultatów ustal z‑order po zakończeniu wszystkich pozostałych modyfikacji slajdu.

**Czy mogę „zablokować” kształt, aby użytkownicy nie mogli go edytować w PowerPoint?**

Tak. Ustaw flagi ochrony na poziomie kształtu (np. blokada zaznaczania, przemieszczania, zmiany rozmiaru, edycji tekstu). W razie potrzeby zastosuj ograniczenia na poziomie mastera lub układu. Należy pamiętać, że jest to ochrona na poziomie interfejsu UI, a nie mechanizm bezpieczeństwa; dla silniejszej ochrony połącz ją z zabezpieczeniami pliku, takimi jak rekomendacje trybu tylko do odczytu lub hasła.