---
title: Zarządzanie łącznikami w prezentacjach w Pythonie poprzez Java
linktitle: Łącznik
type: docs
weight: 10
url: /pl/python-java/connector/
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
description: "Dowiedz się, jak dodawać, podłączać, przemieszczać, regulować i przeglądać proste, zgięte i krzywe łączniki PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Łącznik to linia, która może pozostać połączona z dwoma kształtami, gdy którykolwiek z nich się przemieszcza. Jego końce przyczepiają się do miejsc połączeń, przedstawionych jako zielone kropki w PowerPoint. Niektóre zgięte i wygięte łączniki udostępniają również punkty regulacji, przedstawione jako pomarańczowe kropki, które sterują pozycją poszczególnych segmentów łącznika.

Aspose.Slides reprezentuje łączniki za pomocą klasy [Connector](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/). Można je tworzyć, podłączać ich końce do kształtów, wybierać miejsca połączeń, zmieniać trasę oraz modyfikować geometrię łączników posiadających punkty regulacji.

## **Typy łączników**

Klasa [ShapeType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/) zawiera zestawy prostych, zgiętych i krzywych łączników. Poniższa tabela przedstawia dostępne geometrie łączników oraz liczbę punktów regulacji zdefiniowanych w każdym zestawie.

| Łącznik | Obraz | Liczba punktów regulacji |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Liczba i znaczenie punktów regulacji stanowią część wybranego zestawu łącznika. Nie zakładaj, że dwa różne typy łączników udostępniają tę samą strukturę kolekcji.

## **Połączenie dwóch kształtów**

