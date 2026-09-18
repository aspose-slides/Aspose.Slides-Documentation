---
title: Nâng cao Bài thuyết trình PowerPoint với Hoạt hình trong Python
linktitle: Hoạt hình PowerPoint
type: docs
weight: 150
url: /vi/python-net/powerpoint-animation/
keywords:
- thêm hoạt hình
- cập nhật hoạt hình
- thay đổi hoạt hình
- xóa hoạt hình
- quản lý hoạt hình
- kiểm soát hoạt hình
- hiệu ứng hoạt hình
- hoạt hình PowerPoint
- dòng thời gian hoạt hình
- hoạt hình tương tác
- hoạt hình tùy chỉnh
- hoạt hình hình dạng
- biểu đồ động
- văn bản động
- hình dạng động
- đối tượng OLE động
- hình ảnh động
- bảng động
- bài thuyết trình PowerPoint
- Python
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides cho Python qua .NET trong việc xử lý hoạt hình PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bài thuyết trình của bạn."
---
## **Giới thiệu**

Bài thuyết trình được thiết kế để truyền đạt thông tin, vì vậy giao diện trực quan và hành vi tương tác là những yếu tố quan trọng cần xem xét trong quá trình tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bài thuyết trình hấp dẫn và thu hút người xem. Aspose.Slides for Python via .NET cung cấp nhiều tùy chọn để thêm hoạt hình vào bản trình bày PowerPoint. Bạn có thể:

- Áp dụng các hiệu ứng hoạt hình khác nhau cho hình dạng, biểu đồ, bảng, đối tượng OLE và các thành phần khác.
- Sử dụng nhiều hiệu ứng hoạt hình trên cùng một hình dạng.
- Kiểm soát các hiệu ứng thông qua dòng thời gian hoạt hình.
- Tạo hoạt hình tùy chỉnh.

Trong Aspose.Slides for Python via .NET, các hiệu ứng hoạt hình có thể được áp dụng cho hình dạng. Vì mọi thành phần trên một slide — bao gồm văn bản, hình ảnh, đối tượng OLE và bảng — đều được coi là một hình dạng, bạn có thể áp dụng hiệu ứng hoạt hình cho bất kỳ thành phần nào trên slide.

Namespace [aspose.slides.animation](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/) cung cấp các lớp để làm việc với hoạt hình PowerPoint.

## **Cài đặt**

```bash
pip install aspose.slides
```

## **Thêm hiệu ứng hoạt hình vào hình dạng trong Python**

Các hiệu ứng hoạt hình tồn tại trong chuỗi chính của slide. Thêm một hình dạng, sau đó gọi `add_effect` trên `slide.timeline.main_sequence`, truyền loại hiệu ứng, phụ loại và kích hoạt bắt đầu nó.

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

Tệp đã lưu chứa một hiệu ứng trên slide đầu tiên: hình chữ nhật bay vào từ phía trái trong hai giây khi người thuyết trình nhấp chuột. Khi mở lại và đọc `slide.timeline.main_sequence` sẽ trả về hiệu ứng đó, vì vậy hoạt hình tồn tại qua vòng quay thay vì chỉ tồn tại trong bộ nhớ.

## **Hiệu ứng hoạt hình**

Aspose.Slides hỗ trợ **150+ hiệu ứng hoạt hình**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, cũng như các hiệu ứng chuyên biệt như OLEObjectShow và OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ trong enumeration [EffectType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttype/).

Ngoài ra, các hiệu ứng hoạt hình này có thể kết hợp với các hiệu ứng sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/seteffect/)

## **Hoạt hình tùy chỉnh**

Đối với các ví dụ Python hoàn chỉnh tạo, kiểm tra và sửa đổi hành vi cũng như các đường chuyển động có thể chỉnh sửa, xem [Custom Animation](/slides/vi/python-net/custom-animation/).

Bạn có thể tạo **hoạt hình tùy chỉnh** của riêng mình trong Aspose.Slides bằng cách kết hợp nhiều hành vi thành một hiệu ứng duy nhất.

[Behavior](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/) là khối xây dựng của một hiệu ứng hoạt hình PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng một hiệu ứng đã định nghĩa trước. Việc lặp lại được cấu hình qua cài đặt thời gian chứ không phải bằng một hành vi lặp riêng.

[Animation Point](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/point/) đánh dấu thời điểm hoặc vị trí mà một hành vi được áp dụng (một keyframe).

## **Dòng thời gian hoạt hình**

[Sequence](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/) là một tập hợp các hiệu ứng hoạt hình có thể nhắm tới các hình dạng khác nhau.

[Timeline](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/animationtimeline/) là tập hợp các chuỗi được sử dụng trên một slide cụ thể. Nó được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt hình khó khăn và thường cần các giải pháp thay thế. Timeline thay thế lớp `AnimationSettings` cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt hình PowerPoint. Mỗi slide chỉ có thể có một dòng thời gian hoạt hình.

## **Hoạt hình tương tác**

[Trigger](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/) cho phép bạn xác định các hành động người dùng (ví dụ: nhấp nút) để bắt đầu một hoạt hình cụ thể. Triggers chỉ được thêm vào trong các phiên bản mới nhất của PowerPoint.

## **Hoạt hình hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt hình cho các hình dạng — chẳng hạn như văn bản, hình chữ nhật, đường kẻ, khung, đối tượng OLE và hơn thế nữa.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về hoạt hình hình dạng**](/slides/vi/python-net/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**

Để tạo biểu đồ động, sử dụng cùng các lớp như khi làm việc với hình dạng. Tuy nhiên, hoạt hình PowerPoint chỉ có thể áp dụng cho các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng một hiệu ứng hoạt hình cho một phần tử danh mục riêng lẻ hoặc một phần tử chuỗi riêng lẻ.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về biểu đồ động**](/slides/vi/python-net/animated-charts/).
{{% /alert %}}

## **Văn bản động**

Ngoài việc hoạt hình hóa văn bản, bạn còn có thể áp dụng hoạt hình cho một đoạn văn.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về văn bản động**](/slides/vi/python-net/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt hình có được giữ nguyên khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt hình và [slide transitions](/slides/vi/python-net/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/python-net/export-to-html5/), [animated GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/) hoặc [video](/slides/vi/python-net/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển bài thuyết trình động thành video và điều chỉnh tốc độ khung hình và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/python-net/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: qua ffmpeg), chọn FPS và độ phân giải. Các hoạt hình và slide transitions sẽ được phát trong quá trình render.

**Các hoạt hình có vẫn nguyên vẹn khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/python-net/open-presentation/) và [writing](/slides/vi/python-net/save-presentation/), nhưng điều này không đảm bảo việc bảo tồn hoạt hình. Dữ liệu hoạt hình tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Custom Animation](/slides/vi/python-net/custom-animation/) để biết ví dụ và hướng dẫn kiểm tra tính tương thích của định dạng.