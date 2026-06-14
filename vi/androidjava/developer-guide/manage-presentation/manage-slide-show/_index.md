---
title: Quản lý Slide Show trên Android
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/androidjava/manage-slide-show/
keywords:
- loại trình chiếu
- được trình bày bởi người nói
- được duyệt bởi cá nhân
- được duyệt tại kiosk
- tùy chọn trình chiếu
- vòng lặp liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hoạt ảnh
- màu bút
- trình chiếu slide
- trình chiếu tùy chỉnh
- tiến tới slide
- bằng tay
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho Android bằng Java. Kiểm soát chuyển đổi slide, thời gian và nhiều tính năng khác trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Trong Microsoft PowerPoint, cài đặt **Slide Show** là công cụ quan trọng để chuẩn bị và trình bày các bản thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bản thuyết trình phù hợp với các điều kiện và khán giả cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: được trình bày bởi người nói, được duyệt bởi cá nhân, hoặc được duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị, và sử dụng thời gian. Bước chuẩn bị này rất quan trọng để làm cho bản thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`getSlideShowSettings` là một phương thức của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) trả về một đối tượng kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowsettings/), cho phép bạn quản lý các cài đặt slide show trong bản thuyết trình PowerPoint. Trong bài viết này, chúng tôi sẽ khám phá cách sử dụng phương thức này để cấu hình và kiểm soát các khía cạnh khác nhau của cài đặt slide show. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.setSlideShowType` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bản thuyết trình cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc trình bày thủ công.

Ví dụ mã dưới đây tạo một bản thuyết trình mới và đặt loại trình chiếu là “Browsed by an individual” mà không hiển thị thanh cuộn.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Kích Hoạt Tùy Chọn Trình Chiếu**

`SlideShowSettings.setLoop` xác định liệu slide show có nên lặp lại trong một vòng lặp cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bản thuyết trình tự động cần chạy liên tục. `SlideShowSettings.setShowNarration` xác định liệu các lời thuyết minh âm thanh có nên được phát trong slide show hay không. Nó hữu ích cho các bản thuyết trình tự động có chứa hướng dẫn âm thanh cho khán giả. `SlideShowSettings.setShowAnimation` xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có nên được phát hay không. Điều này hữu ích để cung cấp đầy đủ hiệu ứng hình ảnh của bản thuyết trình.

Ví dụ mã sau tạo một bản thuyết trình mới và lặp lại slide show.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Chọn Các Slide Để Trình Chiếu**

`SlideShowSettings.setSlides` cho phép bạn chọn một phạm vi các slide sẽ được trình chiếu trong bản thuyết trình. Điều này hữu ích khi bạn chỉ cần hiển thị một phần của bản thuyết trình thay vì tất cả các slide. Ví dụ mã dưới đây tạo một bản thuyết trình mới và đặt phạm vi slide để hiển thị từ slide `2` đến `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Sử Dụng Tiến Trình Tự Động**

`SlideShowSettings.setUseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian dừng được thiết lập trước cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị các slide với thời lượng hiển thị đã được xác định trước. Ví dụ mã dưới đây tạo một bản thuyết trình mới và tắt việc sử dụng thời gian dừng.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Hiển Thị Điều Khiển Media**

`SlideShowSettings.setShowMediaControls` xác định liệu các điều khiển media (như phát, tạm dừng và dừng) có nên được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình khả năng kiểm soát phát media trong suốt bản thuyết trình.

Ví dụ mã sau tạo một bản thuyết trình mới và bật hiển thị các điều khiển media.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản thuyết trình sao cho nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ mở trực tiếp ở chế độ slide show khi được mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/androidjava/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Các slide ẩn vẫn tồn tại trong bản thuyết trình nhưng không được hiển thị trong slide show.

**Aspose.Slides có thể phát một slide show hoặc điều khiển một bản thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉnh sửa, phân tích và chuyển đổi tệp bản thuyết trình; việc phát thực tế được xử lý bởi một ứng dụng xem như PowerPoint.