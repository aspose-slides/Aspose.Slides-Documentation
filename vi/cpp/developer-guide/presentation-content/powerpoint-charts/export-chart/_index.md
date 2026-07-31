---
title: Xuất biểu đồ bản trình chiếu trong C++
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/cpp/export-chart/
keywords:
- biểu đồ
- biểu đồ sang hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ bản trình chiếu bằng Aspose.Slides cho C++, hỗ trợ các định dạng PPT và PPTX, và tối ưu hoá báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất một biểu đồ từ bản thuyết trình dưới dạng hình ảnh. Bài viết này hướng dẫn cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản PowerPoint.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides for C++ cung cấp hỗ trợ để trích xuất hình ảnh của biểu đồ cụ thể. Ví dụ mẫu dưới đây được đưa ra.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì ảnh raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng [phương pháp lưu shape-to-SVG](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/).

**Làm thế nào để đặt kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload render‑hình ảnh cho phép bạn chỉ định kích thước hoặc tỷ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỷ lệ được cung cấp.

**Nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất thì tôi nên làm gì?**

[Load the required fonts](/slides/vi/cpp/custom-font/) qua [FontsLoader](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/) để việc render biểu đồ giữ nguyên các chỉ số và giao diện văn bản.

**Việc xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ render của Aspose.Slides tuân theo định dạng của bản thuyết trình (chủ đề, kiểu dáng, màu nền, hiệu ứng), vì vậy giao diện của biểu đồ được bảo toàn.

**Tôi có thể tìm thấy các khả năng render/​xuất khác ngoài hình ảnh biểu đồ ở đâu?**

Xem mục xuất của [API](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/)/[documentation](/slides/vi/cpp/convert-powerpoint/) để biết các đích xuất (PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/vi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), v.v.) và các tùy chọn render liên quan.