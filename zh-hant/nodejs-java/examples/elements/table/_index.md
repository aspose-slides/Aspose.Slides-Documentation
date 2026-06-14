---
title: 表格
type: docs
weight: 120
url: /zh-hant/nodejs-java/examples/elements/table/
keywords:
- 程式碼範例
- 表格
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用表格：建立、格式化、合併儲存格、套用樣式、匯入資料，並提供 PPT、PPTX 與 ODP 的範例，進行匯出。"
---
使用 **Aspose.Slides for Node.js via Java** 添加表格、存取表格、刪除表格以及合併儲存格的範例。

## **新增表格**

建立一個包含兩列兩欄的簡易表格。

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

## **存取表格**

從投影片中取得第一個表格形狀。

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 存取投影片上的第一個表格。
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

## **移除表格**

從投影片中刪除表格。

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀是表格。
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **合併表格儲存格**

將表格中相鄰的儲存格合併為單一儲存格。

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀是表格。
        let table = slide.getShapes().get_Item(0);

        // 合併儲存格。
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```