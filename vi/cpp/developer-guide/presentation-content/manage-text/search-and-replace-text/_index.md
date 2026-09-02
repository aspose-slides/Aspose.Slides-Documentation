---
title: "Tìm kiếm và Thay thế Văn bản trong Bài thuyết trình PowerPoint bằng C++"
linktitle: "Tìm kiếm và Thay thế Văn bản"
type: docs
weight: 55
url: /vi/cpp/search-and-replace-text/
keywords:
- "tìm kiếm văn bản"
- "tô sáng văn bản"
- "thay thế văn bản"
- "biểu thức chính quy"
- "callback kết quả"
- "khung văn bản"
- "báo cáo kiểm toán"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "C++"
- "Aspose.Slides"
description: "Tìm kiếm, tô sáng và thay thế văn bản trong các bài thuyết trình PowerPoint đồng thời thu thập mọi khớp với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ có thể tìm kiếm, tô sáng và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bài thuyết trình. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mỗi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bài thuyết trình và đồng thời xây dựng một lịch sử kiểm toán chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa nhạy cảm, kiểm tra thuật ngữ, dọn dẹp mẫu, và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Sample text](sample_text.png)

## **Chọn Phạm vi Tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) để giới hạn một thao tác vào một khung văn bản. Sử dụng các phương thức trên [IPresentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/) để xử lý mọi văn bản áp dụng trong bài thuyết trình.

| Thao tác | Một khung văn bản | Toàn bộ bài thuyết trình |
|---|---|---|
| Tô sáng văn bản nguyên thủy | [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlighttext/) |
| Tô sáng các khớp biểu thức chính quy | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlightregex/) |
| Thay thế văn bản nguyên thủy | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replacetext/) |
| Thay thế các khớp biểu thức chính quy | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Cấu hình Khớp Văn bản**

Đối với các thao tác văn bản nguyên thủy, sử dụng [ITextSearchOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/) để kiểm soát việc khớp:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) giới hạn các khớp chỉ ở các từ đầy đủ.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) kiểm soát việc có phải khớp chữ hoa/thường hay không.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và tô sáng ở mức bài thuyết trình.

Các thao tác biểu thức chính quy sử dụng một `System::Text::RegularExpressions::Regex`, vì vậy các quy tắc khớp như độ nhạy cảm chữ hoa/thường và biên giới từ được xác định bởi biểu thức và các tùy chọn của nó.

## **Xác định Chủ sở hữu của Khung Văn bản**

Các luồng công việc xử lý văn bản chung thường nhận một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) trong khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentshape/) và [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) để xác định đối tượng bài thuyết trình nào sở hữu khung văn bản.

Giá trị mong đợi phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Một AutoShape hoặc một hình dạng khác chứa văn bản | The owning [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) | `nullptr` |
| Một ô bảng | `nullptr` | The owning [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) |

