---
title: Chuyển đổi bản trình chiếu PowerPoint sang GIF động trong .NET
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF động
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang GIF
- bản trình chiếu sang GIF
- slide sang GIF
- PPT sang GIF
- PPTX sang GIF
- lưu PPT dưới dạng GIF
- lưu PPTX dưới dạng GIF
- xuất PPT dưới dạng GIF
- xuất PPTX dưới dạng GIF
- cài đặt mặc định
- cài đặt tùy chỉnh
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng chuyển đổi bản trình chiếu PowerPoint (PPT, PPTX) sang GIF động với Aspose.Slides cho .NET. Kết quả nhanh chóng, chất lượng cao."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bản trình chiếu PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide dưới dạng nhẹ, được hỗ trợ rộng rãi và có thể nhúng vào trang web, ứng dụng nhắn tin hoặc tài liệu. Bài viết này giải thích cách xuất bản trình chiếu sang GIF bằng cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển tiếp thông qua [GifOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/gifoptions/).

## **Chuyển đổi Bản trình chiếu sang GIF Động bằng Cài đặt Mặc định**

Mã mẫu này trong C# cho bạn thấy cách chuyển đổi một bản trình chiếu sang GIF động bằng các cài đặt tiêu chuẩn:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="TIP"  color="info"  %}} 

Nếu bạn muốn tùy chỉnh các tham số cho GIF, bạn có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/gifoptions). Xem mã mẫu bên dưới. 

{{% /alert %}} 

## **Chuyển đổi Bản trình chiếu sang GIF Động bằng Cài đặt Tùy chỉnh**

Mã mẫu này cho bạn thấy cách chuyển đổi một bản trình chiếu sang GIF động bằng các cài đặt tùy chỉnh trong C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // kích thước của GIF đã tạo  
        DefaultDelay = 2000, // thời lượng mỗi slide sẽ được hiển thị cho đến khi chuyển sang slide tiếp theo
        TransitionFps = 35 // tăng FPS để cải thiện chất lượng hoạt ảnh chuyển đổi
    });
}
```

{{% alert title="Info" color="info" %}}

Bạn có thể muốn khám phá công cụ chuyển đổi MIỄN PHÍ [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) được phát triển bởi Aspose. 

{{% /alert %}}

## **Câu hỏi thường gặp**

### Nếu các phông chữ được sử dụng trong bản trình chiếu không được cài đặt trên hệ thống thì sao?

Cài đặt các phông chữ thiếu hoặc [configure fallback fonts](/slides/vi/net/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác nhau. Đối với thương hiệu, luôn đảm bảo các phông chữ cần thiết đã có sẵn một cách rõ ràng.

### Tôi có thể đặt một watermark lên các khung GIF không?

Có. [Add a semi-transparent object/logo](/slides/vi/net/watermark/) vào slide chủ hoặc vào các slide riêng lẻ trước khi xuất — watermark sẽ xuất hiện trên mỗi khung.