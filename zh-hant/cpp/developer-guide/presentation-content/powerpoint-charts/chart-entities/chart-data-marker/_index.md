---
title: 使用 C++ 在簡報中管理圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/cpp/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中自訂圖表資料標記，透過清晰的 C++ 程式碼範例提升 PPT 和 PPTX 簡報的效果。"
---
## **概觀**

本文說明了如何在 Aspose.Slides 中使用圖表資料標記。它展示了如何建立圖表、存取系列及其資料點、在資料點層級為標記套用圖片填充、調整標記大小，以及儲存更新後的簡報。本文亦指出，可透過 `MarkerStyleType` 列舉取得標準標記形狀，且在將圖表匯出為光柵格式或 SVG 時，標記外觀會被保留。

## **設定圖表標記**
Aspose.Slides for C++ 提供簡易的 API 自動設定圖表系列的標記。以下範例中，每個圖表系列會自動取得不同的預設標記符號。

以下程式碼範例示範如何自動設定圖表系列的標記。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **設定圖表標記選項**
可以在特定系列的圖表資料點上設定標記。請依照以下步驟設定圖表標記選項：

- 實例化[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 寫入簡報至磁碟。

在下方的範例中，我們在資料點層級設定了圖表標記選項。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **在系列資料點層級設定圖表標記**
現在，可以在特定系列的圖表資料點上設定標記。請依照以下步驟設定圖表標記選項：

- 實例化 Presentation 類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 寫入簡報至磁碟。

在下方的範例中，我們在資料點層級設定了圖表標記選項。

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//實例化表示 PPTX 檔案的 Presentation 類別

//Access first slide
//存取第一張投影片

// Add chart with default data
// 加入具有預設資料的圖表

// Setting the index of chart data sheet
// 設定圖表資料工作表的索引

// Getting the chart data worksheet
// 取得圖表資料工作表

// Delete default generated series and categories
// 刪除預設產生的系列與類別

// Now, Adding a new series
// 現在，加入新系列

SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// 取得圖片
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// 將圖片加入簡報的影像集合
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // 在此新增資料點 (1:3)。
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **對資料點套用顏色**
您可以使用 Aspose.Slides for C++ 為圖表中的資料點套用顏色。已新增 **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)** 與 **[IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/)** 類別，以取得資料點層級的屬性。本文示範了如何存取並為圖表中的資料點套用顏色。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **常見問題**

**有哪些內建的標記形狀？**

標準形狀可供使用（圓形、方形、菱形、三角形等）；清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/markerstyletype/) 列舉定義。如果需要非標準形狀，可使用帶圖片填充的標記來模擬自訂視覺效果。

**匯出圖表為影像或 SVG 時，標記會保留嗎？**

是的。當將圖表渲染為[光柵格式](/slides/zh-hant/cpp/convert-powerpoint-to-png/)或儲存[形狀為 SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)時，標記會保留其外觀和設定，包括大小、填充與輪廓。