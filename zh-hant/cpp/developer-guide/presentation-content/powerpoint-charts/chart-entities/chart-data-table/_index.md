---
title: 使用 С++ 在簡報中自訂圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/cpp/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "使用 С++ 針對 PPT 與 PPTX 透過 Aspose.Slides 自訂圖表資料表，以提升簡報的效率與吸引力。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式與字型高度）來自訂文字格式。範例示範了載入簡報、加入圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

## **設定圖表資料表的字型屬性**
Aspose.Slides for C++ 允許變更圖表資料表的字型屬性。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供示範範例。  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **常見問題**

**我可以在圖表資料表的數值旁顯示小的圖例鍵嗎？**

是的。資料表支援 [legend keys](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/datatable/set_showlegendkey/)，您可以開啟或關閉它們。

**將簡報匯出為 PDF、HTML 或圖片時，資料表會被保留嗎？**

是的。Aspose.Slides 將圖表渲染為投影片的一部分，因此匯出的 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)/[image](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 會包含帶有資料表的圖表。

**來自範本檔案的圖表是否支援資料表？**

是的。對於從現有簡報或範本載入的任何圖表，您可以使用圖表的屬性檢查並變更資料表是否[是否顯示](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/set_hasdatatable/)。

**如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性以判斷資料表是否[是否顯示](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/get_hasdatatable/)，並遍歷投影片以辨識已啟用資料表的圖表。