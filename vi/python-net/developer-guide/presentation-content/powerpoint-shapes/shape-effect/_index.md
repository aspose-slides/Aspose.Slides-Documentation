---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng Python
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/python-net/shape-effect
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chuyển đổi các tệp PPT, PPTX và ODP của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Python—tạo các slide nổi bật, chuyên nghiệp chỉ trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/python-net/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng phát sáng của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp của các hiệu ứng trông tốt hơn các kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một sự kết hợp đã biết là đẹp mắt của hai hoặc nhiều hiệu ứng. Bằng cách này, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp tốt.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Python via .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bản trình chiếu của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra khỏi các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu.

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

Khi tái tạo phong cách hình ảnh của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng vẻ ngoài lõm vào. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm nó trông nổi lên, trong khi bóng trong làm tối các cạnh bên trong của nó.

Gọi [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), sau đó cấu hình [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Python này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu dưới dạng tệp PPTX:

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

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides for Python via .NET, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một vẻ ngoài bóng bẩy và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh trên nhiều phần tử để duy trì thiết kế nhất quán.

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

## **Áp dụng hiệu ứng phát sáng**

Để áp dụng hiệu ứng phát sáng cho một hình dạng trong Aspose.Slides for Python via .NET, bạn có thể thêm một hào quang mềm mại, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố hình ảnh hấp dẫn, thu hút mắt vào bản trình chiếu của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng phát sáng](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) cho một hình dạng:

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

![Hiệu ứng phát sáng](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for Python via .NET, bạn có thể tạo một chuyển đổi mờ nhẹ quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng, hoàn hảo cho các thiết kế cần sự mềm mại, nhẹ nhàng. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình chiếu.

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

Sử dụng làm mờ hình dạng để làm mềm màu nền và đường viền của hình dạng trong khi giữ hình dạng có thể chỉnh sửa. Gọi [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo hiệu ứng làm mờ mạnh hơn. Bán kính bằng không giữ nguyên giao diện.

Cài đặt [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) điều khiển giới hạn hiển thị của hiệu ứng. Với `False`, độ mờ bị cắt theo giới hạn được vẽ ban đầu, bao gồm cả đường viền. Với `True`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng màu nền, đường viền và kích thước hình dạng trong suốt. Hàng trên sử dụng `grow = False`; hàng dưới sử dụng `grow = True`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ Python này tạo một hình chữ nhật màu cam với đường viền xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) và lưu hình dạng không có độ mờ.

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

Làm mờ hình dạng ảnh hưởng đến màu nền và đường viền cùng lúc. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm dịu bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng sang ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều loại khác.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.