---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng C++
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/cpp/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay thế
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho C++ khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình chiếu được hiển thị hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung của bản trình chiếu.

Bạn có thể xác định phông chữ sẽ được sử dụng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp giữ cho đầu ra nhất quán trên các môi trường có các phông chữ được cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) để xác định các phông chữ sẽ được thay thế khi bản trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ C++ dưới đây liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Lấy các phép thay thế phông chữ cho các slide được chọn**

Sử dụng phương thức overload của [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) có tham số `System::ArrayPtr<int32_t> slides` để kiểm tra chỉ các phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn đang render hoặc xuất một phần của bản trình chiếu, kiểm tra một bản trình chiếu lớn theo từng phần, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt khi render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ số slide được đánh số bắt đầu từ 1: `1` xác định slide đầu tiên. Ngược lại, phương thức [Presentation::get_Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slide/) sử dụng chỉ số bắt đầu từ 0, vì vậy cùng một slide được truy cập bằng `presentation->get_Slide(0)`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ số.

Gọi overload qua phương thức [Presentation::get_FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/). Nó trả về chỉ các phép thay thế được xác định trong khi render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và tên phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc fallback đã cấu hình, các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsubstrulecollection/), và [phông chữ được tải ngoại vi](/slides/vi/cpp/custom-font/).

Một phép thay thế có thể được yêu cầu bởi nhiều slide được chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra trước. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Giao diện [IFontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một trong số chúng tùy theo phạm vi của thao tác render:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) không có tham số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) với `System::ArrayPtr<int32_t> slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra theo từng phần, hoặc xuất một phần của bản trình chiếu. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ C++ dưới đây thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, và sau đó render slide đầu tiên để xác nhận kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Lưu ý" %}}
Đối với việc thay đổi không có điều kiện các phông chữ được sử dụng trên toàn bộ bản trình chiếu, xem mục [Font Replacement](/slides/vi/cpp/font-replacement/).
{{% /alert %}}

## **Giới hạn đối với phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ tiêu chuẩn được sử dụng khi render và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không khả dụng bằng phông chữ có sẵn được chỉ định trong quy tắc.

Các công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục công thức. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để render hoặc chuyển đổi bản trình chiếu như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt phông chữ này trong hệ điều hành hoặc tải nó như một [phông chữ ngoại vi](/slides/vi/cpp/custom-font/).

Giới hạn này chỉ áp dụng cho bố cục công thức. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thông thường trong bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế hoàn toàn phông chữ là gì?**

[Font replacement](/slides/vi/cpp/font-replacement/) thay đổi có chủ đích một phông chữ sang phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chỉ chọn một phông chữ cho đầu ra đã render khi đáp ứng điều kiện cấu hình, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/cpp/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình chọn phông chữ của mình. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ ngoại vi để tránh việc thay thế không?**

Có. Bạn có thể [load external fonts](/slides/vi/cpp/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**Làm sao để làm cho việc chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng một tập tin phông chữ và cùng phiên bản trên mọi máy hoặc container, [load required external fonts](/slides/vi/cpp/custom-font/), và [embed fonts](/slides/vi/cpp/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.