---
title: PPTX のチャートサイズ変更に対する実践的解決策
type: docs
weight: 40
url: /ja/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャート サイズ変更
- Excel チャート
- OLE オブジェクト
- チャートの埋め込み
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して埋め込まれた Excel OLE オブジェクトで PPTX の予期せぬチャートサイズ変更を修正します。チャートと OLE フレームのサイズを一貫させるために、固定のチャート寸法を設定します。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でチャートの外観に顕著な違いが生じます。本記事では、サイズ変更が発生する理由を説明し、固定されたチャートサイズを OLE フレームに合わせることでそれを防止する方法を示します。

In [プレゼンテーションに OLE オブジェクトとして埋め込む Excel チャートの作成](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Java and embed it in a PowerPoint presentation using Aspose.Slides for Java. To address the [オブジェクト プレビューの問題](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **サイズ変更の原因**

埋め込まれた Excel ワークブックは独自のウィンドウサイズを持ち、オブジェクトが最初にアクティブ化されたときに Excel がそのサイズを保持しようとします。スライド上の OLE フレームは別個に定義されたサイズを持ちます。Excel ワークブックがアクティブになると、Excel と PowerPoint がオブジェクトのサイズを協議し、埋め込みプロセスの一部として比例を保とうとします。ワークブックウィンドウと OLE フレームのサイズが異なるため、オブジェクトがリサイズされることがあります。

## **実装方法**

チャートのサイズをスライド上の OLE フレームに合わせ、チャートの寸法をワークブックウィンドウとは独立させます。このソリューションは新規プレゼンテーションでも既存のテンプレートでも機能します。

この例は Aspose.Cells for Java と Aspose.Slides for Java が必要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、ワークブックを XLS 形式で埋め込みます。チャートプレビュー画像は割り当てず、PowerPoint で OLE オブジェクトがアクティブ化されたときにチャートが表示されます。

例では、左端から 0.5 インチ、上端から 1 インチの位置に、サイズ 9.5 × 4 インチ (684 × 288 ポイント) の OLE フレームを持つ新しいプレゼンテーションを作成します。スライド座標と寸法はポイント単位 (1 インチ = 72 ポイント) です。既存のプレゼンテーションの場合は、[テンプレートの使用](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) を false に設定して、チャートの寸法をワークブックウィンドウから独立させます。[getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) の寸法は [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) と [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) で設定し、96 ピクセル/インチの換算でポイントからピクセルに変換します。たとえば、684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。[setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) を [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) の CUSTOM 値に設定します。例では [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) でワークブックを埋め込み、9.5 × 4 インチの OLE フレームを持つプレゼンテーションを保存します。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // スライドの座標と寸法はポイント単位です (1 インチ = 72 ポイント)。
        float width = 684f; // 9.5 インチ。
        float height = 288f; // 4 インチ。

        chart.setSizeWithWindow(false);
        // ポイントを 96 ピクセル/インチで換算してチャートのピクセルに変換します。
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **テンプレートの使用**

既存のプレゼンテーションでも同様のサイズロジックを使用します。例を適用する手順は次のとおりです。

1. 空のプレゼンテーションを作成する代わりにテンプレート プレゼンテーションをロードします。  
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。  
3. 固定値 684 と 288 の代わりに、そのシェイプからフレームの幅と高さを取得します。サイズ計算は変更しません。  
4. 固定座標 36 と 72 の代わりに、プレースホルダーの位置に OLE フレームを追加します。  
5. 保存する前にプレースホルダーを削除します。

## **よくある質問**

**PowerPoint でアクティブ化した後に埋め込んだ Excel チャートのサイズが変わるのはなぜですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクト フレームは独自のサイズを持ちます。PowerPoint と Excel がアスペクト比を保つためにサイズを協議するため、リサイズが発生します。

**チャートと OLE フレームのサイズを一致させるにはどうすればよいですか？**  
固定されたチャート寸法を OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に必要な設定と単位変換が示されています。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**  
ワークブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズ変更を確実に防止できません。例に示すように固定チャート寸法を使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。テンプレートを使用する場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**  
この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティブ化動作は示していません。

## **関連セクション**

- [プレゼンテーションに OLE オブジェクトとして埋め込む Excel チャートの作成](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)