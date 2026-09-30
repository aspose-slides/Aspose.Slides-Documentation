---
title: PowerPoint テーブルの行と列を Android で管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/androidjava/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行の複製
- 列の複製
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行のテキスト書式設定
- 列のテキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---
## **導入**

Aspose.Slides for Android via Java を使用すると、PowerPoint プレゼンテーション内のテーブルの構造と書式設定を、[テーブル](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) クラスと [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) インターフェイスを介して管理できます。ヘッダー行を指定したり、行や列を複製・削除したり、行や列全体にテキストの書式設定を適用したりできます。

この記事では、これらの操作を Java の例とともに説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行と列のインデックスは 0 始まりです。

## **行の高さを制御する**

[IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) を使用して、行の最小高さ（ポイント単位）を設定します。これは下限であり、固定高さではありません。[IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) は実際の高さを返します。行は [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--) を介して取得します。

例では [row-height-input.pptx](row-height-input.pptx) を読み込みます。このファイルは最初のスライドの最初のシェイプとしてテーブルを含みます。最初の行は 70 ポイントから開始します。セルは 18 ポイントの Arial テキスト、折り返し、上下 6 ポイントの余白を使用し、2 列目の長いテキストは複数行に折り返されます。例では最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後に実際の高さを出力し、両方の結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

提供されたプレゼンテーションでは、最小値を増やすと行に余白が追加されます。最小値を減らすと余白は削除されますが、実際の高さはテキストとセル余白が必要とするスペースのため 20 ポイントより大きくなります。最小値だけを減らしても、コンテンツが必要とするスペース以下に行を縮めることはできません。

実際の高さに影響を与える要因は次のとおりです。

- **テキストとフォントサイズ:** 長いテキスト、明示的な改行、または大きなフォントは、より多くの垂直スペースを必要とします。
- **折り返しと列幅:** 折り返しが有効な場合、[IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) で列幅を狭めると行数が増えます。列幅を広げると垂直方向の必要スペースが減ります。
- **セル余白:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) と [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) は垂直余白を追加します。[ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) と [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) はテキストに利用できる幅を減らし、追加の折り返しを引き起こすことがあります。

結合セルのないこのテーブルでは、最も垂直スペースを必要とするセルが行全体の下限を決定します。行を短くするには、テキストを短くしたり、フォントサイズや余白を減らしたり、列幅を広げたりする必要があります。

以下の画像は同じテーブルを同一スケールで示しています。実際の高さはそれぞれ 70、100、55.2 ポイントで、最終行は 20 ポイントの最小値よりも高く残っています。フォント環境によりテキスト測定は若干異なる場合があります。保存された結果は [increased minimum](row-height-increased.pptx) と [decreased minimum](row-height-decreased.pptx) からダウンロードできます。

| 元: 最小 70 pt、実際 70 pt | 増加: 最小 100 pt、実際 100 pt | 減少: 最小 20 pt、実際 55.2 pt |
| --- | --- | --- |
| ![最初の行が 70 ポイントの元のテーブル。](row-height-before.png) | ![最初の行の最小高さを 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小高さを 20 ポイントに減らした後のテーブル；折り返しテキストにより行は最小値より高くなります。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定する**

[setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) メソッドを使用して、最初の行をヘッダー書式としてマークします。外観はテーブルに適用されたテーブルスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. 最初のスライドにアクセスします。
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスします。
4. 最初の行にヘッダー書式設定を有効にします。
5. 変更されたプレゼンテーションを保存します。

例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要です。最初の行にヘッダー書式設定を有効にし、`First_row_header.pptx` として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブル行または列を複製する**

行や列を複製して、コンテンツと書式を再利用できます。コピーをテーブルの末尾に追加することも、特定の位置に挿入することも可能です。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加します。
5. 必要な行を複製します。
6. 必要な列を複製します。
7. 変更されたプレゼンテーションを保存します。

例では、少なくとも 1 スライドがある `Test.pptx` が必要です。3 列 5 行のテーブルをポイント単位で作成し、最初の行と列のコピーを末尾に追加し、2 行目と列のコピーをインデックス 3（4 番目の位置）に挿入します。結果として 7 行 5 列のテーブルが得られます。`false` 引数は隣接する結合行や列への複製を無効にします。このテーブルには結合セルがありません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルから行または列を削除する**

不要になった行や列をテーブルから削除します。項目を削除すると、その後に続く行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを作成します。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加します。
5. 2 行目と 2 列目を削除します。
6. 変更されたプレゼンテーションを保存します。

この例では、3×3 のテーブルを作成し、インデックス 1 の行と列を削除して、`TestTable_out.pptx` に 2×2 のテーブルを残します。サイズはポイント単位です。`false` 引数は隣接する結合行や列の削除を無効にします。このテーブルには結合セルがありません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブル行レベルでテキスト書式を設定する**

行全体にテキスト書式を適用して、セル間の一貫性を保ちます。フォント属性、段落書式、テキスト方向を個々のセルを個別に設定せずに行えます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の行に対して [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を使用します。
4. 最初の行に対して [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用します。
5. 2 行目に対して [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。
6. 変更されたプレゼンテーションを保存します。

例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 行があります。最初の行に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 行目に縦書きテキストを設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブル列レベルでテキスト書式を設定する**

列全体にテキスト書式を適用して、セル間の一貫性を保ちます。フォント属性、段落書式、テキスト方向を個々のセルを個別に設定せずに行えます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の列に対して [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を使用します。
4. 最初の列に対して [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用します。
5. 2 列目に対して [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。
6. 変更されたプレゼンテーションを保存します。

例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 列があります。最初の列に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 列目に縦書きテキストを設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルスタイルプロパティを取得する**

[getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) メソッドを使用して、テーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これは、個々のセル書式オーバーライドではなく、プリセット自体を識別します。

例ではテーブルを作成し、[TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) を適用してからプリセットを取得します。`DarkStyle1` に対応する整数値を出力し、テーブルを `table.pptx` に保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**作成済みのテーブルに PowerPoint のテーマ／スタイルを適用できますか？**

はい。テーブルはスライド／レイアウト／マスターテーマを継承しますが、その上で塗りつぶし、枠線、テキストカラーなどを上書きすることが可能です。

**Excel のようにテーブル行をソートできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルター機能はありません。まずメモリ上でデータをソートし、その順序でテーブル行を再配置してください。

**特定のセルにカスタム色を保持しながら、帯状（ストライプ）列を設定できますか？**

はい。帯状列を有効にした上で、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。