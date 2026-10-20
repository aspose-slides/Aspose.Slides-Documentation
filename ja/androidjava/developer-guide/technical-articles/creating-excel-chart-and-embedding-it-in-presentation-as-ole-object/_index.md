---
title: Excel チャートを作成し、プレゼンテーションに OLE オブジェクトとして埋め込む
type: docs
weight: 30
url: /ja/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャート埋め込み
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Cells for Android (Java)で Excel チャートを作成し、Aspose.Slides for Android (Java)でブックを PowerPoint プレゼンテーションに埋め込み、チャートのプレビューを含めます。"
---
## **概要**

この記事では、Java 経由で Android 用 Aspose.Cells を使用して Excel の縦棒グラフを作成し、そのブックを Android 用 Aspose.Slides を使用して PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたブックには元データとグラフの両方が含まれます。OLE オブジェクトがアクティブになる前に、スライド上にグラフを表示する PNG プレビューが別途表示されます。

結果として得られるのはネイティブな PowerPoint グラフではなく、埋め込み Excel オブジェクトです。OLE 経由でブックを編集するには、OLE のアクティベーションに対応したデスクトップアプリケーションと、対応する Excel のインストールが必要です。

## **前提条件**

プロジェクトの依存関係に Android 用 Aspose.Cells (Java) と Android 用 Aspose.Slides (Java) を追加します。Android アクティビティから `ExcelChartEmbedding.createPresentation(getFilesDir())` を呼び出します。これらのライブラリを使用してプレゼンテーションを生成するために Microsoft Office は必要ありません。

入力ファイルは不要です。サンプルはメモリ上でデータとチャートを作成し、`OutputChart.pptx` をアプリケーションの内部ファイルディレクトリに書き込みます。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つブックを作成します。
2. チャート シートをアクティブにして、ブックがチャート上で開くようにします。
3. ブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ブックをメモリ上で XLSX として保存し、そのバイト列をスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ブックの表示範囲とスライド上のフレームは別々の役割を持ちます。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) は 0 基数の開始/終了行と列のインデックスを受け取ります。[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) は代わりに上端行、左端列、下端行、右端列を受け取ります。サンプルは下右境界として行インデックス 55 と列インデックス 25 を使用していますが、これらの値はレイアウト上の選択であり、データ行や列の数を示すものではありません。

スライドのフレームはポイント単位です。サンプルはスライド内に収めてセンタリングし、PNG のアスペクト比を保持したままプレビューを伸ばさずに配置します。

## **チャートの作成と埋め込み**

以下の完全なサンプルは `DataSheet` に 4 行 5 列の値を設定します。各行がチャートの系列になります。ブックを保存する前に `ChartSheet` をアクティブ シートとして選択します。

ブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/) に渡された `xlsx` 拡張子に一致します。PNG は中間のビットマップ変換を行わずにバイト列から直接読み込まれます。[getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を通じて割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // チャートのプレビューをレンダリングし、編集可能なブックを別々にシリアライズします。
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // アスペクト比を変更せずにプレビューをスライド内に収めます。
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```

## **期待される結果**

`OutputChart.pptx` には埋め込み Excel ブックとチャート プレビューを含む 1 枚のスライドが含まれます。ブックには元データと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比例を維持します。

![埋め込みブックのプレビューとして表示される Excel の縦棒グラフ](excel-chart-ole-preview.png)

互換性のあるデスクトップ版 PowerPoint 環境で Excel が利用可能な場合、オブジェクトをダブルクリックしてアクティブ化し、埋め込みブックを編集できます。アクティブ化と編集はホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **FAQ**

**プレビュー画像が必要な理由は何ですか？**

埋め込みブックとスライドのプレビューは別々のコンテンツです。チャート画像を提供することで、スライドにデフォルトの "EMBEDDED OLE OBJECT" プレースホルダーの代わりにチャートが表示されます。[Object Preview Issue when Adding OleObjectFrame](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/) を参照してください。

**コードでブックを変更したときにプレビューは自動的に更新されますか？**

プレビューはスナップショットとして扱います。プログラムでブックのデータを更新する場合は、チャート画像を再生成し、プレビューと埋め込みブックのデータの両方を置き換える必要があります。

**XLS を使用できますか？（XLSX の代わりに）**

はい。ブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のブック形式と一致している必要があり、拡張子だけを変更してもデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わるのはなぜですか？**

ホストアプリケーションはブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ブックの OLE 表示範囲とスライドフレームのサイズの両方が影響します。[Working Solution for Worksheet Resizing](/slides/ja/androidjava/working-solution-for-worksheet-resizing/) を参照してください。

## **関連セクション**

- [ワークシートのサイズ変更に関する実用的な解決策](/slides/ja/androidjava/working-solution-for-worksheet-resizing/)
- [OleObjectFrame を追加する際のオブジェクト プレビュー問題](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [OLE の管理](/slides/ja/androidjava/manage-ole/)