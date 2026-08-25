---
title: 使用 Python 在簡報中管理圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/python-net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 嵌入圖像
- 連結圖像
- 提取圖像
- 點陣圖像
- SVG 圖像
- 裁剪圖像
- 刪除裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框格式設定
- 相對縮放
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在簡報中建立、格式化、連結、裁剪、提取與壓縮圖片框。"
---
## **概觀**

圖片框是一種顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示該圖像的形狀是分離的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 透過其[ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 擁有嵌入的圖像資源，而[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果及其他框架層級的設定。

此分離在相同圖像需要顯示多次時非常有用。將圖像一次加入簡報，保留返回的[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)，在建立圖片框時使用該圖像資源。

圖片框可以包含 PNG 或 JPEG 等點陣圖，以及 SVG 向量圖。也可以參照連結圖像而非將圖像位元組存放在簡報中。選擇會影響可攜性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定圖像應如何儲存是很實用的。

## **加入與格式化嵌入圖像**

對於嵌入圖像，將圖像資料加入簡報，並使用[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/)建立圖片框。圖像會成為簡報套件的一部分，因而在搬移至其他電腦時仍保持自包含。

以下範例加入 JPEG 圖像，依圖像原始尺寸建立框，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；變更框的大小並不會改變嵌入圖像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **使用相對縮放**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 提供[relative_scale_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/relative_scale_width/)與[relative_scale_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/relative_scale_height/)屬性。一個值為`1.0` 代表 100% 原始圖片大小。相對縮放在工作流程需要保留與來源圖像尺寸之關係，而非手動計算最終尺寸時非常有用。

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

相對縮放會變更框的縮放設定；它不會重新取樣或壓縮嵌入圖像。

## **嵌入與連結圖像**

嵌入圖片將圖像資料儲存在簡報內，因此在可攜性與可預測的渲染方面是最安全的選擇。連結圖片則透過[Picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/)連結路徑指向外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中的圖像資料量，但會產生外部依賴。連結的檔案必須保持對開啟或渲染簡報的應用程式可存取。若路徑變更、檔案移動或資源無法取得，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、存檔或在隔離環境中渲染的簡報，嵌入圖像通常較為可靠。

### **加入連結圖像**

以下範例建立圖片框並指向本機圖像檔案。它僅處理圖像連結；影片連結屬於另一個媒體工作流程，故此例未混入。

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

當外部檔案管理是有意為之時才使用連結。不要僅將其作為壓縮的替代方案：帶有斷裂圖像依賴的較小 PPTX 通常不如較大且自包含的簡報實用。

## **從圖片框提取圖像**

在從現有簡報提取圖像之前，先確認形狀實際上是[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)且包含嵌入圖像。連結圖片框可能不含可直接提取的圖像位元組。

### **提取點陣圖像**

現代圖像 API 直接使用[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖片，並以 PNG 儲存：

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

透過[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 儲存會將提取的圖像轉換為請求的輸出格式。若需要簡報內儲存的編碼位元組而非轉換後的點陣檔，請改用[PPImage.binary_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/binary_data/) 屬性。

### **提取 SVG 圖像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 會公開一個[SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 物件。這讓您可以直接取得 SVG 資料，而不用先光柵化圖片。

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

以 SVG 形式保留 SVG 內容可在簡報內保留向量來源。PNG 或 JPEG 等點陣匯出必然將該向量內容渲染為像素。PDF 或 SVG 投影片匯出亦屬於渲染操作，故匯出的圖形不應被視為原始嵌入 SVG 的逐位元拷貝；當需要原始向量資源時，請使用嵌入的[SvgImage.svg_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/svg_data/)。

## **裁剪圖像**

裁剪會變更在框內可見的圖像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 上的裁剪值是來源圖像尺寸的百分比。裁剪最初不會刪除嵌入圖像中隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框並套用裁剪值：

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

因為隱藏的圖像資料仍然存在，之後可以變更裁剪而不會失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁剪區域。

## **移除裁剪的圖像資料**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 會移除目前裁剪矩形之外的圖像資料，並返回結果圖像資源。這可減少檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素將無法再進行取消裁剪。

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

此方法可能會向簡報新增圖像資源。若原始圖像同時被其他圖片框使用，這些框仍需其現有資源，因此刪除裁剪區域不一定會減少圖像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖像**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/compress_image/) 會相對於圖片顯示尺寸降低點陣圖解析度。它也可以在同一操作中移除裁剪區域。當圖像被重新調整大小或裁剪時，方法回傳`True`；若不需要變更則回傳`False`。

當標準目標解析度足夠時，可使用預定義的[PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/picturescompression/) 值：

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

若需特定目標，可傳入自訂的正 DPI 數值取代列舉值。

壓縮僅適用於點陣圖像。SVG 與圖形檔內容不會因此點陣壓縮工作流程而減少。同時請記住，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報復原。應根據圖像實際顯示或匯出的最大尺寸選擇目標解析度，而非全局套用最低 DPI。

## **管理圖像變換效果**

欲深入了解亮度、對比度、顏色變換、模糊、透明度效果、排序鏈、檢查、移除與往返驗證等完整工作流程，請參閱[Image Transform Effects](/slides/zh-hant/python-net/image-transform-effects/)。

## **鎖定圖片框幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被禁用。例如，[aspect_ratio_locked](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 屬性可在調整大小時保留形狀比例。

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

此鎖定套用於圖片框形狀，不會強迫來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界盒的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值選擇來源圖像的可見部分；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 進行填充定位。若目的是隱藏來源圖像邊緣，則使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框格式化分開處理時，主要權衡較易管理：

- **嵌入圖像** 使簡報自包含，對於分享與伺服器端渲染最可靠；但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結圖像** 可讓套件較小，然而簡報依賴外部檔案在存放路徑或位置仍可取得。
- **裁剪** 初始為非破壞性。隱藏的像素會保留在嵌入圖像中，直到明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在已知投影片上實際顯示尺寸後再套用。
- **SVG 圖像** 若向量保留重要，應保持為 SVG。需要向量資源時直接提取嵌入的 SVG。光柵化的投影片匯出始終會將渲染的投影片轉換為像素。
- **重複圖像** 應盡可能重用現有[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)資源，而非在簡報工作流程中重複載入相同檔案。

對於大型簡報，圖像最佳化通常在選擇性執行時最有效：將商標與圖表保留為向量內容，依實際顯示尺寸壓縮照片，僅在不需日後編輯時移除裁剪像素，除非依賴管理是部署設計的一部份，否則避免使用外部連結。

## **常見問答**

**圖片框與圖像資源有何差異？**

[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 代表與簡報關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 是投影片上的形狀，用於顯示圖像並儲存框層級的幾何與格式設定，如大小、旋轉、裁剪值、效果與鎖定。

**應該嵌入還是連結圖像？**

當簡報必須可攜、存檔或在無外部資源存取的情況下渲染時，請嵌入圖像。僅在刻意將圖像檔案保留在 PPTX 之外且外部位置能可靠維護時才連結圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

單純裁剪不會。一般的裁剪設定會隱藏圖像的部分，但會保留底層像素。若可永久捨棄這些像素，請使用[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 或搭配裁剪區域移除的圖像壓縮。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會捨棄圖像資料。若日後可能需要高解析度編輯，請將原始來源圖像保留在簡報外部。

**SVG 圖像該如何處理？**

當向量完整性重要時，請保留 SVG 內容為 SVG。可直接提取嵌入的[SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/)。將投影片渲染為 PNG 或 JPEG 等點陣格式會將 SVG 光柵化為投影片影像。

**如何避免在讀取現有投影片時產生不安全的型別轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。使用`isinstance(shape, slides.PictureFrame)` 可避免無效的型別轉換，並讓程式碼正確處理不含圖片框的投影片。