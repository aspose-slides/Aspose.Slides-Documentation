---
title: "Trích xuất văn bản nâng cao từ bản trình chiếu trong .NET"
linktitle: "Trích xuất Văn bản"
type: docs
weight: 90
url: /vi/net/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình chiếu
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình chiếu
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Thực hiện theo hướng dẫn từng bước đơn giản của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ bản trình chiếu là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Cho dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay bản trình chiếu OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể quan trọng cho mục đích phân tích, tự động hoá, lập chỉ mục, hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách trích xuất văn bản một cách hiệu quả từ các định dạng bản trình chiếu khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for .NET. Bạn sẽ học cách duyệt qua các thành phần của bản trình chiếu để lấy chính xác nội dung văn bản cần thiết.

## **Trích xuất Văn bản từ một Slide**

Aspose.Slides for .NET cung cấp không gian tên [Aspose.Slides.Util](https://reference.aspose.com/slides/vi/net/aspose.slides.util/) , bao gồm lớp [SlideUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/). Lớp này cung cấp một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản trình chiếu hoặc slide. Để trích xuất văn bản từ một slide trong bản trình chiếu, sử dụng phương thức [GetAllTextBoxes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextboxes/). Phương thức này nhận một đối tượng kiểu [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/) làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), giữ nguyên mọi định dạng văn bản.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình chiếu:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Trích xuất Văn bản từ một Bản Trình Chiếu**

Để quét văn bản từ toàn bộ bản trình chiếu, sử dụng phương thức tĩnh [GetAllTextFrames](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextframes/) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [IPresentation](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/) đại diện cho bản trình chiếu PowerPoint hoặc OpenDocument mà từ đó sẽ trích xuất văn bản.  
1. Thứ hai, một giá trị `Boolean` chỉ định liệu các slide mẫu (master slides) có được bao gồm khi quét văn bản từ bản trình chiếu hay không.

Phương thức trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản trình chiếu, bao gồm cả các slide mẫu.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Trích xuất Văn bản Phân Loại và Nhanh**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ bản trình chiếu:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/net/aspose.slides/textextractionarrangingmode/) chỉ định chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô mà không quan tâm đến vị trí trên slide.  
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp (`Unarranged`) có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ đã sắp xếp.

[IPresentationText](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình chiếu. Thuộc tính `SlidesText` của nó trả về một mảng các đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/net/aspose.slides/islidetext/). Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/net/aspose.slides/islidetext/) có các thuộc tính sau:

- `Text` - Văn bản trong các hình dạng của slide.  
- `MasterText` - Văn bản trong các hình dạng của slide mẫu (master) liên kết với slide này.  
- `LayoutText` - Văn bản trong các hình dạng của slide bố cục (layout) liên kết với slide này.  
- `NotesText` - Văn bản trong các hình dạng của slide ghi chú (notes) liên kết với slide này.  
- `CommentsText` - Văn bản trong các bình luận liên kết với slide này.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý nhanh như thế nào khi trích xuất văn bản từ các bản trình chiếu lớn?**

Aspose.Slides được tối ưu cho hiệu năng cao và có thể xử lý ngay cả [bản trình chiếu lớn](/slides/vi/net/open-presentation/), giúp nó phù hợp cho các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình chiếu không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều thành phần của slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc trình chiếu phổ biến.

**Tôi có cần giấy phép Aspose.Slides đặc biệt để trích xuất văn bản từ bản trình chiếu không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, mặc dù nó sẽ có [một số hạn chế](/slides/vi/net/licensing/), chẳng hạn chỉ xử lý được một số slide giới hạn. Để sử dụng không giới hạn và xử lý các bản trình chiếu lớn hơn, việc mua giấy phép đầy đủ được khuyến nghị.