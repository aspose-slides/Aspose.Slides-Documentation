---
title: Управление коннекторами в презентациях с использованием JavaScript
linktitle: Коннектор
type: docs
weight: 10
url: /ru/nodejs-java/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- точка соединения
- точка регулировки
- соединять фигуры
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять, присоединять, перенаправлять, регулировать и просматривать прямые, изгибные и изогнутые коннекторы PowerPoint с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Коннектор — это линия, которая может оставаться присоединённой к двум фигурам, когда любая из фигур перемещается. Его концы присоединяются к точкам соединения, обозначенным зелёными точками в PowerPoint. Некоторые изогнутые и гибкие коннекторы также имеют регулируемые точки, отображаемые оранжевыми точками, которые контролируют положение отдельных сегментов коннектора.

Aspose.Slides представляет коннекторы через класс [Коннектор](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/). Вы можете создавать их, присоединять их концы к фигурам, выбирать точки соединения, изменять маршрут и менять геометрию коннекторов, имеющих регулирующие точки.

## **Типы коннекторов**

Класс [ShapeType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapetype/) включает предустановки прямых, сгибных и изогнутых коннекторов. В таблице ниже показаны доступные геометрии коннекторов и количество регулирующих точек, определённых для каждой предустановки.

| Коннектор | Изображение | Количество регулирующих точек |
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

Количество и значение регулирующих точек являются частью выбранной предустановки коннектора. Не следует предполагать, что два разных типа коннекторов предоставляют одинаковую структуру коллекции.

## **Соединить две фигуры**

Используйте [ShapeCollection.addConnector](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/addconnector/) для добавления коннектора и используйте [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) и [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) для присоединения его концов. После присоединения обоих концов [Connector.reroute](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/reroute/) выбирает кратчайший маршрут между фигурами.

Следующий пример соединяет эллипс и прямоугольник с помощью сгибного коннектора:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Предупреждение" %}}
Вызов `reroute` может изменить значения [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) и [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Установите конкретные точки соединения после изменения маршрута, если эти точки должны оставаться фиксированными.
{{% /alert %}}

## **Выбор точки соединения**

Каждая соединяемая фигура сообщает количество точек через [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Проверьте желаемый индекс точки (нумерация с нуля) перед присвоением его коннектору; количество точек зависит от геометрии фигуры.

В этом примере коннектор присоединяется к определённой точке на эллипсе, если такая точка существует:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10;

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Регулировка точки коннектора**

Коннекторы с регулируемыми точками раскрывают их через [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/geometryshape/). Просмотрите каждое [AdjustValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/) и проверьте его значение [getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/) перед изменением с помощью [setRawValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Общие правила идентификации регулировок предустановленных фигур описаны в разделе [Shape Manipulation](/slides/ru/nodejs-java/shape-manipulations/).

Количество, порядок, смысл и допустимый диапазон значений регулировок коннектора зависят от предустановки коннектора. Тип регулировки только для чтения, тогда как значение можно изменять. Метод только для чтения [getName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/getname/) предоставляет дополнительную идентификацию, когда у коннектора более одной регулировки одного и того же семантического типа.

### **Обход препятствия**

На следующем макете коннектор `BentConnector5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт препятствующий коннектор:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Перемещение вертикального изгиба изменяет маршрут, так что коннектор обходится вокруг препятствия:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо того чтобы предполагать, что индекс коллекции `1` всегда представляет вертикальный изгиб, данный пример ищет `ConnectorBendPositionY` и изменяет его только когда присутствует ожидаемый семантический тип:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5` содержит две регулировки `ConnectorBendPositionX` и одну `ConnectorBendPositionY`. Если нужный тип встречается более одного раза, проверьте `getName` и известную геометрию этой предустановки перед выбором. Если регулировка возвращает `ShapeAdjustmentType.Custom`, рассматривайте её смысл и диапазон как специфичные для предустановки и не изменяйте её, пока не будет известен соответствующий контракт.

## **Связание значений регулировок с геометрией коннектора**

Для изгибных коннекторов значения регулировок можно использовать для оценки позиций отдельных сегментов. Эти расчёты специфичны для предустановки коннектора:

- `BentConnector4` обычно имеет одну регулировку `ConnectorBendPositionX` и одну `ConnectorBendPositionY`.
- Для этих положений изгиба деление значения, возвращаемого `getRawValue`, на `100000` даёт долю ширины или высоты рамки коннектора, используемую в примерах ниже.
- Рамка коннектора может быть повернута или отражена, поэтому координаты рамки необходимо преобразовать перед сравнением с координатами слайда.

В следующих примерах сначала используется `getType` для определения регулировок. Индексы коллекции не рассматриваются как переносимые идентификаторы.

### **Неповернутый коннектор**

Исходный макет содержит две текстовые фигуры, соединённые `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример проверяет коннектор и получает его горизонтальные и вертикальные регулировки изгиба:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

В результате получаем коннектор, у которого горизонтальные и вертикальные сегменты сместились:

![connector-adjusted-1](connector-adjusted-1.png)

После определения семантических типов их значения можно преобразовать в координаты рамки коннектора. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, контролируемым двумя регулировками изгиба:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Форма‑направляющая отмечает вычисленный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый коннектор**

Когда та же геометрия коннектора ориентирована вертикально, её значения [Shape.getFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapeframe/getfliph/), и [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapeframe/getflipv/) влияют на преобразование координат рамки коннектора в координаты слайда.

Этот пример создаёт и регулирует вертикально ориентированный коннектор:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Отрегулированный коннектор отображается вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла поворота `alpha` поверните точку рамки коннектора `(x, y)` вокруг центра рамки `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает 90‑градусную ориентацию, использованную в этом примере, и рисует красную направляющую над соответствующим сегментом коннектора:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Красная направляющая отмечает вычисленный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель коннектора. Проверьте типы регулировок, ориентацию рамки и диапазоны значений перед применением тех же расчётов к другой предустановке.

## **Найти угол направления коннектора**

Направление прямого коннектора можно вычислить по его ширине и высоте с учётом горизонтального и вертикального отражения. В следующем примере выводится угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **ЧаВо**

**Как понять, может ли коннектор присоединяться к фигуре?**

Проверьте значение [getConnectionSiteCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getconnectionsitecount/) у фигуры. Положительное значение означает, что фигура предоставляет точки соединения. Проверьте выбранный индекс точки перед присвоением его концу коннектора.

**Можно ли идентифицировать регулировку коннектора по её индексу в коллекции?**

Индекс имеет смысл только для известной предустановки коннектора и структуры коллекции. Проверьте [AdjustValue.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/) перед изменением значения и используйте [AdjustValue.getName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/getname/) как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.

**Что происходит, когда соединённая фигура удаляется?**

Соответствующий конец коннектора отсоединяется. Коннектор остаётся на слайде и может быть удалён, размещён как свободная линия или присоединён к другой фигуре.

**Сохраняются ли привязки коннектора при копировании слайда?**

Привязки обычно сохраняются при копировании слайда вместе с соединёнными фигурами. Если коннектор копируется без одной из целевых фигур, соответствующий конец необходимо присоединить заново.