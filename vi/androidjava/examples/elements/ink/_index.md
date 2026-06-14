---
title: Mực
type: docs
weight: 180
url: /vi/androidjava/examples/elements/ink/
keywords:
- ví dụ mã
- mực
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Làm việc với mực trong Aspose.Slides cho Android: vẽ, nhập và chỉnh sửa các nét, điều chỉnh màu và độ rộng, và xuất ra PPT, PPTX và ODP bằng các ví dụ Java."
---
Bài viết này cung cấp các ví dụ về cách truy cập các hình mực hiện có và xóa chúng bằng cách sử dụng **Aspose.Slides for Android via Java**.

> ❗ **Lưu ý:** Các hình mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới bằng chương trình, nhưng bạn có thể đọc và chỉnh sửa mực hiện có.

## **Truy cập mực**

Đọc các thẻ từ hình mực đầu tiên trên một slide.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Sử dụng tagName khi cần.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa mực**

Xóa một hình mực khỏi slide nếu nó tồn tại.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```