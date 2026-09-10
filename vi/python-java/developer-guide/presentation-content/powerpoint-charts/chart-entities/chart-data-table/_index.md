---
title: Tùy chỉnh Bảng Dữ liệu Biểu đồ trong Bản trình chiếu bằng Python
linktitle: Bảng Dữ liệu
type: docs
url: /vi/python-java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong Python cho PPT và PPTX với Aspose.Slides for Python via Java để tăng hiệu quả và sức hấp dẫn trong các bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu của biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu in đậm và chiều cao phông. Ví dụ minh họa việc tạo một bản trình chiếu, thêm biểu đồ, bật bảng dữ liệu của biểu đồ, áp dụng các thiết lập phông và lưu bản trình chiếu đã cập nhật.

Nó cũng bao gồm các câu trả lời ngắn gọn cho các câu hỏi thường gặp về việc hiển thị khóa chú giải trong bảng dữ liệu của biểu đồ, bảo tồn bảng dữ liệu khi xuất, làm việc với biểu đồ được tải từ bản trình chiếu hoặc mẫu hiện có, và xác định các biểu đồ có bật bảng dữ liệu.

## **Đặt Thuộc tính Phông cho Bảng Dữ liệu Biểu đồ**

Aspose.Slides for Python via Java cho phép bạn hiển thị bảng dữ liệu của một biểu đồ và thay đổi các thuộc tính phông của văn bản trong đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm một biểu đồ vào slide.
1. Hiển thị bảng dữ liệu của biểu đồ.
1. Đặt kiểu in đậm và chiều cao phông cho văn bản trong bảng dữ liệu.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau minh họa các bước này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Tạo một bản trình chiếu trống.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Tôi có thể hiển thị các khóa chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setShowLegendKey), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được bảo tồn khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/python-java/convert-powerpoint-to-html/)/[image](/slides/vi/python-java/convert-powerpoint-to-png/) xuất ra sẽ bao gồm biểu đồ cùng bảng dữ liệu.

**Bảng dữ liệu có được hỗ trợ cho các biểu đồ được lấy từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ bản trình chiếu hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#hasDataTable) bằng các thuộc tính của biểu đồ.

**Làm thế nào để tôi nhanh chóng tìm các biểu đồ trong tệp có bật bảng dữ liệu?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#hasDataTable) và duyệt qua các slide để xác định các biểu đồ mà tính năng này được bật.