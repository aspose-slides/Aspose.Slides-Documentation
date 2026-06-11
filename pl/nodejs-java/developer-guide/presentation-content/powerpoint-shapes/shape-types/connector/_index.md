---
title: "Zarządzaj łącznikami w prezentacjach za pomocą JavaScript"
linktitle: "Łącznik"
type: docs
weight: 10
url: /pl/nodejs-java/connector/
keywords:
- "łącznik"
- "typ łącznika"
- "punkt łącznika"
- "linia łącznika"
- "kąt łącznika"
- "łączenie kształtów"
- "PowerPoint"
- "prezentacja"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Umożliw aplikacjom JavaScript rysowanie, łączenie i automatyczne wyznaczanie tras linii na slajdach PowerPoint — uzyskaj pełną kontrolę nad prostymi, łokciowymi i zakrzywionymi łącznikami."
---
## **Wprowadzenie**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przy nich przytwierdzona, nawet gdy są przesuwane lub zmieniane ich położenie na danym slajdzie. 

Łączniki są zazwyczaj podłączane do *punktów połączenia* (zielonych kropek), które domyślnie występują na wszystkich kształtach. Punkty połączenia pojawiają się, gdy kursor zbliży się do nich.

*Punkty dopasowania* (pomarańczowe kropki), które występują tylko w niektórych łącznikach, służą do modyfikacji pozycji i kształtu łączników.

## **Typy łączników**

W programie PowerPoint możesz używać łączników prostych, łokciowych (kątowych) i zakrzywionych. 

Aspose.Slides udostępnia następujące łączniki:

| Łącznik | Obraz | Liczba punktów dopasowania |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Łączenie kształtów przy użyciu łączników**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu przy pomocy jego indeksu.
1. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
1. Dodaj łącznik przy użyciu metody `addConnector` udostępnionej przez obiekt `Shapes`, definiując typ łącznika.
1. Połącz kształty przy pomocy łącznika. 
1. Wywołaj metodę `reroute`, aby zastosować najkrótszą ścieżkę połączenia.
1. Zapisz prezentację. 

Ten kod JavaScript pokazuje, jak dodać łącznik (zagięty łącznik) pomiędzy dwoma kształtami (elipsą i prostokątem):

```javascript
// Tworzy klasę prezentacji reprezentującą plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do kolekcji kształtów dla konkretnego slajdu
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Dodaje automatyczny kształt elipsy
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Dodaje automatyczny kształt prostokąta
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Łączy kształty przy użyciu łącznika
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Wywołuje metodę reroute, która ustawia automatyczną najkrótszą ścieżkę pomiędzy kształtami
    connector.reroute();
    // Zapisuje prezentację
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `Connector.reroute` przekierowuje łącznik i wymusza, aby przyjął najkrótszą możliwą ścieżkę pomiędzy kształtami. Aby osiągnąć ten cel, metoda może zmienić punkty `setStartShapeConnectionSiteIndex` i `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Określenie punktu połączenia**

Jeśli chcesz, aby łącznik łączył dwa kształty przy użyciu określonych punktów na kształtach, musisz w ten sposób określić preferowane punkty połączenia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu przy pomocy jego indeksu.
1. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
1. Dodaj łącznik przy użyciu metody `addConnector` udostępnionej przez obiekt `Shapes`, definiując typ łącznika.
1. Połącz kształty przy pomocy łącznika. 
1. Ustaw preferowane punkty połączenia na kształtach. 
1. Zapisz prezentację.

Ten kod JavaScript demonstruje operację, w której określono preferowany punkt połączenia:

```javascript
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do kolekcji kształtów dla konkretnego slajdu
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Dodaje automatyczny kształt elipsy
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Dodaje automatyczny kształt prostokąta
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Łączy kształty przy użyciu łącznika
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Ustawia preferowany indeks punktu połączenia na kształcie elipsy
    var wantedIndex = 6;
    // Sprawdza, czy preferowany indeks jest mniejszy niż maksymalna liczba indeksów punktów połączenia
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Ustawia preferowany punkt połączenia na automatycznym kształcie elipsy
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Zapisuje prezentację
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostosowanie punktu łącznika**

Możesz dostosować istniejący łącznik za pomocą jego punktów dopasowania. Tylko łączniki posiadające punkty dopasowania mogą być w ten sposób modyfikowane. Zobacz tabelę pod **[Typy łączników.](/slides/pl/nodejs-java/connector/#types-of-connectors)**

### **Prosty przypadek**

Rozważ przypadek, w którym łącznik pomiędzy dwoma kształtami (A i B) przechodzi przez trzeci kształt (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Aby uniknąć lub ominąć trzeci kształt, możemy dostosować łącznik, przesuwając jego pionową linię w lewo w następujący sposób:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Złożone przypadki** 

Aby wykonać bardziej skomplikowane dostosowania, musisz wziąć pod uwagę następujące kwestie:

* Punkt regulacyjny łącznika jest ściśle powiązany z formułą obliczającą i określającą jego położenie. Dlatego zmiany położenia punktu mogą zmienić kształt łącznika.
* Punkty dopasowania łącznika są definiowane w sztywnej kolejności w tablicy. Punkty dopasowania są numerowane od punktu początkowego łącznika do jego końcowego.
* Wartości punktów dopasowania odzwierciedlają procent szerokości/wysokości kształtu łącznika. 
  * Kształt jest ograniczony przez punkty początkowy i końcowy łącznika pomnożone przez 1000. 
  * Pierwszy punkt, drugi punkt i trzeci punkt określają odpowiednio procent z szerokości, procent z wysokości oraz ponownie procent z szerokości. 
* Przy obliczeniach określających współrzędne punktów dopasowania łącznika należy uwzględnić obrót łącznika oraz jego odbicie. **Uwaga**, że kąt obrotu dla wszystkich łączników pokazanych pod **[Typy łączników](/slides/pl/nodejs-java/connector/#types-of-connectors)** wynosi 0.

#### **Przypadek 1**

Rozważ przypadek, w którym dwa obiekty ramki tekstowej są połączone za pomocą łącznika:

```javascript
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var sld = pres.getSlides().get_Item(0);
    // Dodaje kształty, które zostaną połączone przy pomocy łącznika
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Dodaje łącznik
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Określa kierunek łącznika
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Określa kolor łącznika
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Określa grubość linii łącznika
    connector.getLineFormat().setWidth(3);
    // Łączy kształty razem za pomocą łącznika
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Pobiera punkty dopasowania dla łącznika
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Dostosowanie**

