---
title: Quản lý các phần slide trong bản trình bày bằng Python thông qua Java
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/python-java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- lấy slide của phần
- xử lý slide của phần
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho Python thông qua Java: tạo, đổi tên, sắp xếp lại, truy xuất và xử lý các slide của phần trong bản trình bày PPTX."
---
## **Giới thiệu**

Các phần tổ chức các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides cho Python thông qua Java, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSections).

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương hợp lý;
- các nhóm slide khác nhau được giao cho các cộng sự khác nhau;
- các slide cần được xử lý, di chuyển hoặc hợp nhất dưới dạng nhóm.

Chọn tên phần ngắn gọn mô tả mục đích của các slide được nhóm lại. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng các API của phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và Quản lý Các Phần**

Sử dụng [SectionCollection.addSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/#addSection) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định các slide thuộc phần dựa trên cấu trúc phần hiện tại của bản trình bày.

Cùng với [SectionCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/) bạn còn có thể:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [reorderSectionWithSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- xóa chỉ định nghĩa phần bằng [removeSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/#removeSection), giữ lại các slide của nó;
- xóa một phần và các slide của nó bằng [removeSectionWithSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- thêm một phần trống ở cuối bằng [appendEmptySection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide và thêm một phần trống:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần trống `Appendix`. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi Tên Các Phần**

Để đổi tên một phần, gọi phương thức [Section.setName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#setName) của nó. Các slide và vị trí của phần không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Lấy Các Slide Từ Các Phần**

Phương thức [Presentation.getSections](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSections) trả về một [SectionCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectioncollection/) mà bạn có thể duyệt. Đối với mỗi [Section](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/), gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getSlidesListOfSection) để lấy các slide hiện đang thuộc về nó. Phương thức này trả về một [SectionSlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectionslidecollection/), cung cấp số lượng, truy cập theo chỉ mục và khả năng lặp.

Ví dụ sau tạo hai phần có nội dung và một phần trống, sau đó in ra [name](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getStartedFromSlide), số lượng slide và số thứ tự slide của mỗi phần. Nó sử dụng [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectionslidecollection/#get_Item) để đọc slide đầu tiên và một câu lệnh `for` để xử lý mọi slide. Đối với phần trống, collection trả về có kích thước bằng không, phương thức không được gọi và vòng lặp không thực hiện bất kỳ thao tác nào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Không tính toán phạm vi của phần một cách thủ công từ [Section.getStartedFromSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getStartedFromSlide), chỉ số slide và slide bắt đầu của phần kế tiếp.

Các chỉnh sửa cấu trúc có thể thay đổi cả các slide trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide của nó, xóa slide và xóa phần. Ví dụ tiếp theo gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getSlidesListOfSection) sau mỗi thay đổi như vậy thay vì giữ các giả định về giới hạn trước đây của phần.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Gọi lại [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getSlidesListOfSection) bất cứ khi nào slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giúp quá trình xử lý tiếp theo luôn phù hợp với cấu trúc hiện tại của bản trình bày.

Định dạng PPT (PowerPoint 97–2003) không lưu giữ siêu dữ liệu của phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn như PPTX; việc chuyển đổi sang PPT sẽ loại bỏ cấu trúc phần cần thiết cho việc lặp lại sau này.

## **Câu Hỏi Thường Gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể “ẩn” toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị. Để ẩn nội dung của nó, hãy gọi [Slide.setHidden](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#setHidden) cho từng slide trong phần.

**Làm thế nào để tìm phần chứa một slide cụ thể?**

Duyệt qua collection trả về bởi [Presentation.getSections](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSections), gọi [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getSlidesListOfSection) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không rỗng, [Section.getStartedFromSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/section/#getStartedFromSlide) trả về slide đầu tiên; đối với phần rỗng, nó trả về `None`.