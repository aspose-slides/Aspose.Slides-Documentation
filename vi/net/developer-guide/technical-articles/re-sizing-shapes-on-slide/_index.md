---
title: Thay đổi kích thước các hình dạng trên slide trình chiếu trong .NET
type: docs
weight: 130
url: /vi/net/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument với Aspose.Slides cho .NET—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất từ khách hàng Aspose.Slides for .NET là cách thay đổi kích thước các hình dạng sao cho khi kích thước slide thay đổi, dữ liệu không bị cắt bỏ. Bài viết kỹ thuật ngắn này trình bày cách thực hiện.

## **Thay đổi kích thước hình dạng**

Để ngăn các hình dạng bị lệch khi kích thước slide thay đổi, hãy cập nhật vị trí và kích thước của mỗi hình dạng sao cho chúng phù hợp với bố cục slide mới.

```c#
 // Tải tệp trình chiếu.
 using (Presentation presentation = new Presentation("sample.pptx"))
 {
     // Lấy kích thước slide ban đầu.
     float currentHeight = presentation.SlideSize.Size.Height;
     float currentWidth = presentation.SlideSize.Size.Width;

     // Thay đổi kích thước slide mà không tỉ lệ các hình dạng hiện có.
     presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

     // Lấy kích thước slide mới.
     float newHeight = presentation.SlideSize.Size.Height;
     float newWidth = presentation.SlideSize.Size.Width;

     float heightRatio = newHeight / currentHeight;
     float widthRatio = newWidth / currentWidth;

     // Thay đổi kích thước và vị trí các hình dạng trên mọi slide.
     foreach (ISlide slide in presentation.Slides)
     {
         foreach (IShape shape in slide.Shapes)
         {
             // Tỉ lệ kích thước hình dạng.
             shape.Height *= heightRatio;
             shape.Width *= widthRatio;

             // Tỉ lệ vị trí hình dạng.
             shape.Y *= heightRatio;
             shape.X *= widthRatio;
         }
     }

     presentation.Save("output.pptx", SaveFormat.Pptx);
 }
```

{{% alert color="primary" %}}
Nếu một slide chứa bảng, đoạn mã trên sẽ không hoạt động đúng. Trong trường hợp này, mỗi ô trong bảng phải được thay đổi kích thước.
{{% /alert %}}

Sử dụng đoạn mã sau để thay đổi kích thước slide có chứa bảng. Đối với bảng, việc đặt chiều rộng hoặc chiều cao là một trường hợp đặc biệt: bạn phải điều chỉnh chiều cao của từng hàng và chiều rộng của từng cột để thay đổi kích thước tổng thể của bảng.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Lấy kích thước slide ban đầu.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Thay đổi kích thước slide mà không tỉ lệ các hình dạng hiện có.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Lấy kích thước slide mới.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Tỉ lệ kích thước hình dạng.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Tỉ lệ vị trí hình dạng.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Tỉ lệ kích thước hình dạng.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Tì lệ vị trí hình dạng.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Tỉ lệ kích thước hình dạng.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Tỉ lệ vị trí hình dạng.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt bỏ sau khi thay đổi kích thước slide?**

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước ban đầu trừ khi tỷ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến nội dung bị cắt hoặc các hình dạng bị lệch.

**Mã được cung cấp có hoạt động với mọi loại hình dạng không?**

Ví dụ cơ bản hoạt động với hầu hết các loại hình dạng (hộp văn bản, hình ảnh, biểu đồ, v.v.). Tuy nhiên, đối với bảng, bạn cần xử lý riêng từng hàng và cột, vì chiều cao và chiều rộng của bảng được xác định bởi kích thước của các ô riêng lẻ.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Bạn cần lặp qua tất cả các hàng và cột của bảng và thay đổi chiều cao và chiều rộng theo tỉ lệ, như trong ví dụ mã thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các slide mẫu và slide bố cục không?**

Có, nhưng bạn cũng nên lặp qua [Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/) và [LayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/layoutslides/) và áp dụng cùng logic tỷ lệ cho các hình dạng của chúng để đảm bảo tính nhất quán trong toàn bộ bài thuyết trình.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Bạn có thể đặt [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/vi/net/aspose.slides/islidesize/orientation/) để thay đổi hướng. Đảm bảo bạn thiết lập logic tỷ lệ phù hợp để duy trì bố cục.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**

Aspose.Slides hỗ trợ kích thước tùy chỉnh, nhưng kích thước quá lớn có thể ảnh hưởng đến hiệu năng hoặc khả năng tương thích với một số phiên bản PowerPoint.

**Làm sao để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Bạn có thể kiểm tra thuộc tính `AspectRatioLocked` của hình dạng trước khi thực hiện tỷ lệ. Nếu nó bị khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách đồng tỷ lệ thay vì thay đổi chúng riêng lẻ.