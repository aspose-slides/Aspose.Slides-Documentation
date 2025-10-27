---
title: Manage Connectors in Presentations with Python
linktitle: Connector
type: docs
weight: 10
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connect shapes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Empower Python apps to draw, connect and auto-route lines in PowerPoint & OpenDocument slides—gain full control over straight, elbow and curved connectors."
---

## **はじめに**

PowerPoint のコネクタは、2 つの図形を結び付け、スライド上で図形を移動または再配置しても接続されたままになる特殊な線です。コネクタは図形上の **接続点**（緑の点）に取り付けられます。ポインタが接続点に近づくと表示されます。特定のコネクタに用意されている **調整ハンドル**（黄色の点）を使うと、コネクタの位置や形状を変更できます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角型）、曲線の 3 種類のコネクタを使用できます。

Aspose.Slides がサポートしているコネクタの種類は次のとおりです。

| Connector Type                  | Image                                                     | Number of adjustment points |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![Line connector](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Bent connector 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Bent connector 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Bent connector 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Bent connector 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3                           |

## **コネクタで図形を接続する**

このセクションでは、Aspose.Slides で図形をコネクタで結び付ける方法を示します。スライドにコネクタを追加し、開始点と終了点を対象の図形に接続します。接続点を使用すると、図形が移動やサイズ変更をした際にも「貼り付けられた」状態が保たれます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) が提供する `add_auto_shape` メソッドで、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. 同じく [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) が提供する `add_connector` メソッドでコネクタを追加し、コネクタの種類を指定します。  
5. コネクタで図形を接続します。  
6. `reroute` メソッドを呼び出して最短接続パスを適用します。  
7. プレゼンテーションを保存します。

以下の Python コードは、楕円と矩形の間にベンドコネクタを追加する例です。

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the shortest path.
    connector.reroute()

    # Save the presentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

`connector.reroute` メソッドはコネクタを再ルーティングし、図形間の最短パスを取らせます。そのため、`start_shape_connection_site_index` と `end_shape_connection_site_index` の値が変更されることがあります。

{{% /alert %}}

## **接続点の指定**

このセクションでは、Aspose.Slides で図形上の特定の接続点にコネクタを取り付ける方法を説明します。正確な接続サイトを指定することで、コネクタのルーティングやレイアウトを制御し、プレゼンテーション上に整然とした予測可能な図を作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `add_auto_shape` メソッドで 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) をスライドに追加します。  
4. `add_connector` メソッドでコネクタを追加し、種類を指定します。  
5. コネクタで図形を接続します。  
6. 図形上の希望する接続点を設定します。  
7. プレゼンテーションを保存します。

以下のコードは、希望する接続点を指定する例です。

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide's shape collection.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Set the preferred connection site index on the ellipse.
    site_index = 6

    # Check that the preferred index is within the available site count.
    if  ellipse.connection_site_count > site_index:
        # Assign the preferred connection site on the ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Save the presentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタの調整ポイントの変更**

調整ポイントを利用してコネクタを変更できます。調整ポイントを公開しているコネクタだけがこの方法で編集可能です。どのコネクタが調整をサポートしているかは、[コネクタの種類](/slides/ja/python-net/connector/#connector-types) の表をご参照ください。

### **簡単なケース**

2 つの図形（A と B）の間のコネクタが、別の図形（C）と交差しているケースを考えます。

![Connector obstruction](connector-obstruction.png)

コード例:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

3 番目の図形を避けるため、コネクタの垂直セグメントを左に移動して調整します。

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **複雑なケース** 

より高度な調整例を示します。

- コネクタの調整ポイントは、位置を決定する数式に基づいています。数式を変更するとコネクタ全体の形が変わります。  
- 調整ポイントは、コネクタの開始点から終了点へ向かう順序で格納された厳密に順序付けられた配列です。  
- 調整ポイントの値は、コネクタ形状の幅／高さに対するパーセンテージです。  
  - 幅／高さは、開始点と終了点で決まる領域を 1000 でスケーリングしたものです。  
  - 第1・第2・第3 調整ポイントはそれぞれ幅％、高さ％、幅％（再び）を表します。  
- 調整ポイント座標を算出する際は、コネクタの回転や反転も考慮します。**注意:** [コネクタの種類](/slides/ja/python-net/connector/#connector-types) に列挙されているすべてのコネクタは回転角が 0 です。

#### **ケース 1**

2 つのテキストフレームをコネクタで結んだ例です。

![Linked shapes](connector-shape-complex.png)

コード例:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Get the first slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Add a connector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Set the connector's direction.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Set the connector's color.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Set the connector's line thickness.
    connector.line_format.width = 3

    # Link the shapes with the connector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Get the connector's adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**調整**

幅のパーセンテージを 20%、高さのパーセンテージを 200% 増やして調整ポイントの値を変更します。

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 1](connector-adjusted-1.png)

コネクタのセグメント座標と形状を求めるモデルを作成するため、`connector.adjustments[0]` に対応する垂直コンポーネントの形状を描画します。

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果:

![Connector adjustment 2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では基本的な調整手順を示しましたが、実際のシナリオではコネクタの回転や表示設定（`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`）も考慮する必要があります。以下に手順を示します。

最初にスライドに新しいテキストフレーム（**To 1**）を作成し、既存オブジェクトと結ぶ緑色のコネクタを作成します。

```python
    # Create a new target object.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Create a new connector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connect the objects using the newly created connector.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Get the connector adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 3](connector-adjusted-3.png)

次に、`connector.adjustments[0]` を通る **水平** セグメントに対応する形状を作成します。`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` の値と、点 `x0` 周りの回転変換式

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

を使用します。今回は回転角が 90°、コネクタが垂直表示なので以下のコードになります。

```python
    # Save the connector coordinates.
    x = connector.x
    y = connector.y
    
    # Correct the connector coordinates if it is flipped.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Use the adjustment point value as the coordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convert the coordinates because sin(90°) = 1 and cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determine the width of the horizontal segment using the second adjustment point value.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果:

![Connector adjustment 4](connector-adjusted-4.png)

これらの例により、単純な調整と回転を考慮した複雑な調整ポイントの計算方法が分かります。この知識を活用して、独自のモデルやコードを作成し、スライド座標に基づく `GraphicsPath` オブジェクト取得や、コネクタの調整ポイント値設定が可能になります。

## **コネクタラインの角度を求める**

以下のサンプルを使用して、Aspose.Slides でスライド上のコネクタラインの角度を取得します。コネクタの端点を読み取り、向きを計算することで、矢印やラベル、他の図形を正確に配置できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. コネクタラインのシェイプにアクセスします。  
4. ラインの幅・高さとシェイフレームの幅・高さを使用して角度を計算します。

角度計算の例コード:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**コネクタを特定の図形に「貼り付け」られるかどうかはどうやって判断しますか？**

図形が [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合は貼り付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数をチェックすることが推奨されます。

**接続された図形の一方を削除したらコネクタはどうなりますか？**

コネクタの端は切り離され、スライド上には通常の線として残ります（開始点・終了点が自由になります）。削除するか、再度接続先を割り当て、必要に応じて [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) を実行してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**

一般的には保持されますが、対象の図形も同様にコピーされている必要があります。接続された図形が存在しない状態でスライドだけを挿入した場合、コネクタの端は自由になり、再度接続し直す必要があります。