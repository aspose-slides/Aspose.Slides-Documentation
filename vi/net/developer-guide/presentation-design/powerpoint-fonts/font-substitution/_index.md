---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày trên .NET
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
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho .NET khi kết xuất hoặc chuyển đổi các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình bày được kết xuất hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã được kết xuất; nó không thay đổi phông chữ được gán cho nội dung bản trình bày.

Bạn có thể xác định phông chữ sẽ được sử dụng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình kết xuất. Điều này giúp duy trì tính nhất quán của đầu ra trên các môi trường có các phông chữ đã cài đặt khác nhau.

Nếu một phông chữ có sẵn nhưng không có dạng chữ in đậm riêng, xem [Xử lý phông chữ không có dạng chữ in đậm riêng](/slides/vi/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và hậu quả đối với việc chọn văn bản, tìm kiếm và phóng to/thu nhỏ.

## **Lấy Thông tin Thay thế Phông chữ**

Sử dụng phương thức [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) để xác định các phông chữ nào sẽ được thay thế khi bản trình bày được kết xuất. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) xác định tên phông chữ gốc và phông chữ đã được thay thế.

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

## **Lấy Thông tin Thay thế Phông chữ cho Các Slide Được Chọn**

Sử dụng phương thức [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) có tham số `int[] slides` để kiểm tra chỉ những phép thay thế cần thiết cho việc kết xuất các slide cụ thể. Điều này hữu ích khi bạn đang kết xuất hoặc xuất một phần của bản trình bày, kiểm tra dần dần một bản trình bày lớn, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong việc kết xuất mà không cần xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide bắt đầu từ 1: `1` xác định slide đầu tiên. Ngược lại, bộ chỉ mục của tập hợp [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) là bắt đầu từ 0, vì vậy slide đó được truy cập bằng `presentation.Slides[0]`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch một.

Gọi phương thức này thông qua thuộc tính [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Nó trả về chỉ các phép thay thế được xác định khi kết xuất các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ đã được thay thế. Kết quả phản ánh môi trường phông chữ hiện tại và [phông chữ được tải bên ngoài](/slides/vi/net/custom-font/). Các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) thay đổi đầu ra đã kết xuất nhưng không được phản ánh trong kết quả.

Một phép thay thế giống nhau có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo một danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) cung cấp cả hai phương thức. Chọn một phương thức phù hợp với phạm vi của hoạt động kết xuất:

| Ghi đè | Sử dụng khi |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) với không có đối số | Bạn cần các thay thế cho toàn bộ bản trình bày. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) với `int[] slides` | Bạn cần các thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Đặt Quy tắc Thay thế Phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình bày.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập cho thuộc tính [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Kết xuất hoặc chuyển đổi bản trình bày.

Ví dụ C# sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, sau đó kết xuất slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Để thay đổi không có điều kiện các phông chữ được sử dụng trong toàn bộ bản trình bày, xem [Thay thế phông chữ](/slides/vi/net/font-replacement/).
{{% /alert %}}

## **Giới hạn đối với Phông chữ Phương trình Toán học**

Các quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình kết xuất và chuyển đổi. Chúng hoạt động với văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ có sẵn được chỉ định trong quy tắc.

Các phương trình Office Math có yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và kết xuất bố cục phương trình. Một quy tắc thay thế bằng một phông chữ toán khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc kết xuất vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để kết xuất hoặc chuyển đổi bản trình bày như vậy, hãy làm cho **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/net/custom-font/).

Giới hạn này áp dụng cho bố cục phương trình. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thông thường trong bản trình bày.

## **FAQ**

**Sự khác biệt giữa việc thay thế phông chữ và thay thế phông chữ là gì?**

[Font replacement](/slides/vi/net/font-replacement/) thay đổi có chủ đích một phông chữ thành phông chữ khác trên toàn bộ bản trình bày. Thay thế phông chữ chọn một phông chữ cho đầu ra đã kết xuất khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/net/font-selection-sequence/) trong quá trình kết xuất và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của mình. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường thời gian chạy.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/net/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình kết xuất và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể yêu cầu thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải phông chữ bên ngoài cần thiết](/slides/vi/net/custom-font/), và [nhúng phông chữ](/slides/vi/net/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.