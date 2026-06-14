---
title: 從 Python 中的簡報形狀提取影像
linktitle: 形狀中的影像
type: docs
weight: 90
url: /zh-hant/python-net/extracting-images-from-presentation-shapes/
keywords:
- 提取影像
- 取得影像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 從 PowerPoint 與 OpenDocument 簡報的形狀中提取影像 - 快速、程式碼友善的解決方案。"
---
## **概觀**

簡報中的圖片可以以多種形狀類型出現：普通的圖片框、套用於形狀的圖片填滿、OLE 物件預覽圖、影片或音訊框的縮圖、縮放圖片，或是嵌入於表格、圖表與 SmartArt 形狀內的圖片。Aspose.Slides 會將這些圖片儲存在簡報的影像集合中，透過 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 與 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件對外提供。

如果您只需要匯出簡報中嵌入的每一個影像資源，只要遍歷 `presentation.images` 即可。本文聚焦於另一項作業：遍歷形狀以找出圖片在投影片中的使用位置，讓儲存的檔案能保留有用的情境資訊，如投影片編號、形狀位置以及來源類型（圖片框、填滿圖片、媒體預覽、OLE 預覽或縮放圖片）。

{{% alert title="Tip" color="primary" %}}
使用 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的 `binary_data` 屬性可保留原始編碼的影像資料與檔案類型。若想將輸出正規化為特定格式（例如 PNG），則使用 `image` 屬性搭配 `save`。
{{% /alert %}}

## **共用輔助方法**

以下的輔助方法用於簡化範例程式碼。`save_original_image` 會寫入原始嵌入位元組、依 MIME 類型選擇安全的副檔名，並根據 SHA-256 雜湊跳過重複的影像二進位資料。

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

## **從圖片框擷取影像**

使用此方法可處理作為獨立物件插入的圖片。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 會將圖片儲存在 `picture_format.picture.image`，該屬性會回傳一個 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件。

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

## **從圖片填滿形狀擷取影像**

形狀可以使用圖片作為填滿。先檢查形狀的填滿類型：如果不是 [FillType.PICTURE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)，則該填滿不含圖片可供擷取。以下範例處理 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 物件，並透過 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的 `image` 屬性將每張圖片存為 PNG。

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

## **從 OLE 物件框擷取預覽影像**

