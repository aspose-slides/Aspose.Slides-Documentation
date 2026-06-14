---
title: Quản lý các Phần Slide trong Bản Trình Bày bằng .NET
linktitle: Phần Slide
type: docs
weight: 100
url: /vi/net/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tối ưu hóa các phần slide trong PowerPoint và OpenDocument với Aspose.Slides cho .NET — tách, đổi tên và sắp xếp lại để cải thiện quy trình làm việc với PPTX và ODP."
---
## **Giới thiệu**

Với Aspose.Slides for .NET, bạn có thể tổ chức một bản trình bày PowerPoint thành các phần. Bạn có thể tạo các phần chứa các slide cụ thể. 

Bạn có thể muốn tạo các phần và sử dụng chúng để tổ chức hoặc chia các slide trong một bản trình bày thành các phần logic trong các tình huống sau:

- Khi bạn đang làm việc trên một bản trình bày lớn với người khác hoặc một đội—và bạn cần giao một số slide cho đồng nghiệp hoặc một số thành viên trong đội. 
- Khi bạn đang xử lý một bản trình bày có nhiều slide—and bạn gặp khó khăn trong việc quản lý hoặc chỉnh sửa toàn bộ nội dung cùng một lúc.

Lý tưởng nhất, bạn nên tạo một phần chứa các slide tương tự—các slide có điểm chung hoặc có thể tồn tại trong một nhóm dựa trên một quy tắc—và đặt tên cho phần sao cho mô tả các slide bên trong. 

## **Tạo Phần trong Bài Thuyết Trình**

Để thêm một phần chứa các slide trong bản trình bày, Aspose.Slides for .NET cung cấp phương thức AddSection cho phép bạn chỉ định tên của phần muốn tạo và slide mà phần bắt đầu. 

Mã mẫu này cho bạn thấy cách tạo một phần trong bản trình bày bằng C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 sẽ kết thúc tại newSlide2 và sau đó section2 sẽ bắt đầu   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Thay đổi Tên các Phần**

Sau khi bạn tạo một phần trong bản trình bày PowerPoint, bạn có thể quyết định thay đổi tên của nó. 

Mã mẫu này cho bạn thấy cách thay đổi tên của một phần trong bản trình bày bằng C# sử dụng Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu của phần, vì vậy việc nhóm phần sẽ bị mất khi lưu thành .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Chỉ các slide riêng lẻ có thể bị ẩn. Một phần như một thực thể không có trạng thái “ẩn”.

**Tôi có thể nhanh chóng tìm một phần dựa trên một slide và ngược lại, tìm slide đầu tiên của một phần không?**

Có. Một phần được xác định duy nhất bởi slide bắt đầu của nó; với một slide bạn có thể xác định phần mà nó thuộc về, và với một phần bạn có thể truy cập slide đầu tiên của nó.