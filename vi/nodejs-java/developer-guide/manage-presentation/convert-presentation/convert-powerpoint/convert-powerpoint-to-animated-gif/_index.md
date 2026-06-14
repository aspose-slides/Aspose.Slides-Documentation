---
title: Chuyển đổi Bản trình chiếu PowerPoint sang GIF Động trong JavaScript
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF động
- chuyển PowerPoint
- chuyển bản trình chiếu
- chuyển slide
- chuyển PPT
- chuyển PPTX
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
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX) sang GIF động trong JavaScript với Aspose.Slides cho Node.js thông qua Java. Nhanh, kết quả chất lượng cao."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bản trình chiếu PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide dưới dạng định dạng động nhẹ, được hỗ trợ rộng rãi và có thể nhúng trong các trang web, trình nhắn tin hoặc tài liệu. Bài viết này giải thích cách xuất bản trình chiếu sang GIF bằng cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển đổi thông qua [GifOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/gifoptions/).

## **Chuyển đổi Bản trình bày sang GIF Động bằng Cài đặt Mặc định**

Mã mẫu này trong JavaScript cho bạn thấy cách chuyển đổi bản trình chiếu sang GIF động bằng cài đặt tiêu chuẩn:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="TIP"  color="primary"  %}} 
Nếu bạn muốn tùy chỉnh các tham số cho GIF, bạn có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GifOptions). Xem mã mẫu dưới đây. 
{{% /alert %}} 

## **Chuyển đổi Bản trình bày sang GIF Động bằng Cài đặt Tùy chỉnh**

Mã mẫu này cho bạn thấy cách chuyển đổi bản trình chiếu sang GIF động bằng các cài đặt tùy chỉnh trong JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// kích thước của GIF được tạo
    gifOptions.setDefaultDelay(2000);// thời gian mỗi slide sẽ được hiển thị cho đến khi chuyển sang slide tiếp theo
    gifOptions.setTransitionFps(35);// tăng FPS để cải thiện chất lượng hoạt ảnh chuyển đổi
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Bạn có thể muốn khám phá công cụ chuyển đổi MIỄN PHÍ [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) do Aspose phát triển. 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Nếu các phông chữ được sử dụng trong bản trình chiếu không được cài đặt trên hệ thống thì sao?**

Cài đặt các phông chữ còn thiếu hoặc [định cấu hình phông chữ dự phòng](/slides/vi/nodejs-java/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác nhau. Đối với thương hiệu, luôn đảm bảo các kiểu chữ cần thiết đã có sẵn một cách rõ ràng.

**Tôi có thể đặt một watermark lên các khung GIF không?**

Có. [Thêm một đối tượng/logo bán trong suốt](/slides/vi/nodejs-java/watermark/) vào bản trình chiếu master hoặc vào các slide riêng lẻ trước khi xuất — watermark sẽ xuất hiện trên mọi khung.