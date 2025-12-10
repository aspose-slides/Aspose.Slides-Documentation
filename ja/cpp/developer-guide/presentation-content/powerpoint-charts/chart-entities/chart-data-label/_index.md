---
title: C++ を使用したプレゼンテーションでのチャート データ ラベルの管理
linktitle: データ ラベル
type: docs
url: /ja/cpp/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---

チャートのデータラベルは、チャートのデータ系列や個々のデータポイントに関する詳細を表示します。これにより、読者はデータ系列をすばやく識別でき、チャートの理解もしやすくなります。

## **チャート データラベルのデータ精度を設定する**

この C++ コードは、チャート データラベルのデータ精度を設定する方法を示します。
```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドを取得する
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// デフォルトデータでチャートを追加する
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 系列の数値書式を設定する
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// プレゼンテーションファイルをディスクに保存する
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ラベルとしてパーセンテージを表示する**

Aspose.Slides for C++ を使用すると、表示されたチャートにパーセンテージ ラベルを設定できます。この C++ コードは、その操作を示しています。
```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Presentation クラスのインスタンスを作成する
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

	// チャートを含むプレゼンテーションを保存する
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **チャート データラベルにパーセンテージ記号を設定する**

この C++ コードは、チャート データラベルにパーセンテージ記号を設定する方法を示します。
```c++
	// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentation クラスのインスタンスを作成する
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// インデックスでスライドの参照を取得する
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライド上に PercentsStackedColumn チャートを作成する
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource を false に設定する
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// チャート データシートのインデックスを設定する
	int defaultWorksheetIndex = 0;

	// チャート データのワークシートを取得する
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// デフォルトで生成された系列を削除する
	chart->get_ChartData()->get_Series()->Clear();
	

	// 新しい系列を追加する
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 最初のチャート系列を取得する
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// 系列データを設定する
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 系列の塗りつぶし色を設定する
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormat のプロパティを設定する
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 2 番目のチャート系列を取得する
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// 系列データを設定する
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 系列の塗りつぶし色を設定する
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormat のプロパティを設定する
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// プレゼンテーションファイルをディスクに保存する
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```



## **軸からラベルの距離を設定する**

この C++ コードは、軸からプロットされたチャートでカテゴリ軸からラベルの距離を設定する方法を示します。
```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentation クラスのインスタンスを作成する
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// スライドの参照を取得する
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライド上にチャートを作成する
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// チャート系列コレクションを取得する
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 軸からラベルの距離を設定する
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// プレゼンテーションファイルをディスクに保存する
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ラベル位置を調整する**

円グラフのように軸に依存しないチャートを作成する場合、チャートのデータラベルが端に近すぎることがあります。そのような場合、リーダーラインが明確に表示されるようにデータラベルの位置を調整する必要があります。

この C++ コードは、円グラフでラベル位置を調整する方法を示します。
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

## **FAQ**

**密集したチャートでデータラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、いくつかのフィールド（例: カテゴリ）を非表示にするか、極端または重要なポイントのみラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際にラベルスタイルの一貫性を確保するにはどうすればよいですか？**

フォント（ファミリー、サイズ）を明示的に設定し、フォールバックを防ぐためにレンダリング側でフォントが利用可能であることを確認します。