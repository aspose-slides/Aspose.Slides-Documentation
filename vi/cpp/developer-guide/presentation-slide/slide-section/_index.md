---
title: Quản lý các phần Slide trong Bản trình bày bằng C++
linktitle: Phần Slide
type: docs
weight: 100
url: /vi/cpp/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Tối ưu hoá các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho C++ — tách, đổi tên và sắp xếp lại để cải thiện quy trình làm việc PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides for C++, bạn có thể tổ chức một PowerPoint Presentation thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể. 

Bạn có thể muốn tạo các phần và sử dụng chúng để tổ chức hoặc chia các slide trong một bản trình bày thành các phần logic trong các tình huống sau:

- Khi bạn đang làm việc trên một bản trình bày lớn với những người khác hoặc một nhóm—và bạn cần chỉ định một số slide cho một đồng nghiệp hoặc một số thành viên trong nhóm. 
- Khi bạn đang xử lý một bản trình bày có nhiều slide—and bạn gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung một lúc. 

Lý tưởng nhất, bạn nên tạo một phần chứa các slide có tính tương đồng—các slide có điểm chung hoặc có thể tồn tại trong một nhóm dựa trên một quy tắc—và đặt tên cho phần đó mô tả các slide bên trong. 

## **Tạo phần trong bản trình bày**

Để thêm một phần sẽ chứa các slide trong một bản trình bày, Aspose.Slides for C++ cung cấp phương thức AddSection cho phép bạn chỉ định tên của phần muốn tạo và slide mà phần bắt đầu. 

Mã mẫu sau cho bạn thấy cách tạo một phần trong bản trình bày bằng C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 sẽ kết thúc ở newSlide2 và sau đó section2 sẽ bắt đầu   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Thay đổi tên các phần**

Sau khi bạn tạo một phần trong PowerPoint presentation, bạn có thể quyết định thay đổi tên của nó. 

Mã mẫu sau cho bạn thấy cách thay đổi tên của một phần trong bản trình bày bằng C++ sử dụng Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, vì vậy việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ mới có thể bị ẩn. Một phần như một thực thể không có trạng thái "ẩn".

**Tôi có thể nhanh chóng tìm một phần dựa trên một slide và ngược lại, tìm slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bằng slide bắt đầu; nếu biết một slide, bạn có thể xác định phần mà slide đó thuộc về, và với một phần bạn có thể truy cập slide đầu tiên của nó.