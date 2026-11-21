---
title: Chuyển đổi bản trình bày PowerPoint sang PDF với ghi chú trong C++
linktitle: PowerPoint sang PDF với ghi chú
type: docs
weight: 50
url: /vi/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình bày sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình bày dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú người nói
- PDF có ghi chú
- C++
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho C++. Duy trì bố cục và ghi chú người nói cho các bản trình bày chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bản trình bày PowerPoint sang định dạng PDF kèm ghi chú người nói bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF trong khi vẫn giữ nguyên ghi chú người nói.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người nói được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/cpp/notes-size/).

## **Chuyển đổi PowerPoint sang PDF với Ghi chú**

Phương thức `Save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình bày PPT hoặc PPTX sang PDF kèm ghi chú người nói. Với Aspose.Slides, bạn chỉ cần tải bản trình bày, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú người nói, sau đó lưu tệp dưới dạng PDF. Đoạn mã sau đây minh họa cách chuyển đổi một bản trình bày mẫu sang PDF ở chế độ xem Slide Ghi chú.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Cấu hình tùy chọn PDF để hiển thị ghi chú người nói.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú người nói dưới slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Lưu bản trình bày thành PDF với ghi chú người nói.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Bạn có thể muốn xem công cụ [Chuyển đổi PowerPoint sang PDF trực tuyến của Aspose](https://products.aspose.app/slides/vi/conversion).
{{% /alert %}}