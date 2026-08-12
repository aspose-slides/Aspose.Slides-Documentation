---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint bằng C++
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/cpp/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- đánh dấu văn bản
- thay thế văn bản
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo kiểm toán
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm kiếm, đánh dấu và thay thế văn bản trong bản trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ có thể tìm kiếm, đánh dấu và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mọi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng một bản ghi audit chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc xem xét, gỡ bỏ thông tin nhạy cảm, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) để giới hạn một thao tác trong một khung văn bản. Sử dụng các phương thức trên [IPresentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/) để xử lý tất cả các văn bản áp dụng trong bản trình chiếu.

| Hoạt động | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Đánh dấu văn bản nguyên văn | [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlighttext/) |
| Đánh dấu kết quả khớp biểu thức chính quy | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlightregex/) |
| Thay thế văn bản nguyên văn | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replacetext/) |
| Thay thế kết quả khớp biểu thức chính quy | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [ITextSearchOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/) để kiểm soát việc khớp:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) giới hạn các khớp thành các từ hoàn chỉnh.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) kiểm soát việc có phải khớp chữ hoa chữ thường.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) bao gồm ghi chú slide trong các hoạt động tìm kiếm, thay thế và đánh dấu ở mức bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng `System::Text::RegularExpressions::Regex`, vì vậy các quy tắc khớp như độ nhạy chữ hoa chữ thường và ranh giới từ được xác định bởi biểu thức và các tùy chọn của nó.

## **Thu thập thông tin khớp với Callback**

Triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi kết quả khớp. Phương thức [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/foundresult/) cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Đoạn mã dưới đây lấy nó từ [ISlideComponent::get_Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecomponent/get_slide/) và cũng xử lý văn bản được tìm thấy trong ghi chú slide qua [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotesslide/get_parentslide/). Một số slide có thể null cho phép cùng một mô hình kết quả biểu diễn văn bản liên quan đến các loại slide khác.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
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
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
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

Đối với các thao tác thay thế, `FoundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Đánh dấu văn bản**

Sử dụng phương thức [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/) để đánh dấu các kết quả khớp văn bản nguyên văn trong một khung văn bản. Truyền vào [ITextSearchOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/) để kiểm soát tìm kiếm và một callback để thu thập chi tiết kết quả.

Đoạn mã dưới đây đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu từ hoàn chỉnh **"to"**. Cả hai tìm kiếm đều báo cáo kết quả cho cùng một callback.

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

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
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

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/) đánh dấu các kết quả khớp được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Đoạn mã sau đánh dấu tất cả các từ có độ dài bảy ký tự trở lên và thu thập mỗi kết quả khớp:

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

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đánh dấu văn bản trên toàn bộ bản trình chiếu**

Sử dụng [IPresentation::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlighttext/) và [IPresentation::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/highlightregex/) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình chiếu. Ví dụ dưới đây đánh dấu một thuật ngữ nguyên văn và tất cả các địa chỉ email đồng thời giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

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

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) cho văn bản nguyên văn và [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ nguyên định dạng phần bao quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ dưới đây chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản. Callback giống nhau ghi lại các thuật ngữ gốc đã được khớp bởi cả hai thao tác.

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

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra đầu ra để xác nhận định dạng nào sẽ được áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình chiếu**

Sử dụng [IPresentation::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replacetext/) và [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/replaceregex/) để áp dụng cùng một thao tác trên toàn bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và gỡ bỏ thông tin nhạy cảm.

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

## **Nhóm các khớp để báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các khớp cho mục đích audit, báo cáo hoặc quy trình xem xét. Ví dụ dưới đây nhóm các kết quả đã thu thập đầu tiên theo slide và sau đó theo khung văn bản:

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

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của hình dạng và gọi [ITextFrame::HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) hoặc [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) trên khung văn bản đó. Các phương thức ở mức bản trình chiếu sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp toàn bộ từ với viết hoa chữ thường chính xác?**

Gọi [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) và [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) với giá trị `true`, và truyền các tùy chọn đó vào phương thức đánh dấu hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, định nghĩa ranh giới từ và độ nhạy chữ hoa chữ thường trong chính `System::Text::RegularExpressions::Regex`.

**Việc tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Gọi [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) với `true` khi sử dụng thao tác văn bản nguyên văn ở mức bản trình chiếu. Cấu hình callback được trình bày ở trên sẽ ánh xạ kết quả khớp trong ghi chú slide trở lại số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không phải quét lại bản trình chiếu một lần nữa?**

Truyền một triển khai của [IFindResultCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifindresultcallback/) vào thao tác đánh dấu hoặc thay thế. Callback nhận mỗi kết quả khớp trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide đã suy ra để nhóm hoặc xuất sau này.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replacetext/) và [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/replaceregex/) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ định dạng phần bao quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu định dạng mong muốn.