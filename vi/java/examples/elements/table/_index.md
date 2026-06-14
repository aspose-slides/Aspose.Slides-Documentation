---
title: Bảng
type: docs
weight: 120
url: /vi/java/examples/elements/table/
keywords:
- ví dụ mã
- bảng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Làm việc với các bảng trong Aspose.Slides for Java: tạo, định dạng, hợp nhất các ô, áp dụng kiểu, nhập dữ liệu và xuất với các ví dụ Java cho PPT, PPTX và ODP."
---
Các ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô bằng cách sử dụng **Aspose.Slides for Java**.

## **Thêm Bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập Bảng**

Lấy hình dạng bảng đầu tiên trên slide.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Truy cập bảng đầu tiên trên slide.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Bảng**

Xóa một bảng khỏi slide.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Hợp nhất các ô trong bảng**

Hợp nhất các ô liền kề của một bảng thành một ô duy nhất.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Hợp nhất các ô.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```