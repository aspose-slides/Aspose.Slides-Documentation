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
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **概要**

チャートのデータ ラベルは、データ系列や個々のデータ ポイントに関する詳細を表示します。これにより、読者はデータ系列をすばやく識別でき、チャートの理解が容易になります。

## **チャート データ ラベルのデータ精度を設定する**

この C++ コードは、チャート データ ラベルのデータ精度を設定する方法を示します。

```c++
	// ドキュメント ディレクトリへのパス
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTX ファイルを表す Presentation クラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドを取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// デフォルト データでチャートを追加
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 系列の数値書式を設定
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// プレゼンテーション ファイルをディスクに保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **パーセンテージをラベルとして表示する**

Aspose.Slides for C++ を使用すると、表示されるチャートにパーセンテージ ラベルを設定できます。この C++ コードはその操作をデモンストレーションします。

```c++
	// ドキュメント ディレクトリへのパス
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Presentation クラスのインスタンスを作成
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

## **チャート データ ラベルにパーセンテージ記号を設定する**

この C++ コードは、チャート データ ラベルにパーセンテージ記号を設定する方法を示します。

```c++
	// ドキュメント ディレクトリへのパス。
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentation クラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// インデックスでスライドの参照を取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライド上に PercentsStackedColumn チャートを作成
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource を false に設定
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// チャート データ シートのインデックスを設定
	int defaultWorksheetIndex = 0;

	// チャート データ ワークシートを取得
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// デフォルトで生成された系列を削除 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 新しい系列を追加
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 最初のチャート系列を取得
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// 系列データを設定
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 系列の塗りつぶし色を設定
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormat のプロパティを設定
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 2 番目のチャート系列を取得
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// 系列データを設定
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 系列の塗りつぶし色を設定
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormat のプロパティを設定
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// プレゼンテーション ファイルをディスクに保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **軸からのラベル距離を設定する**

この C++ コードは、軸からカテゴリ軸上のラベル距離を設定する方法を示します。

```c++
	// ドキュメント ディレクトリへのパス
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentation クラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// スライドの参照を取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライド上にチャートを作成
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// チャート系列コレクションを取得
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 軸からラベルの距離を設定
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// プレゼンテーション ファイルをディスクに保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ラベル位置を調整する**

軸に依存しないチャート（例: 円グラフ）を作成すると、データ ラベルがエッジに近すぎることがあります。そのような場合、リーダー ラインがはっきり表示されるようにデータ ラベルの位置を調整する必要があります。

この C++ コードは、円グラフのラベル位置を調整する方法を示します。

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

## **よくある質問**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォント サイズの縮小を組み合わせます。必要に応じて、一部のフィールド（例: カテゴリ）を非表示にするか、極端または重要なポイントにのみラベルを表示します。

**ゼロ、負、または空の値に対してラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートする際にラベルのスタイルを一貫させるにはどうすればよいですか？**

フォント（ファミリ、サイズ）を明示的に設定し、レンダリング側でフォントが利用可能であることを確認してフォールバックを防止します。