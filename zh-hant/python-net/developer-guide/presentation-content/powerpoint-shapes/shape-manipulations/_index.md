---
title: 使用 Python 管理簡報中的形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/python-net/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 尋找形狀
- 複製形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 Interop 形狀 ID
- 形狀替代文字
- 形狀版面格式
- 形狀為 SVG
- 形狀轉 SVG
- 對齊形狀
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習在 Aspose.Slides for Python via .NET 中建立、編輯與最佳化形狀，並交付高效能的 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

本指南介紹如何在 Aspose.Slides for Python via .NET 中操作形狀。學習實務模式，包括依替代文字尋找形狀、複製、刪除或隱藏、重新排序、對齊與翻轉、讀取 ID 與版面配置驅動的格式化，以及使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 和 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) API 將單一形狀匯出為 SVG。

## **在投影片上尋找形狀**

PowerPoint 僅透過內部 ID 辨識形狀。請在 PowerPoint 中為目標形狀指定唯一的替代文字，然後使用 Aspose.Slides for Python 開啟簡報，遍歷投影片的形狀集合，選取替代文字相符的形狀。`find_shape` 方法即實作此作法，並回傳符合的形狀。

```py
import aspose.slides as slides

# 依替代文字在投影片上尋找形狀。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 尋找替代文字為 "Shape1" 的形狀。
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **複製形狀**

若要在 Aspose.Slides 中將形狀從來源投影片複製到新投影片，請依照下列步驟：

1. 從來源檔案建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)。
1. 依索引取得來源投影片及其形狀集合。
1. 從母片取得一個空白版面配置。
1. 使用該版面配置新增空白投影片，並取得其形狀集合。
1. 將形狀複製到目標投影片。
1. 將簡報另存為 PPTX。

以下程式碼範例示範如何將形狀從一張投影片複製到另一張。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # 將簡報儲存到磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **移除形狀**

Aspose.Slides 允許您從投影片中移除任何形狀。例如，若要依替代文字刪除第一張投影片上的形狀，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例並載入檔案。
1. 從投影片集合中存取第一張投影片。
1. 依替代文字值尋找形狀。
1. 從投影片的形狀集合中移除該形狀。
1. 以 PPTX 格式將簡報儲存至磁碟。

```py
import aspose.slides as slides

# 依替代文字在投影片上尋找形狀。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 尋找 Alt Text 為「User Defined」的形狀。
    shape = find_shape(slide, "User Defined")
    # 移除該形狀。
    slide.shapes.remove(shape)
    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **隱藏形狀**

Aspose.Slides 允許您隱藏投影片上的任何形狀。例如，若要依替代文字隱藏第一張投影片上的形狀，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例並載入檔案。
1. 從投影片集合中存取第一張投影片。
1. 依替代文字值尋找形狀。
1. 隱藏該形狀。
1. 以 PPTX 格式將簡報儲存至磁碟。

```py
# 依替代文字在投影片上尋找形狀。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 尋找 Alt Text 為 "User Defined" 的形狀。
    shape = find_shape(slide, "User Defined")
    # 隱藏該形狀。
    shape.hidden = True
    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **變更形狀的順序**

Aspose.Slides 允許開發人員重新排序形狀（變更 Z 順序）。重新排序決定哪個形狀位於前方或後方。例如，要在第一張投影片上重新排序兩個形狀，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 存取第一張投影片。
1. 新增第一個形狀（例如矩形）。
1. 新增第二個形狀（例如三角形）。
1. 透過將第二個形狀移至集合的第一個位置來重新排序形狀。
1. 將簡報儲存至磁碟。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 在投影片上新增兩個形狀。
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # 將第二個形狀移至第一個位置。
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **取得 Interop Shape ID**

Aspose.Slides 讓您取得形狀在投影片範圍內的唯一識別碼，與 `unique_id`（全簡報唯一）不同。`office_interop_shape_id` 屬性位於 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別上，其值對應到 `Microsoft.Office.Interop.PowerPoint.Shape` 物件的 `Id`。以下示範程式碼說明如何取得該屬性。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 取得形狀在投影片內的唯一識別碼。
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **設定形狀的替代文字**

Aspose.Slides 允許開發人員為任何形狀設定替代文字。您可以使用替代文字來辨識與定位簡報中的形狀。此屬性可透過 Aspose.Slides 或 Microsoft PowerPoint 讀寫。透過標記形狀的此屬性，之後即可在投影片上刪除、隱藏或重新排序它們。

設定形狀的替代文字，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 存取第一張投影片。
1. 為投影片新增一個形狀。
1. 設定替代文字。
1. 將簡報儲存至磁碟。

```py
import aspose.slides as slides

