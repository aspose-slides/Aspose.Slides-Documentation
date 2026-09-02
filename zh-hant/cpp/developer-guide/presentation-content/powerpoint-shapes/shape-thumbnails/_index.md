---
title: 在 C++ 中建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/cpp/shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 渲染形狀
- 形狀渲染
- 視覺範圍
- 形狀範圍
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 從 PowerPoint 投影片產生高品質的形狀縮圖——輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立以投影片為單位的簡報檔案，這些投影片可透過 Microsoft PowerPoint 開啟檢視。但有時開發人員可能需要在影像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides 可協助您產生投影片形狀的縮圖圖像。本文說明如何使用此功能。

本文說明了以不同方式產生投影片縮圖的做法：

- 產生投影片內部的形狀縮圖。  
- 為投影片形狀產生具使用者自訂尺寸的縮圖。  
- 依據形狀外觀的範圍產生縮圖。

## **從投影片產生形狀縮圖**
要使用 Aspose.Slides for C++ 從任意投影片產生形狀縮圖：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
2. 以 ID 或索引取得任意投影片的參考。  
3. 以預設比例取得參考投影片的形狀縮圖影像。  
4. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範產生形狀縮圖。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **產生使用者自訂縮放係數的縮圖**
要使用 Aspose.Slides for C++ 為任意投影片形狀產生縮圖：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
2. 以 ID 或索引取得任意投影片的參考。  
3. 以形狀範圍取得參考投影片的縮圖影像。  
4. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範以使用者自訂縮放係數產生縮圖。

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // 沿 X 與 Y 軸的縮放.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **建立基於範圍的形狀外觀縮圖**
此方法允許開發人員在形狀外觀的範圍內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖受投影片範圍限制。若要在形狀外觀的範圍內產生任意投影片形狀的縮圖，請使用以下範例程式碼：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
2. 以 ID 或索引取得任意投影片的參考。  
3. 以形狀外觀的範圍取得參考投影片的縮圖影像。  
4. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範以使用者自訂縮放係數產生縮圖。

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // 沿 X 與 Y 軸的縮放.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **取得形狀的實際視覺範圍**

[IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 的框架屬性—`IShape::get_X()`、`IShape::get_Y()`、`IShape::get_Width()` 與 `IShape::get_Height()`—描述儲存在簡報模型中的矩形。實際渲染的內容可能會超出該框架或佔用不同的軸對齊矩形。旋轉、輪廓、箭頭、文字版面配置與溢位、產生的 SmartArt 幾何圖形以及其他渲染效果皆可能改變佔用區域。

使用 [Shape::GetVisualBounds](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getvisualbounds/) 可在不建立影像的情況下計算該佔用區域。此方法回傳以投影片座標表示的 [RectangleF](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/rectanglef/)。回傳的矩形不會被裁剪至投影片範圍內，因此當內容超出投影片原點時，其座標可能為負值。

目前 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面尚未宣告 [Shape::GetVisualBounds](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getvisualbounds/)。因此，請將從投影片形狀集合取得的形狀保留為介面型別，並在呼叫該方法時才進行型別轉換。

以下範例取得並比較框架與視覺範圍：

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

相同的 [RectangleF](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/rectanglef/) 可用於對齊相鄰形狀的 `RectangleF::get_Left()`、`RectangleF::get_Right()`、`RectangleF::get_Top()` 或 `RectangleF::get_Bottom()` 邊緣；在產生的版面配置中留出足夠空間；或偵測內容是否超出允許的區域。視覺範圍在 SmartArt、文字方塊、箭頭、圖片、旋轉形狀與群組形狀中特別有用，因為儲存的框架可能無法完整代表最終渲染結果。

當您只需要版面配置或驗證的座標且不需要位圖時，請使用 [Shape::GetVisualBounds](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getvisualbounds/)。若需要渲染形狀，則使用 [IShape::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getimage/)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapethumbnailbounds/) 時，`ShapeThumbnailBounds::Shape` 會根據形狀範圍（包括輪廓設定）調整影像大小，而 `ShapeThumbnailBounds::Appearance` 則以形狀的外觀為基礎，並將結果限制在投影片範圍內。相較之下，[Shape::GetVisualBounds](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getvisualbounds/) 只回傳計算出的矩形且不會裁剪至投影片。

## **FAQ**

**儲存形狀縮圖時可以使用哪些影像格式？**  
[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/)，以及其他格式皆可使用。形狀也可透過將內容以 SVG 儲存為向量格式來 [匯出為 SVG](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 範圍有何差異？**  
`Shape` 使用形狀的幾何資訊；`Appearance` 會考慮 [視覺效果](/slides/zh-hant/cpp/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會仍然產生縮圖嗎？**  
隱藏的形狀仍屬於模型的一部份，仍可被渲染；隱藏旗標僅影響簡報播放時的顯示，並不會阻止產生形狀影像。

**是否支援群組形狀、圖表、SmartArt 與其他複雜物件？**  
支援。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/)、以及 [SmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**  
會。您應該 [提供必要的字型](/slides/zh-hant/cpp/custom-font/)（或 [設定字型替代](/slides/zh-hant/cpp/font-substitution/)），以避免不期望的回退與文字重排。