---
title: Chuyển đổi Bài thuyết trình PowerPoint sang GIF động trên Android
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- GIF động
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang GIF
- bài thuyết trình sang GIF
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Dễ dàng chuyển đổi bài thuyết trình PowerPoint (PPT, PPTX) sang GIF động với Aspose.Slides cho Android bằng Java. Kết quả nhanh, chất lượng cao."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide dưới dạng nhẹ, được hỗ trợ rộng rãi, có thể nhúng vào trang web, trình nhắn tin hoặc tài liệu. Bài viết này giải thích cách xuất một bài thuyết trình sang GIF bằng cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển đổi thông qua [GifOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/gifoptions/).

## **Chuyển đổi bài thuyết trình sang GIF động bằng Cài đặt Mặc định**

Đoạn mã mẫu này bằng Java cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng cài đặt tiêu chuẩn:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="TIP"  color="info"  %}} 
Nếu bạn muốn tùy chỉnh các tham số cho GIF, bạn có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GifOptions). Xem đoạn mã mẫu bên dưới. 
{{% /alert %}} 

## **Chuyển đổi bài thuyết trình sang GIF động bằng Cài đặt Tùy chỉnh**

Đoạn mã mẫu này cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng cài đặt tùy chỉnh trong Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // kích thước của GIF tạo ra  
	gifOptions.setDefaultDelay(2000); // thời gian mỗi slide sẽ được hiển thị cho đến khi chuyển sang slide tiếp theo
	gifOptions.setTransitionFps(35); // tăng FPS để cải thiện chất lượng hoạt ảnh chuyển tiếp

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Bạn có thể muốn xem bộ chuyển đổi MIỄN PHÍ [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) do Aspose phát triển. 
{{% /alert %}}

## **Câu hỏi thường gặp**

### Nếu các phông chữ được sử dụng trong bài thuyết trình không được cài đặt trên hệ thống thì sao?

Cài đặt các phông chữ còn thiếu hoặc [cấu hình phông dự phòng](/slides/vi/androidjava/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác nhau. Đối với thương hiệu, luôn đảm bảo các phông chữ cần thiết có sẵn một cách rõ ràng.

### Tôi có thể ghép logo nước lên các khung GIF không?

Có. [Thêm đối tượng/logo bán trong suốt](/slides/vi/androidjava/watermark/) vào slide chủ hoặc vào các slide riêng lẻ trước khi xuất — logo nước sẽ xuất hiện trên mọi khung.