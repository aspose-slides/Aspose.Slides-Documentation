---
title: Nhóm các hình trong bài thuyết trình .NET
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/net/group/
keywords:
- hình nhóm
- nhóm hình
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách nhóm và bỏ nhóm các hình trong bộ PowerPoint bằng Aspose.Slides cho .NET—hướng dẫn nhanh, từng bước với mã C# miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các nhóm hình trong Aspose.Slides. Nó cho thấy cách thêm một nhóm hình vào slide, đặt các hình bên trong, và lưu bản trình chiếu đã cập nhật. Bài viết cũng trình bày cách truy cập các hình được lưu trong một nhóm và đọc giá trị `AlternativeText` của chúng. Ngoài ra, bài viết còn đề cập ngắn gọn tới các khả năng liên quan đến nhóm hình như nhóm lồng nhau, thứ tự z, và các tùy chọn khóa.

## **Thêm Nhóm Hình**
Aspose.Slides hỗ trợ làm việc với các nhóm hình trên slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình chiếu phong phú hơn. Aspose.Slides for .NET hỗ trợ việc thêm hoặc truy cập các nhóm hình. Có thể thêm các hình vào một nhóm hình đã được tạo để điền nội dung hoặc truy cập bất kỳ thuộc tính nào của nhóm hình. Để thêm một nhóm hình vào slide bằng Aspose.Slides for .NET:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
1. Thêm một nhóm hình vào slide.
1. Thêm các hình vào nhóm hình đã thêm.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một nhóm hình vào slide.

```c#
// Khởi tạo lớp Presentation 
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên 
    ISlide sld = pres.Slides[0];

    // Truy cập bộ sưu tập hình của slide 
    IShapeCollection slideShapes = sld.Shapes;

    // Thêm một nhóm hình vào slide 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Thêm các hình vào nhóm đã thêm 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Thêm khung cho nhóm hình 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Ghi tệp PPTX ra đĩa 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **Truy cập thuộc tính AltText**
Chủ đề này đưa ra các bước đơn giản, kèm ví dụ mã, để thêm một nhóm hình và truy cập thuộc tính AltText của các nhóm hình trên slide. Để truy cập AltText của một nhóm hình trong slide bằng Aspose.Slides for .NET:

1. Khởi tạo lớp `Presentation` đại diện cho tệp PPTX.
1. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
1. Truy cập bộ sưu tập hình của slide.
1. Truy cập nhóm hình.
1. Truy cập thuộc tính AltText.

Ví dụ dưới đây truy cập văn bản thay thế của nhóm hình.

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("AltText.pptx");

// Lấy slide đầu tiên
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Truy cập bộ sưu tập hình của slide
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Truy cập nhóm hình.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Truy cập thuộc tính AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **Câu hỏi thường gặp**

**Có hỗ trợ nhóm lồng nhau (một nhóm bên trong một nhóm) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/groupshape/) có thuộc tính [ParentGroup](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/parentgroup/) cho biết rõ hỗ trợ phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm thế nào để kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng thuộc tính [ZOrderPosition](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/zorderposition/) của [GroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Có thể ngăn việc di chuyển/chỉnh sửa/hủy nhóm không?**

Có. Phần khóa của nhóm được mở ra qua [GroupShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/groupshape/groupshapelock/), cho phép bạn hạn chế các thao tác trên đối tượng.