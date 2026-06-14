---
title: Slide bố cục
type: docs
weight: 20
url: /vi/nodejs-java/examples/elements/layout-slide/
keywords:
- ví dụ mã
- slide bố cục
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các slide bố cục trong Aspose.Slides cho Node.js: chọn, áp dụng và tùy chỉnh bố cục slide, placeholder và master với các ví dụ cho bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho Node.js thông qua Java. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide thông thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các slide không dùng để giảm kích thước bản trình bày.

## **Thêm một Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để xác định định dạng có thể tái sử dụng.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Tạo một slide bố cục với loại bố cục trống và tên tùy chỉnh.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Ghi chú 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Ghi chú 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.  
> Ảnh chụp màn hình dưới đây hiển thị hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slide kế thừa nội dung Layout](layout-slide-result.png)

## **Truy cập một Layout Slide**

Layout slides có thể được truy cập bằng chỉ số hoặc theo loại layout (ví dụ, `Blank`, `Title`, `SectionHeader`, v.v.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Truy cập một slide bố cục theo chỉ mục.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Truy cập một slide bố cục theo loại.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu nó không còn cần thiết nữa.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Lấy một slide bố cục theo loại và xóa nó.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các Layout Slides không sử dụng**

Để giảm kích thước bản trình bày, bạn có thể muốn xóa các layout slides không được sử dụng bởi bất kỳ slide thông thường nào.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Tự động xóa tất cả các slide bố cục không được bất kỳ slide nào tham chiếu.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sao chép một Layout Slide**

Bạn có thể sao chép một layout slide bằng cách sử dụng phương thức `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Lấy một slide bố cục hiện có theo loại.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Sao chép slide bố cục đến cuối bộ sưu tập slide bố cục.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Tóm tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát đầy đủ việc tạo, quản lý và tối ưu hóa layout slides.