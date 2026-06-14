---
title: Áp dụng Hiệu ứng Hình dạng trong Bản trình bày với Python
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/python-net/shape-effect
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng viền mềm
- định dạng hiệu ứng
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Biến đổi các tệp PPT, PPTX và ODP của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Python—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [fills](/slides/vi/python-net/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng phát sáng của hình dạng, v.v.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 
* Một số kết hợp hiệu ứng trông tốt hơn so với những thứ khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một sự kết hợp đã được chứng minh là đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ đó, bằng cách chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng bóng ngoài (`outer_shadow_effect`) cho một hình chữ nhật:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng hiệu ứng phản chiếu**

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng phản chiếu cho một hình dạng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng hiệu ứng phát sáng**

Đoạn mã Python này cho bạn thấy cách áp dụng hiệu ứng phát sáng cho một hình dạng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng hiệu ứng viền mềm**

Đoạn mã Python này cho bạn thấy cách áp dụng viền mềm cho một hình dạng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những loại hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và các hình dạng khác.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.