---
title: Zarządzanie łącznikami w prezentacjach przy użyciu Pythona
linktitle: Łącznik
type: docs
weight: 10
url: /pl/python-net/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- miejsce połączenia
- punkt regulacji
- łączenie kształtów
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj sposób dodawania, dołączania, zmiany trasy, regulacji i przeglądania prostych, zgiętych oraz krzywych łączników PowerPoint przy użyciu Aspose.Slides dla Pythona w środowisku .NET."
---
## **Przegląd**

Łącznik to linia, która może pozostać przyłączona do dwóch kształtów, gdy którykolwiek z nich się przemieszcza. Jego końce przyczepiają się do miejsc połączenia, reprezentowanych przez zielone kropki w programie PowerPoint. Niektóre łączniki zgięte i krzywe udostępniają również punkty regulacji, przedstawione jako pomarańczowe kropki, które kontrolują położenie poszczególnych segmentów łącznika.

Aspose.Slides reprezentuje łączniki za pomocą interfejsu [IConnector](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/). Można je tworzyć, przyłączać ich końce do kształtów, wybierać miejsca połączenia, zmieniać ich trasę oraz modyfikować geometrię łączników posiadających punkty regulacji.

## **Typy łączników**

Wyliczenie [ShapeType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapetype/) zawiera zestawy łączników prostych, zgiętych i krzywych. Poniższa tabela przedstawia dostępne geometrie łączników oraz liczbę punktów regulacji zdefiniowaną dla każdego zestawu.

| Łącznik | Obraz | Liczba punktów regulacji |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Liczba i znaczenie punktów regulacji są częścią wybranego zestawu łącznika. Nie zakładaj, że dwa różne typy łączników udostępniają tę samą strukturę kolekcji.

## **Połącz dwa kształty**

Użyj [IShapeCollection.add_connector](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapecollection/add_connector/) aby dodać łącznik i przypisz jego właściwości [start_shape_connected_to](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/start_shape_connected_to/) oraz [end_shape_connected_to](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/end_shape_connected_to/). Po podłączeniu obu końców, [IConnector.reroute](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/reroute/) wybiera krótką trasę pomiędzy kształtami.

