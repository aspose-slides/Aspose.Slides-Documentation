---
title: Áp dụng hoạt ảnh hình dạng trong bài thuyết trình bằng Python
linktitle: Hoạt ảnh hình dạng
type: docs
weight: 60
url: /vi/python-net/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng hoạt ảnh
- văn bản hoạt ảnh
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Nổi bật hơn!"
---
## **Giới thiệu**

Hiệu ứng động là các hiệu ứng trực quan có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [biểu đồ](/slides/vi/python-net/animated-charts/). Chúng mang lại sức sống cho bài thuyết trình hoặc các thành phần của nó. 

## **Tại sao nên dùng hiệu ứng động trong bài thuyết trình?**

Sử dụng hiệu ứng động, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc sự tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho các hiệu ứng động và các hiệu ứng hoạt hình trong các danh mục **đầu vào**, **đầu ra**, **nhấn mạnh**, và **đường di chuyển**. 

## **Hiệu ứng động trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hiệu ứng động trong không gian tên [Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/), 
* Aspose.Slides cung cấp hơn **150 hiệu ứng động** trong enumeration [EffectType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttype/). Các hiệu ứng này về cơ bản giống (hoặc tương đương) các hiệu ứng được sử dụng trong PowerPoint.

## **Áp dụng hiệu ứng động cho TextBox**

Aspose.Slides cho Python thông qua .NET cho phép bạn áp dụng hiệu ứng động cho văn bản trong một hình dạng. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iautoshape/). 
4. Thêm văn bản vào `IAutoShape.TextFrame`.
5. Lấy chuỗi hiệu ứng chính.
6. Thêm một hiệu ứng động vào [IAutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iautoshape/). 
7. Đặt thuộc tính `TextAnimation.BuildType` thành giá trị từ Enumeration `BuildType`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Thêm AutoShape mới với văn bản
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Lấy chuỗi chính của slide.
    sequence = sld.timeline.main_sequence

    # Thêm hiệu ứng hoạt ảnh Fade vào shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Hoạt ảnh văn bản shape theo các đoạn cấp độ 1
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Lưu tệp PPTX vào đĩa
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hiệu ứng động cho văn bản, bạn cũng có thể áp dụng hiệu ứng động cho một [Paragraph](/slides/vi/python-net/animated-text/). Xem [**Animated Text**](/slides/vi/python-net/animated-text/).

{{% /alert %}} 

## **Áp dụng hiệu ứng động cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) trên slide. 
4. Lấy chuỗi hiệu ứng chính.
5. Thêm một hiệu ứng động vào [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/).
6. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
with slides.Presentation() as pres:
    # Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của trình chiếu
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Thêm khung hình ảnh vào slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Lấy chuỗi chính của slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Thêm hiệu ứng Fly từ trái vào khung hình ảnh
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Lưu tệp PPTX vào đĩa
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng hiệu ứng động cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iautoshape/). 
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iautoshape/) (khi đối tượng này được nhấp, hiệu ứng sẽ được phát).
5. Tạo một chuỗi hiệu ứng cho hình Bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh di chuyển tới `UserPath`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường bóng) cho một shape:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo một lớp Presentation đại diện cho tệp PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Thêm hiệu ứng hoạt ảnh PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Tạo một loại "button" nào đó.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Tạo một chuỗi hiệu ứng cho button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ được di chuyển chỉ sau khi button được nhấn.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Thêm các lệnh di chuyển vì đường dẫn đã tạo đang rỗng.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Ghi tệp PPTX vào đĩa
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy các hiệu ứng động đã áp dụng cho Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `get_effects_by_shape` từ lớp [Sequence](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/) để lấy tất cả các hiệu ứng động đã được áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng động được áp dụng cho shape trên slide bình thường**

