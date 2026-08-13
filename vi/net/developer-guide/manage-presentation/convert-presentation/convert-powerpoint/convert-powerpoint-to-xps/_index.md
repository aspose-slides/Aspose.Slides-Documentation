---
title: Chuyển đổi bản trình chiếu PowerPoint sang XPS trong .NET
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/net/convert-powerpoint-to-xps/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang XPS
- bản trình chiếu sang XPS
- slide sang XPS
- PPT sang XPS
- PPTX sang XPS
- lưu PPT dưới dạng XPS
- lưu PPTX dưới dạng XPS
- xuất PPT sang XPS
- xuất PPTX sang XPS
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, độc lập nền tảng trong .NET bằng Aspose.Slides. Nhận hướng dẫn từng bước và mã mẫu C#."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bản trình chiếu PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và cho thấy cách thực hiện chuyển đổi với Aspose.Slides bằng cách sử dụng cài đặt mặc định hoặc tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions/) .

## **Giới thiệu về XPS**
Microsoft đã phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một giải pháp thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách xuất một tệp rất giống với PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS vẫn giống nhau trên mọi hệ điều hành và máy in. 

## **Khi nào nên sử dụng định dạng Microsoft XPS**

{{% alert color="info" %}} 

Để xem cách Aspose.Slides chuyển đổi bản trình chiếu PPT hoặc PPTX sang định dạng XPS, bạn có thể truy cập [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bản trình chiếu Microsoft PowerPoint sang định dạng XPS. Cách này sẽ giúp bạn dễ dàng lưu, chia sẻ và in tài liệu hơn. 

Microsoft tiếp tục triển khai hỗ trợ mạnh mẽ cho XPS trên Windows (kể cả Windows 10), vì vậy bạn có thể cân nhắc lưu tệp vào định dạng này. Nếu bạn đang làm việc trên Windows 8.1, Windows 8, Windows 7 và Windows Vista, thì XPS có thể là lựa chọn tốt nhất cho một số hoạt động. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho các tệp XPS. OXPS là phiên bản tiêu chuẩn của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho các tệp XPS so với các tệp PDF. 
  - **XPS:** Trình xem/đọc XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Trình đọc PDF có sẵn nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Các hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho các tệp XPS so với PDF. 
  - **XPS:** Trình xem XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ các thao tác in trong PDF thông qua tính năng Print to PDF trên Windows 10. Trước đây, người dùng phải in tài liệu qua định dạng XPS. 

## **Chuyển đổi XPS với Aspose.Slides**

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/net/) cho .NET, bạn có thể sử dụng phương thức [**Save**](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save/index) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) để chuyển đổi toàn bộ bản trình chiếu thành tài liệu XPS. 

Khi chuyển đổi bản trình chiếu sang XPS, bạn phải lưu bản trình chiếu bằng một trong các cài đặt sau:

- Cài đặt mặc định (không có [**XPSOptions**](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions))
- Cài đặt tùy chỉnh (có [**XPSOptions**](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions))

### **Chuyển đổi bản trình chiếu sang XPS bằng Cài đặt Mặc định**

Mã mẫu này bằng C# cho thấy cách chuyển đổi một bản trình chiếu thành tài liệu XPS sử dụng cài đặt tiêu chuẩn:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Lưu bản trình chiếu thành tài liệu XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Chuyển đổi bản trình chiếu sang XPS bằng Cài đặt Tùy chỉnh**
Mã mẫu này cho thấy cách chuyển đổi một bản trình chiếu thành tài liệu XPS sử dụng cài đặt tùy chỉnh bằng C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Khởi tạo lớp TiffOptions
    XpsOptions options = new XpsOptions();

    // Lưu MetaFiles dưới dạng PNG
    options.SaveMetafilesAsPng = true;

    // Lưu bản trình chiếu thành tài liệu XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **Câu hỏi thường gặp**

### Tôi có thể lưu XPS vào stream thay vì tệp không?

Có — Aspose.Slides cho phép bạn xuất trực tiếp tới một stream, rất lý tưởng cho các API web, quy trình phía máy chủ, hoặc bất kỳ kịch bản nào bạn muốn gửi XPS mà không cần chạm tới hệ thống tệp.

### Các slide ẩn có được chuyển sang XPS không, và tôi có thể loại bỏ chúng không?

Mặc định, chỉ các slide thường (có thể nhìn thấy) được render. Bạn có thể [bao gồm hoặc loại trừ các slide ẩn](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions/showhiddenslides/) thông qua [cài đặt xuất](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions/) trước khi lưu thành XPS, đảm bảo đầu ra chứa chính xác các trang bạn muốn.