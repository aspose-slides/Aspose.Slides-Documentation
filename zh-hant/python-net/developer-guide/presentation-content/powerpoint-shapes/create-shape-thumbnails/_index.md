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
- 視覺邊界
- 形狀邊界
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 從 PowerPoint 和 OpenDocument 投影片產生高品質的形狀縮圖 – 輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Python via .NET 用於建立每頁為投影片的簡報檔案。您可以透過開啟簡報檔案於 Microsoft PowerPoint 來檢視這些投影片。然而，開發人員有時需要在圖像檢視器中單獨檢視形狀的圖像。在此情況下，Aspose.Slides 可為投影片形狀產生縮圖影像。本文說明如何使用此功能。

## **從投影片產生形狀縮圖**

當您需要特定物件的預覽而不是整張投影片時，您可以為單一形狀渲染縮圖。Aspose.Slides 允許您將任意形狀匯出為影像，便於建立輕量級的預覽、圖示或供後續處理使用的資產。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片的參考。
1. 取得該投影片上形狀的參考。
1. 渲染該形狀的縮圖影像。
1. 以所需的格式儲存縮圖影像。

以下範例會產生形狀縮圖。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 建立帶有預設比例的影像。
    with shape.get_image() as thumbnail:
        # 將影像以 PNG 格式存儲到磁碟。
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **使用自訂比例因子產生縮圖**

本節說明如何在 Aspose.Slides 中使用使用者自訂的比例因子產生形狀縮圖。透過控制比例，您可微調縮圖尺寸，以符合預覽、匯出或高 DPI 顯示器的需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片的參考。
1. 取得該投影片上形狀的參考。
1. 以指定的比例渲染該形狀的縮圖影像。
1. 以所需的格式儲存縮圖影像。

以下範例會產生具有使用者自訂比例因子的縮圖。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 使用定義的比例建立影像。
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # 將影像以 PNG 格式存儲到磁碟。
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **使用形狀外觀邊界產生縮圖**

本節說明如何在形狀的外觀邊界內產生縮圖。它會考慮所有形狀效果。產生的縮圖會受投影片邊界限制。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片的參考。
1. 取得該投影片上形狀的參考。
1. 以指定的邊界渲染該形狀的縮圖影像。
1. 以所需的影像格式儲存縮圖影像。

以下範例會使用使用者自訂的邊界建立縮圖。

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 建立外觀邊界形狀影像。
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 將影像以 PNG 格式存儲到磁碟。
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **取得形狀的實際可視邊界**

[Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 的框架屬性——`Shape.x`、`Shape.y`、`Shape.width` 與 `Shape.height`——描述儲存在簡報模型中的矩形。實際呈現的內容可能會超出該框架或佔據不同的軸對齊矩形。旋轉、輪廓、箭頭、文字版面配置與溢位、產生的 SmartArt 幾何形狀以及其他渲染效果皆可能改變佔用區域。

使用 [Shape.get_visual_bounds](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_visual_bounds/) 可在不建立影像的情況下計算該佔用區域。此方法回傳投影片座標系中的浮點數矩形。返回的矩形不會被裁切至投影片範圍，若內容超出投影片原點，其座標可能為負值。

以下範例取得並比較框架與可視邊界：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

相同的矩形可用於將鄰近形狀對齊至其 `left`、`right`、`top` 或 `bottom` 邊緣；在產生的版面配置中保留足夠空間；或偵測超出允許區域的內容。可視邊界對於 SmartArt、文字方塊、箭頭、圖片、旋轉形狀與群組形狀特別有用，因為儲存的框架可能無法完整呈現實際的渲染結果。

當您需要版面配置或驗證的座標且不需要位圖時，請使用 [Shape.get_visual_bounds](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_visual_bounds/)。若需要渲染形狀，則使用 [Shape.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapethumbnailbounds/) 時，`ShapeThumbnailBounds.SHAPE` 會根據形狀邊界（包括輪廓設定）調整影像大小，而 `ShapeThumbnailBounds.APPEARANCE` 則根據形狀的外觀調整大小，並將結果限制在投影片邊界內。相較之下，`Shape.get_visual_bounds` 僅返回計算出的矩形，且不會裁切至投影片。

## **常見問題**

**保存形狀縮圖時可以使用哪些影像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/) 等等。形狀也可以透過將其內容儲存為 SVG 來 [匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/)。

**在渲染縮圖時，SHAPE 與 APPEARANCE 邊界有何差異？**

`SHAPE` 使用形狀的幾何形狀；`APPEARANCE` 會考慮 [視覺效果](/slides/zh-hant/python-net/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會渲染成縮圖嗎？**

隱藏的形狀仍屬於模型的一部份且可以被渲染；隱藏旗標僅影響投影片放映的顯示，並不會阻止產生形狀的影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/) 與 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/)）均可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會的。您應該 [提供所需的字型](/slides/zh-hant/python-net/custom-font/)（或 [設定字型替代](/slides/zh-hant/python-net/font-substitution/)），以避免不必要的備援字型與文字重新換行。