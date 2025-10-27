---
title: Pythonでプレゼンテーションのコネクタを管理する
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
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
description: "Python アプリで PowerPoint および OpenDocument のスライドに線を描画、接続、自動経路設定できるようにし、直線、エルボー、曲線コネクタをフルコントロールします。"
---

## **はじめに**

PowerPoint のコネクタは、2 つの図形を結びつけ、スライド上で図形を移動または再配置しても接続されたままになる特殊な線です。コネクタは図形上の **接続点**（緑の点）に取り付けられます。ポインタが接続点に近づくと表示されます。特定のコネクタには **調整ハンドル**（黄色の点）があり、コネクタの位置や形状を変更できます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角度付き）、曲線の 3 種類のコネクタが使用できます。

Aspose.Slides がサポートするコネクタの種類は次のとおりです。

| コネクタの種類                | 画像                                                       | 調整点の数 |
| ----------------------------- | ---------------------------------------------------------- | ---------- |
| `ShapeType.LINE`              | ![Line connector](shapetype-lineconnector.png)            | 0          |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0          |
| `ShapeType.BENT_CONNECTOR2`   | ![Bent connector 2](shapetype-bent-connector2.png)        | 0          |
| `ShapeType.BENT_CONNECTOR3`   | ![Bent connector 3](shapetype-bentconnector3.png)         | 1          |
| `ShapeType.BENT_CONNECTOR4`   | ![Bent connector 4](shapetype-bentconnector4.png)         | 2          |
| `ShapeType.BENT_CONNECTOR5`   | ![Bent connector 5](shapetype-bentconnector5.png)         | 3          |
| `ShapeType.CURVED_CONNECTOR2` | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0          |
| `ShapeType.CURVED_CONNECTOR3` | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1          |
| `ShapeType.CURVED_CONNECTOR4` | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2          |
| `ShapeType.CURVED_CONNECTOR5` | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3          |

## **コネクタで図形を接続する**

このセクションでは、Aspose.Slides でコネクタを使用して図形同士を接続する方法を示します。スライドにコネクタを追加し、開始点と終了点を対象の図形に接続します。接続ポイントを使用すると、図形が移動またはサイズ変更してもコネクタが「くっついた」ままになります。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) が提供する `add_auto_shape` メソッドで、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. 同じく [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) の `add_connector` メソッドを使い、コネクタの種類を指定して追加します。  
5. コネクタで図形を接続します。  
6. `reroute` メソッドを呼び出して、最短接続パスを適用します。  
7. プレゼンテーションを保存します。

以下の Python コードは、楕円と矩形の間にベンドコネクタを追加する例です。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1 枚目のスライドの Shapes コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 矩形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 図形をコネクタで接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 最短経路に再ルーティングします。
    connector.reroute()

    # プレゼンテーションを保存します。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute` メソッドはコネクタを再ルーティングし、図形間の最短パスを取らせます。これにより、`start_shape_connection_site_index` と `end_shape_connection_site_index` の値が変更されることがあります。
{{% /alert %}}

## **接続ポイントを指定する**

このセクションでは、Aspose.Slides でコネクタを特定の接続ポイントに取り付ける方法を説明します。正確な接続サイトを指定することで、コネクタの経路とレイアウトを制御し、プレゼンテーション内に整った図を作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `add_auto_shape` を使用して 2 つの AutoShape をスライドに追加します。  
4. `add_connector` でコネクタを追加し、種類を指定します。  
5. コネクタで図形を接続します。  
6. 図形上の好みの接続ポイントを設定します。  
7. プレゼンテーションを保存します。

以下のコードは、好みの接続ポイントを指定する例です。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1 枚目のスライドの Shapes コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 矩形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドの ShapeCollection にコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 図形をコネクタで接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 楕円側の好みの接続サイトインデックスを設定します。
    site_index = 6

    # インデックスが利用可能なサイト数以内か確認します。
    if ellipse.connection_site_count > site_index:
        # 楕円 AutoShape の好みの接続サイトを割り当てます。
        connector.start_shape_connection_site_index = site_index

    # プレゼンテーションを保存します。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタの調整点を変更する**

