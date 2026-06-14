---
title: Quản lý các phần slide trong bản trình bày bằng JavaScript
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/nodejs-java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tối ưu hoá các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho Node.js — tách, đổi tên và sắp xếp lại để cải thiện quy trình làm việc với PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides cho Node.js thông qua Java, bạn có thể sắp xếp một bản trình bày PowerPoint thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể.

Bạn có thể muốn tạo các phần và sử dụng chúng để sắp xếp hoặc chia các slide trong bản trình bày thành các phần logic trong các tình huống sau:

- Khi bạn đang làm việc trên một bản trình bày lớn với người khác hoặc một đội—và cần giao một số slide cho đồng nghiệp hoặc một số thành viên trong đội. 
- Khi bạn đang xử lý một bản trình bày có nhiều slide—và gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung cùng một lúc.

Lý tưởng nhất, bạn nên tạo một phần chứa các slide tương tự—các slide có điểm chung hoặc chúng có thể tồn tại trong một nhóm dựa trên một quy tắc—và đặt cho phần một tên mô tả các slide bên trong.

## **Tạo các Phần trong Bản Trình Bày**

Để thêm một phần sẽ chứa các slide trong bản trình bày, Aspose.Slides cho Node.js thông qua Java cung cấp phương thức [addSection()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) cho phép bạn chỉ định tên của phần bạn muốn tạo và slide mà phần bắt đầu.

Mã mẫu này cho bạn cách tạo một phần trong bản trình bày bằng JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 sẽ kết thúc tại newSlide2 và sau đó section2 sẽ bắt đầu
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay Đổi Tên Các Phần**

Sau khi bạn tạo một phần trong bản trình bày PowerPoint, bạn có thể quyết định thay đổi tên của nó.

Mã mẫu này cho bạn cách thay đổi tên một phần trong bản trình bày bằng JavaScript sử dụng Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ có thể được ẩn. Một phần như một thực thể không có trạng thái "ẩn".

**Tôi có thể nhanh chóng tìm một phần bằng một slide và ngược lại, slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bằng slide bắt đầu; với một slide bạn có thể xác định nó thuộc phần nào, và với một phần bạn có thể truy cập slide đầu tiên của nó.