---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu trên .NET
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra phông chữ đã được thay thế trong Aspose.Slides cho .NET khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình chiếu được render hoặc chuyển đổi. Việc thay thế chỉ ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể xác định phông chữ sẽ sử dụng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì tính nhất quán của đầu ra giữa các môi trường có các phông chữ đã cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) xác định tên phông chữ gốc và phông chữ đã được thay thế.

Ví dụ C# sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Lấy các phép thay thế phông chữ cho các slide đã chọn**

Sử dụng phương thức [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) có tham số `int[] slides` để chỉ kiểm tra các phép thay thế cần thiết cho các slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất phần của bản trình chiếu, kiểm tra một bản trình chiếu lớn theo từng phần, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt về render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ số slide dựa trên 1: `1` xác định slide đầu tiên. Ngược lại, chỉ số của bộ sưu tập [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) là dựa trên 0, vì vậy slide tương tự được truy cập bằng `presentation.Slides[0]`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi phương thức overload thông qua thuộc tính [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Nó trả về chỉ các phép thay thế được xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ đã được thay thế. Kết quả phản ánh môi trường phông chữ hiện tại và [phông chữ tải ngoại vi](/slides/vi/net/custom-font/). Các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) thay đổi đầu ra render nhưng không được phản ánh trong kết quả.

Một phép thay thế có thể được yêu cầu bởi hơn một slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo bảng kiểm kê phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một trong số chúng tùy theo phạm vi hoạt động render:

| Overload | Khi nào nên sử dụng |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) với `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra theo từng phần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi một phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập vào thuộc tính [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ C# sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, sau đó render slide đầu tiên để xác nhận kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
Đối với việc thay đổi không có điều kiện đối với tất cả phông chữ trong một bản trình chiếu, xem [Thay thế phông chữ](/slides/vi/net/font-replacement/).
{{% /alert %}}

## **Các hạn chế đối với phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ khả dụng được chỉ định trong quy tắc.

Công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục công thức. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để render hoặc chuyển đổi bản trình chiếu như vậy, hãy cung cấp **Cambria Math** cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó dưới dạng [phông chữ ngoại vi](/slides/vi/net/custom-font/).

Hạn chế này áp dụng cho việc bố cục công thức. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thường của bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế toàn bộ phông chữ là gì?**

[Thay thế phông chữ](/slides/vi/net/font-replacement/) cố ý đổi một phông chữ sang phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã render khi điều kiện cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/net/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường chạy.

**Tôi có thể tải phông chữ ngoại vi để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ ngoại vi](/slides/vi/net/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy hệ điều hành, vì vậy một phông chữ có trên máy này có thể cần được thay thế trên máy khác.

**Làm sao để giữ cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải các phông chữ ngoại vi cần thiết](/slides/vi/net/custom-font/), và [nhúng phông chữ](/slides/vi/net/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.