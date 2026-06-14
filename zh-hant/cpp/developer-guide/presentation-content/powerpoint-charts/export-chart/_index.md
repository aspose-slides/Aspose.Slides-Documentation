---
title: 在 C++ 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/cpp/export-chart/
keywords:
- 圖表
- 圖表轉為影像
- 圖表作為影像
- 擷取圖表影像
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程自動化整合至任何工作流程。"
---
## **概覽**

Aspose.Slides 允許您將簡報中的圖表匯出為影像。本文示範如何取得圖表的影像並將其儲存，這在需要在 PowerPoint 簡報之外重複使用圖表視覺時非常有用。

## **取得圖表影像**
Aspose.Slides for C++ 提供擷取特定圖表影像的支援。以下示範範例說明如何操作。

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

**我可以將圖表匯出為向量 (SVG) 而不是點陣圖嗎？**

可以。圖表是一個形狀，其內容可以使用[形狀轉 SVG 儲存方法](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)儲存為 SVG。

**如何在匯出圖表時設定精確的像素尺寸？**

使用允許指定尺寸或比例的影像渲染覆載函式—函式庫支援以給定的尺寸/比例渲染物件。

**匯出後標籤與圖例的字型顯示異常，我該怎麼辦？**

[載入所需字型](/slides/zh-hant/cpp/custom-font/)，並透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/)載入，這樣圖表渲染時即可保留字型度量與文字外觀。

**匯出是否遵守 PowerPoint 主題、樣式與效果？**

會。Aspose.Slides 的渲染器遵循簡報的格式設定（主題、樣式、填色、效果），因此圖表的外觀會被保留。

**我可以在哪裡找到圖表影像以外的其他渲染/匯出功能？**

請參閱[API](/slides/zh-hant/cpp/convert-powerpoint/)與[文件](/slides/zh-hant/cpp/convert-powerpoint/)的匯出章節，了解可輸出的目標（[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)等）以及相關的渲染選項。