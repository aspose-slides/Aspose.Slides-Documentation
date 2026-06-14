---
title: Slide
type: docs
weight: 10
url: /vi/androidjava/examples/elements/slide/
keywords:
- ví dụ mã
- slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Kiểm soát các slide trong Aspose.Slides cho Android: tạo, sao chép, sắp xếp lại, thay đổi kích thước, đặt nền, và áp dụng chuyển đổi với Java cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for Android via Java**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ bên dưới bao gồm một phần giải thích ngắn gọn và sau đó là đoạn mã mẫu bằng Java.

## **Add a Slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình chiếu.

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

> 💡 **Note:** Mỗi bố cục slide được kế thừa từ một slide chủ, định nghĩa thiết kế tổng thể và cấu trúc placeholder. Hình ảnh dưới đây minh họa cách các slide chủ và các bố cục liên quan được tổ chức trong PowerPoint.

![Mối quan hệ giữa Master và Layout](master-layout-slide.png)

## **Access Slides by Index**

Bạn có thể truy cập các slide bằng chỉ mục của chúng, hoặc tìm chỉ mục của một slide dựa trên một tham chiếu. Điều này hữu ích khi lặp qua hoặc sửa đổi các slide cụ thể.

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

## **Clone a Slide**

Ví dụ này trình bày cách sao chép một slide hiện có. Slide đã sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

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

## **Reorder Slides**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới chỉ mục mới. Trong trường hợp này, chúng tôi di chuyển slide đã sao chép tới vị trí đầu tiên.

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

## **Remove a Slide**

Để xóa một slide, chỉ cần tham chiếu tới nó và gọi `remove`. Ví dụ này thêm một slide thứ hai và sau đó xóa slide gốc, chỉ còn lại slide mới.

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