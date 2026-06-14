---
title: Quản lý Slide Show trong Python
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/python-net/manage-slide-show/
keywords:
- loại trình chiếu
- trình bày bởi người nói
- duyệt bởi cá nhân
- duyệt tại kiosk
- tùy chọn trình chiếu
- lặp lại liên tục
- trình chiếu không lời thuyết minh
- trình chiếu không hoạt ảnh
- màu bút
- trình chiếu các slide
- trình chiếu tùy chỉnh
- tiến tới các slide
- thủ công
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho Python qua .NET. Kiểm soát chuyển đổi slide, thời gian và nhiều tính năng khác trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Trong Microsoft PowerPoint, các thiết lập **Slide Show** là công cụ quan trọng để chuẩn bị và trình bày các bài thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bài thuyết trình phù hợp với các điều kiện và khán giả nhất định, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: được trình bày bởi người nói, duyệt bởi cá nhân, hoặc duyệt tại kiosk), bật hoặc tắt việc lặp lại, chọn các slide cụ thể để hiển thị, và sử dụng thời gian. Bước này trong quá trình chuẩn bị rất quan trọng để làm cho bài thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`slide_show_settings` là một thuộc tính của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) , kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slideshowsettings/) , cho phép bạn quản lý các thiết lập slide show trong một bản trình bày PowerPoint. Trong bài viết này, chúng tôi sẽ khám phá cách sử dụng thuộc tính này để cấu hình và kiểm soát các khía cạnh khác nhau của thiết lập slide show. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.slide_show_type` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/python-net/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/python-net/aspose.slides/browsedatkiosk/). Sử dụng thuộc tính này cho phép bạn thích nghi bản trình bày cho các kịch bản sử dụng khác nhau, chẳng hạn kiosk tự động hoặc trình chiếu thủ công.

Đoạn mã mẫu bên dưới tạo một bản trình bày mới và đặt loại trình chiếu thành “Browsed by an individual” mà không hiển thị thanh cuộn.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bật Tùy Chọn Trình Chiếu**

`SlideShowSettings.loop` xác định liệu slide show có nên lặp lại trong vòng lặp cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bản trình chiếu tự động cần chạy liên tục. `SlideShowSettings.show_narration` xác định liệu lời thuyết minh âm thanh có nên được phát trong slide show hay không. Điều này hữu ích cho các bản trình chiếu tự động có hướng dẫn âm thanh cho khán giả. `SlideShowSettings.show_animation` xác định liệu các hoạt ảnh được thêm vào đối tượng slide có nên được phát hay không. Điều này hữu ích để cung cấp hiệu ứng hình ảnh đầy đủ của bản trình bày.

Đoạn mã sau tạo một bản trình bày mới và lặp lại slide show.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Chọn Các Slide Để Chiếu**

Thuộc tính `SlideShowSettings.slides` cho phép bạn chọn một phạm vi slide sẽ được hiển thị trong quá trình trình chiếu. Điều này hữu ích khi bạn chỉ muốn chiếu một phần của bản trình bày thay vì toàn bộ các slide. Đoạn mã mẫu dưới đây tạo một bản trình bày mới và đặt phạm vi slide để hiển thị từ slide `2` đến `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sử Dụng Slide Tiến Trước**

Thuộc tính `SlideShowSettings.use_timings` cho phép bạn bật hoặc tắt việc sử dụng thời gian được đặt sẵn cho mỗi slide. Điều này hữu ích để tự động hiển thị các slide với thời gian hiển thị đã định trước. Đoạn mã dưới đây tạo một bản trình bày mới và tắt việc sử dụng thời gian.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiển Thị Điều Khiển Phương Tiện**

Thuộc tính `SlideShowSettings.show_media_controls` xác định liệu các điều khiển đa phương tiện (như phát, tạm dừng và dừng) có nên được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người trình bày khả năng kiểm soát việc phát đa phương tiện trong bản trình bày.

Đoạn mã sau tạo một bản trình bày mới và bật hiển thị các điều khiển đa phương tiện.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể lưu một bản trình bày để nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ khởi động trực tiếp ở chế độ slide show khi mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/python-net/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/). Các slide ẩn vẫn còn trong bản trình bày nhưng không được hiển thị trong slide show.

**Aspose.Slides có thể phát một slide show hoặc điều khiển một buổi trình chiếu trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉnh sửa, phân tích và chuyển đổi các tệp bản trình bày; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.