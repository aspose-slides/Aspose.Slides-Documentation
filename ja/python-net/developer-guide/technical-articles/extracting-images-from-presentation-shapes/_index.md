---
title: Python でプレゼンテーションシェイプから画像を抽出
linktitle: シェイプからの画像
type: docs
weight: 90
url: /ja/python-net/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出します - 素早くコードフレンドリーなソリューション。"
---
## **概要**

プレゼンテーション内の画像は、いくつかのシェイプタイプで表示されます。通常の画像フレーム、シェイプに適用された画像塗り、OLE オブジェクトのプレビュー画像、ビデオまたはオーディオフレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt シェイプにネストされた画像などです。Aspose.Slides は、これらの画像をプレゼンテーション画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) と [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation.images` を反復処理します。本記事は別のタスク、すなわちスライド上で画像が使用されている場所をシェイプをたどって検出し、保存したファイルにスライド番号、シェイプ位置、ソースタイプ（画像フレーム、塗り画像、メディアプレビュー、OLE プレビュー、またはズーム画像）といった有用なコンテキストを保持できるようにすることに焦点を当てています。

{{% alert title="Tip" color="primary" %}}
`binary_data` プロパティ（[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/)）を使用すると、元のエンコードされた画像データとファイルタイプを保持できます。特定のフォーマット（例: PNG）に正規化して出力したい場合は、`image` プロパティと `save` を使用してください。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`save_original_image` は埋め込みバイトを元のまま書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュで重複する画像バイナリをスキップします。

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **画像フレームから画像を抽出する**

スタンドアロンオブジェクトとして挿入された画像にこの方法を使用します。[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) はその画像を `picture_format.picture.image` に格納し、[PPImage] オブジェクトを返します。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **画像塗りシェイプから画像を抽出する**

シェイプは画像を塗りとして使用できます。まずシェイプの塗りタイプを確認してください。`FillType.PICTURE` でない場合、その塗りから抽出できる画像はありません。以下の例は [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) オブジェクトを扱い、各画像を `PPImage` の `image` プロパティを介して PNG として保存します。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **OLE オブジェクトフレームからプレビュー画像を抽出する**

[OleObjectFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/oleobjectframe/) は、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像を持つことがあります。この画像は `substitute_picture_format.picture.image` で取得できます。抽出されるのはプレビュー画像であり、埋め込まれた OLE パッケージの内容ではありません。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **ビデオフレームからプレビュー画像を抽出する**

[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) も `picture_format.picture.image` にプレビュー画像を格納できます。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **オーディオフレームからプレビュー画像を抽出する**

[AudioFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/) は `picture_format.picture.image` にサムネイルを格納できます。これはスライド上のオーディオオブジェクトに表示される画像です。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **ズームオブジェクトから画像を抽出する**

[ZoomFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/zoomframe/) および [SectionZoomFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectionzoomframe/) シェイプはカスタム画像を使用できます。ズームフレームの `zoom_image` を読み取ります。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **サマリーズームフレームから画像を抽出する**

[SummaryZoomFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/summaryzoomframe/) もシェイプです。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `zoom_image` プロパティで取得できます。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **テーブルシェイプから画像を抽出する**

[Table](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) はシェイプです。テーブル内の画像は通常、セルの画像塗りとして格納されます。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **チャートシェイプから画像を抽出する**

[Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) はシェイプです。以下の例はチャート領域の画像塗りから画像を抽出します。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **SmartArt シェイプから画像を抽出する**

[SmartArt](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartart/) オブジェクトはシェイプです。SmartArt のレイアウトによっては、ノードの箇条書き塗りやノードシェイプの塗り形式に画像が格納されることがあります。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **グループ化されたシェイプ内の画像を含める**

グループ化シェイプは独自のシェイプコレクションを持ちます。共有の `enumerate_shapes` ヘルパーには `include_grouped_shapes` オプションがあります。`GroupShape` オブジェクト内のシェイプを検査したい場合は `True` に設定してください。以下の例は画像フレーム、画像塗りシェイプ、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めたい場合は、前節の専門抽出ロジックを再利用しながら同じ再帰的シェイプ走査を行ってください。

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **エッジケースと実用的な注意点**

- **重複画像:** 複数のシェイプが同一画像を参照することや、バイト列が同一の別画像が存在することがあります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) の `binary_data` プロパティをハッシュ化してからファイルを書き出してください。
- **元データと変換後出力:** [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) の `binary_data` を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データがそのまま保持されます。`image` プロパティを `save` で使用すると、PNG などの一貫したフォーマットに変換できます。
- **未対応の塗りタイプ:** ソリッド、グラデーション、パターン、ノーフィル シェイプは画像塗りを含みません。`picture_fill_format` を読む前に [FillType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) を確認してください。
- **グループ化シェイプ:** スライドのトップレベルシェイプコレクションはグループをフラット化しません。グループ化コンテンツが重要な場合は、[GroupShape.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/groupshape/shapes/) を再帰的に検査してください。
- **OLE オブジェクトプレビュー:** [OleObjectFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/oleobjectframe/) は `substitute_picture_format` を通じてプレビュー画像を提供することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内部の埋め込みファイルではありません。
- **ビデオフレームサムネイル:** [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) は `picture_format` を通じてプレビュー画像を提供しますが、これはスライド上に表示されるポスターであり、ビデオストリームから抽出されたフレームではありません。
- **オーディオフレームサムネイル:** [AudioFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/) は `picture_format` を通じてアイコンやサムネイルを提供しますが、埋め込まれたオーディオデータそのものではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームシェイプは `image` プロパティを通じてカスタム [PPImage] オブジェクトを使用できる場合があります。
- **入れ子になったシェイプモデル:** テーブル、チャート、SmartArt オブジェクトはすべて [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) を実装しますが、画像はしばしばネストされたテーブルセル、チャート要素、SmartArt ノードの書式オブジェクトに格納されています。
- **切り抜きや変形された画像:** [PPImage] にアクセスすると格納されている画像リソースが取得できます。シェイプが適用した切り抜き、透過、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

**元の画像を切り抜きやエフェクト、シェイプ変形なしで抽出できますか？**

はい。[PPImage] オブジェクトにアクセスし、その `binary_data` プロパティをディスクに書き込んでください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上での表示方法は影響を受けません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。[PPImage] の `image` プロパティで画像オブジェクトを取得し、[ImageFormat.PNG](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imageformat/) を指定して `save` を呼び出してください。これにより出力が PNG に変換され、元のファイルタイプやベクターデータは保持されない可能性があります。

**同じ画像を複数回保存しないようにするには？**

[PPImage] の `binary_data` プロパティのハッシュを計算し、セットに保持してください。同じハッシュが既に存在する場合はスキップするか、既存の出力ファイルへの参照を記録してください。

**なぜ一部のシェイプから画像が取得できないのですか？**

画像フレーム、画像塗りシェイプ、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、画像はネストされた書式オブジェクトを介して提供されることがあり、単純な `picture_format` やシェイプの `fill_format` のチェックだけでは検出できない場合があります。

**ビデオフレームに表示されるサムネイルを抽出できますか？**

はい。[VideoFrame] を使用し、`picture_format.picture.image` を読み取ってください。これによりビデオフレームに格納されたポスター画像が抽出されますが、ビデオファイルから生成されたフレームではありません。

**プレゼンテーション画像コレクションから特定の画像を使用しているシェイプを特定するには？**

Aspose.Slides は [PPImage] からシェイプへの逆リンクを保持していません。走査中にマッピングを構築し、画像参照が見つかったときにスライド番号、シェイプパス、画像ハッシュまたはコレクション項目を記録してください。

**OLE オブジェクト内に埋め込まれた画像（例: 添付ドキュメント）を抽出できますか？**

[OleObjectFrame] の `substitute_picture_format` プロパティからスライドプレビュー画像は抽出できますが、これは埋め込まれたドキュメント自体ではありません。内部ファイルから画像を抽出したい場合は、OLE データを取得し、該当ファイルタイプ用のツールで解析してください。