調整点が公開されているコネクタは、調整点を使って形状を変更できます。どのコネクタが調整をサポートしているかは、[コネクタの種類](/slides/ja/python-net/connector/#connector-types) の表をご参照ください。

### **シンプルなケース**

2 つの図形 (A と B) を結ぶコネクタが、別の図形 (C) と交差している場合を考えます。

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

3 番目の図形を回避するため、垂直セグメントを左に移動してコネクタを調整します。

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **複雑なケース**

高度な調整を行う場合のポイント:

- 調整点は位置を決める数式に従います。数式を変更するとコネクタ全体の形が変わります。  
- 調整点は開始点から終了点へ向かう厳密な順序で配列に格納されます。  
- 調整点の値はコネクタ形状の幅/高さに対するパーセンテージです。  
  - 幅と高さは開始点と終了点で決まり、1000 でスケーリングされます。  
  - 1 番目、2 番目、3 番目の調整点はそれぞれ幅、 高さ、 再び幅 のパーセンテージを表します。  
- 調整点座標を計算する際は、コネクタの回転と反転を考慮します。**注:** [コネクタの種類](/slides/ja/python-net/connector/#connector-types) に列挙されたすべてのコネクタは回転角が 0 です。

#### **ケース 1**

テキストフレーム 2 つをコネクタで接続する例です。

![Linked shapes](connector-shape-complex.png)

コード例:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1 枚目のスライドを取得します。
    slide = presentation.slides[0]

    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # コネクタを追加します。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 矢印の形状を設定します。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 色を設定します。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 線幅を設定します。
    connector.line_format.width = 3

    # 図形をコネクタで接続します。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 調整点を取得します。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**調整**

幅のパーセンテージを 20% 増加し、 高さのパーセンテージを 200% 増加させます。

```python
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 1](connector-adjusted-1.png)

次に、`connector.adjustments[0]` の位置に対応する垂直コンポーネントの形状を作成し、セグメント座標と形状をモデル化します。

```python
    # コネクタの垂直コンポーネントを描画します。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果:

![Connector adjustment 2](connector-adjusted-2.png)

#### **ケース 2**

ケース 1 で示した単純な調整に加え、回転や表示設定 (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`) を考慮した例です。

まず、スライドに新しいテキストフレーム (**To 1**) を追加し、既存オブジェクトへ接続する緑のコネクタを作成します。

```python
    # 新しいターゲットオブジェクトを作成します。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 新しいコネクタを作成します。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # コネクタでオブジェクトを接続します。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 調整点を取得します。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 調整点の値を変更します。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 3](connector-adjusted-3.png)

次に、`connector.adjustments[0]` を通過する **水平** セグメントに対応する形状を作成し、回転と反転を考慮した座標変換式を適用します。

```python
    # コネクタの座標を保存します。
    x = connector.x
    y = connector.y
    
    # 反転がある場合は座標を補正します。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 調整点の値を座標として使用します。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1, cos(90°)=0 のため座標を変換します。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 第二の調整点の値で水平セグメントの幅を決定します。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果:

![Connector adjustment 4](connector-adjusted-4.png)

これらの例で、シンプルな調整から回転を考慮した高度な調整までを示しました。この知識を活用して、スライド座標から `GraphicsPath` を取得したり、特定の座標に基づいてコネクタの調整点を設定したりするモデルやコードを作成できます。

## **コネクタラインの角度を求める**

以下のサンプルを使って、Aspose.Slides でスライド上のコネクタラインの角度を算出します。コネクタの端点を取得し、向きを計算することで、矢印やラベル、他の図形を正確に配置できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. コネクタラインのシェイプにアクセスします。  
4. ラインの幅・高さとシェイプフレームの幅・高さを用いて角度を計算します。

角度を計算する Python コード例:

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

**コネクタが特定の図形に「くっつく」かどうかはどうやって確認しますか？**

図形が [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) を提供しているか確認します。接続サイトが存在しない、または数が 0 の場合は「くっつき」機能は利用できません。その場合はフリーエンドポイントを使用して手動で位置を設定するとよいでしょう。接続前にサイト数をチェックするのが賢明です。

**接続されている図形の一方を削除したらコネクタはどうなりますか？**

コネクタの端は切り離され、スライド上には自由端の普通の線として残ります。不要であれば削除するか、再度接続先を割り当て、必要に応じて [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーした場合、コネクタのバインディングは保持されますか？**

通常は保持されますが、コピー先に接続対象の図形も同時にコピーされていることが前提です。接続先の図形が存在しない状態でスライドだけを挿入した場合、端はフリーになり、再度接続し直す必要があります。