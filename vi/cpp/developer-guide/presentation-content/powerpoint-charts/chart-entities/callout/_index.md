---
title: Quản lý Callout trong Biểu đồ Bài thuyết trình bằng C++
linktitle: Gọi chú
type: docs
url: /vi/cpp/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho C++ với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hoá quy trình làm việc với bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng phương thức `set_ShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các thiết lập nhãn liên quan đến callout cho biểu đồ bánh rán, và lưu ý rằng các callout và giao diện của chúng được giữ nguyên khi bài thuyết trình được xuất ra các định dạng PDF, HTML5, SVG và ảnh raster.

## **Sử dụng Callouts**
Thuộc tính mới **ShowLabelAsDataCallout** đã được thêm vào lớp **DataLabelFormat** và giao diện **IDataLabelFormat**, nó xác định nhãn dữ liệu của biểu đồ được chỉ định sẽ được hiển thị dưới dạng callout hay dưới dạng nhãn dữ liệu. Trong ví dụ dưới đây, chúng tôi đã thiết lập Callout.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Đặt Callout cho Biểu đồ Doughnut**
Aspose.Slides for C++ hỗ trợ việc đặt hình dạng callout cho nhãn dữ liệu của chuỗi trong biểu đồ Doughnut. Ví dụ mẫu dưới đây được cung cấp.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Câu hỏi thường gặp**

**Liệu các callout có được giữ nguyên khi chuyển đổi bài thuyết trình sang PDF, HTML5, SVG hoặc hình ảnh không?**

Có. Callout là một phần của quá trình render biểu đồ, vì vậy khi bạn xuất ra [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/cpp/export-to-html5/), [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), hoặc [hình ảnh raster](/slides/vi/cpp/convert-powerpoint-to-png/), chúng sẽ được giữ nguyên cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout không, và giao diện của chúng có thể được giữ nguyên khi xuất không?**

Có. Aspose.Slides hỗ trợ [nhúng phông chữ](/slides/vi/cpp/embedded-font/) vào bài thuyết trình và kiểm soát việc nhúng phông chữ trong quá trình xuất như [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), đảm bảo các callout hiển thị giống nhau trên các hệ thống khác nhau.