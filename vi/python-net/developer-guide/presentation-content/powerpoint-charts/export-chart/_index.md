---
title: Xuất biểu đồ trình chiếu bằng Python
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/python-net/export-chart/
keywords:
- biểu đồ
- biểu đồ thành ảnh
- biểu đồ dưới dạng ảnh
- trích xuất ảnh biểu đồ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ trong bài thuyết trình bằng Aspose.Slides cho Python qua .NET, hỗ trợ các định dạng PPT, PPTX và ODP, và tối ưu hoá quy trình báo cáo trong bất kỳ luồng công việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất một biểu đồ từ bản trình bày dưới dạng hình ảnh. Bài viết này hướng dẫn cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản trình chiếu PowerPoint.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides cho Python qua .NET hỗ trợ trích xuất hình ảnh của biểu đồ cụ thể. Ví dụ mẫu dưới đây được cung cấp.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì hình raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng [phương thức lưu shape-to-SVG](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/write_as_svg/).

**Làm thế nào để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các phương thức overload của việc render hình ảnh cho phép bạn chỉ định kích thước hoặc tỉ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỉ lệ đã cho.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất?**

[Tải phông chữ cần thiết](/slides/vi/python-net/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/) để việc render biểu đồ giữ nguyên các chỉ số metric và hiển thị văn bản.

**Việc xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình bày (chủ đề, kiểu dáng, màu nền, hiệu ứng), do đó giao diện của biểu đồ được giữ nguyên.

**Tôi có thể tìm thấy các khả năng render/xuất bổ sung ngoài hình ảnh biểu đồ ở đâu?**

Xem phần xuất của [API](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/)/[tài liệu](/slides/vi/python-net/convert-powerpoint/) để biết các mục tiêu đầu ra ([PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.