---
title: Quản lý Slide Show trong PHP
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/php-java/manage-slide-show/
keywords:
- loại trình chiếu
- được trình bày bởi người nói
- được duyệt bởi cá nhân
- được duyệt tại kiosk
- các tùy chọn trình chiếu
- lặp lại liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hoạt ảnh
- màu bút
- trình chiếu các slide
- trình chiếu tùy chỉnh
- tiến đến slide tiếp
- bằng tay
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho PHP thông qua Java. Kiểm soát chuyển đổi slide, thời gian và nhiều hơn nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Introduction**

Trong Microsoft PowerPoint, cài đặt **Slide Show** là công cụ quan trọng để chuẩn bị và trình bày các bài thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bài thuyết trình cho các điều kiện và khán giả cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: được trình bày bởi người nói, được duyệt bởi cá nhân, hoặc được duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị và sử dụng thời gian. Bước chuẩn bị này rất quan trọng để làm cho bài thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`getSlideShowSettings` là một phương thức của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trả về một đối tượng kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowsettings/), cho phép bạn quản lý cài đặt slide show trong một bài thuyết trình PowerPoint. Trong bài viết này, chúng ta sẽ khám phá cách sử dụng phương thức này để cấu hình và điều khiển các khía cạnh khác nhau của cài đặt slide show. 

## **Select Show Type**

`SlideShowSettings->setSlideShowType` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/php-java/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bài thuyết trình cho các kịch bản sử dụng khác nhau, như kiosk tự động hoặc trình chiếu thủ công.

Ví dụ mã bên dưới tạo một bài thuyết trình mới và đặt loại trình chiếu thành "Browsed by an individual" mà không hiển thị thanh cuộn.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Enable Show Options**

`SlideShowSettings->setLoop` quyết định liệu slide show có lặp lại trong vòng lặp cho đến khi người dùng dừng thủ công hay không. Điều này hữu ích cho các bài thuyết trình tự động cần chạy liên tục. `SlideShowSettings->setShowNarration` quyết định liệu lời thuyết minh âm thanh có được phát trong slide show hay không. Nó hữu ích cho các bài thuyết trình tự động có chứa hướng dẫn âm thanh cho khán giả. `SlideShowSettings->setShowAnimation` quyết định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này hữu ích để cung cấp hiệu ứng hình ảnh đầy đủ của bài thuyết trình.

Ví dụ mã sau tạo một bài thuyết trình mới và lặp lại slide show.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Select Slides to Show**

`SlideShowSettings->setSlides` cho phép bạn chọn một khoảng slide sẽ được hiển thị trong bài thuyết trình. Điều này hữu ích khi bạn chỉ cần hiển thị một phần của bài thuyết trình thay vì tất cả các slide. Ví dụ mã dưới đây tạo một bài thuyết trình mới và đặt phạm vi slide để hiển thị từ slide `2` đến `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Use Advance Slides**

`SlideShowSettings->setUseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian đã định trước cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị slide với thời lượng hiển thị đã được xác định trước. Ví dụ mã dưới đây tạo một bài thuyết trình mới và tắt việc sử dụng thời gian.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Show Media Controls**

`SlideShowSettings->setShowMediaControls` quyết định liệu các điều khiển media (như phát, tạm dừng và dừng) có được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình khả năng điều khiển phát lại media trong bài thuyết trình.

Ví dụ mã sau tạo một bài thuyết trình mới và bật các điều khiển media để hiển thị.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

**Có thể lưu một bài thuyết trình để nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ khởi chạy trực tiếp ở chế độ slide show khi mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/php-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

**Có thể loại bỏ các slide riêng lẻ khỏi trình chiếu mà không xóa chúng khỏi file không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/sethidden/). Các slide ẩn vẫn tồn tại trong bài thuyết trình nhưng không được hiển thị trong slide show.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

**Aspose.Slides có thể phát một slide show hoặc điều khiển một bài thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉnh sửa, phân tích và chuyển đổi các tệp bài thuyết trình; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.