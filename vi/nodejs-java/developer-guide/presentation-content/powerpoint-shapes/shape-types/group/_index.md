---
title: Các hình dạng nhóm trong bản trình bày JavaScript
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/nodejs-java/group/
keywords:
- nhóm hình
- nhóm hình
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Học cách nhóm và bỏ nhóm các hình dạng trong bộ PowerPoint bằng cách sử dụng Aspose.Slides cho Node.js qua Java — hướng dẫn nhanh, từng bước với mã JavaScript miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với nhóm hình trong Aspose.Slides. Nó cho thấy cách thêm một nhóm hình vào slide, đặt các hình bên trong và lưu bản trình bày đã cập nhật. Nó cũng minh họa cách truy cập các hình đã lưu trong một nhóm và đọc giá trị `AlternativeText` của chúng. Ngoài ra, bài viết còn đề cập ngắn gọn đến các khả năng liên quan đến nhóm hình như nhóm lồng nhau, thứ tự z và các tùy chọn khóa.

## **Thêm Nhóm Hình**
Aspose.Slides hỗ trợ làm việc với nhóm hình trên các slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides for Node.js via Java hỗ trợ việc thêm hoặc truy cập nhóm hình. Có thể thêm các hình vào một nhóm hình đã thêm để lấp đầy nó hoặc truy cập bất kỳ thuộc tính nào của nhóm hình. Để thêm một nhóm hình vào slide bằng Aspose.Slides for Node.js via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
1. Thêm một nhóm hình vào slide.
1. Thêm các hình vào nhóm hình đã thêm.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Truy cập bộ sưu tập hình của slide
    var slideShapes = sld.getShapes();
    // Thêm một nhóm hình vào slide
    var groupShape = slideShapes.addGroupShape();
    // Thêm các hình vào trong nhóm hình đã thêm
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Thêm khung cho nhóm hình
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Ghi tệp PPTX ra đĩa
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Thuộc tính AltText**
Chủ đề này trình bày các bước đơn giản, kèm ví dụ mã, để thêm một nhóm hình và truy cập thuộc tính AltText của nhóm hình trên slide. Để truy cập AltText của một nhóm hình trong slide bằng Aspose.Slides for Node.js via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) đại diện cho tệp PPTX.
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập bộ sưu tập hình của slide.
1. Truy cập nhóm hình.
1. Gọi thuộc tính [getAlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX file
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Truy cập bộ sưu tập hình của slide
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Truy cập nhóm hình.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Truy cập thuộc tính AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Có hỗ trợ nhóm lồng nhau (một nhóm bên trong một nhóm) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/) có một phương thức [getParentGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getparentgroup/) trực tiếp cho thấy hỗ trợ phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm thế nào để tôi kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng phương thức [getZOrderPosition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getzorderposition/) của [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Tôi có thể ngăn việc di chuyển/chỉnh sửa/bỏ nhóm không?**

Có. Phần khóa của nhóm được mở ra qua [GroupShapeLock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), cho phép bạn hạn chế các thao tác trên đối tượng.