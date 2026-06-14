---
title: Quản lý Trình chiếu trong .NET
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/net/manage-slide-show/
keywords:
- loại trình chiếu
- trình bày bởi người nói
- duyệt cá nhân
- duyệt tại kiosk
- tùy chọn trình chiếu
- vòng lặp liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hoạt ảnh
- màu bút
- hiển thị slide
- trình chiếu tùy chỉnh
- tiến slide
- bằng tay
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho .NET. Kiểm soát chuyển đổi slide, thời gian và hơn thế nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Trong Microsoft PowerPoint, cài đặt **Slide Show** là công cụ then chốt để chuẩn bị và trình chiếu các bài thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bài thuyết trình theo các điều kiện và khán giả cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: trình bày bởi người nói, duyệt cá nhân, hoặc duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị và sử dụng thời gian. Bước chuẩn bị này rất quan trọng để làm cho bài thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`SlideShowSettings` là thuộc tính của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slideshowsettings/), cho phép bạn quản lý các cài đặt trình chiếu trong một tệp PowerPoint. Trong bài viết này, chúng ta sẽ khám phá cách sử dụng thuộc tính này để cấu hình và kiểm soát các khía cạnh khác nhau của cài đặt trình chiếu. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.SlideShowType` xác định loại trình chiếu, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/net/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/net/aspose.slides/browsedatkiosk/). Sử dụng thuộc tính này cho phép bạn điều chỉnh bài thuyết trình cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc trình bày thủ công.

Ví dụ mã dưới đây tạo một bài thuyết trình mới và đặt loại trình chiếu là “Browsed by an individual” mà không hiển thị thanh cuộn.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Bật Tùy Chọn Trình Chiếu**

`SlideShowSettings.Loop` xác định liệu trình chiếu có lặp lại liên tục cho đến khi dừng bằng tay hay không. Điều này hữu ích cho các bài thuyết trình tự động cần chạy liên tục. `SlideShowSettings.ShowNarration` xác định liệu lời thuyết minh âm thanh có được phát trong quá trình trình chiếu hay không. Nó hữu ích cho các bài thuyết trình tự động có hướng dẫn âm thanh cho khán giả. `SlideShowSettings.ShowAnimation` xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này giúp cung cấp hiệu ứng hình ảnh đầy đủ của bài thuyết trình.

Ví dụ mã sau tạo một bài thuyết trình mới và lặp lại trình chiếu.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Chọn Các Slide Để Hiển Thị**

Thuộc tính `SlideShowSettings.Slides` cho phép bạn chọn một dải slide sẽ được hiển thị trong quá trình trình chiếu. Điều này hữu ích khi bạn chỉ muốn hiển thị một phần của bài thuyết trình thay vì tất cả các slide. Ví dụ mã dưới đây tạo một bài thuyết trình mới và đặt phạm vi slide hiển thị từ slide `2` đến `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Sử Dụng Tự Động Tiến Slide**

Thuộc tính `SlideShowSettings.UseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian đặt trước cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị slide với thời lượng hiển thị đã định trước. Ví dụ mã dưới đây tạo một bài thuyết trình mới và tắt việc sử dụng thời gian.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Hiển Thị Điều Khiển Phương Tiện**

Thuộc tính `SlideShowSettings.ShowMediaControls` xác định liệu các điều khiển phương tiện (như phát, tạm dừng và dừng) có được hiển thị trong quá trình trình chiếu khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình khả năng kiểm soát việc phát phương tiện trong suốt bài thuyết trình.

Ví dụ mã sau tạo một bài thuyết trình mới và bật hiển thị các điều khiển phương tiện.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Câu Hỏi Thường Gặp**

**Có thể lưu một bài thuyết trình sao cho nó mở trực tiếp ở chế độ trình chiếu không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ khởi chạy trực tiếp ở chế độ trình chiếu khi được mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [trong quá trình xuất](/slides/vi/net/save-presentation/).

**Có thể loại bỏ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/hidden/). Các slide ẩn vẫn tồn tại trong bài thuyết trình nhưng sẽ không được hiển thị trong quá trình trình chiếu.

**Aspose.Slides có thể phát một buổi trình chiếu hoặc điều khiển một bài thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉnh sửa, phân tích và chuyển đổi các tệp bài thuyết trình; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.