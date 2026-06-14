---
title: 使用 C++ 自訂 Treemap 與 Sunburst 圖表中的資料點
linktitle: Treemap 與 Sunburst 圖表中的資料點
type: docs
url: /zh-hant/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 管理 Treemap 與 Sunburst 圖表中的資料點，兼容 PowerPoint 格式。"
---
## **簡介**

在 PowerPoint 圖表的其他類型中，有兩種「階層」類型──**Treemap** 與 **Sunburst** 圖表（亦稱為 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。這些圖表以樹狀結構顯示階層資料，從葉節點到分支的頂部。葉節點由系列資料點定義，而每個後續的巢狀分組層級則由相應的類別定義。Aspose.Slides for C++ 允許在 C++ 中設定 Sunburst 圖表與 Treemap 的資料點。

以下是一個 Sunburst 圖表，Series1 欄位的資料定義葉節點，而其他欄位定義階層資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中新增一個 Sunburst 圖表開始：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**建立 Sunburst 圖表**](/slides/zh-hant/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

如果需要設定圖表的資料點，我們應使用以下項目：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/) 類別以及 [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 方法提供了存取 Treemap 與 Sunburst 圖表資料點格式的功能。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) 用於存取多層級類別——它代表 [**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/) 物件的容器。  
基本上它是 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) 的包裝器，加入了針對資料點的特定屬性。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/) 類別有兩個方法： [**get_Format()**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) 與 [**get_Label()**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/)，它們提供對相應設定的存取。

## **顯示資料點值**

顯示「Leaf 4」資料點的值：

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與顏色**

將「Branch 1」資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。然後將文字顏色設定為黃色：

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **設定資料點分支顏色**

變更「Stem 4」分支的顏色：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常見問題**

**我可以變更 Sunburst/Treemap 中區段的順序（排序）嗎？**

不行。PowerPoint 會自動排序區段（通常依值由大到小、順時針方向）。Aspose.Slides 會遵循相同的行為：無法直接變更順序；只能透過前置處理資料來實現。

**簡報主題如何影響區段與標籤的顏色？**

除非明確設定填色/字型，否則圖表顏色會繼承簡報的 [theme/palette](/slides/zh-hant/cpp/presentation-theme/) 。為取得一致的結果，請在所需層級鎖定實心填色與文字格式。

**匯出為 PDF/PNG 時會保留自訂的分支顏色與標籤設定嗎？**

會。匯出簡報時，圖表的設定（填色、標籤）會在輸出格式中保留，因為 Aspose.Slides 會以套用的圖表格式進行渲染。

**我可以計算標籤/元素的實際座標，以便在圖表上方自訂覆蓋物的位置嗎？**

會。圖表版面配置驗證完成後，可取得元素的實際 X 與實際 Y（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/datalabel/)），這有助於精確定位覆蓋物。