Trước đó, bạn đã học cách thêm các hiệu ứng động vào shape trong bài thuyết trình PowerPoint. Đoạn mã mẫu dưới đây cho bạn thấy cách lấy các hiệu ứng đã được áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Lấy chuỗi hoạt ảnh chính của slide.
    sequence = first_slide.timeline.main_sequence

    # Lấy shape đầu tiên trên slide đầu tiên.
    shape = first_slide.shapes[0]

    # Lấy các hiệu ứng hoạt ảnh được áp dụng cho shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Ví dụ 2: Lấy tất cả các hiệu ứng động, bao gồm cả những hiệu ứng được kế thừa từ placeholders**

Nếu một shape trên slide bình thường có các placeholder nằm trên slide bố cục và/hoặc slide chủ, và các hiệu ứng động đã được thêm vào các placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong buổi trình chiếu, bao gồm cả những hiệu ứng được kế thừa từ các placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape chân trang có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** được áp dụng cho shape.

![Slide shape animation effect](slide-shape-animation.png)

Giả sử nữa rằng hiệu ứng **Split** được áp dụng cho placeholder chân trang trên slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** được áp dụng cho placeholder chân trang trên slide **master**.

![Master shape animation effect](master-shape-animation.png)

Đoạn mã mẫu dưới đây cho bạn thấy cách sử dụng phương thức `get_base_placeholder` từ lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) để truy cập các placeholder của shape và lấy các hiệu ứng động đã áp dụng cho shape chân trang, bao gồm cả những hiệu ứng được kế thừa từ các placeholder nằm trên slide layout và master.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Lấy các hiệu ứng hoạt ảnh của shape trên slide bình thường.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Lấy các hiệu ứng hoạt ảnh của placeholder trên slide layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Lấy các hiệu ứng hoạt ảnh của placeholder trên slide master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Thay đổi thuộc tính thời gian của hiệu ứng động**

Aspose.Slides cho Python thông qua .NET cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng động.

Đây là bảng Animation Timing trong Microsoft PowerPoint:

![example1_image](shape-animation.png)

Đây là các tương quan giữa PowerPoint Timing và các thuộc tính `Effect.Timing`:

- Danh sách thả xuống **Start** của PowerPoint Timing tương khớp với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/). 
- **Duration** của PowerPoint Timing tương khớp với thuộc tính `Effect.Timing.Duration`. Thời lượng của một hiệu ứng động (theo giây) là tổng thời gian mà hiệu ứng cần để hoàn thành một chu kỳ. 
- **Delay** của PowerPoint Timing tương khớp với thuộc tính `Effect.Timing.TriggerDelayTime`. 

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng động.
2. Đặt giá trị mới cho các thuộc tính `Effect.Timing` bạn cần. 
3. Lưu tệp PPTX đã sửa đổi.

Đoạn mã Python này minh họa thao tác:

```python
import aspose.slides as slides

# Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Lấy chuỗi chính của slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Lấy hiệu ứng đầu tiên của chuỗi chính.
    effect = sequence[0]

    # Thay đổi TriggerType của hiệu ứng để bắt đầu khi click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Thay đổi Duration của hiệu ứng
    effect.timing.duration = 3

    # Thay đổi TriggerDelayTime của hiệu ứng
    effect.timing.trigger_delay_time = 0.5

    # Lưu tệp PPTX vào đĩa
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Âm thanh của hiệu ứng động**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng động: 

- `sound`
- `stop_previous_sound`

### **Thêm âm thanh cho hiệu ứng động**

Đoạn mã Python này cho bạn thấy cách thêm âm thanh cho hiệu ứng động và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Thêm âm thanh vào bộ sưu tập âm thanh của bản trình chiếu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Lấy chuỗi chính của slide.
    sequence = first_slide.timeline.main_sequence

    # Lấy hiệu ứng đầu tiên của chuỗi chính
    first_effect = sequence[0]

    # Kiểm tra hiệu ứng có "No Sound" không
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Thêm âm thanh cho hiệu ứng đầu tiên
        first_effect.sound = effect_sound

    # Lấy chuỗi tương tác đầu tiên của slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Đặt cờ "Stop previous sound" cho hiệu ứng
    interactive_sequence[0].stop_previous_sound = True

    # Ghi tệp PPTX vào đĩa
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Trích xuất âm thanh của hiệu ứng động**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Lấy chuỗi hiệu ứng chính. 
4. Trích xuất `sound` được nhúng vào mỗi hiệu ứng động. 

Đoạn mã Python này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng động:

```python
import aspose.slides as slides

# Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Lấy chuỗi chính của slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Trích xuất âm thanh của hiệu ứng thành mảng byte
        audio = effect.sound.binary_data
```

## **Sau khi hiệu ứng động**

Aspose.Slides cho .NET cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng động.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint Effect tương khớp với các thuộc tính sau: 

- Thuộc tính `after_animation_type` mô tả loại After animation:
  * PowerPoint **More Colors** tương khớp với kiểu [COLOR](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** tương khớp với kiểu [DO_NOT_DIM](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/) (loại After animation mặc định);
  * PowerPoint **Hide After Animation** tương khớp với kiểu [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** tương khớp với kiểu [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/);
- Thuộc tính `after_animation_color` định nghĩa định dạng màu sau hiệu ứng. Thuộc tính này hoạt động cùng với kiểu [COLOR](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/). Nếu bạn thay đổi loại sang khác, màu sau hiệu ứng sẽ bị xóa.

Đoạn mã Python này cho bạn thấy cách thay đổi một hiệu ứng After animation:

```python
import aspose.slides as slides

# Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Lấy hiệu ứng đầu tiên của chuỗi chính
    first_effect = first_slide.timeline.main_sequence[0]

    # Thay đổi loại after animation thành Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Đặt màu giảm sáng after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Ghi tệp PPTX vào đĩa
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Hoạt ảnh Văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng động:

- `animate_text_type` mô tả loại animate text của hiệu ứng. Văn bản shape có thể được hoạt ảnh:
  - Tất cả cùng lúc ([ALL_AT_ONCE] loại)
  - Theo từ ([BY_WORD] loại)
  - Theo ký tự ([BY_LETTER] loại)
- `delay_between_text_parts` đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ tỷ lệ phần trăm thời lượng hiệu ứng. Giá trị âm chỉ thời gian trễ bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng động.
2. Đặt thuộc tính `build_type` thành giá trị [AS_ONE_OBJECT] để tắt chế độ hoạt ảnh *By Paragraphs*.
3. Đặt giá trị mới cho các thuộc tính `animate_text_type` và `delay_between_text_parts`.
4. Lưu tệp PPTX đã sửa đổi.

Đoạn mã Python này minh họa thao tác:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Lấy hiệu ứng đầu tiên của chuỗi chính
    first_effect = first_slide.timeline.main_sequence[0]

    # Thay đổi loại hoạt ảnh Văn bản của hiệu ứng thành "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Thay đổi loại Animate text của hiệu ứng thành "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
    first_effect.delay_between_text_parts = 20

    # Ghi tệp PPTX vào đĩa
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo các hiệu ứng động được giữ nguyên khi xuất bản bài thuyết trình lên web?**

[Export to HTML5](/slides/vi/python-net/export-to-html5/) và bật các [tùy chọn](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/) chịu trách nhiệm cho các hiệu ứng [shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_shapes/) và [transition](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_transitions/). HTML thuần không phát các hiệu ứng slide, trong khi HTML5 có.

**Thay đổi thứ tự z-order (thứ tự lớp) của các shape ảnh hưởng thế nào đến hiệu ứng động?**

Animation và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và loại xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/z_order_position/) xác định phần nào che phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects‑and‑shapes của Aspose.Slides tuân theo logic tương tự.)

**Có giới hạn nào khi chuyển đổi các hiệu ứng động sang video cho một số hiệu ứng nhất định không?**

Nhìn chung, [animations are supported](/slides/vi/python-net/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc với những hiệu ứng cụ thể có thể được render khác nhau. Khuyến nghị bạn kiểm tra với các hiệu ứng mình dùng và với phiên bản thư viện hiện tại.