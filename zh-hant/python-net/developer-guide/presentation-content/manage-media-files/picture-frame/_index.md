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
- 內嵌圖像
- 連結圖像
- 抽取圖像
- 點陣圖像
- SVG 圖像
- 裁剪圖像
- 刪除裁剪區域
- 壓縮圖像
- 拉伸偏移
- 圖片框格式設定
- 相對比例
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在簡報中建立、格式化、連結、裁剪、抽取與壓縮圖片框。"
---
## **Overview**

圖片框是顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示圖像的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 透過其 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 擁有內嵌圖像資源，而一個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級設定。

當同一張圖像需要顯示多次時，這種分離非常有用。先將圖像加入簡報一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)，在建立圖片框時重複使用該圖像資源。

圖片框可以容納 PNG 或 JPEG 等點陣圖，也可以容納 SVG 向量圖。它們亦可參照連結圖像，而非將圖像位元組儲存在簡報中。此選擇會影響可攜性、檔案大小、抽取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的儲存方式是很有幫助的。

## **Add and Format an Embedded Image**

對於內嵌圖像，將圖像資料加入簡報，並使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 建立圖片框。圖像會成為簡報套件的一部分，因而在搬移到其他電腦時仍能保持自包含。

以下範例加入 JPEG 圖像，依圖像原始尺寸建立框架，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；變更框架大小不會改變儲存在內嵌圖像資源中的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 提供 [relative_scale_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/relative_scale_width/) 和 [relative_scale_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/relative_scale_height/) 供框架使用。`1.0` 的值相當於原始圖片大小的 100%。相對比例在工作流程需要保留與來源圖像尺寸關係，而非手動計算最終尺寸時非常有用。

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

相對比例會變更框架的比例設定；它不會重新取樣或壓縮內嵌圖像。

## **Embedded and Linked Images**

內嵌圖片將圖像資料儲存在簡報內，因而是最安全的可攜性與可預測渲染選擇。連結圖片則透過 [Picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/) 連結路徑儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中儲存的圖像資料量，但會產生外部相依性。開啟或渲染簡報的應用程式必須能存取該連結檔案。若路徑變更、檔案搬移或資源無法取得，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、保存或在隔離環境中渲染的簡報，內嵌圖像通常較為可靠。

### **Add a Linked Image**

以下範例建立圖片框並指向本機圖像檔。此範例僅處理圖像連結；視訊連結屬於另一套媒體工作流程，故未混入此範例。

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

在刻意管理外部檔案時使用連結。不要僅將其當作壓縮的替代方案：一個帶有破損圖像相依性的較小 PPTX 通常不如較大且自包含的簡報實用。

## **Extract Images from Picture Frames**

在從現有簡報抽取圖像之前，先確認形狀實際上是 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 且包含內嵌圖像。連結圖片框可能不包含可同樣抽取的圖像位元組。

### **Extract a Raster Image**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/)。以下範例在投影片上找到第一個內嵌點陣圖片，並以 PNG 格式儲存：

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

透過 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 儲存會將抽取的圖像轉換為所請求的輸出格式。如果需要簡報中儲存的編碼位元組，而非已轉換的點陣檔，請改用 [PPImage.binary_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/binary_data/) 屬性。

### **Extract an SVG Image**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 會公開一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報中保留向量來源。PNG 或 JPEG 等點陣匯出必然將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是一種渲染動作，因此匯出的圖形不應被視為原始內嵌 SVG 的位元對位元拷貝；在需要原始向量資源時，請使用內嵌的 [SvgImage.svg_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/svg_data/)。

## **Crop an Image**

裁剪會變更框架內可見的圖像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 上的裁剪值以來源圖像尺寸的百分比表示。裁剪並不會立即從內嵌圖像中刪除隱藏的像素，只是改變可見區域。

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

因為隱藏的圖像資料仍然存在，之後仍可變更裁剪而不會失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁剪區域。

## **Remove Cropped Image Data**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 會移除目前裁剪矩形外的圖像資料，並回傳產生的圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再用於之後的取消裁剪操作。

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

此方法可能會在簡報中加入新的圖像資源。如果原始圖像同時被其他圖片框使用，這些框仍需保留其現有資源，因此刪除裁剪區域不一定會減少圖像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **Compress Raster Images**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/compress_image/) 會依圖片顯示的尺寸相對降低點陣圖解析度。它也可以在同一次操作中移除裁剪區域。若圖像被重新調整大小或裁剪，方法會回傳 `True`；若未需要變更則回傳 `False`。

