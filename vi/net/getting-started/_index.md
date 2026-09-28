---
title: Bắt đầu
type: docs
weight: 10
url: /vi/net/getting-started/
keywords:
- bắt đầu
- yêu cầu hệ thống
- cài đặt
- bài thuyết trình đầu tiên
- NuGet
- xử lý PPT
- xử lý PPTX
- xử lý ODP
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quá trình từ một dự án .NET mới đến bài thuyết trình đầu tiên được lưu bằng Aspose.Slides: kiểm tra yêu cầu, cài đặt gói, chạy chương trình đầu tiên, và tiếp tục với các tác vụ chung."
---
## **Tổng quan**

Thực hiện bốn bước dưới đây theo thứ tự. Mỗi bước nêu rõ những gì cần làm và liên kết tới bài viết chi tiết. Đánh giá, cấp phép và hỗ trợ được đề cập sau các bước.

## **Bước 1: Kiểm tra yêu cầu hệ thống**

Aspose.Slides for .NET chạy trên Windows, Linux và macOS. [System Requirements](/slides/vi/net/system-requirements/) liệt kê các hệ điều hành và phiên bản .NET mà mỗi gói hỗ trợ, cũng như các thư viện mà Linux cần thêm.

## **Bước 2: Cài đặt gói**

Aspose.Slides for .NET được phân phối qua NuGet dưới dạng hai gói cung cấp cùng các lớp. Thêm một trong số chúng vào dự án của bạn:

- Trên Windows: `dotnet add package Aspose.Slides.NET`
- Trên Linux và macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Trên Linux, cần cài đặt thư viện `fontconfig` trước.
- Trên Alpine Linux, và trên các hệ thống Linux có glibc cũ hơn 2.23 (x64) hoặc 2.39 (ARM64): Aspose.Slides.NET, với thư viện `libgdiplus` đã được cài đặt.

[Installation](/slides/vi/net/installation/) cung cấp các lệnh Linux, cài đặt khởi động bổ sung mà Aspose.Slides.NET cần trên Linux, và các bước cho Visual Studio.

## **Bước 3: Tạo bài thuyết trình đầu tiên của bạn**

[quick start on the Aspose.Slides for .NET home page](/slides/vi/net/#your-first-presentation) là một chương trình console đầy đủ: nó thêm một hộp văn bản vào slide và lưu bài thuyết trình dưới dạng tệp PPTX. [Create Presentations](/slides/vi/net/create-presentation/) giải thích các bước tương tự chi tiết hơn và chỉ cách mở một bài thuyết trình hiện có và lưu nó sang định dạng khác.

## **Bước 4: Tiếp tục với các tác vụ phổ biến**

- [Open a presentation](/slides/vi/net/open-presentation/)
- [Save a presentation](/slides/vi/net/save-presentation/)
- [Convert a presentation to PDF](/slides/vi/net/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/vi/net/convert-slide/)
- [Edit presentation text](/slides/vi/net/manage-text/)
- [Examples by slide element](/slides/vi/net/examples/)

## **Đánh giá và Cấp phép**

Nếu không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó thêm watermark vào mỗi slide khi lưu và cắt bớt văn bản được đọc từ các bài thuyết trình.

- [Evaluate Aspose.Slides](/slides/vi/net/evaluate-aspose-slides/) mô tả các hạn chế của chế độ đánh giá và cách yêu cầu giấy phép tạm thời.
- [Licensing](/slides/vi/net/licensing/) chỉ ra cách áp dụng giấy phép từ tệp, luồng hoặc tài nguyên nhúng.
- [Metered Licensing](/slides/vi/net/metered-licensing/) đề cập đến giấy phép được tính phí theo mức sử dụng.
- [Supported File Formats](/slides/vi/net/supported-file-formats/) liệt kê các định dạng mà Aspose.Slides có thể tải và lưu.

## **Nhận trợ giúp**

[Product Support](/slides/vi/net/product-support/) giải thích cách đặt câu hỏi trên [free support forum](https://forum.aspose.com/c/slides/vi/11) và những gì cần bao gồm khi báo cáo vấn đề.

## **FAQ**

**Tôi có cần cài đặt Microsoft PowerPoint không?**

Không. Aspose.Slides tự đọc và ghi các tệp bài thuyết trình và không sử dụng PowerPoint, vì vậy nó cũng chạy được trên máy chủ và trên Linux.

**Tôi nên sử dụng gói nào cho ứng dụng .NET Framework?**

Aspose.Slides.NET. Nó bao gồm các bản dựng cho .NET Framework 4.6.2 trở lên, .NET 6 trở lên và .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform yêu cầu .NET 6 trở lên.