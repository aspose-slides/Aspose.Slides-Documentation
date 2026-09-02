---
title: Управление соединителями в презентациях с использованием PHP
linktitle: Соединитель
type: docs
weight: 10
url: /ru/php-java/connector/
keywords:
- соединитель
- тип соединителя
- точка соединителя
- линия соединителя
- угол соединителя
- точка подключения
- точка регулировки
- соединить фигуры
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять, присоединять, перенаправлять, регулировать и просматривать прямые, согнутые и изогнутые соединители PowerPoint с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Соединитель — это линия, которая может оставаться привязанной к двум фигурам, когда любая из фигур перемещается. Его концы присоединяются к точкам подключения, отображаемым в PowerPoint в виде зеленых точек. Некоторые согнутые и изогнутые соединители также имеют точки регулировки, отображаемые оранжевыми точками, которые контролируют положение отдельных сегментов соединителя.

Aspose.Slides представляет соединители с помощью класса [Connector](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/). Вы можете создавать их, присоединять их концы к фигурам, выбирать точки подключения, перенаправлять их и изменять геометрию соединителей, имеющих точки регулировки.

## **Типы соединителей**

Класс [ShapeType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapetype/) включает предустановки прямых, согнутых и изогнутых соединителей. В следующей таблице показаны доступные геометрии соединителей и количество точек регулировки, определённых каждой предустановкой.

| Соединитель | Изображение | Количество точек регулировки |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Количество и смысл точек регулировки являются частью выбранной предустановки соединителя. Не следует предполагать, что два разных типа соединителей предоставляют одинаковую структуру коллекции.

## **Подключить две фигуры**

Для добавления соединителя используйте [ShapeCollection::addConnector](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addconnector/). Чтобы присоединить его концы, используйте [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/setstartshapeconnectedto/) и [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/setendshapeconnectedto/). После присоединения обоих концов [Connector::reroute](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/reroute/) выбирает короткий путь между фигурами.

В следующем примере соединитель с изгибом соединяет эллипс и прямоугольник:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Предупреждение" %}}
Вызов `reroute` может изменить значения [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) и [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). После перенаправления назначьте конкретные точки подключения, если они должны оставаться фиксированными.
{{% /alert %}}

## **Выбор точки подключения**

Каждая подключаемая фигура сообщает количество своих точек через [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getconnectionsitecount/). Перед назначением индекса точки (нумерация с нуля) проверяйте его корректность; количество точек зависит от геометрии фигуры.

В этом примере соединитель присоединяется к конкретной точке на эллипсе, если такая точка существует:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Регулировка точки соединителя**

Соединители с точками регулировки предоставляют их через [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/geometryshape/#getadjustments). Просмотрите каждое [AdjustValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/) и проверьте значение [AdjustValue::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/#gettype) перед изменением с помощью [AdjustValue::setRawValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/setrawvalue/). Общие правила определения точек регулировки предустановок фигур описаны в разделе [Манипуляция фигурами](/slides/ru/php-java/shape-manipulations/).

Количество, порядок, смысл и допустимый диапазон значений точек регулировки соединителя зависят от предустановки соединителя. Тип регулировки только для чтения, в то время как значение регулировки доступно для записи. Метод только для чтения [AdjustValue::getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/getname/) предоставляет дополнительную идентификацию, когда в соединителе более одной регулировки одного и того же семантического типа.

### **Обход препятствия**

В следующей схеме соединитель `BentConnector5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт соединитель с препятствием:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Перемещение вертикального изгиба изменяет маршрут так, чтобы соединитель обходил препятствие:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо того чтобы предполагать, что индекс коллекции `1` всегда представляет вертикальный изгиб, данный пример ищет `ConnectorBendPositionY` и изменяет его только когда ожидаемый семантический тип присутствует:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

`BentConnector5` имеет две регулировки `ConnectorBendPositionX` и одну `ConnectorBendPositionY`. Если нужный вам тип встречается более одного раза, проверьте `getName` и известную геометрию этой предустановки перед выбором. Если регулировка возвращает `ShapeAdjustmentType::Custom`, рассматривайте её смысл и диапазон как специфичные для предустановки и не меняйте её, пока этот контракт не будет известен.

## **Соотношение значений регулировки с геометрией соединителя**

Для согнутых соединителей значения регулировки можно использовать для оценки положения отдельных сегментов. Эти вычисления специфичны для предустановки соединителя:

- `BentConnector4` обычно предоставляет одну регулировку `ConnectorBendPositionX` и одну `ConnectorBendPositionY`.
- Для этих позиций изгиба деление значения, возвращаемого `getRawValue`, на `100000` даёт долю ширины или высоты кадра соединителя, как показано в примерах ниже.
- Кадр соединителя может быть повернут или отражён, поэтому координаты кадра необходимо преобразовать перед сравнением с координатами слайда.

В следующих примерах сначала используется `getType` для идентификации регулировок. Они не рассматривают индексы коллекции как переносимые идентификаторы.

### **Не повернутый соединитель**

Исходная схема содержит две текстовые фигуры, соединённые `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример исследует соединитель и получает его горизонтальные и вертикальные регулировки изгиба:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Результатом будет соединитель, у которого горизонтальные и вертикальные сегменты сместились:

![connector-adjusted-1](connector-adjusted-1.png)

После того как семантические типы известны, их значения можно преобразовать в координаты кадра соединителя. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, управляемым двумя регулировками изгиба:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый соединитель**

Когда та же геометрия соединителя ориентирована вертикально, её значения [Shape::getFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapeframe/getfliph/), и [ShapeFrame::getFlipV](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapeframe/getflipv/) влияют на преобразование координат кадра соединителя в координаты слайда.

В этом примере создаётся и регулируется вертикально ориентированный соединитель:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла вращения `alpha` точку кадра соединителя `(x, y)` вокруг центра кадра `(x0, y0)` вращают так:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает ориентацию на 90 градусов, используемую в этом примере, и рисует красную направляющую над соответствующим сегментом соединителя:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Красная направляющая отмечает рассчитанный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель соединителя. Проверьте типы регулировок, ориентацию кадра и диапазоны значений перед применением тех же вычислений к другой предустановке.

## **Найти угол направления соединителя**

Направление прямого соединителя можно вычислить по его ширине и высоте, учитывая горизонтальные и вертикальные отражения. В следующем примере выводится угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Как определить, может ли соединитель присоединяться к фигуре?**

Проверьте значение [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getconnectionsitecount/). Положительное количество значит, что у фигуры есть точки подключения. Проверьте выбранный индекс точки перед назначением его как концу соединителя.

**Могу ли я идентифицировать регулировку соединителя по её индексу в коллекции?**

Индекс имеет смысл только для известной предустановки соединителя и структуры коллекции. Проверьте [AdjustValue::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/#gettype) перед изменением значения и используйте [AdjustValue::getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/getname/) как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.

**Что происходит, если подключённая фигура удаляется?**

Соответствующий конец соединителя открепляется. Соединитель остаётся на слайде и может быть удалён, размещён как свободная линия или присоединён к другой фигуре.

**Сохраняются ли привязки соединителей при копировании слайда?**

Привязки обычно сохраняются при копировании слайда вместе с подключёнными фигурами. Если соединитель копируется без одной из целевых фигур, соответствующий конец нужно снова присоединить.