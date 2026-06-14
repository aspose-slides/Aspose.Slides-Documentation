---
title: Quản lý Callout trong Biểu đồ Bài thuyết trình sử dụng С++
linktitle: Ghi chú
type: docs
url: /vi/cpp/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- bài thuyết trình
- С++
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho С++ với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hoá quy trình làm việc của bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng phương thức `set_ShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các cài đặt nhãn liên quan đến callout cho biểu đồ Donut, và lưu ý rằng callout và giao diện của chúng được bảo tồn khi bài thuyết trình được xuất sang các định dạng PDF, HTML5, SVG và raster image.

## **Sử dụng Callout**

Thuộc tính mới **ShowLabelAsDataCallout** đã được thêm vào lớp **DataLabelFormat** và giao diện **IDataLabelFormat**, xác định liệu nhãn dữ liệu của biểu đồ đã chỉ định sẽ được hiển thị dưới dạng data callout hay là nhãn dữ liệu. Trong ví dụ dưới đây, chúng tôi đã thiết lập Callout.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Đặt Callout cho Biểu đồ Donut**

Aspose.Slides for C++ cung cấp hỗ trợ để đặt hình dạng callout cho nhãn dữ liệu của series trong biểu đồ Donut. Dưới đây là ví dụ mẫu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Câu hỏi thường gặp**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Có. Callout là một phần của việc render biểu đồ, vì vậy khi bạn xuất sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/cpp/export-to-html5/), [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), hoặc [hình ảnh raster](/slides/vi/cpp/convert-powerpoint-to-png/), chúng được bảo tồn cùng với định dạng của slide.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Có. Aspose.Slides hỗ trợ [nhúng phông chữ](/slides/vi/cpp/embedded-font/) vào bài thuyết trình và kiểm soát việc nhúng phông chữ trong quá trình xuất như [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), đảm bảo callout trông giống nhau trên các hệ thống khác nhau.