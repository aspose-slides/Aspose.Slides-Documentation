---
title: C++ を使用したプレゼンテーションでのチャート データ マーカーの管理
linktitle: データ マーカー
type: docs
url: /ja/cpp/chart-data-marker/
keywords:
- チャート
- データ ポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶし タイプ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でチャート データ マーカーをカスタマイズする方法を学び、明確な C++ コード例を使用して PPT および PPTX 形式のプレゼンテーション効果を高めます。"
---
## **概要**

この記事では、Aspose.Slides でチャート データ マーカーを操作する方法を説明します。チャートの作成、シリーズとそのデータポイントへのアクセス、データポイントレベルでのマーカーへの画像塗りつぶしの適用、マーカーサイズの調整、更新されたプレゼンテーションの保存方法を示します。また、標準のマーカー形状は `MarkerStyleType` 列挙体で利用でき、チャートをラスタ形式または SVG にエクスポートする際にマーカーの外観が保持されることも説明します。

## **チャート マーカーの設定**
Aspose.Slides for C++ は、チャート シリーズのマーカーを自動的に設定するシンプルな API を提供します。以下の機能では、すべてのチャート シリーズにデフォルトの異なるマーカー記号が自動的に付与されます。

以下のコード例は、チャート シリーズのマーカーを自動的に設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **チャート マーカー オプションの設定**
特定のシリーズ内のチャート データポイントにマーカーを設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- インスタンス化 [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラス。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート シリーズを取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャート マーカー オプションを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **シリーズ データポイントレベルでのチャート マーカーの設定**
現在、特定のシリーズ内のチャート データポイントにマーカーを設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- インスタンス化 [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラス。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート シリーズを取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャート マーカー オプションを設定しています。

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

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
Aspose.Slides for C++ を使用して、チャートのデータポイントに色を適用できます。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) と **[IChartDataPointLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/)** クラスが追加され、データポイント レベルのプロパティにアクセスできるようになりました。本記事では、チャートのデータポイントにアクセスし色を適用する方法を示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **よくある質問**

**標準で利用できるマーカー形状は何ですか？**

標準の形状（円、正方形、ダイヤモンド、三角形など）が利用可能で、リストは [MarkerStyleType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。標準外の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートした際にマーカーは保持されますか？**

はい。チャートを [raster formats](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングしたり、[shapes as SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) として保存したりする場合、マーカーはサイズ、塗りつぶし、アウトラインなどの外観と設定を保持します。