---
title: Chuyển đổi Bài thuyết trình PowerPoint sang XPS trong Python
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/python-net/convert-powerpoint-to-xps/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- PowerPoint sang XPS
- bài thuyết trình sang XPS
- PPT sang XPS
- PPTX sang XPS
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, không phụ thuộc vào nền tảng trong Python bằng Aspose.Slides. Nhận hướng dẫn từng bước và mã mẫu."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi bài thuyết trình PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và chỉ ra cách thực hiện chuyển đổi bằng Aspose.Slides sử dụng cài đặt mặc định hoặc tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/xpsoptions/) settings.

## **Về XPS**
Microsoft phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một lựa chọn thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách xuất ra một tệp rất giống PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS vẫn giống nhau trên mọi hệ điều hành và máy in. 

## Khi nào nên sử dụng định dạng Microsoft XPS

{{% alert color="primary" %}} 
Để xem cách Aspose.Slides chuyển đổi bài thuyết trình PPT hoặc PPTX sang định dạng XPS, bạn có thể truy cập [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bài thuyết trình Microsoft PowerPoint sang định dạng XPS. Bằng cách này, việc lưu, chia sẻ và in tài liệu sẽ dễ dàng hơn. 

Microsoft tiếp tục cung cấp hỗ trợ mạnh mẽ cho XPS trong Windows (ngay cả trong Windows 10), vì vậy bạn có thể cân nhắc lưu tệp dưới định dạng này. Nếu bạn đang làm việc với Windows 8.1, Windows 8, Windows 7 và Windows Vista, XPS có thể là lựa chọn tốt nhất cho một số thao tác nhất định. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho các tệp XPS. OXPS là phiên bản tiêu chuẩn hoá của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho các tệp XPS so với các tệp PDF. 
  - **XPS:** Trình xem/đọc XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Trình đọc PDF có sẵn nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Các hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho các tệp XPS so với PDF. 
  - **XPS:** Trình xem XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPT:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-ppptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ in tài liệu ở định dạng PDF thông qua tính năng Print to PDF trong Windows 10. Trước đây, người dùng thường phải in tài liệu qua định dạng XPS. 

## Chuyển đổi XPS với Aspose.Slides

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/python-net/) cho .NET, bạn có thể sử dụng phương thức [**Save**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để chuyển đổi toàn bộ bài thuyết trình thành một tài liệu XPS. 

Khi chuyển đổi một bài thuyết trình sang XPS, bạn phải lưu bài thuyết trình bằng một trong hai cài đặt sau:

- Cài đặt mặc định (không có [**XPSOptions**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/xpsoptions/))
- Cài đặt tùy chỉnh (có [**XPSOptions**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/xpsoptions/))

### **Chuyển đổi bài thuyết trình sang XPS bằng cài đặt mặc định**

Mã mẫu này trong Python cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu XPS bằng cài đặt tiêu chuẩn:

```py
import aspose.slides as slides

# Khởi tạo đối tượng Presentation đại diện cho tệp bài thuyết trình
pres = slides.Presentation("Convert_XPS.pptx")

# Lưu bài thuyết trình thành tài liệu XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Chuyển đổi bài thuyết trình sang XPS bằng cài đặt tùy chỉnh**
Mã mẫu này cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu XPS bằng cài đặt tùy chỉnh trong Python:

```py
import aspose.slides as slides

# Khởi tạo đối tượng Presentation đại diện cho tệp bài thuyết trình
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Khởi tạo lớp TiffOptions
options = slides.export.XpsOptions()

# Lưu MetaFiles dưới dạng PNG
options.save_metafiles_as_png = True

# Lưu bài thuyết trình thành tài liệu XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu XPS vào một stream thay vì tệp không?**

Có—Aspose.Slides cho phép bạn xuất trực tiếp vào một stream, rất phù hợp cho API web, pipeline phía máy chủ, hoặc bất kỳ trường hợp nào bạn muốn gửi XPS mà không cần ghi vào hệ thống tệp.

**Các slide ẩn có được chuyển sang XPS không, và tôi có thể loại bỏ chúng không?**

Mặc định, chỉ các slide thường (có thể nhìn thấy) được render. Bạn có thể [bao gồm hoặc loại trừ các slide ẩn](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) thông qua [cài đặt xuất](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/xpsoptions/) trước khi lưu thành XPS, đảm bảo kết quả chứa đúng các trang bạn muốn.