---
title: Python via JavaでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-java/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- スケッチ効果
- 図形の線のスケッチ
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透過性
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python via Java で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果スタイルを正確かつ完全に制御して設定できます。"
---
## **イントロダクション**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭に対して効果を変更したり適用したりして書式設定できます。また、内部の塗りつぶし方法を指定して図形を書式設定することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットするクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタム線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) の書式設定方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # 矩形シェイプの塗りつぶし色を設定します。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 矩形の線に書式設定を適用します。
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # 矩形の線の色を設定します。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # PPTX ファイルをディスクに保存します。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The formatted lines in the presentation](formatted-lines.png)

## **図形の線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手描き風に見せます。`Shape.getLineFormat` を使用して線の設定にアクセスし、`LineFormat.getSketchFormat` でスケッチ設定にアクセスし、`SketchFormat.setSketchType` で [LineSketchType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の Python コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linesketchtype/#Curved) 効果を適用し、明示的に設定された値を読み取り、[LineSketchType.None_](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linesketchtype/#None) で効果を削除する方法を示しています。

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

    # 図形の線フォーマットとスケッチフォーマットにアクセスします。
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

`SketchFormat.getSketchType` が返す値は、図形に直接割り当てられた設定を表します。線の書式がテーマ、マスタースライド、またはレイアウトスライドから継承される可能性がある場合は、`LineFormat.getEffective` を使用し、`LineFormatEffectiveData.getSketchFormat` にアクセスして `SketchFormatEffectiveData.getSketchType` を読み取ります。実効値は継承が解決された後に実際に適用される書式を反映します。

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

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

デフォルトでは、PowerPoint は角度のある 2 本の線（図形のコーナーなど）を結合するときに **Round** 設定を使用します。ただし、鋭角のある図形を描く場合は **Miter** オプションの方が適しています。

![The join style in the presentation](join-style-powerpoint.png)

次の Python コードは、上図のように Miter、Bevel、Round の結合タイプ設定で 3 つの矩形が作成された例を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを 3 つ追加します。
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # 各矩形シェイプの塗りつぶし色を設定します。
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 線幅を設定します。
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # 各矩形の線の色を設定します。
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 結合スタイルを設定します。
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # 各矩形にテキストを追加します。
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # PPTX ファイルをディスクに保存します。
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式オプションです。たとえば、2 色以上を徐々にフェードさせながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/gradientformat/) クラスが公開するグラデーションストップコレクションの `addPresetColor` メソッドを使用し、位置を指定した 2 つの好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Python コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Ellipse タイプのオートシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # 楕円にグラデーション書式設定を適用します。
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # グラデーションの方向を設定します。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # グラデーションストップを 2 つ追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The ellipse with gradient fill](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点・ストライプ・クロスハッチ・チェックなどの 2 色デザインを図形に適用できる書式オプションです。パターンの前景色と背景色をカスタムカラーで指定できます。

Aspose.Slides は 45 以上の事前定義パターンスタイルを提供し、プレゼンテーションの視覚効果を高めるために図形に適用できます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/python-java/aspose.slides/patternformat/#getBackColor) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/python-java/aspose.slides/patternformat/#getForeColor) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Python コードは、矩形にパターン塗りつぶしを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
    presentation = Presentation()
    try:
        # 最初のスライドを取得します。
        slide = presentation.getSlides().get_Item(0)

        # Rectangle タイプのオートシェイプを追加します。
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

        # 塗りつぶしタイプを Pattern に設定します。
        shape.getFillFormat().setFillType(FillType.Pattern)

        # パターンスタイルを設定します。
        shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

        # パターンの背景色と前景色を設定します。
        shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
        shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

        # PPTX ファイルをディスクに保存します。
        presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

結果:

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の背景として挿入できる書式オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用したい画像から [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `SlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![The lotus picture](lotus.png)

次の Python コードは、図形に画像塗りつぶしを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 画像塗りつぶしモードを設定します。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # 画像を設定します。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # PPTX ファイルをディスクに保存します。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を使用する**

タイル画像をテクスチャとして設定し、タイル処理の動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内でのタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileOffsetX): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileOffsetY): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

次のコードサンプルは、タイル画像塗りつぶし付きの矩形を追加し、タイルオプションを構成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    first_slide = presentation.getSlides().get_Item(0)

    # 矩形のオートシェイプを追加します。
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # 図形の塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # 画像を図形に割り当てます。
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # 画像塗りつぶしモードとタイル設定を構成します。
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # PPTX ファイルをディスクに保存します。
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式オプションです。グラデーション、テクスチャ、パターンなどは使用されません。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Python コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 塗りつぶしタイプを Solid に設定します。
    shape.getFillFormat().setFillType(FillType.Solid)

    # 塗りつぶし色を設定します。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The shape with solid color fill](solid-color-fill.png)

## **透過性の設定**

PowerPoint では、単色、グラデーション、画像、テクスチャの塗りつぶしを図形に適用する際に、透過レベルを設定して塗りつぶしの不透明度を制御できます。透過値が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色の alpha 値を調整することで透過レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を `Solid` に設定します。
1. [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) を使用して透過を含む色を定義します（`alpha` コンポーネントが透過度を制御します）。
1. プレゼンテーションを保存します。

次の Python コードは、矩形に透過塗りつぶし色を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # ソリッド矩形のオートシェイプを追加します。
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # PPTX ファイルをディスクに保存します。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint のプレゼンテーション内で図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を配置する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の Python コードは、図形を 5 度回転させる例です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 図形を 5 度回転させます。
    shape.setRotation(5)

    # PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/) プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを生成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の Python コードは、図形に 3D ベベル効果を適用する例です。

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

    # シェイプの ThreeDFormat プロパティを設定します。
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

結果:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/) プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. `setCameraType` および `setLightType` メソッドを使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の Python コードは、図形に 3D 回転効果を適用する例です。

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

結果:

![The 3D rotation effect](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

`Shape.setBlackWhiteMode` メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに、個々の図形がどのように描画されるかを指定します。このメソッド自体が白黒表示を有効にするわけではなく、通常のカラー モードでの図形の塗り、線、その他の書式設定も変更しません。

`BlackWhiteMode` クラスの値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレイ 調に、`BlackWhite` は黒と白だけ、`Black` と `White` は単一色に、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

次の Python コードは、カラー図形を作成し、白黒表示モードで灰色として表示させる例です。

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

    # カラーモードではオレンジの塗りを保ち、白黒モードでは図形を灰色で描画します。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

通常のカラー モードでは矩形はオレンジの塗りが保持されますが、白黒表示ワークフローでは `Gray` が設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど、プレゼンテーションの白黒表示設定を尊重するワークフローで別の外観を定義できます。

## **書式設定のリセット**

次の Python コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/) 上のプレースホルダー付きすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # レイアウトにプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

ほとんど影響しません。埋め込まれた画像やメディアがファイル容量の大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほぼありません。

**同じ書式設定を共有する図形をスライド上で検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルは同一とみなして論理的にグループ化できます。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。