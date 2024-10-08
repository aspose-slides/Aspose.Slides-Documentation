---
title: 图表数据标签
type: docs
url: /zh/cpp/chart-data-label/
keywords: "图表数据标签,标签距离,C++,CPP,Aspose.Slides for C++"
description: "在C++中设置PowerPoint图表数据标签和距离"
---

图表上的数据标签显示有关图表数据系列或单个数据点的详细信息。它们使读者能够快速识别数据系列，也使图表更容易理解。

## **设置图表数据标签中的数据精度**

以下C++代码演示了如何在图表数据标签中设置数据精度：

```c++
	// 文档目录的路径
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// 实例化一个表示PPTX文件的Presentation类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 获取第一个幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 设置系列数字格式
	chart->set_HasDataTable(true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues(u"#,##0.00");

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **将百分比显示为标签**
Aspose.Slides for C++允许您在显示的图表上设置百分比标签。以下C++代码演示了该操作：

```c++
	// 文档目录的路径
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// 创建Presentation类的实例
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);

		}

	}

	// 保存包含图表的演示文稿
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **在图表数据标签中设置百分号**
以下C++代码演示了如何为图表数据标签设置百分号：

```c++
	// 文档目录的路径。
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// 创建Presentation类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 通过索引获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在幻灯片上创建PercentsStackedColumn图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// 将NumberFormatLinkedToSource设置为false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// 设置图表数据工作表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 删除默认生成的系列 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 添加新的系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"系列 2")), chart->get_Type());


	// 获取第一个图表系列
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"红色")), chart->get_Type());
	// 填充系列数据
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 设置系列的填充颜色
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// 设置LabelFormat属性
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 获取第二个图表系列
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"蓝色")), chart->get_Type());
	// 填充系列数据
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 设置系列的填充颜色
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// 设置LabelFormat属性
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **设置标签与轴的距离**
以下C++代码演示了如何设置类别轴的标签距离：

```c++
	// 文档目录的路径
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// 创建Presentation类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在幻灯片上创建图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 获取图表系列集合
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 设置轴的标签距离
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **调整标签位置**

当您创建不依赖任何轴（例如饼图）的图表时，图表的数据标签可能会过于靠近边缘。在这种情况下，您必须调整数据标签的位置，以便引导线清晰显示。

以下C++代码演示了如何在饼图上调整标签位置：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![饼图调整后的标签](pie-chart-adjusted-label.png)