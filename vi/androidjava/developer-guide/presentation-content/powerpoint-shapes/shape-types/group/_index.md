---
title: Nhóm các hình trong bản trình bày trên Android
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/androidjava/group/
keywords:
- nhóm hình
- nhóm hình
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhóm và tách nhóm các hình trong bộ PowerPoint bằng Aspose.Slides cho Android—hướng dẫn nhanh, từng bước với mã Java miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các nhóm hình trong Aspose.Slides. Nó cho thấy cách thêm một nhóm hình vào một slide, đặt các hình bên trong và lưu bản trình bày đã cập nhật. Ngoài ra còn trình bày cách truy cập các hình lưu trong một nhóm và đọc giá trị `AlternativeText` của chúng. Thêm nữa, bài viết tóm tắt ngắn gọn các khả năng liên quan đến nhóm hình như nhóm lồng nhau, thứ tự z và các tùy chọn khóa.

## **Thêm một Nhóm Hình**
Aspose.Slides hỗ trợ làm việc với các nhóm hình trên slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides for Android via Java hỗ trợ việc thêm hoặc truy cập các nhóm hình. Bạn có thể thêm các hình vào một nhóm đã tạo để lấp đầy nó hoặc truy cập bất kỳ thuộc tính nào của nhóm hình. Để thêm một nhóm hình vào slide bằng Aspose.Slides for Android via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu của slide bằng cách sử dụng Index của nó
1. Thêm một nhóm hình vào slide.
1. Thêm các hình vào nhóm đã thêm.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một nhóm hình vào slide.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Truy cập bộ sưu tập hình của các slide
    IShapeCollection slideShapes = sld.getShapes();

    // Thêm một nhóm hình vào slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Thêm các hình bên trong nhóm hình đã thêm
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Thêm khung cho nhóm hình
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Ghi tệp PPTX vào đĩa
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập thuộc tính AltText**
Chủ đề này trình bày các bước đơn giản, kèm theo ví dụ mã, để thêm một nhóm hình và truy cập thuộc tính AltText của các nhóm hình trên slide. Để truy cập AltText của một nhóm hình trong slide bằng Aspose.Slides for Android via Java:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) đại diện cho tệp PPTX.
1. Lấy tham chiếu của slide bằng cách sử dụng Index của nó.
1. Truy cập bộ sưu tập hình của slide.
1. Truy cập nhóm hình.
1. Truy cập thuộc tính [AlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

Ví dụ dưới đây truy cập văn bản thay thế của nhóm hình.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Truy cập bộ sưu tập hình của các slide
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Truy cập nhóm hình.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Truy cập thuộc tính AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Có hỗ trợ nhóm lồng nhau (một nhóm bên trong một nhóm) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/groupshape/) có phương thức [getParentGroup](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getParentGroup--) , cho phép xác định trực tiếp hỗ trợ cấu trúc phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm sao tôi kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng phương thức [getZOrderPosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getZOrderPosition--) của [GroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Có thể ngăn không cho di chuyển/chỉnh sửa/ungroup không?**

Có. Phần khóa của nhóm được phơi bày qua [getGroupShapeLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) , cho phép bạn hạn chế các thao tác trên đối tượng.