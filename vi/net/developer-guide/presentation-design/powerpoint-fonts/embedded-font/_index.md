---
title: Nhúng phông chữ trong bản trình chiếu bằng .NET
linktitle: Phông chữ đã nhúng
type: docs
weight: 40
url: /vi/net/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các phông chữ đã nhúng trong PowerPoint bằng Aspose.Slides cho .NET. Sử dụng C# để thêm, lấy, xóa và nén phông chữ nhằm giữ nguyên giao diện văn bản và giảm kích thước tệp."
---
## **Introduction**

Nhúng phông chữ lưu trữ dữ liệu phông chữ bên trong một bản trình chiếu PowerPoint. Khi một trình xem hỗ trợ phông chữ nhúng, nó có thể hiển thị văn bản bằng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống đích. Điều này giúp giữ nguyên ngắt dòng, khoảng cách văn bản và bố cục slide.

Aspose.Slides for .NET cho phép bạn truy xuất, thêm và xóa phông chữ nhúng thông qua thuộc tính [FontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/fontsmanager/) của một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản trình chiếu không sử dụng.

Các ví dụ dưới đây làm việc với tập tin PPTX. Trước khi nhúng phông chữ, hãy chắc chắn dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông chữ Nhúng**

Sử dụng [GetEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) để liệt kê các phông chữ được lưu trong một bản trình chiếu. Để xóa một phông chữ, truyền phông chữ đó từ danh sách vào [RemoveEmbeddedFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/removeembeddedfont/), sau đó lưu bản trình chiếu.

Ví dụ sau liệt kê các phông chữ nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó tồn tại:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Xóa một phông chữ nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Nếu không, việc render có thể yêu cầu [font substitution](/slides/vi/net/font-substitution/), điều này có thể ảnh hưởng đến bố cục.

## **Kiểm tra Dữ liệu Phông chữ và Quyền Nhúng**

Sử dụng giao diện [IFontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/) để kiểm tra phông chữ trước khi nhúng chúng. Gọi [IFontsManager.GetFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong bản trình chiếu. Với mỗi phông chữ, truyền một đối tượng [IFontData](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/net/aspose.slides/fontstyletype/) cần thiết vào [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getfontbytes/). Phương thức này trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `null` khi phông chữ hoặc kiểu yêu cầu không có sẵn. Đừng truyền kết quả `null` vào [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), vì phương thức này yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/net/aspose.slides/embeddinglevel/) là một enum kiểu cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép của phông chữ.
- `Restricted` cấm nhúng trừ khi được phép từ chủ sở hữu pháp lý của phông chữ khi nó là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu.
- `NoSubsetting` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần con của các glyph. Khi cờ này có mặt, phải nhúng toàn bộ ký tự.
- `BitmapOnly` là một hạn chế bổ sung cho phép chỉ nhúng các bitmap strike, không phải dữ liệu outline. Nếu phông chữ không có bitmap strike, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể kết hợp với chúng. Kiểm tra các bộ điều chỉnh bằng phép toán bitwise. Vì `Installable` bằng zero, không dùng `HasFlag` để phát hiện; hãy áp dụng mặt nạ cho các bit quyền sử dụng và so sánh kết quả với `Installable`. Các phông chữ hiện nay nên đặt tối đa một bit quyền sử dụng. Để tương thích với các phông chữ cũ đặt nhiều hơn một bit, hàm trợ giúp dưới đây chọn quyền ít hạn chế nhất: `Editable`, sau đó `PreviewPrint`, rồi `Restricted`.

Ví dụ sau kiểm tra dữ liệu thường, đậm, nghiêng và đậm-ngoặc cho mỗi phông chữ được trả về bởi `GetFonts`. Nó bỏ qua các kiểu không có, phông chữ bị hạn chế, phông chữ chỉ bitmap, phông chữ giới hạn ở preview và print vì kết quả vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào có sẵn có `NoSubsetting`, nó sẽ nhúng toàn bộ ký tự cho họ phông chữ đó.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Kiểm tra này báo cáo các hạn chế được mã hoá trong từng tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã có phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao đã nhúng.

## **Thêm Phông chữ Nhúng**

Sử dụng [AddEmbeddedFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/addembeddedfont/) để nhúng một phông chữ. Các overload của nó chấp nhận hoặc một đối tượng [IFontData](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontdata/), hoặc một mảng byte chứa dữ liệu phông chữ. Enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedfontcharacters/) điều khiển các ký tự được bao gồm:

- [All](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedfontcharacters/) nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình chiếu và nhập văn bản mới.
- [OnlyUsed](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedfontcharacters/) chỉ nhúng các ký tự được sử dụng trong bản trình chiếu để giảm kích thước tệp. Chọn tùy chọn này cho bản trình chiếu đã hoàn thành, chủ yếu để xem.

Ví dụ sau sử dụng [GetFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được dùng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng hiện có sẽ giữ lại bộ ký tự hiện tại của chúng.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Nén Phông chữ Nhúng**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không dùng. Nó hoạt động trên các phông chữ đã được nhúng, vì vậy mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không dùng trong bản trình chiếu.

Ví dụ sau nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả dưới dạng tệp riêng:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Giữ lại tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ đã nhúng, ngay cả khi bạn đã nhúng toàn bộ ký tự từ đầu.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra xem một phông chữ nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [GetSubstitutions](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getsubstitutions/) trong môi trường bạn render bản trình chiếu để xem Aspose.Slides sẽ thay thế những phông chữ nào. Cũng kiểm tra cài đặt [font substitution](/slides/vi/net/font-substitution/) và quy tắc [font fallback](/slides/vi/net/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết các ký tự mà phông chữ đó không có.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Căn cứ quyết định dựa trên môi trường mục tiêu. Nếu các phông chữ cần thiết có sẵn trên mọi máy mở hoặc render bản trình chiếu, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp giữ nguyên giao diện mong muốn, với điều kiện giấy phép cho phép.