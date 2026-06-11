---
title: Zarządzanie łącznikami w prezentacjach w .NET
linktitle: Łącznik
type: docs
weight: 10
url: /pl/net/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- łączenie kształtów
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Umożliw aplikacjom .NET rysowanie, łączenie i automatyczne wyznaczanie tras linii w slajdach PowerPoint - uzyskaj pełną kontrolę nad prostymi, łokowymi i zakrzywionymi łącznikami."
---
## **Wprowadzenie**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przy nich nawet po ich przeniesieniu lub zmianie położenia na danym slajdzie.  

Łączniki są zazwyczaj podłączane do *punktów połączenia* (zielonych kropek), które domyślnie istnieją na wszystkich kształtach. Punkty połączenia pojawiają się, gdy kursor zbliży się do nich.  

*Punkty regulacji* (pomarańczowe kropki), które istnieją tylko w niektórych łącznikach, służą do modyfikacji położenia i kształtu łączników.

## **Rodzaje łączników**

W programie PowerPoint można używać prostych, łokowych (zagiętych) i zakrzywionych łączników.  

Aspose.Slides udostępnia następujące łączniki:

| Łącznik | Obraz | Liczba punktów regulacji |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Łączenie kształtów przy użyciu łączników**

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu, używając metody `AddAutoShape` udostępnionej przez obiekt `Shapes`.
4. Dodaj łącznik, używając metody `AddConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
5. Połącz kształty przy użyciu łącznika. 
6. Wywołaj metodę `Reroute`, aby zastosować najkrótszą ścieżkę połączenia.
7. Zapisz prezentację. 

Ten kod C# pokazuje, jak dodać łącznik (zagięty łącznik) pomiędzy dwoma kształtami (elipsą i prostokątem):

```c#
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
using (Presentation input = new Presentation())
{                
    // Uzyskuje dostęp do kolekcji kształtów dla konkretnego slajdu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Dodaje autokształt Elipsa
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Dodaje autokształt Prostokąt
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Łączy kształty za pomocą łącznika
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Wywołuje metodę reroute, która ustawia automatyczną najkrótszą ścieżkę między kształtami
    connector.Reroute();

    // Zapisuje prezentację
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Metoda `Connector.Reroute` przekierowuje łącznik i zmusza go do przyjęcia najkrótszej możliwej ścieżki między kształtami. Aby osiągnąć ten cel, metoda może zmienić punkty `StartShapeConnectionSiteIndex` oraz `EndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Określenie punktu połączenia**

Jeśli chcesz, aby łącznik łączył dwa kształty przy użyciu konkretnych punktów na kształtach, musisz określić wybrane punkty połączenia w następujący sposób:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu, używając metody `AddAutoShape` udostępnionej przez obiekt `Shapes`.
4. Dodaj łącznik, używając metody `AddConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
5. Połącz kształty przy użyciu łącznika. 
6. Ustaw wybrane punkty połączenia na kształtach. 
7. Zapisz prezentację.

Ten kod C# demonstruje operację, w której określony zostaje punkt połączenia:

```c#
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
using (Presentation presentation = new Presentation())
{
    // Uzyskuje dostęp do kolekcji kształtów dla konkretnego slajdu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Dodaje kształt łącznika do kolekcji kształtów slajdu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Dodaje autokształt Elipsa
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Dodaje autokształt Prostokąt
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Łączy kształty za pomocą łącznika
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Ustawia preferowany indeks punktu połączenia na kształcie Elipsa
    uint wantedIndex = 6;

    // Sprawdza, czy preferowany indeks jest mniejszy niż maksymalna liczba punktów połączenia
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Ustawia preferowany punkt połączenia na autokształcie Elipsa
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Zapisuje prezentację
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Regulacja punktu łącznika**

Możesz regulować istniejący łącznik za pomocą jego punktów regulacji. Tylko łączniki z punktami regulacji mogą być w ten sposób modyfikowane. Zobacz tabelę pod **[Rodzaje łączników.](/slides/pl/net/connector/#types-of-connectors)** 

### **Prosty przypadek**

Rozważ przypadek, w którym łącznik pomiędzy dwoma kształtami (A i B) przechodzi przez trzeci kształt (C):

![connector-obstruction](connector-obstruction.png)

Kod:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Aby uniknąć lub ominąć trzeci kształt, możemy wyregulować łącznik, przesuwając jego pionową linię w lewo w następujący sposób:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Złożone przypadki** 

Aby wykonać bardziej skomplikowane regulacje, należy wziąć pod uwagę następujące elementy:

* Punkt regulacji łącznika jest ściśle powiązany z formułą obliczającą i określającą jego położenie. Zmiany położenia punktu mogą więc zmienić kształt łącznika.
* Punkty regulacji łącznika są zdefiniowane w ścisłej kolejności w tablicy. Punkty regulacji są numerowane od punktu początkowego łącznika do jego końcowego.
* Wartości punktów regulacji odzwierciedlają procent szerokości/wysokości kształtu łącznika.  
  * Kształt jest ograniczony przez punkty początkowy i końcowy łącznika pomnożone przez 1000.  
  * Pierwszy punkt, drugi punkt i trzeci punkt określają odpowiednio procent z szerokości, procent z wysokości oraz ponownie procent z szerokości.  
* Przy obliczeniach wyznaczających współrzędne punktów regulacji łącznika należy uwzględnić jego obrót oraz odbicie. **Uwaga**, że kąt obrotu wszystkich łączników pokazanych w **[Rodzaje łączników](/slides/pl/net/connector/#types-of-connectors)** wynosi 0.

#### **Przypadek 1**

Rozważ przypadek, w którym dwa obiekty ramki tekstowej są połączone łącznikiem:

![connector-shape-complex](connector-shape-complex.png)

```c#
// Tworzy instancję klasy prezentacji reprezentującej plik PPTX
Presentation pres = new Presentation();
// Pobiera pierwszy slajd w prezentacji
ISlide sld = pres.Slides[0];
// Dodaje kształty, które będą połączone za pomocą łącznika
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Dodaje łącznik
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Określa kierunek łącznika
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Określa kolor łącznika
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Określa grubość linii łącznika
connector.LineFormat.Width = 3;

// Łączy kształty razem za pomocą łącznika
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Pobiera punkty regulacji dla łącznika
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Regulacja**

Możemy zmienić wartości punktów regulacji łącznika, zwiększając odpowiednio procent szerokości o 20 % i procent wysokości o 200 %:

```c#
// Zmienia wartości punktów regulacji
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Wynik:

![connector-adjusted-1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający określenie współrzędnych i kształtu poszczególnych części łącznika, utwórzmy kształt odpowiadający poziomej składowej łącznika w punkcie `connector.Adjustments[0]`:

```c#
// Rysuje pionową składową łącznika

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Wynik:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Przypadek 2**

W **Przypadku 1** pokazaliśmy prostą operację regulacji łącznika z wykorzystaniem podstawowych zasad. W normalnych sytuacjach należy uwzględnić obrót łącznika oraz jego wyświetlanie (ustawiane przez `connector.Rotation`, `connector.Frame.FlipH` i `connector.Frame.FlipV`). Teraz zaprezentujemy ten proces.

Najpierw dodajmy nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórzmy nowy (zielony) łącznik, który połączy go z wcześniej utworzonymi obiektami.

```c#
// Tworzy nowy obiekt powiązania
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Tworzy nowy łącznik
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Łączy obiekty przy użyciu nowo utworzonego łącznika
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Pobiera punkty regulacji łącznika
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Zmienia wartości punktów regulacji
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Wynik:

![connector-adjusted-3](connector-adjusted-3.png)

Następnie utwórzmy kształt odpowiadający poziomej składowej łącznika przechodzącej przez nowy punkt regulacji `connector.Adjustments[0]`. Skorzystamy z wartości z danych łącznika: `connector.Rotation`, `connector.Frame.FlipH` i `connector.Frame.FlipV` oraz zastosujemy popularną formułę przekształcenia współrzędnych dla obrotu wokół danego punktu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

W naszym przypadku kąt obrotu obiektu wynosi 90 stopni, a łącznik jest wyświetlany pionowo, więc odpowiedni kod wygląda tak:

```c#
// Zapisuje współrzędne łącznika
x = connector.X;
y = connector.Y;
// Koryguje współrzędne łącznika w razie potrzeby
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Używa wartości punktu regulacji jako współrzędnej
x += connector.Width * adjValue_0.RawValue / 100000;
//  Konwertuje współrzędne, ponieważ Sin(90) = 1 i Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Określa szerokość komponentu poziomego przy użyciu wartości drugiego punktu regulacji
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```

Wynik:

![connector-adjusted-4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia obejmujące proste regulacje oraz skomplikowane punkty regulacji (punkty regulacji z kątami obrotu). Korzystając z nabytej wiedzy, możesz opracować własny model (lub napisać kod), aby uzyskać obiekt `GraphicsPath` lub nawet ustawić wartości punktów regulacji łącznika na podstawie konkretnych współrzędnych slajdu.

## **Wyznaczanie kąta linii łącznika**

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu linii łącznika. 
4. Użyj szerokości i wysokości linii oraz wysokości i szerokości ramki kształtu, aby obliczyć kąt.

Ten kod C# demonstruje operację, w której obliczyliśmy kąt dla kształtu linii łącznika:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do konkretnego kształtu?**

Sprawdź, czy kształt udostępnia [punkty połączenia](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/connectionsitecount/). Jeśli ich brak lub liczba wynosi zero, przyklejanie nie jest dostępne; w takim przypadku użyj wolnych końcówek i ustaw je ręcznie. Warto sprawdzić liczbę punktów przed podłączeniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**

Jego końce zostaną odłączone; łącznik pozostaje na slajdzie jako zwykła linia z wolnym początkiem i końcem. Możesz go usunąć lub ponownie przydzielić połączenia i, w razie potrzeby, [przekierować](https://reference.aspose.com/slides/pl/net/aspose.slides/connector/reroute/).

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu do innej prezentacji?**

Zazwyczaj tak, pod warunkiem że skopiowane zostaną również docelowe kształty. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce staną się wolne i będzie trzeba je ponownie podłączyć.