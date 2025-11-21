---
title: Python でプレゼンテーションのコネクタを管理する
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
keywords:
- コネクタ
- コネクタタイプ
- コネクタポイント
- コネクタライン
- コネクタ角度
- 図形を接続
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python アプリに PowerPoint および OpenDocument スライド上で線を描画し、接続し、自動ルーティングする能力を付与し、直線、エルボー、曲線コネクタを完全に制御できるようにします。"
---

## **はじめに**

PowerPoint のコネクタは、2 つの図形を結ぶ特殊な線で、スライド上で図形を移動または再配置しても接続されたままです。コネクタは図形上の **connection points**（緑の点）に接続します。ポインタが近づくと connection points が表示されます。特定のコネクタに利用できる **Adjustment handles**（黄色の点）を使用すると、コネクタの位置や形状を変更できます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（折れ線）、曲線の 3 種類のコネクタを使用できます。

Aspose.Slides は以下のコネクタの種類をサポートしています。

| コネクタの種類                | 画像                                                         | 調整ポイントの数 |
| ----------------------------- | ------------------------------------------------------------ | ---------------- |
| `ShapeType.LINE`              | ![直線コネクタ](shapetype-lineconnector.png)                | 0                |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![直線コネクタ 1](shapetype-straightconnector1.png)          | 0                |
| `ShapeType.BENT_CONNECTOR2`   | ![折れ線コネクタ 2](shapetype-bent-connector2.png)           | 0                |
| `ShapeType.BENT_CONNECTOR3`   | ![折れ線コネクタ 3](shapetype-bentconnector3.png)            | 1                |
| `ShapeType.BENT_CONNECTOR4`   | ![折れ線コネクタ 4](shapetype-bentconnector4.png)            | 2                |
| `ShapeType.BENT_CONNECTOR5`   | ![折れ線コネクタ 5](shapetype-bentconnector5.png)            | 3                |
| `ShapeType.CURVED_CONNECTOR2` | ![曲線コネクタ 2](shapetype-curvedconnector2.png)            | 0                |
| `ShapeType.CURVED_CONNECTOR3` | ![曲線コネクタ 3](shapetype-curvedconnector3.png)            | 1                |
| `ShapeType.CURVED_CONNECTOR4` | ![曲線コネクタ 4](shapetype-curvedconnector4.png)            | 2                |
| `ShapeType.CURVED_CONNECTOR5` | ![曲線コネクタ 5](shapetype.curvedconnector5.png)            | 3                |

## **コネクタで図形を接続する**

このセクションでは、Aspose.Slides で図形をコネクタでリンクする方法を示します。スライドにコネクタを追加し、開始点と終了点を対象の図形に接続します。接続サイトを使用すると、図形が移動またはサイズ変更されてもコネクタが「くっついた」状態を保ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトが提供する `add_auto_shape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトが提供する `add_connector` メソッドを使用してコネクタを追加し、コネクタの種類を指定します。  
1. コネクタで図形を接続します。  
1. `reroute` メソッドを呼び出して、最短接続パスを適用します。  
1. プレゼンテーションを保存します。

以下の Python コードは、楕円と矩形の間に折れ線コネクタを追加する方法を示しています:
```python
import aspose.slides as slides

# PPTX ファイルを作成するために Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドのシェイプ コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 矩形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # コネクタで図形を接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 最短パスを設定するために reroute を呼び出します。
    connector.reroute()

    # プレゼンテーションを保存します。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
`connector.reroute` メソッドはコネクタを再ルーティングし、図形間で可能な限り最短のパスを取らせます。その際、`start_shape_connection_site_index` と `end_shape_connection_site_index` の値が変更されることがあります。
{{% /alert %}}

## **接続ポイントの指定**

このセクションでは、Aspose.Slides でコネクタを図形上の特定の接続ポイントに固定する方法を説明します。正確な接続サイトを指定することで、コネクタの経路とレイアウトを制御し、プレゼンテーション内で整然とした予測可能な図を作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトが提供する `add_auto_shape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_connector` メソッドでコネクタを追加し、コネクタの種類を指定します。  
1. コネクタで図形を接続します。  
1. 図形上の希望する接続ポイントを設定します。  
1. プレゼンテーションを保存します。

以下の Python コードは、希望する接続ポイントを指定する方法を示しています:
```python
import aspose.slides as slides

# PPTX ファイルを作成するために Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドのシェイプ コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円の AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 矩形の AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドのシェイプ コレクションにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # コネクタで図形を接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 楕円の優先接続サイト インデックスを設定します。
    site_index = 6

    # 優先インデックスが利用可能なサイト数以内であることを確認します。
    if  ellipse.connection_site_count > site_index:
        # 楕円 AutoShape に優先接続サイトを割り当てます。
        connector.start_shape_connection_site_index = site_index

    # プレゼンテーションを保存します。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```


## **コネクタポイントの調整**

