---
title: Cải thiện bài thuyết trình của bạn với AutoFit trong Python
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/python-net/manage-autofit-settings/
keywords:
- hộp văn bản
- autofit
- không tự động vừa
- vừa văn bản
- thu nhỏ văn bản
- ngắt dòng văn bản
- thay đổi kích thước hình
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý cài đặt AutoFit trong Aspose.Slides cho Python qua .NET để tối ưu hiển thị văn bản trong các bài thuyết trình PowerPoint và OpenDocument của bạn và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản — nó tự động thay đổi kích thước hộp để đảm bảo văn bản luôn vừa vào bên trong. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp trở nên dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp — tăng chiều cao — để chứa nhiều văn bản hơn. 
* Khi văn bản trong hộp ngắn hơn hoặc nhỏ hơn, PowerPoint tự động giảm hộp — giảm chiều cao — để loại bỏ không gian dư thừa. 

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng điều khiển hành vi autofit cho một hộp văn bản: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET cung cấp các tùy chọn tương tự — một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) — cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bản trình chiếu. 

## **Resize Shapes to Fit Text**

Nếu bạn muốn văn bản trong một hộp luôn vừa vào hộp sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, đặt thuộc tính [autofit_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) thành `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Đoạn mã Python này cho thấy cách chỉ định rằng văn bản luôn phải vừa vào hộp trong bản trình chiếu PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Nếu văn bản dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa vào. Nếu văn bản ngắn hơn, quá trình ngược lại sẽ diễn ra. 

## **Do Not Autofit**

Nếu bạn muốn một hộp văn bản hoặc hình dạng giữ nguyên kích thước bất kể thay đổi nội dung, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, đặt thuộc tính [autofit_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) thành `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Đoạn mã Python này cho thấy cách chỉ định rằng một hộp văn bản luôn giữ nguyên kích thước trong bản trình chiếu PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Khi văn bản quá dài so với hộp, nó sẽ tràn ra ngoài. 

## **Shrink Text on Overflow**

Nếu văn bản quá dài so với hộp, bạn có thể sử dụng tùy chọn **Shrink text on overflow** để chỉ định giảm kích thước và khoảng cách của văn bản sao cho vừa vào hộp. Để chỉ định cài đặt này, đặt thuộc tính [autofit_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) thành `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã Python này cho thấy cách chỉ định rằng văn bản sẽ bị thu nhỏ khi tràn trong bản trình chiếu PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản quá dài so với hộp. 

{{% /alert %}}

## **Wrap Text**

Nếu bạn muốn văn bản trong một hình dạng được tự động ngắt dòng bên trong hình khi văn bản vượt quá biên (chỉ chiều rộng) của hình, bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn phải đặt thuộc tính [wrap_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) thành `NullableBool.TRUE`. 

Đoạn mã Python này cho thấy cách sử dụng cài đặt Wrap Text trong bản trình chiếu PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Nếu bạn đặt thuộc tính `wrap_text` thành `NullableBool.FALSE` cho một hình dạng, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ kéo dài ra ngoài biên của hình trên một dòng duy nhất. 

{{% /alert %}}

## **FAQ**

**Các lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Padding (lề nội bộ) giảm diện tích khả dụng cho văn bản, vì vậy AutoFit sẽ kích hoạt sớm hơn — thu nhỏ phông chữ hoặc thay đổi kích thước hình sớm hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng ép buộc vẫn giữ nguyên, và AutoFit điều chỉnh kích thước phông và khoảng cách xung quanh chúng. Loại bỏ các ngắt dòng không cần thiết thường giảm mức độ AutoFit cần thu nhỏ văn bản.

**Thay đổi phông chữ chủ đề hoặc kích hoạt việc thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế bằng phông chữ có các chỉ số glyph khác nhau sẽ thay đổi chiều rộng/chiều cao văn bản, có thể làm thay đổi kích thước phông cuối cùng và cách ngắt dòng. Sau bất kỳ thay đổi hoặc thay thế phông nào, hãy kiểm tra lại các slide.