Możemy zmienić wartości punktów dopasowania łącznika, zwiększając odpowiednio procent szerokości o 20% i wysokości o 200%:

```javascript
// Zmienia wartości punktów dopasowania
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Wynik:

![connector-adjusted-1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający określenie współrzędnych i kształtu poszczególnych części łącznika, utwórzmy kształt odpowiadający poziomej składowej łącznika w punkcie connector.getAdjustments().get_Item(0):

```javascript
// Rysuje pionową składową łącznika
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Wynik:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Przypadek 2**

W **Przypadku 1** zademonstrowaliśmy prostą operację dostosowania łącznika przy użyciu podstawowych zasad. W normalnych sytuacjach należy uwzględnić obrót łącznika oraz jego wyświetlanie (ustawiane przez connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV()). Teraz pokażemy ten proces.

Najpierw dodajmy nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórzmy nowy (zielony) łącznik, który połączy go z już istniejącymi obiektami.

```javascript
// Tworzy nowy obiekt powiązania
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Tworzy nowy łącznik
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Łączy obiekty przy użyciu nowo utworzonego łącznika
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Pobiera punkty dopasowania łącznika
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Zmienia wartości punktów dopasowania
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Wynik:

![connector-adjusted-3](connector-adjusted-3.png)

Po drugie, utwórzmy kształt, który będzie odpowiadał poziomej składowej łącznika przechodzącej przez nowy punkt dopasowania connector.getAdjustments().get_Item(0). Użyjemy wartości z danych łącznika dla connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV() oraz zastosujemy popularną formułę konwersji współrzędnych dla obrotu wokół danego punktu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

W naszym przypadku kąt obrotu obiektu wynosi 90 stopni, a łącznik jest wyświetlany pionowo, więc odpowiedni kod wygląda tak:

```javascript
// Zapisuje współrzędne łącznika
x = connector.getX();
y = connector.getY();
// Koryguje współrzędne łącznika w razie potrzeby
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Pobiera wartość punktu dopasowania jako współrzędną
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Konwertuje współrzędne, ponieważ Sin(90) = 1 i Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Określa szerokość komponentu poziomego przy użyciu wartości drugiego punktu dopasowania
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Wynik:

![connector-adjusted-4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia dotyczące prostych dostosowań i skomplikowanych punktów dopasowania (punktów dopasowania z kątami obrotu). Korzystając z nabytej wiedzy, możesz opracować własny model (lub napisać kod), aby uzyskać obiekt `GraphicsPath` lub nawet ustawić wartości punktów dopasowania łącznika na podstawie konkretnych współrzędnych slajdu.

## **Znajdowanie kąta linii łącznika**

1. Utwórz instancję klasy.
1. Uzyskaj odniesienie do slajdu przy pomocy jego indeksu.
1. Uzyskaj dostęp do kształtu linii łącznika.
1. Użyj szerokości linii, wysokości, wysokości ramki kształtu i szerokości ramki kształtu, aby obliczyć kąt.

Ten kod JavaScript demonstruje operację, w której obliczyliśmy kąt dla kształtu linii łącznika:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do określonego kształtu?**

Sprawdź, czy kształt udostępnia [punkty połączenia](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Jeśli ich nie ma lub liczba wynosi zero, przyklejenie nie jest dostępne; w takim przypadku użyj wolnych końcówek i pozycjonuj je ręcznie. Warto sprawdzić liczbę punktów przed podłączeniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**

Jego końce zostaną odłączone; łącznik pozostaje na slajdzie jako zwykła linia z wolnymi początkiem i końcem. Możesz go usunąć lub ponownie przypisać połączenia i, w razie potrzeby, [przekierować](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/reroute/).

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu do innej prezentacji?**

Zazwyczaj tak, pod warunkiem że również zostaną skopiowane docelowe kształty. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce staną się wolne i będzie trzeba je ponownie podłączyć.