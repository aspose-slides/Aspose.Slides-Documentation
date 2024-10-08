---
title: 创建 C++ 中的 PowerPoint 演示文稿图表
linktitle: 创建图表
type: docs
weight: 10
url: /zh/cpp/create-chart/
keywords: "创建图表，散点图，饼图，树图，股票图，箱线图，直方图，漏斗图，旭日图，多类别图，PowerPoint 演示文稿，C++，CPP，Aspose.Slides for C++"
description: "在 C++ 中创建 PowerPoint 演示文稿图表"
---

## **创建图表**

图表帮助人们迅速可视化数据并获取可能在表格或电子表格中不明显的洞察。

**为什么要创建图表？**

使用图表，您可以

* 在演示文稿的单个幻灯片上汇总、浓缩或总结大量数据
* 显示数据中的模式和趋势
* 推断数据随时间变化的方向和动量或相对于特定测量单位的变化
* 找出异常值、偏差、错误、无意义的数据等
* 传达或展示复杂数据

在 PowerPoint 中，您可以通过插入功能创建图表，该功能提供用于设计多种类型图表的模板。使用 Aspose.Slides，您可以创建常规图表（基于流行的图表类型）和自定义图表。

{{% alert color="primary" %}} 

为了让您创建图表，Aspose.Slides 提供了 [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) 枚举类，位于 [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/) 命名空间下。这个枚举类下的值对应于不同的图表类型。

{{% /alert %}} 

### **创建常规图表**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有一些数据的图表并指定所需的图表类型。
1. 为图表添加标题。
1. 访问图表数据工作表。
1. 清除所有默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加一些新的图表数据。
1. 为图表系列添加填充颜色。
1. 为图表系列添加标签。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建常规图表：

```c++
// 文档目录的路径。
	const String outPath = u"../out/NormalCharts_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加一个带有默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 设置图表标题
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"示例标题");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// 删除默认生成的系列和类别
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// 添加新系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"系列 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"系列 2")), chart->get_Type());

	// 添加类别
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"类别 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"类别 3")));

	
	// 取第一个图表系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 填充系列数据
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// 设置系列的填充颜色
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// 取第二个图表系列
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// 填充系列数据
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// 设置系列的填充颜色
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// 第一个标签设置为显示类别名称
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);

	// 显示第三个标签的值
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue(true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator(u"/");

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **创建散点图**
散点图（也称为散点图或 x-y 图）通常用于检查模式或显示两个变量之间的相关性。

当您想使用散点图时

* 您有成对的数字数据
* 您有两个紧密配对的变量
* 您想确定两个变量是否相关
* 您有一个独立变量，对应多个依赖变量值

以下 C++ 代码向您展示如何创建具有不同系列标记的散点图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加一个带有默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// 设置图表标题
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"示例标题");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// 删除默认生成的系列 
	chart->get_ChartData()->get_Series()->Clear();
	
	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 添加新系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"系列 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"系列 2")), chart->get_Type());

	// 取第一个图表系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 添加新点 (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// 添加新点 (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// 编辑系列类型
	series->set_Type(ChartType::ScatterWithStraightLinesAndMarkers);

	// 更改图表系列标记
	series->get_Marker()->set_Size(10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// 取第二个图表系列
	series = chart->get_ChartData()->get_Series()->idx_get(1);

	// 添加新点 (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// 添加新点 (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// 添加新点 (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// 添加新点 (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// 更改图表系列标记
	series->get_Marker()->set_Size(10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// 设置扇区边框
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width(3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// 设置扇区边框
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width(3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// 设置扇区边框
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width(2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// 为新系列的每个类别创建自定义标签
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// 显示图表的引导线
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// 设置饼图扇区的旋转角度
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建饼图**
饼图最适合用来显示数据中的部分与整体的关系，尤其当数据包含带有数值的分类标签时。然而，如果您的数据包含许多部分或标签，您可能更适合使用条形图。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（在本例中为 `ChartType.Pie`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 为图表的扇区添加新点并添加自定义颜色。
1. 为系列设置标签。
1. 为系列标签设置引导线。
1. 设置饼图扇区的旋转角度。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建饼图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/PieChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加一个带有默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// 设置图表标题
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"示例标题");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// 删除默认生成的系列和类别
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 添加类别
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"第一季度")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"第二季度")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"第三季度")));

	// 添加新系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"系列 1")), chart->get_Type());
	
	// 取第一个图表系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 填充系列数据
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// 设置扇区边框
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width(3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// 设置扇区边框
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width(3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// 设置扇区边框
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width(2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// 为新系列的每个类别创建自定义标签
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// 设置图表系列显示引导线
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// 设置饼图扇区的旋转角度
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建折线图**

折线图（也称为线图）最适合用于展示随时间变化的数值。在使用折线图时，您可以同时比较大量数据，跟踪随时间变化的变化和趋势，突出数据系列中的异常值等。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（在本例中为 `ChartType::Line`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建折线图：

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

默认情况下，折线图上的点通过连续的直线连接。如果您希望点通过虚线连接，则可以这样指定您所需的虚线类型：

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **创建树图**

树图最适合用于销售数据，当您想展示数据类别的相对大小并迅速引起人们对每个类别大贡献者的注意时。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（在本例中为 `ChartType.TreeMap`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建树图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/TreemapChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 分支 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"叶子1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"分支1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"叶子2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"叶子3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"叶子4")));


	// 分支 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"叶子5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"分支2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"叶子6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"叶子7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"叶子8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建股票图**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（ChartType.OpenHighLowClose）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 指定 HiLowLines 格式。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码用于创建股票图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/AddStockChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加一个带有默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 删除默认生成的系列和类别
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// 添加类别
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// 添加新系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"开盘")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"最高")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"最低")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"收盘")), chart->get_Type());


	// 取第一个图表系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// 填充第一个系列数据
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// 填充第二个系列数据
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// 填充第三个系列数据
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// 填充第四个系列数据
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// 设置系列组
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars(true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for (int i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建箱线图**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（ChartType.BoxAndWhisker）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建箱线图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"类别 1")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));


	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建漏斗图**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（ChartType.Funnel）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建漏斗图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/FunnelChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"类别 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"类别 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"类别 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"类别 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"类别 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"类别 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建旭日图**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（在本例中为 `ChartType.sunburst`）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建旭日图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/SunburstChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 分支 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"叶子1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"分支1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"叶子2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"叶子3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"叶子4")));

	// 分支 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"叶子5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"分支2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"叶子6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"叶子7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"干4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"叶子8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **创建直方图**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一些图表数据并指定所需的图表类型（在本例中为 `ChartType.Histogram`）。
1. 访问图表数据 `IChartDataWorkbook`。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建直方图：

```c++
// 文档目录的路径。
	const String outPath = u"../out/HistogramChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建雷达图**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一些数据的图表并指定所需图表类型（在本例中是 `ChartType.Radar`）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建雷达图：

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建多类别图表**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需类型（ChartType.ClusteredColumn）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何创建多类别图表：

