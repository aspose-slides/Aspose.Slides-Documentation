---
title: C++ を使用したプレゼンテーションのチャート凡例のカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/cpp/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してチャート凡例をカスタマイズし、カスタマイズされた凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for C++ は、PowerPoint プレゼンテーションのチャート凡例をカスタマイズするオプションを提供します。本記事では、凡例の位置とサイズの指定、凡例全体のフォントサイズの設定、個々の凡例エントリの書式設定、選択したエントリの非表示または復元方法を示します。

FAQ では、凡例のスペース確保、複数行ラベルの表示、プレゼンテーションテーマからの書式継承など、関連する動作について説明します。

## **凡例の位置指定**

凡例の [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) メソッドを使用して、チャートのサイズに対する相対的な位置とサイズを指定します。

この例では、プレゼンテーションを作成し、デフォルト データを持つクラスター化列グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100×100 ポイントになります。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// 凡例の位置とサイズをチャートに対して相対的に指定します。
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **凡例のフォントサイズの設定**

凡例の [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) を使用してテキスト書式にアクセスし、[set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) でフォントサイズをポイント単位で設定します。

この例では、デフォルト データのチャートを作成し、凡例テキストを 20 ポイントに設定します。また、垂直軸の自動範囲設定を無効にし、範囲を -5 から 10 に設定します。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **個別の凡例エントリのフォントサイズの設定**

凡例の [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) メソッドが返すコレクションを使用して、特定のエントリの書式にアクセスします。エントリのインデックスは 0 から始まるため、インデックス `1` は 2 番目のエントリを指します。

この例では、デフォルト データに少なくとも 2 系列が含まれるクラスター化列グラフを作成します。2 番目の凡例エントリを太字・斜体・20 ポイントの青色テキストで書式設定します。

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **個別の凡例エントリを非表示にする**

データは表示したまま補助系列を凡例から除外するには、[ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) を `true` で呼び出し、[IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) を介して対象とします。これにより選択した凡例エントリだけが非表示になり、系列やデータ ポイントは削除されません。対照的に、[IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) を `false` で呼び出すと、凡例全体が非表示になります。

以下の例では、デフォルト データを使用した複数系列のクラスター化列グラフを作成します。2 番目の系列の凡例エントリ（インデックス `1`）を非表示にし、プレゼンテーションを保存します。その後、`set_Hide` を `false` で呼び出してエントリを復元し、2 番目のコピーを保存します。列は両方のファイルで表示されたままです。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// チャート データを変更せずに同じエントリを復元します。
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

下の比較では、すべてのエントリが表示され、Series 2 が凡例から非表示になったチャートの比較（すべての列は表示されたまま）を示します。2 番目の系列の列は変わりません。

![すべての凡例エントリが表示され、Series 2 が凡例から非表示になったチャートの比較（すべての列は表示されたまま）](hide-legend-entry.png)

列、棒、折れ線グラフでは、凡例エントリは系列を表します。円グラフの場合、凡例エントリは個々のデータ ポイント（スライス）を表すため、選択したスライスに対して [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) を使用します。このデータポイント メソッドは `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` の各チャートタイプについて API に記載されています。ドーナツ グラフには適用されないことに注意してください。

## **よくある質問**

**チャートが凡例の上にオーバーレイせず、凡例用にスペースを確保させることはできますか？**

はい。`false` を指定して [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) を呼び出すと、プロット領域と重ならないように凡例用のスペースを確保できます。

**複数行の凡例ラベルを作成できますか？**

はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、系列名に改行文字を入れることで改行を要求することもできます。

**凡例をプレゼンテーションのテーマ カラースキームに従わせるにはどうすればよいですか？**

凡例の色、塗りつぶし、フォントを設定しないままにしておくと、テーマの書式設定を継承します。明示的に書式を設定すると、対応するテーマ設定を上書きします。