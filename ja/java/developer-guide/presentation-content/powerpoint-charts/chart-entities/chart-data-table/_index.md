---
title: Java を使用してプレゼンテーションのチャート データテーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、罫線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for Java は、チャートのデータ テーブルを表示し、テキスト書式設定、罫線、凡例キーをカスタマイズできます。本記事では、テーブルの有効化、テキストの書式設定、各種罫線の制御、および凡例キーの表示/非表示方法を説明します。サンプルは、設定したチャートを PPTX ファイルに保存します。

## **フォントプロパティの設定**

チャートのデータ テーブルを表示するには、`true` を [setDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/#setDataTable-boolean-) に渡します。[getChartDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/#getChartDataTable--) を使用してテーブルにアクセスし、テキスト書式設定を構成します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. 最初のスライドにクラスター化された縦棒グラフを追加します。
3. チャートのデータ テーブルを有効にします。
4. [setFontBold](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) で太字テキストを有効にし、[setFontHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) に `20` を渡して 20 ポイントのテキストにします。
5. 変更されたプレゼンテーションを保存します。

次の例では、作業ディレクトリに少なくとも 1 枚のスライドがある `test.pptx` が必要です。デフォルト データのチャートを位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントで追加します。保存された `output.pptx` には、データ テーブルが有効化され、指定されたフォント設定が適用されたチャートが含まれます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **データ テーブル罫線のカスタマイズ**

[IChart.setDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDataTable-boolean-) でテーブルを有効にし、[IChart.getChartDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#getChartDataTable--) でアクセスします。3 種類の罫線を個別に制御できます。

- [setBorderHorizontal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) は水平セル罫線を制御します。
- [setBorderVertical](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) は垂直セル罫線を制御します。
- [setBorderOutline](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) はテーブルの外枠罫線を制御します。

`true` を各メソッドに渡すと罫線が表示され、`false` を渡すと非表示になります。次の例は、デフォルト データのクラスター化縦棒グラフを作成し、水平罫線と外枠罫線を表示し、垂直罫線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイント単位で指定されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は、4 つのケースすべてで同じチャート データと凡例キー設定を使用しています。すべての罫線が有効な状態から、各バリアントは 1 つの罫線設定だけを無効にします。左下のバリアントが例の罫線設定と一致します。

![すべての罫線が有効、水平罫線なし、垂直罫線なし、外枠罫線なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示または非表示**

凡例キーは、データテーブルの系列名の横に表示される小さな色付きマーカーです。各テーブル行とチャート系列を対応させるのに役立ちます。[setShowLegendKey](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) に `true` を渡すとこれらのマーカーが表示され、`false` を渡すと非表示になります。

チャートの別個の凡例は [IChart.setLegend](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setLegend-boolean-) で制御します。これらの設定は独立しており、別個の凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても別個の凡例は表示されたままです。

次の例は、デフォルト データのチャートを作成し、データテーブルを有効にして、別個の凡例を非表示にしながら内部の凡例キーを表示します。すべてのテーブル罫線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にするには、[setShowLegendKey](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) に `false` を渡します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は、凡例キーが有効な場合と無効な場合の同じテーブルを示します。すべての罫線は有効のままで、別個のチャート凡例は両方の場合で非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **よくある質問**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。凡例キーを表示するには [setShowLegendKey](https://reference.aspose.com/slides/ja/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) に `true` を渡し、非表示にするには `false` を渡します。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするときにデータテーブルは保持されますか？**

はい。Aspose.Slides は、エクスポート時にチャートと表示されたデータテーブルをスライドの一部として描画します。PDF は [PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、HTML は [HTML](/slides/ja/java/convert-powerpoint-to-html/)、画像は [画像](/slides/ja/java/convert-powerpoint-to-png/) にエクスポートできます。

**テンプレートから読み込んだチャートでデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込んだチャートについては、[hasDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/#hasDataTable--) と [setDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/#setDataTable-boolean--) を使用してデータテーブルの表示有無を確認または変更できます。

**データテーブルが有効になっているチャートを見つけるにはどうすればよいですか？**

各スライドのシェイプを走査し、チャートを特定して、[hasDataTable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/#hasDataTable--) メソッドを呼び出します。`true` の返値はデータテーブルが有効であることを示します。