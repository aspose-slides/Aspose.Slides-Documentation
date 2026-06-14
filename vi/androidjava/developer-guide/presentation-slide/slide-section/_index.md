---
title: Quản lý các phần slide trong bản thuyết trình trên Android
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/androidjava/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tối ưu hoá các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho Android qua Java—chia, đổi tên và sắp xếp lại để nâng cao quy trình làm việc với PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides cho Android thông qua Java, bạn có thể tổ chức một bản thuyết trình PowerPoint thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể.

Bạn có thể muốn tạo các phần và sử dụng chúng để tổ chức hoặc chia các slide trong một bản thuyết trình thành các phần hợp lý trong các tình huống sau:

- Khi bạn đang làm việc trên một bản thuyết trình lớn với người khác hoặc một nhóm — và bạn cần chỉ định một số slide cho đồng nghiệp hoặc một số thành viên trong nhóm. 
- Khi bạn đang xử lý một bản thuyết trình có nhiều slide — và bạn gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung cùng một lúc.

Lý tưởng nhất, bạn nên tạo một phần chứa các slide tương tự — các slide có điểm chung hoặc có thể tồn tại trong một nhóm dựa trên một quy tắc — và đặt tên cho phần sao cho mô tả các slide bên trong.

## **Tạo Các Phần Trong Bản Thuyết Trình**

Để thêm một phần chứa các slide trong một bản thuyết trình, Aspose.Slides cho Android thông qua Java cung cấp phương thức [addSection()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) cho phép bạn chỉ định tên của phần muốn tạo và slide mà phần bắt đầu từ đó.

Đoạn mã mẫu này cho bạn thấy cách tạo một phần trong bản thuyết trình bằng Java:

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

Sau khi bạn tạo một phần trong bản thuyết trình PowerPoint, bạn có thể quyết định thay đổi tên của nó. 

Đoạn mã mẫu này cho bạn thấy cách thay đổi tên của một phần trong bản thuyết trình bằng Java sử dụng Aspose.Slides:

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

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, vì vậy việc nhóm các phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ có thể bị ẩn. Một phần như một thực thể không có trạng thái "ẩn".

**Tôi có thể nhanh chóng tìm một phần dựa trên một slide và ngược lại, slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bằng slide bắt đầu; dựa trên một slide, bạn có thể xác định phần mà nó thuộc về, và đối với một phần, bạn có thể truy cập slide đầu tiên của nó.