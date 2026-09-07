---
title: Chuyển đổi Bài thuyết trình PowerPoint sang GIF Động trong Python
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/python-java/convert-powerpoint-to-animated-gif/
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
- Python
- Java
- Aspose.Slides
description: "Dễ dàng chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX) sang GIF động với Aspose.Slides cho Python qua Java. Nhanh chóng, kết quả chất lượng cao."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn chuyển đổi các bài thuyết trình PowerPoint thành tệp GIF động chỉ với vài dòng mã. Điều này hữu ích cho việc chia sẻ nội dung slide trên các trang web, trình nhắn tin hoặc tài liệu. Bài viết này giải thích cách xuất một bài thuyết trình bằng cài đặt mặc định và cách tùy chỉnh kích thước khung, độ trễ slide và tốc độ khung chuyển tiếp thông qua [GifOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gifoptions/).

## **Chuyển đổi Bài thuyết trình sang GIF Động bằng Cài đặt Mặc định**

Ví dụ Python sau tải `pres.pptx` và lưu nó dưới dạng GIF động bằng các cài đặt tiêu chuẩn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Mẹo" %}}
Để tùy chỉnh đầu ra GIF, truyền một đối tượng [GifOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gifoptions/) khi lưu, như được minh họa bên dưới.
{{% /alert %}}

## **Chuyển đổi Bài thuyết trình sang GIF Động bằng Cài đặt Tùy chỉnh**

Sử dụng [setFrameSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gifoptions/#setFrameSize) để chỉ định kích thước đầu ra tính bằng pixel, [setDefaultDelay](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gifoptions/#setDefaultDelay) để đặt độ trễ slide mặc định tính bằng mili giây, và [setTransitionFps](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gifoptions/#setTransitionFps) để điều khiển tốc độ khung chuyển tiếp.

Ví dụ sau xuất một GIF kích thước 960 × 720 với độ trễ slide mặc định là hai giây và 35 khung hình mỗi giây cho các chuyển tiếp. Độ trễ mặc định được áp dụng khi thời gian chuyển tiếp của slide không được đặt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Lưu ý" %}}
Bạn cũng có thể thử công cụ chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Nếu các phông chữ được sử dụng trong bài thuyết trình không có sẵn trên hệ thống thì sao?**

Cài đặt các phông chữ thiếu hoặc [cấu hình phông chữ dự phòng](/slides/vi/python-java/powerpoint-fonts/). Thay thế phông chữ có thể làm thay đổi diện mạo của GIF đã xuất. Việc cung cấp các phông chữ gốc là cần thiết để giữ nguyên thiết kế của bài thuyết trình.

**Tôi có thể chèn watermark lên các khung GIF không?**

Có. [Thêm một đối tượng hoặc logo bán trong suốt](/slides/vi/python-java/watermark/) vào các master slide liên quan hoặc vào từng slide riêng lẻ trước khi xuất. Watermark sẽ trở thành một phần của nội dung slide được render.