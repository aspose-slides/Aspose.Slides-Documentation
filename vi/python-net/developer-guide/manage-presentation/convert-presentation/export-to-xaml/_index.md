---
title: Xuất bản trình chiếu sang XAML bằng Python
linktitle: Xuất sang XAML
type: docs
weight: 30
url: /vi/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong Python bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, trình bày cách lưu một bản trình chiếu dưới dạng XAML với cài đặt mặc định, và minh họa cách tùy chỉnh quá trình xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích ngăn xếp XAML và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ lập trình mô tả cho phép bạn xây dựng hoặc viết giao diện người dùng cho các ứng dụng, đặc biệt là những ứng dụng sử dụng WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin Forms.  

XAML, một ngôn ngữ dựa trên XML, là biến thể của Microsoft để mô tả giao diện người dùng. Bạn thường sẽ sử dụng công cụ thiết kế để làm việc với các tệp XAML, nhưng vẫn có thể viết và chỉnh sửa giao diện của mình. 

## **Xuất bản trình chiếu sang XAML với tùy chọn mặc định**

Đoạn mã Python này cho bạn thấy cách xuất một bản trình chiếu sang XAML với các cài đặt mặc định:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Xuất bản trình chiếu sang XAML với tùy chọn tùy chỉnh**

Bạn có thể chọn các tùy chọn từ lớp [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) để điều khiển quá trình xuất và xác định cách Aspose.Slides xuất bản trình chiếu của bạn sang XAML. 

Ví dụ, nếu bạn muốn Aspose.Slides thêm các slide ẩn từ bản trình chiếu của bạn khi xuất sang XAML, bạn có thể đặt thuộc tính [export_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) thành `True`. Xem đoạn mã Python mẫu này: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [default_regular_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) — nó được sử dụng làm phông chữ dự phòng khi phông chữ gốc không có. Điều này giúp tránh các sự thay thế không mong muốn.

**XAML xuất ra chỉ dành cho WPF, hay có thể được sử dụng trong các ngăn xếp XAML khác cũng được không?**

XAML là một ngôn ngữ đánh dấu giao diện người dùng chung được dùng trong WPF, UWP và Xamarin.Forms. Quá trình xuất nhằm mục tiêu tương thích với các ngăn xếp XAML của Microsoft; hành vi chính xác và hỗ trợ các cấu trúc cụ thể phụ thuộc vào nền tảng mục tiêu. Hãy kiểm tra markup trong môi trường của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao tôi có thể ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [export_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) — để nó tắt nếu bạn không cần xuất chúng.