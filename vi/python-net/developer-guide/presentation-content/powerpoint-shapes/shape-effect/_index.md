---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu với Python
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/python-net/shape-effect
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Biến đổi các tệp PPT, PPTX và ODP của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Python — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/python-net/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng ánh hào quang của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp của các hiệu ứng trông tốt hơn các kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một sự kết hợp đã được biết là đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ vậy, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng Đổ bóng**

Aspose.Slides cho Python thông qua .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bài thuyết trình của bạn.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) cho một hình chữ nhật:
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

![Hiệu ứng bóng](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng hình ảnh của mẫu, hãy sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lõm. Bóng ngoài mở rộng ra ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng bên trong các cạnh của nó.

Gọi [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), sau đó cấu hình [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Giá trị blur-radius lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Python này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX:
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

![Hình chữ nhật màu xanh nhạt có bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, Thay đổi và Xóa bóng Preset**

Gọi [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) và đặt thuộc tính [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) của bóng thành một giá trị [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) để xóa bỏ bóng trong khi vẫn giữ nguyên phần đổ màu và viền.

Ví dụ này hiển thị bốn giai đoạn cạnh nhau trên một slide. Nó sao chép hình chữ nhật trước mỗi thay đổi để bạn có thể so sánh kết quả. Cả hai bóng đều dịch offset 10 điểm. Hướng 225° đặt bóng đầu tiên phía trên và bên trái của hình chữ nhật, còn 45° đặt bóng thứ hai phía dưới và bên phải.
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
| ![Không có bóng](preset_shadow_original.png) | ![Bóng đổ trên‑trái](preset_shadow_top_left.png) | ![Bóng đổ dưới‑phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng Phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Python thông qua .NET, bạn có thể thêm phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bài thuyết trình bằng cách tạo cho các hình dạng vẻ ngoài tinh tế và chuyên nghiệp hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để đạt thiết kế đồng nhất.

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

## **Áp dụng hiệu ứng Hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho Python thông qua .NET, bạn có thể thêm một hào quang mềm mại, rực rỡ quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố hình ảnh thu hút, bắt mắt vào bài thuyết trình của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể hình ảnh của các slide.

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

## **Áp dụng hiệu ứng Cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho Python thông qua .NET, bạn có thể tạo một chuyển tiếp mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần vẻ ngoài nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt hiệu quả mong muốn cho nhiều hình dạng trong bài thuyết trình.

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

## **Áp dụng hiệu ứng Làm mờ**

Sử dụng làm mờ hình dạng để làm mềm phần đổ màu và viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên ngoại hình.

Cài đặt [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `False`, độ mờ được cắt theo giới hạn đã vẽ ban đầu, bao gồm cả viền. Khi `True`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một màu đổ, viền và kích thước hình dạng xuyên suốt. Hàng trên sử dụng `grow = False`; hàng dưới sử dụng `grow = True`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ Python này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng độ mờ 5 điểm, rồi cập nhật lên độ mờ 15 điểm bằng cách gọi lại [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) . Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) và lưu hình dạng mà không có độ mờ.
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

Sự làm mờ hình dạng ảnh hưởng đến cả phần đổ màu và viền. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành ảnh.

## **FAQ**

**Bạn có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng?**

Bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo động hơn.

**Bạn có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho các loại hình dạng khác nhau, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.