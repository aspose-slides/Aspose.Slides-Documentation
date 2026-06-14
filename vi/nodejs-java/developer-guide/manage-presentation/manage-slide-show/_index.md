---
title: Quản lý Slide Show trong JavaScript
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/nodejs-java/manage-slide-show/
keywords:
- kiểu trình chiếu
- được trình bày bởi người nói
- được duyệt bởi cá nhân
- được duyệt tại kiosk
- tùy chọn trình chiếu
- lặp liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hoạt ảnh
- màu bút
- trình chiếu slide
- trình chiếu tùy chỉnh
- tiến tới slide tiếp theo
- thủ công
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các trình chiếu trong JavaScript với Aspose.Slides cho Node.js. Kiểm soát chuyển đổi slide, thời gian và hơn thế nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Trong Microsoft PowerPoint, các cài đặt **Slide Show** là công cụ then chốt để chuẩn bị và trình bày các bài thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bài thuyết trình cho các điều kiện và khán giả cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: được trình bày bởi người nói, được duyệt bởi cá nhân, hoặc được duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị và sử dụng thời gian. Bước chuẩn bị này rất quan trọng để làm cho bài thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`getSlideShowSettings` là một phương thức của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) trả về một đối tượng kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowsettings/), cho phép bạn quản lý cài đặt slide show trong một bài thuyết trình PowerPoint. Trong bài viết này, chúng ta sẽ khám phá cách sử dụng phương thức này để cấu hình và kiểm soát các khía cạnh khác nhau của cài đặt slide show. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.setSlideShowType` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bài thuyết trình cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc thuyết trình thủ công. 

Ví dụ mã dưới đây tạo một bài thuyết trình mới và thiết lập loại trình chiếu thành “Browsed by an individual” mà không hiển thị thanh cuộn.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Bật Tùy Chọn Trình Chiếu**

`SlideShowSettings.setLoop` xác định liệu slide show có nên lặp lại trong vòng lặp cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bài thuyết trình tự động cần chạy liên tục. `SlideShowSettings.setShowNarration` xác định liệu các lời thuyết minh bằng giọng nói có được phát trong slide show hay không. Nó hữu ích cho các bài thuyết trình tự động có hướng dẫn âm thanh cho khán giả. `SlideShowSettings.setShowAnimation` xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này hữu ích để cung cấp hiệu ứng hình ảnh đầy đủ của bài thuyết trình. 

Ví dụ mã sau tạo một bài thuyết trình mới và lặp lại slide show.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Chọn Slide Để Hiển Thị**

`SlideShowSettings.setSlides` cho phép bạn chọn một phạm vi slide sẽ được hiển thị trong suốt bài thuyết trình. Điều này hữu ích khi bạn chỉ cần hiển thị một phần của bài thuyết trình thay vì tất cả các slide. Ví dụ mã sau tạo một bài thuyết trình mới và thiết lập phạm vi slide để hiển thị từ slide `2` đến `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Sử Dụng Trình Chiếu Tự Động**

`SlideShowSettings.setUseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian định sẵn cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị slide với thời gian hiển thị đã được xác định trước. Ví dụ mã dưới đây tạo một bài thuyết trình mới và tắt việc sử dụng thời gian.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Hiển Thị Điều Khiển Media**

`SlideShowSettings.setShowMediaControls` xác định liệu các điều khiển media (như phát, tạm dừng và dừng) có được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cho người thuyết trình kiểm soát việc phát lại media trong suốt bài thuyết trình. 

Ví dụ mã sau tạo một bài thuyết trình mới và bật hiển thị các điều khiển media.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu một bài thuyết trình để nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ khởi chạy trực tiếp ở chế độ slide show khi mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/nodejs-java/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/sethidden/). Các slide ẩn vẫn tồn tại trong bài thuyết trình nhưng không được hiển thị trong slide show.

**Aspose.Slides có thể phát một slide show hoặc điều khiển một bài thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉ chỉnh sửa, phân tích và chuyển đổi các tệp thuyết trình; việc phát lại thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.