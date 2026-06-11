---
title: "Zarządzaj łącznikami w prezentacjach za pomocą Pythona"
linktitle: "Łącznik"
type: docs
weight: 10
url: /pl/python-net/connector/
keywords:
- "łącznik"
- "typ łącznika"
- "punkt łącznika"
- "linia łącznika"
- "kąt łącznika"
- "łączenie kształtów"
- "PowerPoint"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Umożliw aplikacjom Python rysowanie, łączenie i automatyczne wyznaczanie tras linii w slajdach PowerPoint i OpenDocument — uzyskaj pełną kontrolę nad prostymi, łokciowymi i zakrzywionymi łącznikami."
---
## **Wstęp**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przyczepiona, gdy kształty są przemieszczane lub zmieniane na slajdzie. Łączniki przyczepiają się do **punktów połączenia** (zielonych punktów) na kształtach. Punkty połączenia pojawiają się, gdy wskaźnik zbliża się do nich. **Uchwyty regulacji** (żółte punkty), dostępne w niektórych łącznikach, pozwalają modyfikować pozycję i kształt łącznika.

## **Typy Łączników**

W programie PowerPoint można używać trzech typów łączników: prostego, łokciowego (z kątem) i zakrzywionego.

Aspose.Slides obsługuje następujące typy łączników:

