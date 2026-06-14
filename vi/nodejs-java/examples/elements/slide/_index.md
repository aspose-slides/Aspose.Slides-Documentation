---
title: Slide
type: docs
weight: 10
url: /vi/nodejs-java/examples/elements/slide/
keywords:
- ví dụ mã
- slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Kiểm soát các slide trong Aspose.Slides cho Node.js: tạo, sao chép, sắp xếp lại, thay đổi kích thước, đặt nền và áp dụng chuyển đổi cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for Node.js via Java**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ dưới đây bao gồm một mô tả ngắn gọn và một đoạn mã mẫu bằng JavaScript.

## **Thêm một Slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình chiếu.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý:** Mỗi bố cục slide được tạo ra từ một slide master, định nghĩa thiết kế tổng thể và cấu trúc các placeholder. Hình ảnh dưới đây minh họa cách các slide master và các bố cục liên kết của chúng được tổ chức trong PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Truy cập Slide theo Chỉ mục**

Bạn có thể truy cập các slide bằng chỉ mục của chúng. Điều này hữu ích khi lặp qua hoặc chỉnh sửa các slide cụ thể.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Truy cập một slide theo chỉ mục.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Sao chép một Slide**

Ví dụ này trình bày cách sao chép một slide hiện có. Slide đã sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sắp xếp lại Slides**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới một chỉ mục mới. Trong trường hợp này, chúng tôi di chuyển một slide lên vị trí đầu tiên.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Sắp xếp lại các slide bằng cách di chuyển slide thứ hai lên vị trí đầu tiên.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Slide**

Để xóa một slide, chỉ cần tham chiếu đến nó và gọi `remove`. Ví dụ này thêm một slide thứ hai và sau đó xóa slide gốc, chỉ để lại slide mới.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```