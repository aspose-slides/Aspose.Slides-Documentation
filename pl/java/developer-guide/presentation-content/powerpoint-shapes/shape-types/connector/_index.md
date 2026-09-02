---
title: "Zarządzanie łącznikami w prezentacjach w Javie"
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
- miejsce połączenia
- punkt regulacji
- połącz kształty
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przyłączać, przerysowywać, regulować i przeglądać proste, zgięte i zakrzywione łączniki PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Łącznik to linia, która może pozostać przyłączona do dwóch kształtów, gdy którykolwiek z nich się przemieszcza. Jego końce przymocowują się do miejsc połączeń, przedstawionych jako zielone kropki w PowerPoint. Niektóre zgięte i zakrzywione łączniki udostępniają także punkty regulacji, oznaczone pomarańczowymi kropkami, które sterują pozycją poszczególnych segmentów łącznika.

Aspose.Slides reprezentuje łączniki za pomocą interfejsu [IConnector](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/). Można je tworzyć, przyłączać ich końce do kształtów, wybierać miejsca połączeń, przerysowywać je oraz modyfikować geometrię łączników posiadających punkty regulacji.

## **Typy łączników**

Klasa [ShapeType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapetype/) zawiera gotowe łączniki prostoliniowe, zgięte i zakrzywione. Poniższa tabela przedstawia dostępne geometrie łączników oraz liczbę punktów regulacji zdefiniowanych w każdym zestawie.

| Łącznik | Obraz | Liczba punktów regulacji |
|---|---|---|
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

Liczba i znaczenie punktów regulacji są częścią wybranego zestawu łącznika. Nie zakładaj, że dwa różne typy łączników udostępniają ten sam układ kolekcji.

## **Połączenie dwóch kształtów**