Cả hai phương thức đều cung cấp điều hướng chỉ đọc. Gọi chúng không di chuyển khung văn bản hoặc thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị xem có `nullptr` và xử lý khả năng không có chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/getalltextframes/) để lặp qua các khung văn bản trong một bài thuyết trình. Đối với các hình dạng, nó báo cáo tên hình dạng, kiểu thời gian chạy C++, và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và hàng tính từ 0 và slide chứa.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Đối với nội dung SmartArt, lặp qua các hình dạng trong [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) và truy cập mỗi [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Khung văn bản có thể được truy xuất tới hình dạng liên quan thông qua [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentshape/), trong khi [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) trả về `nullptr`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập Thông tin Khớp với Callback**

Triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi khớp. Phương thức [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/foundresult/) của nó cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Cài đặt bên dưới suy ra nó từ [ISlideComponent::get_Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecomponent/get_slide/) và cũng xử lý văn bản được tìm thấy trong ghi chú slide qua [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslide/get_parentslide/). Một số slide có thể null cho phép mô hình kết quả giống nhau đại diện cho văn bản liên quan đến các loại slide khác.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Đối với các thao tác thay thế, `FoundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các cụm từ đã được thay thế.

## **Tô sáng Văn bản**

Sử dụng phương thức [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/) để tô sáng các khớp văn bản nguyên thủy trong một khung văn bản. Truyền [ITextSearchOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/) để kiểm soát tìm kiếm và một callback để thu thập chi tiết khớp.

Ví dụ mã dưới đây tô sáng tất cả các lần xuất hiện của các ký tự **"try"** và sau đó chỉ tô sáng từ đầy đủ **"to"**. Cả hai tìm kiếm đều báo cáo các khớp của chúng tới cùng một callback.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Lấy hình dạng đầu tiên từ slide đầu tiên.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Tô sáng mọi lần xuất hiện của "try" trong khung văn bản.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Chỉ tô sáng từ đầy đủ "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The highlighted text](highlighted_text.png)

## **Tô sáng Văn bản bằng Biểu thức Chính quy**

Phương thức [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/) tô sáng các khớp văn bản được tìm thấy bằng một biểu thức chính quy trong một khung văn bản.

Mã sau tô sáng tất cả các từ chứa bảy ký tự trở lên và thu thập mỗi khớp:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Tô sáng Văn bản trên Toàn bộ Bài thuyết trình**

Sử dụng [IPresentation::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlighttext/) và [IPresentation::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlightregex/) để tìm kiếm tất cả các khung văn bản áp dụng trong một bài thuyết trình. Ví dụ sau tô sáng một thuật ngữ nguyên thủy và tất cả địa chỉ email trong khi giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thay thế Văn bản trong Khung Văn bản**

Sử dụng [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) cho văn bản nguyên thủy và [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi đơn.

Ví dụ sau chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản. Callback giống nhau ghi lại các cụm từ gốc được khớp bởi cả hai thao tác.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy xem lại kết quả để xác nhận định dạng nào sẽ áp dụng cho văn bản thay thế.

## **Thay thế Văn bản trên Toàn bộ Bài thuyết trình**

Sử dụng [IPresentation::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replacetext/) và [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replaceregex/) để áp dụng các thao tác giống nhau trên toàn bộ bài thuyết trình. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa nhạy cảm.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nhóm các Khớp cho Báo cáo**

Vì mỗi kết quả lưu số slide và khung văn bản, các ứng dụng có thể nhóm các khớp để kiểm toán, báo cáo hoặc quy trình rà soát. Ví dụ sau nhóm các kết quả đã thu thập đầu tiên theo slide và sau đó theo khung văn bản:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi chỉ tìm kiếm một hộp văn bản thay vì toàn bộ bài thuyết trình?**

Lấy khung văn bản của hình dạng và gọi [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/), hoặc [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) trên khung văn bản đó. Các phương thức ở mức bài thuyết trình sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp các từ đầy đủ với chữ hoa đúng?**

Gọi [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) và [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) với `true`, và truyền các tùy chọn này tới phương thức tô sáng hoặc thay thế văn bản nguyên thủy. Đối với biểu thức chính quy, định nghĩa biên giới từ và độ nhạy cảm chữ trong chính `System::Text::RegularExpressions::Regex`.

**Có thể tìm kiếm và thay thế bao gồm văn bản trong ghi chú slide không?**

Có. Gọi [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) với `true` khi sử dụng thao tác văn bản nguyên thủy ở mức bài thuyết trình. Cài đặt callback được trình bày ở trên sẽ ánh xạ một khớp trong slide ghi chú trở lại số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không phải quét lại bài thuyết trình một lần nữa?**

Truyền một triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/) vào thao tác tô sáng hoặc thay thế. Callback nhận mọi khớp trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để nhóm hoặc xuất sau này.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) và [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ định dạng phần xung quanh. Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để chắc chắn việc thay thế sử dụng kiểu mong muốn.