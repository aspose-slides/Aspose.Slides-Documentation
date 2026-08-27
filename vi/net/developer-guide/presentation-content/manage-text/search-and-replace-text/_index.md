---
title: Tìm kiếm và Thay thế Văn bản trong Bài trình chiếu PowerPoint bằng .NET
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
- báo cáo kiểm tra
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm kiếm, làm nổi bật và thay thế văn bản trong các bài trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp với Aspose.Slides for .NET."
---
## **Tổng quan**

Aspose.Slides for .NET có thể tìm kiếm, làm nổi bật và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mỗi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng một nhật ký kiểm tra chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc xem xét, xóa thông tin nhạy cảm, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn Phạm vi Tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) để giới hạn một thao tác trong một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình chiếu.

| Thao tác | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Làm nổi bật văn bản nguyên văn | [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlighttext/) |
| Làm nổi bật các khớp biểu thức chính quy | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlightregex/) |
| Thay thế văn bản nguyên văn | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replacetext/) |
| Thay thế các khớp biểu thức chính quy | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replaceregex/) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/wholewordsonly/) giới hạn các kết quả khớp chỉ ở các từ hoàn chỉnh.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/casesensitive/) kiểm soát việc có phải khớp chữ hoa/chữ thường hay không.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/includenotes/) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và làm nổi bật ở mức bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng .NET `Regex`, vì vậy các quy tắc khớp như độ nhạy cảm chữ hoa/chữ thường và ranh giới từ được xác định bởi biểu thức và các tùy chọn của nó.

## **Xác định Chủ sở hữu của Khung Văn bản**

Các quy trình xử lý văn bản chung thường nhận một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/) và [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) để xác định đối tượng bản trình chiếu nào sở hữu khung văn bản.

Các giá trị mong đợi phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `ParentShape` | `ParentCell` |
|---|---|---|
| Một AutoShape hoặc một hình dạng chứa văn bản khác | Đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) sở hữu | `null` |
| Một ô bảng | `null` | Đối tượng [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) sở hữu |

Cả hai thuộc tính đều là thuộc tính điều hướng chỉ đọc. Đọc chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị đối với `null` và xử lý khả năng không có chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextframes/) để duyệt qua các khung văn bản trong một bản trình chiếu. Đối với hình dạng, nó báo cáo tên hình dạng, loại hình dạng và slide chứa. Đối với ô bảng, nó báo cáo tọa độ cột và hàng (bắt đầu từ 0) và slide chứa.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Đối với nội dung SmartArt, duyệt qua các hình dạng trong [ISmartArtNode.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartartnode/shapes/) và truy cập mỗi [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartartshape/textframe/). Khung văn bản có thể được truy ngược tới hình dạng liên quan thông qua [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/), trong khi [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) là `null`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập Thông tin Khớp với Callback**

Triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi kết quả khớp. Phương thức [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/foundresult/) cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Đoạn triển khai dưới đây suy ra số slide từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Một số slide nullable cho phép cùng một mô hình kết quả đại diện cho văn bản liên quan đến các loại slide khác.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

## **Làm nổi bật Văn bản**

Sử dụng phương thức [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/) để làm nổi bật các khớp văn bản nguyên văn trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/) để kiểm soát tìm kiếm và một callback để thu thập chi tiết khớp.

Ví dụ mã dưới đây làm nổi bật mọi lần xuất hiện của ký tự **"try"** và sau đó chỉ làm nổi bật toàn bộ từ **"to"**. Cả hai tìm kiếm đều báo cáo kết quả cho cùng một callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Lấy hình dạng đầu tiên từ slide đầu tiên.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Làm nổi bật mọi lần xuất hiện của "try" trong khung văn bản.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Chỉ làm nổi bật toàn bộ từ "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Kết quả:

![Văn bản đã được làm nổi bật](highlighted_text.png)

## **Làm nổi bật Văn bản bằng Biểu thức Chính quy**

Phương thức [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/) làm nổi bật các khớp văn bản được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Đoạn mã sau làm nổi bật mọi từ có bảy ký tự trở lên và thu thập mỗi khớp:

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

![Văn bản đã được làm nổi bật bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Làm nổi bật Văn bản Trên Toàn Bộ Bản Trình Chiếu**

Sử dụng [Presentation.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlighttext/) và [Presentation.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/highlightregex/) để tìm kiếm tất cả các khung văn bản áp dụng trong bản trình chiếu. Ví dụ dưới đây làm nổi bật một thuật ngữ nguyên văn và tất cả địa chỉ email đồng thời giữ các bộ sưu tập kết quả riêng cho hai tìm kiếm.

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

## **Thay thế Văn bản trong Khung Văn bản**

Sử dụng [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) cho văn bản nguyên văn và [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ dưới đây chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản. Cùng một callback ghi lại các thuật ngữ gốc khớp bởi cả hai thao tác.

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

Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy xem lại kết quả để xác nhận định dạng nào nên áp dụng cho văn bản thay thế.

## **Thay thế Văn bản Trên Toàn Bộ Bản Trình Chiếu**

Sử dụng [Presentation.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replacetext/) và [Presentation.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replaceregex/) để áp dụng cùng các thao tác trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa thông tin nhạy cảm.

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

## **Nhóm Các Khớp cho Báo cáo**

Bởi vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các khớp để kiểm tra, báo cáo hoặc quy trình xem xét. Ví dụ dưới đây nhóm các kết quả đã thu thập trước tiên theo slide và sau đó theo khung văn bản:

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

**Làm sao tôi có thể tìm kiếm chỉ một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của hình dạng và gọi [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/), hoặc [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) trên khung văn bản đó. Các phương thức ở mức bản trình chiếu sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp toàn bộ từ với đúng viết hoa?**

Đặt [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/wholewordsonly/) và [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/casesensitive/) thành `true`, và truyền các tùy chọn vào phương thức làm nổi bật hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, xác định ranh giới từ và độ nhạy cảm chữ hoa/chữ thường trong chính `Regex` của .NET.

**Tìm kiếm và thay thế có thể bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/includenotes/) thành `true` khi sử dụng thao tác văn bản nguyên văn ở mức bản trình chiếu. Đoạn triển khai callback ở trên sẽ ánh xạ một kết quả trong slide ghi chú về số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không phải quét lại bản trình chiếu một lần nữa?**

Truyền một triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/ifindresultcallback/) vào thao tác làm nổi bật hoặc thay thế. Callback nhận mọi kết quả khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để sau này nhóm hoặc xuất.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replacetext/) và [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/replaceregex/) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ định dạng phần xung quanh. Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo phần thay thế sử dụng kiểu định dạng mong muốn.