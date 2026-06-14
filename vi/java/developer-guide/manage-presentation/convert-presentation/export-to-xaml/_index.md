---
title: Xuất bản trình chiếu sang XAML trong Java
linktitle: Bản trình chiếu sang XAML
type: docs
weight: 30
url: /vi/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong Java bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, cho thấy cách lưu một bản trình chiếu dưới dạng XAML với cài đặt mặc định, và minh họa cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích của ngăn xếp XAML và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn xây dựng hoặc viết giao diện người dùng cho các ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin Forms.  

XAML, một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện đồ họa người dùng (GUI). Bạn thường sẽ sử dụng một công cụ thiết kế để làm việc với các tệp XAML, nhưng vẫn có thể viết và chỉnh sửa GUI bằng tay.

## **Xuất bản trình chiếu sang XAML với tùy chọn mặc định**

Mã Java này cho bạn thấy cách xuất một bản trình chiếu sang XAML với các thiết lập mặc định:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Xuất bản trình chiếu sang XAML với tùy chọn tùy chỉnh**

Bạn có thể chọn các tùy chọn từ giao diện [IXamlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IXamlOptions) để điều khiển quá trình xuất và xác định cách Aspose.Slides xuất bản trình chiếu của bạn sang XAML. 

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bản trình chiếu khi xuất ra XAML, bạn có thể đặt thuộc tính [ExportHiddenSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) thành true. Xem đoạn mã Java mẫu này:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [phông chữ thường mặc định](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) trong [XamlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/xamloptions/) — nó sẽ được dùng làm phông chữ dự phòng khi phông chữ gốc không tồn tại. Điều này giúp tránh các việc thay thế không mong muốn.

**XAML được xuất ra chỉ dành cho WPF hay có thể sử dụng trong các ngăn xếp XAML khác không?**

XAML là một ngôn ngữ đánh dấu UI chung được sử dụng trong WPF, UWP và Xamarin.Forms. Quá trình xuất nhằm tương thích với các ngăn xếp XAML của Microsoft; hành vi cụ thể và hỗ trợ cho các cấu trúc nhất định phụ thuộc vào nền tảng mục tiêu. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao để ngăn chúng được xuất ra mặc định?**

Mặc định, các slide ẩn sẽ không được bao gồm. Bạn có thể kiểm soát hành vi này qua [setExportHiddenSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) trong [XamlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/xamloptions/) — giữ nó ở trạng thái tắt nếu bạn không cần xuất các slide ẩn.