# 建立代表 PPTX 檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # 新增形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # 設定形狀的替代文字。
    shape.alternative_text = "User Defined"
    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **存取形狀的版面格式**

Aspose.Slides 提供簡易的 API 以存取形狀的版面格式。本節說明如何存取版面格式。

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **將形狀渲染為 SVG**

Aspose.Slides 支援將形狀渲染為 SVG。[Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別的 `write_as_svg` 方法（以及其多載）允許您將形狀內容儲存為 SVG 圖像。以下程式碼片段示範如何將形狀匯出為 SVG 檔案。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # 取得第一張投影片上的第一個形狀。
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **對齊形狀**

使用 [SlidesUtil](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/) 類別的 `align_shape` 方法，您可以：

* 依投影片邊距對齊形狀（參見範例 1）。
* 依形狀彼此對齊（參見範例 2）。

[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapesalignmenttype/) 列舉定義了可用的對齊選項。

**範例 1**

以下 Python 程式碼示範如何將索引為 1、2、4 的形狀對齊至投影片的上緣：

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**範例 2**

此 Python 範例示範如何將集合中所有形狀相對於該集合中最底部的形狀進行對齊：

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **翻轉屬性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapeframe/) 類別透過 `flip_h` 與 `flip_v` 屬性提供水平與垂直鏡射控制。兩個屬性皆為 [NullableBool](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/nullablebool/) 型別，可接受 `TRUE`（翻轉）、`FALSE`（不翻轉）或 `NOT_DEFINED`（使用預設行為）。這些值可從形狀的 [Frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/frame/) 取得。

若要修改翻轉設定，會以形狀目前的位置與大小、希望的 `flip_h` 與 `flip_v` 值以及旋轉角度建立新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapeframe/) 實例。將此實例指派給形狀的 [Frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/frame/)，並儲存簡報，即可應用鏡射變換並寫入輸出檔案。

假設我們有一個 sample.pptx 檔案，第一張投影片包含一個預設翻轉設定的單一形狀，如下所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下程式碼範例取得形狀目前的翻轉屬性，並同時水平與垂直翻轉它。

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # 取得形狀的水平翻轉屬性。
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # 取得形狀的垂直翻轉屬性。
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # 同時水平與垂直翻轉。
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The flipped shape](flipped_shape.png)

## **常見問題**

**我可以在投影片上像桌面編輯器那樣合併形狀（聯集/交集/相減）嗎？**

目前沒有內建的布林運算 API。您可以自行建立所需的輪廓，例如使用 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 計算結果幾何，然後以該輪廓建立新形狀，並選擇性地移除原始形狀。

**如何控制堆疊順序（Z 順序），使形狀永遠保持在最上層？**

變更投影片 [shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/shapes/) 集合中的插入/移動順序。為確保預期結果，請在完成所有其他投影片修改後再最終設定 Z 順序。

**我可以「鎖定」形狀，以防止使用者在 PowerPoint 中編輯它嗎？**

可以。設定 [shape-level protection flags](/slides/zh-hant/python-net/applying-protection-to-presentation/)（例如鎖定選取、移動、調整大小、文字編輯）。必要時在母片或版面上鏡射限制。此為 UI 級別的保護，非安全功能；若需更強的保護，請結合檔案層級的限制，例如 [唯讀建議或密碼](/slides/zh-hant/python-net/password-protected-presentation/)。