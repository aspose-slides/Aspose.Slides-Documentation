---
title: Quản lý trình chiếu trong Python qua Java
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/python-java/manage-slide-show/
keywords:
- kiểu trình chiếu
- trình chiếu bởi người thuyết trình
- trình chiếu bởi cá nhân
- trình chiếu tại kiosk
- tùy chọn trình chiếu
- lặp lại liên tục
- trình chiếu không có lời thuyết minh
- trình chiếu không có hoạt ảnh
- màu bút
- hiển thị slide
- trình chiếu tùy chỉnh
- tiến slide
- thủ công
- sử dụng thời gian
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý trình chiếu trong Aspose.Slides cho Python qua Java. Kiểm soát chuyển đổi slide, thời gian và hơn thế nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Các tùy chọn **Set Up Show** của Microsoft PowerPoint cho phép bạn chọn kiểu trình chiếu, bật vòng lặp, chọn các slide, và kiểm soát cách chuyển slide. Với Aspose.Slides cho Python thông qua Java, bạn có thể cấu hình các tùy chọn này bằng mã và lưu chúng vào tệp trình chiếu.

Phương thức [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlideShowSettings) trả về một đối tượng [SlideShowSettings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/) kiểm soát các tùy chọn này. Các ví dụ bên dưới yêu cầu Aspose.Slides cho Python thông qua Java và một môi trường chạy Java tương thích. Mỗi ví dụ sẽ khởi động JVM nếu cần và giải phóng bản trình chiếu khi kết thúc.

## **Chọn Kiểu Trình Chiếu**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setSlideShowType) xác định kiểu trình chiếu, có thể là một thể hiện của các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/python-java/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/browsedatkiosk/). Việc sử dụng phương thức này cho phép bạn điều chỉnh bản trình chiếu cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc trình chiếu thủ công.

Ví dụ mã dưới đây tạo một bản trình chiếu mới và đặt kiểu trình chiếu thành "Browsed by an individual" mà không hiển thị thanh cuộn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bật Các Tùy Chọn Trình Chiếu**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setLoop) xác định liệu trình chiếu có nên lặp lại liên tục cho đến khi dừng thủ công hay không. Điều này hữu ích cho các bản trình chiếu tự động cần chạy liên tục. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowNarration) xác định liệu lời thuyết minh âm thanh có được phát trong trình chiếu hay không. Điều này hữu ích cho các bản trình chiếu tự động có hướng dẫn bằng giọng nói cho khán giả. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowAnimation) xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này hữu ích để cung cấp hiệu ứng hình ảnh đầy đủ của bản trình chiếu.

Ví dụ mã sau tạo một bản trình chiếu mới và lặp lại trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chọn Các Slide Để Hiển Thị**

Phương thức [SlideShowSettings.setSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setSlides) cho phép bạn chọn một dải slide để hiển thị trong bản trình chiếu. Điều này hữu ích khi bạn chỉ cần hiển thị một phần của bản trình chiếu thay vì tất cả các slide. Ví dụ mã dưới đây tạo một bản trình chiếu gồm chín slide và chọn các slide từ 2 đến 9. Dải này sử dụng số slide bắt đầu từ 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Tạo chín slide để phạm vi đã chọn tồn tại.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm Soát Việc Tiến Slide**

Phương thức [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setUseTimings) cho phép bạn bật hoặc tắt việc sử dụng thời gian cài đặt sẵn cho mỗi slide. Điều này hữu ích để tự động hiển thị slide với thời gian hiển thị đã định sẵn. Ví dụ mã dưới đây tạo một bản trình chiếu mới và tắt việc sử dụng thời gian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hiển Thị Điều Khiển Phương Tiện**

Phương thức [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) xác định liệu các điều khiển đa phương tiện (như phát, tạm dừng và dừng) có được hiển thị trong trình chiếu khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình quyền kiểm soát việc phát phương tiện trong bản trình chiếu.

Ví dụ mã sau tạo một bản trình chiếu mới và bật hiển thị các điều khiển đa phương tiện.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể lưu một bản trình chiếu để nó mở trực tiếp ở chế độ trình chiếu không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ khởi chạy trực tiếp ở chế độ trình chiếu khi mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [during export](/slides/vi/python-java/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [hidden](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#setHidden). Các slide ẩn vẫn tồn tại trong bản trình chiếu nhưng không được hiển thị trong trình chiếu.

**Aspose.Slides có thể phát một trình chiếu hoặc điều khiển một bản trình chiếu trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉ chỉnh sửa, phân tích và chuyển đổi tệp bản trình chiếu; việc phát thực tế được thực hiện bởi một ứng dụng xem như PowerPoint.