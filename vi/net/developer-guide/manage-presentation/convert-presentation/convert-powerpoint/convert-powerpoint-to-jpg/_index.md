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
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang ảnh JPG chất lượng cao trong C# với Aspose.Slides cho .NET bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang ảnh JPG giúp việc chia sẻ slide, tối ưu hiệu suất và nhúng nội dung vào website hoặc ứng dụng. Aspose.Slides for .NET cho phép bạn biến đổi các tệp PPTX, PPT và ODP thành ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, bạn dễ dàng triển khai trình xem trình chiếu riêng và tạo ảnh thu nhỏ cho mỗi slide. Điều này có ích nếu bạn muốn bảo vệ slide trình chiếu khỏi việc sao chép hoặc trình diễn trong chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình chiếu hoặc một slide cụ thể sang các định dạng ảnh.

## **Chuyển đổi các slide trình chiếu sang ảnh JPG**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy đối tượng slide kiểu [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide) từ bộ sưu tập [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/properties/slides) .
3. Tạo ảnh của slide bằng cách sử dụng phương thức [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/#getimage_5) .
4. Gọi phương thức [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/#save_3) trên đối tượng ảnh. Đưa tên tệp đầu ra và định dạng ảnh làm đối số.

{{% alert color="primary" %}} 
**Lưu ý:** Việc chuyển đổi PPT, PPTX hoặc ODP sang JPG khác với chuyển đổi sang các định dạng khác trong Aspose.Slides .NET API. Đối với các định dạng khác, bạn thường dùng phương thức [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/#save_5). Tuy nhiên, đối với chuyển đổi JPG, bạn cần dùng phương thức [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Tạo ảnh slide với tỉ lệ đã chỉ định.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Lưu ảnh vào đĩa ở định dạng JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Chuyển đổi slide sang JPG với kích thước tùy chỉnh**

Để thay đổi kích thước của các ảnh JPG tạo ra, bạn có thể đặt kích thước ảnh bằng cách truyền vào phương thức [ISlide.GetImage(Size)](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/#getimage_6). Điều này cho phép bạn tạo ra các ảnh có chiều rộng và chiều cao cụ thể, đảm bảo đầu ra đáp ứng yêu cầu về độ phân giải và tỉ lệ khung hình. Sự linh hoạt này đặc biệt hữu ích khi tạo ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi cần kích thước ảnh chính xác.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Tạo ảnh slide với kích thước đã chỉ định.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Lưu ảnh vào đĩa ở định dạng JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Kết xuất bình luận khi lưu slide dưới dạng ảnh**

Aspose.Slides for .NET cung cấp tính năng cho phép bạn kết xuất các bình luận trên slide của bản trình chiếu khi chuyển đổi chúng thành ảnh JPG. Tính năng này đặc biệt hữu ích để bảo tồn các chú thích, phản hồi hoặc thảo luận do cộng tác viên thêm vào trong các bản PowerPoint. Bằng cách bật tùy chọn này, bạn đảm bảo các bình luận hiển thị trong ảnh được tạo, giúp việc xem xét và chia sẻ phản hồi dễ dàng hơn mà không cần mở tệp trình chiếu gốc.

Giả sử chúng ta có một tệp trình chiếu, "sample.pptx", với một slide chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Đoạn mã C# sau đây chuyển đổi slide sang ảnh JPG đồng thời bảo tồn các bình luận:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Đặt tùy chọn cho các bình luận của slide.
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

![Ảnh JPG có bình luận](image_with_comments.png)

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang ảnh, chẳng hạn:

- [Chuyển đổi PowerPoint sang GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/)
- [Chuyển đổi PowerPoint sang PNG](/slides/vi/net/convert-powerpoint-to-png/)
- [Chuyển đổi PowerPoint sang TIFF](/slides/vi/net/convert-powerpoint-to-tiff/)
- [Chuyển đổi PowerPoint sang SVG](/slides/vi/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Để xem cách Aspose.Slides chuyển đổi PowerPoint sang ảnh JPG, hãy thử các công cụ chuyển đổi trực tuyến miễn phí sau: PowerPoint [PPTX sang JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT sang JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Trình chuyển đổi PPTX sang JPG trực tuyến miễn phí](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose cung cấp một [ứng dụng Collage miễn phí](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép các ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 

Dựa trên các nguyên tắc đã mô tả trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/); chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/); chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides sẽ kết xuất tất cả nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác của quá trình kết xuất có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu phông chữ.

**Có bất kỳ giới hạn nào về số lượng slide có thể xử lý không?**

Aspose.Slides tự thân không áp đặt bất kỳ giới hạn nghiêm ngặt nào về số lượng slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bản trình chiếu lớn hoặc ảnh độ phân giải cao.