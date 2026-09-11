---
title: Python via Java でプレゼンテーション形状のサムネイルを作成
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/python-java/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状のレンダリング
- 形状レンダリング
- ビジュアル境界
- 形状境界
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint スライドから高品質な形状サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---
## **はじめに**

Aspose.Slides for Python via Java は、各ページがスライドに対応するプレゼンテーション ファイルを作成するために使用できます。スライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者は形状の画像を画像ビューアで個別に表示する必要がある場合があります。そのような場合、Aspose.Slides for Python via Java はスライド形状のサムネイル画像を生成するのに役立ちます。

この記事では、形状サムネイルをさまざまな方法で生成する方法を説明します。

- スライド内の形状サムネイルを生成する方法  
- ユーザー定義のサイズでスライド形状のサムネイルを生成する方法  
- 形状の外観領域内でサムネイルを生成する方法  

## **スライドから形状サムネイルを生成する**
Aspose.Slides for Python via Java を使用して任意のスライドから形状サムネイルを生成するには、次の手順を実行します。

1. Aspose.Slides for Python via Java の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. ID またはインデックスを使用してスライドへの参照を取得します。  
3. 参照されたスライド上の形状の[Get the shape thumbnail image](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage)をデフォルトのスケールで取得します。  
4. サムネイル画像を好みの画像形式で保存します。

このサンプルコードは、スライドから形状サムネイルを生成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("Thumbnail.pptx")
try:
    # フルスケールの画像を作成します。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # 画像を PNG 形式でディスクに保存します。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **ユーザー定義のスケーリング係数でサムネイルを生成する**
Aspose.Slides for Python via Java を使用してスライドの形状サムネイルを生成するには、次の手順を実行します。

1. Aspose.Slides for Python via Java の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. ID またはインデックスを使用してスライドへの参照を取得します。  
3. ユーザー定義のサイズで、参照されたスライド上の形状の[Get the shape thumbnail image](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage)を取得します。  
4. サムネイル画像を好みの画像形式で保存します。

このサンプルコードは、定義されたスケーリング係数に基づいて形状サムネイルを生成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("Thumbnail.pptx")
try:
    # 両方向に 2 倍の倍率でスケーリングされた画像を作成します。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # 画像を PNG 形式でディスクに保存します。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **外観領域ベースの形状サムネイルを作成する**
このサムネイル作成方法では、開発者は形状の外観領域内でサムネイルを生成できます。形状のすべてのエフェクトが考慮され、生成されたサムネイルはスライドの境界で制限されます。外観領域内でスライド形状のサムネイルを生成するには、次の手順を実行します。

1. Aspose.Slides for Python via Java の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. ID またはインデックスを使用してスライドへの参照を取得します。  
3. 外観領域を使用して、参照されたスライド上の形状のサムネイル画像を取得します。  
4. サムネイル画像を好みの画像形式で保存します。

上記の手順に基づくサンプルコードは次のとおりです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("Thumbnail.pptx")
try:
    # フルスケールの画像を作成します。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # 画像を PNG 形式でディスクに保存します。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **形状の実際のビジュアル境界を取得する**

[Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) のフレーム プロパティ—`getX`、`getY`、`getWidth`、`getHeight` メソッド—は、プレゼンテーション モデルに格納されている矩形を記述します。実際に描画されるコンテンツはそのフレームを超えることもあれば、別の軸に平行な矩形を占有することもあります。回転、アウトライン、矢じり、テキストのレイアウトとオーバーフロー、生成された SmartArt のジオメトリ、その他の描画効果はすべて占有領域を変更する可能性があります。

[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getVisualBounds) を使用すると、画像を作成せずに占有領域を算出できます。このメソッドはスライド座標系の [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を返します。返された矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

次の例はフレームとビジュアル境界を取得し比較します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

同じ [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を使用して、近接する形状を左・右・上・下のエッジに揃えたり、生成されたレイアウトに十分なスペースを確保したり、許可された領域外のコンテンツを検出したりできます。ビジュアル境界は特に SmartArt、テキスト ボックス、矢印、画像、回転形状、グループ形状で有用です。これらの場合、格納されたフレームは完全な描画結果を表さないことがあります。

レイアウトや検証のために座標が必要でビットマップが不要な場合は [Shape.getVisualBounds](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getVisualBounds) を使用してください。形状を描画する必要がある場合は [Shape.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) を使用します。`ShapeThumbnailBounds`、`ShapeThumbnailBounds.Shape` は輪郭設定を含めて形状の境界から画像サイズを決定し、`ShapeThumbnailBounds.Appearance` は形状の外観からサイズを決定し、結果をスライド境界に制限します。一方、`Shape.getVisualBounds` は計算された矩形のみを返し、スライドへクリップしません。

## **FAQ**

**形状サムネイルを保存する際に使用できる画像形式は何ですか？**  
[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/)、その他の形式が使用可能です。また、形状の内容を SVG として保存することで、[ベクター SVG としてエクスポート](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#writeAsSvgToBytes) することもできます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**  
`Shape` は形状のジオメトリを使用し、`Appearance` は[ビジュアル エフェクト](/slides/ja/python-java/shape-effect/)（影、光彩など）を考慮します。

**形状が非表示としてマークされている場合、サムネイルは生成されますか？**  
非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、形状の画像生成を妨げません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**  
はい。[Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) など）すべてサムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキスト形状のサムネイル品質に影響しますか？**  
はい。不要なフォントのフォールバックやテキストの折り返しを防ぐために、[必要なフォントを提供](/slides/ja/python-java/custom-font/)（または[フォント置換を構成](/slides/ja/python-java/font-substitution/)）することが推奨されます。