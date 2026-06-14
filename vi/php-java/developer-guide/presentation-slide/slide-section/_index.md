---
title: Quản lý các phần slide trong bản trình chiếu bằng PHP
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/php-java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tối ưu hoá các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho PHP thông qua Java — tách, đổi tên và sắp xếp lại để cải thiện quy trình làm việc PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides cho PHP thông qua Java, bạn có thể sắp xếp một Bản trình chiếu PowerPoint thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể.

Bạn có thể muốn tạo các phần và sử dụng chúng để tổ chức hoặc chia các slide trong một bản trình chiếu thành các phần logic trong các tình huống sau:

- Khi bạn đang làm việc trên một bản trình chiếu lớn cùng với những người khác hoặc một nhóm — và bạn cần giao một số slide cho đồng nghiệp hoặc một số thành viên trong nhóm. 
- Khi bạn đang xử lý một bản trình chiếu chứa nhiều slide — và bạn gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung cùng một lúc.

Lý tưởng nhất, bạn nên tạo một phần chứa các slide tương tự — các slide có điểm chung hoặc có thể tồn tại trong một nhóm dựa trên một quy tắc — và đặt tên cho phần mô tả các slide bên trong.

## **Tạo Phần trong Bản Trình Chiếu**

Để thêm một phần chứa các slide trong bản trình chiếu, Aspose.Slides cho PHP thông qua Java cung cấp phương thức [addSection()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sectioncollection/#addSection) cho phép bạn chỉ định tên của phần mà bạn muốn tạo và slide mà phần đó bắt đầu.

Mã mẫu này cho bạn thấy cách tạo một phần trong bản trình chiếu :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 sẽ kết thúc tại newSlide2 và sau đó section2 sẽ bắt đầu

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thay Đổi Tên Các Phần**

Sau khi bạn tạo một phần trong bản trình chiếu PowerPoint, bạn có thể quyết định thay đổi tên của nó. 

Mã mẫu này cho bạn thấy cách thay đổi tên của một phần trong bản trình chiếu bằng cách sử dụng Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ có thể bị ẩn. Một phần dưới dạng một thực thể không có trạng thái "ẩn".

**Tôi có thể nhanh chóng tìm một phần bằng một slide và ngược lại, tìm slide đầu tiên của một phần không?**

Có. Một phần được định nghĩa duy nhất bởi slide bắt đầu; dựa trên một slide bạn có thể xác định phần nào nó thuộc về, và đối với một phần bạn có thể truy cập slide đầu tiên của nó.