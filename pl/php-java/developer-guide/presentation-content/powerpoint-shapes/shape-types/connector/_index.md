---
title: "Zarządzanie łącznikami w prezentacjach przy użyciu PHP"
linktitle: "Łącznik"
type: docs
weight: 10
url: /pl/php-java/connector/
keywords:
- "łącznik"
- "typ łącznika"
- "punkt łącznika"
- "linia łącznika"
- "kąt łącznika"
- "łączenie kształtów"
- "PowerPoint"
- "prezentacja"
- "PHP"
- "Aspose.Slides"
description: "Umożliw aplikacjom PHP rysowanie, łączenie i automatyczne trasowanie linii w slajdach PowerPoint — uzyskaj pełną kontrolę nad prostymi, łokciowymi i zakrzywionymi łącznikami."
---
## **Wprowadzenie**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przy nich przytwierdzona nawet po ich przeniesieniu lub przemieszczeniu na danym slajdzie. 

Łączniki są zazwyczaj podłączane do *punktów połączeń* (zielonych kropek), które domyślnie istnieją na wszystkich kształtach. Punkty połączeń pojawiają się, gdy kursor zbliży się do nich.

*Punkty regulacji* (pomarańczowe kropki), które występują tylko w niektórych łącznikach, służą do modyfikowania pozycji i kształtów łączników.

## **Typy łączników**

W PowerPoint możesz używać łączników prostych, łokciowych (z kątem) i zakrzywionych. 

Aspose.Slides udostępnia następujące łączniki:

| Łącznik | Obraz | Liczba punktów regulacji |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Łączenie kształtów przy użyciu łączników**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu poprzez jego indeks.
3. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
4. Dodaj łącznik za pomocą metody `addConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
5. Połącz kształty przy użyciu łącznika. 
6. Wywołaj metodę `reroute`, aby zastosować najkrótszą ścieżkę połączenia.
7. Zapisz prezentację. 

Ten kod PHP pokazuje, jak dodać łącznik (łamany łącznik) między dwoma kształtami (elipsą i prostokątem):

```php
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do kolekcji kształtów dla określonego slajdu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Dodaje autokształt Elipsa
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Dodaje autokształt Prostokąt
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Dodaje kształt łącznika do kolekcji kształtów slajdu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Łączy kształty przy użyciu łącznika
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Wywołuje metodę reroute, która ustawia automatyczną najkrótszą ścieżkę pomiędzy kształtami
    $connector->reroute();
    # Zapisuje prezentację
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `Connector.reroute` przekierowuje łącznik i wymusza, aby przyjął najkrótszą możliwą ścieżkę między kształtami. Aby osiągnąć ten cel, metoda może zmienić punkty `setStartShapeConnectionSiteIndex` i `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Określenie punktu połączenia**

Jeśli chcesz, aby łącznik połączył dwa kształty za pomocą konkretnych punktów na tych kształtach, musisz określić preferowane punkty połączenia w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj odwołanie do slajdu poprzez jego indeks.
1. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
1. Dodaj łącznik za pomocą metody `addConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
1. Połącz kształty przy użyciu łącznika. 
1. Ustaw preferowane punkty połączenia na kształtach. 
1. Zapisz prezentację.

Ten kod PHP demonstruje operację, w której określony jest preferowany punkt połączenia:

```php
  # Tworzy instancję klasy prezentacji reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do kolekcji kształtów dla określonego slajdu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Dodaje autokształt Elipsa
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Dodaje autokształt Prostokąt
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Dodaje kształt łącznika do kolekcji kształtów slajdu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Łączy kształty przy użyciu łącznika
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Ustawia preferowany indeks punktu połączenia na kształcie Elipsa
    $wantedIndex = 6;
    # Sprawdza, czy preferowany indeks jest mniejszy niż maksymalna liczba indeksów punktów połączeń
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Ustawia preferowany punkt połączenia na autokształcie Elipsa
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Zapisuje prezentację
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Regulacja punktu łącznika**

Możesz regulować istniejący łącznik przy użyciu jego punktów regulacji. Tylko łączniki posiadające punkty regulacji mogą być w ten sposób modyfikowane. Zobacz tabelę pod **[Typy łączników.](/slides/pl/php-java/connector/#types-of-connectors)**

### **Prosty przypadek**

Rozważ przypadek, w którym łącznik między dwoma kształtami (A i B) przechodzi przez trzeci kształt (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Aby uniknąć lub ominąć trzeci kształt, możemy dostosować łącznik, przesuwając jego pionową linię w lewo w następujący sposób:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Złożone przypadki** 

Aby wykonać bardziej skomplikowane regulacje, musisz wziąć pod uwagę następujące kwestie:

* Punkt regulacji łącznika jest ściśle powiązany ze wzorem, który oblicza i określa jego pozycję. Dlatego zmiany położenia punktu mogą zmienić kształt łącznika.
* Punkty regulacji łącznika są definiowane w ścisłej kolejności w tablicy. Punkty regulacji są numerowane od punktu początkowego łącznika do jego końcowego.
* Wartości punktów regulacji odzwierciedlają procent szerokości/wysokości kształtu łącznika. 
  * Kształt jest ograniczony przez punkty początkowy i końcowy łącznika pomnożone przez 1000. 
  * Pierwszy punkt, drugi punkt i trzeci punkt określają odpowiednio procent z szerokości, procent z wysokości oraz ponownie procent z szerokości. 
* Dla obliczeń określających współrzędne punktów regulacji łącznika musisz uwzględnić rotację łącznika oraz jego odbicie. **Uwaga** że kąt rotacji wszystkich łączników pokazanych pod **[Typy łączników](/slides/pl/php-java/connector/#types-of-connectors)** wynosi 0.

#### **Przypadek 1**

Rozważ przypadek, w którym dwa obiekty ramki tekstowej są połączone za pomocą łącznika:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd w prezentacji
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaje kształty, które zostaną połączone łącznikiem
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Dodaje łącznik
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Określa kierunek łącznika
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Określa kolor łącznika
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Określa grubość linii łącznika
    $connector->getLineFormat()->setWidth(3);
    # Łączy kształty razem przy użyciu łącznika
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Pobiera punkty regulacji dla łącznika
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Regulacja**

Możemy zmienić wartości punktów regulacji łącznika, zwiększając odpowiednio procent szerokości o 20 % oraz wysokości o 200 %:

```php
  # Zmienia wartości punktów regulacji
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Wynik:

