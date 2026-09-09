---
title: Quản lý buổi chiếu slide trong Python qua Java
linktitle: Trình chiếu
type: docs
weight: 90
url: /vi/python-java/manage-slide-show/
keywords:
- loại trình chiếu
- trình chiếu do người thuyết trình
- trình chiếu do cá nhân
- trình chiếu tại kiosk
- tùy chọn trình chiếu
- vòng lặp liên tục
- trình chiếu không có lời thoại
- trình chiếu không có hoạt ảnh
- màu bút
- trình chiếu slide
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
description: "Tìm hiểu cách quản lý buổi chiếu slide trong Aspose.Slides cho Python qua Java. Kiểm soát chuyển đổi slide, thời gian và hơn thế nữa trên các định dạng PPT, PPTX và ODP một cách dễ dàng."
---
## **Giới thiệu**

Các tùy chọn **Set Up Show** của Microsoft PowerPoint cho phép bạn chọn loại buổi trình chiếu, bật vòng lặp, chọn các slide và kiểm soát cách các slide tiến lên. Với Aspose.Slides cho Python qua Java, bạn có thể cấu hình các tùy chọn này bằng mã và lưu chúng trong một tệp trình chiếu.

Phương thức [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlideShowSettings) trả về một đối tượng [SlideShowSettings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/) kiểm soát các tùy chọn này. Các ví dụ dưới đây yêu cầu Aspose.Slides cho Python qua Java và một môi trường chạy Java tương thích. Mỗi ví dụ sẽ khởi động JVM nếu cần và giải phóng đối tượng trình chiếu khi hoàn thành.

## **Chọn Loại Buổi Trình Chiếu**

Phương thức [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setSlideShowType) xác định loại buổi trình chiếu, có thể là một trong các lớp sau: [PresentedBySpeaker](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/vi/python-java/aspose.slides/browsedbyindividual/), hoặc [BrowsedAtKiosk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/browsedatkiosk/). Sử dụng phương thức này cho phép bạn điều chỉnh bản trình chiếu cho các kịch bản sử dụng khác nhau, chẳng hạn như kiosk tự động hoặc buổi trình chiếu thủ công.

Đoạn mã mẫu bên dưới tạo một bản trình chiếu mới và đặt loại buổi trình chiếu thành "Browsed by an individual" mà không hiển thị thanh cuộn.

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

Phương thức [SlideShowSettings.setLoop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setLoop) xác định liệu buổi trình chiếu có lặp lại liên tục cho đến khi người dùng dừng thủ công hay không. Điều này hữu ích cho các bản trình chiếu tự động cần chạy liên tục. Phương thức [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowNarration) xác định liệu các lời thuyết minh âm thanh có được phát trong buổi trình chiếu hay không. Nó hữu ích cho các bản trình chiếu tự động có hướng dẫn bằng giọng nói cho khán giả. Phương thức [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowAnimation) xác định liệu các hoạt ảnh được thêm vào các đối tượng slide có được phát hay không. Điều này giúp cung cấp hiệu ứng hình ảnh đầy đủ của bản trình chiếu.

Đoạn mã sau tạo một bản trình chiếu mới và lặp lại buổi trình chiếu.

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

## **Chọn Các Slide Để Trình Chiếu**

Phương thức [SlideShowSettings.setSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setSlides) cho phép bạn chọn một phạm vi các slide sẽ được hiển thị trong buổi trình chiếu. Điều này hữu ích khi bạn chỉ muốn trình chiếu một phần của bản trình chiếu thay vì tất cả các slide. Đoạn mã sau tạo một bản trình chiếu có chín slide và chọn các slide từ 2 đến 9. Phạm vi sử dụng số slide bắt đầu từ 1.

```python
import jpype
import asposeslides

if not jpapi.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Tạo chín slide để phạm vi được chọn tồn tại.
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

## **Kiểm Soát Tiến Độ Slide**

Phương thức [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setUseTimings) cho phép bạn bật hoặc tắt việc sử dụng thời gian định trước cho mỗi slide. Điều này hữu ích cho việc tự động hiển thị slide với thời gian hiển thị được xác định trước. Đoạn mã dưới đây tạo một bản trình chiếu mới và tắt việc sử dụng thời gian.

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

Phương thức [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) xác định liệu các điều khiển phương tiện (như phát, tạm dừng và dừng) có được hiển thị trong buổi trình chiếu khi nội dung đa phương tiện (ví dụ: video hoặc âm thanh) được phát hay không. Điều này hữu ích khi bạn muốn cung cấp cho người thuyết trình khả năng kiểm soát việc phát phương tiện trong suốt buổi trình chiếu.

Đoạn mã sau tạo một bản trình chiếu mới và bật hiển thị các điều khiển phương tiện.

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

## **Câu hỏi thường gặp**

**Tôi có thể lưu một bản trình chiếu sao cho nó mở trực tiếp ở chế độ trình chiếu không?**

Có. Lưu tệp dưới dạng PPSX hoặc PPSM; các định dạng này sẽ mở trực tiếp ở chế độ trình chiếu khi được mở trong PowerPoint. Trong Aspose.Slides, chọn định dạng lưu tương ứng [trong quá trình xuất](/slides/vi/python-java/save-presentation/).

**Tôi có thể loại trừ các slide riêng lẻ khỏi buổi trình chiếu mà không xóa chúng khỏi tệp không?**

Có. Đánh dấu một slide là [ẩn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#setHidden). Các slide ẩn vẫn tồn tại trong bản trình chiếu nhưng sẽ không được hiển thị trong buổi trình chiếu.

**Aspose.Slides có thể phát buổi trình chiếu hoặc điều khiển một buổi trình chiếu trực tiếp trên màn hình không?**

Không. Aspose.Slides chỉ thực hiện chỉnh sửa, phân tích và chuyển đổi các tệp trình chiếu; việc phát thực tế được thực hiện bởi ứng dụng xem như PowerPoint.