---
title: Python でプレゼンテーションのコネクタを管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- シェイプ を接続
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python アプリで PowerPoint および OpenDocument のスライドに線を描画、接続、自動ルーティングし、直線・エルボー・曲線コネクタをフルコントロールできます。"
---

## **概要**

PowerPoint のコネクタは、2 つのシェイプを結び付け、スライド上でシェイプが移動または再配置されても接続されたままになる特殊な線です。コネクタはシェイプ上の **接続ポイント**（緑の点）に接続します。ポインタが接続ポイントに近づくと表示されます。特定のコネクタに利用できる **調整ハンドル**（黄色の点）を使用すると、コネクタの位置と形状を変更できます。

## **コネクタ タイプ**

PowerPoint では、直線、エルボー（角付き）、曲線の 3 種類のコネクタを使用できます。

Aspose.Slides がサポートするコネクタ タイプは次のとおりです。

| コネクタ タイプ | 画像 | 調整ポイント数 |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![直線コネクタ](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![直線コネクタ 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![エルボーコネクタ 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![エルボーコネクタ 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![エルボーコネクタ 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![エルボーコネクタ 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![曲線コネクタ 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![曲線コネクタ 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![曲線コネクタ 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![曲線コネクタ 5](shapetype.curvedconnector5.png)     | 3                           |

## **シェイプ を接続するコネクタ**

このセクションでは、Aspose.Slides でシェイプをコネクタでリンクする方法を示します。スライドにコネクタを追加し、開始点と終了点を対象シェイプに接続します。接続サイトを使用すると、シェイプが移動またはサイズ変更されてもコネクタが「貼り付け」されたままになります。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) の `add_connector` メソッドを使用してコネクタを追加し、コネクタ タイプを指定します。
1. コネクタでシェイプを接続します。
1. `reroute` メソッドを呼び出して最短接続経路を適用します。
1. プレゼンテーションを保存します。

以下の Python コードは、楕円と長方形の間にエルボーコネクタ（BENT_CONNECTOR2）を追加する方法を示しています。

```python
import aspose.slides as slides

# PPTX ファイルを作成するために Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドのシェイプ コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円 AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 四角形 AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # コネクタでシェイプを接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 最短パスを設定するために reroute を呼び出します。
    connector.reroute()

    # プレゼンテーションを保存します。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}

`connector.reroute` メソッドはコネクタを再ルーティングし、シェイプ間の最短パスを取るように強制します。その際、`start_shape_connection_site_index` と `end_shape_connection_site_index` の値が変更される可能性があります。

{{% /alert %}}

## **接続ポイント を指定する**

このセクションでは、Aspose.Slides でシェイプ上の特定の接続ポイントにコネクタを結び付ける方法を説明します。正確な接続サイトを指定することで、コネクタのルーティングとレイアウトを制御し、プレゼンテーション内に整然とした図を作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. `add_auto_shape` メソッドで 2 つの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. `add_connector` メソッドでコネクタを追加し、タイプを指定します。
1. コネクタでシェイプを接続します。
1. シェイプ上の希望する接続ポイントを設定します。
1. プレゼンテーションを保存します。

以下の Python コードは、希望する接続ポイントを指定する例です。

```python
import aspose.slides as slides

# PPTX ファイルを作成するために Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドのシェイプ コレクションにアクセスします。
    shapes = presentation.slides[0].shapes

    # 楕円 AutoShape を追加します。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 四角形 AutoShape を追加します。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # スライドのシェイプ コレクションにコネクタを追加します。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # コネクタでシェイプを接続します。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 楕円の希望接続サイト インデックスを設定します。
    site_index = 6

    # 希望インデックスが利用可能なサイト数以内か確認します。
    if ellipse.connection_site_count > site_index:
        # 楕円 AutoShape の希望接続サイトを割り当てます。
        connector.start_shape_connection_site_index = site_index

    # プレゼンテーションを保存します。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタ ポイント を調整する**

調整ポイントを持つコネクタは、そのポイントを操作して形状を変更できます。調整ポイントを公開しているコネクタのみがこの方法で編集可能です。どのコネクタが調整をサポートしているかは、[コネクタ タイプ](/slides/ja/python-net/connector/#connector-types) の表をご参照ください。

### **単純ケース**

2 つのシェイプ（A と B）を結ぶコネクタが、3 番目のシェイプ（C）と交差するケースを考えます。

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

3 番目のシェイプを回避するため、垂直セグメントを左へ移動してコネクタを調整します。

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **複合ケース**

より高度な調整例を示します。

- コネクタの調整ポイントは、その位置を決定する数式に従います。ポイントを変更するとコネクタ全体の形が変わります。
- 調整ポイントはコネクタの開始から終了へと厳密に順序付けられた配列に格納されます。
- 調整ポイントの値は、コネクタ形状の幅/高さに対するパーセンテージです。
  - 幅と高さはコネクタの開始点と終了点で定義され、1000 倍でスケーリングされます。
  - 第 1〜第 3 の調整ポイントはそれぞれ「幅のパーセンテージ」「高さのパーセンテージ」「幅のパーセンテージ」を表します。
- 調整ポイント座標を算出する際は、コネクタの回転および反転を考慮します。**注意:** [コネクタ タイプ](/slides/ja/python-net/connector/#connector-types) に列挙されたすべてのコネクタは回転角が 0 です。

#### **ケース 1**

テキストフレームオブジェクト 2 つをコネクタでリンクする例です。

![Linked shapes](connector-shape-complex.png)

コード例:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを作成するために Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 楕円 AutoShape を追加します。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # コネクタを追加します。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # コネクタの矢尻スタイルを設定します。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # コネクタの色を設定します。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # コネクタの線幅を設定します。
    connector.line_format.width = 3

    # コネクタでシェイプを接続します。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # コネクタの調整ポイントを取得します。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**調整**

幅のパーセンテージを 20% 増やし、高さのパーセンテージを 200% 増やして、調整ポイントの値を変更します。

```python
    # 調整ポイントの値を変更します。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果:

![Connector adjustment 1](connector-adjusted-1.png)

垂直セグメントを表すシェイプを作成し、`connector.adjustments[0]` の位置に合わせます。

```python
    # コネクタの垂直セグメントを描画します。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果:

![Connector adjustment 2](connector-adjusted-2.png)

#### **ケース 2**

ケース 1 では基本的な調整を示しました。実際のシナリオでは、コネクタの回転や表示設定（`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`）を考慮する必要があります。以下に手順を示します。

まず、スライドに新しいテキストフレームオブジェクト (**To 1**) を作成し、既存オブジェクトに接続する緑色のコネクタを作成します。

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

    # 新しいコネクタでオブジェクトを接続します。
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

![Connector adjustment 3](connector-adjusted-3.png)

次に、`connector.adjustments[0]` を通過するコネクタの **水平** セグメントに対応するシェイプを作成します。`connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` の値を使用し、以下の回転変換式を適用します。

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0

本例ではオブジェクトの回転角は 90° で、コネクタは垂直に表示されるため、コードは次のようになります。

```python
    # コネクタの座標を保存します。
    x = connector.x
    y = connector.y
    
    # 反転されている場合は座標を補正します。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 調整ポイントの値を座標として使用します。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1, cos(90°)=0 のため座標を変換します。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 第2調整ポイントの値で水平セグメントの幅を求めます。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果:

![Connector adjustment 4](connector-adjusted-4.png)

このように、単純な調整から回転を考慮した複雑な調整までを計算できました。この知識を活用して、スライド座標に基づく `GraphicsPath` オブジェクトを取得したり、コネクタの調整ポイント値を設定したりするモデルやコードを書き上げることができます。

## **コネクタ ライン の角度 を求める**

以下の例を使用して、Aspose.Slides でスライド上のコネクタ ラインの角度を求めます。コネクタの端点を読み取り、向きを計算する方法を学び、矢印やラベル、その他のシェイプを正確に配置できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. コネクタ ライン シェイプにアクセスします。
1. ラインの幅と高さ、シェイプフレームの幅と高さを使用して角度を計算します。

以下の Python コードは、コネクタ ライン シェイプの角度を計算する例です。

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

**コネクタを特定のシェイプに「貼り付け」できるかどうかはどう確認できますか？**

シェイプが [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合は貼り付けは利用できません。その場合はフリーエンドポイントを使用し、手動で位置を設定します。接続前にサイト数をチェックするのが賢明です。

**接続されているシェイプの一方を削除した場合、コネクタはどうなりますか？**

コネクタの端点は切り離され、スライド上に普通の線として残ります。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) を実行してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタの結合は保持されますか？**

一般的に保持されますが、対象シェイプも一緒にコピーされていることが前提です。接続されたシェイプが存在しない状態でスライドを別ファイルに挿入した場合、端点はフリーになり、再度接続する必要があります。