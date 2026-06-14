---
title: Xuất biểu đồ trình chiếu trong C++
linktitle: Xuất biểu đồ
type: docs
weight: 90
url: /vi/cpp/export-chart/
keywords:
- biểu đồ
- biểu đồ thành hình ảnh
- biểu đồ dưới dạng hình ảnh
- trích xuất hình ảnh biểu đồ
- PowerPoint
- trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách xuất biểu đồ trình chiếu bằng Aspose.Slides cho C++, hỗ trợ các định dạng PPT và PPTX, và tối ưu hóa việc báo cáo trong bất kỳ quy trình làm việc nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn xuất biểu đồ từ một bản trình chiếu dưới dạng hình ảnh. Bài viết này chỉ ra cách lấy hình ảnh từ biểu đồ và lưu lại, hữu ích khi bạn cần tái sử dụng hình ảnh biểu đồ bên ngoài bản trình chiếu PowerPoint.

## **Lấy hình ảnh biểu đồ**
Aspose.Slides for C++ cung cấp hỗ trợ để trích xuất hình ảnh của biểu đồ cụ thể. Ví dụ mẫu bên dưới được đưa ra.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Tôi có thể xuất biểu đồ dưới dạng vector (SVG) thay vì ảnh raster không?**

Có. Biểu đồ là một hình dạng, và nội dung của nó có thể được lưu dưới dạng SVG bằng cách sử dụng[phương pháp lưu shape‑to‑SVG](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/).

**Làm thế nào để thiết lập kích thước chính xác của biểu đồ đã xuất tính bằng pixel?**

Sử dụng các overload render‑hình ảnh cho phép bạn chỉ định kích thước hoặc tỉ lệ — thư viện hỗ trợ render các đối tượng với kích thước/tỉ lệ đã cho.

**Tôi nên làm gì nếu phông chữ trong nhãn và chú giải hiển thị sai sau khi xuất?**

[Tải phông chữ cần thiết](/slides/vi/cpp/custom-font/) qua[FontsLoader](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/) để quá trình render biểu đồ giữ nguyên các chỉ số và hiển thị văn bản.

**Việc xuất có tôn trọng chủ đề, kiểu dáng và hiệu ứng của PowerPoint không?**

Có. Bộ renderer của Aspose.Slides tuân theo định dạng của bản trình chiếu (chủ đề, kiểu dáng, lớp nền, hiệu ứng), do đó giao diện của biểu đồ được bảo tồn.

**Tôi có thể tìm thấy khả năng render/xuất nào có sẵn ngoài hình ảnh biểu đồ?**

Xem mục xuất của[API](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/)/[tài liệu](/slides/vi/cpp/convert-powerpoint/) để biết các đích xuất ([PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/),[SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/),[XPS](/slides/vi/cpp/convert-powerpoint-to-xps/),[HTML](/slides/vi/cpp/convert-powerpoint-to-html/), etc.) và các tùy chọn render liên quan.