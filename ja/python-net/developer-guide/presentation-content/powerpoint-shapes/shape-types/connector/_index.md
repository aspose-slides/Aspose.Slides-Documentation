---
title: プレゼンテーションでPythonを使ってコネクタを管理する
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
keywords:
- コネクタ
- コネクタの種類
- コネクタポイント
- コネクタライン
- コネクタ角度
- シェイプを接続する
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PythonアプリでPowerPointおよびOpenDocumentスライド上に線を描画、接続、自動ルーティングし、直線、エルボー、曲線コネクタを完全に制御します。"
---

## **はじめに**

PowerPoint のコネクタは、2 つのシェイプを結び付け、スライド上でシェイプが移動または位置変更されても接続されたままになる特殊な線です。コネクタはシェイプの **接続ポイント**（緑の点）に取り付けられます。ポインタが接続ポイントに近づくと表示されます。特定のコネクタに用意されている **調整ハンドル**（黄色の点）を使うと、コネクタの位置や形状を変更できます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角度付き）、曲線の 3 種類のコネクタを使用できます。

Aspose.Slides がサポートするコネクタの種類は次のとおりです。

| コネクタタイプ                  | 画像                                                        | 調整ポイント数 |
| ------------------------------- | ----------------------------------------------------------- | -------------- |
| `ShapeType.LINE`                | ![Line connector](shapetype-lineconnector.png)            | 0              |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0              |
| `ShapeType.BENT_CONNECTOR2`     | ![Bent connector 2](shapetype-bent-connector2.png)        | 0              |
| `ShapeType.BENT_CONNECTOR3`     | ![Bent connector 3](shapetype-bentconnector3.png)         | 1              |
| `ShapeType.BENT_CONNECTOR4`     | ![Bent connector 4](shapetype-bentconnector4.png)         | 2              |
| `ShapeType.BENT_CONNECTOR5`     | ![Bent connector 5](shapetype-bentconnector5.png)         | 3              |
| `ShapeType.CURVED_CONNECTOR2`   | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0              |
| `ShapeType.CURVED_CONNECTOR3`   | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1              |
| `ShapeType.CURVED_CONNECTOR4`   | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2              |
| `ShapeType.CURVED_CONNECTOR5`   | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3              |

## **シェイプをコネクタで接続する**

このセクションでは、Aspose.Slides でシェイプをコネクタで結び付ける方法を示します。スライドにコネクタを追加し、開始点と終了点を対象シェイプに接続します。接続サイトを使用すると、シェイプが移動またはサイズ変更されてもコネクタが「接着」された状態を保てます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを `add_auto_shape` メソッドで 2 つスライドに追加します（ShapeCollection が提供）。  
1. `add_connector` メソッドでコネクタを追加し、コネクタタイプを指定します（ShapeCollection が提供）。  
1. コネクタでシェイプ同士を接続します。  
1. `reroute` メソッドを呼び出して最短接続経路を適用します。  
1. プレゼンテーションを保存します。

以下の Python コードは、楕円と長方形の間にベンドコネクタを追加する例です。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1枚目のスライドのシェイプコレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 長方形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # コネクタでシェイプを接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # reroute を呼び出して最短経路を設定します。
    connector.reroute()

    # プレゼンテーションを保存します。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

`connector.reroute` メソッドはコネクタを再ルーティングし、シェイプ間で可能な限り最短のパスを取らせます。その際、`start_shape_connection_site_index` と `end_shape_connection_site_index` の値が変更されることがあります。

{{% /alert %}}

## **接続ポイントの指定**

このセクションでは、Aspose.Slides でシェイプ上の特定の接続ポイントにコネクタを取り付ける方法を説明します。正確な接続サイトを指定することで、コネクタのルーティングとレイアウトを制御し、プレゼンテーション内にきれいで予測可能な図を作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `add_auto_shape` メソッドで 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) をスライドに追加します（ShapeCollection が提供）。  
1. `add_connector` メソッドでコネクタを追加し、コネクタタイプを指定します（ShapeCollection が提供）。  
1. コネクタでシェイプを接続します。  
1. シェイプ上で希望する接続ポイントを設定します。  
1. プレゼンテーションを保存します。

以下の Python コードは、希望の接続ポイントを指定する例です。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1枚目のスライドのシェイプコレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 長方形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドのシェイプコレクションにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # コネクタでシェイプを接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 楕円側の希望接続サイトインデックスを設定します。
    site_index = 6

    # インデックスが利用可能なサイト数以内か確認します。
    if ellipse.connection_site_count > site_index:
        # 楕円の AutoShape に希望の接続サイトを割り当てます。
        connector.start_shape_connection_site_index = site_index

    # プレゼンテーションを保存します。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタポイントの調整**

