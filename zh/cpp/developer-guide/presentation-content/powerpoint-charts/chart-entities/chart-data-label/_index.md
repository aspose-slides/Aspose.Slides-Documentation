---
title: 在演示文稿中使用 C++ 管理图表数据标签
linktitle: 数据标签
type: docs
url: /zh/cpp/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 PowerPoint 演示文稿中使用 Aspose.Slides for C++ 添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **介绍**

图表上的数据标签显示有关图表数据系列或单个数据点的详细信息。它们使读者能够快速识别数据系列，并使图表更易于理解。

## **在图表数据标签中设置数据精度**

下面的 C++ 代码演示了如何在图表数据标签中设置数据精度：

```c++
	// 文档目录的路径
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// 实例化表示 PPTX 文件的 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 获取第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 添加带默认数据的图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 设置系列数字格式
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **将百分比显示为标签**
Aspose.Slides for C++ 允许在展示的图表上设置百分比标签。下面的 C++ 代码演示了此操作：

```c++
	// 文档目录的路径
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// 创建 Presentation 类的实例
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
下面的 C++ 代码演示了如何为图表数据标签设置百分号：

```c++
	// 文档目录的路径。
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// 创建 Presentation 类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 通过索引获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在幻灯片上创建 PercentsStackedColumn 图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// 将 NumberFormatLinkedToSource 设置为 false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// 设置图表数据工作表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 删除默认生成的系列 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 添加新的系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 获取第一条图表系列
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// 填充系列数据
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 设置系列的填充颜色
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// 设置 LabelFormat 属性
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 获取第二条图表系列
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// 填充系列数据
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 设置系列的填充颜色
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// 设置 LabelFormat 属性
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


## **设置标签与坐标轴的距离**
下面的 C++ 代码演示了在处理从坐标轴绘制的图表时，如何设置标签与类别坐标轴的距离：

```c++
	// 文档目录的路径
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// 创建 Presentation 类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在幻灯片上创建图表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 获取图表系列集合
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 设置标签距离坐标轴的距离
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// 将演示文稿文件写入磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **调整标签位置**

当创建不依赖坐标轴的图表（例如饼图）时，图表的数据标签可能会过于靠近边缘。在这种情况下，需要调整数据标签的位置，以便清晰显示指示线。

下面的 C++ 代码演示了如何在饼图上调整标签位置：

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

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表中数据标签重叠？**

结合自动标签布局、指示线和减小字体大小；必要时隐藏某些字段（例如类别），或仅对极端/关键点显示标签。

**如何仅对零、负数或空值禁用标签？**

在启用标签之前过滤数据点，并根据定义的规则关闭对值为0、负数或缺失值的显示。

**如何在导出为 PDF/图像时确保标签样式一致？**

显式设置字体（系列、大小），并确认渲染端已安装该字体，以避免回退。