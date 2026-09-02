---
title: PHP を使用したプレゼンテーションでのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/php-java/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- 接続サイト
- 調整ポイント
- 図形を接続
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint の直線、曲がり、曲線コネクタを追加、接続、再ルーティング、調整、検査する方法を学びます。"
---
## **概要**

コネクタは、どちらかの図形が移動しても2つの図形に接続されたままにできる線です。その端は接続サイトに接続され、PowerPoint では緑の点で表されます。曲がったコネクタや曲線コネクタの中には、オレンジの点で表される調整ポイントがあり、個々のコネクタセグメントの位置を制御します。

Aspose.Slides はコネクタを [Connector](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/) クラスで表します。コネクタの作成、端を図形に接続、接続サイトの選択、再ルーティング、調整ポイントを持つコネクタのジオメトリの変更が可能です。

## **コネクタの種類**

[ShapeType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapetype/) クラスには、直線、曲がり、曲線コネクタのプリセットが含まれます。以下の表は、利用可能なコネクタジオメトリと各プリセットで定義された調整ポイントの数を示しています。

| コネクタ | 画像 | 調整ポイント数 |
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

調整ポイントの数と意味は、選択されたコネクタプリセットの一部です。異なるコネクタタイプが同じコレクションレイアウトを提供するとは限りません。

## **2つの図形を接続する**

コネクタを追加するには [ShapeCollection::addConnector](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addconnector/) を使用し、端を接続するには [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/setstartshapeconnectedto/) と [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/setendshapeconnectedto/) を使用します。両端が接続された後、[Connector::reroute](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/reroute/) が図形間の短い経路を選択します。

次の例は、楕円と矩形を曲がりコネクタで接続します。

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

{{% alert color="warning" title="Warning" %}}

`reroute` を呼び出すと、[Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) と [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) の値が変更される可能性があります。再ルーティング後に特定の接続サイトが固定されている必要がある場合は、明示的にサイトを再設定してください。

{{% /alert %}}

## **接続サイトを選択する**

接続可能な各図形は、[Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getconnectionsitecount/) を通じてサイト数を報告します。図形ジオメトリによりサイト数は異なるため、コネクタ端に割り当てる前に零ベースのサイトインデックスを検証してください。

この例は、該当するサイトが存在する場合に楕円上の特定のサイトにコネクタを接続します。

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

## **コネクタポイントを調整する**

