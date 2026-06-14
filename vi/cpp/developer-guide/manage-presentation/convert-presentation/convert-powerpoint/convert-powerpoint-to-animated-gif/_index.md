---
title: Chuyển đổi Bài thuyết trình PowerPoint sang GIF Động trong C++
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "Dễ dàng chuyển đổi bài thuyết trình PowerPoint (PPT, PPTX) sang GIF động bằng Aspose.Slides cho C++. Kết quả nhanh, chất lượng cao."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide ở định dạng nhẹ, hỗ trợ rộng rãi và có thể nhúng vào các trang web, tin nhắn hoặc tài liệu. Bài viết này giải thích cách xuất bài thuyết trình sang GIF bằng cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển tiếp thông qua [GifOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/gifoptions/).

## **Chuyển đổi Bài thuyết trình sang GIF Động bằng Cài đặt Mặc định**

Mã mẫu này bằng C++ cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng cài đặt tiêu chuẩn:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="MẸO"  color="primary"  %}} 

Nếu bạn muốn tùy chỉnh các tham số cho GIF, có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.gif_options). Xem mã mẫu dưới đây. 

{{% /alert %}} 

## **Chuyển đổi Bài thuyết trình sang GIF Động bằng Cài đặt Tùy chỉnh**

Mã mẫu này cho bạn thấy cách chuyển đổi một bài thuyết trình sang GIF động bằng cài đặt tùy chỉnh trong C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// kích thước của GIF tạo ra
gifOptions->set_FrameSize(Size(960, 720));
// thời gian mỗi slide sẽ được hiển thị cho đến khi chuyển sang slide tiếp theo
gifOptions->set_DefaultDelay(2000);
// tăng FPS để cải thiện chất lượng hoạt ảnh chuyển tiếp
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Thông tin" color="info" %}}

Bạn có thể muốn thử một công cụ chuyển đổi **MIỄN PHÍ** [Chuyển đổi Văn bản sang GIF](https://products.aspose.app/slides/vi/text-to-gif) được phát triển bởi Aspose. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Nếu các phông chữ được sử dụng trong bài thuyết trình không được cài đặt trên hệ thống thì sao?**

Cài đặt các phông chữ thiếu hoặc [cấu hình phông chữ dự phòng](/slides/vi/cpp/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác. Đối với thương hiệu, luôn đảm bảo các phông chữ cần thiết được cung cấp rõ ràng.

**Tôi có thể đặt một watermark lên các khung GIF không?**

Có. [Thêm đối tượng/logo bán trong suốt](/slides/vi/cpp/watermark/) vào slide chủ hoặc vào từng slide trước khi xuất — watermark sẽ xuất hiện trên mọi khung.