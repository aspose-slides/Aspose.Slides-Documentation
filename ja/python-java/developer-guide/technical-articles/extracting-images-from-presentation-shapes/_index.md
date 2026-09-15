---
title: Python（Java 経由）でプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 100
url: /ja/python-java/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションの形状から画像を抽出する - 簡単でコードに優しいソリューション。"
---
## **概要**

プレゼンテーション内の画像は、さまざまな形状タイプで表示されます。普通の画像フレームとして、形状に適用された画像塗りつぶしとして、OLE オブジェクトのプレビュー画像として、ビデオやオーディオフレームのサムネイルとして、ズーム画像として、またはテーブル、チャート、SmartArt の形状に入れ子になった画像としてです。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/) と [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、[Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) を列挙してください。本記事は別のタスクに焦点を当てています。スライド上で画像が使用されている形状を走査し、保存したファイルにスライド番号、形状の位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、またはズーム画像）といった有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="success" %}}
[PPImage.getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getBinaryData) を使用すると、元のエンコードされた画像データとファイルタイプを保持できます。特定の形式（例: PNG）に正規化した出力が必要な場合は、`save` とともに [PPImage.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getImage) を使用してください。
{{% /alert %}}

## **共有ヘルパー関数**

以下の共有ヘルパー関数を `image_helpers.py` に保存し、サンプルスクリプトと同じディレクトリに置きます。これによりサンプルを簡潔に保てます。`save_original_image` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュによって重複する画像バイナリをスキップします。

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
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
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **画像フレームから画像を抽出する**

単独オブジェクトとして挿入された画像に対してこのアプローチを使用します。[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) は、[getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture)、および [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImage) を介して画像にアクセスでき、[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトを返します。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **画像で塗りつぶされた形状から画像を抽出する**

形状は画像を塗りつぶしとして使用できます。まず形状の塗りつぶしタイプを確認してください。`[FillType.Picture]` でない場合、その塗りつぶしから抽出できる画像はありません。以下の例は [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) オブジェクトを処理し、[PPImage.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getImage) を使用して各画像を PNG として保存します。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **OLE オブジェクトフレームからプレビュー画像を抽出する**

[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) には、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は [getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)、[getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture)、および [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImage) を介して取得できます。この画像を抽出すると、埋め込まれた OLE パッケージの内容ではなく、プレビュー画像が得られます。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **ビデオフレームからプレビュー画像を抽出する**

[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) も同様に、[getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture)、および [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImage) を介してプレビュー画像を格納できます。これはスライドに表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **オーディオフレームからプレビュー画像を抽出する**

[AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) は、[getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture)、および [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImage) を介してサムネイルを格納できます。これはスライド上のオーディオオブジェクトに表示される画像です。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **ズームオブジェクトから画像を抽出する**

[ZoomFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zoomframe/) および [SectionZoomFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームからは [getZoomImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zoomobject/#getZoomImage) を読み取ります。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **サマリーズームフレームから画像を抽出する**

[SummaryZoomFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/summaryzoomframe/) も形状です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの [getZoomImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zoomobject/#getZoomImage) メソッドで取得できます。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **テーブル形状から画像を抽出する**

[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) は形状です。テーブル内の画像は通常、テーブルセルの画像塗りつぶしとして保存されます。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **チャート形状から画像を抽出する**

[Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **SmartArt 形状から画像を抽出する**

[SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、ノードの箇条書き塗りつぶしやノード形状の塗りつぶしフォーマットに画像が格納されている場合があります。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを保持します。共有されている `enumerate_shapes` ヘルパーには `include_grouped_shapes` オプションがあります。`GroupShape` オブジェクト内部の形状も検査したい場合は `True` に設定してください。以下の例は画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトのプレビュー、ビデオフレームのサムネイル、オーディオフレームのサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めたい場合は、前述のセクションの専用抽出ロジックを再利用し、同じ再帰的形状走査を維持してください。

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **エッジケースと実用的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照したり、バイト列が同一の別画像を参照したりすることがあります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、ファイルを書き込む前に [PPImage.getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getBinaryData) のハッシュを取得してください。
- **元データと変換後出力:** [PPImage.getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getBinaryData) を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データがそのまま保持されます。`save` とともに [PPImage.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getImage) を使用すると、PNG などの統一フォーマットに変換できます。
- **サポートされない塗りつぶしタイプ:** ソリッド、グラデーション、パターン、ノーフィルの形状には画像塗りつぶしが含まれません。[FillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を確認し、[getPictureFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#getPictureFillFormat) を読む前に判定してください。
- **グループ化された形状:** スライドの最上位形状コレクションはグループをフラットにしません。グループ化されたコンテンツが重要な場合は、[GroupShape.getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/#getShapes) を再帰的に検査してください。
- **OLE オブジェクトのプレビュー:** [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) は [getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じてプレビュー画像を公開することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内に埋め込まれたファイルそのものではありません。
- **ビデオフレームのサムネイル:** [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) は [getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat) を通じてプレビュー画像を提供しますが、これはスライド上に表示されるポスターであり、ビデオストリームから抽出されたフレームではありません。
- **オーディオフレームのサムネイル:** [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) は [getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat) を通じてアイコンまたはサムネイルを提供しますが、埋め込まれたオーディオデータ自体ではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズーム形状は、[getZoomImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zoomobject/#getZoomImage) を介してカスタムの [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトを使用できます。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトはすべて [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) を実装していますが、画像はしばしば入れ子になったテーブルセル、チャート要素、または SmartArt ノードのフォーマットオブジェクトに格納されています。
- **切り抜きや変形された画像:** [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) にアクセスすると、格納されている画像リソースが取得できます。形状が適用した切り抜き、透明度、再カラー、回転、その他の視覚効果は反映されません。

## **FAQ**

**元の画像を切り抜きやエフェクト、形状変換なしで抽出できますか？**

はい。[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトにアクセスし、[PPImage.getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getBinaryData) をディスクに書き込んでください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上でのレンダリング方式は影響しません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。[PPImage.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getImage) を使用して画像オブジェクトを取得し、`save` と共に [ImageFormat.Png](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/) を指定してください。これにより出力が PNG に変換されますが、元のファイルタイプやベクターデータは保持されない可能性があります。

**同じ画像を複数回保存しないようにするには？**

[PPImage.getBinaryData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getBinaryData) のハッシュを計算し、ハッシュの集合で管理します。新しい画像のハッシュが既に存在する場合は、保存をスキップするか、既存の出力ファイルへの参照を記録してください。

**なぜ一部の形状から画像が取得できないのですか？**

画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、画像が入れ子になったフォーマットオブジェクトを介して公開されることがあります。そのため、単純な [getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat) や形状の [getFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getFillFormat) だけでは不十分な場合があります。

**ビデオフレームのサムネイル画像を抽出できますか？**

はい。[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) を使用し、[getPictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture)、および [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImage) を読み取ります。これにより、ビデオフレームに保存されたポスター画像が抽出されますが、ビデオファイルから生成されたフレームではありません。

**特定の画像がプレゼンテーション画像コレクションのどの形状で使用されているかを特定するには？**

Aspose.Slides は [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) から形状への逆リンクを保持していません。走査中にマッピングを構築してください。画像参照が見つかったら、スライド番号、形状パス、画像ハッシュまたはコレクション項目を記録します。

**OLE オブジェクト内に埋め込まれた画像（例: 添付文書）を抽出できますか？**

[OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) からはスライドプレビュー画像が取得できますが、これは埋め込まれた文書そのものではありません。OLE データを抽出し、対象ファイルタイプに適したツールで内部の画像を調査してください。