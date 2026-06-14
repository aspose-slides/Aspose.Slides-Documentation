---  
title: Quản lý Trình chiếu trong C++  
linktitle: Trình chiếu  
type: docs  
weight: 90  
url: /vi/cpp/manage-slide-show/  
keywords:  
- loại trình chiếu  
- được trình bày bởi người nói  
- được duyệt bởi cá nhân  
- được duyệt tại kiosk  
- tùy chọn trình chiếu  
- lặp liên tục  
- trình chiếu không có lời thuyết minh  
- trình chiếu không có hoạt ảnh  
- màu bút  
- trình chiếu các slide  
- trình chiếu tùy chỉnh  
- tiến tới các slide  
- bằng tay  
- sử dụng thời gian  
- PowerPoint  
- OpenDocument  
- bản trình chiếu  
- C++  
- Aspose.Slides  
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho C++. Kiểm soát chuyển tiếp slide, thời gian và nhiều hơn nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."  
---
## **Giới thiệu**

Trong Microsoft PowerPoint, các thiết lập **Slide Show** là một công cụ quan trọng để chuẩn bị và trình bày các bản thuyết trình chuyên nghiệp. Một trong những tính năng quan trọng nhất trong phần này là **Set Up Show**, cho phép bạn tùy chỉnh bản thuyết trình theo các điều kiện và đối tượng cụ thể, đảm bảo tính linh hoạt và tiện lợi. Với tính năng này, bạn có thể chọn loại trình chiếu (ví dụ: được trình bày bởi người nói, được duyệt bởi cá nhân, hoặc được duyệt tại kiosk), bật hoặc tắt vòng lặp, chọn các slide cụ thể để hiển thị, và sử dụng thời gian hiển thị. Bước này trong quá trình chuẩn bị là rất quan trọng để làm cho bản thuyết trình của bạn hiệu quả và chuyên nghiệp hơn.

`get_SlideShowSettings` là một phương thức của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) trả về một đối tượng kiểu [SlideShowSettings](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slideshowsettings/), cho phép bạn quản lý các thiết lập slide show trong một bản trình chiếu PowerPoint. Trong bài viết này, chúng ta sẽ khám phá cách sử dụng phương thức này để cấu hình và kiểm soát các khía cạnh khác nhau của thiết lập slide show. 

## **Chọn Loại Trình Chiếu**

`SlideShowSettings.set_SlideShowType` xác định loại slide show, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/cpp/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/cpp/aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bản trình chiếu cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc thuyết trình thủ công.

Ví dụ mã dưới đây tạo một bản trình chiếu mới và đặt loại trình chiếu thành "Browsed by an individual" mà không hiển thị thanh cuộn.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bật Các Tùy Chọn Trình Chiếu**

`SlideShowSettings.set_Loop` xác định liệu slide show có lặp lại trong vòng lặp cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bản thuyết trình tự động cần chạy liên tục. `SlideShowSettings.set_ShowNarration` xác định liệu các lời thuyết minh âm thanh có được phát trong slide show hay không. Điều này hữu ích cho các bản thuyết trình tự động có hướng dẫn âm thanh cho khán giả. `SlideShowSettings.set_ShowAnimation` xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này hữu ích để cung cấp hiệu ứng hình ảnh đầy đủ của bản thuyết trình.

Ví dụ mã sau tạo một bản trình chiếu mới và lặp lại slide show.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Chọn Các Slide Để Trình Chiếu**

`SlideShowSettings.set_Slides` cho phép bạn chọn một phạm vi các slide sẽ được hiển thị trong suốt bản thuyết trình. Điều này hữu ích khi bạn chỉ cần trình chiếu một phần của bản thuyết trình chứ không phải tất cả các slide.

Ví dụ mã sau tạo một bản trình chiếu mới và đặt phạm vi slide để hiển thị từ slide `2` đến `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sử Dụng Tiến Độ Slide**

`SlideShowSettings.set_UseTimings` cho phép bạn bật hoặc tắt việc sử dụng thời gian cài sẵn cho mỗi slide. Điều này hữu ích để tự động hiển thị các slide với thời gian hiển thị được xác định trước.

Ví dụ mã dưới đây tạo một bản trình chiếu mới và tắt việc sử dụng thời gian.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Hiển Thị Điều Khiển Phương Tiện**

`SlideShowSettings.set_ShowMediaControls` xác định liệu các điều khiển phương tiện (như chạy, tạm dừng và dừng) có được hiển thị trong slide show khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình khả năng kiểm soát việc phát đa phương tiện trong suốt bản thuyết trình.

Ví dụ mã sau tạo một bản trình chiếu mới và bật việc hiển thị các điều khiển phương tiện.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Tôi có thể lưu một bản thuyết trình để nó mở trực tiếp ở chế độ slide show không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ mở trực tiếp ở chế độ slide show khi được mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [khi xuất](/slides/vi/cpp/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/set_hidden/). Các slide ẩn vẫn tồn tại trong bản thuyết trình nhưng sẽ không được hiển thị trong slide show.

**Aspose.Slides có thể phát một slide show hoặc điều khiển một bản thuyết trình trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉ chỉnh sửa, phân tích và chuyển đổi các tệp thuyết trình; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.