---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng Python qua Java
linktitle: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/python-java/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến trình tự động của slide, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Chuyển đổi slide kiểm soát cách các slide xuất hiện trong một buổi chiếu slide. Với Aspose.Slides cho Python thông qua Java, bạn có thể chọn một hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc tiến hành bằng nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn cụ thể cho một hiệu ứng. Bài viết này sử dụng các ví dụ Python để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và truy cập vào cài đặt chuyển đổi của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Chuyển đổi bánh xe**

Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) để chọn Wheel từ [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Sau đó gọi [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) để truy cập cài đặt [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Phương thức [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) của nó điều khiển số lượng sector tia radial tiết lộ slide đích.

Ví dụ tạo hai cặp slide giống hệt nhau. Mỗi cặp bắt đầu bằng một slide màu đen và kết thúc bằng một hình chữ nhật màu vàng phủ toàn slide. Cả hai slide đích đều sử dụng cùng tốc độ chậm được đặt bằng [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) và cùng thời lượng rõ ràng 8.000 mili giây được đặt bằng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Chỉ số lượng spokes thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mở `wheel-transitions.pptx` trong PowerPoint và bắt đầu buổi chiếu slide. Tiếp tục từ slide 1 sang slide 2 để thấy một vòng quay theo chiều kim đồng hồ tiết lộ hình chữ nhật màu vàng. Sau đó tiếp tục từ slide 3 sang slide 4 để thấy tám sector tia radial tiết lộ cùng một hình chữ nhật đồng thời.

## **Mờ qua màu đen với chuyển đổi Reveal**

Đặt loại chuyển đổi của slide đích thành Reveal, sau đó gọi [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) trên cài đặt [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) của nó. Ví dụ tạo một slide nguồn màu xanh mòng biển và một slide đích màu san hô, rồi sao chép cả hai. Mỗi cặp sử dụng cùng chuyển đổi Reveal kéo dài hai giây. Chỉ cặp thứ hai mờ qua màu đen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mở `reveal-transitions.pptx` trong PowerPoint và bắt đầu buổi chiếu slide. Tiếp tục từ slide 1 sang slide 2 để thấy màu xanh mòng biển mờ trực tiếp vào màu san hô. Sau đó tiến tới slide 3 và slide 4. Màn hình tạm thời tối lại gần màu đen trước khi slide màu san hô xuất hiện. Cả hai slide vẫn giữ màu nền gốc của chúng.

Các hàng bên dưới hiển thị các khung hình từ PowerPoint mỗi nửa giây một lần. So sánh khung hình ở giữa mỗi hàng để thấy hiệu ứng.

![Phát lại PowerPoint với mờ qua màu đen bị tắt (trên) và bật (dưới). Chỉ hàng dưới cùng đi qua gần màu đen.](reveal-through-black.png)

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một nhấp chuột có tiến hành buổi chiếu slide hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật tiến hành tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) xác định độ trễ trước khi tiến hành tự động, tính bằng mili giây.

Bật cả tiến hành bằng nhấp chuột và bằng thời gian để cho phép người xem di chuyển bằng một cú nhấp chuột hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `False` tới [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm buổi chiếu slide tiến lên; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến hành tự động sau 3, 5 và 7 giây, tương ứng. Nhấp chuột cũng có thể tiến hành các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Để kiểm tra xem tiến hành theo thời gian có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ lưu trữ một mình không cho biết bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật, và tắt tiến hành tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide cung cấp các cài đặt này thông qua [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động tiến tới, tính bằng mili giây. Gửi `True` tới [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một danh mục tốc độ được định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Nó được sử dụng khi không có thời lượng chính xác được chỉ định. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) kiểm soát chỉ hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến hành tự động riêng biệt. Khi không có thời lượng rõ ràng nào được đặt, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển đổi 750 ms và cài đặt tự động tiến tới 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung cung cấp cho mỗi slide một chuyển đổi Fade kéo dài 750 ms và riêng biệt bật tiến hành tự động sau 5 000 ms. Thời lượng chuyển đổi kiểm soát hiệu ứng; tiến hành kiểm soát thời điểm rời slide. Các thanh này là cài đặt sơ đồ, không phải một dòng thời gian tổng hợp đo lường.* 
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), và cho mỗi chuyển đổi thời lượng 750 mili giây. Nó riêng biệt bật tiến hành tự động sau 5 000 ms và tắt tiến hành bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Cấu hình tiến trình tự động độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Đặt thời lượng khác nhau cho từng slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho phần giới thiệu. Ví dụ này đặt 500 ms cho slide đầu tiên và 1 200 ms cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Phối hợp chuyển đổi với đầu ra Animation**

Khi chuẩn bị một [animated GIF](/slides/vi/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/python-java/export-to-html5/), hoặc [video](/slides/vi/python-java/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng một pha trộn fade 600 ms giữa các cảnh, và điều chỉnh độ trễ tiến hành của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung đầu ra với thời lượng hiệu ứng: 600 ms tương đương 18 khung tại 30 khung mỗi giây. Trong HTML5, bật chuyển đổi động trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) trước khi sửa đổi chuyển đổi để xác định liệu giá trị rõ ràng có được lưu không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng nào được đặt; một giá trị không âm chỉ định thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát tính toán: Aspose.Slides sử dụng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Chuyển đổi Morph**

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng chuyển động giữa trạng thái gốc và trạng thái đã chỉnh sửa.

Ví dụ sau tạo một slide có một hình chữ nhật chứa văn bản, sao chép slide đó, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Các loại chuyển đổi Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) coi mỗi hình dạng như một đối tượng nguyên vẹn.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Giá trị sau đó là một thể hiện của lớp [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) của nó chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt ảnh Morph dựa trên từ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn có sẵn phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng lớp phù hợp từ [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của một chuyển đổi slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) đã định sẵn—Slow, Medium hoặc Fast—đủ và không cần đặt thời lượng rõ ràng. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ tiến hành tự động.

**Tôi có thể gắn âm thanh vào một chuyển đổi và lặp lại nó không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), truyền `StartSound` từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) tới [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) với `True`. Âm thanh sẽ lặp lại cho đến khi có sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Duyệt qua tập hợp [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để giữ hành vi nhất quán trên các slide.

**Làm thế nào để kiểm tra chuyển đổi nào hiện đang được thiết lập trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.