---
title: Chuyển đổi bản trình bày OpenDocument trong C++
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/cpp/convert-openoffice-odp/
keywords:
- chuyển đổi ODP
- ODP sang hình ảnh
- ODP sang GIF
- ODP sang HTML
- ODP sang JPG
- ODP sang MD
- ODP sang PDF
- ODP sang PNG
- ODP sang PPT
- ODP sang PPTX
- ODP sang TIFF
- ODP sang video
- ODP sang Word
- ODP sang XPS
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Aspose.Slides cho C++ cho phép bạn chuyển đổi ODP sang PDF, HTML và các định dạng hình ảnh một cách dễ dàng. Tăng cường ứng dụng C++ của bạn với việc chuyển đổi bản trình bày nhanh chóng và chính xác."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/vi/cpp/) cho phép bạn chuyển đổi các bản trình bày OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, v.v.). API được sử dụng để chuyển đổi tệp ODP sang các định dạng tài liệu khác giống như API được dùng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bản trình bày ODP sang PDF, bạn có thể thực hiện như sau:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```