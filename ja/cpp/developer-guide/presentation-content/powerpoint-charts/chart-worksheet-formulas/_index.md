---
title: C++ を使用したプレゼンテーションでチャート ワークシートの数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/cpp/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- チャート データ ワークブック
- 数式 計算
- 優先カルチャ
- カルチャ固有 の 数式
- DBCS
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 演算子
- 比較 演算子
- A1 スタイル
- R1C1 スタイル
- 組み込み 関数
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートに元データを格納します。Aspose.Slides for C++ では、チャート データ ワークブックを通じてそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。チャートの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式の割り当て、再計算、計算結果の取得、セルをチャート シリーズに接続、プレゼンテーションの保存、さらにサポートされている数式構文、組み込み関数のサブセット、キャッシュされた値、サポート外の数式、スプレッドシート固有のエラーについても解説します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、シリーズ名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートが開かれた状態で、カテゴリとシリーズ データが表示されているチャート](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [IChartDataWorkbook](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/) インターフェイスを通じて公開されています。A1 形式の数式には [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_formula/) を、R1C1 形式の数式には [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) を使用します。入力セルや数式を変更したら、[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算されたセルは依然として [IChartDataCell::get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/get_value/) で結果を取得できます。コード内で数式結果を確認したり、セルをチャート データ ポイントとして使用したりする際に重要です。

## **チャートの作成とワークシート数式の計算**

次の例は、エンドツーエンドのワークフローを示します。クラスター化列グラフを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャート 値として使用し、プレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

チャート データ ポイントは `D2:D4` を参照しているため、計算された利益の値が使用されます。このワークフローでは別途チャート の更新呼び出しは不要です。まずワークブックを再計算し、次に計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式の使用**

A1 表記は列を文字、行を数字で識別します。A1 形式の式は [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_formula/) で割り当てます。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

代表的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式がスプレッドシート アプリケーションで移動またはコピーされたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のどちらか一方だけを固定します。

## **R1C1 形式の数式の使用**

R1C1 表記は行と列の両方を数値で識別します。相対参照は角括弧内のオフセットで表します。この構文は [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) で割り当てます。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

代表的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえば、セル `D2` で `RC[-2]` は同じ行の左に 2 列あるセル (`B2`) を意味します。

## **数式の定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 型 | 例 | 注釈 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 整数表記と科学技術表記の両方がサポートされています。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果ではなくスプレッドシート エラー値を返すことがあります。 |

この例は複数の定数タイプを使用しています。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // 偽
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセント | `30%` |
| `^` | 累乗 | `2^3` |

評価順序を明示したい場合は括弧を使用します。例: `(A2+B2)*C2`.

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | 大きい | `A2>3` |
| `>=` | 大きいまたは等しい | `A2>=3` |
| `<` | 小さい | `A2<3` |
| `<=` | 小さいまたは等しい | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれますが、完全な Excel 計算エンジンではありません。ドキュメント化されている関数は以下の一覧に限られます。[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) が任意の Excel 関数を再計算できると想定しないでください。

| 関数 | 用途またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定した倍数へ切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムで日付を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 つの日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で文字列を検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件付き結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示した制限は重要です。`INDEX` は参照形式、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされます。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能や関数は、Aspose.Slides の数式評価エンジンではサポートされていないとみなしてください。

## **優先カルチャでの数式計算**

一部のワークブック関数はテキストをカルチャ固有の規則で解釈します。特に、ダブルバイト文字セット (DBCS) を使用する言語向け関数では重要です。正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/) を作成し、[LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 経由で [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) を構成し、プレゼンテーションをロードします。

以下の例は日本語カルチャを選択し、構成したロード オプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出します。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

優先カルチャはプレゼンテーションのロード設定の一部です。したがって、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成する前に指定します。ワークブック数式で期待されるカルチャを使用してください。例: 日本語 DBCS 計算規則に従う数式の場合は `ja-JP` を使用します。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を格納します。Aspose.Slides はプレゼンテーションがロードされ、該当するチャート データが変更されていない場合、[IChartDataCell::get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/get_value/) からキャッシュされた値を読み取ることができます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取るか、依存するチャート データを保存する前に、必ず [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してください。

サポート外の数式については、Aspose.Slides が数式を解析できない、または依存関係を確立できない可能性があります。ワークブックが変更された場合、以前のキャッシュ値はもはや信頼できません。そのような状況でサポート外のデータを含むセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされることがあります。

チャートが Aspose.Slides で評価されない Excel 関数に依存している場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測した値で置き換えてはいけません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

* 数式は有効だが、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` といったスプレッドシート エラー結果を返す場合。この場合、エラー トークンはセルの結果であり、[IChartDataCell::get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/get_value/) で取得できます。
* 数式自体が構文エラー、参照エラー、依存関係エラー、またはサポート外データエラーで失敗する場合。Aspose.Slides はこれらのケースに対して以下のスプレッドシート固有例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算と値取得の周囲でこれらの例外を処理してください。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // 無効な数式を処理します。
}
catch (CellInvalidReferenceException&)
{
    // 無効なセル参照を処理します。
}
catch (CellCircularReferenceException&)
{
    // 循環参照を処理します。
}
catch (CellUnsupportedDataException&)
{
    // サポートされていないスプレッドシート データを処理します。
}
```

## **実務上の制限**

チャート ワークシートでの数式サポートは、完全な Excel 互換性ではなく、定義されたサブセットの計算を対象としています。レポート ワークフローを設計する際は次の点に留意してください。

* Aspose.Slides に再計算させる必要がある場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
* 式の結果が依存するセルを変更したら必ず再計算してください。
* ロードされたプレゼンテーションからのキャッシュ値はスナップショットとみなし、編集後の再計算の代替にはしないでください。
* 既存テンプレートからの数式は、ドキュメント化されたリストにない関数を使用しているかどうか事前にテストしてください。
* 完全なスプレッドシート計算エンジンが必要な数式は外部で計算し、結果のみをチャート ワークブックに書き込んでください。

## **FAQ**

**`set_Formula` と `set_R1C1Formula` の違いは何ですか？**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_formula/) は `B2-C2` のような A1 形式の式を格納します。[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) は `RC[-2]-RC[-1]` のような R1C1 形式の式を格納します。数式の生成またはコピー方法に最も適した表記を使用してください。

**計算後にセル自体を読むべきですか、値を読むべきですか？**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) は `IChartDataCell` を返します。再計算後に結果を取得するには、そのセルの [IChartDataCell::get_Value](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatacell/get_value/) を読み取ります。

**`CalculateFormulas` はいつ呼び出すべきですか？**

入力値または数式を変更した直後、計算結果に依存する前に [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してください。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換性が必要な場合は、別のスプレッドシート エンジンで計算し、最終的な値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポート外の数式が含まれていたらどうなりますか？**

チャート データが変更されていない場合、ワークブックには以前に計算されたキャッシュ値が残っていることがあります。関連データが変更されると、そのキャッシュ値は無効になる可能性があります。処理できない数式を含むセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされることがあります。

**数式エラーの値は C++ の例外と同じですか？**

いいえ。`#DIV/0!` のような結果は、有効な計算によって生成されたスプレッドシートの値です。[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) などの例外は、数式が正常に処理できないことを示します。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート シリーズはワークブックセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。データ ポイントが計算されたセルを参照していれば、チャートは更新されたセル値を使用します。このワークフローでは別途チャート更新メソッドは不要です。

**チャートは外部 Excel ワークブックを使用できますか？**

はい、チャート データは API を通じて外部ワークブックを使用するように構成できます。ただし、この記事で説明した数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価する数式サブセットに限定されます。[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) が外部 XLSX ファイル内の任意の数式を完全に再計算するとは想定しないでください。

**別シートや別ブックを参照する数式は使用できますか？**

Excel 形式の参照はチャート ワークブックに存在する可能性がありますが、評価はサポートされるパーサーと関数セットに制限されます。クロスシートまたは外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に評価できるか確認してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決済みの値をチャート データに書き戻すことを検討してください。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides API の例では `B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てます。この形に従うことで、API 例と一貫した数式を生成できます。