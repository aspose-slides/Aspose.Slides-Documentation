---
title: 使用 Python 向簡報新增圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/python-net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增影像
- 建立影像
- 擷取影像
- 點陣影像
- 向量影像
- 裁切影像
- 裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，為 PowerPoint 與 OpenDocument 簡報新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

在 Aspose.Slides for Python 中，圖片框允許您將點陣圖與向量圖作為原生投影片形狀放置和管理。您可以從檔案或串流插入圖片，以精確座標定位與調整大小、套用旋轉、設定透明度，並與其他形狀一起控制 Z‑order。API 亦支援裁切、維持長寬比、設定邊框與效果，並可在不重新建立版面配置的情況下更換底層圖片。由於圖片框的行為如同一般形狀，您可為其加入動畫、超連結與替代文字，輕鬆打造視覺豐富且具可及性的簡報。

## **建立圖片框**

本節說明如何在 Aspose.Slides for Python 中建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 以在投影片中插入圖片。您將學習如何載入圖片、精確放置於投影片上，以及控制其大小與格式設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
2. 依索引取得投影片。  
3. 透過將圖片加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。此圖片將用來填充形狀。  
4. 指定框架的寬度與高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法建立相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
6. 將簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何建立圖片框：

```py
import aspose.slides as slides

# 實例化 Presentation 類別以代表 PPTX 檔案。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 將影像加入簡報。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 新增與影像尺寸相同的圖片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 將簡報儲存為 PPTX。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

圖片框可讓您快速從圖片建立簡報投影片。將圖片框與 Aspose.Slides 儲存選項結合使用，您即可控制 I/O 操作，將圖片從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/image-to-jpg/)、轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-image/)、轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-jpg/)、轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/svg-to-png/)。  

{{% /alert %}}

## **以相對比例建立圖片框**

本節示範先以固定尺寸放置圖片，然後分別以百分比方式獨立調整寬度與高度。因為百分比可能不同，長寬比會發生變化。縮放是相對於圖片原始尺寸執行。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
2. 依索引取得投影片。  
3. 透過將圖片加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。  
4. 在投影片上加入 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
5. 設定圖片框的相對寬度與高度。  
6. 將簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何以相對縮放建立圖片框：

```py
import aspose.slides as slides

# 實例化 Presentation 類別以代表 PPTX 檔案。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 將影像加入簡報的圖像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 將圖片框新增至投影片。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 設定相對縮放的寬度與高度。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 儲存簡報。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **從圖片框提取點陣圖**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 物件中提取點陣圖，並以 PNG、JPG 及其他格式儲存。以下程式碼示例說明如何從文件「sample.pptx」提取圖像並以 PNG 格式儲存。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **從圖片框提取 SVG 圖像**

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 形狀內放置 SVG 圖形時，Aspose.Slides for Python via .NET 可讓您以完整保真度取得原始向量圖。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)，檢查其底層的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 是否包含 SVG 內容，然後將該圖像以原始 SVG 格式儲存至磁碟或串流。

以下程式碼示例演示如何從圖片框提取 SVG 圖像：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **取得圖像透明度**

Aspose.Slides 允許您取得套用於圖像的透明度效果。以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
所有套用於圖像的效果均可在 [aspose.slides.effects](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/) 找到。  
{{% /alert %}}

## **取得圖像的亮度與對比度**

Aspose.Slides 允許您取得套用於圖像的亮度與對比度效果。[Luminance](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/luminance/) 類別代表此圖像轉換效果。

以下 Python 程式碼示範如何從圖片框取得亮度與對比度設定：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **圖片框格式設定**

