---
title: Excel チャートを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 30
url: /ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャートを埋め込む
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Cells for Java を使用して Excel チャートを作成し、Aspose.Slides を使用して PowerPoint プレゼンテーションにブックを埋め込み、チャートのプレビューを含めます。"
---
## **概要**

このドキュメントでは、Aspose.Cells for Java を使用して Excel の縦棒グラフを作成し、Aspose.Slides for Java を使用してそのブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたブックにはソース データとグラフの両方が含まれます。別の PNG プレビューが、OLE オブジェクトが有効になる前にスライド上にグラフを表示します。

結果はネイティブな PowerPoint グラフではなく、埋め込まれた Excel オブジェクトです。OLE を介してブックを編集するには、OLE の有効化をサポートするデスクトップ アプリケーションと、互換性のある Excel のインストールが必要です。

## **前提条件**

プロジェクトの依存関係に Aspose.Cells for Java と Aspose.Slides for Java を追加します。例は Java メソッド内で実行してください。このライブラリを使用してプレゼンテーションを生成する際に Microsoft Office は不要です。

入力ファイルは必要ありません: 例はメモリ内でデータとグラフを作成し、`OutputChart.pptx` を現在の作業ディレクトリに書き出します。評価モード外で実行する場合は、両方の製品に対してライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つワークブックを作成します。
1. チャート シートをアクティブにして、ワークブックがチャート上で開くようにします。
1. ワークブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
1. ワークブックをメモリ内で XLSX として保存し、そのバイト列をスライドに埋め込みます。
1. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ワークブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) はゼロベースの開始/終了行と列のインデックスを受け取ります。[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) は代わりに上端行、左端列、下端行、右端列を受け取ります。例では下端の境界として行インデックス 55、列インデックス 25 を使用しています。これらの値はレイアウト上の選択であり、データ行や列の数を表すものではありません。

スライドのフレームはポイント単位です。例ではスライド内に収まるようにサイズ調整し、PNG のアスペクト比を維持したまま中央に配置しています。プレビューをスライド全体に引き伸ばすことはありません。

## **チャートの作成と埋め込み**

以下の完全なサンプルは、`DataSheet` に 4 行 5 列の値を設定します。各行がチャート系列になります。`ChartSheet` をアクティブ シートとして選択した後にワークブックを保存します。

ワークブックは明示的に XLSX として保存され、`xlsx` 拡張子が [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) に渡されたものと一致します。PNG は中間のビットマップ変換を行わずにバイト列から直接ロードされます。[getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を通じて割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

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

        // チャートのプレビューをレンダリングし、編集可能なワークブックを別々にシリアライズします。
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

                // プレビューをアスペクト比を変更せずにスライド内に合わせます。
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
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
```

## **期待される結果**

`OutputChart.pptx` には埋め込まれた Excel ワークブックとチャート プレビューを含む 1 枚のスライドが含まれます。ワークブックには元のデータと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中心に配置され、比例が維持されています。

![Excel の縦棒グラフが埋め込みブックのプレビューとして表示されます](excel-chart-ole-preview.png)

Excel が利用できる互換性のあるデスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして OLE を有効化し、埋め込まれたワークブックを編集できます。アクティベーションと編集はホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **FAQ**

**プレビュー画像が必要な理由は何ですか？**  
埋め込まれたワークブックとスライドのプレビューは別々のコンテンツです。チャート画像を提供することで、スライドにデフォルトの「EMBEDDED OLE OBJECT」プレースホルダーではなくチャートが表示されます。詳細は[Object Preview Issue when Adding OleObjectFrame](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/)をご覧ください。

**コードでワークブックを変更した場合、プレビューは自動的に更新されますか？**  
プレビューはスナップショットとして扱われます。プログラムでワークブック データを更新した場合は、チャート画像を再生成し、プレビューと埋め込みワークブック データの両方を置き換える必要があります。

**XLS ではなく XLSX を使用できますか？**  
はい。ワークブックを XLS 形式で保存し、埋め込みデータ拡張子として `xls` を使用できます。拡張子は実際のワークブック形式と一致する必要があり、拡張子だけを変更してもデータは変換されません。

**オブジェクトがアクティベート後にサイズが変わることがありますか？**  
ホスト アプリケーションは、ワークブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ワークブックの OLE 表示範囲とスライド フレームの寸法の両方が影響します。詳しくは[Working Solution for Chart Resizing in PPTX](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)をご参照ください。

## **関連セクション**

- [Working Solution for Chart Resizing in PPTX](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)