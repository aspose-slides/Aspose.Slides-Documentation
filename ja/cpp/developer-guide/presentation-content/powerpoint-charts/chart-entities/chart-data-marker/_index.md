---
title: プレゼンテーションで С++ を使用してチャートデータマーカーを管理する
linktitle: データマーカー
type: docs
url: /ja/cpp/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカーオプション
- マーカーサイズ
- 塗りタイプ
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ でチャートデータマーカーをカスタマイズする方法を学び、明確な С++ コード例を使用して PPT および PPTX 形式のプレゼンテーションへのインパクトを高めます。"
---

## **チャートマーカーの設定**
Aspose.Slides for C++ は、チャート系列のマーカーを自動的に設定するためのシンプルな API を提供します。以下の機能では、すべてのチャート系列に自動的に異なるデフォルトのマーカー記号が設定されます。

以下のコード例は、チャート系列のマーカーを自動的に設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **チャートマーカーオプションの設定**
特定の系列内のチャートデータポイントにマーカーを設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- インスタンス化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラス。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **系列データポイントレベルでのチャートマーカー設定**
特定の系列内のチャートデータポイントにマーカーを設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//PPTX ファイルを表す Presentation クラスのインスタンス化
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// デフォルトデータでチャートを追加
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// チャート データ シートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// デフォルトで生成された系列とカテゴリを削除
chart->get_ChartData()->get_Series()->Clear();

// 今、新しい系列を追加
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// 画像を取得
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// プレゼンテーションの画像コレクションに画像を追加
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// 新しいポイント (1:3) を追加
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


## **データポイントに色を適用する**
Aspose.Slides for C++ を使用して、チャートのデータポイントに色を適用できます。**IChartDataPointLevelsManager** と **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)** クラスが追加され、データポイントレベルのプロパティにアクセスできるようになりました。この記事では、チャートのデータポイントにアクセスし、色を適用する方法を示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**標準で利用できるマーカー形状は何ですか？**

標準の形状が利用可能です（円、正方形、ダイヤモンド、三角形など）。一覧は [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。標準外の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタムのビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートする際にマーカーは保持されますか？**

はい。チャートを [raster formats](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングしたり、[shapes as SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) として保存したりすると、マーカーはサイズ、塗り、アウトラインなどの外観と設定を保持したままです。