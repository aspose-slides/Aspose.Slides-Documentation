---
title: Chuyển đổi bài thuyết trình PowerPoint sang GIF động trên Android
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
description: Dễ dàng chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX) sang GIF động với Aspose.Slides cho Android bằng Java. Kết quả nhanh, chất lượng cao.
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide dưới dạng định dạng động nhẹ, được hỗ trợ rộng rãi và có thể nhúng vào trang web, tin nhắn hoặc tài liệu. Bài viết này giải thích cách xuất một bài thuyết trình sang GIF bằng các cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển tiếp thông qua [GifOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/gifoptions/).

## **Chuyển đổi bài thuyết trình sang GIF động bằng cài đặt mặc định**

Đoạn mã mẫu này trong Java cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng các cài đặt tiêu chuẩn:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="TIP"  color="primary"  %}} 

Nếu bạn muốn tùy chỉnh các tham số cho GIF, bạn có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GifOptions). Xem đoạn mã mẫu bên dưới.

{{% /alert %}} 

## **Chuyển đổi bài thuyết trình sang GIF động bằng cài đặt tùy chỉnh**

Đoạn mã mẫu này cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng các cài đặt tùy chỉnh trong Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // kích thước của GIF kết quả  
	gifOptions.setDefaultDelay(2000); // thời gian mỗi slide sẽ được hiển thị cho đến khi chuyển sang slide tiếp theo
	gifOptions.setTransitionFps(35); // tăng FPS để cải thiện chất lượng hoạt ảnh chuyển tiếp
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Bạn có thể muốn xem bộ chuyển đổi [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) MIỄN PHÍ được phát triển bởi Aspose. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Nếu các phông chữ được sử dụng trong bài thuyết trình không được cài đặt trên hệ thống thì sao?**

Cài đặt các phông chữ còn thiếu hoặc [cấu hình phông chữ dự phòng](/slides/vi/androidjava/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác nhau. Đối với việc xây dựng thương hiệu, luôn đảm bảo các phông chữ cần thiết được cung cấp rõ ràng.

**Tôi có thể chồng một hình mờ lên các khung GIF không?**

Có. [Thêm một đối tượng/logo bán trong suốt](/slides/vi/androidjava/watermark/) vào slide chủ hoặc vào các slide riêng lẻ trước khi xuất — hình mờ sẽ xuất hiện trên mỗi khung.