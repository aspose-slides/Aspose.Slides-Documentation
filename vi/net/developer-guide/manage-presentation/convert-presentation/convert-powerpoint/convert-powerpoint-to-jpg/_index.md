---
title: Chuyển đổi PPT và PPTX sang JPG trong .NET
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/net/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bản trình chiếu sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bản trình chiếu dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) thành hình ảnh JPG chất lượng cao trong C# với Aspose.Slides cho .NET bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang hình ảnh JPG giúp chia sẻ slide, tối ưu hiệu suất và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides for .NET cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, bạn có thể dễ dàng triển khai trình xem bản trình chiếu của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ các slide trình chiếu khỏi việc sao chép hoặc trình chiếu ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình chiếu hoặc một slide cụ thể sang định dạng hình ảnh.

## **Chuyển Đổi Các Slide Trình Chiếu Sang Hình Ảnh JPG**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
1. Lấy đối tượng slide kiểu [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide) từ tập hợp [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/properties/slides) .
1. Tạo một hình ảnh của slide bằng phương thức [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/#getimage_5) .
1. Gọi phương thức [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/#save_3) trên đối tượng hình ảnh. Truyền tên tệp đầu ra và định dạng hình ảnh làm đối số.

{{% alert color="info" %}} 

**Lưu ý:** PPT, PPTX hoặc ODP sang chuyển đổi JPG khác với chuyển đổi sang các định dạng khác trong API Aspose.Slides .NET. Đối với các định dạng khác, bạn thường sử dụng phương thức [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/#save_5). Tuy nhiên, đối với chuyển đổi JPG, bạn cần sử dụng phương thức [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/#save_3).

{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Tạo một hình ảnh slide với tỷ lệ đã chỉ định.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Lưu hình ảnh vào đĩa ở định dạng JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```
## **Chuyển Đổi Các Slide Sang JPG Với Kích Thước Tùy Chỉnh**

Để thay đổi kích thước của các hình ảnh JPG được tạo ra, bạn có thể đặt kích thước hình ảnh bằng cách truyền vào phương thức [ISlide.GetImage(Size)](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/#getimage_6). Điều này cho phép bạn tạo ra các hình ảnh với giá trị chiều rộng và chiều cao cụ thể, đảm bảo rằng đầu ra đáp ứng yêu cầu về độ phân giải và tỷ lệ khung hình của bạn. Tính linh hoạt này đặc biệt hữu ích khi tạo hình ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi cần các kích thước hình ảnh chính xác.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Tạo một hình ảnh slide với kích thước đã chỉ định.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Lưu hình ảnh vào đĩa ở định dạng JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```
## **Hiển Thị Bình Luận Khi Lưu Slide Dưới Dạng Hình Ảnh**

Aspose.Slides for .NET cung cấp một tính năng cho phép bạn hiển thị bình luận trên các slide của bản trình chiếu khi chuyển đổi chúng sang hình ảnh JPG. Chức năng này đặc biệt hữu ích để bảo tồn các chú thích, phản hồi hoặc thảo luận do cộng tác viên thêm vào bản trình chiếu PowerPoint. Bằng cách bật tùy chọn này, bạn đảm bảo rằng bình luận hiển thị trong các hình ảnh được tạo, giúp việc xem lại và chia sẻ phản hồi dễ dàng hơn mà không cần mở file bản trình chiếu gốc.

Giả sử chúng ta có một tệp bản trình chiếu, "sample.pptx", với một slide có chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Mã C# sau đây chuyển đổi slide sang hình ảnh JPG trong khi giữ lại bình luận:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Đặt các tùy chọn cho bình luận slide.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Chuyển đổi slide đầu tiên thành hình ảnh.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Kết quả:

![Hình JPG có bình luận](image_with_comments.png)

## **Xem Thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang hình ảnh, chẳng hạn như:

- [Chuyển Đổi PowerPoint Sang GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/)
- [Chuyển Đổi PowerPoint Sang PNG](/slides/vi/net/convert-powerpoint-to-png/)
- [Chuyển Đổi PowerPoint Sang TIFF](/slides/vi/net/convert-powerpoint-to-tiff/)
- [Chuyển Đổi PowerPoint Sang SVG](/slides/vi/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Để xem cách Aspose.Slides chuyển đổi PowerPoint sang hình ảnh JPG, hãy thử các công cụ chuyển đổi trực tuyến miễn phí sau: PowerPoint [PPTX sang JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT sang JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Trình Chuyển Đổi PPTX Sang JPG Trực Tuyến Miễn Phí](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất các hình ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 

Sử dụng các nguyên tắc giống nhau mô tả trong bài viết này, bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

### Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?

Có, Aspose.Slides hiển thị mọi nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và nhiều hơn nữa. Tuy nhiên, độ chính xác của việc hiển thị có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu.

### Có bất kỳ giới hạn nào về số lượng slide có thể được xử lý không?

Aspose.Slides tự nó không đưa ra bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình chiếu lớn hoặc hình ảnh độ phân giải cao.