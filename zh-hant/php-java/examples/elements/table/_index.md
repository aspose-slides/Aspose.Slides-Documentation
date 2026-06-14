---
title: 表格
type: docs
weight: 120
url: /zh-hant/php-java/examples/elements/table/
keywords:
- 表格
- 新增表格
- 存取表格
- 移除表格
- 合併儲存格
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中建立與格式化表格：插入資料、合併儲存格、設定邊框樣式、對齊內容，並支援 PPT、PPTX 與 ODP 的匯入/匯出。"
---
示範使用 **Aspose.Slides for PHP via Java** 來新增表格、存取表格、移除表格以及合併儲存格的範例。

## **Add a Table**
建立一個具有兩列兩欄的簡易表格。

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

## **Access a Table**
取得投影片上第一個表格形狀。

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個表格。
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

## **Remove a Table**
從投影片中刪除表格。

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設表格是投影片上的第一個形狀。
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Merge Table Cells**
將表格中相鄰的儲存格合併為單一儲存格。

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設表格是投影片上的第一個形狀。
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```