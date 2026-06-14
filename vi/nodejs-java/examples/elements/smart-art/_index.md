---
title: SmartArt
type: docs
weight: 140
url: /vi/nodejs-java/examples/elements/smart-art/
keywords:
- ví dụ mã
- SmartArt
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với SmartArt trong Aspose.Slides cho Node.js: tạo, chỉnh sửa, chuyển đổi và tạo kiểu cho các sơ đồ bằng JavaScript cho các bài thuyết trình PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng **Aspose.Slides for Node.js via Java**.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng cách sử dụng một trong các bố cục có sẵn.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Thay đổi Bố cục SmartArt**

Cập nhật loại bố cục của một đồ họa SmartArt hiện có.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```