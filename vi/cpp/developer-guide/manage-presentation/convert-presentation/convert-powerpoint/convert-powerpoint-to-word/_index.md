---
title: Chuyển đổi Bản trình chiếu PowerPoint sang Tài liệu Word bằng C++
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/cpp/convert-powerpoint-to-word/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang Word
- bản trình bày sang Word
- slide sang Word
- PPT sang Word
- PPTX sang Word
- PowerPoint sang DOCX
- bản trình bày sang DOCX
- slide sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- PowerPoint sang DOC
- bản trình bày sang DOC
- slide sang DOC
- PPT sang DOC
- PPTX sang DOC
- lưu PPT dưới dạng DOCX
- lưu PPTX dưới dạng DOCX
- xuất PPT sang DOCX
- xuất PPTX sang DOCX
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint PPT và PPTX sang tài liệu Word có thể chỉnh sửa trong C++ bằng cách sử dụng Aspose.Slides với bố cục, hình ảnh và định dạng được giữ nguyên."
---
## **Giới thiệu**

Nếu bạn dự định sử dụng nội dung văn bản hoặc thông tin từ một bản trình bày (PPT hoặc PPTX) theo những cách mới, bạn có thể hưởng lợi từ việc chuyển đổi bản trình bày sang Word (DOC hoặc DOCX). 

* So với Microsoft PowerPoint, ứng dụng Microsoft Word được trang bị nhiều công cụ hoặc tính năng hơn cho nội dung. 
* Ngoài các chức năng chỉnh sửa trong Word, bạn còn có thể hưởng lợi từ các tính năng hợp tác, in ấn và chia sẻ được cải thiện. 

{{% alert color="info" %}} 
Bạn có thể muốn thử [**Bộ chuyển đổi Trình chiếu sang Word Trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) để xem bạn có thể đạt được gì khi làm việc với nội dung văn bản từ các slide. 
{{% /alert %}} 

## **Aspose.Slides và Aspose.Words**

Để chuyển đổi tệp PowerPoint (PPTX hoặc PPT) sang Word (DOCX hoặc DOC), bạn cần cả [Aspose.Slides cho C++](https://products.aspose.com/slides/vi/cpp/) và [Aspose.Words cho C++](https://products.aspose.com/words/cpp/).

Là một API độc lập, [Aspose.Slides](https://products.aspose.app/slides) cho C++ cung cấp các chức năng cho phép bạn trích xuất văn bản từ các bản trình bày. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) là một API xử lý tài liệu nâng cao cho phép các ứng dụng tạo, sửa đổi, chuyển đổi, hiển thị, in tài liệu và thực hiện các tác vụ khác với tài liệu mà không cần sử dụng Microsoft Word.

## **Chuyển đổi Bản trình bày PowerPoint sang Tài liệu Word**

Sử dụng đoạn mã này để chuyển đổi PowerPoint sang Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // tạo hình ảnh slide dưới dạng luồng mảng byte
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // chèn văn bản của slide
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **Câu hỏi thường gặp**

### Các thành phần nào cần được cài đặt để chuyển đổi các bản trình bày PowerPoint và OpenDocument sang tài liệu Word?

Bạn chỉ cần thêm các gói tương ứng cho [Aspose.Slides cho C++](https://releases.aspose.com/slides/vi/cpp/) và [Aspose.Words cho C++](https://releases.aspose.com/words/cpp/) vào dự án của mình. Cả hai thư viện hoạt động như các API độc lập và không yêu cầu cài đặt Microsoft Office.

### Có hỗ trợ tất cả các định dạng bản trình bày PowerPoint và OpenDocument không?

Aspose.Slides [hỗ trợ tất cả các định dạng bản trình bày](/slides/vi/cpp/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo bạn có thể làm việc với các bản trình bày được tạo bằng các phiên bản khác nhau của Microsoft PowerPoint.