---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày bằng C++
linktitle: Chú giải biểu đồ
type: docs
url: /vi/cpp/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho C++ để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bản trình bày PowerPoint. Bài viết này trình bày cách định vị và kích thước một chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng đề cập đến một số hành vi liên quan trong mục Câu hỏi thường gặp, bao gồm việc sử dụng chế độ không chồng lên để vùng vẽ nhường chỗ cho chú giải, cho phép nhãn chú giải dài tự động ngắt dòng hoặc sử dụng ký tự xuống dòng, và cho phép định dạng chú giải kế thừa từ giao diện bài thuyết trình khi không áp dụng các thiết lập màu sắc, nền hoặc phông chữ cụ thể.

## **Định vị Chú giải**
Để thiết lập các thuộc tính của chú giải, hãy thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
- Lấy tham chiếu của slide.
- Thêm một biểu đồ vào slide.
- Thiết lập các thuộc tính của chú giải.
- Ghi bản trình bày dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt vị trí và kích thước cho chú giải biểu đồ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Đặt Kích thước Phông chữ cho một Chú giải**
Aspose.Slides cho C++ cho phép nhà phát triển đặt kích thước phông chữ của chú giải. Vui lòng làm theo các bước sau:

- Khởi tạo lớp Presentation.
- Tạo biểu đồ mặc định.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Đặt Kích thước Phông chữ cho một Mục Chú giải Cá nhân**
Aspose.Slides cho C++ cho phép nhà phát triển đặt kích thước phông chữ cho các mục chú giải riêng lẻ. Vui lòng làm theo các bước sau:

- Khởi tạo lớp Presentation.
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể bật chú giải để biểu đồ tự động dành chỗ cho nó thay vì chồng lên không?**

Có. Sử dụng chế độ không chồng lên ([set_Overlay(false)](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/legend/set_overlay/)); trong trường hợp này, vùng vẽ sẽ co lại để chứa chú giải.

**Tôi có thể tạo nhãn chú giải dạng đa dòng không?**

Có. Nhãn dài sẽ tự động ngắt dòng khi không đủ không gian; việc buộc ngắt dòng cũng được hỗ trợ thông qua ký tự xuống dòng trong tên chuỗi.

**Làm thế nào để chú giải tuân theo bảng màu của giao diện bài thuyết trình?**

Không đặt màu sắc, nền hoặc phông chữ cụ thể cho chú giải hoặc văn bản của nó. Chúng sẽ kế thừa từ giao diện và sẽ cập nhật đúng khi thiết kế thay đổi.