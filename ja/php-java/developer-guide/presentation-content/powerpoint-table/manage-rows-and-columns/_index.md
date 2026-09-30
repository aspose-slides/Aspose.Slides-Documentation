---
title: PHP を使用して PowerPoint テーブルの行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/php-java/manage-rows-and-columns/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---
## **概要**

Aspose.Slides for PHP via Java を使用すると、PowerPoint プレゼンテーション内のテーブル構造と書式設定を [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラスで管理できます。ヘッダー行を指定したり、行や列をクローンまたは削除したり、行や列全体にテキスト書式を適用したりできます。

この記事では、これらの操作を PHP の例とともに説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行と列のインデックスは 0 から始まります。

## **行の高さを制御する**

行の最小高さ（ポイント）を設定するには [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) を使用します。これは下限であり、固定高さではありません。[Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) は実際の高さを返します。行は [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) を介して取得します。

この例は [row-height-input.pptx](row-height-input.pptx) を読み込みます。このプレゼンテーションの最初のスライドの最初のシェイプとしてテーブルが配置されています。最初の行は 70 ポイントから始まります。セルは 18 ポイント Arial テキスト、折り返し、上下マージン 6 ポイントで設定されています。2 列目の長いテキストは複数行に折り返されます。この例では最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後に実際の高さを出力し、両方の結果を保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

提供されたプレゼンテーションでは、最小高さを増やすと行に余白が追加されます。最小高さを減らすと余分なスペースが削除されますが、テキストとセルのマージンが必要とするため、実際の高さは 20 ポイントより大きくなります。最小高さを下げるだけでは、コンテンツが必要とするスペース以下に行を強制することはできません。

実際の高さに影響する要因は次のとおりです：

- **テキストとフォントサイズ:** 長いテキストや明示的な改行、または大きなフォントは垂直方向のスペースが必要になります。
- **折り返しと列幅:** 折り返しが有効な場合、[Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) で列幅を狭くすると行数が増え、垂直方向のスペースが増えます。列幅を広くすると垂直方向の必要スペースが減ります。
- **セルの余白:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) と [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) は垂直方向の余白を追加します。[Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) と [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) はテキストに使用できる幅を減らし、折り返しが増える原因となります。

結合セルのないこのテーブルでは、最も垂直スペースを必要とするセルが行全体のコンテンツ主導の下限を決定します。行を短くするには、テキストを短くしたり、フォントサイズや余白を減らしたり、列幅を広げる必要があります。

以下の画像は、同じスケールで同一テーブルを示しています。示された結果では、実際の高さはそれぞれ 70、100、55.2 ポイントでした。最終的な行は 20 ポイントの最小値よりも高くなっています。テキストの正確な測定値は環境にインストールされているフォントにより異なることがあります。保存された結果をダウンロードしてください: [increased minimum](row-height-increased.pptx) と [decreased minimum](row-height-decreased.pptx)。

| オリジナル: 最小 70 pt、実際 70 pt | 増加: 最小 100 pt、実際 100 pt | 減少: 最小 20 pt、実際 55.2 pt |
| --- | --- | --- |
| ![最初の行が 70 ポイントのオリジナルテーブル。](row-height-before.png) | ![最初の行の最小値を 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小値を 20 ポイントに減らした後のテーブル; 折り返しテキストにより行は最小値よりも高くなります。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定する**

[setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) メソッドを使用して、最初の行をヘッダー書式としてマークします。その外観はテーブルに適用されたテーブルスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドにアクセスする。
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスする。
4. その最初の行のヘッダー書式を有効にする。
5. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要です。最初の行のヘッダー書式を有効にし、`First_row_header.pptx` として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル行または列をクローンする**

行や列をクローンして、内容と書式設定を再利用できます。コピーをテーブルの末尾に追加したり、特定の位置に挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドにアクセスする。
3. 列幅と行高さを定義する。
4. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドでテーブルを追加する。
5. 必要な行をクローンする。
6. 必要な列をクローンする。
7. 変更したプレゼンテーションを保存する。

この例では、少なくとも 1 枚のスライドがある `Test.pptx` が必要です。3 列 5 行のテーブルを、ポイントで指定した寸法で作成します。最初の行と列のコピーを末尾に追加し、2 行目と列をインデックス 3（4 番目の位置）に挿入します。結果としてテーブルは 7 行 5 列になります。`false` 引数は隣接する結合行や列へのクローンを無効にします。このテーブルには結合セルがありません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルから行または列を削除する**

テーブルで不要になった行や列を削除します。アイテムを削除すると、以降の行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを作成する。
2. 最初のスライドにアクセスする。
3. 列幅と行高さを定義する。
4. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドでテーブルを追加する。
5. 2 番目の行と 2 番目の列を削除する。
6. 変更したプレゼンテーションを保存する。

この例では、3×3 のテーブルを作成し、インデックス 1 の行と列を削除して、`TestTable_out.pptx` に 2×2 のテーブルを残します。寸法はポイントで指定されています。`false` 引数は隣接する結合行や列の削除を無効にします。このテーブルには結合セルがありません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル行レベルでテキスト書式を設定する**

行全体にテキスト書式を適用してセルの一貫性を保ちます。各セルを個別に書式設定することなく、フォント属性、段落書式、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライド上のテーブルにアクセスする。
3. 最初の行に対して [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を使用する。
4. 最初の行に対して [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を使用する。
5. 2 行目に対して [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を使用する。
6. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 行が存在します。最初の行に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 行目に縦書きテキストを設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル列レベルでテキスト書式を設定する**

列全体にテキスト書式を適用してセルの一貫性を保ちます。各セルを個別に書式設定することなく、フォント属性、段落書式、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライド上のテーブルにアクセスする。
3. 最初の列に対して [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を使用する。
4. 最初の列に対して [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を使用する。
5. 2 列目に対して [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を使用する。
6. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 列が存在します。最初の列に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 列目に縦書きテキストを設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルスタイルプロパティを取得する**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) メソッドを使用してテーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これにより、個々のセル書式のオーバーライドではなく、プリセット自体が識別されます。

この例ではテーブルを作成し、[TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) を適用してプリセットを取得します。`DarkStyle1` に対応する整数値を出力し、テーブルを `table.pptx` に保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承し、必要に応じて塗りつぶし、枠線、テキストカラーを上書きすることができます。

**Excel のようにテーブル行を並べ替えることはできますか？**

いいえ、Aspose.Slides のテーブルには組み込みの並べ替えやフィルター機能はありません。データをメモリ上で先に並べ替えてから、目的の順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、帯状（ストライプ）列を設定できますか？**

はい。帯状列を有効にした上で、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。