Użyj [ShapeCollection.addConnector](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addConnector), aby dodać łącznik, oraz metod [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#setStartShapeConnectedTo) i [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#setEndShapeConnectedTo), aby podłączyć jego końce. Po podłączeniu obu końców, metoda [Connector.reroute](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#reroute) wybiera najkrótszą trasę między kształtami.

Poniższy przykład łączy elipsę i prostokąt zgiętym łącznikiem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Ostrzeżenie" %}}
Wywołanie [reroute](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#reroute) może zmienić wartości [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) i [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Po przemieszczeniu łącznika przypisz konkretne miejsca połączeń, jeśli mają one pozostać stałe.
{{% /alert %}}

## **Wybór miejsca połączenia**

Każdy kształt, z którym można się połączyć, udostępnia liczbę miejsc połączeń przez metodę [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getConnectionSiteCount). Zweryfikuj wybrany indeks (liczony od zera) przed przypisaniem go do końca łącznika; liczba miejsc różni się w zależności od geometrii kształtu.

Ten przykład podłącza łącznik do konkretnego miejsca na elipsie, gdy takie miejsce istnieje:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Regulacja punktu łącznika**

Łączniki posiadające punkty regulacji udostępniają je przez metodę [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#getAdjustments). Sprawdź każdy [AdjustValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/) i jego wartość [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType) przed zmianą przy pomocy [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue). Ogólne zasady identyfikacji regulacji predefiniowanych kształtów opisano w sekcji [Manipulacja kształtem](/slides/pl/python-java/shape-manipulations/).

Liczba, kolejność, znaczenie oraz dopuszczalny zakres wartości regulacji łącznika zależą od wybranego zestawu. Typ regulacji jest tylko do odczytu, natomiast wartość regulacji można modyfikować. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) dostarcza dodatkową identyfikację, gdy łącznik zawiera więcej niż jedną regulację tego samego typu semantycznego.

### **Omijanie przeszkody**

W poniższym układzie łącznik [BentConnector5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector5) między dwoma kształtami przechodzi przez trzeci kształt:

![connector-obstruction](connector-obstruction.png)

Ten kod tworzy łącznik zablokowany przez przeszkodę:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przesunięcie pionowego zgięcia zmienia trasę tak, aby łącznik omijał przeszkodę:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Zamiast zakładać, że indeks kolekcji `1` zawsze reprezentuje pionowe zgięcie, ten przykład wyszukuje [ConnectorBendPositionY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) i zmienia go tylko wtedy, gdy oczekiwany typ semantyczny jest obecny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[**BentConnector5**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector5) posiada dwa regulacje [ConnectorBendPositionX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) oraz jedną [ConnectorBendPositionY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Jeśli potrzebny typ występuje więcej niż raz, sprawdź [getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) i znaną geometrię zestawu przed wybraniem jednej z nich. Gdy regulacja zwraca [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#Custom), traktuj jej znaczenie i zakres jako specyficzne dla zestawu i nie zmieniaj jej, dopóki nie zostanie określona odpowiednia umowa.

## **Powiązanie wartości regulacji z geometrią łącznika**

W przypadku zgiętych łączników wartości regulacji mogą być użyte do oszacowania położeń poszczególnych segmentów. Obliczenia te są specyficzne dla konkretnego zestawu łącznika:

- [BentConnector4](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector4) zazwyczaj udostępnia jedną regulację [ConnectorBendPositionX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) i jedną [ConnectorBendPositionY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Dla tych pozycji zgięcia, podzielenie wartości zwróconej przez [getRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getRawValue) przez `100000.0` daje ułamek szerokości lub wysokości ramki łącznika używany w poniższych przykładach.
- Ramka łącznika może być obrócona lub odwrócona, więc współrzędne ramki muszą być przekształcone przed porównaniem z współrzędnymi slajdu.

Poniższe przykłady najpierw wykorzystują [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType) do identyfikacji regulacji. Nie traktują indeksów kolekcji jako przenośnych identyfikatorów.

### **Nierotowany łącznik**

Początkowy układ zawiera dwa kształty tekstowe połączone [BentConnector4](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Ten przykład bada łącznik i pobiera jego regulacje poziomego oraz pionowego zgięcia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Aby zmienić oba zgięcia, znajdź każdy oczekiwany typ i modyfikuj wartości dopiero po odnalezieniu ich obu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynikiem jest łącznik, którego segmenty poziome i pionowe zostały przesunięte:

![connector-adjusted-1](connector-adjusted-1.png)

Gdy typy semantyczne są znane, ich wartości mogą zostać przeliczone na współrzędne ramki łącznika. Ten przykład rysuje cienki prostokąt nad pionowym segmentem sterowanym przez dwie regulacje zgięcia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kształt pomocniczy oznacza obliczony segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Obrócony lub odwrócony łącznik**

Gdy ta sama geometria łącznika jest skierowana pionowo, wartości [Shape.getFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeframe/#getFlipH) i [ShapeFrame.getFlipV](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeframe/#getFlipV) wpływają na konwersję współrzędnych ramki łącznika na współrzędne slajdu.

Ten przykład tworzy i reguluje pionowo skierowany łącznik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Skorygowany łącznik pojawia się pionowo pomiędzy kształtami:

![connector-adjusted-3](connector-adjusted-3.png)

Dla dowolnego kąta obrotu `alpha` obróć punkt ramki łącznika `(x, y)` wokół środka ramki `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Poniższy kod obsługuje 90‑stopniową orientację używaną w tym przykładzie i rysuje czerwoną prowadnicę nad odpowiednim segmentem łącznika:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Czerwona prowadnica oznacza obliczony segment po transformacji współrzędnych:

![connector-adjusted-4](connector-adjusted-4.png)

Formuły te opisują zestawy użyte w przykładach, a nie uniwersalny model łącznika. Zweryfikuj typy regulacji, orientację ramki oraz zakresy wartości przed zastosowaniem tych obliczeń do innego zestawu.

## **Wyznaczenie kąta kierunku łącznika**

Kierunek prostego łącznika można obliczyć na podstawie jego szerokości i wysokości, uwzględniając poziome i pionowe odbicia. Poniższy przykład podaje kąt w stopniach, liczony zgodnie z ruchem wskazówek zegara od dodatniej osi poziomej w układzie współrzędnych slajdu:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może zostać podłączony do kształtu?**

Sprawdź wartość [getConnectionSiteCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getConnectionSiteCount) kształtu. Dodatnia liczba oznacza, że kształt udostępnia miejsca połączeń. Zweryfikuj wybrany indeks miejsca przed przypisaniem go do któregokolwiek końca łącznika.

**Czy mogę zidentyfikować regulację łącznika po jej indeksie w kolekcji?**

Indeks ma sens tylko w kontekście znanego zestawu łącznika i układu kolekcji. Przed modyfikacją wartości sprawdź [AdjustValue.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType) i użyj [AdjustValue.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) jako dodatkowej informacji, gdy ten sam typ semantyczny występuje więcej niż raz.

**Co się stanie, gdy połączony kształt zostanie usunięty?**

Odpowiedni koniec łącznika zostaje odłączony. Łącznik pozostaje na slajdzie i może zostać usunięty, przekształcony w wolną linię lub podłączony do innego kształtu.

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu?**

Powiązania są zazwyczaj zachowywane, gdy połączone kształty są kopiowane razem ze slajdem. Jeśli łącznik zostanie skopiowany bez jednego z docelowych kształtów, dotknięty koniec musi być ponownie podłączony.