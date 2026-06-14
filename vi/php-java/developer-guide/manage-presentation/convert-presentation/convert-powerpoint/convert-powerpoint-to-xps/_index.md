---
title: Chuyển đổi Bài thuyết trình PowerPoint sang XPS trong PHP
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, không phụ thuộc vào nền tảng bằng cách sử dụng Aspose.Slides cho PHP qua Java. Nhận hướng dẫn chi tiết từng bước và mã mẫu."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi bài thuyết trình PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và hướng dẫn cách thực hiện chuyển đổi với Aspose.Slides bằng cài đặt mặc định hoặc cài đặt tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xpsoptions/).

## **Giới thiệu về XPS**
Microsoft đã phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một lựa chọn thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách xuất ra một tệp rất giống PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS giữ nguyên trên mọi hệ điều hành và máy in. 

## **Khi nào nên sử dụng Định dạng XPS của Microsoft**

{{% alert color="primary" %}} 

Để xem Aspose.Slides chuyển đổi bài thuyết trình PPT hoặc PPTX sang định dạng XPS như thế nào, bạn có thể truy cập [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bài thuyết trình Microsoft PowerPoint sang định dạng XPS. Nhờ vậy, việc lưu, chia sẻ và in tài liệu sẽ trở nên dễ dàng hơn. 

Microsoft vẫn tiếp tục hỗ trợ mạnh mẽ cho XPS trên Windows (ngay cả trên Windows 10), vì vậy bạn có thể cân nhắc lưu tệp ở định dạng này. Nếu bạn đang làm việc với Windows 8.1, Windows 8, Windows 7 và Windows Vista, XPS có thể thực sự là lựa chọn tốt nhất cho một số thao tác nhất định. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho tệp XPS. OXPS là phiên bản chuẩn hoá của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho tệp XPS so với tệp PDF. 
  - **XPS:** Có trình xem/XPS tích hợp và tính năng in ra XPS. 
  - **PDF:** Có trình đọc PDF nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Các hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho tệp XPS so với PDF. 
  - **XPS:** Có trình xem XPS tích hợp và tính năng in ra XPS. 
  - **PDF:** Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ chức năng in PDF thông qua tính năng Print to PDF trên Windows 10. Trước đó, người dùng thường phải in tài liệu qua định dạng XPS. 

## **Chuyển đổi XPS với Aspose.Slides**

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/php-java/) cho Java, bạn có thể sử dụng phương thức [**Save**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) để chuyển đổi toàn bộ bài thuyết trình thành tài liệu XPS.

Khi chuyển đổi bài thuyết trình sang XPS, bạn phải lưu bài thuyết trình bằng một trong các cài đặt sau:

- Cài đặt mặc định (không dùng [**XPSOptions**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xpsoptions))
- Cài đặt tùy chỉnh (với [**XPSOptions**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xpsoptions))

### **Chuyển đổi Bài thuyết trình sang XPS bằng Cài đặt Mặc định**

Đoạn mã mẫu dưới đây cho thấy cách chuyển đổi một bài thuyết trình sang tài liệu XPS bằng cài đặt tiêu chuẩn:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Lưu bài thuyết trình thành tài liệu XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Chuyển đổi Bài thuyết trình sang XPS bằng Cài đặt Tùy chỉnh**
Đoạn mã mẫu dưới đây cho thấy cách chuyển đổi một bài thuyết trình sang tài liệu XPS bằng cài đặt tùy chỉnh:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Khởi tạo lớp TiffOptions
    $options = new XpsOptions();
    # Lưu MetaFiles dưới dạng PNG
    $options->setSaveMetafilesAsPng(true);
    # Lưu bài thuyết trình thành tài liệu XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu XPS vào stream thay vì tệp không?**

Có — Aspose.Slides cho phép bạn xuất trực tiếp ra stream, rất thích hợp cho API web, pipeline phía máy chủ, hoặc bất kỳ trường hợp nào bạn muốn gửi XPS mà không cần chạm tới hệ thống tệp.

**Các slide ẩn có được chuyển sang XPS không, và tôi có thể loại bỏ chúng không?**

Mặc định, chỉ các slide thường (có thể hiển thị) được render. Bạn có thể [bao gồm hoặc loại bỏ các slide ẩn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) thông qua [cài đặt xuất](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xpsoptions/) trước khi lưu sang XPS, đảm bảo đầu ra chứa đúng các trang bạn mong muốn.