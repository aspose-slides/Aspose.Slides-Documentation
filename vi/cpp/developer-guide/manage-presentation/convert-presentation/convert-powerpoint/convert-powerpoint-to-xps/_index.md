---
title: Chuyển đổi Bài thuyết trình PowerPoint sang XPS trong C++
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/cpp/convert-powerpoint-to-xps
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang XPS
- bài thuyết trình sang XPS
- slide sang XPS
- PPT sang XPS
- PPTX sang XPS
- lưu PPT dưới dạng XPS
- lưu PPTX dưới dạng XPS
- xuất PPT sang XPS
- xuất PPTX sang XPS
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, không phụ thuộc vào nền tảng trong C++ bằng Aspose.Slides. Nhận hướng dẫn từng bước và mã mẫu."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi bài thuyết trình PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và chỉ ra cách thực hiện việc chuyển đổi với Aspose.Slides bằng cách sử dụng cấu hình mặc định hoặc cấu hình tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/xpsoptions/) .

## **Về XPS**
Microsoft phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một lựa chọn thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách xuất ra một tệp rất giống PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS luôn giống nhau trên mọi hệ điều hành và máy in. 

## **Khi nào nên sử dụng định dạng Microsoft XPS**

{{% alert color="info" %}} 

Để xem Aspose.Slides chuyển đổi bài thuyết trình PPT hoặc PPTX sang định dạng XPS như thế nào, bạn có thể xem [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bài thuyết trình Microsoft PowerPoint sang định dạng XPS. Cách này sẽ giúp bạn dễ dàng lưu, chia sẻ và in tài liệu hơn. 

Microsoft vẫn tiếp tục triển khai hỗ trợ mạnh mẽ cho XPS trong Windows (kể cả Windows 10), vì vậy bạn có thể cân nhắc lưu tệp vào định dạng này. Nếu bạn làm việc với Windows 8.1, Windows 8, Windows 7 và Windows Vista, XPS có thể là lựa chọn tốt nhất cho một số thao tác. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho các tệp XPS. OXPS là phiên bản tiêu chuẩn hoá của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho các tệp XPS so với các tệp PDF. 
  - **XPS:** Trình xem/đọc XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Trình đọc PDF có sẵn nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Các hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho các tệp XPS so với PDF. 
  - **XPS:** Trình xem XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ các thao tác in trong PDF thông qua tính năng Print to PDF trong Windows 10. Trước đây, người dùng thường được yêu cầu in tài liệu qua định dạng XPS. 

## **Chuyển đổi XPS với Aspose.Slides**

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/cpp/) cho C++, bạn có thể sử dụng phương thức [**Save**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) để chuyển đổi toàn bộ bài thuyết trình thành tài liệu XPS. 

Khi chuyển đổi một bài thuyết trình sang XPS, bạn phải lưu bài thuyết trình bằng một trong các cấu hình sau:

- Cấu hình mặc định (không sử dụng [**XPSOptions**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.xps_options))
- Cấu hình tùy chỉnh (sử dụng [**XPSOptions**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.xps_options))

### **Chuyển đổi bài thuyết trình sang XPS bằng cấu hình mặc định**

Mã mẫu bằng C++ sau đây cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu XPS bằng cấu hình tiêu chuẩn:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Lưu bài thuyết trình dưới dạng tài liệu XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Chuyển đổi bài thuyết trình sang XPS bằng cấu hình tùy chỉnh**
Mã mẫu này cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu XPS bằng cấu hình tùy chỉnh trong C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Khởi tạo lớp TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Lưu MetaFiles dưới dạng PNG
options->set_SaveMetafilesAsPng(true);

// Lưu bài thuyết trình dưới dạng tài liệu XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Câu hỏi thường gặp**

### Tôi có thể lưu XPS vào stream thay vì tệp không?

Có—Aspose.Slides cho phép bạn xuất trực tiếp tới một stream, rất phù hợp cho các API web, pipeline phía máy chủ, hoặc bất kỳ kịch bản nào mà bạn muốn gửi XPS mà không cần thao tác với hệ thống tệp.

### Các slide ẩn có được chuyển sang XPS không, và tôi có thể loại bỏ chúng không?

Mặc định, chỉ các slide thường (có thể nhìn thấy) được render. Bạn có thể [bao gồm hoặc loại bỏ các slide ẩn](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) thông qua [các thiết lập xuất](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/xpsoptions/) trước khi lưu sang XPS, đảm bảo đầu ra chỉ chứa các trang bạn mong muốn.