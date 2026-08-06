---
title: Nâng cao bài thuyết trình PowerPoint với hoạt ảnh trong Python
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/python-net/powerpoint-animation/
keywords:
- thêm hoạt ảnh
- cập nhật hoạt ảnh
- thay đổi hoạt ảnh
- xóa hoạt ảnh
- quản lý hoạt ảnh
- kiểm soát hoạt ảnh
- hiệu ứng hoạt ảnh
- hoạt ảnh PowerPoint
- dòng thời gian hoạt ảnh
- hoạt ảnh tương tác
- hoạt ảnh tùy chỉnh
- hoạt ảnh hình dạng
- biểu đồ động
- văn bản động
- hình dạng động
- đối tượng OLE động
- hình ảnh động
- bảng động
- bài thuyết trình PowerPoint
- Python
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides for Python via .NET trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bài thuyết trình của bạn."
---
## **Giới thiệu**

Bản trình chiếu được thiết kế để truyền tải thông tin, vì vậy hình ảnh trực quan và hành vi tương tác là những yếu tố quan trọng cần xem xét khi tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bản trình chiếu thu hút và hấp dẫn người xem. Aspose.Slides for Python via .NET cung cấp nhiều tùy chọn để thêm hoạt hình vào bản trình chiếu PowerPoint. Bạn có thể:

- Áp dụng các hiệu ứng hoạt hình đa dạng cho hình dạng, biểu đồ, bảng, đối tượng OLE và các yếu tố khác.
- Sử dụng nhiều hiệu ứng hoạt hình cho cùng một hình dạng.
- Kiểm soát các hiệu ứng thông qua dòng thời gian hoạt hình.
- Tạo các hoạt hình tùy chỉnh.

Trong Aspose.Slides for Python via .NET, các hiệu ứng hoạt hình có thể được áp dụng cho hình dạng. Vì mọi yếu tố trên một slide — bao gồm văn bản, hình ảnh, đối tượng OLE và bảng — đều được coi là một hình dạng, bạn có thể áp dụng hiệu ứng hoạt hình cho bất kỳ yếu tố nào trên slide.

Tên không gian [aspose.slides.animation](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/) cung cấp các lớp để làm việc với hoạt hình PowerPoint.

## **Cài đặt**

```bash
pip install aspose.slides
```

## **Thêm hiệu ứng hoạt hình vào hình dạng trong Python**

Các hiệu ứng hoạt hình tồn tại trong chuỗi chính của slide. Thêm một hình dạng, sau đó gọi `add_effect` trên `slide.timeline.main_sequence`, truyền vào kiểu hiệu ứng, phụ kiểu và trình kích hoạt bắt đầu nó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Tệp đã lưu chứa một hiệu ứng trên slide đầu tiên: hình chữ nhật bay vào từ bên trái trong hai giây khi người thuyết trình nhấn chuột. Khi mở lại và đọc `slide.timeline.main_sequence` sẽ trả về hiệu ứng đó, do đó hoạt hình tồn tại qua quá trình lưu‑đọc thay vì chỉ tồn tại trong bộ nhớ.

## **Hiệu ứng hoạt hình**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt hình**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, cũng như các hiệu ứng chuyên biệt như OLEObjectShow và OLEObjectOpen. Bạn có thể xem danh sách đầy đủ trong enum [EffectType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttype/).

Ngoài ra, các hiệu ứng hoạt hình này có thể được kết hợp với các hiệu ứng sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/seteffect/)

## **Hoạt hình tùy chỉnh**

Bạn có thể tạo **hoạt hình tùy chỉnh** của riêng mình trong Aspose.Slides bằng cách kết hợp nhiều hành vi thành một hiệu ứng duy nhất.

[Behavior](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/) là khối xây dựng cơ bản của bất kỳ hiệu ứng hoạt hình PowerPoint nào. Mỗi hiệu ứng hoạt hình thực chất là một tập hợp các hành vi được sắp xếp thành một chiến lược hoặc dòng thời gian. Bạn có thể lắp ráp các hành vi thành một hoạt hình tùy chỉnh một lần và sử dụng lại trong các bản trình chiếu khác. Nếu bạn thêm một hành vi mới vào một hiệu ứng hoạt hình PowerPoint tiêu chuẩn, nó sẽ trở thành một hoạt hình tùy chỉnh — ví dụ, thêm hành vi lặp lại để làm cho hoạt hình phát nhiều lần.

[Animation Point](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/point/) đánh dấu thời điểm hoặc vị trí mà một hành vi được áp dụng (một keyframe).

## **Dòng thời gian hoạt hình**

[Sequence](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/) là một tập hợp các hiệu ứng hoạt hình được áp dụng cho một hình dạng cụ thể.

[Timeline](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/animationtimeline/) là tập hợp các sequence được sử dụng trên một slide cụ thể. Nó được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt hình rất khó và thường cần các giải pháp tạm thời. Timeline thay thế lớp `AnimationSettings` cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt hình PowerPoint. Mỗi slide chỉ có thể có một dòng thời gian hoạt hình duy nhất.

## **Hoạt hình tương tác**

[Trigger](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/) cho phép bạn định nghĩa các hành động của người dùng (ví dụ: nhấp nút) để khởi động một hoạt hình cụ thể. Triggers chỉ được thêm vào trong các phiên bản PowerPoint mới nhất.

## **Hoạt hình hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt hình cho các hình dạng — như văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="primary" %}}

Read more [**Về hoạt hình hình dạng**](/slides/vi/python-net/shape-animation/).

{{% /alert %}}

## **Biểu đồ động**

Để tạo biểu đồ động, sử dụng cùng các lớp như khi làm việc với hình dạng. Tuy nhiên, hoạt hình PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt hình cho một phần tử danh mục riêng lẻ hoặc phần tử chuỗi.

{{% alert color="primary" %}}

Read more [**Về biểu đồ động**](/slides/vi/python-net/animated-charts/).

{{% /alert %}}

## **Văn bản động**

Ngoài việc hoạt hình hóa văn bản, bạn còn có thể áp dụng hoạt hình cho một đoạn văn.

{{% alert color="primary" %}}

Read more [**Về văn bản động**](/slides/vi/python-net/animated-text/).

{{% /alert %}}

## **FAQ**

### Các hoạt hình có được giữ lại khi xuất sang PDF không?

Không. PDF là định dạng tĩnh, do đó các hoạt hình và [slide transitions](/slides/vi/python-net/slide-transition/) không phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/python-net/export-to-html5/), [animated GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/python-net/convert-powerpoint-to-video/) thay thế.

### Bạn có thể chuyển bản trình chiếu động thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?

Có. Bạn có thể [render the presentation as frames](/slides/vi/python-net/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, qua ffmpeg), chọn FPS và độ phân giải. Các hoạt hình và chuyển đổi slide sẽ được phát trong quá trình render.

### Hoạt hình sẽ vẫn nguyên vẹn khi làm việc với ODP (không chỉ PPTX) không?

PPT, PPTX và ODP đều được hỗ trợ để [reading](/slides/vi/python-net/open-presentation/) và [writing](/slides/vi/python-net/save-presentation/), nhưng sự khác nhau về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm tra các trường hợp quan trọng bằng các mẫu thực.