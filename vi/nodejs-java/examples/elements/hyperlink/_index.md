---
title: Liên kết siêu văn bản
type: docs
weight: 130
url: /vi/nodejs-java/examples/elements/hyperlink/
keywords:
- ví dụ mã
- liên kết siêu văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm và quản lý các liên kết siêu văn bản trong Aspose.Slides cho Node.js: liên kết văn bản, hình dạng và hình ảnh, đặt đích và hành động cho PPT, PPTX và ODP với các ví dụ."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cập nhật liên kết siêu văn bản trên các hình dạng bằng cách sử dụng **Aspose.Slides for Node.js via Java**.

## **Thêm liên kết siêu văn bản**

Tạo một hình chữ nhật có liên kết siêu văn bản trỏ tới một trang web bên ngoài.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập liên kết siêu văn bản**

Đọc liên kết siêu văn bản từ phần văn bản của một hình dạng.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên chứa văn bản có siêu liên kết.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa liên kết siêu văn bản**

Xóa bỏ liên kết siêu văn bản khỏi văn bản của một hình dạng.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên chứa văn bản có siêu liên kết.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật liên kết siêu văn bản**

Thay đổi đích của một liên kết siêu văn bản hiện có. Sử dụng `HyperlinkManager` để chỉnh sửa văn bản đã có liên kết siêu văn bản, mô phỏng cách PowerPoint cập nhật liên kết siêu văn bản một cách an toàn.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên chứa văn bản có siêu liên kết.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Thay đổi một siêu liên kết trong văn bản hiện có nên thực hiện qua
        // HyperlinkManager thay vì đặt thuộc tính trực tiếp.
        // Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```