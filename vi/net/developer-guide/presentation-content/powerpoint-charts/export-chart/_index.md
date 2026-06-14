---
title: Xuất biểu đồ bản trình chiếu trong .NET
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/net/export-chart/
keywords:
- biểu đồ
- biểu đồ thành hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ bản trình chiếu bằng Aspose.Slides cho .NET, hỗ trợ định dạng PPT và PPTX, và tối ưu hoá báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ một bản trình chiếu dưới dạng hình ảnh. Bài viết này trình bày cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản trình chiếu PowerPoint.

Ngoài quy trình xuất hình ảnh cơ bản, bài viết còn giải đáp các câu hỏi thường gặp về xuất khẩu, bao gồm lưu nội dung biểu đồ dưới dạng SVG, kiểm soát kích thước đầu ra qua các tùy chọn render, tải phông chữ để bảo toàn giao diện nhãn và chú giải, và duy trì định dạng bản trình chiếu gốc như chủ đề, kiểu dáng, màu nền và hiệu ứng trong quá trình render.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides cho .NET cung cấp hỗ trợ để trích xuất hình ảnh của biểu đồ cụ thể. Dưới đây là ví dụ mẫu.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **Câu hỏi thường gặp**

**Có thể xuất biểu đồ dưới dạng vector (SVG) thay vì hình ảnh raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng [phương pháp lưu shape-to-SVG](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/).

**Làm sao để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload của image-rendering cho phép bạn chỉ định kích thước hoặc tỷ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỷ lệ đã cho.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất?**

[Tải các phông chữ cần thiết](/slides/vi/net/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/) để việc render biểu đồ giữ nguyên các chỉ số và giao diện văn bản.

**Quá trình xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình chiếu (chủ đề, kiểu dáng, màu nền, hiệu ứng), vì vậy giao diện của biểu đồ được bảo toàn.

**Tôi có thể tìm thông tin về các khả năng render/xuất khác ngoài hình ảnh biểu đồ ở đâu?**

Xem phần xuất của [API](https://reference.aspose.com/slides/vi/net/aspose.slides.export/)/[tài liệu](/slides/vi/net/convert-powerpoint/) để biết các mục tiêu đầu ra ([PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [SVG](/slides/vi/net/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/net/convert-powerpoint-to-xps/), [HTML](/slides/vi/net/convert-powerpoint-to-html/), …) và các tùy chọn render liên quan.