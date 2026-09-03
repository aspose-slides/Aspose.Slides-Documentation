---
title: "Nhúng phông chữ trong bản trình bày bằng C++"
linktitle: "Phông chữ được nhúng"
type: docs
weight: 40
url: /vi/cpp/embedded-font/
keywords:
- "thêm phông chữ"
- "nhúng phông chữ"
- "nhúng phông chữ"
- "lấy phông chữ đã nhúng"
- "thêm phông chữ đã nhúng"
- "xoá phông chữ đã nhúng"
- "nén phông chữ đã nhúng"
- "PowerPoint"
- "bản trình bày"
- "C++"
- "Aspose.Slides"
description: "Quản lý phông chữ được nhúng trong PowerPoint bằng Aspose.Slides cho C++. Thêm, truy xuất, xóa và nén phông chữ để duy trì giao diện văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Nhúng phông chữ lưu trữ dữ liệu phông trong một bản trình bày PowerPoint. Khi một trình xem hỗ trợ phông chữ nhúng, nó có thể hiển thị văn bản sử dụng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống đích. Điều này giúp bảo lưu các ngắt dòng, khoảng cách văn bản và bố cục slide.

Aspose.Slides for C++ cho phép bạn truy xuất, thêm và xóa phông chữ nhúng thông qua phương thức [Presentation::get_FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/) của một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản trình bày không sử dụng.

Các ví dụ bên dưới hoạt động với các tệp PPTX. Trước khi nhúng một phông chữ, hãy chắc chắn dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông chữ Nhúng**

Sử dụng [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) để liệt kê các phông chữ được lưu trong một bản trình bày. Để xóa một phông chữ, truyền phông chữ đó từ danh sách cho [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), sau đó lưu bản trình bày.

Ví dụ sau liệt kê các phông chữ nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Việc xóa một phông chữ nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Nếu không, việc render có thể yêu cầu [font substitution](/slides/vi/cpp/font-substitution/), điều này có thể ảnh hưởng đến bố cục.

## **Kiểm tra Dữ liệu Phông chữ và Quyền Nhúng**

Sử dụng giao diện [IFontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/) để kiểm tra các phông chữ trước khi nhúng chúng. Gọi [IFontsManager::GetFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong bản trình bày. Đối với mỗi phông chữ, truyền một đối tượng [IFontData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontstyletype/) cần thiết vào [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getfontbytes/). Phương thức trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `nullptr` khi phông chữ hoặc kiểu được yêu cầu không khả dụng. Không truyền kết quả `nullptr` vào [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), vì phương thức đó yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/embeddinglevel/) là một enumeration dạng cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép của phông chữ.
- `Restricted` cấm nhúng trừ khi được phép từ chủ sở hữu pháp lý của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu.
- `NoSubsetting` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần của các glyph. Khi cờ này hiện diện, phải nhúng toàn bộ ký tự.
- `BitmapOnly` là một hạn chế bổ sung chỉ cho phép nhúng các bitmap strike, không cho phép dữ liệu outline. Nếu phông chữ không có bitmap strike, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể được kết hợp với chúng. Kiểm tra các bộ sửa đổi bằng các phép toán bitwise. Vì `Installable` bằng không, hãy áp dụng mặt nạ cho các bit quyền sử dụng và so sánh kết quả với `Installable`. Các phông chữ hiện tại nên đặt tối đa một bit quyền sử dụng. Đối với tính tương thích với các phông chữ cũ hơn đặt nhiều hơn một bit, công cụ trợ giúp bên dưới sẽ chọn quyền ít hạn chế nhất: `Editable`, sau đó `PreviewPrint`, rồi `Restricted`.

Ví dụ sau kiểm tra dữ liệu thường, đậm, nghiêng và đậm-ngoại lệ có sẵn cho mỗi phông chữ trả về bởi `GetFonts`. Nó bỏ qua các kiểu không khả dụng, phông chữ bị hạn chế, phông chữ chỉ bitmap, phông chữ giới hạn ở preview và print vì kết quả vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào có `NoSubsetting`, nó sẽ nhúng toàn bộ ký tự cho họ họ phông chữ đó.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kiểm tra này báo cáo các hạn chế được mã hoá trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã có phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao nhúng.

## **Thêm Phông chữ Nhúng**

Sử dụng [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/addembeddedfont/) để nhúng một phông chữ. Các overload của nó chấp nhận hoặc một đối tượng [IFontData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. Enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedfontcharacters/) kiểm soát những ký tự nào được bao gồm:

- [All](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedfontcharacters/) nhúng tất cả ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình bày và nhập văn bản mới.
- [OnlyUsed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedfontcharacters/) chỉ nhúng các ký tự đã được sử dụng trong bản trình bày để giảm kích thước tệp. Chọn tùy chọn này cho bản trình bày đã hoàn thiện và chủ yếu nhằm mục đích xem.

Ví dụ sau sử dụng [IFontsManager::GetFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng sẽ giữ nguyên bộ ký tự hiện tại.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nén Phông chữ Nhúng**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không sử dụng. Nó hoạt động trên các phông chữ đã được nhúng, vì vậy mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không dùng mà bản trình bày chứa.

Ví dụ sau nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả dưới dạng tệp riêng:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Giữ lại tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ nhúng, ngay cả khi ban đầu bạn đã nhúng toàn bộ ký tự.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi kiểm tra xem một phông chữ nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) trong môi trường bạn render bản trình bày để xem Aspose.Slides sẽ thay thế phông chữ nào. Cũng kiểm tra cài đặt [font substitution](/slides/vi/cpp/font-substitution/) và quy tắc [font fallback](/slides/vi/cpp/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết các ký tự mà phông chữ tự nó không chứa.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Căn cứ quyết định vào môi trường đích. Nếu các phông chữ cần thiết có sẵn trên mọi máy mở hoặc render bản trình bày, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp bảo lưu giao diện mong muốn, với điều kiện giấy phép cho phép.