---
title: Slide Bố Cục
type: docs
weight: 20
url: /vi/java/examples/elements/layout-slide/
keywords:
- ví dụ mã
- bố cục slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các layout slide trong Aspose.Slides cho Java: chọn, áp dụng và tùy chỉnh bố cục slide, các placeholder và master với các ví dụ Java cho bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho Java. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide bình thường. Bạn có thể thêm, truy cập, sao chép và xoá layout slides, cũng như dọn dẹp các layout không sử dụng để giảm kích thước bản trình chiếu.

## **Thêm Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để xác định định dạng có thể tái sử dụng. Ví dụ, bạn có thể thêm một hộp văn bản xuất hiện trên tất cả các slide sử dụng layout này.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Tạo một layout slide với loại bố cục trống và tên tuỳ chỉnh.
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

> 💡 **Note 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Note 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chia sẻ này. Ảnh chụp màn hình bên dưới cho thấy hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slide kế thừa nội dung Layout](layout-slide-result.png)

## **Truy cập Layout Slide**

Layout slides có thể được truy cập bằng chỉ mục hoặc bằng loại layout (ví dụ: `Blank`, `Title`, `SectionHeader`, v.v.).

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

## **Xoá Layout Slide**

Bạn có thể xoá một layout slide cụ thể nếu không còn cần thiết.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Lấy một layout slide theo loại và xoá nó.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Xoá Layout Slide không sử dụng**

Để giảm kích thước bản trình chiếu, bạn có thể muốn xoá các layout slide không được bất kỳ slide bình thường nào sử dụng.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Tự động xoá tất cả các layout slide không được bất kỳ slide nào tham chiếu.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Sao chép Layout Slide**

Bạn có thể sao chép một layout slide bằng cách sử dụng phương thức `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Lấy một layout slide hiện có theo loại.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Sao chép layout slide tới cuối bộ sưu tập layout slide.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát đầy đủ việc tạo, quản lý và tối ưu hóa layout slides.