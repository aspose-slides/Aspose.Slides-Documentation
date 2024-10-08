---
title: 图表数据标记
type: docs
url: /cpp/chart-data-marker/
---

## **设置图表标记**
Aspose.Slides for C++ 提供了一个简单的 API 来自动设置图表系列标记。在以下功能中，每个图表系列会自动获得不同的默认标记符号。

下面的代码示例展示了如何自动设置图表系列标记。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **设置图表标记选项**
可以在特定系列内的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤进行：

- 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
- 创建默认图表。
- 设置图片。
- 取第一个图表系列。
- 添加一个新的数据点。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们在数据点级别上设置了图表标记选项。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **在系列数据点级别设置图表标记**
现在，可以在特定系列内的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤进行：

- 实例化 Presentation 类。
- 创建默认图表。
- 设置图片。
- 取第一个图表系列。
- 添加一个新的数据点。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们在数据点级别上设置了图表标记选项。

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//实例化表示 PPTX 文件的 Presentation 类
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//访问第一个幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 添加具有默认数据的图表
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// 设置图表数据工作表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// 删除默认生成的系列和类别
chart->get_ChartData()->get_Series()->Clear();

// 现在，添加一个新的系列
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"系列 1")), chart->get_Type());

// 获取图片
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// 将图片添加到演示文稿的图片集合中
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// 添加新的点 (1:3)。
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

// 更改图表系列标记
series->get_Marker()->set_Size(15);

// 将演示文稿文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **对数据点应用颜色**
您可以使用 Aspose.Slides for C++ 对图表中的数据点应用颜色。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 和 **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** 类已被添加以访问数据点级别的属性。本文演示了如何访问并对图表中的数据点应用颜色。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}