---
title: C++ を使用したプレゼンテーションでチャート データ テーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/cpp/chart-data-table/
keywords:
- チャート データ
- データ テーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション内のチャート データ テーブルのフォント、罫線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for C++ を使用すると、チャートのデータ テーブルを表示し、テキストの書式設定、罫線、および凡例キーをカスタマイズできます。本記事では、テーブルの有効化、テキストの書式設定、各種罫線の制御、凡例キーの表示または非表示の方法について説明します。サンプルは設定されたチャートを PPTX ファイルに保存します。

## **フォント プロパティの設定**

チャートのデータテーブルを表示するには、`true` を [IChart::set_HasDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/set_hasdatatable/) に渡します。[IChart::get_ChartDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/get_chartdatatable/) を使用してテーブルにアクセスし、テキストの書式設定を構成します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
1. 最初のスライドにクラスター化列チャートを追加します。
1. チャートのデータテーブルを有効にします。
1. [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_fontbold/) で太字テキストを有効にし、[IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_fontheight/) に `20` を渡して 20 ポイントのテキストにします。
1. 変更されたプレゼンテーションを保存します。

次のサンプルは、作業ディレクトリに少なくとも 1 スライドが含まれる `test.pptx` が必要です。位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定されたフォント設定が適用されたチャートが含まれます。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **データテーブル罫線のカスタマイズ**

[IChart::set_HasDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/set_hasdatatable/) でテーブルを有効にし、[IChart::get_ChartDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/get_chartdatatable/) でアクセスします。3 種類の罫線を個別に制御できます:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) は水平セル罫線を制御します。
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) は垂直セル罫線を制御します。
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) はテーブルの外枠罫線を制御します。

`true` を各セッターに渡すと罫線が表示され、`false` を渡すと非表示になります。次の例はデフォルト データのクラスター化列チャートを作成し、水平罫線と外枠罫線を表示し、垂直罫線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイント単位で指定されます。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

以下の比較は、すべてのケースで同じチャートデータと凡例キー設定を使用しています。すべての罫線が有効な状態から開始し、残りの各バリアントは 1 つの罫線設定だけを無効にします。左下のバリアントが例の罫線設定と一致します。

![すべての罫線が有効、水平罫線なし、垂直罫線なし、外枠罫線なしのチャートデータテーブル](data-table-borders.png)

## **凡例キーの表示または非表示**

凡例キーはデータテーブルの系列名の横にある小さなカラー マーカーです。各テーブル行とチャート系列を対応させるのに役立ちます。[IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) に `true` を渡すとこれらのマーカーが表示され、`false` を渡すと非表示になります。

チャートの個別凡例は [IChart::set_HasLegend](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/set_haslegend/) で制御されます。これらの設定は独立しており、個別凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても個別凡例は非表示になりません。

次の例はデフォルト データのチャートを作成し、データテーブルを有効にして、個別凡例を非表示にしつつテーブル内に凡例キーを表示します。すべてのテーブル罫線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にするには、[IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) に `false` を渡します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

以下の比較は、凡例キーが有効と無効の同じテーブルを示します。すべての罫線は有効のままで、個別チャート凡例は両方とも非表示です。

![左側に凡例キーが表示され、右側に非表示のチャートデータテーブル](data-table-legend-keys.png)

## **よくある質問**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。[IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) に `true` を渡すと凡例キーが表示され、`false` を渡すと非表示になります。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするときにデータテーブルは保持されますか？**

はい。Aspose.Slides は、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、または[画像](/slides/ja/cpp/convert-powerpoint-to-png/) にエクスポートする際、チャートと表示されたデータテーブルをスライドの一部としてレンダリングします。

**テンプレートから読み込んだチャートでデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについては、[IChart::get_HasDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/get_hasdatatable/) を使用してデータテーブルが表示されているか確認し、[IChart::set_HasDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/set_hasdatatable/) で表示状態を変更できます。

**データテーブルが有効になっているチャートをどのように見つけられますか？**

各スライド上のシェイプを列挙し、チャートを特定して、[IChart::get_HasDataTable](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/get_hasdatatable/) の結果を確認します。`true` の場合、データテーブルが有効であることを示します。