調整ポイントを持つコネクタは、[GeometryShape::getAdjustments](https://reference.aspose.com/slides/ja/php-java/aspose.slides/geometryshape/#getadjustments) を介してそれらを公開します。各 [AdjustValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/) を検査し、変更前にその [AdjustValue::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/#gettype) を確認し、[AdjustValue::setRawValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/setrawvalue/) で変更します。プリセット形状の調整の一般的な規則は [Shape Manipulation](/slides/ja/php-java/shape-manipulations/) に記載されています。

コネクタ調整の数、順序、意味、および有効な値範囲はコネクタプリセットに依存します。調整タイプは読み取り専用ですが、調整値は書き込み可能です。複数の同一セマンティックタイプの調整がある場合、読み取り専用の [AdjustValue::getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/getname/) メソッドが追加の識別情報を提供します。

### **障害物の回り込み**

以下のレイアウトでは、2つの図形間の `BentConnector5` が3つ目の図形を通過しています。

![connector-obstruction](connector-obstruction.png)

このコードは障害物があるコネクタを作成します。

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

垂直の曲がりを移動すると、コネクタは障害物を回避するように経路が変更されます。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

インデックス `1` が常に垂直曲がりを表すと仮定せず、以下の例では `ConnectorBendPositionY` を検索し、期待されるセマンティックタイプが存在する場合にのみ変更します。

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

`BentConnector5` には `ConnectorBendPositionX` が2つ、`ConnectorBendPositionY` が1つあります。必要なタイプが複数回出現する場合は、`getName` とそのプリセットの既知ジオメトリを確認してから選択してください。調整が `ShapeAdjustmentType::Custom` を返す場合、その意味と範囲はプリセット固有とみなし、契約が明確になるまで変更しないでください。

## **調整値とコネクタジオメトリの関連付け**

曲がりコネクタでは、調整値を使用して個々のセグメントの位置を概算できます。これらの計算はコネクタプリセット固有です。

- `BentConnector4` は通常、`ConnectorBendPositionX` と `ConnectorBendPositionY` の各1つの調整を公開します。
- これらの曲がり位置については、`getRawValue` が返す値を `100000` で除算すると、以下の例で使用されるコネクタフレームの幅または高さの割合が得られます。
- コネクタフレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換が必要です。

以下の例は `getType` で調整を識別し、コレクションインデックスをポータブルな識別子として使用しません。

### **回転していないコネクタ**

最初のレイアウトは、`BentConnector4` で接続された2つのテキスト図形を含みます。

![connector-shape-complex](connector-shape-complex.png)

この例はコネクタを調査し、水平および垂直の曲がり調整を取得します。

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

両方の曲がりを変更するには、期待されるタイプをそれぞれ見つけ、両方が見つかった後に値を変更します。

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

結果として、水平および垂直セグメントが移動したコネクタが得られます。

![connector-adjusted-1](connector-adjusted-1.png)

セマンティックタイプが判明したら、その値をコネクタフレーム座標に変換できます。この例は、2つの曲がり調整で制御される垂直セグメント上に細い矩形を描画します。

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

ガイド図形は計算されたセグメントを示します。

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転したコネクタ**

同じコネクタジオメトリが垂直に配置された場合、[Shape::getFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getframe/)、[ShapeFrame::getFlipH](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapeframe/getfliph/)、[ShapeFrame::getFlipV](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapeframe/getflipv/) の値がコネクタフレーム座標からスライド座標への変換に影響します。

この例は垂直方向に配置されたコネクタを作成し、調整します。

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

調整されたコネクタは図形間に垂直に表示されます。

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角度 `alpha` に対して、コネクタフレーム点 `(x, y)` をフレーム中心 `(x0, y0)` の周りで回転させる式は次のとおりです。

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用される 90 度の向きに対応し、対応するコネクタセグメント上に赤いガイドを描画します。

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

赤いガイドは座標変換後の計算されたセグメントを示します。

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用されるプリセットを説明しており、汎用コネクタモデルを示すものではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、値範囲を必ず検証してください。

## **コネクタの方向角度を求める**

直線コネクタの方向は、その幅と高さ、および水平・垂直の反転を考慮して計算できます。次の例は、スライド座標系で正の水平軸から時計回りの角度を報告します。

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

**コネクタが図形に接続できるかどうかはどうやって判断できますか？**

図形の [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getconnectionsitecount/) を確認してください。正のカウントがある場合、その図形は接続サイトを公開しています。コネクタ端に割り当てる前に、選択したサイトインデックスを必ず検証してください。

**コネクタの調整をコレクションインデックスで特定できますか？**

インデックスは既知のコネクタプリセットとコレクションレイアウトに対してのみ意味があります。値を変更する前に [AdjustValue::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/#gettype) を確認し、同一セマンティックタイプが複数存在する場合は [AdjustValue::getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/getname/) を追加情報として使用してください。

**接続された図形が削除された場合はどうなりますか？**

該当するコネクタ端は切り離されます。コネクタ自体はスライド上に残り、削除したり、フリーラインとして配置したり、別の図形に再接続したりできます。

**スライドをコピーしたときにコネクタのバインディングは保持されますか？**

接続された図形とともにスライドがコピーされる場合、バインディングは一般的に保持されます。コネクタだけがコピーされ、対象図形のいずれかが欠けている場合は、影響を受けた端を再度接続する必要があります。