---
title: Python を使用したプレゼンテーションでのピクチャーフレームの管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/python-java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 埋め込み画像
- リンク画像
- 画像を抽出
- ラスター画像
- SVG画像
- 画像をクロップ
- クロップ領域を削除
- 画像を圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像効果
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

Pictureフレームは画像を表示するスライドシェイプです。Aspose.Slidesでは、画像リソースとそれを表示するシェイプは別々のオブジェクトです。 [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) は埋め込み画像リソースをその [ImageCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/) を介して所有し、[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は便利です。画像をプレゼンテーションに一度だけ追加し、返された [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を保持し、PictureFrame を作成する際にその画像リソースを使用します。

PictureFrame は PNG や JPEG などのラスタ画像や SVG などのベクタ画像を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することも可能です。この選択はポータビリティ、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を行う前に画像の保存方法を決定しておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame) を使用して画像フレームを作成します。画像はプレゼンテーション パッケージの一部となるため、別のコンピュータに移動してもプレゼンテーションは自己完結型のままです。

次の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

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

PictureFrame は表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この違いは、後で画像をクロップまたは圧縮する際に重要になります。

## **相対スケールの使用**

PictureFrame はフレームの幅と高さの相対スケーリングを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) で公開します。`1.0` の値は元画像サイズの 100% に相当します。相対スケールは、最終サイズを手動で計算する代わりに、ソース画像サイズとの関係を保持する必要があるワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像のリサンプリングや圧縮は行いません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内に保存するため、ポータビリティと予測可能なレンダリングに最も安全な選択です。リンク画像は画像データを埋め込む代わりに、[Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#setLinkPathLong) メソッドで外部の場所を保持します。

リンク画像は PPTX に保存される画像データ量を減らすことができますが、外部依存性が発生します。リンク先のファイルは、プレゼンテーションを開くまたはレンダリングするアプリケーションがアクセスできる状態である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されません。メールで送信したり、アーカイブしたり、隔離環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は PictureFrame を作成し、ローカル画像ファイルへのリンクを設定します。この例は画像リンクのみに焦点を当てており、動画リンクは別のメディアワークフローであり、意図的にこの例には混在させていません。

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

外部ファイル管理が意図的な場合にのみリンクを使用してください。圧縮の代替として単に使用しないでください。画像依存関係が壊れた小さな PPTX は、サイズが大きくても自己完結型のプレゼンテーションよりも実用性が低いことが多いです。

## **PictureFrame から画像を抽出**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に PictureFrame であり、埋め込み画像を含んでいるかを確認してください。リンクされた PictureFrame には、同様に抽出できる画像バイトが含まれていない場合があります。

### **ラスタ画像の抽出**

最新の画像 API はラスタ画像を直接扱い、従来の Java 画像ラッパーは不要です。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

ラスタ画像を保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、変換されたラスタファイルではなく画像リソースのバイナリデータを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、PPImage は SvgImage オブジェクトを提供します。これにより、画像を先にラスタイズすることなく、SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内のベクトルソースが保存されます。PNG や JPEG などのラスタエクスポートは、必然的にベクトルコンテンツをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされた画像は元の埋め込み SVG のバイト単位のコピーとして扱うべきではありません。元のベクトルリソースが必要な場合は、埋め込み SvgImage.getSvgData のデータを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。PictureFillFormat のクロップ値はソース画像の寸法に対するパーセンテージです。クロップは埋め込み画像から隠れたピクセルを削除するわけではなく、表示領域を変更するだけです。

次の例は PictureFrame を安全に取得し、クロップ値を適用します。

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

隠れた画像データがまだ存在するため、クロップは後で変更でき、元のピクセルは失われません。ファイルサイズが可逆性より重要な場合は、次のセクションで説明するようにクロップ領域を実際に削除できます。

## **クロップされた画像データの削除**

PictureFillFormat.deletePictureCroppedAreas は現在のクロップ矩形の外側の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後でクロップ解除を行う際に利用できなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する場合があります。元の画像が他の PictureFrame でも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、クロップ領域の削除が必ずしも画像総数の削減につながるわけではありません。このメソッドで WMF や EMF コンテンツをクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

PictureFillFormat.compressImage は、画像が表示されるサイズに対してラスタ画像の解像度を下げます。同時にクロップ領域を削除することもできます。画像がリサイズまたはクロップされた場合は `True`、変更が必要なかった場合は `False` を返します。

標準的な目標解像度で十分な場合は、事前定義された PicturesCompression の値を使用してください。

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

圧縮はラスタ画像を対象としています。SVG およびメタファイルのコンテンツはこのラスタ圧縮フローでは縮小されません。また、低解像度化や削除されたクロップ領域は最適化されたプレゼンテーションから復元できないことを忘れないでください。画像が実際に表示またはエクスポートされる最大サイズに基づいて目標解像度を選択し、全体的に最も低い DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラートランスフォーメーション、ぼかし、アルファ効果、順序付けられたチェーン、検査、削除、往復検証を網羅した完全なワークフローについては、[Image Transform Effects](/slides/ja/python-java/image-transform-effects/) を参照してください。

## **PictureFrame のジオメトリをロック**

PictureFrameLock 設定は、PictureFrame に対して無効化する編集操作を制御します。たとえば、setAspectRatioLocked はリサイズ時にシェイプの比率を保持します。

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

ロックは PictureFrame シェイプに適用されますが、ソース画像がリサンプリングされたり、同じアスペクト比に永続的に変更されたりすることはありません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、PictureFillFormat の stretch-offset 値は PictureFrame のバウンディングボックスに対する塗りつぶし矩形を定義します。正のパーセンテージは端からのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分を表示するかを選択し、stretch offset は表示された画像の塗りつぶしが伸縮される矩形を変更します。

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

塗りつぶしの配置には stretch offset を使用し、ソース画像の端を隠すことが目的の場合はクロッププロパティを使用してください。

## **ストレージ、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存と PictureFrame の書式設定を別々に扱うと、主なトレードオフの管理が容易になります。

- **埋め込み画像** はプレゼンテーションを自己完結型にし、共有やサーバー側レンダリングで最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは保存されたパスや位置にある外部ファイルが利用可能であることに依存します。
- **クロップ** は最初は破壊的でありません。隠れたピクセルは、クロップ領域が明示的に削除されるか、圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** はサイズが大きすぎるラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での実際のサイズが決まってから適用すべきです。
- **SVG 画像** はベクトル保存が重要な場合は SVG のままにすべきです。ベクトルリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタスライドのエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の PPImage リソースを再利用し、同じファイルをプレゼンテーションのワークフローに何度もロードするのを避けるべきです。

大規模なプレゼンテーションでは、画像最適化は選択的に実行するのが最も効果的です。ロゴや図はベクトルコンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が必要ない場合にのみクロップされたピクセルを削除し、依存関係の管理が展開設計の一部でない限り外部リンクは避けてください。

## **FAQ**

**PictureFrame と画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) はスライド上で画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持するシェイプです。

