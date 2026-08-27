---
title: Quản lý các connector trong bài thuyết trình bằng PHP
linktitle: Kết nối
type: docs
weight: 10
url: /vi/php-java/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- vị trí kết nối
- điểm điều chỉnh
- kết nối các hình
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, xác định lại lộ trình, điều chỉnh và kiểm tra các connector thẳng, uốn và cong của PowerPoint với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Một connector là một đường có thể vẫn gắn vào hai shape khi một shape di chuyển. Các đầu của nó gắn vào các connection site, được biểu thị bằng các chấm xanh trong PowerPoint. Một số connector cong và uốn cũng hiển thị các adjustment point, được biểu thị bằng các chấm cam, điều khiển vị trí của các segment connector riêng lẻ.

Aspose.Slides đại diện cho các connector thông qua lớp [Connector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/) . Bạn có thể tạo chúng, gắn các đầu vào shape, chọn connection site, reroute chúng và sửa đổi geometry của các connector có adjustment point.

## **Các loại connector**

Lớp [ShapeType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/) bao gồm các preset connector thẳng, bent và curved. Bảng dưới đây hiển thị các geometry connector khả dụng và số adjustment point được định nghĩa cho mỗi preset.

| Connector | Image | Number of adjustment points |
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

Số và ý nghĩa của các adjustment point là một phần của preset connector đã chọn. Đừng giả định rằng hai loại connector khác nhau đều có cùng layout collection.

## **Kết nối hai shape**

Sử dụng [ShapeCollection::addConnector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addconnector/) để thêm một connector, và sử dụng [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/setstartshapeconnectedto/) và [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/setendshapeconnectedto/) để gắn các đầu của nó. Sau khi cả hai đầu đã được gắn, [Connector::reroute](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/reroute/) sẽ chọn một lộ trình ngắn giữa các shape.

Ví dụ sau kết nối một ellipse và một rectangle bằng một bent connector:

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

