---
title: Chuyển đổi Bản thuyết trình PowerPoint sang PDF có Ghi chú trong C++
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản thuyết trình sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản thuyết trình dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú diễn giả
- PDF có ghi chú
- C++
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho C++. Bảo tồn bố cục và ghi chú diễn giả cho các bản thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bản thuyết trình PowerPoint sang định dạng PDF có ghi chú diễn giả bằng Aspose.Slides. Hướng dẫn này sẽ bao phủ các bước cần thiết và cung cấp ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời bảo tồn ghi chú diễn giả.  
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú diễn giả được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `Save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản thuyết trình PPT hoặc PPTX sang PDF có ghi chú diễn giả. Với Aspose.Slides, bạn chỉ cần tải bản thuyết trình, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú diễn giả, sau đó lưu tệp dưới dạng PDF. Đoạn mã sau trình bày cách chuyển đổi một bản thuyết trình mẫu sang PDF trong chế độ xem Notes Slide.

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

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Hiển thị ghi chú diễn giả bên dưới slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Bạn có thể muốn kiểm tra Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}