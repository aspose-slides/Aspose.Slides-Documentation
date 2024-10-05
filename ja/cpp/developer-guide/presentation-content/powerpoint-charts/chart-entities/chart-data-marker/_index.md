---
title: チャートデータマーカー
type: docs
url: /cpp/chart-data-marker/
---

## **チャートマーカーの設定**
Aspose.Slides for C++ は、チャート系列のマーカーを自動的に設定するためのシンプルなAPIを提供します。次の機能では、各チャート系列が自動的に異なるデフォルトマーカーシンボルを取得します。

以下のコード例は、チャート系列のマーカーを自動的に設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **チャートマーカーオプションの設定**
マーカーは、特定の系列内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスをインスタンス化します。
- デフォルトチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **系列データポイントレベルでのチャートマーカーの設定**
現在、マーカーは、特定の系列内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- Presentation クラスをインスタンス化します。
- デフォルトチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しました。

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//PPTXファイルを表すPresentationクラスをインスタンス化
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// デフォルトデータを持つチャートを追加
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークブックの取得
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// デフォルトで生成された系列とカテゴリを削除
chart->get_ChartData()->get_Series()->Clear();

// 新しい系列を追加
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"系列 1")), chart->get_Type());

// 画像を取得
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// プレゼンテーションの画像コレクションに画像を追加
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// (1:3)の新しい点を追加
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

// チャート系列のマーカーを変更
series->get_Marker()->set_Size(15);

// プレゼンテーションファイルをディスクに書き込む
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **データポイントに色を適用**
Aspose.Slides for C++を使用して、チャート内のデータポイントに色を適用できます。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)と**[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)**クラスが追加され、データポイントレベルのプロパティにアクセスできるようになりました。この記事では、チャート内のデータポイントにアクセスして色を適用する方法を示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}