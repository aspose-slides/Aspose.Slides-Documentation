---
title: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
keywords: "形状を接続, コネクタ, PowerPoint 形状, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointの形状を接続する"
---

PowerPointのコネクタは、2つの形状を接続またはリンクする特別な線であり、与えられたスライド上で移動または再配置されても形状に固定されます。 

コネクタは通常、すべての形状にデフォルトで存在する*接続点*（緑の点）に接続されます。接続点はカーソルが近づくと表示されます。

*調整ポイント*（オレンジの点）は、特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPointでは、直線、肘（角度付き）、および曲線コネクタを使用できます。 

Aspose.Slidesはこれらのコネクタを提供します：

| コネクタ                       | 画像                                                        | 調整ポイントの数       |
| ---------------------------- | ------------------------------------------------------------ | --------------------- |
| `ShapeType.LINE`              | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                     |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                     |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                     |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                     |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                     |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                     |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                     |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                     |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                     |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                     |

## **コネクタを使って形状を接続する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトによって公開された`add_auto_shape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。
1. コネクタタイプを定義して`Shapes`オブジェクトによって公開された`add_auto_shape`メソッドを使用して、コネクタを追加します。
1. コネクタを使用して形状を接続します。
1. `reroute`メソッドを呼び出して、最短接続パスを適用します。
1. プレゼンテーションを保存します。 

以下のPythonコードは、2つの形状（楕円と長方形）の間にコネクタ（曲がったコネクタ）を追加する方法を示しています：

```python
import aspose.slides as slides

# PPTXファイルを表すプレゼンテーションクラスをインスタンス化
with slides.Presentation() as input:
    # 特定のスライドの形状コレクションにアクセス
    shapes = input.slides[0].shapes

    # 楕円自動形状を追加
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # 長方形自動形状を追加
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # スライド形状コレクションにコネクタ形状を追加
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # コネクタを使用して形状を接続
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 形状間の自動最短パスを設定する再ルートを呼び出す
    connector.reroute()

    # プレゼンテーションを保存
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="注意"  color="warning"   %}} 

`connector.reroute`メソッドはコネクタを再ルートさせ、形状間で可能な限り最短のパスを取るよう強制します。この目的を達成するために、メソッドは`start_shape_connection_site_index`および`end_shape_connection_site_index`ポイントを変更する場合があります。 

{{% /alert %}} 

## **接続点を指定する**

コネクタが形状の特定の点を使用して2つの形状をリンクするようにしたい場合は、好みの接続点をこのように指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトによって公開された`add_auto_shape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。
1. コネクタタイプを定義して`Shapes`オブジェクトによって公開された`add_connector`メソッドを使ってコネクタを追加します。
1. コネクタを使用して形状を接続します。
1. 形状上の好みの接続点を設定します。 
1. プレゼンテーションを保存します。

以下のPythonコードは、好ましい接続点が指定される操作を示しています：