![connector-adjusted-1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający określenie współrzędnych i kształtu poszczególnych części łącznika, utwórzmy kształt odpowiadający poziomej składowej łącznika w punkcie connector.getAdjustments().get_Item(0):

```php
  # Rysuje pionową składową łącznika
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Wynik:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Przypadek 2**

W **Przypadku 1** przedstawiliśmy prostą operację regulacji łącznika wykorzystującą podstawowe zasady. W typowych sytuacjach musisz wziąć pod uwagę rotację łącznika oraz jego wyświetlanie (ustawiane przez connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV()). Teraz pokażemy proces.

Najpierw dodajmy nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórzmy nowy (zielony) łącznik, który łączy go z już utworzonymi obiektami.

```php
  # Tworzy nowy obiekt wiązania
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Tworzy nowy łącznik
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Łączy obiekty przy użyciu nowo utworzonego łącznika
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Pobiera punkty regulacji łącznika
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Zmienia wartości punktów regulacji
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Wynik:

![connector-adjusted-3](connector-adjusted-3.png)

Po drugie, utwórzmy kształt, który będzie odpowiadał poziomej składowej łącznika przechodzącej przez nowy punkt regulacji connector.getAdjustments().get_Item(0). Zastosujemy wartości z danych łącznika dla connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV() oraz popularny wzór konwersji współrzędnych dla rotacji wokół danego punktu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

W naszym przypadku kąt rotacji obiektu wynosi 90 stopni, a łącznik jest wyświetlany pionowo, więc odpowiadający kod wygląda następująco:

```php
  # Zapisuje współrzędne łącznika
  $x = $connector->getX();
  $y = $connector->getY();
  # Koryguje współrzędne łącznika w razie potrzeby
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Używa wartości punktu regulacji jako współrzędnej
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Konwertuje współrzędne, ponieważ Sin(90) = 1 i Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Określa szerokość poziomej składowej przy użyciu wartości drugiego punktu regulacji
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Wynik:

![connector-adjusted-4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia obejmujące proste regulacje oraz skomplikowane punkty regulacji (punkty regulacji z kątami rotacji). Korzystając z zdobytej wiedzy, możesz opracować własny model (lub napisać kod), aby uzyskać obiekt `GraphicsPath` lub nawet ustawić wartości punktów regulacji łącznika na podstawie konkretnych współrzędnych slajdu.

## **Znajdowanie kąta linii łącznika**

1. Utwórz instancję klasy.
1. Uzyskaj odwołanie do slajdu poprzez jego indeks.
1. Uzyskaj dostęp do kształtu linii łącznika.
1. Użyj szerokości i wysokości linii, wysokości ramki kształtu oraz szerokości ramki kształtu do obliczenia kąta.

Ten kod PHP demonstruje operację, w której obliczyliśmy kąt dla kształtu linii łącznika:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do konkretnego kształtu?**

Sprawdź, czy kształt udostępnia [punkty połączeń](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getconnectionsitecount/). Jeśli ich nie ma lub liczba wynosi zero, przyklejanie nie jest dostępne; w takim przypadku użyj wolnych końcówek i ustaw je ręcznie. Warto sprawdzić liczbę punktów przed ich przyłączeniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**

Jego końce zostaną odłączone; łącznik pozostanie na slajdzie jako zwykła linia z wolnym początkiem/końcem. Możesz go usunąć lub ponownie przypisać połączenia i w razie potrzeby [przekierować](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/reroute/).

**Czy połączenia łącznika są zachowywane przy kopiowaniu slajdu do innej prezentacji?**

Zasadniczo tak, pod warunkiem że docelowe kształty również zostaną skopiowane. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce stają się wolne i będzie trzeba je ponownie podłączyć.