---
title: Hình Nhóm
type: docs
weight: 170
url: /vi/nodejs-java/examples/elements/group-shape/
keywords:
- ví dụ mã
- hình nhóm
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các hình đã nhóm trong Aspose.Slides cho Node.js: tạo, lồng, căn chỉnh, sắp xếp lại và định dạng các hình nhóm với các ví dụ trong bản trình bày PPT, PPTX và ODP."
---
Các ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bằng **Aspose.Slides for Node.js via Java**.

## **Thêm hình nhóm**

Tạo một nhóm chứa hai hình cơ bản.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập hình nhóm**

Lấy hình nhóm đầu tiên từ một slide.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa hình nhóm**

Xóa một hình nhóm khỏi slide.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình đầu tiên là hình nhóm.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Tách nhóm các hình**

Di chuyển các hình ra khỏi container nhóm.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình đầu tiên là một hình nhóm.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Sao chép từng hình từ nhóm lên slide.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```