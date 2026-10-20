---
title: PPTX のチャートリサイズに対する実装ソリューション
type: docs
weight: 40
url: /ja/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して埋め込まれた Excel OLE オブジェクトを利用する際に、PPTX で発生する予期しないチャートリサイズを修正します。固定チャート寸法を設定して、チャートと OLE フレームのサイズを一貫させます。"
---
## **概要**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込んだ Excel グラフは、最初にアクティブ化した後にサイズが変わることがあります。これにより、アクティブ化前後でグラフの見た目に目立つ差が生じます。本記事ではサイズ変更が発生する理由を解説し、固定チャートサイズを OLE フレームに合わせることでそれを防ぐ方法を示します。

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Android via Java を使用して Excel グラフを作成し、Aspose.Slides for Android via Java で PowerPoint に埋め込む方法を説明しました。[object preview issue](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/) に対応するため、グラフ画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、グラフ画像が表示された OLE オブジェクトフレームをダブルクリックすると Excel グラフがアクティブ化されます。ユーザーは埋め込まれた Excel ワークブックを編集し、編集後はアクティブ化されたワークブックの外側をクリックしてスライドに戻ります。スライドに戻った際に OLE オブジェクトフレームのサイズが変わり、リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

埋め込まれた Excel ワークブックには独自のウィンドウサイズがあり、オブジェクトが最初にアクティブ化されたときに Excel がそのサイズを保持しようとします。一方、スライド上の OLE フレームは別途定義されたサイズを持ちます。Excel ワークブックがアクティブ化されると、Excel と PowerPoint がオブジェクトのサイズを交渉し、埋め込みプロセスの一環として縦横比を維持しようとします。ワークブックウィンドウと OLE フレームのサイズ差がオブジェクトのリサイズを引き起こす原因となります。

## **動作するソリューション**

チャートのサイズをスライド上の OLE フレームに合わせ、チャートサイズをワークブックウィンドウとは独立させます。このソリューションは新規プレゼンテーションでも既存テンプレートでも機能します。

この例は Aspose.Cells for Android via Java と Aspose.Slides for Android via Java が必要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、XLS 形式でワークブックを埋め込みます。Android アクティビティから `FixedChartSize.createPresentation(getFilesDir())` を呼び出すと、出力がアプリの内部ファイルディレクトリに保存されます。OLE のアクティベーションにはデスクトップ版 PowerPoint と互換性のある Excel のインストールが必要です。プレビュー画像は割り当てず、OLE オブジェクトが PowerPoint でアクティブ化されたときにチャートが表示されます。

例では、左端から 0.5 インチ、上端から 1 インチの位置に 9.5 × 4 インチの OLE フレームを配置した新規プレゼンテーションを作成します。スライド座標とサイズはポイント単位（1 インチ＝72 ポイント）です。既存プレゼンテーションの場合は、[Use a Template](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) を false に設定し、チャートサイズをワークブックウィンドウから独立させます。 [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) のサイズは、[setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) と [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) で設定し、ポイントを 96 ピクセル/インチでピクセルに変換します。たとえば 684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。 [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) を [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) の CUSTOM 値に設定します。例では [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) を使用してワークブックを埋め込み、9.5 × 4 インチの OLE フレーム付きプレゼンテーションを保存します。

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // スライドの座標と寸法はポイント単位です (1インチ＝72ポイント)。
                    float width = 684f; // 9.5 インチ。
                    float height = 288f; // 4 インチ。

                    chart.setSizeWithWindow(false);
                    // ポイントを 96 ピクセル/インチでチャートのピクセルに変換します。
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **テンプレートの使用**

既存プレゼンテーションでも同様のサイズロジックが適用されます。例を適合させる手順は以下の通りです。

1. 空のプレゼンテーションを作成する代わりにテンプレートプレゼンテーションを読み込みます。  
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。  
3. 固定値 684 と 288 の代わりにそのシェイプからフレームの幅と高さを取得します。サイズ計算は変更しません。  
4. 固定座標 36 と 72 の代わりにプレースホルダーの位置に OLE フレームを追加します。  
5. 保存前にプレースホルダーを削除します。

## **よくある質問**

**埋め込んだ Excel グラフは、PowerPoint でアクティブ化した後にサイズが変わるのはなぜですか？**

最初にアクティブ化されたときに Excel が元のウィンドウサイズを復元しようとする一方、PowerPoint の OLE オブジェクトフレームは独自のサイズを持っているためです。PowerPoint と Excel がサイズを交渉してアスペクト比を維持しようとする結果、リサイズが発生します。

**チャートと OLE フレームのサイズを一貫させるにはどうすればよいですか？**

固定チャートサイズを OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に示した設定と単位変換を参照してください。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**

ワークブックウィンドウのサイズだけを合わせても、アクティブ化後に OLE フレームがサイズ変更する問題を確実に防げません。例にあるように固定チャートサイズを使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。テンプレートを使用する場合はプレースホルダーのサイズと位置を利用し、新規プレゼンテーションの場合はフレームのサイズと位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**

この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティベーション動作は示していません。

## **関連セクション**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)