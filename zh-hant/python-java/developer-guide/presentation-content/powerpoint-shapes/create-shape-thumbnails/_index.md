---
title: 在 Python via Java 中建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/python-java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 渲染形狀
- 形狀渲染
- 視覺邊界
- 形狀邊界
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，從 PowerPoint 投影片產生高品質的形狀縮圖——輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Python via Java 可用於建立每頁對應一張投影片的簡報檔案。這些投影片可以使用 Microsoft PowerPoint 開啟檢視。但開發人員有時需要在影像檢視器中單獨檢視形狀的圖像。此時，Aspose.Slides for Python via Java 可協助產生投影片形狀的縮圖影像。

本文說明了以不同方式產生形狀縮圖的做法：

- 在投影片內產生形狀縮圖。
- 使用使用者自訂尺寸產生投影片形狀的縮圖。
- 依形狀外觀的範圍產生縮圖。

## **從投影片產生形狀縮圖**
若要使用 Aspose.Slides for Python via Java 從任意投影片產生形狀縮圖，請依照下列步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片參考。
1. 以預設比例從參考投影片上的形狀取得[shape thumbnail image](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)。
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# 實例化一個代表簡報檔案的 Presentation 類別。
presentation = Presentation("Thumbnail.pptx")
try:
    # 建立完整比例的影像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # 將影像以 PNG 格式儲存到磁碟。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **使用自訂縮放比例產生縮圖**
若要使用 Aspose.Slides for Python via Java 產生投影片形狀的縮圖，請依照下列步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片參考。
1. 以使用者自訂尺寸從參考投影片上的形狀取得[shape thumbnail image](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)。
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼示範如何依自訂縮放比例產生形狀縮圖：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 實例化一個代表簡報檔案的 Presentation 類別。
presentation = Presentation("Thumbnail.pptx")
try:
    # 建立一個在兩個方向上放大 2 倍的影像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # 將影像以 PNG 格式儲存到磁碟。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **建立基於邊界的形狀外觀縮圖**
此方法允許開發人員在形狀外觀的邊界內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖受投影片邊界限制。若要在形狀外觀的邊界內產生投影片形狀的縮圖，請依照下列步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依照 ID 或索引取得投影片參考。
1. 使用外觀邊界取得參考投影片上形狀的縮圖影像。
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼依上述步驟示範：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# 實例化一個代表簡報檔案的 Presentation 類別。
presentation = Presentation("Thumbnail.pptx")
try:
    # 建立完整比例的影像。
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # 將影像以 PNG 格式儲存到磁碟。
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **取得形狀的實際視覺邊界**

[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 的框架屬性——其 [getX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getX)、[getY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getY)、[getWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getWidth) 與 [getHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getHeight) 方法——描述儲存在簡報模型中的矩形。實際渲染的內容可能會超出該框架或佔用不同的軸對齊矩形。旋轉、輪廓、箭頭頭部、文字布局與溢位、產生的 SmartArt 幾何形狀，以及其他渲染效果，都可能改變佔用區域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getVisualBounds) 可在不建立影像的情況下計算該佔用區域。此方法傳回以投影片座標表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。傳回的矩形不會被投影片裁切，若內容超出投影片原點，其座標可能為負值。

以下範例取得並比較框架與視覺邊界：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

相同的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 可用於將相鄰形狀對齊至左、右、上或下邊緣；在產生的版面配置中保留足夠空間；或偵測內容是否超出允許的區域。視覺邊界對於 SmartArt、文字方塊、箭頭、圖片、旋轉形狀與群組形狀尤為有用，因為儲存的框架可能無法完整呈現渲染結果。

當您需要版面配置或驗證的座標且不需要點陣圖時，請使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getVisualBounds)。當您需要渲染形狀時，請使用 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapethumbnailbounds/) 時，[ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapethumbnailbounds/#Shape) 會根據形狀邊界（包括輪廓設定）調整影像大小；而 [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapethumbnailbounds/#Appearance) 則根據形狀外觀調整大小，並限制結果於投影片邊界。相較之下，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getVisualBounds) 僅傳回計算出的矩形，且不會裁切至投影片。

## **常見問題**

**儲存形狀縮圖時可以使用哪些影像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將內容另存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#writeAsSvgToBytes)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何形狀；`Appearance` 會考慮[視覺效果](/slides/zh-hant/python-java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會仍然產生縮圖嗎？**

隱藏的形狀仍是模型的一部份，可被渲染；隱藏旗標僅影響投影片播放時的顯示，不會阻止產生形狀影像。

**是否支援群組形狀、圖表、SmartArt 與其他複雜物件？**

支援。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 與 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需字型](/slides/zh-hant/python-java/custom-font/)（或[設定字型替代](/slides/zh-hant/python-java/font-substitution/)），以避免不必要的備援字型與文字重新排版。