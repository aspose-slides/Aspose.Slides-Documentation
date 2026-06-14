---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình bày bằng C++
linktitle: Bảng dữ liệu
type: docs
url: /vi/cpp/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong C++ cho PPT và PPTX với Aspose.Slides để tăng hiệu quả và sức hấp dẫn trong bản trình bày."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó chỉ ra cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách thiết lập các thuộc tính phông chữ như kiểu đậm và chiều cao phông chữ. Ví dụ minh họa việc tải một bản trình bày, thêm một biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản trình bày đã cập nhật.

## **Đặt thuộc tính phông chữ cho bảng dữ liệu biểu đồ**
Aspose.Slides for C++ cho phép thay đổi các thuộc tính phông chữ cho bảng dữ liệu biểu đồ. 

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
1. Thêm biểu đồ vào slide.
1. Đặt bảng biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình bày đã sửa đổi.

Dưới đây là ví dụ mẫu. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Tôi có thể hiển thị các ký hiệu chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/datatable/set_showlegendkey/), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình bày sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy khi xuất ra [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/cpp/convert-powerpoint-to-html/)/[image](/slides/vi/cpp/convert-powerpoint-to-png/) sẽ bao gồm biểu đồ cùng bảng dữ liệu của nó.

**Có hỗ trợ bảng dữ liệu cho các biểu đồ được tạo từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ một bản trình bày hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/set_hasdatatable/) bằng các thuộc tính của biểu đồ.

**Làm sao tôi có thể nhanh chóng tìm ra những biểu đồ nào trong tệp có bật bảng dữ liệu?**

Kiểm tra thuộc tính của từng biểu đồ cho biết liệu bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/get_hasdatatable/) hay không và duyệt qua các slide để xác định các biểu đồ đã bật tính năng này.