---
title: C++ を使用したプレゼンテーションのチャートデータマーカーの管理
linktitle: データマーカー
type: docs
url: /ja/cpp/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカーオプション
- マーカーサイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でチャートデータマーカーをカスタマイズする方法を学び、PPT および PPTX 形式のプレゼンテーション効果を高める、明確な C++ コード例を提供します。"
---

## **チャート マーカーの設定**
Aspose.Slides for C++ は、チャート系列マーカーを自動的に設定するシンプルな API を提供します。以下の機能では、すべてのチャート系列が自動的に異なるデフォルトマーカーシンボルを取得します。

以下のコード例は、チャート系列マーカーを自動的に設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **チャート マーカー オプションの設定**
マーカーは特定の系列内のチャート データポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き出します。

以下の例では、データポイントレベルでチャート マーカー オプションを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **シリーズ データ ポイント レベルでのチャート マーカーの設定**
現在、マーカーは特定の系列内のチャート データポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き出します。

以下の例では、データポイントレベルでチャート マーカー オプションを設定しています。
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Access first slide
// Add chart with default data
// Setting the index of chart data sheet
// Getting the chart data worksheet
// Delete default generated series and categories
// Now, Adding a new series
// Get the picture
// Add image to presentation's images collection
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


## **データポイントへの色の適用**
Aspose.Slides for C++ を使用して、チャートのデータポイントに色を適用できます。データポイントレベルのプロパティにアクセスするために、[IChartDataPointLevelsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) と **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** クラスが追加されました。本稿では、チャートのデータポイントにアクセスし、色を適用する方法を示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**標準で利用できるマーカー形状は何ですか？**

標準の形状が利用可能です（円、正方形、ダイヤモンド、三角形など）。この一覧は [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。非標準の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートする際、マーカーは保持されますか？**

はい。チャートを [ラスタ形式](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングしたり、[シェイプを SVG として保存](/slides/ja/cpp/render-a-slide-as-an-svg-image/) したりすると、マーカーはサイズ、塗りつぶし、輪郭などの外観と設定を保持したままです。