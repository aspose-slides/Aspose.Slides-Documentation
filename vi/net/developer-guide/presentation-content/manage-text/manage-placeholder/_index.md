---
title: Quản lý Trình giữ chỗ Bản trình bày trong .NET
linktitle: Quản lý Trình giữ chỗ
type: docs
weight: 10
url: /vi/net/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ ảnh
- trình giữ chỗ biểu đồ
- văn bản nhắc
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng quản lý các trình giữ chỗ trong Aspose.Slides cho .NET: thay thế văn bản, tùy chỉnh nhắc nhở và đặt độ trong suốt cho hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các trình giữ chỗ của bản trình bày một cách lập trình. Bài viết này giải thích cách tìm trình giữ chỗ trên các slide và thay đổi văn bản của chúng, đặt văn bản nhắc tùy chỉnh cho bố cục trình giữ chỗ, và điều chỉnh độ trong suốt của ảnh được sử dụng làm nền cho trình giữ chỗ. Nó cũng bao gồm một phần FAQ ngắn giải thích sự khác biệt giữa trình giữ chỗ cơ sở và hình dạng cục bộ, cách các thay đổi trình giữ chỗ có thể được áp dụng qua bố cục hoặc master, và chỉ đến việc quản lý trình giữ chỗ tiêu đề và chân trang.

## **Thay đổi văn bản trong Trình giữ chỗ**
Sử dụng [Aspose.Slides for .NET](/slides/vi/net/), bạn có thể tìm và sửa đổi các trình giữ chỗ trên các slide trong bản trình bày. Aspose.Slides cho phép bạn thay đổi văn bản trong một trình giữ chỗ.

**Yêu cầu trước**: Bạn cần một bản trình bày có chứa trình giữ chỗ. Bạn có thể tạo bản trình bày như vậy bằng ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn sử dụng Aspose.Slides để thay thế văn bản trong trình giữ chỗ của bản trình bày đó:

1. Khởi tạo lớp [`Presentation`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và truyền bản trình bày làm đối số.
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Duyệt qua các shape để tìm trình giữ chỗ.
4. Ép kiểu shape trình giữ chỗ sang một [`AutoShape`](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) và thay đổi văn bản bằng cách sử dụng [`TextFrame`](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) liên kết với [`AutoShape`](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/). 
5. Lưu bản trình bày đã sửa đổi.

Đoạn mã C# này cho thấy cách thay đổi văn bản trong một trình giữ chỗ:

```c#
// Khởi tạo một lớp Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Duyệt qua các shape để tìm trình giữ chỗ
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Thay đổi văn bản trong mỗi trình giữ chỗ
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Lưu bản trình bày vào đĩa
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Đặt văn bản nhắc trong Trình giữ chỗ**
Các bố cục tiêu chuẩn và đã được xây dựng sẵn chứa các văn bản nhắc cho trình giữ chỗ như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn các văn bản nhắc ưa thích của mình vào các bố cục trình giữ chỗ.

Đoạn mã C# này cho bạn thấy cách đặt văn bản nhắc trong một trình giữ chỗ:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Duyệt qua slide
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint hiển thị "Nhấn để thêm tiêu đề"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Thêm phụ đề
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Đặt độ trong suốt cho hình ảnh trình giữ chỗ**

Aspose.Slides cho phép bạn đặt độ trong suốt của ảnh nền trong một trình giữ chỗ văn bản. Bằng cách điều chỉnh độ trong suốt của ảnh trong khung như vậy, bạn có thể làm cho văn bản hoặc ảnh nổi bật (tùy thuộc vào màu của văn bản và ảnh).

Đoạn mã C# này cho bạn thấy cách đặt độ trong suốt cho nền ảnh (bên trong một shape):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Trình giữ chỗ cơ sở là gì, và nó khác gì so với hình dạng cục bộ trên một slide?**

Trình giữ chỗ cơ sở là shape gốc trên một layout hoặc master mà shape của slide kế thừa—kiểu, vị trí và một số định dạng được lấy từ nó. Hình dạng cục bộ là độc lập; nếu không có trình giữ chỗ cơ sở, việc kế thừa sẽ không áp dụng.

**Làm sao tôi có thể cập nhật tất cả tiêu đề hoặc chú thích trên toàn bộ bản trình bày mà không phải lặp qua từng slide?**

Chỉnh sửa trình giữ chỗ tương ứng trên layout hoặc master. Các slide dựa trên những layout/master đó sẽ tự động kế thừa thay đổi.

**Làm thế nào tôi kiểm soát các trình giữ chỗ tiêu đề/chân trang tiêu chuẩn—ngày & giờ, số slide và văn bản chân trang?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi phù hợp (slide bình thường, layout, master, notes/handouts) để bật hoặc tắt các trình giữ chỗ đó và đặt nội dung của chúng.