{{% alert color="warning" title="Cảnh báo" %}}
Gọi `reroute` có thể thay đổi giá trị của [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) và [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Gán các connection site cụ thể sau khi reroute nếu các site đó phải được giữ cố định.
{{% /alert %}}

## **Chọn vị trí kết nối**

Mỗi shape có thể kết nối báo cáo số lượng site của nó qua [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getconnectionsitecount/). Xác thực một chỉ số site (zero‑based) được ưa thích trước khi gán nó cho đầu connector; số lượng site thay đổi tùy vào geometry của shape.

Ví dụ này gắn connector vào một site cụ thể trên ellipse khi site đó tồn tại:

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

## **Điều chỉnh điểm connector**

Các connector có adjustment point sẽ lộ chúng qua [GeometryShape::getAdjustments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#getadjustments). Kiểm tra từng [AdjustValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/) và kiểm tra giá trị [AdjustValue::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/#gettype) trước khi thay đổi bằng [AdjustValue::setRawValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/setrawvalue/). Các quy tắc chung để xác định các shape adjustment preset được mô tả trong [Shape Manipulation](/slides/vi/php-java/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các adjustment connector phụ thuộc vào preset connector. Kiểu adjustment là read‑only, trong khi giá trị adjustment có thể ghi. Phương thức read‑only [AdjustValue::getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/getname/) cung cấp thông tin bổ sung khi một connector chứa nhiều hơn một adjustment có cùng semantic type.

### **Định tuyến quanh chướng ngại vật**

Trong layout dưới đây, một connector `BentConnector5` giữa hai shape đi qua một shape thứ ba:

![connector-obstruction](connector-obstruction.png)

Đoạn code này tạo connector bị cản trở:

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

Di chuyển bend dọc thay đổi lộ trình sao cho connector tránh chướng ngại vật:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định rằng chỉ mục collection `1` luôn đại diện cho bend dọc, ví dụ này tìm `ConnectorBendPositionY` và chỉ thay đổi nó khi semantic type dự kiến hiện diện:

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

Một `BentConnector5` có hai adjustment `ConnectorBendPositionX` và một `ConnectorBendPositionY`. Nếu kiểu bạn cần xuất hiện nhiều hơn một lần, kiểm tra `getName` và geometry đã biết của preset trước khi chọn. Nếu một adjustment báo cáo `ShapeAdjustmentType::Custom`, coi ý nghĩa và phạm vi của nó là đặc thù cho preset và không thay đổi cho đến khi hợp đồng này được xác định.

## **Liên quan giá trị adjustment tới geometry connector**

Đối với các bent connector, giá trị adjustment có thể được dùng để ước tính vị trí của các segment riêng lẻ. Các phép tính này là riêng cho preset connector:

- `BentConnector4` thường lộ một adjustment `ConnectorBendPositionX` và một `ConnectorBendPositionY`.
- Đối với các vị trí bend này, chia giá trị trả về bởi `getRawValue` cho `100000` sẽ cho phần tử của chiều rộng hoặc chiều cao của khung connector như trong các ví dụ dưới.
- Khung connector có thể được xoay hoặc lật, vì vậy các tọa độ khung phải được biến đổi trước khi so sánh với tọa độ slide.

Các ví dụ dưới đây sử dụng `getType` để xác định các adjustment trước. Chúng không xem xét chỉ mục collection là định danh di động.

### **Kết nối không xoay**

Layout ban đầu chứa hai shape văn bản được kết nối bởi một `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các adjustment bend ngang và dọc:

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

Để thay đổi cả hai bend, xác định mỗi loại mong đợi và chỉnh sửa giá trị chỉ sau khi cả hai đã được tìm thấy:

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

Kết quả là một connector mà các segment ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi các semantic type đã được xác định, giá trị của chúng có thể chuyển đổi thành tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng lên segment dọc được điều khiển bởi hai bend adjustment:

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

Shape hướng dẫn đánh dấu segment đã tính:

![connector-adjusted-2](connector-adjusted-2.png)

### **Kết nối xoay hoặc lật**

Khi geometry connector tương tự được định hướng theo chiều dọc, các giá trị [Shape::getFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/getfliph/), và [ShapeFrame::getFlipV](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/getflipv/) ảnh hưởng đến việc chuyển đổi từ tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector định hướng dọc:

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

Connector đã điều chỉnh xuất hiện dọc giữa các shape:

![connector-adjusted-3](connector-adjusted-3.png)

Đối với một góc xoay tùy ý `alpha`, xoay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Đoạn code sau xử lý hướng 90 độ được dùng trong ví dụ này và vẽ một guide màu đỏ lên segment connector tương ứng:

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
        echo "The connector does not expose the expected bend adjustments." . PHP::EOL;
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

Guide màu đỏ đánh dấu segment đã tính sau khi biến đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các preset được dùng trong các ví dụ, không phải một mô hình connector chung. Xác thực các loại adjustment, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho một preset khác.

## **Tìm góc hướng của connector**

Hướng của một straight connector có thể được tính từ chiều rộng và chiều cao của nó, kèm theo các flip ngang và dọc. Ví dụ dưới đây trả về góc đồng hồ từ trục ngang dương trong tọa độ slide:

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

## **Câu hỏi thường gặp**

**Làm sao tôi biết một connector có thể gắn vào một shape hay không?**

Kiểm tra giá trị [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getconnectionsitecount/) của shape. Giá trị dương có nghĩa là shape cung cấp connection site. Xác thực chỉ mục site được chọn trước khi gán cho bất kỳ đầu connector nào.

**Tôi có thể xác định một connector adjustment bằng chỉ mục collection không?**

Một chỉ mục chỉ có ý nghĩa đối với một preset connector đã biết và layout collection. Kiểm tra [AdjustValue::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/#gettype) trước khi sửa đổi giá trị, và sử dụng [AdjustValue::getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/getname/) như thông tin bổ sung khi cùng một semantic type xuất hiện nhiều lần.

**Điều gì xảy ra khi một shape được kết nối bị xóa?**

Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, chuyển thành một đường tự do, hoặc gắn lại vào một shape khác.

**Các binding của connector có được giữ lại khi slide được sao chép không?**

Binding thường được giữ khi các shape được kết nối được sao chép cùng slide. Nếu một connector được sao chép mà không có một trong các shape mục tiêu, đầu bị ảnh hưởng phải được gắn lại.