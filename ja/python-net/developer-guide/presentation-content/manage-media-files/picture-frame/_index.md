---
title: Pythonでプレゼンテーションの画像フレームを管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/python-net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

画像フレームは画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。 a [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) が its [ImageCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) を通じて埋め込み画像リソースを所有し、 while a [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロッピング、画像効果、その他フレームレベルの設定を制御します。

この分離は同じ画像が複数回表示される場合に便利です。画像をプレゼンテーションに一度追加し、返された [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) を保持し、ピクチャーフレームを作成するときにその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG などのラスタ画像や SVG などのベクター画像を含めることができます。また、プレゼンテーションに画像バイトを格納せずにリンク画像を参照させることもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) でピクチャーフレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピューターに移動してもプレゼンテーションは自己完結します。

次の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

ピクチャーフレームは表示ジオメトリを制御します。フレーム サイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変更されません。この違いは後で画像をクロップまたは圧縮する際に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) はフレーム用に [relative_scale_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/relative_scale_width/) と [relative_scale_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/relative_scale_height/) を公開しています。値 `1.0` は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手計算せずに元画像サイズとの関係を保持したいワークフローで便利です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に格納するため、ポータビリティと予測可能なレンダリングに最も安全です。リンク画像は [Picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picture/) のリンクパスを通じて外部場所を指すため、画像データは埋め込まれません。

リンク画像は PPTX 内の画像データ量を減らすことができますが、外部依存性が生じます。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションがアクセスできる状態でなければなりません。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されない可能性があります。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例はピクチャーフレームを作成し、ローカル画像ファイルへポイントします。画像リンクのみを扱い、動画リンクは別のメディア ワークフローであり、この例に混在させていません。

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替として単に使用しないでください。破損した画像依存関係を持つ小さな PPTX は、サイズの大きな自己完結型プレゼンテーションよりも実用的でないことが多いです。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされたピクチャーフレームは、同じ方法で抽出できる画像バイトを含んでいない可能性があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

[IImage] を介して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されたエンコード済みバイトが必要な場合は、代わりに [PPImage.binary_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/binary_data/) プロパティを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) は [SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) オブジェクトを公開します。これにより、画像をラスタライズせずに SVG データを直接取得できます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部にベクター ソースが残ります。PNG や JPEG などのラスタ エクスポートはベクター コンテンツをピクセルにレンダリングします。PDF や SVG のスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとはみなさず、元のベクター リソースが必要なときは埋め込み [SvgImage.svg_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/svg_data/) を使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/) のクロップ値は元画像寸法のパーセンテージです。クロップは最初は埋め込み画像から隠されたピクセルを削除せず、表示領域だけを変更します。

次の例はピクチャーフレームを安全に取得し、クロップ値を適用します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

隠された画像データは依然として存在するため、後で元のピクセルを失うことなくクロップを変更できます。ファイルサイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズが減りますが、破壊的な最適化です。プレゼンテーションが保存された後は、削除されたピクセルは後からのアンクロップ操作で利用できなくなります。

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元画像が他のピクチャーフレームでも使用されている場合、これらのフレームは既存リソースを必要とするため、クロップ領域の削除が必ずしも画像総数を減らすわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/compress_image/) は表示サイズに対するラスタ画像の解像度を下げます。同時にクロップ領域を削除することも可能です。メソッドは画像がリサイズまたはクロップされた場合に `True` を、変更が不要な場合に `False` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/picturescompression/) 値を使用してください。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

特定のターゲットが必要なときは、列挙値の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、低解像度化や削除されたクロップ領域は最適化されたプレゼンテーションから復元できないことを忘れないでください。画像が実際に表示またはエクスポートされる最大サイズに基づいてターゲット解像度を選択し、全体的に最も低い DPI を適用しないようにしてください。

## **画像効果の検査**

画像効果はフレームで使用される画像に格納されます。画像変換コレクションには、透明度用の固定アルファ変調や明るさ・コントラスト用の輝度などの効果が含まれることがあります。次の例はスライド上の最初のピクチャーフレームから両方の効果を安全に読み取ります。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/alphamodulatefixed/) と [Luminance](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/luminance/) はフレーム内での画像のレンダリング方法を変更しますが、元の埋め込み画像バイトを書き換えるものではありません。

## **ピクチャーフレームジオメトリのロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframelock/) 設定は、ピクチャーフレームに対してどの編集操作が無効になるかを制御します。たとえば、[aspect_ratio_locked](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) プロパティはリサイズ時に形状の比率を保持します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

ロックはピクチャーフレーム シェイプに適用されます。ソース画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

ピクチャー 塗りつぶしモードが stretch のとき、[PictureFillFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/) の stretch‑offset 値はピクチャーフレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからの内側のインセットを作り、負のパーセンテージは外側のアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択し、stretch offset は表示されたピクチャー塗りつぶしが伸張される矩形を変更します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

塗りつぶし位置を指定する場合は stretch offset を使用し、ソース画像の端を隠したい場合はクロップ プロパティを使用してください。

## **保存、ファイル サイズ、エクスポート上の考慮点**

画像の保存とピクチャーフレームの書式設定を別々に扱うと、以下のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側のレンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存されたパスまたは場所で利用可能であることに依存します。
- **クロップ** は当初は非破壊的です。隠されたピクセルはクロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上の最終表示サイズが判明した後に適用すべきです。
- **SVG 画像** はベクター の保持が重要な場合は SVG のまま残すべきです。ベクター リソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタ スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図表はベクター コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後の編集が不要な場合にのみクロップされたピクセルを削除し、外部リンクは依存関係管理が展開設計の一部である場合にのみ使用してください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) は画像を表示し、サイズ、回転、クロップ値、効果、ロックなどフレームレベルのジオメトリと書式設定を保持するスライド上のシェイプです。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルに、アーカイブに、または外部リソースにアクセスできない状態でレンダリングする必要がある場合は埋め込んでください。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合にのみリンクしてください。

**クロップは PPTX のファイルサイズを減らしますか？**

単独では減らしません。通常のクロップ設定はソース画像の一部を隠すだけで、基になるピクセルは保持されます。ピクセルを永久に削除したい場合は、[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) またはクロップ領域削除付きの画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクター の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式にスライドをレンダリングすると、SVG はスライド画像の一部としてラスタライズされます。

**既存のスライドを読み取る際に安全でないキャストを回避するには？**

ピクチャーフレーム固有のメンバーを使用する前にシェイプの型を確認してください。`isinstance(shape, slides.PictureFrame)` を使用すれば、ピクチャーフレームでないスライドに対する無効なキャストを防げます。