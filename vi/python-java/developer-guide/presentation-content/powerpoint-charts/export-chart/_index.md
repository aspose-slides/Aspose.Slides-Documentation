---
title: Xuất Biểu Đồ Bài Trình Chiếu bằng Python qua Java
linktitle: Xuất Biểu Đồ
type: docs
weight: 90
url: /vi/python-java/export-chart/
keywords:
- biểu đồ
- biểu đồ thành hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- bài trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ bài trình chiếu với Aspose.Slides cho Python qua Java, hỗ trợ định dạng PPT và PPTX, và tối ưu hóa báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất một biểu đồ từ bản trình bày dưới dạng hình ảnh. Bài viết này hướng dẫn cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ ngoài bản PowerPoint.

Ngoài quy trình xuất hình ảnh cơ bản, bài viết còn giải đáp các câu hỏi thường gặp liên quan đến xuất, bao gồm lưu nội dung biểu đồ dưới dạng SVG, kiểm soát kích thước đầu ra qua các tùy chọn render, tải font để bảo toàn diện mạo nhãn và chú giải, và giữ nguyên định dạng bản trình bày gốc như chủ đề, kiểu dáng, màu nền và hiệu ứng trong quá trình render.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides for Python via Java hỗ trợ trích xuất hình ảnh của một biểu đồ cụ thể. Ví dụ sau minh họa cách thực hiện.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì ảnh raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng [phương thức lưu shape-to-SVG](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Làm thế nào để đặt kích thước chính xác cho biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload render ảnh cho phép bạn chỉ định kích thước hoặc tỷ lệ—thư viện hỗ trợ render đối tượng với các kích thước/tỷ lệ cụ thể.

**Nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất thì phải làm gì?**

[Load the required fonts](/slides/vi/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/) để quá trình render biểu đồ bảo toàn các thông số và giao diện văn bản.

**Quá trình xuất có tuân thủ chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản trình bày (chủ đề, kiểu dáng, màu nền, hiệu ứng), do đó giao diện biểu đồ được giữ nguyên.

**Tôi có thể tìm thấy các khả năng render/xuất nào khác ngoài hình ảnh biểu đồ?**

Xem [API](https://reference.aspose.com/slides/vi/python-java/aspose.slides/)/[documentation](/slides/vi/python-java/convert-powerpoint/) để biết các đích xuất (như [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.