Użyj [IShapeCollection.addConnector](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) aby dodać łącznik, a następnie [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) i [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) aby przyłączyć jego końce. Po przyłączeniu obu końcówek, [IConnector.reroute](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/#reroute--) wybiera krótką trasę pomiędzy kształtami.

Poniższy przykład łączy elipsę i prostokąt przy użyciu łącznika zgiętego:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Ostrzeżenie" %}}
Wywołanie `reroute` może zmienić wartości [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) i [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Przypisz konkretne miejsca połączeń po przerysowaniu, jeśli te miejsca mają pozostać stałe.
{{% /alert %}}

## **Wybór miejsca połączenia**

Każdy kształt, z którym można się połączyć, zwraca liczbę dostępnych miejsc przez [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Zweryfikuj żądany indeks miejsca (liczony od zera) przed jego przypisaniem do końca łącznika; liczba miejsc różni się w zależności od geometrii kształtu.

Ten przykład przyłącza łącznik do konkretnego miejsca na elipsie, jeśli takie miejsce istnieje:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regulacja punktu łącznika**

Łączniki posiadające punkty regulacji udostępniają je poprzez [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igeometryshape/#getAdjustments--). Przejrzyj każdy [IAdjustValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/) i sprawdź jego wartość [getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/#getType--) przed zmianą za pomocą [setRawValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Ogólne zasady identyfikacji gotowych regulacji kształtu opisano w sekcji [Manipulacja kształtami](/slides/pl/java/shape-manipulations/).

Liczba, kolejność, znaczenie i dopuszczalny zakres wartości regulacji łącznika zależą od wybranego zestawu. Typ regulacji jest tylko do odczytu, natomiast wartość regulacji jest zapisywalna. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/#getName--) dostarcza dodatkową identyfikację, gdy łącznik zawiera więcej niż jedną regulację tego samego typu semantycznego.

### **Omijanie przeszkody**

W poniższym układzie łącznik `BentConnector5` pomiędzy dwoma kształtami przechodzi przez trzeci kształt:

![connector-obstruction](connector-obstruction.png)

Ten kod tworzy łącznik zablokowany przez przeszkodę:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przesunięcie pionowego zgięcia zmienia trasę tak, aby łącznik omijał przeszkodę:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Zamiast zakładać, że indeks kolekcji `1` zawsze oznacza pionowe zgięcie, ten przykład wyszukuje `ConnectorBendPositionY` i zmienia go tylko wtedy, gdy występuje oczekiwany typ semantyczny:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5` posiada dwa regulacje `ConnectorBendPositionX` oraz jedną `ConnectorBendPositionY`. Jeśli potrzebny typ występuje więcej niż raz, sprawdź metodę `getName` oraz znaną geometrię zestawu przed wybraniem jednej z nich. Jeśli regulacja zwraca `ShapeAdjustmentType.Custom`, potraktuj jej znaczenie i zakres jako specyficzne dla zestawu i nie zmieniaj jej, dopóki nie będziesz znał obowiązującej umowy.

## **Powiązanie wartości regulacji z geometrią łącznika**

W przypadku łączników zgiętych wartości regulacji można wykorzystać do oszacowania pozycji poszczególnych segmentów. Obliczenia są specyficzne dla wybranego zestawu łącznika:

- `BentConnector4` zazwyczaj udostępnia jedną regulację `ConnectorBendPositionX` i jedną `ConnectorBendPositionY`.
- Dla tych pozycji zgięcia, podzielenie wartości zwróconej przez `getRawValue` przez `100000f` daje ułamek szerokości lub wysokości ramki łącznika używany w poniższych przykładach.
- Ramka łącznika może być obrócona lub odbita, więc współrzędne ramki muszą być przekształcone przed porównaniem z współrzędnymi slajdu.

Poniższe przykłady najpierw identyfikują regulacje za pomocą `getType`. Nie traktują one indeksów kolekcji jako przenośnych identyfikatorów.

### **Nieobrócony łącznik**

Początkowy układ zawiera dwa kształty tekstowe połączone łącznikiem `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ten przykład przegląda łącznik i pobiera jego regulacje zgięcia poziomego i pionowego:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Aby zmienić oba zgięcia, znajdź każdy oczekiwany typ i zmodyfikuj wartości dopiero po znalezieniu obu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Wynikiem jest łącznik, którego segmenty poziome i pionowe zostały przesunięte:

![connector-adjusted-1](connector-adjusted-1.png)

Po poznaniu typów semantycznych ich wartości można przeliczyć na współrzędne ramki łącznika. Ten przykład rysuje cienki prostokąt nad segmentem pionowym sterowanym przez dwie regulacje zgięcia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Kształt pomocniczy zaznacza obliczony segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Obrócony lub odbity łącznik**

Gdy ta sama geometria łącznika jest skierowana pionowo, wartości [IShape.getFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapeframe/#getFlipH--) i [ShapeFrame.getFlipV](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapeframe/#getFlipV--) wpływają na konwersję współrzędnych ramki łącznika na współrzędne slajdu.

Ten przykład tworzy i reguluje pionowo zorientowany łącznik:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Regulowany łącznik pojawia się pionowo między kształtami:

![connector-adjusted-3](connector-adjusted-3.png)

Dla dowolnego kąta obrotu `alpha` obróć punkt ramki łącznika `(x, y)` wokół środka ramki `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Poniższy kod obsługuje 90‑stopniową orientację używaną w tym przykładzie i rysuje czerwoną linię pomocniczą nad odpowiednim segmentem łącznika:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Czerwona linia pomocnicza oznacza obliczony segment po przekształceniu współrzędnych:

![connector-adjusted-4](connector-adjusted-4.png)

Formuły te opisują zestawy użyte w przykładach, a nie uniwersalny model łącznika. Zweryfikuj typy regulacji, orientację ramki i zakresy wartości przed zastosowaniem tych samych obliczeń do innego zestawu.

## **Wyznaczanie kąta kierunkowego łącznika**

Kierunek prostego łącznika można obliczyć na podstawie jego szerokości i wysokości, uwzględniając poziome i pionowe odbicia. Poniższy przykład zwraca kąt w stopniach, mierzony zgodnie z ruchem wskazówek zegara od dodatniej osi poziomej w współrzędnych slajdu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę sprawdzić, czy łącznik może zostać przyłączony do kształtu?**

Sprawdź wartość [getConnectionSiteCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getConnectionSiteCount--) kształtu. Dodatnia liczba oznacza, że kształt udostępnia miejsca połączeń. Zweryfikuj wybrany indeks miejsca przed przypisaniem go do dowolnego końca łącznika.

**Czy mogę zidentyfikować regulację łącznika po jej indeksie w kolekcji?**

Indeks ma sens tylko dla znanego zestawu łącznika i układu kolekcji. Sprawdź [IAdjustValue.getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/#getType--) przed modyfikacją wartości i użyj [IAdjustValue.getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iadjustvalue/#getName--) jako dodatkowej informacji, gdy ten sam typ semantyczny występuje więcej niż raz.

**Co się stanie, gdy połączony kształt zostanie usunięty?**

Odpowiedni koniec łącznika zostaje odłączony. Łącznik pozostaje na slajdzie i może być usunięty, przekształcony w wolną linię lub przyłączony do innego kształtu.

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu?**

Powiązania są zazwyczaj zachowywane, gdy połączone kształty są kopiowane razem ze slajdem. Jeśli łącznik zostanie skopiowany bez jednego z docelowych kształtów, dotknięty koniec musi zostać ponownie przyłączony.