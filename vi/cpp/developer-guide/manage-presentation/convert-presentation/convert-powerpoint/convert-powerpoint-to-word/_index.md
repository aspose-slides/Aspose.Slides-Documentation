---
title: Chuyển đổi bản trình chiếu PowerPoint sang tài liệu Word trong C++
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/cpp/convert-powerpoint-to-word/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang Word
- bản trình chiếu sang Word
- slide sang Word
- PPT sang Word
- PPTX sang Word
- PowerPoint sang DOCX
- bản trình chiếu sang DOCX
- slide sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- PowerPoint sang DOC
- bản trình chiếu sang DOC
- slide sang DOC
- PPT sang DOC
- PPTX sang DOC
- lưu PPT dưới dạng DOCX
- lưu PPTX dưới dạng DOCX
- xuất PPT sang DOCX
- xuất PPTX sang DOCX
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint PPT và PPTX sang tài liệu Word có thể chỉnh sửa trong C++ bằng Aspose.Slides với bố cục, hình ảnh và định dạng được giữ nguyên."
---
## **Giới thiệu**

Nếu bạn dự định sử dụng nội dung văn bản hoặc thông tin từ một bản trình bày (PPT hoặc PPTX) theo các cách mới, bạn có thể hưởng lợi từ việc chuyển đổi bản trình bày sang Word (DOC hoặc DOCX). 

* So với Microsoft PowerPoint, ứng dụng Microsoft Word được trang bị nhiều công cụ hoặc chức năng hơn cho nội dung. 
* Ngoài các chức năng chỉnh sửa trong Word, bạn còn có thể hưởng lợi từ các tính năng cộng tác, in ấn và chia sẻ được cải thiện. 

{{% alert color="primary" %}} 

Bạn có thể muốn thử [**Trình chuyển đổi Trình chiếu sang Word trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) để xem bạn có thể thu được gì khi làm việc với nội dung văn bản từ các slide. 

{{% /alert %}} 

## **Aspose.Slides và Aspose.Words**

Để chuyển đổi tệp PowerPoint (PPTX hoặc PPT) sang Word (DOCX hoặc DOC), bạn cần cả [Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/) và [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Là một API độc lập, [Aspose.Slides](https://products.aspose.app/slides) cho C++ cung cấp các hàm cho phép bạn trích xuất văn bản từ các bản trình bày. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) là một API xử lý tài liệu nâng cao cho phép các ứng dụng tạo, sửa đổi, chuyển đổi, render, in tệp và thực hiện các nhiệm vụ khác với tài liệu mà không cần sử dụng Microsoft Word.

## **Chuyển đổi Bản trình chiếu PowerPoint sang Tài liệu Word**

Sử dụng đoạn mã sau để chuyển đổi PowerPoint sang Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // tạo và chèn hình ảnh slide
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // chèn nội dung văn bản của slide
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
```

## **Câu hỏi thường gặp**

**Cần cài đặt những thành phần nào để chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word?**

Bạn chỉ cần thêm các gói tương ứng cho [Aspose.Slides for C++](https://releases.aspose.com/slides/vi/cpp/) và [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) vào dự án của mình. Cả hai thư viện hoạt động như các API độc lập và không yêu cầu phải cài đặt Microsoft Office.

**Tất cả các định dạng bản trình chiếu PowerPoint và OpenDocument có được hỗ trợ không?**

Aspose.Slides [hỗ trợ tất cả các định dạng bản trình chiếu](/slides/vi/cpp/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo bạn có thể làm việc với các bản trình chiếu được tạo trong các phiên bản khác nhau của Microsoft PowerPoint.