---
title: C++ を使用したプレゼンテーションでのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/cpp/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "レポートや可視化のための PowerPoint プレゼンテーションで、Aspose.Slides for C++ を使用してチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

このドキュメントでは、Aspose.Slides for C++ を使用してチャートの軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて取り上げます。

## **垂直軸の最大値を取得する方法**

[プレゼンテーション](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を作成し、デフォルト データのエリア チャートを追加します。計算された軸の値を取得する前に、[ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) を呼び出して、チャートのレイアウトが最新になるようにします。

軸の上限は [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) と [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) で取得し、目盛り間隔は [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) と [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) で取得します。日付軸に関連する時間単位スケールは、[get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) と [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) が提供します。この例では、取得した値をローカル変数に格納し、チャートを保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **軸間のデータを入れ替える**

[SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) を使用して、チャート データ内の系列とカテゴリの役割を交換します。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。この例では、[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えた後、4 系列と 3 カテゴリのチャートを保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **折れ線グラフの垂直軸を非表示にする**

垂直軸に対して `false` を指定した [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) を使用して軸を非表示にします。この例ではデフォルト データの折れ線グラフを作成し、垂直軸を非表示にした状態で保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **折れ線グラフの水平軸を非表示にする**

水平軸に対して `false` を指定した [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) を使用して軸を非表示にします。この例ではデフォルト データの折れ線グラフを作成し、水平軸を非表示にした状態で保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **カテゴリ軸を変更する**

[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) を使用して、日付軸またはテキスト軸を選択します。この例では `ExistingChart.pptx` が必要で、最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリ セルには数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) に `false`、[set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) に `1`、[set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) に `months` を指定して、主要目盛りを 1 ヶ月間隔に設定します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **カテゴリ軸ラベルの間隔を制御する**

チャートに多数のカテゴリがある場合、カテゴリやデータ ポイントを削除せずに表示される軸ラベルの数を減らすことができます。[set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) に `false` を設定し、続いて [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) に希望するカテゴリ間隔を指定します。テキストカテゴリが通常の順序で並んでいる場合、カウントは最初のカテゴリから開始します。

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` の間隔を指定すると、3 番目ごとのラベルが表示され、表示されたラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を決定し、必ずしもすべてのラベルを表示するわけではありません。

目盛りは別個に制御できます。[set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) に `false` を設定し、[set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) で間隔を指定します。たとえば `1` を設定すると、カテゴリ間隔ごとに目盛りが配置され、ラベルは 3 番目ごとにのみ表示されます。[set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) で目立つスタイルを指定すると結果が確認できます。自動間隔プロパティを `true` に戻すと、チャートが間隔を再度自動計算します。

以下の単独実装例は 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライドを保存します：自動間隔、ラベル間隔を手動で設定した例（目盛りは独立）、自動間隔に復元した例です。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより、密度の違いが見やすくなります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: スライド 2: 3 つごとにラベルを表示し、各カテゴリの目盛りはそのまま残す。
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: スライド 3: チャートに両方の間隔を再び自動で選択させる。
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**自動間隔（スライド 1）:** この描画では、2 番目のカテゴリラベルごとに表示され、2 行に折り返されます。自動結果はチャートサイズ、フォント、レンダラにより変わります。

![自動カテゴリラベル間隔（24 列すべて表示）](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含め、すべての 24 列が同じ値で表示されます。スライド 3 は上記の自動表示に戻ります。

![手動カテゴリラベル間隔（3）で 24 列すべて表示](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフなど）のカテゴリ数間隔としてこの設定を使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) に適用します。目盛り間隔は series 軸を持つチャートでも適用できます。

カテゴリ ラベル間隔を値軸の数値スケール設定に使用しないでください。値軸では [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) が値の差を指定します（例: `10` の主要単位は 0、10、20…）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸の変更](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸値の日時書式を設定する**

この例ではデフォルト データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納されます。[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) で日付軸を選択し、[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) でソースリンク書式を無効にし、[set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) に `yyyy` を設定して、セルの書式設定に関係なくカテゴリ ラベルに 4 桁の年が表示されるようにします。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **チャート軸タイトルの回転角度を設定する**

[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) で垂直軸タイトルを有効にし、タイトル テキストを設定し、[set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) でタイトルを回転させます。角度は度で測定され、この例では値軸タイトルを 90 度回転させた列グラフを保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **カテゴリ軸または値軸の位置を設定する**

[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) を使用して、値軸がカテゴリ軸の間（カテゴリ間の目盛り位置）を横切るか、カテゴリ目盛り位置で横切るかを制御します。このプロパティはカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **チャート値軸の表示単位を設定する**

[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) を使用して、基になるデータを変更せずに値軸ラベルのスケールを調整します。[DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) を `Millions` に設定すると、60,000,000 の値が 60 と表示されます。この例では列グラフを作成し、垂直軸にミリオン単位の表示単位を適用します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **対数値軸を構成する**

対数値軸は、正の値が数桁にわたって変化する場合に有用です。たとえば、5 つの期間で 10、100、1,000、10,000、100,000 のリクエストがあるとします。線形スケールでは小さい値がゼロ付近に密集して表示されますが、対数スケールでは相対的な成長が比較しやすくなります（等距離が等比率を表す）。

値軸に対して `true` の [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) を呼び出し、[set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータのフィッティング結果であり、別機能です。

### **値軸と基数を選択する**

折れ線グラフや列グラフの場合、値軸は [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) です。水平棒グラフの場合は [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) になります。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（整数）までの基数が使用でき、`2.5` のような小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の単独実装例は、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 枚目で基数 10 の対数値軸を有効にします。2 枚のスライドは同じデータを保持します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更する。
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**線形スケール（スライド 1）:** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、比較的小さい値が区別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離が等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケールでは直線的に上昇する直線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示すグラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは厳密に正の値しか表示できません。適用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを使用するか、別途表示してください。これらの値を除外することが分析上適切な場合は、その理由を説明します。小さい正の数に置き換えてはならず、データの意味が変わります。対数軸の最小値・最大値を手動で設定する場合も、正の数である必要があります。

## **FAQ**

**軸が交差する位置（軸交差）を設定するにはどうすればよいですか？**

[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) で交差動作を選択し、数値の交差位置を指定するには [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) を使用します。これらの設定により、軸交差位置を適切な基準線に移動できます。

**目盛ラベルの位置を軸に対してどのように設定できますか？**

[set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) と [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/)（`Low`、`High`、`NextTo`、`None`）から値を選択します。目盛り自体を制御するには、[set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) または [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) を使用します。これらはラベル位置設定とは別です。