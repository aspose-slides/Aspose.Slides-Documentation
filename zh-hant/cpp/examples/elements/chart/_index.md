---
title: 圖表
type: docs
weight: 60
url: /zh-hant/cpp/examples/elements/chart/
keywords:
- 程式碼範例
- 圖表
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 精通圖表：建立、格式化、繫結資料，並以 C++ 範例將圖表匯出為 PPT、PPTX 和 ODP。"
---
以下示例說明如何使用 **Aspose.Slides for C++** 新增、存取、移除和更新不同類型的圖表。下列程式碼片段展示了基本的圖表操作。

## **新增圖表**

此方法會在第一張投影片中新增一個簡單的面積圖表。

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 在第一張投影片加入一個簡單的面積圖表。
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **存取圖表**

建立圖表後，您可以透過形狀集合取得它。

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // 存取投影片上的第一個圖表。
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **移除圖表**

以下程式碼會從投影片中移除圖表。

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // 移除圖表。
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **更新圖表資料**

您可以變更圖表屬性，例如標題。

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // 更改圖表標題。
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```