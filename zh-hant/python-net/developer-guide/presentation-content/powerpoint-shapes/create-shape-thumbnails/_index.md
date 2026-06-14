---
title: 在 Python 中建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/python-net/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 渲染形狀
- 形狀渲染
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 從 PowerPoint 和 OpenDocument 投影片產生高品質的形狀縮圖——輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Python via .NET 用於建立每個頁面都是投影片的簡報檔。您可以透過開啟簡報檔在 Microsoft PowerPoint 中檢視這些投影片。然而，開發人員有時需要在影像檢視器中單獨檢視形狀的圖片。在此情況下，Aspose.Slides 能產生投影片形狀的縮圖。本篇說明如何使用此功能。

## **從投影片產生形狀縮圖**

當您需要特定物件的預覽而非整張投影片時，可以為單一形狀渲染縮圖。Aspose.Slides 讓您將任何形狀匯出為影像，輕鬆建立輕量預覽、圖示或後續處理的資產。

要從任意形狀產生縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得投影片的參照。
1. 取得該投影片上形狀的參照。
1. 將形狀的縮圖圖像渲染出來。
1. 以所需格式儲存縮圖圖像。

以下範例產生形狀縮圖。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用預設比例建立影像。
    with shape.get_image() as thumbnail:
        # 將影像以 PNG 格式儲存到磁碟。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **使用自訂縮放因子產生縮圖**

本節說明如何在 Aspose.Slides 中使用使用者自訂的縮放因子產生形狀縮圖。透過控制縮放比例，您可以微調縮圖大小，以符合預覽、匯出或高 DPI 顯示需求。

要為投影片上任意形狀產生縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得投影片。
1. 取得該投影片上的目標形狀。
1. 使用指定的縮放比例渲染形狀的縮圖圖像。
1. 以所需格式儲存縮圖圖像。

以下範例產生具有使用者自訂縮放因子的縮圖。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# 實例化 Presentation 類別以開啟簡報檔。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用已定義的比例建立影像。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # 將影像以 PNG 格式儲存到磁碟。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **使用形狀外觀範圍產生縮圖**

本節說明如何在形狀的外觀範圍內產生縮圖，會考慮所有形狀效果。產生的縮圖受投影片邊界限制。

要在形狀的外觀範圍內產生任意投影片形狀的縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得投影片。
1. 取得該投影片上的目標形狀。
1. 使用指定的範圍渲染形狀的縮圖圖像。
1. 以所需的影像格式儲存縮圖圖像。

以下範例建立具有使用者自訂範圍的縮圖。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 實例化 Presentation 類別以開啟簡報檔。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 建立外觀範圍的形狀影像。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 將影像以 PNG 格式儲存到磁碟。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **常見問題**

**可以使用哪些影像格式來儲存形狀縮圖？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/)。

**在渲染縮圖時，SHAPE 與 APPEARANCE 範圍有何差異？**

`SHAPE` 使用形狀的幾何結構；`APPEARANCE` 會考慮[視覺效果](/slides/zh-hant/python-net/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏會怎樣？它仍會被渲染成縮圖嗎？**

隱藏的形狀仍是模型的一部份，仍可被渲染；隱藏旗標只影響簡報播放時的顯示，不會阻止產生形狀的圖像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以[Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)、以及[SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需字型](/slides/zh-hant/python-net/custom-font/)（或[設定字型替代](/slides/zh-hant/python-net/font-substitution/)）以避免意外的回退與文字重排。