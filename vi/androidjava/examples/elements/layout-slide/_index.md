---
title: Slide Bố cục
type: docs
weight: 20
url: /vi/androidjava/examples/elements/layout-slide/
keywords:
- ví dụ mã
- slide bố cục
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý slide bố cục trong Aspose.Slides cho Android: chọn, áp dụng và tùy chỉnh bố cục slide, trình giữ chỗ và master với các ví dụ Java cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho Android thông qua Java. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide thông thường. Bạn có thể thêm, truy cập, sao chép và xóa các layout slide, cũng như dọn dẹp những layout không sử dụng để giảm kích thước bài thuyết trình.

## **Thêm một Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để định nghĩa định dạng có thể tái sử dụng. Ví dụ, bạn có thể thêm một hộp văn bản xuất hiện trên tất cả các slide sử dụng layout này.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Tạo một layout slide với kiểu bố cục trống và tên tùy chỉnh.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Thêm một hộp văn bản vào layout slide.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Thêm hai slide sử dụng layout này; cả hai sẽ kế thừa văn bản từ layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Ghi chú 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Ghi chú 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.
> Ảnh chụp màn hình bên dưới hiển thị hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slide Thừa Kế Nội Dung Layout](layout-slide-result.png)

## **Truy cập một Layout Slide**

Layout slides có thể được truy cập bằng chỉ mục hoặc bằng loại layout (ví dụ, `Blank`, `Title`, `SectionHeader`, v.v.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Truy cập một layout slide theo chỉ mục.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Truy cập một layout slide theo loại.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu nó không còn cần thiết.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Lấy một layout slide theo loại và xóa nó.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các Layout Slides không sử dụng**

Để giảm kích thước bài thuyết trình, bạn có thể muốn xóa các layout slide không được bất kỳ slide thông thường nào sử dụng.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Tự động xóa tất cả các layout slide không được bất kỳ slide nào tham chiếu.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Sao chép một Layout Slide**

Bạn có thể sao chép một layout slide bằng cách sử dụng phương thức `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Lấy một layout slide hiện có theo loại.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Sao chép layout slide vào cuối bộ sưu tập layout slide.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Tóm tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng đồng nhất trên các slide. Aspose.Slides cho phép kiểm soát toàn diện việc tạo, quản lý và tối ưu hóa layout slides.