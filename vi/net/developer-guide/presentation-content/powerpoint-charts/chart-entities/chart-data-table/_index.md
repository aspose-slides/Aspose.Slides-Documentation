---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình chiếu bằng .NET
linktitle: Bảng dữ liệu
type: docs
url: /vi/net/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong .NET cho PPT và PPTX với Aspose.Slides để tăng hiệu quả và sức hấp dẫn trong bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu in đậm và chiều cao phông chữ. Ví dụ minh họa việc tải một bản trình chiếu, thêm một biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản trình chiếu đã cập nhật.

Nó cũng bao gồm các câu trả lời ngắn gọn cho các câu hỏi thường gặp về việc hiển thị khóa chú giải trong bảng dữ liệu biểu đồ, bảo tồn bảng dữ liệu khi xuất, làm việc với biểu đồ được tải từ bản trình chiếu hoặc mẫu hiện có, và xác định các biểu đồ mà bảng dữ liệu đã được bật.

## **Đặt Thuộc Tính Phông Chữ cho Bảng Dữ Liệu Biểu Đồ**
Aspose.Slides for .NET cung cấp hỗ trợ thay đổi màu của các danh mục trong một series color. 

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Thêm biểu đồ vào slide.
1. Đặt bảng biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình chiếu đã sửa đổi.

Ví dụ mẫu dưới đây được đưa ra. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các khóa chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/datatable/showlegendkey/), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy [PDF](/slides/vi/net/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/net/convert-powerpoint-to-html/)/[image](/slides/vi/net/convert-powerpoint-to-png/) xuất ra sẽ bao gồm biểu đồ cùng với bảng dữ liệu của nó.

**Bảng dữ liệu có được hỗ trợ cho các biểu đồ đến từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ một bản trình chiếu hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc [is shown](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/hasdatatable/) của bảng dữ liệu bằng cách sử dụng các thuộc tính của biểu đồ.

**Làm thế nào tôi có thể nhanh chóng tìm ra các biểu đồ trong tệp nào đã bật bảng dữ liệu?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/hasdatatable/) và duyệt qua các slide để xác định các biểu đồ mà nó đã được bật.