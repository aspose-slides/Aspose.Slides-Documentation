---
title: Trang chiếu
type: docs
weight: 10
url: /vi/java/examples/elements/slide/
keywords:
- ví dụ mã
- trang chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Kiểm soát các trang chiếu trong Aspose.Slides cho Java: tạo, sao chép, sắp lại thứ tự, thay đổi kích thước, đặt nền và áp dụng chuyển động với Java cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for Java**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp lại thứ tự và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ dưới đây bao gồm một giải thích ngắn gọn, tiếp theo là đoạn mã mẫu bằng Java.

## **Thêm một Slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng ta sử dụng bố cục `Blank` và thêm một slide trống vào bản trình bày.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý:** Mỗi bố cục slide được tạo ra từ một slide master, định nghĩa thiết kế chung và cấu trúc placeholder. Hình ảnh bên dưới minh họa cách các slide master và các bố cục liên quan của chúng được tổ chức trong PowerPoint.

![Mối quan hệ giữa Master và Layout](master-layout-slide.png)

## **Truy cập Slides theo Chỉ mục**

Bạn có thể truy cập các slide bằng chỉ mục của chúng, hoặc tìm chỉ mục của một slide dựa trên một tham chiếu. Điều này hữu ích cho việc duyệt qua hoặc sửa đổi các slide cụ thể.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Thêm một slide trống khác.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Truy cập các slide theo chỉ mục.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Lấy chỉ mục slide từ một tham chiếu, sau đó truy cập nó theo chỉ mục.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Sao chép một Slide**

Ví dụ này minh họa cách sao chép một slide hiện có. Slide được sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Sắp xếp lại Slides**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới chỉ mục mới. Trong trường hợp này, chúng ta di chuyển slide đã sao chép đến vị trí đầu tiên.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Slide**

Để xóa một slide, chỉ cần tham chiếu tới nó và gọi `remove`. Ví dụ này thêm một slide thứ hai và sau đó xóa slide gốc, chỉ để lại slide mới.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```