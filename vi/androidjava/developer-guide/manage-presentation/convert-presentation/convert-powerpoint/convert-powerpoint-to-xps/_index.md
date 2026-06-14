---
title: Chuyển đổi Bản thuyết trình PowerPoint sang XPS trên Android
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, độc lập nền tảng trong Java bằng Aspose.Slides cho Android. Nhận hướng dẫn từng bước và mã mẫu."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bản thuyết trình PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và trình bày cách thực hiện chuyển đổi với Aspose.Slides bằng cách sử dụng cài đặt mặc định hoặc tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xpsoptions/) settings.

## **Về XPS**
Microsoft đã phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một sự thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách xuất ra một tệp rất giống PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS vẫn giữ nguyên trên mọi hệ điều hành và máy in. 

## **Khi nào nên sử dụng định dạng Microsoft XPS**

{{% alert color="primary" %}} 

Để xem cách Aspose.Slides chuyển đổi bản thuyết trình PPT hoặc PPTX sang định dạng XPS, bạn có thể truy cập [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bản thuyết trình Microsoft PowerPoint sang định dạng XPS. Cách này sẽ giúp bạn dễ dàng lưu, chia sẻ và in tài liệu hơn. 

Microsoft tiếp tục triển khai hỗ trợ mạnh mẽ cho XPS trong Windows (ngay cả trong Windows 10), vì vậy bạn có thể cân nhắc lưu tệp ở định dạng này. Nếu bạn đang làm việc với Windows 8.1, Windows 8, Windows 7 và Windows Vista, thì XPS có thể là lựa chọn tốt nhất cho một số thao tác nhất định. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho các tệp XPS. OXPS là phiên bản chuẩn hoá của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho tệp XPS so với tệp PDF. 
  - **XPS:** Trình xem/đọc XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Trình đọc PDF có sẵn nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Những hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho tệp XPS so với PDF. 
  - **XPS:** Trình xem XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF:** Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ các thao tác in trong PDF thông qua tính năng Print to PDF trong Windows 10. Trước đó, người dùng được yêu cầu in tài liệu qua định dạng XPS. 

## **Chuyển đổi XPS với Aspose.Slides**

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/androidjava/) cho Java, bạn có thể sử dụng phương thức [**Save**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) để chuyển đổi toàn bộ bản thuyết trình thành tài liệu XPS.

Khi chuyển đổi bản thuyết trình sang XPS, bạn phải lưu bản thuyết trình bằng một trong các cài đặt sau:

- Cài đặt mặc định (không có [**XPSOptions**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xpsoptions))
- Cài đặt tùy chỉnh (có [**XPSOptions**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xpsoptions))

### **Chuyển đổi bản thuyết trình sang XPS bằng cài đặt mặc định**

Mã mẫu này trong Java cho thấy cách chuyển đổi một bản thuyết trình thành tài liệu XPS bằng cài đặt tiêu chuẩn:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Lưu bản thuyết trình thành tài liệu XPS
    pres.save("XPS_Output_Without_XPSOption.xls", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Chuyển đổi bản thuyết trình sang XPS bằng cài đặt tùy chỉnh**
Mã mẫu này cho thấy cách chuyển đổi một bản thuyết trình thành tài liệu XPS bằng cài đặt tùy chỉnh trong Java:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Khởi tạo lớp TiffOptions
    XpsOptions options = new XpsOptions();

    // Lưu MetaFiles dưới dạng PNG
    options.setSaveMetafilesAsPng(true);

    // Lưu bản thuyết trình thành tài liệu XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Có thể lưu XPS vào stream thay vì tệp không?**

Có—Aspose.Slides cho phép bạn xuất trực tiếp ra một stream, điều này lý tưởng cho API web, pipeline phía máy chủ, hoặc bất kỳ kịch bản nào bạn muốn gửi XPS mà không chạm tới hệ thống tệp.

**Các slide ẩn có được chuyển sang XPS không, và tôi có thể loại bỏ chúng không?**

Mặc định, chỉ các slide thường (hiển thị) được render. Bạn có thể [include or exclude hidden slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) thông qua [export settings](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xpsoptions/) trước khi lưu sang XPS, đảm bảo đầu ra chứa chính xác các trang bạn muốn.