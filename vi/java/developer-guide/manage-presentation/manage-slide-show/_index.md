---
title: Quản lý trình chiếu trong Java
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/java/manage-slide-show/
keywords:
- loại trình chiếu
- trình bày bởi người thuyết trình
- duyệt bởi cá nhân
- duyệt tại kiosk
- tùy chọn trình chiếu
- vòng lặp liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hiệu ứng
- màu bút
- trình chiếu các slide
- trình chiếu tùy chỉnh
- tiến hành các slide
- thủ công
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho Java. Kiểm soát chuyển đổi slide, thời gian và nhiều tính năng khác trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Trong Microsoft PowerPoint, các cài đặt **Slide Show** là công cụ quan trọng để chuẩn bị và trình bày các bài thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bài thuyết trình sao cho phù hợp với các điều kiện và khán giả cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: trình bày bởi người thuyết trình, duyệt bởi cá nhân, hoặc duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị và sử dụng thời gian. Bước chuẩn bị này rất quan trọng để làm cho bài thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`getSlideShowSettings` là một phương thức của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) trả về một đối tượng loại [SlideShowSettings](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowsettings/), cho phép bạn quản lý các cài đặt slide show trong một bản thuyết trình PowerPoint. Trong bài viết này, chúng ta sẽ khám phá cách sử dụng phương thức này để cấu hình và điều khiển các khía cạnh khác nhau của cài đặt slide show. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.setSlideShowType` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/java/com.aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bài thuyết trình cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc thuyết trình thủ công.

Đoạn mã dưới đây tạo một bản thuyết trình mới và đặt loại trình chiếu thành “Browsed by an individual” mà không hiển thị thanh cuộn.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bật Các Tùy Chọn Trình Chiếu**

`SlideShowSettings.setLoop` xác định liệu slide show có nên lặp lại liên tục cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bài thuyết trình tự động cần chạy liên tục. `SlideShowSettings.setShowNarration` xác định liệu các lời thuyết minh bằng giọng nói có được phát trong slide show hay không. Nó hữu ích cho các bài thuyết trình tự động có hướng dẫn âm thanh cho khán giả. `SlideShowSettings.setShowAnimation` xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này giúp hiển thị đầy đủ hiệu ứng hình ảnh của bài thuyết trình.

Đoạn mã sau tạo một bản thuyết trình mới và lặp lại slide show.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Chọn Các Slide Để Hiển Thị**

Phương thức `SlideShowSettings.setSlides` cho phép bạn chọn một phạm vi slide sẽ được hiển thị trong quá trình thuyết trình. Điều này hữu ích khi bạn chỉ muốn hiển thị một phần của bài thuyết trình thay vì tất cả các slide. Đoạn mã dưới đây tạo một bản thuyết trình mới và đặt phạm vi slide hiển thị từ slide `2` đến `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Sử Dụng Thời Gian Tự Động**

Phương thức `SlideShowSettings.setUseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian đặt trước cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị các slide với thời lượng hiển thị đã định trước. Đoạn mã dưới đây tạo một bản thuyết trình mới và tắt việc sử dụng thời gian.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Hiển Thị Điều Khiển Media**

Phương thức `SlideShowSettings.setShowMediaControls` xác định liệu các điều khiển media (như phát, tạm dừng và dừng) có được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình quyền kiểm soát việc phát media trong quá trình thuyết trình.

Đoạn mã sau tạo một bản thuyết trình mới và bật hiển thị các điều khiển media.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Tôi có thể lưu một bản thuyết trình để nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ mở trực tiếp ở chế độ slide show khi được mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/java/save-presentation/).

**Tôi có thể loại bỏ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#setHidden-boolean-). Các slide ẩn vẫn tồn tại trong bản thuyết trình nhưng sẽ không được hiển thị trong slide show.

**Aspose.Slides có thể phát một slide show hoặc điều khiển một buổi thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉ chỉnh sửa, phân tích và chuyển đổi các tệp bản thuyết trình; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.