| Typ łącznika | Obraz | Liczba punktów regulacji |
| ------------ | ----- | ------------------------ |
| `ShapeType.LINE` | ![Łącznik prosty](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Łącznik prosty 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![Łącznik łamany 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![Łącznik łamany 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![Łącznik łamany 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![Łącznik łamany 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![Łącznik zakrzywiony 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![Łącznik zakrzywiony 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![Łącznik zakrzywiony 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![Łącznik zakrzywiony 5](shapetype.curvedconnector5.png) | 3 |

## **Łączenie Kształtów za pomocą Łączników**

Ta sekcja pokazuje, jak łączyć kształty za pomocą łączników w Aspose.Slides. Dodasz łącznik do slajdu, przyczepisz jego początek i koniec do docelowych kształtów. Użycie punktów połączenia zapewnia, że łącznik pozostaje „przyklejony” do kształtów, nawet gdy są one przemieszczane lub zmieniane.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za jego indeksem.
1. Dodaj dwa obiekty [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu, używając metody `add_auto_shape` udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/).
1. Dodaj łącznik przy użyciu metody `add_connector` udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/), określając typ łącznika.
1. Połącz kształty za pomocą łącznika.
1. Wywołaj metodę `reroute`, aby zastosować najkrótszą ścieżkę połączenia.
1. Zapisz prezentację.

Poniższy kod w Pythonie pokazuje, jak dodać łamany łącznik między dwoma kształtami (elipsą i prostokątem):

```python
import aspose.slides as slides

# Utwórz obiekt klasy Presentation, aby stworzyć plik PPTX.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do kolekcji kształtów pierwszego slajdu.
    shapes = presentation.slides[0].shapes

    # Dodaj AutoShape w kształcie elipsy.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Dodaj AutoShape w kształcie prostokąta.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Dodaj łącznik do slajdu.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Połącz kształty przy użyciu łącznika.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Wywołaj reroute, aby ustawić najkrótszą ścieżkę.
    connector.reroute()

    # Zapisz prezentację.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda `connector.reroute` przerysowuje łącznik, zmuszając go do przyjęcia najkrótszej możliwej ścieżki między kształtami. W tym celu metoda może zmienić wartości `start_shape_connection_site_index` i `end_shape_connection_site_index`.
{{% /alert %}}

## **Określanie Punktów Połączenia**

Ta sekcja wyjaśnia, jak przyczepić łącznik do konkretnego punktu połączenia na kształcie w Aspose.Slides. Kierując się precyzyjnie wybranymi punktami połączenia, możesz kontrolować trasę i układ łącznika, uzyskując czyste, przewidywalne diagramy w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za jego indeksem.
1. Dodaj dwa obiekty [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu, używając metody `add_auto_shape` udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/).
1. Dodaj łącznik przy użyciu metody `add_connector` na obiekcie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/) i określ typ łącznika.
1. Połącz kształty za pomocą łącznika.
1. Ustaw preferowane punkty połączenia na kształtach.
1. Zapisz prezentację.

Poniższy kod w Pythonie demonstruje, jak określić preferowany punkt połączenia:

```python
import aspose.slides as slides

# Utwórz obiekt klasy Presentation, aby stworzyć plik PPTX.
with slides.Presentation() as presentation:

    # Uzyskaj dostęp do kolekcji kształtów pierwszego slajdu.
    shapes = presentation.slides[0].shapes

    # Dodaj AutoShape w kształcie elipsy.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Dodaj AutoShape w kształcie prostokąta.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Dodaj łącznik do kolekcji kształtów slajdu.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Połącz kształty przy użyciu łącznika.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Ustaw preferowany indeks punktu połączenia na elipsie.
    site_index = 6

    # Sprawdź, czy preferowany indeks mieści się w dostępnej liczbie punktów połączenia.
    if  ellipse.connection_site_count > site_index:
        # Przypisz preferowany punkt połączenia do AutoShape elipsy.
        connector.start_shape_connection_site_index = site_index

    # Zapisz prezentację.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Regulacja Punktów Łącznika**

Możesz modyfikować łączniki przy użyciu ich punktów regulacji. Tylko łączniki, które udostępniają punkty regulacji, mogą być w ten sposób edytowane. Szczegóły, które łączniki obsługują regulacje, znajdziesz w tabeli pod [Typy Łączników](/slides/pl/python-net/connector/#connector-types).

### **Prosty Przypadek**

Rozważmy przypadek, w którym łącznik między dwoma kształtami (A i B) przecina trzeci kształt (C):

![Przeszkoda łącznika](connector-obstruction.png)

Przykład kodu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Aby ominąć trzeci kształt, wyreguluj łącznik, przesuwając jego pionowy odcinek w lewo:

![Naprawiona przeszkoda łącznika](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Złożone Przypadki**

- Reguluowany punkt łącznika jest określany przez formułę wyznaczającą jego położenie. Zmiana tego punktu może zmienić ogólny kształt łącznika.
- Punkty regulacji łącznika są przechowywane w ściśle uporządkowanej tablicy, numerowanej od początku łącznika do jego końca.
- Wartości punktów regulacji reprezentują procenty szerokości/wysokości kształtu łącznika.
  - Kształt jest ograniczony przez punkty początkowy i końcowy łącznika i skalowany przez 1000.
  - Pierwszy, drugi i trzeci punkt regulacji oznaczają kolejno: procent szerokości, procent wysokości oraz ponownie procent szerokości.
- Przy obliczaniu współrzędnych punktów regulacji uwzględnij rotację i odbicie łącznika. **Uwaga:** dla wszystkich łączników wymienionych w [Typy Łączników](/slides/pl/python-net/connector/#connector-types) kąt rotacji wynosi 0.

#### **Przypadek 1**

Rozważmy przypadek, w którym dwa obiekty ramki tekstowej są połączone łącznikiem:

![Połączone kształty](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz obiekt klasy Presentation, aby stworzyć plik PPTX.
with slides.Presentation() as presentation:

    # Uzyskaj pierwszy slajd.
    slide = presentation.slides[0]

    # Uzyskaj pierwszy slajd.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Dodaj łącznik.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Ustaw kierunek łącznika.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Ustaw kolor łącznika.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Ustaw grubość linii łącznika.
    connector.line_format.width = 3

    # Połącz kształty przy użyciu łącznika.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Pobierz punkty regulacji łącznika.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Regulacja**

Zmień wartości punktów regulacji łącznika, zwiększając procent szerokości o 20 % oraz procent wysokości o 200 %:

```python
    # Zmień wartości punktów regulacji.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Wynik:

![Regulacja łącznika 1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający wyznaczenie współrzędnych i kształtu odcinków łącznika, utwórz kształt odpowiadający pionowej części łącznika przy `connector.adjustments[0]`:

```python
    # Narysuj pionowy składnik łącznika.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Wynik:

![Regulacja łącznika 2](connector-adjusted-2.png)

#### **Przypadek 2**

W **Przypadku 1** przedstawiliśmy prostą regulację łącznika, wykorzystując podstawowe zasady. W typowych scenariuszach musisz uwzględnić rotację łącznika oraz jego ustawienia wyświetlania (kontrolowane przez `connector.rotation`, `connector.frame.flip_h` i `connector.frame.flip_v`). Oto jak przebiega proces.

Najpierw dodaj nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórz nowy zielony łącznik, który łączy go z istniejącymi obiektami.

```python
    # Utwórz nowy obiekt docelowy.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Utwórz nowy łącznik.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Połącz obiekty używając nowo utworzonego łącznika.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Pobierz punkty regulacji łącznika.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Zmień wartości punktów regulacji.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Wynik:

![Regulacja łącznika 3](connector-adjusted-3.png)

Następnie utwórz kształt odpowiadający **poziomemu** odcinkowi łącznika, który przechodzi przez nowy punkt regulacji łącznika `connector.adjustments[0]`. Skorzystaj z wartości `connector.rotation`, `connector.frame.flip_h` i `connector.frame.flip_v` oraz zastosuj standardową formułę przekształcenia współrzędnych dla obrotu wokół punktu `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

W naszym przypadku kąt obrotu obiektu wynosi 90 stopni, a łącznik wyświetlany jest pionowo, więc odpowiedni kod to:

```python
    # Zapisz współrzędne łącznika.
    x = connector.x
    y = connector.y
    
    # Skoryguj współrzędne łącznika, jeśli jest odwrócony.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Użyj wartości punktu regulacji jako współrzędnej.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Przekształć współrzędne, ponieważ sin(90°) = 1 i cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Określ szerokość poziomego odcinka przy użyciu wartości drugiego punktu regulacji.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Wynik:

![Regulacja łącznika 4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia obejmujące zarówno proste regulacje, jak i bardziej złożone punkty regulacji (uwzględniające rotację). Korzystając z tej wiedzy, możesz opracować własny model — lub napisać kod — aby uzyskać obiekt `GraphicsPath` albo nawet ustawić wartości punktów regulacji łącznika na podstawie konkretnych współrzędnych slajdu.

## **Znajdowanie Kątów Linii Łącznika**

Użyj poniższego przykładu, aby określić kąt linii łącznika na slajdzie w Aspose.Slides. Dowiesz się, jak odczytać końcowe punkty łącznika i obliczyć jego orientację, aby precyzyjnie wyrównać strzałki, etykiety i inne kształty.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według indeksu.
1. Uzyskaj dostęp do kształtu linii łącznika.
1. Skorzystaj z szerokości i wysokości linii oraz szerokości i wysokości ramki kształtu, aby obliczyć kąt.

Poniższy kod w Pythonie pokazuje, jak obliczyć kąt dla kształtu linii łącznika:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do konkretnego kształtu?**

Sprawdź, czy kształt udostępnia [punkty połączenia](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/connection_site_count/). Jeśli ich nie ma lub liczba wynosi zero, przyklejenie nie jest dostępne; w takim wypadku użyj wolnych końcówek i ręcznie je pozycjonuj. Warto sprawdzić liczbę punktów przed przyczepieniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**

Jego końce zostaną odłączone; łącznik pozostaje na slajdzie jako zwykła linia z wolnym początkiem i końcem. Możesz go usunąć lub ponownie przypisać połączenia i, w razie potrzeby, [przeroutować](https://reference.aspose.com/slides/pl/python-net/aspose.slides/connector/reroute/).

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu do innej prezentacji?**

Zazwyczaj tak, pod warunkiem że skopiowane zostaną również docelowe kształty. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce staną się wolne i będzie trzeba je ponownie przyczepić.