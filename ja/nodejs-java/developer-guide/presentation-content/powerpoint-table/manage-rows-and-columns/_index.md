---
title: 行と列の管理
type: docs
weight: 20
url: /ja/nodejs-java/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPoint プレゼンテーション, Java, Node.js via Java 用 Aspose.Slides"
description: "JavaScript で PowerPoint プレゼンテーションのテーブルの行と列を管理する"
---

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) クラス、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) クラス、その他多数の型を提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) オブジェクトを作成し、null に設定します。  
4. すべての [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) オブジェクトを走査して対象のテーブルを見つけます。  
5. テーブルの最初の行をヘッダーとして設定します。  

この JavaScript コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // null の TableEx を初期化
    var tbl = null;
    // 形状を走査し、テーブルへの参照を設定
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // テーブルの最初の行をヘッダーとして設定
            tbl.setFirstRow(true);
        }
    }
    // プレゼンテーションをディスクに保存
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) メソッドを使用してスライドに [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) オブジェクトを追加します。  
6. テーブル行をクローンします。  
7. テーブル列をクローンします。  
8. 変更したプレゼンテーションを保存します。  

この JavaScript コードは、PowerPoint テーブルの行または列をクローンする方法を示しています:
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // 幅付き列と高さ付き行を定義
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // スライドにテーブルシェイプを追加
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 行 1 のセル 1 にテキストを追加
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // 行 1 のセル 2 にテキストを追加
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // テーブルの末尾に行 1 をクローン
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // 行 2 のセル 1 にテキストを追加
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // 行 2 のセル 2 にテキストを追加
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // テーブルの 4 行目として行 2 をクローン
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // 末尾に最初の列をクローン
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // 4 列目のインデックスに 2 番目の列をクローン
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // プレゼンテーションをディスクに保存
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) メソッドを使用してスライドに [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) オブジェクトを追加します。  
6. テーブル行を削除します。  
7. テーブル列を削除します。  
8. 変更したプレゼンテーションを保存します。  

この JavaScript コードは、テーブルから行または列を削除する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブル行レベルでテキスト書式を設定**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. 最初の行のセルに対して [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. 最初の行のセルに対して [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を設定します。  
6. 2 行目のセルに対して [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更したプレゼンテーションを保存します。  

この JavaScript コードは操作を示しています。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルであると想定します
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 最初の行のセルのフォント高さを設定
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // 最初の行のセルのテキスト配置と右余白を設定
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // 2 行目のセルのテキスト垂直方向タイプを設定
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // プレゼンテーションをディスクに保存
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブル列レベルでテキスト書式を設定**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. 最初の列のセルに対して [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. 最初の列のセルに対して [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を設定します。  
6. 2 列目のセルに対して [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更したプレゼンテーションを保存します。  

この JavaScript コードは操作を示しています:
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルであると想定します
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 最初の列のセルのフォント高さを設定
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // 最初の列のセルのテキスト配置と右余白を一度に設定
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // 2 列目のセルのテキスト垂直方向タイプを設定
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルスタイルプロパティを取得**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、その情報を別のテーブルや他の場所で利用できます。この JavaScript コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// デフォルトのスタイルプリセットテーマを変更する
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスタのテーマを継承しますが、テーマの上に塗りつぶし、枠線、テキストカラーを上書きすることも可能です。

**Excel のようにテーブル行を並べ替えることはできますか？**

できません。Aspose.Slides のテーブルには組み込みのソートやフィルター機能がありません。データをメモリ上で先にソートし、その順序でテーブル行を再配置してください。

**帯状（ストライプ）列を使用しつつ、特定のセルにカスタムカラーを保持できますか？**

はい。帯状列を有効にした上で、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。