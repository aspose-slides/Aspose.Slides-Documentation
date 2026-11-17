---
title: Quản lý chuyển tiếp slide trong bản trình chiếu bằng Python qua Java
linktitle: Chuyển tiếp slide
type: docs
weight: 80
url: /vi/python-java/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- áp dụng chuyển tiếp slide
- chuyển tiếp slide nâng cao
- chuyển tiếp morph
- loại chuyển tiếp
- hiệu ứng chuyển tiếp
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Áp dụng chuyển tiếp slide, cấu hình chuyển tiếp slide tự động, và tùy chỉnh Morph cùng các hiệu ứng chuyển tiếp khác với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Hiệu ứng chuyển tiếp slide kiểm soát cách các slide xuất hiện trong một buổi trình chiếu. Với Aspose.Slides cho Python thông qua Java, bạn có thể chọn một hiệu ứng chuyển tiếp cho từng slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho mỗi hiệu ứng. Bài viết này sử dụng các ví dụ Python để áp dụng chuyển tiếp, đặt thời lượng chuyển tiếp chính xác, quản lý thời gian slide, và tạo một chuyển tiếp Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các thiết lập vào tệp PPTX.

## **Thêm chuyển tiếp slide**

Để áp dụng một chuyển tiếp, tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và truy cập các thiết lập chuyển tiếp của slide qua [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ dưới đây áp dụng chuyển tiếp Circle cho slide đầu tiên và chuyển tiếp Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

## **Chuyển tiếp Wheel**

Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) để chọn Wheel từ [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Sau đó gọi [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) để truy cập các thiết lập [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Phương thức [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) điều khiển số sector tia kéo để lộ slide đích.

Ví dụ tạo hai cặp slide giống hệt nhau. Mỗi cặp bắt đầu bằng một slide đen và kết thúc bằng một hình chữ nhật vàng phủ toàn bộ slide. Cả hai slide đích đều sử dụng cùng tốc độ chậm được đặt bằng [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) và cùng thời lượng rõ ràng là 8.000 mil giây được đặt bằng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Chỉ số lượng spoke thay đổi.

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

Mở `wheel-transitions.pptx` trong PowerPoint và bắt đầu buổi trình chiếu. Tiến tới slide 2 từ slide 1 để thấy một vòng quay theo chiều kim đồng hồ lộ ra hình chữ nhật vàng. Sau đó tiến tới slide 4 từ slide 3 để thấy tám sector tia cùng lúc lộ ra cùng một hình chữ nhật.

## **Thêm chuyển tiếp slide nâng cao**

Bạn có thể cấu hình thời gian một slide ở lại trên màn hình và việc nhấp chuột có chuyển sang slide tiếp theo hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật chuyển tiếp tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi tự động chuyển tiếp, tính bằng mil giây.

Bật cả chuyển tiếp bằng nhấp chuột và thời gian để người xem có thể chuyển tiếp bằng nhấp chuột hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `False` vào [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm buổi trình chiếu chuyển sang slide tiếp theo; nó không đặt thời lượng của hiệu ứng chuyển tiếp trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật chuyển tiếp tự động sau 3, 5 và 7 giây, tương ứng. Người xem cũng có thể chuyển tiếp các slide này bằng nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem chuyển tiếp tự động có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ được lưu không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật chuyển tiếp bằng nhấp chuột cho các slide đó và lưu lại các thiết lập đã cập nhật.

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

## **Kiểm soát thời gian chuyển tiếp một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển tiếp, tính bằng mil giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide cung cấp các thiết lập này thông qua [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của hiệu ứng chuyển tiếp, tính bằng mil giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng mil giây. Truyền `True` vào [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một nhóm tốc độ định sẵn từ liệt kê [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được sử dụng khi không có thời lượng cụ thể được chỉ định. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) chỉ kiểm soát hiệu ứng chuyển tiếp; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tự động chuyển tiếp riêng biệt. Khi không đặt thời lượng rõ ràng, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển tiếp 750 ms và thiết lập tự động chuyển tiếp 5.000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung này đặt mỗi slide có chuyển tiếp Fade 750 ms và đồng thời bật tự động chuyển tiếp sau 5.000 ms. Thời lượng chuyển tiếp chỉ kiểm soát hiệu ứng; chuyển tiếp tự động kiểm soát thời điểm rời slide. Các thanh này là thiết lập sơ đồ, không phải một dòng thời gian được đo lường kết hợp.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và cùng thời lượng cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), và đặt thời lượng mỗi chuyển tiếp là 750 mil giây. Nó bật tự động chuyển tiếp sau 5.000 mil giây và tắt chuyển tiếp bằng nhấp chuột, rồi lưu kết quả dưới dạng PPTX.

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

        # Cấu hình tự động chuyển tiếp độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Đặt thời lượng khác nhau cho từng slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển tiếp ngắn cho slide tiêu đề và chuyển tiếp dài hơn cho slide giới thiệu phần. Ví dụ này đặt 500 mil giây cho slide đầu tiên và 1.200 mil giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển tiếp với xuất ra dạng hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/python-java/export-to-html5/), hoặc [video](/slides/vi/python-java/convert-powerpoint-to-video/), hãy đặt thời lượng chuyển tiếp chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 mil giây giữa các cảnh và điều chỉnh độ trễ chuyển tiếp của mỗi slide riêng để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, hãy đồng bộ tốc độ khung hình xuất ra với thời lượng hiệu ứng: 600 mil giây tương đương 18 khung hình ở 30 fps. Trong HTML5, bật chuyển tiếp hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển tiếp hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) trước khi thay đổi chuyển tiếp để xác định liệu có giá trị rõ ràng được lưu hay không. Giá trị `-1` nghĩa là không có thời lượng cụ thể được đặt; giá trị không âm chỉ thời lượng đã lưu tính bằng mil giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides dùng loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển tiếp có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các thiết lập gốc trước.

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

## **Chuyển tiếp Morph**

Chuyển tiếp Morph hoạt hình các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo một hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển tiếp Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng chuyển động giữa trạng thái gốc và trạng thái đã sửa đổi.

Ví dụ sau tạo một slide có một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

## **Các loại chuyển tiếp Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt hình nội dung:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) hoạt hình văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) hoạt hình văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Giá trị trả về sẽ là một thể hiện của lớp [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) của nó chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt hình Morph dựa trên từ.

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

## **Đặt các hiệu ứng chuyển tiếp**

Một số chuyển tiếp cung cấp các tùy chọn phụ, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn có sẵn phụ thuộc vào chuyển tiếp được chọn bằng [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng lớp thích hợp từ [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển tiếp Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) để chuyển tiếp bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát của một chuyển tiếp slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mil giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục tốc độ định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium hoặc Fast — là đủ và không có thời lượng cụ thể được đặt. Các thiết lập này kiểm soát hiệu ứng chuyển tiếp độc lập với độ trễ tự động chuyển tiếp.

**Tôi có thể gắn âm thanh vào chuyển tiếp và lặp lại không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), truyền `StartSound` từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) với `True`. Âm thanh sẽ lặp lại cho đến khi có sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển tiếp cho mọi slide là gì?**

Duyệt qua tập hợp [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để giữ hành vi nhất quán trên các slide.

**Làm sao tôi kiểm tra chuyển tiếp hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` có nghĩa là không có hiệu ứng chuyển tiếp nào được áp dụng.