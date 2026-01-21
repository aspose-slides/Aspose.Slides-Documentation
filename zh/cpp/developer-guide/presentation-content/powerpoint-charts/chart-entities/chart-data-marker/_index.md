---
title: 在演示文稿中使用 C++ 管理图表数据标记
linktitle: 数据标记
type: docs
url: /zh/cpp/chart-data-marker/
keywords:
- 图表
- 数据点
- 标记
- 标记选项
- 标记大小
- 填充类型
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中自定义图表数据标记，通过清晰的 C++ 示例代码提升 PPT 和 PPTX 格式演示文稿的效果。"
---

## **设置图表标记**
Aspose.Slides for C++ 提供了简单的 API，可自动设置图表系列标记。在以下功能中，每个图表系列将自动获得不同的默认标记符号。

下面的代码示例展示了如何自动设置图表系列标记。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新的数据点。
- 将演示文稿写入磁盘。

以下示例中，我们在数据点级别设置了图表标记选项。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **在系列数据点级别设置图表标记**
现在，可以在特定系列的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新的数据点。
- 将演示文稿写入磁盘。

以下示例中，我们在数据点级别设置了图表标记选项。
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//实例化表示 PPTX 文件的 Presentation 类
//访问第一张幻灯片
// 添加带默认数据的图表
// 设置图表数据表的索引
// 获取图表数据工作表
// 删除默认生成的系列和类别
// 现在，添加新系列
// 获取图片
// 将图片添加到演示文稿的图像集合
// 在此处添加新点 (1:3)。

// Add chart with default data
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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


## **为数据点应用颜色**
您可以使用 Aspose.Slides for C++ 为图表中的数据点应用颜色。已添加 [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) 和 **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)** 类，以访问数据点级别的属性。本文示例演示了如何访问并为图表中的数据点应用颜色。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **常见问题**
**默认提供哪些标记形状？**

提供标准形状（圆形、方形、菱形、三角形等）；列表由 [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) 枚举定义。如需非标准形状，可使用带图片填充的标记来模拟自定义视觉效果。

**导出图表为图像或 SVG 时标记会被保留吗？**

会。将图表渲染为 [栅格格式](/slides/zh/cpp/convert-powerpoint-to-png/) 或保存为 [SVG 形状](/slides/zh/cpp/render-a-slide-as-an-svg-image/) 时，标记会保留其外观和设置，包括大小、填充和轮廓。