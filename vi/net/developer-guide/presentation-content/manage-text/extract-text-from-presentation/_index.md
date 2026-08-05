---
title: Trích xuất văn bản nâng cao từ các bài thuyết trình trong .NET
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/vi/
keywords:
  - trích xuất văn bản
  - trích xuất văn bản từ slide
  - trích xuất văn bản từ bài thuyết trình
  - trích xuất văn bản từ PowerPoint
  - trích xuất văn bản từ OpenDocument
  - trích xuất văn bản từ PPT
  - trích xuất văn bản từ PPTX
  - trích xuất văn bản từ ODP
  - lấy văn bản
  - lấy văn bản từ slide
  - lấy văn bản từ bài thuyết trình
  - lấy văn bản từ PowerPoint
  - lấy văn bản từ OpenDocument
  - lấy văn bản từ PPT
  - lấy văn bản từ PPTX
  - lấy văn bản từ ODP
  - PowerPoint
  - OpenDocument
  - bài thuyết trình
  - .NET
  - C#
  - Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bài thuyết trình PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho .NET. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bài thuyết trình là một nhiệm vụ phổ biến nhưng thiết yếu đối với các nhà phát triển làm việc với nội dung slide. Dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hoặc các bài thuyết trình OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể quan trọng cho mục đích phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách trích xuất văn bản một cách hiệu quả từ các định dạng bài thuyết trình khác nhau, bao gồm PPT, PPTX và ODP, bằng cách sử dụng Aspose.Slides cho .NET. Bạn sẽ học cách duyệt hệ thống các phần tử của bài thuyết trình để lấy chính xác nội dung văn bản mà bạn cần.

## **Trích xuất văn bản từ một slide**

Aspose.Slides cho .NET cung cấp không gian tên [Aspose.Slides.Util](https://reference.aspose.com/slides/vi/net/aspose.slides.util/), trong đó bao gồm lớp [SlideUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/). Lớp này cung cấp một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bài thuyết trình hoặc slide. Để trích xuất văn bản từ một slide trong bài thuyết trình, hãy sử dụng phương thức [GetAllTextBoxes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextboxes/). Phương thức này nhận một đối tượng có kiểu [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/) làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng có kiểu [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), bảo lưu bất kỳ định dạng văn bản nào.

Đoạn mã sau đây trích xuất toàn bộ văn bản từ slide đầu tiên của bài thuyết trình:

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

## **Trích xuất văn bản từ một bài thuyết trình**

Để quét văn bản từ toàn bộ bài thuyết trình, hãy sử dụng phương thức tĩnh [GetAllTextFrames](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextframes/) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [IPresentation](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/) đại diện cho một bài thuyết trình PowerPoint hoặc OpenDocument mà từ đó sẽ trích xuất văn bản.
1. Thứ hai, một giá trị `Boolean` chỉ ra liệu các slide master có nên được bao gồm khi quét văn bản từ bài thuyết trình hay không.

Phương thức trả về một mảng các đối tượng có kiểu [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bài thuyết trình, bao gồm các slide master.

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

## **Trích xuất văn bản có phân loại và nhanh chóng**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bài thuyết trình:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/net/aspose.slides/textextractionarrangingmode/) chỉ ra chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô mà không quan tâm đến vị trí của nó trên slide.
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ Unarranged có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn so với chế độ Arranged.

[IPresentationText](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationtext/) đại diện cho văn bản thô được trích xuất từ bài thuyết trình. Thuộc tính `SlidesText` của nó trả về một mảng các đối tượng có kiểu [ISlideText](https://reference.aspose.com/slides/vi/net/aspose.slides/islidetext/). Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng có kiểu [ISlideText](https://reference.aspose.com/slides/vi/net/aspose.slides/islidetext/) có các thuộc tính sau:

- `Text` - Văn bản trong các hình dạng của slide.
- `MasterText` - Văn bản trong các hình dạng của slide master liên kết với slide này.
- `LayoutText` - Văn bản trong các hình dạng của slide layout liên kết với slide này.
- `NotesText` - Văn bản trong các hình dạng của slide ghi chú liên kết với slide này.
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

**Aspose.Slides xử lý các bài thuyết trình lớn trong quá trình trích xuất văn bản nhanh như thế nào?**

Aspose.Slides được tối ưu hóa cho hiệu năng cao và có thể xử lý ngay cả [các bài thuyết trình lớn](/slides/vi/net/open-presentation/), làm cho nó phù hợp cho các kịch bản xử lý thời gian thực hoặc xử lý hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bài thuyết trình không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều phần tử của slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, vì vậy bạn có thể truy cập và phân tích nội dung văn bản trong các cấu trúc bài thuyết trình thường gặp.

**Tôi có cần giấy phép Aspose.Slides đặc biệt để trích xuất văn bản từ bài thuyết trình không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, mặc dù nó sẽ có [một số hạn chế](/slides/vi/net/licensing/), chẳng hạn chỉ xử lý được số lượng slide giới hạn. Đối với việc sử dụng không giới hạn và để xử lý các bài thuyết trình lớn hơn, nên mua giấy phép đầy đủ.