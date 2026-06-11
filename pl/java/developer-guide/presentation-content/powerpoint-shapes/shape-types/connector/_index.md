---
title: "Zarządzanie łącznikami w prezentacjach przy użyciu Javy"
linktitle: "Łącznik"
type: docs
weight: 10
url: /pl/java/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- łączenie kształtów
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Umożliw aplikacjom Java rysowanie, łączenie i automatyczne wyznaczanie tras linii w slajdach PowerPoint — uzyskaj pełną kontrolę nad prostymi, łokciowymi i zakrzywionymi łącznikami."
---
## **Wstęp**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przy nich przytwierdzona, nawet gdy są przemieszczane lub zmieniane ich położenie na danym slajdzie. 

Łączniki są zazwyczaj podłączane do *punktów połączenia* (zielonych kropek), które domyślnie występują we wszystkich kształtach. Punkty połączenia pojawiają się, gdy kursor zbliży się do nich.

*Punkty regulacji* (pomarańczowe kropki), które istnieją tylko w niektórych łącznikach, służą do modyfikacji położenia i kształtu łączników.

## **Typy łączników**

W programie PowerPoint możesz używać łączników prostych, łokciowych (kątowych) i zakrzywionych. 

Aspose.Slides udostępnia następujące łączniki:

| Łącznik                      | Image                                                        | Liczba punktów regulacji |
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

## **Łączenie kształtów za pomocą łączników**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj dwie [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
4. Dodaj łącznik przy użyciu metody `addConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
5. Połącz kształty przy użyciu łącznika. 
6. Wywołaj metodę `reroute`, aby zastosować najkrótszą ścieżkę połączenia.
7. Zapisz prezentację. 

Ten kod Java pokazuje, jak dodać łącznik (zagięty łącznik) między dwoma kształtami (elipsą i prostokątem):

```Java
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do kolekcji kształtów dla określonego slajdu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Dodaje autokształt Elipsa
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Dodaje autokształt Prostokąt
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Łączy kształty za pomocą łącznika
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Wywołuje metodę reroute, która ustawia automatyczną najkrótszą ścieżkę między kształtami
    connector.reroute();
    
    // Zapisuje prezentację
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `Connector.reroute` przerysowuje łącznik i zmusza go do przyjęcia najkrótszej możliwej ścieżki pomiędzy kształtami. Aby osiągnąć cel, metoda może zmienić punkty `setStartShapeConnectionSiteIndex` i `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Określenie punktu połączenia**

Jeśli chcesz, aby łącznik łączył dwa kształty przy użyciu konkretnych punktów na kształtach, musisz określić preferowane punkty połączenia w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj dwie [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AutoShape) do slajdu, używając metody `addAutoShape` udostępnionej przez obiekt `Shapes`.
4. Dodaj łącznik przy użyciu metody `addConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
5. Połącz kształty przy użyciu łącznika. 
6. Ustaw preferowane punkty połączenia na kształtach. 
7. Zapisz prezentację.

Ten kod Java demonstruje operację, w której określony jest preferowany punkt połączenia:

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do kolekcji kształtów dla konkretnego slajdu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Dodaje autokształt Elipsa
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Dodaje autokształt Prostokąt
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Łączy kształty przy użyciu łącznika
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Ustawia preferowany indeks punktu połączenia na kształcie Elipsa
    int wantedIndex = 6;

    // Sprawdza, czy preferowany indeks jest mniejszy niż maksymalna liczba indeksów punktów połączenia
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Ustawia preferowany punkt połączenia na autokształcie Elipsa
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Zapisuje prezentację
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Regulacja punktu łącznika**

