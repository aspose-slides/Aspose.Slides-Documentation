---
title: Quản lý chuyển đổi slide trong các bản trình chiếu bằng Python
linktitle: Chuyển đổi Slide
type: docs
weight: 90
url: /vi/python-net/slide-transition/
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
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến tới slide tự động, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Hiệu ứng chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides for Python via .NET, bạn có thể chọn một hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc tiến tới bằng cú nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn cụ thể cho một hiệu ứng. Bài viết này sử dụng các ví dụ Python để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và truy cập thuộc tính [slide_show_transition](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_show_transition/) của slide. Đặt [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/) thành một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/), sau đó lưu bản thuyết trình.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có tiến tới buổi trình chiếu hay không. Các thuộc tính sau kiểm soát hành vi này:

- [advance_on_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) cho phép người xem tiến tới bằng cách nhấp chuột.
- [advance_after](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) cho phép tiến tới tự động.
- [advance_after_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) chỉ định độ trễ trước khi tiến tới tự động, tính bằng mili giây.

Kích hoạt cả tiến tới bằng cú nhấp và bằng thời gian để cho phép người xem chuyển tiếp bằng cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, đặt [advance_on_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) thành `False`. Độ trễ kiểm soát thời điểm buổi trình chiếu tiến tới; nó không đặt thời lượng của hiệu ứng chuyển đổi hình ảnh.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tới tự động sau 3, 5 và 7 giây, tương ứng. Cú nhấp chuột cũng có thể tiến tới các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Để kiểm tra xem tiến tới có thời gian có được bật hay không, đọc [advance_after](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Một độ trễ đã lưu chỉ không cho biết bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt tiến tới tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật cú nhấp chuột cho các slide đó và lưu các cài đặt đã cập nhật.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Thuộc tính [slide_show_transition](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_show_transition/) của slide cung cấp các cài đặt này thông qua [SlideShowTransition](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/):

| Thuộc tính | Mục đích |
| --- | --- |
| [duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [advance_after_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Đặt độ trễ trước khi slide tiến tới tự động, tính bằng mili giây. Bật [advance_after](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) để kích hoạt bộ hẹn giờ này. |
| [speed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Chọn một danh mục tốc độ được định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM hoặc FAST. Nó được sử dụng khi không chỉ định thời lượng chính xác. |

[duration] chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide hiển thị. Cấu hình độ trễ tiến tới tự động riêng biệt. Khi không có thời lượng rõ ràng được đặt, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [speed].

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/), và đặt thời lượng 750 mili giây cho mỗi chuyển đổi. Nó tách ra bật tiến tới tự động sau 5.000 mili giây và tắt tiến tới bằng cú nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Cấu hình việc tiến tới tự động độc lập với thời lượng hiệu ứng.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Đặt thời lượng khác nhau cho các slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển đổi ngắn cho slide tiêu đề và chuyển đổi dài hơn cho phần giới thiệu. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Phối hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/python-net/export-to-html5/), hoặc [video](/slides/vi/python-net/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng làm mờ 600 mili giây giữa các cảnh, và điều chỉnh độ trễ tiến tới của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.  
Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở tốc độ 30 khung hình/giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Đọc [duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) trước khi chỉnh sửa chuyển đổi để xác định xem có giá trị rõ ràng nào được lưu không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng được đặt; một giá trị không âm chỉ định thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính: Aspose.Slides sử dụng loại chuyển đổi và [speed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Chuyển đổi Morph**

Chuyển đổi Morph hoạt hình các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp cho chuyển đổi các đối tượng tương ứng để hoạt hình giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide chứa một hình chữ nhật văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó nó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bài thuyết trình hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Các loại chuyển đổi Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt hình nội dung:

- [BY_OBJECT](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionmorphtype/) xử lý mỗi hình dạng như một đối tượng hoàn chỉnh.
- [BY_WORD](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách khớp các từ khi có thể.
- [BY_CHAR](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách khớp các ký tự khi có thể.

Đặt [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi thành Morph trước khi truy cập [value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/value/). Giá trị sau đó cung cấp đối tượng [MorphTransition](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/morphtransition/), trong đó thuộc tính [morph_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/morphtransition/morph_type/) chọn chế độ khớp.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi đã chọn. Đặt loại trước, sau đó sử dụng đối tượng chuyển đổi phù hợp từ [value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó đặt [from_black](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Đúng. Ưu tiên sử dụng [duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [speed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionspeed/) định sẵn—SLOW, MEDIUM hoặc FAST—đủ và không có thời lượng rõ ràng nào được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ tiến tới tự động.

**Tôi có thể đính kèm âm thanh vào một chuyển đổi và lặp lại nó không?**

Đúng. Gán âm thanh nhúng vào [sound](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound/), đặt [sound_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) thành START_SOUND từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionsoundmode/), và bật [sound_loop](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua tập hợp [slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) của bản thuyết trình và đặt [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi cho mỗi slide thành cùng một giá trị. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao tôi có thể kiểm tra chuyển đổi hiện đang được đặt trên một slide?**

Đọc thuộc tính [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/) từ [slide_show_transition](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_show_transition/) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/); NONE có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.