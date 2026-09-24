---
title: Android のプレゼンテーションにおけるチャート データテーブルのカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/androidjava/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、罫線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for Android via Java を使用すると、チャートのデータテーブルを表示し、テキストの書式設定、罫線、凡例キーをカスタマイズできます。本記事では、テーブルの有効化、テキストの書式設定、各種罫線の制御、および凡例キーの表示/非表示方法について説明します。サンプルでは、設定したチャートを PPTX ファイルに保存します。

## **フォントプロパティの設定**

チャートのデータテーブルを表示するには、`true` を [setDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) に渡します。[getChartDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/#getChartDataTable--) を使用してテーブルにアクセスし、テキストの書式設定を構成します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. 最初のスライドにクラスター化された縦棒グラフを追加します。
3. チャートのデータテーブルを有効にします。
4. [setFontBold](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) で太字テキストを有効にし、20 ポイントのテキストにするために [setFontHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) に `20` を渡します。
5. 変更したプレゼンテーションを保存します。

以下の例は、作業ディレクトリに少なくとも 1 枚のスライドが含まれる `test.pptx` が必要です。位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定したフォント設定が適用されたチャートが含まれます。

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

## **データテーブル罫線のカスタマイズ**

[IChart.setDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) でテーブルを有効にし、[IChart.getChartDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#getChartDataTable--) でアクセスします。3 種類の罫線を個別に制御できます。

- [setBorderHorizontal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) は水平セル罫線を制御します。
- [setBorderVertical](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) は垂直セル罫線を制御します。
- [setBorderOutline](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) はテーブルの外枠罫線を制御します。

各メソッドに `true` を渡すと罫線が表示され、`false` を渡すと非表示になります。以下の例は、デフォルト データのクラスター化縦棒グラフを作成し、水平罫線と外枠罫線を表示し、垂直罫線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイント単位で指定されます。

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

以下の比較では、4 つのケースすべてで同じチャートデータと凡例キー設定を使用しています。すべての罫線が有効な状態から始め、残りの各バリエーションは 1 つの罫線設定だけを無効にしています。左下のバリエーションが例の罫線設定と一致します。

![すべての罫線が有効、水平罫線なし、垂直罫線なし、外枠罫線なしのチャートデータテーブル](data-table-borders.png)

## **凡例キーの表示/非表示**

凡例キーは、データテーブルの系列名の横に表示される小さな色付きマーカーです。各テーブル行とチャート系列を対応させるのに役立ちます。[setShowLegendKey](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) に `true` を渡すとこれらのマーカーが表示され、`false` を渡すと非表示になります。

チャートの別個の凡例は [IChart.setLegend](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) で制御します。これらの設定は独立しています。別個の凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても別個の凡例は非表示になりません。

以下の例は、デフォルト データのチャートを作成し、データテーブルを有効にし、別個の凡例を非表示にしたままテーブル内に凡例キーを表示します。すべてのテーブル罫線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にするには、[setShowLegendKey](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) に `false` を渡します。

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

以下の比較では、凡例キーを有効にした状態と無効にした状態の同じテーブルを示しています。すべての罫線は有効なままで、別個のチャート凡例は両方のケースで非表示です。

![左側に凡例キーが表示され、右側に非表示のチャートデータテーブル](data-table-legend-keys.png)

## **FAQ**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。凡例キーを表示するには [setShowLegendKey](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) に `true` を、非表示にするには `false` を渡します。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするときにデータテーブルは保持されますか？**

はい。Aspose.Slides は、エクスポート時にチャートと表示されたデータテーブルをスライドの一部としてレンダリングします。PDF は [PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、HTML は [HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、画像は [images](/slides/ja/androidjava/convert-powerpoint-to-png/) にエクスポートできます。

**テンプレートからロードしたチャートでデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードしたチャートについては、[hasDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/#hasDataTable--) と [setDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) を使用して、データテーブルが表示されているかどうかを確認または変更できます。

**データテーブルが有効なチャートをどうやって見つけますか？**

各スライドのシェイプを走査し、チャートを特定してその [hasDataTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/#hasDataTable--) メソッドを呼び出します。`true` が返されれば、データテーブルが有効です。