```c++
// 文档目录的路径。
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// 实例化一个表示 PPTX 文件的演示文稿类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加一个带有默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 清空工作簿
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// 添加类别
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"组1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"组2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"组3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"组4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// 添加新系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"系列 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **创建地图图表**

地图图表是显示包含数据的区域的可视化。地图图表最适合用于比较地理区域之间的数据或值。

以下 C++ 代码向您展示如何创建地图图表：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **创建组合图表**

组合图表（或组合图）是在单个图表中组合两种或多种图表的图表。这种图表允许您突出、比较或审查两个（或更多）数据集之间的差异。通过这种方式，您可以看到数据集之间的关系（如果有的话）。

![combination-chart-ppt](combination-chart-ppt.png)

以下 C++ 代码向您展示如何在 PowerPoint 中创建组合图表：

```c++
void CreateComboChart()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
    System::SharedPtr<IChart> chart = CreateChart(pres->get_Slide(0));
    AddFirstSeriesToChart(chart);
    AddSecondSeriesToChart(chart);
    pres->Save(u"combo-chart.pptx", SaveFormat::Pptx);
}

System::SharedPtr<IChart> CreateChart(System::SharedPtr<ISlide> slide)
{
    System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 400.0f);
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartSeriesCollection> seriesCollection = chartData->get_Series();
    System::SharedPtr<IChartCategoryCollection> categories = chartData->get_Categories();

    seriesCollection->Clear();
    categories->Clear();

    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(u"系列 1")), chart->get_Type());
    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(u"系列 2")), chart->get_Type());

    categories->Add(workbook->GetCell(worksheetIndex, 1, 0, System::ExplicitCast<System::Object>(u"类别 1")));
    categories->Add(workbook->GetCell(worksheetIndex, 2, 0, System::ExplicitCast<System::Object>(u"类别 2")));
    categories->Add(workbook->GetCell(worksheetIndex, 3, 0, System::ExplicitCast<System::Object>(u"类别 3")));

    System::SharedPtr<IChartDataPointCollection> dataPoints = chartData->get_ChartSeries(0)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, System::ExplicitCast<System::Object>(20)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, System::ExplicitCast<System::Object>(50)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, System::ExplicitCast<System::Object>(30)));

    dataPoints = chartData->get_ChartSeries(1)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, System::ExplicitCast<System::Object>(30)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, System::ExplicitCast<System::Object>(10)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, System::ExplicitCast<System::Object>(60)));

    return chart;
}

void AddFirstSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 3, System::ExplicitCast<System::Object>(u"系列 3")), ChartType::ScatterWithSmoothLines);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(3)), workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(5)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(13)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 3, System::ExplicitCast<System::Object>(20)), workbook->GetCell(worksheetIndex, 2, 4, System::ExplicitCast<System::Object>(15)));

    series->set_PlotOnSecondAxis(true);
}

void AddSecondSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 5, System::ExplicitCast<System::Object>(u"系列 4")), ChartType::ScatterWithStraightLinesAndMarkers);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(5)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(2)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 5, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 6, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 5, System::ExplicitCast<System::Object>(15)), workbook->GetCell(worksheetIndex, 2, 6, System::ExplicitCast<System::Object>(12)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 3, 5, System::ExplicitCast<System::Object>(12)), workbook->GetCell(worksheetIndex, 3, 6, System::ExplicitCast<System::Object>(9)));

    series->set_PlotOnSecondAxis(true);
}
```

## **更新图表**

1. 实例化一个表示包含图表的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据。
6. 添加新系列并填充数据。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码向您展示如何更新图表：

```c++
// 实例化一个表示 PPTX 文件的演示文稿类
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// 访问第一张幻灯片
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个带有默认数据的图表
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// 设置图表数据表的索引
int32_t defaultWorksheetIndex = 0;

// 获取图表数据工作表
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// 更改图表类别名称
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"修改的类别 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"修改的类别 2"));

// 取第一个图表系列
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// 更新系列数据
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"新系列1"));
// 修改系列名称
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// 取第二个图表系列
series = chart->get_ChartData()->get_Series()->idx_get(1);

// 现在更新系列数据
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"新系列2"));
// 修改系列名称
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// 现在，添加一个新系列
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"系列 3")), chart->get_Type());

// 取第三个图表系列
series = chart->get_ChartData()->get_Series()->idx_get(2);

// 现在填充系列数据
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// 保存带图表的演示文稿
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **设置图表的数据范围**

1. 打开包含图表的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿保存为 PPTX 文件。

以下 C