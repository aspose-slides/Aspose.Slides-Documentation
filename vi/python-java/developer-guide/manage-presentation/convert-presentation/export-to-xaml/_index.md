---
title: Xuất bản trình chiếu sang XAML trong Python qua Java
linktitle: Bản trình chiếu sang XAML
type: docs
weight: 30
url: /vi/python-java/export-to-xaml/
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
- lưu PPT thành XAML
- lưu PPTX thành XAML
- lưu ODP thành XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- Python
- Java
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang XAML với Aspose.Slides cho Python qua Java. Sử dụng các tùy chọn mặc định hoặc bao gồm các slide ẩn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất các bản trình chiếu PowerPoint và OpenDocument sang XAML bằng Aspose.Slides cho Python qua Java. Nó giới thiệu XAML, chỉ ra cách xuất với các cài đặt mặc định và trình bày cách bao gồm các slide ẩn bằng [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/).

Các ví dụ yêu cầu Aspose.Slides cho Python qua Java và một môi trường chạy Java tương thích. Đặt `pres.pptx` trong thư mục làm việc hiện tại. Mỗi ví dụ sẽ khởi động JVM chỉ nếu nó chưa chạy.

## **Giới thiệu về XAML**

XAML (Extensible Application Markup Language) là một ngôn ngữ dựa trên XML để mô tả giao diện người dùng. Nó được sử dụng bởi các khung như Windows Presentation Foundation (WPF). Bạn có thể tạo và chỉnh sửa XAML bằng công cụ thiết kế trực quan hoặc trình soạn thảo văn bản.

## **Xuất bản trình chiếu sang XAML với các tùy chọn mặc định**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) từ tệp đầu vào, sau đó truyền [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) vào [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để xuất với các cài đặt mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Xuất bản trình chiếu sang XAML với các tùy chọn tùy chỉnh**

Sử dụng [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) để cấu hình việc xuất. Để bao gồm các slide ẩn, gọi [setExportHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) với `True` trước khi lưu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Làm cách nào để chọn phông chữ thay thế khi phông chữ gốc không khả dụng?**

Sử dụng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) trên đối tượng [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) của bạn để chỉ định phông chữ thay thế. Đảm bảo phông chữ đã chọn có sẵn trong môi trường xuất.

**Tôi có thể sử dụng markup đã xuất trong bất kỳ khung XAML nào không?**

Các khung XAML khác nhau về các thành phần và tính năng được hỗ trợ. Hãy kiểm tra markup đã xuất trong khung mục tiêu của bạn trước khi tích hợp vào ứng dụng.

**Các slide ẩn có được xuất mặc định không?**

Không. Để bao gồm chúng, gọi [setExportHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) với `True`. Đặt giá trị `False` để loại trừ chúng.