**画像は埋め込むべきかリンクすべきか？**

プレゼンテーションをポータブルにしたり、アーカイブしたり、外部リソースにアクセスできない状態でレンダリングする必要がある場合は、画像を埋め込んでください。画像ファイルを PPTX の外部に置き、外部の場所を確実に管理できる場合に限り、リンク画像を使用してください。

**クロップは PPTX のファイルサイズを削減しますか？**

単独では削減しません。通常のクロップ設定は画像の一部を非表示にするだけで、基になるピクセルは保持されます。ピクセルを完全に削除したい場合は、PictureFillFormat.deletePictureCroppedAreas を使用するか、クロップ領域の削除を伴う画像圧縮を行ってください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要な場合は、プレゼンテーションの外部に元のソース画像を保管してください。

**SVG 画像はどのように扱うべきですか？**

ベクトルの忠実性が重要な場合は、SVG コンテンツを SVG のまま保持してください。埋め込まれた [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) は直接抽出できます。スライドを PNG や JPEG などのラスタ形式でレンダリングすると、SVG はピクセルにラスタライズされます。

**既存スライドを読むときに unsafe cast を防ぐには？**

PictureFrame 固有のメンバーを使用する前に、シェイプの型が PictureFrame であるかを確認してください。`isinstance` を使用して [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) かどうかをチェックすれば、無効なキャストを防ぎ、PictureFrame を含まないスライドも安全に処理できます。