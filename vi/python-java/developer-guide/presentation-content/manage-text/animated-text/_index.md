---
title: Tạo hoạt ảnh văn bản PowerPoint trong Python qua Java
linktitle: Văn bản động
type: docs
weight: 60
url: /vi/python-java/animated-text/
keywords:
- văn bản động
- hoạt ảnh văn bản
- đoạn văn động
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tạo văn bản động và hoạt ảnh trong các bài thuyết trình PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Python qua Java, với các ví dụ mã Python dễ hiểu và tối ưu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản động trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho các đoạn văn riêng lẻ và lấy lại các hiệu ứng đã được gán cho các đoạn văn trong một khung văn bản. Nó tập trung vào các phương thức API được sử dụng để thêm hoạt hình cấp đoạn và kiểm tra các hiệu ứng hoạt hình đoạn đang tồn tại trong một bài thuyết trình.

## **Thêm hiệu ứng hoạt hình vào các đoạn văn**

Phương thức [addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) của lớp [Sequence](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/) cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất. Đoạn mã mẫu này cho thấy cách thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất:

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

## **Lấy hiệu ứng hoạt hình của các đoạn văn**

Bạn có thể muốn lấy lại các hiệu ứng hoạt hình đã áp dụng cho một đoạn văn — ví dụ, để áp dụng các hiệu ứng đó cho một đoạn văn hoặc hình dạng khác.

Aspose.Slides cho Python thông qua Java cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn văn có trong một khung văn bản (hình dạng). Đoạn mã mẫu này cho thấy cách lấy các hiệu ứng hoạt hình đã áp dụng cho một đoạn văn:

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

## **Câu hỏi thường gặp**

**Các hoạt hình văn bản khác với chuyển tiếp slide như thế nào, và chúng có thể kết hợp được không?**

Các hoạt hình văn bản điều khiển hành vi của đối tượng theo thời gian trên slide, trong khi [transitions](/slides/vi/python-java/slide-transition/) điều khiển cách slide chuyển đổi. Chúng độc lập và có thể được sử dụng đồng thời; thứ tự phát lại được quyết định bởi dòng thời gian hoạt hình và cài đặt chuyển tiếp.

**Các hoạt hình văn bản có được giữ nguyên khi xuất sang PDF hoặc hình ảnh không?**

Không. PDF và ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ chuyển động, hãy sử dụng xuất [video](/slides/vi/python-java/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/python-java/export-to-html5/).

**Các hoạt hình văn bản có hoạt động trong bố cục và master slide không?**

Các hiệu ứng được áp dụng cho các đối tượng layout/master sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt hình cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.