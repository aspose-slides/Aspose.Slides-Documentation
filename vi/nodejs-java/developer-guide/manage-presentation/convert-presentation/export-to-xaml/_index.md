---
title: Xuất Bản Trình Chiếu sang XAML trong JavaScript
linktitle: Trình chiếu sang XAML
type: docs
weight: 30
url: /vi/nodejs-java/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- bản trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong JavaScript bằng Aspose.Slides cho Node.js—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, hướng dẫn cách lưu một bản trình chiếu dưới dạng XAML với các thiết lập mặc định, và minh họa cách tùy chỉnh quá trình xuất qua [XamlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích với các ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn xây dựng hoặc viết các lớp người dùng cho ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin Forms.

XAML, một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện người dùng. Bạn thường sẽ sử dụng trình thiết kế để làm việc với các tệp XAML, nhưng vẫn có thể viết và chỉnh sửa giao diện của mình bằng tay.

## **Xuất Bản Trình Chiếu Sang XAML Với Các Tùy Chọn Mặc Định**

Đoạn mã JavaScript sau cho thấy cách xuất một bản trình chiếu sang XAML với các thiết lập mặc định:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xuất Bản Trình Chiếu Sang XAML Với Các Tùy Chọn Tùy Chỉnh**

Bạn có thể chọn các tùy chọn từ lớp [XamlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/XamlOptions) để kiểm soát quá trình xuất và xác định cách Aspose.Slides xuất bản trình chiếu của bạn sang XAML.

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bản trình chiếu khi xuất sang XAML, bạn có thể đặt phương thức [setExportHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) thành true. Xem đoạn mã JavaScript mẫu sau:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Sử dụng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [XamlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xamloptions/) — nó được dùng làm phông chữ dự phòng khi phông chữ gốc bị thiếu. Điều này giúp tránh các sự thay thế không mong muốn.

**XAML xuất ra chỉ dành cho WPF hay có thể dùng được trong các ngăn xếp XAML khác không?**

XAML là một ngôn ngữ markup UI chung được sử dụng trong WPF, UWP và Xamarin.Forms. Đầu ra được thiết kế để tương thích với các ngăn xếp XAML của Microsoft; hành vi cụ thể và hỗ trợ các cấu trúc phụ thuộc vào nền tảng mục tiêu. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm thế nào để ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này bằng cách sử dụng [setExportHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/xamloptions/) — giữ chế độ tắt nếu bạn không muốn xuất chúng.