當標準目標解析度足以時，可使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/picturescompression/) 值：

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

若需要特定目標，亦可傳入自訂的正值 DPI 取代列舉值。

壓縮僅適用於點陣圖。SVG 與圖形檔內容不會因此點陣壓縮工作流程而縮小。也請記得，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請基於圖像實際檢視或匯出時的最大尺寸選擇目標解析度，而非全局套用最低 DPI。

## **Inspect Image Effects**

圖片效果儲存在框架使用的圖片上。圖像變換集合可以包含例如固定透明度調變 (AlphaModulateFixed) 與亮度調整 (Luminance) 等效果。下列範例安全地從投影片上的第一個圖片框讀取這兩種效果：

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

[AlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/alphamodulatefixed/) 與 [Luminance](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/luminance/) 會變更框架內圖像的呈現方式；它們不會重新寫入原始內嵌圖像位元組。

## **Lock Picture Frame Geometry**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會對圖片框被停用。例如，[aspect_ratio_locked](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 屬性能在調整大小時保持形狀比例。

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

此鎖定套用於圖片框形狀本身，並不會強迫來源圖像重新取樣或永久改變為相同的長寬比。

## **Adjust the StretchOffset Values**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 上的 stretch‑offset 值會相對於圖片框的邊界框定義填充矩形。正比例會在邊緣內縮，負比例則會向外延伸。

這與裁剪不同。裁剪值決定來源圖像哪個部分可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 進行填充位置調整。若目標是隱藏來源圖像邊緣，則使用裁剪屬性。

## **Storage, File Size, and Export Considerations**

當圖像儲存與圖片框格式分別處理時，主要的權衡較易管理：

- **Embedded images** 使簡報自包含，是分享與伺服器端渲染最可靠的選擇，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **Linked images** 可以讓套件較小，但簡報依賴外部檔案在儲存的路徑或位置仍須可用。
- **Cropping** 初始為非破壞性。隱藏的像素會保留在內嵌圖像中，直到明確刪除裁剪區域或在壓縮時移除。
- **Compression** 能顯著減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再執行。
- **SVG images** 在需要保留向量時應保持為 SVG。當需要向量資源本身時，直接抽取內嵌 SVG。點陣投影片匯出始終會將渲染的投影片轉換為像素。
- **Repeated images** 應盡可能重複使用既有的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 資源，而不是在簡報工作流程中重複載入相同檔案。

對於大型簡報，圖像最佳化通常在有選擇性地執行時最有效：將標誌與圖表保留為向量內容，依實際顯示尺寸壓縮照片，僅在不需日後編輯時移除裁剪像素，除非部署設計已納入相依管理，否則避免使用外部連結。

## **FAQ**

**What is the difference between a picture frame and an image resource?**

[PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 代表與簡報關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示圖像並儲存框架層級的幾何與格式（例如大小、旋轉、裁剪值、效果與鎖定）。

**Should I embed or link images?**

當簡報必須具備可攜性、保存或在無外部資源存取的情況下渲染時，請嵌入圖像。僅在有意將圖像檔案保留在 PPTX 之外且能可靠維護外部位置時，才使用連結圖像。

**Does cropping reduce PPTX file size?**

僅裁剪本身不會減少檔案大小。普通的裁剪設定會隱藏來源圖像的部分，但仍保留底層像素。若需要永久移除這些像素，請使用 [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 或搭配裁剪區域刪除的圖像壓縮。

**Can I restore image quality after compression?**

不能。壓縮會降低儲存的點陣解析度，且刪除裁剪區域會捨棄圖像資料。若日後可能需要高解析度編輯，請將原始來源圖像保留在簡報之外。

**How should SVG images be handled?**

在向量保真度重要時，應將 SVG 內容保留為 SVG。內嵌的 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 可直接抽取。將投影片渲染為 PNG 或 JPEG 等點陣格式會將 SVG 光柵化為圖像的一部分。

**How can I avoid unsafe casts when reading existing slides?**

在使用圖片框相關成員之前，先檢查形狀類型。使用 `isinstance(shape, slides.PictureFrame)` 可避免無效的類型轉換，並讓程式碼能正確處理不含圖片框的投影片。