調整ポイントを使用してコネクタを変更できます。調整ポイントを公開しているコネクタだけがこの方法で編集可能です。どのコネクタが調整に対応しているかは、[コネクタの種類](/slides/ja/python-net/connector/#connector-types) の表をご参照ください。

### **シンプルなケース**

2 つの図形（A と B）を結ぶコネクタが 3 番目の図形（C）と交差しているケースを考えます:

![コネクタの障害](connector-obstruction.png)

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


3 番目の図形を回避するために、縦セグメントを左へ移動してコネクタを調整します:

![調整後のコネクタ障害回避](connector-obstruction-fixed.png)
```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```


### **複雑なケース** 

より高度な調整の場合、以下を考慮してください。

- コネクタの調整ポイントは位置を決定する数式に支配されます。このポイントを変更するとコネクタ全体の形状が変わります。  
- コネクタの調整ポイントは厳密に順序付けられた配列に格納され、コネクタの開始点から終了点へ番号付けされます。  
- 調整ポイントの値はコネクタ形状の幅/高さのパーセンテージを表します。  
  - 形状はコネクタの開始点と終了点で境界付けされ、1000 でスケーリングされます。  
  - 最初、二番目、三番目の調整ポイントはそれぞれ幅のパーセンテージ、高さのパーセンテージ、再び幅のパーセンテージを表します。  
- 調整ポイントの座標を計算する際は、コネクタの回転と反転を考慮してください。**注:** [コネクタの種類](/slides/ja/python-net/connector/#connector-types) に列挙されているすべてのコネクタは回転角が 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタでリンクされているケースを考えます:

![リンクされた図形](connector-shape-complex.png)

コード例:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを作成するために Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 最初のスライドを取得します。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # コネクタを追加します。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # コネクタの向きを設定します。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # コネクタの色を設定します。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # コネクタの線の太さを設定します。
    connector.line_format.width = 3

    # コネクタで図形を接続します。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # コネクタの調整ポイントを取得します。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```


**調整**

幅のパーセンテージを 20% 増加し、高さのパーセンテージを 200% 増加させて、コネクタの調整ポイントの値を変更します:
```python
    # 調整ポイントの値を変更します。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


結果:

![コネクタ調整 1](connector-adjusted-1.png)

`connector.adjustments[0]` に対応する垂直コンポーネントの形状を作成して、コネクタのセグメント座標と形状を決定できるモデルを定義します:
```python
    # コネクタの垂直コンポーネントを描画します。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```


結果:

![コネクタ調整 2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原則を用いたシンプルなコネクタ調整を示しました。実際のシナリオでは、コネクタの回転や表示設定（`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`）も考慮する必要があります。以下に手順を示します。

最初に、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、既存オブジェクトに接続する緑のコネクタを作成します。
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

    # 作成したコネクタでオブジェクトを接続します。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # コネクタの調整ポイントを取得します。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 調整ポイントの値を変更します。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


結果:

![コネクタ調整 3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント `connector.adjustments[0]` を通過する **horizontal** セグメントに対応する形状を作成します。`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` の値を使用し、基準点 `x0` 周りの回転に対する標準座標変換式を適用します。

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

本例ではオブジェクトの回転角は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです:
```python
    # コネクタの座標を保存します。
    x = connector.x
    y = connector.y
    
    # コネクタがフリップされている場合は座標を補正します。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 調整ポイントの値を座標として使用します。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1, cos(90°)=0 のため座標を変換します。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 第2調整ポイントの値を使って水平セグメントの幅を決定します。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```


結果:

![コネクタ調整 4](connector-adjusted-4.png)

シンプルな調整と、回転を考慮した複雑な調整ポイントの計算例を示しました。この知識を活用して、座標に基づく `GraphicsPath` オブジェクトを取得したり、スライド座標に応じてコネクタの調整ポイント値を設定したりする独自のモデルやコードを作成できます。

## **コネクタ線の角度を求める**

以下の例を使用して、Aspose.Slides でスライド上のコネクタ線の角度を求める方法を学びます。コネクタの端点を取得し、向きを計算することで、矢印やラベル、その他の図形を正確に配置できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. コネクタ線のシェイプにアクセスします。  
1. 線の幅と高さ、シェイプフレームの幅と高さを使用して角度を計算します。

以下の Python コードは、コネクタ線シェイプの角度を計算する方法を示しています:
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


## **よくある質問**

**特定の図形にコネクタを「くっつけ」られるかどうかはどうやって確認できますか？**

その図形が [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合はくっ付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数をチェックするのが賢明です。

**接続されている図形の一方を削除した場合、コネクタはどうなりますか？**

端点は切り離され、コネクタは普通の線としてスライド上に残ります（開始点/終了点が自由になります）。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**

通常は保持されますが、対象の図形も同時にコピーされていることが前提です。接続された図形が存在しない状態でスライドを別ファイルに挿入した場合、端点は自由になり、再接続が必要になります。