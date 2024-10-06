---
title: チャートデータラベル
type: docs
url: /ja/cpp/chart-data-label/
keywords: "チャートデータラベル,ラベル距離,C++,CPP,Aspose.Slides for C++"
description: "C++でPowerPointチャートのデータラベルと距離を設定する"
---

チャートのデータラベルは、チャートデータシリーズや個々のデータポイントに関する詳細を表示します。これにより、読者はデータシリーズを迅速に特定でき、チャートの理解が容易になります。

## **チャートデータラベルのデータ精度を設定する**

このC++コードは、チャートデータラベルにおけるデータの精度を設定する方法を示しています：

```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTXファイルを表すPresentationクラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドを取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// デフォルトデータのチャートを追加
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// シリーズ番号形式を設定
	chart->set_HasDataTable(true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues(u"#,##0.00");

	// プレゼンテーションファイルをディスクに書き込む
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **パーセンテージをラベルとして表示**
Aspose.Slides for C++を使用すると、表示されたチャートにパーセンテージラベルを設定できます。このC++コードは、その操作を実演します：

```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Presentationクラスのインスタンスを作成
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

	// チャートを含むプレゼンテーションを保存
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **チャートデータラベルにパーセンテージ記号を設定する**
このC++コードは、チャートデータラベルのパーセンテージ記号を設定する方法を示しています：

```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentationクラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// スライドのインデックスを通じて参照を取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライドにPercentsStackedColumnチャートを作成
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSourceをfalseに設定
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// チャートデータシートのインデックスを設定
	int defaultWorksheetIndex = 0;

	// チャートデータのワークシートを取得
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// デフォルト生成されたシリーズを削除 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 新しいシリーズを追加
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 最初のチャートシリーズを取得
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// シリーズデータを埋める
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// シリーズの塗りつぶし色を設定
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormatプロパティを設定
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 二番目のチャートシリーズを取得
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// シリーズデータを埋める
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// シリーズの塗りつぶし色を設定
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormatプロパティを設定
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// プレゼンテーションファイルをディスクに書き込む
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **軸からのラベル距離を設定する**
このC++コードは、軸からのラベル距離を設定する方法を示しています：

```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentationクラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// スライドの参照を取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライドにチャートを作成
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// チャートシリーズコレクションを取得
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 軸からのラベル距離を設定
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

	// プレゼンテーションファイルをディスクに書き込む
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ラベルの位置を調整する**

軸に依存しないチャート（例えば円グラフ）を作成すると、チャートのデータラベルがエッジに近すぎることがあります。この場合、リーダーラインが明確に表示されるようにデータラベルの位置を調整する必要があります。

このC++コードは、円グラフのラベル位置を調整する方法を示しています：

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