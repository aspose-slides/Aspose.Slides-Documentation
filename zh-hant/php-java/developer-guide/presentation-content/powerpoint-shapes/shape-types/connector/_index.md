---
title: 使用 PHP 在簡報中管理連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/php-java/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線段
- 連接線角度
- 連接點
- 調整點
- 連接形狀
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP（透過 Java）新增、附加、重新路由、調整與檢查直線、彎曲與曲線的 PowerPoint 連接線。"
---
## **概觀**

連接線是一條在任一形狀移動時仍能保持連接到兩個形狀的直線。其兩端連接到連接點，在 PowerPoint 中以綠點表示。某些彎曲與曲線連接線還會顯示調整點，以橙點表示，可控制單個連接線段的位置。

Aspose.Slides 透過 [Connector](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/) 類別來表示連接線。您可以建立連接線、將兩端附加到形狀、選擇連接點、重新路由，並修改具有調整點的連接線幾何形狀。

## **連接線類型**

[ShapeType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapetype/) 類別包含直線、彎曲與曲線連接線預設。下表顯示可用的連接線幾何形狀以及每個預設所定義的調整點數量。

| 連接線 | 圖片 | 調整點數量 |
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

調整點的數量與意義屬於所選的連接線預設。不要假設兩種不同的連接線類型會顯示相同的集合佈局。

## **連接兩個形狀**

使用 [ShapeCollection::addConnector](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addconnector/) 新增連接線，並使用 [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/setstartshapeconnectedto/) 與 [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/setendshapeconnectedto/) 連接其兩端。兩端皆連接後，[Connector::reroute](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/reroute/) 會在形狀之間選擇最短路徑。

以下範例使用彎曲連接線將橢圓與矩形連接：

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

{{% alert color="warning" title="警告" %}}
呼叫 `reroute` 可能會更改 [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) 與 [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) 的值。若必須固定該連接點，請在重新路由後再指定特定連接點。
{{% /alert %}}

## **選擇連接點**

每個可連接的形狀會透過 [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getconnectionsitecount/) 回傳其連接點數量。在將索引指派給連接線端點之前，請先驗證所偏好的零基索引；不同形狀的幾何會導致連接點數量不同。

以下範例在橢圓上存在的特定連接點時，將連接線附加至該點：

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

## **調整連接點**

具有調整點的連接線會透過 [GeometryShape::getAdjustments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/geometryshape/#getadjustments) 取得。檢查每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/) 並在變更前確認其 [AdjustValue::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/#gettype) 值。使用 [AdjustValue::setRawValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/setrawvalue/) 變更值。關於辨識預設形狀調整的通用規則，請參閱 [Shape Manipulation](/slides/zh-hant/php-java/shape-manipulations/)。

調整點的數量、順序、意義與有效值範圍皆取決於連接線預設。調整類型為唯讀，調整值則可寫。唯讀的 [AdjustValue::getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/getname/) 方法在同一語意類型出現多次時提供額外識別資訊。

### **繞過障礙物的路徑**

在下列版面配置中，`BentConnector5` 連接線在兩個形狀之間穿過第三個形狀：

![connector-obstruction](connector-obstruction.png)

此程式碼建立受阻的連接線：

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

移動垂直彎曲會改變路徑，使連接線繞過障礙物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

此範例不假設集合索引 `1` 總是代表垂直彎曲，而是搜尋 `ConnectorBendPositionY`，僅在出現預期語意類型時才變更：

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

`BentConnector5` 具有兩個 `ConnectorBendPositionX` 調整以及一個 `ConnectorBendPositionY` 調整。如果所需類型出現多次，請在選取之前檢查 `getName` 並參考該預設的已知幾何。若調整回傳 `ShapeAdjustmentType::Custom`，則其意義與範圍屬於特定預設，除非已明確了解合約，否則不要修改。

## **將調整值與連接線幾何關聯**

對於彎曲連接線，調整值可用於估算各段位置。以下計算僅適用於相應的連接線預設：

- `BentConnector4` 通常會公開一個 `ConnectorBendPositionX` 與一個 `ConnectorBendPositionY` 調整。
- 對於這些彎曲位置，將 `getRawValue` 的回傳值除以 `100000`，即可得到下例所使用的連接框寬度或高度的比例。
- 連接框可能會旋轉或翻轉，故在與投影片座標比較前必須先轉換框座標。

以下範例先使用 `getType` 來識別調整點，並不將集合索引視為可移植的識別符號。

### **未旋轉的連接線**

初始版面包含兩個文字形狀，由 `BentConnector4` 連接：

![connector-shape-complex](connector-shape-complex.png)

此範例檢查連接線並取得水平與垂直彎曲的調整值：

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

若要同時變更兩個彎曲，請先找到每個預期類型，確認兩者皆存在後再修改值：

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

結果是一條水平與垂直段落皆已移動的連接線：

![connector-adjusted-1](connector-adjusted-1.png)

一旦確定語意類型，可將其值轉換為連接框座標。此範例在由兩個彎曲調整控制的垂直段上繪製細長矩形：

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

導引形狀標示計算出的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋轉或翻轉的連接線**

當相同的連接線幾何垂直定位時，其 [Shape::getFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getframe/)、[ShapeFrame::getFlipH](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/getfliph/)、以及 [ShapeFrame::getFlipV](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/getflipv/) 會影響從連接框座標到投影片座標的轉換。

此範例建立並調整垂直方向的連接線：

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

調整後的連接線在形狀之間垂直顯示：

![connector-adjusted-3](connector-adjusted-3.png)

對於任意旋轉角度 `alpha`，將連接框點 `(x, y)` 圍繞框中心 `(x0, y0)` 旋轉：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`
`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下程式碼處理本範例使用的 90 度方向，並在相應的連接線段上繪製紅色導引：

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

紅色導引在座標轉換後標示計算出的段落：

![connector-adjusted-4](connector-adjusted-4.png)

這些公式說明的是範例中使用的預設，並非通用連接線模型。在將相同計算套用至不同預設前，必須驗證調整類型、框的方向以及值範圍。

## **尋找連接線方向角度**

直線連接線的方向可根據其寬度與高度計算，並考慮水平與垂直翻轉。以下範例回報投影片座標系統中正水平軸的順時針角度：

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

## **常見問題**

**如何判斷連接線是否能附加到形狀？**

檢查形狀的 [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getconnectionsitecount/) 值。正值表示該形狀提供連接點。在指派給任一連接線端點前，先驗證所選的連接點索引。

**我可以依據集合索引識別連接線調整嗎？**

索引僅在已知的連接線預設與集合佈局下才具有意義。在修改值之前，先檢查 [AdjustValue::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/#gettype)，若同一語意類型出現多次，則以 [AdjustValue::getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/getname/) 作為額外識別資訊。

**當連接的形狀被刪除時會發生什麼事？**

對應的連接線端點會被分離。連接線仍保留在投影片上，您可以刪除、將其視為自由線條，或重新附加到其他形狀。

**在複製投影片時，連接線的綁定會被保留嗎？**

當連接的形狀與投影片一起被複製時，綁定通常會被保留。如果僅複製連接線而未同時複製其目標形狀，則必須重新附加受影響的端點。