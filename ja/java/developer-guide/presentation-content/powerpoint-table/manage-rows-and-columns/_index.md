---
title: PowerPoint テーブルで Java を使用して行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/java/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行のクローン
- 列のクローン
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行のテキスト書式設定
- 列のテキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集やデータ更新を高速化します。"
---
## **概要**

Aspose.Slides for Java は、PowerPoint プレゼンテーション内のテーブル構造と書式設定を [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) クラスおよび [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) インターフェイスを通じて管理できます。ヘッダー行を指定したり、行や列をクローンまたは削除したり、行または列全体にテキスト書式設定を適用したりできます。

この記事では、これらの操作を Java の例とともに解説します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行および列のインデックスはゼロベースです。

## **行の高さを制御する**

[IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) を使用して、行の最小高さ（ポイント単位）を設定します。これは下限であり、固定高さではありません。[IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) は実際の高さを返します。行は [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) を介して取得します。

例では [row-height-input.pptx](row-height-input.pptx) を読み込みます。このプレゼンテーションの最初のスライドの最初のシェイプはテーブルで、最初の行は 70 ポイントから始まります。セルは 18 ポイント Arial のテキスト、折り返し、上下 6 ポイントの余白を使用します。2 列目の長いテキストは複数行に折り返されます。例では最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後の実際の高さを出力し、両方の結果を保存します。

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

提供されたプレゼンテーションでは、最小高さを増やすと行に余白が追加されます。最小高さを減らすと余分なスペースは削除されますが、テキストとセルの余白が必要とする分だけ実際の高さは 20 ポイントより大きく残ります。最小高さだけを減らしても、コンテンツが必要とするスペース以下に行を強制することはできません。

実際の高さに影響する要因は次のとおりです：

- **テキストとフォントサイズ:** 長いテキスト、明示的な改行、または大きなフォントは、より多くの垂直スペースを必要とします。
- **折り返しと列幅:** 折り返しが有効な場合、[IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) で列幅を狭くすると行数が増えます。広い列は垂直スペースの必要量を減らすことがあります。
- **セル余白:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) と [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) は垂直余白を追加します。[ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) と [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) はテキストに利用できる幅を減らし、追加の折り返しを引き起こすことがあります。

結合セルがないこのテーブルでは、最も垂直スペースを必要とするセルが行全体のコンテンツ主導の下限を決定します。行を短くするには、テキストを短くしたり、フォントサイズや余白を縮小したり、列幅を広げる必要があります。

以下の画像は同じテーブルを同一スケールで示しています。実際の高さはそれぞれ 70、100、55.2 ポイントで、最終行は 20 ポイントの最小高さを下回っていません。フォント環境により正確な測定は変わることがあります。保存された結果は [increased minimum](row-height-increased.pptx) と [decreased minimum](row-height-decreased.pptx) からダウンロードできます。

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![70 ポイントの最初の行を持つ元のテーブル。](row-height-before.png) | ![最初の行の最小高さを 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小高さを 20 ポイントに減らした後のテーブル。折り返しテキストにより行は最小高さより高くなります。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定する**

[setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) メソッドを使用して、最初の行をヘッダー書式としてマークします。その外観はテーブルに適用されたテーブルスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを読み込みます。
2. 最初のスライドにアクセスします。
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスします。
4. 最初の行にヘッダー書式を有効にします。
5. 変更したプレゼンテーションを保存します。

例は最初のスライドの最初のシェイプがテーブルである `table.pptx` を必要とします。最初の行にヘッダー書式を有効にし、`First_row_header.pptx` として保存します。

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

## **テーブルの行または列をクローンする**

行や列をクローンして、コンテンツと書式設定を再利用できます。コピーをテーブルの末尾に追加することも、特定の位置に挿入することもできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを読み込みます。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加します。
5. 必要な行をクローンします。
6. 必要な列をクローンします。
7. 変更したプレゼンテーションを保存します。

例は少なくとも 1 枚のスライドがある `Test.pptx` を必要とします。3 列 5 行のテーブルをポイント単位で作成し、最初の行と列のコピーを末尾に追加し、2 行目と列のコピーをインデックス 3（4 つ目の位置）に挿入します。結果として 7 行 5 列のテーブルが生成されます。`false` 引数は隣接する結合行や列へのクローンを無効にします。このテーブルには結合セルはありません。

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

不要になったテーブルの行や列を削除します。アイテムを削除すると、後続の行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを作成します。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加します。
5. 2 行目と 2 列目を削除します。
6. 変更したプレゼンテーションを保存します。

この例は 3×3 のテーブルを作成し、インデックス 1 の行と列を削除して `TestTable_out.pptx` に 2×2 のテーブルとして保存します。サイズはポイント単位です。`false` 引数は隣接する結合行や列の削除を無効にします。このテーブルには結合セルはありません。

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

## **テーブル行レベルでテキスト書式設定を行う**

行全体にテキスト書式設定を適用して、セルの一貫性を保ちます。フォントプロパティ、段落書式、テキスト方向を個別のセルを設定せずに変更できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを読み込みます。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の行に対して [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) を使用します。
4. 最初の行に対して [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用します。
5. 2 行目に対して [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。
6. 変更したプレゼンテーションを保存します。

例は最初のシェイプがテーブルで、少なくとも 2 行ある `table.pptx` を必要とします。最初の行に 25 ポイントのテキスト、右寄せ、右段落余白 20 ポイントを適用し、2 行目に垂直テキストを設定します。

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

## **テーブル列レベルでテキスト書式設定を行う**

列全体にテキスト書式設定を適用して、セルの一貫性を保ちます。フォントプロパティ、段落書式、テキスト方向を個別のセルを設定せずに変更できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを読み込みます。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の列に対して [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) を使用します。
4. 最初の列に対して [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用します。
5. 2 列目に対して [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。
6. 変更したプレゼンテーションを保存します。

例は最初のシェイプがテーブルで、少なくとも 2 列ある `table.pptx` を必要とします。最初の列に 25 ポイントのテキスト、右寄せ、右段落余白 20 ポイントを適用し、2 列目に垂直テキストを設定します。

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

## **テーブルスタイルプロパティの取得**

[getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) メソッドを使用してテーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これにより、個々のセルの書式オーバーライドではなく、プリセット自体が識別されます。

例はテーブルを作成し、[TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) を適用してからプリセットを読み取ります。`DarkStyle1` に対応する整数値を出力し、テーブルを `table.pptx` に保存します。

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

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスタのテーマを継承しますが、その上で塗りつぶし、枠線、テキスト色を個別に上書きすることが可能です。

**Excel のようにテーブル行を並べ替えることはできますか？**

できません。Aspose.Slides のテーブルには組み込みのソートやフィルタ機能はありません。データをメモリ内でソートしてから、その順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、帯状（ストライプ）列を設定できますか？**

はい。帯状列を有効にした後、ローカル書式で特定のセルを上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。