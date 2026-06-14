---
title: Siêu liên kết
type: docs
weight: 130
url: /vi/java/examples/elements/hyperlink/
keywords:
- ví dụ mã
- siêu liên kết
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Thêm và quản lý siêu liên kết trong Aspose.Slides cho Java: liên kết văn bản, hình dạng và hình ảnh, thiết lập đích và hành động cho PPT, PPTX và ODP với các ví dụ Java."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cập nhật siêu liên kết trên các hình dạng bằng **Aspose.Slides for Java**.

## **Thêm Siêu liên kết**

Tạo một hình chữ nhật có siêu liên kết trỏ tới một trang web bên ngoài.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập Siêu liên kết**

Đọc thông tin siêu liên kết từ phần văn bản của hình.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Siêu liên kết**

Xóa siêu liên kết khỏi văn bản của hình.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật Siêu liên kết**

Thay đổi đích của một siêu liên kết hiện có. Sử dụng `HyperlinkManager` để sửa đổi văn bản đã chứa siêu liên kết, mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Thay đổi siêu liên kết trong văn bản hiện có nên được thực hiện qua
        // HyperlinkManager thay vì đặt thuộc tính trực tiếp.
        // Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```