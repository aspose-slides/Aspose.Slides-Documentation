---
title: Quản lý các phần Slide trong Bản trình chiếu bằng Java
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tối ưu hoá các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho Java — chia nhỏ, đổi tên và sắp xếp lại để cải thiện quy trình làm việc PPTX và ODP."
---
## **Introduction**

Với Aspose.Slides for Java, bạn có thể sắp xếp một bản trình chiếu PowerPoint thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể.

Bạn có thể muốn tạo các phần và sử dụng chúng để sắp xếp hoặc chia các slide trong bản trình chiếu thành các phần logic trong những tình huống sau:
- Khi bạn đang làm việc trên một bản trình chiếu lớn cùng với người khác hoặc một nhóm—và bạn cần chỉ định một số slide cho đồng nghiệp hoặc một số thành viên trong nhóm.
- Khi bạn đang xử lý một bản trình chiếu có nhiều slide—và bạn gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung một cách đồng thời.

Lý tưởng nhất, bạn nên tạo một phần chứa các slide giống nhau—các slide có điểm chung hoặc có thể tồn tại trong một nhóm dựa trên một quy tắc—và đặt cho phần một tên mô tả các slide bên trong.

## **Tạo Các Phần trong Bản Trình Chiếu**

Để thêm một phần sẽ chứa các slide trong bản trình chiếu, Aspose.Slides for Java cung cấp phương thức [addSection()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) cho phép bạn chỉ định tên của phần mà bạn muốn tạo và slide mà phần đó bắt đầu.

Các đoạn mã mẫu sau cho bạn thấy cách tạo một phần trong bản trình chiếu bằng Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 sẽ kết thúc tại newSlide2 và sau đó section2 sẽ bắt đầu   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay Đổi Tên Các Phần**

Sau khi bạn tạo một phần trong bản trình chiếu PowerPoint, bạn có thể quyết định thay đổi tên của nó.

Các đoạn mã mẫu sau cho bạn thấy cách thay đổi tên của một phần trong bản trình chiếu bằng Java sử dụng Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Liệu các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ có thể ẩn các slide riêng lẻ. Một phần như một thực thể không có trạng thái “ẩn”.

**Tôi có thể nhanh chóng tìm một phần dựa trên một slide và ngược lại, tìm slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bởi slide bắt đầu; dựa trên một slide, bạn có thể xác định phần nào nó thuộc về, và với một phần bạn có thể truy cập slide đầu tiên của nó.