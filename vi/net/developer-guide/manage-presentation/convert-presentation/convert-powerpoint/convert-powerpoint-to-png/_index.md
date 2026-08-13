---
title: Chuyển đổi các slide PowerPoint sang PNG trong .NET
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/net/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint sang hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho .NET, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang hình ảnh PNG bằng Aspose.Slides. Nó cho thấy cách tải các tệp bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render các slide thành hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng minh họa cách tùy chỉnh hình ảnh PNG được tạo bằng cách đặt các giá trị tỷ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/properties/slides) dưới giao diện [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide).
3. Sử dụng phương thức [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) để render mỗi slide theo tỷ lệ bạn cần.
4. Sử dụng phương thức [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.ipresentation/save/methods/5) để lưu thumbnail của slide dưới định dạng PNG.

Đoạn mã C# này cho bạn thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PNG. Đối tượng Presentation có thể tải PPT, PPTX, ODP, v.v., sau đó mỗi slide trong đối tượng Presentation sẽ được chuyển đổi sang định dạng PNG hoặc các định dạng ảnh khác.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Lưu ý:** Các đối số tỷ lệ `1f, 1f` render mỗi slide ở kích thước đầy đủ, vì vậy một slide 720×540 pt tạo ra ảnh 720×540 px. Phiên bản không có tham số của [GetImage()](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) trả về một thumbnail xem trước nhỏ hơn nhiều. 
{{% /alert %}} 

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn có các tệp PNG ở một tỷ lệ nhất định, bạn có thể thiết lập các giá trị cho `desiredX` và `desiredY`, chúng xác định kích thước của thumbnail kết quả. 

Đoạn mã C# sau minh họa thao tác đã mô tả:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn có các tệp PNG ở một kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mà bạn muốn cho `imageSize`. 

Đoạn mã này cho bạn thấy cách chuyển đổi PowerPoint sang PNG đồng thời chỉ định kích thước cho các hình ảnh: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Câu hỏi thường gặp**

### Làm sao tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc hình ảnh) thay vì toàn bộ slide?

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/net/create-shape-thumbnails/); bạn có thể render một hình dạng thành ảnh PNG.

### Chuyển đổi song song có được hỗ trợ trên máy chủ không?

Có, nhưng [không chia sẻ](/slides/vi/net/multithreading/) một thể hiện Presentation duy nhất giữa các luồng. Hãy sử dụng một thể hiện riêng cho mỗi luồng hoặc quá trình.

### Những hạn chế của phiên bản dùng thử khi xuất sang PNG là gì?

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [những hạn chế khác](/slides/vi/net/licensing/) cho đến khi giấy phép được áp dụng.