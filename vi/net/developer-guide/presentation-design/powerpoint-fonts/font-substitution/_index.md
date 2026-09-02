---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày bằng .NET
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/net/font-substitution/
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho .NET khi render hoặc chuyển đổi các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình bày được render hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung của bản trình bày.

Bạn có thể định nghĩa phông chữ sẽ dùng khi một phông chữ nhất định không có, và có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì sự nhất quán của đầu ra giữa các môi trường có các phông chữ đã cài đặt khác nhau.

## **Lấy thay thế phông chữ**

Sử dụng phương thức [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getsubstitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình bày được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ đã thay thế.

Ví dụ C# sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình bày:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Lấy thay thế phông chữ cho các slide đã chọn**

Sử dụng [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getsubstitutions/) overload với tham số `int[] slides` để chỉ kiểm tra các phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất phần của bản trình bày, kiểm tra dần một bản trình bày lớn, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong quá trình render mà không xử lý các slide không liên quan.

`Mảng` slides chứa các chỉ mục slide được đánh số bắt đầu từ 1: `1` xác định slide đầu tiên. Ngược lại, bộ chỉ mục của tập hợp [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) là bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation.Slides[0]`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi overload thông qua thuộc tính [Presentation.FontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/fontsmanager/). Nó trả về chỉ các phép thay thế được xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ đã thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc fallback đã cấu hình, các quy tắc thay thế lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsubstrulecollection/), và [phông chữ tải bên ngoài](/slides/vi/net/custom-font/).

Một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra trước. Ví dụ sau báo cáo mọi phép thay thế trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Giao diện [IFontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một tùy theo phạm vi của thao tác render:

| Overload | Khi nào sử dụng |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Bạn cần các phép thay thế cho toàn bộ bản trình bày. |
| [GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình bày.  
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.  
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstcondition/).  
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsubstrulecollection/).  
5. Gán bộ sưu tập này cho thuộc tính [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Render hoặc chuyển đổi bản trình bày.

Ví dụ C# sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, và sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Lưu ý" %}}
Để thay đổi vô điều kiện các phông chữ được sử dụng trong toàn bộ bản trình bày, xem mục [Thay thế phông chữ](/slides/vi/net/font-replacement/).
{{% /alert %}}

## **Giới hạn cho phông chữ công thức toán học**

Các quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động với văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không khả dụng bằng phông chữ khả dụng được quy tắc chỉ định.

Các công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần phông chữ chính xác đó để tính toán và render bố cục công thức. Quy tắc thay thế một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo rằng **Cambria Math** là cần thiết.

Để render hoặc chuyển đổi bản trình bày như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/net/custom-font/).

Giới hạn này áp dụng cho bố cục công thức. Các quy tắc thay thế đã mô tả ở trên vẫn áp dụng cho văn bản bình thường trong bản trình bày.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa font replacement và font substitution là gì?**

[Font replacement](/slides/vi/net/font-replacement/) cố tình thay đổi một phông chữ sang phông chữ khác trên toàn bộ bản trình bày. Font substitution chọn một phông chữ cho đầu ra đã render khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/net/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất dựa trên quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/net/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải các phông chữ bên ngoài cần thiết](/slides/vi/net/custom-font/), và [nhúng phông chữ](/slides/vi/net/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.