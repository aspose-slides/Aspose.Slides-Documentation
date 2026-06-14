---
title: Tạo Trình xem Bản trình chiếu trong .NET
linktitle: Trình xem Bản trình chiếu
type: docs
weight: 50
url: /vi/net/presentation-viewer/
keywords:
- xem bản trình chiếu
- trình xem bản trình chiếu
- tạo trình xem bản trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo một trình xem bản trình chiếu tùy chỉnh trong .NET bằng Aspose.Slides. Dễ dàng hiển thị tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Giới thiệu**

Aspose.Slides for .NET được sử dụng để tạo các tệp bản trình chiếu có các slide. Các slide này có thể được xem bằng cách mở bản trình chiếu trong Microsoft PowerPoint, ví dụ. Tuy nhiên, các nhà phát triển đôi khi cần xem các slide dưới dạng hình ảnh trong trình xem ảnh ưa thích hoặc sử dụng chúng trong một trình xem bản trình chiếu tùy chỉnh. Trong những trường hợp như vậy, Aspose.Slides cho phép bạn xuất các slide riêng lẻ thành hình ảnh. Bài viết này giải thích cách thực hiện.

## **Tạo hình ảnh SVG từ một Slide**

Để tạo hình ảnh SVG từ một slide trong bản trình chiếu bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Mở một luồng tệp.
1. Lưu slide dưới dạng hình ảnh SVG vào luồng tệp.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Tạo SVG với ID Hình dạng Tùy chỉnh**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với `ID` hình dạng tùy chỉnh. Để thực hiện điều này, sử dụng thuộc tính Id từ giao diện [ISvgShape](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshape). Lớp `CustomSvgShapeFormattingController` có thể được dùng để đặt ID cho hình dạng.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Tạo Hình ảnh Thu nhỏ Slide**

Aspose.Slides giúp bạn tạo các hình ảnh thu nhỏ của slide. Để tạo một hình thu nhỏ của slide bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Tạo một hình thu nhỏ của slide đã tham chiếu với tỉ lệ mong muốn.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Tạo Thu nhỏ Slide với Kích thước Được Người dùng Định nghĩa**

Để tạo hình ảnh thu nhỏ slide với kích thước được người dùng định nghĩa, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Tạo một hình thu nhỏ của slide đã tham chiếu với các kích thước được chỉ định.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Tạo Thu nhỏ Slide với Ghi chú Diễn giả**

Để tạo hình thu nhỏ của một slide có ghi chú diễn giả bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/).
1. Sử dụng thuộc tính `RenderingOptions.SlidesLayoutOptions` để đặt vị trí của ghi chú diễn giả.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Tạo một hình thu nhỏ của slide đã tham chiếu bằng cách sử dụng các tùy chọn render.
1. Lưu hình thu nhỏ ở định dạng ảnh mà bạn muốn.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Ví dụ Trực tiếp**

Thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem bạn có thể thực hiện gì với API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/vi/viewer/)

## **Câu hỏi thường gặp**

**Tôi có thể nhúng trình xem bản trình chiếu vào ứng dụng web ASP.NET không?**

Có. Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để render các slide thành hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và thu phóng có thể được triển khai bằng JavaScript để có trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong một trình xem .NET tùy chỉnh là gì?**

Cách được khuyến nghị là render mỗi slide dưới dạng hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi nó sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một picture box (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm thế nào để xử lý các bản trình chiếu lớn với nhiều slide?**

Đối với các bộ slide lớn, hãy cân nhắc tải lười (lazy-loading) hoặc render slide khi cần. Điều này có nghĩa là tạo nội dung của slide chỉ khi người dùng chuyển tới, giúp giảm bộ nhớ và thời gian tải.