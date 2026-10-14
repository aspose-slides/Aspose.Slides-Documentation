---
title: Python（Java 経由）で PowerPoint 図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-java/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- ジョインスタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python（Java 経由）で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果のスタイルを正確かつ完全に制御できます。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したり効果を適用したりして書式設定できます。さらに、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットできます。

![PowerPoint の図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Python via Java は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットできるクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形のカスタム線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [線スタイル](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [破線スタイル](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形の [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) をフォーマットする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # 矩形シェイプの塗りつぶし色を設定。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 矩形の線に書式設定を適用。
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # 矩形の線の色を設定。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # PPTX ファイルをディスクに保存。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形線へのスケッチ効果の適用**

スケッチ効果は、図形の線を手書き風にします。[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) を使用して線の設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) を使用して [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の Python コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) で効果を削除する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # 図形の線書式とそのスケッチ書式にアクセスします。
    sketch_format = shape.getLineFormat().getSketchFormat()

    # スケッチ効果を適用します。
    sketch_format.setSketchType(LineSketchType.Curved)

    # 図形に直接割り当てられたスケッチ効果を読み取ります。
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # スケッチ効果を削除します。
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承できる場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) を使用し、`LineFormatEffectiveData.getSketchFormat` にアクセスして `SketchFormatEffectiveData.getSketchType` を読み取ります。有効な値は、継承が解決された後に実際に適用される書式設定を反映します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **ジョインスタイルの書式設定**

ジョインタイプのオプションは次の3つです。

* ラウンド
* ミーター
* ベベル

既定では、PowerPoint は角度で2本の線を結合する際（図形のコーナーなど）に **Round** 設定を使用します。ただし、鋭い角度の図形を描く場合は **Miter** オプションを選択した方が良い場合があります。

![プレゼンテーションのジョインスタイル](join-style-powerpoint.png)

次の Python コードは、上の画像に示されたように、Miter、Bevel、Round のジョインタイプ設定を使用して3つの矩形を作成した方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを3つ追加。
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # 各矩形シェイプの塗りつぶし色を設定。
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 線の幅を設定。
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # 各矩形の線の色を設定。
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # ジョインスタイルを設定。
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # 各矩形にテキストを追加。
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # PPTX ファイルをディスクに保存。
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式設定オプションです。たとえば、2色以上を徐々にフェードさせて適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) クラスが公開するグラデーションストップコレクションの [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) メソッドを使用して、位置を指定した2つの希望する色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Ellipse タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # 楕円にグラデーション書式設定を適用。
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # グラデーションの方向を設定。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # 2つのグラデーションストップを追加。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # PPTX ファイルをディスクに保存。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートされた画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリングスタイルを選択できます。

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの2色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる45以上の事前定義パターンスタイルを提供します。事前定義のパターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義のオプションからパターンスタイルを選択します。
1. [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) を設定します。
1. [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 塗りつぶしタイプを Pattern に設定。
    shape.getFillFormat().setFillType(FillType.Pattern)

    # パターンスタイルを設定。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # パターンの背景色と前景色を設定。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # PPTX ファイルをディスクに保存。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して画像塗りつぶしを図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用したい画像から [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `SlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

![蓮の画像](lotus.png)

次の Python コードは、画像で図形を塗りつぶす方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # 塗りつぶしタイプを Picture に設定。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 画像塗りつぶしモードを設定。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # 画像を読み込み、プレゼンテーションのリソースに追加。
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # 画像を設定。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # PPTX ファイルをディスクに保存。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとして画像をタイル状に設定**

画像をテクスチャとしてタイル状に設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) クラスの以下のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像塗りつぶしモードを設定します — `Tile` または `Stretch` のいずれかです。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平、垂直、またはその両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

次のコードサンプルは、タイル画像塗りつぶしの矩形形状を追加し、タイルオプションを構成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    first_slide = presentation.getSlides().get_Item(0)

    # 矩形のオートシェイプを追加。
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # 図形の塗りつぶしタイプを Picture に設定。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 画像を読み込み、プレゼンテーションのリソースに追加。
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # 画像を図形に割り当て。
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # 画像塗りつぶしモードとタイル設定を構成。
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # PPTX ファイルをディスクに保存。
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。この単純な背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 塗りつぶしタイプを Solid に設定。
    shape.getFillFormat().setFillType(FillType.Solid)

    # 塗りつぶし色を設定。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # PPTX ファイルをディスクに保存。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、またはテクスチャ塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど、図形が透けて見え、背景や下のオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を `Solid` に設定します。
1. [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) を使用して透明度を持つ色を定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # ソリッド矩形のオートシェイプを追加。
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ソリッド形状の上に透明な矩形オートシェイプを追加。
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # PPTX ファイルをディスクに保存。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件がある場合に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティを目的の角度に設定します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
presentation = Presentation()
try:
    # 最初のスライドを取得。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 5????????


```

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

3D ベベル効果を図形に追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # スライドにシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # 図形の ThreeDFormat プロパティを設定します。
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

3D 回転効果を図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) と [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) メソッドを使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに個々の図形がどのようにレンダリングされるかを指定します。これだけで白黒表示が有効になるわけではなく、通常のカラー表示時の塗りつぶしや線、その他の書式設定は変更されません。

[BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。たとえば、`Automatic` はレンダリングアプリケーションに変換を任せ、`Gray` と `LightGray` はグレー表示、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを維持、`Hidden` は白黒モードで図形を省略します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

次の Python コードは、カラー図形を作成し、白黒表示モードで灰色に表示させる例です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # カラー モードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレーカラーでレンダリングします。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

通常のカラー表示では、矩形はオレンジの塗りつぶしを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しながら、印刷やプレビュー、その他の白黒表示設定を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

次の Python コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # レイアウト上にプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

影響はごくわずかです。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を共有するスライド上の図形をどのように検出してグループ化できますか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化して後のスタイル管理を簡素化できます。

**カスタム図形スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライドデッキまたは .POTX テンプレートファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。