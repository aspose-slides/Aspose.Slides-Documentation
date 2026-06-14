---
title: Xuất Bản Trình Chiếu sang XAML trong PHP
linktitle: Trình chiếu sang XAML
type: docs
weight: 30
url: /vi/php-java/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML bằng Aspose.Slides cho PHP qua Java — giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất các bài thuyết trình PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm một phần giới thiệu ngắn gọn về XAML, cho biết cách lưu một bài thuyết trình dưới dạng XAML với cài đặt mặc định, và minh họa cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một vài câu hỏi phổ biến liên quan đến phông chữ dự phòng, khả năng tương thích với các ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn xây dựng hoặc viết giao diện người dùng cho các ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin Forms.  

XAML, một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện đồ họa (GUI). Bạn thường sử dụng trình thiết kế để làm việc với các tệp XAML, nhưng vẫn có thể tự viết và chỉnh sửa GUI bằng tay.

## **Xuất bản trình chiếu sang XAML với tùy chọn mặc định**

Mã PHP này cho bạn thấy cách xuất một bài thuyết trình sang XAML với cài đặt mặc định:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xuất bản trình chiếu sang XAML với tùy chọn tùy chỉnh**

Bạn có thể chọn các tùy chọn từ lớp [XamlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/) để điều khiển quá trình xuất và xác định cách Aspose.Slides xuất bản trình chiếu của bạn sang XAML.

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bản trình chiếu khi xuất sang XAML, bạn có thể sử dụng phương thức [setExportHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/setexporthiddenslides/) với giá trị `true`. Xem đoạn mã PHP mẫu này:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [một phông chữ chuẩn mặc định](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [XamlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/) — nó sẽ được sử dụng làm phông chữ dự phòng khi phông chữ gốc thiếu. Điều này giúp tránh các sự thay thế không mong muốn.

**XAML xuất ra chỉ dành cho WPF hay có thể được sử dụng trong các ngăn xếp XAML khác không?**

XAML là một ngôn ngữ đánh dấu UI chung được sử dụng trong WPF, UWP và Xamarin.Forms. Việc xuất nhằm mục đích tương thích với các ngăn xếp XAML của Microsoft; hành vi cụ thể và hỗ trợ các cấu trúc nhất định phụ thuộc vào nền tảng mục tiêu. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao ngăn chúng không được xuất mặc định?**

Mặc định, các slide ẩn sẽ không được bao gồm. Bạn có thể kiểm soát hành vi này thông qua [setExportHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/setexporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/) — giữ nó bị tắt nếu bạn không muốn xuất các slide ẩn.