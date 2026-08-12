---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint bằng .NET
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/net/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- làm nổi bật văn bản
- thay thế văn bản
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo kiểm toán
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm kiếm, làm nổi bật và thay thế văn bản trong bản trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET có thể tìm kiếm, làm nổi bật và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mỗi kết quả khớp qua một callback kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng nhật ký kiểm tra chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa thông tin, kiểm tra thuật ngữ, dọn dẹp mẫu, và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) để giới hạn một thao tác cho một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình chiếu.

| Thao tác | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Đánh dấu văn bản nguyên văn | [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlighttext/) |
| Đánh dấu kết quả biểu thức chính quy | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlightregex/) |
| Thay thế văn bản nguyên văn | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replacetext/) |
| Thay thế kết quả biểu thức chính quy | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replaceregex/) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/wholewordsonly/) giới hạn các kết quả khớp chỉ ở các từ hoàn chỉnh.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/casesensitive/) kiểm soát việc có phải khớp phân biệt chữ hoa chữ thường hay không.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/includenotes/) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và làm nổi bật ở cấp độ bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng .NET `Regex`, vì vậy các quy tắc khớp như phân biệt chữ hoa chữ thường và ranh giới từ được xác định bởi biểu thức và các tùy chọn của nó.

## **Thu thập thông tin khớp với Callback**

Thực hiện [IFindResultCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi kết quả khớp. Phương thức [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/foundresult/) cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận số slide một cách trực tiếp. Triển khai dưới đây suy ra nó từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Một số slide nullable cho phép cùng một mô hình kết quả đại diện cho văn bản liên quan đến các loại slide khác.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Đối với các thao tác thay thế, `FoundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Làm nổi bật văn bản**

Sử dụng phương thức [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/) để làm nổi bật các kết quả khớp văn bản nguyên văn trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/) để kiểm soát tìm kiếm và một callback để thu thập chi tiết kết quả.

Mã mẫu bên dưới làm nổi bật mọi lần xuất hiện của các ký tự **"try"** và sau đó chỉ làm nổi bật toàn từ **"to"**. Cả hai tìm kiếm đều báo cáo các kết quả cho cùng một callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Kết quả:

![Văn bản được làm nổi bật](highlighted_text.png)

## **Làm nổi bật văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/) làm nổi bật các phần văn bản khớp được tìm bằng biểu thức chính quy trong một khung văn bản.

Mã sau làm nổi bật tất cả các từ chứa bảy ký tự trở lên và thu thập mỗi kết quả:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Kết quả:

![Văn bản được làm nổi bật bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Làm nổi bật văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlighttext/) và [Presentation.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlightregex/) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình chiếu. Ví dụ dưới đây làm nổi bật một thuật ngữ nguyên văn và mọi địa chỉ email đồng thời giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) cho văn bản nguyên văn và [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ lại định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hoá một biến thể chính tả rồi thay thế các nhãn phiên bản. Cùng một callback ghi lại các thuật ngữ gốc đã được khớp bởi cả hai thao tác.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ được áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replacetext/) và [Presentation.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replaceregex/) để áp dụng các thao tác giống nhau trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa thông tin.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Nhóm kết quả cho báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả cho công việc kiểm toán, báo cáo hoặc rà soát. Ví dụ dưới đây nhóm các kết quả đã thu thập đầu tiên theo slide rồi theo khung văn bản:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của shape và gọi [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) hoặc [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) trên khung văn bản đó. Các phương thức cấp độ bản trình chiếu xử lý tất cả các khung văn bản áp dụng thay vì.

**Làm sao tôi có thể khớp các từ đầy đủ với việc viết hoa đúng?**

Đặt [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/wholewordsonly/) và [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/casesensitive/) thành `true`, và truyền các tùy chọn này vào phương thức làm nổi bật hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, xác định ranh giới từ và phân biệt chữ hoa chữ thường trong chính `Regex` của .NET.

**Tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/includenotes/) thành `true` khi sử dụng thao tác văn bản nguyên văn ở cấp độ bản trình chiếu. Việc thực hiện callback được hiển thị ở trên ánh xạ một kết quả trong slide ghi chú trở lại số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không quét lại bản trình chiếu lần thứ hai?**

Truyền một triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/) vào thao tác làm nổi bật hoặc thay thế. Callback nhận mọi kết quả khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide đã suy ra để nhóm hoặc xuất sau.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) và [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ nguyên định dạng phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu dáng mong muốn.