Poniższy przykład łączy elipsę i prostokąt łącznikiem zgiętym:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
Wywołanie `reroute` może zmienić wartości [start_shape_connection_site_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) i [end_shape_connection_site_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Przypisz konkretne miejsca połączenia po zmianie trasy, jeśli mają one pozostać stałe.
{{% /alert %}}

## **Wybierz miejsce połączenia**

Każdy kształt, z którym można się połączyć, zgłasza liczbę swoich miejsc połączenia poprzez [connection_site_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/igeometryshape/connection_site_count/). Sprawdź wybrany indeks miejsca (zerowy) przed przypisaniem go do końca łącznika; liczba miejsc zależy od geometrii kształtu.

Ten przykład przyczepia łącznik do konkretnego miejsca na elipsie, jeśli to miejsce istnieje:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Regulacja punktu łącznika**

Łączniki posiadające punkty regulacji udostępniają je przez [IGeometryShape.adjustments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/igeometryshape/adjustments/). Przed zmianą ich [raw_value](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iadjustvalue/raw_value/) sprawdź ich [type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iadjustvalue/type/). Ogólne manipulacje kształtami znajdziesz w [Shape Manipulation](/slides/pl/python-net/shape-manipulations/).

Liczba, kolejność, znaczenie i prawidłowy zakres wartości punktów regulacji łącznika zależą od zestawu łącznika. Właściwość `type` jest tylko do odczytu, natomiast wartość regulacji jest zapisywalna. Właściwość tylko do odczytu [name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iadjustvalue/name/) zapewnia dodatkową identyfikację, gdy łącznik zawiera więcej niż jedną regulację tego samego typu semantycznego.

### **Omijanie przeszkody**

W poniższym układzie łącznik `ShapeType.BENT_CONNECTOR5` pomiędzy dwoma kształtami przechodzi przez trzeci kształt:

![connector-obstruction](connector-obstruction.png)

Ten kod tworzy łącznik z przeszkodą:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Przemieszczenie pionowego zgięcia zmienia trasę tak, aby łącznik omijał przeszkodę:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Zamiast zakładać, że indeks kolekcji `1` zawsze reprezentuje pionowe zgięcie, ten przykład wyszukuje `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` i zmienia go tylko wtedy, gdy oczekiwany typ semantyczny jest obecny:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Łącznik `ShapeType.BENT_CONNECTOR5` posiada dwa punkty regulacji `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` i jeden punkt `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Jeśli potrzebny typ pojawia się więcej niż raz, sprawdź `name` oraz znaną geometrię tego zestawu przed dokonaniem wyboru. Jeśli regulacja zgłasza [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeadjustmenttype/), traktuj jej znaczenie i zakres jako specyficzne dla zestawu i nie zmieniaj jej, dopóki nie będzie znany odpowiedni kontrakt.

## **Powiązanie wartości regulacji z geometrią łącznika**

W przypadku łączników zgiętych wartości regulacji można wykorzystać do oszacowania położeń poszczególnych segmentów. Obliczenia te są specyficzne dla zestawu łącznika:

- `ShapeType.BENT_CONNECTOR4` zazwyczaj udostępnia jedną regulację `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` oraz jedną `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Dla tych pozycji zgięcia `raw_value / 100000` daje ułamek szerokości lub wysokości ramki łącznika używany w poniższych przykładach.
- Ramka łącznika może być obrócona lub odbita, więc współrzędne ramki muszą zostać przekształcone przed porównaniem z współrzędnymi slajdu.

Poniższe przykłady najpierw używają `type` do identyfikacji regulacji. Nie traktują indeksów kolekcji jako przenośnych identyfikatorów.

### **Łącznik nieobrócony**

Początkowy układ zawiera dwa kształty tekstowe połączone łącznikiem `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Ten przykład inspekcuje łącznik i pobiera jego regulacje poziomego i pionowego zgięcia:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Aby zmienić oba zgięcia, zlokalizuj każdy oczekiwany typ i zmodyfikuj wartości dopiero po znalezieniu obu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Wynikiem jest łącznik, którego segmenty poziomy i pionowy zostały przesunięte:

![connector-adjusted-1](connector-adjusted-1.png)

Gdy typy semantyczne są znane, ich wartości można przeliczyć na współrzędne ramki łącznika. Ten przykład rysuje cienki prostokąt nad pionowym segmentem kontrolowanym przez dwie regulacje zgięcia:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Kształt prowadzący oznacza obliczony segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Obrócony lub odbity łącznik**

Gdy ta sama geometria łącznika jest ustawiona pionowo, jej wartości [frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapeframe/flip_h/), oraz [flip_v](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapeframe/flip_v/) wpływają na konwersję współrzędnych ramki łącznika na współrzędne slajdu.

Ten przykład tworzy i reguluje pionowo ustawiony łącznik:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Regulowany łącznik pojawia się pionowo pomiędzy kształtami:

![connector-adjusted-3](connector-adjusted-3.png)

Dla dowolnego kąta obrotu `alpha` obróć punkt ramki łącznika `(x, y)` wokół środka ramki `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Poniższy kod obsługuje 90‑stopniową orientację używaną w tym przykładzie i rysuje czerwoną linię prowadzącą nad odpowiadającym segmentem łącznika:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Czerwona linia prowadząca oznacza obliczony segment po przekształceniu współrzędnych:

![connector-adjusted-4](connector-adjusted-4.png)

Formuły opisują zestawy użyte w przykładach, a nie uniwersalny model łącznika. Zweryfikuj typy regulacji, orientację ramki oraz zakresy wartości przed zastosowaniem tych samych obliczeń do innego zestawu.

## **Znajdź kąt kierunku łącznika**

Kierunek prostego łącznika można obliczyć z jego szerokości i wysokości, uwzględniając odbicia poziome i pionowe. Poniższy przykład podaje kąt w stopniach liczony zgodnie z ruchem wskazówek zegara od dodatniej osi poziomej w współrzędnych slajdu:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może być przyłączony do kształtu?**

Sprawdź [connection_site_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/igeometryshape/connection_site_count/) kształtu. Dodatnia liczba oznacza, że kształt udostępnia miejsca połączenia. Zweryfikuj wybrany indeks miejsca przed przypisaniem go do któregoś końca łącznika.

**Czy mogę zidentyfikować regulację łącznika po jej indeksie w kolekcji?**

Indeks ma sens tylko dla znanego zestawu łącznika i układu kolekcji. Sprawdź [IAdjustValue.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iadjustvalue/type/) przed modyfikacją wartości i użyj [IAdjustValue.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iadjustvalue/name/) jako dodatkowej informacji, gdy ten sam typ semantyczny występuje wielokrotnie.

**Co się dzieje, gdy połączony kształt zostanie usunięty?**

Odpowiedni koniec łącznika zostaje odłączony. Łącznik pozostaje na slajdzie i może być usunięty, przekształcony w wolną linię lub przyłączony do innego kształtu.

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu?**

Powiązania zazwyczaj są zachowywane, gdy połączone kształty są kopiowane razem ze slajdem. Jeśli łącznik zostanie skopiowany bez jednego z docelowych kształtów, odpowiedni koniec musi zostać ponownie przyłączony.