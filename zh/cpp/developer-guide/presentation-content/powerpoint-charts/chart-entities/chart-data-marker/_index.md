---
title: 使用 С++ 在演示文稿中管理图表数据标记
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
- С++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for С++ 中自定义图表数据标记，通过清晰的 С++ 代码示例提升 PPT 和 PPTX 格式演示文稿的效果。"
---

## **设置图表标记**
Aspose.Slides for C++ 提供了一个简便的 API，可自动设置图表系列的标记。在以下示例中，每个图表系列将自动获得不同的默认标记符号。

下面的代码示例展示了如何自动设置图表系列的标记。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加一个新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们在数据点级别设置了图表标记选项。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **在系列数据点级别设置图表标记**
现在，可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加一个新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们在数据点级别设置了图表标记选项。
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//实例化表示 PPTX 文件的 Presentation 类
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 添加默认数据的图表
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// 设置图表数据表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// 删除默认生成的系列和类别
chart->get_ChartData()->get_Series()->Clear();

// 现在，添加新系列
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// 获取图片
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// 将图片添加到演示文稿的图像集合
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// 在此处添加新点 (1:3)。
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
您可以使用 Aspose.Slides for C++ 为图表中的数据点应用颜色。已添加 **IChartDataPointLevelsManager** 和 **IChartDataPointLevel** 类，以获取数据点级别属性的访问权限。本文演示了如何访问并为图表中的数据点应用颜色。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**有哪些标记形状是开箱即用的？**

标准形状可用（圆形、方形、菱形、三角形等）；列表由 [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) 枚举定义。如果需要非标准形状，可使用图片填充的标记来模拟自定义视觉效果。

**在将图表导出为图像或 SVG 时，标记是否会保留？**

会保留。当将图表渲染为 [栅格格式](/slides/zh/cpp/convert-powerpoint-to-png/) 或保存为 [SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/) 时，标记会保持其外观和设置，包括大小、填充和轮廓。