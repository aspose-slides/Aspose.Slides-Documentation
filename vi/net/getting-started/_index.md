---
title: Bắt đầu
type: docs
weight: 10
url: /vi/net/getting-started/
keywords:
- bắt đầu
- yêu cầu hệ thống
- cài đặt
- bản trình bày đầu tiên
- NuGet
- xử lý PPT
- xử lý PPTX
- xử lý ODP
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quá trình từ một dự án .NET mới đến bản trình bày đầu tiên được lưu bằng Aspose.Slides: kiểm tra yêu cầu, cài đặt gói, chạy chương trình đầu tiên, và tiếp tục với các tác vụ phổ biến."
---
## **Tổng quan**

Thực hiện bốn bước dưới đây theo thứ tự. Mỗi bước ghi rõ những việc cần làm và liên kết đến bài viết chi tiết. Đánh giá, cấp phép và hỗ trợ được trình bày sau các bước.

## **Bước 1: Kiểm tra yêu cầu hệ thống**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) chạy trên Windows, Linux và macOS. [Yêu cầu hệ thống](/slides/vi/net/system-requirements/) liệt kê các hệ điều hành và phiên bản .NET mà mỗi gói hỗ trợ, và các thư viện mà Linux cần thêm.

## **Bước 2: Cài đặt gói**

Aspose.Slides for .NET được phân phối qua NuGet dưới dạng hai gói cung cấp cùng các lớp. Thêm một trong số chúng vào dự án của bạn:

- Trên Windows: `dotnet add package Aspose.Slides.NET`
- Trên Linux và macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Trên Linux, cài đặt thư viện `fontconfig` trước.
- Trên Alpine Linux, và trên các hệ thống Linux có glibc cũ hơn 2.23 (x64) hoặc 2.39 (ARM64): Aspose.Slides.NET, với thư viện `libgdiplus` đã được cài đặt.

[Cài đặt](/slides/vi/net/installation/) cung cấp các lệnh Linux, cài đặt khởi động bổ sung mà Aspose.Slides.NET cần trên Linux, và các bước cho Visual Studio.

## **Bước 3: Tạo bản trình bày đầu tiên của bạn**

Bản [bắt đầu nhanh trên trang chủ Aspose.Slides for .NET](/slides/vi/net/#your-first-presentation) là một chương trình console đầy đủ: nó thêm một hộp văn bản vào một slide và lưu bản trình bày dưới dạng file PPTX. [Tạo bản trình bày](/slides/vi/net/create-presentation/) giải thích các bước tương tự chi tiết hơn và cho thấy cách mở một bản trình bày hiện có và lưu nó sang định dạng khác.

## **Bước 4: Tiếp tục với các tác vụ phổ biến**

- [Mở một bản trình bày](/slides/vi/net/open-presentation/)
- [Lưu một bản trình bày](/slides/vi/net/save-presentation/)
- [Chuyển đổi bản trình bày sang PDF](/slides/vi/net/convert-powerpoint-to-pdf/)
- [Kết xuất các slide thành ảnh](/slides/vi/net/convert-slide/)
- [Chỉnh sửa văn bản bản trình bày](/slides/vi/net/manage-text/)
- [Ví dụ theo phần tử slide](/slides/vi/net/examples/)

## **Đánh giá và Cấp phép**

Nếu không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó thêm một hình mờ lên mỗi slide khi lưu và cắt bớt văn bản đọc từ các bản trình bày.

- [Đánh giá Aspose.Slides](/slides/vi/net/evaluate-aspose-slides/) mô tả các hạn chế của chế độ đánh giá và cách yêu cầu giấy phép tạm thời.
- [Cấp phép](/slides/vi/net/licensing/) cho biết cách áp dụng giấy phép từ tệp, luồng hoặc tài nguyên nhúng.
- [Cấp phép theo mức sử dụng](/slides/vi/net/metered-licensing/) đề cập đến việc cấp phép dựa trên mức sử dụng.
- [Định dạng tệp được hỗ trợ](/slides/vi/net/supported-file-formats/) liệt kê các định dạng mà Aspose.Slides có thể tải và lưu.

## **Nhận trợ giúp**

[Hỗ trợ sản phẩm](/slides/vi/net/product-support/) giải thích cách đặt câu hỏi trên [diễn đàn hỗ trợ miễn phí](https://forum.aspose.com/c/slides/11) và những gì cần bao gồm khi bạn báo cáo một vấn đề.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint không?**

Không. Aspose.Slides tự đọc và ghi các tệp bản trình bày và không sử dụng PowerPoint, vì vậy nó cũng chạy trên máy chủ và trên Linux.

**Tôi nên sử dụng gói nào cho ứng dụng .NET Framework?**

Aspose.Slides.NET. Nó bao gồm các bản dựng cho .NET Framework 4.6.2 trở lên, .NET 6 trở lên, và .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform yêu cầu .NET 6 trở lên.