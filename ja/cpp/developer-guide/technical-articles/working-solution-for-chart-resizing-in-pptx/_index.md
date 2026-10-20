---
title: PPTX のチャートサイズ変更に対する実用的解決策
type: docs
weight: 60
url: /ja/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャート サイズ変更
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して埋め込まれた Excel OLE オブジェクトで PPTX の予期しないチャートサイズ変更を修正します。チャートと OLE フレームのサイズを一貫させるために、固定のチャート寸法を設定します。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel グラフは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でグラフの外観に顕著な差が生じることがあります。本記事ではサイズ変更が発生する理由を説明し、固定されたチャートサイズを OLE フレームに合わせることでそれを防止する方法を示します。

In [PowerPoint プレゼンテーションに OLE オブジェクトとして Excel グラフを作成して埋め込む](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for C++ and embed it in a PowerPoint presentation using Aspose.Slides for C++. To address the [オブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **サイズ変更の原因**

埋め込まれた Excel ワークブックは独自のウィンドウサイズを持っており、Excel はオブジェクトが最初にアクティブ化されたときにそのサイズを維持しようとします。スライド上の OLE フレームは別個に定義されたサイズを持っています。Excel ワークブックがアクティブ化されると、Excel と PowerPoint がオブジェクトのサイズを交渉し、埋め込みプロセスの一部として比例を保ちます。ワークブックウィンドウと OLE フレーム間の違いが、オブジェクトのサイズ変更を引き起こす原因となります。

## **実用的な解決策**

チャートのサイズをスライド上の OLE フレームに合わせ、チャートの寸法をワークブックウィンドウとは独立させます。このソリューションは新規プレゼンテーションでも既存のテンプレートでも機能します。

この例は Aspose.Cells for C++ と Aspose.Slides for C++ が必要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、ブックを XLS 形式で埋め込みます。プレビュー画像は割り当てず、PowerPoint で OLE オブジェクトがアクティブ化されたときにチャートが表示されます。

例のコードはアプリケーションのエントリポイントに配置し、インクルード宣言はファイルスコープに置きます。Aspose.Cells のオブジェクトを作成する前に初期化し、オブジェクトが破棄された後にリソースを解放します。例では Aspose.Cells が返すブックのバイトベクターを Aspose.Slides が受け入れる配列型にコピーしています。

例は 9.5 × 4 インチの OLE フレームを左端から 0.5 インチ、上端から 1 インチの位置に作成します。スライド座標とサイズはポイント単位（1 インチ＝72 ポイント）です。既存のプレゼンテーションの場合は、[テンプレートの使用](#use-a-template) を参照してください。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // スライドの座標とサイズはポイント単位です（1 インチ = 72 ポイント）。
    auto width = 684.f; // 9.5 インチです。
    auto height = 288.f; // 4 インチです。

    chart.SetSizeWithWindow(false);
    // ポイントをインチあたり 96 ピクセルの比率でチャートのピクセルに変換します。
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Cells のバイトベクターを Slides が受け入れる配列型にコピーします。
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **固定チャートサイズの設定**

[Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) を false に設定して、チャートの寸法がワークブックウィンドウに依存しないようにします。チャートオブジェクトのサイズは [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) から取得し、[Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) と [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/) で設定します。ポイントをピクセルに変換する際は 1 インチ＝96 ピクセルを使用します。たとえば 684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。[Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) を [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/) の Custom 値に設定します。例では [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) を使用してブックを埋め込み、9.5 × 4 インチの OLE フレームを持つプレゼンテーションを保存します。

## **テンプレートの使用**

既存のプレゼンテーションでも同様のサイズロジックを使用します。例を適用する手順は次のとおりです。

1. 空のプレゼンテーションを作成する代わりにテンプレートプレゼンテーションを読み込みます。  
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。  
3. 固定値 684 と 288 の代わりに、そのシェイプからフレームの幅と高さを取得します。サイズ計算は変更しません。  
4. プレースホルダーの位置に OLE フレームを配置し、固定座標 36 と 72 は使用しません。  
5. プレゼンテーションを保存する前にプレースホルダーを削除します。

## **FAQ**

**PowerPoint でアクティブ化した後に埋め込み Excel グラフのサイズが変わるのはなぜですか？**

Excel が最初にアクティブ化されたときに元のウィンドウサイズを復元しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持つためです。PowerPoint と Excel がサイズとアスペクト比を調整して交渉する結果、サイズ変更が発生します。

**チャートと OLE フレームのサイズを一貫させるにはどうすればよいですか？**

固定されたチャート寸法を OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に示す設定と単位変換を参照してください。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**

ワークブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズが変わることを確実に防げません。例にあるように固定チャート寸法を使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。テンプレートの場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**

この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティブ化動作は示していません。

## **関連セクション**

- [PowerPoint プレゼンテーションに OLE オブジェクトとして Excel グラフを作成して埋め込む](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)