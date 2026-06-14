---
title: 在 C++ 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/cpp/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 將 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖像。它展示了如何載入 PPT、PPTX 和 ODP 等格式的簡報檔案、將投影片渲染為圖像，並將結果儲存為 PNG 格式。

本文亦示範如何透過設定比例值或指定所需的寬度與高度，來自訂產生的 PNG 圖像。

## **將 PowerPoint 轉換為 PNG**

依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 從 [Presentation::get_Slides()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合中取得屬於 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide) 介面的投影片物件。 
3. 使用 [ISlide::GetImage()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage) 方法取得每張投影片的縮圖。 
4. 使用 [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) 方法將投影片縮圖儲存為 PNG 格式。 

以下 C++ 程式碼示範如何將 PowerPoint 簡報轉換為 PNG：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

如果您想取得以特定比例的 PNG 檔案，可以設定 `desiredX` 與 `desiredY` 的值，這兩個參數決定最終縮圖的尺寸。 

以下 C++ 程式碼示範上述操作：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

如果您想取得特定大小的 PNG 檔案，可以為 `ImageSize` 傳入您偏好的 `width` 和 `height` 參數。 

以下程式碼示範如何在指定圖像大小的情況下，將 PowerPoint 轉換為 PNG：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **常見問題**

**如何僅匯出特定形狀（例如圖表或圖片），而不是整張投影片？**

Aspose.Slides 支援 [為單一形狀產生縮圖](/slides/zh-hant/cpp/create-shape-thumbnails/)，您可以將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

可以，但請勿在多執行緒間共用同一個簡報實例，請於每個執行緒或程序使用獨立的實例。

**匯出 PNG 時，試用版有哪些限制？**

試用模式會在輸出圖像上加上浮水印，並在授權之前套用 [其他限制](/slides/zh-hant/cpp/licensing/)。