Możesz regulować istniejący łącznik za pomocą jego punktów regulacji. Tylko łączniki posiadające punkty regulacji mogą być w ten sposób modyfikowane. Zobacz tabelę pod **[Typy łączników.](/slides/pl/java/connector/#types-of-connectors)** 

### **Przypadek prosty**

Rozważ przypadek, w którym łącznik pomiędzy dwoma kształtami (A i B) przechodzi przez trzeci kształt (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Aby uniknąć lub ominąć trzeci kształt, możemy dostosować łącznik, przesuwając jego pionową linię w lewo w następujący sposób:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Przypadki złożone** 

Aby wykonać bardziej skomplikowane regulacje, musisz wziąć pod uwagę następujące kwestie:

* Regulowany punkt łącznika jest ściśle powiązany z formułą, która oblicza i określa jego pozycję. Dlatego zmiany położenia punktu mogą zmienić kształt łącznika.
* Punkty regulacji łącznika są zdefiniowane w ścisłej kolejności w tablicy. Punkty regulacji są numerowane od punktu początkowego łącznika do jego końcowego.
* Wartości punktów regulacji odzwierciedlają procent szerokości/wysokości kształtu łącznika. 
  * Kształt jest ograniczony przez punkty początkowy i końcowy łącznika pomnożone przez 1000. 
  * Pierwszy punkt, drugi punkt i trzeci punkt określają odpowiednio procent szerokości, procent wysokości oraz ponownie procent szerokości.
* Podczas obliczania współrzędnych punktów regulacji łącznika należy uwzględnić rotację łącznika i jego odbicie. **Uwaga**: kąt rotacji wszystkich łączników przedstawionych w **[Typy łączników](/slides/pl/java/connector/#types-of-connectors)** wynosi 0.

#### **Przypadek 1**

Rozważ przypadek, w którym dwa obiekty ramki tekstowej są połączone za pomocą łącznika:

![connector-shape-complex](connector-shape-complex.png)

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide sld = pres.getSlides().get_Item(0);
    // Dodaje kształty, które będą połączone łącznikiem
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Dodaje łącznik
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Określa kierunek łącznika
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Określa kolor łącznika
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Określa grubość linii łącznika
    connector.getLineFormat().setWidth(3);
    
    // Łączy kształty razem przy użyciu łącznika
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Pobiera punkty regulacji dla łącznika
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Regulacja**

Możemy zmienić wartości punktów regulacji łącznika, zwiększając odpowiednio procent szerokości i wysokości o 20% i 200%:

```java
// Changes the values of the adjustment points
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Wynik:

![connector-adjusted-1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający wyznaczenie współrzędnych i kształtu poszczególnych części łącznika, utwórzmy kształt odpowiadający poziomemu komponentowi łącznika w punkcie connector.getAdjustments().get_Item(0):

```java
// Narysuj pionowy komponent łącznika
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Wynik:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Przypadek 2**

W **przypadku 1** pokazaliśmy prostą operację regulacji łącznika przy użyciu podstawowych zasad. W typowych sytuacjach należy uwzględnić rotację łącznika oraz jego wyświetlanie (ustawiane przez connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV()). Teraz pokażemy ten proces.

Najpierw dodajmy nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórzmy nowy (zielony) łącznik, który połączy go z wcześniej utworzonymi obiektami.

```java
// Tworzy nowy obiekt wiązania
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Tworzy nowy łącznik
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Łączy obiekty przy użyciu nowo utworzonego łącznika
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Pobiera punkty regulacji łącznika
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Zmienia wartości punktów regulacji
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Wynik:

![connector-adjusted-3](connector-adjusted-3.png)

Po drugie, utwórzmy kształt, który będzie odpowiadał poziomemu komponentowi łącznika przechodzącemu przez nowy punkt regulacji connector.getAdjustments().get_Item(0). Użyjemy wartości z danych łącznika dla connector.getRotation(), connector.getFrame().getFlipH() i connector.getFrame().getFlipV() oraz zastosujemy popularną formułę konwersji współrzędnych dla rotacji wokół danego punktu x0:

```java
// Zapisuje współrzędne łącznika
x = connector.getX();
y = connector.getY();
// Koryguje współrzędne łącznika w razie potrzeby
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Używa wartości punktu regulacji jako współrzędnej
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Konwertuje współrzędne, ponieważ sin(90) = 1 i cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Wyznacza szerokość poziomego komponentu przy użyciu wartości drugiego punktu regulacji
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Wynik:

![connector-adjusted-4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia obejmujące proste regulacje oraz skomplikowane punkty regulacji (punkty regulacji z kątami rotacji). Korzystając z nabytej wiedzy, możesz opracować własny model (lub napisać kod), aby uzyskać obiekt `GraphicsPath` lub nawet ustawić wartości punktów regulacji łącznika na podstawie konkretnych współrzędnych slajdu.

## **Znajdowanie kąta linii łączników**

1. Utwórz instancję klasy.
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu linii łącznika.
4. Użyj szerokości i wysokości linii, wysokości ramki kształtu oraz szerokości ramki kształtu do obliczenia kąta.

Ten kod Java demonstruje operację, w której obliczyliśmy kąt dla kształtu linii łącznika:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do konkretnego kształtu?**

Sprawdź, czy kształt udostępnia [punkty połączenia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getConnectionSiteCount--). Jeśli nie ma żadnych lub liczba wynosi zero, przyklejanie nie jest dostępne; w takim przypadku użyj wolnych punktów końcowych i pozycjonuj je ręcznie. Warto sprawdzić liczbę punktów przed przyłączeniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**

Jego końce zostaną odłączone; łącznik pozostaje na slajdzie jako zwykła linia z wolnymi początkiem/końcem. Możesz go usunąć lub ponownie przypisać połączenia i, w razie potrzeby, [przerozpisać](https://reference.aspose.com/slides/pl/java/com.aspose.slides/connector/#reroute--).

**Czy połączenia łączników są zachowywane przy kopiowaniu slajdu do innej prezentacji?**

Zazwyczaj tak, pod warunkiem że również skopiowane zostaną docelowe kształty. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce staną się wolne i będzie trzeba je ponownie podłączyć.