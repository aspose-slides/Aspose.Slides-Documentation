---
title: Bảng
type: docs
weight: 120
url: /vi/nodejs-java/examples/elements/table/
keywords:
- ví dụ mã
- bảng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với các bảng trong Aspose.Slides cho Node.js: tạo, định dạng, hợp nhất ô, áp dụng kiểu dáng, nhập dữ liệu và xuất với các ví dụ cho PPT, PPTX và ODP."
---
Các ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô bằng cách sử dụng **Aspose.Slides for Node.js via Java**.

## **Thêm bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

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

## **Truy cập bảng**

Lấy hình dạng bảng đầu tiên từ slide.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập bảng đầu tiên trên slide.
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

## **Xóa bảng**

Xóa một bảng khỏi slide.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là một bảng.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Hợp nhất các ô bảng**

Hợp nhất các ô kề nhau của một bảng thành một ô duy nhất.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là một bảng.
        let table = slide.getShapes().get_Item(0);

        // Hợp nhất các ô.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```