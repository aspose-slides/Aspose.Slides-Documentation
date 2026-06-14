---
title: Xuất bài thuyết trình sang XAML trong .NET
linktitle: Bài thuyết trình sang XAML
type: docs
weight: 30
url: /vi/net/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bài thuyết trình
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bài thuyết trình
- PowerPoint sang XAML
- OpenDocument sang XAML
- bài thuyết trình sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong .NET bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Trong bài viết này giải thích cách xuất các bài thuyết trình PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, cho thấy cách lưu một bài thuyết trình thành XAML với các cài đặt mặc định, và trình bày cách tùy chỉnh việc xuất thông qua XamlOptions, bao gồm xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan tới phông chữ dự phòng, khả năng tương thích với các ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn tạo hoặc viết giao diện người dùng cho các ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin Forms.  

XAML, là một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện người dùng. Bạn thường sẽ sử dụng một công cụ thiết kế để làm việc với các tệp XAML, nhưng vẫn có thể tự viết và chỉnh sửa giao diện của mình. 

## **Xuất bài thuyết trình sang XAML với các tùy chọn mặc định**

Mã C# dưới đây cho bạn thấy cách xuất một bài thuyết trình sang XAML với các cài đặt mặc định:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Xuất bài thuyết trình sang XAML với các tùy chọn tùy chỉnh**

Bạn có thể chọn các tùy chọn từ giao diện IXamlOptions để điều khiển quá trình xuất và xác định cách Aspose.Slides xuất bài thuyết trình của bạn sang XAML. 

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bài thuyết trình khi xuất sang XAML, bạn có thể đặt thuộc tính ExportHiddenSlides thành true. Xem đoạn mã C# mẫu này: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [DefaultRegularFont](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/defaultregularfont/) trong [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/) — nó được sử dụng làm phông chữ dự phòng khi phông chữ gốc không có. Điều này giúp tránh các sự thay thế không mong muốn.

**XAML xuất ra chỉ dành cho WPF hay có thể được sử dụng trong các ngăn xếp XAML khác không?**

XAML là một ngôn ngữ đánh dấu giao diện người dùng chung được sử dụng trong WPF, UWP và Xamarin.Forms. Việc xuất nhằm mục đích tương thích với các ngăn xếp XAML của Microsoft; hành vi chính xác và hỗ trợ cho các cấu trúc cụ thể phụ thuộc vào nền tảng mục tiêu. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn sẽ không được bao gồm. Bạn có thể điều khiển hành vi này thông qua [ExportHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/) — giữ thuộc tính này ở trạng thái vô hiệu nếu bạn không cần xuất chúng.