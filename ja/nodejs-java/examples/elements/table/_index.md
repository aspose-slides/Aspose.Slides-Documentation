---
title: テーブル
type: docs
weight: 120
url: /ja/nodejs-java/examples/elements/table/
keywords:
- コード例
- テーブル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でテーブルを操作します：作成、書式設定、セルの結合、スタイルの適用、データのインポート、そして PPT、PPTX、ODP の例を使用したエクスポート。"
---
**Aspose.Slides for Node.js via Java** を使用したテーブルの追加、アクセス、削除、セル結合の例。

## **テーブルの追加**

2 行 2 列のシンプルなテーブルを作成します。

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **テーブルへのアクセス**

スライドから最初のテーブル シェイプを取得します。

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // スライド上の最初のテーブルにアクセスします。
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **テーブルの削除**

スライドからテーブルを削除します。

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがテーブルであると想定します。
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **テーブルセルの結合**

テーブルの隣接セルを単一セルに結合します。

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがテーブルであると想定します。
        let table = slide.getShapes().get_Item(0);

        // セルを結合します。
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```