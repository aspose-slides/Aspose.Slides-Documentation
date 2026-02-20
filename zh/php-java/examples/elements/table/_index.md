---
title: 表格
type: docs
weight: 120
url: /zh/php-java/examples/elements/table/
keywords:
- 表格
- 添加表格
- 访问表格
- 删除表格
- 合并单元格
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 创建和格式化表格：插入数据、合并单元格、设置边框样式、对齐内容，并支持 PPT、PPTX 和 ODP 的导入/导出。"
---
使用 **Aspose.Slides for PHP via Java** 添加表格、访问表格、删除表格以及合并单元格的示例。

## **添加表格**

创建一个包含两行两列的简单表格。

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

## **访问表格**

检索幻灯片上的第一个表格形状。

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个表格。
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

## **删除表格**

从幻灯片中删除表格。

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设该表格是幻灯片上的第一个形状。
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **合并表格单元格**

将表格相邻的单元格合并为一个单元格。

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设该表格是幻灯片上的第一个形状。
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```