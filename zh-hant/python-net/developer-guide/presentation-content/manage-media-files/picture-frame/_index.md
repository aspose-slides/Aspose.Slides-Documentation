---
title: 使用 Python 在簡報中加入圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/python-net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增圖像
- 建立圖像
- 擷取圖像
- 點陣圖像
- 向量圖像
- 裁剪圖像
- 已裁剪區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 圖像效果
- 長寬比
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中加入圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

Aspose.Slides for Python 中的圖片框允許您將點陣圖和向量圖作為本機幻燈片形狀放置和管理。您可以從檔案或串流插入圖片，使用精確座標定位和調整大小，套用旋轉、設定透明度，並與其他形狀一起控制 Z 順序。API 亦支援裁剪、維持長寬比、設定邊框與效果，以及在不重新建立佈局的情況下替換底層圖像。由於圖片框的行為類似一般形狀，您可以新增動畫、超連結與替代文字，輕鬆建構視覺豐富且具可及性的簡報。

## **建立圖片框**

本節說明如何透過在 Aspose.Slides for Python 中建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 來將影像插入幻燈片。您將學習如何載入影像、精確放置於幻燈片上，以及控制其大小與格式設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片。  
3. 透過將影像加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。此影像將用於填充形狀。  
4. 指定圖片框的寬度與高度。  
5. 使用 [add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法，建立相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
6. 將簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何建立圖片框：

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示 PPTX 檔案。
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
圖片框讓您能快速從圖像建立簡報投影片。當您將圖片框與 Aspose.Slides 儲存選項結合時，您可以控制 I/O 操作，將圖像從一種格式轉換為另一種格式。您可能想參考以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-svg/); convert [SVG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **建立具有相對縮放的圖片框**

本節示範將影像以固定大小放置，然後對其寬度與高度分別套用百分比縮放。由於百分比可能不同，長寬比會隨之變化。縮放是相對於影像的原始尺寸執行。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片。  
3. 透過將影像加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。  
4. 將 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 新增至投影片。  
5. 設定圖片框的相對寬度與高度。  
6. 將簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何建立具有相對縮放的圖片框：

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示 PPTX 檔案。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 將影像加入簡報的影像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 在投影片上新增圖片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 設定相對縮放的寬度與高度。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # 儲存簡報。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **從圖片框提取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 物件提取點陣圖像，並儲存為 PNG、JPG 及其他格式。以下程式碼範例示範如何從文件 "sample.pptx" 中提取圖像並以 PNG 格式儲存。

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

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 形狀內放置 SVG 圖形時，Aspose.Slides for Python 透過 .NET 讓您能完整還原原始向量圖像。透過遍歷投影片的形狀集合，您可以識別每個 [PictureFrame]、檢查底層的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 是否包含 SVG 內容，然後將該圖像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中提取 SVG 圖像：

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
所有套用於圖像的效果皆可在 [aspose.slides.effects](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.effects/) 中找到。
{{% /alert %}}

## **圖片框格式設定**

Aspose.Slides 提供多種格式設定選項，可套用於圖片框。透過這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片。  
3. 透過將影像加入投影片的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。此影像將用於填充形狀。  
4. 指定圖片框的寬度與高度。  
5. 使用投影片的 [add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法，建立相同尺寸的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
6. 設定圖片框的線條顏色。  
7. 設定圖片框的線條寬度。  
8. 透過提供正值（順時針）或負值（逆時針）旋轉圖片框。  
9. 將修改後的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範圖片框的格式設定流程：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例以表示 PPTX 檔案。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 將影像加入簡報的影像集合。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 新增與影像尺寸相同的圖片框。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 套用圖片框的格式設定。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # 將簡報儲存為 PPTX。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose 已開發免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像，或 [建立相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，都可以使用此服務。
{{% /alert %}}

## **將圖像作為連結添加**

為了減小簡報檔案大小，您可以透過連結方式加入圖像或影片，而非直接將檔案嵌入簡報。以下 Python 程式碼示範如何在佔位符中插入圖像與影片：

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

## **裁剪圖像**

在本節中，您將學習如何在不更改來源檔案的情況下，裁剪圖片框內圖像的可見區域。您也會了解套用裁剪邊距的基本方法，以在投影片上直接建立乾淨、聚焦的構圖。

以下 Python 程式碼示範如何在投影片上裁剪圖像：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 將影像加入簡報的影像集合。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 在投影片上新增圖片框。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 裁剪影像（百分比值）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 儲存結果。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **刪除圖像的裁剪區域**

如果您想刪除框中圖像的裁剪區域，可使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法。該方法會回傳裁剪後的圖像，若不需要裁剪則回傳原始圖像。

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
[delete_picture_cropped_areas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) 方法會將裁剪後的圖像加入簡報的圖像集合。若該圖像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 中使用，則可減少簡報大小；否則，最終簡報的圖像數量可能會增加。 在裁剪期間，此方法會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。
{{% /alert %}}

## **壓縮圖像**

您可以使用 [PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/compress_image/) 方法壓縮簡報中的圖片。此方法會根據形狀尺寸與指定的解析度縮減圖像大小，並可選擇刪除裁剪區域。

它會調整圖片的大小與解析度，類似於 PowerPoint 的 **Picture Format -> Compress Pictures -> Resolution** 功能。

以下 Python 範例示範如何透過指定目標解析度並可選擇刪除裁剪區域，壓縮簡報中的圖像：

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 使用目標解析度 150 DPI（網路解析度）壓縮圖像並移除已裁剪區域。
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

    # 將圖像壓縮至 150 DPI（網路解析度），並移除已裁剪區域。
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
此方法會根據形狀尺寸與提供的 DPI 將圖像轉換為較低解析度。也可以刪除裁剪區域以優化檔案大小。若圖像為中繪圖檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 的品質會根據解析度保持或略為下降，與 PowerPoint 處理高解析度 JPEG 的方式相同。
{{% /alert %}}

## **鎖定長寬比**

如果您想讓包含圖像的形狀在變更圖像尺寸後仍保持長寬比，請將 [aspect_ratio_locked](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) 屬性設為 `True`。

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
此 *Lock Aspect Ratio* 設定只保護形狀本身的長寬比，而不會保持內部圖像的長寬比。
{{% /alert %}}

## **使用 Stretch Offset 屬性**

使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 類別的 `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right` 與 `stretch_offset_bottom` 屬性，您可以定義填充矩形。

當對圖像指定拉伸時，來源矩形會被縮放以符合填充矩形。填充矩形的每一邊皆以相對於形狀邊界框相應邊緣的百分比偏移來定義。正值表示內縮，負值表示外伸。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 新增矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。  
4. 設定形狀的填充類型。  
5. 設定形狀的圖片填充模式。  
6. 載入圖像。  
7. 將圖像指派給形狀填充。  
8. 指定圖像相對於形狀邊界框各邊緣的偏移。  
9. 將簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何使用 Stretch Offset 屬性：

```py
import aspose.slides as slides

# 建立代表 PPTX 檔案的 Presentation 類別實例。
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

    # 將影像指派給形狀填充。
    shape.fill_format.picture_fill_format.picture.image = image

    # 指定影像相對於形狀邊界框各邊緣的偏移。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose 提供免費的轉換器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——可讓您快速從圖像建立簡報。
{{% /alert %}}

## **常見問題**

**如何找出 PictureFrame 支援的圖像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 的影像物件，支援點陣圖（PNG、JPEG、BMP、GIF 等）與向量圖（例如 SVG）。支援的格式清單通常與投影片及影像轉換引擎的功能相吻合。

**在 PPTX 中加入數十張大圖會如何影響檔案大小與效能？**

嵌入大型圖像會增加檔案大小與記憶體使用量；以連結方式加入圖像則可減少簡報大小，但需確保外部檔案仍可存取。Aspose.Slides 提供通過連結加入圖像的功能，以降低檔案大小。

**如何防止意外移動/調整圖像物件？**

可對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/picture_frame_lock/) （例如，停用移動或調整大小）。鎖定機制在針對形狀的獨立 [保護文章](/slides/zh-hant/python-net/applying-protection-to-presentation/) 中說明，並支援包括 [PictureFrame] 在內的多種形狀類型。

**將簡報匯出為 PDF/圖像時，SVG 向量保真度是否得以保留？**

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 中提取 SVG 作為原始向量。當[匯出為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)或[點陣格式](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 時，結果可能會根據匯出設定而被光柵化；而原始 SVG 以向量形式儲存的事實則可由提取行為證實。