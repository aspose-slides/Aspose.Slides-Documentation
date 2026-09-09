---
title: Python を使用したプレゼンテーションでのピクチャーフレーム管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/python-java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーション内のピクチャーフレームを作成、書式設定、リンク、クロップ、抽出、圧縮する。"
---
## **概要**

Pictureフレームは画像を表示するスライドシェイプです。Aspose.Slidesでは、画像リソースとそれを表示するシェイプは別々のオブジェクトです。`Presentation` は [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を通じて埋め込み画像リソースを所有し、[ImageCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/) を介して管理します。一方、[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果など、フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度追加し、返される [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を保持し、Pictureフレームを作成する際にその画像リソースを使用します。

Pictureフレームは PNG や JPEG などのラスタ画像や、SVG などのベクタ画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照することもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame) で picture フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピューターに移動してもプレゼンテーションは自己完結した状態を保ちます。

以下の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

picture フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変更されません。この違いは後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) によってフレームの幅と高さの相対スケールを公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算せずに元画像サイズとの関係を保持したいワークフローで便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプルしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み picture は画像データをプレゼンテーション内部に格納するため、ポータビリティと予測可能なレンダリングに最も安全です。リンク picture は [Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#setLinkPathLong) メソッドを通じて外部場所を参照し、画像データを同様に埋め込むことはありません。

リンク画像は PPTX に格納される画像データ量を減らすことができますが、外部依存が発生します。リンク先のファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能であり続けなければなりません。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク picture は期待通りに表示されない可能性があります。メールで送信したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例は picture フレームを作成し、ローカル画像ファイルへリンクします。画像リンクのみを扱っており、動画リンクは別のメディアワークフローであり、本例には意図的に混ぜていません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替として単にリンクを使用しないでください。リンクが切れた小さな PPTX は、自己完結した大きなプレゼンテーションよりも実用性が低くなります。

## **Picture Frame から画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンク picture フレームは同じ方法で抽出できる画像バイトを持たない場合があります。

### **ラスタ画像の抽出**

最新の画像 API はラスタ画像を直接扱い、古い Java 画像ラッパーは不要です。以下の例はスライド上の最初の埋め込みラスタ picture を見つけ、PNG として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

ラスタ画像の保存は抽出した画像を要求された出力形式に変換します。プレゼンテーションに格納されたエンコード済みバイトが必要な場合は、画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG picture の場合、[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) は [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、まず picture をラスタ化せずに SVG データを直接取得できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

SVG コンテンツを SVG のまま保持することで、プレゼンテーション内部にベクタソースが残ります。PNG や JPEG などのラスタエクスポートはベクタコンテンツをピクセルにレンダリングします。PDF や SVG のスライドエクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとは見なさず、元のベクタリソースが必要な場合は埋め込み [SvgImage.getSvgData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/#getSvgData) を使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が可視になるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/) のクロップ値は元画像の寸法に対するパーセンテージです。クロップは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域だけを変更します。

以下の例は picture フレームを安全に取得し、クロップ値を適用します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

隠れた画像データは依然として存在するため、後からクロップを変更しても元のピクセルは失われません。ファイルサイズが重要であり、可逆性が必要ない場合は、次節で説明するようにクロップ領域を実際に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズは削減できますが、破壊的最適化となります。プレゼンテーションを保存した後は、削除されたピクセルは元に戻せません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他の picture フレームでも使用されている場合、これらのフレームは引き続き既存のリソースを必要とするため、クロップ領域の削除が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#compressImage) は表示サイズに対するラスタ画像の解像度を低減します。圧縮時にクロップ領域を同時に削除することもできます。画像がリサイズまたはクロップされた場合は `True`、変更が不要だった場合は `False` を返します。

標準的な対象解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturescompression/) 値を使用してください：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

特定の目標が必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を渡すことができます。

圧縮はラスタ画像を対象としています。SVG やメタファイル コンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりクロップ領域を削除したりした画像は、最適化されたプレゼンテーションからは復元できないことを覚えておいてください。画像が実際に表示またはエクスポートされる最大サイズに基づいて対象解像度を選択し、全体的に最も低い DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、除去、往復検証を網羅した完全なワークフローについては、[Image Transform Effects](/slides/ja/python-java/image-transform-effects/) を参照してください。

## **Picture Frame のジオメトリをロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframelock/) 設定は、picture フレームに対してどの編集操作が無効になるかを制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) はリサイズ時にシェイプの比例を維持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ロックは picture フレーム シェイプに適用されます。ソース画像がリサンプルされたり、同じアスペクト比に永続的に変更されたりすることはありません。

## **StretchOffset 値の調整**

picture の塗りつぶしモードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/) の stretch‑offset 値は picture フレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからの内側のインセットを作り、負のパーセンテージは外側へのアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が可視になるかを選択しますが、stretch offset は可視 picture 塗りつぶしが伸ばされる矩形を変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

塗りつぶし位置を調整する場合は stretch offset を使用し、ソース画像の端を隠したい場合はクロップ プロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存と picture‑frame の書式設定を別々に扱うと、主要なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX サイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存パスまたは場所で利用可能であることに依存します。
- **クロップ** は当初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか、圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での最終サイズが確定した後に適用すべきです。
- **SVG 画像** はベクタ保持が重要な場合は SVG のままにしてください。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタスライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施すると効果的です。ロゴや図はベクタコンテンツとして残し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップピクセルを削除し、外部リンクは依存関係管理が展開設計の一部でない限り避けてください。

## **FAQ**

**Picture Frame と画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどのフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルに、アーカイブ可能に、外部リソースなしでレンダリングできる必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを減らしますか？**

単体では減りません。通常のクロップ設定は元画像のピクセルを保持したまま隠すだけです。ピクセルを永久に削除したい場合は [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) を使用するか、クロップ領域の削除を伴う画像圧縮を行ってください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーション外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) は直接抽出可能です。PNG や JPEG などのラスタ形式にスライドをレンダリングすると、SVG はピクセルに変換されます。

**既存スライドの読み取り時に安全でないキャストを避ける方法は？**

picture‑frame 固有のメンバーを使用する前にシェイプの型を確認してください。`isinstance` チェックで [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) かどうかを判定すれば、無効なキャストを防ぎ、picture フレームを含まないスライドでも安全に処理できます。