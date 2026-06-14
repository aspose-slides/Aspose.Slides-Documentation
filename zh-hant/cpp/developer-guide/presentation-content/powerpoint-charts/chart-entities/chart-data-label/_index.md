---
title: 使用 C++ 在簡報中管理圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/cpp/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 PowerPoint 簡報中使用 Aspose.Slides for C++ 添加與格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

圖表中的資料標籤會顯示圖表資料系列或單一資料點的詳細資訊。它們讓讀者能快速辨識資料系列，並使圖表更易於理解。

## **在圖表資料標籤中設定資料精度**

以下 C++ 程式碼示範如何在圖表資料標籤中設定資料精度：

```c++
	// 文件目錄的路徑
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// 建立一個代表 PPTX 檔案的 Presentation 類別實例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 取得第一張投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 加入具有預設資料的圖表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 設定系列的數值格式
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// 將簡報檔案寫入磁碟
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **將百分比顯示為標籤**

Aspose.Slides for C++ 允許您在顯示的圖表上設定百分比標籤。以下 C++ 程式碼示範此操作：

```c++
	// 文件目錄的路徑
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// 建立 Presentation 類別的實例
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

	// 儲存包含圖表的簡報
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **在圖表資料標籤中設定百分比符號**

以下 C++ 程式碼示範如何為圖表資料標籤設定百分比符號：

```c++
	// 文件目錄的路徑。
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// 建立 Presentation 類別的實例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 透過索引取得投影片的參照
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在投影片上建立 PercentsStackedColumn 圖表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// 將 NumberFormatLinkedToSource 設為 false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// 設定圖表資料工作表的索引
	int defaultWorksheetIndex = 0;

	// 取得圖表資料工作表
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 刪除預設產生的系列 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 新增一個系列
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 取得第一個圖表系列
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// 填充系列資料
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 設定系列的填滿顏色
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// 設定 LabelFormat 屬性
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 取得第二個圖表系列
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// 填充系列資料
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 設定系列的填滿顏色
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// 設定 LabelFormat 屬性
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 將簡報檔寫入磁碟
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **設定標籤與類別軸的距離**

以下 C++ 程式碼示範當您使用軸繪製圖表時，如何設定標籤與類別軸的距離：

```c++
	// 文件目錄的路徑
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// 建立 Presentation 類別的實例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 取得投影片的參照
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 在投影片上建立圖表
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 取得圖表系列集合
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 設定標籤與軸的距離
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// 將簡報檔寫入磁碟
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **調整標籤位置**

當您建立不依賴任何軸的圖表（例如圓餅圖）時，圖表的資料標籤可能會太靠近邊緣。此時，需要調整資料標籤的位置，以便清楚顯示指引線。

以下 C++ 程式碼示範如何在圓餅圖上調整標籤位置：

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

![已調整標籤的圓餅圖](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止在密集圖表上標籤重疊？**

結合自動標籤放置、指引線與縮小字體大小；必要時隱藏某些欄位（例如類別）或僅為極端/關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤前過濾資料點，並根據定義的規則關閉零值、負值或遺失值的顯示。

**如何在匯出為 PDF/圖片時確保標籤樣式一致？**

明確設定字型（族群、大小），並確認渲染端具備該字型，以避免回退。