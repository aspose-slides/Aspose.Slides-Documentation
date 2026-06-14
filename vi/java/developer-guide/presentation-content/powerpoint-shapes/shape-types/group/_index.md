---
title: "Các hình dạng nhóm trong PowerPoint bằng Java"
linktitle: "Nhóm Hình Dạng"
type: docs
weight: 40
url: /vi/java/group/
keywords:
- "hình dạng nhóm"
- "nhóm hình dạng"
- "thêm nhóm"
- "văn bản thay thế"
- "PowerPoint"
- "bản trình bày"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu cách nhóm và bỏ nhóm các hình dạng trong bản PowerPoint bằng Aspose.Slides for Java—hướng dẫn nhanh, từng bước với mã Java miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng nhóm trong Aspose.Slides. Nó cho thấy cách thêm một hình dạng nhóm vào một slide, đặt các hình dạng bên trong và lưu bản trình bày đã cập nhật. Ngoài ra, nó còn trình bày cách truy cập các hình dạng được lưu trong một nhóm và đọc giá trị `AlternativeText` của chúng. Thêm nữa, bài viết tóm tắt ngắn gọn các khả năng liên quan đến hình dạng nhóm như nhóm lồng nhau, thứ tự z và các tùy chọn khóa.

## **Thêm một hình dạng nhóm**
Aspose.Slides hỗ trợ làm việc với các hình dạng nhóm trên slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides for Java hỗ trợ việc thêm hoặc truy cập các hình dạng nhóm. Có thể thêm các hình dạng vào một hình dạng nhóm đã thêm để điền nội dung hoặc truy cập bất kỳ thuộc tính nào của hình dạng nhóm. Để thêm một hình dạng nhóm vào slide bằng Aspose.Slides for Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) .
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
1. Thêm một hình dạng nhóm vào slide.
1. Thêm các hình dạng vào hình dạng nhóm đã thêm.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một hình dạng nhóm vào slide.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Truy cập bộ sưu tập hình dạng của slide
    IShapeCollection slideShapes = sld.getShapes();

    // Thêm hình dạng nhóm vào slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Thêm các hình dạng vào trong hình dạng nhóm đã thêm
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Thêm khung cho hình dạng nhóm
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Ghi tệp PPTX vào đĩa
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập thuộc tính AltText**
Chủ đề này trình bày các bước đơn giản, kèm theo ví dụ mã, để thêm một hình dạng nhóm và truy cập thuộc tính AltText của các hình dạng nhóm trên slide. Để truy cập AltText của một hình dạng nhóm trong slide bằng Aspose.Slides for Java:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) đại diện cho tệp PPTX.
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập bộ sưu tập hình dạng của slide.
1. Truy cập hình dạng nhóm.
1. Truy cập thuộc tính [AlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getAlternativeText--) .

Ví dụ dưới đây truy cập văn bản thay thế của hình dạng nhóm.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Truy cập bộ sưu tập hình dạng của slide
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Truy cập hình dạng nhóm.
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

Có. [GroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/groupshape/) có phương thức [getParentGroup](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getParentGroup--) , chỉ ra hỗ trợ phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm thế nào để kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng phương thức [getZOrderPosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getZOrderPosition--) của [GroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Tôi có thể ngăn việc di chuyển/chỉnh sửa/bỏ nhóm không?**

Có. Phần khóa của nhóm được mở ra qua [GroupShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/groupshape/#getGroupShapeLock--) , cho phép bạn hạn chế các thao tác trên đối tượng.