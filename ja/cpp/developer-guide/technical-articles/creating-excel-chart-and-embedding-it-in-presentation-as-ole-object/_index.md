---
title: Excel チャートを作成し、プレゼンテーションに OLE オブジェクトとして埋め込む
type: docs
weight: 40
url: /ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャートを埋め込む
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Cells for C++ を使用して Excel チャートを作成し、Aspose.Slides を使用して PowerPoint プレゼンテーションにワークブックを埋め込み、チャートのプレビューを含めます。"
---
## **概要**

この記事では、Aspose.Cells for C++ を使用して Excel の縦棒グラフを作成し、Aspose.Slides for C++ を使用してそのワークブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたワークブックには、元データとグラフの両方が含まれます。別の PNG プレビューが、OLE オブジェクトがアクティブになる前にスライド上にグラフを表示します。

結果はネイティブな PowerPoint グラフではなく、埋め込まれた Excel オブジェクトです。OLE を介してワークブックを編集するには、OLE アクティベーションをサポートし、互換性のある Excel がインストールされたデスクトップ アプリケーションが必要です。

## **前提条件**

C++ プロジェクトを Aspose.Cells for C++ と Aspose.Slides for C++ のヘッダーおよびライブラリで構成します。例のコードはアプリケーションのエントリ ポイントに配置し、インクルード宣言はファイル スコープに置きます。Microsoft Office はこれらのライブラリでプレゼンテーションを生成するために必要ありません。

入力ファイルは必要ありません。例ではデータとチャートをメモリ内に作成し、`OutputChart.pptx` を現在の作業ディレクトリに書き込みます。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つワークブックを作成します。
2. チャート シートをアクティブにして、ワークブックがチャート上で開くようにします。
3. ワークブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ワークブックを XLSX としてメモリに保存し、そのバイト列をスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ワークブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) はゼロベースの開始/終了行と列のインデックスを受け取ります。[ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) は代わりに上端行、左端列、下端行、右端列を受け取ります。例では行インデックス 55 と列インデックス 25 を右下の境界として使用していますが、これらの値はレイアウト上の選択であり、データ行や列の数を示すものではありません。

スライドのフレームはポイント単位です。例ではスライド内に収め、PNG のアスペクト比を保持しながら中心に配置し、プレビューをスライド全体に引き伸ばすことはありません。

## **チャートの作成と埋め込み**

以下の完全な例は、`DataSheet` に 4 行 5 列の値を入力します。各行がチャート系列になります。ワークブックを保存する前に、`ChartSheet` をアクティブ シートとして選択します。

ワークブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) に渡された `xlsx` 拡張子と一致します。PNG は中間のビットマップ変換を行わず、メモリ ストリームからロードされます。Aspose.Cells はバイト ベクターを返し、例ではそれを Aspose.Slides が受け入れる配列型にコピーします。Aspose.Cells のオブジェクトを使用する前に初期化し、オブジェクトが破棄された後にリソースを解放します。[IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) を通じて設定すると、デフォルトの OLE プレースホルダーが置き換えられます。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render the chart preview and serialize the editable workbook separately.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copy Cells buffers into the array type used by Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Fit the preview within the slide without changing its aspect ratio.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Release Cells resources after all Cells objects have been destroyed.
Aspose::Cells::Cleanup();
```

## **期待される結果**

`OutputChart.pptx` には、埋め込まれた Excel ワークブックとチャート プレビューを含む 1 枚のスライドが含まれます。ワークブックには元データと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比例を保持します。

![埋め込まれたワークブックのプレビューとして表示された Excel 縦棒グラフ](excel-chart-ole-preview.png)

Excel が利用可能な対応するデスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして埋め込まれたワークブックをアクティブ化および編集できます。アクティブ化と編集は、ホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **よくある質問**

**プレビュー画像が必要な理由は？**  
埋め込まれたワークブックとスライドのプレビューは別個のコンテンツです。デフォルトの「EMBEDDED OLE OBJECT」プレースホルダーの代わりにチャートを表示させるため、チャート画像を提供します。[OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/) を参照してください。

**コードでワークブックを変更した場合、プレビューは自動的に更新されますか？**  
プレビューはスナップショットとして扱います。プログラムでワークブック データを更新する場合、チャート画像を再生成し、プレビューと埋め込みワークブック データの両方を置き換える必要があります。

**XLS を XLSX の代わりに使用できますか？**  
はい。ワークブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のワークブック形式と一致している必要があり、拡張子だけを変更してもデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わる可能性があるのはなぜですか？**  
ホスト アプリケーションは、ワークブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ワークブックの OLE 表示範囲とスライド フレームのサイズの両方が影響します。[PPTX におけるチャートサイズ変更の実装例](/slides/ja/cpp/working-solution-for-chart-resizing-in-pptx/) を参照してください。

## **関連項目**

- [PPTX におけるチャートサイズ変更の実装例](/slides/ja/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/)