---
title: テーブルの管理
type: docs
weight: 10
url: /ja/java/manage-table/
keywords: "テーブル、テーブルの作成、テーブルへのアクセス、テーブルのアスペクト比、PowerPointプレゼンテーション、Java、Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションのテーブルを作成および管理する"
---

PowerPointでのテーブルは、情報を表示し、表現するための効率的な方法です。セルのグリッド内の情報（行と列に配置）は、簡潔で理解しやすいです。

Aspose.Slidesは、[Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table)クラス、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)インターフェース、[Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)クラス、[ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)インターフェース、その他の型を提供し、さまざまなプレゼンテーションでテーブルを作成、更新、管理することを可能にします。

## **ゼロからテーブルを作成する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトをスライドに追加します。これは[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)メソッドを使用します。
6. 各[ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)を反復処理して、上、下、右、左の境界にフォーマットを適用します。
7. テーブルの最初の行の最初の2つのセルをマージします。
8. [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)の[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)にアクセスします。
9. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)にテキストを追加します。
10. 修正されたプレゼンテーションを保存します。

このJavaコードは、プレゼンテーションにテーブルを作成する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅のある列と高さのある行を定義
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界フォーマットを設定
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 行1のセル1 & 2をマージ
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // マージされたセルにテキストを追加
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("マージされたセル");

    // プレゼンテーションをディスクに保存
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けは簡単でゼロベースです。テーブル内の最初のセルは0,0（列0、行0）としてインデックス付けされています。

たとえば、4列4行のテーブルのセルは次のように番号付けされています：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

このJavaコードは、テーブル内のセルに番号付けを指定する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅のある列と高さのある行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界フォーマットを設定
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。

2. インデックスを通じてテーブルを含むスライドへの参照を取得します。

3. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを作成し、nullに設定します。

4. テーブルが見つかるまで、すべての[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)オブジェクトを反復処理します。

   スライドに単一のテーブルが含まれていると疑う場合は、その形状をすべて確認するだけで済みます。形状がテーブルと識別された場合、[Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table)オブジェクトとしてキャストできます。しかし、あなたが扱っているスライドに複数のテーブルが含まれている場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-)を通じて必要なテーブルを検索する方が良いでしょう。

5. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを使用してテーブルで作業します。以下の例では、テーブルに新しい行を追加しました。

6. 修正されたプレゼンテーションを保存します。

このJavaコードは、既存のテーブルにアクセスして作業する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // nullのTableExを初期化
    ITable tbl = null;

    // 形状を反復処理し、見つかったテーブルへの参照を設定
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 2行目の最初の列のテキストを設定
            tbl.get_Item(0, 1).getTextFrame().setText("新しい");
        }
    }
    
    // 修正されたプレゼンテーションをディスクに保存
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブル内のテキストを整列させる**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを追加します。
4. テーブルから[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)オブジェクトにアクセスします。
5. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)の[IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)にアクセスします。
6. テキストを垂直整列します。
7. 修正されたプレゼンテーションを保存します。

このJavaコードは、テーブル内のテキストを整列させる方法を示しています：

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 幅のある列と高さのある行を定義
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // スライドにテーブル形状を追加
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // テキストフレームのためのParagraphオブジェクトを作成
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用のPortionオブジェクトを作成
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("ここにテキスト");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // テキストを垂直に整列
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // プレゼンテーションをディスクに保存
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルレベルでのテキストフォーマットの設定**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドから[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトにアクセスします。
4. テキストのフォントの高さを[setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)で設定します。
5. [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)と[setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)を設定します。
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正されたプレゼンテーションを保存します。

このJavaコードは、テーブル内のテキストに好みのフォーマットオプションを適用する方法を示しています：

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 最初のスライドの最初の形状がテーブルであると仮定
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // テーブルのセルのフォント高さを設定
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // テーブルのセルのテキスト整列と右マージンを1回の呼び出しで設定
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // テーブルのセルのテキストの垂直タイプを設定
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得して、別のテーブルや他の場所でその詳細を使用できます。このJavaコードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // デフォルトのスタイルプリセットテーマを変更
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slidesは、テーブルや他の形状のアスペクト比設定をロックできる[**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)プロパティを提供しています。

このJavaコードは、テーブルのアスペクト比をロックする方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("アスペクト比ロック設定: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // 反転

    System.out.println("アスペクト比ロック設定: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```