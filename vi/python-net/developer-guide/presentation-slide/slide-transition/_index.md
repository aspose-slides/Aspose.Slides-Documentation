---
title: Quản lý chuyển tiếp slide trong bản trình bày bằng Python
linktitle: Chuyển tiếp Slide
type: docs
weight: 90
url: /vi/python-net/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- áp dụng chuyển tiếp slide
- chuyển tiếp slide nâng cao
- chuyển tiếp morph
- loại chuyển tiếp
- hiệu ứng chuyển tiếp
- Python
- Aspose.Slides
description: "Khám phá cách tùy chỉnh chuyển tiếp slide trong Aspose.Slides for Python qua .NET, với hướng dẫn từng bước cho các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides for Python cung cấp quyền kiểm soát đầy đủ đối với các chuyển tiếp slide, từ việc chọn loại chuyển tiếp đến cấu hình thời gian và trình kích hoạt như một phần của quy trình làm việc tự động hóa bản trình bày. Bạn có thể đặt slide tiến tới khi nhấp và/hoặc sau một khoảng thời gian xác định và tinh chỉnh hành vi hình ảnh bằng các hiệu ứng như cắt từ màu đen hoặc xuất hiện theo hướng. Thư viện cũng hỗ trợ chuyển tiếp Morph được giới thiệu trong PowerPoint 2019, bao gồm các chế độ Morph theo đối tượng, từ hoặc ký tự để tạo chuyển động mượt mà, thống nhất giữa các slide.

## **Thêm chuyển tiếp slide**

Để dễ hiểu hơn, ví dụ này minh họa cách sử dụng Aspose.Slides for Python để quản lý các chuyển tiếp slide đơn giản. Các nhà phát triển có thể áp dụng các hiệu ứng chuyển tiếp slide khác nhau cho slide và tùy chỉnh hành vi của chúng. Để tạo một chuyển tiếp slide đơn giản, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Áp dụng một chuyển tiếp slide bằng một trong các hiệu ứng từ enum [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/) .
1. Lưu tệp bản trình bày đã sửa đổi.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để tải tệp bản trình bày.
with slides.Presentation("sample.pptx") as presentation:
    # Áp dụng chuyển tiếp hình tròn cho slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Áp dụng chuyển tiếp comb cho slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Lưu bản trình bày vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm chuyển tiếp slide nâng cao**

Trong phần này, chúng tôi đã áp dụng một hiệu ứng chuyển tiếp đơn giản cho một slide. Để hiệu ứng đó được kiểm soát và tinh tế hơn, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Áp dụng một chuyển tiếp slide bằng một trong các hiệu ứng từ enum [TransitionType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitiontype/) .
1. Cấu hình chuyển tiếp để Tiến tới Khi Nhấp, sau một khoảng thời gian cụ thể, hoặc cả hai.
1. Lưu tệp bản trình bày đã sửa đổi.

Nếu **Advance On Click** được bật, slide sẽ tiến tới chỉ khi người dùng nhấp. Nếu thuộc tính **Advance After Time** được thiết lập, slide sẽ tự động tiến tới sau khoảng thời gian đã chỉ định.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp bản trình bày.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Áp dụng chuyển tiếp hình tròn cho slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Bật tiến tới khi nhấp và đặt thời gian tự động tiến tới 3 giây.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Áp dụng chuyển tiếp comb cho slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Bật tiến tới khi nhấp và đặt thời gian tự động tiến tới 5 giây.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Áp dụng chuyển tiếp zoom cho slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Bật tiến tới khi nhấp và đặt thời gian tự động tiến tới 7 giây.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Lưu bản trình bày vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Chuyển tiếp Morph**

Aspose.Slides for Python hỗ trợ [Morph transition](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/morphtransition/), cho phép tạo chuyển động mượt mà từ slide này sang slide kế tiếp. Phần này giải thích cách sử dụng chuyển tiếp Morph. Để sử dụng hiệu quả, bạn cần hai slide có ít nhất một đối tượng chung. Cách đơn giản nhất là sao chép một slide và sau đó di chuyển đối tượng đến vị trí khác trên slide thứ hai.

Đoạn mã sau cho thấy cách sao chép một slide chứa văn bản và áp dụng chuyển tiếp Morph cho slide thứ hai.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Sao chép slide đầu tiên để tạo slide thứ hai với cùng các hình dạng cho tính liên tục của Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Chọn cùng hình chữ nhật trên slide thứ hai và thay đổi vị trí và kích thước của nó.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Bật chuyển tiếp Morph trên slide thứ hai để tạo hoạt ảnh cho các thay đổi hình dạng một cách mượt mà.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Các loại chuyển tiếp Morph**

Enum [TransitionMorphType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionmorphtype/) biểu thị các loại chuyển tiếp Morph khác nhau cho slide.

Đoạn mã sau cho thấy cách áp dụng chuyển tiếp Morph cho một slide và thay đổi loại morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt hiệu ứng chuyển tiếp**

Aspose.Slides for Python cho phép bạn đặt các hiệu ứng chuyển tiếp như **From Black**, **From Left**, **From Right**, v.v. Để cấu hình một hiệu ứng chuyển tiếp, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide.
1. Đặt hiệu ứng chuyển tiếp mong muốn.
1. Lưu bản trình bày dưới dạng tệp PPTX.

Trong ví dụ bên dưới, chúng tôi đặt một số hiệu ứng chuyển tiếp.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp bản trình bày.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Áp dụng chuyển tiếp Cut và bật From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Lưu bản trình bày vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Bạn có thể kiểm soát tốc độ phát lại của chuyển tiếp slide không?**

Có. Đặt [speed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) của chuyển tiếp bằng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/transitionspeed/), ví dụ: slow/medium/fast.

**Bạn có thể đính kèm âm thanh vào một chuyển tiếp và lặp lại nó không?**

Có. Bạn có thể nhúng âm thanh cho chuyển tiếp và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và lặp lại (ví dụ: [sound](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), cộng với siêu dữ liệu như [sound_is_built_in](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) và [sound_name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Cách nhanh nhất để áp dụng cùng một chuyển tiếp cho mọi slide là gì?**

Cấu hình loại chuyển tiếp mong muốn trên cài đặt chuyển tiếp của mỗi slide; các chuyển tiếp được lưu riêng cho từng slide, vì vậy áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả nhất quán.

**Làm sao để kiểm tra chuyển tiếp nào đang được đặt trên một slide?**

Kiểm tra [transition settings](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_show_transition/) của slide và đọc [transition type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.slideshow/slideshowtransition/type/); giá trị đó cho bạn biết chính xác hiệu ứng nào đang được áp dụng.