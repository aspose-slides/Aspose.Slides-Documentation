---
title: Управление соединителями в презентациях на Android
linktitle: Соединитель
type: docs
weight: 10
url: /ru/androidjava/connector/
keywords:
- соединитель
- тип соединителя
- точка соединителя
- линия соединителя
- угол соединителя
- точка соединения
- точка регулировки
- соединять фигуры
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, присоединять, перенаправлять, регулировать и просматривать прямые, изогнутые и гибкие соединители PowerPoint с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Соединитель — это линия, которая может оставаться прикреплённой к двум фигурам, когда любая из фигур перемещается. Его концы присоединяются к точкам соединения, обозначенным зелёными точками в PowerPoint. Некоторые изогнутые и гибкие соединители также имеют точки регулировки, обозначенные оранжевыми точками, которые управляют положением отдельных сегментов соединителя.

Aspose.Slides представляет соединители через интерфейс [IConnector](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/). Вы можете создавать их, прикреплять их концы к фигурам, выбирать точки соединения, переопределять их маршрут и изменять геометрию соединителей, имеющих точки регулировки.

## **Типы соединителей**

Класс [ShapeType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapetype/) включает предустановки прямых, гибких и изогнутых соединителей. В таблице ниже показана доступная геометрия соединителей и количество точек регулировки, определённых для каждой предустановки.

| Соединитель | Изображение | Количество точек регулировки |
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

Количество и смысл точек регулировки являются частью выбранной предустановки соединителя. Не следует предполагать, что два разных типа соединителей используют одинаковую структуру коллекции.

## **Соединить две фигуры**

Используйте [IShapeCollection.addConnector](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) для добавления соединителя и методы [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) и [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) для присоединения его концов. После присоединения обоих концов метод [IConnector.reroute](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/#reroute--) выбирает короткий маршрут между фигурами.

Следующий пример соединяет эллипс и прямоугольник гибким соединителем:

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

{{% alert color="warning" title="Warning" %}}
Вызов `reroute` может изменить значения [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) и [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). После переопределения маршрута присвойте конкретные точки соединения, если они должны оставаться фиксированными.
{{% /alert %}}

## **Выбрать точку соединения**

Каждая соединяемая фигура сообщает своё количество точек через метод [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Перед присвоением индекса соединителю проверьте, что выбранный нулевой‑основанный индекс существует; количество точек зависит от геометрии фигуры.

В этом примере соединитель присоединяется к определённой точке на эллипсе, если такая точка существует:

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

## **Регулировка точки соединителя**

Соединители с точками регулировки раскрывают их через метод [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Перед изменением значения осмотрите каждый объект [IAdjustValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/) и проверьте его тип, вызывая [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getType--). Затем измените значение через [setRawValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). Общие правила идентификации предустановленных регулировок фигур описаны в разделе [Shape Manipulation](/slides/ru/androidjava/shape-manipulations/).

Количество, порядок, смысл и допустимый диапазон значений регулировки зависят от предустановки соединителя. Тип регулировки доступен только для чтения, а значение — для записи. Метод только для чтения [getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getName--) предоставляет дополнительную идентификацию, когда у соединителя более одной регулировки одного и того же семантического типа.

### **Обход препятствия**

В следующем расположении соединитель `BentConnector5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт соединитель с препятствием:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Перемещение вертикального изгиба изменяет маршрут так, что соединитель объезжает препятствие:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо того чтобы предполагать, что индекс коллекции `1` всегда представляет вертикальный изгиб, пример ищет `ConnectorBendPositionY` и изменяет его только при наличии ожидаемого семантического типа:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

У `BentConnector5` две регулировки `ConnectorBendPositionX` и одна `ConnectorBendPositionY`. Если нужный тип встречается несколько раз, осмотрите `getName` и известную геометрию предустановки перед выбором. Если регулировка возвращает `ShapeAdjustmentType.Custom`, её смысл и диапазон являются специфичными для предустановки; изменяйте её только после уточнения контракта.

## **Связать значения регулировки с геометрией соединителя**

Для гибких соединителей значения регулировки могут использоваться для оценки позиций отдельных сегментов. Эти вычисления специфичны для предустановки соединителя:

- `BentConnector4` обычно раскрывает одну регулировку `ConnectorBendPositionX` и одну `ConnectorBendPositionY`.
- Для этих позиций деление значения, полученного через `getRawValue`, на `100000f` даёт долю ширины или высоты рамки соединителя, используемую в примерах ниже.
- Рамка соединителя может быть вращена или отражена, поэтому координаты рамки необходимо преобразовать перед сравнением с координатами слайда.

Следующие примеры используют `getType` для предварительной идентификации регулировок. Они не используют индексы коллекции как переносимые идентификаторы.

### **Не повернутый соединитель**

Исходное расположение содержит две текстовые фигуры, соединённые `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример осматривает соединитель и получает его горизонтальные и вертикальные регулировки изгиба:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и модифицируйте значения только после того, как оба будут найдены:

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

В результате получаем соединитель, у которого горизонтальный и вертикальный сегменты смещены:

![connector-adjusted-1](connector-adjusted-1.png)

После того как известны семантические типы, их значения можно преобразовать в координаты рамки соединителя. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, управляемым двумя регулировками изгиба:

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

Помимо этого, вспомогательная фигура отмечает вычисленный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый соединитель**

Когда та же геометрия соединителя ориентирована вертикально, значения [IShape.getFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeframe/#getFlipH--) и [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeframe/#getFlipV--) влияют на преобразование координат из рамки соединителя в координаты слайда.

Этот пример создаёт и регулирует вертикально ориентированный соединитель:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
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

Отрегулированный соединитель отображается вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла поворота `alpha` поворачивайте точку рамки соединителя `(x, y)` вокруг центра рамки `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает ориентацию 90 градусов, используемую в этом примере, и рисует красную направляющую над соответствующим сегментом соединителя:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Красная направляющая отмечает вычисленный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель соединителя. Перед применением тех же вычислений к другой предустановке проверьте типы регулировки, ориентацию рамки и диапазоны значений.

## **Найти угол направления соединителя**

Угол направления прямого соединителя можно вычислить по его ширине и высоте с учётом горизонтального и вертикального отражения. Пример ниже выводит угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

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

**Как определить, может ли соединитель присоединиться к фигуре?**

Проверьте значение [getConnectionSiteCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) у фигуры. Положительное значение означает, что фигура имеет точки соединения. Перед присвоением индекса убедитесь в его корректности.

**Можно ли идентифицировать регулировку соединителя по её индексу в коллекции?**

Индекс имеет смысл только для известной предустановки соединителя и её структуры коллекции. Перед изменением значения проверьте [IAdjustValue.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getType--) и при необходимости используйте [IAdjustValue.getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getName--) как дополнительную информацию, если один и тот же семантический тип встречается несколько раз.

**Что происходит, если удаляется фигура, к которой присоединён соединитель?**

Конец соединителя, привязанный к удалённой фигуре, открепляется. Сам соединитель остаётся на слайде и может быть удалён, перемещён как свободная линия или присоединён к другой фигуре.

**Сохраняются ли привязки соединителей при копировании слайда?**

Привязки обычно сохраняются, когда копируются вместе с слайдом связанные фигуры. Если соединитель копируется без одной из целевых фигур, соответствующий конец необходимо заново присоединить.