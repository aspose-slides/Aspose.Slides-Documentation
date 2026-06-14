---
title: Chuyển đổi bản thuyết trình PowerPoint sang XPS trong JavaScript
linktitle: PowerPoint sang XPS
type: docs
weight: 70
url: /vi/nodejs-java/convert-powerpoint-to-xps/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang XPS
- bản thuyết trình sang XPS
- slide sang XPS
- PPT sang XPS
- PPTX sang XPS
- lưu PPT dưới dạng XPS
- lưu PPTX dưới dạng XPS
- xuất PPT sang XPS
- xuất PPTX sang XPS
- PowerPoint
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang XPS chất lượng cao, độc lập nền tảng trong JavaScript bằng Aspose.Slides cho Node.js. Nhận hướng dẫn chi tiết từng bước và mã mẫu."
---
## **Overview**

Aspose.Slides cho phép bạn chuyển đổi các bản thuyết trình PowerPoint sang XPS bằng cách lưu tệp PPT hoặc PPTX ở định dạng XPS. Bài viết này giải thích khi nào định dạng XPS có thể hữu ích và chỉ ra cách thực hiện chuyển đổi với Aspose.Slides bằng cả cài đặt mặc định và cài đặt tùy chỉnh [XpsOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xpsoptions/) .

## **About XPS**

Microsoft đã phát triển [XPS](https://docs.fileformat.com/page-description-language/xps/) như một sự thay thế cho [PDF](https://docs.fileformat.com/pdf/). Nó cho phép bạn in nội dung bằng cách tạo ra một tệp rất giống PDF. Định dạng XPS dựa trên XML. Bố cục hoặc cấu trúc của tệp XPS vẫn giữ nguyên trên mọi hệ điều hành và máy in. 

## **When to Use Microsoft XPS Format**

{{% alert color="primary" %}} 

Để xem cách Aspose.Slides chuyển đổi bản thuyết trình PPT hoặc PPTX sang định dạng XPS, bạn có thể tham khảo [ứng dụng chuyển đổi trực tuyến miễn phí này](https://products.aspose.app/slides/vi/conversion). 

{{% /alert %}} 

Nếu bạn muốn giảm chi phí lưu trữ, bạn có thể chuyển đổi bản thuyết trình Microsoft PowerPoint sang định dạng XPS. Như vậy, việc lưu, chia sẻ và in ấn tài liệu sẽ trở nên dễ dàng hơn. 

Microsoft vẫn tiếp tục cung cấp hỗ trợ mạnh mẽ cho XPS trong Windows (ngay cả trên Windows 10), vì vậy bạn có thể cân nhắc lưu tệp ở định dạng này. Nếu bạn đang làm việc với Windows 8.1, Windows 8, Windows 7 và Windows Vista, XPS có thể là lựa chọn tốt nhất cho một số thao tác nhất định. 

- **Windows 8** sử dụng định dạng OXPS (Open XPS) cho các tệp XPS. OXPS là phiên bản tiêu chuẩn hoá của định dạng XPS gốc. Windows 8 cung cấp hỗ trợ tốt hơn cho tệp XPS so với tệp PDF. 
  - **XPS:** Trình xem/đọc XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF**: Trình đọc PDF có sẵn nhưng không có tính năng in ra PDF. 

- **Windows 7 và Windows Vista** sử dụng định dạng XPS gốc. Các hệ điều hành này cũng cung cấp hỗ trợ tốt hơn cho tệp XPS so với PDF. 
  - **XPS**: Trình xem XPS tích hợp và tính năng in ra XPS có sẵn. 
  - **PDF**: Không có trình đọc PDF. Không có tính năng in ra PDF. 

|<p>**Đầu vào PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Đầu ra XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft cuối cùng đã triển khai hỗ trợ cho các thao tác in qua tính năng Print to PDF trong Windows 10. Trước đây, người dùng phải in tài liệu thông qua định dạng XPS. 

## **XPS Conversion with Aspose.Slides**

Trong [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/vi/nodejs-java/), bạn có thể sử dụng phương thức [**save**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) để chuyển đổi toàn bộ bản thuyết trình thành tài liệu XPS.

Khi chuyển đổi bản thuyết trình sang XPS, bạn phải lưu bản thuyết trình bằng một trong các cài đặt sau:

- Cài đặt mặc định (không sử dụng [**XPSOptions**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xpsoptions))
- Cài đặt tùy chỉnh (với [**XPSOptions**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xpsoptions))

### **Converting Presentations to XPS Using Default Settings**

Mã mẫu này bằng JavaScript cho bạn thấy cách chuyển đổi bản thuyết trình sang tài liệu XPS bằng cài đặt tiêu chuẩn:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản thuyết trình
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Lưu bản thuyết trình thành tài liệu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Converting Presentations to XPS Using Custom Settings**

Mã mẫu này cho bạn thấy cách chuyển đổi bản thuyết trình sang tài liệu XPS bằng cài đặt tùy chỉnh trong JavaScript:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Khởi tạo lớp TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Lưu MetaFiles dưới dạng PNG
    options.setSaveMetafilesAsPng(true);
    // Lưu bản thuyết trình thành tài liệu XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I save to XPS into a stream instead of a file?**

Yes—Aspose.Slides lets you export directly to a stream, which is ideal for web APIs, server-side pipelines, or any scenario where you want to send the XPS without touching the file system.

**Are hidden slides carried over to XPS, and can I exclude them?**

By default, only regular (visible) slides are rendered. You can [include or exclude hidden slides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) through [export settings](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xpsoptions/) before saving to XPS, ensuring the output contains exactly the pages you intend.