```python
import aspose.slides as slides

# PPTXファイルを表すプレゼンテーションクラスをインスタンス化
with slides.Presentation() as presentation:
    # 特定のスライドの形状コレクションにアクセス
    shapes = presentation.slides[0].shapes

    # スライドの形状コレクションにコネクタ形状を追加
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 楕円自動形状を追加
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # 長方形自動形状を追加
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # コネクタを使用して形状を接続
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 楕円形状上の好ましい接続点インデックスを設定
    wantedIndex = 6

    # 指定されたインデックスが最大サイトインデックス数未満であるか確認
    if ellipse.connection_site_count > wantedIndex:
        # 楕円自動形状の好ましい接続点を設定
        connector.start_shape_connection_site_index = wantedIndex

    # プレゼンテーションを保存
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **コネクタポイントを調整する**

既存のコネクタは、その調整ポイントを通じて調整できます。調整ポイントを持つコネクタのみがこの方法で変更できます。 **[コネクタの種類](/slides/ja/python-net/connector/#types-of-connectors)**の下の表を参照してください。

#### **簡単なケース**

2つの形状（AとB）の間のコネクタが、3つ目の形状（C）を通る場合を考えてみましょう：

![connector-obstruction](connector-obstruction.png)

コード：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

3つ目の形状を回避または迂回するために、コネクタの垂直線を左に移動させることで調整できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **複雑なケース** 

より複雑な調整を行うには、以下の点を考慮する必要があります：

* コネクタの調整ポイントは、その位置を計算し決定する数式に強く関連しています。したがって、ポイントの位置を変更すると、コネクタの形状が変わる可能性があります。
* コネクタの調整ポイントは、コネクタの開始点から終了点までの厳密な順序で定義されています。調整ポイントは、コネクタの起点から終点まで番号付けされています。
* 調整ポイントの値は、コネクタ形状の幅/高さのパーセンテージを反映します。 
  * 形状は、コネクタの開始点と終了点で1000倍されたものに制約されます。 
  * 最初のポイント、2番目のポイント、3番目のポイントは、それぞれ幅からのパーセンテージ、高さからのパーセンテージ、幅からのパーセンテージ（再び）を定義します。
* コネクタの調整ポイントの座標を決定する計算では、コネクタの回転と反射を考慮する必要があります。**注意**： **[コネクタの種類](/slides/ja/python-net/connector/#types-of-connectors)**の下に示されているすべてのコネクタの回転角度は0です。

#### **ケース 1**

2つのテキストフレームオブジェクトがコネクタを介して接続されている場合を考えてみましょう：

![connector-shape-complex](connector-shape-complex.png)

コード：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すプレゼンテーションクラスをインスタンス化
with slides.Presentation() as pres:
    # プレゼンテーションの最初のスライドを取得
    sld = pres.slides[0]
    # コネクタを介して結合される形状を追加
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "From"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "To"
    # コネクタを追加
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # コネクタの方向を指定
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # コネクタの色を指定
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # コネクタの線の太さを指定
    connector.line_format.width = 3

    # コネクタで形状を結びつける
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # コネクタの調整ポイントを取得
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**調整**

コネクタの調整ポイント値を、幅と高さのパーセンテージをそれぞれ20％と200％増加させることで変更できます：

```python
    # 調整ポイントの値を変更
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの接続部分に対応する形状を描画するモデルを定義するために、コネクタの.adjustments[0]ポイントでのコネクタの横成分に対応する形状を作成します：

```python
    # コネクタの垂直成分を描画

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1**では、基本的な原則を使用してコネクタの調整操作を簡単に示しました。通常の状況では、コネクタの回転と表示（これらは`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`で設定されています）を考慮する必要があります。プロセスを示します。

最初に、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、すでに作成したオブジェクトに接続するための新しい（緑色の）コネクタを作成します。

```python
    # 新しいバインディングオブジェクトを作成
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "To 1"
    # 新しいコネクタを作成
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # 新しく作成されたコネクタを使用してオブジェクトを接続
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connected_to = 3
    # コネクタの調整ポイントを取得
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # 調整ポイントの値を変更 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント`connector.adjustments[0]`を通過するコネクタの横成分に対応する形状を作成します。コネクタデータから`connector.rotation`、`connector.frame.flip_h`、および`connector.frame.flip_v`の値を使用し、与えられた点の周りの回転の一般的な座標変換公式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この場合、オブジェクトの回転角度は90度で、コネクタは垂直に表示されるため、次のようにコードを記述します：

```python
    # コネクタ座標を保存
    x = connector.x
    y = connector.y
    # コネクタが表示された場合の座標を修正
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 調整ポイントの値を座標として取り込む
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 角度を考慮して座標を変換（Sin(90) = 1 および Cos(90) = 0）
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 新しい接点の幅を定義
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

簡単な調整や複雑な調整ポイント（回転角度を持つ調整ポイント）に関与する計算を示しました。得た知識を基に、自分のモデル（またはコードを書いて）`GraphicsPath`オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定することができます。

## **コネクタ線の角度を見つける**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. コネクタ線の形状にアクセスします。
1. 線の幅、高さ、形状フレームの高さ、および形状フレームの幅を使用して角度を計算します。

以下のPythonコードは、コネクタ線の形状の角度を計算する操作を示しています：

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```