---
title: Mực
type: docs
weight: 180
url: /vi/nodejs-java/examples/elements/ink/
keywords:
- ví dụ mã
- mực
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với Mực trong Aspose.Slides cho Node.js: vẽ, nhập và chỉnh sửa các nét, điều chỉnh màu và độ rộng, và xuất ra PPT, PPTX và ODP bằng các ví dụ."
---
Bài viết này cung cấp các ví dụ về cách truy cập các hình mực hiện có và xóa chúng bằng **Aspose.Slides for Node.js via Java**.

> ❗ **Note:** Các hình mực biểu thị đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới một cách lập trình, nhưng bạn có thể đọc và chỉnh sửa các nét mực hiện có.

## **Truy cập mực**

Lấy hình mực đầu tiên trên một slide.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa mực**

Xóa một hình mực khỏi slide.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình mực là hình đầu tiên trên slide.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```