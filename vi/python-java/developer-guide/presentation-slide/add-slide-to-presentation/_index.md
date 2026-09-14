---
title: Thêm Slide vào Bản Thuyết Trình trong Python
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/python-java/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản thuyết trình
- Python
- Aspose.Slides
description: "Dễ dàng thêm slide vào các bản PowerPoint và OpenDocument của bạn bằng Aspose.Slides for Python via Java—chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Overview**

Aspose.Slides cho phép bạn thêm slide vào các bản thuyết trình PowerPoint một cách lập trình. Một bản thuyết trình chứa các slide **master/layout** và các slide **normal**, các slide bình thường được sắp xếp theo chỉ số bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản thuyết trình không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide mới thêm, và lưu bản thuyết trình đã cập nhật. Nó cũng đề cập đến các điểm liên quan như chèn slide ở vị trí cụ thể, sử dụng layout, và hiểu slide trống có trong một bản thuyết trình mới tạo.

## **Add a Slide to a Presentation**

Trước khi thảo luận cách thêm slide vào các tệp bản thuyết trình, hãy xem lại một số thông tin về slide. Mỗi tệp bản thuyết trình PowerPoint chứa các slide **master/layout** và **normal**. Một tệp bản thuyết trình chứa ít nhất một slide. Các tệp không có slide không được Aspose.Slides for Python via Java hỗ trợ. Mỗi slide có một ID duy nhất, và tất cả các slide bình thường được sắp xếp theo thứ tự được chỉ định bằng chỉ số bắt đầu từ 0.

Aspose.Slides for Python via Java cho phép các nhà phát triển thêm slide trống vào bản thuyết trình của họ. Để thêm một slide trống vào bản thuyết trình, thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy một tham chiếu tới đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) bằng cách sử dụng phương thức [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Thêm một slide trống vào cuối bộ sưu tập slide của bản thuyết trình bằng cách gọi phương thức [addEmptySlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addEmptySlide) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/).
- Thực hiện một số công việc với slide trống vừa được thêm.
- Cuối cùng, ghi tệp bản thuyết trình bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản thuyết trình.
presentation = Presentation()
try:
    # Lấy bộ sưu tập slide.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Thêm một slide trống vào bộ sưu tập slide.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Thực hiện một số công việc trên slide vừa được thêm.

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone), do đó bạn có thể thêm slide tại chỉ mục yêu cầu thay vì chỉ ở cuối.

**Are the theme/styles preserved when adding a slide based on a layout?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Which slide is present in a new "empty" presentation before adding slides?**

Một bản thuyết trình mới tạo đã chứa sẵn một slide trống với chỉ số 0. Điều này quan trọng khi tính toán chỉ số chèn.

**How do I choose the "right" layout for a new slide if the master has many options?**

Thông thường, chọn [LayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidelayouttype/)). Nếu không có layout như vậy, bạn có thể [thêm vào master](/slides/vi/python-java/slide-layout/) và sau đó sử dụng nó.