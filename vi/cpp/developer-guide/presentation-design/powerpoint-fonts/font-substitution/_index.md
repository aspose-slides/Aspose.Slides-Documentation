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
- thay đổi phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho C++ khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập được khi một bản trình chiếu được render hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể xác định phông chữ sẽ dùng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì tính nhất quán của đầu ra giữa các môi trường có các phông chữ được cài đặt khác nhau.

Nếu một phông chữ có sẵn nhưng không có kiểu đậm riêng, xem [Xử lý phông chữ không có kiểu đậm riêng](/slides/vi/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và các hậu quả đối với việc chọn văn bản, tìm kiếm và thu phóng.

## **Lấy các thay thế phông chữ**

Sử dụng phương thức [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ C++ sau liệt kê tất cả các thay thế phông chữ cho một bản trình chiếu:

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

## **Lấy các thay thế phông chữ cho các slide được chọn**

Sử dụng overload của [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) với đối số `System::ArrayPtr<int32_t> slides` để chỉ kiểm tra các thay thế cần thiết cho các slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất một phần của bản trình chiếu, kiểm tra một bản trình chiếu lớn một cách tăng dần, xác định các slide phụ thuộc vào các phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong render mà không cần xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide dựa trên 1: `1` xác định slide đầu tiên. Ngược lại, phương thức [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) sử dụng chỉ mục bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation->get_Slide(0)`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi overload thông qua phương thức [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Nó trả về chỉ các thay thế được xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), và [các phông chữ được tải bên ngoài](/slides/vi/cpp/custom-font/).

Cùng một thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mọi thay thế được trả về và sau đó tạo danh sách sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một trong số chúng tùy theo phạm vi của thao tác render:

| Overload | Sử dụng khi |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) không có tham số | Bạn cần các thay thế cho toàn bộ bản trình chiếu. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) với `System::ArrayPtr<int32_t> slides` | Bạn cần các thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi một phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ C++ sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, và sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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

Đối với một thay đổi không có điều kiện đối với các phông chữ được sử dụng trong toàn bộ bản trình chiếu, xem [Thay thế phông chữ](/slides/vi/cpp/font-replacement/).

{{% /alert %}}

## **Hạn chế đối với phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ có sẵn được chỉ định trong quy tắc.

Các công thức Office Math có một yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục công thức. Quy tắc thay thế một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc render vẫn có thể báo cáo rằng **Cambria Math** là cần thiết.

Để render hoặc chuyển đổi bản trình chiếu như vậy, hãy cung cấp **Cambria Math** cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/cpp/custom-font/).

Hạn chế này áp dụng cho bố cục công thức. Các quy tắc thay thế được mô tả ở trên vẫn áp dụng cho văn bản thông thường trong bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa thay thế phông chữ và thay thế phông chữ là gì?**

[Thay thế phông chữ](/slides/vi/cpp/font-replacement/) thay đổi có chủ đích một phông chữ sang phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã render khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [quy trình lựa chọn phông chữ](/slides/vi/cpp/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/cpp/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy hệ điều hành, vì vậy một phông chữ có trên máy này có thể cần được thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải các phông chữ bên ngoài cần thiết](/slides/vi/cpp/custom-font/), và [nhúng phông chữ](/slides/vi/cpp/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) trước khi xuất để xác định các thay thế không mong muốn.