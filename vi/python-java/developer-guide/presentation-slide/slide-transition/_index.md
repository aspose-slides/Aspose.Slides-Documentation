---
title: Quản lý chuyển đổi slide trong bài thuyết trình bằng Python qua Java
linktitle: Chuyển đổi slide
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
description: "Áp dụng chuyển đổi slide, cấu hình tự động chuyển tiếp slide, và tùy chỉnh Morph cùng các hiệu ứng chuyển đổi khác với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Các chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi chiếu slide. Với Aspose.Slides for Python via Java, bạn có thể chọn một hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ Python để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và truy cập cài đặt chuyển đổi của slide qua [getSlideShowTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

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

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có chuyển tiếp buổi chiếu hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật chuyển tiếp tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi chuyển tiếp tự động, tính bằng mili giây.

Kích hoạt cả chuyển tiếp bằng nhấp chuột và thời gian để người xem có thể chuyển sang bằng một cú nhấp hoặc đợi bộ đếm. Để chỉ dùng bộ đếm, truyền `False` cho [setAdvanceOnClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ điều khiển khi buổi chiếu chuyển tiếp; nó không xác định thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật chuyển tiếp tự động sau 3, 5 và 7 giây tương ứng. Các cú nhấp chuột cũng có thể chuyển tiếp các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem chuyển tiếp thời gian có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ đã lưu không có nghĩa là bộ đếm đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ đếm được bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật chuyển tiếp bằng nhấp chuột cho những slide đó và lưu lại cài đặt đã cập nhật.

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

Sử dụng [setDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide cung cấp các cài đặt này qua [SlideShowTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của hiệu ứng chuyển đổi, tính bằng mili giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng mili giây. Truyền `True` cho [setAdvanceAfter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ đếm này. |
| [setSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một mục tốc độ đã định nghĩa trước từ enum [TransitionSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được dùng khi không chỉ định thời lượng cụ thể. |

[setDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setDuration) chỉ điều khiển hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ chuyển tiếp tự động riêng biệt. Khi không có thời lượng rõ ràng, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Áp dụng cùng thời lượng cho mọi slide**

Để duy trì nhịp độ đồng nhất, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitiontype/), và đặt thời lượng mỗi chuyển đổi là 750 mili giây. Nó đồng thời bật chuyển tiếp tự động sau 5.000 mili giây và tắt chuyển tiếp bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

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

        # Cấu hình chuyển tiếp tự động độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho phần giới thiệu. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/python-java/export-to-html5/), hoặc [video](/slides/vi/python-java/convert-powerpoint-to-video/), hãy đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ chuyển tiếp của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở 30 khung hình mỗi giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getDuration) trước khi chỉnh sửa chuyển đổi để xác định liệu có giá trị rõ ràng được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng; một giá trị không âm chỉ thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính: Aspose.Slides dùng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

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

Chuyển đổi Morph hoạt hình các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo một hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp cho các đối tượng tương ứng khả năng hoạt hình giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ sau tạo một slide chứa một hình chữ nhật văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó nó chọn Morph từ enum [TransitionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

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

Enum [TransitionMorphType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt hình nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionmorphtype/#ByObject) coi mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionmorphtype/#ByWord) hoạt hình văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionmorphtype/#ByChar) hoạt hình văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getValue). Giá trị trả về sẽ là một thể hiện của lớp [MorphTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/morphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/morphtransition/#setMorphType) của nó chọn chế độ khớp.

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

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng lớp thích hợp từ [getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/vi/python-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionspeed/) đã định nghĩa trước—Slow, Medium, hoặc Fast—đủ và không có thời lượng rõ ràng được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ chuyển tiếp tự động.

**Tôi có thể đính kèm âm thanh vào một chuyển đổi và lặp lại nó không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setSound), truyền `StartSound` từ enum [TransitionSoundMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitionsoundmode/) cho [setSoundMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setSoundLoop) với `True`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Duyệt qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao tôi kiểm tra chuyển đổi hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/transitiontype/); `None_` có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.