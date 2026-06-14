---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong Python
linktitle: Bảng dữ liệu
type: docs
url: /vi/python-net/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong Python cho PPT, PPTX và ODP với Aspose.Slides để tăng hiệu suất và tính hấp dẫn trong các bản trình bày."
---
## **Overview**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản của nó bằng cách đặt các thuộc tính phông chữ như kiểu in đậm và chiều cao phông chữ. Ví dụ minh họa cách tải một bản trình bày, thêm một biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản trình bày đã cập nhật.

Nó cũng bao gồm các câu trả lời ngắn gọn cho các câu hỏi thường gặp về việc hiển thị khóa chú giải trong bảng dữ liệu biểu đồ, bảo tồn bảng dữ liệu khi xuất, làm việc với các biểu đồ được tải từ bản trình bày hoặc mẫu có sẵn, và xác định các biểu đồ mà bảng dữ liệu được bật.

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Python via .NET provides support for changing color of categories in a series color. 

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm biểu đồ vào slide.
1. Đặt bảng dữ liệu cho biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình bày đã sửa đổi.

Ví dụ mẫu dưới đây được cung cấp. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể hiển thị các khóa chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datatable/show_legend_key/), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được bảo tồn khi xuất bản trình bày sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy bản xuất [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf)/[HTML](/slides/vi/python-net/convert-powerpoint-to-html)/[image](/slides/vi/python-net/convert-powerpoint-to-png) sẽ bao gồm biểu đồ cùng với bảng dữ liệu của nó.

**Bảng dữ liệu có được hỗ trợ cho các biểu đồ đến từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ bản trình bày hoặc mẫu có sẵn, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu có [được hiển thị](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) hay không bằng cách sử dụng các thuộc tính của biểu đồ.

**Làm thế nào để tôi nhanh chóng tìm các biểu đồ trong tệp có bật bảng dữ liệu?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết bảng dữ liệu có [được hiển thị](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/has_data_table/) hay không và lặp qua các slide để xác định các biểu đồ mà nó được bật.