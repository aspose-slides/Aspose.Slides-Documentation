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
description: "Chuyển đổi các bản trình chiếu PowerPoint thành hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho .NET, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang hình ảnh PNG bằng Aspose.Slides. Nó cho thấy cách tải các tệp trình chiếu ở các định dạng như PPT, PPTX và ODP, render các slide thành hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các hình ảnh PNG được tạo bằng cách đặt giá trị tỉ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/properties/slides) dưới giao diện [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide).
3. Sử dụng phương thức [ISlide.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) để lấy ảnh thu nhỏ cho mỗi slide.
4. Sử dụng phương thức [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.ipresentation/save/methods/5) để lưu ảnh thu nhỏ slide ở định dạng PNG.

Đoạn mã C# này cho bạn thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PNG. Đối tượng Presentation có thể tải PPT, PPTX, ODP, v.v., sau đó mỗi slide trong đối tượng Presentation được chuyển đổi sang định dạng PNG hoặc các định dạng hình ảnh khác.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn có các tệp PNG với một tỉ lệ nhất định, bạn có thể đặt giá trị cho `desiredX` và `desiredY`, những giá trị này xác định kích thước của ảnh thu nhỏ kết quả.

Đoạn mã C# này minh họa hoạt động đã mô tả:

```c#
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

Nếu bạn muốn có các tệp PNG với kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mong muốn cho `imageSize`.

Đoạn mã này cho bạn thấy cách chuyển đổi PowerPoint sang PNG trong khi chỉ định kích thước cho các hình ảnh:

```c#
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

## **FAQ**

**Làm thế nào để tôi chỉ xuất một hình dạng cụ thể (ví dụ: biểu đồ hoặc hình ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo ảnh thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/net/create-shape-thumbnails/); bạn có thể render một hình dạng thành ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có, nhưng [không chia sẻ](/slides/vi/net/multithreading/) một thể hiện Presentation duy nhất giữa các luồng. Sử dụng một thể hiện riêng cho mỗi luồng hoặc tiến trình.

**Những hạn chế của phiên bản dùng thử khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/net/licensing/) cho đến khi có giấy phép.