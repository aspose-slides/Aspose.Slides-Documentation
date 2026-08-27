---
title: Android でのプレゼンテーションにおけるコネクタの管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/androidjava/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- 接続サイト
- 調整ポイント
- 形状の接続
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java で Aspose.Slides を使用し、PowerPoint の直線、曲げ、曲線コネクタを追加、接続、再ルーティング、調整、検査する方法を学びます。"
---
## **概要**

コネクタは、どちらかの形状が移動しても 2 つの形状に接続されたままにできる線です。  
その端は接続サイトに接続され、PowerPoint では緑の点で表されます。  
一部の曲がったコネクタや曲線コネクタは、オレンジの点で表される調整ポイントも公開しており、個々のコネクタセグメントの位置を制御します。

Aspose.Slides はコネクタを [IConnector](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/) インターフェイスで表します。  
コネクタを作成し、端を形状に接続し、接続サイトを選択し、再ルーティングし、調整ポイントを持つコネクタのジオメトリを変更できます。

## **コネクタの種類**

[ShapeType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapetype/) クラスには、直線、曲がり、曲線コネクタのプリセットが含まれています。  
以下の表は、利用可能なコネクタジオメトリと各プリセットで定義された調整ポイント数を示しています。

| コネクタ | 画像 | 調整ポイント数 |
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

調整ポイントの数と意味は、選択されたコネクタプリセットの一部です。異なるコネクタタイプが同じコレクションレイアウトを公開していると想定しないでください。

## **2つの形状を接続する**

[IShapeCollection.addConnector](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) を使用してコネクタを追加し、[IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) と [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) を使用して端を接続します。両端が接続された後、[IConnector.reroute](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/#reroute--) が形状間の最短ルートを選択します。

次の例は、楕円と長方形を曲げコネクタで接続します。

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
`reroute` を呼び出すと、[setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) と [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) の値が変更される可能性があります。これらのサイトを固定したままにする必要がある場合は、再ルーティング後に特定の接続サイトを割り当ててください。
{{% /alert %}}

## **接続サイトを選択する**

接続可能な各形状は、[IShape.getConnectionSiteCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) を介してサイト数を報告します。コネクタの端に割り当てる前に、希望するゼロベースのサイトインデックスが有効か確認してください。サイト数は形状のジオメトリによって異なります。

この例は、該当するサイトが存在する場合に楕円の特定のサイトにコネクタを接続します。

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

## **コネクタポイントを調整する**

調整ポイントを持つコネクタは、[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) でそれらを公開します。すべての [IAdjustValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/) を検査し、[setRawValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) で変更する前にその [getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getType--) の値を確認してください。プリセット形状の調整を識別する一般的なルールは、[Shape Manipulation](/slides/ja/androidjava/shape-manipulations/) に記載されています。

コネクタの調整の数、順序、意味、および有効な値の範囲は、コネクタプリセットに依存します。調整タイプは読み取り専用で、調整値は書き込み可能です。同一のセマンティックタイプが複数存在する場合、読み取り専用の [getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getName--) メソッドが追加の識別情報を提供します。

### **障害物の回避**

以下のレイアウトでは、2 つの形状間の `BentConnector5` が 3 つ目の形状を通過しています。

![connector-obstruction](connector-obstruction.png)

このコードは、障害物があるコネクタを作成します。

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

垂直の曲げを移動すると、ルートが変更され、コネクタが障害物を回避します。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

コレクションインデックス `1` が常に垂直の曲げを表すと想定する代わりに、この例は `ConnectorBendPositionY` を検索し、期待されるセマンティックタイプが存在する場合にのみ変更します。

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

`BentConnector5` には 2 つの `ConnectorBendPositionX` 調整と 1 つの `ConnectorBendPositionY` 調整があります。必要なタイプが複数回現れる場合は、`getName` とそのプリセットの既知ジオメトリを確認してから選択してください。調整が `ShapeAdjustmentType.Custom` を報告する場合、その意味と範囲はプリセット固有とみなし、契約が明確になるまで変更しないでください。

## **調整値をコネクタジオメトリに関連付ける**

曲がったコネクタの場合、調整値を使用して個々のセグメントの位置を推定できます。これらの計算はコネクタプリセット固有です。

- `BentConnector4` は通常、1 つの `ConnectorBendPositionX` と 1 つの `ConnectorBendPositionY` 調整を公開します。  
- これらの曲げ位置については、`getRawValue` が返す値を `100000f` で除算すると、以下の例で使用されるコネクタフレームの幅または高さの割合が得られます。  
- コネクタフレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換する必要があります。

以下の例は、まず `getType` を使用して調整を特定します。コレクションインデックスを移植可能な識別子として扱いません。

### **回転していないコネクタ**

初期レイアウトには、`BentConnector4` で接続された 2 つのテキスト形状があります。

![connector-shape-complex](connector-shape-complex.png)

この例では、コネクタを検査し、その水平および垂直の曲げ調整を取得します。

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

両方の曲げを変更するには、各期待されるタイプを見つけ、両方が見つかった後に値を変更します。

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

結果は、水平セグメントと垂直セグメントが移動したコネクタです。

![connector-adjusted-1](connector-adjusted-1.png)

セマンティックタイプが判明したら、その値をコネクタフレーム座標に変換できます。この例は、2 つの曲げ調整で制御される垂直セグメント上に細い矩形を描画します。

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

ガイド形状が計算されたセグメントを示しています。

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転したコネクタ**

同じコネクタジオメトリが垂直に配置される場合、[IShape.getFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getFrame--)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapeframe/#getFlipH--)、および [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapeframe/#getFlipV--) の値が、コネクタフレーム座標からスライド座標への変換に影響します。

この例では、縦向きのコネクタを作成し、調整します。

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

調整されたコネクタは形状間に垂直に表示されます。

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角 `alpha` に対して、コネクタフレーム点 `(x, y)` をフレーム中心 `(x0, y0)` 周りで回転させます：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用された 90 度の向きに対応し、対応するコネクタセグメント上に赤いガイドを描画します。

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

座標変換後に計算されたセグメントを赤いガイドが示しています。

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用されたプリセットを記述したものであり、汎用的なコネクタモデルではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、値範囲を検証してください。

## **コネクタの方向角を求める**

直線コネクタの方向は、幅と高さから水平・垂直の反転を考慮して計算できます。以下の例は、スライド座標系で正の水平軸から時計回りの角度を報告します。

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

**コネクタが形状に接続できるかどうかはどう判断できますか？**  
形状の [getConnectionSiteCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) の値を確認してください。正の数であれば、その形状は接続サイトを公開しています。コネクタの端に割り当てる前に、選択したサイトインデックスが有効か検証してください。

**コレクションインデックスだけでコネクタの調整を特定できますか？**  
インデックスは既知のコネクタプリセットとコレクションレイアウトに対してのみ有意味です。値を変更する前に [IAdjustValue.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getType--) を確認し、同一のセマンティックタイプが複数存在する場合は [IAdjustValue.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getName--) を追加情報として使用してください。

**接続された形状が削除された場合はどうなりますか？**  
対応するコネクタの端は切り離されます。コネクタ自体はスライド上に残り、削除したり、フリーラインとして配置したり、別の形状に再接続したりできます。

**スライドをコピーしたときにコネクタのバインディングは保持されますか？**  
接続された形状とともにスライドがコピーされる場合、バインディングは一般的に保持されます。コネクタだけがコピーされ、対象形状が欠けている場合は、影響を受けた端を再度接続する必要があります。