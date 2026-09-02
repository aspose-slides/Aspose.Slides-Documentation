---
title: Tự động hoá việc Địa phương hoá Bản trình chiếu trong C++
linktitle: Địa phương hoá Bản trình chiếu
type: docs
weight: 100
url: /vi/cpp/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- tắt kiểm tra chính tả
- ngôn ngữ kiểm tra
- id ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thiết lập ngôn ngữ kiểm tra cho văn bản bản trình chiếu PowerPoint và OpenDocument trong C++ với Aspose.Slides, bao gồm các giá trị mặc định và đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides cho C++ cho phép bạn cấu hình siêu dữ liệu kiểm tra cho các phần văn bản riêng lẻ. Sử dụng [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/) để xác định ngôn ngữ kiểm tra, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_spellcheck/) để cho phép hoặc tắt kiểm tra chính tả, và [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_proofdisabled/) để kiểm soát trạng thái không kiểm tra rộng hơn. Vì các cài đặt này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), tạo các đoạn văn đa ngôn ngữ, chọn giữa `SpellCheck` và `ProofDisabled`, và bảo tồn các cài đặt mong muốn khi sử dụng [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Các thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, thực hiện kiểm tra chính tả dựa trên từ điển, hoặc trả về các từ sai chính tả.

## **Đặt ngôn ngữ kiểm tra chính tả cho văn bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), truy cập phần văn bản cần thiết qua [IPortion::get_PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_portionformat/), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình, đặt tiếng Anh Anh làm ngôn ngữ kiểm tra, và lưu kết quả bằng [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt ngôn ngữ mặc định cho văn bản mới**

Sử dụng [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides sẽ gán cho văn bản mới tạo. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong một bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ rõ ràng.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sử dụng nhiều ngôn ngữ trong một đoạn văn**

Một [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) chứa một tập hợp các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `LanguageId` của nó một cách độc lập.

Ví dụ này tạo một đoạn văn có các phần tiếng Anh và tiếng Pháp:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bật hoặc tắt kiểm tra chính tả cho các phần riêng lẻ**

[IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [IBasePortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/). Truy cập định dạng của một phần qua [IPortion::get_PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_portionformat/) và gọi [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_spellcheck/) để kiểm soát liệu một ứng dụng trình chiếu có thể kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `false`: `true` cho phép kiểm tra chính tả, trong khi `false` tắt nó.

Cài đặt này áp dụng cho các phần văn bản riêng lẻ. Các phần khác nhau trong cùng một đoạn văn do đó có thể sử dụng các giá trị khác nhau. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) và `SpellCheck` có mục đích bổ trợ: `LanguageId` xác định ngôn ngữ kiểm tra, trong khi `SpellCheck` quyết định liệu có cho phép kiểm tra chính tả cho phần đó hay không.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_proofdisabled/) cũng kiểm soát việc kiểm tra, nhưng nó đại diện cho trạng thái "không kiểm tra" rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/). Sử dụng `SpellCheck` khi bạn cần một công tắc Boolean trực tiếp cho kiểm tra chính tả. Sử dụng `ProofDisabled` khi bạn cần bảo tồn hoặc kiểm soát một cách rõ ràng siêu dữ liệu không kiểm tra của bản trình chiếu, bao gồm trạng thái `NullableBool::NotDefined`. Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; không kết hợp `SpellCheck = true` với `ProofDisabled = NullableBool::True`.

Các thuộc tính này cấu hình siêu dữ liệu kiểm tra được sử dụng bởi PowerPoint và các ứng dụng trình chiếu khác. Aspose.Slides không sử dụng chúng để chạy kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai chính tả.

Ví dụ đầy đủ sau tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai phần trong cùng một đoạn văn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/joinportionswithsameformatting/) kết hợp các phần liền kề có cùng định dạng. Chỉ có sự khác biệt về `SpellCheck` không giữ các phần này riêng biệt; sau khi chúng được kết hợp, phần kết quả vẫn giữ giá trị `SpellCheck` của phần đầu tiên. Nếu các phần cần cài đặt kiểm tra chính tả khác nhau, hãy gọi `JoinPortionsWithSameFormatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của phần đã kết hợp và áp dụng lại các cài đặt sau đó. Các phần có giá trị `LanguageId` khác nhau vẫn tách biệt vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **Câu hỏi thường gặp**

**Liệu một ID ngôn ngữ có dịch văn bản không?**

Không. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/) lưu trữ siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ phù hợp cho mỗi phần đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, gạch ngang hay ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [fonts](/slides/vi/cpp/powerpoint-fonts/) có sẵn, hệ thống viết, và cài đặt khung văn bản. Để hiển thị đáng tin cậy, cung cấp các phông chữ cần thiết, cấu hình [font substitution](/slides/vi/cpp/font-substitution/), hoặc [embed fonts](/slides/vi/cpp/embedded-font/) trong bản trình chiếu.

**Một đoạn văn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng biệt, như trong ví dụ đoạn văn đa ngôn ngữ.

**Nên sử dụng `DefaultTextLanguage` hay `LanguageId`?**

Sử dụng [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) khi bạn muốn một ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/) khi một phần cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn văn chứa nhiều ngôn ngữ.