---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng Python
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
description: "Áp dụng chuyển đổi slide, cấu hình tiến tự động của slide, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides for Python qua .NET."
---
## **Tổng quan**

Hiệu ứng chuyển đổi slide điều khiển cách các slide xuất hiện trong một buổi trình chiếu. Với Aspose.Slides for Python qua .NET, bạn có thể chọn hiệu ứng chuyển đổi cho từng slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ Python để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và truy cập thuộc tính [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) của slide. Đặt [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) thành một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), sau đó lưu bản trình chiếu.

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

## **Chuyển đổi Wheel**

Thuộc tính [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) của [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) kiểm soát số lượng sector tia radial để hiển thị slide đích. Đặt [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi slide thành WHEEL từ [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) trước khi truy cập [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) dưới dạng [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Ví dụ này tạo hai cặp slide giống hệt nhau: một slide màu đen tiếp theo là một slide có hình chữ nhật màu vàng. Các slide đích sử dụng số lượng spokes là 1 và 8, với cùng [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) và một [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) rõ ràng là 8.000 mili giây để dễ dàng quan sát sự khác biệt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Mở bản trình chiếu đầu ra trong PowerPoint và chạy buổi trình chiếu. Tiến từ slide 1 tới slide 2, sau đó từ slide 3 tới slide 4. Khi phát trong PowerPoint, số spokes đã xác nhận là 1 sẽ hiển thị slide bằng một vòng quay theo chiều kim đồng hồ; số 8 sẽ hiển thị nó qua tám sector tia đồng thời. Nội dung đích và thời gian chuyển đổi đều giống nhau, vì vậy sự khác biệt chỉ là số lượng sector hiển thị.

## **Fade Through Black với chuyển đổi Reveal**

Đặt [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi slide đích thành Reveal, sau đó thiết lập [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) trên đối tượng [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) được tạo ra. Ví dụ tạo một slide nguồn màu teal và một slide đích màu coral, sau đó sao chép cặp này. Cả hai cặp đều sử dụng cùng một chuyển đổi Reveal kéo dài hai giây. Chỉ cặp thứ hai sẽ fade qua màu đen.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Mở `reveal-transitions.pptx` trong PowerPoint và bắt đầu buổi trình chiếu. Tiến từ slide 1 tới slide 2 để xem màu teal fade trực tiếp sang coral. Sau đó tiến từ slide 3 tới slide 4. Màn hình sẽ tối lên nhanh chóng gần màu đen trước khi slide coral xuất hiện. Cả hai slide vẫn giữ màu nền gốc của mình.

Các hàng dưới đây hiển thị các khung hình từ PowerPoint với khoảng thời gian nửa giây. So sánh khung hình ở giữa mỗi hàng để thấy hiệu ứng của thiết lập.

![Phát lại PowerPoint với through_black bị tắt (trên) và bật (dưới). Chỉ hàng dưới đi qua gần màu đen.](reveal-through-black.png)

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide vẫn hiển thị trên màn hình và liệu một cú nhấp chuột có tiến buổi trình chiếu hay không. Các thuộc tính sau kiểm soát hành vi này:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) cho phép người xem tiến lên bằng cách nhấp chuột.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) cho phép tiến tự động.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) đặt độ trễ trước khi tiến tự động, tính bằng mili giây.

Bật cả tiến bằng nhấp chuột và tiến theo hẹn giờ để cho phép người xem di chuyển bằng một cú nhấp hoặc chờ hẹn giờ. Để chỉ dùng hẹn giờ, đặt [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) thành `False`. Độ trễ kiểm soát thời điểm buổi trình chiếu tiến; nó không thiết lập thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tự động sau 3, 5 và 7 giây, tương ứng. Các cú nhấp chuột cũng có thể tiến các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem tiến tự động có được bật hay không, đọc [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Một độ trễ được lưu không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật và tắt tiến tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

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

Sử dụng [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Thuộc tính [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) của slide cung cấp các cài đặt này qua [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Thuộc tính | Mục đích |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Đặt thời lượng của hiệu ứng chuyển đổi, tính bằng mili giây. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Đặt độ trễ trước khi slide tự động tiến, tính bằng mili giây. Bật [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) để kích hoạt bộ hẹn giờ này. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Chọn một danh mục tốc độ định trước từ [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM, hoặc FAST. Được sử dụng khi không chỉ định thời lượng chính xác. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến tự động riêng biệt. Khi không đặt thời lượng rõ ràng, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì tốc độ đồng nhất, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), và đặt thời lượng cho mỗi chuyển đổi là 750 mili giây. Nó riêng biệt bật tiến tự động sau 5.000 mili giây và tắt tiến bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Cấu hình tiến tự động một cách độc lập với thời lượng hiệu ứng.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Đặt thời lượng khác nhau cho từng slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển đổi ngắn cho slide tiêu đề và chuyển đổi dài hơn cho phần giới thiệu chương. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

Khi chuẩn bị một [animated GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/python-net/export-to-html5/), hoặc [video](/slides/vi/python-net/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp điệu mong muốn. Ví dụ, sử dụng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ tiến mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở tốc độ 30 khung/giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian mà định dạng xuất hỗ trợ, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Đọc [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) trước khi sửa đổi chuyển đổi để xác định xem có giá trị rõ ràng nào được lưu không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng được đặt; giá trị không âm chỉ định thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại đã tính: Aspose.Slides sử dụng loại chuyển đổi và [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo một thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

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

Chuyển đổi Morph hoạt hình các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp cho các đối tượng tương ứng khả năng hoạt hình giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ sau tạo một slide có một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enumeration [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để thấy hiệu ứng trong buổi trình chiếu.

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

Enumeration [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt hình nội dung:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) xem mỗi hình dạng như một đối tượng toàn bộ.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách ghép các từ khi có thể.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách ghép các ký tự khi có thể.

Đặt [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi thành Morph trước khi truy cập [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Giá trị sau đó cung cấp đối tượng [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), thuộc tính [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) của nó chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo ở phần trước và cấu hình slide thứ hai để sử dụng hoạt hình Morph dựa trên từ.

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

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) của chuyển đổi đã chọn. Đặt loại trước, sau đó sử dụng đối tượng chuyển đổi thích hợp từ [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó đặt [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) qua [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát lại của chuyển đổi slide không?**

Có. Ưu tiên sử dụng [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) đã định – SLOW, MEDIUM, hoặc FAST – là đủ và không có thời lượng rõ ràng được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi một cách độc lập với độ trễ tiến tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Có. Gán âm thanh nhúng vào [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), đặt [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) thành START_SOUND từ enumeration [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/), và bật [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Âm thanh sẽ lặp lại cho tới sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) của bản trình chiếu và đặt [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) của mỗi slide thành cùng một giá trị. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để giữ hành vi nhất quán trên các slide.

**Làm sao tôi kiểm tra được chuyển đổi hiện đang được đặt trên một slide?**

Đọc thuộc tính [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) từ [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) của slide. Nó trả về một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.