[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 可能具有 PowerPoint 用於投影片預覽的替代圖片。此圖片可透過 `substitute_picture_format.picture.image` 取得。擷取此圖片會得到預覽圖，而非嵌入的 OLE 套件內容。

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

## **從影片框擷取預覽影像**

[VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 也能在 `picture_format.picture.image` 中儲存預覽圖。這是投影片上顯示的海報或縮圖，並非從影片串流解碼的畫格。

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

## **從音訊框擷取預覽影像**

[AudioFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/audioframe/) 可以在 `picture_format.picture.image` 中存放縮圖。此圖像是投影片上音訊物件顯示的圖示。

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

## **從縮放物件擷取影像**

[ZoomFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/zoomframe/) 與 [SectionZoomFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectionzoomframe/) 形狀可以使用自訂圖片。從縮放框讀取 `zoom_image`。

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

## **從摘要縮放框擷取影像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/summaryzoomframe/) 也是一個形狀。其各節項目可使用自訂圖片，透過每個摘要縮放節的 `zoom_image` 屬性取得。

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

## **從表格形狀擷取影像**

[Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 本身即為形狀。表格中的圖片通常以儲存格的圖片填滿形式存在。

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

## **從圖表形狀擷取影像**

[Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/) 為形狀。下列範例從圖表區域的圖片填滿中擷取影像。

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

## **從 SmartArt 形狀擷取影像**

[SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/) 物件是形狀。依據 SmartArt 版面配置，圖片可能儲存在節點的項目符號填滿或節點形狀的填滿格式中。

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

## **包含群組形狀內的影像**

群組形狀擁有自己的形狀集合。共用的 `enumerate_shapes` 輔助方法提供 `include_grouped_shapes` 參數。當您需要檢查 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/) 物件內的形狀時，將其設為 `True`。下例從圖片框、圖片填滿形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中擷取影像。若同時想包含表格、圖表、SmartArt 與摘要縮放的影像，請重複使用前述各節的專屬擷取邏輯，並保持相同的遞迴形狀遍歷方式。

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

## **邊緣案例與實務說明**

- **重複影像：** 多個形狀可能參考同一張影像，或是不同影像卻擁有相同的位元組。寫檔前先對 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的 `binary_data` 屬性進行雜湊，可讓每個唯一影像只產生一個輸出檔案。
- **原始資料 vs. 轉換後輸出：** 儲存 `binary_data` 屬性會保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。透過 `image` 屬性並呼叫 `save` 則適用於需要統一輸出格式的情況。
- **不支援的填滿類型：** 實心、漸層、圖案與無填滿的形狀不含圖片填滿。在讀取 `picture_fill_format` 前請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)。
- **群組形狀：** 投影片的頂層形狀集合不會自動展開群組。當群組內容重要時，請遞迴檢查 [GroupShape.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/shapes/)。
- **OLE 物件預覽：** [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 可能透過 `substitute_picture_format` 暴露預覽影像，但該影像僅為投影片預覽，並非 OLE 物件內嵌的檔案本身。
- **影片框縮圖：** [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 可能透過 `picture_format` 暴露預覽影像，該影像僅為投影片上顯示的海報，並未從影片串流抽取。
- **音訊框縮圖：** [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/audioframe/) 可能透過 `picture_format` 暴露圖示或縮圖，該資料並非嵌入的音訊檔案本身。
- **縮放影像：** 投影片縮放、節點縮放與摘要縮放形狀可使用自訂的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件，透過 `image` 屬性取得。
- **巢狀形狀模型：** Table、Chart 與 SmartArt 物件皆實作 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/)，但它們的圖片通常儲存在巢狀的表格儲存格、圖表元素或 SmartArt 節點的格式物件內。
- **裁切或變形的圖片：** 直接存取 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 會得到儲存的影像資源。它不會套用形狀所做的裁切、透明度、重新著色、旋轉或其他視覺效果。

## **常見問答**

**我可以在不裁切、套用效果或形狀變形的情況下擷取原始影像嗎？**

可以。存取 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件，將其 `binary_data` 屬性寫入磁碟，即可保留簡報中儲存的原始編碼影像，而非投影片上渲染的結果。

**我可以將所有擷取的影像匯出為 PNG 嗎？**

可以。使用 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的 `image` 屬性取得影像物件，然後以 [ImageFormat.PNG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/) 呼叫 `save`。此方式會將輸出轉換為 PNG，可能無法保留原始檔案類型或向量資料。

**如何避免同一張影像被多次儲存？**

對 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的 `binary_data` 屬性計算雜湊，並將雜湊值存入集合。若新影像的雜湊已存在，則跳過寫入或改為記錄另一個對應的輸出檔案。

**為什麼有些形狀不會產生影像？**

圖片框、圖片填滿形狀、OLE 物件框、媒體框、縮放框、表格、圖表與 SmartArt 物件都可能參考影像。但某些形狀是透過巢狀的格式物件公開影像，僅檢查 `picture_format` 或形狀的 `fill_format` 可能不足以捕捉所有情況。

**我可以擷取影片框顯示的縮圖嗎？**

可以。使用 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 並讀取 `picture_format.picture.image`，即可取得隨影片框一起儲存的海報圖像，而非從影片檔案產生的畫格。

**我如何判斷哪些形狀使用了簡報影像集合中的特定影像？**

Aspose.Slides 不會保留從 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 到形狀的反向連結。遍歷過程中可自行建立映射：每當找到影像參考時，記錄投影片編號、形狀路徑以及影像雜湊或集合項目。

**我能擷取嵌入於 OLE 物件內的影像（例如附加的文件）嗎？**

您可以從 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 的 `substitute_picture_format` 屬性取得該 OLE 物件在投影片上的預覽圖。但此預覽圖並非嵌入的文件本身。若要從嵌入檔案中擷取影像，需先將 OLE 資料抽出，然後使用相應檔案類型的工具進行檢查。