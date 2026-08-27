---
title: Управление коннекторами в презентациях на Java
linktitle: Коннектор
type: docs
weight: 10
url: /ru/java/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- точка соединения
- регулируемая точка
- соединить фигуры
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, прикреплять, пере‑маршрутизировать, настраивать и проверять прямые, изогнутые и изгиб‑наклонённые коннекторы PowerPoint с помощью Aspose.Slides для Java."
---
## **Обзор**

Коннектор — это линия, которая может оставаться присоединённой к двум фигурам, когда любая из фигур перемещается. Его концы привязываются к точкам соединения, отображаемым зелёными точками в PowerPoint. Некоторые изогнутые и изгиб‑наклоненные коннекторы также имеют регулируемые точки, отображаемые оранжевыми точками, которые управляют положением отдельных сегментов коннектора.

Aspose.Slides представляет коннекторы через интерфейс [IConnector](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/). Вы можете создавать их, привязывать их концы к фигурам, выбирать точки соединения, менять их маршрут и изменять геометрию коннекторов, имеющих регулируемые точки.

## **Типы коннекторов**

Класс [ShapeType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapetype/) включает предустановки прямых, изогнутых и изгиб‑наклонённых коннекторов. В следующей таблице показана доступная геометрия коннекторов и количество регулируемых точек, определяемое каждой предустановкой.

| Коннектор | Изображение | Количество регулируемых точек |
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

Количество и смысл регулируемых точек являются частью выбранной предустановки коннектора. Не следует предполагать, что два разных типа коннекторов используют одинаковую структуру коллекции.

## **Соединить две фигуры**

Используйте [IShapeCollection.addConnector](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) для добавления коннектора и методы [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) и [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) для привязки его концов. После привязки обоих концов [IConnector.reroute](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/#reroute--) выбирает короткий маршрут между фигурами.

Ниже приводится пример, соединяющий эллипс и прямоугольник изгиб‑наклонённым коннектором:

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
Вызов `reroute` может изменить значения [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) и [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). После пере‑маршрутизации назначайте конкретные точки соединения, если они должны оставаться фиксированными.
{{% /alert %}}

## **Выбор точки соединения**

Каждая соединяемая фигура сообщает количество своих точек через [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Проверьте предпочтительный нулевой индекс точки перед её назначением коннектору; количество точек зависит от геометрии фигуры.

В этом примере коннектор привязывается к определённой точке эллипса, если такая точка существует:

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

## **Регулировка точки коннектора**

Коннекторы с регулируемыми точками открывают их через [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/java/com.aspose.slides/igeometryshape/#getAdjustments--). Просмотрите каждый [IAdjustValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/) и проверьте его значение [getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/#getType--) перед изменением с помощью [setRawValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Общие правила определения предустановок регулировок фигур описаны в разделе [Манипулирование фигурами](/slides/ru/java/shape-manipulations/).

Количество, порядок, смысл и допустимый диапазон значений регулировок коннектора зависят от предустановки коннектора. Тип регулировки только для чтения, а значение можно изменять. Метод только для чтения [getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/#getName--) предоставляет дополнительную идентификацию, когда у коннектора несколько регулировок одного и того же семантического типа.

### **Обход препятствия**

На следующем макете коннектор `BentConnector5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Код, создающий такой препятствующий коннектор:

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

Перемещение вертикального изгиба меняет маршрут так, чтобы коннектор обходил препятствие:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо предположения, что индекс коллекции `1` всегда обозначает вертикальный изгиб, пример ищет `ConnectorBendPositionY` и меняет его только при наличии ожидаемого семантического типа:

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

У `BentConnector5` две регулировки `ConnectorBendPositionX` и одна `ConnectorBendPositionY`. Если нужный тип встречается более одного раза, проверьте `getName` и известную геометрию предустановки перед выбором. Если регулировка возвращает `ShapeAdjustmentType.Custom`, рассматривайте её смысл и диапазон как специфичные для предустановки и не изменяйте её, пока контракт не будет известен.

## **Связь значений регулировок с геометрией коннектора**

Для изгиб‑наклонённых коннекторов значения регулировок могут использоваться для оценки позиций отдельных сегментов. Эти расчёты специфичны для предустановки коннектора:

- `BentConnector4` обычно раскрывает одну регулировку `ConnectorBendPositionX` и одну `ConnectorBendPositionY`.
- Для этих позиций изгиба деление значения, полученного через `getRawValue`, на `100000f` даёт долю ширины или высоты рамки коннектора, используемую в примерах ниже.
- Рамка коннектора может быть вращена или отражена, поэтому координаты рамки следует преобразовать перед сравнением с координатами слайда.

Ниже приведены примеры, использующие `getType` для идентификации регулировок. Они не используют индексы коллекции как переносимые идентификаторы.

### **Невращённый коннектор**

Исходный макет содержит две текстовые фигуры, соединённые `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример исследует коннектор и получает его горизонтальные и вертикальные регулировки изгиба:

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

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

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

В результате получаем коннектор, у которого горизонтальные и вертикальные сегменты сместились:

![connector-adjusted-1](connector-adjusted-1.png)

После того как семантические типы известны, их значения можно преобразовать в координаты рамки коннектора. Пример рисует тонкий прямоугольник над вертикальным сегментом, контролируемым двумя изгибами:

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

Фигура‑помощник отмечает вычисленный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Вращённый или отражённый коннектор**

Когда та же геометрия коннектора ориентирована вертикально, значения [IShape.getFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapeframe/#getFlipH--) и [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapeframe/#getFlipV--) влияют на преобразование координат из рамки коннектора в координаты слайда.

Этот пример создаёт и регулирует вертикально ориентированный коннектор:

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

Отрегулированный коннектор появляется вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла вращения `alpha` вращайте точку рамки коннектора `(x, y)` вокруг её центра `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает 90‑градусную ориентацию, использованную в этом примере, и рисует красную направляющую над соответствующим сегментом коннектора:

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

Красная направляющая отмечает вычисленный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, используемые в примерах, а не универсальную модель коннектора. Проверяйте типы регулировок, ориентацию рамки и диапазоны значений перед применением тех же расчётов к другой предустановке.

## **Определение угла направления коннектора**

Направление прямого коннектора может быть вычислено из его ширины и высоты с учётом горизонтального и вертикального отражения. Ниже пример, выводящий угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

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

## **ЧаВо**

**Как узнать, может ли коннектор присоединиться к фигуре?**

Проверьте значение [getConnectionSiteCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getConnectionSiteCount--) у фигуры. Положительное число означает, что фигура имеет точки соединения. Проверьте выбранный индекс точки перед её назначением коннектору.

**Могу ли я идентифицировать регулировку коннектора по индексу коллекции?**

Индекс имеет смысл только для известной предустановки коннектора и структуры коллекции. Перед изменением значения проверьте [IAdjustValue.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/#getType--), а при множественном появлении одного семантического типа используйте [IAdjustValue.getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iadjustvalue/#getName--) как дополнительную информацию.

**Что происходит, когда соединённая фигура удаляется?**

Соответствующий конец коннектора открепляется. Коннектор остаётся на слайде и может быть удалён, превращён в свободную линию или присоединён к другой фигуре.

**Сохраняются ли привязки коннектора при копировании слайда?**

Привязки обычно сохраняются, когда копируются связанные фигуры вместе со слайдом. Если коннектор копируется без одной из целевых фигур, конец, который потерял привязку, необходимо снова присоединить.