調整ポイントを持つコネクタは、これらのポイントを使って形状を変更できます。調整ポイントを提供しないコネクタはこの方法で編集できません。どのコネクタが調整に対応しているかは、[コネクタの種類](/slides/ja/python-net/connector/#connector-types) の表をご参照ください。

### **シンプルなケース**

2 つのシェイプ（A と B）を結ぶコネクタが、3 番目のシェイプ（C）と交差しているケースを考えます。

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
    connector.end_shape_connection_site_index = 2
```

3 番目のシェイプを回避するため、コネクタの垂直セグメントを左に移動させます。

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **複雑なケース**

より高度な調整を行う場合は、次の点に留意してください。

- コネクタの調整ポイントは、位置を決定する数式に従います。数式を変更するとコネクタ全体の形状が変わります。  
- 調整ポイントは、コネクタの開始点から終了点へ向かう厳密な順序の配列に格納されます。  
- 調整ポイントの値は、コネクタ形状の幅・高さに対するパーセンテージで表されます。  
  - シェイプはコネクタの開始点と終了点で囲まれ、1000 でスケーリングされます。  
  - 第 1, 第 2, 第 3 調整ポイントはそれぞれ「幅のパーセンテージ」「高さのパーセンテージ」「再び幅のパーセンテージ」を表します。  
- 調整ポイント座標を算出する際は、コネクタの回転と反転を考慮します。**注意:** [コネクタの種類](/slides/ja/python-net/connector/#connector-types) に列挙されているすべてのコネクタは回転角度が 0 です。

#### **Case 1**

テキストフレームオブジェクト 2 つがコネクタで結ばれているケースです。

![Linked shapes](connector-shape-complex.png)

コード例:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成して PPTX ファイルを生成します。
with slides.Presentation() as presentation:

    # 1枚目のスライドを取得。
    slide = presentation.slides[0]

    # シェイプを作成。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # コネクタを追加。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # コネクタの矢印先端を設定。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # コネクタの色を設定。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # コネクタの線幅を設定。
    connector.line_format.width = 3

    # シェイプをコネクタで接続。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # コネクタの調整ポイントを取得。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**調整**

幅のパーセンテージを 20%、高さのパーセンテージを 200% 増やして調整ポイントの値を変更します。

```python
    # 調整ポイントの値を変更。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 1](connector-adjusted-1.png)

コネクタの垂直セグメントに対応するシェイプを作成し、`connector.adjustments[0]` の位置を描画します。

```python
    # コネクタの垂直セグメントを描画。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果:

![Connector adjustment 2](connector-adjusted-2.png)

#### **Case 2**

**Case 1** で示したシンプルな調整に加えて、コネクタの回転と表示設定（`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`）を考慮する必要があります。以下に手順を示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、既存オブジェクトと結ぶ緑のコネクタを作成します。

```python
    # 新しいターゲットオブジェクトを作成。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 新しいコネクタを作成。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 作成したコネクタでオブジェクトを接続。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # コネクタの調整ポイントを取得。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 調整ポイントの値を変更。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 3](connector-adjusted-3.png)

次に、`connector.adjustments[0]` を通るコネクタの **水平** セグメントに対応するシェイプを作成します。`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` の値と、回転中心 `x0` 周りの標準座標変換式を使用します。

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

本例ではオブジェクトの回転角が 90 度で、コネクタは垂直に表示されるため、コードは次のようになります。

```python
    # コネクタの座標を保存。
    x = connector.x
    y = connector.y
    
    # 反転がある場合は座標を補正。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 調整ポイントの値を座標として使用。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1、cos(90°)=0 のため座標を変換。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 第 2 調整ポイントの値で水平セグメントの幅を決定。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果:

![Connector adjustment 4](connector-adjusted-4.png)

以上で、シンプルな調整と回転を考慮した複雑な調整ポイントの計算例を示しました。この知識を元に、スライド座標に基づく `GraphicsPath` オブジェクトの取得や、コネクタの調整ポイント値の設定を行うモデルやコードを自作できます。

## **コネクタラインの角度を求める**

以下の例を使って、Aspose.Slides でスライド上のコネクタラインの角度を求めます。コネクタの端点を取得し、方向を計算することで、矢印やラベル、その他のシェイプを正確に配置できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. コネクタラインのシェイプにアクセスします。  
1. ラインの幅・高さとシェイプフレームの幅・高さを使って角度を計算します。

以下の Python コードは、コネクタラインシェイプの角度を計算する方法を示します。

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

**コネクタが特定のシェイプに「接着」できるかどうかはどう確認できますか？**  
シェイプが [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) を公開しているか確認してください。存在しないかカウントが 0 の場合は接着できません。その場合はフリーエンドポイントを使用し、手動で配置します。接続前にサイト数を確認すると安全です。

**接続されたシェイプの一方を削除した場合、コネクタはどうなりますか？**  
コネクタの端は切り離され、スライド上に普通の線として残ります。削除するか、再度接続し直し、必要に応じて [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**  
一般的に保持されますが、対象シェイプも一緒にコピーされている必要があります。接続されたシェイプが存在しないままスライドを挿入すると、端がフリーになり、再接続が必要です。