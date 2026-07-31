---
title: 在 C++ 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/cpp/export-chart/
keywords:
- 圖表
- 圖表轉圖像
- 圖表作為圖像
- 擷取圖表圖像
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程簡化至任何工作流程。"
---
## **概觀**

Aspose.Slides 允許您將投影片中的圖表匯出為影像。本文示範如何從圖表取得影像並儲存，它在您需要在 PowerPoint 投影片之外重複使用圖表視覺時非常有用。

## **取得圖表影像**
Aspose.Slides for C++ 提供支援，以擷取特定圖表的影像。以下提供範例程式碼。

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **常見問題**

**我可以將圖表匯出為向量圖（SVG）而非點陣圖嗎？**

是的。圖表是一個形狀，其內容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)儲存為 SVG。

**如何設定匯出圖表的精確像素大小？**

使用可指定大小或縮放比例的影像渲染覆載方法——函式庫支援以給定的尺寸/縮放比例呈現物件。

**匯出後標籤和圖例的字型顯示不正確，我該怎麼辦？**

可透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) [載入必要的字型](/slides/zh-hant/cpp/custom-font/)，以確保圖表渲染保留字型度量與文字外觀。

**匯出是否遵循 PowerPoint 主題、樣式與效果？**

是的。Aspose.Slides 的渲染器遵循簡報的格式設定（主題、樣式、填色、效果），因此圖表的外觀得以保留。

**我在哪裡可以找到圖表影像之外的可用渲染/匯出功能？**

請參閱 [API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/)/[文件](/slides/zh-hant/cpp/convert-powerpoint/) 的匯出章節，以了解可用的輸出目標（[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)...）以及相關的渲染選項。