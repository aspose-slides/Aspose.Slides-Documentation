---
title: "C++ を使用したプレゼンテーションの円グラフカスタマイズ"
linktitle: "円グラフ"
type: docs
url: /ja/cpp/pie-chart/
keywords:
- 円グラフ
- グラフの管理
- グラフのカスタマイズ
- グラフ オプション
- グラフ 設定
- プロット オプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して円グラフを作成およびカスタマイズします。二次プロットを設定し、データラベルを表示し、PowerPoint で自動スライス着色を適用できます。"
---
## **概要**

この記事では、Aspose.Slides で円グラフを操作する方法を説明します。Pie of Pie および Bar of Pie グラフの二次プロットオプションの設定方法と、標準円グラフで自動スライス着色を有効にする方法を示します。

例では、スライドへのグラフ追加、シリーズやラベル設定の調整、既定のグラフデータをカスタムのカテゴリと値に置き換える、更新されたプレゼンテーションの保存といったグラフカスタマイズ作業に焦点を当てています。

## **Pie of Pie および Bar of Pie グラフの二次プロットオプション**

Aspose.Slides for C++ は Pie of Pie および Bar of Pie グラフの二次プロットオプションをサポートします。これらのオプションは二次プロットのサイズと、データポイントを二つのプロット間でどのように分割するかを制御します。

以下の例は新しいプレゼンテーションに Pie of Pie グラフを作成し、データポイントの値をラベルとして表示します。[set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) メソッドは二次プロットのサイズをメインプロットの 149% に設定します。[set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) はパーセンテージベースの分割を選択し、[set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) は閾値を 53% に設定します。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **二次プロット用カテゴリの選択**

パーセンテージ値に関係なく特定のカテゴリを二次プロットにグループ化したい場合は、カスタム分割を使用します。例えば、売上レポートで Online と Events を一緒に表示すると、読者はこれら 2 つのチャネルを比較でき、合計売上の 35% と 10% を占めていても問題ありません。

[set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) を [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) と共に呼び出し、[get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/) でポイントを選択します。コレクションの [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) メソッドはシリーズ内の0から始まるインデックスを受け取ります。この例ではインデックス 1 が Online、インデックス 3 が Events を選択します。Partners も一時的に追加され、その後 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/) で除外されます。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// デフォルトデータをチャネル別の売上に置き換えます。
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// シリーズ内のゼロベースインデックスで Online と Events を選択します。
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// ソースデータを削除せずに Partners を選択から除外します。
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) と Events (10) は二次プロットで別々のスライスとして表示されます。一次プロットでは、Retail (40) と Partners (15) と合わせて、値 45 の結合スライスとして表されます。カスタム選択から Partners を除外しても一次プロットには残り、カテゴリやその値がチャートの元データから削除されることはありません。

以下の画像は PowerPoint で保存されたプレゼンテーションを示しています。

![二次プロットに Online と Events が表示され、一次プロットで合計値 45 になる Pie of Pie グラフ](pie_of_pie_custom.png)

## **円グラフの自動スライス着色の設定**

Aspose.Slides for C++ は円グラフのスライスに自動的に異なる色を割り当てることができます。以下の例は中央にタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) メソッドは 20、50、30 の値をラベルとして表示し、[set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) は各スライスに異なる色を有効にします。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// 中央揃えのチャートタイトルを追加します。
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// 最初のワークシートを使用して既定のデータを置き換えます。
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// 値を表示し、スライスに異なる色を割り当てます。
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **よくある質問**

**Pie of Pie および Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは[supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) を通じて、Pie of Pie と Bar of Pie タイプを含む円グラフの二次プロットをサポートしています。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)（PNG など）を使用して、プレゼンテーション全体をエクスポートせずにチャートだけを画像としてエクスポートできます。