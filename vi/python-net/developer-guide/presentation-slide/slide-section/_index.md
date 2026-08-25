---
title: Quản lý các phần slide trong bản trình bày với Python
linktitle: Phần slide
type: docs
weight: 100
url: /vi/python-net/slide-section/
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
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho Python qua .NET: tạo, đổi tên, sắp xếp lại, lấy và xử lý các slide của phần trong các bản trình bày PPTX."
---
## **Giới thiệu**

Các phần (Sections) sắp xếp các slide liên tiếp thành các nhóm có tên mà không làm thay đổi nội dung slide. Với Aspose.Slides for Python qua .NET, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua thuộc tính [Presentation.sections](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sections/) .

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương logic;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- cần xử lý, di chuyển hoặc gộp các slide theo nhóm.

Chọn tên phần ngắn gọn mô tả mục đích của các slide được nhóm lại. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng API phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và Quản lý Các Phần**

Sử dụng [SectionCollection.add_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/add_section/) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định slide nào thuộc về phần dựa trên cấu trúc phần hiện tại của bản trình bày.

Cùng với [SectionCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/) , bạn cũng có thể:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- xóa chỉ định nghĩa phần bằng [SectionCollection.remove_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/remove_section/), mà vẫn giữ các slide của nó;
- xóa một phần và các slide của nó bằng [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- thêm một phần trống ở cuối bằng [SectionCollection.append_empty_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/append_empty_section/).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide và thêm một phần trống vào cuối:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần `Appendix` trống. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi tên Các Phần**

Để đổi tên một phần, đặt giá trị cho thuộc tính [Section.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/name/). Các slide và vị trí của phần vẫn không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Lấy các Slide từ Các Phần**

Thuộc tính [Presentation.sections](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sections/) trả về một [SectionCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/) mà bạn có thể duyệt qua. Đối với mỗi [Section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/), gọi [Section.get_slides_list_of_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/get_slides_list_of_section/) để lấy các slide hiện đang thuộc về nó. Phương thức này trả về một [SectionSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectionslidecollection/), cung cấp số lượng, truy cập theo chỉ mục và khả năng lặp.

Ví dụ sau tạo hai phần có nội dung và một phần trống, sau đó in ra [name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/started_from_slide/), số slide và số slide của mỗi phần. Nó sử dụng truy cập theo chỉ mục để đọc slide đầu tiên và vòng lặp `for` để xử lý mọi slide. Đối với phần trống, collection trả về có số lượng bằng không, không truy cập chỉ mục và việc lặp không thực hiện bước nào.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Không tự tính toán phạm vi của phần bằng cách dựa vào [Section.started_from_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/started_from_slide/), chỉ số slide và slide bắt đầu của phần tiếp theo.

Các chỉnh sửa cấu trúc có thể thay đổi cả các slide được trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide, xóa slide và xóa phần. Ví dụ tiếp theo gọi [Section.get_slides_list_of_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/get_slides_list_of_section/) sau mỗi thay đổi như vậy thay vì giữ giả định về giới hạn trước của phần.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Gọi [Section.get_slides_list_of_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/get_slides_list_of_section/) lại mỗi khi slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giúp quá trình xử lý tiếp theo luôn phù hợp với cấu trúc bản trình bày hiện tại.

Định dạng PPT (PowerPoint 97–2003) không lưu giữ siêu dữ liệu của phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn PPTX; việc chuyển sang PPT sẽ mất cấu trúc phần cần thiết cho việc lặp sau này.

## **FAQ**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, vì vậy việc nhóm các phần sẽ bị mất khi lưu thành .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị/ẩn. Để ẩn nội dung của nó, đặt thuộc tính [Slide.hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) cho mỗi slide trong phần đó.

**Làm sao tôi có thể tìm phần chứa một slide?**

Duyệt qua [Presentation.sections](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sections/), gọi [Section.get_slides_list_of_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/get_slides_list_of_section/) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không trống, [Section.started_from_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/started_from_slide/) trả về slide đầu tiên; đối với phần trống, nó trả về `None`.