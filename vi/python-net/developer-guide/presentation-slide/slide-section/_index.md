---
title: Quản lý các phần slide trong bài thuyết trình bằng Python
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
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tối ưu hóa các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho Python — tách, đổi tên và sắp xếp lại để cải thiện quy trình làm việc PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides cho Python, bạn có thể tổ chức một bài thuyết trình PowerPoint thành các phần nhóm các slide cụ thể.

Bạn có thể muốn tạo các phần để sắp xếp hoặc chia một bài thuyết trình thành các phần logic trong các tình huống sau:

- Khi bạn đang làm việc trên một bài thuyết trình lớn với một nhóm và cần giao một số slide cho các đồng nghiệp cụ thể.
- Khi bạn đang xử lý một bài thuyết trình có nhiều slide và cảm thấy khó quản lý hoặc chỉnh sửa tất cả cùng một lúc.

Lý tưởng nhất là tạo các phần nhóm các slide liên quan — những slide có chung chủ đề, nội dung hoặc mục đích — và đặt tên cho mỗi phần sao cho phản ánh rõ ràng nội dung của nó.

## **Tạo phần trong bài thuyết trình**

Để thêm một [Section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/) nhóm các slide trong một bài thuyết trình, Aspose.Slides cung cấp phương thức [add_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/add_section/). Phương thức này cho phép bạn chỉ định tên phần và slide bắt đầu của phần.

Ví dụ Python sau cho thấy cách tạo một phần trong bài thuyết trình:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Phần 1 kết thúc tại slide2; Phần 2 bắt đầu tại slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Thay đổi tên các phần**

Sau khi tạo một [Section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/) trong một bài thuyết trình PowerPoint, bạn có thể quyết định thay đổi tên của nó.

Ví dụ Python sau cho thấy cách đổi tên một phần trong bài thuyết trình:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ có thể bị ẩn. Một phần như một thực thể không có trạng thái "ẩn".

**Tôi có thể nhanh chóng tìm một phần dựa trên một slide và ngược lại, tìm slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bằng slide bắt đầu của nó; khi biết một slide, bạn có thể xác định phần mà slide đó thuộc về, và đối với một phần bạn có thể truy cập slide đầu tiên của nó.