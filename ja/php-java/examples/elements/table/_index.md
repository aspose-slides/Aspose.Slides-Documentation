---
title: テーブル
type: docs
weight: 120
url: /ja/php-java/examples/elements/table/
keywords:
- テーブル
- テーブルを追加
- テーブルにアクセス
- テーブルを削除
- セルを結合
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でテーブルを作成および書式設定します。データの挿入、セルの結合、枠線のスタイル設定、内容の配置、そして PPT、PPTX、ODP のインポート/エクスポートが可能です。"
---
**Aspose.Slides for PHP via Java** を使用して、テーブルの追加、アクセス、削除、セルの結合の例です。

## **テーブルの追加**

2 行 2 列のシンプルなテーブルを作成します。

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **テーブルにアクセス**

スライド上の最初のテーブルシェイプを取得します。

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のテーブルにアクセスします。
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **テーブルの削除**

スライドからテーブルを削除します。

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // テーブルがスライド上の最初のシェイプであると想定します。
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **テーブルセルの結合**

テーブルの隣接するセルを 1 つのセルに結合します。

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // テーブルがスライド上の最初のシェイプであると想定します。
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```