Aspose.Slides 提供多種格式設定選項，可套用於圖片框，以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
2. 依索引取得投影片。  
3. 透過將圖片加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。此圖片將用來填充形狀。  
4. 指定框架的寬度與高度。  
5. 使用投影片的 [add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法建立相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
6. 設定圖片框的線條顏色。  
7. 設定圖片框的線條寬度。  
8. 以正值（順時針）或負值（逆時針）旋轉圖片框。  
9. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範圖片框的格式設定流程：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化 Presentation 類別以代表 PPTX 檔案。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 將影像加入簡報的圖像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 新增與影像尺寸相同的圖片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 對圖片框套用格式設定。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # 將簡報儲存為 PPTX。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose 已開發免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若需 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖片，或是 [建立相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，可使用此服務。  
{{% /alert %}}

## **將圖像作為連結加入**

為了縮小簡報檔案大小，您可以透過連結方式加入圖像或影片，而非直接嵌入檔案。以下 Python 程式碼示範如何在佔位區插入圖像與影片：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **裁切圖像**

本節將說明如何在不改變來源檔案的前提下，裁切圖片框內圖像的可見區域。您也會學習基本的裁切邊距設定方法，以在投影片上直接建立乾淨、聚焦的構圖。

以下 Python 程式碼示範如何在投影片上裁切圖像：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 將影像加入簡報的圖像集合。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 新增圖片框至投影片。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 裁切影像（百分比值）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 儲存結果。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **刪除圖像的裁切區域**

若要刪除框中圖像的裁切區域，請使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法。若無需裁切，該方法會回傳原始圖像。

以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 從第一張投影片取得 PictureFrame。
    picture_frame = slides.shape[0]

    # 從第一張投影片取得 PictureFrame。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 儲存結果。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

[delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法會將裁切後的圖像加入簡報的圖像集合。若該圖像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 中使用，則可減少簡報大小；否則，最終簡報中的圖像數量可能會增加。

在裁切過程中，此方法會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。  
{{% /alert %}}

## **壓縮圖像**

您可使用 [PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/compress_image/) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定解析度減少圖像尺寸，並可選擇刪除裁切區域。

它的運作方式類似 PowerPoint 中 **圖片格式 -> 壓縮圖片 -> 解析度** 功能。

以下 Python 範例示範如何依目標解析度壓縮簡報中的圖像，並可選擇移除裁切區域：

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 以目標解析度 150 DPI（網路解析度）壓縮影像並移除裁切區域。
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # 檢查壓縮結果。
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

或直接使用自訂 DPI 值：

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 將影像壓縮至 150 DPI（網路解析度），並移除裁切區域。
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

此方法會依形狀大小與提供的 DPI 將圖像轉換為較低解析度。裁切區域亦可被刪除以最佳化檔案大小。若圖像為 WMF/EMF 中繪圖檔或 SVG，則不會套用壓縮。JPEG 的品質會依解析度略有降低，與 PowerPoint 處理高解析度 JPEG 的方式相同。  
{{% /alert %}}

## **鎖定長寬比**

若您希望在變更圖像尺寸後，包含圖像的形狀仍保留其長寬比，請將 [aspect_ratio_locked](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 屬性設為 `True`。

以下 Python 程式碼示範如何鎖定形狀的長寬比：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # 在調整大小時鎖定長寬比。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

此 *鎖定長寬比* 設定僅保留形狀的長寬比，而不會影響其中圖像本身的長寬比。  
{{% /alert %}}

## **使用 Stretch Offset 屬性**

透過 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 類別的 `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right`、`stretch_offset_bottom` 屬性，您可以定義填充矩形。

當為圖像指定拉伸時，來源矩形會被縮放以符合填充矩形。填充矩形的每一邊皆以相對於形狀邊界框相應邊緣的百分比偏移來定義。正百分比表示內縮，負百分比表示外擴。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
2. 依索引取得投影片參考。  
3. 新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。  
4. 設定形狀的填充類型。  
5. 設定形狀的圖片填充模式。  
6. 載入圖像。  
7. 將圖像指派為形狀的填充。  
8. 指定圖像相對於形狀邊界框各邊的偏移。  
9. 將簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何使用 Stretch Offset 屬性：

```py
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增矩形 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 設定形狀的填充類型。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 設定形狀的圖片填充模式。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 載入影像並將其加入簡報。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 將影像指派為形狀的填充。
    shape.fill_format.picture_fill_format.picture.image = image

    # 指定影像相對於形狀邊界框各邊的偏移量。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose 提供免費的轉換工具—[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓您快速從圖片建立簡報。  
{{% /alert %}}

## **常見問題集**

**如何得知 PictureFrame 支援哪些圖像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 的圖像物件，支援點陣圖 (PNG、JPEG、BMP、GIF 等) 與向量圖 (例如 SVG)。支援的格式清單大致與投影片與圖像轉換引擎的功能相吻合。

**加入大量大型圖像會對 PPTX 大小與效能產生什麼影響？**

嵌入大型圖像會增加檔案大小與記憶體使用量；以連結方式加入圖像則可降低簡報大小，但需確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入圖像的功能，以減少檔案大小。

**如何防止圖像物件被意外移動或調整大小？**

可對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/picture_frame_lock/)（例如停用移動或調整大小）。鎖定機制在獨立的 [保護文章](/slides/zh-hant/python-net/applying-protection-to-presentation/) 中說明，且支援包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 在內的多種形狀類型。

**在將簡報匯出為 PDF/圖像時，SVG 向量的保真度是否會被保留？**

Aspose.Slides 可從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 中提取原始 SVG 向量。若 [匯出為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/python-net/convert-powerpoint-to-png/)，結果可能會根據匯出設定被點陣化；提取行為確認了原始 SVG 仍以向量形式儲存。