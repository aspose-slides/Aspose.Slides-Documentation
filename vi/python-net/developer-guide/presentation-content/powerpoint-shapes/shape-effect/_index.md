---
title: Áp dụng Hiệu ứng Hình dạng trong Bài thuyết trình với Python
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Biến đổi các tệp PPT, PPTX và ODP của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides for Python — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/python-net/shape-formatting/#gradient-fill) hoặc đường viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông đẹp hơn các kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một tổ hợp đã được kiểm chứng đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ đó, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Python via .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế của bài thuyết trình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài cạnh của hình dạng, tạo ấn tượng rằng hình dạng đang nổi lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu.

Mã Python này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) cho một hình chữ nhật:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng hình ảnh của mẫu, sử dụng bóng trong để tạo cảm giác hình thẻ hoặc bảng hơi lõm. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm nó trông nổi, trong khi bóng trong làm tối bên trong các cạnh của nó.

Gọi [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), sau đó cấu hình [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Python này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu dưới dạng tệp PPTX:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides for Python via .NET, bạn có thể thêm một lớp phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bài thuyết trình bằng cách tạo cho các hình dạng một vẻ ngoài tinh tế và chuyên nghiệp hơn. Việc thực hiện rất đơn giản với một đoạn mã ngắn, cho phép áp dụng nhanh chóng trên nhiều phần tử để đồng bộ thiết kế.

Mã Python này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) cho một hình dạng:

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

![Reflection effect](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for Python via .NET, bạn có thể thêm một hào quang mềm mại, tỏa sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp làm nổi bật hình dạng và thêm một yếu tố trực quan hấp dẫn vào bài thuyết trình. Thực hiện rất dễ dàng với ít mã, giúp cải thiện tổng thể giao diện các slide.

Mã Python này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) cho một hình dạng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for Python via .NET, bạn có thể tạo một chuyển đổi mờ dịu quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần một diện mạo mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bài thuyết trình.

Mã Python này cho thấy cách áp dụng [cạnh mềm](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) cho một hình dạng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên cùng một hình dạng để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.