---
title: Tạo hoạt ảnh văn bản PowerPoint trong Python qua Java
linktitle: Văn bản động
type: docs
weight: 60
url: /vi/python-java/animated-text/
keywords:
- văn bản động
- hoạt ảnh văn bản
- đoạn văn bản động
- hoạt ảnh đoạn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo văn bản động trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java, với các ví dụ mã Python dễ hiểu và được tối ưu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản động trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt ảnh cho từng đoạn văn và lấy lại các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được sử dụng để thêm hoạt ảnh ở mức đoạn và kiểm tra các hiệu ứng hoạt ảnh đoạn đã tồn tại trong một bản trình bày.

## **Thêm hiệu ứng hoạt ảnh cho các đoạn**

Phương thức [addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) của lớp [Sequence](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/) cho phép bạn thêm hiệu ứng hoạt ảnh vào một đoạn đơn. Đoạn mã mẫu này cho bạn thấy cách thêm một hiệu ứng hoạt ảnh vào một đoạn duy nhất:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Chọn đoạn văn để thêm hiệu ứng.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy hiệu ứng hoạt ảnh của các đoạn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt ảnh đã được thêm vào một đoạn — ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt ảnh trong một đoạn vì bạn dự định áp dụng những hiệu ứng đó cho một đoạn hoặc hình dạng khác.

Aspose.Slides for Python qua Java cho phép bạn lấy tất cả các hiệu ứng hoạt ảnh được áp dụng cho các đoạn nằm trong một khung văn bản (hình). Đoạn mã mẫu này cho bạn thấy cách lấy các hiệu ứng hoạt ảnh trong một đoạn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Cách hoạt ảnh văn bản khác với chuyển đổi slide như thế nào và chúng có thể được kết hợp không?**

Hoạt ảnh văn bản điều khiển hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/python-java/slide-transition/) điều khiển cách các slide chuyển đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát lại được điều khiển bởi dòng thời gian hoạt ảnh và cài đặt chuyển đổi.

**Các hoạt ảnh văn bản có được giữ lại khi xuất ra PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ chuyển động, hãy sử dụng xuất sang [video](/slides/vi/python-java/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/python-java/export-to-html5/).

**Các hoạt ảnh văn bản có hoạt động trong bố cục và chủ đề slide không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/chủ đề sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt ảnh ở mức slide phụ thuộc vào chuỗi cuối cùng trên slide.