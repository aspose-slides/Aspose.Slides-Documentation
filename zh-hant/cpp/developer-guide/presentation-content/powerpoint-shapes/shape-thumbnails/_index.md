---
title: 在 C++ 中建立簡報形狀的縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/cpp/shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 渲染形狀
- 形狀渲染
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 從 PowerPoint 投影片產生高品質的形狀縮圖 ─ 輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立每頁都是投影片的簡報檔案。這些投影片可使用 Microsoft PowerPoint 開啟檢視。但有時開發人員可能需要在圖像檢視器中分別檢視形狀的圖像。此時，Aspose.Slides 可協助產生投影片形狀的縮圖。本文說明如何使用此功能。

本文解釋了以不同方式產生投影片縮圖的方法：

- 在投影片內產生形狀縮圖。
- 為投影片形狀產生具有使用者自訂尺寸的縮圖。
- 在形狀外觀的範圍內產生縮圖。

## **從投影片產生形狀縮圖**
使用 Aspose.Slides for C++ 從任意投影片產生形狀縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得任意投影片的參考。
1. 以預設比例取得參考投影片的形狀縮圖影像。
1. 將縮圖影像儲存為任意想要的影像格式。

以下範例產生形狀縮圖。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **產生使用者自訂縮放比例的縮圖**
使用 Aspose.Slides for C++ 為任意投影片形狀產生縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得任意投影片的參考。
1. 以形狀範圍取得參考投影片的縮圖影像。
1. 將縮圖影像儲存為任意想要的影像格式。

以下範例產生具有使用者自訂縮放比例的縮圖。

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // 沿 X 與 Y 軸的縮放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **建立基於範圍的形狀外觀縮圖**
此方法允許開發人員在形狀外觀的範圍內產生縮圖，並考慮所有形狀效果。產生的形狀縮圖受投影片範圍限制。要在形狀外觀的範圍內產生任意投影片形狀的縮圖，請使用以下範例程式碼：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依 ID 或索引取得任意投影片的參考。
1. 以外觀形式的形狀範圍取得參考投影片的縮圖影像。
1. 將縮圖影像儲存為任意想要的影像格式。

以下範例建立具有使用者自訂縮放比例的縮圖。

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // 沿 X 與 Y 軸的縮放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**儲存形狀縮圖時可以使用哪些影像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何資訊；`Appearance` 會考慮[視覺效果](/slides/zh-hant/cpp/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會仍然產生縮圖嗎？**

隱藏的形狀仍是模型的一部分，仍可被渲染；隱藏旗標只影響投影片播放時的顯示，不會阻止產生形狀圖像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

支援。任何以[Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/) 表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/)、以及[SmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需字型](/slides/zh-hant/cpp/custom-font/)（或[設定字型替代](/slides/zh-hant/cpp/font-substitution/)）以避免不必要的備案字型與文字重排。