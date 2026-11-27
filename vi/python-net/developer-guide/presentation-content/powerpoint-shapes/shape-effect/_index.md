---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu bằng Python
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/python-net/shape-effect
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Chuyển đổi các tệp PPT, PPTX và ODP của bạn với các hiệu ứng hình dạng tiên tiến bằng Aspose.Slides cho Python—tạo các slide nổi bật, chuyên nghiệp trong vài giây."
---
## **Introduction**

Trong PowerPoint, hiệu ứng có thể được sử dụng để làm cho một hình dạng nổi bật, nhưng chúng khác với [đổ màu](/slides/vi/python-net/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng ánh hào quang của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Có một số kết hợp hiệu ứng trông tốt hơn những kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một sự kết hợp đã được kiểm chứng đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ đó, khi chọn một preset, bạn không cần tốn thời gian kiểm tra hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Aspose.Slides cho Python thông qua .NET hỗ trợ bóng đổ ngoài và trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bản trình chiếu của mình.

### **Áp dụng bóng đổ ngoài**

Bạn có thể sử dụng bóng đổ ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng đổ kéo dài ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng bóng đổ ngoài](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) cho một hình chữ nhật:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng bóng đổ](shadow_effect.png)

#### **Kiểm soát hướng bóng khi hình dạng quay**

Theo mặc định, [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) là `True`, vì vậy bóng sẽ quay cùng hình dạng. Để các hình dạng với các góc quay khác nhau nhìn như được chiếu sáng từ cùng một hướng, đặt thuộc tính này thành `False` và đặt [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) của các bóng đổ giống nhau.

Ví dụ tạo hai mũi tên với bóng màu xám lệch 42 điểm sang phải (`direction = 0`). Sau đó sao chép slide và xoay cả hai mũi tên 90° theo chiều kim đồng hồ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

Trên slide thứ hai, mũi tên trái chiếu bóng xuống dưới, trong khi mũi tên phải vẫn chiếu bóng sang phải. Hướng được cấu hình vẫn là 0° cho cả hai bóng.

![Kết xuất PowerPoint trước và sau khi xoay 90°. Cả hai bóng đều bắt đầu ở bên phải. Sau khi xoay, bóng di chuyển xuống dưới mũi tên trái và vẫn ở bên phải mũi tên phải.](arrow-shadow-rotation.png)

### **Áp dụng bóng đổ trong**

Khi tái tạo kiểu dáng hình ảnh của mẫu, hãy sử dụng bóng đổ trong để tạo cảm giác lõm cho thẻ hoặc bảng. Bóng đổ ngoài mở rộng ra ngoài hình dạng và làm cho nó trông nổi lên, trong khi bóng đổ trong làm tối bên trong các cạnh của nó.

Gọi [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), sau đó cấu hình [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Giá trị blur-radius lớn hơn tạo ra các cạnh mềm hơn.

Đoạn ví dụ Python này tạo một thẻ màu xanh nhạt với bóng đổ trong màu xám đậm và lưu nó dưới dạng tệp PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hình chữ nhật màu xanh nhạt có bóng đổ trong](inner_shadow_effect.png)

Để xóa bỏ bóng đổ trong, gọi [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và gỡ bỏ bóng đổ Preset**

Gọi [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) và đặt thuộc tính [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) của bóng đổ thành giá trị của [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) để xóa bóng đổ trong khi vẫn giữ phần đổ màu và viền.

Ví dụ này hiển thị bốn giai đoạn cạnh nhau trên một slide. Nó sao chép hình chữ nhật trước mỗi thay đổi để bạn có thể so sánh kết quả. Cả hai bóng đều lệch 10 điểm. Hướng 225° đặt bóng đầu tiên ở phía trên và bên trái của hình chữ nhật, và 45° đặt bóng thứ hai ở phía dưới và bên phải.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng thả góc trên‑trái](preset_shadow_top_left.png) | ![Bóng thả góc dưới‑phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Python thông qua .NET, bạn có thể thêm một phản chiếu gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một diện mạo được đánh bóng và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để có thiết kế nhất quán.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) cho một hình dạng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho Python thông qua .NET, bạn có thể thêm một hào quang mềm mại xung quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố hình ảnh hấp dẫn, thu hút mắt vào bản trình chiếu của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể vẻ ngoài của các slide.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) cho một hình dạng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho Python thông qua .NET, bạn có thể tạo một chuyển đổi mượt mà, mờ dần quanh các cạnh của một hình dạng. Hiệu ứng này thêm một diện mạo tinh tế và nhẹ nhàng hơn, hoàn hảo cho các thiết kế cần vẻ ngoài mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên các hình dạng khác nhau trong bản trình chiếu.

Đoạn mã Python này cho thấy cách áp dụng [cạnh mềm](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) cho một hình dạng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm phần đổ màu và viền của hình mà vẫn giữ được khả năng chỉnh sửa. Gọi [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) trên định dạng hiệu ứng của hình. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không giữ nguyên ngoại hình.

Cài đặt [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) kiểm soát phạm vi hiển thị của hiệu ứng. Khi `False`, độ mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm cả viền. Khi `True`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình.

So sánh dưới đây sử dụng cùng một màu đổ, viền và kích thước hình suốt quá trình. Hàng trên sử dụng `grow = False`; hàng dưới sử dụng `grow = True`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Đoạn ví dụ Python này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Nó lưu cả hai trạng thái đã làm mờ, rồi gọi [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) và lưu hình không có độ mờ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Làm mờ hình dạng ảnh hưởng đến cả phần đổ màu và viền đồng thời. Hiệu ứng cạnh mềm làm nhạt các cạnh của hình, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng làm mờ trực tiếp trên định dạng hiệu ứng của hình mà không chuyển hình sang ảnh.

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo năng động hơn.

**Các loại hình dạng nào tôi có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.