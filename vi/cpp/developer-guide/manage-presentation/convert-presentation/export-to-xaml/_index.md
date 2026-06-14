---
title: Xuất bản trình chiếu sang XAML trong C++
linktitle: Bản trình chiếu sang XAML
type: docs
weight: 30
url: /vi/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong C++ bằng Aspose.Slides—giải pháp nhanh, không phụ thuộc vào Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm một phần giới thiệu ngắn về XAML, trình bày cách lưu một bản trình chiếu dưới dạng XAML với các cài đặt mặc định, và minh họa cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/), bao gồm cả việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan đến phông chữ dự phòng, tính tương thích của ngăn xếp XAML và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn xây dựng hoặc viết giao diện người dùng cho các ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin forms.  

XAML, là một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện người dùng. Bạn thường sẽ sử dụng một công cụ thiết kế để làm việc với các tệp XAML, nhưng bạn vẫn có thể viết và chỉnh sửa giao diện của mình. 

## **Xuất bản trình chiếu sang XAML với tùy chọn mặc định**

Đoạn mã C++ này cho bạn thấy cách xuất một bản trình chiếu sang XAML với các cài đặt mặc định:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Xuất bản trình chiếu sang XAML với tùy chọn tùy chỉnh**

Bạn có thể chọn các tùy chọn từ giao diện [IXamlOptions](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.xaml.i_xaml_options) để điều khiển quá trình xuất và xác định cách Aspose.Slides xuất bản trình chiếu của bạn sang XAML. 

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bản trình chiếu của mình khi xuất sang XAML, bạn có thể truyền giá trị true cho phương thức [set_ExportHiddenSlides()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Xem đoạn mã mẫu C++ này: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **Câu hỏi thường gặp**

**Làm thế nào để đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Sử dụng [set_DefaultRegularFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) trong [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/) — nó được dùng làm phông chữ dự phòng khi phông chữ gốc không có. Điều này giúp tránh việc thay thế không mong muốn.

**XAML được xuất có chỉ dành cho WPF không, hay có thể sử dụng trong các ngăn xếp XAML khác không?**

XAML là một ngôn ngữ đánh dấu giao diện người dùng chung được sử dụng trong WPF, UWP và Xamarin.Forms. Việc xuất nhằm mục tiêu tương thích với các ngăn xếp XAML của Microsoft; hành vi chính xác và hỗ trợ cho các cấu trúc cụ thể phụ thuộc vào nền tảng đích. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao để ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể điều khiển hành vi này thông qua [set_ExportHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/) — giữ nó tắt nếu bạn không cần xuất chúng.